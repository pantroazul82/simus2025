using SM.LibreriaComun.DTO.FichaAsesoria;
using SM.SIPA;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SM.Datos.Escuelas
{
    public class InstrumentoServicio
    {
        #region Actualización
        public static int Agregar(ART_MUSICA_ESCUELA_INSTRUMENTOS registro)
        {
            int registroId = 0;
            try
            {
                using (var context = new SIPAEntities())
                {
                    context.ART_MUSICA_ESCUELA_INSTRUMENTOS.Add(registro);
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

        public static void Actualizar(int registroId, InstrumentoNuevoDTO datos, int UsuarioId)
        {
            try
            {

                using (var context = new SIPAEntities())
                {
                    var entidad = context.ART_MUSICA_ESCUELA_INSTRUMENTOS.Where(x => x.Id == registroId).FirstOrDefault();

                    if (entidad != null)
                    {
                        entidad.CantidadBuenos = datos.CantidadBuenos;
                        entidad.CantidadMalos = datos.CantidadMalos;
                        entidad.CantidadMincultura = datos.CantidadMincultura;
                        entidad.CantidadRegular = datos.CantidadRegular;
                        entidad.CantidadPerdidos = datos.CantidadPerdidos;
                        entidad.Descripcion = datos.Descripcion;
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
                    context.ART_MUSICA_ESCUELA_INSTRUMENTOS.Remove(context.ART_MUSICA_ESCUELA_INSTRUMENTOS.Where(x => x.Id == Id).FirstOrDefault());
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
        public static ART_MUSICA_ESCUELA_INSTRUMENTOS ConsultarPorId(int Id)
        {

            var listado = new ART_MUSICA_ESCUELA_INSTRUMENTOS();

            try
            {
                using (var context = new SIPAEntities())
                {

                    listado = context.ART_MUSICA_ESCUELA_INSTRUMENTOS.Where(x => x.Id == Id).FirstOrDefault();


                }
                return listado;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<ART_MUSICA_ESCUELA_INSTRUMENTOS> ConsultarPorEscuelaId(decimal EscuelaId)
        {

            var listado = new List<ART_MUSICA_ESCUELA_INSTRUMENTOS>();

            try
            {
                using (var context = new SIPAEntities())
                {

                    listado = context.ART_MUSICA_ESCUELA_INSTRUMENTOS.Where(x => x.EscuelaId == EscuelaId).ToList();


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
