using SM.Aplicacion.Documentos;
using SM.LibreriaComun.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebSImus.Models;

namespace WebSImus.Translator
{
    public class TranslatorDocumento
    {
        public static DocumentoModels ConsultaDocumentoPorId(int Id)
        {
            try
            {
                var model = new DocumentoDTO();
                var datos = new DocumentoModels();
                model = DocumentosNeg.ConsultaDocumentoPorId(Id);

                if (model != null)
                {
                    datos.BytesArchivo = model.BytesArchivo;
                    datos.DocumentoId = model.DocumentoId;
                    datos.ExtensionArchivo = model.ExtensionArchivo.Trim();
                    datos.FechaRegistro = model.FechaRegistro;
                    datos.NombreArchivo = model.NombreArchivo.Trim();
                    datos.NombreUsuario = model.NombreUsuario;
                    datos.TamanoArchivo = model.TamanoArchivo;
                    datos.TipoContenido = model.TipoContenido;
                    datos.Token = model.Token;
                    datos.UsuarioId = model.UsuarioId;
                }


                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<DocumentoModels> ConsultaDocumento(int Id)
        {
            try
            {
                var model = new DocumentoDTO();
                var datos = new DocumentoModels();
                var listDocumentos = new List<DocumentoModels>();
                model = DocumentosNeg.ConsultaDocumentoPorId(Id);

                if (model != null)
                {
                    datos.BytesArchivo = model.BytesArchivo;
                    datos.DocumentoId = model.DocumentoId;
                    datos.ExtensionArchivo = model.ExtensionArchivo;
                    datos.FechaRegistro = model.FechaRegistro;
                    datos.NombreArchivo = model.NombreArchivo;
                    datos.NombreUsuario = model.NombreUsuario;
                    datos.TamanoArchivo = model.TamanoArchivo;
                    datos.TipoContenido = model.TipoContenido;
                    datos.Token = model.Token;
                    datos.UsuarioId = model.UsuarioId;
                    listDocumentos.Add(datos);
                }


                return listDocumentos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}