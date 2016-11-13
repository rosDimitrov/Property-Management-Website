using Property_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Property_Management.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ManagementServices()
        {
            return View();
        }

        public ActionResult Pricing()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult About(EnquiryViewModel enquiry)
        {
            if (ModelState.IsValid)
            {
                 MailMessage msg = new MailMessage();
            msg.To.Add("email@yahoo.com");
            msg.Subject = "New Message from Adelina Property Management";
            msg.From = new MailAddress(enquiry.Email.ToString(),enquiry.Email.ToString());
            msg.Body = enquiry.Message.ToString() + " | " +enquiry.FirstName.ToString() +" | "+ enquiry.Phone.ToString();
                using (SmtpClient smtp = new SmtpClient())
                {
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.UseDefaultCredentials = false;
                    smtp.EnableSsl = true;
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.Credentials = new NetworkCredential("username@gmail.com", "password");
                    smtp.EnableSsl = true;
                    smtp.Send(msg);
                }
    
                //send mail
                //redirect to thank you page
            }
            return View();
        }
    }
}