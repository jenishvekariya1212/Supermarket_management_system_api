using Supermarketapi.DAL;
using Supermarketapi.Models;

namespace Supermarketapi.BAL
{
    public class Login_BALBase
    {
        #region PR_Category_SelectByPk
        public LoginModel PR_Login_SelectByUserPass(string UserName,string Password)
        {
            try
            {
                Login_DALBase category_DAL = new Login_DALBase();
                LoginModel categoryModels = category_DAL.PR_Login_SelectByUserPass(UserName,Password);
                return categoryModels;
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
                Login_DALBase category_DAL = new Login_DALBase();

                if (category_DAL.PR_Register_Insert(loginModel))
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
