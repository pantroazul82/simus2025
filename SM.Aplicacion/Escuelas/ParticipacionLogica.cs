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
    public class ParticipacionLogica
    {
        #region Actualizacion

        public static bool ValidarParticipacion(decimal entId)
        {
            bool validar = false;
            try
            {
                validar = Participacion.ValidarParticipacion(entId);
            }
            catch (Exception ex)
            { throw ex; }
            return validar;
        }
        public static void Grabar(decimal entId,
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
                bool validar = Participacion.ValidarParticipacion(entId);

                if (!validar)
                {
                    Participacion.Insertar(entId,
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
                                     entTipoOrganizacionComunitariaId,
                                     entOtraOrganizacionComunitaria,
                                     entOrganizacionComunitariaProyectoEntornoEscuela,
                                     entOtroProyectoEntornoEscuela,
                                     entNombreOrganizacion,
                                     entIntegrantesOrganizacion,
                                     entNombrePresidenteOrganizacion,
                                     entTelefonoCelularPresidenteOrganizacion,
                                     entTelefonoFijoPresidenteOrganizacion,
                                     entCorreoElectronicoPresidenteOrganizacion,
                                     entCantidadAlumnosMayor60,
                                     cantidadCupos,
                                     cantidadRedUnidos,
                                     proyectos,
                                     SimusUsuarioId,
                                     NombreUsuario,
                                     strIP);

                }
                else
                {
                    Participacion.Actualizar(entId,
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
                                     entTipoOrganizacionComunitariaId,
                                     entOtraOrganizacionComunitaria,
                                     entOrganizacionComunitariaProyectoEntornoEscuela,
                                     entOtroProyectoEntornoEscuela,
                                     entNombreOrganizacion,
                                     entIntegrantesOrganizacion,
                                     entNombrePresidenteOrganizacion,
                                     entTelefonoCelularPresidenteOrganizacion,
                                     entTelefonoFijoPresidenteOrganizacion,
                                     entCorreoElectronicoPresidenteOrganizacion,
                                     entCantidadAlumnosMayor60,
                                     cantidadCupos,
                                     cantidadRedUnidos,
                                     proyectos,
                                      SimusUsuarioId,
                                     NombreUsuario,
                                     strIP);

                }

            }
            catch (Exception ex)
            { throw ex; }
        }



        #endregion

        #region Consultas
        public static ParticipacionDTO ConsultarParticipacionPorId(decimal EscuelaId)
        {
            try
            {
                var model = new ART_MUSICA_ENTIDAD_PARTICIPACION();
                ParticipacionDTO datos = new ParticipacionDTO();
                model = Participacion.ConsultarParticipacionPorId(EscuelaId);

                if (model != null)
                {
                    datos.ENT_CANTIDAD_ALUMNOS_AFRO = model.ENT_CANTIDAD_ALUMNOS_AFRO;
                    datos.ENT_CANTIDAD_ALUMNOS_DESPLAZADOS = model.ENT_CANTIDAD_ALUMNOS_DESPLAZADOS;
                    datos.ENT_CANTIDAD_ALUMNOS_DISCAPACITADOS = model.ENT_CANTIDAD_ALUMNOS_DISCAPACITADOS;
                    datos.ENT_CANTIDAD_ALUMNOS_ENTRE_12_18 = model.ENT_CANTIDAD_ALUMNOS_ENTRE_12_18;
                    datos.ENT_CANTIDAD_ALUMNOS_ENTRE_19_25 = model.ENT_CANTIDAD_ALUMNOS_ENTRE_19_25;
                    datos.ENT_CANTIDAD_ALUMNOS_ENTRE_7_11 = model.ENT_CANTIDAD_ALUMNOS_ENTRE_7_11;
                    datos.ENT_CANTIDAD_ALUMNOS_FEMENINO = model.ENT_CANTIDAD_ALUMNOS_FEMENINO;
                    datos.ENT_CANTIDAD_ALUMNOS_INDIGENAS = model.ENT_CANTIDAD_ALUMNOS_INDIGENAS;
                    datos.ENT_CANTIDAD_ALUMNOS_MASCULINO = model.ENT_CANTIDAD_ALUMNOS_MASCULINO;
                    datos.ENT_CANTIDAD_ALUMNOS_MAYOR_26 = model.ENT_CANTIDAD_ALUMNOS_MAYOR_26;
                    datos.ENT_CANTIDAD_ALUMNOS_MAYOR_60 = model.ENT_CANTIDAD_ALUMNOS_MAYOR_60 ?? 0;
                    datos.ENT_CANTIDAD_ALUMNOS_MENOR_6 = model.ENT_CANTIDAD_ALUMNOS_MENOR_6;
                    datos.ENT_CANTIDAD_ALUMNOS_OTROS = model.ENT_CANTIDAD_ALUMNOS_OTROS;
                    datos.ENT_CANTIDAD_ALUMNOS_RAIZALES = model.ENT_CANTIDAD_ALUMNOS_RAIZALES;
                    datos.ENT_CANTIDAD_ALUMNOS_ROM = model.ENT_CANTIDAD_ALUMNOS_ROM;
                    datos.ENT_CANTIDAD_ALUMNOS_RURAL = model.ENT_CANTIDAD_ALUMNOS_RURAL;
                    datos.ENT_CANTIDAD_ALUMNOS_URBANA = model.ENT_CANTIDAD_ALUMNOS_URBANA;
                    datos.ENT_CANTIDAD_TOTAL_ALUMNOS_AREA = model.ENT_CANTIDAD_TOTAL_ALUMNOS_AREA;
                    datos.ENT_CANTIDAD_TOTAL_ALUMNOS_ESPECIALES = model.ENT_CANTIDAD_TOTAL_ALUMNOS_ESPECIALES;
                    datos.ENT_CANTIDAD_TOTAL_ALUMNOS_ETNIA = model.ENT_CANTIDAD_TOTAL_ALUMNOS_ETNIA;
                    datos.ENT_CANTIDAD_TOTAL_ALUMNOS_GENERO = model.ENT_CANTIDAD_TOTAL_ALUMNOS_GENERO;
                    datos.ENT_CANTITDAD_TOTAL_ALUMNOS_EDAD = model.ENT_CANTITDAD_TOTAL_ALUMNOS_EDAD;
                    datos.ENT_CANTIDAD_ALUMNOS_REDUNIDOS = model.ENT_CANTIDAD_ALUMNOS_REDUNIDOS ?? 0;
                    datos.ENT_CANTIDAD_ALUMNOS_CUPOS = model.ENT_CANTIDAD_ALUMNOS_CUPOS ?? 0;
                    datos.ENT_CORREO_ELECTRONICO_PRESIDENTE_ORGANIZACION = model.ENT_CORREO_ELECTRONICO_PRESIDENTE_ORGANIZACION;
                    datos.ENT_ID = model.ENT_ID;
                    datos.ENT_INTEGRANTES_ORGANIZACION = model.ENT_INTEGRANTES_ORGANIZACION ?? 0;
                    datos.ENT_NOMBRE_ORGANIZACION = model.ENT_NOMBRE_ORGANIZACION;
                    datos.ENT_NOMBRE_PRESIDENTE_ORGANIZACION = model.ENT_NOMBRE_PRESIDENTE_ORGANIZACION;
                    datos.ENT_ORGANIZACION_COMUNITARIA = model.ENT_ORGANIZACION_COMUNITARIA;
                    datos.ENT_ORGANIZACION_COMUNITARIA_PROYECTO_ENTORNO_ESCUELA = model.ENT_ORGANIZACION_COMUNITARIA_PROYECTO_ENTORNO_ESCUELA;
                    datos.ENT_TELEFONO_CELULAR_PRESIDENTE_ORGANIZACION = model.ENT_TELEFONO_CELULAR_PRESIDENTE_ORGANIZACION;
                    datos.ENT_TELEFONO_FIJO_PRESIDENTE_ORGANIZACION = model.ENT_TELEFONO_FIJO_PRESIDENTE_ORGANIZACION;
                    datos.ORGANIZACION_COMUNITARIA_ID = model.ORGANIZACION_COMUNITARIA_ID ?? 0;
                    datos.OTRA_ORGANIZACION_COMUNITARIA = model.OTRA_ORGANIZACION_COMUNITARIA;
                    datos.OTRO_PROYECTO_ENTORNO_ESCUELA = model.OTRO_PROYECTO_ENTORNO_ESCUELA;
                }

                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ParticipacionDTO> ConsultarParticipacionTodos()
        {
            try
            {
                var model = new List<ART_ME_ART_MUSICA_ENTIDAD_PARTICIPACION_ObtenerTodos_Result>();
                var result = new List<ParticipacionDTO>();
                model = Participacion.ConsultarParticipacionTodos();

                foreach (var item in model)
                {
                    ParticipacionDTO datos = new ParticipacionDTO();
                    datos.ENT_CANTIDAD_ALUMNOS_AFRO = item.ENT_CANTIDAD_ALUMNOS_AFRO;
                    datos.ENT_CANTIDAD_ALUMNOS_DESPLAZADOS = item.ENT_CANTIDAD_ALUMNOS_DESPLAZADOS;
                    datos.ENT_CANTIDAD_ALUMNOS_DISCAPACITADOS = item.ENT_CANTIDAD_ALUMNOS_DISCAPACITADOS;
                    datos.ENT_CANTIDAD_ALUMNOS_ENTRE_12_18 = item.ENT_CANTIDAD_ALUMNOS_ENTRE_12_18;
                    datos.ENT_CANTIDAD_ALUMNOS_ENTRE_19_25 = item.ENT_CANTIDAD_ALUMNOS_ENTRE_19_25;
                    datos.ENT_CANTIDAD_ALUMNOS_ENTRE_7_11 = item.ENT_CANTIDAD_ALUMNOS_ENTRE_7_11;
                    datos.ENT_CANTIDAD_ALUMNOS_FEMENINO = item.ENT_CANTIDAD_ALUMNOS_FEMENINO;
                    datos.ENT_CANTIDAD_ALUMNOS_INDIGENAS = item.ENT_CANTIDAD_ALUMNOS_INDIGENAS;
                    datos.ENT_CANTIDAD_ALUMNOS_MASCULINO = item.ENT_CANTIDAD_ALUMNOS_MASCULINO;
                    datos.ENT_CANTIDAD_ALUMNOS_MAYOR_26 = item.ENT_CANTIDAD_ALUMNOS_MAYOR_26;
                    datos.ENT_CANTIDAD_ALUMNOS_MAYOR_60 = item.ENT_CANTIDAD_ALUMNOS_MAYOR_60 ?? 0;
                    datos.ENT_CANTIDAD_ALUMNOS_MENOR_6 = item.ENT_CANTIDAD_ALUMNOS_MENOR_6;
                    datos.ENT_CANTIDAD_ALUMNOS_OTROS = item.ENT_CANTIDAD_ALUMNOS_OTROS;
                    datos.ENT_CANTIDAD_ALUMNOS_RAIZALES = item.ENT_CANTIDAD_ALUMNOS_RAIZALES;
                    datos.ENT_CANTIDAD_ALUMNOS_ROM = item.ENT_CANTIDAD_ALUMNOS_ROM;
                    datos.ENT_CANTIDAD_ALUMNOS_RURAL = item.ENT_CANTIDAD_ALUMNOS_RURAL;
                    datos.ENT_CANTIDAD_ALUMNOS_URBANA = item.ENT_CANTIDAD_ALUMNOS_URBANA;
                    datos.ENT_CANTIDAD_TOTAL_ALUMNOS_AREA = item.ENT_CANTIDAD_TOTAL_ALUMNOS_AREA;
                    datos.ENT_CANTIDAD_TOTAL_ALUMNOS_ESPECIALES = item.ENT_CANTIDAD_TOTAL_ALUMNOS_ESPECIALES;
                    datos.ENT_CANTIDAD_TOTAL_ALUMNOS_ETNIA = item.ENT_CANTIDAD_TOTAL_ALUMNOS_ETNIA;
                    datos.ENT_CANTIDAD_TOTAL_ALUMNOS_GENERO = item.ENT_CANTIDAD_TOTAL_ALUMNOS_GENERO;
                    datos.ENT_CANTITDAD_TOTAL_ALUMNOS_EDAD = item.ENT_CANTITDAD_TOTAL_ALUMNOS_EDAD;
                    result.Add(datos);
                }

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<indicadoresDTO> ConsultarAlumnosPorRangoEdad(decimal EscuelaId)
        {
            List<indicadoresDTO> lstRerporte = new List<indicadoresDTO>();
            var objalumnos = new indicadoresDTO();
            try
            {
                var reporte = Participacion.ConsultarAlumnosPorRangoEdad(EscuelaId);

                if (reporte != null)
                {
                    objalumnos = new indicadoresDTO();
                    objalumnos.indexLabel = "< 6 años";
                    objalumnos.orden = 1;
                    if (!String.IsNullOrEmpty(reporte.Menor6Anos))
                        objalumnos.y = Convert.ToInt32(reporte.Menor6Anos);
                    else
                        objalumnos.y = 0;
                    lstRerporte.Add(objalumnos);

                    objalumnos = new indicadoresDTO();
                    objalumnos.indexLabel = "6 y 11 años";
                    objalumnos.orden = 2;
                    if (!String.IsNullOrEmpty(reporte.Entre6y11Anos))
                        objalumnos.y = Convert.ToInt32(reporte.Entre6y11Anos);
                    else
                        objalumnos.y = 0;
                    lstRerporte.Add(objalumnos);

                    objalumnos = new indicadoresDTO();
                    objalumnos.orden = 3;
                    objalumnos.indexLabel = "12 y 18 años";
                    if (!String.IsNullOrEmpty(reporte.Entre12y18Anos))
                        objalumnos.y = Convert.ToInt32(reporte.Entre12y18Anos);
                    else
                        objalumnos.y = 0;
                    lstRerporte.Add(objalumnos);

                    objalumnos = new indicadoresDTO();
                    objalumnos.orden = 4;
                    objalumnos.indexLabel = "19 y 26 años";
                    if (!String.IsNullOrEmpty(reporte.Entre19y26Anos))
                        objalumnos.y = Convert.ToInt32(reporte.Entre19y26Anos);
                    else
                        objalumnos.y = 0;
                    lstRerporte.Add(objalumnos);

                    objalumnos = new indicadoresDTO();
                    objalumnos.indexLabel = "27 y 60 años";
                    objalumnos.orden = 5;
                    if (!String.IsNullOrEmpty(reporte.Entre27y60Anos))
                        objalumnos.y = Convert.ToInt32(reporte.Entre27y60Anos);
                    else
                        objalumnos.y = 0;
                    lstRerporte.Add(objalumnos);

                    objalumnos = new indicadoresDTO();
                    objalumnos.orden = 6;
                    objalumnos.indexLabel = "> 60 años";
                    if (!String.IsNullOrEmpty(reporte.Mayores60Anos))
                        objalumnos.y = Convert.ToInt32(reporte.Mayores60Anos);
                    else
                        objalumnos.y = 0;

                    lstRerporte.Add(objalumnos);

                    bool EsDatos = false;
                    foreach (var item in lstRerporte)
                    {
                        if (item.y != 0)
                            EsDatos = true;
                    }

                    if (!EsDatos)
                    {
                        var itemToRemove = lstRerporte.Single(r => r.indexLabel == "6 y 11 años");
                        lstRerporte.Remove(itemToRemove);

                        var objRegistro = new indicadoresDTO();
                        objRegistro.indexLabel = "6 y 11 años";
                        objalumnos.orden = 1;
                        objRegistro.y = 1;
                        lstRerporte.Add(objRegistro);
                    }
                }
                return lstRerporte;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<indicadoresDTO> ConsultarAlumnosPorEtnia(decimal EscuelaId)
        {
            List<indicadoresDTO> lstRerporte = new List<indicadoresDTO>();
            try
            {
                var reporte = Participacion.ConsultarAlumnosPorEtnia(EscuelaId);
                var objalumnos = new indicadoresDTO();
                if (reporte != null)
                {
                    objalumnos = new indicadoresDTO();
                    objalumnos.indexLabel = "Indígenas";
                    objalumnos.orden = 1;
                    if (!String.IsNullOrEmpty(reporte.Indigenas))
                        objalumnos.y = Convert.ToInt32(reporte.Indigenas);
                    else
                        objalumnos.y = 0;
                    lstRerporte.Add(objalumnos);

                    objalumnos = new indicadoresDTO();
                    objalumnos.orden = 2;
                    objalumnos.indexLabel = "Afro";
                    if (!String.IsNullOrEmpty(reporte.Afro))
                        objalumnos.y = Convert.ToInt32(reporte.Afro);
                    else
                        objalumnos.y = 0;
                    lstRerporte.Add(objalumnos);

                    objalumnos = new indicadoresDTO();
                    objalumnos.orden = 3;
                    objalumnos.indexLabel = "Rom";
                    if (!String.IsNullOrEmpty(reporte.Rom))
                        objalumnos.y = Convert.ToInt32(reporte.Rom);
                    else
                        objalumnos.y = 0;
                    lstRerporte.Add(objalumnos);

                    objalumnos = new indicadoresDTO();
                    objalumnos.orden = 4;
                    objalumnos.indexLabel = "Raizales";
                    if (!String.IsNullOrEmpty(reporte.Raizales))
                        objalumnos.y = Convert.ToInt32(reporte.Raizales);
                    else
                        objalumnos.y = 0;
                    lstRerporte.Add(objalumnos);

                    objalumnos = new indicadoresDTO();
                    objalumnos.orden = 5;
                    objalumnos.indexLabel = "Otros";
                    if (!String.IsNullOrEmpty(reporte.Otros))
                        objalumnos.y = Convert.ToInt32(reporte.Otros);
                    else
                        objalumnos.y = 0;

                    lstRerporte.Add(objalumnos);


                    bool EsDatos = false;
                    foreach (var item in lstRerporte)
                    {
                        if (item.y != 0)
                            EsDatos = true;
                    }

                    if (!EsDatos)
                    {
                        var itemToRemove = lstRerporte.Single(r => r.indexLabel == "Otros");
                        lstRerporte.Remove(itemToRemove);

                        objalumnos = new indicadoresDTO();
                        objalumnos.indexLabel = "Otros";
                        objalumnos.y = 1;
                        objalumnos.orden = 1;
                        lstRerporte.Add(objalumnos);
                    }
                }
                return lstRerporte;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<indicadoresDTO> ConsultarAlumnosPorSexo(decimal EscuelaId)
        {
            List<indicadoresDTO> lstRerporte = new List<indicadoresDTO>();
            var objalumnos = new indicadoresDTO();
            try
            {
                var reporte = Participacion.ConsultarAlumnosPorSexo(EscuelaId);
                if (reporte != null)
                {
                    objalumnos = new indicadoresDTO();
                    objalumnos.indexLabel = "Femenino";
                    objalumnos.orden = 1;
                    if (!String.IsNullOrEmpty(reporte.Femenino))
                        objalumnos.y = Convert.ToInt32(reporte.Femenino);
                    else
                        objalumnos.y = 0;

                    lstRerporte.Add(objalumnos);

                    objalumnos = new indicadoresDTO();
                    objalumnos.indexLabel = "Masculino";
                    objalumnos.orden = 2;
                    if (!String.IsNullOrEmpty(reporte.Masculino))
                        objalumnos.y = Convert.ToInt32(reporte.Masculino);
                    else
                        objalumnos.y = 0;

                    lstRerporte.Add(objalumnos);

                    bool EsDatos = false;
                    foreach (var item in lstRerporte)
                    {
                        if (item.y != 0)
                            EsDatos = true;
                    }

                    if (!EsDatos)
                    {
                        var itemToRemove = lstRerporte.Single(r => r.indexLabel == "Masculino");
                        lstRerporte.Remove(itemToRemove);

                        objalumnos = new indicadoresDTO();
                        objalumnos.indexLabel = "Masculino";
                        objalumnos.y = 1;
                        objalumnos.orden = 1;
                        lstRerporte.Add(objalumnos);
                    }
                }
                return lstRerporte;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<indicadoresDTO> ConsultarAlumnosPorUbicacion(decimal EscuelaId)
        {
            List<indicadoresDTO> lstRerporte = new List<indicadoresDTO>();
            var objalumnos = new indicadoresDTO();
            try
            {
                var reporte = Participacion.ConsultarAlumnosPorUbicacion(EscuelaId);
                if (reporte != null)
                {
                    objalumnos = new indicadoresDTO();
                    objalumnos.indexLabel = "Rural";
                    objalumnos.orden = 1;
                    if (!String.IsNullOrEmpty(reporte.Rural))
                        objalumnos.y = Convert.ToInt32(reporte.Rural);
                    else
                        objalumnos.y = 0;
                    lstRerporte.Add(objalumnos);

                    objalumnos = new indicadoresDTO();
                    objalumnos.indexLabel = "Urbana";
                    objalumnos.orden = 2;
                    if (!String.IsNullOrEmpty(reporte.Urbana))
                        objalumnos.y = Convert.ToInt32(reporte.Urbana);
                    else
                        objalumnos.y = 0;
                    lstRerporte.Add(objalumnos);

                    bool EsDatos = false;
                    foreach (var item in lstRerporte)
                    {
                        if (item.y != 0)
                            EsDatos = true;
                    }

                    if (!EsDatos)
                    {
                        var itemToRemove = lstRerporte.Single(r => r.indexLabel == "Urbana");
                        lstRerporte.Remove(itemToRemove);

                        objalumnos = new indicadoresDTO();
                        objalumnos.indexLabel = "Urbana";
                        objalumnos.y = 1;
                        objalumnos.orden = 1;
                        lstRerporte.Add(objalumnos);
                    }
                }
                return lstRerporte;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<indicadoresDTO> ConsultarAlumnosPorCondicionesEspeciales(decimal EscuelaId)
        {
            List<indicadoresDTO> lstRerporte = new List<indicadoresDTO>();
            var objalumnos = new indicadoresDTO();
            try
            {
                var reporte = Participacion.ConsultarAlumnosPorCondicionesEspeciales(EscuelaId);
                if (reporte != null)
                {
                    objalumnos = new indicadoresDTO();
                    objalumnos.indexLabel = "Discapacitados";
                    objalumnos.orden = 1;
                    if (!String.IsNullOrEmpty(reporte.Discapacitados))
                        objalumnos.y = Convert.ToInt32(reporte.Discapacitados);
                    else
                        objalumnos.y = 0;
                    lstRerporte.Add(objalumnos);

                    objalumnos = new indicadoresDTO();
                    objalumnos.indexLabel = "Deplazados";
                    objalumnos.orden = 2;
                    if (!String.IsNullOrEmpty(reporte.Deplazados))
                        objalumnos.y = Convert.ToInt32(reporte.Deplazados);
                    else
                        objalumnos.y = 0;
                    lstRerporte.Add(objalumnos);

                    objalumnos = new indicadoresDTO();
                    objalumnos.indexLabel = "Red Unidos";
                    objalumnos.orden = 3;
                    if (!String.IsNullOrEmpty(reporte.RedUnidos))
                        objalumnos.y = Convert.ToInt32(reporte.RedUnidos);
                    else
                        objalumnos.y = 0;
                    lstRerporte.Add(objalumnos);

                    bool EsDatos = false;
                    foreach (var item in lstRerporte)
                    {
                        if (item.y != 0)
                            EsDatos = true;
                    }

                    if (!EsDatos)
                    {
                        var itemToRemove = lstRerporte.Single(r => r.indexLabel == "Deplazados");
                        lstRerporte.Remove(itemToRemove);

                        objalumnos = new indicadoresDTO();
                        objalumnos.indexLabel = "Deplazados";
                        objalumnos.y = 1;
                        objalumnos.orden = 1;
                        lstRerporte.Add(objalumnos);
                    }
                }
                return lstRerporte;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
