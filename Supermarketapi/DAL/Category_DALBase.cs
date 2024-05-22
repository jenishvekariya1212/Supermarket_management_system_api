using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Supermarketapi.Models;
using System.Data;
using System.Data.Common;

namespace Supermarketapi.DAL
{
    public class Category_DALBase : DAL_Helpercs
    {

        #region PR_Category_SelectAll
        public List<CategoryModel> PR_Category_SelectAll()
        {
            try
            {

                SqlDatabase sqldb = new SqlDatabase(Connstring);
                DbCommand cmd = sqldb.GetStoredProcCommand("PR_Category_SelectAll");
                List<CategoryModel> categoryModels = new List<CategoryModel>();
                using (IDataReader dr = sqldb.ExecuteReader(cmd)) {

                    while (dr.Read())
                    {
                        CategoryModel categoryModel = new CategoryModel();
                        categoryModel.CategoryID = Convert.ToInt32(dr["CategoryID"]);
                        categoryModel.CategoryName = dr["CategoryName"].ToString();
                        categoryModel.CategoryDescription = dr["CategoryDescription"].ToString();
                        categoryModels.Add(categoryModel);
                    }

                }
                return categoryModels;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion


        #region PR_Category_SelectByPk
        public CategoryModel PR_Category_SelectByPk(int CategoryID)
        {
            try
            {

                SqlDatabase sqldb = new SqlDatabase(Connstring);
                DbCommand cmd = sqldb.GetStoredProcCommand("PR_Category_SelectByPk");
                sqldb.AddInParameter(cmd, "@CategoryID", SqlDbType.Int, CategoryID);
                CategoryModel categoryModel = new CategoryModel();
                using (IDataReader dr = sqldb.ExecuteReader(cmd))
                {

                    while (dr.Read())
                    {

                        categoryModel.CategoryID = Convert.ToInt32(dr["CategoryID"]);
                        categoryModel.CategoryName = dr["CategoryName"].ToString();
                        categoryModel.CategoryDescription = dr["CategoryDescription"].ToString();

                    }

                }
                return categoryModel;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion


        #region PR_Category_DeleteByPk
        public bool PR_Category_DeleteByPk(int CategoryID)
        {
            try
            {
                SqlDatabase sqldb = new SqlDatabase(Connstring);
                DbCommand cmd = sqldb.GetStoredProcCommand("PR_Category_DeleteByPk");
                sqldb.AddInParameter(cmd,"@CategoryID", SqlDbType.Int,CategoryID);

                if(Convert.ToBoolean(sqldb.ExecuteNonQuery(cmd)))
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


        #region PR_Category_Insert
        public bool PR_Category_Insert(CategoryModel categoryModel)
        {
            try
            {
                SqlDatabase sqldb = new SqlDatabase(Connstring);
                DbCommand cmd = sqldb.GetStoredProcCommand("PR_Category_Insert");
                sqldb.AddInParameter(cmd, "@CategoryName", SqlDbType.VarChar, categoryModel.CategoryName);
                sqldb.AddInParameter(cmd, "@CategoryDescription", SqlDbType.VarChar, categoryModel.CategoryDescription);
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


        #region PR_Category_UpdateByPk
        public bool PR_Category_UpdateByPk (int CategoryID, CategoryModel categoryModel)
        {
            try
            {
                SqlDatabase sqldb = new SqlDatabase(Connstring);
                DbCommand cmd = sqldb.GetStoredProcCommand("PR_Category_UpdateByPk");
                sqldb.AddInParameter(cmd, "@CategoryID", SqlDbType.VarChar, categoryModel.CategoryID);
                sqldb.AddInParameter(cmd, "@CategoryName", SqlDbType.VarChar, categoryModel.CategoryName);
                sqldb.AddInParameter(cmd, "@CategoryDescription", SqlDbType.VarChar, categoryModel.CategoryDescription);
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


        #region PR_Category_Exportaspdf
        public List<CategoryModel> PR_Category_Exportaspdf()
        {
            try
            {

                SqlDatabase sqldb = new SqlDatabase(Connstring);
                DbCommand cmd = sqldb.GetStoredProcCommand("PR_Category_Exportaspdf");
                List<CategoryModel> categoryModels = new List<CategoryModel>();
                using (IDataReader dr = sqldb.ExecuteReader(cmd))
                {

                    while (dr.Read())
                    {
                        CategoryModel categoryModel = new CategoryModel();
                        categoryModel.CategoryID = Convert.ToInt32(dr["CategoryID"]);
                        categoryModel.CategoryName = dr["CategoryName"].ToString();
                        categoryModel.CategoryDescription = dr["CategoryDescription"].ToString();
                        categoryModels.Add(categoryModel);
                    }

                }
                return categoryModels;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

    }
}
