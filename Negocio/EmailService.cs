using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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

        public void EmailCompra(string toAddress, int idtransaccion,string nombreusuario)
        {
            email = new MailMessage();
            email.From = new MailAddress("noresponder@technogeek.com.ar");
            email.To.Add(toAddress);
            email.Subject = "Gracias por tu compra en TechnoGeek";
            email.IsBodyHtml = true;

            string cuerpoCorreo = $@"
        <div>
            <h1>Hola {nombreusuario}! Gracias por tu compra en TechnoGeek.</h1>
            <p>Estamos encantados de tenerte como cliente, pronto nos pondremos en contacto contigo para contarte novedades sobre tu pedido.</p>
            <h3>{idtransaccion} <-- Este sera tu numero de pedido.</h3>
            <p>Te deseamos un buen día.</p>
            <p>TechnoGeek ARG</p>
        </div>";

            email.Body = cuerpoCorreo;
            EnviarMail();
            email.To.Clear();
            email.To.Add("technogeekprog3@gmail.com");
            email.Subject = "Has recibido una nueva compra";
            email.IsBodyHtml = true;

            cuerpoCorreo = $@"
        <div>
            <h1>Has recibido una nueva compra de {nombreusuario}, numero de transaccion: {idtransaccion}</h1>           
            <p>TechnoGeek ARG</p>
        </div>";

            email.Body = cuerpoCorreo;
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
        public void EmailConsulta(string nombreconsulta, string emailconsulta, string cuerpoconsulta)
        {
            email = new MailMessage();
            email.From = new MailAddress("Clientes@technogeek.com");
            email.To.Add("technogeekprog3@gmail.com");
            email.Subject = "Haz recibido una consulta";
            email.IsBodyHtml = true;
            email.Body = $@" 
                    <div>
                        <h1>Tiene una consulta de {nombreconsulta}.</h1>
                        <h2>Email del consultante: {emailconsulta}</h2>
                        <h4>Consulta: {cuerpoconsulta}</h4>                        
                    </div>";
            EnviarMail();
            email.To.Clear();
            email.To.Add(emailconsulta);
            email.Subject = "Hemos recibido tu consulta";
            email.IsBodyHtml = true;
            email.Body = $@" 
                    <div>
                        <h1>Hola {nombreconsulta}, ya recibimos tu consulta!</h1>
                        <h4>Te estaremos enviando una respuesta a la brevedad al correo: {emailconsulta}.</h4>
                        <h4>Gracias por tu consulta.</h4>                        
                        <p>TechnoGeek ARG.</p>                        
                    </div>";
            EnviarMail();
        }
        public void EmailAlUsuario(string nombreusuario,string toAddress,string consulta)
        {
            email = new MailMessage();
            email.From = new MailAddress("noresponder@technogeek.com.ar");
            email.To.Add(toAddress);
            email.Subject = "nuevo mensaje de TechnoGeek ARG";
            email.IsBodyHtml = true;
            string cuerpoCorreo = consulta;        
            email.Body = $@" 
                    <div>
                        <h1>Hola,{nombreusuario}. Tienes un nuevo mensaje de TechnoGeek ARG.</h1>
                        <h4> {consulta}</h4>                                                
                    </div>";
            EnviarMail();
        }

    }
}

