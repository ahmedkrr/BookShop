using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShop.Domain;
using BookShop.Models;
using System.Net.Mail;
using System.IO;
using System.Net;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Resourses.Account
{
    [ApiController]
    [Route("api/Account")]

    public class RequestResetPasswordByEmail : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public RequestResetPasswordByEmail(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpPost("sendEmail")]
        public async Task<object> SendEmailRequest([FromBody]EmailModel model)
        {
            var guid = Guid.NewGuid();

            DateTime expiration = DateTime.UtcNow; 

            var user = await _dbContext.Set<UserProfile>().FirstOrDefaultAsync(c => c.Email == model.To);

            if(user != null)
            {
                var request = new ResetPassword(guid.ToString(), user.Id);
                _dbContext.Add(request);
               await _dbContext.SaveChangesAsync();
            }

            using (var client = new SmtpClient("smtp.gmail.com", 587))
            {
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("infoautopart2023@gmail.com", "llpwqwrnhlwkhqzy");

                var emailMessage = new MailMessage
                {
                    From = new MailAddress("infoautopart2023@gmail.com", "Book Shop Reset Password"),
                    Subject = "Reset Password",
                    Body = "Your guid for 20 minutes : "+ guid,
                    IsBodyHtml = true
                };
                emailMessage.To.Add(new MailAddress(model.To));

                client.Send(emailMessage);
                return Ok();
            }


        }

        [HttpPost("resetpassword/{guid}")]
        public async Task<object> ResetPasswordRequest([FromBody]ResetPasswordReq model , [FromRoute] Guid guid)
        {
            var requestReset = await _dbContext.Set<ResetPassword>().FirstOrDefaultAsync(c => c.Guid == guid.ToString());
            if (requestReset == null || requestReset.RequestTime.AddMinutes(20) < DateTime.UtcNow)
                return BadRequest("Invalid or expired GUID");


            if (model.Password != model.Confirmpassword)
                return BadRequest("The Password Not Match");

            try
            {

                var user = await _dbContext.Set<UserProfile>().FirstOrDefaultAsync(c => c.Id == requestReset.UserProfileId); 

                user.ResetPassword(model.Password);
                await _dbContext.SaveChangesAsync();
                return Ok("The Password Changed Successfully");

            }
            catch(Exception e)
            {
                throw new Exception($"{e.Message}");
            }
        }
    }
}
