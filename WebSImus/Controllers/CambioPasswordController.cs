using SM.LibreriaComun.DTO;
using SM.Utilidades.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSImus.Models;

namespace WebSImus.Controllers
{
    [HandleError()]

    public class CambioPasswordController : BaseController
    {
        //
        // GET: /CambioPassword/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CambioPass()
        {
            //valida si viene del registro
            if (Request["Tok"] != null && Request["Tok"] != string.Empty && Request["di"] != null && Request["di"] != string.Empty)
            {
                string Token = Request["Tok"];

                if (bvalidateToaken(Token))
                {

                    RestablecerModel obj = new RestablecerModel();
                    obj.idUserSimus = int.Parse(Request["di"]);
                    UsuarioDTOSIM objUser = SM.Aplicacion.Modulo_Usuarios.UsuarioLogica.obtenerUsuarioporId(obj.idUserSimus);
                    obj.correo = objUser.Email;

                    return View(obj);
                }

            }
            else
            {               
                TempData["TokenInvalido"] = true;
                return RedirectToAction("Login", "Cuenta");
            }

            return View();
        }
        public ActionResult Index(string token)
        {
            //To Do
            return View();
        }

        public ActionResult Restablecer(string token)
        {

            RestablecerModel obj = new RestablecerModel();

            return View(obj);



        }

        [HttpPost]
        public ActionResult Restablecer(RestablecerModel model)
        {
            if (!ModelState.IsValid)
            {

                return View("CambioPass", model);
            }


            UsuarioDTOSIM objUser = SM.Aplicacion.Modulo_Usuarios.UsuarioLogica.obtenerUsuarioporEmail(model.correo, Comunes.ConstantesRecursosBD.SIMUS_USUARIO_TIPO_SIMUS);
            if (objUser.TipoRSS == "MINCULTURA")
            {
                Warning(string.Format("<b></b> Acepte términos y condiciones "), true);
                return View("CambioPass");
            }
            objUser.contrasena = model.contrasena;
            SM.Aplicacion.Modulo_Usuarios.UsuarioLogica.modificarPasswordUserSimus(objUser, Request.UserHostAddress);
            TempData["CambioContrasena"] = true;
           
            return RedirectToAction("Login", "Cuenta");
        }

        public ActionResult RestablecerCelebra(string token)
        {

            RestablecerModel obj = new RestablecerModel();

            return View(obj);



        }

        [HttpPost]
        public ActionResult RestablecerCelebra(RestablecerModel model)
        {
            if (!ModelState.IsValid)
            {

                return View("CambioPass", model);
            }


            UsuarioDTOSIM objUser = SM.Aplicacion.Modulo_Usuarios.UsuarioLogica.obtenerUsuarioporEmail(model.correo, Comunes.ConstantesRecursosBD.SIMUS_USUARIO_TIPO_SIMUS);
            if (objUser.TipoRSS == "MINCULTURA")
            {
                Warning(string.Format("<b></b> Acepte términos y condiciones "), true);
                return View("CambioPass");
            }
            objUser.contrasena = model.contrasena;
            SM.Aplicacion.Modulo_Usuarios.UsuarioLogica.modificarPasswordUserSimus(objUser, Request.UserHostAddress);
            objUser.cambioContraseña = true;
            Session["$usuario"] = objUser;


            return RedirectToAction("LoginMusica", "Cuenta");
        }


        private bool bvalidateToaken(string token)
        {
            bool respuesta = true;
            token = token.Replace(" ", "+");
            byte[] data = Convert.FromBase64String(token);
            DateTime when = DateTime.FromBinary(BitConverter.ToInt64(data, 0));
            if (when < DateTime.UtcNow.AddHours(-24))
            {
                respuesta = false;
                // too vencidooo
            }
            return respuesta;
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            string ruta = "";
            ruta = Server.MapPath("/Log");
            Log.WriteLog(ruta, filterContext.Exception.ToString());

            Exception ex = filterContext.Exception;
            filterContext.ExceptionHandled = true;


            var model = new HandleErrorInfo(filterContext.Exception, "CambioPassword", "Action");

            filterContext.Result = new ViewResult()
            {
                ViewName = "Error",
                ViewData = new ViewDataDictionary(model)
            };
        }
    }
}