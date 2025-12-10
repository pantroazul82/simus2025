using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SM.Aplicacion.ServicioEstimulos;
using System.ServiceModel;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SM.LibreriaComun.DTO;
using System.Globalization;
using SM.SIPA;
using SM.Datos.Servicios;
using SM.LibreriaComun.DTO.Servicios;
using SM.Datos.Documentos;

namespace SM.Aplicacion.Estimulos
{
    public class ServicioEstimuloNeg
    {
        #region Actualizar
        public static void Agregar(ConvocatoriaEstimuloDTO datos, DocumentoDTO ArchivoAgenda, string NombreUsuario, string strIP, int ArtMusicaUsuarioId)
        {
            int DocumentoId = 0;
            int ConvocatoriaId = 0;
            try
            {

                var entidad = new ART_MUSICA_CONVOCATORIA_ESTIMULOS
                    {
                        EstadoId = datos.EstadoId,
                        FechaApertura = datos.FechaApertura,
                        FechaCierre = datos.FechaCierre,
                        FechaPublicacion = datos.FechaPublicacion,
                        FechaCreacion = DateTime.Now,
                        Periodo = datos.Periodo,
                        Titulo = datos.Titulo,
                        UsuarioId = datos.UsuarioId
                    };

                ConvocatoriaId = ConvocatoriaEstimulosServicio.Agregar(entidad, NombreUsuario, strIP, ArtMusicaUsuarioId);
                if (ArchivoAgenda != null)
                {
                    var documento = new ART_MUSICA_DOCUMENTOS
                    {
                        Bytes = ArchivoAgenda.BytesArchivo,
                        Extension = ArchivoAgenda.ExtensionArchivo,
                        FechaRegistro = DateTime.Now,
                        NombreArchivo = ArchivoAgenda.NombreArchivo,
                        TamanoArchivo = ArchivoAgenda.TamanoArchivo,
                        TipoContenido = ArchivoAgenda.TipoContenido,
                        UsuarioId = ArchivoAgenda.UsuarioId,
                    };

                    DocumentoId = DocumentoServicio.Crear(documento, NombreUsuario, strIP, ArtMusicaUsuarioId);
                    ConvocatoriaEstimulosServicio.ActualizarDocumento(ConvocatoriaId, DocumentoId);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void Actualizar(ConvocatoriaEstimuloDTO datos, DocumentoDTO ArchivoAgenda, string NombreUsuario, string strIP, int ArtMusicaUsuarioId)
        {
            int documentoAnteriorId = 0;
            int DocumentoId = 0;
            try
            {
                documentoAnteriorId = ConvocatoriaEstimulosServicio.Actualizar(datos, NombreUsuario, strIP, ArtMusicaUsuarioId);
                if (ArchivoAgenda != null && ArchivoAgenda.BytesArchivo != null)
                {
                    var documento = new ART_MUSICA_DOCUMENTOS
                    {
                        Bytes = ArchivoAgenda.BytesArchivo,
                        Extension = ArchivoAgenda.ExtensionArchivo,
                        FechaRegistro = DateTime.Now,
                        NombreArchivo = ArchivoAgenda.NombreArchivo,
                        TamanoArchivo = ArchivoAgenda.TamanoArchivo,
                        TipoContenido = ArchivoAgenda.TipoContenido,
                        UsuarioId = ArchivoAgenda.UsuarioId,
                    };

                    DocumentoId = DocumentoServicio.Crear(documento, NombreUsuario, strIP, ArtMusicaUsuarioId);
                    if (documentoAnteriorId > 0 && DocumentoId > 0)
                        DocumentoServicio.Eliminar(documentoAnteriorId);
                 
                    ConvocatoriaEstimulosServicio.ActualizarDocumento(datos.Id, DocumentoId);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Consulta
        public static ConvocatoriaEstimuloDTO ConsultarConvocatoriaPorId(int Id)
        {
            try
            {
                var datos = new ConvocatoriaEstimuloDTO();
                var model = ConvocatoriaEstimulosServicio.ConsultarConvocatoriaPorId(Id);

                if (model != null)
                {
                    datos.EstadoId = model.EstadoId;
                    datos.FechaApertura = model.FechaApertura;
                    datos.FechaCierre = model.FechaCierre;
                    datos.FechaPublicacion = model.FechaPublicacion;
                    datos.Id = model.Id;
                    datos.Periodo = model.Periodo;
                    datos.Titulo = model.Titulo;
                    if (model.DocumentoId != null)
                        datos.DocumentoId = (int)model.DocumentoId;

                }

                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ConvocatoriaListadoEstimuloDTO> ConsultarTodasLasConvocatoriasEstimulos()
        {
            try
            {
                var model = ConvocatoriaEstimulosServicio.ConsultarTodasLasConvocatoriasEstimulos();
                return model;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ConvocatoriaListadoEstimuloDTO> ConsultarConvocatoriasEstimulosEstado(int EstadoId)
        {
            try
            {
                var model = ConvocatoriaEstimulosServicio.ConsultarConvocatoriasEstimulosEstado(EstadoId);
                return model;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<ResultadoEstimuloDTO> ObtenerGanadoresConvocatoriaCoro(string strAnio)
        {
            try
            {
                string baseUrl = "http://convocatorias.mincultura.gov.co/WsResultadosEstimulos/ServicioResultadoEstimulos.svc/";
                string modalidad = "8";
                string convocatoria = "674";
                // Estado ganador convocatoria como 6
                string estado = "6";
                List<ResultadoEstimuloDTO> listado;
                WebClient proxy = new WebClient();
                string serviceUrl = string.Format(baseUrl + "GetResultados/{0}/{1}/{2}/{3}", strAnio, modalidad, convocatoria, estado);
                byte[] data = proxy.DownloadData(serviceUrl);

                Stream stream = new MemoryStream(data);
                string result = Encoding.UTF8.GetString((stream as MemoryStream).ToArray());
                string[] formats = { "MM/dd/yyyy" };

                dynamic objJson = JsonConvert.DeserializeObject(result);
                object array = objJson.GetResultadosResult;
                listado = ((JArray)array).Select(x => new ResultadoEstimuloDTO
                   {
                       NombreConvocatoria = (string)x["NombreConvocatoria"],
                       Anio = (short)x["Anio"],
                       Area = (string)x["Area"],
                       CausalRechazo = (string)x["CausalRechazo"],
                       CodigoMunicipio = (string)x["CodigoMunicipio"],
                       Departamento = (string)x["Departamento"],
                       Genero = (string)x["Genero"],
                       Id = (long)x["Id"],
                       Municipio = (string)x["Municipio"],
                       FechaNacimiento = (string)x["FechaNacimiento"],
                       NombreEstado = (string)x["NombreEstado"],
                       NombreModalidad = (string)x["NombreModalidad"],
                       NombreParticipante = (string)x["NombreParticipante"],
                       NumeroRadicacion = (string)x["NumeroRadicacion"],
                       Participante = (string)x["Participante"],
                       NombreProyecto = (string)x["NombreProyecto"]

                   }).ToList();



                foreach (var item in listado)
                {
                    string[] fechaarray = item.FechaNacimiento.Split('/');
                    if (fechaarray.Length >= 3)
                    {
                        string year = fechaarray[2];
                        year = year.Substring(0, 4);
                        string mes = fechaarray[1];
                        string dia = fechaarray[0];
                        DateTime fecha = new DateTime(Convert.ToInt32(year), Convert.ToInt32(fechaarray[1]), Convert.ToInt32(fechaarray[0]));

                        item.Edad = DateTime.Today.AddTicks(-fecha.Ticks).Year - 1;
                    }



                }

                listado = listado.OrderBy(x => x.Departamento).ToList();

                return listado;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
