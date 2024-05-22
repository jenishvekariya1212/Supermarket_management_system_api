using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Supermarketapi.Models;
using System.Data.Common;
using System.Data;

namespace Supermarketapi.DAL
{
    public class Order_DALBase:DAL_Helpercs
    {
        #region PR_Order_SelectByPk
        public List<OrderModel> PR_Order_SelectByPk(int CartID)
        {
            try
            {

                SqlDatabase sqldb = new SqlDatabase(Connstring);
                DbCommand cmd = sqldb.GetStoredProcCommand("PR_Order_SelectByPk");
                sqldb.AddInParameter(cmd, "@CartID", SqlDbType.Int, CartID);
                List<OrderModel> productModels = new List<OrderModel>();
                using (IDataReader dr = sqldb.ExecuteReader(cmd))
                {

                    while (dr.Read())
                    {
                        OrderModel productModel = new OrderModel();
                        productModel.OrderID = Convert.ToInt32(dr["OrderID"]);
                        productModel.ProductImage = dr["ProductImage"].ToString();
                        productModel.ProductName = dr["ProductName"].ToString();
                        productModel.Quantity = Convert.ToInt32(dr["Quantity"]);
                        productModel.ProductPrice = Convert.ToDecimal(dr["ProductPrice"]);
                        productModel.UserID = Convert.ToInt32(dr["UserID"]);
                        productModel.OrderDate = Convert.ToDateTime(dr["OrderDate"]);
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


		#region PR_Order_Insert
		public bool PR_Order_Insert(OrderModel orderModel)
		{
			try
			{
				SqlDatabase sqldb = new SqlDatabase(Connstring);
				DbCommand cmd = sqldb.GetStoredProcCommand("PR_Order_Insert");
				sqldb.AddInParameter(cmd, "@CartID", SqlDbType.Int, orderModel.CartID);

				sqldb.AddInParameter(cmd, "@UserID", SqlDbType.Int, orderModel.UserID);
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


        #region PR_Orderofadminview_Selectall
        public List<OrderModel> PR_Orderofadminview_Selectall()
        {
            try
            {

                SqlDatabase sqldb = new SqlDatabase(Connstring);
                DbCommand cmd = sqldb.GetStoredProcCommand("PR_Orderofadminview_Selectall");
                List<OrderModel> orderModels = new List<OrderModel>();
                using (IDataReader dr = sqldb.ExecuteReader(cmd))
                {

                    while (dr.Read())
                    {
                        OrderModel order = new OrderModel();
                      
                        order.ProductName = dr["ProductName"].ToString();
                        order.Quantity = Convert.ToInt32(dr["Quantity"]);
                        order.FirstName = dr["FirstName"].ToString();
                        order.LastName = dr["LastName"].ToString();
                        order.ProductPrice = Convert.ToDecimal(dr["ProductPrice"]);
                        order.OrderDate = Convert.ToDateTime(dr["OrderDate"]);
                        orderModels.Add(order);
                    }

                }
                return orderModels;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region PR_Category_SelectByPk
        public List<BillModel> PR_Bill_Exportpdf(int UserID)
        {
            try
            {

                SqlDatabase sqldb = new SqlDatabase(Connstring);
                DbCommand cmd = sqldb.GetStoredProcCommand("PR_Bill_Exportpdf");
                sqldb.AddInParameter(cmd, "@UserID", SqlDbType.Int, UserID);
                List<BillModel> categoryModels = new List<BillModel>();
                using (IDataReader dr = sqldb.ExecuteReader(cmd))
                {

                    while (dr.Read())
                    {
                        BillModel orderModel = new BillModel();
                        /*   categoryModel.UserID = Convert.ToInt32(dr["UserID"]);*/
                        orderModel.FirstName = dr["FirstName"].ToString();
                        orderModel.LastName = dr["LastName"].ToString();
                        orderModel.ProductName = dr["ProductName"].ToString();
                        orderModel.ProductPrice = Convert.ToDecimal(dr["ProductPrice"]);
                        categoryModels.Add(orderModel);
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
