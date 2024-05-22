using Supermarketapi.DAL;
using Supermarketapi.Models;

namespace Supermarketapi.BAL
{
    public class Product_BALBase
    {
        #region PR_Product_SelectAll
        public List<ProductModel> PR_Product_SelectAll()
        {
            try
            {
                Product_DALBase product_DAL = new Product_DALBase();
                List<ProductModel> productModels = product_DAL.PR_Product_SelectAll();
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
                Product_DALBase subCategory_DAL = new Product_DALBase();
                List<Categorydropdown> categoryModels = subCategory_DAL.PR_CategoryDropDownList();
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
                Product_DALBase subCategory_DAL = new Product_DALBase();
                List<SubcategoryDropDown> subcategoryModels = subCategory_DAL.PR_SubCategoryDropdownList();
                return subcategoryModels;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region PR_Product_SelectByPk
        public List<SubCategoryModel> PR_Product_Cascading(int CategoryID)
        {
            try
            {
                Product_DALBase product_DAL = new Product_DALBase();
                List<SubCategoryModel> productModel = product_DAL.PR_Product_Cascading(CategoryID);
                return productModel;
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
                Product_DALBase product_DAL = new Product_DALBase();
                ProductModel productModel = product_DAL.PR_Product_SelectByPk(ProductID);
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
                Product_DALBase product_DAL = new Product_DALBase();

                if (product_DAL.PR_Product_DeleteByPk(ProductID))
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
                Product_DALBase product_DAL = new Product_DALBase();

                if (product_DAL.PR_Product_Insert(productModel))
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
                Product_DALBase product_DAL = new Product_DALBase();

                if (product_DAL.PR_Product_UpdateByPk(ProductID, productModel))
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
				Product_DALBase product_DAL = new Product_DALBase();
				List<ProductModel> productModel = product_DAL.PR_SelectBySubCategory(SubCategoryID);
				return productModel;
			}
			catch (Exception ex)
			{
				return null;
			}
		}
		#endregion

	}



}
