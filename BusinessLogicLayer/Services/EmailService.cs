using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Configuration;

namespace BusinessLogicLayer.Services
{
    public class EmailService
    {
        private readonly string _smtpHost;
        private readonly int _smtpPort;
        private readonly string _smtpUser;
        private readonly string _smtpPass;
        private readonly string _fromAddress;

        public EmailService()
        {
            _smtpHost = ConfigurationManager.AppSettings["SmtpHost"];
            _smtpPort = int.Parse(ConfigurationManager.AppSettings["SmtpPort"]);
            _smtpUser = ConfigurationManager.AppSettings["SmtpUser"];
            _smtpPass = ConfigurationManager.AppSettings["SmtpPass"];
            _fromAddress = ConfigurationManager.AppSettings["SmtpFrom"];
        }

        public bool SendEmail(string to, string subject, string body, bool isHtml = true)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(_fromAddress);
                mail.To.Add(to);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = isHtml;

                using (SmtpClient smtp = new SmtpClient(_smtpHost, _smtpPort))
                {
                    smtp.Credentials = new NetworkCredential(_smtpUser, _smtpPass);
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Email send failed: " + ex.Message);
                return false;
            }
        }
    }
}
