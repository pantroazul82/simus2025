using SM.LibreriaComun.DTO.GEO;
using SM.LibreriaComun.DTO.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebSImus.Areas.Mapas.Models;
using WebSImus.Models;

namespace WebSImus.Translator
{
    public class TranslatorUtilidad
    {

        public static HerramientaModel TranslatorHerramientaModel(HerramientaDataDTO objfrom)
        {
            var objto = new HerramientaModel();
            objto.Autores = objfrom.Autores;
            objto.Descripcion = objfrom.Descripcion;
            objto.DocumentoId = objfrom.DocumentoId;
            objto.EstadoId = objfrom.EstadoId.ToString();
            objto.Id = objfrom.Id;
            objto.Nombre = objfrom.Nombre;
            objto.TipoId = objfrom.TipoId.ToString();
            objto.UrlArchivo = objfrom.UrlArchivo;
            objto.UrlVideo = objfrom.UrlYoutube;

            if (objfrom.DocumentoId > 0)
            {
                objto.DocumentoId = objfrom.DocumentoId;
                objto.documentoArchivo = TranslatorDocumento.ConsultaDocumento(objfrom.DocumentoId);
            }
            else
                objto.DocumentoId = 0;
            return objto;
        }
        public static UtilidadPadreModels TranslatorUtilidadModel(UtilidadDTO objfrom)
        {
            var objto = new UtilidadPadreModels();
            objto.UtilidadId = objfrom.UtilidadId;
            objto.ArtMusicaUsuarioId = objfrom.UsuarioId;
            objto.Descripcion = objfrom.Descripcion;
            objto.EstadoId = objfrom.EstadoId.ToString();
            objto.FechaFin = objfrom.FechaFin.ToString("yyyy-MM-dd");
            objto.FechaInicio = objfrom.FechaInicio.ToString("yyyy-MM-dd");
            objto.HoraInicio = objfrom.FechaInicio.ToString("hh:mm tt");
            objto.HoraFin = objfrom.FechaFin.ToString("hh:mm tt");
            objto.Tipo = objfrom.TipoActorId.ToString();
            objto.TipoActor = objfrom.ActorId.ToString();
            objto.Titulo = objfrom.Titulo;
            objto.NombreEstado = objfrom.Estado;
            objto.Tipoutilidad = objfrom.TipoUtilidadId.ToString();
            objto.TipoEvento = objfrom.TipoEventoId.ToString();
            objto.imagen = objfrom.imagen;
            objto.CodigoPais = objfrom.CodPais.ToString();
            objto.OtraCiudad = objfrom.OtraCiudad;
            objto.CodigoDepartamento = objfrom.codDepto;
            objto.CodigoMunicipio = objfrom.codMunicipio;
            objto.Direccion = objfrom.Direccion;
            objto.Telefono = objfrom.Telefono;
            objto.CorreoElectronico = objfrom.CorreoElectronico;
            objto.Latitud = objfrom.Latitud;
            objto.Longitud = objfrom.Longitud;
            objto.TipoEvento = objfrom.TipoEventoId.ToString();
            objto.EsActivo = objfrom.EsActivo;

            if (objfrom.DocumentoId > 0)
            {
                objto.DocumentoId = objfrom.DocumentoId;
                objto.documentoArchivo = TranslatorDocumento.ConsultaDocumento(objfrom.DocumentoId);
            }
            else
                objto.DocumentoId = 0;
            return objto;
        }

        public static List<UtilidadHomeModels> TranslatorUtilidadHomeModel(List<UtilidadHomeDataDTO> model)
        {
            var resultado = new List<UtilidadHomeModels>();
            if (model != null)
            {
                foreach (var objfrom in model)
                {
                    var objto = new UtilidadHomeModels();
                    objto.UtilidadId = objfrom.UtilidadId;
                    objto.Descripcion = objfrom.Descripcion;
                    objto.FechaFin = objfrom.FechaFin;
                    objto.FechaInicio = objfrom.FechaInicio;
                    objto.NombreActor = objfrom.NombreActor;
                    objto.TipoActor = objfrom.TipoActor;
                    objto.TipoUtilidad = objfrom.TipoUtilidad;
                    objto.Titulo = objfrom.Titulo;
                    objto.UtilidadId = objfrom.UtilidadId;
                    objto.TipoActorId = objfrom.TipoActorId;
                    objto.TipoEventoId = objfrom.TipoEventoId;
                    objto.TipoServicioId = objfrom.TipoServicioId;
                    objto.Email = objfrom.Email;
                    objto.Telefono = objfrom.Telefono;
                    objto.Clasificacion = objfrom.Clasificacion;

                    if (objfrom.DocumentoId > 0)
                    {
                        objto.documentoId = objfrom.DocumentoId;
                        objto.documentoArchivo = TranslatorDocumento.ConsultaDocumento(objfrom.DocumentoId);
                    }
                    else
                        objto.documentoId = 0;

                    resultado.Add(objto);
                }
            }
            return resultado;
        }

        public static List<AgendaModels> TranslatorUtilidadAgendaModel(List<AgendaDTO> model)
        {
            var resultado = new List<AgendaModels>();
            if (model != null)
            {
                string strClasName = "fc-eventcustom";
                foreach (var objfrom in model)
                {
                    var objto = new AgendaModels();

                    objto.className = strClasName;
                    objto.end = objfrom.FechaFin;
                    objto.id = objfrom.UtilidadId;
                    objto.start = objfrom.FechaInicio;
                    objto.title = objfrom.Titulo;
                    resultado.Add(objto);
                    if (strClasName == "fc-eventcustom")
                        strClasName = "fc-eventcustom";
                    else if (strClasName == "fc-eventcustom")
                        strClasName = "fc-event";
                    
                }
            }
            return resultado;
        }

        public static UtilidadHomeModels TranslatorNoticiasDetalle(UtilidadDataDetalleDTO objfrom, List<NoticiasDataDTO> listNoticias, string hostname)
        {

            var objto = new UtilidadHomeModels();
            objto.UtilidadId = objfrom.UtilidadId;
            objto.Descripcion = objfrom.Descripcion;
            DateTime datFechaInicio = objfrom.FechaInicio ?? DateTime.Today;
            objto.FechaInicio = datFechaInicio.ToString("dd/MM/yyyy");
            objto.NombreActor = objfrom.NombreActor;
            objto.TipoActor = objfrom.TipoActor;
            objto.TipoUtilidad = objfrom.TipoUtilidad;
            objto.Titulo = objfrom.Titulo;
            objto.UtilidadId = objfrom.UtilidadId;
            objto.Email = objfrom.Email;
            objto.Telefono = objfrom.Telefono;
            objto.Clasificacion = objfrom.Clasificacion;
            objto.Direccion = objfrom.Direccion;
            if (objfrom.Pais == "COLOMBIA")
                objto.Ubicacion = objfrom.Pais + " " + objfrom.Departamento + " " + objfrom.Municipio;
            else
                objto.Ubicacion = objfrom.Pais + " " + objfrom.OtraCiudad;
           
            objto.rutaFoto = "";
            if (objfrom.Imagen != null)
                objto.Imagen = objfrom.Imagen;
            else
                objto.rutaFoto =  hostname +  "/img/agrupa_generica.jpg";
            if (objfrom.DocumentoId > 0)
            {
                objto.documentoId = objfrom.DocumentoId;
                objto.documentoArchivo = TranslatorDocumento.ConsultaDocumento(objfrom.DocumentoId);
            }
            else
                objto.documentoId = 0;

            var listNoticiasrecientes = new List<NoticiasRecientes>();
            foreach (var item in listNoticias)
            {
                var datos = new NoticiasRecientes();
                datos.Descripcion = item.Descripcion;
                datos.rutaFoto = "";
                if (item.Imagen != null)
                    datos.Imagen = item.Imagen;
                else 
                    datos.rutaFoto = hostname + "/img/agrupa_generica.jpg";
                datos.Titulo = item.Titulo;
                datos.UtilidadId = item.UtilidadId;
                datos.FechaInicio = item.FechaInicio;
                listNoticiasrecientes.Add(datos);
            }
            objto.listadoNoticias = listNoticiasrecientes;
            return objto;
        }

        public static UtilidadHomeModels TranslatorAgendaDetalle(UtilidadDataDetalleDTO objfrom,  string hostname)
        {

            var objto = new UtilidadHomeModels();
            objto.UtilidadId = objfrom.UtilidadId;
            objto.Descripcion = objfrom.Descripcion;
            DateTime datFechaInicio = objfrom.FechaInicio ?? DateTime.Today;
            DateTime datFechaFin = objfrom.FechaFin ?? DateTime.Today;
            objto.FechaInicio = datFechaInicio.ToString("dd/MM/yyyy hh:mm");
            objto.FechaFin = datFechaFin.ToString("dd/MM/yyyy hh:mm");
            objto.NombreActor = objfrom.NombreActor;
            objto.TipoActor = objfrom.TipoActor;
            objto.TipoUtilidad = objfrom.TipoUtilidad;
            objto.Titulo = objfrom.Titulo;
            objto.UtilidadId = objfrom.UtilidadId;
            objto.Email = objfrom.Email;
            objto.Telefono = objfrom.Telefono;
            objto.Clasificacion = objfrom.Clasificacion;
            objto.Direccion = objfrom.Direccion;
            if (objfrom.Pais == "COLOMBIA")
                objto.Ubicacion = objfrom.Pais + " " + objfrom.Departamento + " " + objfrom.Municipio;
            else
                objto.Ubicacion = objfrom.Pais + " " + objfrom.OtraCiudad;

            objto.rutaFoto = "";
            if (objfrom.Imagen != null)
                objto.Imagen = objfrom.Imagen;
            else
                objto.rutaFoto = hostname + "/img/agrupa_generica.jpg";
            if (objfrom.DocumentoId > 0)
            {
                objto.documentoId = objfrom.DocumentoId;
                objto.documentoArchivo = TranslatorDocumento.ConsultaDocumento(objfrom.DocumentoId);
            }
            else
                objto.documentoId = 0;

          
            return objto;
        }
    }
}