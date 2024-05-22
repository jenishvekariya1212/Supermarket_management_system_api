namespace Supermarketapi.Models
{
    public class BillModel
    {
      /*  public int ProductID { get; set; }
*/
        public string ProductName { get; set; }

        public decimal ProductPrice { get; set; }


        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        /*public decimal TotalPrice { get; set; }*/
        public int UserID { get; set; }

    }
}
