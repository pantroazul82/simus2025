using SM.Aplicacion.Notificacion;
using SM.LibreriaComun.DTO.General;
using SM.LibreriaComun.DTO.Notificacion;
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
    public static class NotificacionCorreo
    {
        public static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public static void MensajeNotificaionPorEstado(string email, 
                                                        string nombreRegistro, 
                                                        int estadoId, 
                                                        string modulo, 
                                                         int actorId,
                                                         int UsuarioId,
                                                         string nombreUsuario,
                                                         string motivo)
        {
            string asunto = string.Empty;
            string mensaje = string.Empty;
            var registro = new EstadoDTO();
            try
            {
                registro = SM.Aplicacion.Basicas.BasicaLogica.ObtenerEstadoMensaje(estadoId);
                if (registro != null)
                    EnvioCorreo(email, registro.Mensaje, registro.Nombre, nombreRegistro, modulo, estadoId, actorId, UsuarioId, nombreUsuario, motivo);
            }
            catch(Exception ex)
            {
                //throw ex;
                // Loguea, pero no detengas el flujo en desarrollo
                System.Diagnostics.Debug.WriteLine("Error enviando correo: " + ex.Message);
            }
        }

        private static void EnvioCorreo(string email, 
                                        string mensaje, 
                                        string estado, 
                                        string nombreRegistro, 
                                        string modulo, 
                                        int estadoId, 
                                        int actorId,
                                         int UsuarioId,
                                         string nombreUsuario,
                                         string motivo)
        {


            string strUrl = string.Empty;

            try
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

                string pathPlantilla = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "plantilla/notificacion.html");

                string htmlBody = "";
                using (StreamReader reader = new StreamReader(pathPlantilla))
                {
                    htmlBody = reader.ReadToEnd();
                }


                htmlBody = htmlBody.Replace("@mensaje", mensaje);
                htmlBody = htmlBody.Replace("@username", nombreRegistro);
                htmlBody = htmlBody.Replace("@estado", estado);
                htmlBody = htmlBody.Replace("@modulo", modulo);
                htmlBody = htmlBody.Replace("@motivo", motivo);

                if (estadoId == 2)
                {
                    strUrl = ObtenerUrl(actorId.ToString(), modulo);
                    htmlBody = htmlBody.Replace("@url", strUrl);
                    
                }
                else
                {
                    htmlBody = htmlBody.Replace("@url", "");

                }

                //email = "greymilenaj@gmail.com";
                string userToAcc = email;
                // string userTocc = userFromDisplay; 
                string userTocc = "simus@mincultura.gov.co";

                MailMessage objMail = new MailMessage();

                objMail.From = new MailAddress(userFromAcc, userFromDisplay);

                objMail.To.Add(email);
                objMail.CC.Add(userTocc);
                objMail.Subject = estado;

                objMail.IsBodyHtml = true;

                objMail.Body = htmlBody;


                Attachment oAttachment = new Attachment(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "img/correo/head.jpg"));
                oAttachment.ContentId = "head";
                objMail.Attachments.Add(oAttachment);

                Attachment oAttachment2 = new Attachment(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "img/correo/arrow.jpg"));
                oAttachment2.ContentId = "arrow";
                objMail.Attachments.Add(oAttachment2);

                Attachment oAttachment3 = new Attachment(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "img/correo/fb.jpg"));
                oAttachment3.ContentId = "facebook";
                objMail.Attachments.Add(oAttachment3);

                Attachment oAttachment4 = new Attachment(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "img/correo/tw.jpg"));
                oAttachment4.ContentId = "twitter";
                objMail.Attachments.Add(oAttachment4);

                Attachment oAttachment5 = new Attachment(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "img/correo/in.jpg"));
                oAttachment5.ContentId = "youtube";
                objMail.Attachments.Add(oAttachment5);

                Attachment oAttachment6 = new Attachment(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "img/correo/simus_logo_BN.jpg"));
                oAttachment6.ContentId = "logo_simus";
                objMail.Attachments.Add(oAttachment6);


                NetworkCredential objNC = new NetworkCredential(userFromAcc, userFromPass);
                SmtpClient objsmtp = new SmtpClient(host, port);
                objsmtp.EnableSsl = enableSsl;


                //Guardar en el historico

                var registro = new NotificacionDTO
                {
                    EstadoId = estadoId,
                    Modulo = modulo,
                    RegistroId = actorId,
                    NombreEstado = estado,
                    NombreUsuario = nombreUsuario,
                    UsuarioId = UsuarioId,
                    Tipo = "Notificacion",
                    Motivo = motivo
                };
                NotificacionNeg.Crear(registro);

                // ENvío correo

                objsmtp.Credentials = objNC;

                objsmtp.Send(objMail);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private static string ObtenerUrl(string id, string Modulo)
        {
            string url = string.Empty;
            if (Modulo == Comunes.ConstantesRecursosBD.ACTORES_AGENTES)
                url = "http://simus.mincultura.gov.co/Home/DetalleAgente/" + id;
            else if (Modulo == Comunes.ConstantesRecursosBD.ACTORES_AGRUPACIONES)
                url = "http://simus.mincultura.gov.co/Home/DetalleAgrupacion/" + id;
            else if (Modulo == Comunes.ConstantesRecursosBD.ACTORES_ENTIDADES)
                url = "http://simus.mincultura.gov.co/Home/DetalleEntidad/" + id;
            else if (Modulo == Comunes.ConstantesRecursosBD.ACTORES_ESCUELAS)
                url = "http://simus.mincultura.gov.co/Home/Ficha/" + id;
            return url;

        }
    }
}