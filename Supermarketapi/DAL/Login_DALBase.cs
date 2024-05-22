using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Supermarketapi.Models;
using System.Data.Common;
using System.Data;
using System.Collections;

namespace Supermarketapi.DAL
{
    public class Login_DALBase:DAL_Helpercs
    {
        #region PR_Category_SelectByPk
        public LoginModel PR_Login_SelectByUserPass(string UserName,string Password)
        {
            try
            {

                SqlDatabase sqldb = new SqlDatabase(Connstring);
                DbCommand cmd = sqldb.GetStoredProcCommand("PR_Login_SelectByUserPass");
                sqldb.AddInParameter(cmd, "@UserName", SqlDbType.VarChar, UserName);
                sqldb.AddInParameter(cmd, "@Password", SqlDbType.VarChar, Password);
                LoginModel loginModel = new LoginModel();
                using (IDataReader dr = sqldb.ExecuteReader(cmd))
                {
                    dr.Read();


                        loginModel.UserID = Convert.ToInt32(dr["UserID"].ToString());
                        loginModel.FirstName = dr["FirstName"].ToString();
                        loginModel.LastName = dr["LastName"].ToString();
                        loginModel.UserName = dr["UserName"].ToString();
                        loginModel.Password = dr["Password"].ToString();
                        loginModel.Email = dr["Email"].ToString();
                        loginModel.ISActive = Convert.ToBoolean(dr["ISActive"].ToString()); 

                }
                return loginModel;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion


        #region PR_Category_Insert
        public bool PR_Register_Insert(LoginModel loginModel)
        {
            try
            {
                SqlDatabase sqldb = new SqlDatabase(Connstring);
                DbCommand cmd = sqldb.GetStoredProcCommand("PR_Register_Insert");
                sqldb.AddInParameter(cmd, "@FirstName", SqlDbType.VarChar, loginModel.FirstName);
                sqldb.AddInParameter(cmd, "@LastName", SqlDbType.VarChar, loginModel.LastName);
                sqldb.AddInParameter(cmd, "@UserName", SqlDbType.VarChar, loginModel.UserName);
                sqldb.AddInParameter(cmd, "@Password", SqlDbType.VarChar, loginModel.Password);
                sqldb.AddInParameter(cmd, "@Email", SqlDbType.VarChar, loginModel.Email);
                sqldb.AddInParameter(cmd, "@ISActive", SqlDbType.VarChar, loginModel.ISActive);

                if (Convert.ToBoolean(sqldb.ExecuteNonQuery(cmd)))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        #endregion
    }
}
