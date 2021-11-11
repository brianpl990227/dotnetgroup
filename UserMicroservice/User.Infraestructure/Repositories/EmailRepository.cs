using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace User.Infraestructure.Repositories
{
    public class EmailRepository
    {
        private SmtpClient client;

        /**
         * Host: smtp.gmail.com
         * Port: 465
         * UseSSL: true
         * username or email: dotnetgroup00@gmail.com
         * Password: DotNetGroup*00
         **/
        public EmailRepository()
        {
            client = new SmtpClient()
            {
                Host = "smtp.gmail.com",
                Port = 587,
            //    DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential("dotnetgroup00@gmail.com", "DotNetGroup*00"),
             //   UseDefaultCredentials = false,
                EnableSsl = true
            };
        }

        public async Task Test()
        {
            try
            {


                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("DotNetGroup", "DotNetGroup*00"));
                message.To.Add(new MailboxAddress("brianpl990227@gmail.com"));
                message.Subject = "Esto es un correo de prueba";
                message.Body = new TextPart("text")
                {
                    Text = "Esto es un correo desde el microservicio de usuarios"
                };

                

                using (var client = new MailKit.Net.Smtp.SmtpClient())
                {
                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                    await client.ConnectAsync("smtp.gmail.com", 465, true);
                    await client.AuthenticateAsync("dotnetgroup00@gmail.com", "DotNetGroup*00");
                    await client.SendAsync(message);
                    await client.DisconnectAsync(true);

                }




            }
            catch (Exception e)
            {
                throw new InvalidOperationException(e.Message);
            }
        }

        public async Task SendCode()
        {

            int value = new Random().Next(100000, 999999);

            string test = "<h1>Esto es una prueba</h1> <p>Este es tu código: <strong>"+value+"</strong></p>";

            var email = new MailMessage();
            email.To.Add("brianpl990227@gmail.com");
            email.Subject = "Correo de prueba";
            email.SubjectEncoding = Encoding.UTF8;
            email.Body = test;
            email.BodyEncoding = Encoding.UTF8;
            email.IsBodyHtml = true;
            email.From = new MailAddress("dotnetgroup00@gmail.com");
            await client.SendMailAsync(email);
        }

      
    }
    
}
