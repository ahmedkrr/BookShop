using BookShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Domain
{
    public class UserProfile
    {
        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string MiddleName { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public UserRole Role { get; private set; }
        public DateTime CreatDate { get; private set; }
        public ICollection<ResetPassword> ResetPasswords { get; set; }




        public UserProfile()
        {

        }

        public UserProfile(string firstname, string middlename, string email, string password)
        {
            FirstName = firstname;
            MiddleName = middlename;
            Email = email;
            Password = password;
            CreatDate = DateTime.UtcNow;
            Role = UserRole.Member;
        }

        public void ResetPassword(string password)
        {
            Password = password;
        }
           
    }
    
}
