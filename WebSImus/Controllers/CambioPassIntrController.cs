using SM.LibreriaComun.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSImus.Models;

namespace WebSImus.Controllers
{
    public class CambioPassIntrController : Controller
    {
        //
        // GET: /CambioPassIntr/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CambioClaveInt()
        {


            if (Session["$usuario"] != null)
            {
                UsuarioDTOSIM userLogin = ((UsuarioDTOSIM)Session["$usuario"]);
                RestablecerModel model = new RestablecerModel();
                model.correo = userLogin.Email;
                return View(model);
            }

            return View();
        }


        [HttpPost]
        public ActionResult Restablecer(RestablecerModel model)
        {
            if (!ModelState.IsValid)
            {

                return View("CambioClaveInt", model);
            }

            ///validamos la clave sea correcta
            var userLogin = SM.Aplicacion.Modulo_Usuarios.UsuarioLogica.obtenerUsuarioSimuis(model.correo, model.actualcontrasena);
            if (userLogin == null)
            {
                ModelState.AddModelError("", "La contraseña actual no es correcta, por favor valide");
                return View("CambioClaveInt", model);
            }

            UsuarioDTOSIM objUser = SM.Aplicacion.Modulo_Usuarios.UsuarioLogica.obtenerUsuarioporEmail(model.correo, Comunes.ConstantesRecursosBD.SIMUS_USUARIO_TIPO_SIMUS);
            objUser.contrasena = model.contrasena;
            SM.Aplicacion.Modulo_Usuarios.UsuarioLogica.modificarPasswordUserSimus(objUser, Request.UserHostAddress);
            objUser.cambioContraseña = true;
            Session["$usuario"] = objUser;


            return RedirectToAction("Login", "Cuenta");
        }


    }
}