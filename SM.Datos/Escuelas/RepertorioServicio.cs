using SM.LibreriaComun.DTO.FichaAsesoria;
using SM.SIPA;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SM.Datos.Escuelas
{
    public class RepertorioServicio
    {
        #region Actualización
        public static int Agregar(ART_MUSICA_ESCUELA_REPERTORIOS registro)
        {
            int registroId = 0;
            try
            {
                using (var context = new SIPAEntities())
                {
                    context.ART_MUSICA_ESCUELA_REPERTORIOS.Add(registro);
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

        public static void Actualizar(int registroId, RepertorioNuevoDTO datos, int UsuarioId)
        {
            try
            {

                using (var context = new SIPAEntities())
                {
                    var entidad = context.ART_MUSICA_ESCUELA_REPERTORIOS.Where(x => x.Id == registroId).FirstOrDefault();

                    if (entidad != null)
                    {
                        entidad.Arreglista = datos.Arreglista;
                        entidad.Compositor = datos.Compositor;
                        entidad.Dificultad = datos.Dificultad;
                        entidad.Nombre = datos.Nombre;
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
                    context.ART_MUSICA_ESCUELA_REPERTORIOS.Remove(context.ART_MUSICA_ESCUELA_REPERTORIOS.Where(x => x.Id == Id).FirstOrDefault());
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
        public static List<ART_MUSICA_ESCUELA_REPERTORIOS> ConsultarPorEscuelaId(decimal EscuelaId)
        {

            var listado = new List<ART_MUSICA_ESCUELA_REPERTORIOS>();

            try
            {
                using (var context = new SIPAEntities())
                {

                    listado = context.ART_MUSICA_ESCUELA_REPERTORIOS.Where(x => x.EscuelaId == EscuelaId).ToList();


                }
                return listado;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static ART_MUSICA_ESCUELA_REPERTORIOS ConsultarPorId(int Id)
        {

            var listado = new ART_MUSICA_ESCUELA_REPERTORIOS();

            try
            {
                using (var context = new SIPAEntities())
                {

                    listado = context.ART_MUSICA_ESCUELA_REPERTORIOS.Where(x => x.Id == Id).FirstOrDefault(); 


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
