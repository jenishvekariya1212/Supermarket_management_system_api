using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Supermarketapi.Models;
using System.Data.Common;
using System.Data;
using Microsoft.VisualBasic;

namespace Supermarketapi.DAL
{
    public class Product_DALBase:DAL_Helpercs
    {
     
        #region PR_Product_SelectAll
        public List<ProductModel> PR_Product_SelectAll()
        {
            try
            {

                SqlDatabase sqldb = new SqlDatabase(Connstring);
                DbCommand cmd = sqldb.GetStoredProcCommand("PR_Product_SelectAll");
                List<ProductModel> productModels = new List<ProductModel>();
                using (IDataReader dr = sqldb.ExecuteReader(cmd))
                {

                    while (dr.Read())
                    {
                        ProductModel productModel = new ProductModel();
                        productModel.ProductID = Convert.ToInt32(dr["ProductID"]);
                        productModel.ProductName = dr["ProductName"].ToString();
                        productModel.CategoryName = dr["CategoryName"].ToString();
                        productModel.SubCategoryName = dr["SubCategoryName"].ToString();
                        productModel.ProductImage = dr["ProductImage"].ToString();
                        productModel.ProductQuantity = Convert.ToInt32(dr["ProductQuantity"]);
                        productModel.ProductPrice = Convert.ToDecimal(dr["ProductPrice"]);
                        productModel.ProductExpiryDate = Convert.ToDateTime(dr["ProductExpiryDate"]);
                        productModel.Created = Convert.ToDateTime(dr["Created"]);
                        productModel.Modified = Convert.ToDateTime(dr["Modified"]);
                        productModels.Add(productModel);
                    }

                }
                return productModels;
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


        #region PR_SubCategoryDropdownList
        public List<SubcategoryDropDown> PR_SubCategoryDropdownList()
        {
            try
            {

                SqlDatabase sqldb = new SqlDatabase(Connstring);
                DbCommand cmd = sqldb.GetStoredProcCommand("PR_SubCategoryDropdownList");
                List<SubcategoryDropDown> subcategoryModels = new List<SubcategoryDropDown>();
                using (IDataReader dr = sqldb.ExecuteReader(cmd))
                {

                    while (dr.Read())
                    {
                        SubcategoryDropDown subcategoryDropDown = new SubcategoryDropDown();
                        subcategoryDropDown.SubCategoryID = Convert.ToInt32(dr["SubCategoryID"]);
                        subcategoryDropDown.SubCategoryName = dr["SubCategoryName"].ToString();

                        subcategoryModels.Add(subcategoryDropDown);
                    }

                }
                return subcategoryModels;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion


        #region PR_Product_Cascading
        public List<SubCategoryModel> PR_Product_Cascading (int CategoryID)
        {
            try
            {

                SqlDatabase sqldb = new SqlDatabase(Connstring);
                DbCommand cmd = sqldb.GetStoredProcCommand("PR_Product_Cascading");
                sqldb.AddInParameter(cmd, "@CategoryID", SqlDbType.Int, CategoryID );
                List<SubCategoryModel> cascading = new List<SubCategoryModel>();
                using (IDataReader dr = sqldb.ExecuteReader(cmd))
                {

                    while (dr.Read())
                    {
                        SubCategoryModel cascading1 = new SubCategoryModel();
                        cascading1.SubCategoryID = Convert.ToInt32(dr["SubCategoryID"]);
                        cascading1.SubCategoryName = dr["SubCategoryName"].ToString();
                       
                        cascading.Add(cascading1);
                    }

                }
                return cascading;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

       

        #region PR_Product_SelectByPk
        public ProductModel PR_Product_SelectByPk(int ProductID)
        {
            try
            {

                SqlDatabase sqldb = new SqlDatabase(Connstring);
                DbCommand cmd = sqldb.GetStoredProcCommand("PR_Product_SelectByPk");
                sqldb.AddInParameter(cmd, "@ProductID", SqlDbType.Int, ProductID);
                ProductModel productModel = new ProductModel();
                using (IDataReader dr = sqldb.ExecuteReader(cmd))
                {

                    while (dr.Read())
                    {

                        productModel.ProductID = Convert.ToInt32(dr["ProductID"]);
                        productModel.ProductName = dr["ProductName"].ToString();
                        productModel.CategoryID = Convert.ToInt32(dr["CategoryID"]);
                        productModel.SubCategoryID = Convert.ToInt32(dr["SubCategoryID"]);
                        productModel.ProductQuantity = Convert.ToInt32(dr["ProductQuantity"]);
                        productModel.ProductPrice = Convert.ToDecimal(dr["ProductPrice"]);
                        productModel.ProductExpiryDate = Convert.ToDateTime(dr["ProductExpiryDate"]);
                        productModel.ProductImage = dr["ProductImage"].ToString();


                    }

                }
                return productModel;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region PR_Product_DeleteByPk
        public bool PR_Product_DeleteByPk(int ProductID)
        {
            try
            {
                SqlDatabase sqldb = new SqlDatabase(Connstring);
                DbCommand cmd = sqldb.GetStoredProcCommand("PR_Product_DeleteByPk");
                sqldb.AddInParameter(cmd, "@ProductID", SqlDbType.Int, ProductID);

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

        #region PR_Product_Insert
        public bool PR_Product_Insert(ProductModel productModel)
        {
            try
            {
                SqlDatabase sqldb = new SqlDatabase(Connstring);
                DbCommand cmd = sqldb.GetStoredProcCommand("PR_Product_Insert");
                
                sqldb.AddInParameter(cmd, "@ProductName", SqlDbType.VarChar, productModel.ProductName);
                sqldb.AddInParameter(cmd, "@CategoryID", SqlDbType.Int, productModel.CategoryID);
                sqldb.AddInParameter(cmd, "@SubCategoryID", SqlDbType.Int, productModel.SubCategoryID);
                sqldb.AddInParameter(cmd, "@ProductQuantity", SqlDbType.Int, productModel.ProductQuantity);
                sqldb.AddInParameter(cmd, "@ProductPrice", SqlDbType.Decimal, productModel.ProductPrice);
                sqldb.AddInParameter(cmd, "@ProductExpiryDate", SqlDbType.DateTime, productModel.ProductExpiryDate);
                sqldb.AddInParameter(cmd, "@ProductImage", SqlDbType.VarChar, productModel.ProductImage);
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

        #region PR_Product_UpdateByPk
        public bool PR_Product_UpdateByPk(int ProductID, ProductModel productModel)
        {
            try
            {
                SqlDatabase sqldb = new SqlDatabase(Connstring);
                DbCommand cmd = sqldb.GetStoredProcCommand("PR_Product_UpdateByPk");
                sqldb.AddInParameter(cmd, "@ProductID", SqlDbType.Int, productModel.ProductID);
                sqldb.AddInParameter(cmd, "@ProductName", SqlDbType.VarChar, productModel.ProductName);
                sqldb.AddInParameter(cmd, "@CategoryID", SqlDbType.Int, productModel.CategoryID);
                sqldb.AddInParameter(cmd, "@SubCategoryID", SqlDbType.Int, productModel.SubCategoryID);
                sqldb.AddInParameter(cmd, "@ProductQuantity", SqlDbType.Int, productModel.ProductQuantity);
                sqldb.AddInParameter(cmd, "@ProductPrice", SqlDbType.Decimal, productModel.ProductPrice);
                sqldb.AddInParameter(cmd, "@ProductExpiryDate", SqlDbType.DateTime, productModel.ProductExpiryDate);
                sqldb.AddInParameter(cmd, "@ProductImage", SqlDbType.VarChar, productModel.ProductImage);
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




		#region PR_SelectBySubCategory
		public List<ProductModel> PR_SelectBySubCategory(int SubCategoryID)
		{
			try
			{

				SqlDatabase sqldb = new SqlDatabase(Connstring);
				DbCommand cmd = sqldb.GetStoredProcCommand("PR_SelectBySubCategory");
				sqldb.AddInParameter(cmd, "@SubCategoryID", SqlDbType.Int, SubCategoryID);
				List<ProductModel> productModels = new List<ProductModel>();
				using (IDataReader dr = sqldb.ExecuteReader(cmd))
				{

					while (dr.Read())
					{
                        ProductModel productModel = new ProductModel();
						productModel.ProductID = Convert.ToInt32(dr["ProductID"]);
						productModel.ProductName = dr["ProductName"].ToString();
						productModel.CategoryID = Convert.ToInt32(dr["CategoryID"]);
						productModel.SubCategoryID = Convert.ToInt32(dr["SubCategoryID"]);
						productModel.ProductQuantity = Convert.ToInt32(dr["ProductQuantity"]);
						productModel.ProductPrice = Convert.ToDecimal(dr["ProductPrice"]);
						productModel.ProductExpiryDate = Convert.ToDateTime(dr["ProductExpiryDate"]);
						productModel.ProductImage = dr["ProductImage"].ToString();
                        productModels.Add(productModel);

					}

				}
				return productModels;
			}
			catch (Exception ex)
			{
				return null;
			}
		}
		#endregion

	}
}
