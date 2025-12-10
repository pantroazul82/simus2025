using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SM.Datos.DTO;
using SM.SIPA;

namespace SM.Datos.Agentes
{
    /// <summary>
    /// Clase de datos para crear, consultar, editar la experiencia profesional y musical de los agentes.
    /// </summary>
    public class ExperienciaServicio
    {
        #region Consultas
        public static ART_MUSICA_AGENTE_EXPERIENCIA ConsultarExperienciaPorId(int ExperienciaId)
        {
            var experiencia = new ART_MUSICA_AGENTE_EXPERIENCIA();
            try
            {
                using (var context = new SIPAEntities())
                {

                    experiencia = context.ART_MUSICA_AGENTE_EXPERIENCIA.Where(x => x.Id == ExperienciaId).FirstOrDefault();

                }
                return experiencia;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<ART_MUSICA_AGENTE_EXPERIENCIA> ConsultarExperienciaPorAgente(int AgenteId, int Tipo)
        {
            var list = new List<ART_MUSICA_AGENTE_EXPERIENCIA>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    list = context.ART_MUSICA_AGENTE_EXPERIENCIA.Where(x => x.AgenteId == AgenteId && x.Tipo == Tipo).ToList();

                }
                return list;

            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Actualizacion
        public static void CrearExperiencia(int AgenteId,
                                                string Empresa,
                                                string titulo,
                                                int MesInicio,
                                                int AnoInicio,
                                                int MesFinal,
                                                int AnoFinal,
                                                bool EsActual,
                                                int tipo,
                                                string Descripcion)
        {
            try
            {
                using (var context = new SIPAEntities())
                {

                    var experiencia = new ART_MUSICA_AGENTE_EXPERIENCIA

                    {
                        AgenteId = AgenteId,
                        AnoFin = AnoFinal,
                        AnoInicio = AnoInicio,
                        Descripcion = Descripcion,
                        Empresa = Empresa,
                        MesFin = MesFinal,
                        MesInicio = MesInicio,
                        Tipo = tipo,
                        Titulo = titulo,
                        TrabajoActual = EsActual,

                    };
                    context.ART_MUSICA_AGENTE_EXPERIENCIA.Add(experiencia);
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void ActualizarExperiencia(int ExperienciaId,
                                                 string Empresa,
                                                 string titulo,
                                                 int MesInicio,
                                                 int AnoInicio,
                                                 int MesFinal,
                                                 int AnoFinal,
                                                 bool EsActual,
                                                 int tipo,
                                                 string Descripcion)
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    var experiencia = context.ART_MUSICA_AGENTE_EXPERIENCIA.Where(x => x.Id == ExperienciaId).FirstOrDefault();
                    if (experiencia != null)
                    {
                        experiencia.AnoFin = AnoFinal;
                        experiencia.AnoInicio = AnoInicio;
                        experiencia.Descripcion = Descripcion;
                        experiencia.Empresa = Empresa;
                        experiencia.MesFin = MesFinal;
                        experiencia.MesInicio = MesInicio;
                        experiencia.Tipo = tipo;
                        experiencia.Titulo = titulo;
                        experiencia.TrabajoActual = EsActual;
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void EliminarExperiencia(int ExperienciaId)
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    context.ART_MUSICA_AGENTE_EXPERIENCIA.Remove(context.ART_MUSICA_AGENTE_EXPERIENCIA.Where(x => x.Id == ExperienciaId).FirstOrDefault());
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
