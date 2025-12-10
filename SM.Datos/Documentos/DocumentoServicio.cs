using SM.Datos.AuditoriaData;
using SM.SIPA;
using System;
using System.Linq;
using System.Text;

namespace SM.Datos.Documentos
{
    /// <summary>
    /// Clase de datos para crear, consultar documentos
    /// </summary>
    public class DocumentoServicio
    {
        #region Actualizacion
        public static int Crear(ART_MUSICA_DOCUMENTOS documento, string NombreUsuario, string strIP, int ArtMusicaUsuarioId)
        {
            int documentoId = 0;
            try
            {              
              
                using (var context = new SIPAEntities())
                {
                    context.ART_MUSICA_DOCUMENTOS.Add(documento);
                    context.SaveChanges();
                    documentoId =documento.Id;

                    string temp;
                    temp = string.Format("El usuario {0} ({1}) creó el {2} el documento.\ndocumentoId:\n{3} ", NombreUsuario, ArtMusicaUsuarioId, DateTime.Now, documentoId);
                    StringBuilder stringBuilder = new StringBuilder();
                    stringBuilder.AppendLine(temp);
                    ART_MUSICA_REGISTRO_OPERACION registroOperacion = new ART_MUSICA_REGISTRO_OPERACION { Categoria = CategoriaRegistroOperacion.EscuelasDocumentos.ToString(), IpUsuario = strIP, RegistroId = documentoId, UsuarioId = ArtMusicaUsuarioId, NombreUsuario = NombreUsuario, Descripcion = stringBuilder.ToString(), FechaRegistro = DateTime.Now, Operacion = "Creación documentos" };

                    RegistroOperacionServicio auditoria = new RegistroOperacionServicio();
                    auditoria.Crear(registroOperacion);
         
                }

                return documentoId;
           
            }
            catch (Exception)
            {
                throw;
            }

        }

        public static int Eliminar(int documentoId)
        {

            try
            {

                using (var context = new SIPAEntities())
                {
                    context.ART_MUSICA_DOCUMENTOS.Remove(context.ART_MUSICA_DOCUMENTOS.Where(x => x.Id == documentoId).FirstOrDefault());
                    context.SaveChanges();
       
                }

                return documentoId;

            }
            catch (Exception)
            {
                throw;
            }

        }
        #endregion
        #region consultas
        public static ART_MUSICA_DOCUMENTOS ConsultaDocumentoPorId(int DocumentoId)
        {
            var evento = new ART_MUSICA_DOCUMENTOS();
            try
            {
                using (var context = new SIPAEntities())
                {

                    evento = context.ART_MUSICA_DOCUMENTOS.Where(x => x.Id == DocumentoId).FirstOrDefault();

                }
                return evento;

            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
