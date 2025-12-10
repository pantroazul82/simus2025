using SM.Datos.DTO;
using SM.SIPA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Datos.Reportes
{
    public class ServicioReporte
    {
        /// <summary>
        /// Reporte de escuelas por departamento
        /// </summary>
        /// <returns></returns>
        public static List<Basica> obtenerEscuelasDpto()
        {
            List<Basica> listReporte = new List<Basica>();
            try
            {
                using (var context = new SIPAEntities())
                {


                    var reporte = context.Database.SqlQuery<BasicoReporte>(@"EXEC ART_MUSICA_REPORTE_ESCUELA_DPTO");


                    //listMunicipio = (from z in context.BAS_ZONAS_GEOGRAFICAS
                    //                 where z.ZON_PADRE_ID == codigoDane
                    //                 select new Basica
                    //                 {
                    //                     Value = z.ZON_ID,
                    //                     Nombre = z.ZON_NOMBRE
                    //                 }).ToList();
                    Basica objbasico = null;
                    foreach (var item in reporte)
                    {
                        objbasico = new Basica();
                        objbasico.Nombre = item.Nombre;
                        objbasico.Value = item.Value.ToString();
                        listReporte.Add(objbasico);
                    }

                }
                return listReporte;

            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// obtenemos las escuelas por tipo(privada, publica etc)
        /// </summary>
        /// <returns></returns>
        public static List<Basica> obtenerEscuelasPorTipo()
        {
            List<Basica> listReporte = new List<Basica>();
            try
            {
                using (var context = new SIPAEntities())
                {


                    var reporte = context.Database.SqlQuery<BasicoReporte>(@"EXEC ART_MUSICA_REPORTE_ESCUELA_TIPO");


                    //listMunicipio = (from z in context.BAS_ZONAS_GEOGRAFICAS
                    //                 where z.ZON_PADRE_ID == codigoDane
                    //                 select new Basica
                    //                 {
                    //                     Value = z.ZON_ID,
                    //                     Nombre = z.ZON_NOMBRE
                    //                 }).ToList();
                    Basica objbasico = null;
                    foreach (var item in reporte)
                    {
                        objbasico = new Basica();
                        objbasico.Nombre = item.Nombre;
                        objbasico.Value = item.Value.ToString();
                        listReporte.Add(objbasico);
                    }

                }
                return listReporte;

            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Obtenemos las escuelas por practica musical
        /// </summary>
        /// <returns></returns>
        public static List<Basica> obtenerEscPorPracticaMuscal()
        {
            List<Basica> listReporte = new List<Basica>();
            try
            {
                using (var context = new SIPAEntities())
                {


                    var reporte = context.Database.SqlQuery<BasicoReporte>(@"EXEC ART_MUSICA_REPORTE_ESCUELA_PRAC_MUSICA");


                    Basica objbasico = null;
                    foreach (var item in reporte)
                    {
                        objbasico = new Basica();
                        objbasico.Nombre = item.Nombre;
                        objbasico.Value = item.Value.ToString();
                        listReporte.Add(objbasico);
                    }

                }
                return listReporte;

            }
            catch (Exception)
            {
                throw;
            }
        }





        /// <summary>
        /// eades de los miembros de la escuela
        /// </summary>
        /// <returns></returns>
        public static List<Basica> obtenerEscPorEdaddes()
        {
            List<Basica> listReporte = new List<Basica>();
            try
            {
                using (var context = new SIPAEntities())
                {


                    var reporte = context.Database.SqlQuery<BasicoReporte>(@"EXEC ART_MUSICA_REPORTE_ESCUELA_EDADES");


                    Basica objbasico = null;
                    foreach (var item in reporte)
                    {
                        objbasico = new Basica();
                        objbasico.Nombre = item.Nombre;
                        objbasico.Value = item.Value.ToString();
                        listReporte.Add(objbasico);
                    }

                }
                return listReporte;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<Basica> obtenerEscporEtnia()
        {
            List<Basica> listReporte = new List<Basica>();
            try
            {
                using (var context = new SIPAEntities())
                {


                    var reporte = context.Database.SqlQuery<BasicoReporte>(@"EXEC ART_MUSICA_REPORTE_ESCUELA_ENTIA");


                    Basica objbasico = null;
                    foreach (var item in reporte)
                    {
                        objbasico = new Basica();
                        objbasico.Nombre = item.Nombre;
                        objbasico.Value = item.Value.ToString();
                        listReporte.Add(objbasico);
                    }

                }
                return listReporte;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<Basica> obtenerEscporSexo()
        {
            List<Basica> listReporte = new List<Basica>();
            try
            {
                using (var context = new SIPAEntities())
                {


                    var reporte = context.Database.SqlQuery<BasicoReporte>(@"EXEC ART_MUSICA_REPORTE_ESCUELA_SEXO");


                    Basica objbasico = null;
                    foreach (var item in reporte)
                    {
                        objbasico = new Basica();
                        objbasico.Nombre = item.Nombre;
                        objbasico.Value = item.Value.ToString();
                        listReporte.Add(objbasico);
                    }

                }
                return listReporte;

            }
            catch (Exception)
            {
                throw;
            }
        }


        public static List<Basica> obtenerEscporArea()
        {
            List<Basica> listReporte = new List<Basica>();
            try
            {
                using (var context = new SIPAEntities())
                {


                    var reporte = context.Database.SqlQuery<BasicoReporte>(@"EXEC ART_MUSICA_REPORTE_ESCUELA_AREA");


                    Basica objbasico = null;
                    foreach (var item in reporte)
                    {
                        objbasico = new Basica();
                        objbasico.Nombre = item.Nombre;
                        objbasico.Value = item.Value.ToString();
                        listReporte.Add(objbasico);
                    }

                }
                return listReporte;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<Basica> obtenerEscporCodEsp()
        {
            List<Basica> listReporte = new List<Basica>();
            try
            {
                using (var context = new SIPAEntities())
                {


                    var reporte = context.Database.SqlQuery<BasicoReporte>(@"EXEC ART_MUSICA_REPORTE_ESCUELA_CONDIESPEC");


                    Basica objbasico = null;
                    foreach (var item in reporte)
                    {
                        objbasico = new Basica();
                        objbasico.Nombre = item.Nombre;
                        objbasico.Value = item.Value.ToString();
                        listReporte.Add(objbasico);
                    }

                }
                return listReporte;

            }
            catch (Exception)
            {
                throw;
            }
        }


        #region nuevos reportes
        /// <summary>
        /// Cantidad de escuelas de música con organización comunitaria   
        /// </summary>
        /// <returns></returns>
        public static List<Basica> obtenerEscporOrgComunitaria()
        {
            List<Basica> listReporte = new List<Basica>();
            try
            {
                using (var context = new SIPAEntities())
                {


                    var reporte = context.Database.SqlQuery<BasicoReporte>(@"EXEC ART_MUSICA_REPORTE_ORG_COMUNITARIA");


                    Basica objbasico = null;
                    foreach (var item in reporte)
                    {
                        objbasico = new Basica();
                        objbasico.Nombre = item.Nombre;
                        objbasico.Value = item.Value.ToString();
                        listReporte.Add(objbasico);
                    }

                }
                return listReporte;

            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Densidad poblacional por profesor en las escuelas de música
        /// </summary>
        /// <returns></returns>
        public static List<Basica> obtenerEscporProfesores()
        {
            List<Basica> listReporte = new List<Basica>();
            try
            {
                using (var context = new SIPAEntities())
                {


                    var reporte = context.Database.SqlQuery<BasicoReporte>(@"EXEC ART_MUSICA_REPORTE_PROFESORES");


                    Basica objbasico = null;
                    foreach (var item in reporte)
                    {
                        objbasico = new Basica();
                        objbasico.Nombre = item.Nombre;
                        objbasico.Value = item.Value.ToString();
                        listReporte.Add(objbasico);
                    }

                }
                return listReporte;

            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// mostrar detalle o xls para reporte
        /// </summary>
        /// <returns></returns>
        public static List<ReporteComplex> obtenerEdadesPorDpto()
        {
            List<ReporteComplex> listReporte = new List<ReporteComplex>();
            try
            {
                using (var context = new SIPAEntities())
                {


                    var reporte = context.Database.SqlQuery<ReporteComplex>(@"EXEC ART_MUSICA_REPORTE_ESCUELA_EDADES_DPTO");


                    ReporteComplex objbasico = null;
                    foreach (var item in reporte)
                    {
                        objbasico = new ReporteComplex();
                        objbasico.Id = item.Id;
                        objbasico.departamento = item.departamento.ToString();
                        objbasico.criterio6 = item.criterio6.ToString();
                        objbasico.criterio7 = item.criterio7.ToString();
                        objbasico.criterio12 = item.criterio12.ToString();

                        objbasico.criterio19 = item.criterio19.ToString();
                        objbasico.criterio26 = item.criterio26.ToString();
                        listReporte.Add(objbasico);
                    }

                }
                return listReporte;

            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Cantidad de escuelas por estado de consolidación
        /// </summary>
        /// <returns></returns>
        public static List<Basica> obtenerCantidadEscuelasConsolidacion()
        {
            List<Basica> listReporte = new List<Basica>();
            try
            {
                using (var context = new SIPAEntities())
                {


                    var reporte = context.Database.SqlQuery<BasicoReporte>(@"EXEC ART_MUSICA_REPORTE_ESCUELA_CONSOLIDACION");


                    Basica objbasico = null;
                    foreach (var item in reporte)
                    {
                        objbasico = new Basica();
                        objbasico.Nombre = item.Nombre;
                        objbasico.Value = item.Value.ToString();
                        listReporte.Add(objbasico);
                    }

                }
                return listReporte;

            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Cantidad de escuelas por estado de consolidación agrupado por dpto
        /// </summary>
        /// <returns></returns>
        public static List<ReporteComplex> obtenerCantidadEscuelasConsolidacionDpto()
        {
            List<ReporteComplex> listReporte = new List<ReporteComplex>();
            try
            {
                using (var context = new SIPAEntities())
                {


                    var reporte = context.Database.SqlQuery<ReporteComplex>(@"EXEC ART_MUSICA_REPORTE_ESCUELA_CONSOLIDACION_DPTO");


                    ReporteComplex objbasico = null;
                    foreach (var item in reporte)
                    {
                        objbasico = new ReporteComplex();
                        objbasico.Id = item.Id;
                        objbasico.departamento = item.departamento.ToString();
                        objbasico.criterio6 = item.criterio6.ToString();
                        objbasico.criterio7 = item.criterio7.ToString();
                        objbasico.criterio12 = item.criterio12.ToString();

                        objbasico.criterio19 = item.criterio19.ToString();
                        objbasico.criterio26 = item.criterio26.ToString();
                        listReporte.Add(objbasico);
                    }

                }
                return listReporte;

            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Cantidad de participaciones de los estudiantes en escenarios()
        /// </summary>
        /// <returns></returns>
        public static List<ReporteComplex> obtenerCantidadEstudiantesESC()
        {
            List<ReporteComplex> listReporte = new List<ReporteComplex>();
            try
            {
                using (var context = new SIPAEntities())
                {


                    var reporte = context.Database.SqlQuery<ReporteComplex>(@"EXEC ART_MUSICA_REPORTE_EST_ESCEN");


                    ReporteComplex objbasico = null;
                    foreach (var item in reporte)
                    {
                        objbasico = new ReporteComplex();
                        objbasico.Id = item.Id;
                        objbasico.departamento = item.departamento.ToString();
                        objbasico.criterio6 = item.criterio6.ToString();
                        objbasico.criterio7 = item.criterio7.ToString();
                        objbasico.criterio12 = item.criterio12.ToString();

                        objbasico.criterio19 = item.criterio19.ToString();
                        objbasico.criterio26 = item.criterio26.ToString();
                        listReporte.Add(objbasico);
                    }

                }
                return listReporte;

            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Cantidad de escuelas que dependen de otra entidad
        /// </summary>
        /// <returns></returns>
        public static List<Basica> obtenerCantidadEscuelasDependeOtra()
        {
            List<Basica> listReporte = new List<Basica>();
            try
            {
                using (var context = new SIPAEntities())
                {


                    var reporte = context.Database.SqlQuery<BasicoReporte>(@"EXEC ART_MUSICA_REPORTE_ESC_OTRA_ENT");


                    Basica objbasico = null;
                    foreach (var item in reporte)
                    {
                        objbasico = new Basica();
                        objbasico.Nombre = item.Nombre;
                        objbasico.Value = item.Value.ToString();
                        listReporte.Add(objbasico);
                    }

                }
                return listReporte;

            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Cantidad de docentes por  departamento
        /// </summary>
        /// <returns></returns>
        public static List<ReporteProfesor> obtenerProfesoresNivelEduDpto()
        {
            List<ReporteProfesor> listReporte = new List<ReporteProfesor>();
            try
            {
                using (var context = new SIPAEntities())
                {
                    var reporte = context.Database.SqlQuery<ReporteProfesor>(@"EXEC ART_MUSICA_REPORTE_PROFESORES_DPTO");

                    ReporteProfesor objbasico = null;
                    foreach (var item in reporte)
                    {
                        objbasico = new ReporteProfesor();
                        objbasico.Id = item.Id;
                        objbasico.departamento = item.departamento.ToString();
                        objbasico.primaria = item.primaria.ToString();
                        objbasico.secundaria = item.secundaria.ToString();
                        objbasico.tecnico = item.tecnico.ToString();
                        objbasico.universiatrio = item.universiatrio.ToString();

                        objbasico.pregradomusica = item.pregradomusica.ToString();
                        objbasico.pregradootra = item.pregradootra.ToString();
                        objbasico.total = item.total.ToString();
                        listReporte.Add(objbasico);
                    }

                }
                return listReporte;

            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Dotación instrumental existente en las escuelas de música
        /// </summary>
        /// <returns></returns>
        public static List<ReporteInstrumento> obtenerDotacionInstrumentalDPTO()
        {
            List<ReporteInstrumento> listReporte = new List<ReporteInstrumento>();
            try
            {
                using (var context = new SIPAEntities())
                {
                    var reporte = context.Database.SqlQuery<ReporteInstrumento>(@"EXEC ART_MUSICA_REPORTE_INSTRUMENTO_DPTO");

                    ReporteInstrumento objbasico = null;
                    foreach (var item in reporte)
                    {
                        objbasico = new ReporteInstrumento();
                        objbasico.Id = item.Id;
                        objbasico.departamento = item.departamento.ToString();
                        objbasico.cuerdapulsada = item.cuerdapulsada.ToString();
                        objbasico.cuerdassinf = item.cuerdassinf.ToString();
                        objbasico.vientomadera = item.vientomadera.ToString();
                        objbasico.pmenor = item.pmenor.ToString();
                        objbasico.psinfonica = item.psinfonica.ToString();
                        objbasico.instrumentootra = item.instrumentootra.ToString();

                        objbasico.total = item.total.ToString();
                        listReporte.Add(objbasico);
                    }

                }
                return listReporte;

            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// obtenemos la cantidad de agentes
        /// </summary>
        /// <returns></returns>
        public static int obtenerCantidadAgente()
        {
            int count = 0;
            try
            {
                using (var context = new SIPAEntities())
                {


                    count = context.ART_MUSICA_AGENTE.Where(e => e.EstadoId == 2).Count();



                }
                return count;

            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// obtenemos la cantidad de entidades
        /// </summary>
        /// <returns></returns>
        public static int obtenerCantidadEntidades()
        {
            int count = 0;
            try
            {
                using (var context = new SIPAEntities())
                {


                    count = context.ART_MUSICA_ENTIDADES.Where(e => e.EstadoId == 2).Count();



                }
                return count;

            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// obtenemos la cantidad de agrupaciones
        /// </summary>
        /// <returns></returns>
        public static int obtenerCantidadAgrupaciones()
        {
            int count = 0;
            try
            {
                using (var context = new SIPAEntities())
                {


                    count = context.ART_MUSICA_AGRUPACION.Where(e => e.EstadoId == 2).Count();



                }
                return count;

            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// obtenemos la cantidad de escuelas de música
        /// </summary>
        /// <returns></returns>
        public static int obtenerCantidadEscuelas()
        {
            int count = 0;
            try
            {
                using (var context = new SIPAEntities())
                {
                                        
                    count = (from e in context.ART_ENTIDADES_ARTES
                             join i in context.ART_MUSICA_ENTIDAD_IDENTIFICACION on e.ENT_ID equals i.ENT_ID
                             where e.ENT_TIPO == "E"
                             where i.EstadoId == 2
                             select e).Count();


                }
                return count;

            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Practicas musicales en las escuelas
        /// </summary>
        /// <returns></returns>
        public static List<ReporteComplex> obtenerPracticaMusicaDpto()
        {
            List<ReporteComplex> listReporte = new List<ReporteComplex>();
            try
            {
                using (var context = new SIPAEntities())
                {


                    var reporte = context.Database.SqlQuery<ReporteComplex>(@"EXEC ART_MUSICA_REPORTE_ESCUELA_PRAC_MUSICA_DPTO");


                    ReporteComplex objbasico = null;
                    foreach (var item in reporte)
                    {
                        objbasico = new ReporteComplex();
                        objbasico.Id = item.Id;
                        objbasico.departamento = item.departamento.ToString();
                        objbasico.criterio6 = item.criterio6.ToString();
                        objbasico.criterio7 = item.criterio7.ToString();
                        objbasico.criterio12 = item.criterio12.ToString();

                        objbasico.criterio19 = item.criterio19.ToString();
                        objbasico.criterio26 = item.criterio26.ToString();
                        listReporte.Add(objbasico);
                    }

                }
                return listReporte;

            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Cobertura territorial según el área de ubicación reporte DPTO
        /// </summary>
        /// <returns></returns>
        public static List<ReporteComplex> obtenerAreaMusicaDPTO()
        {
            List<ReporteComplex> listReporte = new List<ReporteComplex>();
            try
            {
                using (var context = new SIPAEntities())
                {


                    var reporte = context.Database.SqlQuery<ReporteComplex>(@"EXEC ART_MUSICA_REPORTE_ESCUELA_AREA_DPTO");


                    ReporteComplex objbasico = null;
                    foreach (var item in reporte)
                    {
                        objbasico = new ReporteComplex();
                        objbasico.Id = item.Id;
                        objbasico.departamento = item.departamento.ToString();
                        objbasico.criterio6 = item.criterio6.ToString();
                        objbasico.criterio7 = item.criterio7.ToString();
                        objbasico.criterio12 = item.criterio12.ToString();

                        objbasico.criterio19 = item.criterio19.ToString();
                        objbasico.criterio26 = item.criterio26.ToString();
                        listReporte.Add(objbasico);
                    }

                }
                return listReporte;

            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Población en condiciones especiales atendida reporte DPTO
        /// </summary>
        /// <returns></returns>
        public static List<ReporteComplex> obtenerPoblaCodEsDPTO()
        {
            List<ReporteComplex> listReporte = new List<ReporteComplex>();
            try
            {
                using (var context = new SIPAEntities())
                {
                    var reporte = context.Database.SqlQuery<ReporteComplex>(@"EXEC ART_MUSICA_REPORTE_ESCUELA_CONDIESPEC_DPTO");


                    ReporteComplex objbasico = null;
                    foreach (var item in reporte)
                    {
                        objbasico = new ReporteComplex();
                        objbasico.Id = item.Id;
                        objbasico.departamento = item.departamento.ToString();
                        objbasico.criterio6 = item.criterio6.ToString();
                        objbasico.criterio7 = item.criterio7.ToString();
                        objbasico.criterio12 = item.criterio12.ToString();

                        objbasico.criterio19 = item.criterio19.ToString();
                        objbasico.criterio26 = item.criterio26.ToString();
                        listReporte.Add(objbasico);
                    }

                }
                return listReporte;

            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Consulta Reporte general
        /// </summary>
        /// <returns></returns>
        public static List<ReporteGeneral> obtenerReporteGeneral()
        {
            List<ReporteGeneral> listReporte = new List<ReporteGeneral>();
            try
            {
                using (var context = new SIPAEntities())
                {
                    var reporte = context.Database.SqlQuery<ReporteGeneral>(@"EXEC ART_MUSICA_REPORTE_GENERAL");


                    ReporteGeneral objbasico = null;
                    #region  reporte dto
                    foreach (var item in reporte)
                    {
                        objbasico = new ReporteGeneral();
                        objbasico.CODIGODEPARTAMENTO = item.CODIGODEPARTAMENTO;
                        objbasico.CODIGOMUNICIPIO = item.CODIGOMUNICIPIO;
                        objbasico.DEPARTAMENTO = item.DEPARTAMENTO;
                        objbasico.MUNICIPIO = item.MUNICIPIO.ToString();
                        objbasico.ESTADO = item.ESTADO.ToString();
                        objbasico.ENT_ID = item.ENT_ID.ToString();
                        objbasico.NOMBRE_ESCUELA = item.NOMBRE_ESCUELA.ToString();
                        objbasico.DIRECCION_ESCUELA = item.DIRECCION_ESCUELA.ToString();
                        objbasico.TELEFONO_ESCUELA = item.TELEFONO_ESCUELA.ToString();
                        objbasico.FAX_ESCUELA = item.FAX_ESCUELA.ToString();

                        objbasico.CORREO_ELECTRONICO_ESCUELA = item.CORREO_ELECTRONICO_ESCUELA.ToString();

                        objbasico.NOMBRE_CONTACTO = item.NOMBRE_CONTACTO.ToString();

                        objbasico.TELEFONO_CONTACTO = item.TELEFONO_CONTACTO.ToString();
                        objbasico.CORREO_ELECTRONICO_CONTACTO = item.CORREO_ELECTRONICO_CONTACTO.ToString();
                        objbasico.NOMBRE_DIRECTOR = item.NOMBRE_DIRECTOR.ToString();
                        objbasico.TELEFONO_DIRECTOR = item.TELEFONO_DIRECTOR.ToString();
                        objbasico.CATEGORIA = item.CATEGORIA.ToString();
                        objbasico.PORCENTAJE = item.PORCENTAJE.ToString();
                        objbasico.FECHA_CREACION = item.FECHA_CATEGORIZACION;
                        objbasico.FECHA_ACTUALIZACION = item.FECHA_ACTUALIZACION;
                        objbasico.NOMBRE_CREADOR = item.NOMBRE_CREADOR;

                        objbasico.NOMBRE_USUARIO_CREADOR = item.NOMBRE_USUARIO_CREADOR;

                        objbasico.CORREO_ELECTRONICO_CREADOR = item.CORREO_ELECTRONICO_CREADOR;

                        objbasico.ESCUELA_CREADA_LEGALMENTE = item.ESCUELA_CREADA_LEGALMENTE;
                        objbasico.TIENE_PERSONERIA_JURIDICA = item.TIENE_PERSONERIA_JURIDICA;
                        objbasico.NATURALEZA = item.NATURALEZA;
                        objbasico.DEPENDE_DE_OTRA_ENTIDAD = item.DEPENDE_DE_OTRA_ENTIDAD;
                        objbasico.ENTIDAD_DE_LA_QUE_DEPENDE = item.ENTIDAD_DE_LA_QUE_DEPENDE;
                        objbasico.TIENE_DIRECTOR = item.TIENE_DIRECTOR;
                        objbasico.NOMBRE_DIRECTOR = item.NOMBRE_DIRECTOR;
                        objbasico.FECHA_NACIMIENTO_DIRECTOR = item.FECHA_NACIMIENTO_DIRECTOR;
                        objbasico.CELULAR_DIRECTOR = item.CELULAR_DIRECTOR;
                        objbasico.TIPO_VINCULACION_DIRECTOR = item.TIPO_VINCULACION_DIRECTOR;
                        objbasico.ENTIDAD_CONTRATANTE_DIRECTOR = item.ENTIDAD_CONTRATANTE_DIRECTOR;
                        objbasico.CANTIDAD_DOCENTES_VOLUNTARIOS = item.CANTIDAD_DOCENTES_VOLUNTARIOS;
                        objbasico.CANTIDAD_DOCENTES_PRESTACION_SERVICIOS = item.CANTIDAD_DOCENTES_PRESTACION_SERVICIOS;
                        objbasico.CANTIDAD_DOCENTES_HONORARIOS = item.CANTIDAD_DOCENTES_HONORARIOS;
                        objbasico.CANTIDAD_DOCENTES_NOMINA = item.CANTIDAD_DOCENTES_NOMINA;
                        objbasico.CANTIDAD_TOTAL_DOCENTES_VINCULADOS = item.CANTIDAD_TOTAL_DOCENTES_VINCULADOS;
                        objbasico.CANTIDAD_DOCENTES_NIVEL_PRIMARIA = item.CANTIDAD_DOCENTES_NIVEL_PRIMARIA;
                        objbasico.CANTIDAD_DOCENTES_NIVEL_SECUNDARIA = item.CANTIDAD_DOCENTES_NIVEL_SECUNDARIA;
                        objbasico.CANTIDAD_DOCENTES_NIVEL_TECNICO = item.CANTIDAD_DOCENTES_NIVEL_TECNICO;
                        objbasico.CANTIDAD_DOCENTES_UNIVERSITARIO = item.CANTIDAD_DOCENTES_UNIVERSITARIO;
                        objbasico.CANTIDAD_DOCENTES_PREGRADO_MUSICA = item.CANTIDAD_DOCENTES_PREGRADO_MUSICA;
                        objbasico.CANTIDAD_DOCENTES_PREGRADO_OTRA_AREA = item.CANTIDAD_DOCENTES_PREGRADO_OTRA_AREA;
                        objbasico.CANTIDAD_DOCENTES_POSTGRADO = item.CANTIDAD_DOCENTES_POSTGRADO;
                        objbasico.CANTIDAD_TOTAL_DOCENTES_NIVEL_EDUCATIVO = item.CANTIDAD_TOTAL_DOCENTES_NIVEL_EDUCATIVO;
                        objbasico.CUENTA_APOYO_ADMINISTRATIVO = item.CUENTA_APOYO_ADMINISTRATIVO;
                        objbasico.CANTIDAD_APOYO_VOLUNTARIO = item.CANTIDAD_APOYO_VOLUNTARIO;
                        objbasico.CANTIDAD_APOYO_PRESTACION_SERVICIOS = item.CANTIDAD_APOYO_PRESTACION_SERVICIOS;
                        objbasico.CANTIDAD_APOYO_HONORARIOS = item.CANTIDAD_APOYO_HONORARIOS;
                        objbasico.CANTIDAD_APOYO_NOMINA = item.CANTIDAD_APOYO_NOMINA;
                        objbasico.INCLUYE_ACTIVIDAD_MUSICAL = item.INCLUYE_ACTIVIDAD_MUSICAL;
                        objbasico.SEDE_DE_TRABAJO = item.SEDE_DE_TRABAJO;
                        objbasico.ESPACIO = item.ESPACIO;
                        objbasico.SEDE_ASIGNADA_SOPORTE_ESCRITO = item.SEDE_ASIGNADA_SOPORTE_ESCRITO;
                        objbasico.CANTIDAD_SILLAS = item.CANTIDAD_SILLAS;
                        objbasico.CANTIDAD_ATRILES = item.CANTIDAD_ATRILES;
                        objbasico.CANTIDAD_TABLEROS = item.CANTIDAD_TABLEROS;

                        objbasico.CANTIDAD_ESTANTERIA = item.CANTIDAD_ESTANTERIA;
                        objbasico.SEDE_ADECUADA_ACUSTICAMENTE = item.SEDE_ADECUADA_ACUSTICAMENTE;

                        objbasico.CANTIDAD_INSTRUMENTOS_VIENTOS_MADERAS = item.CANTIDAD_INSTRUMENTOS_VIENTOS_MADERAS;
                        objbasico.CANTIDAD_INSTRUMENTOS_CUERDAS_SINFONICAS = item.CANTIDAD_INSTRUMENTOS_CUERDAS_SINFONICAS;

                        objbasico.CANTIDAD_INSTRUMENTOS_CUERDAS_PULSADAS = item.CANTIDAD_INSTRUMENTOS_CUERDAS_PULSADAS;
                        objbasico.CANTIDAD_INSTRUMENTOS_VIENTOS_METALES = item.CANTIDAD_INSTRUMENTOS_VIENTOS_METALES;

                        objbasico.CANTIDAD_INSTRUMENTOS_PERCUSION_MENOR = item.CANTIDAD_INSTRUMENTOS_PERCUSION_MENOR;
                        objbasico.CANTIDAD_INSTRUMENTOS_PERCUSION_SINFONICA = item.CANTIDAD_INSTRUMENTOS_PERCUSION_SINFONICA;
                        objbasico.CANTIDAD_INSTRUMENTOS_OTROS = item.CANTIDAD_INSTRUMENTOS_OTROS;
                        objbasico.CANTIDAD_INSTRUMENTOS_TOTAL = item.CANTIDAD_INSTRUMENTOS_TOTAL;
                        objbasico.CUENTA_MATERIAL_PEDAGOGICO = item.CUENTA_MATERIAL_PEDAGOGICO;
                        objbasico.CANTIDAD_TITULOS_BIBLIOGRAFICOS = item.CANTIDAD_TITULOS_BIBLIOGRAFICOS;
                        objbasico.TIENE_ACCESO_INTERNET = item.TIENE_ACCESO_INTERNET;

                        objbasico.CANTIDAD_ALUMNOS_MENOR_6 = item.CANTIDAD_ALUMNOS_MENOR_6;
                        objbasico.CANTIDAD_ALUMNOS_ENTRE_7_11 = item.CANTIDAD_ALUMNOS_ENTRE_7_11;
                        objbasico.CANTIDAD_ALUMNOS_ENTRE_12_18 = item.CANTIDAD_ALUMNOS_ENTRE_12_18;
                        objbasico.CANTIDAD_ALUMNOS_ENTRE_19_25 = item.CANTIDAD_ALUMNOS_ENTRE_19_25;
                        objbasico.CANTIDAD_ALUMNOS_ENTRE_26_60 = item.CANTIDAD_ALUMNOS_ENTRE_26_60;
                        objbasico.CANTIDAD_ALUMNOS_MAYOR_60 = item.CANTIDAD_ALUMNOS_MAYOR_60;
                        objbasico.CANTIDAD_TOTAL_ALUMNOS_EDAD = item.CANTIDAD_TOTAL_ALUMNOS_EDAD;
                        objbasico.CANTIDAD_ALUMNOS_MASCULINO = item.CANTIDAD_ALUMNOS_MASCULINO;



                        objbasico.CANTIDAD_ALUMNOS_MASCULINO = item.CANTIDAD_ALUMNOS_MASCULINO;
                        objbasico.CANTIDAD_ALUMNOS_FEMENINO = item.CANTIDAD_ALUMNOS_FEMENINO;

                        objbasico.CANTIDAD_TOTAL_ALUMNOS_GENERO = item.CANTIDAD_TOTAL_ALUMNOS_GENERO;
                        objbasico.CANTIDAD_ALUMNOS_RURAL = item.CANTIDAD_ALUMNOS_RURAL;
                        objbasico.CANTIDAD_ALUMNOS_URBANA = item.CANTIDAD_ALUMNOS_URBANA;
                        objbasico.CANTIDAD_TOTAL_ALUMNOS_AREA = item.CANTIDAD_TOTAL_ALUMNOS_AREA;
                        objbasico.CANTIDAD_ALUMNOS_INDIGENAS = item.CANTIDAD_ALUMNOS_INDIGENAS;
                        objbasico.CANTIDAD_ALUMNOS_AFRO = item.CANTIDAD_ALUMNOS_AFRO;
                        objbasico.CANTIDAD_ALUMNOS_ROM = item.CANTIDAD_ALUMNOS_ROM;
                        objbasico.CANTIDAD_ALUMNOS_RAIZALES = item.CANTIDAD_ALUMNOS_RAIZALES;
                        objbasico.CANTIDAD_ALUMNOS_OTROS = item.CANTIDAD_ALUMNOS_OTROS;
                        objbasico.CANTIDAD_TOTAL_ALUMNOS_ETNIA = item.CANTIDAD_TOTAL_ALUMNOS_ETNIA;
                        objbasico.CANTIDAD_ALUMNOS_DISCAPACITADOS = item.CANTIDAD_ALUMNOS_DISCAPACITADOS;
                        objbasico.CANTIDAD_ALUMNOS_DESPLAZADOS = item.CANTIDAD_ALUMNOS_DESPLAZADOS;
                        objbasico.CANTIDAD_ALUMNOS_DESVINCULADOS = item.CANTIDAD_ALUMNOS_DESVINCULADOS;
                        objbasico.CANTIDAD_ALUMNOS_VULNERABLES = item.CANTIDAD_ALUMNOS_VULNERABLES;
                        objbasico.CANTIDAD_TOTAL_ALUMNOS_ESPECIALES = item.CANTIDAD_TOTAL_ALUMNOS_ESPECIALES;
                        objbasico.CUENTA_ORGANIZACION_COMUNITARIA = item.CUENTA_ORGANIZACION_COMUNITARIA;
                        objbasico.ORGANIZACION_COMUNITARIA = item.ORGANIZACION_COMUNITARIA;
                        objbasico.OTRA_ORGANIZACION_COMUNITARIA = item.OTRA_ORGANIZACION_COMUNITARIA;



                        objbasico.NOMBRE_ORGANIZACION = item.NOMBRE_ORGANIZACION;

                        objbasico.INTEGRANTES_ORGANIZACION = item.INTEGRANTES_ORGANIZACION;
                        objbasico.NOMBRE_PRESIDENTE_ORGANIZACION = item.NOMBRE_PRESIDENTE_ORGANIZACION;

                        objbasico.TELEFONO_CELULAR_PRESIDENTE_ORGANIZACION = item.TELEFONO_CELULAR_PRESIDENTE_ORGANIZACION;
                        objbasico.TELEFONO_FIJO_PRESIDENTE_ORGANIZACION = item.TELEFONO_FIJO_PRESIDENTE_ORGANIZACION;
                        objbasico.CORREO_ELECTRONICO_PRESIDENTE_ORGANIZACION = item.CORREO_ELECTRONICO_PRESIDENTE_ORGANIZACION;
                        objbasico.PROCESOS_FORMACION = item.PROCESOS_FORMACION;
                        objbasico.PRACTICAS_MUSICALES = item.PRACTICAS_MUSICALES;
                        objbasico.PRACTICAS_MUSICALES_ORIENTADAS_MUSICO = item.PRACTICAS_MUSICALES_ORIENTADAS_MUSICO;
                        objbasico.TALLERES_INDEPENDIENTES = item.TALLERES_INDEPENDIENTES;
                        objbasico.PROGRAMAS_FORMULADOS_ESCRITO = item.PROGRAMAS_FORMULADOS_ESCRITO;
                        objbasico.INICIACION_DURACION_PROMEDIO_MESES = item.INICIACION_DURACION_PROMEDIO_MESES;
                        objbasico.INICIACION_POBLACION = item.INICIACION_POBLACION;
                        objbasico.INICIACION_INTENSIDAD_HORAS_SEMANAL = item.INICIACION_INTENSIDAD_HORAS_SEMANAL;
                        objbasico.INICIACION_OBSERVACIONES = item.INICIACION_OBSERVACIONES;
                        objbasico.BASICO_DURACION_PROMEDIO_MESES = item.BASICO_DURACION_PROMEDIO_MESES;

                        objbasico.BASICO_POBLACION = item.BASICO_POBLACION;
                        objbasico.BASICO_INTENSIDAD_HORAS_SEMANAL = item.BASICO_INTENSIDAD_HORAS_SEMANAL;
                        objbasico.BASICO_OBSERVACIONES = item.BASICO_OBSERVACIONES;
                        objbasico.MEDIO_DURACION_PROMEDIO_MESES = item.MEDIO_DURACION_PROMEDIO_MESES;
                                            
                        objbasico.MEDIO_POBLACION = item.MEDIO_POBLACION;
                        objbasico.MEDIO_INTENSIDAD_HORAS_SEMANAL = item.MEDIO_INTENSIDAD_HORAS_SEMANAL;
                        objbasico.MEDIO_OBSERVACIONES = item.MEDIO_OBSERVACIONES;
                        objbasico.CURSO_DURACION_PROCURSO_SEMANA = item.CURSO_DURACION_PROCURSO_SEMANA;
                        objbasico.CURSO_POBLACION = item.CURSO_POBLACION;
                        objbasico.CURSO_INTENSIDAD_HORAS_SEMANAL = item.CURSO_INTENSIDAD_HORAS_SEMANAL;
                        objbasico.CURSO_OBSERVACIONES = item.CURSO_OBSERVACIONES;
                        objbasico.PEDAGOGIAS_DURACION_PROPEDAGOGIAS_SEMANA = item.PEDAGOGIAS_DURACION_PROPEDAGOGIAS_SEMANA;

                        objbasico.PEDAGOGIAS_POBLACION = item.PEDAGOGIAS_POBLACION;
                        objbasico.PEDAGOGIAS_INTENSIDAD_HORAS_SEMANAL = item.PEDAGOGIAS_INTENSIDAD_HORAS_SEMANAL;
                        objbasico.PEDAGOGIAS_OBSERVACIONES = item.PEDAGOGIAS_OBSERVACIONES;
                        objbasico.CANTIDAD_GIRAS_NACIONALES_ULTIMO_AÑO = item.CANTIDAD_GIRAS_NACIONALES_ULTIMO_AÑO;
                        objbasico.CANTIDAD_GIRAS_INTERNACIONALES_ULTIMO_AÑO = item.CANTIDAD_GIRAS_INTERNACIONALES_ULTIMO_AÑO;
                        objbasico.ENT_CANTIDAD_PRESENTACIONES_LOCALIDAD_ULTIMO_ANIO = item.ENT_CANTIDAD_PRESENTACIONES_LOCALIDAD_ULTIMO_ANIO;

                        objbasico.CANTIDAD_DISCOS_ULTIMO_AÑO = item.CANTIDAD_DISCOS_ULTIMO_AÑO;
                        objbasico.CANTIDAD_DISCOS_ULTIMO_AÑO = item.CANTIDAD_DISCOS_ULTIMO_AÑO;
                        objbasico.CANTIDAD_MATERIAL_DIVULGATIVO_ULTIMO_AÑO = item.CANTIDAD_MATERIAL_DIVULGATIVO_ULTIMO_AÑO;
                        objbasico.CANTIDAD_MATERIAL_APOYO_ULTIMO_AÑO = item.CANTIDAD_MATERIAL_APOYO_ULTIMO_AÑO;
                        objbasico.CANTIDAD_AGRUPACIONES_CONFORMADAS_VIGENTES = item.CANTIDAD_AGRUPACIONES_CONFORMADAS_VIGENTES;
                        objbasico.TipoEscuela = item.TipoEscuela;



                        listReporte.Add(objbasico);
                    }

                }
                    #endregion
                return listReporte;

            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Consulta Reporte general
        /// </summary>
        /// <returns></returns>
        public static List<ReporteGeneralBasico> ObtenerReporteBasico()
        {
            List<ReporteGeneralBasico> listReporte = new List<ReporteGeneralBasico>();
            try
            {
                using (var context = new SIPAEntities())
                {
                    var reporte = context.Database.SqlQuery<ReporteGeneralBasico>(@"EXEC ART_ME_Reporte_General_Datos_Basicos");


                    ReporteGeneralBasico objbasico = null;
                    #region  reporte dto
                    foreach (var item in reporte)
                    {
                        objbasico = new ReporteGeneralBasico();
                        objbasico.CODIGODEPARTAMENTO = item.CODIGODEPARTAMENTO;
                        objbasico.CODIGOMUNICIPIO = item.CODIGOMUNICIPIO;
                        objbasico.DEPARTAMENTO = item.DEPARTAMENTO;
                        objbasico.MUNICIPIO = item.MUNICIPIO.ToString();
                        objbasico.ESTADO = item.ESTADO.ToString();
                        objbasico.ENT_ID = (decimal)item.ENT_ID;
                        objbasico.NOMBRE_ESCUELA = item.NOMBRE_ESCUELA.ToString();
                        objbasico.DIRECCIÓN_ESCUELA = item.DIRECCIÓN_ESCUELA.ToString();
                        objbasico.TELÉFONO_ESCUELA = item.TELÉFONO_ESCUELA.ToString();
                        objbasico.FAX_ESCUELA = item.FAX_ESCUELA.ToString();
                        objbasico.CORREO_ELECTRÓNICO_ESCUELA = item.CORREO_ELECTRÓNICO_ESCUELA.ToString();
                        objbasico.NOMBRE_CONTACTO = item.NOMBRE_CONTACTO.ToString();
                        objbasico.TELÉFONO_CONTACTO = item.TELÉFONO_CONTACTO.ToString();
                        objbasico.CORREO_ELECTRÓNICO_CONTACTO = item.CORREO_ELECTRÓNICO_CONTACTO.ToString();
                        objbasico.NOMBRE_DIRECTOR = item.NOMBRE_DIRECTOR.ToString();
                        objbasico.TELÉFONO_DIRECTOR = item.TELÉFONO_DIRECTOR.ToString();
                        objbasico.CATEGORÍA = item.CATEGORÍA.ToString();
                        objbasico.PORCENTAJE = item.PORCENTAJE;
                        objbasico.FECHA_CATEGORIZACIÓN = item.FECHA_CATEGORIZACIÓN;
                        objbasico.FECHA_ACTUALIZACIÓN = item.FECHA_ACTUALIZACIÓN;
                        objbasico.NOMBRE_CREADOR = item.NOMBRE_CREADOR;
                        objbasico.NOMBRE_USUARIO_CREADOR = item.NOMBRE_USUARIO_CREADOR;
                        objbasico.CORREO_ELECTRONICO_CREADOR = item.CORREO_ELECTRONICO_CREADOR;
                        objbasico.NOMBRE_DIRECTOR = item.NOMBRE_DIRECTOR;
                        objbasico.TipoEscuela = item.TipoEscuela;

                        listReporte.Add(objbasico);
                    }

                }
                    #endregion
                return listReporte;

            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
