using SM.LibreriaComun.DTO.FichaAsesoria;
using SM.SIPA;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SM.Datos.Escuelas
{
   public  class ClasificacionServicio
    {
        #region Actualización
        public static int Agregar(ART_MUSICA_ESCUELA_CLASIFICACION registro)
        {
            int registroId = 0;
            try
            {
                using (var context = new SIPAEntities())
                {
                    context.ART_MUSICA_ESCUELA_CLASIFICACION.Add(registro);
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

        public static void Actualizar(int registroId, ClasificacionNuevoDTO datos, int UsuarioId)
        {
            try
            {

                using (var context = new SIPAEntities())
                {
                    var entidad = context.ART_MUSICA_ESCUELA_CLASIFICACION.Where(x => x.Id == registroId).FirstOrDefault();

                    if (entidad != null)
                    {
                        entidad.Bueno = datos.Bueno;
                        //entidad.Clasificacion = datos.Clasificacion;
                        //entidad.ClasificacionId = datos.ClasificacionId;
                        entidad.DEFICIENTE = datos.DEFICIENTE;
                        entidad.NOSEREALIZA = datos.NOSEREALIZA;
                        entidad.REGULAR = datos.REGULAR;
                        //entidad.Tipo = datos.Tipo;
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
        #endregion

        #region Consulta

        public static ART_MUSICA_ESCUELA_CLASIFICACION ConsultarPorId(int Id)
        {

            var listado = new ART_MUSICA_ESCUELA_CLASIFICACION();

            try
            {
                using (var context = new SIPAEntities())
                {

                    listado = context.ART_MUSICA_ESCUELA_CLASIFICACION.Where(x => x.Id == Id).FirstOrDefault();


                }
                return listado;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<ART_MUSICA_ESCUELA_CLASIFICACION> ConsultarPorEscuelaId(decimal EscuelaId, string tipo)
        {

            var listado = new List<ART_MUSICA_ESCUELA_CLASIFICACION>();

            try
            {
                using (var context = new SIPAEntities())
                {

                    listado = context.ART_MUSICA_ESCUELA_CLASIFICACION.Where(x => x.EscuelaId == EscuelaId && x.Tipo == tipo).ToList();


                }
                return listado;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<ART_MUSICA_ESCUELA_CLASIFICACION> ValidarExisteEscuela(decimal EscuelaId)
        {

            var listado = new List<ART_MUSICA_ESCUELA_CLASIFICACION>();

            try
            {
                using (var context = new SIPAEntities())
                {

                    listado = context.ART_MUSICA_ESCUELA_CLASIFICACION.Where(x => x.EscuelaId == EscuelaId).ToList();


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
