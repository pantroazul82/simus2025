using SM.Datos.Basicas;
using SM.Datos.DTO;
using SM.LibreriaComun.DTO;
using SM.SIPA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Aplicacion.Reporte
{
    public class ServicioReporteNeg
    {
        /// <summary>
        /// reporte de Donut para el reporte de escuelas por departamento
        /// </summary>
        /// <returns></returns>

        public static List<BasicoReporteDTO> obtenerReporteDptoEscuela()
        {
            List<BasicoReporteDTO> lstRerporte = new List<BasicoReporteDTO>();

            var reporte = SM.Datos.Reportes.ServicioReporte.obtenerEscuelasDpto();
            BasicoReporteDTO objreporte = null;
            foreach (var i in reporte)
            {
                objreporte = new BasicoReporteDTO();
                objreporte.label = i.Nombre;
                objreporte.value = i.Value;


                lstRerporte.Add(objreporte);


            }
            return lstRerporte;
        }

        /// <summary>
        /// Tipo de escuelas privada/publica etc
        /// </summary>
        /// <returns></returns>
        public static List<BasicoReporteDTO> obtenerReporteEscuelasTipo()
        {
            List<BasicoReporteDTO> lstRerporte = new List<BasicoReporteDTO>();

            var reporte = SM.Datos.Reportes.ServicioReporte.obtenerEscuelasPorTipo();
            BasicoReporteDTO objreporte = null;
            foreach (var i in reporte)
            {
                objreporte = new BasicoReporteDTO();
                objreporte.label = i.Nombre;
                objreporte.value = i.Value;


                lstRerporte.Add(objreporte);


            }
            return lstRerporte;
        }


        public static List<BasicoReporteDTO> obtenerReporteEscuelasPracticaMcal()
        {
            List<BasicoReporteDTO> lstRerporte = new List<BasicoReporteDTO>();

            var reporte = SM.Datos.Reportes.ServicioReporte.obtenerEscPorPracticaMuscal();
            BasicoReporteDTO objreporte = null;
            foreach (var i in reporte)
            {
                objreporte = new BasicoReporteDTO();
                objreporte.label = i.Nombre.Trim();
                objreporte.value = i.Value;


                lstRerporte.Add(objreporte);


            }
            return lstRerporte;
        }

        /// <summary>
        /// edades miembros
        /// </summary>
        /// <returns></returns>
        public static List<BasicoReporteDTO> obtenerReporteEscEdadesMiembros()
        {
            List<BasicoReporteDTO> lstRerporte = new List<BasicoReporteDTO>();

            var reporte = SM.Datos.Reportes.ServicioReporte.obtenerEscPorEdaddes();
            BasicoReporteDTO objreporte = null;
            foreach (var i in reporte)
            {
                objreporte = new BasicoReporteDTO();
                objreporte.label = i.Nombre;
                objreporte.value = i.Value;


                lstRerporte.Add(objreporte);


            }
            return lstRerporte;
        }
        public static List<BasicoReporteDTO> obtenerReporteEsceEtnia()
        {
            List<BasicoReporteDTO> lstRerporte = new List<BasicoReporteDTO>();

            var reporte = SM.Datos.Reportes.ServicioReporte.obtenerEscporEtnia();
            BasicoReporteDTO objreporte = null;
            foreach (var i in reporte)
            {
                objreporte = new BasicoReporteDTO();
                objreporte.label = i.Nombre;
                objreporte.value = i.Value;


                lstRerporte.Add(objreporte);


            }
            return lstRerporte;
        }
        public static List<BasicoReporteDTO> obtenerReportesexo()
        {
            List<BasicoReporteDTO> lstRerporte = new List<BasicoReporteDTO>();

            var reporte = SM.Datos.Reportes.ServicioReporte.obtenerEscporSexo();
            BasicoReporteDTO objreporte = null;
            foreach (var i in reporte)
            {
                objreporte = new BasicoReporteDTO();
                objreporte.label = i.Nombre;
                objreporte.value = i.Value;


                lstRerporte.Add(objreporte);


            }
            return lstRerporte;
        }
        public static List<BasicoReporteDTO> obtenerReporteArea()
        {
            List<BasicoReporteDTO> lstRerporte = new List<BasicoReporteDTO>();

            var reporte = SM.Datos.Reportes.ServicioReporte.obtenerEscporArea();
            BasicoReporteDTO objreporte = null;
            foreach (var i in reporte)
            {
                objreporte = new BasicoReporteDTO();
                objreporte.label = i.Nombre;
                objreporte.value = i.Value;


                lstRerporte.Add(objreporte);


            }
            return lstRerporte;
        }

        public static List<BasicoReporteDTO> obtenerReporteCondiesp()
        {
            List<BasicoReporteDTO> lstRerporte = new List<BasicoReporteDTO>();

            var reporte = SM.Datos.Reportes.ServicioReporte.obtenerEscporCodEsp();
            BasicoReporteDTO objreporte = null;
            foreach (var i in reporte)
            {
                objreporte = new BasicoReporteDTO();
                objreporte.label = i.Nombre;
                objreporte.value = i.Value;


                lstRerporte.Add(objreporte);


            }
            return lstRerporte;
        }

        #region nuevos reportes
        /// <summary>
        /// Cantidad de escuelas de música con organización comunitaria   
        /// </summary>
        /// <returns></returns>
        public static List<BasicoReporteDTO> obtenerReporteOrgComunitaria()
        {
            List<BasicoReporteDTO> lstRerporte = new List<BasicoReporteDTO>();

            var reporte = SM.Datos.Reportes.ServicioReporte.obtenerEscporOrgComunitaria();
            BasicoReporteDTO objreporte = null;
            foreach (var i in reporte)
            {
                objreporte = new BasicoReporteDTO();
                objreporte.label = i.Nombre;
                objreporte.value = i.Value;


                lstRerporte.Add(objreporte);


            }
            return lstRerporte;
        }

        /// <summary>
        /// Densidad poblacional por profesor en las escuelas de música  
        /// </summary>
        /// <returns></returns>
        public static List<BasicoReporteDTO> obtenerReporteProfesores()
        {
            List<BasicoReporteDTO> lstRerporte = new List<BasicoReporteDTO>();

            var reporte = SM.Datos.Reportes.ServicioReporte.obtenerEscporProfesores();
            BasicoReporteDTO objreporte = null;
            foreach (var i in reporte)
            {
                objreporte = new BasicoReporteDTO();
                objreporte.label = i.Nombre;
                objreporte.value = i.Value;


                lstRerporte.Add(objreporte);


            }
            return lstRerporte;
        }
        /// <summary>
        /// Obtenemos reporte para xls edades por dpto
        /// </summary>
        /// <returns></returns>
        public static List<ReporteComplexDTO> obtenerReporteEdadesDpto()
        {
            List<ReporteComplexDTO> lstRerporte = new List<ReporteComplexDTO>();

            var reporte = SM.Datos.Reportes.ServicioReporte.obtenerEdadesPorDpto();
            ReporteComplexDTO objreporte = null;
            foreach (var item in reporte)
            {
                objreporte = new ReporteComplexDTO();
                objreporte.Id = item.Id;
                objreporte.departamento = item.departamento.ToString();
                objreporte.criterio6 = item.criterio6.ToString();
                objreporte.criterio7 = item.criterio7.ToString();
                objreporte.criterio12 = item.criterio12.ToString();

                objreporte.criterio19 = item.criterio19.ToString();
                objreporte.criterio26 = item.criterio26.ToString();
                lstRerporte.Add(objreporte);


            }



            return lstRerporte;
        }
        /// <summary>
        /// Cantidad de escuelas por estado de consolidación
        /// </summary>
        /// <returns></returns>
        public static List<BasicoReporteDTO> obtenerCantidadEscuelasConsolidacion()
        {
            List<BasicoReporteDTO> lstRerporte = new List<BasicoReporteDTO>();

            var reporte = SM.Datos.Reportes.ServicioReporte.obtenerCantidadEscuelasConsolidacion();
            BasicoReporteDTO objreporte = null;
            foreach (var i in reporte)
            {
                objreporte = new BasicoReporteDTO();
                objreporte.label = i.Nombre;
                objreporte.value = i.Value;


                lstRerporte.Add(objreporte);


            }
            return lstRerporte;
        }


        /// <summary>
        /// Cantidad de escuelas por estado de consolidación DPTO
        /// </summary>
        /// <returns></returns>
        public static List<ReporteComplexDTO> obtenerCantidadEscuelasConsolidacionDPTO()
        {
            List<ReporteComplexDTO> lstRerporte = new List<ReporteComplexDTO>();

            var reporte = SM.Datos.Reportes.ServicioReporte.obtenerCantidadEscuelasConsolidacionDpto();
            ReporteComplexDTO objreporte = null;
            foreach (var item in reporte)
            {
                objreporte = new ReporteComplexDTO();
                objreporte.Id = item.Id;
                objreporte.departamento = item.departamento.ToString();
                objreporte.criterio6 = item.criterio6.ToString();
                objreporte.criterio7 = item.criterio7.ToString();
                objreporte.criterio12 = item.criterio12.ToString();

                objreporte.criterio19 = item.criterio19.ToString();
                objreporte.criterio26 = item.criterio26.ToString();
                lstRerporte.Add(objreporte);


            }



            return lstRerporte;
        }

        /// <summary>
        /// Cantidad de participaciones de los estudiantes en escenarios
        /// </summary>
        /// <returns></returns>
        public static List<ReporteComplexDTO> obtenerCantidadEstudiantesESC()
        {
            List<ReporteComplexDTO> lstRerporte = new List<ReporteComplexDTO>();

            var reporte = SM.Datos.Reportes.ServicioReporte.obtenerCantidadEstudiantesESC();
            ReporteComplexDTO objreporte = null;
            foreach (var item in reporte)
            {
                objreporte = new ReporteComplexDTO();
                objreporte.Id = item.Id;
                objreporte.departamento = item.departamento.ToString();
                objreporte.criterio6 = item.criterio6.ToString();
                objreporte.criterio7 = item.criterio7.ToString();
                objreporte.criterio12 = item.criterio12.ToString();

                objreporte.criterio19 = item.criterio19.ToString();
                objreporte.criterio26 = item.criterio26.ToString();
                lstRerporte.Add(objreporte);


            }



            return lstRerporte;
        }

        /// <summary>
        ///Cantidad de escuelas que dependen de otra entidad
        /// </summary>
        /// <returns></returns>
        public static List<BasicoReporteDTO> obtenerCantidadEscuelasDependeOtra()
        {
            List<BasicoReporteDTO> lstRerporte = new List<BasicoReporteDTO>();

            var reporte = SM.Datos.Reportes.ServicioReporte.obtenerCantidadEscuelasDependeOtra();
            BasicoReporteDTO objreporte = null;
            foreach (var i in reporte)
            {
                objreporte = new BasicoReporteDTO();
                objreporte.label = i.Nombre;
                objreporte.value = i.Value;


                lstRerporte.Add(objreporte);


            }
            return lstRerporte;
        }



        /// <summary>
        ///Nivel Profesor   grafica
        /// </summary>
        /// <returns></returns>
        public static List<BasicoReporteDTO> obtenerGraphCantidadNivelProfesorDPTO()
        {
            List<BasicoReporteDTO> lstRerporte = new List<BasicoReporteDTO>();

            var reporte = SM.Datos.Reportes.ServicioReporte.obtenerProfesoresNivelEduDpto();

            BasicoReporteDTO objPrimaria = new BasicoReporteDTO();
            objPrimaria.label = "Primaria";
            objPrimaria.value = reporte.Sum(p => Convert.ToDecimal(p.primaria)).ToString();
            lstRerporte.Add(objPrimaria);

            BasicoReporteDTO objSecundaria = new BasicoReporteDTO();
            objSecundaria.label = "Secundaria";
            objSecundaria.value = reporte.Sum(p => Convert.ToDecimal(p.secundaria)).ToString();
            lstRerporte.Add(objSecundaria);

            BasicoReporteDTO objTecnico = new BasicoReporteDTO();
            objTecnico.label = "Tecnico";
            objTecnico.value = reporte.Sum(p => Convert.ToDecimal(p.tecnico)).ToString();
            lstRerporte.Add(objTecnico);

            BasicoReporteDTO objUN = new BasicoReporteDTO();
            objUN.label = "Universitario";
            objUN.value = reporte.Sum(p => Convert.ToDecimal(p.universiatrio)).ToString();
            lstRerporte.Add(objUN);

            BasicoReporteDTO objPMusica = new BasicoReporteDTO();
            objPMusica.label = "Pregrado en musica";
            objPMusica.value = reporte.Sum(p => Convert.ToDecimal(p.pregradomusica)).ToString();

            lstRerporte.Add(objPMusica);

            BasicoReporteDTO objPOtra = new BasicoReporteDTO();
            objPOtra.label = "Pregrado";
            objPOtra.value = reporte.Sum(p => Convert.ToDecimal(p.pregradootra)).ToString();
            lstRerporte.Add(objPOtra);





            return lstRerporte;
        }

        /// <summary>
        /// Cantidad de docentes por nivel educativo reporte
        /// </summary>
        /// <returns></returns>
        public static List<ReporteProfesorDTO> obtenerReportePorfesorNvlDepartamento()
        {
            List<ReporteProfesorDTO> lstRerporte = new List<ReporteProfesorDTO>();

            var reporte = SM.Datos.Reportes.ServicioReporte.obtenerProfesoresNivelEduDpto();
            ReporteProfesorDTO objbasico = null;
            foreach (var item in reporte)
            {
                objbasico = new ReporteProfesorDTO();
                objbasico.Id = item.Id;
                objbasico.departamento = item.departamento.ToString();
                objbasico.primaria = item.primaria.ToString();
                objbasico.secundaria = item.secundaria.ToString();
                objbasico.tecnico = item.tecnico.ToString();
                objbasico.universiatrio = item.universiatrio.ToString();

                objbasico.pregradomusica = item.pregradomusica.ToString();
                objbasico.pregradootra = item.pregradootra.ToString();
                objbasico.total = item.total.ToString();
                lstRerporte.Add(objbasico);


            }



            return lstRerporte;
        }

        /// <summary>
        ///Dotación instrumental existente en las escuelas de música grafica
        /// </summary>
        /// <returns></returns>
        public static List<BasicoReporteDTO> obtenerGraphInstrumentoDepartamento()
        {
            List<BasicoReporteDTO> lstRerporte = new List<BasicoReporteDTO>();

            var reporte = SM.Datos.Reportes.ServicioReporte.obtenerDotacionInstrumentalDPTO();
            BasicoReporteDTO objreporte = null;
            foreach (var i in reporte)
            {
                objreporte = new BasicoReporteDTO();
                objreporte.label = i.departamento;
                objreporte.value = i.total;


                lstRerporte.Add(objreporte);


            }
            return lstRerporte;
        }

        public static List<BasicoReporteDTO> obtenerGraphInstrumentoDepartamentoV2()
        {
            List<BasicoReporteDTO> lstRerporte = new List<BasicoReporteDTO>();

            var reporte = SM.Datos.Reportes.ServicioReporte.obtenerDotacionInstrumentalDPTO();




            BasicoReporteDTO objreporte = new BasicoReporteDTO();
            objreporte.label = "Cuerdas pulsadas";
            objreporte.value = reporte.Sum(x => Convert.ToDecimal(x.cuerdapulsada)).ToString();
            lstRerporte.Add(objreporte);


            objreporte = null;
            objreporte = new BasicoReporteDTO();
            objreporte.label = "Cuerdas sinfónicas";
            objreporte.value = reporte.Sum(x => Convert.ToDecimal(x.cuerdassinf)).ToString();
            lstRerporte.Add(objreporte);

            objreporte = null;
            objreporte = new BasicoReporteDTO();
            objreporte.label = "Vientos de madera";
            objreporte.value = reporte.Sum(x => Convert.ToDecimal(x.vientomadera)).ToString();
            lstRerporte.Add(objreporte);


            objreporte = null;
            objreporte = new BasicoReporteDTO();
            objreporte.label = "Percusión menor";
            objreporte.value = reporte.Sum(x => Convert.ToDecimal(x.pmenor)).ToString();
            lstRerporte.Add(objreporte);


            objreporte = null;
            objreporte = new BasicoReporteDTO();
            objreporte.label = "Percusión sinfonica";
            objreporte.value = reporte.Sum(x => Convert.ToDecimal(x.psinfonica)).ToString();
            lstRerporte.Add(objreporte);

            objreporte = null;
            objreporte = new BasicoReporteDTO();
            objreporte.label = "Otros instrumentos";
            objreporte.value = reporte.Sum(x => Convert.ToDecimal(x.instrumentootra)).ToString();
            lstRerporte.Add(objreporte);
            //objreporte.label = i.departamento;
            //objreporte.value = i.total;







            return lstRerporte;
        }


        /// <summary> 
        /// Dotación instrumental existente en las escuelas de música REPORTE
        /// </summary>
        /// <returns></returns>
        public static List<ReporteInstrumentoDTO> obtenerReporteInstrumentoDepartamento()
        {
            List<ReporteInstrumentoDTO> lstRerporte = new List<ReporteInstrumentoDTO>();

            var reporte = SM.Datos.Reportes.ServicioReporte.obtenerDotacionInstrumentalDPTO();
            ReporteInstrumentoDTO objbasico = null;
            foreach (var item in reporte)
            {
                objbasico = new ReporteInstrumentoDTO();
                objbasico.Id = item.Id;
                objbasico.departamento = item.departamento.ToString();
                objbasico.cuerdapulsada = item.cuerdapulsada.ToString();
                objbasico.cuerdassinf = item.cuerdassinf.ToString();
                objbasico.vientomadera = item.vientomadera.ToString();
                objbasico.pmenor = item.pmenor.ToString();
                objbasico.psinfonica = item.psinfonica.ToString();
                objbasico.instrumentootra = item.instrumentootra.ToString();

                objbasico.total = item.total.ToString();
                lstRerporte.Add(objbasico);


            }



            return lstRerporte;
        }

        public static int obtenerCantidadAgente()
        {
            return SM.Datos.Reportes.ServicioReporte.obtenerCantidadAgente();
        }

        /// <summary>
        /// obtenemos la cantidad de entidades
        /// </summary>
        /// <returns></returns>
        public static int obtenerCantidadEntidades()
        {
            return SM.Datos.Reportes.ServicioReporte.obtenerCantidadEntidades();
        }

        /// <summary>
        /// obtenemos la cantidad de escuelas de música
        /// </summary>
        /// <returns></returns>
        public static int obtenerCantidadAgrupaciones()
        {
            return SM.Datos.Reportes.ServicioReporte.obtenerCantidadAgrupaciones();
        }


        /// <summary>
        /// obtenemos la cantidad de escuelas de música
        /// </summary>
        /// <returns></returns>
        public static int obtenerCantidadEscuelas() 
        {
            return SM.Datos.Reportes.ServicioReporte.obtenerCantidadEscuelas();
        }

        /// <summary>
        /// Practicas musicales en las escuelas por dpto
        /// </summary>
        /// <returns></returns>
        public static List<ReporteComplexDTO> obtenerPracticaMusicaDpto()
        {
            List<ReporteComplexDTO> lstRerporte = new List<ReporteComplexDTO>();

            var reporte = SM.Datos.Reportes.ServicioReporte.obtenerPracticaMusicaDpto();
            ReporteComplexDTO objreporte = null;
            foreach (var item in reporte)
            {
                objreporte = new ReporteComplexDTO();
                objreporte.Id = item.Id;
                objreporte.departamento = item.departamento.ToString();
                objreporte.criterio6 = item.criterio6.ToString();
                objreporte.criterio7 = item.criterio7.ToString();
                objreporte.criterio12 = item.criterio12.ToString();

                objreporte.criterio19 = item.criterio19.ToString();
                objreporte.criterio26 = item.criterio26.ToString();
                lstRerporte.Add(objreporte);


            }



            return lstRerporte;
        }




        /// <summary>
        /// Cobertura territorial según el área de ubicación reporte DPTO
        /// </summary>
        /// <returns></returns>
        public static List<ReporteComplexDTO> obtenerAreaMusicaDPTO()
        {
            List<ReporteComplexDTO> lstRerporte = new List<ReporteComplexDTO>();

            var reporte = SM.Datos.Reportes.ServicioReporte.obtenerAreaMusicaDPTO();
            ReporteComplexDTO objreporte = null;
            foreach (var item in reporte)
            {
                objreporte = new ReporteComplexDTO();
                objreporte.Id = item.Id;
                objreporte.departamento = item.departamento.ToString();
                objreporte.criterio6 = item.criterio6.ToString();
                objreporte.criterio7 = item.criterio7.ToString();
                objreporte.criterio12 = item.criterio12.ToString();

                objreporte.criterio19 = item.criterio19.ToString();
                objreporte.criterio26 = item.criterio26.ToString();
                lstRerporte.Add(objreporte);


            }



            return lstRerporte;
        }
        /// <summary>
        /// Población en condiciones especiales atendida reporte DPTO
        /// </summary>
        /// <returns></returns>
        public static List<ReporteComplexDTO> obtenerPoblaCodEsDPTO()
        {
            List<ReporteComplexDTO> lstRerporte = new List<ReporteComplexDTO>();

            var reporte = SM.Datos.Reportes.ServicioReporte.obtenerPoblaCodEsDPTO();
            ReporteComplexDTO objreporte = null;

            foreach (var item in reporte)
            {
                objreporte = new ReporteComplexDTO();
                objreporte.Id = item.Id;
                objreporte.departamento = item.departamento.ToString();
                objreporte.criterio6 = item.criterio6.ToString();
                objreporte.criterio7 = item.criterio7.ToString();
                objreporte.criterio12 = item.criterio12.ToString();

                objreporte.criterio19 = item.criterio19.ToString();
                objreporte.criterio26 = item.criterio26.ToString();
                lstRerporte.Add(objreporte);


            }



            return lstRerporte;
        }

        /// <summary>
        /// Obtenemos el reporte general
        /// </summary>
        /// <returns></returns>
        public static List<ReporteGeneralDTO> obtenerReporteGeneral()
        {
            List<ReporteGeneralDTO> lstRerporte = new List<ReporteGeneralDTO>();

            var reporte = SM.Datos.Reportes.ServicioReporte.obtenerReporteGeneral();
            ReporteGeneralDTO objbasico = null;
            var listaPracticas = new List<ART_ME_ART_MUSICA_PRACTICAMUSICAL_ObtenerPorENT_ID_Result>();
            //ConsultarPracticaMusicalSeleccionada()
            #region  reporte dto
            foreach (var item in reporte)
            {

                objbasico = new ReporteGeneralDTO();
                objbasico.ENT_ID = item.ENT_ID.ToString();
                objbasico.CODIGODEPARTAMENTO = item.CODIGODEPARTAMENTO;
                objbasico.CODIGOMUNICIPIO = item.CODIGOMUNICIPIO; 
                objbasico.DEPARTAMENTO = item.DEPARTAMENTO;
                objbasico.MUNICIPIO = item.MUNICIPIO.ToString();
                objbasico.ESTADO = item.ESTADO.ToString();

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
                objbasico.FECHA_CREACION = item.FECHA_CREACION;
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
                objbasico.TIPO_ESCUELA = item.TipoEscuela;

                ///practicas musicales
                ///
                listaPracticas = ServicioBasicas.ConsultarPracticaMusicalSeleccionada(Convert.ToDecimal(item.ENT_ID));
                if (listaPracticas != null  && listaPracticas.Count > 0)
                {
                    objbasico.CANTIDAD_PRACTICA = listaPracticas.Count.ToString();

                    string nombrepracticas = "";
                    foreach (var x in listaPracticas)
                    {
                        nombrepracticas = nombrepracticas + x.ART_MUS_PRAC_MUS_DESCRIPCION.Trim() + ", ";
                    }

                    objbasico.PRACTICA_MUSICALES = nombrepracticas;
                }
                lstRerporte.Add(objbasico);
            }


            #endregion



            return lstRerporte;
        }


        /// <summary>
        /// Obtenemos el reporte general báisco
        /// </summary>
        /// <returns></returns>
        public static List<ReporteEscuelasBasicoDTO> ObtenerReporteGeneralBasico()
        {
            List<ReporteEscuelasBasicoDTO> lstRerporte = new List<ReporteEscuelasBasicoDTO>();

            var reporte = SM.Datos.Reportes.ServicioReporte.ObtenerReporteBasico();
            ReporteEscuelasBasicoDTO objbasico = null;

            #region  reporte dto
            foreach (var item in reporte)
            {

                objbasico = new ReporteEscuelasBasicoDTO();
                objbasico.ENT_ID = item.ENT_ID.ToString();
                objbasico.CODIGODEPARTAMENTO = item.CODIGODEPARTAMENTO;
                objbasico.CODIGOMUNICIPIO = item.CODIGOMUNICIPIO;
                objbasico.DEPARTAMENTO = item.DEPARTAMENTO;
                objbasico.MUNICIPIO = item.MUNICIPIO.ToString();
                objbasico.ESTADO = item.ESTADO.ToString();
                objbasico.NOMBRE_ESCUELA = item.NOMBRE_ESCUELA.ToString();
                objbasico.DIRECCION_ESCUELA = item.DIRECCIÓN_ESCUELA.ToString();
                objbasico.TELEFONO_ESCUELA = item.TELÉFONO_ESCUELA.ToString();
                objbasico.FAX_ESCUELA = item.FAX_ESCUELA.ToString();
                objbasico.CORREO_ELECTRONICO_ESCUELA = item.CORREO_ELECTRÓNICO_ESCUELA.ToString();
                objbasico.NOMBRE_CONTACTO = item.NOMBRE_CONTACTO.ToString();
                objbasico.TELEFONO_CONTACTO = item.TELÉFONO_CONTACTO.ToString();
                objbasico.CORREO_ELECTRONICO_CONTACTO = item.CORREO_ELECTRÓNICO_CONTACTO.ToString();
                objbasico.NOMBRE_DIRECTOR = item.NOMBRE_DIRECTOR.ToString();
                objbasico.TELEFONO_DIRECTOR = item.TELÉFONO_DIRECTOR.ToString();
                objbasico.CATEGORIA = item.CATEGORÍA.ToString();
                objbasico.PORCENTAJE = item.PORCENTAJE.ToString();
                objbasico.FECHA_CATEGORIZACIÓN = item.FECHA_CATEGORIZACIÓN;
                objbasico.FECHA_ACTUALIZACION = (DateTime)item.FECHA_ACTUALIZACIÓN;
                objbasico.NOMBRE_CREADOR = item.NOMBRE_CREADOR;
                objbasico.NOMBRE_USUARIO_CREADOR = item.NOMBRE_USUARIO_CREADOR;
                objbasico.CORREO_ELECTRONICO_CREADOR = item.CORREO_ELECTRONICO_CREADOR;
                objbasico.TIPO_ESCUELA = item.TipoEscuela;
                lstRerporte.Add(objbasico);
            }


            #endregion



            return lstRerporte;
        }


        #endregion


    }
}
