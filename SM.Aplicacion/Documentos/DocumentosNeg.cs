using SM.Datos.Documentos;
using SM.LibreriaComun.DTO;
using SM.SIPA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Aplicacion.Documentos
{
    public class DocumentosNeg
    {
        #region Actualizacion
        public static int Crear(DocumentoDTO ArchivoAgenda, string NombreUsuario, string strIP, int ArtMusicaUsuarioId)
        {
            int DocumentoId = 0;
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

                DocumentoId = DocumentoServicio.Crear(documento, NombreUsuario, strIP, ArtMusicaUsuarioId);

                return DocumentoId;
            }
            catch (Exception ex)
            { throw ex; }
        }
        #endregion
        #region Consultas
        public static DocumentoDTO ConsultaDocumentoPorId(int Id)
        {
            try
            {
                var model = new ART_MUSICA_DOCUMENTOS();
                var datos = new DocumentoDTO();
                model = DocumentoServicio.ConsultaDocumentoPorId(Id);

                if (model != null)
                {
                    datos.BytesArchivo = model.Bytes;
                    datos.DocumentoId = model.Id;
                    datos.ExtensionArchivo = model.Extension;
                    datos.FechaRegistro = model.FechaRegistro;
                    datos.NombreArchivo = model.NombreArchivo;
                    datos.NombreUsuario = "";
                    datos.TamanoArchivo = model.TamanoArchivo ?? 0;
                    datos.TipoContenido = model.TipoContenido;
                    datos.Token = "";
                    datos.UsuarioId = model.UsuarioId;

                }


                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<DocumentoDTO> ConsultarDocumento(int Id)
        {
            try
            {
                var model = new ART_MUSICA_DOCUMENTOS();
                var datos = new DocumentoDTO();
                model = DocumentoServicio.ConsultaDocumentoPorId(Id);
                var listado = new List<DocumentoDTO>();

                if (model != null)
                {
                    datos.BytesArchivo = model.Bytes;
                    datos.DocumentoId = model.Id;
                    datos.ExtensionArchivo = model.Extension;
                    datos.FechaRegistro = model.FechaRegistro;
                    datos.NombreArchivo = model.NombreArchivo;
                    datos.NombreUsuario = "";
                    datos.TamanoArchivo = model.TamanoArchivo ?? 0;
                    datos.TipoContenido = model.TipoContenido;
                    datos.Token = "";
                    datos.UsuarioId = model.UsuarioId;

                }
                listado.Add(datos);

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
