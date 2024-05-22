using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Supermarketapi.DAL;
using Supermarketapi.Models;
using System.Data.Common;
using System.Data;

namespace Supermarketapi.BAL
{
    public class Category_BALBase
    {
        #region PR_Category_SelectAll
        public List<CategoryModel> PR_Category_SelectAll()
        {
            try
            {
                Category_DALBase category_DAL = new Category_DALBase();
                List<CategoryModel> categoryModels = category_DAL.PR_Category_SelectAll();
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
                Category_DALBase category_DAL = new Category_DALBase();
                CategoryModel categoryModels = category_DAL.PR_Category_SelectByPk(CategoryID);
                return categoryModels;
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
               Category_DALBase category_DAL = new Category_DALBase();

                if (category_DAL.PR_Category_DeleteByPk(CategoryID))
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
                Category_DALBase category_DAL = new Category_DALBase();

                if (category_DAL.PR_Category_Insert(categoryModel))
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
        public bool PR_Category_UpdateByPk(int CategoryID, CategoryModel categoryModel)
        {
            try
            {
                Category_DALBase category_DAL = new Category_DALBase();

                if (category_DAL.PR_Category_UpdateByPk(CategoryID, categoryModel))
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
                Category_DALBase category_DAL = new Category_DALBase();
                List<CategoryModel> categoryModels = category_DAL.PR_Category_Exportaspdf();
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

