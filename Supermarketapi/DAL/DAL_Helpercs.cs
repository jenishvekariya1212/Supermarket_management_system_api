namespace Supermarketapi.DAL
{
    public class DAL_Helpercs
    {
        public static string Connstring = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("mystr");
    }
}
