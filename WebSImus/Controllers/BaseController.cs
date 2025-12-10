using SM.LibreriaComun.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebSImus.Helpers;

namespace WebSImus.Controllers
{
    public abstract class BaseController : Controller
    {
        //
        public void Success(string message, bool dismissable = false)
        {
            AddAlert(AlertStyles.Success, message, dismissable);
        }

        public void Information(string message, bool dismissable = false)
        {
            AddAlert(AlertStyles.Information, message, dismissable);
        }

        public void Warning(string message, bool dismissable = false)
        {
            AddAlert(AlertStyles.Warning, message, dismissable);
        }

        public void Danger(string message, bool dismissable = false)
        {
            AddAlert(AlertStyles.Danger, message, dismissable);
        }

        private void AddAlert(string alertStyle, string message, bool dismissable)
        {
            var alerts = TempData.ContainsKey(Alert.TempDataKey)
                ? (List<Alert>)TempData[Alert.TempDataKey]
                : new List<Alert>();

            alerts.Add(new Alert
            {
                AlertStyle = alertStyle,
                Message = message,
                Dismissable = dismissable
            });

            TempData[Alert.TempDataKey] = alerts;
        }

      

        /// <summary>
        /// Mensaje paa registro de simis
        /// mensaje de restablcer contraseña
        /// mensaje de termino de seccion
        /// mensaje de token invalido
        /// </summary>
        public void MensajesAccesoSimus()
        {


            if (Session["$usuario"] != null)
            {
                UsuarioDTOSIM objRegistro = (UsuarioDTOSIM)Session["$usuario"];

              
                if (objRegistro != null && objRegistro.escreateeditexistoso)
                {
                    string message = string.Format("<b>{0}</b>," + " Se ha realizado el proceso satisfactoriamente.. ", objRegistro.PrimerNombre + " " + objRegistro.PrimerApellido);
                    // ((UsuarioDTOSIM)Session["$usuario"]).tokenInvalido = false;
                    objRegistro.escreateeditexistoso = false;
                    Session["$usuario"] = objRegistro;
                    AddAlert(AlertStyles.Success, message, true);
                }

                if (objRegistro != null && objRegistro.esactualizadoPerfil)
                {
                    string message = string.Format("<b>{0}</b>," + "Se ha realizado el proceso de actualización satisfactoriamente..", objRegistro.PrimerNombre + " " + objRegistro.PrimerApellido);
                    // ((UsuarioDTOSIM)Session["$usuario"]).tokenInvalido = false;
                    objRegistro.esactualizadoPerfil = false;
                    Session["$usuario"] = objRegistro;
                    AddAlert(AlertStyles.Success, message, true);
                }

                if (objRegistro != null && objRegistro.esactualizadoMenu)
                {
                    string message = string.Format("<b>{0}</b>," + "Se ha realizado el proceso satisfactoriamente..", objRegistro.PrimerNombre + " " + objRegistro.PrimerApellido);
                    // ((UsuarioDTOSIM)Session["$usuario"]).tokenInvalido = false;
                    objRegistro.esactualizadoMenu = false;
                    Session["$usuario"] = objRegistro;
                    AddAlert(AlertStyles.Success, message, true);
                }


            }

        }


        ///administración de usuario
        ///
        public string Usuario
        {
            get
            {
                if (!User.Identity.IsAuthenticated)
                    return string.Empty;

                FormsIdentity formsIdentity = User.Identity as FormsIdentity;
                if (formsIdentity != null)
                {
                    return formsIdentity.Ticket.UserData.Split('|')[1];
                }

                return string.Empty;
            }
        }

        /// <summary>
        /// Retorna el nombre de completo del usuario actual
        /// </summary>
        public string NombreCompletoUsuario
        {
            get
            {
                if (!User.Identity.IsAuthenticated)
                    return string.Empty;

                return User.Identity.Name;
            }
        }

        ///// <summary>
        ///// Retorna el Id del usuario
        ///// </summary>
        public string UsuaroId
        {
            get
            {
                if (!User.Identity.IsAuthenticated)
                    return string.Empty;

                FormsIdentity formsIdentity = User.Identity as FormsIdentity;
                if (formsIdentity != null)
                {
                    return formsIdentity.Ticket.UserData.Split('|')[0];
                }

                return string.Empty;
            }
        }

        ///// <summary>
        ///// Retorna el nombre completo del usuario autenticado
        ///// </summary>
        public string NombrePerfil
        {
            get
            {
                if (!User.Identity.IsAuthenticated)
                    return string.Empty;

                FormsIdentity formsIdentity = User.Identity as FormsIdentity;
                if (formsIdentity != null)
                {
                    return formsIdentity.Ticket.UserData.Split('|')[2];
                }

                return string.Empty;
            }
        }


        protected override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            var response = filterContext.HttpContext.Response;
            response.Cache.SetExpires(DateTime.Now.AddDays(-1));
            response.Cache.SetValidUntilExpires(false);
            response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
            response.Cache.SetCacheability(HttpCacheability.NoCache);
            response.Cache.SetNoStore();
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //IUsuariosServicio usuariosServicio = UnityConfig.GetConfiguredContainer().Resolve<IUsuariosServicio>("UsuariosServicio");

            //if ((filterContext.ActionDescriptor.ControllerDescriptor.ControllerName == "Home" && filterContext.ActionDescriptor.ActionName == "Index") || !filterContext.ActionDescriptor.IsDefined(typeof(ExcluirAutorizacionAttribute), true))
            //{
            //    var url = Request.Url != null ? Request.Url.AbsolutePath : string.Empty;
            //    ViewBag.Menu = usuariosServicio.ObtenerMenu(UsuaroId, url);
            //}

            //base.OnActionExecuting(filterContext);
        }



    }
}