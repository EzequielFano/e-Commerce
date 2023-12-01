using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class EmailService
    {
        private MailMessage email;
        private SmtpClient server;

        public EmailService()
        {
            server = new SmtpClient();
            server.Credentials = new NetworkCredential("technogeekprog3@gmail.com", "hvkz vije imqz fdmu");
            server.EnableSsl = true;
            server.Port = 587;
            server.Host = "smtp.gmail.com";
        }

        public void EmailCompra(string toAddress)
        {
            string cuerpoHtml = traercuerpoHTMLCompra();
            email = new MailMessage();
            email.From = new MailAddress("noresponder@technogeek.com.ar");
            email.To.Add(toAddress);
            email.Subject = "Gracias por tu compra by TechnoGeek";
            email.IsBodyHtml = true;
            email.Body = cuerpoHtml;
            EnviarMail();


        }
        private void EnviarMail()
        {
            try
            {
                server.Send(email);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private string traercuerpoHTMLCompra()
        {
            string aux = @"
            <html>
                <head>
                     <style>
            
            body {
                font-family: 'Arial', sans-serif;
                background-color: #f4f4f4;
                color: #333;
                padding: 20px;
            }

            .container {
                max-width: 600px;
                margin: 0 auto;
                background-color: rebeccapurple;
                padding: 20px;
                border-radius: 5px;
                box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            }

            h1 {
                color: #673ab7;
            }

            p {
                line-height: 1.6;
            }
        </style>
                </head>
                <body>
                    <div>
                        <p>Gracias por tu compra en TechnoGeek.</p>
                        <p>Estamos encantados de tenerte como cliente, pronto recibiras novedades sobre tu pedido </p>
                        <p>Te deseamos un buen dia. </p>
                        <p>TechnoGeek ARG </p>
                        
                    </div>
                </body>
            </html>";

            return aux;
        }
    }
}

