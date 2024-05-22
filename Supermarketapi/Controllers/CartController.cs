using Microsoft.AspNetCore.Mvc;
using Supermarketapi.BAL;
using Supermarketapi.DAL;
using Supermarketapi.Models;

namespace Supermarketapi.Controllers
{

	[Route("api/[Controller]/[Action]")]
	[ApiController]
	public class CartController : Controller
	{

		[HttpGet("{UserID}")]
		public IActionResult GetByID(int UserID)
		{
			Cart_BALBase bal = new Cart_BALBase();
			List<CartModel> Category = bal.PR_Cart_SelectAll(UserID);
			Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();

			if (Category.Count > 0 && Category != null)
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
		public IActionResult Post([FromForm] CartModel cartModel)
		{
			Cart_DALBase category_BAL = new Cart_DALBase();
			bool issuccess = category_BAL.PR_Cart_Insert(cartModel);
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

		[HttpDelete]
		public IActionResult Delete(int CartID)
		{
			Cart_BALBase cart_BALBase = new Cart_BALBase();
			bool issuccess = cart_BALBase.PR_Cart_DeleteByPk(CartID);
			Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
			if (issuccess)
			{
				response.Add("status", true);
				response.Add("message", "data found");
				return Ok(response);
			}
			else
			{
				response.Add("status", false);
				response.Add("message", "data not found");
				return Ok(response);
			}
		}


		[HttpGet("{CartID}")]
		public IActionResult GetByCartID(int CartID)
		{
			Cart_BALBase bal = new Cart_BALBase();
			CartModel Category = bal.PR_Cart_SelectByPk(CartID);
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



		[HttpPut]
			public IActionResult Increment(int ProductID)
		{
			Cart_BALBase cart_BALBase = new Cart_BALBase();
			   
            bool issuccess = cart_BALBase.Increment_Quantity(ProductID);
			Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
			if (issuccess)
			{
				response.Add("status", true);
				response.Add("message", "data found");
				return Ok(response);
			}
			else
			{
				response.Add("status", false);
				response.Add("message", "data not found");
				return Ok(response);
			}


		}

        [HttpPut]
        public IActionResult Decrement(int ProductID)
        {
            Cart_BALBase cart_BALBase = new Cart_BALBase();

            bool issuccess = cart_BALBase.Decrement_Quantity(ProductID);
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (issuccess)
            {
                response.Add("status", true);
                response.Add("message", "data found");
                return Ok(response);
            }
            else
            {
                response.Add("status", false);
                response.Add("message", "data not found");
                return Ok(response);
            }


        }


    }
}
