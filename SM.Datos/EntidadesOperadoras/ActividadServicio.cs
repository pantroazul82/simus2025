using SM.Datos.DTO;
using SM.Datos.DTO.Servicios;
using SM.LibreriaComun.DTO.EntidadesOperadoras;
using SM.SIPA;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace SM.Datos.EntidadesOperadoras
{
    public class ActividadServicio
    {
        #region actualizacion
        public static int Crear(ART_MUSICA_ACTIVIDADES registro)
        {
            int DotacionId = 0;
            try
            {
                using (var context = new SIPAEntities())
                {
                    context.ART_MUSICA_ACTIVIDADES.Add(registro);
                    context.SaveChanges();
                    DotacionId = registro.Id;

                }

                return DotacionId;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void ActualizarDocumento(int ActividadId,
                                           int documentoId)
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    var entidad = context.ART_MUSICA_ACTIVIDADES.Where(x => x.Id == ActividadId).FirstOrDefault();

                    if (entidad != null)
                    {
                        entidad.DocumentoId = documentoId;
                        entidad.FechaActualizacion = DateTime.Now;
                    }
                    context.SaveChanges();
                }
            }
            catch (Exception)
            { throw; }
        }
        public static void Actualizar(int Id, ActividadDTO datos, int UsuarioId)
        {
            try
            {

                using (var context = new SIPAEntities())
                {
                    var entidad = context.ART_MUSICA_ACTIVIDADES.Where(x => x.Id == Id).FirstOrDefault();



                    if (entidad != null)
                    {
                        entidad.ConvenioId = datos.ConvenioId;
                        entidad.Descripcion = datos.Descripcion;
                        entidad.EstadoId = Convert.ToInt32(datos.EstadoId);
                        entidad.ValorEjecutado = Convert.ToInt64(datos.ValorEjecutado);
                        entidad.ValorProgramado = Convert.ToInt64(datos.ValorProgramado);
                        entidad.TipoActividadId = Convert.ToInt32(datos.TipoActividadId);
                        entidad.FechaActualizacion = DateTime.Now;
                        entidad.FechaCreacion = DateTime.Now;
                        entidad.Nombre = datos.Nombre;
                        entidad.Minimo_Dias = Convert.ToInt32(datos.NumeroDias);
                        entidad.UsuarioCreadorId = UsuarioId;

                    }
                    context.SaveChanges();

                }
            }
            catch (Exception)
            { throw; }
        }
        #endregion
        #region Consulta

        public static List<ART_MUSICA_ACTIVIDADES> ConsultarPorConvenioId(int Id)
        {

            var listado = new List<ART_MUSICA_ACTIVIDADES>();

            try
            {
                using (var context = new SIPAEntities())
                {

                    listado = context.ART_MUSICA_ACTIVIDADES.Where(x => x.ConvenioId == Id).ToList();


                }
                return listado;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static ART_MUSICA_ACTIVIDADES ConsultarPorId(int Id)
        {

            var registro = new ART_MUSICA_ACTIVIDADES();

            try
            {
                using (var context = new SIPAEntities())
                {

                    registro = context.ART_MUSICA_ACTIVIDADES.Where(x => x.Id == Id).FirstOrDefault();


                }
                return registro;

            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion
    }
}
