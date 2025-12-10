using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SM.Datos.Agentes;
using SM.SIPA;
using SM.LibreriaComun.DTO;

namespace SM.Aplicacion.Agentes
{
    public class ExperienciaNeg
    {
        #region Consultas
        public static ExperienciaDTO ConsultarExperienciaPorId(int experienciaId)
        {
            try
            {
                var model = new ART_MUSICA_AGENTE_EXPERIENCIA();
                var datos = new ExperienciaDTO();
                model = ExperienciaServicio.ConsultarExperienciaPorId(experienciaId);

                if (model != null)
                {
                    datos.AgenteId = model.AgenteId;
                    datos.AnoFin = model.AnoFin ?? 0;
                    datos.AnoInicio = model.AnoInicio;
                    datos.Descripcion = model.Descripcion;
                    datos.Empresa = model.Empresa;
                    datos.Id = model.Id;
                    datos.MesFin = model.MesFin ?? 0;
                    datos.MesInicio = model.MesInicio;
                    datos.Tipo = model.Tipo;
                    datos.Titulo = model.Titulo;
                    datos.TrabajoActual = model.TrabajoActual ?? false;
                }


                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ExperienciaDTO> ConsultarExperienciaPorAgente(int AgenteId, int Tipo)
        {
            try
            {
                var model = new List<ART_MUSICA_AGENTE_EXPERIENCIA>();
                var listExperiencia = new List<ExperienciaDTO>();
                model = ExperienciaServicio.ConsultarExperienciaPorAgente(AgenteId, Tipo);

                if (model != null)
                {
                    foreach (var item in model)
                    {
                        var datos = new ExperienciaDTO();
                        datos.AgenteId = item.AgenteId;
                        datos.AnoFin = item.AnoFin ?? 0;
                        datos.AnoInicio = item.AnoInicio;
                        datos.Descripcion = item.Descripcion;
                        datos.Empresa = item.Empresa;
                        datos.Id = item.Id;
                        datos.MesFin = item.MesFin ?? 0;
                        datos.MesInicio = item.MesInicio;
                        datos.Tipo = item.Tipo;
                        datos.Titulo = item.Titulo;
                        datos.TrabajoActual = item.TrabajoActual ?? false;
                        listExperiencia.Add(datos);
                    }
                }


                return listExperiencia;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Actualizacion

        public static void CrearExperiencia(int ExperienciaId,ExperienciaDTO datos)
        {
            try
            {
                if (ExperienciaId == 0)
                {
                    ExperienciaServicio.CrearExperiencia(datos.AgenteId,
                                                         datos.Empresa,
                                                         datos.Titulo,
                                                         datos.MesInicio,
                                                         datos.AnoInicio,
                                                         datos.MesFin,
                                                         datos.AnoFin,
                                                         datos.TrabajoActual,
                                                         datos.Tipo,
                                                         datos.Descripcion);
                }
                else
                {
                    ExperienciaServicio.ActualizarExperiencia(ExperienciaId,
                                                   datos.Empresa,
                                                   datos.Titulo,
                                                   datos.MesInicio,
                                                   datos.AnoInicio,
                                                   datos.MesFin,
                                                   datos.AnoFin,
                                                   datos.TrabajoActual,
                                                   datos.Tipo,
                                                   datos.Descripcion);
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static void EliminarExperiencia(int ExperienciaId)
        {
            try
            {
                ExperienciaServicio.EliminarExperiencia(ExperienciaId);
            }

            catch (Exception ex)
            {
                throw ex;
            }

        }
      
        #endregion
    }
}
