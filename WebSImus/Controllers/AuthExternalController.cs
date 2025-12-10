using Oauth2Login.Service;
using SM.Aplicacion.Basicas;
using SM.LibreriaComun.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebSImus.Comunes;
using WebSImus.Models;
using WebSImus.Translator;

namespace WebSImus.Controllers
{
    public enum AuthExternalMode
    {
        Default = 0,
        AttachLogin = 1
    }


    public class AuthExternalController : BaseController
    {
        static string codColombia = "52";

        public Usuarios m_usuario
        {
            get { return TranslatorUsuarioToUsuariodtosim.UsuarioDTOSIMtoUsuario((UsuarioDTOSIM)Session["$usuario"]); }

        }
        public ActionResult Login(string id, AuthExternalMode? mode)
        {
            var service = BaseOauth2Service.GetService(id);

            if (service != null)
            {
                var url = service.BeginAuthentication();

                if (mode.HasValue)
                    TempData["AuthExternalMode"] = mode;

                return Redirect(url);
            }
            else
            {
                return RedirectToAction("LoginFail");
            }
        }

        public ActionResult Callback(string id)
        {
            var service = BaseOauth2Service.GetService(id);

            if (service != null)
            {
                try
                {
                    var redirectUrl = service.ValidateLogin(Request);
                    // service.

                    if (redirectUrl != null)
                    {
                        return Redirect(redirectUrl);
                    }

                    // This is demo, so I am not handling saving of data into database
                    // 
                    AuthCallbackResult respModel = null;
                    AuthExternalMode authMode = TempData["AuthExternalMode"] as AuthExternalMode? ?? AuthExternalMode.Default;
                    if (authMode == AuthExternalMode.AttachLogin)
                    {
                        // var userSession = GetUserSession();
                        // if (userSession == null)
                        //    throw new Exception("Initial attach call was probably coming from other domain / session");

                        // var login = BaseAttachToExistingLogin(userSession.UserId, service.UserData);
                        respModel = new AuthCallbackResult { RedirectUrl = "/Accounts/AttachLoginProviders" };
                    }
                    else
                    {//cargamos n session el usuario
                        usuarioLoad(service.UserData);

                        if (this.m_usuario.esnuevoenSimus)
                        {
                            // respModel = InsertNewUserIntoDatabase(service);
                            respModel = new AuthCallbackResult { RedirectUrl = "/AuthExternal/LoginSuccess" };
                        }
                        else
                        {
                           

                            respModel = new AuthCallbackResult { RedirectUrl = "/Inicio/Index" };
                            //todo se nevia para la pagina de inicio
                        }

                    }

                    return View(respModel);
                }
                catch (Exception ex)
                {
                    throw ex;
                    //RedirectToAction("Error");
                }
            }
            else
            {
                return RedirectToAction("LoginFail");
            }
        }

        public ActionResult LoginFail()
        {
            return View();
        }

        public ActionResult LoginSuccess()
        {
            if (m_usuario == null) return RedirectToAction("Index");

            List<BasicaDTO> lsttipoDoc = BasicaLogica.ConsultarTiposDocumentos();
            ViewBag.listTipoDocumento = new SelectList(lsttipoDoc, "value", "text");

            List<BasicaDTO> lstPaises = ZonaGeograficasLogica.ConsultarPaises();
            ViewBag.listPaises = new SelectList(lstPaises, "value", "text");
            List<BasicaDTO> lstDpto = new List<BasicaDTO>();

            var model = m_usuario;
            //traemos la informacion si esta ya existe
            if (SM.Aplicacion.Modulo_Usuarios.UsuarioLogica.existeUsurioEmail(m_usuario.usuario))
            {
                UsuarioDTOSIM userExiste = SM.Aplicacion.Modulo_Usuarios.UsuarioLogica.obtenerUsuarioporEmail(m_usuario.usuario, m_usuario.tipoRedSocial);

                model.pais = userExiste.CodPais;
                model.Id = userExiste.Id;
                model.departamento = userExiste.CodDpto;
                model.municipio = userExiste.CodMunicipio;
                model.sexo = userExiste.Sexo;
                model.segundoNombre = userExiste.SegundoNombre;
                model.segundoApellido = userExiste.segundoApellido;
                model.fechaNacimiento = userExiste.Fechanacimiento != null ? userExiste.Fechanacimiento.Value.ToString("yyyy-MM-dd") : String.Empty;
                model.tipoRedSocial = userExiste.TipoRSS;
                model.tipoDocumento = userExiste.CodTipoDocumento;
            }
           
            if (model.pais != null && model.pais != Comunes.ConstantesRecursosBD.SIMUS_SIPA_COD_COLOMBIA)
            {
                lstDpto = ZonaGeograficasLogica.ConsultarDepartamentosporPais(model.pais);
            }
            else
            {
                lstDpto = ZonaGeograficasLogica.ConsultarDepartamentos();
            }


            ViewBag.listDpto = new SelectList(lstDpto, "value", "text");


            List<BasicaDTO> listMun = new List<BasicaDTO>();

            if (model.departamento != null && model.pais == Comunes.ConstantesRecursosBD.SIMUS_SIPA_COD_COLOMBIA)
            {
                listMun = ZonaGeograficasLogica.ConsultarMunicipios(model.departamento);
            }
            ViewBag.listMun = new SelectList(listMun, "value", "text");


            ViewBag.esColombia = true;
            ViewBag.esDpto = true;
            // cargamos el que acaba de llegar



            model.contrasena = Comunes.ConstantesRecursosBD.SIMUS_SIPA_CLAVE_DEFAULT;
            model.confcontrasena = Comunes.ConstantesRecursosBD.SIMUS_SIPA_CLAVE_DEFAULT;


            return View(model);


           
        }

        private void valoredefaut(Usuarios userProfile)
        {
            List<BasicaDTO> lsttipoDoc = BasicaLogica.ConsultarTiposDocumentos();
            ViewBag.listTipoDocumento = new SelectList(lsttipoDoc, "value", "text");

            List<BasicaDTO> lstPaises = ZonaGeograficasLogica.ConsultarPaises();
            ViewBag.listPaises = new SelectList(lstPaises, "value", "text");

            List<BasicaDTO> lstDpto = new List<BasicaDTO>();
            lstDpto = ZonaGeograficasLogica.ConsultarDepartamentos();
            ViewBag.listDpto = new SelectList(lstDpto, "value", "text");

            List<BasicaDTO> listMun = new List<BasicaDTO>();
            if (userProfile != null)
            {
                listMun = ZonaGeograficasLogica.ConsultarMunicipios(userProfile.departamento);
            }
            ViewBag.listMun = new SelectList(listMun, "value", "text");


            ViewBag.esColombia = true;
            ViewBag.esDpto = true;


        }


        public JsonResult obtenerDepartamento(string codpais = null)
        {

            List<BasicaDTO> listDpto = new List<BasicaDTO>();
            ViewBag.esColombia = true;
            if (!String.IsNullOrEmpty(codpais) && codColombia == codpais)
            {
                ViewBag.esColombia = false;
                listDpto = ZonaGeograficasLogica.ConsultarDepartamentos();
            }

            var data = listDpto;
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public JsonResult obtenerMunicipio(string coddpto = null)
        {
            ViewBag.esDpto = true;
            List<BasicaDTO> listMunicipios = new List<BasicaDTO>();

            if (!String.IsNullOrEmpty(coddpto))
            {
                ViewBag.esDpto = false;
                listMunicipios = ZonaGeograficasLogica.ConsultarMunicipios(coddpto);
            }

            var data = listMunicipios;
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Cargamos en session l usuario que viene de la red social
        /// </summary>
        /// <param name="UserDataRS"></param>
        private void usuarioLoad(BaseUserData UserDataRS)
        {
            UsuarioDTOSIM objUser = new UsuarioDTOSIM();
            objUser.IdUserRSS = UserDataRS.UserId;
            objUser.esnuevoenSimus = false;
            string nombrePerfil = "STANDARD";
            string nombreCompleto;

            if (SM.Aplicacion.Modulo_Usuarios.UsuarioLogica.existeUsurioExterno(objUser.IdUserRSS))
            {
                UsuarioDTOSIM objDTOSIM = SM.Aplicacion.Modulo_Usuarios.UsuarioLogica.obtenerUsuarioExterno(objUser.IdUserRSS);

                objUser = objDTOSIM;
                objUser.PrimerNombre = UserDataRS.nombre;
                objUser.PrimerApellido = UserDataRS.apellido;
                objUser.SegundoNombre = objDTOSIM.SegundoNombre;
                objUser.segundoApellido = objDTOSIM.segundoApellido;
                objUser.CodPais = objDTOSIM.CodPais;
                objUser.CodDpto = objDTOSIM.CodDpto;
                objUser.CodMunicipio = objDTOSIM.CodMunicipio;
                objUser.Id = objDTOSIM.Id;
                objUser.IdAgente = objDTOSIM.IdAgente;
                objUser.IdUserRSS = objDTOSIM.IdUserRSS;
                objUser.TipoRSS = objDTOSIM.TipoRSS;
                objUser.IdSipa = objDTOSIM.IdSipa;
            
                objUser.rutaFoto = UserDataRS.photo;
                        
              
                if (objDTOSIM.Sexo!=null)
                objUser.Sexo = objDTOSIM.Sexo.Trim();
               

            }
            else
            {
                //Tipo de red social
                objUser.TipoRSS = UserDataRS.AuthService.ToString();
                
                objUser.Email = UserDataRS.nombre + UserDataRS.apellido + "@simus.com";
                if (UserDataRS.Email != null)
                {
                    objUser.Email = UserDataRS.Email;
                }
                string[] arrNombre = UserDataRS.nombre.Split(' ');
                string[] arrApellido = UserDataRS.apellido.Split(' ');
               
                objUser.PrimerNombre = UserDataRS.nombre;
                objUser.PrimerApellido = UserDataRS.apellido;
                if (arrNombre.Length>1)
                {
                    objUser.PrimerNombre = arrNombre[0];
                    objUser.SegundoNombre = arrNombre[1];
                }
                if (arrApellido.Length > 1)
                {
                    objUser.PrimerApellido = arrApellido[0];
                    objUser.segundoApellido = arrApellido[1];
                }


                objUser.Sexo = "Femenino";
                objUser.rutaFoto = UserDataRS.photo;

                if (UserDataRS.genero != null && UserDataRS.genero.Equals("male"))
                {
                    objUser.Sexo = "Masculino";
                }
                objUser.esnuevoenSimus = true;

                //se cargan vlaores Id por refrencia.
                //SM.Aplicacion.Modulo_Usuarios.UsuarioLogica.crearUsuarioExterno(objUser);

            }




            ///todo se debe validar si existe para que actualice informacion

            if (Session["$usuario"] == null)
            {
                Session["$usuario"] = objUser;
            }
            else
            {
                Session["$usuario"] = objUser;
            }
            nombreCompleto = objUser.PrimerNombre + " " + objUser.SegundoNombre + " " + objUser.PrimerApellido;
            int UsuarioInterno = 2;
            ///Ojo quitar la variable de session
            ///Agregamos la cookie

            var authTicket = new FormsAuthenticationTicket(1, nombreCompleto, DateTime.Now, DateTime.Now.AddMinutes(30), true, objUser.Id.ToString() + "|" + objUser.Email + "|" + nombrePerfil + "|" + UsuarioInterno.ToString());

            string cookieContents = FormsAuthentication.Encrypt(authTicket);
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, cookieContents)
            {
                Expires = authTicket.Expiration,
                Path = FormsAuthentication.FormsCookiePath,
                Secure = false,
                HttpOnly = true
            };

            Response.Cookies.Add(cookie);



            ///
        }
        [HttpPost]
        public ActionResult Guardar(Usuarios userProfile)
        {
            string nombrePerfil = "STANDARD";
            string nombreCompleto;
            if (!ModelState.IsValid)
            {
                this.valoredefaut(userProfile);
                return View("LoginSuccess", userProfile);
            }
            UsuarioDTOSIM objDTOSIM = TranslatorUsuarioToUsuariodtosim.UsuariotoUsuarioDTOSIM(userProfile);



            if (userProfile.numeroDocumento == null || userProfile.numeroDocumento == "")
            {
                ModelState.AddModelError("", "El numero de identificación es obligatorio");
                this.valoredefaut(userProfile);
                return View("LoginSuccess", userProfile);
            }

            if (userProfile.tipoDocumento == null || userProfile.tipoDocumento == "")
            {
                ModelState.AddModelError("", "El tipo de documento es obligatorio");
                this.valoredefaut(userProfile);
                return View("LoginSuccess", userProfile);
            }


            if (!SM.Aplicacion.Modulo_Usuarios.UsuarioLogica.existeUsurioExterno(objDTOSIM.IdUserRSS))
            {   //valor por default
                objDTOSIM.contrasena = Comunes.ConstantesRecursosBD.SIMUS_SIPA_CLAVE_DEFAULT;
                string ip = Request.UserHostAddress;
           
                SM.Aplicacion.Modulo_Usuarios.UsuarioLogica.crearUsuarioenSimusRSS(objDTOSIM, ip);
                //Indicamos el mensaje 
                objDTOSIM.esnuevoenSimus = true;
               
                StringBuilder sUser = new StringBuilder();

                if (objDTOSIM.PrimerNombre != null)
                {
                    sUser.Append(objDTOSIM.PrimerNombre);
                }
                if (objDTOSIM.SegundoNombre != null)
                {
                    sUser.Append(" " + objDTOSIM.SegundoNombre);
                }
                if (objDTOSIM.PrimerApellido != null)
                {
                    sUser.Append(" " + objDTOSIM.PrimerApellido);
                }
                if (objDTOSIM.segundoApellido != null)
                {
                    sUser.Append(" " + objDTOSIM.segundoApellido);
                }



                EnvioCorreo.EnviarCorreoHtmlCreacion(objDTOSIM.Email, System.Configuration.ConfigurationManager.AppSettings["EmailMensajeCreacion"], "Creacion de cuenta en simus", sUser.ToString());



            }
            else
            {
                //validamos que el nuevo correo si lo cambia no exista para alguine a diferencia de el
                if (SM.Aplicacion.Modulo_Usuarios.UsuarioLogica.existeUsurioEmailId(userProfile.usuario, userProfile.Id))
                {
                    ModelState.AddModelError("", "El correo electronico ya esta asociado a otro usuario por favor verifique.");
                    this.valoredefaut(userProfile);
                    return View("LoginSuccess", userProfile);
                }


                SM.Aplicacion.Modulo_Usuarios.UsuarioLogica.modificarUsuarioRSS(objDTOSIM, Request.UserHostAddress);

            }

            Session["$usuario"] = objDTOSIM;

            nombreCompleto = objDTOSIM.PrimerNombre + " " + objDTOSIM.SegundoNombre + " " + objDTOSIM.PrimerApellido;
            int UsuarioInterno = 2;
            ///Ojo quitar la variable de session
            ///Agregamos la cookie

            var authTicket = new FormsAuthenticationTicket(1, nombreCompleto, DateTime.Now, DateTime.Now.AddMinutes(30), true, objDTOSIM.Id.ToString() + "|" + objDTOSIM.Email + "|" + nombrePerfil + "|" + UsuarioInterno.ToString());

            string cookieContents = FormsAuthentication.Encrypt(authTicket);
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, cookieContents)
            {
                Expires = authTicket.Expiration,
                Path = FormsAuthentication.FormsCookiePath,
                Secure = false,
                HttpOnly = true
            };

            Response.Cookies.Add(cookie);

            return RedirectToAction("Index", "Inicio");
        }



    }
}