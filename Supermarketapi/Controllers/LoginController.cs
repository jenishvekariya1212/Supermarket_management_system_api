using Microsoft.AspNetCore.Mvc;
using Supermarketapi.BAL;
using Supermarketapi.Models;

namespace Supermarketapi.Controllers
{

    [Route("api/[Controller]/[Action]")]
    [ApiController]
    public class LoginController : Controller
    {
        [HttpGet("{UserName}/{Password}")]
        public IActionResult GetById(string UserName, string Password)
        {
            Login_BALBase bal = new Login_BALBase();
            LoginModel Category = bal.PR_Login_SelectByUserPass(UserName,Password);
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();


            if (Category != null)
            {
                response.Add("status", true);
                response.Add("message", "data found");
                response.Add("data", Category);
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



        [HttpPost]
        public IActionResult Post([FromForm] LoginModel loginModel)
        {
            Login_BALBase category_BAL = new Login_BALBase();
            bool issuccess = category_BAL.PR_Register_Insert(loginModel);
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (issuccess)
            {
                response.Add("status", true);
                response.Add("message", "data inserted successfully");
                return Ok(response);
            }
            else
            {
                response.Add("status", false);
                response.Add("message", "data not inserted");
                return Ok(response);
            }
        }

    }
}

