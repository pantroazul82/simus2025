using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Web;

namespace WebSImus.Comunes
{
    public static class EnvioCorreo
    {

        public static void EnviarCorreoHtmlCreacionMusica(string email, string mensaje, string asunto, string nombreusuario)
        {

            string host = System.Configuration.ConfigurationManager.AppSettings["EmailHost"];
            int port = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["EmailPort"]);
            bool enableSsl = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["EmailEnableSSl"]);
            //int port = 
            string userFromAcc = System.Configuration.ConfigurationManager.AppSettings["EmailUserAcc"];
            //string userFromAcc = 

            string userFromDisplay = System.Configuration.ConfigurationManager.AppSettings["EmailUserDisplay"];
            //string userFromDisplay = 

            string userFromPass = System.Configuration.ConfigurationManager.AppSettings["EmailUserPass"];

            string pathPlantilla = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "plantilla/correoMusica.html");

            //HttpContext.Current.Server.MapPath("~/plantilla/correo.html");
            string htmlBody = "";
            using (StreamReader reader = new StreamReader(pathPlantilla))
            {
                htmlBody = reader.ReadToEnd();
            }


            htmlBody = htmlBody.Replace("@mensaje", mensaje);
            htmlBody = htmlBody.Replace("@username", nombreusuario);

            string userToAcc = email;




            //MailMessage objMail = new MailMessage(userFromAcc, email, asunto, mensaje);
            MailMessage objMail = new MailMessage();

            objMail.From = new MailAddress(userFromAcc, userFromDisplay);

            objMail.To.Add(email);

            objMail.Subject = asunto;


            objMail.IsBodyHtml = true;

            objMail.Body = htmlBody;


            Attachment oAttachment = new Attachment(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "img/logo_celebra_correo.png"));
            oAttachment.ContentId = "logodanza";
            objMail.Attachments.Add(oAttachment);

            Attachment oAttachment2 = new Attachment(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "img/logos_gubernamentales.png"));
            oAttachment2.ContentId = "logos_gubernamentales";
            objMail.Attachments.Add(oAttachment2);


            NetworkCredential objNC = new NetworkCredential(userFromAcc, userFromPass);
            SmtpClient objsmtp = new SmtpClient(host, port);
            objsmtp.EnableSsl = enableSsl;

           
            objsmtp.Credentials = objNC;

            try
            {
                objsmtp.Send(objMail);
            }
            catch (Exception)
            {

            }

        }

        public static void EnviarCorreoHtmlCreacionDanza(string email, string mensaje, string asunto, string nombreusuario)
        {

            string host = System.Configuration.ConfigurationManager.AppSettings["EmailHost"];
            int port = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["EmailPort"]);
            bool enableSsl = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["EmailEnableSSl"]);
            //int port = 
            string userFromAcc = System.Configuration.ConfigurationManager.AppSettings["EmailUserAcc"];
            //string userFromAcc = 

            string userFromDisplay = System.Configuration.ConfigurationManager.AppSettings["EmailUserDisplay"];
            //string userFromDisplay = 

            string userFromPass = System.Configuration.ConfigurationManager.AppSettings["EmailUserPass"];

            string pathPlantilla = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "plantilla/correoDanza.html");

            //HttpContext.Current.Server.MapPath("~/plantilla/correo.html");
            string htmlBody = "";
            using (StreamReader reader = new StreamReader(pathPlantilla))
            {
                htmlBody = reader.ReadToEnd();
            }


            htmlBody = htmlBody.Replace("@mensaje", mensaje);
            htmlBody = htmlBody.Replace("@username", nombreusuario);

            string userToAcc = email;




            //MailMessage objMail = new MailMessage(userFromAcc, email, asunto, mensaje);
            MailMessage objMail = new MailMessage();

            objMail.From = new MailAddress(userFromAcc, userFromDisplay);

            objMail.To.Add(email);

            objMail.Subject = asunto;


            objMail.IsBodyHtml = true;

            objMail.Body = htmlBody;


            Attachment oAttachment = new Attachment(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "img/logo-danza.png"));
            oAttachment.ContentId = "logodanza";
            objMail.Attachments.Add(oAttachment);

            Attachment oAttachment2 = new Attachment(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "img/logos_gubernamentales.png"));
            oAttachment2.ContentId = "logos_gubernamentales";
            objMail.Attachments.Add(oAttachment2);


            NetworkCredential objNC = new NetworkCredential(userFromAcc, userFromPass);
            SmtpClient objsmtp = new SmtpClient(host, port);
            objsmtp.EnableSsl = enableSsl;

         
            objsmtp.Credentials = objNC;

            try
            {
                objsmtp.Send(objMail);
            }
            catch (Exception)
            {

            }

        }

        public static void EnviarCorreoHtmlCreacion(string email, string mensaje, string asunto, string nombreusuario)
        {


            string host = System.Configuration.ConfigurationManager.AppSettings["EmailHost"];
            int port = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["EmailPort"]);
            bool enableSsl = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["EmailEnableSSl"]);
            //int port = 
            string userFromAcc = System.Configuration.ConfigurationManager.AppSettings["EmailUserAcc"];
            //string userFromAcc = 

            string userFromDisplay = System.Configuration.ConfigurationManager.AppSettings["EmailUserDisplay"];
            //string userFromDisplay = 

            string userFromPass = System.Configuration.ConfigurationManager.AppSettings["EmailUserPass"];

            string pathPlantilla = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "plantilla/correo.html");

            //HttpContext.Current.Server.MapPath("~/plantilla/correo.html");
            string htmlBody = "";
            using (StreamReader reader = new StreamReader(pathPlantilla))
            {
                htmlBody = reader.ReadToEnd();
            }


            htmlBody = htmlBody.Replace("@mensaje", mensaje);
            htmlBody = htmlBody.Replace("@username", nombreusuario);

            string userToAcc = email;




            //MailMessage objMail = new MailMessage(userFromAcc, email, asunto, mensaje);
            MailMessage objMail = new MailMessage();

            objMail.From = new MailAddress(userFromAcc, userFromDisplay);

            objMail.To.Add(email);

            objMail.Subject = asunto;


            objMail.IsBodyHtml = true;

            objMail.Body = htmlBody;


            Attachment oAttachment = new Attachment(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "img/logo_simus.png"));
            oAttachment.ContentId = "logosimus";
            objMail.Attachments.Add(oAttachment);
           
            Attachment oAttachment2 = new Attachment(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "img/logos_gubernamentales.png"));
            oAttachment2.ContentId = "logos_gubernamentales";
            objMail.Attachments.Add(oAttachment2);


            NetworkCredential objNC = new NetworkCredential(userFromAcc, userFromPass);
            SmtpClient objsmtp = new SmtpClient(host, port);
            objsmtp.EnableSsl = enableSsl;

          
            objsmtp.Credentials = objNC;
            
            try
            {
                objsmtp.Send(objMail);
            }
            catch (Exception)
            {

            }

        }


        public static void EnviarCorreoRestablecerContrasena(string email, int id, string nombreusuario)
        {
            string host = System.Configuration.ConfigurationManager.AppSettings["EmailHost"];
            int port = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["EmailPort"]);
            bool enableSsl = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["EmailEnableSSl"]);
            //int port = 
            string userFromAcc = System.Configuration.ConfigurationManager.AppSettings["EmailUserAcc"];
            //string userFromAcc = 

            string userFromDisplay = System.Configuration.ConfigurationManager.AppSettings["EmailUserDisplay"];
            //string userFromDisplay = 

            string userFromPass = System.Configuration.ConfigurationManager.AppSettings["EmailUserPass"];

            string pathPlantilla = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "plantilla/restablcerpassword.html");
            string token = GenerarNuevoToken();

            //HttpContext.Current.Server.MapPath("~/plantilla/correo.html");
            string htmlBody = "";
            using (StreamReader reader = new StreamReader(pathPlantilla))
            {
                htmlBody = reader.ReadToEnd();
            }
            string URL = System.Configuration.ConfigurationManager.AppSettings["EmailurlPass"];
            URL += "?Tok=" + token.Trim() + "&di=" + id;

            htmlBody = htmlBody.Replace("@url", URL);
            htmlBody = htmlBody.Replace("@username", nombreusuario);

            string userToAcc = email;

            string asunto = "Restablecer contraseña SIMUS";


            //MailMessage objMail = new MailMessage(userFromAcc, email, asunto, mensaje);
            MailMessage objMail = new MailMessage();

            objMail.From = new MailAddress(userFromAcc, userFromDisplay);

            objMail.To.Add(email);

            objMail.Subject = asunto;


            objMail.IsBodyHtml = true;

            objMail.Body = htmlBody;



            Attachment oAttachment = new Attachment(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "img/logo_simus.png"));
            oAttachment.ContentId = "logosimus";
            objMail.Attachments.Add(oAttachment);

            Attachment oAttachment2 = new Attachment(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "img/logos_gubernamentales.png"));
            oAttachment2.ContentId = "logos_gubernamentales";
            objMail.Attachments.Add(oAttachment2);


            NetworkCredential objNC = new NetworkCredential(userFromAcc, userFromPass);
            SmtpClient objsmtp = new SmtpClient(host, port);
            objsmtp.EnableSsl = enableSsl;
            objsmtp.Credentials = objNC;
            try
            {
                objsmtp.Send(objMail);
            }
            catch (Exception)
            {

            }
        }

        public static void EnviarCorreoRestablecerContrasenaDanza(string email, int id, string nombreusuario)
        {
            string host = System.Configuration.ConfigurationManager.AppSettings["EmailHost"];
            int port = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["EmailPort"]);
            bool enableSsl = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["EmailEnableSSl"]);
            //int port = 
            string userFromAcc = System.Configuration.ConfigurationManager.AppSettings["EmailUserAcc"];
            //string userFromAcc = 

            string userFromDisplay = System.Configuration.ConfigurationManager.AppSettings["EmailUserDisplay"];
            //string userFromDisplay = 

            string userFromPass = System.Configuration.ConfigurationManager.AppSettings["EmailUserPass"];

            string pathPlantilla = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "plantilla/restablcerpassworddanza.html");
            string token = GenerarNuevoToken();

            //HttpContext.Current.Server.MapPath("~/plantilla/correo.html");
            string htmlBody = "";
            using (StreamReader reader = new StreamReader(pathPlantilla))
            {
                htmlBody = reader.ReadToEnd();
            }
            string URL = System.Configuration.ConfigurationManager.AppSettings["EmailurlPass"];
            URL += "?Tok=" + token.Trim() + "&di=" + id;

            htmlBody = htmlBody.Replace("@url", URL);
            htmlBody = htmlBody.Replace("@username", nombreusuario);

            string userToAcc = email;

            string asunto = "Restablecer contraseña";


            //MailMessage objMail = new MailMessage(userFromAcc, email, asunto, mensaje);
            MailMessage objMail = new MailMessage();

            objMail.From = new MailAddress(userFromAcc, userFromDisplay);

            objMail.To.Add(email);

            objMail.Subject = asunto;


            objMail.IsBodyHtml = true;

            objMail.Body = htmlBody;



            Attachment oAttachment = new Attachment(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "img/logo-danza.png"));
            oAttachment.ContentId = "logodanza";
            objMail.Attachments.Add(oAttachment);

            Attachment oAttachment2 = new Attachment(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "img/logos_gubernamentales.png"));
            oAttachment2.ContentId = "logos_gubernamentales";
            objMail.Attachments.Add(oAttachment2);


            NetworkCredential objNC = new NetworkCredential(userFromAcc, userFromPass);
            SmtpClient objsmtp = new SmtpClient(host, port);
            objsmtp.EnableSsl = enableSsl;
            objsmtp.Credentials = objNC;
            try
            {
                objsmtp.Send(objMail);
            }
            catch (Exception)
            {

            }
        }

        public static void EnviarCorreoRestablecerContrasenaMusica(string email, int id, string nombreusuario)
        {
            string host = System.Configuration.ConfigurationManager.AppSettings["EmailHost"];
            int port = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["EmailPort"]);
            bool enableSsl = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["EmailEnableSSl"]);
            //int port = 
            string userFromAcc = System.Configuration.ConfigurationManager.AppSettings["EmailUserAcc"];
            //string userFromAcc = 

            string userFromDisplay = System.Configuration.ConfigurationManager.AppSettings["EmailUserDisplay"];
            //string userFromDisplay = 

            string userFromPass = System.Configuration.ConfigurationManager.AppSettings["EmailUserPass"];

            string pathPlantilla = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "plantilla/restablecerMusica.html");
            string token = GenerarNuevoToken();

            //HttpContext.Current.Server.MapPath("~/plantilla/correo.html");
            string htmlBody = "";
            using (StreamReader reader = new StreamReader(pathPlantilla))
            {
                htmlBody = reader.ReadToEnd();
            }
            string URL = @"http://simus.mincultura.gov.co/CambioPassword/RestablecerCelebra";
           
            htmlBody = htmlBody.Replace("@url", URL);
            htmlBody = htmlBody.Replace("@username", nombreusuario);

            string userToAcc = email;

            string asunto = "Restablecer contraseña";


            //MailMessage objMail = new MailMessage(userFromAcc, email, asunto, mensaje);
            MailMessage objMail = new MailMessage();

            objMail.From = new MailAddress(userFromAcc, userFromDisplay);

            objMail.To.Add(email);

            objMail.Subject = asunto;


            objMail.IsBodyHtml = true;

            objMail.Body = htmlBody;



            Attachment oAttachment = new Attachment(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "img/logo_celebra_correo.png"));
            oAttachment.ContentId = "logodanza";
            objMail.Attachments.Add(oAttachment);

            Attachment oAttachment2 = new Attachment(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "img/logos_gubernamentales.png"));
            oAttachment2.ContentId = "logos_gubernamentales";
            objMail.Attachments.Add(oAttachment2);


            NetworkCredential objNC = new NetworkCredential(userFromAcc, userFromPass);
            SmtpClient objsmtp = new SmtpClient(host, port);
            objsmtp.EnableSsl = enableSsl;
            objsmtp.Credentials = objNC;
            try
            {
                objsmtp.Send(objMail);
            }
            catch (Exception)
            {

            }
        }
        /// <summary>
        /// envio de correo para los administradores
        /// </summary>
        /// <param name="mensaje"></param>
        /// <param name="asunto"></param>
        /// <param name="nombreusuario"></param>
        public static void EnviarCorreoEscuelas(string mensaje, string asunto, string nombreusuario)
        {


            string host = System.Configuration.ConfigurationManager.AppSettings["EmailHost"];
            int port = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["EmailPort"]);
            bool enableSsl = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["EmailEnableSSl"]);
            //int port = 
            string userFromAcc = System.Configuration.ConfigurationManager.AppSettings["EmailUserAcc"];
            //string userFromAcc = 

            string userFromDisplay = System.Configuration.ConfigurationManager.AppSettings["EmailUserDisplay"];
            //string userFromDisplay = 

            string userFromPass = System.Configuration.ConfigurationManager.AppSettings["EmailUserPass"];

            string pathPlantilla = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "plantilla/Escuelas.html");

            //HttpContext.Current.Server.MapPath("~/plantilla/correo.html");
            string htmlBody = "";
            using (StreamReader reader = new StreamReader(pathPlantilla))
            {
                htmlBody = reader.ReadToEnd();
            }


            htmlBody = htmlBody.Replace("@mensaje", mensaje);
            htmlBody = htmlBody.Replace("@username", nombreusuario);

            string userToAcc = System.Configuration.ConfigurationManager.AppSettings["EmailUseradmin"]; ;




            //MailMessage objMail = new MailMessage(userFromAcc, email, asunto, mensaje);
            MailMessage objMail = new MailMessage();

            objMail.From = new MailAddress(userFromAcc, userFromDisplay);

            objMail.To.Add(userToAcc);

            objMail.Subject = asunto;


            objMail.IsBodyHtml = true;

            objMail.Body = htmlBody;



            Attachment oAttachment = new Attachment(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "img/logo_simus.png"));
            oAttachment.ContentId = "logosimus";
            objMail.Attachments.Add(oAttachment);

            Attachment oAttachment2 = new Attachment(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "img/logos_gubernamentales.png"));
            oAttachment2.ContentId = "logos_gubernamentales";
            objMail.Attachments.Add(oAttachment2);


            NetworkCredential objNC = new NetworkCredential(userFromAcc, userFromPass);
            SmtpClient objsmtp = new SmtpClient(host, port);
            objsmtp.EnableSsl = enableSsl;
            objsmtp.Credentials = objNC;
            try
            {
                objsmtp.Send(objMail);
            }
            catch (Exception)
            {

            }

        }


        public static string GenerarNuevoToken()
        {

            //Inactivar anterior Token si lo hay
            byte[] time = BitConverter.GetBytes(DateTime.UtcNow.ToBinary());
            byte[] key = Guid.NewGuid().ToByteArray();
            string token = Convert.ToBase64String(time.Concat(key).ToArray());

            return token;
        }

        /// <summary>
        /// Envía correo de confirmación a la alcaldía cuando se crea una nueva versión de festival
        /// </summary>
        /// <param name="emailAlcaldia">Correo de contacto de la alcaldía</param>
        /// <param name="nombreFestival">Nombre del festival</param>
        /// <param name="nombreVersion">Nombre de la versión</param>
        /// <param name="numeroVersion">Número de versión</param>
        public static void EnviarCorreoFestivalAlcaldia(string emailAlcaldia, string nombreFestival, string nombreVersion, int numeroVersion)
        {
            try
            {
                string host = System.Configuration.ConfigurationManager.AppSettings["EmailHost"];
                int port = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["EmailPort"]);
                bool enableSsl = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["EmailEnableSSl"]);
                string userFromAcc = System.Configuration.ConfigurationManager.AppSettings["EmailUserAcc"];
                string userFromDisplay = System.Configuration.ConfigurationManager.AppSettings["EmailUserDisplay"];
                string userFromPass = System.Configuration.ConfigurationManager.AppSettings["EmailUserPass"];

                string asunto = "Confirmaci&#243;n de registro de versi&#243;n de festival - SIMUS";

                string htmlBody = @"
<!DOCTYPE html>
<html>
<head>
    <meta charset='UTF-8'>
    <style>
        body { font-family: Arial, sans-serif; line-height: 1.6; color: #333; }
        .container { max-width: 600px; margin: 0 auto; padding: 20px; }
        .header { background-color: #2c9c94; color: white; padding: 20px; text-align: center; }
        .content { background-color: #f9f9f9; padding: 20px; border: 1px solid #ddd; }
        .footer { text-align: center; padding: 10px; font-size: 12px; color: #666; }
        .info-box { background-color: #e8f5f4; padding: 15px; margin: 15px 0; border-left: 4px solid #2c9c94; }
    </style>
</head>
<body>
    <div class='container'>
        <div class='header'>
            <h2>Sistema de Informaci&#243;n de la M&#250;sica - SIMUS</h2>
        </div>
        <div class='content'>
            <p>Estimado usuario,</p>
            
            <p>Su solicitud de registro de versi&#243;n de festival ha sido recibida exitosamente.</p>
            
            <div class='info-box'>
                <strong>Festival:</strong> {0}<br>
                <strong>Versi&#243;n:</strong> {1} (N&#250;mero {2})
            </div>
            
            <p>La informaci&#243;n ser&#225; revisada por el equipo de SIMUS y se le dar&#225; respuesta en el menor tiempo posible.</p>
            
            <p>Si tiene alguna pregunta o necesita realizar alg&#250;n cambio, por favor comun&#237;quese con nosotros.</p>
            
            <p>Atentamente,<br>
            <strong>Equipo SIMUS - Ministerio de Cultura</strong></p>
        </div>
        <div class='footer'>
            <p>Este es un mensaje autom&#225;tico, por favor no responder a este correo.</p>
        </div>
    </div>
</body>
</html>";

                htmlBody = string.Format(htmlBody, nombreFestival, nombreVersion, numeroVersion);

                MailMessage objMail = new MailMessage();
                objMail.From = new MailAddress(userFromAcc, userFromDisplay);
                objMail.To.Add(emailAlcaldia);
                objMail.Subject = asunto;
                objMail.IsBodyHtml = true;
                objMail.Body = htmlBody;

                NetworkCredential objNC = new NetworkCredential(userFromAcc, userFromPass);
                SmtpClient objsmtp = new SmtpClient(host, port);
                objsmtp.EnableSsl = enableSsl;
                objsmtp.Credentials = objNC;

                objsmtp.Send(objMail);
            }
            catch (Exception ex)
            {
                // Log del error pero no lanzar excepción para no bloquear el flujo principal
                string ruta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log");
                if (!Directory.Exists(ruta))
                    Directory.CreateDirectory(ruta);
                
                string archivo = Path.Combine(ruta, $"Log{DateTime.Now:yyyyMMdd}.txt");
                File.AppendAllText(archivo, $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - Error enviando correo a alcald&#237;a: {ex.ToString()}\r\n");
            }
        }

        /// <summary>
        /// Envía correo de notificación a SIMUS cuando se crea una nueva versión de festival
        /// </summary>
        /// <param name="nombreFestival">Nombre del festival</param>
        /// <param name="nombreVersion">Nombre de la versión</param>
        /// <param name="numeroVersion">Número de versión</param>
        /// <param name="emailAlcaldia">Correo de contacto de la alcaldía</param>
        /// <param name="departamento">Departamento donde se realiza</param>
        /// <param name="municipio">Municipio donde se realiza</param>
        public static void EnviarCorreoFestivalSimus(string nombreFestival, string nombreVersion, int numeroVersion, 
            string emailAlcaldia, string departamento, string municipio)
        {
            try
            {
                string host = System.Configuration.ConfigurationManager.AppSettings["EmailHost"];
                int port = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["EmailPort"]);
                bool enableSsl = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["EmailEnableSSl"]);
                string userFromAcc = System.Configuration.ConfigurationManager.AppSettings["EmailUserAcc"];
                string userFromDisplay = System.Configuration.ConfigurationManager.AppSettings["EmailUserDisplay"];
                string userFromPass = System.Configuration.ConfigurationManager.AppSettings["EmailUserPass"];

                string emailSimus = "simus@mincultura.gov.co";
                string asunto = "Nueva versi&#243;n de festival registrada - SIMUS";

                string htmlBody = @"
<!DOCTYPE html>
<html>
<head>
    <meta charset='UTF-8'>
    <style>
        body { font-family: Arial, sans-serif; line-height: 1.6; color: #333; }
        .container { max-width: 600px; margin: 0 auto; padding: 20px; }
        .header { background-color: #2c9c94; color: white; padding: 20px; text-align: center; }
        .content { background-color: #f9f9f9; padding: 20px; border: 1px solid #ddd; }
        .footer { text-align: center; padding: 10px; font-size: 12px; color: #666; }
        .info-box { background-color: #e8f5f4; padding: 15px; margin: 15px 0; border-left: 4px solid #2c9c94; }
        .data-row { margin: 8px 0; }
    </style>
</head>
<body>
    <div class='container'>
        <div class='header'>
            <h2>Nueva Versi&#243;n de Festival Registrada</h2>
        </div>
        <div class='content'>
            <p>Se ha registrado una nueva versi&#243;n de festival en el sistema SIMUS.</p>
            
            <div class='info-box'>
                <div class='data-row'><strong>Festival:</strong> {0}</div>
                <div class='data-row'><strong>Versi&#243;n:</strong> {1}</div>
                <div class='data-row'><strong>N&#250;mero de versi&#243;n:</strong> {2}</div>
                <div class='data-row'><strong>Departamento:</strong> {3}</div>
                <div class='data-row'><strong>Municipio:</strong> {4}</div>
                <div class='data-row'><strong>Correo de contacto:</strong> {5}</div>
            </div>
            
            <p><strong>Por favor revise la informaci&#243;n registrada y proceda con la validaci&#243;n correspondiente.</strong></p>
            
            <p>Atentamente,<br>
            <strong>Sistema SIMUS</strong></p>
        </div>
        <div class='footer'>
            <p>Este es un mensaje autom&#225;tico generado por el Sistema de Informaci&#243;n de la M&#250;sica.</p>
        </div>
    </div>
</body>
</html>";

                htmlBody = string.Format(htmlBody, nombreFestival, nombreVersion, numeroVersion, 
                    departamento ?? "No especificado", municipio ?? "No especificado", emailAlcaldia);

                MailMessage objMail = new MailMessage();
                objMail.From = new MailAddress(userFromAcc, userFromDisplay);
                objMail.To.Add(emailSimus);
                objMail.Subject = asunto;
                objMail.IsBodyHtml = true;
                objMail.Body = htmlBody;

                NetworkCredential objNC = new NetworkCredential(userFromAcc, userFromPass);
                SmtpClient objsmtp = new SmtpClient(host, port);
                objsmtp.EnableSsl = enableSsl;
                objsmtp.Credentials = objNC;

                objsmtp.Send(objMail);
            }
            catch (Exception ex)
            {
                // Log del error pero no lanzar excepción para no bloquear el flujo principal
                string ruta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log");
                if (!Directory.Exists(ruta))
                    Directory.CreateDirectory(ruta);
                
                string archivo = Path.Combine(ruta, $"Log{DateTime.Now:yyyyMMdd}.txt");
                File.AppendAllText(archivo, $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - Error enviando correo a SIMUS: {ex.ToString()}\r\n");
            }
        }
    }

}