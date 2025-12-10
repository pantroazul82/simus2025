using SM.Datos.Documentos;
using SM.Datos.DTO;
using SM.LibreriaComun.DTO;
using SM.SIPA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Aplicacion.Documentos
{
    public class EscuelaDocumentosNeg
    {
        #region Actualizacion

        public static void CrearDocumentoDotacion(DocumentoDTO ArchivoAgenda, int DotacionId, string Categoria)
        {

            try
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

                EscuelasDocumentosServicio.CrearDocumentosDotacion(documento, DotacionId, Categoria);


            }
            catch (Exception ex)
            { throw ex; }
        }

        public static void CrearDocumentoCronograma(DocumentoDTO ArchivoAgenda, int CronogramaId, string Categoria, int UsuarioId)
        {

            try
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

                EscuelasDocumentosServicio.CrearDocumentosCronograma(documento, CronogramaId, Categoria, UsuarioId);


            }
            catch (Exception ex)
            { throw ex; }
        }
        public static void Crear(DocumentoDTO ArchivoAgenda, decimal EscuelaId, string Categoria, string NombreUsuario, string strIP, int ArtMusicaUsuarioId)
        {
          
            try
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

                EscuelasDocumentosServicio.Crear(documento, EscuelaId, Categoria, NombreUsuario, strIP, ArtMusicaUsuarioId);


            }
            catch (Exception ex)
            { throw ex; }
        }

        public static void EliminarDocumento(int EscuelaDocumentoId)
        {
            try
            { EscuelasDocumentosServicio.EliminarDocumento(EscuelaDocumentoId); }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void EliminarDocumentoDotacion(int DotacionDocumentoId)
        {
            try
            { EscuelasDocumentosServicio.EliminarDocumentoDotacion(DotacionDocumentoId); }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void EliminarDocumentoCronograma(int CronogramaDocumentoId)
        {
            try
            { EscuelasDocumentosServicio.EliminarDocumentoCronograma(CronogramaDocumentoId); }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Consultas
        public static List<EscuelaDocumentoDTO> ConsultarEscuelasDocumentos(decimal EscuelaId)
        {
            try
            {
                var listDocumento = new List<DocumentoResultadoDTO>();
                var listDocumentoResultado = new List<EscuelaDocumentoDTO>();
                listDocumento = EscuelasDocumentosServicio.ConsultarDocumentos(EscuelaId);
                foreach (var item in listDocumento)
                {
                    var datos = new EscuelaDocumentoDTO();
                    datos.Categoria = item.Categoria;
                    datos.DocumentoId = item.DocumentoId;
                    datos.EscuelaDocumentoId = item.EscuelaDocumentoId;
                    datos.EscuelaId = item.EscuelaId;
                    datos.FechaRegistro = item.FechaRegistro.ToString("yyyy-MM-dd");
                    datos.Fecha = item.FechaRegistro;
                    datos.TamanoArchivo = item.TamanoArchivo;
                    datos.NombreArchivo = item.NombreArchivo;
                    listDocumentoResultado.Add(datos);
                }

                return listDocumentoResultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<EscuelaDocumentoDTO> ConsultarDocumentosDotacion(int DotacionId)
        {
            try
            {
                var listDocumento = new List<DocumentoResultadoDTO>();
                var listDocumentoResultado = new List<EscuelaDocumentoDTO>();
                listDocumento = EscuelasDocumentosServicio.ConsultarDocumentosDotacion(DotacionId);
                foreach (var item in listDocumento)
                {
                    var datos = new EscuelaDocumentoDTO();
                    datos.Categoria = item.Categoria;
                    datos.DocumentoId = item.DocumentoId;
                    datos.DotacionDocumentoId = item.DotacionDocumentoId;
                    datos.DotacionId = item.DotacionId;
                    datos.FechaRegistro = item.FechaRegistro.ToString("yyyy-MM-dd");
                    datos.Fecha = item.FechaRegistro;
                    datos.TamanoArchivo = item.TamanoArchivo;
                    datos.NombreArchivo = item.NombreArchivo;
                    listDocumentoResultado.Add(datos);
                }

                return listDocumentoResultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<EscuelaDocumentoDTO> ConsultarDocumentosCronograma(int cronogramaId)
        {
            try
            {
                var listDocumento = new List<DocumentoResultadoDTO>();
                var listDocumentoResultado = new List<EscuelaDocumentoDTO>();
                listDocumento = EscuelasDocumentosServicio.ConsultarDocumentosCronograma(cronogramaId);
                foreach (var item in listDocumento)
                {
                    var datos = new EscuelaDocumentoDTO();
                    datos.Categoria = item.Categoria;
                    datos.DocumentoId = item.DocumentoId;
                    datos.CronogramaDocumentoId = item.DotacionDocumentoId;
                    datos.CronogramaId = item.CronogramaId;
                    datos.FechaRegistro = item.FechaRegistro.ToString("yyyy-MM-dd");
                    datos.Fecha = item.FechaRegistro;
                    datos.TamanoArchivo = item.TamanoArchivo;
                    datos.NombreArchivo = item.NombreArchivo;
                    listDocumentoResultado.Add(datos);
                }

                return listDocumentoResultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
