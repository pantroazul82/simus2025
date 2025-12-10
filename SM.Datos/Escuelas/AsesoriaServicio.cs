using SM.LibreriaComun.DTO.FichaAsesoria;
using SM.SIPA;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SM.Datos.Escuelas
{
    public class AsesoriaServicio
    {
        #region Actualización
        public static int Agregar(ART_MUSICA_ESCUELA_ASESORIA registro)
        {
            int registroId = 0;
            try
            {
                using (var context = new SIPAEntities())
                {
                    context.ART_MUSICA_ESCUELA_ASESORIA.Add(registro);
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

        public static void Actualizar(int EscuelaId, AsesoriaNuevoDTO datos, int UsuarioId)
        {
            try
            {

                using (var context = new SIPAEntities())
                {
                    var entidad = context.ART_MUSICA_ESCUELA_ASESORIA.Where(x => x.EscuelaId == EscuelaId).FirstOrDefault();

               

                    if (entidad != null)
                    {
                        entidad.NombreDirector = datos.NombreDirector;
                        entidad.NombreAgrupacion = datos.NombreAgrupacion;
                        entidad.PracticaColectiva = datos.PracticaColectiva;
                        entidad.PromedioAnualPresentaciones = Convert.ToInt32(datos.PromedioAnualPresentaciones);
                        entidad.PromedioMesesPresentaciones = Convert.ToInt32(datos.PromedioMesesPresentaciones);
                        entidad.Basico = datos.Basico;
                        entidad.Medio = datos.Medio;
                        entidad.Avanzado = datos.Avanzado;
                        entidad.Conformacion = Convert.ToInt32(datos.AnoValue);
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

        public static void ActualizarConcepto(int EscuelaId, AsesoriaConceptoDTO datos, int UsuarioId)
        {
            try
            {

                using (var context = new SIPAEntities())
                {
                    var entidad = context.ART_MUSICA_ESCUELA_ASESORIA.Where(x => x.EscuelaId == EscuelaId).FirstOrDefault();



                    if (entidad != null)
                    {
                        entidad.AspectoAsesorado = datos.AspectoAsesorado;
                        entidad.Concepto = datos.Concepto;
                        entidad.Mecanismo = datos.Mecanismo;
                        entidad.Recomendacion = datos.Recomendacion;
                        entidad.FechaActualizacion = DateTime.Now;
                        entidad.UsuarioId = UsuarioId;

                    }
                    context.SaveChanges();

                }
            }
            catch (Exception)
            { throw; }
        }
        #endregion

        #region Consulta
        public static ART_MUSICA_ESCUELA_ASESORIA ConsultarPorEscuelaId(decimal EscuelaId)
        {

            var registro = new ART_MUSICA_ESCUELA_ASESORIA();

            try
            {
                using (var context = new SIPAEntities())
                {

                    registro = context.ART_MUSICA_ESCUELA_ASESORIA.Where(x => x.EscuelaId == EscuelaId).FirstOrDefault(); 


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
