using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Net;
using WebSImus.Models;
using SM.LibreriaComun.DTO;
using SM.Aplicacion.Modulo_Usuarios;
using SM.Aplicacion.Basicas;
using WebSImus.Translator;
using System.IO;
using WebSImus.Comunes;
using System.Text;
using System.Text.RegularExpressions;
using SM.Utilidades.Log;
using System.Web.Security;


namespace WebSImus.Controllers
{

    [HandleError()]

    public class CuentaController : BaseController
    {
        public UserManager<ApplicationUser> UserManager { get; private set; }
        SM.LibreriaRecursos.Recursos.FabricaManejador fabricaMensajes;
        SM.LibreriaRecursos.Recursos.ManejadorRecursos manejadoMensajes;
        static string codColombia = "52";

        #region terminos y condiciones
        public ActionResult Terminos()
        {

            return View();
        }

        public ActionResult TerminosDanza()
        {

            return View();
        }

        public ActionResult TerminosMusica()
        {

            return View();
        }
        #endregion


        private void AlertasMensajes()
        {
            if ((TempData["Esnuevo"] != null) && ((bool)TempData["Esnuevo"]))
            {
                string mensaje = $"<strong>{TempData["PrimerNombre"]} {TempData["PrimerApellido"]}</strong>, {System.Configuration.ConfigurationManager.AppSettings["MensajeRegistro"]}";
                TempData["MensajeSistema"] = mensaje;
                TempData["MensajeTipo"] = "success";
            }

            if ((TempData["EsRestabecer"] != null) && ((bool)TempData["EsRestabecer"]))
            {
                string mensaje = $"<strong>{TempData["PrimerNombre"]} {TempData["PrimerApellido"]}</strong>, se ha enviado un correo para restablecer su contraseña. Por favor valide.";
                TempData["MensajeSistema"] = mensaje;
                TempData["MensajeTipo"] = "info";
            }

            if ((TempData["TokenInvalido"] != null) && ((bool)TempData["TokenInvalido"]))
            {
                TempData["MensajeSistema"] = "⚠️ Se ha detectado un intento de acceso anómalo. Por favor valide sus credenciales.";
                TempData["MensajeTipo"] = "warning";
                Session["$usuario"] = null;
            }

            if ((TempData["CambioContrasena"] != null) && ((bool)TempData["CambioContrasena"]))
            {
                TempData["MensajeSistema"] = "🔒 Su contraseña ha sido actualizada correctamente.";
                TempData["MensajeTipo"] = "success";
            }
        }

        //
        // GET: /Cuenta/
        public ActionResult Login(string redirecciona = "")
        {
            AutenticacionViewModel inicioSesionModel = new AutenticacionViewModel();

            if (!String.IsNullOrEmpty(redirecciona))
                inicioSesionModel.redirecciona = redirecciona;

            AlertasMensajes();

            HttpCookie httpCookie = Request.Cookies["DatosRecordarmeSIMUS"];
            if (httpCookie != null && httpCookie["NombreUsuario"] != null)
            {
                inicioSesionModel.NombreUsuario = httpCookie["NombreUsuario"];
                inicioSesionModel.Recordarme = true;
            }

            return View(inicioSesionModel);
        }


        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Login(AutenticacionViewModel inicioSesionModel, string redirecciona = "")
        {

            if (ModelState.IsValid)
            {
                string nombreCompleto = String.Empty;
                string nombrePerfil = String.Empty;
                int usuarioId = 0;
                bool IsLdap = false;
                string dominio = "mincultura";//dominio del ldap
                string NombreUsuario = "";
                string Contrasena = "";
                string controlador = "Inicio";
                string accion = "Index";
                int usuarioInterno = 0;
                fabricaMensajes = new SM.LibreriaRecursos.Recursos.FabricaManejador();
                manejadoMensajes = fabricaMensajes.getInstance();

                UsuarioDTOSIM userLogin = null;

                NombreUsuario = inicioSesionModel.NombreUsuario;
                Contrasena = inicioSesionModel.Contrasena;

                IsLdap = NombreUsuario.Contains(dominio);

                if (!inicioSesionModel.AceptarTerminos)
                {
                    ModelState.AddModelError("", "Debe aceptar los términos y condiciones");
                    return View(inicioSesionModel);

                }

                if (IsLdap)
                {

                    string userName = inicioSesionModel.NombreUsuario.ToString().Split('@')[0];
                    userLogin = UsuarioLogica.usuarioMincultura(userName, Contrasena);
                    usuarioInterno = 1;
                    if (userLogin != null)
                    {
                        if (!userLogin.esUsuarioSiMUS)//existe ya en simus
                        {
                            controlador = "MinculturaPerfil";
                            accion = "MinPerfil";

                        }

                    }

                }
                else
                {
                    userLogin = UsuarioLogica.obtenerUsuarioSimuis(NombreUsuario, Contrasena);
                }

                if (userLogin != null)
                {
                    /// debemos reemplazar esta session
                    /// 
                    userLogin.imagen = null;
                    userLogin.nombrecompleto = string.Empty;
                    userLogin.rutaFoto = string.Empty;
                     Session["$usuario"] = userLogin;
                    nombreCompleto = userLogin.PrimerNombre + " " + userLogin.PrimerApellido;
                    usuarioId = userLogin.Id;

                

                }
                else
                {//Usuario incorrecto
                    if (usuarioInterno == 0)
                    {
                        String mensaje = manejadoMensajes.obtenerValor(SM.LibreriaRecursos.Constantes.ConstantesRecursos.SIMUS_Contrasena_Invalida);
                        ModelState.AddModelError("", mensaje);
                        return View(new AutenticacionViewModel());
                    }
                    else
                    {

                        String mensaje = manejadoMensajes.obtenerValor(SM.LibreriaRecursos.Constantes.ConstantesRecursos.SIMUS_mincutura_invalido);
                        ModelState.AddModelError("", mensaje);
                        return View(new AutenticacionViewModel());
                    }
                }


                var authTicket = new FormsAuthenticationTicket(1, nombreCompleto, DateTime.Now, DateTime.Now.AddMinutes(30), true, usuarioId.ToString() + "|" + inicioSesionModel.NombreUsuario + "|" + nombrePerfil + "|" + usuarioInterno.ToString());

                string cookieContents = FormsAuthentication.Encrypt(authTicket);
                var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, cookieContents)
                {
                    Expires = authTicket.Expiration,
                    Path = FormsAuthentication.FormsCookiePath,
                    Secure = false,
                    HttpOnly = true
                };

                Response.Cookies.Add(cookie);

                if (inicioSesionModel.Recordarme)
                {
                    HttpCookie httpCookie = new HttpCookie("DatosRecordarmeSIMUS");
                    httpCookie["NombreUsuario"] = inicioSesionModel.NombreUsuario;
                    httpCookie.Expires = DateTime.Now.AddDays(30d);
                    httpCookie.HttpOnly = true;
                    Response.Cookies.Add(httpCookie);
                }
                else
                {
                    if (Request.Cookies["DatosRecordarmeSIMUS"] != null)
                    {
                        HttpCookie httpCookie = new HttpCookie("DatosRecordarmeSIMUS")
                        {
                            Expires = DateTime.Now.AddDays(-1d)
                        };
                        Response.Cookies.Add(httpCookie);
                    }
                }

                if (!String.IsNullOrEmpty(inicioSesionModel.redirecciona))
                {
                    return RedirectToActionPermanent(inicioSesionModel.redirecciona);
                }

                return RedirectToActionPermanent(accion, controlador);
            }

            
            return View(inicioSesionModel);
        }


        public ActionResult IniciarSesion(string redirecciona = "")
        {

            

            AutenticacionViewModel inicioSesionModel = new AutenticacionViewModel();
            if (!String.IsNullOrEmpty(redirecciona))
                inicioSesionModel.redirecciona = redirecciona;

            HttpCookie httpCookie = Request.Cookies["DatosRecordarmeSIMUS"];
            if (httpCookie != null && httpCookie["NombreUsuario"] != null)
            {
                inicioSesionModel.NombreUsuario = httpCookie["NombreUsuario"];
                inicioSesionModel.Recordarme = true;
            }

            return View(inicioSesionModel);
        }


        /// Metodo post
        [HttpPost]
        public ActionResult IniciarSesion(AutenticacionViewModel inicioSesionModel)
        {
            if (ModelState.IsValid)
            {
                string nombreCompleto = String.Empty;
                string nombrePerfil = String.Empty;
                int usuarioId = 0;
                bool IsLdap = false;
                string dominio = "mincultura";//dominio del ldap
                string NombreUsuario = "";
                string Contrasena = "";
                string controlador = "Inicio";
                string accion = "Index";
                int usuarioInterno = 0;
                fabricaMensajes = new SM.LibreriaRecursos.Recursos.FabricaManejador();
                manejadoMensajes = fabricaMensajes.getInstance();

                if (!inicioSesionModel.AceptarTerminos)
                {
                    ModelState.AddModelError("", "Debe aceptar los términos y condiciones");
                    return View(inicioSesionModel);

                }
                UsuarioDTOSIM userLogin = null;


                NombreUsuario = inicioSesionModel.NombreUsuario;
                Contrasena = inicioSesionModel.Contrasena;

                IsLdap = NombreUsuario.Contains(dominio);


                if (IsLdap)
                {

                    string userName = inicioSesionModel.NombreUsuario.ToString().Split('@')[0];
                    userLogin = UsuarioLogica.usuarioMincultura(userName, Contrasena);
                    usuarioInterno = 1;
                    if (userLogin != null)
                    {
                        if (!userLogin.esUsuarioSiMUS)//existe ya en simus
                        {
                            controlador = "MinculturaPerfil";
                            accion = "MinPerfil";

                        }

                    }

                }
                else
                {
                    userLogin = UsuarioLogica.obtenerUsuarioSimuis(NombreUsuario, Contrasena);
                }

                if (userLogin != null)
                {
                    /// debemos reemplazar esta session
                    Session["$usuario"] = userLogin;
                    nombreCompleto = userLogin.PrimerNombre + " " + userLogin.SegundoNombre + " " + userLogin.PrimerApellido + " ";
                    usuarioId = userLogin.Id;

                    Session["usuarioId"] = usuarioId;
                    Session["nombreCompleto"] = nombreCompleto;
                    Session["NombreUsuario"] = NombreUsuario;

                }
                else
                {//Usuario incorrecto
                    if (usuarioInterno == 0)
                    {
                        String mensaje = manejadoMensajes.obtenerValor(SM.LibreriaRecursos.Constantes.ConstantesRecursos.SIMUS_Contrasena_Invalida);
                        ModelState.AddModelError("", mensaje);
                        return View(new AutenticacionViewModel());
                    }
                    else
                    {

                        String mensaje = manejadoMensajes.obtenerValor(SM.LibreriaRecursos.Constantes.ConstantesRecursos.SIMUS_mincutura_invalido);
                        ModelState.AddModelError("", mensaje);
                        return View(new AutenticacionViewModel());
                    }
                }


                var authTicket = new FormsAuthenticationTicket(1, nombreCompleto, DateTime.Now, DateTime.Now.AddMinutes(30), true, usuarioId.ToString() + "|" + inicioSesionModel.NombreUsuario + "|" + nombrePerfil + "|" + usuarioInterno.ToString());

                string cookieContents = FormsAuthentication.Encrypt(authTicket);
                var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, cookieContents)
                {
                    Expires = authTicket.Expiration,
                    Path = FormsAuthentication.FormsCookiePath,
                    Secure = false,
                    HttpOnly = true
                };

                Response.Cookies.Add(cookie);

                if (inicioSesionModel.Recordarme)
                {
                    HttpCookie httpCookie = new HttpCookie("DatosRecordarmeSIMUS");
                    httpCookie["NombreUsuario"] = inicioSesionModel.NombreUsuario;
                    httpCookie.Expires = DateTime.Now.AddDays(30d);
                    httpCookie.HttpOnly = true;
                    Response.Cookies.Add(httpCookie);
                }
                else
                {
                    if (Request.Cookies["DatosRecordarmeSIMUS"] != null)
                    {
                        HttpCookie httpCookie = new HttpCookie("DatosRecordarmeSIMUS")
                        {
                            Expires = DateTime.Now.AddDays(-1d)
                        };
                        Response.Cookies.Add(httpCookie);
                    }
                }

                if (!String.IsNullOrEmpty(inicioSesionModel.redirecciona))
                {
                    return Redirect("~/" + inicioSesionModel.redirecciona);
                }
                return RedirectToActionPermanent(accion, controlador);
            }

            return View(inicioSesionModel);
        }


        public ActionResult LoginCelebra(Usuarios model = null)
        {
            //Mensajes de acceso
            Session["$EsAdmin"] = null;
            MensajesAccesoSimus();
            //Session["$usuario"] = null;
            System.Web.HttpContext.Current.Session[ConstantesRecursosBD.SIMUS_RECURSOS_USUARIO] = null;

            return View(model);
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult LoginCelebra(Usuarios model, string returnUrl)
        {

            fabricaMensajes = new SM.LibreriaRecursos.Recursos.FabricaManejador();
            manejadoMensajes = fabricaMensajes.getInstance();

            if (model.contrasena == null || model.contrasena == "" || model.usuario == null || model.usuario == "") return View(model);
            UsuarioDTOSIM userLogin = null;
            userLogin = UsuarioLogica.obtenerUsuarioSimuis(model.usuario, model.contrasena);

            if (userLogin != null)
            {

                Session["$usuario"] = userLogin;
                return RedirectToAction("Index", "Celebra");
            }
            else
            {//Usuario incorrecto
                if (!model.esUsuarioInterno)
                {

                    String mensaje = manejadoMensajes.obtenerValor(SM.LibreriaRecursos.Constantes.ConstantesRecursos.SIMUS_Contrasena_Invalida);
                    ModelState.AddModelError("", mensaje);
                    return View(new Usuarios());
                }

            }


            // Si llegamos a este punto, es que se ha producido un error y volvemos a mostrar el formulario
            return View(model);
        }

        public ActionResult LoginMusica(Usuarios model = null)
        {
            AutenticacionViewModel inicioSesionModel = new AutenticacionViewModel();

            AlertasMensajes();

            HttpCookie httpCookie = Request.Cookies["DatosRecordarmeSIMUS"];
            if (httpCookie != null && httpCookie["NombreUsuario"] != null)
            {
                inicioSesionModel.NombreUsuario = httpCookie["NombreUsuario"];
                inicioSesionModel.Recordarme = true;
            }

            return View(inicioSesionModel);
        }
        [HttpPost]
        public ActionResult LoginMusica(AutenticacionViewModel inicioSesionModel)
        {

            if (ModelState.IsValid)
            {
                string nombreCompleto = String.Empty;
                string nombrePerfil = String.Empty;
                int usuarioId = 0;
                bool IsLdap = false;
                string dominio = "mincultura";//dominio del ldap
                string NombreUsuario = "";
                string Contrasena = "";
                string controlador = "Musica";
                string accion = "Index";
                int usuarioInterno = 0;
                fabricaMensajes = new SM.LibreriaRecursos.Recursos.FabricaManejador();
                manejadoMensajes = fabricaMensajes.getInstance();

                UsuarioDTOSIM userLogin = null;
                if (!inicioSesionModel.AceptarTerminos)
                {
                    ModelState.AddModelError("", "Debe aceptar los términos y condiciones");
                    return View(inicioSesionModel);

                }
                NombreUsuario = inicioSesionModel.NombreUsuario;
                Contrasena = inicioSesionModel.Contrasena;

                IsLdap = NombreUsuario.Contains(dominio);


                if (IsLdap)
                {

                    string userName = inicioSesionModel.NombreUsuario.ToString().Split('@')[0];
                    userLogin = UsuarioLogica.usuarioMincultura(userName, Contrasena);
                    usuarioInterno = 1;
                    if (userLogin != null)
                    {
                        if (!userLogin.esUsuarioSiMUS)//existe ya en simus
                        {
                            controlador = "MinculturaPerfil";
                            accion = "MinPerfil";

                        }

                    }

                }
                else
                {
                    userLogin = UsuarioLogica.obtenerUsuarioSimuis(NombreUsuario, Contrasena);
                }

                if (userLogin != null)
                {
                    /// debemos reemplazar esta session
                    /// 
                    userLogin.imagen = null;
                    userLogin.nombrecompleto = string.Empty;
                    userLogin.rutaFoto = string.Empty;
                    Session["$usuario"] = userLogin;
                    nombreCompleto = userLogin.PrimerNombre + " " + userLogin.PrimerApellido;
                    usuarioId = userLogin.Id;



                }
                else
                {//Usuario incorrecto
                    if (usuarioInterno == 0)
                    {
                        String mensaje = manejadoMensajes.obtenerValor(SM.LibreriaRecursos.Constantes.ConstantesRecursos.SIMUS_Contrasena_Invalida);
                        ModelState.AddModelError("", mensaje);
                        return View(new AutenticacionViewModel());
                    }
                    else
                    {

                        String mensaje = manejadoMensajes.obtenerValor(SM.LibreriaRecursos.Constantes.ConstantesRecursos.SIMUS_mincutura_invalido);
                        ModelState.AddModelError("", mensaje);
                        return View(new AutenticacionViewModel());
                    }
                }


                var authTicket = new FormsAuthenticationTicket(1, nombreCompleto, DateTime.Now, DateTime.Now.AddMinutes(30), true, usuarioId.ToString() + "|" + inicioSesionModel.NombreUsuario + "|" + nombrePerfil + "|" + usuarioInterno.ToString());

                string cookieContents = FormsAuthentication.Encrypt(authTicket);
                var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, cookieContents)
                {
                    Expires = authTicket.Expiration,
                    Path = FormsAuthentication.FormsCookiePath,
                    Secure = false,
                    HttpOnly = true
                };

                Response.Cookies.Add(cookie);

                if (inicioSesionModel.Recordarme)
                {
                    HttpCookie httpCookie = new HttpCookie("DatosRecordarmeSIMUS");
                    httpCookie["NombreUsuario"] = inicioSesionModel.NombreUsuario;
                    httpCookie.Expires = DateTime.Now.AddDays(30d);
                    httpCookie.HttpOnly = true;
                    Response.Cookies.Add(httpCookie);
                }
                else
                {
                    if (Request.Cookies["DatosRecordarmeSIMUS"] != null)
                    {
                        HttpCookie httpCookie = new HttpCookie("DatosRecordarmeSIMUS")
                        {
                            Expires = DateTime.Now.AddDays(-1d)
                        };
                        Response.Cookies.Add(httpCookie);
                    }
                }

                return RedirectToActionPermanent(accion, controlador);
            }

            return View(inicioSesionModel);
        }
        public ActionResult Registrarse()
        {
            valoredefaut(null);

            var mdl = new Usuarios();
            mdl.sexo = "Femenino";
            return View(mdl);

        }

        public ActionResult RegistrarseCelebra()
        {
            valoredefaut(null);

            var mdl = new Usuarios();
            mdl.sexo = "Femenino";
            return View(mdl);

        }

        [HttpPost]
        public ActionResult RegistrarseCelebra(HttpPostedFileBase imagenPerfil, Usuarios userProfile)
        {
            userProfile.msg = "";
            string imageDataURL = "";
            if (!ModelState.IsValid)
            {
                this.valoredefaut(userProfile);
                return View("RegistrarseCelebra", userProfile);
            }
            userProfile.esUsuarioInterno = false;

            if (!userProfile.aceptaCondiciones)
            {


                ModelState.AddModelError("", "Acepte términos y condiciones");
                this.valoredefaut(userProfile);
                return View("RegistrarseCelebra", userProfile);
            }


            if (SM.Aplicacion.Modulo_Usuarios.UsuarioLogica.existeUsurioEmail(userProfile.usuario))
            {
                ModelState.AddModelError("", "El correo electrónico ya esta asociado a otro usuario por favor verifique.");
                this.valoredefaut(userProfile);
                return View("RegistrarseCelebra", userProfile);
            }

            if (userProfile.numeroDocumento == null || userProfile.numeroDocumento == "")
            {
                ModelState.AddModelError("", "El número de identificación es obligatorio");
                this.valoredefaut(userProfile);
                return View("RegistrarseCelebra", userProfile);
            }
            else
            {
                if (userProfile.tipoDocumento == null || userProfile.tipoDocumento == "")
                {
                    ModelState.AddModelError("", "El tipo de documento es obligatorio");
                    this.valoredefaut(userProfile);
                    return View("RegistrarseCelebra", userProfile);
                }
                else
                {

                    if (SM.Aplicacion.Modulo_Usuarios.UsuarioLogica.existedocumentoTipo(userProfile.numeroDocumento, userProfile.tipoDocumento))
                    {
                        ModelState.AddModelError("", "El número de documento existe para el tipo de documento.");
                        this.valoredefaut(userProfile);
                        return View("RegistrarseCelebra", userProfile);
                    }

                }
            }
            //validacion del password
            Regex rgx = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$");
            if (!rgx.IsMatch(userProfile.contrasena))
            {
                ModelState.AddModelError("", "La contraseña debe tener mínimo 8 caracteres, al menos 1 en mayúscula, 1 en minúscula y al menos un número");
                this.valoredefaut(userProfile);
                return View("RegistrarseCelebra", userProfile);
            }


            if (imagenPerfil != null && imagenPerfil.ContentLength > 0)
            {
                byte[] fileData = null;
                using (var binaryReader = new BinaryReader(imagenPerfil.InputStream))
                {// est se guarda en db
                    fileData = binaryReader.ReadBytes(imagenPerfil.ContentLength);
                }
                /// SM.Aplicacion.Escuelas.EscuelasLogica.ActualizarImagen(Convert.ToDecimal(Id), fileData);
                // model.Escuelas.imagen = fileData;

                string imageBase64Data = Convert.ToBase64String(fileData);
                imageDataURL = string.Format("data:image/png;base64,{0}", imageBase64Data);
                TempData["imagen"] = imageDataURL;
                ViewBag.ImageData = imageDataURL;

                userProfile.imagen = fileData;

            }


            UsuarioDTOSIM objDTOSIM = TranslatorUsuarioToUsuariodtosim.UsuariotoUsuarioDTOSIM(userProfile);
            // se deja activo para probra el proceso pero le llegara n correo para dicha activacion.
            objDTOSIM.esActivo = true;
            objDTOSIM.TipoRSS = Comunes.ConstantesRecursosBD.SIMUS_USUARIO_TIPO_CELEBRALADANZA;
            string ip = Request.UserHostAddress;
            SM.Aplicacion.Modulo_Usuarios.UsuarioLogica.crearUsuarioenSimusRegistrese(objDTOSIM, ip);
            //Enviamos el correo
            //FormsAuthentication.SetAuthCookie(model.usuario, false);
            objDTOSIM.esnuevoenSimus = true;
            Session["$usuario"] = objDTOSIM;



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

            ///ojo enviar a un archivo de recursos

            string strMensjeCreacion = "Bienvenido al Portal Celebra la Danza, como miembro, podrás acceder a la información relacionada con el Sector de la Danza de nuestro país y mucho más.";
            EnvioCorreo.EnviarCorreoHtmlCreacionDanza(objDTOSIM.Email, strMensjeCreacion, "Creación de cuenta", sUser.ToString());

            //ir a pagina de creacion
            return RedirectToAction("LoginCelebra", "Cuenta");
        }

        public ActionResult RegistrarseMusica()
        {
            valoredefaut(null);

            var mdl = new Usuarios();
            mdl.sexo = "Femenino";
            return View(mdl);

        }

        [HttpPost]
        public ActionResult RegistrarseMusica(HttpPostedFileBase imagenPerfil, Usuarios userProfile)
        {
            userProfile.msg = "";
            string imageDataURL = "";
            if (!ModelState.IsValid)
            {
                this.valoredefaut(userProfile);
                return View("RegistrarseMusica", userProfile);
            }
            userProfile.esUsuarioInterno = false;

            if (!userProfile.aceptaCondiciones)
            {
                Warning(string.Format("<b></b> Acepte términos y condiciones "), true);
                this.valoredefaut(userProfile);
                return View("RegistrarseMusica", userProfile);
            }


            if (SM.Aplicacion.Modulo_Usuarios.UsuarioLogica.existeUsurioEmail(userProfile.usuario))
            {
                Warning(string.Format("<b></b> El correo electrónico ya esta asociado a otro usuario por favor verifique "), true);
                this.valoredefaut(userProfile);
                return View("RegistrarseMusica", userProfile);
            }

            if (userProfile.numeroDocumento == null || userProfile.numeroDocumento == "")
            {
                Warning(string.Format("<b></b> El número de identificación es obligatorio "), true);
                this.valoredefaut(userProfile);
                return View("RegistrarseMusica", userProfile);
            }
            else
            {
                if (userProfile.tipoDocumento == null || userProfile.tipoDocumento == "")
                {
                    Warning(string.Format("<b></b> El tipo de documento es obligatorio. "), true);
                    this.valoredefaut(userProfile);
                    return View("RegistrarseMusica", userProfile);
                }
                else
                {

                    if (SM.Aplicacion.Modulo_Usuarios.UsuarioLogica.existedocumentoTipo(userProfile.numeroDocumento, userProfile.tipoDocumento))
                    {
                        Warning(string.Format("<b></b> El número de documento existe para el tipo de documento. "), true);
                        this.valoredefaut(userProfile);
                        return View("RegistrarseMusica", userProfile);
                    }

                }
            }
            //validacion del password
            Regex rgx = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$");
            if (!rgx.IsMatch(userProfile.contrasena))
            {
                Warning(string.Format("<b></b> La contraseña debe tener mínimo 8 caracteres, al menos 1 en mayúscula, 1 en minúscula y al menos un número. "), true);
                this.valoredefaut(userProfile);
                return View("RegistrarseMusica", userProfile);
            }


            if (imagenPerfil != null && imagenPerfil.ContentLength > 0)
            {
                byte[] fileData = null;
                using (var binaryReader = new BinaryReader(imagenPerfil.InputStream))
                {// est se guarda en db
                    fileData = binaryReader.ReadBytes(imagenPerfil.ContentLength);
                }
                /// SM.Aplicacion.Escuelas.EscuelasLogica.ActualizarImagen(Convert.ToDecimal(Id), fileData);
                // model.Escuelas.imagen = fileData;

                string imageBase64Data = Convert.ToBase64String(fileData);
                imageDataURL = string.Format("data:image/png;base64,{0}", imageBase64Data);
                TempData["imagen"] = imageDataURL;
                ViewBag.ImageData = imageDataURL;

                userProfile.imagen = fileData;

            }


            UsuarioDTOSIM objDTOSIM = TranslatorUsuarioToUsuariodtosim.UsuariotoUsuarioDTOSIM(userProfile);
            // se deja activo para probra el proceso pero le llegara n correo para dicha activacion.
            objDTOSIM.esActivo = true;
            objDTOSIM.TipoRSS = Comunes.ConstantesRecursosBD.SIMUS_USUARIO_TIPO_CELEBRALAMUSICA;
            string ip = Request.UserHostAddress;
            SM.Aplicacion.Modulo_Usuarios.UsuarioLogica.crearUsuarioenSimusRegistrese(objDTOSIM, ip);
            //Enviamos el correo
            //FormsAuthentication.SetAuthCookie(model.usuario, false);
            objDTOSIM.esnuevoenSimus = true;
            Session["$usuario"] = objDTOSIM;



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

            ///ojo enviar a un archivo de recursos

            string strMensjeCreacion = "Bienvenido al Portal Celebra la Música. Ahora puedes crear tu concierto, agregar artistas y modificar o agregar información.";
            EnvioCorreo.EnviarCorreoHtmlCreacionMusica(objDTOSIM.Email, strMensjeCreacion, "Creación de cuenta", sUser.ToString());

            //ir a pagina de creacion
            return RedirectToAction("LoginMusica", "Cuenta");
        }

        private void valoredefaut(Usuarios userProfile)
        {
            List<BasicaDTO> lsttipoDoc = BasicaLogica.ConsultarTiposDocumentos();
            ViewBag.listTipoDocumento = new SelectList(lsttipoDoc, "value", "text");

            List<BasicaDTO> lstPaises = ZonaGeograficasLogica.ConsultarPaises();
            ViewBag.listPaises = new SelectList(lstPaises, "value", "text");

            List<BasicaDTO> lstDpto = new List<BasicaDTO>();

            List<BasicaDTO> listMun = new List<BasicaDTO>();
            if (userProfile != null)
            {
                if (!string.IsNullOrEmpty(userProfile.departamento))
                {
                    lstDpto = ZonaGeograficasLogica.ConsultarDepartamentos();
                    listMun = ZonaGeograficasLogica.ConsultarMunicipios(userProfile.departamento);
                }
            }
            ViewBag.listDpto = new SelectList(lstDpto, "value", "text");
            ViewBag.listMun = new SelectList(listMun, "value", "text");


            ViewBag.esColombia = true;
            ViewBag.esDpto = true;


        }


        // GET: /Cuenta/
        public ActionResult OlvidoContrasena()
        {
            return View();
        }
        public ActionResult OlvidoContrasenaDanza()
        {
            return View();
        }
        [HttpPost]
        public ActionResult OlvidoContrasenaDanza(EmailModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("OlvidoContrasenaDanza", model);
            }
            //validamos que exista el correo elctreonico
            if (!SM.Aplicacion.Modulo_Usuarios.UsuarioLogica.existeUsurioEmailCelebra(model.usuario))
            {
                ModelState.AddModelError("", "El correo electrónico no existe por favor verifique.");
                return View("OlvidoContrasenaDanza", model);
            }


            UsuarioDTOSIM objUser = SM.Aplicacion.Modulo_Usuarios.UsuarioLogica.obtenerUsuarioporEmailCelebra(model.usuario);

            Comunes.EnvioCorreo.EnviarCorreoRestablecerContrasenaDanza(model.usuario, objUser.Id, objUser.PrimerNombre + " " + objUser.PrimerApellido + "" + objUser.SegundoNombre);

            objUser.restablececontrasena = true;
            Session["$usuario"] = objUser;
            return RedirectToAction("LoginCelebra", "Cuenta");
        }

        public ActionResult OlvidoContrasenaMusica()
        {
            return View();
        }
        [HttpPost]
        public ActionResult OlvidoContrasenaMusica(EmailModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("OlvidoContrasenaMusica", model);
            }
            //validamos que exista el correo elctreonico
            if (!SM.Aplicacion.Modulo_Usuarios.UsuarioLogica.existeUsurioEmailCelebra(model.usuario))
            {
                ModelState.AddModelError("", "El correo electrónico no existe por favor verifique.");
                return View("OlvidoContrasenaMusica", model);
            }


            UsuarioDTOSIM objUser = SM.Aplicacion.Modulo_Usuarios.UsuarioLogica.obtenerUsuarioporEmailCelebra(model.usuario);
            Comunes.EnvioCorreo.EnviarCorreoRestablecerContrasenaMusica(model.usuario, objUser.Id, objUser.PrimerNombre + " " + objUser.SegundoNombre + " " + objUser.PrimerApellido);

            objUser.restablececontrasena = true;
            Session["$usuario"] = objUser;
            return RedirectToAction("LoginMusica", "Cuenta");
        }
        #region MetodosPrivados
        private IAuthenticationManager AuthenticationManager
        {
            get
            {

                return HttpContext.GetOwinContext().Authentication;
            }
        }
        private async Task SignInAsync(ApplicationUser user, bool isPersistent)
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            var identity = await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);
        }
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Inicio");
            }
        }
        #endregion



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
        /// Guardar el nuevo usuario
        /// </summary>
        /// <param name="userProfile"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Guardar(HttpPostedFileBase imagenPerfil, Usuarios userProfile)
        {
            userProfile.msg = "";
            string imageDataURL = "";
            if (!ModelState.IsValid)
            {
                this.valoredefaut(userProfile);
                return View("Registrarse", userProfile);
            }
            userProfile.esUsuarioInterno = false;

            if (!userProfile.aceptaCondiciones)
            {
                TempData["MensajeSistema"] = "Acepte los términos y condiciones.";
                TempData["MensajeTipo"] = "warning";
                this.valoredefaut(userProfile);
                return View("Registrarse", userProfile);
            }

            if (SM.Aplicacion.Modulo_Usuarios.UsuarioLogica.existeUsurioEmail(userProfile.usuario))
            {
                TempData["MensajeSistema"] = "El correo electrónico ya está asociado a otro usuario. Por favor verifique.";
                TempData["MensajeTipo"] = "error";
                this.valoredefaut(userProfile);
                return View("Registrarse", userProfile);
            }

            if (string.IsNullOrWhiteSpace(userProfile.numeroDocumento))
            {
                TempData["MensajeSistema"] = "El número de identificación es obligatorio.";
                TempData["MensajeTipo"] = "warning";
                this.valoredefaut(userProfile);
                return View("Registrarse", userProfile);
            }

            if (string.IsNullOrWhiteSpace(userProfile.tipoDocumento))
            {
                TempData["MensajeSistema"] = "El tipo de documento es obligatorio.";
                TempData["MensajeTipo"] = "warning";
                this.valoredefaut(userProfile);
                return View("Registrarse", userProfile);
            }

            if (SM.Aplicacion.Modulo_Usuarios.UsuarioLogica.existedocumentoTipo(userProfile.numeroDocumento, userProfile.tipoDocumento))
            {
                TempData["MensajeSistema"] = "El número de documento ya existe para el tipo de documento seleccionado.";
                TempData["MensajeTipo"] = "error";
                this.valoredefaut(userProfile);
                return View("Registrarse", userProfile);
            }

            // Validación de contraseña segura
            Regex rgx = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*_.-]).{8,}$");
            if (!rgx.IsMatch(userProfile.contrasena))
            {
                TempData["MensajeSistema"] = "La contraseña debe tener al menos 8 caracteres, una mayúscula, una minúscula, un número y un carácter especial (!@#$%^&*_.-).";
                TempData["MensajeTipo"] = "warning";
                this.valoredefaut(userProfile);
                return View("Registrarse", userProfile);
            }



            if (imagenPerfil != null && imagenPerfil.ContentLength > 0)
            {
                byte[] fileData = null;
                using (var binaryReader = new BinaryReader(imagenPerfil.InputStream))
                {// est se guarda en db
                    fileData = binaryReader.ReadBytes(imagenPerfil.ContentLength);
                }
                /// SM.Aplicacion.Escuelas.EscuelasLogica.ActualizarImagen(Convert.ToDecimal(Id), fileData);
                // model.Escuelas.imagen = fileData;

                string imageBase64Data = Convert.ToBase64String(fileData);
                imageDataURL = string.Format("data:image/png;base64,{0}", imageBase64Data);
                TempData["imagen"] = imageDataURL;
                ViewBag.ImageData = imageDataURL;

                userProfile.imagen = fileData;

            }


            UsuarioDTOSIM objDTOSIM = TranslatorUsuarioToUsuariodtosim.UsuariotoUsuarioDTOSIM(userProfile);
            // se deja activo para probra el proceso pero le llegara n correo para dicha activacion.
            objDTOSIM.esActivo = true;
            objDTOSIM.TipoRSS = Comunes.ConstantesRecursosBD.SIMUS_USUARIO_TIPO_SIMUS;
            string ip = Request.UserHostAddress;
            SM.Aplicacion.Modulo_Usuarios.UsuarioLogica.crearUsuarioenSimusRegistrese(objDTOSIM, ip);

            TempData["Esnuevo"] = true;

            StringBuilder sUser = new StringBuilder();

            if (objDTOSIM.PrimerNombre != null)
            {
                sUser.Append(objDTOSIM.PrimerNombre);
                TempData["PrimerNombre"] = objDTOSIM.PrimerNombre;
            }
            if (objDTOSIM.SegundoNombre != null)
            {
                sUser.Append(" " + objDTOSIM.SegundoNombre);
            }
            if (objDTOSIM.PrimerApellido != null)
            {
                sUser.Append(" " + objDTOSIM.PrimerApellido);
                TempData["PrimerApellido"] = objDTOSIM.PrimerApellido;
            }
            if (objDTOSIM.segundoApellido != null)
            {
                sUser.Append(" " + objDTOSIM.segundoApellido);
            }



            EnvioCorreo.EnviarCorreoHtmlCreacion(objDTOSIM.Email, System.Configuration.ConfigurationManager.AppSettings["EmailMensajeCreacion"], "Creacion de cuenta en simus", sUser.ToString());

            //ir a pagina de creacion
            return RedirectToAction("Login", "Cuenta");
        }
        [HttpPost]
        public ActionResult Regresar()
        {
            return View("Index");
        }

        [HttpPost]
        public ActionResult Restablecer(EmailModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("OlvidoContrasena", model);
            }
            //validamos que exista el correo elctreonico
            if (!SM.Aplicacion.Modulo_Usuarios.UsuarioLogica.existeUsurioEmailSIMUS(model.usuario))
            {
                ModelState.AddModelError("", "El correo electrónico no existe por favor verifique.");
                return View("OlvidoContrasena", model);
            }


            UsuarioDTOSIM objUser = SM.Aplicacion.Modulo_Usuarios.UsuarioLogica.obtenerUsuarioporEmailCelebra(model.usuario);

            Comunes.EnvioCorreo.EnviarCorreoRestablecerContrasena(model.usuario, objUser.Id, objUser.PrimerNombre + " " + objUser.PrimerApellido);

            TempData["PrimerApellido"] = objUser.PrimerApellido;
            TempData["PrimerNombre"] = objUser.PrimerNombre;

            TempData["EsRestabecer"] = true;

            return RedirectToAction("Login", "Cuenta");
        }

        /// <summary>
        /// fin de session
        /// </summary>
        /// <returns></returns>
        public ActionResult Logout()
        {
            Session.Clear();
            Request.Cookies.Clear();
            FormsAuthentication.SignOut();
            this.Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            this.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            this.Response.Cache.SetNoStore();
            return RedirectToAction("Login", "Cuenta");
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            string ruta = "";
            ruta = Server.MapPath("/Log");
            Log.WriteLog(ruta, filterContext.Exception.ToString());

            Exception ex = filterContext.Exception;
            filterContext.ExceptionHandled = true;


            var model = new HandleErrorInfo(filterContext.Exception, "Cuenta", "Action");

            filterContext.Result = new ViewResult()
            {
                ViewName = "Error",
                ViewData = new ViewDataDictionary(model)
            };
        }

    }
}