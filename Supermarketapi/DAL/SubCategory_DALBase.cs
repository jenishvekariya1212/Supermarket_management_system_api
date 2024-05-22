using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Supermarketapi.Models;
using System.Data.Common;
using System.Data;

namespace Supermarketapi.DAL
{
    public class SubCategory_DALBase:DAL_Helpercs
    {
        #region PR_SubCategory_SelectAll
        public List<SubCategoryModel> PR_SubCategory_SelectAll()
        {
            try
            {

                SqlDatabase sqldb = new SqlDatabase(Connstring);
                DbCommand cmd = sqldb.GetStoredProcCommand("PR_SubCategory_SelectAll");
                List<SubCategoryModel> categoryModels = new List<SubCategoryModel>();
                using (IDataReader dr = sqldb.ExecuteReader(cmd))
                {

                    while (dr.Read())
                    {
                        SubCategoryModel categoryModel = new SubCategoryModel();
                        categoryModel.SubCategoryID = Convert.ToInt32(dr["SubCategoryID"]);
                        categoryModel.CategoryName = dr["CategoryName"].ToString();
                        categoryModel.SubCategoryName = dr["SubCategoryName"].ToString();
                        categoryModel.SubCategoryImage = dr["SubCategoryImage"].ToString();
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

        #region PR_CategoryDropDownList
        public List<Categorydropdown> PR_CategoryDropDownList()
        {
            try
            {

                SqlDatabase sqldb = new SqlDatabase(Connstring);
                DbCommand cmd = sqldb.GetStoredProcCommand("PR_CategoryDropDownList");
                List<Categorydropdown> categoryModels = new List<Categorydropdown>();
                using (IDataReader dr = sqldb.ExecuteReader(cmd))
                {

                    while (dr.Read())
                    {
                        Categorydropdown categorydropdown = new Categorydropdown();
                        categorydropdown.CategoryID = Convert.ToInt32(dr["CategoryID"]);
                        categorydropdown.CategoryName = dr["CategoryName"].ToString();
                        
                        categoryModels.Add(categorydropdown);
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

        #region PR_SubCategory_SelectByPk
        public SubCategoryModel PR_SubCategory_SelectByPk(int SubCategoryID)
        {
            try
            {

                SqlDatabase sqldb = new SqlDatabase(Connstring);
                DbCommand cmd = sqldb.GetStoredProcCommand("PR_SubCategory_SelectByPk");
                sqldb.AddInParameter(cmd, "@SubCategoryID", SqlDbType.Int, SubCategoryID);
              
                SubCategoryModel subCategoryModel = new SubCategoryModel();
                using (IDataReader dr = sqldb.ExecuteReader(cmd))
                {

                    while (dr.Read())
                    {

                        subCategoryModel.SubCategoryID = Convert.ToInt32(dr["SubCategoryID"]);
                        subCategoryModel.CategoryID = Convert.ToInt32(dr["CategoryID"]);
                        subCategoryModel.SubCategoryName = dr["SubCategoryName"].ToString();
                        subCategoryModel.SubCategoryImage = dr["SubCategoryImage"].ToString();

                    }

                }
                return subCategoryModel;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region PR_SubCategory_DeleteByPk
        public bool PR_SubCategory_DeleteByPk(int SubCategoryID)
        {
            try
            {
                SqlDatabase sqldb = new SqlDatabase(Connstring);
                DbCommand cmd = sqldb.GetStoredProcCommand("PR_SubCategory_DeleteByPk");
                sqldb.AddInParameter(cmd, "@SubCategoryID", SqlDbType.Int, SubCategoryID);

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

        #region PR_SubCategory_Insert
        public bool PR_SubCategory_Insert(SubCategoryModel subCategoryModel)
        {
            try
            {
                SqlDatabase sqldb = new SqlDatabase(Connstring);
                DbCommand cmd = sqldb.GetStoredProcCommand("PR_SubCategory_Insert");
                sqldb.AddInParameter(cmd, "@CategoryID", SqlDbType.Int, subCategoryModel.CategoryID);
                sqldb.AddInParameter(cmd, "@SubCategoryName", SqlDbType.VarChar, subCategoryModel.SubCategoryName);
                sqldb.AddInParameter(cmd, "@SubCategoryImage", SqlDbType.VarChar, subCategoryModel.SubCategoryImage);
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



        /*#region PR_SubCategory_Insert
        public bool PR_SubCategory_Insert(SubCategoryModel subCategoryModel)
        {
            try
            {
                SqlDatabase sqldb = new SqlDatabase(Connstring);
                DbCommand cmd = sqldb.GetStoredProcCommand("PR_SubCategory_Insert");
                sqldb.AddInParameter(cmd, "@CategoryID", SqlDbType.Int, subCategoryModel.CategoryID);
                sqldb.AddInParameter(cmd, "@SubCategoryName", SqlDbType.VarChar, subCategoryModel.SubCategoryName);

                // If an image is provided, save it to the server and store the path in the database
                if (subCategoryModel.SubCategoryImageFile != null)
                {
                    string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "images", subCategoryModel.SubCategoryImageFile.FileName);
                    using (var stream = new FileStream(imagePath, FileMode.Create))
                    {
                        subCategoryModel.SubCategoryImageFile.CopyTo(stream);
                    }
                    sqldb.AddInParameter(cmd, "@SubCategoryImage", SqlDbType.VarChar, subCategoryModel.SubCategoryImageFile.FileName);
                }
                else
                {
                    // If no image is provided, use a default image path
                    sqldb.AddInParameter(cmd, "@SubCategoryImage", SqlDbType.VarChar, "default-image.jpg");
                }

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
        #endregion*/




        /*   #region PR_SubCategory_UpdateByPk
           public bool PR_SubCategory_UpdateByPk(int SubCategoryID, SubCategoryModel subCategoryModel)
           {
               try
               {
                   SqlDatabase sqldb = new SqlDatabase(Connstring);
                   DbCommand cmd = sqldb.GetStoredProcCommand("PR_SubCategory_UpdateByPk");
                   sqldb.AddInParameter(cmd, "@SubCategoryID", SqlDbType.Int, subCategoryModel.SubCategoryID);
                   sqldb.AddInParameter(cmd, "@SubCategoryName", SqlDbType.VarChar, subCategoryModel.SubCategoryName);
                   sqldb.AddInParameter(cmd, "@CategoryID", SqlDbType.Int, subCategoryModel.CategoryID);

                   // If an image is provided, save it to the server and store the path in the database
                   if (subCategoryModel.SubCategoryImageFile != null)
                   {
                       string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "images", subCategoryModel.SubCategoryImageFile.FileName);
                       using (var stream = new FileStream(imagePath, FileMode.Create))
                       {
                           subCategoryModel.SubCategoryImageFile.CopyTo(stream);
                       }
                       sqldb.AddInParameter(cmd, "@SubCategoryImage", SqlDbType.VarChar, subCategoryModel.SubCategoryImageFile.FileName);
                   }
                   else
                   {
                       // If no image is provided, keep the existing image path
                       var existingSubCategory = PR_SubCategory_SelectByPk(SubCategoryID);
                       sqldb.AddInParameter(cmd, "@SubCategoryImage", SqlDbType.VarChar, existingSubCategory.SubCategoryImage);
                   }

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
               #endregion*/

        #region PR_SubCategory_UpdateByPk
        public bool PR_SubCategory_UpdateByPk(int SubCategoryID, SubCategoryModel subCategoryModel)
        {
            try
            {
                SqlDatabase sqldb = new SqlDatabase(Connstring);
                DbCommand cmd = sqldb.GetStoredProcCommand("PR_SubCategory_UpdateByPk");
                sqldb.AddInParameter(cmd, "@SubCategoryID", SqlDbType.Int, subCategoryModel.SubCategoryID);
                sqldb.AddInParameter(cmd, "@SubCategoryName", SqlDbType.VarChar, subCategoryModel.SubCategoryName);
                sqldb.AddInParameter(cmd, "@SubCategoryImage", SqlDbType.VarChar, subCategoryModel.SubCategoryImage);
                sqldb.AddInParameter(cmd, "@CategoryID", SqlDbType.Int, subCategoryModel.CategoryID);
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



        #region PR_SubCategory_Exportaspdf
        public List<SubCategoryModel> PR_SubCategory_Exportaspdf()
        {
            try
            {

                SqlDatabase sqldb = new SqlDatabase(Connstring);
                DbCommand cmd = sqldb.GetStoredProcCommand("PR_SubCategory_Exportaspdf");
                List<SubCategoryModel> categoryModels = new List<SubCategoryModel>();
                using (IDataReader dr = sqldb.ExecuteReader(cmd))
                {

                    while (dr.Read())
                    {
                        SubCategoryModel categoryModel = new SubCategoryModel();
                        categoryModel.SubCategoryID = Convert.ToInt32(dr["SubCategoryID"]);
                        categoryModel.CategoryName = dr["CategoryName"].ToString();
                        categoryModel.SubCategoryName = dr["SubCategoryName"].ToString();
                        categoryModel.SubCategoryImage = dr["SubCategoryImage"].ToString();
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


		#region PR_SelectByCategory
		public List<SubCategoryModel> PR_SelectByCategory(int CategoryID)
		{
			try
			{

				SqlDatabase sqldb = new SqlDatabase(Connstring);
				DbCommand cmd = sqldb.GetStoredProcCommand("PR_SelectByCategory");
				sqldb.AddInParameter(cmd, "@CategoryID", SqlDbType.Int, CategoryID);
				List<SubCategoryModel> subCategoryModels = new List<SubCategoryModel>();
				using (IDataReader dr = sqldb.ExecuteReader(cmd))
				{

					while (dr.Read())
					{
						SubCategoryModel subCategoryModel = new SubCategoryModel();
						subCategoryModel.SubCategoryID = Convert.ToInt32(dr["SubCategoryID"]);
						subCategoryModel.CategoryID = Convert.ToInt32(dr["CategoryID"]);
						subCategoryModel.SubCategoryName = dr["SubCategoryName"].ToString();
						subCategoryModel.SubCategoryImage = dr["SubCategoryImage"].ToString();
                        subCategoryModels.Add(subCategoryModel);

					}

				}
				return subCategoryModels;
			}
			catch (Exception ex)
			{
				return null;
			}
		}
		#endregion

	}
}
