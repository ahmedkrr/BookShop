using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Models
{
    public class UserModel
    {
    }
    public class CreateAccountRequest
    {
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        
    }
    public class CreateAccountResponse
    {
        public string Email { get; set; }
        public string message { get; set; }
    }
    public class LoginReq
    {
        public string Email { get; set; }
        public string password { get; set; }
    }
    public class LoginResponse
    {
        public string Message { get; set; }
        public string Token { get; set; }

    }
    public enum UserRole
    {
        undefined = 0,
        Member = 1,
        Admin = 2
    }
}
