using Microsoft.AspNetCore.Mvc;
using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;
using Supermarketapi.BAL;
using Supermarketapi.Models;

namespace Supermarketapi.Controllers
{
    [Route("api/[Controller]/[Action]")]
    [ApiController]
    public class CategoryController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            Category_BALBase bal = new Category_BALBase();
            List<CategoryModel> Category = bal.PR_Category_SelectAll();
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

        [HttpGet("{CategoryID}")]
        public IActionResult GetById(int CategoryID)
        {
            Category_BALBase bal = new Category_BALBase();
            CategoryModel Category = bal.PR_Category_SelectByPk(CategoryID);
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


        [HttpDelete]
        public IActionResult Delete(int CategoryID)
        {
            Category_BALBase category_BAL = new Category_BALBase();
            bool issuccess = category_BAL.PR_Category_DeleteByPk(CategoryID);
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
        public IActionResult Post([FromForm] CategoryModel categoryModel)
        {
            Category_BALBase category_BAL = new Category_BALBase();
            bool issuccess = category_BAL.PR_Category_Insert(categoryModel);
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
        public IActionResult Put(int CategoryID, [FromForm] CategoryModel categoryModel)
        {
            Category_BALBase category_BAL = new Category_BALBase();
            categoryModel.CategoryID = CategoryID;
            bool issuccess = category_BAL.PR_Category_UpdateByPk(CategoryID, categoryModel);

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
        
        public IActionResult CategoryExport()
        {
            Category_BALBase bal = new Category_BALBase();
            List<CategoryModel> category = bal.PR_Category_Exportaspdf();


            if (category.Count > 0 && category != null)
            {
                var pdfBytes = GeneratePdf(category);
                return File(pdfBytes, "application/pdf", "user_data.pdf");
            }
            else
            {
                return NotFound("No data available to export.");
            }


        }

        private byte[] GeneratePdf(List<CategoryModel> users)
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
                gfx.DrawString("ID", fontHeader, textColor, new XRect(20, yPosition, columnWidth, rowHeight), XStringFormats.TopLeft);
                gfx.DrawString("Name", fontHeader, textColor, new XRect(20 + columnWidth, yPosition, columnWidth, rowHeight), XStringFormats.TopLeft);
                gfx.DrawString("Contact", fontHeader, textColor, new XRect(20 + 2 * columnWidth, yPosition, columnWidth, rowHeight), XStringFormats.TopLeft);
               
                yPosition += rowHeight;

                // Data rows
                foreach (var user in users)
                {
                    // Alternate row background
                    gfx.DrawRectangle(rowBackground, 20, yPosition, page.Width - 40, rowHeight);
                    gfx.DrawString(user.CategoryID.ToString(), fontData, textColor, new XRect(20, yPosition, columnWidth, rowHeight), XStringFormats.TopLeft);
                    gfx.DrawString(user.CategoryName, fontData, textColor, new XRect(20 + columnWidth, yPosition, columnWidth, rowHeight), XStringFormats.TopLeft);
                    gfx.DrawString(user.CategoryDescription, fontData, textColor, new XRect(20 + 2 * columnWidth, yPosition, columnWidth, rowHeight), XStringFormats.TopLeft);
                  
                    yPosition += rowHeight;
                }

                using (var ms = new MemoryStream())
                {
                    document.Save(ms);
                    return ms.ToArray();
                }
            }


        }
    }
}
