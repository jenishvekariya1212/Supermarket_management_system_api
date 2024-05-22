using Supermarketapi.DAL;
using Supermarketapi.Models;

namespace Supermarketapi.BAL
{
    public class Order_BALBase
    {
        #region PR_SelectBySubCategory
        public List<OrderModel> PR_Order_SelectByPk(int CartID)
        {
            try
            {
                Order_DALBase product_DAL = new Order_DALBase();
                List<OrderModel> productModel = product_DAL.PR_Order_SelectByPk(CartID);
                return productModel;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
		#endregion

		#region PR_Order_Insert      
		public bool PR_Order_Insert(OrderModel orderModel)
		{
			try
			{
				Order_DALBase category_DAL = new Order_DALBase();

				if (category_DAL.PR_Order_Insert(orderModel))
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

        #region PR_Orderofadminview_Selectall
        public List<OrderModel> PR_Orderofadminview_Selectall()
        {
            try
            {
                Order_DALBase category_DAL = new Order_DALBase();

                List<OrderModel> categoryModels = category_DAL.PR_Orderofadminview_Selectall();
                return categoryModels;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion


        #region PR_Bill_Exportpdf
        public List<BillModel> PR_Bill_Exportpdf(int UserID)
        {
            try
            {
                Order_DALBase category_DAL = new Order_DALBase();
                List<BillModel> categoryModels = category_DAL.PR_Bill_Exportpdf(UserID);
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
