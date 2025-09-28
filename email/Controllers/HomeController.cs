using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;
using System.Runtime.Intrinsics.X86;


namespace YourNamespace.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SendEmail(string recipient, string subject, string body)
        {
            // Configure SMTP settings
            SmtpClient smtpClient = new SmtpClient("sandbox.smtp.mailtrap.io")
            {
                Port = 587,
                Credentials = new NetworkCredential("7c64d852fa2ae8", "fa554f7f00237b"),
                EnableSsl = true,

            };

            // Create the email message
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("your_email@example.com");
            mailMessage.To.Add(recipient);
            mailMessage.Subject = subject;
            mailMessage.Body = body;

            try
            {
                // Send the email
                smtpClient.Send(mailMessage);
                ViewBag.Message = "Email sent successfully!";
            }
            catch (Exception ex)
            {
                ViewBag.Error = $"Failed to send email: {ex.Message}";
            }

            return View("Index");
        }
    }
}