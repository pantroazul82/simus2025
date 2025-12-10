using SM.Datos.DTO.Servicios;
using SM.Datos.Servicios;
using SM.Utilidades.Log;
using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;
using WebSImus.Models;
using System.Text;
using SM.SIPA;
using System.Data.Entity;
using System.Data;
using System.Globalization;

namespace WebSImus.Controllers
{
    public class FestivalesController : BaseController
    {
        // Memoria temporal de versiones por Festival (simulado)
        private static List<FestivalVersionListadoItemViewModel> _versionesTemp = new List<FestivalVersionListadoItemViewModel>
        {
            new FestivalVersionListadoItemViewModel{ Id=1, NombreVersion="Versión 1", FechaCreacion=new DateTime(2025,6,17), FechaSolicitud=new DateTime(2025,6,17), Estado="Incompleto"},
            new FestivalVersionListadoItemViewModel{ Id=2, NombreVersion="Versión 2", FechaCreacion=new DateTime(2025,6,17), FechaSolicitud=new DateTime(2025,6,17), Estado="Registrado"},
            new FestivalVersionListadoItemViewModel{ Id=3, NombreVersion="Versión 3", FechaCreacion=new DateTime(2025,6,17), FechaSolicitud=new DateTime(2025,6,17), Estado="Rechazado"},
            new FestivalVersionListadoItemViewModel{ Id=4, NombreVersion="Versión 4", FechaCreacion=new DateTime(2025,6,17), FechaSolicitud=new DateTime(2025,6,17), Estado="Solicitud de Aclaraciones"},
            new FestivalVersionListadoItemViewModel{ Id=5, NombreVersion="Versión 5", FechaCreacion=new DateTime(2025,6,17), FechaSolicitud=new DateTime(2025,6,17), Estado="Publicado"},
        };
        // Simulamos una "base de datos" con datos ficticios
        private static List<FestivalViewModel> festivalesColombia = new List<FestivalViewModel>
        {
            new FestivalViewModel { Nombre = "Festival Vallenato", Ciudad = "Valledupar", Departamento = "Cesar", Fecha = new DateTime(2025, 4, 26), GeneroMusical = "Vallenato", EsGratis = false, ImagenUrl = "/img/logo-login.png" },
            new FestivalViewModel { Nombre = "Rock al Parque", Ciudad = "Bogotá", Departamento = "Cundinamarca", Fecha = new DateTime(2025, 7, 15), GeneroMusical = "Rock", EsGratis = true, ImagenUrl = "/img/logo-login.png" },
            new FestivalViewModel { Nombre = "Estéreo Picnic", Ciudad = "Bogotá", Departamento = "Cundinamarca", Fecha = new DateTime(2025, 3, 22), GeneroMusical = "Alternativo", EsGratis = false, ImagenUrl = "/img/logo-login.png" },
            new FestivalViewModel { Nombre = "Petronio Álvarez", Ciudad = "Cali", Departamento = "Valle del Cauca", Fecha = new DateTime(2025, 8, 12), GeneroMusical = "Pacífico", EsGratis = true, ImagenUrl = "/img/logo-login.png" },
            new FestivalViewModel { Nombre = "Jazz al Parque", Ciudad = "Bogotá", Departamento = "Cundinamarca", Fecha = new DateTime(2025, 9, 3), GeneroMusical = "Jazz", EsGratis = true, ImagenUrl = "/img/logo-login.png" },
            new FestivalViewModel { Nombre = "Festival de Tambores", Ciudad = "San Basilio de Palenque", Departamento = "Bolívar", Fecha = new DateTime(2025, 10, 18), GeneroMusical = "Folclor", EsGratis = false, ImagenUrl = "/img/logo-login.png" },
            new FestivalViewModel { Nombre = "Colombia al Parque", Ciudad = "Bogotá", Departamento = "Cundinamarca", Fecha = new DateTime(2025, 6, 7), GeneroMusical = "Folclor", EsGratis = true, ImagenUrl = "/img/logo-login.png" },
            new FestivalViewModel { Nombre = "Festival del Bambuco", Ciudad = "Neiva", Departamento = "Huila", Fecha = new DateTime(2025, 6, 24), GeneroMusical = "Andino", EsGratis = false, ImagenUrl = "/img/logo-login.png" },
            new FestivalViewModel { Nombre = "Carnaval de Negros y Blancos", Ciudad = "Pasto", Departamento = "Nariño", Fecha = new DateTime(2025, 1, 5), GeneroMusical = "Tradicional", EsGratis = true, ImagenUrl = "/img/logo-login.png" },
            new FestivalViewModel { Nombre = "Festival de Jazz de Mompox", Ciudad = "Mompox", Departamento = "Bolívar", Fecha = new DateTime(2025, 11, 1), GeneroMusical = "Jazz", EsGratis = false, ImagenUrl = "/img/logo-login.png" },
        };

        public ActionResult Index(
                string textoBusqueda,
                string generoSeleccionado,
                bool? soloGratis,
                string departamentoSeleccionado,
                DateTime? fechaInicio,
                DateTime? fechaFin)
        {
            var resultados = festivalesColombia.AsQueryable();

            if (!string.IsNullOrEmpty(textoBusqueda))
                resultados = resultados.Where(f => f.Nombre.ToLower().Contains(textoBusqueda.ToLower())
                                                || f.Ciudad.ToLower().Contains(textoBusqueda.ToLower()));

            if (!string.IsNullOrEmpty(generoSeleccionado))
                resultados = resultados.Where(f => f.GeneroMusical == generoSeleccionado);

            if (!string.IsNullOrEmpty(departamentoSeleccionado))
                resultados = resultados.Where(f => f.Departamento == departamentoSeleccionado);

            if (soloGratis.HasValue && soloGratis.Value)
                resultados = resultados.Where(f => f.EsGratis);

            if (fechaInicio.HasValue)
                resultados = resultados.Where(f => f.Fecha >= fechaInicio.Value);

            if (fechaFin.HasValue)
                resultados = resultados.Where(f => f.Fecha <= fechaFin.Value);

            var model = new BusquedaFestivalesViewModel
            {
                TextoBusqueda = textoBusqueda,
                GeneroSeleccionado = generoSeleccionado,
                DepartamentoSeleccionado = departamentoSeleccionado,
                FechaInicio = fechaInicio,
                FechaFin = fechaFin,
                SoloGratis = soloGratis,
                Resultados = resultados.ToList()
            };

            return View(model);
        }

        // Página de listado administrativo (tabla) similar a la imagen proporcionada
        public ActionResult Listado()
        {
            try
            {
                var vm = new FestivalListadoViewModel
                {
                    FiltroTexto = "",
                    Festivales = new List<FestivalListadoItemViewModel>(),
                    PaginaActual = 1,
                    TotalPaginas = 1
                };

                return View(vm);
            }
            catch (Exception ex)
            {
                // Log del error
                string ruta = Server.MapPath("/Log");
                Log.WriteLog(ruta, ex.ToString());

                var vmError = new FestivalListadoViewModel
                {
                    FiltroTexto = "",
                    Festivales = new List<FestivalListadoItemViewModel>(),
                    PaginaActual = 1,
                    TotalPaginas = 1
                };
                return View(vmError);
            }
        }

        [ValidateInput(false)]
        public ActionResult GridViewPartial()
        {
            var model = new List<FestivalListadoItemViewModel>();
            
            try
            {
                // Obtener ID del usuario autenticado desde BaseController
                int usuarioId = string.IsNullOrEmpty(UsuaroId) ? 0 : Convert.ToInt32(UsuaroId);
                
                // Consultar TODOS los festivales del usuario
                List<FestivalListadoDTO> datos = FestivalServicio.ObtenerPorUsuarioId(usuarioId);

                // Convertir DTO a ViewModel para la vista
                model = datos.Select(d => new FestivalListadoItemViewModel
                {
                    Id = d.Id,
                    Nombre = d.Nombre,
                    FechaCreacion = d.FechaCreacion,
                    FechaSolicitud = d.FechaSolicitud,
                    FechaSolicitudAclaraciones = d.FechaSolicitudAclaraciones,
                    FechaReciboAclaraciones = d.FechaReciboAclaraciones,
                    Estado = d.Estado
                }).ToList();
            }
            catch (Exception ex)
            {
                // Log del error
                string ruta = Server.MapPath("/Log");
                Log.WriteLog(ruta, ex.ToString());
            }

            return PartialView("_GridViewPartial", model);
        }

        // GET: Festivales/Ver/5
        public ActionResult Ver(int id)
        {
            try
            {
                var datos = FestivalServicio.ObtenerPorId(id);
                
                if (datos == null)
                {
                    return HttpNotFound();
                }

                // Convertir DTO a ViewModel
                var model = new FestivalDetalleViewModel
                {
                    Id = datos.Id,
                    Nombre = datos.Nombre,
                    VersionesRealizadas = datos.VersionesRealizadas,
                    FechaUltimaVersion = datos.FechaUltimaVersion,
                    Descripcion = datos.Descripcion,
                    CorreoContacto = datos.CorreoContacto,
                    Instagram = datos.Instagram,
                    Facebook = datos.Facebook,
                    PaginaWeb = datos.PaginaWeb,
                    OtroEnlace = datos.OtroEnlace,
                    Celular = datos.Celular,
                    ObservacionesContacto = datos.ObservacionesContacto,
                    FechaEnvio = datos.FechaEnvio,
                    Estado = datos.Estado,
                    SoloLectura = true
                };

                return View(model);
            }
            catch (Exception ex)
            {
                string ruta = Server.MapPath("/Log");
                Log.WriteLog(ruta, ex.ToString());
                return RedirectToAction("Listado");
            }
        }

        // ========== MÉTODOS PRIVADOS DE VALIDACIÓN ==========

        /// <summary>
        /// Normaliza y limpia los datos del festival
        /// </summary>
        private void NormalizarDatosFestival(FestivalRegistroViewModel model)
        {
            // Limpiar espacios en blanco
            if (!string.IsNullOrEmpty(model.Nombre))
                model.Nombre = model.Nombre.Trim();

            if (!string.IsNullOrEmpty(model.Descripcion))
                model.Descripcion = model.Descripcion.Trim();

            if (!string.IsNullOrEmpty(model.CorreoContacto))
                model.CorreoContacto = model.CorreoContacto.Trim().ToLower();

            // Normalizar teléfono: solo dígitos
            if (!string.IsNullOrEmpty(model.TelefonoCelular))
            {
                model.TelefonoCelular = new string(model.TelefonoCelular.Where(char.IsDigit).ToArray());
            }

            // Normalizar URLs: agregar https:// si no tiene protocolo
            if (!string.IsNullOrEmpty(model.Instagram) && !model.Instagram.StartsWith("http"))
                model.Instagram = "https://" + model.Instagram.Trim();

            if (!string.IsNullOrEmpty(model.Facebook) && !model.Facebook.StartsWith("http"))
                model.Facebook = "https://" + model.Facebook.Trim();

            if (!string.IsNullOrEmpty(model.PaginaWeb) && !model.PaginaWeb.StartsWith("http"))
                model.PaginaWeb = "https://" + model.PaginaWeb.Trim();

            if (!string.IsNullOrEmpty(model.OtroEnlace) && !model.OtroEnlace.StartsWith("http"))
                model.OtroEnlace = "https://" + model.OtroEnlace.Trim();
        }

        /// <summary>
        /// Valida los datos del festival (backend)
        /// </summary>
        private void ValidarFestival(FestivalRegistroViewModel model)
        {
            // 1. VALIDACIÓN DE CAMPOS OBLIGATORIOS
            if (string.IsNullOrWhiteSpace(model.Nombre))
                ModelState.AddModelError("Nombre", "El nombre del festival es obligatorio");

            if (!model.NumeroVersiones.HasValue || model.NumeroVersiones < 0)
                ModelState.AddModelError("NumeroVersiones", "El número de versiones realizadas es obligatorio y debe ser mayor o igual a 0");

            if (!model.FechaUltimaVersion.HasValue)
                ModelState.AddModelError("FechaUltimaVersion", "La fecha de última versión es obligatoria");
            else if (model.FechaUltimaVersion.Value > DateTime.Now.Date)
                ModelState.AddModelError("FechaUltimaVersion", "La fecha de última versión no puede ser futura");

            if (string.IsNullOrWhiteSpace(model.CorreoContacto))
                ModelState.AddModelError("CorreoContacto", "El correo electrónico de contacto es obligatorio");

            // 2. VALIDACIÓN DE FORMATO DE EMAIL
            if (!string.IsNullOrWhiteSpace(model.CorreoContacto))
            {
                try
                {
                    var addr = new System.Net.Mail.MailAddress(model.CorreoContacto);
                    if (addr.Address != model.CorreoContacto)
                        ModelState.AddModelError("CorreoContacto", "El correo electrónico no tiene un formato válido");
                }
                catch
                {
                    ModelState.AddModelError("CorreoContacto", "El correo electrónico no tiene un formato válido");
                }
            }

            // 3. VALIDACIÓN DE TELÉFONO
            if (!string.IsNullOrWhiteSpace(model.TelefonoCelular))
            {
                if (model.TelefonoCelular.Length < 7 || model.TelefonoCelular.Length > 15)
                    ModelState.AddModelError("TelefonoCelular", "El teléfono debe tener entre 7 y 15 dígitos");
            }

            // 4. VALIDACIÓN DE AL MENOS UNA RED SOCIAL
            var tieneInstagram = !string.IsNullOrWhiteSpace(model.Instagram);
            var tieneFacebook = !string.IsNullOrWhiteSpace(model.Facebook);
            var tienePaginaWeb = !string.IsNullOrWhiteSpace(model.PaginaWeb);

            if (!tieneInstagram && !tieneFacebook && !tienePaginaWeb)
            {
                ModelState.AddModelError("", "Debe diligenciar al menos uno: Instagram, Facebook o Página WEB");
            }

            // 5. VALIDACIÓN DE URLs DE REDES SOCIALES
            if (tieneInstagram)
            {
                if (!ValidarURL(model.Instagram))
                    ModelState.AddModelError("Instagram", "La URL de Instagram no es válida");
                else if (!model.Instagram.Contains("instagram.com"))
                    ModelState.AddModelError("Instagram", "La URL debe pertenecer a instagram.com");
            }

            if (tieneFacebook)
            {
                if (!ValidarURL(model.Facebook))
                    ModelState.AddModelError("Facebook", "La URL de Facebook no es válida");
                else if (!model.Facebook.Contains("facebook.com"))
                    ModelState.AddModelError("Facebook", "La URL debe pertenecer a facebook.com");
            }

            if (tienePaginaWeb && !ValidarURL(model.PaginaWeb))
                ModelState.AddModelError("PaginaWeb", "La URL de la página web no es válida");

            if (!string.IsNullOrWhiteSpace(model.OtroEnlace) && !ValidarURL(model.OtroEnlace))
                ModelState.AddModelError("OtroEnlace", "La URL de otro enlace no es válida");
        }

        /// <summary>
        /// Valida si una URL tiene formato correcto
        /// </summary>
        private bool ValidarURL(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                return false;

            return Uri.TryCreate(url, UriKind.Absolute, out Uri uriResult)
                   && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }

        // GET: Festivales/Crear
        // GET: Festivales/Editar/5 (usa la misma vista Crear)
        public ActionResult Crear(int? id, string activeTab = "festival")
        {
            try
            {
                var vm = new FestivalRegistroViewModel();

                // Si hay id, estamos editando
                if (id.HasValue)
                {
                    var datos = FestivalServicio.ObtenerPorId(id.Value);
                    if (datos == null)
                    {
                        return HttpNotFound();
                    }

                    // Cargar datos del festival existente
                    vm.Id = datos.Id;
                    vm.Nombre = datos.Nombre;
                    vm.NumeroVersiones = datos.VersionesRealizadas;
                    vm.FechaUltimaVersion = datos.FechaUltimaVersion;
                    vm.Descripcion = datos.Descripcion;
                    vm.CorreoContacto = datos.CorreoContacto;
                    vm.Instagram = datos.Instagram;
                    vm.Facebook = datos.Facebook;
                    vm.PaginaWeb = datos.PaginaWeb;
                    vm.OtroEnlace = datos.OtroEnlace;
                    vm.TelefonoCelular = datos.Celular;
                    vm.Observaciones = datos.ObservacionesContacto;
                    vm.EsEdicion = true;
                }

                // Configurar pestaña activa
                vm.ActiveTab = activeTab;

                return View(vm);
            }
            catch (Exception ex)
            {
                string ruta = Server.MapPath("/Log");
                Log.WriteLog(ruta, ex.ToString());
                return RedirectToAction("Listado");
            }
        }

        // POST: Festivales/Crear
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(FestivalRegistroViewModel model, string accion)
        {
            // accion: Guardar | Siguiente | Cancelar
            if (string.Equals(accion, "Cancelar", StringComparison.OrdinalIgnoreCase))
                return RedirectToAction("Listado");

            // Normalizar y limpiar datos
            NormalizarDatosFestival(model);

            // Validar siempre (tanto para Guardar como Siguiente)
            ValidarFestival(model);

            // Verificar si hay errores de validación
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            bool esValidoParaSiguiente = string.Equals(accion, "Siguiente", StringComparison.OrdinalIgnoreCase);

            // Guardar: permite guardar incompleto o completar el registro
            if (string.Equals(accion, "Guardar", StringComparison.OrdinalIgnoreCase) || esValidoParaSiguiente)
            {
                try
                {
                    // Obtener información del usuario autenticado
                    int usuarioId = string.IsNullOrEmpty(UsuaroId) ? 0 : Convert.ToInt32(UsuaroId);
                    string nombreUsuario = Usuario ?? "Sistema";
                    string ipUsuario = Request.UserHostAddress ?? "0.0.0.0";

                    string ruta = Server.MapPath("/Log");
                    Log.WriteLog(ruta, $"POST Crear - Iniciando guardado. Usuario: {nombreUsuario}, UsuarioId: {usuarioId}, Accion: {accion}");
                    Log.WriteLog(ruta, $"POST Crear - Modelo: Id={model.Id}, Nombre={model.Nombre}, NumVersiones={model.NumeroVersiones}");

                    int festivalId;

                    // Verificar si es edición o creación
                    if (model.Id > 0)
                    {
                        Log.WriteLog(ruta, $"POST Crear - MODO ACTUALIZACIÓN - Festival ID: {model.Id}");
                        
                        // ACTUALIZAR festival existente
                        var festivalActualizar = new FestivalActualizarDTO
                        {
                            Id = model.Id,
                            Nombre = model.Nombre?.Trim(),
                            NumeroVersiones = model.NumeroVersiones,
                            FechaUltimaVersion = model.FechaUltimaVersion,
                            Descripcion = model.Descripcion?.Trim(),
                            CorreoContacto = model.CorreoContacto?.Trim(),
                            Instagram = model.Instagram?.Trim(),
                            Facebook = model.Facebook?.Trim(),
                            PaginaWeb = model.PaginaWeb?.Trim(),
                            OtroEnlace = model.OtroEnlace?.Trim(),
                            TelefonoCelular = model.TelefonoCelular?.Trim(),
                            Observaciones = model.Observaciones?.Trim(),
                            IdEstado = esValidoParaSiguiente ? 2 : 1
                        };

                        Log.WriteLog(ruta, $"POST Crear - Llamando a FestivalServicio.Actualizar...");
                        FestivalServicio.Actualizar(festivalActualizar, nombreUsuario, usuarioId, ipUsuario);
                        festivalId = model.Id;
                        
                        Log.WriteLog(ruta, $"POST Crear - Actualización exitosa. FestivalId: {festivalId}");

                        // Mensaje de éxito y redirección
                        if (esValidoParaSiguiente)
                        {
                            Log.WriteLog(ruta, $"POST Crear - Redirigiendo a pestaña de versiones");
                            Success("Festival actualizado correctamente. Ahora puede gestionar versiones.");
                            // Permanecer en edición con pestaña de versiones activa
                            return RedirectToAction("Crear", new { id = festivalId, activeTab = "versiones" });
                        }
                        else
                        {
                            Log.WriteLog(ruta, $"POST Crear - Redirigiendo a listado");
                            Success("Festival actualizado correctamente.");
                            return RedirectToAction("Listado");
                        }
                    }
                    else
                    {
                        Log.WriteLog(ruta, $"POST Crear - MODO CREACIÓN - Nuevo festival");
                        
                        // CREAR nuevo festival
                        var nuevoFestival = new FestivalCrearDTO
                        {
                            Nombre = model.Nombre?.Trim(),
                            NumeroVersiones = model.NumeroVersiones,
                            FechaUltimaVersion = model.FechaUltimaVersion,
                            Descripcion = model.Descripcion?.Trim(),
                            CorreoContacto = model.CorreoContacto?.Trim(),
                            Instagram = model.Instagram?.Trim(),
                            Facebook = model.Facebook?.Trim(),
                            PaginaWeb = model.PaginaWeb?.Trim(),
                            OtroEnlace = model.OtroEnlace?.Trim(),
                            TelefonoCelular = model.TelefonoCelular?.Trim(),
                            Observaciones = model.Observaciones?.Trim(),
                            IdEstado = esValidoParaSiguiente ? 2 : 1
                        };

                        Log.WriteLog(ruta, $"POST Crear - Llamando a FestivalServicio.Agregar...");
                        festivalId = FestivalServicio.Agregar(nuevoFestival, nombreUsuario, usuarioId, ipUsuario);
                        Log.WriteLog(ruta, $"POST Crear - Festival creado exitosamente con ID: {festivalId}");

                        // Mensaje de éxito y redirección
                        if (esValidoParaSiguiente)
                        {
                            Log.WriteLog(ruta, $"POST Crear - Redirigiendo a pestaña de versiones con ID: {festivalId}");
                            Success("Festival creado exitosamente. Ahora puede agregar versiones.");
                            // Redirigir a edición con pestaña de versiones activa
                            return RedirectToAction("Crear", new { id = festivalId, activeTab = "versiones" });
                        }
                        else
                        {
                            Log.WriteLog(ruta, $"POST Crear - Redirigiendo a listado");
                            Success("Festival creado exitosamente.");
                            return RedirectToAction("Listado");
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Log del error
                    string ruta = Server.MapPath("/Log");
                    Log.WriteLog(ruta, $"POST Crear - ERROR CRÍTICO al {(model.Id > 0 ? "actualizar" : "crear")} festival");
                    Log.WriteLog(ruta, $"ERROR: {ex.Message}");
                    Log.WriteLog(ruta, $"STACK TRACE: {ex.StackTrace}");
                    
                    var innerEx = ex.InnerException;
                    while (innerEx != null)
                    {
                        Log.WriteLog(ruta, $"INNER EXCEPTION: {innerEx.Message}");
                        Log.WriteLog(ruta, $"INNER STACK TRACE: {innerEx.StackTrace}");
                        innerEx = innerEx.InnerException;
                    }

                    ModelState.AddModelError("", "Ocurrió un error al guardar el festival. Por favor, intente nuevamente.");
                }
            }

            return View(model);
        }

        // ========== VERSIONES (Pesta&ntilde;a) ==========
        [ValidateInput(false)]
        public ActionResult GridVersionesPartial(int? festivalId, string filtroTexto = null)
        {
            try
            {
                List<FestivalVersionListadoItemViewModel> datos = new List<FestivalVersionListadoItemViewModel>();

                if (festivalId.HasValue && festivalId.Value > 0)
                {
                    // Consultar versiones desde la base de datos con el estado del festival
                    using (var contexto = new SM.SIPA.SIPAEntities())
                    {
                        var versiones = contexto.ART_MUS_FESTIVALES_VERSION
                            .Include("ART_MUS_FESTIVALES")
                            .Where(v => v.ID_FESTIVAL == festivalId.Value)
                            .ToList();

                        foreach (var v in versiones)
                        {
                            // Obtener el estado del festival padre usando el servicio centralizado
                            string estadoVersion = "Sin estado";
                            
                            if (v.ART_MUS_FESTIVALES != null && v.ART_MUS_FESTIVALES.ID_ESTADO.HasValue)
                            {
                                estadoVersion = FestivalServicio.ObtenerNombreEstadoFestival(v.ART_MUS_FESTIVALES.ID_ESTADO.Value);
                            }

                            datos.Add(new FestivalVersionListadoItemViewModel
                            {
                                Id = v.ID,
                                NumeroVersion = v.VERSION_FESTIVAL,
                                NombreVersion = v.NOMBRE_VERSION,
                                FechaCreacion = DateTime.Now, // TODO: Agregar campo de fecha de creaci&oacute;n en la entidad
                                FechaSolicitud = null, // TODO: Agregar campo de fecha de solicitud en la entidad
                                Estado = estadoVersion
                            });
                        }
                    }
                }

                // Aplicar filtro si existe
                if (!string.IsNullOrWhiteSpace(filtroTexto))
                {
                    var f = filtroTexto.Trim();
                    datos = datos.Where(v => (v.NombreVersion ?? string.Empty).IndexOf(f, StringComparison.OrdinalIgnoreCase) >= 0
                                           || (v.Estado ?? string.Empty).IndexOf(f, StringComparison.OrdinalIgnoreCase) >= 0)
                                 .ToList();
                }

                ViewBag.FiltroTextoVersion = filtroTexto;
                ViewBag.FestivalId = festivalId;
                
                // Verificar si el usuario tiene rol 8 para mostrar botón Revisar
                ViewBag.TieneRol8 = false;
                if (!string.IsNullOrEmpty(UsuaroId))
                {
                    decimal userId = Convert.ToDecimal(UsuaroId);
                    var roles = SM.Datos.Perfiles.ServicioPerfil.obtenerIdRol(userId);
                    ViewBag.TieneRol8 = roles != null && roles.Contains(8);
                }
                
                return PartialView("~/Views/Festivales/_GridVersionesPartial.cshtml", datos);
            }
            catch (Exception ex)
            {
                string ruta = Server.MapPath("/Log");
                Log.WriteLog(ruta, ex.ToString());
                ViewBag.TieneRol8 = false;
                return PartialView("~/Views/Festivales/_GridVersionesPartial.cshtml", new List<FestivalVersionListadoItemViewModel>());
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CrearVersion(FestivalVersionCrearViewModel model)
        {
            if (string.IsNullOrWhiteSpace(model.NombreVersion))
            {
                return new HttpStatusCodeResult(400, "El nombre de la versión es obligatorio");
            }
            var nuevo = new FestivalVersionListadoItemViewModel
            {
                Id = (_versionesTemp.Any() ? _versionesTemp.Max(v => v.Id) + 1 : 1),
                NombreVersion = model.NombreVersion.Trim(),
                FechaCreacion = model.FechaCreacion ?? DateTime.Now,
                FechaSolicitud = model.FechaSolicitud,
                Estado = string.IsNullOrWhiteSpace(model.Estado) ? "Incompleto" : model.Estado
            };
            _versionesTemp.Add(nuevo);

            // Devuelve OK; la grilla se recargará por callback desde el cliente
            return Json(new { ok = true });
        }

        public ActionResult VerVersion(int id)
        {
            var item = _versionesTemp.FirstOrDefault(x => x.Id == id);
            if (item == null) return HttpNotFound();
            // En esta versión, mostramos un detalle simple
            return PartialView("~/Views/Festivales/_VersionDetallePartial.cshtml", item);
        }

        public ActionResult EditarVersion(int id)
        {
            var item = _versionesTemp.FirstOrDefault(x => x.Id == id);
            if (item == null) return HttpNotFound();
            // Se puede reutilizar el mismo detalle por ahora
            return PartialView("~/Views/Festivales/_VersionDetallePartial.cshtml", item);
        }

        // GET: Festivales/Reportes
        public ActionResult Reportes([ModelBinder(typeof(DevExpressEditorsBinder))] FestivalReporteFiltroViewModel filtro)
        {
            // Normalizar fechas provenientes del request para evitar problemas de parseo
            NormalizarFechasFiltro(ref filtro);
            // Cargar listas para los dropdowns
            CargarListasReportes();
            // Entregamos la vista con los filtros (vacíos por defecto)
            return View(filtro ?? new FestivalReporteFiltroViewModel());
        }

        private void CargarListasReportes()
        {
            using (var db = new SIPAEntities())
            {
                // Departamentos (ZON_PADRE_ID es null)
                ViewBag.Departamentos = db.BAS_ZONAS_GEOGRAFICAS
                    .Where(z => z.ZON_PADRE_ID == null)
                    .OrderBy(z => z.ZON_NOMBRE)
                    .Select(z => new SelectListItem { Value = z.ZON_ID, Text = z.ZON_NOMBRE })
                    .ToList();

                // Territorios Sonoros
                ViewBag.TerritoriosSonoros = db.ART_MUS_TERRITORIOS_SONOROS
                    .OrderBy(t => t.TERRITORIOS_SONOROS)
                    .Select(t => new SelectListItem { Value = t.ID.ToString(), Text = t.TERRITORIOS_SONOROS })
                    .ToList();

                // Tipologías (solo activos)
                ViewBag.Tipologias = db.ART_MUS_FESTIVALES_TIPOLOGIA
                    .Where(t => t.ACTIVO == 1)
                    .OrderBy(t => t.TIPOLOGIA)
                    .Select(t => new SelectListItem { Value = t.ID.ToString(), Text = t.TIPOLOGIA })
                    .ToList();

                // Expresiones Artísticas (solo activos)
                ViewBag.ExpresionesArtisticas = db.ART_MUS_FESTIVALES_EXPRESIONES_ARTISTICAS
                    .Where(e => e.ACTIVO)
                    .OrderBy(e => e.EXPRESION_ARTISTICA)
                    .Select(e => new SelectListItem { Value = e.ID.ToString(), Text = e.EXPRESION_ARTISTICA })
                    .ToList();

                // Fuentes de Financiación (para principal y secundaria, solo activos)
                ViewBag.FuentesFinanciacion = db.ART_MUS_FESTIVALES_FUENTE_FINANCIACION
                    .Where(f => f.ACTIVO == true)
                    .OrderBy(f => f.FUENTE_FINANCIACION)
                    .Select(f => new SelectListItem { Value = f.ID.ToString(), Text = f.FUENTE_FINANCIACION })
                    .ToList();

                // Tipos de Organizador
                ViewBag.TiposOrganizador = db.ART_MUS_FESTIVALES_TIPO_ORGANIZADOR
                    .OrderBy(t => t.TIPO_ORGANIZADOR)
                    .Select(t => new SelectListItem { Value = t.ID.ToString(), Text = t.TIPO_ORGANIZADOR })
                    .ToList();
            }
        }

        // Partial: grilla de resultados con consulta real
        [ValidateInput(false)]
        [ChildActionOnly]
        public ActionResult GridReportesPartial([ModelBinder(typeof(DevExpressEditorsBinder))] FestivalReporteFiltroViewModel filtro)
        {
            return GridReportesPartialInterno(filtro);
        }

        // Método POST para recarga AJAX del filtro (evita query string demasiado larga)
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult GridReportesPartialAjax([ModelBinder(typeof(DevExpressEditorsBinder))] FestivalReporteFiltroViewModel filtro)
        {
            return GridReportesPartialInterno(filtro);
        }

        // Lógica compartida para ambos métodos
        private ActionResult GridReportesPartialInterno(FestivalReporteFiltroViewModel filtro)
        {
            // Normalizar fechas provenientes del request para evitar problemas de parseo
            NormalizarFechasFiltro(ref filtro);
            // Cargar listas para el caso de callbacks de DevExpress
            CargarListasReportes();
            
            var datos = ObtenerDatosReporte(filtro);

            // Pasar filtros al parcial para usarlos en CallbackRouteValues del Grid
            ViewBag.Filtro = filtro;
            return PartialView("~/Views/Festivales/_GridReportes.cshtml", datos);
        }

        private List<FestivalReporteItemViewModel> ObtenerDatosReporte(FestivalReporteFiltroViewModel filtro)
        {
            using (var db = new SIPAEntities())
            {
                // Consulta base: festivales con sus versiones
                var query = db.ART_MUS_FESTIVALES
                    .Include("ART_MUS_FESTIVALES_VERSION")
                    .Include("ART_MUS_FESTIVALES_VERSION.ART_MUS_FESTIVALES_TIPOLOGIA")
                    .Include("ART_MUS_FESTIVALES_VERSION.ART_MUS_FESTIVALES_TIPO_ORGANIZADOR")
                    .Include("ART_MUS_FESTIVALES_VERSION.ART_MUS_FESTIVALES_FUENTE_FINANCIACION")
                    .Include("ART_MUS_FESTIVALES_VERSION.ART_MUS_FESTIVALES_FUENTE_FINANCIACION1")
                    .Include("ART_MUS_FESTIVALES_VERSION.ART_MUS_LOCALIZACIONXVERSION")
                    .Include("ART_MUS_FESTIVALES_VERSION.ART_MUS_LOCALIZACIONXVERSION.BAS_ZONAS_GEOGRAFICAS")
                    .Include("ART_MUS_FESTIVALES_VERSION.ART_MUS_TERRITORIOS_SONOROSXVERSION")
                    .Include("ART_MUS_FESTIVALES_VERSION.ART_MUS_TERRITORIOS_SONOROSXVERSION.ART_MUS_TERRITORIOS_SONOROS")
                    .Include("ART_MUS_FESTIVALES_VERSION.ART_MUS_FESTIVALES_EXPRESIONXVERSION")
                    .Include("ART_MUS_FESTIVALES_VERSION.ART_MUS_FESTIVALES_EXPRESIONXVERSION.ART_MUS_FESTIVALES_EXPRESIONES_ARTISTICAS")
                    .Include("ART_MUS_FESTIVALES_VERSION.ART_MUS_FESTIVALES_MODALIDADES_PARTICIPACIONXVERSION")
                    .Include("ART_MUS_FESTIVALES_VERSION.ART_MUS_FESTIVALES_MODALIDADES_PARTICIPACIONXVERSION.ART_MUS_FESTIVALES_MODALIDADES_PARTICIPACION")
                    .Include("ART_MUSICA_USUARIO")
                    .AsQueryable();

                // Aplicar filtros
                if (filtro != null)
                {
                    // Filtro por vigencia (fecha última versión >= hoy)
                    if (filtro.Vigente)
                    {
                        var hoy = DateTime.Today;
                        query = query.Where(f => f.FECHA_ULTIMA_VERSION >= hoy);
                    }

                    // Filtro por organización: buscar en versiones o en usuario creador
                    if (!string.IsNullOrWhiteSpace(filtro.Organizacion))
                    {
                        var org = filtro.Organizacion.Trim().ToLower();
                        query = query.Where(f => 
                            f.ART_MUS_FESTIVALES_VERSION.Any(v => v.NOMBRE_ORGANIZACION != null && v.NOMBRE_ORGANIZACION.ToLower().Contains(org)) ||
                            (f.ART_MUSICA_USUARIO != null && (
                                (f.ART_MUSICA_USUARIO.PrimerNombre != null && f.ART_MUSICA_USUARIO.PrimerNombre.ToLower().Contains(org)) ||
                                (f.ART_MUSICA_USUARIO.SegundoNombre != null && f.ART_MUSICA_USUARIO.SegundoNombre.ToLower().Contains(org)) ||
                                (f.ART_MUSICA_USUARIO.PrimerApellido != null && f.ART_MUSICA_USUARIO.PrimerApellido.ToLower().Contains(org)) ||
                                (f.ART_MUSICA_USUARIO.SegundoApellido != null && f.ART_MUSICA_USUARIO.SegundoApellido.ToLower().Contains(org))
                            ))
                        );
                    }

                    // Filtro por nombre del festival (case-insensitive)
                    if (!string.IsNullOrWhiteSpace(filtro.NombreFestival))
                    {
                        var nombre = filtro.NombreFestival.Trim().ToLower();
                        query = query.Where(f => f.NOMBRE_FESTIVAL != null && f.NOMBRE_FESTIVAL.ToLower().Contains(nombre));
                    }

                    // Filtro por fechas
                    if (filtro.FechaInicial.HasValue)
                    {
                        query = query.Where(f => f.FECHA_ULTIMA_VERSION >= filtro.FechaInicial.Value);
                    }

                    if (filtro.FechaFinal.HasValue)
                    {
                        query = query.Where(f => f.FECHA_ULTIMA_VERSION <= filtro.FechaFinal.Value);
                    }
                }

                var festivales = query.ToList();

                // Construir el resultado con todas las versiones
                var resultado = new List<FestivalReporteItemViewModel>();

                foreach (var festival in festivales)
                {
                    var versiones = festival.ART_MUS_FESTIVALES_VERSION.AsQueryable();

                    // Aplicar filtros a nivel de versión
                    if (filtro != null)
                    {
                        // El filtro de Organización ya se aplicó a nivel de festival, aquí solo refinamos si es necesario
                        if (!string.IsNullOrWhiteSpace(filtro.Organizacion))
                        {
                            var org = filtro.Organizacion.Trim().ToLower();
                            versiones = versiones.Where(v => 
                                (v.NOMBRE_ORGANIZACION != null && v.NOMBRE_ORGANIZACION.ToLower().Contains(org)) ||
                                (festival.ART_MUSICA_USUARIO != null && (
                                    (festival.ART_MUSICA_USUARIO.PrimerNombre != null && festival.ART_MUSICA_USUARIO.PrimerNombre.ToLower().Contains(org)) ||
                                    (festival.ART_MUSICA_USUARIO.SegundoNombre != null && festival.ART_MUSICA_USUARIO.SegundoNombre.ToLower().Contains(org)) ||
                                    (festival.ART_MUSICA_USUARIO.PrimerApellido != null && festival.ART_MUSICA_USUARIO.PrimerApellido.ToLower().Contains(org)) ||
                                    (festival.ART_MUSICA_USUARIO.SegundoApellido != null && festival.ART_MUSICA_USUARIO.SegundoApellido.ToLower().Contains(org))
                                ))
                            );
                        }

                        if (!string.IsNullOrWhiteSpace(filtro.NombreVersion))
                        {
                            var nombreVer = filtro.NombreVersion.Trim().ToLower();
                            versiones = versiones.Where(v => v.NOMBRE_VERSION != null && v.NOMBRE_VERSION.ToLower().Contains(nombreVer));
                        }

                        if (!string.IsNullOrWhiteSpace(filtro.Departamento))
                        {
                            var depto = filtro.Departamento;
                            versiones = versiones.Where(v => v.ART_MUS_LOCALIZACIONXVERSION.Any(l => l.ZON_ID == depto));
                        }

                        if (!string.IsNullOrWhiteSpace(filtro.Municipio))
                        {
                            var mun = filtro.Municipio;
                            versiones = versiones.Where(v => v.ART_MUS_LOCALIZACIONXVERSION.Any(l => l.ZON_ID == mun));
                        }

                        if (filtro.TerritorioSonoroId.HasValue)
                        {
                            var tsId = filtro.TerritorioSonoroId.Value;
                            versiones = versiones.Where(v => v.ART_MUS_TERRITORIOS_SONOROSXVERSION.Any(t => t.ID_TERRITORIOS_SONOROS == tsId));
                        }

                        if (filtro.TipologiaId.HasValue)
                        {
                            versiones = versiones.Where(v => v.ID_TIPOLOGIA == filtro.TipologiaId.Value);
                        }

                        if (!string.IsNullOrWhiteSpace(filtro.ModalidadParticipacion))
                        {
                            var mod = filtro.ModalidadParticipacion.Trim().ToLower();
                            versiones = versiones.Where(v => v.ART_MUS_FESTIVALES_MODALIDADES_PARTICIPACIONXVERSION
                                .Any(m => m.ART_MUS_FESTIVALES_MODALIDADES_PARTICIPACION.MODALIDAD_PARTICIPACION != null && 
                                          m.ART_MUS_FESTIVALES_MODALIDADES_PARTICIPACION.MODALIDAD_PARTICIPACION.ToLower().Contains(mod)));
                        }

                        if (filtro.ExpresionesArtisticasId.HasValue)
                        {
                            var expId = filtro.ExpresionesArtisticasId.Value;
                            versiones = versiones.Where(v => v.ART_MUS_FESTIVALES_EXPRESIONXVERSION.Any(e => e.ID_EXPRESION_ARTISTICA == expId));
                        }

                        if (filtro.FuenteFinanciacionPrincipalId.HasValue)
                        {
                            versiones = versiones.Where(v => v.ID_FUENTE_FINANCIACION == filtro.FuenteFinanciacionPrincipalId.Value);
                        }

                        if (filtro.FuenteFinanciacionSecundariaId.HasValue)
                        {
                            versiones = versiones.Where(v => v.ID_FUENTE_FINANCIACION_SECUNDARIA == filtro.FuenteFinanciacionSecundariaId.Value);
                        }

                        if (filtro.TieneFinanciacionSecundaria.HasValue)
                        {
                            if (filtro.TieneFinanciacionSecundaria.Value)
                            {
                                versiones = versiones.Where(v => v.ID_FUENTE_FINANCIACION_SECUNDARIA != null);
                            }
                            else
                            {
                                versiones = versiones.Where(v => v.ID_FUENTE_FINANCIACION_SECUNDARIA == null);
                            }
                        }

                        if (!string.IsNullOrWhiteSpace(filtro.Organizador))
                        {
                            var org = filtro.Organizador.Trim().ToLower();
                            versiones = versiones.Where(v => (v.DIRECTOR != null && v.DIRECTOR.ToLower().Contains(org)) ||
                                                             (v.NOMBRE_ORGANIZACION != null && v.NOMBRE_ORGANIZACION.ToLower().Contains(org)));
                        }

                        if (filtro.TipoOrganizadorId.HasValue)
                        {
                            versiones = versiones.Where(v => v.ID_TIPO_ORGANIZADOR == filtro.TipoOrganizadorId.Value);
                        }
                    }

                    // Mapear cada versión a un item del reporte
                    foreach (var version in versiones.ToList())
                    {
                        var localizacion = version.ART_MUS_LOCALIZACIONXVERSION.FirstOrDefault();
                        var zonaNombre = localizacion?.BAS_ZONAS_GEOGRAFICAS?.ZON_NOMBRE ?? "";
                        
                        // Obtener departamento (padre de la zona)
                        var departamento = "";
                        var municipio = "";
                        if (localizacion != null && localizacion.BAS_ZONAS_GEOGRAFICAS != null)
                        {
                            var zona = localizacion.BAS_ZONAS_GEOGRAFICAS;
                            if (zona.ZON_PADRE_ID == null)
                            {
                                // Es un departamento
                                departamento = zona.ZON_NOMBRE;
                            }
                            else
                            {
                                // Es un municipio
                                municipio = zona.ZON_NOMBRE;
                                var zonaPadre = db.BAS_ZONAS_GEOGRAFICAS.FirstOrDefault(z => z.ZON_ID == zona.ZON_PADRE_ID);
                                departamento = zonaPadre?.ZON_NOMBRE ?? "";
                            }
                        }

                        var territoriosSonoros = string.Join(", ", version.ART_MUS_TERRITORIOS_SONOROSXVERSION
                            .Select(t => t.ART_MUS_TERRITORIOS_SONOROS.TERRITORIOS_SONOROS));

                        var expresionesArtisticas = string.Join(", ", version.ART_MUS_FESTIVALES_EXPRESIONXVERSION
                            .Select(e => e.ART_MUS_FESTIVALES_EXPRESIONES_ARTISTICAS.EXPRESION_ARTISTICA));

                        var modalidades = string.Join(", ", version.ART_MUS_FESTIVALES_MODALIDADES_PARTICIPACIONXVERSION
                            .Select(m => m.ART_MUS_FESTIVALES_MODALIDADES_PARTICIPACION.MODALIDAD_PARTICIPACION));

                        // Construir nombre completo del usuario creador
                        var nombreUsuario = "";
                        if (festival.ART_MUSICA_USUARIO != null)
                        {
                            var u = festival.ART_MUSICA_USUARIO;
                            nombreUsuario = string.Join(" ", new[] { u.PrimerNombre, u.SegundoNombre, u.PrimerApellido, u.SegundoApellido }
                                .Where(n => !string.IsNullOrWhiteSpace(n)));
                        }

                        resultado.Add(new FestivalReporteItemViewModel
                        {
                            FestivalId = festival.id,
                            VersionId = version.ID,
                            // Información del Festival
                            Organizacion = version.NOMBRE_ORGANIZACION ?? nombreUsuario,
                            NombreFestival = festival.NOMBRE_FESTIVAL ?? "",
                            NumeroVersiones = festival.VERSIONES_REALIZADAS ?? 0,
                            FechaUltimaVersion = festival.FECHA_ULTIMA_VERSION,
                            DescripcionFestival = festival.DESCRIPCION_FESTIVAL ?? "",
                            CorreoContacto = festival.CORREO_CONTACTO ?? "",
                            Instagram = festival.INSTAGRAM ?? "",
                            Facebook = festival.FACEBOOK ?? "",
                            PaginaWeb = festival.PAGINA_WEB ?? "",
                            OtroEnlace = festival.OTRO_ENLACE ?? "",
                            TelefonoCelular = festival.CELULAR ?? "",
                            Observacion = festival.OBSERVACIONES_CONTACTO ?? "",
                            
                            // Información de la Versión
                            VersionNumero = version.VERSION_FESTIVAL ?? 0,
                            NombreVersion = version.NOMBRE_VERSION ?? "",
                            DescripcionVersion = version.DESCRIPCION_VERSION ?? "",
                            PracticasMusicales = version.PRACTICAS_MUSICALES_CONGREGA ?? "",
                            FechaInicio = version.FECHA_INICIO ?? "",
                            FechaFin = version.FECHA_FIN ?? "",
                            Departamento = departamento,
                            Municipio = municipio,
                            TerritoriosSonoros = territoriosSonoros,
                            Tipologia = version.ART_MUS_FESTIVALES_TIPOLOGIA?.TIPOLOGIA ?? "",
                            ModalidadesParticipacion = modalidades,
                            ExpresionesArtisticas = expresionesArtisticas,
                            FuenteFinanciacionPrincipal = version.ART_MUS_FESTIVALES_FUENTE_FINANCIACION?.FUENTE_FINANCIACION ?? "",
                            FuenteFinanciacionSecundaria = version.ART_MUS_FESTIVALES_FUENTE_FINANCIACION1?.FUENTE_FINANCIACION ?? "",
                            Director = version.DIRECTOR ?? "",
                            NombreOrganizacionColectiva = version.NOMBRE_ORGANIZACION ?? "",
                            TipoOrganizador = version.ART_MUS_FESTIVALES_TIPO_ORGANIZADOR?.TIPO_ORGANIZADOR ?? "",
                            CorreoVersion = version.CORREO_CONTACTO ?? "",
                            InstagramVersion = version.INSTAGRAM ?? "",
                            FacebookVersion = version.FACEBOOK ?? "",
                            PaginaWebVersion = version.PAGINA_WEB ?? "",
                            OtroEnlaceVersion = version.OTRO_ENLACE ?? "",
                            TelefonoCelularVersion = version.TELEFONO_CELULAR ?? "",
                            ObservacionesVersion = version.OBSERVACIONES_CONTACTO ?? ""
                        });
                    }
                }

                return resultado;
            }
        }

        // POST: Festivales/DescargarReporte - Genera archivo Excel
        [HttpPost]
        public ActionResult DescargarReporte([ModelBinder(typeof(DevExpressEditorsBinder))] FestivalReporteFiltroViewModel filtro, bool? detallado)
        {
            // Normalizar fechas provenientes del request para evitar problemas de parseo
            NormalizarFechasFiltro(ref filtro);
            var datos = ObtenerDatosReporte(filtro);
            
            // Crear DataTable principal (general) para usar con la clase Excel existente / detallada
            var dataTable = new System.Data.DataTable();
            
            // Definir columnas
            dataTable.Columns.Add("Organización", typeof(string));
            dataTable.Columns.Add("Nombre del Festival", typeof(string));
            dataTable.Columns.Add("Número de Versiones", typeof(int));
            dataTable.Columns.Add("Fecha Última Versión", typeof(string));
            dataTable.Columns.Add("Descripción del Festival", typeof(string));
            dataTable.Columns.Add("Correo de Contacto", typeof(string));
            dataTable.Columns.Add("Instagram", typeof(string));
            dataTable.Columns.Add("Facebook", typeof(string));
            dataTable.Columns.Add("Página Web", typeof(string));
            dataTable.Columns.Add("Otro Enlace", typeof(string));
            dataTable.Columns.Add("Teléfono/Celular", typeof(string));
            dataTable.Columns.Add("Observaciones", typeof(string));
            dataTable.Columns.Add("Número de Versión", typeof(int));
            dataTable.Columns.Add("Nombre de la Versión", typeof(string));
            dataTable.Columns.Add("Descripción de la Versión", typeof(string));
            dataTable.Columns.Add("Prácticas Musicales", typeof(string));
            dataTable.Columns.Add("Fecha Inicio", typeof(string));
            dataTable.Columns.Add("Fecha Fin", typeof(string));
            dataTable.Columns.Add("Departamento", typeof(string));
            dataTable.Columns.Add("Municipio", typeof(string));
            dataTable.Columns.Add("Territorios Sonoros", typeof(string));
            dataTable.Columns.Add("Tipología", typeof(string));
            dataTable.Columns.Add("Modalidades de Participación", typeof(string));
            dataTable.Columns.Add("Expresiones Artísticas", typeof(string));
            dataTable.Columns.Add("Fuente de Financiación Principal", typeof(string));
            dataTable.Columns.Add("Fuente de Financiación Secundaria", typeof(string));
            dataTable.Columns.Add("Director", typeof(string));
            dataTable.Columns.Add("Nombre Organización Colectiva", typeof(string));
            dataTable.Columns.Add("Tipo de Organizador", typeof(string));
            dataTable.Columns.Add("Correo Versión", typeof(string));
            dataTable.Columns.Add("Instagram Versión", typeof(string));
            dataTable.Columns.Add("Facebook Versión", typeof(string));
            dataTable.Columns.Add("Página Web Versión", typeof(string));
            dataTable.Columns.Add("Otro Enlace Versión", typeof(string));
            dataTable.Columns.Add("Teléfono Versión", typeof(string));
            dataTable.Columns.Add("Observaciones Versión", typeof(string));
            
            // Llenar datos
            foreach (var item in datos)
            {
                var row = dataTable.NewRow();
                row["Organización"] = item.Organizacion ?? "";
                row["Nombre del Festival"] = item.NombreFestival ?? "";
                row["Número de Versiones"] = item.NumeroVersiones;
                row["Fecha Última Versión"] = item.FechaUltimaVersion?.ToString("dd/MM/yyyy") ?? "";
                row["Descripción del Festival"] = item.DescripcionFestival ?? "";
                row["Correo de Contacto"] = item.CorreoContacto ?? "";
                row["Instagram"] = item.Instagram ?? "";
                row["Facebook"] = item.Facebook ?? "";
                row["Página Web"] = item.PaginaWeb ?? "";
                row["Otro Enlace"] = item.OtroEnlace ?? "";
                row["Teléfono/Celular"] = item.TelefonoCelular ?? "";
                row["Observaciones"] = item.Observacion ?? "";
                row["Número de Versión"] = item.VersionNumero;
                row["Nombre de la Versión"] = item.NombreVersion ?? "";
                row["Descripción de la Versión"] = item.DescripcionVersion ?? "";
                row["Prácticas Musicales"] = item.PracticasMusicales ?? "";
                row["Fecha Inicio"] = item.FechaInicio ?? "";
                row["Fecha Fin"] = item.FechaFin ?? "";
                row["Departamento"] = item.Departamento ?? "";
                row["Municipio"] = item.Municipio ?? "";
                row["Territorios Sonoros"] = item.TerritoriosSonoros ?? "";
                row["Tipología"] = item.Tipologia ?? "";
                row["Modalidades de Participación"] = item.ModalidadesParticipacion ?? "";
                row["Expresiones Artísticas"] = item.ExpresionesArtisticas ?? "";
                row["Fuente de Financiación Principal"] = item.FuenteFinanciacionPrincipal ?? "";
                row["Fuente de Financiación Secundaria"] = item.FuenteFinanciacionSecundaria ?? "";
                row["Director"] = item.Director ?? "";
                row["Nombre Organización Colectiva"] = item.NombreOrganizacionColectiva ?? "";
                row["Tipo de Organizador"] = item.TipoOrganizador ?? "";
                row["Correo Versión"] = item.CorreoVersion ?? "";
                row["Instagram Versión"] = item.InstagramVersion ?? "";
                row["Facebook Versión"] = item.FacebookVersion ?? "";
                row["Página Web Versión"] = item.PaginaWebVersion ?? "";
                row["Otro Enlace Versión"] = item.OtroEnlaceVersion ?? "";
                row["Teléfono Versión"] = item.TelefonoCelularVersion ?? "";
                row["Observaciones Versión"] = item.ObservacionesVersion ?? "";
                
                dataTable.Rows.Add(row);
            }
            
            // Usar la clase Excel existente
            string nombreArchivo;
            System.IO.MemoryStream stream;
            string titulo = string.Format("Reporte Festivales - {0:dd/MM/yyyy HH:mm}", DateTime.Now);

            if (detallado.HasValue && detallado.Value)
            {
                // Armar DataTable de Entidades Aliadas (detalle por festival + versión + entidad)
                var entidadesDt = new System.Data.DataTable();
                entidadesDt.Columns.Add("Festival", typeof(string));
                entidadesDt.Columns.Add("Número Versión", typeof(int));
                entidadesDt.Columns.Add("Nombre Versión", typeof(string));
                entidadesDt.Columns.Add("Entidad Aliada", typeof(string));
                entidadesDt.Columns.Add("Naturaleza", typeof(string));
                entidadesDt.Columns.Add("Correo", typeof(string));

                using (var db = new SIPAEntities())
                {
                    // Consultar entidades aliadas por festival (si tabla existe)
                    foreach (var item in datos)
                    {
                        try
                        {
                            // Identificar festival por nombre (podría mejorarse usando ID si se expone)
                            // Usar VersionId para localizar entidades aliadas de esa versión (más preciso)
                            var entidadesAliadas = db.ART_MUS_FESTIVALES_ENTIDADES_ALIADAS.Where(e => e.ID_FESTIVAL == item.VersionId).ToList();
                            if (entidadesAliadas.Any())
                            {
                                foreach (var ent in entidadesAliadas)
                                {
                                    var r = entidadesDt.NewRow();
                                    r["Festival"] = item.NombreFestival;
                                    r["Número Versión"] = item.VersionNumero;
                                    r["Nombre Versión"] = item.NombreVersion;
                                    r["Entidad Aliada"] = ent.NOMBRE_ENTIDAD_ALIADA ?? "";
                                    r["Naturaleza"] = ent.ID_NATURALEZA?.ToString() ?? "";
                                    r["Correo"] = ent.CORREO_ENTIDAD ?? "";
                                    entidadesDt.Rows.Add(r);
                                }
                            }
                        }
                        catch { /* Silenciar errores por robustez */ }
                    }
                }

                stream = WebSImus.Comunes.Excel.CrearReporteFestivalesDetallado(titulo, dataTable, entidadesDt, out nombreArchivo);
            }
            else
            {
                stream = WebSImus.Comunes.Excel.CrearReporteGeneral(titulo, "", dataTable, out nombreArchivo);
            }
            
            const string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            stream.Position = 0;
            
            // Cambiar el nombre del archivo según el formato solicitado
            nombreArchivo = string.Format("Reporte_Festivales_{0:dd_MM_yyyy}.xlsx", DateTime.Now);
            
            return File(stream, contentType, nombreArchivo);
        }

        /// <summary>
        /// Normaliza las fechas (FechaInicial/FechaFinal) provenientes del request
        /// usando cultura es-CO y formatos esperados dd/MM/yyyy para evitar errores de binding.
        /// </summary>
        /// <param name="filtro">Filtro a corregir</param>
        private void NormalizarFechasFiltro(ref FestivalReporteFiltroViewModel filtro)
        {
            if (filtro == null) filtro = new FestivalReporteFiltroViewModel();

            try
            {
                var ci = new CultureInfo("es-CO");
                var formatos = new[] { "dd/MM/yyyy", "d/M/yyyy", "dd/M/yyyy", "d/MM/yyyy" };

                // Intentar leer directamente del Request para cubrir casos donde el binder no convierta
                string fi = Request?["FechaInicial"]; // nombre coincide con input name
                string ff = Request?["FechaFinal"];   // nombre coincide con input name

                DateTime dt;
                if (!string.IsNullOrWhiteSpace(fi) && DateTime.TryParseExact(fi.Trim(), formatos, ci, DateTimeStyles.None, out dt))
                {
                    filtro.FechaInicial = dt;
                }
                // Si está vacío o no parsea, mantener valor actual o null

                if (!string.IsNullOrWhiteSpace(ff) && DateTime.TryParseExact(ff.Trim(), formatos, ci, DateTimeStyles.None, out dt))
                {
                    filtro.FechaFinal = dt;
                }
            }
            catch
            {
                // No interrumpir el flujo por errores de parseo; se mantienen valores existentes
            }
        }

        // ========== VERSIONES DE FESTIVALES (REGISTRO COMPLETO) ==========

        // Datos simulados de versiones registradas por el usuario
        private static List<FestivalVersionListadoViewModel> _versionesRegistradas = new List<FestivalVersionListadoViewModel>
        {
            new FestivalVersionListadoViewModel{ Id=1, NombreFestival="Festival Vallenato", NombreVersion="Versión 55", FechaCreacion=new DateTime(2025,1,15), FechaSolicitud=new DateTime(2025,1,20), Estado="Incompleto"},
            new FestivalVersionListadoViewModel{ Id=2, NombreFestival="Festival Vallenato", NombreVersion="Versión 54", FechaCreacion=new DateTime(2024,1,10), FechaSolicitud=new DateTime(2024,1,15), FechaSolicitudAclaraciones=new DateTime(2024,2,10), Estado="Solicitud de Aclaraciones"},
            new FestivalVersionListadoViewModel{ Id=3, NombreFestival="Rock al Parque", NombreVersion="Versión 26", FechaCreacion=new DateTime(2024,5,20), FechaSolicitud=new DateTime(2024,5,25), Estado="Registrado"},
            new FestivalVersionListadoViewModel{ Id=4, NombreFestival="Rock al Parque", NombreVersion="Versión 25", FechaCreacion=new DateTime(2023,5,15), FechaSolicitud=new DateTime(2023,5,20), Estado="Publicado"},
            new FestivalVersionListadoViewModel{ Id=5, NombreFestival="Jazz al Parque", NombreVersion="Versión 21", FechaCreacion=new DateTime(2023,8,10), FechaSolicitud=new DateTime(2023,8,15), Estado="Rechazado"},
        };

        // GET: Festivales/ListadoVersiones - Pantalla principal del módulo de versiones
        public ActionResult ListadoVersiones(string filtroTexto = null, int pagina = 1, int tamPagina = 10)
        {
            var query = _versionesRegistradas.AsQueryable();

            if (!string.IsNullOrWhiteSpace(filtroTexto))
            {
                var f = filtroTexto.Trim();
                query = query.Where(v => v.NombreFestival.IndexOf(f, StringComparison.OrdinalIgnoreCase) >= 0
                                      || v.NombreVersion.IndexOf(f, StringComparison.OrdinalIgnoreCase) >= 0
                                      || (v.Estado ?? "").IndexOf(f, StringComparison.OrdinalIgnoreCase) >= 0);
            }

            var total = query.Count();
            var totalPaginas = (int)Math.Ceiling(total / (double)tamPagina);
            if (pagina < 1) pagina = 1;
            if (pagina > totalPaginas && totalPaginas > 0) pagina = totalPaginas;

            var lista = query
                .OrderByDescending(v => v.FechaCreacion)
                .Skip((pagina - 1) * tamPagina)
                .Take(tamPagina)
                .ToList();

            var vm = new VersionesListadoPaginaViewModel
            {
                FiltroTexto = filtroTexto,
                Versiones = lista,
                PaginaActual = pagina,
                TotalPaginas = totalPaginas
            };

            return View(vm);
        }

        // Partial: Grilla de versiones registradas
        [ValidateInput(false)]
        public ActionResult GridVersionesListadoPartial(string filtroTexto = null)
        {
            var query = _versionesRegistradas.AsEnumerable();

            if (!string.IsNullOrWhiteSpace(filtroTexto))
            {
                var f = filtroTexto.Trim();
                query = query.Where(v => v.NombreFestival.IndexOf(f, StringComparison.OrdinalIgnoreCase) >= 0
                                      || v.NombreVersion.IndexOf(f, StringComparison.OrdinalIgnoreCase) >= 0
                                      || (v.Estado ?? "").IndexOf(f, StringComparison.OrdinalIgnoreCase) >= 0);
            }

            ViewBag.FiltroTexto = filtroTexto;
            return PartialView("~/Views/Festivales/_GridVersionesListadoPartial.cshtml", query.ToList());
        }

        // GET: Festivales/RegistrarVersion - Formulario de registro de versión (acordeón)
        public ActionResult RegistrarVersion(int? id, int? festivalId)
        {
            try
            {
                var vm = new FestivalVersionRegistroViewModel();
                SM.Datos.DTO.Festivales.FestivalVersionDTO versionDTO = null;

                if (id.HasValue)
                {
                    // Cargar datos de la versión a editar
                    versionDTO = SM.Datos.Festivales.FestivalVersionServicio.ObtenerPorId(id.Value);
                    if (versionDTO == null)
                    {
                        return HttpNotFound();
                    }

                    // Mapear DTO a ViewModel
                    vm.Id = versionDTO.Id;
                    vm.FestivalId = versionDTO.IdFestival;
                    vm.VersionNumero = versionDTO.NumeroVersion;
                    vm.NombreVersion = versionDTO.NombreVersion;
                    vm.Descripcion = versionDTO.Descripcion;
                    vm.PracticasMusicalesTS = versionDTO.PracticasMusicales;
                    vm.FechaInicio = versionDTO.FechaInicio;
                    vm.FechaFin = versionDTO.FechaFin;

                    // Calcular mes y duración si hay fechas
                    if (versionDTO.FechaInicio.HasValue)
                    {
                        vm.MesRealizacion = versionDTO.FechaInicio.Value.Month;
                    }
                    if (versionDTO.FechaInicio.HasValue && versionDTO.FechaFin.HasValue)
                    {
                        vm.DuracionDias = (int)(versionDTO.FechaFin.Value - versionDTO.FechaInicio.Value).TotalDays + 1;
                    }

                    // Mapear material multimedia
                    if (versionDTO.MaterialMultimedia != null)
                    {
                        foreach (var material in versionDTO.MaterialMultimedia)
                        {
                            switch (material.Descripcion?.ToLower())
                            {
                                case "programa":
                                    vm.UrlPrograma = material.UrlArchivo;
                                    break;
                                case "afiche":
                                    vm.UrlAfiche = material.UrlArchivo;
                                    break;
                                case "logo":
                                    vm.UrlLogo = material.UrlArchivo;
                                    break;
                            }
                        }
                    }

                    vm.EsEdicion = true;
                }
                else if (festivalId.HasValue)
                {
                    // Nueva versión para un festival específico
                    vm.FestivalId = festivalId.Value;
                }

                // Cargar catálogo: Tipos de ingreso
                var catalogoTiposIngreso = SM.Datos.Festivales.FestivalVersionServicio.ObtenerTiposIngreso() ?? new List<SM.Datos.DTO.Festivales.TipoIngresoDTO>();
                ViewBag.TiposIngreso = catalogoTiposIngreso;

                var idsTiposIngresoSeleccionados = new HashSet<int>();
                if (versionDTO != null && versionDTO.TiposIngreso != null)
                {
                    idsTiposIngresoSeleccionados = new HashSet<int>(versionDTO.TiposIngreso.Select(t => t.Id));
                }

                vm.TiposIngreso = catalogoTiposIngreso
                    .Select(t => new WebSImus.Models.TipoIngresoSeleccionItem
                    {
                        Id = t.Id,
                        Nombre = t.Nombre,
                        Selected = idsTiposIngresoSeleccionados.Contains(t.Id)
                    })
                    .ToList();

                // Cargar catálogo: Tipologías
                ViewBag.Tipologias = SM.Datos.Festivales.FestivalVersionServicio.ObtenerTipologias();

                // Cargar catálogo: Fuentes de Financiación
                try
                {
                    ViewBag.FuentesFinanciacion = SM.Datos.Servicios.FestivalServicio.ObtenerFuentesFinanciacion() ?? new List<SM.Datos.DTO.Festivales.FuenteFinanciacionDTO>();
                }
                catch
                {
                    ViewBag.FuentesFinanciacion = new List<SM.Datos.DTO.Festivales.FuenteFinanciacionDTO>();
                }

                // Cargar Territorios Sonoros desde BD
                var territorios = SM.Datos.Festivales.FestivalVersionServicio.ObtenerTerritoriosSonoros() ?? new List<SM.Datos.DTO.Festivales.TerritorioSonoroDTO>();
                var idsSeleccionadosTS = new HashSet<int>();
                
                var idVersionConsulta = vm.Id > 0 ? vm.Id : (id ?? 0);
                if (idVersionConsulta > 0)
                {
                    idsSeleccionadosTS = new HashSet<int>(
                        SM.Datos.Festivales.FestivalVersionServicio.ObtenerTerritoriosSonorosPorVersion(idVersionConsulta)
                    );
                }

                vm.TerritoriosSonoros = territorios.Select(t => new TerritorioSonoroSeleccionItem
                {
                    Id = t.Id,
                    Nombre = t.Nombre,
                    Selected = idsSeleccionadosTS.Contains(t.Id),
                    EsNinguna = (t.Nombre ?? "").Trim().Equals("Ninguna", StringComparison.OrdinalIgnoreCase)
                                || (t.Nombre ?? "").IndexOf("N/A", StringComparison.OrdinalIgnoreCase) >= 0
                }).ToList();

                // Prellenar la lista de IDs seleccionados para los checkboxes
                vm.TerritoriosSeleccionados = vm.TerritoriosSonoros.Where(x => x.Selected).Select(x => x.Id).ToList();

                // Cargar Modalidades de Participación
                var modalidades = SM.Datos.Festivales.FestivalVersionServicio.ObtenerModalidadesParticipacion() ?? new List<SM.Datos.DTO.Festivales.ModalidadParticipacionDTO>();
                var idsModalidadesSeleccionadas = new HashSet<int>();
                
                if (idVersionConsulta > 0)
                {
                    idsModalidadesSeleccionadas = new HashSet<int>(
                        SM.Datos.Festivales.FestivalVersionServicio.ObtenerModalidadesParticipacionPorVersion(idVersionConsulta)
                    );
                }

                vm.ModalidadesParticipacion = modalidades.Select(m => new ModalidadParticipacionSeleccionItem
                {
                    Id = m.Id,
                    Nombre = m.Nombre,
                    Selected = idsModalidadesSeleccionadas.Contains(m.Id)
                }).ToList();
                
                vm.ModalidadesSeleccionadas = vm.ModalidadesParticipacion.Where(x => x.Selected).Select(x => x.Id).ToList();

                // Cargar Expresiones Artísticas
                var expresiones = SM.Datos.Festivales.FestivalVersionServicio.ObtenerExpresionesArtisticas() ?? new List<SM.Datos.DTO.Festivales.ExpresionArtisticaDTO>();
                var idsExpresionesSeleccionadas = new HashSet<int>();
                
                if (idVersionConsulta > 0)
                {
                    idsExpresionesSeleccionadas = new HashSet<int>(
                        SM.Datos.Festivales.FestivalVersionServicio.ObtenerExpresionesArtisticasPorVersion(idVersionConsulta)
                    );
                }

                vm.ExpresionesArtisticas = expresiones.Select(e => new ExpresionArtisticaSeleccionItem
                {
                    Id = e.Id,
                    Nombre = e.Nombre,
                    Selected = idsExpresionesSeleccionadas.Contains(e.Id)
                }).ToList();
                
                vm.ExpresionesSeleccionadas = vm.ExpresionesArtisticas.Where(x => x.Selected).Select(x => x.Id).ToList();

                // Cargar datos de caracterización si es edición
                if (versionDTO != null)
                {
                    vm.IdTipologia = versionDTO.IdTipologia;
                    vm.OtraTipologia = versionDTO.OtraTipologia;
                    vm.OtraModalidadParticipacion = versionDTO.OtraModalidadParticipacion;
                    vm.OtraExpresionArtistica = versionDTO.OtraExpresionArtistica;

                    // Cargar datos de financiación
                    vm.FuenteFinanciacionPrincipal = versionDTO.IdFuenteFinanciacion;
                    vm.FuenteFinanciacionSecundaria = versionDTO.IdFuenteFinanciacionSecundaria;
                    vm.OtraFuenteFinanciacionPrimaria = versionDTO.OtraFuenteFinanciacionPrimaria;
                    vm.OtraFuenteFinanciacionSecundaria = versionDTO.OtraFuenteFinanciacionSecundaria;
                    vm.UsaEstampillaProcultura = versionDTO.UsoEstampillaProcultura;

                    // Cargar datos de contacto
                    vm.Directoria = versionDTO.Director;
                    vm.PerteneceOrganizacion = versionDTO.PerteneceOrgColectiva;
                    vm.NombreOrganizacion = versionDTO.NombreOrganizacion;
                    vm.TipoOrganizador = versionDTO.IdTipoOrganizador?.ToString();
                    vm.OtroTipoOrganizador = versionDTO.OtroTipoOrganizador;
                    vm.CorreoContacto = versionDTO.CorreoContacto;
                    vm.Instagram = versionDTO.Instagram;
                    vm.Facebook = versionDTO.Facebook;
                    vm.PaginaWeb = versionDTO.PaginaWeb;
                    vm.OtroEnlace = versionDTO.OtroEnlace;
                    vm.TelefonoCelular = versionDTO.TelefonoCelular;
                    vm.ObservacionesContacto = versionDTO.ObservacionesContacto;

                    // Cargar entidades aliadas existentes
                    try
                    {
                        using (var contexto = new SM.SIPA.SIPAEntities())
                        {
                            var entidadesExistentes = contexto.ART_MUS_FESTIVALES_ENTIDADES_ALIADAS
                                .Where(e => e.ID_FESTIVAL == versionDTO.Id)
                                .ToList();

                            if (entidadesExistentes.Any())
                            {
                                vm.TieneEntidadesAliadas = true;
                                vm.EntidadesAliadas = entidadesExistentes.Select(e => new EntidadAliadaItem
                                {
                                    Id = e.ID,
                                    Nombre = e.NOMBRE_ENTIDAD_ALIADA,
                                    Naturaleza = e.ID_NATURALEZA?.ToString(),
                                    CorreoElectronico = e.CORREO_ENTIDAD
                                }).ToList();
                            }
                        }
                    }
                    catch (Exception exEntidades)
                    {
                        string rutaEntidades = Server.MapPath("/Log");
                        Log.WriteLog(rutaEntidades, $"Error cargando Entidades Aliadas: {exEntidades}");
                    }
                }

                return View(vm);
            }
            catch (Exception ex)
            {
                string ruta = Server.MapPath("/Log");
                Log.WriteLog(ruta, ex.ToString());
                return RedirectToAction("ListadoVersiones");
            }
        }

        // POST: Festivales/RegistrarVersion
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegistrarVersion(FestivalVersionRegistroViewModel model, string accion)
        {
            // accion: Guardar | Siguiente | Anterior | Cancelar | EnviarSolicitud
            if (string.Equals(accion, "Cancelar", StringComparison.OrdinalIgnoreCase))
            {
                if (model.FestivalId.HasValue && model.FestivalId.Value > 0)
                {
                    return RedirectToAction("Crear", new { id = model.FestivalId });
                }
                return RedirectToAction("Listado");
            }

            // Validación completa para Enviar Solicitud de Registro
            bool esEnviarSolicitud = string.Equals(accion, "EnviarSolicitud", StringComparison.OrdinalIgnoreCase);
            
            if (esEnviarSolicitud)
            {
                var camposFaltantes = new List<string>();

                // SECCIÓN: GENERALIDADES
                if (!model.VersionNumero.HasValue || model.VersionNumero.Value < 1)
                {
                    camposFaltantes.Add("Versi&oacute;n del festival");
                }

                if (string.IsNullOrWhiteSpace(model.NombreVersion))
                {
                    camposFaltantes.Add("Nombre de la versi&oacute;n");
                }

                if (string.IsNullOrWhiteSpace(model.Descripcion))
                {
                    camposFaltantes.Add("Descripci&oacute;n");
                }

                // Validación del afiche deshabilitada temporalmente
                // if (string.IsNullOrWhiteSpace(model.UrlAfiche))
                // {
                //     camposFaltantes.Add("Afiche (debe subir un archivo)");
                // }

                if (!model.MesRealizacion.HasValue || model.MesRealizacion.Value < 1 || model.MesRealizacion.Value > 12)
                {
                    camposFaltantes.Add("Mes de realizaci&oacute;n");
                }

                if (!model.DuracionDias.HasValue || model.DuracionDias.Value < 1)
                {
                    camposFaltantes.Add("Duraci&oacute;n del evento en d&iacute;as");
                }

                // SECCIÓN: CARACTERIZACIÓN
                if (!model.IdTipologia.HasValue || model.IdTipologia.Value < 1)
                {
                    camposFaltantes.Add("Tipolog&iacute;a");
                }

                var modalidadesSeleccionadas = (model.ModalidadesParticipacion ?? new List<WebSImus.Models.ModalidadParticipacionSeleccionItem>())
                    .Where(x => x.Selected)
                    .Count();
                if (modalidadesSeleccionadas == 0)
                {
                    camposFaltantes.Add("Modalidad de participaci&oacute;n (debe seleccionar al menos una)");
                }

                var expresionesSeleccionadas = (model.ExpresionesArtisticas ?? new List<WebSImus.Models.ExpresionArtisticaSeleccionItem>())
                    .Where(x => x.Selected)
                    .Count();
                if (expresionesSeleccionadas == 0)
                {
                    camposFaltantes.Add("Expresiones art&iacute;sticas (debe seleccionar al menos una)");
                }

                // SECCIÓN: FINANCIACIÓN
                if (!model.FuenteFinanciacionPrincipal.HasValue || model.FuenteFinanciacionPrincipal.Value < 1)
                {
                    camposFaltantes.Add("Principal fuente de financiaci&oacute;n");
                }

                if (!model.FuenteFinanciacionSecundaria.HasValue || model.FuenteFinanciacionSecundaria.Value < 1)
                {
                    camposFaltantes.Add("Fuente de financiaci&oacute;n secundaria");
                }

                if (!model.UsaEstampillaProcultura.HasValue)
                {
                    camposFaltantes.Add("Uso de estampilla Procultura");
                }

                // SECCIÓN: CONTACTO
                if (string.IsNullOrWhiteSpace(model.Directoria))
                {
                    camposFaltantes.Add("Directoria");
                }

                if (string.IsNullOrWhiteSpace(model.TipoOrganizador))
                {
                    camposFaltantes.Add("Tipo de organizador");
                }

                if (string.IsNullOrWhiteSpace(model.CorreoContacto))
                {
                    camposFaltantes.Add("Correo electr&oacute;nico de contacto");
                }
                else
                {
                    // Validar formato de correo
                    var emailRegex = new System.Text.RegularExpressions.Regex(@"^[^\s@]+@[^\s@]+\.[^\s@]+$");
                    if (!emailRegex.IsMatch(model.CorreoContacto.Trim()))
                    {
                        camposFaltantes.Add("Correo electr&oacute;nico de contacto (formato inv&aacute;lido)");
                    }
                }

                // Si hay campos faltantes, mostrar error y no continuar
                if (camposFaltantes.Any())
                {
                    var mensaje = new StringBuilder();
                    mensaje.Append("<strong>Por favor complete los siguientes campos obligatorios:</strong><ul style='margin-top:10px;'>");
                    foreach (var campo in camposFaltantes)
                    {
                        mensaje.AppendFormat("<li>{0}</li>", campo);
                    }
                    mensaje.Append("</ul>");

                    ModelState.AddModelError("", mensaje.ToString());

                    // Recargar catálogos y retornar vista
                    CargarCatalogosRegistroVersion(model);
                    return View(model);
                }

                // Si la validación es exitosa, cambiar acción a Guardar para procesar
                accion = "Guardar";
            }

            // Validaciones básicas para avanzar
            if (string.Equals(accion, "Siguiente", StringComparison.OrdinalIgnoreCase))
            {
                if (string.IsNullOrWhiteSpace(model.NombreVersion))
                {
                    ModelState.AddModelError("", "El nombre de la versión es obligatorio.");
                }

                if (ModelState.IsValid)
                {
                    // Avanzar a la siguiente sección del acordeón
                    switch (model.SeccionActiva)
                    {
                        case "generalidades":
                            model.SeccionActiva = "territorioSonoro";
                            break;
                        // Agregar más secciones según se definan
                    }
                }
            }

            // Guardar: permite guardar incompleto (o guardar validado tras EnviarSolicitud)
            if (string.Equals(accion, "Guardar", StringComparison.OrdinalIgnoreCase))
            {
                try
                {
                    // Obtener información del usuario autenticado
                    int usuarioId = string.IsNullOrEmpty(UsuaroId) ? 0 : Convert.ToInt32(UsuaroId);
                    string nombreUsuario = Usuario ?? "Sistema";
                    string ipUsuario = Request.UserHostAddress ?? "0.0.0.0";

                    // Preparar lista de tipos de ingreso seleccionados (desde la lista dinámica del formulario)
                    var tiposIngresoSeleccionados = (model.TiposIngreso ?? new List<WebSImus.Models.TipoIngresoSeleccionItem>())
                        .Where(x => x.Selected)
                        .Select(x => x.Id)
                        .Distinct()
                        .ToList();

                    // Preparar lista de modalidades de participación seleccionadas
                    var modalidadesSeleccionadas = (model.ModalidadesParticipacion ?? new List<WebSImus.Models.ModalidadParticipacionSeleccionItem>())
                        .Where(x => x.Selected)
                        .Select(x => x.Id)
                        .Distinct()
                        .ToList();

                    // Preparar lista de expresiones artísticas seleccionadas
                    var expresionesSeleccionadas = (model.ExpresionesArtisticas ?? new List<WebSImus.Models.ExpresionArtisticaSeleccionItem>())
                        .Where(x => x.Selected)
                        .Select(x => x.Id)
                        .Distinct()
                        .ToList();

                    // Preparar lista de material multimedia
                    var materialMultimedia = new List<SM.Datos.DTO.Festivales.MaterialMultimediaCrearDTO>();
                    
                    // Procesar archivos subidos
                    string rutaPrograma = null;
                    string rutaAfiche = null;
                    string rutaLogo = null;

                    // Guardar archivos si fueron subidos (usamos ID temporal 0 si es creación, se actualizará después)
                    int festivalIdParaArchivo = model.FestivalId ?? 0;
                    int versionIdParaArchivo = model.Id; // 0 si es creación

                    if (model.ArchivoPrograma != null && model.ArchivoPrograma.ContentLength > 0)
                    {
                        rutaPrograma = GuardarArchivoMultimedia(model.ArchivoPrograma, festivalIdParaArchivo, versionIdParaArchivo, "Programa");
                    }
                    else if (!string.IsNullOrWhiteSpace(model.UrlPrograma))
                    {
                        // Mantener URL existente si no se subió nuevo archivo
                        rutaPrograma = model.UrlPrograma;
                    }

                    if (model.ArchivoAfiche != null && model.ArchivoAfiche.ContentLength > 0)
                    {
                        rutaAfiche = GuardarArchivoMultimedia(model.ArchivoAfiche, festivalIdParaArchivo, versionIdParaArchivo, "Afiche");
                    }
                    else if (!string.IsNullOrWhiteSpace(model.UrlAfiche))
                    {
                        rutaAfiche = model.UrlAfiche;
                    }

                    if (model.ArchivoLogo != null && model.ArchivoLogo.ContentLength > 0)
                    {
                        rutaLogo = GuardarArchivoMultimedia(model.ArchivoLogo, festivalIdParaArchivo, versionIdParaArchivo, "Logo");
                    }
                    else if (!string.IsNullOrWhiteSpace(model.UrlLogo))
                    {
                        rutaLogo = model.UrlLogo;
                    }

                    // Agregar material multimedia a la lista con las rutas guardadas
                    if (!string.IsNullOrWhiteSpace(rutaPrograma))
                    {
                        materialMultimedia.Add(new SM.Datos.DTO.Festivales.MaterialMultimediaCrearDTO
                        {
                            UrlArchivo = rutaPrograma,
                            Descripcion = "Programa"
                        });
                    }

                    if (!string.IsNullOrWhiteSpace(rutaAfiche))
                    {
                        materialMultimedia.Add(new SM.Datos.DTO.Festivales.MaterialMultimediaCrearDTO
                        {
                            UrlArchivo = rutaAfiche,
                            Descripcion = "Afiche"
                        });
                    }

                    if (!string.IsNullOrWhiteSpace(rutaLogo))
                    {
                        materialMultimedia.Add(new SM.Datos.DTO.Festivales.MaterialMultimediaCrearDTO
                        {
                            UrlArchivo = rutaLogo,
                            Descripcion = "Logo"
                        });
                    }

                    int versionId;

                    if (model.Id > 0)
                    {
                        // ACTUALIZAR versión existente
                        var versionActualizar = new SM.Datos.DTO.Festivales.FestivalVersionActualizarDTO
                        {
                            Id = model.Id,
                            NumeroVersion = model.VersionNumero,
                            NombreVersion = model.NombreVersion?.Trim(),
                            Descripcion = model.Descripcion?.Trim(),
                            FechaInicio = model.FechaInicio,
                            FechaFin = model.FechaFin,
                            TiposIngreso = tiposIngresoSeleccionados,
                            MaterialMultimedia = materialMultimedia,
                            
                            // Caracterización
                            IdTipologia = model.IdTipologia,
                            OtraTipologia = model.OtraTipologia?.Trim(),
                            ModalidadesParticipacion = modalidadesSeleccionadas,
                            OtraModalidadParticipacion = model.OtraModalidadParticipacion?.Trim(),
                            ExpresionesArtisticas = expresionesSeleccionadas,
                            OtraExpresionArtistica = model.OtraExpresionArtistica?.Trim(),

                            // Financiación
                            IdFuenteFinanciacion = model.FuenteFinanciacionPrincipal,
                            IdFuenteFinanciacionSecundaria = model.FuenteFinanciacionSecundaria,
                            OtraFuenteFinanciacionPrimaria = model.OtraFuenteFinanciacionPrimaria?.Trim(),
                            OtraFuenteFinanciacionSecundaria = model.OtraFuenteFinanciacionSecundaria?.Trim(),
                            UsoEstampillaProcultura = model.UsaEstampillaProcultura,

                            // Contacto
                            Director = model.Directoria?.Trim(),
                            PerteneceOrgColectiva = model.PerteneceOrganizacion,
                            NombreOrganizacion = model.NombreOrganizacion?.Trim(),
                            IdTipoOrganizador = string.IsNullOrWhiteSpace(model.TipoOrganizador) ? (int?)null : int.Parse(model.TipoOrganizador),
                            OtroTipoOrganizador = model.OtroTipoOrganizador?.Trim(),
                            CorreoContacto = model.CorreoContacto?.Trim(),
                            Instagram = model.Instagram?.Trim(),
                            Facebook = model.Facebook?.Trim(),
                            PaginaWeb = model.PaginaWeb?.Trim(),
                            OtroEnlace = model.OtroEnlace?.Trim(),
                            TelefonoCelular = model.TelefonoCelular?.Trim(),
                            ObservacionesContacto = model.ObservacionesContacto?.Trim(),
                            
                            // Estado de la versión: 2 = "Registrado" si envía solicitud, 1 = "Borrador" en guardado normal
                            IdEstado = esEnviarSolicitud ? 2 : 1
                        };

                        SM.Datos.Festivales.FestivalVersionServicio.Actualizar(versionActualizar, nombreUsuario, usuarioId, ipUsuario);
                        versionId = model.Id;

                        // Mensaje diferente si se envió la solicitud completa
                        if (esEnviarSolicitud)
                        {
                            TempData["SuccessMessage"] = "Solicitud de registro enviada exitosamente. La versi&oacute;n ha sido actualizada y est&aacute; lista para revisi&oacute;n.";
                        }
                        else
                        {
                            TempData["SuccessMessage"] = "Versión actualizada correctamente.";
                        }
                    }
                    else
                    {
                        // CREAR nueva versión
                        var nuevaVersion = new SM.Datos.DTO.Festivales.FestivalVersionCrearDTO
                        {
                            IdFestival = model.FestivalId ?? 0,
                            NumeroVersion = model.VersionNumero,
                            NombreVersion = model.NombreVersion?.Trim(),
                            Descripcion = model.Descripcion?.Trim(),
                            FechaInicio = model.FechaInicio,
                            FechaFin = model.FechaFin,
                            TiposIngreso = tiposIngresoSeleccionados,
                            MaterialMultimedia = materialMultimedia,
                            
                            // Caracterización
                            IdTipologia = model.IdTipologia,
                            OtraTipologia = model.OtraTipologia?.Trim(),
                            ModalidadesParticipacion = modalidadesSeleccionadas,
                            OtraModalidadParticipacion = model.OtraModalidadParticipacion?.Trim(),
                            ExpresionesArtisticas = expresionesSeleccionadas,
                            OtraExpresionArtistica = model.OtraExpresionArtistica?.Trim(),

                            // Financiación
                            IdFuenteFinanciacion = model.FuenteFinanciacionPrincipal,
                            IdFuenteFinanciacionSecundaria = model.FuenteFinanciacionSecundaria,
                            OtraFuenteFinanciacionPrimaria = model.OtraFuenteFinanciacionPrimaria?.Trim(),
                            OtraFuenteFinanciacionSecundaria = model.OtraFuenteFinanciacionSecundaria?.Trim(),
                            UsoEstampillaProcultura = model.UsaEstampillaProcultura,

                            // Contacto
                            Director = model.Directoria?.Trim(),
                            PerteneceOrgColectiva = model.PerteneceOrganizacion,
                            NombreOrganizacion = model.NombreOrganizacion?.Trim(),
                            IdTipoOrganizador = string.IsNullOrWhiteSpace(model.TipoOrganizador) ? (int?)null : int.Parse(model.TipoOrganizador),
                            OtroTipoOrganizador = model.OtroTipoOrganizador?.Trim(),
                            CorreoContacto = model.CorreoContacto?.Trim(),
                            Instagram = model.Instagram?.Trim(),
                            Facebook = model.Facebook?.Trim(),
                            PaginaWeb = model.PaginaWeb?.Trim(),
                            OtroEnlace = model.OtroEnlace?.Trim(),
                            TelefonoCelular = model.TelefonoCelular?.Trim(),
                            ObservacionesContacto = model.ObservacionesContacto?.Trim(),
                            
                            // Estado de la versión: 2 = "Registrado" si envía solicitud, 1 = "Borrador" en guardado normal
                            IdEstado = esEnviarSolicitud ? 2 : 1
                        };

                        versionId = SM.Datos.Festivales.FestivalVersionServicio.Crear(nuevaVersion, nombreUsuario, usuarioId, ipUsuario);

                        // Mensaje diferente si se envió la solicitud completa
                        if (esEnviarSolicitud)
                        {
                            TempData["SuccessMessage"] = "Solicitud de registro enviada exitosamente. La versi&oacute;n ha sido creada y est&aacute; lista para revisi&oacute;n.";
                        }
                        else
                        {
                            TempData["SuccessMessage"] = "Versión creada exitosamente.";
                        }
                    }

                    // Guardar localizaciones temporales
                    if (!string.IsNullOrWhiteSpace(model.LocalizacionesTemporalesJson))
                    {
                        try 
                        {
                            var locsTemp = Newtonsoft.Json.JsonConvert.DeserializeObject<List<dynamic>>(model.LocalizacionesTemporalesJson);
                            if (locsTemp != null && locsTemp.Any())
                            {
                                using (var contexto = new SM.SIPA.SIPAEntities())
                                {
                                    foreach (var loc in locsTemp)
                                    {
                                        string munId = (string)loc.municipioId;
                                        int zId = (int)loc.zonaId;
                                        int? zTitId = (int?)loc.zonaTitulacionId;

                                        var nuevaLocalizacion = new SM.SIPA.ART_MUS_LOCALIZACIONXVERSION
                                        {
                                            ID_VERSION = versionId,
                                            ZON_ID = munId,
                                            ID_ZONA = zId,
                                            ID_TITULACION_COLECTIVA = zTitId
                                        };
                                        contexto.ART_MUS_LOCALIZACIONXVERSION.Add(nuevaLocalizacion);
                                    }
                                    contexto.SaveChanges();
                                }
                            }
                        }
                        catch (Exception exLoc)
                        {
                             string rutaLoc = Server.MapPath("/Log");
                             Log.WriteLog(rutaLoc, $"Error guardando localizaciones temporales: {exLoc}");
                        }
                    }

                    // Guardar Territorios Sonoros seleccionados en tabla de cruce
                    try
                    {
                        var idsTS = (model.TerritoriosSeleccionados ?? new List<int>()).Distinct().ToList();
                        var practicasMusicales = string.IsNullOrWhiteSpace(model.PracticasMusicalesTS) ? null : model.PracticasMusicalesTS.Trim();
                        SM.Datos.Festivales.FestivalVersionServicio.GuardarTerritoriosSonoros(versionId, idsTS, practicasMusicales);
                    }
                    catch (Exception exTs)
                    {
                        string rutaTs = Server.MapPath("/Log");
                        Log.WriteLog(rutaTs, $"Error guardando Territorios Sonoros: {exTs}");
                        // No bloquear el flujo principal por un fallo no crítico
                    }

                    // Guardar Entidades Aliadas
                    if (model.TieneEntidadesAliadas == true && model.EntidadesAliadas != null && model.EntidadesAliadas.Any())
                    {
                        try
                        {
                            using (var contexto = new SM.SIPA.SIPAEntities())
                            {
                                // Eliminar entidades aliadas existentes
                                var entidadesExistentes = contexto.ART_MUS_FESTIVALES_ENTIDADES_ALIADAS
                                    .Where(e => e.ID_FESTIVAL == versionId)
                                    .ToList();
                                
                                foreach (var entidad in entidadesExistentes)
                                {
                                    contexto.ART_MUS_FESTIVALES_ENTIDADES_ALIADAS.Remove(entidad);
                                }

                                // Agregar las nuevas entidades aliadas
                                foreach (var entidad in model.EntidadesAliadas)
                                {
                                    var nuevaEntidad = new SM.SIPA.ART_MUS_FESTIVALES_ENTIDADES_ALIADAS
                                    {
                                        ID_FESTIVAL = versionId,
                                        NOMBRE_ENTIDAD_ALIADA = entidad.Nombre,
                                        ID_NATURALEZA = string.IsNullOrWhiteSpace(entidad.Naturaleza) ? (int?)null : int.Parse(entidad.Naturaleza),
                                        CORREO_ENTIDAD = entidad.CorreoElectronico
                                    };
                                    
                                    contexto.ART_MUS_FESTIVALES_ENTIDADES_ALIADAS.Add(nuevaEntidad);
                                }

                                contexto.SaveChanges();
                            }
                        }
                        catch (Exception exEntidades)
                        {
                            string rutaEntidades = Server.MapPath("/Log");
                            Log.WriteLog(rutaEntidades, $"Error guardando Entidades Aliadas: {exEntidades}");
                            // No bloquear el flujo principal por un fallo no crítico
                        }
                    }

                    // Si es envío de solicitud, actualizar el estado del festival a "Registrado" (2) y enviar correos de notificación
                    if (esEnviarSolicitud)
                    {
                        // Actualizar el estado del festival a 2 (Registrado/Pendiente de aprobación)
                        if (model.FestivalId.HasValue && model.FestivalId.Value > 0)
                        {
                            try
                            {
                                using (var contexto = new SM.SIPA.SIPAEntities())
                                {
                                    var festival = contexto.ART_MUS_FESTIVALES.FirstOrDefault(f => f.id == model.FestivalId.Value);
                                    if (festival != null)
                                    {
                                        festival.ID_ESTADO = 2; // Estado "Registrado" - pendiente de aprobación
                                        contexto.SaveChanges();
                                    }
                                }
                            }
                            catch (Exception exEstado)
                            {
                                string rutaEstado = Server.MapPath("/Log");
                                Log.WriteLog(rutaEstado, $"Error actualizando estado del festival: {exEstado}");
                            }
                        }

                        try
                        {
                            // Obtener información del festival para incluir en los correos
                            string nombreFestival = "Festival";
                            string departamento = null;
                            string municipio = null;

                            if (model.FestivalId.HasValue && model.FestivalId.Value > 0)
                            {
                                var festivalDTO = SM.Datos.Servicios.FestivalServicio.ObtenerPorId(model.FestivalId.Value);
                                if (festivalDTO != null)
                                {
                                    nombreFestival = festivalDTO.Nombre ?? "Festival";
                                    
                                    // Obtener departamento y municipio de la primera localización de la versión
                                    using (var contexto = new SM.SIPA.SIPAEntities())
                                    {
                                        var primeraLocalizacion = contexto.ART_MUS_LOCALIZACIONXVERSION
                                            .Include("BAS_ZONAS_GEOGRAFICAS")
                                            .FirstOrDefault(l => l.ID_VERSION == versionId);
                                        
                                        if (primeraLocalizacion != null && primeraLocalizacion.BAS_ZONAS_GEOGRAFICAS != null)
                                        {
                                            municipio = primeraLocalizacion.BAS_ZONAS_GEOGRAFICAS.ZON_NOMBRE;
                                            
                                            // Obtener el departamento padre
                                            if (!string.IsNullOrWhiteSpace(primeraLocalizacion.BAS_ZONAS_GEOGRAFICAS.ZON_PADRE_ID))
                                            {
                                                var zonaPadre = contexto.BAS_ZONAS_GEOGRAFICAS
                                                    .FirstOrDefault(z => z.ZON_ID == primeraLocalizacion.BAS_ZONAS_GEOGRAFICAS.ZON_PADRE_ID);
                                                
                                                if (zonaPadre != null)
                                                {
                                                    departamento = zonaPadre.ZON_NOMBRE;
                                                }
                                            }
                                        }
                                    }
                                }
                            }

                            string nombreVersion = model.NombreVersion ?? "Versión";
                            int numeroVersion = model.VersionNumero ?? 1;
                            string emailAlcaldia = model.CorreoContacto ?? "";

                            // Enviar correo a la alcaldía (usuario autenticado)
                            if (!string.IsNullOrWhiteSpace(emailAlcaldia))
                            {
                                WebSImus.Comunes.EnvioCorreo.EnviarCorreoFestivalAlcaldia(
                                    emailAlcaldia, 
                                    nombreFestival, 
                                    nombreVersion, 
                                    numeroVersion
                                );
                            }

                            // Enviar correo a SIMUS
                            WebSImus.Comunes.EnvioCorreo.EnviarCorreoFestivalSimus(
                                nombreFestival, 
                                nombreVersion, 
                                numeroVersion,
                                emailAlcaldia,
                                departamento,
                                municipio
                            );
                        }
                        catch (Exception exCorreo)
                        {
                            // Log del error pero no bloquear el flujo
                            string rutaCorreo = Server.MapPath("/Log");
                            Log.WriteLog(rutaCorreo, $"Error enviando correos de notificación: {exCorreo}");
                        }
                    }

                    // Redirigir a la página de crear festival con la pestaña de versiones activa
                    return RedirectToAction("Crear", new { id = model.FestivalId });
                }
                catch (Exception ex)
                {
                    // Log del error
                    string ruta = Server.MapPath("/Log");
                    Log.WriteLog(ruta, $"Error al {(model.Id > 0 ? "actualizar" : "crear")} versión: {ex.ToString()}");

                    ModelState.AddModelError("", "Ocurrió un error al guardar la versión. Por favor, intente nuevamente.");
                }
            }

            // Recargar catálogos en caso de error (mantener selección si existe)
            if (model.TiposIngreso == null || !model.TiposIngreso.Any())
            {
                var catalogo = SM.Datos.Festivales.FestivalVersionServicio.ObtenerTiposIngreso() ?? new List<SM.Datos.DTO.Festivales.TipoIngresoDTO>();
                model.TiposIngreso = catalogo.Select(t => new WebSImus.Models.TipoIngresoSeleccionItem
                {
                    Id = t.Id,
                    Nombre = t.Nombre,
                    Selected = false
                }).ToList();
            }

            // Recargar tipologías
            ViewBag.Tipologias = SM.Datos.Festivales.FestivalVersionServicio.ObtenerTipologias();

            // Recargar fuentes de financiación
            try
            {
                ViewBag.FuentesFinanciacion = SM.Datos.Servicios.FestivalServicio.ObtenerFuentesFinanciacion();
            }
            catch
            {
                ViewBag.FuentesFinanciacion = new List<SM.Datos.DTO.Festivales.FuenteFinanciacionDTO>();
            }

            // Recargar modalidades
            if (model.ModalidadesParticipacion == null || !model.ModalidadesParticipacion.Any())
            {
                var modalidades = SM.Datos.Festivales.FestivalVersionServicio.ObtenerModalidadesParticipacion();
                model.ModalidadesParticipacion = modalidades.Select(m => new ModalidadParticipacionSeleccionItem
                {
                    Id = m.Id,
                    Nombre = m.Nombre,
                    Selected = false
                }).ToList();
            }

            // Recargar expresiones
            if (model.ExpresionesArtisticas == null || !model.ExpresionesArtisticas.Any())
            {
                var expresiones = SM.Datos.Festivales.FestivalVersionServicio.ObtenerExpresionesArtisticas();
                model.ExpresionesArtisticas = expresiones.Select(e => new ExpresionArtisticaSeleccionItem
                {
                    Id = e.Id,
                    Nombre = e.Nombre,
                    Selected = false
                }).ToList();
            }

            return View(model);
        }

        // GET: Festivales/VerVersionDetalle
        public ActionResult VerVersionDetalle(int id)
        {
            var version = _versionesRegistradas.FirstOrDefault(v => v.Id == id);
            if (version == null)
                return HttpNotFound();

            // Redirigir al formulario en modo solo lectura
            return RedirectToAction("RegistrarVersion", new { id = id });
        }

        // GET: Festivales/RevisarVersion - Pantalla de revisión de versión (solo lectura para revisores)
        public ActionResult RevisarVersion(int? id)
        {
            try
            {
                if (!id.HasValue)
                {
                    return RedirectToAction("ListadoVersiones");
                }

                var vm = new FestivalVersionRegistroViewModel();
                SM.Datos.DTO.Festivales.FestivalVersionDTO versionDTO = null;

                // Cargar datos de la versión a revisar
                versionDTO = SM.Datos.Festivales.FestivalVersionServicio.ObtenerPorId(id.Value);
                if (versionDTO == null)
                {
                    return HttpNotFound();
                }

                // Mapear DTO a ViewModel
                vm.Id = versionDTO.Id;
                vm.FestivalId = versionDTO.IdFestival;
                vm.VersionNumero = versionDTO.NumeroVersion;
                vm.NombreVersion = versionDTO.NombreVersion;
                vm.Descripcion = versionDTO.Descripcion;
                vm.PracticasMusicalesTS = versionDTO.PracticasMusicales;
                vm.FechaInicio = versionDTO.FechaInicio;
                vm.FechaFin = versionDTO.FechaFin;

                // Calcular mes y duración si hay fechas
                if (versionDTO.FechaInicio.HasValue)
                {
                    vm.MesRealizacion = versionDTO.FechaInicio.Value.Month;
                }
                if (versionDTO.FechaInicio.HasValue && versionDTO.FechaFin.HasValue)
                {
                    vm.DuracionDias = (int)(versionDTO.FechaFin.Value - versionDTO.FechaInicio.Value).TotalDays + 1;
                }

                // Mapear material multimedia
                if (versionDTO.MaterialMultimedia != null)
                {
                    foreach (var material in versionDTO.MaterialMultimedia)
                    {
                        switch (material.Descripcion?.ToLower())
                        {
                            case "programa":
                                vm.UrlPrograma = material.UrlArchivo;
                                break;
                            case "afiche":
                                vm.UrlAfiche = material.UrlArchivo;
                                break;
                            case "logo":
                                vm.UrlLogo = material.UrlArchivo;
                                break;
                        }
                    }
                }

                // Cargar catálogo: Tipos de ingreso
                var catalogoTiposIngreso = SM.Datos.Festivales.FestivalVersionServicio.ObtenerTiposIngreso() ?? new List<SM.Datos.DTO.Festivales.TipoIngresoDTO>();
                ViewBag.TiposIngreso = catalogoTiposIngreso;

                var idsTiposIngresoSeleccionados = new HashSet<int>();
                if (versionDTO != null && versionDTO.TiposIngreso != null)
                {
                    idsTiposIngresoSeleccionados = new HashSet<int>(versionDTO.TiposIngreso.Select(t => t.Id));
                }

                vm.TiposIngreso = catalogoTiposIngreso
                    .Select(t => new WebSImus.Models.TipoIngresoSeleccionItem
                    {
                        Id = t.Id,
                        Nombre = t.Nombre,
                        Selected = idsTiposIngresoSeleccionados.Contains(t.Id)
                    })
                    .ToList();

                // Cargar catálogo: Tipologías
                ViewBag.Tipologias = SM.Datos.Festivales.FestivalVersionServicio.ObtenerTipologias();

                // Cargar catálogo: Fuentes de Financiación
                try
                {
                    ViewBag.FuentesFinanciacion = SM.Datos.Servicios.FestivalServicio.ObtenerFuentesFinanciacion() ?? new List<SM.Datos.DTO.Festivales.FuenteFinanciacionDTO>();
                }
                catch
                {
                    ViewBag.FuentesFinanciacion = new List<SM.Datos.DTO.Festivales.FuenteFinanciacionDTO>();
                }

                // Cargar Territorios Sonoros desde BD
                var territorios = SM.Datos.Festivales.FestivalVersionServicio.ObtenerTerritoriosSonoros() ?? new List<SM.Datos.DTO.Festivales.TerritorioSonoroDTO>();
                var idsSeleccionadosTS = new HashSet<int>();
                
                if (versionDTO.Id > 0)
                {
                    idsSeleccionadosTS = new HashSet<int>(
                        SM.Datos.Festivales.FestivalVersionServicio.ObtenerTerritoriosSonorosPorVersion(versionDTO.Id)
                    );
                }

                vm.TerritoriosSonoros = territorios.Select(t => new TerritorioSonoroSeleccionItem
                {
                    Id = t.Id,
                    Nombre = t.Nombre,
                    Selected = idsSeleccionadosTS.Contains(t.Id),
                    EsNinguna = (t.Nombre ?? "").Trim().Equals("Ninguna", StringComparison.OrdinalIgnoreCase)
                                || (t.Nombre ?? "").IndexOf("N/A", StringComparison.OrdinalIgnoreCase) >= 0
                }).ToList();

                // Cargar Modalidades de Participación
                var modalidades = SM.Datos.Festivales.FestivalVersionServicio.ObtenerModalidadesParticipacion() ?? new List<SM.Datos.DTO.Festivales.ModalidadParticipacionDTO>();
                var idsModalidadesSeleccionadas = new HashSet<int>();
                
                if (versionDTO.Id > 0)
                {
                    idsModalidadesSeleccionadas = new HashSet<int>(
                        SM.Datos.Festivales.FestivalVersionServicio.ObtenerModalidadesParticipacionPorVersion(versionDTO.Id)
                    );
                }

                vm.ModalidadesParticipacion = modalidades.Select(m => new ModalidadParticipacionSeleccionItem
                {
                    Id = m.Id,
                    Nombre = m.Nombre,
                    Selected = idsModalidadesSeleccionadas.Contains(m.Id)
                }).ToList();

                // Cargar Expresiones Artísticas
                var expresiones = SM.Datos.Festivales.FestivalVersionServicio.ObtenerExpresionesArtisticas() ?? new List<SM.Datos.DTO.Festivales.ExpresionArtisticaDTO>();
                var idsExpresionesSeleccionadas = new HashSet<int>();
                
                if (versionDTO.Id > 0)
                {
                    idsExpresionesSeleccionadas = new HashSet<int>(
                        SM.Datos.Festivales.FestivalVersionServicio.ObtenerExpresionesArtisticasPorVersion(versionDTO.Id)
                    );
                }

                vm.ExpresionesArtisticas = expresiones.Select(e => new ExpresionArtisticaSeleccionItem
                {
                    Id = e.Id,
                    Nombre = e.Nombre,
                    Selected = idsExpresionesSeleccionadas.Contains(e.Id)
                }).ToList();

                // Cargar datos de caracterización
                vm.IdTipologia = versionDTO.IdTipologia;
                vm.OtraTipologia = versionDTO.OtraTipologia;
                vm.OtraModalidadParticipacion = versionDTO.OtraModalidadParticipacion;
                vm.OtraExpresionArtistica = versionDTO.OtraExpresionArtistica;

                // Cargar datos de financiación
                vm.FuenteFinanciacionPrincipal = versionDTO.IdFuenteFinanciacion;
                vm.FuenteFinanciacionSecundaria = versionDTO.IdFuenteFinanciacionSecundaria;
                vm.OtraFuenteFinanciacionPrimaria = versionDTO.OtraFuenteFinanciacionPrimaria;
                vm.OtraFuenteFinanciacionSecundaria = versionDTO.OtraFuenteFinanciacionSecundaria;
                vm.UsaEstampillaProcultura = versionDTO.UsoEstampillaProcultura;

                // Cargar datos de contacto
                vm.Directoria = versionDTO.Director;
                vm.PerteneceOrganizacion = versionDTO.PerteneceOrgColectiva;
                vm.NombreOrganizacion = versionDTO.NombreOrganizacion;
                vm.TipoOrganizador = versionDTO.IdTipoOrganizador?.ToString();
                vm.OtroTipoOrganizador = versionDTO.OtroTipoOrganizador;
                vm.CorreoContacto = versionDTO.CorreoContacto;
                vm.Instagram = versionDTO.Instagram;
                vm.Facebook = versionDTO.Facebook;
                vm.PaginaWeb = versionDTO.PaginaWeb;
                vm.OtroEnlace = versionDTO.OtroEnlace;
                vm.TelefonoCelular = versionDTO.TelefonoCelular;
                vm.ObservacionesContacto = versionDTO.ObservacionesContacto;

                // Cargar entidades aliadas existentes
                try
                {
                    using (var contexto = new SM.SIPA.SIPAEntities())
                    {
                        var entidadesExistentes = contexto.ART_MUS_FESTIVALES_ENTIDADES_ALIADAS
                            .Where(e => e.ID_FESTIVAL == versionDTO.Id)
                            .ToList();

                        if (entidadesExistentes.Any())
                        {
                            vm.TieneEntidadesAliadas = true;
                            vm.EntidadesAliadas = entidadesExistentes.Select(e => new EntidadAliadaItem
                            {
                                Id = e.ID,
                                Nombre = e.NOMBRE_ENTIDAD_ALIADA,
                                Naturaleza = e.ID_NATURALEZA?.ToString(),
                                CorreoElectronico = e.CORREO_ENTIDAD
                            }).ToList();
                        }
                    }
                }
                catch (Exception exEntidades)
                {
                    string rutaEntidades = Server.MapPath("/Log");
                    Log.WriteLog(rutaEntidades, $"Error cargando Entidades Aliadas: {exEntidades}");
                }

                return View(vm);
            }
            catch (Exception ex)
            {
                string ruta = Server.MapPath("/Log");
                Log.WriteLog(ruta, ex.ToString());
                return RedirectToAction("ListadoVersiones");
            }
        }

        // POST: Festivales/GestionarSolicitud - Procesa la decisión del revisor (Aprobar/Rechazar/Solicitar Aclaraciones)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GestionarSolicitud(FestivalVersionRegistroViewModel model, string accionSolicitud, string observacionesGestion)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(accionSolicitud))
                {
                    TempData["Error"] = "Debe seleccionar una acci&oacute;n (Aprobar, Solicitar aclaraciones o Rechazar).";
                    return RedirectToAction("RevisarVersion", new { id = model.Id });
                }

                // Validar que haya observaciones para rechazo o solicitud de aclaraciones
                if ((accionSolicitud == "Rechazar" || accionSolicitud == "SolicitarAclaraciones") && string.IsNullOrWhiteSpace(observacionesGestion))
                {
                    TempData["Error"] = "Debe escribir observaciones para rechazar o solicitar aclaraciones.";
                    return RedirectToAction("RevisarVersion", new { id = model.Id });
                }

                // Obtener información del usuario autenticado
                int usuarioId = string.IsNullOrEmpty(UsuaroId) ? 0 : Convert.ToInt32(UsuaroId);
                string nombreUsuario = Usuario ?? "Sistema";

                int nuevoEstado = 0;
                string mensajeExito = "";

                switch (accionSolicitud)
                {
                    case "Aprobar":
                        nuevoEstado = 4; // Estado "Publicado"
                        mensajeExito = "Festival aprobado y publicado exitosamente.";
                        break;
                    case "SolicitarAclaraciones":
                        nuevoEstado = 3; // Estado "Solicitud de Aclaraciones"
                        mensajeExito = "Solicitud de aclaraciones enviada exitosamente.";
                        break;
                    case "Rechazar":
                        nuevoEstado = 5; // Estado "Rechazado"
                        mensajeExito = "Festival rechazado.";
                        break;
                    default:
                        TempData["Error"] = "Acci&oacute;n no reconocida.";
                        return RedirectToAction("RevisarVersion", new { id = model.Id });
                }

                // Actualizar estado del festival
                int festivalId = 0;
                using (var contexto = new SM.SIPA.SIPAEntities())
                {
                    var version = contexto.ART_MUS_FESTIVALES_VERSION.FirstOrDefault(v => v.ID == model.Id);
                    if (version != null && version.ID_FESTIVAL.HasValue)
                    {
                        festivalId = version.ID_FESTIVAL.Value;
                        var festival = contexto.ART_MUS_FESTIVALES.FirstOrDefault(f => f.id == festivalId);
                        if (festival != null)
                        {
                            festival.ID_ESTADO = nuevoEstado;
                            
                            // Guardar observaciones si existen
                            if (!string.IsNullOrWhiteSpace(observacionesGestion))
                            {
                                festival.OBSERVACIONES_CONTACTO = observacionesGestion.Trim();
                            }

                            contexto.SaveChanges();

                            // Enviar correo de notificación (implementar según necesidad)
                            // TODO: Implementar envío de correos según la acción tomada

                            TempData["Msg"] = mensajeExito;
                            // Redirigir al listado de versiones del festival
                            return RedirectToAction("Crear", new { id = festivalId, activeTab = "versiones" });
                        }
                    }
                }

                TempData["Error"] = "No se pudo actualizar el estado del festival.";
                return RedirectToAction("RevisarVersion", new { id = model.Id });
            }
            catch (Exception ex)
            {
                string ruta = Server.MapPath("/Log");
                Log.WriteLog(ruta, $"Error en GestionarSolicitud: {ex.ToString()}");
                TempData["Error"] = "Ocurri&oacute; un error al procesar la solicitud.";
                return RedirectToAction("RevisarVersion", new { id = model.Id });
            }
        }

        /// <summary>
        /// Método helper para recargar catálogos en caso de error de validación
        /// </summary>
        private void CargarCatalogosRegistroVersion(FestivalVersionRegistroViewModel model)
        {
            // Recargar catálogo: Tipos de ingreso
            if (model.TiposIngreso == null || !model.TiposIngreso.Any())
            {
                var catalogo = SM.Datos.Festivales.FestivalVersionServicio.ObtenerTiposIngreso() ?? new List<SM.Datos.DTO.Festivales.TipoIngresoDTO>();
                model.TiposIngreso = catalogo.Select(t => new WebSImus.Models.TipoIngresoSeleccionItem
                {
                    Id = t.Id,
                    Nombre = t.Nombre,
                    Selected = false
                }).ToList();
            }

            // Recargar tipologías
            ViewBag.Tipologias = SM.Datos.Festivales.FestivalVersionServicio.ObtenerTipologias();

            // Recargar fuentes de financiación
            try
            {
                ViewBag.FuentesFinanciacion = SM.Datos.Servicios.FestivalServicio.ObtenerFuentesFinanciacion() ?? new List<SM.Datos.DTO.Festivales.FuenteFinanciacionDTO>();
            }
            catch
            {
                ViewBag.FuentesFinanciacion = new List<SM.Datos.DTO.Festivales.FuenteFinanciacionDTO>();
            }

            // Recargar modalidades
            if (model.ModalidadesParticipacion == null || !model.ModalidadesParticipacion.Any())
            {
                var modalidades = SM.Datos.Festivales.FestivalVersionServicio.ObtenerModalidadesParticipacion();
                model.ModalidadesParticipacion = modalidades.Select(m => new ModalidadParticipacionSeleccionItem
                {
                    Id = m.Id,
                    Nombre = m.Nombre,
                    Selected = false
                }).ToList();
            }

            // Recargar expresiones
            if (model.ExpresionesArtisticas == null || !model.ExpresionesArtisticas.Any())
            {
                var expresiones = SM.Datos.Festivales.FestivalVersionServicio.ObtenerExpresionesArtisticas();
                model.ExpresionesArtisticas = expresiones.Select(e => new ExpresionArtisticaSeleccionItem
                {
                    Id = e.Id,
                    Nombre = e.Nombre,
                    Selected = false
                }).ToList();
            }

            // Recargar territorios sonoros
            var territorios = SM.Datos.Festivales.FestivalVersionServicio.ObtenerTerritoriosSonoros();
            var idsSeleccionadosTS = new HashSet<int>();
            
            if (model.Id > 0)
            {
                idsSeleccionadosTS = new HashSet<int>(
                    SM.Datos.Festivales.FestivalVersionServicio.ObtenerTerritoriosSonorosPorVersion(model.Id)
                );
            }

            if (model.TerritoriosSonoros == null || !model.TerritoriosSonoros.Any())
            {
                model.TerritoriosSonoros = territorios.Select(t => new TerritorioSonoroSeleccionItem
                {
                    Id = t.Id,
                    Nombre = t.Nombre,
                    Selected = idsSeleccionadosTS.Contains(t.Id),
                    EsNinguna = (t.Nombre ?? "").Trim().Equals("Ninguna", StringComparison.OrdinalIgnoreCase)
                                || (t.Nombre ?? "").IndexOf("N/A", StringComparison.OrdinalIgnoreCase) >= 0
                }).ToList();
            }
        }

        // ========== MAPA PÚBLICO DE FESTIVALES (SIN AUTENTICACIÓN) ==========

        /// <summary>
        /// Página pública del mapa de festivales (no requiere autenticación)
        /// </summary>
        [AllowAnonymous]
        public ActionResult MapaPublico()
        {
            var model = new MapaFestivalesViewModel
            {
                Titulo = "Mapa de festivales"
            };
            return View(model);
        }

        /// <summary>
        /// Obtiene datos de festivales por ciudad para gráfica circular
        /// </summary>
        [AllowAnonymous]
        public JsonResult ObtenerFestivalesPorCiudad()
        {
            try
            {
                using (var db = new SIPAEntities())
                {
                    // Consultar festivales publicados agrupados por ciudad (municipio)
                    var festivalesPorCiudad = db.ART_MUS_FESTIVALES
                        .Where(f => f.ID_ESTADO == 4) // Estado "Publicado"
                        .SelectMany(f => f.ART_MUS_FESTIVALES_VERSION
                            .SelectMany(v => v.ART_MUS_LOCALIZACIONXVERSION
                                .Where(l => l.BAS_ZONAS_GEOGRAFICAS != null && !string.IsNullOrEmpty(l.BAS_ZONAS_GEOGRAFICAS.ZON_PADRE_ID))
                                .Select(l => new
                                {
                                    FestivalId = f.id,
                                    Ciudad = l.BAS_ZONAS_GEOGRAFICAS.ZON_NOMBRE
                                })))
                        .GroupBy(x => x.Ciudad)
                        .Select(g => new EstadisticaGraficaDTO
                        {
                            Categoria = g.Key,
                            Cantidad = g.Select(x => x.FestivalId).Distinct().Count()
                        })
                        .OrderByDescending(x => x.Cantidad)
                        .ToList();

                    // Limitar a top 10 ciudades y agrupar el resto como "Otras"
                    var top10 = festivalesPorCiudad.Take(10).ToList();
                    var resto = festivalesPorCiudad.Skip(10).Sum(x => x.Cantidad);

                    if (resto > 0)
                    {
                        top10.Add(new EstadisticaGraficaDTO
                        {
                            Categoria = "Otras ciudades",
                            Cantidad = resto
                        });
                    }

                    return Json(top10, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                string ruta = Server.MapPath("/Log");
                Log.WriteLog(ruta, $"Error en ObtenerFestivalesPorCiudad: {ex.ToString()}");
                return Json(new List<EstadisticaGraficaDTO>(), JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// Obtiene datos de territorios sonoros para gráfica circular
        /// </summary>
        [AllowAnonymous]
        public JsonResult ObtenerTerritoriosSonoros()
        {
            try
            {
                using (var db = new SIPAEntities())
                {
                    // Consultar festivales publicados agrupados por territorio sonoro
                    var festivalesPorTerritorio = db.ART_MUS_FESTIVALES_VERSION
                        .Where(v => v.ART_MUS_FESTIVALES.ID_ESTADO == 4) // Estado "Publicado"
                        .SelectMany(v => v.ART_MUS_TERRITORIOS_SONOROSXVERSION
                            .Where(t => t.ART_MUS_TERRITORIOS_SONOROS != null)
                            .Select(t => new
                            {
                                FestivalId = v.ART_MUS_FESTIVALES.id,
                                Territorio = t.ART_MUS_TERRITORIOS_SONOROS.TERRITORIOS_SONOROS
                            }))
                        .GroupBy(x => x.Territorio)
                        .Select(g => new EstadisticaGraficaDTO
                        {
                            Categoria = g.Key,
                            Cantidad = g.Select(x => x.FestivalId).Distinct().Count()
                        })
                        .OrderByDescending(x => x.Cantidad)
                        .ToList();

                    return Json(festivalesPorTerritorio, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                string ruta = Server.MapPath("/Log");
                Log.WriteLog(ruta, $"Error en ObtenerTerritoriosSonoros: {ex.ToString()}");
                return Json(new List<EstadisticaGraficaDTO>(), JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// Obtiene datos de festivales por tipo para gráfica circular
        /// </summary>
        [AllowAnonymous]
        public JsonResult ObtenerFestivalesPorTipo()
        {
            try
            {
                using (var db = new SIPAEntities())
                {
                    // Consultar festivales publicados agrupados por tipología
                    var festivalesPorTipo = db.ART_MUS_FESTIVALES_VERSION
                        .Where(v => v.ART_MUS_FESTIVALES.ID_ESTADO == 4 && v.ART_MUS_FESTIVALES_TIPOLOGIA != null) // Estado "Publicado"
                        .GroupBy(v => v.ART_MUS_FESTIVALES_TIPOLOGIA.TIPOLOGIA)
                        .Select(g => new EstadisticaGraficaDTO
                        {
                            Categoria = g.Key,
                            Cantidad = g.Select(v => v.ART_MUS_FESTIVALES.id).Distinct().Count()
                        })
                        .OrderByDescending(x => x.Cantidad)
                        .ToList();

                    return Json(festivalesPorTipo, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                string ruta = Server.MapPath("/Log");
                Log.WriteLog(ruta, $"Error en ObtenerFestivalesPorTipo: {ex.ToString()}");
                return Json(new List<EstadisticaGraficaDTO>(), JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// Obtiene datos de festivales por expresión musical para gráfica circular
        /// </summary>
        [AllowAnonymous]
        public JsonResult ObtenerFestivalesPorExpresionMusical()
        {
            try
            {
                using (var db = new SIPAEntities())
                {
                    // Consultar festivales publicados agrupados por expresión artística
                    var festivalesPorExpresion = db.ART_MUS_FESTIVALES_VERSION
                        .Where(v => v.ART_MUS_FESTIVALES.ID_ESTADO == 4) // Estado "Publicado"
                        .SelectMany(v => v.ART_MUS_FESTIVALES_EXPRESIONXVERSION
                            .Where(e => e.ART_MUS_FESTIVALES_EXPRESIONES_ARTISTICAS != null && e.ART_MUS_FESTIVALES_EXPRESIONES_ARTISTICAS.ACTIVO)
                            .Select(e => new
                            {
                                FestivalId = v.ART_MUS_FESTIVALES.id,
                                Expresion = e.ART_MUS_FESTIVALES_EXPRESIONES_ARTISTICAS.EXPRESION_ARTISTICA
                            }))
                        .GroupBy(x => x.Expresion)
                        .Select(g => new EstadisticaGraficaDTO
                        {
                            Categoria = g.Key,
                            Cantidad = g.Select(x => x.FestivalId).Distinct().Count()
                        })
                        .OrderByDescending(x => x.Cantidad)
                        .ToList();

                    // Limitar a top 10 expresiones y agrupar el resto como "Otras"
                    var top10 = festivalesPorExpresion.Take(10).ToList();
                    var resto = festivalesPorExpresion.Skip(10).Sum(x => x.Cantidad);

                    if (resto > 0)
                    {
                        top10.Add(new EstadisticaGraficaDTO
                        {
                            Categoria = "Otras expresiones",
                            Cantidad = resto
                        });
                    }

                    return Json(top10, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                string ruta = Server.MapPath("/Log");
                Log.WriteLog(ruta, $"Error en ObtenerFestivalesPorExpresionMusical: {ex.ToString()}");
                return Json(new List<EstadisticaGraficaDTO>(), JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// Obtiene datos para el mapa de calor (ubicaciones de festivales)
        /// </summary>
        [AllowAnonymous]
        public JsonResult ObtenerUbicacionesFestivales()
        {
            try
            {
                using (var db = new SIPAEntities())
                {
                    // Consultar festivales publicados con sus localizaciones
                    var festivales = db.ART_MUS_FESTIVALES
                        .Where(f => f.ID_ESTADO == 4) // Estado "Publicado"
                        .Select(f => new
                        {
                            f.id,
                            f.NOMBRE_FESTIVAL,
                            f.VERSIONES_REALIZADAS,
                            Versiones = f.ART_MUS_FESTIVALES_VERSION
                                .Where(v => v.ART_MUS_LOCALIZACIONXVERSION.Any())
                                .Select(v => new
                                {
                                    Localizaciones = v.ART_MUS_LOCALIZACIONXVERSION
                                        .Where(l => l.BAS_ZONAS_GEOGRAFICAS != null)
                                        .Select(l => new
                                        {
                                            l.BAS_ZONAS_GEOGRAFICAS.ZON_ID,
                                            l.BAS_ZONAS_GEOGRAFICAS.ZON_NOMBRE,
                                            l.BAS_ZONAS_GEOGRAFICAS.ZON_PADRE_ID,
                                            l.BAS_ZONAS_GEOGRAFICAS.ZON_LATITUD,
                                            l.BAS_ZONAS_GEOGRAFICAS.ZON_LONGITUD
                                        })
                                })
                        })
                        .ToList();

                    var datos = new List<FestivalMapaDTO>();

                    foreach (var festival in festivales)
                    {
                        // Obtener todas las localizaciones únicas del festival
                        var localizaciones = festival.Versiones
                            .SelectMany(v => v.Localizaciones)
                            .GroupBy(l => l.ZON_ID)
                            .Select(g => g.First())
                            .Where(l => l.ZON_LATITUD.HasValue && l.ZON_LONGITUD.HasValue)
                            .ToList();

                        foreach (var loc in localizaciones)
                        {
                            string municipio = loc.ZON_NOMBRE ?? "";
                            string departamento = "";

                            // Si tiene padre, obtener el departamento
                            if (!string.IsNullOrEmpty(loc.ZON_PADRE_ID))
                            {
                                var zonaPadre = db.BAS_ZONAS_GEOGRAFICAS
                                    .FirstOrDefault(z => z.ZON_ID == loc.ZON_PADRE_ID);
                                if (zonaPadre != null)
                                {
                                    departamento = zonaPadre.ZON_NOMBRE;
                                }
                            }
                            else
                            {
                                // Si no tiene padre, es un departamento
                                departamento = loc.ZON_NOMBRE;
                                municipio = "";
                            }

                            datos.Add(new FestivalMapaDTO
                            {
                                Nombre = festival.NOMBRE_FESTIVAL ?? "Sin nombre",
                                Ciudad = municipio,
                                Departamento = departamento,
                                Latitud = loc.ZON_LATITUD.Value,
                                Longitud = loc.ZON_LONGITUD.Value,
                                CantidadVersiones = festival.VERSIONES_REALIZADAS ?? 0
                            });
                        }
                    }

                    return Json(datos, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                string ruta = Server.MapPath("/Log");
                Log.WriteLog(ruta, $"Error en ObtenerUbicacionesFestivales: {ex.ToString()}");
                return Json(new List<FestivalMapaDTO>(), JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// Obtiene la lista de departamentos para los combos de localización
        /// </summary>
        [HttpGet]
        public JsonResult ObtenerDepartamento()
        {
            try
            {
                List<SM.LibreriaComun.DTO.BasicaDTO> listDpto = SM.Aplicacion.Basicas.ZonaGeograficasLogica.ConsultarDepartamentos();
                return Json(listDpto, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                string ruta = Server.MapPath("/Log");
                Log.WriteLog(ruta, ex.ToString());
                return Json(new List<SM.LibreriaComun.DTO.BasicaDTO>(), JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// Obtiene la lista de zonas para el combo de localización
        /// </summary>
        [HttpGet]
        public JsonResult ObtenerZonas()
        {
            try
            {
                List<SM.LibreriaComun.DTO.BasicaDTO> listZonas = new List<SM.LibreriaComun.DTO.BasicaDTO>();

                using (var contexto = new SM.SIPA.SIPAEntities())
                {
                    listZonas = contexto.ART_MUS_FESTIVALES_ZONA
                        .Where(z => z.MUS_FESTIVALES_ZONA != null)
                        .OrderBy(z => z.MUS_FESTIVALES_ZONA)
                        .Select(z => new SM.LibreriaComun.DTO.BasicaDTO
                        {
                            value = z.ID.ToString(),
                            text = z.MUS_FESTIVALES_ZONA
                        })
                        .ToList();
                }

                return Json(listZonas, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                string ruta = Server.MapPath("/Log");
                Log.WriteLog(ruta, ex.ToString());
                return Json(new List<SM.LibreriaComun.DTO.BasicaDTO>(), JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// Obtiene si una zona es rural
        /// </summary>
        [HttpGet]
        public JsonResult ObtenerZonaEsRural(int zonaId)
        {
            try
            {
                bool esRural = false;

                using (var contexto = new SM.SIPA.SIPAEntities())
                {
                    var zona = contexto.ART_MUS_FESTIVALES_ZONA.FirstOrDefault(z => z.ID == zonaId);
                    if (zona != null)
                    {
                        esRural = zona.ES_RURAL ?? false;
                    }
                }

                return Json(new { esRural = esRural }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                string ruta = Server.MapPath("/Log");
                Log.WriteLog(ruta, ex.ToString());
                return Json(new { esRural = false }, JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// Obtiene la lista de zonas con titulación colectiva
        /// </summary>
        [HttpGet]
        public JsonResult ObtenerZonasTitulacionColectiva()
        {
            try
            {
                List<SM.LibreriaComun.DTO.BasicaDTO> listZonas = new List<SM.LibreriaComun.DTO.BasicaDTO>();

                using (var contexto = new SM.SIPA.SIPAEntities())
                {
                    listZonas = contexto.ART_MUS_FESTIVALES_ZONA_TITULACION_COLECTIVA
                        .Where(z => z.ACTIVO == 1 && z.DESCRPCION_ZONA_TITULACION_COLECTIVA != null)
                        .OrderBy(z => z.DESCRPCION_ZONA_TITULACION_COLECTIVA)
                        .Select(z => new SM.LibreriaComun.DTO.BasicaDTO
                        {
                            value = z.ID.ToString(),
                            text = z.DESCRPCION_ZONA_TITULACION_COLECTIVA
                        })
                        .ToList();
                }

                return Json(listZonas, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                string ruta = Server.MapPath("/Log");
                Log.WriteLog(ruta, ex.ToString());
                return Json(new List<SM.LibreriaComun.DTO.BasicaDTO>(), JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// Obtiene las localizaciones de una versión
        /// </summary>
        [HttpGet]
        public JsonResult ObtenerLocalizaciones(int versionId)
        {
            try
            {
                var localizaciones = new List<object>();

                using (var contexto = new SM.SIPA.SIPAEntities())
                {
                    var datos = contexto.ART_MUS_LOCALIZACIONXVERSION
                        .Where(l => l.ID_VERSION == versionId)
                        .ToList();

                    foreach (var l in datos)
                    {
                        // Obtener municipio
                        var municipio = contexto.BAS_ZONAS_GEOGRAFICAS.FirstOrDefault(z => z.ZON_ID == l.ZON_ID);
                        string municipioNombre = municipio != null ? municipio.ZON_NOMBRE : "";
                        
                        // Obtener departamento (padre del municipio)
                        string departamentoId = municipio != null ? municipio.ZON_PADRE_ID : "";
                        var departamento = !string.IsNullOrEmpty(departamentoId) 
                            ? contexto.BAS_ZONAS_GEOGRAFICAS.FirstOrDefault(z => z.ZON_ID == departamentoId)
                            : null;
                        string departamentoNombre = departamento != null ? departamento.ZON_NOMBRE : "";
                        
                        // Obtener zona
                        var zona = l.ID_ZONA.HasValue 
                            ? contexto.ART_MUS_FESTIVALES_ZONA.FirstOrDefault(z => z.ID == l.ID_ZONA.Value)
                            : null;
                        string zonaNombre = zona != null ? zona.MUS_FESTIVALES_ZONA : "";
                        
                        // Obtener zona titulación colectiva
                        var zonaTitulacion = l.ID_TITULACION_COLECTIVA.HasValue
                            ? contexto.ART_MUS_FESTIVALES_ZONA_TITULACION_COLECTIVA.FirstOrDefault(z => z.ID == l.ID_TITULACION_COLECTIVA.Value)
                            : null;
                        string zonaTitulacionNombre = zonaTitulacion != null ? zonaTitulacion.DESCRPCION_ZONA_TITULACION_COLECTIVA : "";
                        
                        localizaciones.Add(new
                        {
                            id = l.ID,
                            departamentoId = departamentoId,
                            departamentoNombre = departamentoNombre,
                            municipioId = l.ZON_ID,
                            municipioNombre = municipioNombre,
                            zonaId = l.ID_ZONA,
                            zonaNombre = zonaNombre,
                            zonaTitulacionId = l.ID_TITULACION_COLECTIVA,
                            zonaTitulacionNombre = zonaTitulacionNombre
                        });
                    }
                }

                return Json(localizaciones, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                string ruta = Server.MapPath("/Log");
                Log.WriteLog(ruta, ex.ToString());
                return Json(new List<object>(), JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// Guarda o actualiza una localización
        /// </summary>
        [HttpPost]
        public JsonResult GuardarLocalizacion(int versionId, int? localizacionId, string municipioId, int zonaId, int? zonaTitulacionId)
        {
            try
            {
                using (var contexto = new SM.SIPA.SIPAEntities())
                {
                    // El campo ZON_ID debe contener el municipio seleccionado
                    // (que tiene como ZON_PADRE_ID el departamento)
                    
                    if (localizacionId.HasValue && localizacionId.Value > 0)
                    {
                        // Actualizar localización existente
                        var localizacion = contexto.ART_MUS_LOCALIZACIONXVERSION.FirstOrDefault(l => l.ID == localizacionId.Value);
                        if (localizacion != null)
                        {
                            localizacion.ZON_ID = municipioId;
                            localizacion.ID_ZONA = zonaId;
                            localizacion.ID_TITULACION_COLECTIVA = zonaTitulacionId;
                        }
                    }
                    else
                    {
                        // Crear nueva localización
                        var nuevaLocalizacion = new SM.SIPA.ART_MUS_LOCALIZACIONXVERSION
                        {
                            ID_VERSION = versionId,
                            ZON_ID = municipioId,
                            ID_ZONA = zonaId,
                            ID_TITULACION_COLECTIVA = zonaTitulacionId
                        };
                        contexto.ART_MUS_LOCALIZACIONXVERSION.Add(nuevaLocalizacion);
                    }

                    contexto.SaveChanges();
                    return Json(new { success = true, message = "Localizaci&oacute;n guardada correctamente" });
                }
            }
            catch (Exception ex)
            {
                string ruta = Server.MapPath("/Log");
                Log.WriteLog(ruta, ex.ToString());
                return Json(new { success = false, message = "Error al guardar la localización: " + ex.Message });
            }
        }

        /// <summary>
        /// Elimina una localización
        /// </summary>
        [HttpPost]
        public JsonResult EliminarLocalizacion(int localizacionId)
        {
            try
            {
                using (var contexto = new SM.SIPA.SIPAEntities())
                {
                    var localizacion = contexto.ART_MUS_LOCALIZACIONXVERSION.FirstOrDefault(l => l.ID == localizacionId);
                    if (localizacion != null)
                    {
                        contexto.ART_MUS_LOCALIZACIONXVERSION.Remove(localizacion);
                        contexto.SaveChanges();
                        return Json(new { success = true, message = "Localizacin eliminada correctamente" });
                    }
                    else
                    {
                        return Json(new { success = false, message = "Localizacin no encontrada" });
                    }
                }
            }
            catch (Exception ex)
            {
                string ruta = Server.MapPath("/Log");
                Log.WriteLog(ruta, ex.ToString());
                return Json(new { success = false, message = "Error al eliminar la localizacin: " + ex.Message });
            }
        }

        /// <summary>
        /// Partial view con grilla DevExpress de localizaciones
        /// </summary>
        [ValidateInput(false)]
        public ActionResult GridLocalizacionesPartial(int versionId)
        {
            try
            {
                var localizaciones = new List<WebSImus.Models.LocalizacionGridViewModel>();

                using (var contexto = new SM.SIPA.SIPAEntities())
                {
                    var datos = contexto.ART_MUS_LOCALIZACIONXVERSION
                        .Where(l => l.ID_VERSION == versionId)
                        .ToList();

                    // Log para depuración
                    string ruta = Server.MapPath("/Log");
                    Log.WriteLog(ruta, $"GridLocalizacionesPartial - VersionId: {versionId}, Registros encontrados: {datos.Count}");

                    foreach (var l in datos)
                    {
                        // Obtener municipio
                        var municipio = contexto.BAS_ZONAS_GEOGRAFICAS.FirstOrDefault(z => z.ZON_ID == l.ZON_ID);
                        string municipioNombre = municipio != null ? municipio.ZON_NOMBRE : "";
                        
                        // Obtener departamento (padre del municipio)
                        string departamentoId = municipio != null ? municipio.ZON_PADRE_ID : "";
                        var departamento = !string.IsNullOrEmpty(departamentoId) 
                            ? contexto.BAS_ZONAS_GEOGRAFICAS.FirstOrDefault(z => z.ZON_ID == departamentoId)
                            : null;
                        string departamentoNombre = departamento != null ? departamento.ZON_NOMBRE : "";
                        
                        // Obtener zona
                        var zona = l.ID_ZONA.HasValue 
                            ? contexto.ART_MUS_FESTIVALES_ZONA.FirstOrDefault(z => z.ID == l.ID_ZONA.Value)
                            : null;
                        string zonaNombre = zona != null ? zona.MUS_FESTIVALES_ZONA : "";
                        
                        // Obtener zona titulación colectiva
                        var zonaTitulacion = l.ID_TITULACION_COLECTIVA.HasValue
                            ? contexto.ART_MUS_FESTIVALES_ZONA_TITULACION_COLECTIVA.FirstOrDefault(z => z.ID == l.ID_TITULACION_COLECTIVA.Value)
                            : null;
                        string zonaTitulacionNombre = zonaTitulacion != null ? zonaTitulacion.DESCRPCION_ZONA_TITULACION_COLECTIVA : "";
                        
                        localizaciones.Add(new WebSImus.Models.LocalizacionGridViewModel
                        {
                            Id = l.ID,
                            DepartamentoNombre = departamentoNombre,
                            MunicipioNombre = municipioNombre,
                            ZonaNombre = zonaNombre,
                            ZonaTitulacionNombre = zonaTitulacionNombre
                        });
                    }
                }

                ViewBag.VersionId = versionId;
                return PartialView("~/Views/Festivales/_GridLocalizacionesPartial.cshtml", localizaciones);
            }
            catch (Exception ex)
            {
                string ruta = Server.MapPath("/Log");
                Log.WriteLog(ruta, ex.ToString());
                return PartialView("~/Views/Festivales/_GridLocalizacionesPartial.cshtml", new List<WebSImus.Models.LocalizacionGridViewModel>());
            }
        }

        /// <summary>
        /// Obtiene la lista de municipios por departamento para los combos de localización
        /// </summary>
        [HttpGet]
        public JsonResult ObtenerMunicipio(string departamento = null)
        {
            try
            {
                List<SM.LibreriaComun.DTO.BasicaDTO> listMunicipios = new List<SM.LibreriaComun.DTO.BasicaDTO>();

                if (!string.IsNullOrEmpty(departamento))
                {
                    listMunicipios = SM.Aplicacion.Basicas.ZonaGeograficasLogica.ConsultarMunicipios(departamento);
                }

                return Json(listMunicipios, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                string ruta = Server.MapPath("/Log");
                Log.WriteLog(ruta, ex.ToString());
                return Json(new List<SM.LibreriaComun.DTO.BasicaDTO>(), JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// Obtiene la lista de tipos de organizador para el combo de contacto
        /// </summary>
        [HttpGet]
        public JsonResult ObtenerTiposOrganizador()
        {
            try
            {
                using (var contexto = new SM.SIPA.SIPAEntities())
                {
                    var tipos = contexto.ART_MUS_FESTIVALES_TIPO_ORGANIZADOR
                        .Where(t => t.TIPO_ORGANIZADOR != null)
                        .Select(t => new SelectListItem
                        {
                            Value = t.ID.ToString(),
                            Text = t.TIPO_ORGANIZADOR
                        })
                        .ToList();

                    return Json(tipos, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                string ruta = Server.MapPath("/Log");
                Log.WriteLog(ruta, ex.ToString());
                return Json(new List<SelectListItem>(), JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// Obtiene la lista de naturalezas de entidad para el combo de entidades aliadas
        /// </summary>
        [HttpGet]
        public JsonResult ObtenerNaturalezasEntidad()
        {
            try
            {
                using (var contexto = new SM.SIPA.SIPAEntities())
                {
                    var naturalezas = contexto.ART_MUS_FESTIVALES_NATURALEZA_ENTIDAD
                        .Where(n => n.NATURALEZA != null)
                        .Select(n => new SelectListItem
                        {
                            Value = n.ID.ToString(),
                            Text = n.NATURALEZA
                        })
                        .ToList();

                    return Json(naturalezas, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                string ruta = Server.MapPath("/Log");
                Log.WriteLog(ruta, ex.ToString());
                return Json(new List<SelectListItem>(), JsonRequestBehavior.AllowGet);
            }
        }

        // ========================================
        // CONSULTA PÚBLICA DE FESTIVALES
        // ========================================

        /// <summary>
        /// Página pública de consulta de festivales con filtros
        /// </summary>
        [AllowAnonymous]
        public ActionResult ConsultaPublica(
            bool buscarPorMes = false,
            bool buscarPorFecha = false,
            string mesInicio = null,
            DateTime? fechaInicio = null,
            DateTime? fechaFin = null,
            string departamento = null,
            string municipio = null,
            string tipoIngreso = null,
            string tipo = null,
            string buscar = null,
            bool sinPublico = false,
            string territorios = null,
            string tipologias = null,
            string expresiones = null,
            bool esPartial = false)
        {
            try
            {
                // Crear ViewModel
                var model = new ConsultaPublicaFestivalesViewModel
                {
                    BuscarPorMes = buscarPorMes,
                    BuscarPorFecha = buscarPorFecha,
                    MesInicio = mesInicio,
                    FechaInicio = fechaInicio,
                    FechaFin = fechaFin,
                    Departamento = departamento,
                    Municipio = municipio,
                    TipoIngreso = tipoIngreso,
                    Tipo = tipo,
                    TextoBusqueda = buscar,
                    SinPublicoPresencial = sinPublico
                };

                // Cargar catálogos para los filtros
                model.TerritoriosSonoros = FestivalServicio.ObtenerTerritoriosSonoros()
                    .Select(t => new CatalogoItemDTO 
                    { 
                        Id = t.Id, 
                        Nombre = t.Nombre,
                        Seleccionado = false 
                    })
                    .ToList();

                model.Tipologias = FestivalServicio.ObtenerTipologias()
                    .Select(t => new CatalogoItemDTO 
                    { 
                        Id = t.Id, 
                        Nombre = t.Nombre,
                        Seleccionado = false 
                    })
                    .ToList();

                model.TiposExpresion = FestivalServicio.ObtenerExpresionesArtisticas()
                    .Select(e => new CatalogoItemDTO 
                    { 
                        Id = e.Id, 
                        Nombre = e.Nombre,
                        Seleccionado = false 
                    })
                    .ToList();

                // Cargar departamentos
                model.Departamentos = FestivalServicio.ObtenerDepartamentos()
                    .Select(d => new CatalogoItemDTO 
                    { 
                        Codigo = d.Codigo, 
                        Nombre = d.Nombre,
                        Seleccionado = false 
                    })
                    .ToList();

                // Cargar tipos de ingreso
                model.TiposIngreso = FestivalServicio.ObtenerTiposIngreso()
                    .Select(t => new CatalogoItemDTO 
                    { 
                        Id = t.Id, 
                        Nombre = t.Nombre,
                        Seleccionado = false 
                    })
                    .ToList();

                // Crear filtros de búsqueda
                var filtros = new SM.Datos.DTO.Festivales.ConsultaPublicaFiltrosDTO
                {
                    MesInicio = mesInicio,
                    FechaInicio = fechaInicio,
                    FechaFin = fechaFin,
                    Departamento = departamento,
                    Municipio = municipio,
                    TipoIngreso = tipoIngreso,
                    Tipo = tipo,
                    TextoBusqueda = buscar,
                    SinPublicoPresencial = sinPublico
                };

                // Parsear territorios seleccionados
                if (!string.IsNullOrEmpty(territorios))
                {
                    filtros.TerritoriosSeleccionados = territorios.Split(',')
                        .Select(t => int.TryParse(t, out int id) ? id : 0)
                        .Where(id => id > 0)
                        .ToList();
                }

                // Parsear tipologías seleccionadas
                if (!string.IsNullOrEmpty(tipologias))
                {
                    filtros.TipologiasSeleccionadas = tipologias.Split(',')
                        .Select(t => int.TryParse(t, out int id) ? id : 0)
                        .Where(id => id > 0)
                        .ToList();
                }

                // Parsear expresiones seleccionadas
                if (!string.IsNullOrEmpty(expresiones))
                {
                    filtros.ExpresionesSeleccionadas = expresiones.Split(',')
                        .Select(e => int.TryParse(e, out int id) ? id : 0)
                        .Where(id => id > 0)
                        .ToList();
                }

                // Buscar festivales
                var festivalesDTO = FestivalServicio.BuscarPublico(filtros);

                // Convertir a ViewModel
                model.Festivales = festivalesDTO.Select(f => new FestivalPublicoDTO
                {
                    Id = f.Id,
                    Nombre = f.Nombre,
                    FechaInicio = f.FechaInicio,
                    FechaFin = f.FechaFin,
                    Departamento = f.Departamento,
                    Municipio = f.Municipio,
                    Ubicacion = f.Ubicacion,
                    ImagenUrl = f.ImagenUrl,
                    Descripcion = f.Descripcion,
                    SinPublicoPresencial = f.SinPublicoPresencial,
                    VersionNumero = f.VersionNumero
                }).ToList();
                
                if (esPartial || Request.IsAjaxRequest())
                {
                    return PartialView("~/Views/Festivales/_ResultadosConsultaPublica.cshtml", model);
                }

                return View(model);
            }
            catch (Exception ex)
            {
                string ruta = Server.MapPath("/Log");
                Log.WriteLog(ruta, $"Error en ConsultaPublica: {ex.ToString()}");

                // Devolver vista con modelo vacío en caso de error
                if (esPartial || Request.IsAjaxRequest())
                {
                    return PartialView("~/Views/Festivales/_ResultadosConsultaPublica.cshtml", new ConsultaPublicaFestivalesViewModel());
                }
                return View(new ConsultaPublicaFestivalesViewModel());
            }
        }

        /// <summary>
        /// Búsqueda de festivales por AJAX - Devuelve solo el partial de resultados
        /// </summary>
        [AllowAnonymous]
        [HttpGet]
        public ActionResult BuscarFestivalesAjax(
            bool buscarPorMes = false,
            bool buscarPorFecha = false,
            string mesInicio = null,
            DateTime? fechaInicio = null,
            DateTime? fechaFin = null,
            string departamento = null,
            string municipio = null,
            string tipoIngreso = null,
            string tipo = null,
            string buscar = null,
            bool sinPublico = false,
            string territorios = null,
            string tipologias = null,
            string expresiones = null)
        {
            try
            {
                // Crear ViewModel
                var model = new ConsultaPublicaFestivalesViewModel();

                // Crear filtros de búsqueda
                var filtros = new SM.Datos.DTO.Festivales.ConsultaPublicaFiltrosDTO
                {
                    MesInicio = mesInicio,
                    FechaInicio = fechaInicio,
                    FechaFin = fechaFin,
                    Departamento = departamento,
                    Municipio = municipio,
                    TipoIngreso = tipoIngreso,
                    Tipo = tipo,
                    TextoBusqueda = buscar,
                    SinPublicoPresencial = sinPublico
                };

                // Parsear territorios seleccionados
                if (!string.IsNullOrEmpty(territorios))
                {
                    filtros.TerritoriosSeleccionados = territorios.Split(',')
                        .Select(t => int.TryParse(t, out int id) ? id : 0)
                        .Where(id => id > 0)
                        .ToList();
                }

                // Parsear tipologías seleccionadas
                if (!string.IsNullOrEmpty(tipologias))
                {
                    filtros.TipologiasSeleccionadas = tipologias.Split(',')
                        .Select(t => int.TryParse(t, out int id) ? id : 0)
                        .Where(id => id > 0)
                        .ToList();
                }

                // Parsear expresiones seleccionadas
                if (!string.IsNullOrEmpty(expresiones))
                {
                    filtros.ExpresionesSeleccionadas = expresiones.Split(',')
                        .Select(e => int.TryParse(e, out int id) ? id : 0)
                        .Where(id => id > 0)
                        .ToList();
                }

                // Buscar festivales
                var festivalesDTO = FestivalServicio.BuscarPublico(filtros);

                // Convertir a ViewModel
                model.Festivales = festivalesDTO.Select(f => new FestivalPublicoDTO
                {
                    Id = f.Id,
                    Nombre = f.Nombre,
                    FechaInicio = f.FechaInicio,
                    FechaFin = f.FechaFin,
                    Departamento = f.Departamento,
                    Municipio = f.Municipio,
                    Ubicacion = f.Ubicacion,
                    ImagenUrl = f.ImagenUrl,
                    Descripcion = f.Descripcion,
                    SinPublicoPresencial = f.SinPublicoPresencial,
                    VersionNumero = f.VersionNumero
                }).ToList();
                
                return PartialView("~/Views/Festivales/_ResultadosConsultaPublica.cshtml", model);
            }
            catch (Exception ex)
            {
                string ruta = Server.MapPath("/Log");
                Log.WriteLog(ruta, $"Error en BuscarFestivalesAjax: {ex.ToString()}");

                return PartialView("~/Views/Festivales/_ResultadosConsultaPublica.cshtml", new ConsultaPublicaFestivalesViewModel());
            }
        }

        /// <summary>
        /// Obtiene el detalle de un festival por su ID de versi&oacute;n (AJAX)
        /// </summary>
        [AllowAnonymous]
        [HttpGet]
        public JsonResult ObtenerDetalleFestival(int festivalId)
        {
            try
            {
                string ruta = Server.MapPath("/Log");
                Log.WriteLog(ruta, $"ObtenerDetalleFestival llamado con festivalId: {festivalId}");
                
                var detalle = FestivalServicio.ObtenerDetalleFestivalPublico(festivalId);
                
                if (detalle == null)
                {
                    Log.WriteLog(ruta, $"Festival con festivalId {festivalId} no encontrado en BD");
                    return Json(new { error = "Festival no encontrado" }, JsonRequestBehavior.AllowGet);
                }

                return Json(detalle, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                string ruta = Server.MapPath("/Log");
                Log.WriteLog(ruta, $"Error en ObtenerDetalleFestival: {ex.ToString()}");
                
                return Json(new { error = "Error al obtener detalle del festival" }, JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// Obtiene los municipios de un departamento para la consulta pública (AJAX)
        /// </summary>
        [AllowAnonymous]
        [HttpGet]
        public JsonResult ObtenerMunicipios(string codigoDepartamento)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(codigoDepartamento))
                {
                    return Json(new List<object>(), JsonRequestBehavior.AllowGet);
                }

                var municipios = FestivalServicio.ObtenerMunicipiosPorDepartamento(codigoDepartamento)
                    .Select(m => new 
                    { 
                        codigo = m.Codigo, 
                        nombre = m.Nombre 
                    })
                    .ToList();

                return Json(municipios, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                string ruta = Server.MapPath("/Log");
                Log.WriteLog(ruta, $"Error en ObtenerMunicipios: {ex.ToString()}");
                
                return Json(new { error = "Error al obtener municipios" }, JsonRequestBehavior.AllowGet);
            }
        }

        #region Helpers para Material Multimedia

        /// <summary>
        /// Guarda un archivo subido en la carpeta de material multimedia y retorna la ruta relativa
        /// </summary>
        /// <param name="archivo">Archivo subido</param>
        /// <param name="festivalId">ID del festival</param>
        /// <param name="versionId">ID de la versión (0 si es creación)</param>
        /// <param name="tipoArchivo">Tipo: Programa, Afiche, Logo</param>
        /// <returns>Ruta relativa del archivo guardado</returns>
        private string GuardarArchivoMultimedia(HttpPostedFileBase archivo, int festivalId, int versionId, string tipoArchivo)
        {
            if (archivo == null || archivo.ContentLength == 0)
                return null;

            try
            {
                // Validar extensión
                var extensionesPermitidas = new[] { ".pdf", ".jpg", ".jpeg", ".png" };
                var extension = System.IO.Path.GetExtension(archivo.FileName).ToLower();
                if (!extensionesPermitidas.Contains(extension))
                    throw new Exception($"Extensión {extension} no permitida. Solo se permiten: {string.Join(", ", extensionesPermitidas)}");

                // Construir carpeta base: ~/Uploads/Festivales/{FestivalId}/Versiones/{VersionId}/
                var carpetaBase = Server.MapPath("~/Uploads/Festivales");
                var carpetaFestival = System.IO.Path.Combine(carpetaBase, festivalId.ToString());
                var carpetaVersion = System.IO.Path.Combine(carpetaFestival, "Versiones", versionId > 0 ? versionId.ToString() : "Temp");

                // Crear carpetas si no existen
                if (!System.IO.Directory.Exists(carpetaVersion))
                    System.IO.Directory.CreateDirectory(carpetaVersion);

                // Nombre del archivo: {TipoArchivo}_{Timestamp}{Extension}
                var timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
                var nombreArchivo = $"{tipoArchivo}_{timestamp}{extension}";
                var rutaCompleta = System.IO.Path.Combine(carpetaVersion, nombreArchivo);

                // Guardar archivo
                archivo.SaveAs(rutaCompleta);

                // Retornar ruta relativa desde el root del sitio
                var rutaRelativa = $"/Uploads/Festivales/{festivalId}/Versiones/{(versionId > 0 ? versionId.ToString() : "Temp")}/{nombreArchivo}";
                return rutaRelativa;
            }
            catch (Exception ex)
            {
                string ruta = Server.MapPath("/Log");
                Log.WriteLog(ruta, $"Error al guardar archivo {tipoArchivo}: {ex.ToString()}");
                throw;
            }
        }

        #endregion

        #region Festivales para Aprobación (Solo Rol = 1)

        /// <summary>
        /// Verifica si el usuario actual tiene rol de administrador (RoleId = 1)
        /// </summary>
        private bool EsAdministrador()
        {
            try
            {
                if (string.IsNullOrEmpty(UsuaroId))
                    return false;

                decimal userId = Convert.ToDecimal(UsuaroId);
                var roles = SM.Datos.Perfiles.ServicioPerfil.obtenerIdRol(userId);
                
                // Verificar si tiene rol = 1 (Administrador)
                return roles != null && roles.Contains(1);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Página de listado de festivales pendientes de aprobación (solo para rol = 1)
        /// </summary>
        public ActionResult FestivalesParaAprobacion()
        {
            try
            {
                // Verificar que el usuario tenga rol de administrador
                if (!EsAdministrador())
                {
                    return RedirectToAction("Index", "Home");
                }

                var vm = new FestivalesAprobacionViewModel
                {
                    FiltroTexto = "",
                    Festivales = new List<FestivalAprobacionItemViewModel>(),
                    PaginaActual = 1,
                    TotalPaginas = 1
                };

                return View(vm);
            }
            catch (Exception ex)
            {
                string ruta = Server.MapPath("/Log");
                Log.WriteLog(ruta, $"Error en FestivalesParaAprobacion: {ex.ToString()}");
                return RedirectToAction("Listado");
            }
        }

        /// <summary>
        /// Partial view con grilla DevExpress de festivales pendientes de aprobación
        /// </summary>
        [ValidateInput(false)]
        [ChildActionOnly]
        public ActionResult GridFestivalesAprobacionPartial(string filtroTexto = null)
        {
            var model = new List<FestivalAprobacionItemViewModel>();

            try
            {
                using (var db = new SIPAEntities())
                {
                    // Consultar versiones con estado "Registrado" (ID_ESTADO = 2 del festival padre)
                    // que tengan datos completos (enviados con "Enviar Solicitud de Registro")
                    var query = db.ART_MUS_FESTIVALES_VERSION
                        .Include("ART_MUS_FESTIVALES")
                        .Include("ART_MUS_FESTIVALES.ART_MUSICA_USUARIO")
                        .Include("ART_MUS_LOCALIZACIONXVERSION")
                        .Include("ART_MUS_LOCALIZACIONXVERSION.BAS_ZONAS_GEOGRAFICAS")
                        .Where(v => v.ART_MUS_FESTIVALES.ID_ESTADO == 2) // Estado "Registrado" - pendiente de aprobación
                        .AsQueryable();

                    // Aplicar filtro de texto si existe
                    if (!string.IsNullOrWhiteSpace(filtroTexto))
                    {
                        var f = filtroTexto.Trim().ToLower();
                        query = query.Where(v =>
                            (v.ART_MUS_FESTIVALES.NOMBRE_FESTIVAL != null && v.ART_MUS_FESTIVALES.NOMBRE_FESTIVAL.ToLower().Contains(f)) ||
                            (v.NOMBRE_VERSION != null && v.NOMBRE_VERSION.ToLower().Contains(f)) ||
                            (v.DIRECTOR != null && v.DIRECTOR.ToLower().Contains(f)) ||
                            (v.CORREO_CONTACTO != null && v.CORREO_CONTACTO.ToLower().Contains(f)));
                    }

                    var versiones = query.OrderByDescending(v => v.ID).ToList();

                    foreach (var v in versiones)
                    {
                        // Obtener departamento y municipio de la primera localización
                        string departamento = "";
                        string municipio = "";

                        var localizacion = v.ART_MUS_LOCALIZACIONXVERSION.FirstOrDefault();
                        if (localizacion != null && localizacion.BAS_ZONAS_GEOGRAFICAS != null)
                        {
                            var zona = localizacion.BAS_ZONAS_GEOGRAFICAS;
                            if (zona.ZON_PADRE_ID == null)
                            {
                                departamento = zona.ZON_NOMBRE ?? "";
                            }
                            else
                            {
                                municipio = zona.ZON_NOMBRE ?? "";
                                var zonaPadre = db.BAS_ZONAS_GEOGRAFICAS.FirstOrDefault(z => z.ZON_ID == zona.ZON_PADRE_ID);
                                departamento = zonaPadre?.ZON_NOMBRE ?? "";
                            }
                        }

                        // Construir nombre del usuario que registró
                        string nombreUsuario = "";
                        if (v.ART_MUS_FESTIVALES != null && v.ART_MUS_FESTIVALES.ART_MUSICA_USUARIO != null)
                        {
                            var u = v.ART_MUS_FESTIVALES.ART_MUSICA_USUARIO;
                            nombreUsuario = string.Join(" ", new[] { u.PrimerNombre, u.SegundoNombre, u.PrimerApellido, u.SegundoApellido }
                                .Where(n => !string.IsNullOrWhiteSpace(n)));
                        }

                        model.Add(new FestivalAprobacionItemViewModel
                        {
                            FestivalId = v.ID_FESTIVAL ?? 0,
                            VersionId = v.ID,
                            NombreFestival = v.ART_MUS_FESTIVALES?.NOMBRE_FESTIVAL ?? "",
                            NombreVersion = v.NOMBRE_VERSION ?? "",
                            NumeroVersion = v.VERSION_FESTIVAL,
                            Departamento = departamento,
                            Municipio = municipio,
                            Director = v.DIRECTOR ?? "",
                            CorreoContacto = v.CORREO_CONTACTO ?? "",
                            FechaSolicitud = null,
                            Estado = "Pendiente de Aprobaci&oacute;n",
                            NombreUsuarioRegistro = nombreUsuario
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                string ruta = Server.MapPath("/Log");
                Log.WriteLog(ruta, $"Error en GridFestivalesAprobacionPartial: {ex.ToString()}");
            }

            ViewBag.FiltroTexto = filtroTexto;
            return PartialView("~/Views/Festivales/_GridFestivalesAprobacionPartial.cshtml", model);
        }

        /// <summary>
        /// Partial view para callbacks de la grilla DevExpress (paginación, filtros, etc.)
        /// </summary>
        [ValidateInput(false)]
        public ActionResult GridFestivalesAprobacionPartialCallback(string filtroTexto = null)
        {
            var model = new List<FestivalAprobacionItemViewModel>();

            try
            {
                using (var db = new SIPAEntities())
                {
                    var query = db.ART_MUS_FESTIVALES_VERSION
                        .Include("ART_MUS_FESTIVALES")
                        .Include("ART_MUS_FESTIVALES.ART_MUSICA_USUARIO")
                        .Include("ART_MUS_LOCALIZACIONXVERSION")
                        .Include("ART_MUS_LOCALIZACIONXVERSION.BAS_ZONAS_GEOGRAFICAS")
                        .Where(v => v.ART_MUS_FESTIVALES.ID_ESTADO == 2)
                        .AsQueryable();

                    if (!string.IsNullOrWhiteSpace(filtroTexto))
                    {
                        var f = filtroTexto.Trim().ToLower();
                        query = query.Where(v =>
                            (v.ART_MUS_FESTIVALES.NOMBRE_FESTIVAL != null && v.ART_MUS_FESTIVALES.NOMBRE_FESTIVAL.ToLower().Contains(f)) ||
                            (v.NOMBRE_VERSION != null && v.NOMBRE_VERSION.ToLower().Contains(f)) ||
                            (v.DIRECTOR != null && v.DIRECTOR.ToLower().Contains(f)) ||
                            (v.CORREO_CONTACTO != null && v.CORREO_CONTACTO.ToLower().Contains(f)));
                    }

                    var versiones = query.OrderByDescending(v => v.ID).ToList();

                    foreach (var v in versiones)
                    {
                        string departamento = "";
                        string municipio = "";

                        var localizacion = v.ART_MUS_LOCALIZACIONXVERSION.FirstOrDefault();
                        if (localizacion != null && localizacion.BAS_ZONAS_GEOGRAFICAS != null)
                        {
                            var zona = localizacion.BAS_ZONAS_GEOGRAFICAS;
                            if (zona.ZON_PADRE_ID == null)
                            {
                                departamento = zona.ZON_NOMBRE ?? "";
                            }
                            else
                            {
                                municipio = zona.ZON_NOMBRE ?? "";
                                var zonaPadre = db.BAS_ZONAS_GEOGRAFICAS.FirstOrDefault(z => z.ZON_ID == zona.ZON_PADRE_ID);
                                departamento = zonaPadre?.ZON_NOMBRE ?? "";
                            }
                        }

                        string nombreUsuario = "";
                        if (v.ART_MUS_FESTIVALES != null && v.ART_MUS_FESTIVALES.ART_MUSICA_USUARIO != null)
                        {
                            var u = v.ART_MUS_FESTIVALES.ART_MUSICA_USUARIO;
                            nombreUsuario = string.Join(" ", new[] { u.PrimerNombre, u.SegundoNombre, u.PrimerApellido, u.SegundoApellido }
                                .Where(n => !string.IsNullOrWhiteSpace(n)));
                        }

                        model.Add(new FestivalAprobacionItemViewModel
                        {
                            FestivalId = v.ID_FESTIVAL ?? 0,
                            VersionId = v.ID,
                            NombreFestival = v.ART_MUS_FESTIVALES?.NOMBRE_FESTIVAL ?? "",
                            NombreVersion = v.NOMBRE_VERSION ?? "",
                            NumeroVersion = v.VERSION_FESTIVAL,
                            Departamento = departamento,
                            Municipio = municipio,
                            Director = v.DIRECTOR ?? "",
                            CorreoContacto = v.CORREO_CONTACTO ?? "",
                            FechaSolicitud = null,
                            Estado = "Pendiente de Aprobaci&oacute;n",
                            NombreUsuarioRegistro = nombreUsuario
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                string ruta = Server.MapPath("/Log");
                Log.WriteLog(ruta, $"Error en GridFestivalesAprobacionPartialCallback: {ex.ToString()}");
            }

            ViewBag.FiltroTexto = filtroTexto;
            return PartialView("~/Views/Festivales/_GridFestivalesAprobacionPartial.cshtml", model);
        }

        /// <summary>
        /// Verifica si el usuario actual es administrador (para uso en vistas)
        /// </summary>
        [HttpGet]
        public JsonResult VerificarEsAdministrador()
        {
            return Json(new { esAdmin = EsAdministrador() }, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}