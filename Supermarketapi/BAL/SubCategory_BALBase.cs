using Supermarketapi.DAL;
using Supermarketapi.Models;

namespace Supermarketapi.BAL
{
    public class SubCategory_BALBase
    {
        #region PR_SubCategory_SelectAll
        public List<SubCategoryModel> PR_SubCategory_SelectAll()
        {
            try
            {
               SubCategory_DALBase subCategory_DAL = new SubCategory_DALBase();
                List<SubCategoryModel> categoryModels = subCategory_DAL.PR_SubCategory_SelectAll();
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
                SubCategory_DALBase subCategory_DAL = new SubCategory_DALBase();
                List<Categorydropdown> categoryModels = subCategory_DAL.PR_CategoryDropDownList();
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
                SubCategory_DALBase SubCategory_DAL = new SubCategory_DALBase();
                SubCategoryModel SubCategoryModels = SubCategory_DAL.PR_SubCategory_SelectByPk(SubCategoryID);
                return SubCategoryModels;
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
                SubCategory_DALBase category_DAL = new SubCategory_DALBase();

                if (category_DAL.PR_SubCategory_DeleteByPk(SubCategoryID))
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
                SubCategory_DALBase subCategory_DAL = new SubCategory_DALBase();

                if (subCategory_DAL.PR_SubCategory_Insert(subCategoryModel))
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

        #region PR_SubCategory_UpdateByPk      
        public bool PR_SubCategory_UpdateByPk(int SubCategoryID, SubCategoryModel subCategoryModel)
        {
            try
            {
                SubCategory_DALBase subCategory_DAL = new SubCategory_DALBase();

                if (subCategory_DAL.PR_SubCategory_UpdateByPk(SubCategoryID, subCategoryModel))
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
                SubCategory_DALBase subCategory_DAL = new SubCategory_DALBase();
                List<SubCategoryModel> categoryModels = subCategory_DAL.PR_SubCategory_Exportaspdf();
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
				SubCategory_DALBase SubCategory_DAL = new SubCategory_DALBase();
				List<SubCategoryModel> SubCategoryModels = SubCategory_DAL.PR_SelectByCategory(CategoryID);
				return SubCategoryModels;
			}
			catch (Exception ex)
			{
				return null;
			}
		}
		#endregion
	}
}
