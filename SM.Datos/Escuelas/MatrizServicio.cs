using SM.LibreriaComun.DTO.FichaAsesoria;
using SM.SIPA;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SM.Datos.Escuelas
{
    public class MatrizServicio
    {
        #region Actualización
        public static int Agregar(ART_MUSICA_ESCUELA_MATRIZ registro)
        {
            int registroId = 0;
            try
            {
                using (var context = new SIPAEntities())
                {
                    context.ART_MUSICA_ESCUELA_MATRIZ.Add(registro);
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

        public static void Actualizar(int registroId, MatrizNuevoDTO datos, int UsuarioId)
        {
            try
            {

                using (var context = new SIPAEntities())
                {
                    var entidad = context.ART_MUSICA_ESCUELA_MATRIZ.Where(x => x.Id == registroId).FirstOrDefault();

                    if (entidad != null)
                    {
                        //entidad.Clasificacion = entidad.Clasificacion;
                        //entidad.ClasificacionId = datos.ClasificacionId;
                        entidad.Dificultades = datos.Dificultades;
                        entidad.Fortaleza = datos.Fortaleza;
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
        public static List<ART_MUSICA_ESCUELA_MATRIZ> ConsultarPorEscuelaId(decimal EscuelaId, string tipo)
        {

            var listado = new List<ART_MUSICA_ESCUELA_MATRIZ>();

            try
            {
                using (var context = new SIPAEntities())
                {

                    listado = context.ART_MUSICA_ESCUELA_MATRIZ.Where(x => x.EscuelaId == EscuelaId && x.Tipo == tipo).ToList();


                }
                return listado;

            }
            catch (Exception)
            {
                throw;
            }
        }


        public static List<ART_MUSICA_ESCUELA_MATRIZ> ValidarExisteEscuela(decimal EscuelaId)
        {

            var listado = new List<ART_MUSICA_ESCUELA_MATRIZ>();

            try
            {
                using (var context = new SIPAEntities())
                {

                    listado = context.ART_MUSICA_ESCUELA_MATRIZ.Where(x => x.EscuelaId == EscuelaId ).ToList();


                }
                return listado;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static ART_MUSICA_ESCUELA_MATRIZ ConsultarPorId(int Id)
        {

            var listado = new ART_MUSICA_ESCUELA_MATRIZ();

            try
            {
                using (var context = new SIPAEntities())
                {

                    listado = context.ART_MUSICA_ESCUELA_MATRIZ.Where(x => x.Id == Id).FirstOrDefault();


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
