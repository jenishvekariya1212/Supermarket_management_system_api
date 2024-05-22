using Microsoft.AspNetCore.Mvc;
using Supermarketapi.BAL;
using Supermarketapi.Models;

namespace Supermarketapi.Controllers
{
    [Route("api/[Controller]/[Action]")]
    [ApiController]
    public class ProductController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            Product_BALBase bal = new Product_BALBase();
            List<ProductModel> products = bal.PR_Product_SelectAll();
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();

            if (products.Count> 0 && products != null)
            {
                response.Add("status", true);
                response.Add("message", "data found");
                response.Add("data", products);
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

/*category dropdoewn*/
        [HttpGet]
        public IActionResult GetCategoryDropdown()
        {
            Product_BALBase bal = new Product_BALBase();
            List<Categorydropdown> Category = bal.PR_CategoryDropDownList();
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

/*subcategorydropdown*/
        [HttpGet]
        public IActionResult GetSubCategoryDropdown()
        {
            Product_BALBase bal = new Product_BALBase();
            List<SubcategoryDropDown> subCategory = bal.PR_SubCategoryDropdownList();
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();

            if (subCategory.Count > 0 && subCategory != null)
            {
                response.Add("status", true);
                response.Add("message", "data found");
                response.Add("data", subCategory);
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


        /*cascading*/
        [HttpGet("{CategoryID}")]
        public IActionResult Cascading(int CategoryID)
        {
            Product_BALBase bal = new Product_BALBase();
            List<SubCategoryModel> product = bal.PR_Product_Cascading(CategoryID);
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();

            if (product != null)
            {
                response.Add("status", true);
                response.Add("message", "data found");
                response.Add("data", product);
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

        [HttpGet("{ProductID}")]
        public IActionResult GetById(int ProductID)
        {
            Product_BALBase bal = new Product_BALBase();
            ProductModel product = bal.PR_Product_SelectByPk(ProductID);
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();

            if (product != null)
            {
                response.Add("status", true);
                response.Add("message", "data found");
                response.Add("data", product);
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

        [HttpDelete]
        public IActionResult Delete(int ProductID)
        {
            Product_BALBase product_BAL = new Product_BALBase();
            bool issuccess = product_BAL.PR_Product_DeleteByPk(ProductID);
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



        [HttpPost]
        public IActionResult Post([FromForm] ProductModel productModel)
        {
            Product_BALBase product_BAL = new Product_BALBase();
            bool issuccess = product_BAL.PR_Product_Insert(productModel);
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

        [HttpPut]
        public IActionResult Put(int ProductID ,[FromForm] ProductModel productModel)
        {
            Product_BALBase product_BAL = new Product_BALBase();
            productModel.ProductID = ProductID;
            bool issuccess = product_BAL.PR_Product_UpdateByPk(ProductID,productModel);
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

/*get by subcategoryid*/

		[HttpGet("{SubCategoryID}")]
		public IActionResult GetBySubCategoryID(int SubCategoryID)
		{
			Product_BALBase bal = new Product_BALBase();
			List<ProductModel> product = bal.PR_SelectBySubCategory(SubCategoryID);
			Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();

			if (product != null)
			{
				response.Add("status", true);
				response.Add("message", "data found");
				response.Add("data", product);
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
