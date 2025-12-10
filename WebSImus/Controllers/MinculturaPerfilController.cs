using SM.Aplicacion.Basicas;
using SM.LibreriaComun.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebSImus.Models;
using WebSImus.Translator;

namespace WebSImus.Controllers
{
    public class MinculturaPerfilController : Controller
    {
        //
        // GET: /MinculturaPerfil/


        static string codColombia = "52";
        public Usuarios m_usuario
        {
            get { return TranslatorUsuarioToUsuariodtosim.UsuarioDTOSIMtoUsuario((UsuarioDTOSIM)Session["$usuario"]); }

        }
        public ActionResult Index()
        {
            if (m_usuario == null) return RedirectToAction("home", "Index");

            List<BasicaDTO> lsttipoDoc = BasicaLogica.ConsultarTiposDocumentos();
            ViewBag.listTipoDocumento = new SelectList(lsttipoDoc, "value", "text");

            List<BasicaDTO> lstPaises = ZonaGeograficasLogica.ConsultarPaises();
            ViewBag.listPaises = new SelectList(lstPaises, "value", "text");

            List<BasicaDTO> lstDpto = new List<BasicaDTO>();
            ViewBag.listDpto = new SelectList(lstDpto, "value", "text");

            List<BasicaDTO> listMun = new List<BasicaDTO>();
            ViewBag.listMun = new SelectList(listMun, "value", "text");


            ViewBag.esColombia = true;
            ViewBag.esDpto = true;
            // cargamos el que acaba de llegar



            var model = m_usuario;


            return View(model);

        }
        public ActionResult MinPerfil()
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
                UsuarioDTOSIM userExiste = SM.Aplicacion.Modulo_Usuarios.UsuarioLogica.obtenerUsuarioporEmail(m_usuario.usuario, Comunes.ConstantesRecursosBD.SIMUS_USUARIO_TIPO_MINCULTURA);

                model.pais = userExiste.CodPais;
                model.Id = userExiste.Id;
                model.departamento = userExiste.CodDpto;
                model.municipio = userExiste.CodMunicipio;
                model.imagen = userExiste.imagen;
                model.sexo = userExiste.Sexo;
                model.segundoNombre = userExiste.SegundoNombre;
                model.segundoApellido = userExiste.segundoApellido;
                IFormatProvider culture = new System.Globalization.CultureInfo("es-CO", true);

                model.fechaNacimiento = userExiste.Fechanacimiento != null ? userExiste.Fechanacimiento.Value.ToString("yyyy-MM-dd") : String.Empty;
                model.tipoRedSocial = userExiste.TipoRSS;
                model.tipoDocumento = userExiste.CodTipoDocumento;
            }
            //if (model.fechaNacimiento == null) m_usuario.fechaNacimiento = DateTime.Now.AddYears(-45);

            if (model.pais != null && model.pais != Comunes.ConstantesRecursosBD.SIMUS_SIPA_COD_COLOMBIA)
            {
                lstDpto = ZonaGeograficasLogica.ConsultarDepartamentosporPais(model.pais);
            }
                      
            List<BasicaDTO> listMun = new List<BasicaDTO>();

            if (model.departamento != null && model.pais== Comunes.ConstantesRecursosBD.SIMUS_SIPA_COD_COLOMBIA)
            {
                lstDpto = ZonaGeograficasLogica.ConsultarDepartamentos();
                listMun = ZonaGeograficasLogica.ConsultarMunicipios(model.departamento);
             
            }
            ViewBag.listDpto = new SelectList(lstDpto, "value", "text");
            ViewBag.listMun = new SelectList(listMun, "value", "text");


            ViewBag.esColombia = true;
            ViewBag.esDpto = true;
            // cargamos el que acaba de llegar



            model.contrasena = Comunes.ConstantesRecursosBD.SIMUS_SIPA_CLAVE_DEFAULT;
            model.confcontrasena = Comunes.ConstantesRecursosBD.SIMUS_SIPA_CLAVE_DEFAULT;


            return View(model);

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


        //
        // GET: /MinculturaPerfil/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /MinculturaPerfil/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /MinculturaPerfil/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /MinculturaPerfil/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /MinculturaPerfil/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /MinculturaPerfil/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
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
            if (userProfile.departamento != null) listMun = ZonaGeograficasLogica.ConsultarMunicipios(userProfile.departamento);
            ViewBag.listMun = new SelectList(listMun, "value", "text");


            ViewBag.esColombia = true;
            ViewBag.esDpto = true;


        }

        //
        // POST: /MinculturaPerfil/Delete/5
        [HttpPost]
        public ActionResult ActualizarCuenta(HttpPostedFileBase imagenPerfil, Usuarios userProfile)
        {
            userProfile.msg = "";
            string imageDataURL = "";
            string ip = Request.UserHostAddress;
            string nombrePerfil = "STANDARD";
            string nombreCompleto;
            if (!ModelState.IsValid)
            {
                this.valoredefaut(userProfile);
                return View("MinPerfil", userProfile);
            }
            userProfile.esUsuarioInterno = false;



            if (userProfile.numeroDocumento == null || userProfile.numeroDocumento == "")
            {
                ModelState.AddModelError("", "El numero de identificación es obligatorio");
                this.valoredefaut(userProfile);
                return View("MinPerfil", userProfile);
            }
            if (userProfile.tipoDocumento == null || userProfile.tipoDocumento == "")
            {
                ModelState.AddModelError("", "El tipo de documento es obligatorio");
                this.valoredefaut(userProfile);
                return View("MinPerfil", userProfile);
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
            objDTOSIM.esUsuarioInterno = true;
            objDTOSIM.TipoRSS = Comunes.ConstantesRecursosBD.SIMUS_USUARIO_TIPO_MINCULTURA;

            if (!SM.Aplicacion.Modulo_Usuarios.UsuarioLogica.existeUsurioEmail(objDTOSIM.Email))
            {   //valor por default
                objDTOSIM.contrasena = Comunes.ConstantesRecursosBD.SIMUS_SIPA_CLAVE_DEFAULT;
                objDTOSIM.TipoRSS = Comunes.ConstantesRecursosBD.SIMUS_USUARIO_TIPO_MINCULTURA;
              
                SM.Aplicacion.Modulo_Usuarios.UsuarioLogica.crearUsuarioenSimusRegistrese(objDTOSIM, ip);
            }
            else
            {
                SM.Aplicacion.Modulo_Usuarios.UsuarioLogica.modificarUsuarioSIMUS(objDTOSIM, ip);
            }


            //Enviamos el correo
            //FormsAuthentication.SetAuthCookie(model.usuario, false);
            objDTOSIM.esactualizadoPerfil = true;
            nombreCompleto = objDTOSIM.PrimerNombre + " " + objDTOSIM.SegundoNombre + " " + objDTOSIM.PrimerApellido;
            int UsuarioInterno = 1;
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
            Session["$usuario"] = objDTOSIM;
            userProfile.msg = "Ha sido registrado satisfactoriamente, pronto tendra un correo electronico para activar su cuenta";

            return RedirectToAction("Index", "Inicio");
        }
    }
}
