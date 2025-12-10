using SM.Aplicacion.Basicas;
using SM.LibreriaComun.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSImus.Models;
using WebSImus.Translator;

namespace WebSImus.Controllers
{
    public class SimusPerfilController : BaseController
    {


        static string codColombia = "52";

        public Usuarios m_usuario
        {
            get { return TranslatorUsuarioToUsuariodtosim.UsuarioDTOSIMtoUsuario((UsuarioDTOSIM)Session["$usuario"]); }

        }


        //
        // GET: /SimusPerfil/
        public ActionResult Index()
        {
            return View();
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
            listMun = ZonaGeograficasLogica.ConsultarMunicipios(userProfile.departamento);
            ViewBag.listMun = new SelectList(listMun, "value", "text");


            ViewBag.esColombia = true;
            ViewBag.esDpto = true;


        }
        public ActionResult SimusPerfil()
        {
            if (m_usuario == null) return RedirectToAction("Login", "Cuenta");

            List<BasicaDTO> lsttipoDoc = BasicaLogica.ConsultarTiposDocumentos();
            ViewBag.listTipoDocumento = new SelectList(lsttipoDoc, "value", "text");

            List<BasicaDTO> lstPaises = ZonaGeograficasLogica.ConsultarPaises();
            ViewBag.listPaises = new SelectList(lstPaises, "value", "text");
            List<BasicaDTO> lstDpto = new List<BasicaDTO>();

            var model = m_usuario;
            //traemos la informacion si esta ya existe
            if (SM.Aplicacion.Modulo_Usuarios.UsuarioLogica.existeUsurioEmail(m_usuario.usuario))
            {
                UsuarioDTOSIM userExiste = SM.Aplicacion.Modulo_Usuarios.UsuarioLogica.obtenerUsuarioporEmail(m_usuario.usuario, Comunes.ConstantesRecursosBD.SIMUS_USUARIO_TIPO_SIMUS);

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



        [HttpPost]
        public ActionResult ActualizarCuenta(HttpPostedFileBase imagenPerfil, Usuarios userProfile)
        {
            userProfile.msg = "";
            string imageDataURL = "";
            if (!ModelState.IsValid)
            {
                this.valoredefaut(userProfile);
                return View("SimusPerfil", userProfile);
            }
            userProfile.esUsuarioInterno = false;
            userProfile.aceptaCondiciones = true;


            if (SM.Aplicacion.Modulo_Usuarios.UsuarioLogica.existeUsurioEmailId(userProfile.usuario, userProfile.Id))
            {
                ModelState.AddModelError("", "El correo electronico ya esta asociado a otro usuario por favor verifique.");
                this.valoredefaut(userProfile);
                return View("SimusPerfil", userProfile);
            }

            if (userProfile.numeroDocumento == null || userProfile.numeroDocumento == "")
            {
                ModelState.AddModelError("", "El número de identificación es obligatorio");
                this.valoredefaut(userProfile);
                return View("SimusPerfil", userProfile);
            }

            if (userProfile.tipoDocumento == null || userProfile.tipoDocumento == "")
            {
                ModelState.AddModelError("", "El tipo de documento es obligatorio");
                this.valoredefaut(userProfile);
                return View("SimusPerfil", userProfile);
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
            objDTOSIM.esUsuarioInterno = false;


            SM.Aplicacion.Modulo_Usuarios.UsuarioLogica.modificarUsuarioSIMUS(objDTOSIM, Request.UserHostAddress);


            //Enviamos el correo
            //FormsAuthentication.SetAuthCookie(model.usuario, false);

            objDTOSIM.esactualizadoPerfil = true;
            Session["$usuario"] = objDTOSIM;
            Success("Ha sido actualizado su perfil satisfactoriamente.  ", true);
            return RedirectToAction("SimusPerfil", "SimusPerfil");
        }

    }
}