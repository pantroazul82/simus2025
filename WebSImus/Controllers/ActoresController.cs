using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSImus.Models;
using SM.LibreriaComun.DTO;
using WebSImus.Translator;
using SM.Aplicacion.Basicas;
using SM.Utilidades.Log;
using System.Web.Script.Serialization;
using PagedList;
using SM.Aplicacion.Agrupacion;
using SM.Aplicacion.Servicios;

namespace WebSImus.Controllers
{
    [HandleError()]
    public class ActoresController : Controller
    {
        private string strFichaEscenario = "FichaEscenario";
        private string strFichaEvento = "FichaEvento";
        // GET: Actores


        #region Agentes
        public ActionResult AgenteDepartamento(string Id, string Tipo, int? page)
        {
            var listResultado = new List<ActoresHomeModels>();
            var listado = new List<ActorHomeDataDTO>();
            listado = ActoresNeg.ConsultarActorHomePorDepartamento(Id);
            if (!String.IsNullOrEmpty(Tipo))
            {
                int tipoId = Convert.ToInt32(Tipo);
                listado = (from l in listado where l.TipoId == tipoId select l).ToList();
                ViewBag.tipoAgrupacionId = Tipo;
            }
            listResultado = TranslatorHomeActores.AgentesHome(listado);
            ViewBag.CodDepto = Id;
            ViewBag.CantidadRegistros = listResultado.Count;
            var model = from l in listResultado select l;
            int pageSize = 12;
            int pageNumber = (page ?? 1);
            return PartialView("_PartialResultadoAgente", model.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult AgenteMunicipio(string Id, string Tipo, int? page)
        {
            var listResultado = new List<ActoresHomeModels>();
            var listado = new List<ActorHomeDataDTO>();
            listado = ActoresNeg.ConsultarActorHomePorMunicipio(Id);
            if (!String.IsNullOrEmpty(Tipo))
            {
                int tipoId = Convert.ToInt32(Tipo);
                listado = (from l in listado where l.TipoId == tipoId select l).ToList();
                ViewBag.tipoAgrupacionId = Tipo;
            }
            listResultado = TranslatorHomeActores.AgentesHome(listado);
            ViewBag.codMunicipio = Id;
            ViewBag.CantidadRegistros = listResultado.Count;
            var model = from l in listResultado select l;
            int pageSize = 12;
            int pageNumber = (page ?? 1);
            return PartialView("_PartialResultadoAgente", model.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult AgenteTipo(string Id, string codDepto, string codMunicipio, int? page)
        {
            var listResultado = new List<ActoresHomeModels>();
            var listado = new List<ActorHomeDataDTO>();
            if (String.IsNullOrEmpty(codDepto) && String.IsNullOrEmpty(codMunicipio))
                listado = ActoresNeg.ConsultarActorHomePorTodos();
            else if (!String.IsNullOrEmpty(codDepto))
            {
                listado = ActoresNeg.ConsultarActorHomePorDepartamento(codDepto);
                ViewBag.CodDepto = codDepto;
            }
            else if (!String.IsNullOrEmpty(codMunicipio))
            {
                listado = ActoresNeg.ConsultarActorHomePorMunicipio(codMunicipio);
                ViewBag.codMunicipio = codMunicipio;
            }

            if (!String.IsNullOrEmpty(Id))
            {
                int tipoId = Convert.ToInt32(Id);
                listado = (from l in listado where l.TipoId == tipoId select l).ToList();
                ViewBag.tipoAgrupacionId = Id;
            }
            listResultado = TranslatorHomeActores.AgentesHome(listado);
            ViewBag.CantidadRegistros = listResultado.Count;
            var model = from l in listResultado select l;
            int pageSize = 12;
            int pageNumber = (page ?? 1);
            return PartialView("_PartialResultadoAgente", model.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult CargarTodoAgente(int? page)
        {
            var listResultado = new List<ActoresHomeModels>();
            var listado = new List<ActorHomeDataDTO>();
            listado = ActoresNeg.ConsultarActorHomePorTodos();

            listResultado = TranslatorHomeActores.AgentesHome(listado);
            ViewBag.codMunicipio = "";
            ViewBag.CantidadRegistros = listResultado.Count;
            var model = from l in listResultado select l;
            int pageSize = 12;
            int pageNumber = (page ?? 1);
            return PartialView("_PartialResultadoAgente", model.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Agentes(string codDepto, string codMunicipio, string tipo, int? page)
        {

            var listResultado = new List<ActoresHomeModels>();
            var listado = new List<ActorHomeDataDTO>();
            if (String.IsNullOrEmpty(codDepto) && String.IsNullOrEmpty(codMunicipio))
                listado = ActoresNeg.ConsultarActorHomePorTodos();
            else if (!String.IsNullOrEmpty(codDepto))
            {
                listado = ActoresNeg.ConsultarActorHomePorDepartamento(codDepto);
                ViewBag.CodDepto = codDepto;
            }
            else if (!String.IsNullOrEmpty(codMunicipio))
            {
                listado = ActoresNeg.ConsultarActorHomePorMunicipio(codMunicipio);
                ViewBag.codMunicipio = codMunicipio;
            }

            if (!String.IsNullOrEmpty(tipo))
            {
                int tipoId = Convert.ToInt32(tipo);
                listado = (from l in listado where l.TipoId == tipoId select l).ToList();
                ViewBag.tipoAgrupacionId = tipo;
            }
            listResultado = TranslatorHomeActores.AgentesHome(listado);
            ViewBag.CantidadRegistros = listResultado.Count;
            var model = from l in listResultado select l;
            int pageSize = 12;
            int pageNumber = (page ?? 1);
            if (page == null)
            {
                List<BasicaDTO> objMunicipios = new List<BasicaDTO>();
                List<BasicaDTO> objDepartamentos = ZonaGeograficasLogica.ConsultarDepartamentos();
                List<BasicaDTO> objTipo = CaracterizacionMusicalNeg.ConsultarTipoAgrupacion();
                ViewBag.departamentos = new SelectList(objDepartamentos, "value", "text");
                ViewBag.municipios = new SelectList(objMunicipios, "value", "text");
                ViewBag.tipo = new SelectList(objTipo, "value", "text");
                return View(model.ToPagedList(pageNumber, pageSize));
            }
            else
                return PartialView("_PartialResultadoAgente", model.ToPagedList(pageNumber, pageSize));
        }
        #endregion

        #region Entidades
        public ActionResult EntidadDepartamento(string Id, string Tipo, int? page)
        {
            var listResultado = new List<ActoresHomeModels>();
            var listado = new List<ActorHomeDataDTO>();
            listado = ActoresNeg.ConsultarActorHomePorDepartamento(Id, "Entidad");
            if (!String.IsNullOrEmpty(Tipo))
            {
                int tipoId = Convert.ToInt32(Tipo);
                listado = (from l in listado where l.TipoId == tipoId select l).ToList();
                ViewBag.tipoAgrupacionId = Tipo;
            }
            listResultado = TranslatorHomeActores.EntidadHome(listado);
            ViewBag.CodDepto = Id;
            ViewBag.CantidadRegistros = listResultado.Count;
            var model = from l in listResultado select l;
            int pageSize = 12;
            int pageNumber = (page ?? 1);
            return PartialView("_PartialResultadoEntidad", model.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult EntidadMunicipio(string Id, string Tipo, int? page)
        {
            var listResultado = new List<ActoresHomeModels>();
            var listado = new List<ActorHomeDataDTO>();
            listado = ActoresNeg.ConsultarActorHomePorMunicipio(Id, "Entidad");
            if (!String.IsNullOrEmpty(Tipo))
            {
                int tipoId = Convert.ToInt32(Tipo);
                listado = (from l in listado where l.TipoId == tipoId select l).ToList();
                ViewBag.tipoAgrupacionId = Tipo;
            }
            listResultado = TranslatorHomeActores.EntidadHome(listado);
            ViewBag.codMunicipio = Id;
            ViewBag.CantidadRegistros = listResultado.Count;
            var model = from l in listResultado select l;
            int pageSize = 12;
            int pageNumber = (page ?? 1);
            return PartialView("_PartialResultadoEntidad", model.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult EntidadTipo(string Id, string codDepto, string codMunicipio, int? page)
        {
            string strActor = "Entidad";
            var listResultado = new List<ActoresHomeModels>();
            var listado = new List<ActorHomeDataDTO>();
            if (String.IsNullOrEmpty(codDepto) && String.IsNullOrEmpty(codMunicipio))
                listado = ActoresNeg.ConsultarActorHomePorTodos(strActor);
            else if (!String.IsNullOrEmpty(codDepto))
            {
                listado = ActoresNeg.ConsultarActorHomePorDepartamento(codDepto, strActor);
                ViewBag.CodDepto = codDepto;
            }
            else if (!String.IsNullOrEmpty(codMunicipio))
            {
                listado = ActoresNeg.ConsultarActorHomePorMunicipio(codMunicipio, strActor);
                ViewBag.codMunicipio = codMunicipio;
            }

            if (!String.IsNullOrEmpty(Id))
            {
                int tipoId = Convert.ToInt32(Id);
                listado = (from l in listado where l.TipoId == tipoId select l).ToList();
                ViewBag.tipoAgrupacionId = Id;
            }
            listResultado = TranslatorHomeActores.EntidadHome(listado);
            ViewBag.CantidadRegistros = listResultado.Count;
            var model = from l in listResultado select l;
            int pageSize = 12;
            int pageNumber = (page ?? 1);
            return PartialView("_PartialResultadoEntidad", model.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult CargarTodoEntidad(int? page)
        {
            string strActor = "Entidad";
            var listResultado = new List<ActoresHomeModels>();
            var listado = new List<ActorHomeDataDTO>();
            listado = ActoresNeg.ConsultarActorHomePorTodos(strActor);

            listResultado = TranslatorHomeActores.EntidadHome(listado);
            ViewBag.codMunicipio = "";
            ViewBag.CantidadRegistros = listResultado.Count;
            var model = from l in listResultado select l;
            int pageSize = 12;
            int pageNumber = (page ?? 1);
            return PartialView("_PartialResultadoEntidad", model.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Entidad(string codDepto, string codMunicipio, string tipo, int? page)
        {
            string strActor = "Entidad";
            var listResultado = new List<ActoresHomeModels>();
            var listado = new List<ActorHomeDataDTO>();
            if (String.IsNullOrEmpty(codDepto) && String.IsNullOrEmpty(codMunicipio))
                listado = ActoresNeg.ConsultarActorHomePorTodos(strActor);
            else if (!String.IsNullOrEmpty(codDepto))
            {
                listado = ActoresNeg.ConsultarActorHomePorDepartamento(codDepto, strActor);
                ViewBag.CodDepto = codDepto;
            }
            else if (!String.IsNullOrEmpty(codMunicipio))
            {
                listado = ActoresNeg.ConsultarActorHomePorMunicipio(codMunicipio, strActor);
                ViewBag.codMunicipio = codMunicipio;
            }

            if (!String.IsNullOrEmpty(tipo))
            {
                int tipoId = Convert.ToInt32(tipo);
                listado = (from l in listado where l.TipoId == tipoId select l).ToList();
                ViewBag.tipoAgrupacionId = tipo;
            }
            listResultado = TranslatorHomeActores.EntidadHome(listado);
            ViewBag.CantidadRegistros = listResultado.Count;
            var model = from l in listResultado select l;
            int pageSize = 12;
            int pageNumber = (page ?? 1);
            if (page == null)
            {
                List<BasicaDTO> objMunicipios = new List<BasicaDTO>();
                List<BasicaDTO> objDepartamentos = ZonaGeograficasLogica.ConsultarDepartamentos();
                ViewBag.departamentos = new SelectList(objDepartamentos, "value", "text");
                ViewBag.municipios = new SelectList(objMunicipios, "value", "text");
                return View(model.ToPagedList(pageNumber, pageSize));
            }
            else
                return PartialView("_PartialResultadoEntidad", model.ToPagedList(pageNumber, pageSize));
        }
        #endregion

        #region Escuelas
        public ActionResult EscuelasDepartamento(string Id, string Tipo, int? page)
        {
            var listResultado = new List<ActoresHomeModels>();
            var listado = new List<ActorHomeDataDTO>();
            listado = ActoresNeg.ConsultarActorHomePorDepartamento(Id, "Escuelas");
            if (!String.IsNullOrEmpty(Tipo))
            {
                int tipoId = Convert.ToInt32(Tipo);
                listado = (from l in listado where l.TipoId == tipoId select l).ToList();
                ViewBag.tipoAgrupacionId = Tipo;
            }
            listResultado = TranslatorHomeActores.EscuelasHome(listado);
            ViewBag.CodDepto = Id;
            ViewBag.CantidadRegistros = listResultado.Count;
            var model = from l in listResultado select l;
            int pageSize = 12;
            int pageNumber = (page ?? 1);
            return PartialView("_PartialResultadoEscuelas", model.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult EscuelasMunicipio(string Id, string Tipo, int? page)
        {
            var listResultado = new List<ActoresHomeModels>();
            var listado = new List<ActorHomeDataDTO>();
            listado = ActoresNeg.ConsultarActorHomePorMunicipio(Id, "Escuelas");
            if (!String.IsNullOrEmpty(Tipo))
            {
                int tipoId = Convert.ToInt32(Tipo);
                listado = (from l in listado where l.TipoId == tipoId select l).ToList();
                ViewBag.tipoAgrupacionId = Tipo;
            }
            listResultado = TranslatorHomeActores.EscuelasHome(listado);
            ViewBag.codMunicipio = Id;
            ViewBag.CantidadRegistros = listResultado.Count;
            var model = from l in listResultado select l;
            int pageSize = 12;
            int pageNumber = (page ?? 1);
            return PartialView("_PartialResultadoEscuelas", model.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult EscuelasTipo(string Id, string codDepto, string codMunicipio, int? page)
        {
            string strActor = "Escuelas";
            var listResultado = new List<ActoresHomeModels>();
            var listado = new List<ActorHomeDataDTO>();
            if (String.IsNullOrEmpty(codDepto) && String.IsNullOrEmpty(codMunicipio) && !String.IsNullOrEmpty(Id))
            {
                listado = ActoresNeg.ConsultarEscuelasHomePorTipo(Convert.ToInt32(Id));
                ViewBag.tipoAgrupacionId = Id;
            }
            else if (!String.IsNullOrEmpty(codMunicipio))
            {
                if (codMunicipio.Length == 5)
                {
                    listado = ActoresNeg.ConsultarActorHomePorMunicipio(codMunicipio, strActor);
                    ViewBag.codMunicipio = codMunicipio;
                }
                else if (!String.IsNullOrEmpty(codDepto))
                {
                    listado = ActoresNeg.ConsultarActorHomePorDepartamento(codDepto, strActor);
                    ViewBag.CodDepto = codDepto;
                }
                else if (!String.IsNullOrEmpty(Id))
                {
                    listado = ActoresNeg.ConsultarEscuelasHomePorTipo(Convert.ToInt32(Id));
                    ViewBag.tipoAgrupacionId = Id;
                }
            }
            else if (!String.IsNullOrEmpty(codDepto))
            {
                listado = ActoresNeg.ConsultarActorHomePorDepartamento(codDepto, strActor);
                ViewBag.CodDepto = codDepto;
            }


            if (!String.IsNullOrEmpty(codDepto) || !String.IsNullOrEmpty(codMunicipio))
            {
                int tipoId = Convert.ToInt32(Id);
                listado = (from l in listado where l.TipoId == tipoId select l).ToList();
                ViewBag.tipoAgrupacionId = Id;
            }
            listResultado = TranslatorHomeActores.EscuelasHome(listado);
            ViewBag.CantidadRegistros = listResultado.Count;
            var model = from l in listResultado select l;
            int pageSize = 12;
            int pageNumber = (page ?? 1);
            return PartialView("_PartialResultadoEscuelas", model.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult CargarTodoEscuelas(int? page)
        {
            string strActor = "Escuelas";
            var listResultado = new List<ActoresHomeModels>();
            var listado = new List<ActorHomeDataDTO>();
            listado = ActoresNeg.ConsultarActorHomePorTodos(strActor);

            listResultado = TranslatorHomeActores.EscuelasHome(listado);
            ViewBag.codMunicipio = "";
            ViewBag.CantidadRegistros = listResultado.Count;
            var model = from l in listResultado select l;
            int pageSize = 12;
            int pageNumber = (page ?? 1);
            return PartialView("_PartialResultadoEscuelas", model.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Escuelas(string codDepto, string codMunicipio, string tipo, int? page)
        {
            string strActor = "Escuelas";
            var listResultado = new List<ActoresHomeModels>();
            var listado = new List<ActorHomeDataDTO>();
            int cantidad = 0;
            if (String.IsNullOrEmpty(codDepto) && String.IsNullOrEmpty(codMunicipio) && String.IsNullOrEmpty(tipo))
            {
                listado = ActoresNeg.ConsultarActorHomePorTodos(strActor);
                cantidad = SM.Aplicacion.Reporte.ServicioReporteNeg.obtenerCantidadEscuelas();
            }
            else if (!String.IsNullOrEmpty(codMunicipio))
            {
                if (codMunicipio.Length == 5)
                {
                    listado = ActoresNeg.ConsultarActorHomePorMunicipio(codMunicipio, strActor);
                    cantidad = listado.Count();
                    ViewBag.codMunicipio = codMunicipio;
                }
                else if (!String.IsNullOrEmpty(codDepto))
                {
                    listado = ActoresNeg.ConsultarActorHomePorDepartamento(codDepto, strActor);
                    cantidad = listado.Count();
                    ViewBag.CodDepto = codDepto;
                }
            }
            else if (!String.IsNullOrEmpty(codDepto))
            {
                listado = ActoresNeg.ConsultarActorHomePorDepartamento(codDepto, strActor);
                cantidad = listado.Count();
                ViewBag.CodDepto = codDepto;
            }
            else if (String.IsNullOrEmpty(codDepto) && String.IsNullOrEmpty(codMunicipio) && !String.IsNullOrEmpty(tipo))
            {
                listado = ActoresNeg.ConsultarEscuelasHomePorTipo(Convert.ToInt32(tipo));
                cantidad = listado.Count();
                ViewBag.tipoAgrupacionId = tipo;
            }



            if ((!String.IsNullOrEmpty(codDepto) || !String.IsNullOrEmpty(codMunicipio)) && !String.IsNullOrEmpty(tipo))
            {
                int tipoId = Convert.ToInt32(tipo);
                listado = (from l in listado where l.TipoId == tipoId select l).ToList();
                cantidad = listado.Count();
                ViewBag.tipoAgrupacionId = tipo;
            }
            listResultado = TranslatorHomeActores.EscuelasHome(listado);
            ViewBag.CantidadRegistros = cantidad;
            var model = from l in listResultado select l;
            int pageSize = 12;
            int pageNumber = (page ?? 1);
            if (page == null)
            {
                List<BasicaDTO> objMunicipios = new List<BasicaDTO>();
                List<BasicaDTO> objDepartamentos = ZonaGeograficasLogica.ConsultarDepartamentos();
                List<BasicaDTO> objTipo = ParametrosLogica.ConsultarTipoEscuelasMusica();
                ViewBag.departamentos = new SelectList(objDepartamentos, "value", "text");
                ViewBag.municipios = new SelectList(objMunicipios, "value", "text");
                ViewBag.tipo = new SelectList(objTipo, "value", "text");
                return View(model.ToPagedList(pageNumber, pageSize));
            }
            else
                return PartialView("_PartialResultadoEscuelas", model.ToPagedList(pageNumber, pageSize));
        }
        #endregion

        #region EscenariosEscenicos

        public ActionResult FichaEscenario(int Id)
        {
            var model = new EscenariohomeDTO();
            model = SM.Aplicacion.Entidades.EsnecariosNeg.ConsultarEscenarioFichaId(Id);
            return View(model);
        }

        public ActionResult FichaEvento(int Id)
        {
            var model = new EventosPeriodicosHomeDTO();
            model = SM.Aplicacion.Eventos.EventosPeriodicosNeg.ConsultarEventosFichaId(Id);
            return View(model);

        }
        public ActionResult EscenarioDepartamento(string Id, string Tipo, int? page)
        {
            var listResultado = new List<ActoresHomeModels>();
            var listado = new List<ActorHomeDataDTO>();
            listado = ActoresNeg.ConsultarEscenarioPorDepartamento(Id);
            if (!String.IsNullOrEmpty(Tipo))
            {
                int clasificacionId = Convert.ToInt32(Tipo);
                listado = (from l in listado where l.TipoId == clasificacionId select l).ToList();
                ViewBag.tipoAgrupacionId = Tipo;
            }
            listResultado = TranslatorHomeActores.EscenariosHome(listado, strFichaEscenario);
            ViewBag.CodDepto = Id;
            ViewBag.CantidadRegistros = listResultado.Count;
            var model = from l in listResultado select l;
            int pageSize = 9;
            int pageNumber = (page ?? 1);
            return PartialView("_PartialResultadoEscenarios", model.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult EscenarioMunicipio(string Id, string Tipo, int? page)
        {
            var listResultado = new List<ActoresHomeModels>();
            var listado = new List<ActorHomeDataDTO>();
            listado = ActoresNeg.ConsultarEscenarioPorMunicipio(Id);
            if (!String.IsNullOrEmpty(Tipo))
            {
                int clasificacionId = Convert.ToInt32(Tipo);
                listado = (from l in listado where l.TipoId == clasificacionId select l).ToList();
                ViewBag.tipoAgrupacionId = Tipo;
            }
            listResultado = TranslatorHomeActores.EscenariosHome(listado, strFichaEscenario);
            ViewBag.codMunicipio = Id;
            ViewBag.CantidadRegistros = listResultado.Count;
            var model = from l in listResultado select l;
            int pageSize = 9;
            int pageNumber = (page ?? 1);
            return PartialView("_PartialResultadoEscenarios", model.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult EscenarioTipo(string Id, string codDepto, string codMunicipio, int? page)
        {
            var listResultado = new List<ActoresHomeModels>();
            var listado = new List<ActorHomeDataDTO>();

            if (String.IsNullOrEmpty(codDepto) && String.IsNullOrEmpty(codMunicipio) && !String.IsNullOrEmpty(Id))
                listado = ActoresNeg.ConsultarEscenarioTodo();
            else if (!String.IsNullOrEmpty(codMunicipio))
            {
                if (codMunicipio.Length == 5)
                {
                    listado = ActoresNeg.ConsultarEscenarioPorMunicipio(codMunicipio);
                    ViewBag.codMunicipio = codMunicipio;
                }
                else if (!String.IsNullOrEmpty(codDepto))
                {
                    listado = ActoresNeg.ConsultarEscenarioPorDepartamento(codDepto);
                    ViewBag.CodDepto = codDepto;
                }
                else if (!String.IsNullOrEmpty(Id))
                {
                    listado = ActoresNeg.ConsultarEscenarioTodo();
                    ViewBag.tipoAgrupacionId = Id;
                }
            }
            else if (!String.IsNullOrEmpty(codDepto))
            {
                listado = ActoresNeg.ConsultarEscenarioPorDepartamento(codDepto);
                ViewBag.CodDepto = codDepto;
            }

            if (!String.IsNullOrEmpty(Id))
            {
                int clasificacionId = Convert.ToInt32(Id);
                listado = (from l in listado where l.TipoId == clasificacionId select l).ToList();
                ViewBag.tipoAgrupacionId = Id;
            }
            listResultado = TranslatorHomeActores.EscenariosHome(listado, strFichaEscenario);
            ViewBag.CantidadRegistros = listResultado.Count;
            var model = from l in listResultado select l;
            int pageSize = 9;
            int pageNumber = (page ?? 1);
            return PartialView("_PartialResultadoEscenarios", model.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult CargarTodoEscenarios(int? page)
        {
            var listResultado = new List<ActoresHomeModels>();
            var listado = new List<ActorHomeDataDTO>();

            listado = ActoresNeg.ConsultarEscenarioTodo();

            listResultado = TranslatorHomeActores.EscenariosHome(listado, strFichaEscenario);
            ViewBag.codMunicipio = "";
            ViewBag.CantidadRegistros = listResultado.Count;
            var model = from l in listResultado select l;
            int pageSize = 9;
            int pageNumber = (page ?? 1);
            return PartialView("_PartialResultadoEscenarios", model.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Escenarios(string codDepto, string codMunicipio, string tipo, int? page)
        {

            var listResultado = new List<ActoresHomeModels>();
            var listado = new List<ActorHomeDataDTO>();
            if (String.IsNullOrEmpty(codDepto) && String.IsNullOrEmpty(codMunicipio) && String.IsNullOrEmpty(tipo))
                listado = ActoresNeg.ConsultarEscenarioTodo();
            else if (!String.IsNullOrEmpty(codMunicipio))
            {
                if (codMunicipio.Length == 5)
                {
                    listado = ActoresNeg.ConsultarEscenarioPorMunicipio(codMunicipio);
                    ViewBag.codMunicipio = codMunicipio;
                }
                else if (!String.IsNullOrEmpty(codDepto))
                {
                    listado = ActoresNeg.ConsultarEscenarioPorDepartamento(codDepto);
                    ViewBag.CodDepto = codDepto;
                }
                else if (!String.IsNullOrEmpty(tipo))
                {
                    listado = ActoresNeg.ConsultarEscenarioTodo();
                    ViewBag.tipoAgrupacionId = tipo;
                }
            }
            else if (!String.IsNullOrEmpty(codDepto))
            {
                listado = ActoresNeg.ConsultarEscenarioPorDepartamento(codDepto);
                ViewBag.CodDepto = codDepto;
            }


            if (!String.IsNullOrEmpty(tipo))
            {
                int clasificacionId = Convert.ToInt32(tipo);
                listado = (from l in listado where l.TipoId == clasificacionId select l).ToList();
                ViewBag.tipoAgrupacionId = tipo;
            }

            listResultado = TranslatorHomeActores.EscenariosHome(listado, strFichaEscenario);
            ViewBag.CantidadRegistros = listResultado.Count;
            var model = from l in listResultado select l;
            int pageSize = 9;
            int pageNumber = (page ?? 1);
            if (page == null)
            {
                List<BasicaDTO> objMunicipios = new List<BasicaDTO>();
                List<BasicaDTO> objDepartamentos = ZonaGeograficasLogica.ConsultarDepartamentos();
                List<BasicaDTO> objTipo = ConvocatoriaNeg.ConsultarCategoria(Comunes.ConstantesRecursosBD.CODIGO_TIPO_ESCENARIOS);
                ViewBag.departamentos = new SelectList(objDepartamentos, "value", "text");
                ViewBag.municipios = new SelectList(objMunicipios, "value", "text");
                ViewBag.tipo = new SelectList(objTipo, "value", "text");
                return View(model.ToPagedList(pageNumber, pageSize));
            }
            else
                return PartialView("_PartialResultadoEscenarios", model.ToPagedList(pageNumber, pageSize));
        }

        #endregion

        #region EventosPeriodicos

        public ActionResult EventoDepartamento(string Id, string Tipo, int? page)
        {
            var listResultado = new List<ActoresHomeModels>();
            var listado = new List<ActorHomeDataDTO>();
            listado = ActoresNeg.ConsultarEventosPorDepartamento(Id);
            if (!String.IsNullOrEmpty(Tipo))
            {
                int clasificacionId = Convert.ToInt32(Tipo);
                listado = (from l in listado where l.TipoId == clasificacionId select l).ToList();
                ViewBag.tipoAgrupacionId = Tipo;
            }
            listResultado = TranslatorHomeActores.EscenariosHome(listado, strFichaEvento);
            ViewBag.CodDepto = Id;
            ViewBag.CantidadRegistros = listResultado.Count;
            var model = from l in listResultado select l;
            int pageSize = 9;
            int pageNumber = (page ?? 1);
            return PartialView("_PartialResultadoEventos", model.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult EventoMunicipio(string Id, string Tipo, int? page)
        {
            var listResultado = new List<ActoresHomeModels>();
            var listado = new List<ActorHomeDataDTO>();
            listado = ActoresNeg.ConsultarEventosPorMunicipio(Id);
            if (!String.IsNullOrEmpty(Tipo))
            {
                int clasificacionId = Convert.ToInt32(Tipo);
                listado = (from l in listado where l.TipoId == clasificacionId select l).ToList();
                ViewBag.tipoAgrupacionId = Tipo;
            }
            listResultado = TranslatorHomeActores.EscenariosHome(listado, strFichaEvento);
            ViewBag.codMunicipio = Id;
            ViewBag.CantidadRegistros = listResultado.Count;
            var model = from l in listResultado select l;
            int pageSize = 9;
            int pageNumber = (page ?? 1);
            return PartialView("_PartialResultadoEventos", model.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult EventoTipo(string Id, string codDepto, string codMunicipio, int? page)
        {
            var listResultado = new List<ActoresHomeModels>();
            var listado = new List<ActorHomeDataDTO>();

            if (String.IsNullOrEmpty(codDepto) && String.IsNullOrEmpty(codMunicipio) && !String.IsNullOrEmpty(Id))
                listado = ActoresNeg.ConsultarEventosTodo();
            else if (!String.IsNullOrEmpty(codMunicipio))
            {
                if (codMunicipio.Length == 5)
                {
                    listado = ActoresNeg.ConsultarEventosPorMunicipio(codMunicipio);
                    ViewBag.codMunicipio = codMunicipio;
                }
                else if (!String.IsNullOrEmpty(codDepto))
                {
                    listado = ActoresNeg.ConsultarEventosPorDepartamento(codDepto);
                    ViewBag.CodDepto = codDepto;
                }
                else if (!String.IsNullOrEmpty(Id))
                {
                    listado = ActoresNeg.ConsultarEventosTodo();
                    ViewBag.tipoAgrupacionId = Id;
                }
            }
            else if (!String.IsNullOrEmpty(codDepto))
            {
                listado = ActoresNeg.ConsultarEventosPorDepartamento(codDepto);
                ViewBag.CodDepto = codDepto;
            }

            if (!String.IsNullOrEmpty(Id))
            {
                int clasificacionId = Convert.ToInt32(Id);
                listado = (from l in listado where l.TipoId == clasificacionId select l).ToList();
                ViewBag.tipoAgrupacionId = Id;
            }
            listResultado = TranslatorHomeActores.EscenariosHome(listado, strFichaEvento);
            ViewBag.CantidadRegistros = listResultado.Count;
            var model = from l in listResultado select l;
            int pageSize = 9;
            int pageNumber = (page ?? 1);
            return PartialView("_PartialResultadoEventos", model.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult CargarTodoEventos(int? page)
        {
            var listResultado = new List<ActoresHomeModels>();
            var listado = new List<ActorHomeDataDTO>();

            listado = ActoresNeg.ConsultarEventosTodo();

            listResultado = TranslatorHomeActores.EscenariosHome(listado, strFichaEvento);
            ViewBag.codMunicipio = "";
            ViewBag.CantidadRegistros = listResultado.Count;
            var model = from l in listResultado select l;
            int pageSize = 12;
            int pageNumber = (page ?? 1);
            return PartialView("_PartialResultadoEventos", model.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Eventos(string codDepto, string codMunicipio, string tipo, int? page)
        {

            var listResultado = new List<ActoresHomeModels>();
            var listado = new List<ActorHomeDataDTO>();
            if (String.IsNullOrEmpty(codDepto) && String.IsNullOrEmpty(codMunicipio) && String.IsNullOrEmpty(tipo))
                listado = ActoresNeg.ConsultarEventosTodo();
            else if (!String.IsNullOrEmpty(codMunicipio))
            {
                if (codMunicipio.Length == 5)
                {
                    listado = ActoresNeg.ConsultarEventosPorMunicipio(codMunicipio);
                    ViewBag.codMunicipio = codMunicipio;
                }
                else if (!String.IsNullOrEmpty(codDepto))
                {
                    listado = ActoresNeg.ConsultarEventosPorDepartamento(codDepto);
                    ViewBag.CodDepto = codDepto;
                }
                else if (!String.IsNullOrEmpty(tipo))
                {
                    listado = ActoresNeg.ConsultarEventosTodo();
                    ViewBag.tipoAgrupacionId = tipo;
                }
            }
            else if (!String.IsNullOrEmpty(codDepto))
            {
                listado = ActoresNeg.ConsultarEventosPorDepartamento(codDepto);
                ViewBag.CodDepto = codDepto;
            }


            if (!String.IsNullOrEmpty(tipo))
            {
                int clasificacionId = Convert.ToInt32(tipo);
                listado = (from l in listado where l.TipoId == clasificacionId select l).ToList();
                ViewBag.tipoAgrupacionId = tipo;
            }

            listResultado = TranslatorHomeActores.EscenariosHome(listado, strFichaEvento);
            ViewBag.CantidadRegistros = listResultado.Count;
            var model = from l in listResultado select l;
            int pageSize = 9;
            int pageNumber = (page ?? 1);
            if (page == null)
            {
                List<BasicaDTO> objMunicipios = new List<BasicaDTO>();
                List<BasicaDTO> objDepartamentos = ZonaGeograficasLogica.ConsultarDepartamentos();
                List<BasicaDTO> objTipo = ConvocatoriaNeg.ConsultarCategoria(Comunes.ConstantesRecursosBD.CODIGO_TIPO_EVENTOS_PERIODICOS);
                ViewBag.departamentos = new SelectList(objDepartamentos, "value", "text");
                ViewBag.municipios = new SelectList(objMunicipios, "value", "text");
                ViewBag.tipo = new SelectList(objTipo, "value", "text");
                return View(model.ToPagedList(pageNumber, pageSize));
            }
            else
                return PartialView("_PartialResultadoEventos", model.ToPagedList(pageNumber, pageSize));
        }

        #endregion
        public JsonResult GetMunicipio(string departamento = null)
        {

            List<BasicaDTO> listMunicipios = new List<BasicaDTO>();

            if (!String.IsNullOrEmpty(departamento))
            {
                listMunicipios = ZonaGeograficasLogica.ConsultarMunicipios(departamento);
            }

            var data = listMunicipios;
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            string ruta = "";
            ruta = Server.MapPath("/Log");
            Log.WriteLog(ruta, filterContext.Exception.ToString());

            Exception ex = filterContext.Exception;
            filterContext.ExceptionHandled = true;


            var model = new HandleErrorInfo(filterContext.Exception, "Actores", "Action");

            filterContext.Result = new ViewResult()
            {
                ViewName = "Error",
                ViewData = new ViewDataDictionary(model)
            };
        }
    }
}