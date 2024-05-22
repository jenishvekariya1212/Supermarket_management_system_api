using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Supermarketapi.Models;
using System.Data.Common;
using System.Data;

namespace Supermarketapi.DAL
{
    public class Dashboard_DALBase:DAL_Helpercs
    {
        #region PR_Dashboard_SelectAll
        public List<DashboardModel> PR_Supermarket_Dashboard_Counts()
        {
            try
            {

                SqlDatabase sqldb = new SqlDatabase(Connstring);
                DbCommand cmd = sqldb.GetStoredProcCommand("PR_Supermarket_Dashboard_Counts");
                List<DashboardModel> dashboardModels = new List<DashboardModel>();
                using (IDataReader dr = sqldb.ExecuteReader(cmd))
                {

                    while (dr.Read())
                    {
                        DashboardModel dashboardModel = new DashboardModel();
                        dashboardModel.CategoryCount = Convert.ToInt32(dr["CategoryCount"]);
                        dashboardModel.SubCategoryCount = Convert.ToInt32(dr["SubCategoryCount"]);
                        dashboardModel.ProductCount = Convert.ToInt32(dr["ProductCount"]);
                        dashboardModel.OrderCount = Convert.ToInt32(dr["OrderCount"]);
                        dashboardModels.Add(dashboardModel);
                    }

                }
                return dashboardModels;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
    }
}
