using Microsoft.AspNetCore.Mvc;
using Supermarketapi.BAL;
using Supermarketapi.Models;

namespace Supermarketapi.Controllers
{
    [Route("api/[Controller]/[Action]")]
    [ApiController]
    public class DashboardController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            Dashboard_BALBase bal = new Dashboard_BALBase();
            List<DashboardModel> dashboards = bal.PR_Supermarket_Dashboard_Counts();
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();

            if (dashboards.Count > 0 && dashboards != null)
            {
                response.Add("status", true);
                response.Add("message", "data found");
                response.Add("data", dashboards);
                return Ok(response);
            }
            else
            {
                response.Add("status", false);
                response.Add("message", "data not found");
                response.Add("data", null);
                return NotFound(response);
            }
            
        }
    }
}
