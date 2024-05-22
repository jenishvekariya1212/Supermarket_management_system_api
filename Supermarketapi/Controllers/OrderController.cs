using Microsoft.AspNetCore.Mvc;
using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;
using Supermarketapi.BAL;
using Supermarketapi.DAL;
using Supermarketapi.Models;

namespace Supermarketapi.Controllers
{

    [Route("api/[Controller]/[Action]")]
    [ApiController]
    public class OrderController : Controller
    {
        [HttpGet("{CartID}")]
        public IActionResult GetByCartID(int CartID)
        {
            Order_BALBase bal = new Order_BALBase();
            List<OrderModel> product = bal.PR_Order_SelectByPk(CartID);
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

		[HttpPost]
		public IActionResult Post([FromForm] OrderModel orderModel)
		{
			Order_BALBase category_BAL = new Order_BALBase();
			bool issuccess = category_BAL.PR_Order_Insert(orderModel);
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

        [HttpGet]
        public IActionResult Adminorder()
        {
            Order_BALBase bal = new Order_BALBase();
            List<OrderModel> Category = bal.PR_Orderofadminview_Selectall();
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


        /*  [HttpGet("{UserID}")]
          public IActionResult Bill(int UserID)
          {
              Order_BALBase bal = new Order_BALBase();
              List<OrderModel> Category = bal.PR_Bill_Exportpdf(UserID);
              Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();

              if (Category != null)
              {
                  var pdfBytes = GeneratePdf(Category);
                  return File(pdfBytes, "application/pdf", "user_data.pdf");
              }
              else
              {
                  return NotFound("No data available to export.");
              }
          }
  */

        [HttpGet("{UserID}")]
        public IActionResult Bill(int UserID)
        {
            Order_BALBase bal = new Order_BALBase();
            List<BillModel> orders = bal.PR_Bill_Exportpdf(UserID);

            if (orders != null && orders.Count > 0)
            {
                var pdfBytes = GeneratePdf(orders);
                return File(pdfBytes, "application/pdf", "user_data.pdf");
            }
            else
            {
                return NotFound("No data available to export.");
            }
        }










        /* private byte[] GeneratePdf(List<BillModel> orders)
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
                 XBrush tableBackground = new XSolidBrush(XColor.FromArgb(255, 255, 255, 255)); // White background
                 XBrush textColor = XBrushes.Black;
                 XPen borderPen = new XPen(XColors.Black, 1); // Black border

                 // Set page background color to dark
                 gfx.DrawRectangle(XBrushes.Black, 0, 0, page.Width, page.Height);

                 // Header
                 gfx.DrawString("Delta supermarket", fontTitle, XBrushes.White,
                     new XRect(0, yPosition, page.Width, page.Height), XStringFormats.TopCenter);
                 yPosition += 40;

                 // Invoice details
                 gfx.DrawString("Invoice ID: INV1234", fontHeader, XBrushes.White, new XRect(20, yPosition, page.Width - 40, rowHeight), XStringFormats.TopLeft);
                 yPosition += rowHeight;
                 gfx.DrawString("Date: " + DateTime.Now.ToString("MM/dd/yyyy"), fontHeader, XBrushes.White, new XRect(20, yPosition, page.Width - 40, rowHeight), XStringFormats.TopLeft);
                 yPosition += rowHeight;

                 // Table Header Background
                 gfx.DrawRectangle(tableBackground, 20, yPosition, page.Width - 40, rowHeight);
                 // Table Header
                 gfx.DrawString("User Name", fontHeader, textColor, new XRect(20, yPosition, columnWidth, rowHeight), XStringFormats.TopLeft);
                 gfx.DrawString("Product Name", fontHeader, textColor, new XRect(20 + columnWidth, yPosition, columnWidth, rowHeight), XStringFormats.TopLeft);
                 gfx.DrawString("Price", fontHeader, textColor, new XRect(20 + 2 * columnWidth, yPosition, columnWidth, rowHeight), XStringFormats.TopLeft);
                 yPosition += rowHeight;

                 // Data rows
                 foreach (var order in orders)
                 {
                     // Draw border for each row
                     gfx.DrawRectangle(borderPen, 20, yPosition, page.Width - 40, rowHeight);

                     // Alternate row background
                     gfx.DrawRectangle(tableBackground, 20, yPosition, page.Width - 40, rowHeight);
                     gfx.DrawString(order.FirstName + " " + order.LastName, fontData, textColor, new XRect(20, yPosition, columnWidth, rowHeight), XStringFormats.TopLeft);
                     gfx.DrawString(order.ProductName, fontData, textColor, new XRect(20 + columnWidth, yPosition, columnWidth, rowHeight), XStringFormats.TopLeft);
                     gfx.DrawString(order.ProductPrice.ToString(), fontData, textColor, new XRect(20 + 2 * columnWidth, yPosition, columnWidth, rowHeight), XStringFormats.TopLeft);
                     yPosition += rowHeight;

                 }

                 // Total
                 decimal total = orders.Sum(order => order.ProductPrice);
                 gfx.DrawRectangle(borderPen, 20, yPosition, page.Width - 40, rowHeight); // Draw border for total row
                 gfx.DrawRectangle(tableBackground, 20, yPosition, page.Width - 40, rowHeight); // Fill background
                 gfx.DrawString("Total:", fontHeader, textColor, new XRect(20, yPosition, columnWidth, rowHeight), XStringFormats.TopLeft);
                 gfx.DrawString(total.ToString(), fontHeader, textColor, new XRect(20 + 2 * columnWidth, yPosition, columnWidth, rowHeight), XStringFormats.TopLeft);

                 using (var ms = new MemoryStream())
                 {
                     document.Save(ms);
                     return ms.ToArray();
                 }
             }
         }*/

        private byte[] GeneratePdf(List<BillModel> orders)
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
                XBrush textColor = XBrushes.Black;
                XPen borderPen = new XPen(XColors.Black, 1); // Black border

                // Draw background design
                gfx.DrawRectangle(XBrushes.LightGray, 0, 0, page.Width, page.Height); // Background color

                // Set page background color to dark
                gfx.DrawRectangle(XBrushes.DarkSlateGray, 20, 20, page.Width - 40, 100); // Dark rectangle as header

                // Header
                gfx.DrawString("Delta supermarket", fontTitle, XBrushes.White,
                    new XRect(0, yPosition, page.Width, page.Height), XStringFormats.TopCenter);
                yPosition += 40;

                // Invoice details
                gfx.DrawString("Invoice ID: INV1234", fontHeader, XBrushes.White, new XRect(20, yPosition, page.Width - 40, rowHeight), XStringFormats.TopLeft);
                yPosition += rowHeight;
                gfx.DrawString("Date: " + DateTime.Now.ToString("MM/dd/yyyy"), fontHeader, XBrushes.White, new XRect(20, yPosition, page.Width - 40, rowHeight), XStringFormats.TopLeft);
                yPosition += rowHeight;

                // Table Header Background
                gfx.DrawRectangle(XBrushes.White, 20, yPosition, page.Width - 40, rowHeight);
                // Table Header
                gfx.DrawString("User Name", fontHeader, textColor, new XRect(20, yPosition, columnWidth, rowHeight), XStringFormats.TopLeft);
                gfx.DrawString("Product Name", fontHeader, textColor, new XRect(20 + columnWidth, yPosition, columnWidth, rowHeight), XStringFormats.TopLeft);
                gfx.DrawString("Price", fontHeader, textColor, new XRect(20 + 2 * columnWidth, yPosition, columnWidth, rowHeight), XStringFormats.TopLeft);
                yPosition += rowHeight;

                // Data rows
                foreach (var order in orders)
                {
                    // Draw border for each row
                    gfx.DrawRectangle(borderPen, 20, yPosition, page.Width - 40, rowHeight);

                    // Alternate row background
                    gfx.DrawRectangle(XBrushes.White, 20, yPosition, page.Width - 40, rowHeight);
                    gfx.DrawString(order.FirstName + " " + order.LastName, fontData, textColor, new XRect(20, yPosition, columnWidth, rowHeight), XStringFormats.TopLeft);
                    gfx.DrawString(order.ProductName, fontData, textColor, new XRect(20 + columnWidth, yPosition, columnWidth, rowHeight), XStringFormats.TopLeft);
                    gfx.DrawString(order.ProductPrice.ToString(), fontData, textColor, new XRect(20 + 2 * columnWidth, yPosition, columnWidth, rowHeight), XStringFormats.TopLeft);
                    yPosition += rowHeight;

                }

                // Total
                decimal total = orders.Sum(order => order.ProductPrice);
                gfx.DrawRectangle(borderPen, 20, yPosition, page.Width - 40, rowHeight); // Draw border for total row
                gfx.DrawRectangle(XBrushes.White, 20, yPosition, page.Width - 40, rowHeight); // Fill background
                gfx.DrawString("Total:", fontHeader, textColor, new XRect(20, yPosition, columnWidth, rowHeight), XStringFormats.TopLeft);
                gfx.DrawString(total.ToString(), fontHeader, textColor, new XRect(20 + 2 * columnWidth, yPosition, columnWidth, rowHeight), XStringFormats.TopLeft);

                using (var ms = new MemoryStream())
                {
                    document.Save(ms);
                    return ms.ToArray();
                }
            }
        }



    }
}
