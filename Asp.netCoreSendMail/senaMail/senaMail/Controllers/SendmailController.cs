using Microsoft.AspNetCore.Mvc;
using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senaMail.Controllers
{
    public class SendmailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SendMail()
        {
            MimeMessage message = new MimeMessage();
            /*
                Bu setirde  biz mailin kimden gonderildiyini Configure etmeliyik
             */
            MailboxAddress from = new MailboxAddress("Admin","ilkin_huseynov_90@inbox.ru");
            message.From.Add(from);

            /*
             Burda kime gonderiecek mail
             */
            MailboxAddress to = new MailboxAddress("User","ilkin_huseynov_90@inbox.ru");
            message.To.Add(to);

            // Movzunun teyin edilmesi
            message.Subject = "This test for sendig mail";

            //Mailin bodysinin teyin etmek
            BodyBuilder bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = "<h1>Hello World </h1>";
            bodyBuilder.TextBody = "Hello World";

            message.Body = bodyBuilder.ToMessageBody();


            //  Smtplerin yazailmasi

            SmtpClient client = new SmtpClient();

            client.Connect("smtp.mail.ru",465);// birinci parametr hansi mail servici ikinci hemin mailinportu

            client.Authenticate("ilkin_huseynov_90@inbox.ru","ilkin0506843155");

            client.Send(message);
            client.Disconnect(true);
            client.Dispose();

            return new JsonResult("Message is sent");
        }
    }
}
