using SM.Datos.AuditoriaData;
using SM.LibreriaComun.DTO;
using SM.SIPA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Datos.Escuelas
{
    public class Formacion
    {
        #region Niveles
        public static void InsertarNiveles(ART_MUSICA_PRACTICA_NIVEL formacion)
        {
            try
            {
                using (var context = new SIPAEntities())
                {

                    context.ART_MUSICA_PRACTICA_NIVEL.Add(formacion);
                    context.SaveChanges();
                }
            }
            catch (Exception)
            { throw; }
        }


        public static void ActualizarNiveles(NivelesFormacionDTO nivel, int Id)
        {
            try
            {
                using (var context = new SIPAEntities())
                {

                    var datos = context.ART_MUSICA_PRACTICA_NIVEL.Where(x => x.Id == Id ).SingleOrDefault();
                    if (datos != null && datos.Id > 0)
                    {
                        datos.CantidadIntegrantes = Convert.ToInt32(nivel.CantidadIntegrantes);
                        datos.CantidadGrupos = Convert.ToInt32(nivel.Cantidadgrupos);
                        datos.HorasSemanal = Convert.ToInt32(nivel.HoraSemanal);
                    }
                    context.SaveChanges();
                }
            }
            catch (Exception)
            { throw; }
        }
        public static int ValidarNivelesFormacion(int FormacionPracticaId, string Nivel)
        {
            try
            {
                int intId = 0;
                using (var context = new SIPAEntities())
                {
                    // Ojo esto se valida al crear formación
                    var datos = context.ART_MUSICA_PRACTICA_NIVEL.Where(x => x.FormacionPracticaId == FormacionPracticaId && x.Nivel == Nivel).SingleOrDefault();
                    if (datos != null && datos.Id > 0)
                        intId = datos.Id;

                    return intId;
                }
            }
            catch (Exception)
            { throw; }
        }
        public static List<NivelesFormacionDTO> ConsultarNiveles(int FormacionPracticaId)
        {
            var listBasica = new List<NivelesFormacionDTO>();

            try
            {
                using (var context = new SIPAEntities())
                {


                    listBasica = (from a in context.ART_MUSICA_PRACTICA_NIVEL
                                  where a.FormacionPracticaId == FormacionPracticaId
                                  orderby a.Nivel
                                  select new NivelesFormacionDTO
                                  {
                                      NombreNiveles = a.Nivel,
                                      Cantidadgrupos = a.CantidadGrupos.ToString(),
                                      CantidadIntegrantes = a.CantidadIntegrantes.ToString(),
                                      HoraSemanal = a.HorasSemanal.ToString(),
                                      FormacionPracticaNuevoId = a.FormacionPracticaId,
                                      EscuelaId = a.EscuelaId,
                                      Id = a.Id
                                  }).ToList();

                }
                return listBasica;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void EliminarPracticaNivel(int PracticaNivelId)
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    context.ART_MUSICA_PRACTICA_NIVEL.Remove(context.ART_MUSICA_PRACTICA_NIVEL.Where(x => x.Id == PracticaNivelId).FirstOrDefault());
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Actualización
        public static void Insertar(decimal entId)
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    ART_MUSICA_ENTIDAD_FORMACION formacion = new ART_MUSICA_ENTIDAD_FORMACION
                    {
                        ENT_ID = entId,
                        ENT_PRACTICAS_MUSICALES_ORIENTADAS_MUSICO = false,
                        ENT_TALLERES_INDEPENDIENTES = false,
                        ENT_PROGRAMAS_FORMULADOS_ESCRITO = false,
                        ENT_FOMRACION_MUSICAL_PLAN_NAL_MUSICA_CONVIVENCIA = false
                    };

                    context.ART_MUSICA_ENTIDAD_FORMACION.Add(formacion);
                    context.SaveChanges();
                }
            }
            catch (Exception)
            { throw; }
        }


        public static bool ValidarFormacion(decimal EntId)
        {
            try
            {
                bool validar = false;
                using (var context = new SIPAEntities())
                {
                    // Ojo esto se valida al crear formación
                    var datos = context.ART_MUSICA_ENTIDAD_FORMACION.Where(x => x.ENT_ID == EntId).SingleOrDefault();
                    if (datos != null)
                        validar = true;

                    return validar;
                }
            }
            catch (Exception)
            { throw; }
        }
        public static void Actualizar(decimal entId,
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

                using (var context = new SIPAEntities())
                {
                    context.ART_ME_ART_MUSICA_ENTIDAD_FORMACION_TOTALES_Actualizar(entId,
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
                                                                             pedagogicasObservaciones);

                    if (practicamusicalselecionadas != null)
                    {
                        EliminarPracticasMusicales(entId);
                        ActualizarPracticasMusicales(entId, practicamusicalselecionadas);
                    }



                    //Auditoria
                    string temp;
                    temp = string.Format("El usuario {0} ({1}) actualizó el {2} la  escuela de música - formación.\nDatos actuales:\n{3} ", NombreUsuario, SimusUsuarioId, DateTime.Now, "ART_MUSICA_ENTIDAD_FORMACION");
                    StringBuilder stringBuilder = new StringBuilder();
                    stringBuilder.AppendLine(temp);
                    ART_MUSICA_REGISTRO_OPERACION registroOperacion = new ART_MUSICA_REGISTRO_OPERACION { Categoria = CategoriaRegistroOperacion.EscuelasFormación.ToString(), IpUsuario = strIP, RegistroId = Convert.ToInt32(entId), UsuarioId = SimusUsuarioId, NombreUsuario = NombreUsuario, Descripcion = stringBuilder.ToString(), FechaRegistro = DateTime.Now, Operacion = "Actualización" };

                    RegistroOperacionServicio auditoria = new RegistroOperacionServicio();
                    auditoria.Crear(registroOperacion);
                }
            }
            catch (Exception)
            { throw; }
        }


        public static void ActualizarNuevo(decimal entId,
                                    string entProcesosFormacion,
                                    bool entTalleresIndependientes,
                                    bool entProgramasFormuladosEscrito,
                                    int SimusUsuarioId,
                                    string NombreUsuario,
                                    string strIP)
        {
            try
            {

                using (var context = new SIPAEntities())
                {

                    var entidad = context.ART_MUSICA_ENTIDAD_FORMACION.Where(x => x.ENT_ID == entId).FirstOrDefault();

                    if (entidad != null)
                    {
                        entidad.ENT_PROCESOS_FORMACION = entProcesosFormacion;
                        entidad.ENT_TALLERES_INDEPENDIENTES = entTalleresIndependientes;
                        entidad.ENT_PROGRAMAS_FORMULADOS_ESCRITO = entProgramasFormuladosEscrito;
                    }
                    context.SaveChanges();
                    //Auditoria
                    string temp;
                    temp = string.Format("El usuario {0} ({1}) actualizó el {2} la  escuela de música - formación.\nDatos actuales:\n{3} ", NombreUsuario, SimusUsuarioId, DateTime.Now, "ART_MUSICA_ENTIDAD_FORMACION");
                    StringBuilder stringBuilder = new StringBuilder();
                    stringBuilder.AppendLine(temp);
                    ART_MUSICA_REGISTRO_OPERACION registroOperacion = new ART_MUSICA_REGISTRO_OPERACION { Categoria = CategoriaRegistroOperacion.EscuelasFormación.ToString(), IpUsuario = strIP, RegistroId = Convert.ToInt32(entId), UsuarioId = SimusUsuarioId, NombreUsuario = NombreUsuario, Descripcion = stringBuilder.ToString(), FechaRegistro = DateTime.Now, Operacion = "Actualización" };

                    RegistroOperacionServicio auditoria = new RegistroOperacionServicio();
                    auditoria.Crear(registroOperacion);
                }
            }
            catch (Exception)
            { throw; }
        }

        public static void ActualizarPracticasMusicales(decimal entId, List<string> practicamusicalselecionadas)
        {
            try
            {
                using (var context = new SIPAEntities())
                {

                    foreach (string item in practicamusicalselecionadas)
                    {
                        context.ART_ME_ART_MUSICA_PRAC_MUS_ENT_FORMACION_Insertar(entId, Convert.ToInt16(item));
                    }

                }

            }
            catch (Exception)
            { throw; }
        }



        public static void EliminarPracticasMusicales(decimal entId)
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    context.ART_ME_ART_MUSICA_PRAC_MUS_ENT_FORMACION_EliminarPorENT_ID(entId);

                }

            }
            catch (Exception)
            { throw; }
        }
        public static void Eliminar(decimal entId)
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    context.ART_ME_ART_MUSICA_ENTIDAD_FORMACION_Eliminar(entId);
                    context.SaveChanges();
                }

            }
            catch (Exception)
            { throw; }

        }
        #endregion

        #region Consultas

        public static List<ART_ME_ART_MUSICA_PRAC_MUS_ENT_FORMACION_ObtenerPorENT_ID_Result> ConsultarPracticaMusicalSeleccionada(decimal EntId)
        {
            List<ART_ME_ART_MUSICA_PRAC_MUS_ENT_FORMACION_ObtenerPorENT_ID_Result> resultado = new List<ART_ME_ART_MUSICA_PRAC_MUS_ENT_FORMACION_ObtenerPorENT_ID_Result>();
            try
            {
                using (var context = new SIPAEntities())
                {
                    resultado = context.ART_ME_ART_MUSICA_PRAC_MUS_ENT_FORMACION_ObtenerPorENT_ID(EntId).ToList();

                }
                return resultado;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<ART_ME_ART_MUSICA_ENTIDAD_FORMACION_TOTALES_Result> ConsultarFormacionPorId(decimal EntId)
        {
            try
            {
                var model = new List<ART_ME_ART_MUSICA_ENTIDAD_FORMACION_TOTALES_Result>();
                using (var context = new SIPAEntities())
                {

                    model = context.ART_ME_ART_MUSICA_ENTIDAD_FORMACION_TOTALES(EntId).ToList();

                }
                return model;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static FormacionDatosDTO ObtenerFormacionId(decimal EntId)
        {
            try
            {
                var model = new FormacionDatosDTO();
                using (var context = new SIPAEntities())
                {

                    model = (from e in context.ART_MUSICA_ENTIDAD_FORMACION
                             where e.ENT_ID == EntId
                             select new FormacionDatosDTO
                                  {
                                      ENT_ID = e.ENT_ID,
                                      ENT_PRACTICAS_MUSICALES_ORIENTADAS_MUSICO = e.ENT_PRACTICAS_MUSICALES_ORIENTADAS_MUSICO,
                                      ENT_PROCESOS_FORMACION = e.ENT_PROCESOS_FORMACION,
                                      ENT_PROGRAMAS_FORMULADOS_ESCRITO = e.ENT_PROGRAMAS_FORMULADOS_ESCRITO,
                                      ENT_TALLERES_INDEPENDIENTES = e.ENT_TALLERES_INDEPENDIENTES
                                  }).FirstOrDefault();

                }
                return model;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<ART_ME_ART_MUSICA_ENTIDAD_FORMACION_ObtenerTodos_Result> ConsultarFormacionTodos()
        {
            try
            {
                var model = new List<ART_ME_ART_MUSICA_ENTIDAD_FORMACION_ObtenerTodos_Result>();
                using (var context = new SIPAEntities())
                {

                    model = context.ART_ME_ART_MUSICA_ENTIDAD_FORMACION_ObtenerTodos().ToList();

                }
                return model;

            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
