using Supermarketapi.DAL;
using Supermarketapi.Models;

namespace Supermarketapi.BAL
{
    public class Cart_BALBase
    {
        #region PR_Cart_SelectAll
        public List<CartModel> PR_Cart_SelectAll(int UserID)
        {
            try
            {
                Cart_DALBase category_DAL = new Cart_DALBase();
                List<CartModel> categoryModels = category_DAL.PR_Cart_SelectAll(UserID);
                return categoryModels;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
		#endregion


		#region PR_Category_Insert      
		public bool PR_Cart_Insert(CartModel cartModel)
		{
			try
			{
				Cart_DALBase category_DAL = new Cart_DALBase();

				if (category_DAL.PR_Cart_Insert(cartModel))
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

		#region PR_Cart_DeleteByPk      
		public bool PR_Cart_DeleteByPk(int CartID)
		{
			try
			{
				Cart_DALBase cart_DALBase = new Cart_DALBase();

				if (cart_DALBase.PR_Cart_DeleteByPk(CartID))
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

        #region Increment_Quantity      
        public bool Increment_Quantity(int ProductID)
        {
            try
            {
                Cart_DALBase cart_DALBase = new Cart_DALBase();

                if (cart_DALBase.Increment_Quantity(ProductID))
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

        #region Increment_Quantity      
        public bool Decrement_Quantity(int ProductID)
        {
            try
            {
                Cart_DALBase cart_DALBase = new Cart_DALBase();

                if (cart_DALBase.Decrement_Quantity(ProductID))
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


        #region PR_Cart_SelectByPk
        public CartModel PR_Cart_SelectByPk(int CartID)
		{
			try
			{
				Cart_DALBase cart_DALBase = new Cart_DALBase();
				CartModel categoryModels = cart_DALBase.PR_Cart_SelectByPk(CartID);
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
