using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Supermarketapi.Models;
using System.Data.Common;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Supermarketapi.DAL
{
	public class Cart_DALBase : DAL_Helpercs
	{
		#region PR_Category_SelectAll
		public List<CartModel> PR_Cart_SelectAll(int UserID)
		{
			try
			{

				SqlDatabase sqldb = new SqlDatabase(Connstring);
				DbCommand cmd = sqldb.GetStoredProcCommand("PR_Cart_SelectAll");
				sqldb.AddInParameter(cmd, "@UserID", SqlDbType.Int, UserID);
				List<CartModel> cartModels = new List<CartModel>();
				using (IDataReader dr = sqldb.ExecuteReader(cmd))
				{

					while (dr.Read())
					{
						CartModel categoryModel = new CartModel();
						categoryModel.CartID = Convert.ToInt32(dr["CartID"]);
						categoryModel.ProductID = Convert.ToInt32(dr["ProductID"]);
						categoryModel.ProductName = dr["ProductName"].ToString();
						categoryModel.ProductImage = dr["ProductImage"].ToString();
						categoryModel.ProductPrice = Convert.ToDecimal(dr["ProductPrice"]);
						categoryModel.Quantity = Convert.ToInt32(dr["Quantity"]);
						cartModels.Add(categoryModel);
					}

				}
				return cartModels;
			}
			catch (Exception ex)
			{
				return null;
			}
		}
		#endregion



		#region PR_Cart_Insert
		public bool PR_Cart_Insert(CartModel cartModel)
		{
			try
			{
				SqlDatabase sqldb = new SqlDatabase(Connstring);
				DbCommand cmd = sqldb.GetStoredProcCommand("PR_Cart_Insert");
				sqldb.AddInParameter(cmd, "@ProductID", SqlDbType.Int, cartModel.ProductID);

				sqldb.AddInParameter(cmd, "@UserID", SqlDbType.Int, cartModel.UserID);
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


		#region PR_Cart_DeleteByPk
		public bool PR_Cart_DeleteByPk(int CartID)
		{
			try
			{
				SqlDatabase sqldb = new SqlDatabase(Connstring);
				DbCommand cmd = sqldb.GetStoredProcCommand("PR_Cart_DeleteByPk");
				sqldb.AddInParameter(cmd, "@CartID", SqlDbType.Int, CartID);

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



		#region PR_Cart_SelectByPk
		public CartModel PR_Cart_SelectByPk(int CartID)
		{
			try
			{

				SqlDatabase sqldb = new SqlDatabase(Connstring);
				DbCommand cmd = sqldb.GetStoredProcCommand("PR_Cart_SelectByPk");
				sqldb.AddInParameter(cmd, "@CartID", SqlDbType.Int, CartID);
				CartModel cartModel = new CartModel();

				using (IDataReader dr = sqldb.ExecuteReader(cmd))
				{

					while (dr.Read())
					{
						cartModel.CartID = Convert.ToInt32(dr["CartID"]);
						cartModel.ProductImage = dr["ProductImage"].ToString();
						cartModel.ProductName = dr["ProductName"].ToString();
						cartModel.ProductPrice = Convert.ToDecimal(dr["ProductPrice"]);
						cartModel.ProductID = Convert.ToInt32(dr["ProductID"]);
						cartModel.Quantity = Convert.ToInt32(dr["Quantity"]);

					}

				}
				return cartModel;
			}
			catch (Exception ex)
			{
				return null;
			}
		}
		#endregion



		#region Method : Increment Quantity
		public bool Increment_Quantity(int ProductID)
		{
			try
			{
				SqlDatabase sqlDatabase = new SqlDatabase(Connstring);
				DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("Increment_Quantity");
				sqlDatabase.AddInParameter(dbCommand, "@ProductID", SqlDbType.Int, ProductID);

				if (Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand)))
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

        #region Method : decrement Quantity
        public bool Decrement_Quantity(int ProductID)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(Connstring);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("Decrement_Quantity");
                sqlDatabase.AddInParameter(dbCommand, "@ProductID", SqlDbType.Int, ProductID);

                if (Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand)))
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
