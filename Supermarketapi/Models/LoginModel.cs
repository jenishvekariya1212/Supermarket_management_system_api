﻿namespace Supermarketapi.Models
{
    public class LoginModel
    {
        public int UserID { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
       
        public string UserName { get; set;} 
        public string Password { get; set; }
        public string Email { get; set; }
        public Boolean ISActive { get; set; }
    }
}
