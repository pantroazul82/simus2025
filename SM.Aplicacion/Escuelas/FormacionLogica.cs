using SM.SIPA;
using SM.LibreriaComun.DTO;
using SM.Datos.Escuelas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Aplicacion.Escuelas
{
    public class FormacionLogica
    {
        #region Niveles
        public static void InsertarNiveles(NivelesFormacionDTO nivel)
        {
            try
            {
                int intId = Formacion.ValidarNivelesFormacion(nivel.FormacionPracticaNuevoId, nivel.NombreNiveles);

                if (intId == 0)
                {
                    ART_MUSICA_PRACTICA_NIVEL registro = new ART_MUSICA_PRACTICA_NIVEL
                    {
                        EscuelaId = nivel.EscuelaId,
                        FormacionPracticaId = nivel.FormacionPracticaNuevoId,
                        CantidadGrupos = Convert.ToInt32(nivel.Cantidadgrupos),
                        CantidadIntegrantes = Convert.ToInt32(nivel.CantidadIntegrantes),
                        HorasSemanal = Convert.ToInt32(nivel.HoraSemanal),
                        Nivel = nivel.NombreNiveles
                    };
                    Formacion.InsertarNiveles(registro);
                }
                else
                {
                    Formacion.ActualizarNiveles(nivel, intId);
                }


            }
            catch (Exception ex)
            { throw ex; }
        }

        public static List<NivelesFormacionDTO> ConsultarNiveles(int FormacionPracticaId)
        {
            var listBasica = new List<NivelesFormacionDTO>();
            try
            {

                return listBasica = Formacion.ConsultarNiveles(FormacionPracticaId);

            }
            catch (Exception ex)
            { throw ex; }
        }

        public static void EliminarPracticaNivel(int PracticaNivelId)
        {
            try
            {
                Formacion.EliminarPracticaNivel(PracticaNivelId);

            }
            catch (Exception ex)
            { throw ex; }
        }
        #endregion
        #region Actualizacion

        public static bool ValidarFormacion(decimal entId)
        {
            bool validar = false;
            try
            {
                validar = Formacion.ValidarFormacion(entId);
            }
            catch (Exception ex)
            { throw ex; }
            return validar;
        }
        public static void Grabar(decimal entId,
                                   string entProcesosFormacion,
                                   bool entPracticasMusicalesOrientadasMusico,
                                   bool entTalleresIndependientes,
                                   bool entProgramasFormuladosEscrito,
                                   int iniciacionDuracionPromedioMeses,
                                   int totalpoblacionInicacion,
                                   int iniciacionIntensidadHorasSemanal,
                                   string iniciacionObservaciones,
                                   int basicoDuracionPromedioMeses,
                                   int totalpoblacionBasica,
                                   int basicoIntensidadHorasSemanal,
                                   string basicoObservaciones,
                                   int medioDuracionPromedioMeses,
                                   int totalPoblacionMedio,
                                   int medioIntensidadHorasSemanal,
                                   string medioObservaciones,
                                   int cursoDuracionPromedioSemana,
                                   int TotalPoblacionCurso,
                                   int cursoIntensidadHorasSemanal,
                                   string cursoObservaciones,
                                   int pedagogicasDuracionPromedioSemana,
                                   int TotalPoblacionPedagogia,
                                   int pedagogicasIntensidadHorasSemanal,
                                   string pedagogicasObservaciones,
                                    List<string> practicamusicalselecionadas,
                                    int SimusUsuarioId,
                                    string NombreUsuario,
                                    string strIP)
        {
            try
            {

                bool validar = Formacion.ValidarFormacion(entId);

                if (!validar)
                {
                    Formacion.Insertar(entId);
                }

                Formacion.Actualizar(entId,
                                     entProcesosFormacion,
                                     entPracticasMusicalesOrientadasMusico,
                                     entTalleresIndependientes,
                                     entProgramasFormuladosEscrito,
                                     iniciacionDuracionPromedioMeses,
                                     totalpoblacionInicacion,
                                     iniciacionIntensidadHorasSemanal,
                                     iniciacionObservaciones,
                                     basicoDuracionPromedioMeses,
                                     totalpoblacionBasica,
                                     basicoIntensidadHorasSemanal,
                                     basicoObservaciones,
                                     medioDuracionPromedioMeses,
                                     totalPoblacionMedio,
                                     medioIntensidadHorasSemanal,
                                     medioObservaciones,
                                     cursoDuracionPromedioSemana,
                                     TotalPoblacionCurso,
                                     cursoIntensidadHorasSemanal,
                                     cursoObservaciones,
                                     pedagogicasDuracionPromedioSemana,
                                     TotalPoblacionPedagogia,
                                     pedagogicasIntensidadHorasSemanal,
                                     pedagogicasObservaciones,
                                     practicamusicalselecionadas,
                                     SimusUsuarioId,
                                     NombreUsuario,
                                     strIP);




            }
            catch (Exception ex)
            { throw ex; }
        }


        public static void Insertar(decimal entId)
        {
            try
            {
                bool validar = Formacion.ValidarFormacion(entId);

                if (!validar)
                {
                    Formacion.Insertar(entId);
                }


            }
            catch (Exception ex)
            { throw ex; }
        }
        public static void GrabarNuevo(decimal entId,
                              string entProcesosFormacion,
                              bool entTalleresIndependientes,
                              bool entProgramasFormuladosEscrito,
                              int SimusUsuarioId,
                               string NombreUsuario,
                               string strIP)
        {
            try
            {


                Formacion.ActualizarNuevo(entId,
                                     entProcesosFormacion,
                                     entTalleresIndependientes,
                                     entProgramasFormuladosEscrito,
                                     SimusUsuarioId,
                                     NombreUsuario,
                                     strIP);




            }
            catch (Exception ex)
            { throw ex; }
        }
        #endregion
        #region Consultas
        public static FormacionDTO ConsultarFormacionPorId(decimal EscuelaId)
        {
            try
            {
                var model = new List<ART_ME_ART_MUSICA_ENTIDAD_FORMACION_TOTALES_Result>();
                var datos = new FormacionDTO();
                model = Formacion.ConsultarFormacionPorId(EscuelaId);

                if (model.Count > 0)
                {
                    datos.BASICO_DURACION_PROMEDIO_MESES = model[0].BASICO_DURACION_PROMEDIO_MESES ?? 0;
                    datos.BASICO_INTENSIDAD_HORAS_SEMANAL = model[0].BASICO_INTENSIDAD_HORAS_SEMANAL ?? 0;
                    datos.BASICO_OBSERVACIONES = model[0].BASICO_OBSERVACIONES;
                    datos.TOTALPOBLACIONBASICO = model[0].TOTAL_BASICO_POBLACION ?? 0;
                    datos.CURSO_DURACION_PROCURSO_SEMANA = model[0].CURSO_DURACION_PROCURSO_SEMANA ?? 0;
                    datos.CURSO_INTENSIDAD_HORAS_SEMANAL = model[0].CURSO_INTENSIDAD_HORAS_SEMANAL ?? 0;
                    datos.CURSO_OBSERVACIONES = model[0].CURSO_OBSERVACIONES;
                    datos.TOTALPOBLACIONCURSO = model[0].TOTAL_CURSOS_POBLACION ?? 0;
                    datos.ENT_ID = model[0].ENT_ID;
                    datos.ENT_PRACTICAS_MUSICALES_ORIENTADAS_MUSICO = model[0].ENT_PRACTICAS_MUSICALES_ORIENTADAS_MUSICO;
                    datos.ENT_PROCESOS_FORMACION = model[0].ENT_PROCESOS_FORMACION;
                    datos.ENT_PROGRAMAS_FORMULADOS_ESCRITO = model[0].ENT_PROGRAMAS_FORMULADOS_ESCRITO;
                    datos.ENT_TALLERES_INDEPENDIENTES = model[0].ENT_TALLERES_INDEPENDIENTES;
                    datos.INICIACION_DURACION_PROMEDIO_MESES = model[0].INICIACION_DURACION_PROMEDIO_MESES ?? 0;
                    datos.INICIACION_INTENSIDAD_HORAS_SEMANAL = model[0].INICIACION_INTENSIDAD_HORAS_SEMANAL ?? 0;
                    datos.INICIACION_OBSERVACIONES = model[0].INICIACION_OBSERVACIONES;
                    datos.TOTALPOBLACIONINICACION = model[0].TOTAL_INICACION_POBLACION ?? 0;
                    datos.MEDIO_DURACION_PROMEDIO_MESES = model[0].MEDIO_DURACION_PROMEDIO_MESES ?? 0;
                    datos.MEDIO_INTENSIDAD_HORAS_SEMANAL = model[0].MEDIO_DURACION_PROMEDIO_MESES ?? 0;
                    datos.MEDIO_OBSERVACIONES = model[0].MEDIO_OBSERVACIONES;
                    datos.TOTALPOBLACIONMEDIO = model[0].TOTAL_MEDIO_POBLACION ?? 0;
                    datos.PEDAGOGIAS_DURACION_PROPEDAGOGIAS_SEMANA = model[0].PEDAGOGIAS_DURACION_PROPEDAGOGIAS_SEMANA ?? 0;
                    datos.PEDAGOGIAS_INTENSIDAD_HORAS_SEMANAL = model[0].PEDAGOGIAS_INTENSIDAD_HORAS_SEMANAL ?? 0;
                    datos.PEDAGOGIAS_OBSERVACIONES = model[0].PEDAGOGIAS_OBSERVACIONES;
                    datos.TOTALPOBLACIONPEDAGOGIAS = model[0].TOTAL_PEDAGOGIA_POBLACION ?? 0;

                }

                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static FormacionDatosDTO ObtenerFormacionId(decimal EscuelaId)
        {
            try
            {
                var model = new FormacionDatosDTO();
                model = Formacion.ObtenerFormacionId(EscuelaId);

                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
