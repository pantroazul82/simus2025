using SM.Datos.AuditoriaData;
using SM.LibreriaComun.DTO.Servicios;
using SM.SIPA;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace SM.Datos.Servicios
{
    public class ConvocatoriaEstimulosServicio
    {
        #region Actualizar
        public static int Agregar(ART_MUSICA_CONVOCATORIA_ESTIMULOS registro, string NombreUsuario, string strIP, int ArtMusicaUsuarioId)
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    context.ART_MUSICA_CONVOCATORIA_ESTIMULOS.Add(registro);
                    context.SaveChanges();
                    string temp;
                    temp = string.Format("El usuario {0} ({1}) actualizo el {2} la convocatoria estimulo.\ndocumentoId:\n{3} ", NombreUsuario, ArtMusicaUsuarioId, DateTime.Now, registro.Id);
                    StringBuilder stringBuilder = new StringBuilder();
                    stringBuilder.AppendLine(temp);
                    ART_MUSICA_REGISTRO_OPERACION registroOperacion = new ART_MUSICA_REGISTRO_OPERACION { Categoria = CategoriaRegistroOperacion.ConvocatoriaEstimulos.ToString(), IpUsuario = strIP, RegistroId = registro.Id, UsuarioId = ArtMusicaUsuarioId, NombreUsuario = NombreUsuario, Descripcion = stringBuilder.ToString(), FechaRegistro = DateTime.Now, Operacion = "Creación" };

                    RegistroOperacionServicio auditoria = new RegistroOperacionServicio();
                    auditoria.Crear(registroOperacion);
                    return registro.Id;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int Actualizar(ConvocatoriaEstimuloDTO datos, string NombreUsuario, string strIP, int ArtMusicaUsuarioId)
        {
            int documentoId = 0;
            try
            {
                using (var context = new SIPAEntities())
                {
                    var entidad = context.ART_MUSICA_CONVOCATORIA_ESTIMULOS.Where(x => x.Id == datos.Id).FirstOrDefault();
                    documentoId = (int)entidad.DocumentoId;
                    if (entidad != null)
                    {
                        entidad.EstadoId = datos.EstadoId;
                        entidad.FechaApertura = datos.FechaApertura;
                        entidad.FechaCierre = datos.FechaCierre;
                        entidad.FechaPublicacion = datos.FechaPublicacion;
                        entidad.Periodo = datos.Periodo;
                        entidad.Titulo = datos.Titulo;
                    }
                    context.SaveChanges();

                    string temp;
                    temp = string.Format("El usuario {0} ({1}) actualizo el {2} la convocatoria estimulo.\ndocumentoId:\n{3} ", NombreUsuario, ArtMusicaUsuarioId, DateTime.Now, entidad.Id);
                    StringBuilder stringBuilder = new StringBuilder();
                    stringBuilder.AppendLine(temp);
                    ART_MUSICA_REGISTRO_OPERACION registroOperacion = new ART_MUSICA_REGISTRO_OPERACION { Categoria = CategoriaRegistroOperacion.ConvocatoriaEstimulos.ToString(), IpUsuario = strIP, RegistroId = entidad.Id, UsuarioId = ArtMusicaUsuarioId, NombreUsuario = NombreUsuario, Descripcion = stringBuilder.ToString(), FechaRegistro = DateTime.Now, Operacion = "Actualizar" };

                    RegistroOperacionServicio auditoria = new RegistroOperacionServicio();
                    auditoria.Crear(registroOperacion);

                    return documentoId;
                }
            }
            catch (Exception)
            { throw; }
        }

        public static void ActualizarDocumento(int ConvocatoriaId,
                                              int documentoId)
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    var entidad = context.ART_MUSICA_CONVOCATORIA_ESTIMULOS.Where(x => x.Id == ConvocatoriaId).FirstOrDefault();

                    if (entidad != null)
                    {
                        entidad.DocumentoId = documentoId;

                    }
                    context.SaveChanges();
                }
            }
            catch (Exception)
            { throw; }
        }
        #endregion

        #region Consultas
        public static ART_MUSICA_CONVOCATORIA_ESTIMULOS ConsultarConvocatoriaPorId(int Id)
        {

            var registro = new ART_MUSICA_CONVOCATORIA_ESTIMULOS();

            try
            {
                using (var context = new SIPAEntities())
                {

                    return registro = context.ART_MUSICA_CONVOCATORIA_ESTIMULOS.Where(x => x.Id == Id).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<ConvocatoriaListadoEstimuloDTO> ConsultarTodasLasConvocatoriasEstimulos()
        {

            var listResultado = new List<ConvocatoriaListadoEstimuloDTO>();

            try
            {
                using (var context = new SIPAEntities())
                {

                    listResultado = context.Database.SqlQuery<ConvocatoriaListadoEstimuloDTO>(@"EXEC ART_MUSICA_CONSULTAR_CONVOCATORIAS_ESTIMULOS").ToList();

                }
                return listResultado;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<ConvocatoriaListadoEstimuloDTO> ConsultarConvocatoriasEstimulosEstado(int estadoId)
        {

            var listResultado = new List<ConvocatoriaListadoEstimuloDTO>();

            try
            {
                using (var context = new SIPAEntities())
                {

                    listResultado = context.Database.SqlQuery<ConvocatoriaListadoEstimuloDTO>(@"EXEC ART_MUSICA_CONSULTAR_CONVOCATORIAS_ESTIMULOS_ESTADOID @EstadoId", new SqlParameter("EstadoId", estadoId)).ToList();

                }
                return listResultado;

            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion
    }
}
