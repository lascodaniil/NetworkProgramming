using System;
using System.Net;
using System.Net.Mail;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestSMTP
{



    [TestClass]
    public class SMTP
    {
        SmtpClient _smtpClient = new SmtpClient("smtp.gmail.com", 587);
        MailMessage _mailMessage = new MailMessage();


        public bool True() {
            _smtpClient.Send(_mailMessage);
            return true;
        }


        [TestMethod]
        public void TryAuthentification()
        {
            SmtpClient _smtpClient = new SmtpClient("smtp.gmail.com", 587);
            _smtpClient.Credentials = new NetworkCredential("lascodaniil4@gmail.com", "");
            _mailMessage.From = new MailAddress("lascodaniil4@gmail.com");
            _mailMessage.To.Add("lascodaniil4@gmail.com");
            _mailMessage.IsBodyHtml = true;
            _smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            var check = True();
            Assert.AreEqual( check , true); // true
        }
        [TestMethod]

        public void TryAuthentificationOutlouk()
        {
            SmtpClient _smtpClient = new SmtpClient("smtp.gmail.com", 587);
            _smtpClient.Credentials = new NetworkCredential("daniil.lasco@ati.utm.md", "");
            _smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            _mailMessage.IsBodyHtml = true;
          //  _smtpClient.Send(_mailMessage);

            Assert.AreEqual(True(), true); // ERROR
        }

    }
}


