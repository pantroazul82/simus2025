using SM.LibreriaComun.DTO.FichaAsesoria;
using SM.SIPA;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SM.Datos.Escuelas
{
    public class ObservacionServicio
    {
        #region Actualización
        public static int Agregar(ART_MUSICA_ESCUELA_OBSERVACION registro)
        {
            int registroId = 0;
            try
            {
                using (var context = new SIPAEntities())
                {
                    context.ART_MUSICA_ESCUELA_OBSERVACION.Add(registro);
                    context.SaveChanges();
                    registroId = registro.Id;

                }

                return registroId;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void Actualizar(int registroId, ObservacionNuevoDTO datos, int UsuarioId)
        {
            try
            {

                using (var context = new SIPAEntities())
                {
                    var entidad = context.ART_MUSICA_ESCUELA_OBSERVACION.Where(x => x.Id == registroId).FirstOrDefault();

                    if (entidad != null)
                    {
                        entidad.Observaciones = datos.Observaciones;
                        entidad.Recomendaciones = datos.Recomendaciones;
                        entidad.Tipo = datos.Tipo;
                        entidad.FechaActualizacion = DateTime.Now;
                        entidad.UsuarioId = UsuarioId; 
                        entidad.EscuelaId = datos.EscuelaId;
                    }
                    context.SaveChanges();

                }
            }
            catch (Exception)
            { throw; }
        }

        public static void Eliminar(int Id)
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    context.ART_MUSICA_ESCUELA_OBSERVACION.Remove(context.ART_MUSICA_ESCUELA_OBSERVACION.Where(x => x.Id == Id).FirstOrDefault());
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Consulta
        public static List<ART_MUSICA_ESCUELA_OBSERVACION> ConsultarPorEscuelaId(decimal EscuelaId)
        {

            var listado = new List<ART_MUSICA_ESCUELA_OBSERVACION>();

            try
            {
                using (var context = new SIPAEntities())
                {

                    listado = context.ART_MUSICA_ESCUELA_OBSERVACION.Where(x => x.EscuelaId == EscuelaId).ToList();


                }
                return listado;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static ART_MUSICA_ESCUELA_OBSERVACION ConsultarPorTipo(decimal EscuelaId, string Tipo)
        {

            var listado = new ART_MUSICA_ESCUELA_OBSERVACION();

            try
            {
                using (var context = new SIPAEntities())
                {

                    listado = context.ART_MUSICA_ESCUELA_OBSERVACION.Where(x => x.EscuelaId == EscuelaId && x.Tipo == Tipo ).FirstOrDefault(); 


                }
                return listado;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static ART_MUSICA_ESCUELA_OBSERVACION ConsultarPorId(int Id)
        {

            var listado = new ART_MUSICA_ESCUELA_OBSERVACION();

            try
            {
                using (var context = new SIPAEntities())
                {

                    listado = context.ART_MUSICA_ESCUELA_OBSERVACION.Where(x => x.Id == Id).FirstOrDefault();


                }
                return listado;

            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
