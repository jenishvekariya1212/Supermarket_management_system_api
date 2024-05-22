using Supermarketapi.DAL;
using Supermarketapi.Models;

namespace Supermarketapi.BAL
{
    public class Dashboard_BALBase
    {
        #region PR_Dashboard_SelectAll
        public List<DashboardModel> PR_Supermarket_Dashboard_Counts()
        {
            try
            {
                Dashboard_DALBase dashboard_DAL = new Dashboard_DALBase();
                List<DashboardModel> dashboardModels =dashboard_DAL.PR_Supermarket_Dashboard_Counts();
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
