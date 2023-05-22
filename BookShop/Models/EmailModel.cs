using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Models
{
    public class EmailModell
    {
    }
    public class EmailModel
    {
        public string To { get; set; }
    }

    public class ResetPasswordReq
    {
        public string Password { get; set; }
        public string Confirmpassword { get; set; }
    }
}
