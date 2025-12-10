using System;
using SM.Datos.DTO;
using SM.SIPA;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SM.Datos.AuditoriaData;
using System.Data.SqlClient;

namespace SM.Datos.Usuario
{
    public static class ServicioAsignacionUsuario
    {
        public static void Crear(ART_MUSICA_SOLICITUD_USUARIOS registro)
        {

            try
            {

                using (var context = new SIPAEntities())
                {
                    context.ART_MUSICA_SOLICITUD_USUARIOS.Add(registro);

                    context.SaveChanges();


                }


            }
            catch (Exception)
            {
                throw;
            }


        }

        public static void Actualizar(ART_MUSICA_SOLICITUD_USUARIOS registro, decimal UsuarioSipaId)
        {

            try
            {

                using (var context = new SIPAEntities())
                {
                    using (var dbContextTransaction = context.Database.BeginTransaction())
                    {
                        try
                        {

                            var solicitud = context.ART_MUSICA_SOLICITUD_USUARIOS.Where(b => b.Id == registro.Id).FirstOrDefault();
                            context.Entry(solicitud).CurrentValues.SetValues(registro);
                            context.SaveChanges();

                            var escuela = context.ART_MUSICA_ENTIDAD_IDENTIFICACION.Where(x => x.ENT_ID == registro.EscuelaId).FirstOrDefault();
                            escuela.USU_ID = UsuarioSipaId;
                            context.SaveChanges();
                            dbContextTransaction.Commit();
                        }
                        catch
                        {
                            dbContextTransaction.Rollback();
                            throw;
                        }
                    }
                }


            }
            catch (Exception)
            {
                throw;
            }


        }

        public static void ActualizarEvento(ART_MUSICA_SOLICITUD_USUARIOS registro)
        {

            try
            {

                using (var context = new SIPAEntities())
                {
                    using (var dbContextTransaction = context.Database.BeginTransaction())
                    {
                        try
                        {

                            var solicitud = context.ART_MUSICA_SOLICITUD_USUARIOS.Where(b => b.Id == registro.Id).FirstOrDefault();
                            context.Entry(solicitud).CurrentValues.SetValues(registro);
                            context.SaveChanges();

                            var eventos = context.ART_MUSICA_EVENTOS.Where(x => x.Id == registro.EventoId).FirstOrDefault();
                            eventos.UsuarioId = registro.UsuarioId;
                            context.SaveChanges();
                            dbContextTransaction.Commit();
                        }
                        catch
                        {
                            dbContextTransaction.Rollback();
                            throw;
                        }
                    }
                }


            }
            catch (Exception)
            {
                throw;
            }


        }

        public static void ActualizarEscuela(ART_MUSICA_ENTIDAD_IDENTIFICACION registro)
        {

            try
            {

                using (var context = new SIPAEntities())
                {
                    var solicitud = context.ART_MUSICA_ENTIDAD_IDENTIFICACION.Where(b => b.ENT_ID == registro.ENT_ID).FirstOrDefault();
                    context.Entry(solicitud).CurrentValues.SetValues(registro);
                    context.SaveChanges();

                }


            }
            catch (Exception)
            {
                throw;
            }


        }

        public static ART_MUSICA_SOLICITUD_USUARIOS ObtenerSolicitudUsuario(int Id)
        {
            var model = new ART_MUSICA_SOLICITUD_USUARIOS();

            try
            {
                using (var context = new SIPAEntities())
                {
                    model = context.ART_MUSICA_SOLICITUD_USUARIOS.Where(x => x.Id == Id).FirstOrDefault();

                }


            }
            catch (Exception)
            {
                throw;
            }

            return model;
        }

        public static ART_MUSICA_ENTIDAD_IDENTIFICACION ObtenerEscuelaIdentificacion(decimal EscuelaId)
        {
            var model = new ART_MUSICA_ENTIDAD_IDENTIFICACION();

            try
            {
                using (var context = new SIPAEntities())
                {
                    model = context.ART_MUSICA_ENTIDAD_IDENTIFICACION.Where(x => x.ENT_ID == EscuelaId).FirstOrDefault();

                }


            }
            catch (Exception)
            {
                throw;
            }

            return model;
        }

        public static List<SolicitudResultadoDTO> ConsultarUsuariosPorEstado(int EstadoId)
        {
            List<SolicitudResultadoDTO> lstmodel = null;


            try
            {
                using (var context = new SIPAEntities())
                {

                    lstmodel = context.Database.SqlQuery<SolicitudResultadoDTO>(@"EXEC ART_MUSICA_SOLICITUD_ESCUELAS @EstadoId", new SqlParameter("EstadoId", EstadoId)).ToList();
                }


            }
            catch (Exception)
            {
                lstmodel = null;
                throw;
            }

            return lstmodel;
        }

        public static List<SolicitudCelebraResultadoDTO> ConsultarEventosUsuariosPorEstado(int EstadoId)
        {
            List<SolicitudCelebraResultadoDTO> lstmodel = null;


            try
            {
                using (var context = new SIPAEntities())
                {

                    lstmodel = context.Database.SqlQuery<SolicitudCelebraResultadoDTO>(@"EXEC ART_MUSICA_SOLICITUD_CELEBRA @EstadoId", new SqlParameter("EstadoId", EstadoId)).ToList();
                }


            }
            catch (Exception)
            {
                lstmodel = null;
                throw;
            }

            return lstmodel;
        }
    }



}
