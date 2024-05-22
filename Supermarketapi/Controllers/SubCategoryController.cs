using Microsoft.AspNetCore.Mvc;
using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;
using Supermarketapi.BAL;
using Supermarketapi.Models;

namespace Supermarketapi.Controllers
{
    [Route("api/[Controller]/[Action]")]
    [ApiController]
    public class SubCategoryController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            SubCategory_BALBase bal = new SubCategory_BALBase();
            List<SubCategoryModel> Category = bal.PR_SubCategory_SelectAll();
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

        /*for dropdown*/
        [HttpGet]
        public IActionResult GetDropdown()
        {
            SubCategory_BALBase bal = new SubCategory_BALBase();
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



        [HttpGet("{SubCategoryID}")]    
        public IActionResult GetById(int SubCategoryID)
        {
            SubCategory_BALBase bal = new SubCategory_BALBase();
            SubCategoryModel SubCategory = bal.PR_SubCategory_SelectByPk(SubCategoryID);
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();

            if (SubCategory != null)
            {
                response.Add("status", true);
                response.Add("message", "data found");
                response.Add("data", SubCategory);
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
        public IActionResult Delete(int SubCategoryID)
        {
            SubCategory_BALBase category_BAL = new SubCategory_BALBase();
            bool issuccess = category_BAL.PR_SubCategory_DeleteByPk(SubCategoryID);
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
        public IActionResult Post([FromForm] SubCategoryModel subCategoryModel)
        {
            SubCategory_BALBase subCategory_BAL = new SubCategory_BALBase();
            bool issuccess = subCategory_BAL.PR_SubCategory_Insert(subCategoryModel);
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
        public IActionResult Put(int SubCategoryID, [FromForm] SubCategoryModel subCategoryModel)
        {
            SubCategory_BALBase subCategory_BAL = new SubCategory_BALBase();
            subCategoryModel.SubCategoryID = SubCategoryID;
            bool issuccess = subCategory_BAL.PR_SubCategory_UpdateByPk(SubCategoryID, subCategoryModel);

            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (issuccess)
            {
                response.Add("status", true);
                response.Add("message", "data updated successfully");
                return Ok(response);
            }
            else
            {
                response.Add("status", false);
                response.Add("message", "data not inserted");
                return Ok(response);
            }
        }



        [HttpGet]

        public IActionResult SubCategoryExport()
        {
            SubCategory_BALBase bal = new SubCategory_BALBase();
            List<SubCategoryModel> subCategories = bal.PR_SubCategory_Exportaspdf();


            if (subCategories.Count > 0 && subCategories != null)
            {
                var pdfBytes = GeneratePdf(subCategories);
                return File(pdfBytes, "application/pdf", "user_data.pdf");
            }
            else
            {
                return NotFound("No data available to export.");
            }


        }

        private byte[] GeneratePdf(List<SubCategoryModel> users)
        {
            using (var document = new PdfDocument())
            {
                var page = document.AddPage();
                var gfx = XGraphics.FromPdfPage(page);
                var fontTitle = new XFont("Arial", 16, XFontStyle.Bold);
                var fontHeader = new XFont("Arial", 12, XFontStyle.Bold);
                var fontData = new XFont("Arial", 10, XFontStyle.Regular);

                int yPosition = 40;
                int rowHeight = 20;
                int columnWidth = 150;
                XBrush tableBackground = new XSolidBrush(XColor.FromArgb(255, 235, 235, 235)); // Light gray
                XBrush rowBackground = new XSolidBrush(XColor.FromArgb(255, 255, 255, 255)); // White
                XBrush textColor = XBrushes.Black;

                // Set page background color to dark
                gfx.DrawRectangle(XBrushes.DarkSlateGray, 0, 0, page.Width, page.Height);

                // Header
                gfx.DrawString("User Data", fontTitle, XBrushes.White,
                    new XRect(0, yPosition, page.Width, page.Height), XStringFormats.TopCenter);
                yPosition += 40;

                // Table Header Background
                gfx.DrawRectangle(tableBackground, 20, yPosition, page.Width - 40, rowHeight);
                // Table Header
                gfx.DrawString("subcategoryid", fontHeader, textColor, new XRect(20, yPosition, columnWidth, rowHeight), XStringFormats.TopLeft);
                gfx.DrawString("subcategoryname", fontHeader, textColor, new XRect(20 + columnWidth, yPosition, columnWidth, rowHeight), XStringFormats.TopLeft);
                gfx.DrawString("categoryname", fontHeader, textColor, new XRect(20 + 2 * columnWidth, yPosition, columnWidth, rowHeight), XStringFormats.TopLeft);

                yPosition += rowHeight;

                // Data rows
                foreach (var user in users)
                {
                    // Alternate row background
                    gfx.DrawRectangle(rowBackground, 20, yPosition, page.Width - 40, rowHeight);
                    gfx.DrawString(user.SubCategoryID.ToString(), fontData, textColor, new XRect(20, yPosition, columnWidth, rowHeight), XStringFormats.TopLeft);
                    gfx.DrawString(user.SubCategoryName, fontData, textColor, new XRect(20 + columnWidth, yPosition, columnWidth, rowHeight), XStringFormats.TopLeft);
                    gfx.DrawString(user.CategoryName, fontData, textColor, new XRect(20 + 2 * columnWidth, yPosition, columnWidth, rowHeight), XStringFormats.TopLeft);

                    yPosition += rowHeight;
                }

                using (var ms = new MemoryStream())
                {
                    document.Save(ms);
                    return ms.ToArray();
                }
            }


        }




		[HttpGet("{CategoryID}")]
		public IActionResult GetByCategoryID(int CategoryID)
		{
			SubCategory_BALBase bal = new SubCategory_BALBase();
			List<SubCategoryModel> SubCategory = bal.PR_SelectByCategory(CategoryID);
			Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();

			if (SubCategory != null)
			{
				response.Add("status", true);
				response.Add("message", "data found");
				response.Add("data", SubCategory);
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
