using SM.Datos.AuditoriaData;
using SM.Datos.DTO;
using SM.SIPA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Datos.Escuelas
{
    public class Participacion
    {
        #region Actualización
        public static void Insertar(decimal entId,
                                    int entCantidadAlumnosMenor6,
                                    int entCantidadAlumnosEntre7Y11,
                                    int entCantidadAlumnosEntre12Y18,
                                    int entCantidadAlumnosEntre19Y25,
                                    int entCantidadAlumnosMayor26,
                                    int entCantidadTotalAlumnosEdad,
                                    int entCantidadAlumnosMasculino,
                                    int entCantidadAlumnosFemenino,
                                    int entCantidadTotalAlumnosGenero,
                                    int entCantidadAlumnosRural,
                                    int entCantidadAlumnosUrbana,
                                    int entCantidadTotalAlumnosArea,
                                    int entCantidadAlumnosIndigenas,
                                    int entCantidadAlumnosAfro,
                                    int entCantidadAlumnosRom,
                                    int entCantidadAlumnosRaizales,
                                    int entCantidadAlumnosOtros,
                                    int entCantidadTotalAlumnosEtnia,
                                    int entCantidadAlumnosDiscapacitados,
                                    int entCantidadAlumnosDesplazados,
                                    int entCantidadTotalAlumnosEspeciales,
                                    bool entOrganizacionComunitaria,
                                    short entTipoOrganizacionComunitariaId,
                                    string entOtraOrganizacionComunitaria,
                                    bool entOrganizacionComunitariaProyectoEntornoEscuela,
                                    string entOtroProyectoEntornoEscuela,
                                    string entNombreOrganizacion,
                                    int entIntegrantesOrganizacion,
                                    string entNombrePresidenteOrganizacion,
                                    string entTelefonoCelularPresidenteOrganizacion,
                                    string entTelefonoFijoPresidenteOrganizacion,
                                    string entCorreoElectronicoPresidenteOrganizacion,
                                    int entCantidadAlumnosMayor60,
                                    int cantidadCupos,
                                    int cantidadRedUnidos,
                                    string[] proyectos,
                                    int SimusUsuarioId,
                                    string NombreUsuario,
                                    string strIP)
        {
            try
            {
                short? shortOrganizacionComunitariaId = null;
                if (entTipoOrganizacionComunitariaId > 0)
                    shortOrganizacionComunitariaId = entTipoOrganizacionComunitariaId;
                using (var context = new SIPAEntities())
                {
                    context.ART_ME_ART_MUSICA_ENTIDAD_PARTICIPACION_Insertar(entId,
                                                                             entCantidadAlumnosMenor6,
                                                                             entCantidadAlumnosEntre7Y11,
                                                                             entCantidadAlumnosEntre12Y18,
                                                                             entCantidadAlumnosEntre19Y25,
                                                                             entCantidadAlumnosMayor26,
                                                                             entCantidadTotalAlumnosEdad,
                                                                             entCantidadAlumnosMasculino,
                                                                             entCantidadAlumnosFemenino,
                                                                             entCantidadTotalAlumnosGenero,
                                                                             entCantidadAlumnosRural,
                                                                             entCantidadAlumnosUrbana,
                                                                             entCantidadTotalAlumnosArea,
                                                                             entCantidadAlumnosIndigenas,
                                                                             entCantidadAlumnosAfro,
                                                                             entCantidadAlumnosRom,
                                                                             entCantidadAlumnosRaizales,
                                                                             entCantidadAlumnosOtros,
                                                                             entCantidadTotalAlumnosEtnia,
                                                                             entCantidadAlumnosDiscapacitados,
                                                                             entCantidadAlumnosDesplazados,
                                                                             entCantidadTotalAlumnosEspeciales,
                                                                             entOrganizacionComunitaria,
                                                                             shortOrganizacionComunitariaId,
                                                                             entOtraOrganizacionComunitaria,
                                                                             entOrganizacionComunitariaProyectoEntornoEscuela,
                                                                             entOtroProyectoEntornoEscuela,
                                                                             entNombreOrganizacion,
                                                                             entIntegrantesOrganizacion,
                                                                             entNombrePresidenteOrganizacion,
                                                                             entTelefonoCelularPresidenteOrganizacion,
                                                                             entTelefonoFijoPresidenteOrganizacion,
                                                                             entCorreoElectronicoPresidenteOrganizacion,
                                                                             entCantidadAlumnosMayor60);

                    ActualizarRedUnidos(entId, cantidadRedUnidos, cantidadCupos);
                    if (proyectos != null)
                        ActualizarProyectos(entId, proyectos);

                    //Auditoria
                    string temp;
                    temp = string.Format("El usuario {0} ({1}) insertó el {2} la  escuela de música - participación.\nDatos actuales:\n{3} ", NombreUsuario, SimusUsuarioId, DateTime.Now, "ART_MUSICA_ENTIDAD_PARTICIPACION");
                    StringBuilder stringBuilder = new StringBuilder();
                    stringBuilder.AppendLine(temp);
                    ART_MUSICA_REGISTRO_OPERACION registroOperacion = new ART_MUSICA_REGISTRO_OPERACION { Categoria = CategoriaRegistroOperacion.EscuelasParticipación.ToString(), IpUsuario = strIP, RegistroId = Convert.ToInt32(entId), UsuarioId = SimusUsuarioId, NombreUsuario = NombreUsuario, Descripcion = stringBuilder.ToString(), FechaRegistro = DateTime.Now, Operacion = "Actualización" };

                    RegistroOperacionServicio auditoria = new RegistroOperacionServicio();
                    auditoria.Crear(registroOperacion);
                }
            }
            catch (Exception)
            { throw; }
        }

        public static bool ValidarParticipacion(decimal EntId)
        {
            try
            {
                bool validar = false;
                using (var context = new SIPAEntities())
                {
                    // Ojo esto se valida al crear formación
                    var datos = context.ART_MUSICA_ENTIDAD_PARTICIPACION.Where(x => x.ENT_ID == EntId).SingleOrDefault();

                    if (datos != null)
                        validar = true;

                    return validar;
                }
            }
            catch (Exception)
            { throw; }
        }
        public static void Actualizar(decimal entId,
                                        int entCantidadAlumnosMenor6,
                                        int entCantidadAlumnosEntre7Y11,
                                        int entCantidadAlumnosEntre12Y18,
                                        int entCantidadAlumnosEntre19Y25,
                                        int entCantidadAlumnosMayor26,
                                        int entCantidadTotalAlumnosEdad,
                                        int entCantidadAlumnosMasculino,
                                        int entCantidadAlumnosFemenino,
                                        int entCantidadTotalAlumnosGenero,
                                        int entCantidadAlumnosRural,
                                        int entCantidadAlumnosUrbana,
                                        int entCantidadTotalAlumnosArea,
                                        int entCantidadAlumnosIndigenas,
                                        int entCantidadAlumnosAfro,
                                        int entCantidadAlumnosRom,
                                        int entCantidadAlumnosRaizales,
                                        int entCantidadAlumnosOtros,
                                        int entCantidadTotalAlumnosEtnia,
                                        int entCantidadAlumnosDiscapacitados,
                                        int entCantidadAlumnosDesplazados,
                                        int entCantidadTotalAlumnosEspeciales,
                                        bool entOrganizacionComunitaria,
                                        short entTipoOrganizacionComunitariaId,
                                        string entOtraOrganizacionComunitaria,
                                        bool entOrganizacionComunitariaProyectoEntornoEscuela,
                                        string entOtroProyectoEntornoEscuela,
                                        string entNombreOrganizacion,
                                        int entIntegrantesOrganizacion,
                                        string entNombrePresidenteOrganizacion,
                                        string entTelefonoCelularPresidenteOrganizacion,
                                        string entTelefonoFijoPresidenteOrganizacion,
                                        string entCorreoElectronicoPresidenteOrganizacion,
                                        int entCantidadAlumnosMayor60,
                                        int cantidadCupos,
                                        int cantidadRedUnidos,
                                        string[] proyectos,
                                        int SimusUsuarioId,
                                        string NombreUsuario,
                                        string strIP)
        {
            try
            {
                short? shortOrganizacionComunitariaId = null;
                if (entTipoOrganizacionComunitariaId > 0)
                    shortOrganizacionComunitariaId = entTipoOrganizacionComunitariaId;
                using (var context = new SIPAEntities())
                {
                    context.ART_ME_ART_MUSICA_ENTIDAD_PARTICIPACION_Actualizar(entId,
                                                                             entCantidadAlumnosMenor6,
                                                                             entCantidadAlumnosEntre7Y11,
                                                                             entCantidadAlumnosEntre12Y18,
                                                                             entCantidadAlumnosEntre19Y25,
                                                                             entCantidadAlumnosMayor26,
                                                                             entCantidadTotalAlumnosEdad,
                                                                             entCantidadAlumnosMasculino,
                                                                             entCantidadAlumnosFemenino,
                                                                             entCantidadTotalAlumnosGenero,
                                                                             entCantidadAlumnosRural,
                                                                             entCantidadAlumnosUrbana,
                                                                             entCantidadTotalAlumnosArea,
                                                                             entCantidadAlumnosIndigenas,
                                                                             entCantidadAlumnosAfro,
                                                                             entCantidadAlumnosRom,
                                                                             entCantidadAlumnosRaizales,
                                                                             entCantidadAlumnosOtros,
                                                                             entCantidadTotalAlumnosEtnia,
                                                                             entCantidadAlumnosDiscapacitados,
                                                                             entCantidadAlumnosDesplazados,
                                                                             entCantidadTotalAlumnosEspeciales,
                                                                             entOrganizacionComunitaria,
                                                                             shortOrganizacionComunitariaId,
                                                                             entOtraOrganizacionComunitaria,
                                                                             entOrganizacionComunitariaProyectoEntornoEscuela,
                                                                             entOtroProyectoEntornoEscuela,
                                                                             entNombreOrganizacion,
                                                                             entIntegrantesOrganizacion,
                                                                             entNombrePresidenteOrganizacion,
                                                                             entTelefonoCelularPresidenteOrganizacion,
                                                                             entTelefonoFijoPresidenteOrganizacion,
                                                                             entCorreoElectronicoPresidenteOrganizacion,
                                                                             entCantidadAlumnosMayor60);

                    ActualizarRedUnidos(entId, cantidadRedUnidos, cantidadCupos);

                    if (proyectos != null)
                    {
                        EliminarProyectos(entId);
                        ActualizarProyectos(entId, proyectos);
                    }

                    //Auditoria
                    string temp;
                    temp = string.Format("El usuario {0} ({1}) actualizó el {2} la  escuela de música - participación.\nDatos actuales:\n{3} ", NombreUsuario, SimusUsuarioId, DateTime.Now, "ART_MUSICA_ENTIDAD_PARTICIPACION");
                    StringBuilder stringBuilder = new StringBuilder();
                    stringBuilder.AppendLine(temp);
                    ART_MUSICA_REGISTRO_OPERACION registroOperacion = new ART_MUSICA_REGISTRO_OPERACION { Categoria = CategoriaRegistroOperacion.EscuelasParticipación.ToString(), IpUsuario = strIP, RegistroId = Convert.ToInt32(entId), UsuarioId = SimusUsuarioId, NombreUsuario = NombreUsuario, Descripcion = stringBuilder.ToString(), FechaRegistro = DateTime.Now, Operacion = "Actualización" };

                    RegistroOperacionServicio auditoria = new RegistroOperacionServicio();
                    auditoria.Crear(registroOperacion);
                }
            }
            catch (Exception)
            { throw; }
        }

        public static void ActualizarProyectos(decimal entId, string[] proyectos)
        {
            try
            {
                using (var context = new SIPAEntities())
                {

                    foreach (string item in proyectos)
                    {
                        context.ART_ME_ART_MUS_TIP_PROY_ORG_COM_ENT_PARTICIPACION_Insertar(entId, Convert.ToInt16(item));
                    }

                }

            }
            catch (Exception)
            { throw; }
        }

        public static void ActualizarRedUnidos(decimal entId, int cantidadRedUnidos, int CantidadCupos)
        {
            try
            {
                using (var context = new SIPAEntities())
                {

                    var datos = context.ART_MUSICA_ENTIDAD_PARTICIPACION.Where(x => x.ENT_ID == entId).FirstOrDefault();
 
                    if (datos != null)
                    {
                        datos.ENT_CANTIDAD_ALUMNOS_REDUNIDOS = cantidadRedUnidos;
                        datos.ENT_CANTIDAD_ALUMNOS_CUPOS = CantidadCupos;
                        context.SaveChanges();
                    }

                }

            }
            catch (Exception)
            { throw; }
        }

        public static void EliminarProyectos(decimal entId)
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    context.ART_ME_ART_MUS_TIP_PROY_ORG_COM_ENT_PARTICIPACION_EliminarPorENT_ID(entId);

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
                    context.ART_ME_ART_MUSICA_ENTIDAD_PARTICIPACION_Eliminar(entId);
                    context.SaveChanges();
                }

            }
            catch (Exception)
            { throw; }

        }
        #endregion

        #region Consultas
        public static ART_MUSICA_ENTIDAD_PARTICIPACION ConsultarParticipacionPorId(decimal EntId)
        {
            try
            {
                var model = new ART_MUSICA_ENTIDAD_PARTICIPACION();
                using (var context = new SIPAEntities())
                {

                    model = context.ART_MUSICA_ENTIDAD_PARTICIPACION.Where(x => x.ENT_ID == EntId).FirstOrDefault(); 

                }
                return model;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static ParticipacionAlumnosDTO ConsultarAlumnosPorRangoEdad(decimal EscuelaID)
        {
            try
            {
              
                using (var context = new SIPAEntities())
                {

                    var model = (from p in context.ART_MUSICA_ENTIDAD_PARTICIPACION
                                 where p.ENT_ID == EscuelaID
                                 select new ParticipacionAlumnosDTO
                                  {
                                      Menor6Anos = p.ENT_CANTIDAD_ALUMNOS_MENOR_6.ToString(),
                                      Entre6y11Anos = p.ENT_CANTIDAD_ALUMNOS_ENTRE_7_11.ToString(),
                                      Entre12y18Anos = p.ENT_CANTIDAD_ALUMNOS_ENTRE_12_18.ToString(),
                                      Entre19y26Anos = p.ENT_CANTIDAD_ALUMNOS_ENTRE_19_25.ToString(),
                                      Entre27y60Anos = p.ENT_CANTIDAD_ALUMNOS_MAYOR_26.ToString(),
                                      Mayores60Anos = p.ENT_CANTIDAD_ALUMNOS_MAYOR_60.ToString() 
                                  }).FirstOrDefault(); 

                    return model;

                }
             

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static ParticipacionEtniaDTO ConsultarAlumnosPorEtnia(decimal EscuelaID)
        {
            try
            {

                using (var context = new SIPAEntities())
                {

                    var model = (from p in context.ART_MUSICA_ENTIDAD_PARTICIPACION
                                 where p.ENT_ID == EscuelaID
                                 select new ParticipacionEtniaDTO
                                 {
                                    Afro = p.ENT_CANTIDAD_ALUMNOS_AFRO.ToString(),
                                    Indigenas = p.ENT_CANTIDAD_ALUMNOS_INDIGENAS.ToString(),
                                    Rom = p.ENT_CANTIDAD_ALUMNOS_ROM.ToString(),
                                    Raizales = p.ENT_CANTIDAD_ALUMNOS_RAIZALES.ToString(),
                                    Otros = p.ENT_CANTIDAD_ALUMNOS_OTROS.ToString()
                                 }).FirstOrDefault();

                    return model;

                }


            }
            catch (Exception)
            {
                throw;
            }
        }

        public static ParticipacionSexoDTO ConsultarAlumnosPorSexo(decimal EscuelaID)
        {
            try
            {

                using (var context = new SIPAEntities())
                {

                    var model = (from p in context.ART_MUSICA_ENTIDAD_PARTICIPACION
                                 where p.ENT_ID == EscuelaID
                                 select new ParticipacionSexoDTO
                                 {
                                    Femenino = p.ENT_CANTIDAD_ALUMNOS_FEMENINO.ToString(),
                                    Masculino = p.ENT_CANTIDAD_ALUMNOS_MASCULINO.ToString()
                                 }).FirstOrDefault();

                    return model;

                }


            }
            catch (Exception)
            {
                throw;
            }
        }

        public static ParticipacionUbicacionDTO ConsultarAlumnosPorUbicacion(decimal EscuelaID)
        {
            try
            {

                using (var context = new SIPAEntities())
                {

                    var model = (from p in context.ART_MUSICA_ENTIDAD_PARTICIPACION
                                 where p.ENT_ID == EscuelaID
                                 select new ParticipacionUbicacionDTO
                                 {
                                     Rural = p.ENT_CANTIDAD_ALUMNOS_RURAL.ToString(),
                                     Urbana = p.ENT_CANTIDAD_ALUMNOS_URBANA.ToString()
                                 }).FirstOrDefault();

                    return model;

                }


            }
            catch (Exception)
            {
                throw;
            }
        }

        public static ParticipacioCondicionesDTO ConsultarAlumnosPorCondicionesEspeciales(decimal EscuelaID)
        {
            try
            {

                using (var context = new SIPAEntities())
                {

                    var model = (from p in context.ART_MUSICA_ENTIDAD_PARTICIPACION
                                 where p.ENT_ID == EscuelaID
                                 select new ParticipacioCondicionesDTO
                                 {
                                     Deplazados = p.ENT_CANTIDAD_ALUMNOS_DESPLAZADOS.ToString(),
                                     Discapacitados = p.ENT_CANTIDAD_ALUMNOS_DISCAPACITADOS.ToString(),
                                     RedUnidos = p.ENT_CANTIDAD_ALUMNOS_REDUNIDOS.ToString()
                                 }).FirstOrDefault();

                    return model;

                }


            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<ART_ME_ART_MUSICA_ENTIDAD_PARTICIPACION_ObtenerTodos_Result> ConsultarParticipacionTodos()
        {
            try
            {
                var model = new List<ART_ME_ART_MUSICA_ENTIDAD_PARTICIPACION_ObtenerTodos_Result>();
                using (var context = new SIPAEntities())
                {

                    model = context.ART_ME_ART_MUSICA_ENTIDAD_PARTICIPACION_ObtenerTodos().ToList();

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
