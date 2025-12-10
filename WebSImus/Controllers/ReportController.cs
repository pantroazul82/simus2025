using DevExpress.Web.Mvc;
using DevExpress.XtraReports.UI;
using SM.Aplicacion.Escuelas;
using SM.LibreriaComun.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebSImus.Models;

namespace WebSImus.Controllers
{
    [HandleError()]
    [SessionExpire]
    public class ReportController : BaseController
    {
        //
        // GET: /Report/
        public ActionResult Index()
        {
            return View(new XtraReport1());
        }

        public ActionResult ReporteEscuelaVideo()
        {
            return View(new XtraReport2());
        }

        public ActionResult Escuelas(int Id)
        {
            return View(new XtraReportEscuela());
        }

        public ActionResult ReporteBasico()
        {
            return View();
        }

        public ActionResult ConsultaBasico()
        {
            return View();
        }
        public ActionResult ConsultaGeneral()
        {
            return View();
        }

        public ActionResult ExportarExcel()
        {

            string usuarioid = UsuaroId;
            var listaescuelas = SM.Aplicacion.Reporte.ServicioReporteNeg.obtenerReporteGeneral();
            System.Data.DataTable dataTable = new System.Data.DataTable();
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Cod Departamento" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Cod municipio" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Departamento" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Municipio" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Estado" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "EscuelaId" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Nombre escuela" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Dirección escuela" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Teléfono escuela" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Fax escuela" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Correo electrónico escuela" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Nombre contacto" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Teléfono contacto" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Correo electrónico contacto" });

            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Fecha creación" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Fecha actualización" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Nombre creador" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Nombre usuario creador" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Correo electrónico creador" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Escuela creada legalmente" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Personería jurídica" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Naturaleza" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Depende de otra entidad" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Entidad depende" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Tiene director" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Nombre director" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Teléfono director" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Celular director" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Fecha nacimiento director" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Tipo vinculación director" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Entidad contratante director" });


            ///desde aqui
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Cantidad docentes voluntarios" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Cantidad docentes prestación servicio" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Cantidad docentes honorarios" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Cantidad docentes nomina" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Cantidad total docentes vinculados" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Cantidad docentes nivel primaria" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Cantidad docentes nivel secundaria" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Cantidad docentes nivel técnico" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Cantidad docentes universitario" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Cantidad docentes pregrado música" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Cantidad docentes pregrado otra área" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Cantidad docentes postgrado" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Cantidad total docentes nivel educativo" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Cuenta apoyo administrativo" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Cantidad apoyo voluntario" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Cantidad apoyo prestación servicios" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Cantidad apoyo honorarios" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Cantidad apoyo nomina" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Incluye actividad musical" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Sede de trabajo" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Espacio" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Sede asignada soporte escrito" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Cantidad sillas" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Cantidad atriles" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Cantidad tableros" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Cantidad estantería" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Sede adecuada acústicamente" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Porcentaje adecuación acústica" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Cantidad instrumentos cuerdas pulsadas" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Cantidad instrumentos cuerdas sinfónicas" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Cantidad instrumentos vientos maderas" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Cantidad instrumentos vientos metales" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Cantidad instrumentos percusión menor" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Cantidad instrumentos percusión sinfónica" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Cantidad instrumentos otros" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Cantidad instrumentos total" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Cuenta material pedagógico" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Cantidad títulos bibliográficos" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Tiene acceso internet" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Cantidad alumnos menor 6" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Cantidad alumnos entre 7 11" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Cantidad alumnos entre 12 18" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Cantidad alumnos entre 19 25" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Cantidad alumnos entre 26 60" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Cantidad alumnos mayor 60" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Cantidad total alumnos edad" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Cantidad alumnos masculino" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Cantidad alumnos femenino" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Cantidad total alumnos genero" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Cantidad alumnos rural" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Cantidad alumnos urbana" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Cantidad total alumnos área" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Cantidad alumnos indígenas" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Cantidad alumnos afro" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Cantidad alumnos ROM" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Cantidad alumnos raizales" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Cantidad alumnos otros" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Cantidad total alumnos etnia" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Cantidad alumnos discapacitados" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Cantidad alumnos desplazados" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Cantidad alumnos desvinculados" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Cantidad alumnos vulnerables" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Cantidad total alumnos especiales" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Cuenta organización comunitaria" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Organización comunitaria" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Otra organización comunitaria" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Nombre organización" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Integrantes organización" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Nombre presidente organización" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Teléfono celular presidente organización" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Teléfono fijo presidente organización" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Correo electrónico presidente organización" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Procesos formación" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Practicas musicales orientadas músico" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Talleres independientes" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Programas formulados escrito" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Iniciación duración promedio meses" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Iniciación población" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Iniciación intensidad horas semanal" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Iniciación observaciones" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Básico duración promedio meses" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Básico población" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Básico intensidad horas semanal" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Básico observaciones" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Medio duración promedio meses" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Medio población" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Medio intensidad horas semanal" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Medio observaciones" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Curso duración por curso semana" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Curso población" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Curso intensidad horas semanal" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Curso observaciones" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Pedagogías duración por pedagogías semana" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Pedagogías población" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Pedagogías intensidad horas semanal" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Pedagogías observaciones" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Cantidad giras nacionales último año" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Cantidad giras internacionales últimos año" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Cantidad presentaciones localidad último año" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Cantidad discos último año" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Cantidad repertorios último año" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Cantidad material divulgativo último año" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Cantidad material apoyo último año" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Cantidad agrupaciones conformadas vigentes" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Tipo escuela" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Cant. practicas" });
            dataTable.Columns.Add(new System.Data.DataColumn { ColumnName = "Práctica musicales" });
            StringBuilder stringBuilder = new StringBuilder();
            foreach (ReporteGeneralDTO item in listaescuelas)
            {
                stringBuilder.Clear();


                System.Data.DataRow dataRow = dataTable.NewRow();
                dataRow["Cod Departamento"] = item.CODIGODEPARTAMENTO;
                dataRow["Cod municipio"] = item.CODIGOMUNICIPIO;
                dataRow["Departamento"] = item.DEPARTAMENTO;
                dataRow["Municipio"] = item.MUNICIPIO;
                dataRow["Estado"] = item.ESTADO;
                dataRow["EscuelaId"] = item.ENT_ID;
                dataRow["Nombre escuela"] = item.NOMBRE_ESCUELA;
                dataRow["Dirección escuela"] = item.DIRECCION_ESCUELA;
                dataRow["Teléfono escuela"] = item.TELEFONO_ESCUELA;
                dataRow["Fax escuela"] = item.FAX_ESCUELA;
                dataRow["Correo electrónico escuela"] = item.CORREO_ELECTRONICO_ESCUELA;
                dataRow["Nombre contacto"] = item.NOMBRE_CONTACTO;
                dataRow["Teléfono contacto"] = item.TELEFONO_CONTACTO;
                dataRow["Correo electrónico contacto"] = item.CORREO_ELECTRONICO_CONTACTO;

                dataRow["Fecha creación"] = item.FECHA_CREACION;
                dataRow["Fecha actualización"] = item.FECHA_ACTUALIZACION;
                dataRow["Nombre creador"] = item.NOMBRE_CREADOR;
                dataRow["Nombre usuario creador"] = item.NOMBRE_USUARIO_CREADOR;
                dataRow["Correo electrónico creador"] = item.CORREO_ELECTRONICO_CREADOR;

                dataRow["Escuela creada legalmente"] = item.ESCUELA_CREADA_LEGALMENTE;
                dataRow["Personería jurídica"] = item.TIENE_PERSONERIA_JURIDICA;
                dataRow["Naturaleza"] = item.NATURALEZA;
                dataRow["Depende de otra entidad"] = item.DEPENDE_DE_OTRA_ENTIDAD;
                dataRow["Entidad depende"] = item.ENTIDAD_DE_LA_QUE_DEPENDE;
                dataRow["Tiene director"] = item.TIENE_DIRECTOR;
                dataRow["Nombre director"] = item.NOMBRE_DIRECTOR;
                dataRow["Teléfono director"] = item.TELEFONO_DIRECTOR;
                dataRow["Fecha nacimiento director"] = item.FECHA_NACIMIENTO_DIRECTOR;
                dataRow["Celular director"] = item.CELULAR_DIRECTOR;
                dataRow["Tipo vinculación director"] = item.TIPO_VINCULACION_DIRECTOR;
                dataRow["Entidad contratante director"] = item.ENTIDAD_CONTRATANTE_DIRECTOR;

                ///desde aqui
                ///
                dataRow["Cantidad docentes voluntarios"] = item.CANTIDAD_DOCENTES_VOLUNTARIOS;
                dataRow["Cantidad docentes prestación servicio"] = item.CANTIDAD_DOCENTES_PRESTACION_SERVICIOS;
                dataRow["Cantidad docentes honorarios"] = item.CANTIDAD_DOCENTES_HONORARIOS;
                dataRow["Cantidad docentes nomina"] = item.CANTIDAD_DOCENTES_NOMINA;
                dataRow["Cantidad total docentes vinculados"] = item.CANTIDAD_TOTAL_DOCENTES_VINCULADOS;
                dataRow["Cantidad docentes nivel primaria"] = item.CANTIDAD_DOCENTES_NIVEL_PRIMARIA;
                dataRow["Cantidad docentes nivel secundaria"] = item.CANTIDAD_DOCENTES_NIVEL_SECUNDARIA;
                dataRow["Cantidad docentes nivel técnico"] = item.CANTIDAD_DOCENTES_NIVEL_TECNICO;
                dataRow["Cantidad docentes universitario"] = item.CANTIDAD_DOCENTES_UNIVERSITARIO;
                dataRow["Cantidad docentes pregrado música"] = item.CANTIDAD_DOCENTES_PREGRADO_MUSICA;
                dataRow["Cantidad docentes pregrado otra área"] = item.CANTIDAD_DOCENTES_PREGRADO_OTRA_AREA;
                dataRow["Cantidad docentes postgrado"] = item.CANTIDAD_DOCENTES_POSTGRADO;
                dataRow["Cantidad total docentes nivel educativo"] = item.CANTIDAD_TOTAL_DOCENTES_NIVEL_EDUCATIVO;
                dataRow["Cuenta apoyo administrativo"] = item.CUENTA_APOYO_ADMINISTRATIVO;
                dataRow["Cantidad apoyo voluntario"] = item.CANTIDAD_APOYO_VOLUNTARIO;
                dataRow["Cantidad apoyo prestación servicios"] = item.CANTIDAD_APOYO_PRESTACION_SERVICIOS;
                dataRow["Cantidad apoyo honorarios"] = item.CANTIDAD_APOYO_HONORARIOS;
                dataRow["Cantidad apoyo nomina"] = item.CANTIDAD_APOYO_NOMINA;
                dataRow["Incluye actividad musical"] = item.INCLUYE_ACTIVIDAD_MUSICAL;
                dataRow["Sede de trabajo"] = item.SEDE_DE_TRABAJO;
                dataRow["Espacio"] = item.ESPACIO;
                dataRow["Sede asignada soporte escrito"] = item.SEDE_ASIGNADA_SOPORTE_ESCRITO;
                dataRow["Cantidad sillas"] = item.CANTIDAD_SILLAS;
                dataRow["Cantidad atriles"] = item.CANTIDAD_ATRILES;
                dataRow["Cantidad tableros"] = item.CANTIDAD_TABLEROS;
                dataRow["Cantidad estantería"] = item.CANTIDAD_ESTANTERIA;
                dataRow["Sede adecuada acústicamente"] = item.SEDE_ADECUADA_ACUSTICAMENTE;
                dataRow["Porcentaje adecuación acústica"] = item.PORCENTAJE_ADECUACION_ACUSTICA;
                dataRow["Cantidad instrumentos cuerdas pulsadas"] = item.CANTIDAD_INSTRUMENTOS_CUERDAS_PULSADAS;
                dataRow["Cantidad instrumentos cuerdas sinfónicas"] = item.CANTIDAD_INSTRUMENTOS_CUERDAS_SINFONICAS;
                dataRow["Cantidad instrumentos vientos maderas"] = item.CANTIDAD_INSTRUMENTOS_VIENTOS_MADERAS;
                dataRow["Cantidad instrumentos vientos metales"] = item.CANTIDAD_INSTRUMENTOS_VIENTOS_METALES;
                dataRow["Cantidad instrumentos percusión menor"] = item.CANTIDAD_INSTRUMENTOS_PERCUSION_MENOR;
                dataRow["Cantidad instrumentos percusión sinfónica"] = item.CANTIDAD_INSTRUMENTOS_PERCUSION_SINFONICA;
                dataRow["Cantidad instrumentos otros"] = item.CANTIDAD_INSTRUMENTOS_OTROS;
                dataRow["Cantidad instrumentos total"] = item.CANTIDAD_INSTRUMENTOS_TOTAL;
                dataRow["Cuenta material pedagógico"] = item.CUENTA_MATERIAL_PEDAGOGICO;
                dataRow["Cantidad títulos bibliográficos"] = item.CANTIDAD_TITULOS_BIBLIOGRAFICOS;
                dataRow["Tiene acceso internet"] = item.TIENE_ACCESO_INTERNET;
                dataRow["Cantidad alumnos menor 6"] = item.CANTIDAD_ALUMNOS_MENOR_6;
                dataRow["Cantidad alumnos entre 7 11"] = item.CANTIDAD_ALUMNOS_ENTRE_7_11;
                dataRow["Cantidad alumnos entre 12 18"] = item.CANTIDAD_ALUMNOS_ENTRE_12_18;
                dataRow["Cantidad alumnos entre 19 25"] = item.CANTIDAD_ALUMNOS_ENTRE_19_25;
                dataRow["Cantidad alumnos entre 26 60"] = item.CANTIDAD_ALUMNOS_ENTRE_26_60;
                dataRow["Cantidad alumnos mayor 60"] = item.CANTIDAD_ALUMNOS_MAYOR_60;
                dataRow["Cantidad total alumnos edad"] = item.CANTIDAD_TOTAL_ALUMNOS_EDAD;
                dataRow["Cantidad alumnos masculino"] = item.CANTIDAD_ALUMNOS_MASCULINO;
                dataRow["Cantidad alumnos femenino"] = item.CANTIDAD_ALUMNOS_FEMENINO;
                dataRow["Cantidad total alumnos genero"] = item.CANTIDAD_TOTAL_ALUMNOS_GENERO;
                dataRow["Cantidad alumnos rural"] = item.CANTIDAD_ALUMNOS_RURAL;
                dataRow["Cantidad alumnos urbana"] = item.CANTIDAD_ALUMNOS_URBANA;
                dataRow["Cantidad total alumnos área"] = item.CANTIDAD_TOTAL_ALUMNOS_AREA;
                dataRow["Cantidad alumnos indígenas"] = item.CANTIDAD_ALUMNOS_INDIGENAS;
                dataRow["Cantidad alumnos afro"] = item.CANTIDAD_ALUMNOS_AFRO;
                dataRow["Cantidad alumnos ROM"] = item.CANTIDAD_ALUMNOS_ROM;
                dataRow["Cantidad alumnos raizales"] = item.CANTIDAD_ALUMNOS_RAIZALES;
                dataRow["Cantidad alumnos otros"] = item.CANTIDAD_ALUMNOS_OTROS;
                dataRow["Cantidad total alumnos etnia"] = item.CANTIDAD_TOTAL_ALUMNOS_ETNIA;
                dataRow["Cantidad alumnos discapacitados"] = item.CANTIDAD_ALUMNOS_DISCAPACITADOS;
                dataRow["Cantidad alumnos desplazados"] = item.CANTIDAD_ALUMNOS_DESPLAZADOS;
                dataRow["Cantidad alumnos desvinculados"] = item.CANTIDAD_ALUMNOS_DESVINCULADOS;
                dataRow["Cantidad alumnos vulnerables"] = item.CANTIDAD_ALUMNOS_VULNERABLES;
                dataRow["Cantidad total alumnos especiales"] = item.CANTIDAD_TOTAL_ALUMNOS_ESPECIALES;
                dataRow["Cuenta organización comunitaria"] = item.CUENTA_ORGANIZACION_COMUNITARIA;
                dataRow["Organización comunitaria"] = item.ORGANIZACION_COMUNITARIA;
                dataRow["Otra organización comunitaria"] = item.OTRA_ORGANIZACION_COMUNITARIA;
                dataRow["Nombre organización"] = item.NOMBRE_ORGANIZACION;
                dataRow["Integrantes organización"] = item.INTEGRANTES_ORGANIZACION;
                dataRow["Nombre presidente organización"] = item.NOMBRE_PRESIDENTE_ORGANIZACION;
                dataRow["Teléfono celular presidente organización"] = item.TELEFONO_CELULAR_PRESIDENTE_ORGANIZACION;
                dataRow["Teléfono fijo presidente organización"] = item.TELEFONO_FIJO_PRESIDENTE_ORGANIZACION;
                dataRow["Correo electrónico presidente organización"] = item.CORREO_ELECTRONICO_PRESIDENTE_ORGANIZACION;
                dataRow["Procesos formación"] = item.PROCESOS_FORMACION;
                dataRow["Practicas musicales orientadas músico"] = item.PRACTICAS_MUSICALES_ORIENTADAS_MUSICO;
                dataRow["Talleres independientes"] = item.TALLERES_INDEPENDIENTES;
                dataRow["Programas formulados escrito"] = item.PROGRAMAS_FORMULADOS_ESCRITO;
                dataRow["Iniciación duración promedio meses"] = item.INICIACION_DURACION_PROMEDIO_MESES;
                dataRow["Iniciación población"] = item.INICIACION_POBLACION;
                dataRow["Iniciación intensidad horas semanal"] = item.INICIACION_INTENSIDAD_HORAS_SEMANAL;
                dataRow["Iniciación observaciones"] = item.INICIACION_OBSERVACIONES;
                dataRow["Básico duración promedio meses"] = item.BASICO_DURACION_PROMEDIO_MESES;
                dataRow["Básico población"] = item.BASICO_POBLACION;
                dataRow["Básico intensidad horas semanal"] = item.BASICO_INTENSIDAD_HORAS_SEMANAL;
                dataRow["Básico observaciones"] = item.BASICO_OBSERVACIONES;
                dataRow["Medio duración promedio meses"] = item.MEDIO_DURACION_PROMEDIO_MESES;
                dataRow["Medio población"] = item.MEDIO_POBLACION;
                dataRow["Medio intensidad horas semanal"] = item.MEDIO_INTENSIDAD_HORAS_SEMANAL;
                dataRow["Medio observaciones"] = item.MEDIO_OBSERVACIONES;
                dataRow["Curso duración por curso semana"] = item.CURSO_DURACION_PROCURSO_SEMANA;
                dataRow["Curso población"] = item.CURSO_POBLACION;
                dataRow["Curso intensidad horas semanal"] = item.CURSO_INTENSIDAD_HORAS_SEMANAL;
                dataRow["Curso observaciones"] = item.CURSO_OBSERVACIONES;
                dataRow["Pedagogías duración por pedagogías semana"] = item.PEDAGOGIAS_DURACION_PROPEDAGOGIAS_SEMANA;
                dataRow["Pedagogías población"] = item.PEDAGOGIAS_POBLACION;
                dataRow["Pedagogías intensidad horas semanal"] = item.PEDAGOGIAS_INTENSIDAD_HORAS_SEMANAL;
                dataRow["Pedagogías observaciones"] = item.PEDAGOGIAS_OBSERVACIONES;
                dataRow["Cantidad giras nacionales último año"] = item.CANTIDAD_GIRAS_NACIONALES_ULTIMO_AÑO;
                dataRow["Cantidad giras internacionales últimos año"] = item.CANTIDAD_GIRAS_INTERNACIONALES_ULTIMO_AÑO;
                dataRow["Cantidad presentaciones localidad último año"] = item.ENT_CANTIDAD_PRESENTACIONES_LOCALIDAD_ULTIMO_ANIO;
                dataRow["Cantidad discos último año"] = item.CANTIDAD_DISCOS_ULTIMO_AÑO;
                dataRow["Cantidad repertorios último año"] = item.CANTIDAD_REPERTORIOS_ULTIMO_AÑO;
                dataRow["Cantidad material divulgativo último año"] = item.CANTIDAD_MATERIAL_DIVULGATIVO_ULTIMO_AÑO;
                dataRow["Cantidad material apoyo último año"] = item.CANTIDAD_MATERIAL_APOYO_ULTIMO_AÑO;
                dataRow["Cantidad agrupaciones conformadas vigentes"] = item.CANTIDAD_AGRUPACIONES_CONFORMADAS_VIGENTES;
                dataRow["Tipo escuela"] = item.TIPO_ESCUELA;
                dataRow["Cant. practicas"] = item.CANTIDAD_PRACTICA;
                dataRow["Práctica musicales"] = item.PRACTICA_MUSICALES;


                dataTable.Rows.Add(dataRow);
            }


            string nombreArchivo;
            var stream = WebSImus.Comunes.Excel.CrearReporteGeneral("Reporte general escuelas", "", dataTable, out nombreArchivo);
            const string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

            stream.Position = 0;
            return File(stream, contentType, nombreArchivo);
        }

        public ActionResult ExportToPermisos(string OutputFormat)
        {
            var model = new List<ReporteGeneralDTO>();
            model = SM.Aplicacion.Reporte.ServicioReporteNeg.obtenerReporteGeneral();

            return GridViewExtension.ExportToXls(GetGridSettings(), model.ToList());
        }

        public ActionResult ExportToBasico(string OutputFormat)
        {
            var model = new List<ReporteEscuelasBasicoDTO>();
            model = SM.Aplicacion.Reporte.ServicioReporteNeg.ObtenerReporteGeneralBasico();

            return GridViewExtension.ExportToXls(GetGridSettingsBasico(), model.ToList());
        }

        [ValidateInput(false)]
        public ActionResult GridViewConsultaReporte()
        {
            ViewBag.GridSettings = GetGridSettings();
            var model = new List<EscuelaConsultaModel>();
            model = ConsultarEscuelas();


            return PartialView("_GridViewConsultaGeneral", model);
        }

        private List<EscuelaConsultaModel> ConsultarEscuelas()
        {
            var model = new List<EscuelaConsultaModel>();
            var result = new List<EscuelaNuevoDatosDTO>();
            result = EscuelasLogica.ConsultarEscuelasTodos();

            foreach (var item in result)
            {
                var datos = new EscuelaConsultaModel();

                datos.Estado = item.Estado;
                datos.Departamento = item.Departamento;
                datos.EscuelaId = item.ENT_ID;
                datos.FechaActualizacion = item.ENT_FECHA_ACTUALIZACION.ToString("dd/MM/yyyy");
                datos.FechaCreacion = item.ENT_FECHA_DILIGENCIAMIENTO.ToString("dd/MM/yyyy");
                datos.Municipio = item.Municipio;
                datos.NombreEscuela = item.ENT_NOMBRE;
                datos.Naturaleza = item.Naturaleza;
                datos.Tipo = item.Tipo;
                model.Add(datos);
            }



            return model;
        }
        [ValidateInput(false)]
        public ActionResult GridViewReporteBasico()
        {
            ViewBag.GridSettings = GetGridSettingsBasico();
            var model = new List<ReporteEscuelasBasicoDTO>();
            model = SM.Aplicacion.Reporte.ServicioReporteNeg.ObtenerReporteGeneralBasico();

            return PartialView("_GridViewReporteBasico", model);
        }

        private GridViewSettings GetGridSettings()
        {
            var settings = new GridViewSettings();
            settings.Name = "gridUsuarioReporteConsulta";
            settings.CallbackRouteValues = new { Controller = "Report", Action = "GridViewConsultaReporte" };
            settings.Settings.ShowFilterRow = true;
            settings.Settings.ShowFilterRowMenu = true;
            //// Export-specific settings  
            settings.SettingsExport.ExportedRowType = DevExpress.Web.GridViewExportedRowType.All;
            settings.SettingsExport.FileName = "ReportGeneral" + DateTime.Now.ToString("yyyyMMdd: HH:mm") + ".xls";
            settings.SettingsExport.PaperKind = System.Drawing.Printing.PaperKind.A4;


            return settings;
        }

        private GridViewSettings GetGridSettingsBasico()
        {
            var settings = new GridViewSettings();
            settings.Name = "gridReporteBasico";
            settings.CallbackRouteValues = new { Controller = "Report", Action = "GridViewReporteBasico" };
            settings.Settings.ShowFilterRow = true;
            settings.Settings.ShowFilterRowMenu = true;
            //// Export-specific settings  
            settings.SettingsExport.ExportedRowType = DevExpress.Web.GridViewExportedRowType.All;
            settings.SettingsExport.FileName = "ReportGeneralBasico" + DateTime.Now.ToString("yyyyMMdd: HH:mm") + ".xls";
            settings.SettingsExport.PaperKind = System.Drawing.Printing.PaperKind.A4;


            return settings;
        }

        #region metodos adicionales
        public ActionResult GridViewRecursoPaginaAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] WebSImus.Models.EscuelaConsultaModel item)
        {
            var model = new object[0];
            if (ModelState.IsValid)
            {
                try
                {
                    // Insert here a code to insert the new item in your model
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_GridViewConsultaGeneral", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewRecursoPaginaUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] WebSImus.Models.EscuelaConsultaModel item)
        {
            var model = new object[0];
            if (ModelState.IsValid)
            {
                try
                {
                    // Insert here a code to update the item in your model
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_GridViewConsultaGeneral", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewRecursoPaginaDelete(decimal EscuelaId)
        {
            if (EscuelaId != 0)
            {
                try
                {
                    //EscuelasLogica.EliminarEscuelas(EscuelaId);
                    //model = ConsultarEscuelas();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_GridViewConsultaGeneral", null);
        }

        #endregion

    }
}