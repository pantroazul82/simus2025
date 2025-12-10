using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using SM.LibreriaComun.DTO;
using SM.Aplicacion.Escuelas;
using SM.Aplicacion.Basicas;
using SM.Aplicacion.Formularios;
using System.Drawing;
using SM.LibreriaComun.DTO.FichaAsesoria;
using SM.LibreriaComun.DTO.EntidadesOperadoras;
using SM.Aplicacion.EntidadesOpeadoras;

namespace WebSImus.Helpers
{
    public class GenerarArchivo
    {
        public static byte[] ObtenerFichaCompleta(decimal escuelaId, out string nombreArchivo)
        {
            nombreArchivo = string.Empty;

            try
            {
                nombreArchivo = "FichaCompleta.xlsx";
                var rutaPlantilla = HttpContext.Current.Server.MapPath("~/Reportes/FichaCompletaPlantilla.xlsx");
                var rutaArchivo = HttpContext.Current.Server.MapPath("~/Reportes/FichaCompleta.xlsx");

                FileInfo template = new FileInfo(rutaPlantilla);
                FileInfo newFile = new FileInfo(rutaArchivo);

                using (ExcelPackage xlPackage = new ExcelPackage(newFile, template))
                {
                    ExcelWorksheet worksheet = xlPackage.Workbook.Worksheets[1];
                    const int columna = 2;
                    // const int columna = 7;

                    EscuelaDTO datosBasicos = EscuelasLogica.ConsultarDatosBasicosPorId(escuelaId);
                    CronogramaEntidadEscuelaDTO datosEntidad = CronogramaNeg.ConsultarResponsableCronogramas(escuelaId);
                    if (datosEntidad != null)
                    {
                        if (!String.IsNullOrEmpty(datosEntidad.Entidad))
                            worksheet.Cells[4, 1].Value = string.Format("{0}", datosEntidad.Entidad.ToUpper());
                        if (!String.IsNullOrEmpty(datosEntidad.Agente))
                            worksheet.Cells[12, 2].Value = string.Format("{0}", datosEntidad.Agente.ToUpper()); ;
                    }

                    if (datosBasicos != null)
                    {
                        string nombre = datosBasicos.ENT_NOMBRE.Trim();
                        string tipo = string.Empty;
                        string Operatividad = string.Empty;

                        nombreArchivo = "FichaCompleta " + nombre + ".xlsx";
                        if (!String.IsNullOrEmpty(datosBasicos.TipoEscuela))
                            tipo = ParametrosLogica.ObtenerNombreTipoEscuela(Convert.ToInt32(datosBasicos.TipoEscuela));

                        if (!String.IsNullOrEmpty(datosBasicos.OperatividadEscuela))
                            Operatividad = ParametrosLogica.obtenerNombreParametro(Convert.ToInt32(datosBasicos.OperatividadEscuela));

                        //worksheet.Cells[6, 1].Value = string.Format("FICHA COMPLETA - {0}", nombre.ToUpper());
                        worksheet.Cells[6, 1].Value = string.Format("{0}", nombre.ToUpper());
                        worksheet.Cells[8, 1].Value = string.Format("Última actualización {0} - Fecha de generación del reporte: {1}", datosBasicos.ENT_FECHA_ACTUALIZACION, DateTime.Now);

                        // Estado
                        worksheet.Cells[11, columna].Value = datosBasicos.ENT_ESTADO.ToString().ToUpper() == "E" ? "Publicado" : "No publicado";

                        // Datos de identificación de la escuela
                        worksheet.Cells[14, columna].Value = nombre;
                        worksheet.Cells[15, columna].Value = tipo;
                        worksheet.Cells[19, columna].Value = Operatividad;
                        if (!string.IsNullOrEmpty(datosBasicos.ENT_NIT))
                            worksheet.Cells[16, columna].Value = datosBasicos.ENT_NIT.Trim();
                        if (!string.IsNullOrEmpty(datosBasicos.ENT_ANO_CONSTITUCION.ToString()))
                            worksheet.Cells[17, columna].Value = datosBasicos.ENT_ANO_CONSTITUCION.ToString();
                        if (!string.IsNullOrEmpty(datosBasicos.ENT_RESENA))
                            worksheet.Cells[18, columna].Value = datosBasicos.ENT_RESENA.ToString();

                        // Datos del contacto de la escuela
                        if (!string.IsNullOrEmpty(datosBasicos.ENT_NOMBRE_CONTACTO))
                            worksheet.Cells[21, columna].Value = datosBasicos.ENT_NOMBRE_CONTACTO.ToString();
                        if (!string.IsNullOrEmpty(datosBasicos.ENT_CARGO_CONTACTO))
                            worksheet.Cells[22, columna].Value = datosBasicos.ENT_CARGO_CONTACTO.ToString();
                        if (!string.IsNullOrEmpty(datosBasicos.ENT_TELEFONOS))
                            worksheet.Cells[23, columna].Value = datosBasicos.ENT_TELEFONOS.ToString();
                        if (!string.IsNullOrEmpty(datosBasicos.ENT_CONTACTO_CORREO))
                            worksheet.Cells[24, columna].Value = datosBasicos.ENT_CONTACTO_CORREO.ToString();

                        //Datos departamento y municipio
                        if (!string.IsNullOrEmpty(datosBasicos.ZON_NOMBRE_PADRE))
                            worksheet.Cells[27, columna].Value = datosBasicos.ZON_NOMBRE_PADRE.ToString();
                        if (!string.IsNullOrEmpty(datosBasicos.ZON_NOMBRE))
                            worksheet.Cells[28, columna].Value = datosBasicos.ZON_NOMBRE.ToString();
                        worksheet.Cells[7, 1].Value = string.Format("{0} - {1}", worksheet.Cells[28, columna].Value, worksheet.Cells[27, columna].Value);
                        // Datos Ubicación de la escuela

                        int AreaId = EscuelasLogica.ConsultarAreaPorId(escuelaId);
                        if (AreaId == 4)
                            worksheet.Cells[29, columna].Value = "Urbana";
                        else if (AreaId == 5)
                            worksheet.Cells[29, columna].Value = "Rural";

                        worksheet.Cells[30, columna].Value = datosBasicos.ENT_DIRECCION.Trim();
                        if (!string.IsNullOrEmpty(datosBasicos.ENT_TELEFONO))
                            worksheet.Cells[31, columna].Value = datosBasicos.ENT_TELEFONO.ToString();
                        if (!string.IsNullOrEmpty(datosBasicos.ENT_FAX))
                            worksheet.Cells[32, columna].Value = datosBasicos.ENT_FAX.ToString();
                        if (!string.IsNullOrEmpty(datosBasicos.ENT_CORREO_ELECTRONICO_ENTIDAD))
                            worksheet.Cells[33, columna].Value = datosBasicos.ENT_CORREO_ELECTRONICO_ENTIDAD.ToString();
                        if (!string.IsNullOrEmpty(datosBasicos.ENT_PAGINA_WEB))
                            worksheet.Cells[34, columna].Value = datosBasicos.ENT_PAGINA_WEB.ToString();
                        if (!string.IsNullOrEmpty(datosBasicos.PERFIL_FACEBOOK))
                            worksheet.Cells[37, columna].Value = datosBasicos.PERFIL_FACEBOOK.ToString();
                        if (!string.IsNullOrEmpty(datosBasicos.PERFIL_TWITTER))
                            worksheet.Cells[38, columna].Value = datosBasicos.PERFIL_TWITTER.ToString();
                        if (!string.IsNullOrEmpty(datosBasicos.CANAL_YOUTUBE))
                            worksheet.Cells[39, columna].Value = datosBasicos.CANAL_YOUTUBE.ToString();
                    }


                    // Institucionalidad

                    InstitucionalidadDTO datosInstitucionalidad = InstitucionalidadLogica.ConsultarInstitucionalidadPorId(escuelaId);
                    worksheet.Cells[44, columna].Value = "No";

                    if (datosInstitucionalidad != null)
                    {
                        string regimenId = datosInstitucionalidad.Regimen;
                        string SubregimenId = datosInstitucionalidad.SubRegimen;
                        string regimenPadre = "";
                        string Subregimen = "";
                        string NombreNivel = "";
                        string TipoVinculacionDirector = "";
                        int NivelesId = datosInstitucionalidad.NivelEntidad;
                        int TipoVinculacionId = datosInstitucionalidad.ENT_TIPO_VINCULACION_DIRECTOR;
                        if (!string.IsNullOrEmpty(regimenId))
                        {
                            if (regimenId != "0")
                                regimenPadre = ParametrosLogica.ConsultarNombreRegimen(Convert.ToDecimal(regimenId));
                        }
                        if (!string.IsNullOrEmpty(SubregimenId))
                        {
                            if (SubregimenId != "0")
                                Subregimen = ParametrosLogica.ConsultarNombreRegimen(Convert.ToDecimal(SubregimenId));
                        }
                        if (NivelesId > 0)
                            NombreNivel = ParametrosLogica.ConsultarNombreNiveles(NivelesId);
                        if (TipoVinculacionId > 0)
                            TipoVinculacionDirector = ParametrosLogica.ConsultarTipoVinculacion(TipoVinculacionId);
                        worksheet.Cells[49, columna].Value = regimenPadre;
                        worksheet.Cells[50, columna].Value = Subregimen;

                        if (!string.IsNullOrEmpty(datosInstitucionalidad.Naturaleza))
                        {
                            switch (datosInstitucionalidad.Naturaleza.ToString())
                            {
                                case "PUBLICA":
                                    worksheet.Cells[51, columna].Value = "Pública";
                                    break;
                                case "PRIVADA":
                                    worksheet.Cells[51, columna].Value = "Privada";
                                    break;
                                case "MIXTA":
                                    worksheet.Cells[51, columna].Value = "Mixta";
                                    break;
                            }
                        }

                        worksheet.Cells[52, columna].Value = datosInstitucionalidad.DependeEntidad.ToString().ToUpper() == "1" ? "Si" : "No";
                        if (!String.IsNullOrEmpty(datosInstitucionalidad.EntidadDepende))
                            worksheet.Cells[53, columna].Value = datosInstitucionalidad.EntidadDepende.ToString();
                        worksheet.Cells[54, columna].Value = NombreNivel;

                        worksheet.Cells[43, columna].Value = "No";
                        if (Convert.ToBoolean(datosInstitucionalidad.ENT_CREADA_LEGALMENTE))
                        {
                            worksheet.Cells[43, columna].Value = "Si";
                        }
                        worksheet.Cells[57, columna].Value = "No";
                        if (Convert.ToBoolean(datosInstitucionalidad.ENT_TIENE_DIRECTOR))
                        {
                            worksheet.Cells[57, columna].Value = "Si";
                        }

                        if (!String.IsNullOrEmpty(datosInstitucionalidad.ENT_NOMBRES_DIRECTOR))
                            worksheet.Cells[58, columna].Value = datosInstitucionalidad.ENT_NOMBRES_DIRECTOR.ToString();
                        if (datosInstitucionalidad.ENT_FECHA_NACIMIENTO_DIRECTOR != null && !string.IsNullOrEmpty(datosInstitucionalidad.ENT_FECHA_NACIMIENTO_DIRECTOR.ToString()))
                        {
                            DateTime fechaNacimiento = Convert.ToDateTime(datosInstitucionalidad.ENT_FECHA_NACIMIENTO_DIRECTOR.ToString());
                            worksheet.Cells[59, columna].Value = fechaNacimiento.ToShortDateString();
                        }

                        if (!String.IsNullOrEmpty(datosInstitucionalidad.ENT_CELULAR_DIRECTOR))
                            worksheet.Cells[60, columna].Value = datosInstitucionalidad.ENT_CELULAR_DIRECTOR.ToString();

                        worksheet.Cells[61, columna].Value = TipoVinculacionDirector;
                        if (!String.IsNullOrEmpty(datosInstitucionalidad.ENT_ENTIDAD_CONTRATANTE))
                            worksheet.Cells[62, columna].Value = datosInstitucionalidad.ENT_ENTIDAD_CONTRATANTE.ToString();
                        worksheet.Cells[68, columna].Value = datosInstitucionalidad.ENT_CANTIDAD_DOCENTES_VOLUNTARIOS.ToString();
                        worksheet.Cells[69, columna].Value = datosInstitucionalidad.ENT_CANTIDAD_DOCENTES_NOMINA.ToString();
                        worksheet.Cells[70, columna].Value = datosInstitucionalidad.ENT_CANTIDAD_DOCENTES_HONORARIOS.ToString();
                        worksheet.Cells[71, columna].Value = datosInstitucionalidad.ENT_CANTIDAD_DOCENTES_PRESTACION_SERVICIOS.ToString();

                        worksheet.Cells[74, columna].Value = datosInstitucionalidad.ENT_CANTIDAD_DOCENTES_NIVEL_PRIMARIA.ToString();
                        worksheet.Cells[75, columna].Value = datosInstitucionalidad.ENT_CANTIDAD_DOCENTES_NIVEL_SECUNDARIA.ToString();
                        worksheet.Cells[76, columna].Value = datosInstitucionalidad.ENT_CANTIDAD_DOCENTES_NIVEL_TECNICO.ToString();
                        worksheet.Cells[77, columna].Value = datosInstitucionalidad.ENT_CANTIDAD_DOCENTES_UNIVERSITARIO.ToString();
                        worksheet.Cells[78, columna].Value = datosInstitucionalidad.ENT_CANTIDAD_DOCENTES_PREGRADO_MUSICA.ToString();
                        worksheet.Cells[79, columna].Value = datosInstitucionalidad.ENT_CANTIDAD_DOCENTES_PREGRADO_OTRA_AREA.ToString();
                        worksheet.Cells[80, columna].Value = datosInstitucionalidad.ENT_CANTIDAD_DOCENTES_POSTGRADO.ToString();

                        worksheet.Cells[82, columna].Value = "No";
                        if (Convert.ToBoolean(datosInstitucionalidad.ENT_CUENTA_APOYO_ADMINISTRATIVO))
                        {
                            worksheet.Cells[82, columna].Value = "Si";
                        }
                        worksheet.Cells[83, columna].Value = datosInstitucionalidad.ENT_CANTIDAD_APOYO_VOLUNTARIO.ToString();
                        worksheet.Cells[84, columna].Value = datosInstitucionalidad.ENT_CANTIDAD_APOYO_PRESTACION_SERVICIOS.ToString();
                        worksheet.Cells[85, columna].Value = datosInstitucionalidad.ENT_CANTIDAD_APOYO_HONORARIOS.ToString();
                        worksheet.Cells[86, columna].Value = datosInstitucionalidad.ENT_CANTIDAD_APOYO_NOMINA.ToString();

                        worksheet.Cells[88, columna].Value = "No";
                        if (Convert.ToBoolean(datosInstitucionalidad.ENT_INCLUYE_ACTIVIDAD_MUSICAL))
                        {
                            worksheet.Cells[88, columna].Value = "Si";
                        }
                    }


                    ///Todo.  traer la información de la base datos
                    worksheet.Cells[63, columna].Value = "No";
                    //End institucionalidad
                    var tiposProyectosOtroEscuela = string.Empty;
                    ParticipacionDTO datosParticipacion = ParticipacionLogica.ConsultarParticipacionPorId(escuelaId);
                    if (datosParticipacion != null)
                    {
                        worksheet.Cells[126, columna].Value = datosParticipacion.ENT_CANTIDAD_ALUMNOS_MENOR_6.ToString();
                        worksheet.Cells[127, columna].Value = datosParticipacion.ENT_CANTIDAD_ALUMNOS_ENTRE_7_11.ToString();
                        worksheet.Cells[128, columna].Value = datosParticipacion.ENT_CANTIDAD_ALUMNOS_ENTRE_12_18.ToString();
                        worksheet.Cells[129, columna].Value = datosParticipacion.ENT_CANTIDAD_ALUMNOS_ENTRE_19_25.ToString();
                        worksheet.Cells[130, columna].Value = datosParticipacion.ENT_CANTIDAD_ALUMNOS_MAYOR_26.ToString();
                        worksheet.Cells[131, columna].Value = datosParticipacion.ENT_CANTIDAD_ALUMNOS_MAYOR_60.ToString();
                        worksheet.Cells[132, columna].Value = datosParticipacion.ENT_CANTITDAD_TOTAL_ALUMNOS_EDAD.ToString();

                        worksheet.Cells[135, columna].Value = datosParticipacion.ENT_CANTIDAD_ALUMNOS_INDIGENAS.ToString();
                        worksheet.Cells[136, columna].Value = datosParticipacion.ENT_CANTIDAD_ALUMNOS_AFRO.ToString();
                        worksheet.Cells[137, columna].Value = datosParticipacion.ENT_CANTIDAD_ALUMNOS_ROM.ToString();
                        worksheet.Cells[138, columna].Value = datosParticipacion.ENT_CANTIDAD_ALUMNOS_RAIZALES.ToString();
                        worksheet.Cells[139, columna].Value = datosParticipacion.ENT_CANTIDAD_ALUMNOS_OTROS.ToString();

                        worksheet.Cells[142, columna].Value = datosParticipacion.ENT_CANTIDAD_ALUMNOS_FEMENINO.ToString();
                        worksheet.Cells[143, columna].Value = datosParticipacion.ENT_CANTIDAD_ALUMNOS_MASCULINO.ToString();

                        worksheet.Cells[146, columna].Value = datosParticipacion.ENT_CANTIDAD_ALUMNOS_RURAL.ToString();
                        worksheet.Cells[147, columna].Value = datosParticipacion.ENT_CANTIDAD_ALUMNOS_URBANA.ToString();

                        worksheet.Cells[150, columna].Value = datosParticipacion.ENT_CANTIDAD_ALUMNOS_DISCAPACITADOS.ToString();
                        worksheet.Cells[151, columna].Value = datosParticipacion.ENT_CANTIDAD_ALUMNOS_DESPLAZADOS.ToString();

                        worksheet.Cells[153, columna].Value = "No";
                        if (Convert.ToBoolean(datosParticipacion.ENT_ORGANIZACION_COMUNITARIA))
                        {
                            worksheet.Cells[153, columna].Value = "Si";
                        }

                        string strOrganizacion = "";
                        int organizacionId = datosParticipacion.ORGANIZACION_COMUNITARIA_ID;
                        if (organizacionId > 0)
                            strOrganizacion = ParametrosLogica.ConsultarNombreOrganizacionComunitaria(organizacionId);

                        worksheet.Cells[154, columna].Value = strOrganizacion;

                        if (!String.IsNullOrEmpty(datosParticipacion.ENT_NOMBRE_ORGANIZACION))
                            worksheet.Cells[155, columna].Value = datosParticipacion.ENT_NOMBRE_ORGANIZACION.ToString();

                        worksheet.Cells[156, columna].Value = datosParticipacion.ENT_INTEGRANTES_ORGANIZACION.ToString();
                        if (!String.IsNullOrEmpty(datosParticipacion.ENT_NOMBRE_PRESIDENTE_ORGANIZACION))
                            worksheet.Cells[157, columna].Value = datosParticipacion.ENT_NOMBRE_PRESIDENTE_ORGANIZACION.ToString();
                        if (!String.IsNullOrEmpty(datosParticipacion.ENT_TELEFONO_CELULAR_PRESIDENTE_ORGANIZACION))
                            worksheet.Cells[158, columna].Value = datosParticipacion.ENT_TELEFONO_CELULAR_PRESIDENTE_ORGANIZACION.ToString();
                        if (!String.IsNullOrEmpty(datosParticipacion.ENT_TELEFONO_FIJO_PRESIDENTE_ORGANIZACION))
                            worksheet.Cells[159, columna].Value = datosParticipacion.ENT_TELEFONO_FIJO_PRESIDENTE_ORGANIZACION.ToString();
                        if (!String.IsNullOrEmpty(datosParticipacion.ENT_CORREO_ELECTRONICO_PRESIDENTE_ORGANIZACION))
                            worksheet.Cells[160, columna].Value = datosParticipacion.ENT_CORREO_ELECTRONICO_PRESIDENTE_ORGANIZACION.ToString();

                        worksheet.Cells[161, columna].Value = "No";
                        if (Convert.ToBoolean(datosParticipacion.ENT_ORGANIZACION_COMUNITARIA_PROYECTO_ENTORNO_ESCUELA))
                        {
                            worksheet.Cells[161, columna].Value = "Si";
                        }

                        if (!String.IsNullOrEmpty(datosParticipacion.OTRO_PROYECTO_ENTORNO_ESCUELA))
                            tiposProyectosOtroEscuela = datosParticipacion.OTRO_PROYECTO_ENTORNO_ESCUELA.ToString();
                    } //Hasta aqui participacion

                    InfraestructuraDTO datosInfraestructura = InfraestructuraLogica.ConsultarInfraestructuraPorId(escuelaId);
                    if (datosInfraestructura != null)
                    {
                        if (!String.IsNullOrEmpty(datosInfraestructura.ENT_SEDE_LUGAR))
                            worksheet.Cells[92, columna].Value = datosInfraestructura.ENT_SEDE_LUGAR.ToString();
                        worksheet.Cells[94, columna].Value = "No";
                        if (Convert.ToBoolean(datosInfraestructura.ENT_SEDE_ASIGNADA_SOPORTE_ESCRITO))
                        {
                            worksheet.Cells[94, columna].Value = "Si";
                        }

                        worksheet.Cells[97, columna].Value = datosInfraestructura.ENT_CANTIDAD_SILLAS.ToString();
                        worksheet.Cells[98, columna].Value = datosInfraestructura.ENT_CANTIDAD_ATRILES.ToString();
                        worksheet.Cells[99, columna].Value = datosInfraestructura.ENT_CANTIDAD_TABLEROS.ToString();
                        worksheet.Cells[100, columna].Value = datosInfraestructura.ENT_CANTIDAD_ESTANTERIA.ToString();

                        worksheet.Cells[102, columna].Value = "No";
                        if (Convert.ToBoolean(datosInfraestructura.ENT_SEDE_ADEC_ACUSTIC))
                        {
                            worksheet.Cells[102, columna].Value = "Si";
                        }
                        worksheet.Cells[104, columna].Value = datosInfraestructura.ENT_SEDE_PORCENTAJE_ADEC_ACUSTIC.ToString();

                        worksheet.Cells[109, columna].Value = datosInfraestructura.ENT_CANTIDAD_INSTR_CUERDAS_PULSADAS.ToString();
                        worksheet.Cells[110, columna].Value = datosInfraestructura.ENT_CANTIDAD_INSTR_CUERDAS_SINFONICAS.ToString();
                        worksheet.Cells[111, columna].Value = datosInfraestructura.ENT_CANTIDAD_INSTR_VIENTOS_MADERAS.ToString();
                        worksheet.Cells[112, columna].Value = datosInfraestructura.ENT_CANTIDAD_INSTR_VIENTOS_METALES.ToString();
                        worksheet.Cells[113, columna].Value = datosInfraestructura.ENT_CANTIDAD_INSTR_PERCUSION_MENOR.ToString();
                        worksheet.Cells[114, columna].Value = datosInfraestructura.ENT_CANTIDAD_INSTR_PERCUSION_SINFONICA.ToString();
                        worksheet.Cells[115, columna].Value = datosInfraestructura.ENT_CANTIDAD_INSTR_OTROS.ToString();
                        worksheet.Cells[116, columna].Value = datosInfraestructura.ENT_CANTIDAD_INSTR_TOTAL.ToString();

                        worksheet.Cells[120, columna].Value = "No";
                        if (Convert.ToBoolean(datosInfraestructura.ENT_MATERIAL_PEDAGOGICO))
                        {
                            worksheet.Cells[120, columna].Value = "Si";
                        }

                        var adecuadaAcusticamenteOtroSoluciones = string.Empty;
                        worksheet.Cells[121, columna].Value = datosInfraestructura.ENT_CANTIDAD_TITULOS_BIBLIOGRAFICOS.ToString();
                        if (!String.IsNullOrEmpty(datosInfraestructura.ENT_SEDE_OTRA_SOLUCION_ADEC_ACUSTIC))
                            adecuadaAcusticamenteOtroSoluciones = datosInfraestructura.ENT_SEDE_OTRA_SOLUCION_ADEC_ACUSTIC.ToString();
                        worksheet.Cells[105, columna].Value = "No";
                        if (!String.IsNullOrEmpty(datosInfraestructura.ENT_SINOACCESO_INTERNET))
                        {
                            if (datosInfraestructura.ENT_SINOACCESO_INTERNET.ToString().ToUpper() == "S")
                            {
                                worksheet.Cells[105, columna].Value = "Si";
                            }
                        }
                        else
                            worksheet.Cells[105, columna].Value = "No";

                        decimal EspacioId = datosInfraestructura.ENT_ESPACIO;
                        string strEspacio = "";
                        //OJO Nombre espacio

                        if (EspacioId > 0)
                            strEspacio = ParametrosLogica.ConsultarNombreEspacio(EspacioId);

                        worksheet.Cells[93, columna].Value = strEspacio;

                        List<string> fuentesLista = new List<string>();

                        List<EstandarDTO> listfuentesdotacion = ParametrosLogica.ConsultarFuentesDotacionSeleccionada(escuelaId);
                        if (listfuentesdotacion.Count > 0)
                        {
                            foreach (var item in listfuentesdotacion)
                            {
                                worksheet.Cells[118, columna].Value = worksheet.Cells[118, columna].Value == null ? item.Nombre.Trim() : string.Format("{0}, {1}", worksheet.Cells[118, columna].Value, item.Nombre.Trim());
                            }
                        }
                        List<EstandarDTO> listNivelesfuentesdotacion = ParametrosLogica.ConsultarTiposFuentesDotacionSeleccionada(escuelaId);
                        if (listNivelesfuentesdotacion.Count > 0)
                        {
                            foreach (var item in listNivelesfuentesdotacion)
                            {
                                worksheet.Cells[119, columna].Value = worksheet.Cells[119, columna].Value == null ? item.Nombre.Trim() : string.Format("{0}, {1}", worksheet.Cells[119, columna].Value, item.Nombre.Trim());
                            }
                        }

                        List<EstandarDTO> listMaterial = ParametrosLogica.ConsultarMaterialPedagogicoSeleccionada(escuelaId);
                        if (listMaterial.Count > 0)
                        {
                            foreach (var item in listMaterial)
                            {
                                worksheet.Cells[122, columna].Value = worksheet.Cells[122, columna].Value == null ? item.Nombre.Trim() : string.Format("{0}, {1}", worksheet.Cells[122, columna].Value, item.Nombre.Trim());
                            }
                        }

                        List<EstandarDTO> listSoluciones = ParametrosLogica.ConsultarSolucionesAcusticasSeleccionada(escuelaId);
                        if (listSoluciones.Count > 0)
                        {
                            foreach (var item in listSoluciones)
                            {
                                worksheet.Cells[103, columna].Value = worksheet.Cells[103, columna].Value == null ? item.Nombre.Trim() : string.Format("{0}, {1}", worksheet.Cells[103, columna].Value, item.Nombre.Trim());
                            }
                        }

                        List<EstandarDTO> listProyectos = ParametrosLogica.ConsultarProyectosParticipacionSeleccionada(escuelaId);
                        if (listProyectos.Count > 0)
                        {
                            foreach (var item in listProyectos)
                            {
                                worksheet.Cells[162, columna].Value = worksheet.Cells[162, columna].Value == null ? item.Nombre.Trim() : string.Format("{0}, {1}", worksheet.Cells[162, columna].Value, item.Nombre.Trim());
                            }
                        }

                    } // End datos infraestructura

                    //INICIO PRODUCCION

                    ProduccionDTO datosProduccion = ProduccionLogica.ConsultarProduccionPorId(escuelaId);
                    if (datosProduccion != null)
                    {
                        worksheet.Cells[166, columna].Value = datosProduccion.ENT_CANTIDAD_GIRAS_ULTIMO_ANIO.ToString();
                        worksheet.Cells[167, columna].Value = datosProduccion.ENT_CANTIDAD_GIRAS_INTER_ULTIMO_ANIO.ToString();
                        worksheet.Cells[168, columna].Value = datosProduccion.ENT_CANTIDAD_PRESENTACIONES_LOCALIDAD_ULTIMO_ANIO.ToString();
                        worksheet.Cells[170, columna].Value = datosProduccion.ENT_CANTIDAD_DISCOS_ULTIMO_ANIO.ToString();
                        worksheet.Cells[171, columna].Value = datosProduccion.ENT_CANTIDAD_REPERTORIOS_ULTIMO_ANIO.ToString();
                        worksheet.Cells[172, columna].Value = datosProduccion.ENT_CANTIDAD_MATERIAL_DIVULGATIVO_ULTIMO_ANIO.ToString();
                        worksheet.Cells[173, columna].Value = datosProduccion.ENT_CANTIDAD_MATERIAL_APOYO_ULTIMO_ANIO.ToString();
                        worksheet.Cells[174, columna].Value = datosProduccion.ENT_CANTIDAD_AGRUPACIONES_CONFORMADAS_VIGENTES.ToString();
                    }
                    // END PRODUCCION

                    //iNICIA DATOS FORMACION
                    FormacionDTO datosFormacion = FormacionLogica.ConsultarFormacionPorId(escuelaId);
                    if (datosFormacion != null)
                    {


                        if (!String.IsNullOrEmpty(datosFormacion.ENT_PROCESOS_FORMACION))
                            worksheet.Cells[177, columna].Value = datosFormacion.ENT_PROCESOS_FORMACION.ToString();
                        worksheet.Cells[178, columna].Value = "No";
                        if (Convert.ToBoolean(datosFormacion.ENT_PRACTICAS_MUSICALES_ORIENTADAS_MUSICO))
                        {
                            worksheet.Cells[178, columna].Value = "Si";
                        }

                        worksheet.Cells[179, columna].Value = "No";
                        if (Convert.ToBoolean(datosFormacion.ENT_TALLERES_INDEPENDIENTES))
                        {
                            worksheet.Cells[179, columna].Value = "Si";
                        }

                        worksheet.Cells[180, columna].Value = "No";
                        if (Convert.ToBoolean(datosFormacion.ENT_PROGRAMAS_FORMULADOS_ESCRITO))
                        {
                            worksheet.Cells[180, columna].Value = "Si";
                        }




                    }

                    //Inicia practicas musicales
                    //Practicas musiclaes formación
                    var listadoPractica = new List<PracticaHomeModelDTO>();
                    listadoPractica = EscuelasLogica.ConsultarPracticaPorEscuelaHome((int)escuelaId);
                    int i = 183;
                    if (listadoPractica != null)
                    {
                        if (listadoPractica.Count > 0)
                        {
                            foreach (var practica in listadoPractica)
                            {
                                worksheet.Cells[i, columna - 1].Value = practica.Nombre;
                                if ((practica.listadoGeneros != null) && ((practica.listadoGeneros.Count > 0)))
                                {
                                    i++;
                                    worksheet.Cells[i, columna - 1].Value = "GÉNEROS MUSICALES";
                                    i++;
                                    foreach (var genero in practica.listadoGeneros)
                                    {
                                        worksheet.Cells[i, columna - 1].Value = genero.Nombre;
                                        i++;
                                    }

                                }

                                if ((practica.listadoNiveles != null) && ((practica.listadoNiveles.Count > 0)))
                                {
                                    i++;
                                    worksheet.Cells[i, columna - 1].Value = "EDUCACIÓN POR NIVELES";
                                    //worksheet.Cells[i, columna - 1].Style.Fill.BackgroundColor.SetColor(Color.Black);
                                    i++;
                                    worksheet.Cells[i, columna].Value = "Grupo";
                                    worksheet.Cells[i, columna + 1].Value = "Integrantes";
                                    worksheet.Cells[i, columna + 2].Value = "Horas/Semanal";
                                    i++;
                                    foreach (var nivel in practica.listadoNiveles)
                                    {
                                        worksheet.Cells[i, columna - 1].Value = nivel.NombreNiveles;
                                        worksheet.Cells[i, columna].Value = nivel.Cantidadgrupos;
                                        worksheet.Cells[i, columna + 1].Value = nivel.CantidadIntegrantes;
                                        worksheet.Cells[i, columna + 2].Value = nivel.HoraSemanal;
                                        i++;
                                    }

                                }

                                i++;
                            }
                        }


                        //ENd practicas musicales
                        //END DATOS FORMACIÓN

                        //Inicio Ficha Asesoria
                        i++;
                        worksheet.Cells[i, columna - 1, i, columna].Merge = true;
                        worksheet.Cells[i, columna - 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        worksheet.Cells[i, columna - 1].Style.Fill.BackgroundColor.SetColor(Color.Black);
                        worksheet.Cells[i, columna - 1].Style.Font.Color.SetColor(Color.White);
                        worksheet.Cells[i, columna - 1].Style.Font.SetFromFont("Arial", 12, true, false, false, false);
                        worksheet.Cells[i, columna - 1].Value = "FICHA DE ASESORIA";
                        AsesoriaNuevoDTO asesoria = AsesoriaNeg.ConsultarPorEscuelaId(escuelaId);
                        if (asesoria != null)
                        {

                            i++;
                            worksheet.Cells[i, columna - 1].Value = "Práctica colectiva a la que pertenece";

                            if (!String.IsNullOrEmpty(asesoria.PracticaColectiva))
                            {
                                worksheet.Cells[i, columna].Value = asesoria.PracticaColectiva;

                            }
                            i++;
                            worksheet.Cells[i, columna - 1].Value = "Nombre de la agrupación";

                            if (!String.IsNullOrEmpty(asesoria.NombreAgrupacion))
                            {
                                worksheet.Cells[i, columna].Value = asesoria.NombreAgrupacion;

                            }
                            i++;

                            worksheet.Cells[i, columna - 1].Value = " Nombre del director de la agrupación";

                            if (!String.IsNullOrEmpty(asesoria.NombreDirector))
                            {
                                worksheet.Cells[i, columna].Value = asesoria.NombreDirector;

                            }
                            i++;

                            worksheet.Cells[i, columna - 1].Value = " Año de conformación";

                            if (!String.IsNullOrEmpty(asesoria.AnoValue))
                            {

                                worksheet.Cells[i, columna].Value = asesoria.AnoValue;

                            }
                            i++;

                            worksheet.Cells[i, columna - 1].Value = " Promedio anual de presentaciones públicas";

                            if (!String.IsNullOrEmpty(asesoria.PromedioAnualPresentaciones))
                            {
                                worksheet.Cells[i, columna].Value = asesoria.PromedioAnualPresentaciones;

                            }
                            i++;
                            worksheet.Cells[i, columna - 1].Value = "Promedio mes de presentaciones";

                            if (!String.IsNullOrEmpty(asesoria.PromedioMesesPresentaciones))
                            {
                                worksheet.Cells[i, columna].Value = asesoria.PromedioMesesPresentaciones;

                            }
                            i++;
                            worksheet.Cells[i, columna - 1].Value = "Nivel Desarrollo - Avanzado(grado 4 en adelante)";

                            if (!String.IsNullOrEmpty(asesoria.Avanzado))
                            {
                                worksheet.Cells[i, columna].Value = asesoria.Avanzado;

                            }
                            i++;
                            worksheet.Cells[i, columna - 1].Value = "Nivel Desarrollo - Medio(grado 2 a 4)";

                            if (!String.IsNullOrEmpty(asesoria.Medio))
                            {
                                worksheet.Cells[i, columna].Value = asesoria.Medio;

                            }
                            i++;
                            worksheet.Cells[i, columna - 1].Value = "Nivel Desarrollo - Básico(en badas grado 0 a 2)";

                            if (!String.IsNullOrEmpty(asesoria.Basico))
                            {

                                worksheet.Cells[i, columna].Value = asesoria.Basico;

                            }
                            i++;

                        }

                        AsesoriaConceptoDTO concepto = AsesoriaNeg.ConsultarConceptoPorEscuelaId(escuelaId);
                        if (concepto != null)
                        {
                            worksheet.Cells[i, columna - 1].Value = "Aspecto asesorado";

                            if (!String.IsNullOrEmpty(concepto.AspectoAsesorado))
                            {
                                worksheet.Cells[i, columna].Value = concepto.AspectoAsesorado;
                            }
                            i++;
                            worksheet.Cells[i, columna - 1].Value = "Concepto";

                            if (!String.IsNullOrEmpty(concepto.Concepto))
                            {
                                worksheet.Cells[i, columna].Value = concepto.Concepto;
                            }
                            i++;

                            worksheet.Cells[i, columna - 1].Value = "Mecanismo";

                            if (!String.IsNullOrEmpty(concepto.Mecanismo))
                            {
                                worksheet.Cells[i, columna].Value = concepto.Mecanismo;
                            }
                            i++;

                            worksheet.Cells[i, columna - 1].Value = "Recomendacion";

                            if (!String.IsNullOrEmpty(concepto.Recomendacion))
                            {
                                worksheet.Cells[i, columna].Value = concepto.Recomendacion;
                            }
                            i++;

                        }

                        //Instrumentos
                        var instrumentos = new List<InstrumentoNuevoDTO>();
                        instrumentos = InstrumentoNeg.ConsultarPorEscuelaId(Convert.ToDecimal(escuelaId));
                        if ((instrumentos != null) && (instrumentos.Count > 0))
                        {
                            i++;
                            worksheet.Cells[i, columna - 1, i, columna].Merge = true;
                            worksheet.Cells[i, columna - 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            worksheet.Cells[i, columna - 1].Style.Fill.BackgroundColor.SetColor(Color.Black);
                            worksheet.Cells[i, columna - 1].Style.Font.Color.SetColor(Color.White);
                            worksheet.Cells[i, columna - 1].Style.Font.SetFromFont("Arial", 12, true, false, false, false);
                            worksheet.Cells[i, columna - 1].Value = "INSTRUMENTOS";

                            i++;
                            worksheet.Cells[i, columna - 1].Value = "Instrumento";
                            worksheet.Cells[i, columna].Value = "Cantidad Buenos";
                            worksheet.Cells[i, columna + 1].Value = "Cantidad Regular";
                            worksheet.Cells[i, columna + 2].Value = "Cantidad Malos";
                            worksheet.Cells[i, columna + 3].Value = "Cantidad Perdidos";
                            worksheet.Cells[i, columna + 4].Value = "Cantidad Mincultura";
                            worksheet.Cells[i, columna + 5].Value = "Descripción";
                            i++;
                            foreach (var x in instrumentos)
                            {
                                worksheet.Cells[i, columna - 1].Value = x.Instrumento;
                                worksheet.Cells[i, columna].Value = x.CantidadBuenos;
                                worksheet.Cells[i, columna + 1].Value = x.CantidadRegular;
                                worksheet.Cells[i, columna + 2].Value = x.CantidadMalos;
                                worksheet.Cells[i, columna + 3].Value = x.CantidadPerdidos;
                                worksheet.Cells[i, columna + 4].Value = x.Total;
                                worksheet.Cells[i, columna + 5].Value = x.Descripcion;
                                i++;
                            }

                        }
                        //End instrumentos
                        //Repertorio
                        var repertorio = new List<RepertorioNuevoDTO>();
                        repertorio = RepositorioNeg.ConsultarPorEscuelaId(Convert.ToDecimal(escuelaId));
                        if ((repertorio != null) && (repertorio.Count > 0))
                        {
                            i++;
                            worksheet.Cells[i, columna - 1, i, columna].Merge = true;
                            worksheet.Cells[i, columna - 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            worksheet.Cells[i, columna - 1].Style.Fill.BackgroundColor.SetColor(Color.Black);
                            worksheet.Cells[i, columna - 1].Style.Font.Color.SetColor(Color.White);
                            worksheet.Cells[i, columna - 1].Style.Font.SetFromFont("Arial", 12, true, false, false, false);
                            worksheet.Cells[i, columna - 1].Value = "REPERTORIO MUSICAL";

                            i++;
                            worksheet.Cells[i, columna - 1].Value = "Nombre";
                            worksheet.Cells[i, columna].Value = "Compositor";
                            worksheet.Cells[i, columna + 1].Value = "Arreglista";
                            worksheet.Cells[i, columna + 2].Value = "Grado dificultad";

                            i++;
                            foreach (var x in repertorio)
                            {
                                worksheet.Cells[i, columna - 1].Value = x.Nombre;
                                worksheet.Cells[i, columna].Value = x.Compositor;
                                worksheet.Cells[i, columna + 1].Value = x.Arreglista;
                                worksheet.Cells[i, columna + 2].Value = x.Dificultad;

                                i++;
                            }

                        }
                        //End repertorio

                        // Iniciar clasificacion Tecnica
                        var clasificacion = new List<ClasificacionNuevoDTO>();
                        clasificacion = ClasificacionNeg.ConsultarPorEscuelaId(escuelaId, "Técnica");

                        if ((clasificacion != null) && (clasificacion.Count > 0))
                        {
                            i++;
                            worksheet.Cells[i, columna - 1, i, columna].Merge = true;
                            worksheet.Cells[i, columna - 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            worksheet.Cells[i, columna - 1].Style.Fill.BackgroundColor.SetColor(Color.Black);
                            worksheet.Cells[i, columna - 1].Style.Font.Color.SetColor(Color.White);
                            worksheet.Cells[i, columna - 1].Style.Font.SetFromFont("Arial", 12, true, false, false, false);
                            worksheet.Cells[i, columna - 1].Value = "TÉCNICA";

                            i++;
                            worksheet.Cells[i, columna - 1].Value = "Clasificación";
                            worksheet.Cells[i, columna].Value = "Bueno";
                            worksheet.Cells[i, columna + 1].Value = "Regular";
                            worksheet.Cells[i, columna + 2].Value = "Deficiente";
                            worksheet.Cells[i, columna + 3].Value = "No se realiza";

                            i++;
                            foreach (var x in clasificacion)
                            {
                                worksheet.Cells[i, columna - 1].Value = x.Clasificacion;
                                worksheet.Cells[i, columna].Value = x.Bueno;
                                worksheet.Cells[i, columna + 1].Value = x.REGULAR;
                                worksheet.Cells[i, columna + 2].Value = x.DEFICIENTE;
                                worksheet.Cells[i, columna + 3].Value = x.NOSEREALIZA;

                                i++;
                            }

                        }
                        // end clasificacion

                        // iniciar Observacion tecnica
                        var observacion = new ObservacionNuevoDTO();
                        observacion = ObservacionNeg.ConsultarPorTipo(escuelaId, "Técnica");
                        if ((clasificacion != null) && (clasificacion.Count > 0))
                        {
                            i++;
                            worksheet.Cells[i, columna - 1, i, columna].Merge = true;
                            worksheet.Cells[i, columna - 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            worksheet.Cells[i, columna - 1].Style.Fill.BackgroundColor.SetColor(Color.Black);
                            worksheet.Cells[i, columna - 1].Style.Font.Color.SetColor(Color.White);
                            worksheet.Cells[i, columna - 1].Style.Font.SetFromFont("Arial", 12, true, false, false, false);
                            worksheet.Cells[i, columna - 1].Value = "OBSERVACIONES Y RECOMENDACIONES TÉCNICA";
                            i++;
                            worksheet.Cells[i, columna - 1].Value = "Observaciones";

                            if (!String.IsNullOrEmpty(observacion.Observaciones))
                            {
                                worksheet.Cells[i, columna].Value = observacion.Observaciones;
                            }
                            i++;
                            worksheet.Cells[i, columna - 1].Value = "Recomendaciones";

                            if (!String.IsNullOrEmpty(observacion.Recomendaciones))
                            {
                                worksheet.Cells[i, columna].Value = observacion.Recomendaciones;
                            }
                            i++;
                        }
                        //end observacion

                        // Iniciar clasificacion Tecnica INSTRUMENTAL
                        clasificacion = new List<ClasificacionNuevoDTO>();
                        clasificacion = ClasificacionNeg.ConsultarPorEscuelaId(escuelaId, "TécnicaInstrumental");

                        if ((clasificacion != null) && (clasificacion.Count > 0))
                        {
                            i++;
                            worksheet.Cells[i, columna - 1, i, columna].Merge = true;
                            worksheet.Cells[i, columna - 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            worksheet.Cells[i, columna - 1].Style.Fill.BackgroundColor.SetColor(Color.Black);
                            worksheet.Cells[i, columna - 1].Style.Font.Color.SetColor(Color.White);
                            worksheet.Cells[i, columna - 1].Style.Font.SetFromFont("Arial", 12, true, false, false, false);
                            worksheet.Cells[i, columna - 1].Value = "TÉCNICA INSTRUMENTAL";

                            i++;
                            worksheet.Cells[i, columna - 1].Value = "Clasificación";
                            worksheet.Cells[i, columna].Value = "Bueno";
                            worksheet.Cells[i, columna + 1].Value = "Regular";
                            worksheet.Cells[i, columna + 2].Value = "Deficiente";
                            worksheet.Cells[i, columna + 3].Value = "No se realiza";

                            i++;
                            foreach (var x in clasificacion)
                            {
                                worksheet.Cells[i, columna - 1].Value = x.Clasificacion;
                                worksheet.Cells[i, columna].Value = x.Bueno;
                                worksheet.Cells[i, columna + 1].Value = x.REGULAR;
                                worksheet.Cells[i, columna + 2].Value = x.DEFICIENTE;
                                worksheet.Cells[i, columna + 3].Value = x.NOSEREALIZA;

                                i++;
                            }

                        }

                        // iniciar Observacion TécnicaInstrumental
                        observacion = new ObservacionNuevoDTO();
                        observacion = ObservacionNeg.ConsultarPorTipo(escuelaId, "TécnicaInstrumental");
                        if ((clasificacion != null) && (clasificacion.Count > 0))
                        {
                            i++;
                            worksheet.Cells[i, columna - 1, i, columna].Merge = true;
                            worksheet.Cells[i, columna - 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            worksheet.Cells[i, columna - 1].Style.Fill.BackgroundColor.SetColor(Color.Black);
                            worksheet.Cells[i, columna - 1].Style.Font.Color.SetColor(Color.White);
                            worksheet.Cells[i, columna - 1].Style.Font.SetFromFont("Arial", 12, true, false, false, false);
                            worksheet.Cells[i, columna - 1].Value = "OBSERVACIONES Y RECOMENDACIONES TÉCNICA INSTRUMENTAL";
                            i++;
                            worksheet.Cells[i, columna - 1].Value = "Observaciones";

                            if (!String.IsNullOrEmpty(observacion.Observaciones))
                            {
                                worksheet.Cells[i, columna].Value = observacion.Observaciones;
                            }
                            i++;
                            worksheet.Cells[i, columna - 1].Value = "Recomendaciones";

                            if (!String.IsNullOrEmpty(observacion.Recomendaciones))
                            {
                                worksheet.Cells[i, columna].Value = observacion.Recomendaciones;
                            }
                            i++;
                        }
                        //end observacion

                        // end clasificacion TECNICA INSTRUMENTAL

                        // Iniciar clasificacion EvaluaciónDelRepertorio
                        clasificacion = new List<ClasificacionNuevoDTO>();
                        clasificacion = ClasificacionNeg.ConsultarPorEscuelaId(escuelaId, "EvaluaciónDelRepertorio");

                        if ((clasificacion != null) && (clasificacion.Count > 0))
                        {
                            i++;
                            worksheet.Cells[i, columna - 1, i, columna].Merge = true;
                            worksheet.Cells[i, columna - 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            worksheet.Cells[i, columna - 1].Style.Fill.BackgroundColor.SetColor(Color.Black);
                            worksheet.Cells[i, columna - 1].Style.Font.Color.SetColor(Color.White);
                            worksheet.Cells[i, columna - 1].Style.Font.SetFromFont("Arial", 12, true, false, false, false);
                            worksheet.Cells[i, columna - 1].Value = "EVALUACIÓN DEL REPERTORIO";

                            i++;
                            worksheet.Cells[i, columna - 1].Value = "Clasificación";
                            worksheet.Cells[i, columna].Value = "Bueno";
                            worksheet.Cells[i, columna + 1].Value = "Regular";
                            worksheet.Cells[i, columna + 2].Value = "Deficiente";
                            worksheet.Cells[i, columna + 3].Value = "No se realiza";

                            i++;
                            foreach (var x in clasificacion)
                            {
                                worksheet.Cells[i, columna - 1].Value = x.Clasificacion;
                                worksheet.Cells[i, columna].Value = x.Bueno;
                                worksheet.Cells[i, columna + 1].Value = x.REGULAR;
                                worksheet.Cells[i, columna + 2].Value = x.DEFICIENTE;
                                worksheet.Cells[i, columna + 3].Value = x.NOSEREALIZA;

                                i++;
                            }

                        }

                        // iniciar Observacion TécnicaInstrumental
                        observacion = new ObservacionNuevoDTO();
                        observacion = ObservacionNeg.ConsultarPorTipo(escuelaId, "TécnicaInstrumental");
                        if ((clasificacion != null) && (clasificacion.Count > 0))
                        {
                            i++;
                            worksheet.Cells[i, columna - 1, i, columna].Merge = true;
                            worksheet.Cells[i, columna - 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            worksheet.Cells[i, columna - 1].Style.Fill.BackgroundColor.SetColor(Color.Black);
                            worksheet.Cells[i, columna - 1].Style.Font.Color.SetColor(Color.White);
                            worksheet.Cells[i, columna - 1].Style.Font.SetFromFont("Arial", 12, true, false, false, false);
                            worksheet.Cells[i, columna - 1].Value = "OBSERVACIONES Y RECOMENDACIONES EVALUACIÓN DEL REPERTORIO";
                            i++;
                            worksheet.Cells[i, columna - 1].Value = "Observaciones";

                            if (!String.IsNullOrEmpty(observacion.Observaciones))
                            {
                                worksheet.Cells[i, columna].Value = observacion.Observaciones;
                            }
                            i++;
                            worksheet.Cells[i, columna - 1].Value = "Recomendaciones";

                            if (!String.IsNullOrEmpty(observacion.Recomendaciones))
                            {
                                worksheet.Cells[i, columna].Value = observacion.Recomendaciones;
                            }
                            i++;
                        }
                        //end observacion
                        // end clasificacion EvaluaciónDelRepertorio

                        // Iniciar clasificacion ComunicaciónYLiderazgo
                        clasificacion = new List<ClasificacionNuevoDTO>();
                        clasificacion = ClasificacionNeg.ConsultarPorEscuelaId(escuelaId, "ComunicaciónYLiderazgo");

                        if ((clasificacion != null) && (clasificacion.Count > 0))
                        {
                            i++;
                            worksheet.Cells[i, columna - 1, i, columna].Merge = true;
                            worksheet.Cells[i, columna - 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            worksheet.Cells[i, columna - 1].Style.Fill.BackgroundColor.SetColor(Color.Black);
                            worksheet.Cells[i, columna - 1].Style.Font.Color.SetColor(Color.White);
                            worksheet.Cells[i, columna - 1].Style.Font.SetFromFont("Arial", 12, true, false, false, false);
                            worksheet.Cells[i, columna - 1].Value = "COMUNICACIÓN Y LIDERAZGO";

                            i++;
                            worksheet.Cells[i, columna - 1].Value = "Clasificación";
                            worksheet.Cells[i, columna].Value = "Bueno";
                            worksheet.Cells[i, columna + 1].Value = "Regular";
                            worksheet.Cells[i, columna + 2].Value = "Deficiente";
                            worksheet.Cells[i, columna + 3].Value = "No se realiza";

                            i++;
                            foreach (var x in clasificacion)
                            {
                                worksheet.Cells[i, columna - 1].Value = x.Clasificacion;
                                worksheet.Cells[i, columna].Value = x.Bueno;
                                worksheet.Cells[i, columna + 1].Value = x.REGULAR;
                                worksheet.Cells[i, columna + 2].Value = x.DEFICIENTE;
                                worksheet.Cells[i, columna + 3].Value = x.NOSEREALIZA;

                                i++;
                            }

                            // iniciar Observacion ComunicaciónYLiderazgo
                            observacion = new ObservacionNuevoDTO();
                            observacion = ObservacionNeg.ConsultarPorTipo(escuelaId, "ComunicaciónYLiderazgo");
                            if ((clasificacion != null) && (clasificacion.Count > 0))
                            {
                                i++;
                                worksheet.Cells[i, columna - 1, i, columna].Merge = true;
                                worksheet.Cells[i, columna - 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                worksheet.Cells[i, columna - 1].Style.Fill.BackgroundColor.SetColor(Color.Black);
                                worksheet.Cells[i, columna - 1].Style.Font.Color.SetColor(Color.White);
                                worksheet.Cells[i, columna - 1].Style.Font.SetFromFont("Arial", 12, true, false, false, false);
                                worksheet.Cells[i, columna - 1].Value = "OBSERVACIONES Y RECOMENDACIONES COMUNICACIÓN Y LIDERAZGO";
                                i++;
                                worksheet.Cells[i, columna - 1].Value = "Observaciones";

                                if (!String.IsNullOrEmpty(observacion.Observaciones))
                                {
                                    worksheet.Cells[i, columna].Value = observacion.Observaciones;
                                }
                                i++;
                                worksheet.Cells[i, columna - 1].Value = "Recomendaciones";

                                if (!String.IsNullOrEmpty(observacion.Recomendaciones))
                                {
                                    worksheet.Cells[i, columna].Value = observacion.Recomendaciones;
                                }
                                i++;
                            }
                            //end observacion ComunicaciónYLiderazgo
                        }
                        // end clasificacion ComunicaciónYLiderazgo

                        // Iniciar clasificacion ObservaciónDelDesempeñoDelDocente
                        var matriz = new List<MatrizNuevoDTO>();
                        matriz = MatrizNeg.ConsultarPorEscuelaId(escuelaId, "ObservaciónDelDesempeñoDelDocente");

                        if ((matriz != null) && (matriz.Count > 0))
                        {
                            i++;
                            worksheet.Cells[i, columna - 1, i, columna].Merge = true;
                            worksheet.Cells[i, columna - 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            worksheet.Cells[i, columna - 1].Style.Fill.BackgroundColor.SetColor(Color.Black);
                            worksheet.Cells[i, columna - 1].Style.Font.Color.SetColor(Color.White);
                            worksheet.Cells[i, columna - 1].Style.Font.SetFromFont("Arial", 12, true, false, false, false);
                            worksheet.Cells[i, columna - 1].Value = "OBSERVACIÓN DEL DESEMPEÑO DEL DOCENTE";

                            i++;
                            worksheet.Cells[i, columna - 1].Value = "Clasificación";
                            worksheet.Cells[i, columna].Value = "Fortaleza";
                            worksheet.Cells[i, columna + 1].Value = "Dificultades";


                            i++;
                            foreach (var x in matriz)
                            {
                                worksheet.Cells[i, columna - 1].Value = x.Clasificacion;
                                worksheet.Cells[i, columna].Value = x.Fortaleza;
                                worksheet.Cells[i, columna + 1].Value = x.Dificultades;


                                i++;
                            }

                        }
                        // iniciar Observacion ObservaciónDelDesempeñoDelDocente
                        observacion = new ObservacionNuevoDTO();
                        observacion = ObservacionNeg.ConsultarPorTipo(escuelaId, "ObservaciónDelDesempeñoDelDocente");
                        if ((clasificacion != null) && (clasificacion.Count > 0))
                        {
                            i++;
                            worksheet.Cells[i, columna - 1, i, columna].Merge = true;
                            worksheet.Cells[i, columna - 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            worksheet.Cells[i, columna - 1].Style.Fill.BackgroundColor.SetColor(Color.Black);
                            worksheet.Cells[i, columna - 1].Style.Font.Color.SetColor(Color.White);
                            worksheet.Cells[i, columna - 1].Style.Font.SetFromFont("Arial", 12, true, false, false, false);
                            worksheet.Cells[i, columna - 1].Value = "OBSERVACIONES Y RECOMENDACIONES  DEL DESEMPEÑO DEL DOCENTE";
                            i++;
                            worksheet.Cells[i, columna - 1].Value = "Observaciones";

                            if (!String.IsNullOrEmpty(observacion.Observaciones))
                            {
                                worksheet.Cells[i, columna].Value = observacion.Observaciones;
                            }
                            i++;
                            worksheet.Cells[i, columna - 1].Value = "Recomendaciones";

                            if (!String.IsNullOrEmpty(observacion.Recomendaciones))
                            {
                                worksheet.Cells[i, columna].Value = observacion.Recomendaciones;
                            }
                            i++;
                        }
                        //end observacion ObservaciónDelDesempeñoDelDocente
                        // end clasificacion ObservaciónDelDesempeñoDelDocente

                        // Iniciar clasificacion PercepciónDelProcesoMusical
                        matriz = new List<MatrizNuevoDTO>();
                        matriz = MatrizNeg.ConsultarPorEscuelaId(escuelaId, "PercepciónDelProcesoMusical");

                        if ((matriz != null) && (matriz.Count > 0))
                        {
                            i++;
                            worksheet.Cells[i, columna - 1, i, columna].Merge = true;
                            worksheet.Cells[i, columna - 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            worksheet.Cells[i, columna - 1].Style.Fill.BackgroundColor.SetColor(Color.Black);
                            worksheet.Cells[i, columna - 1].Style.Font.Color.SetColor(Color.White);
                            worksheet.Cells[i, columna - 1].Style.Font.SetFromFont("Arial", 12, true, false, false, false);
                            worksheet.Cells[i, columna - 1].Value = "PERCEPCIÓN DEL PROCESO MUSICAL";

                            i++;
                            worksheet.Cells[i, columna - 1].Value = "Clasificación";
                            worksheet.Cells[i, columna].Value = "Fortaleza";
                            worksheet.Cells[i, columna + 1].Value = "Dificultades";


                            i++;
                            foreach (var x in matriz)
                            {
                                worksheet.Cells[i, columna - 1].Value = x.Clasificacion;
                                worksheet.Cells[i, columna].Value = x.Fortaleza;
                                worksheet.Cells[i, columna + 1].Value = x.Dificultades;


                                i++;
                            }

                        }
                        // iniciar Observacion PercepciónDelProcesoMusical
                        observacion = new ObservacionNuevoDTO();
                        observacion = ObservacionNeg.ConsultarPorTipo(escuelaId, "PercepciónDelProcesoMusical");
                        if ((clasificacion != null) && (clasificacion.Count > 0))
                        {
                            i++;
                            worksheet.Cells[i, columna - 1, i, columna].Merge = true;
                            worksheet.Cells[i, columna - 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            worksheet.Cells[i, columna - 1].Style.Fill.BackgroundColor.SetColor(Color.Black);
                            worksheet.Cells[i, columna - 1].Style.Font.Color.SetColor(Color.White);
                            worksheet.Cells[i, columna - 1].Style.Font.SetFromFont("Arial", 12, true, false, false, false);
                            worksheet.Cells[i, columna - 1].Value = "OBSERVACIONES Y RECOMENDACIONES PERCEPCIÓN DEL PROCESO MUSICAL";
                            i++;
                            worksheet.Cells[i, columna - 1].Value = "Observaciones";

                            if (!String.IsNullOrEmpty(observacion.Observaciones))
                            {
                                worksheet.Cells[i, columna].Value = observacion.Observaciones;
                            }
                            i++;
                            worksheet.Cells[i, columna - 1].Value = "Recomendaciones";

                            if (!String.IsNullOrEmpty(observacion.Recomendaciones))
                            {
                                worksheet.Cells[i, columna].Value = observacion.Recomendaciones;
                            }
                            i++;
                        }
                        //end observacion PercepciónDelProcesoMusical
                        // end clasificacion PercepciónDelProcesoMusical
                        //End ficha asesoria

                        // Formularios dinámicos

                        //List<FormularioDTO> listFormularios = FormulariosLogica.ConsultarFormulariosActivos();
                        int fila = i++;
                        //if (listFormularios.Count > 0)
                        //{
                        //    foreach (var item in listFormularios)
                        //    {
                        //        worksheet.Cells[fila, columna - 1, fila, columna].Merge = true;
                        //        //worksheet.Cells[fila, columna - 1].StyleID = worksheet.Cells[227, columna].StyleID;
                        //        worksheet.Cells[fila, columna - 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        //        worksheet.Cells[fila, columna - 1].Style.Fill.BackgroundColor.SetColor(Color.Black);
                        //        worksheet.Cells[fila, columna - 1].Style.Font.Color.SetColor(Color.White);
                        //        worksheet.Cells[fila, columna - 1].Style.Font.SetFromFont(new Font("Arial", 12, FontStyle.Bold));
                        //        worksheet.Cells[fila, columna - 1].Value = item.Nombre.ToString().ToUpper();
                        //        fila++;
                        //        List<FormularioValoresDTO> listFormulariosValores = FormulariosLogica.ConsultarValores(escuelaId, item.ForID);

                        //        if (listFormulariosValores.Count > 0)
                        //        {
                        //            foreach (var dato in listFormulariosValores)
                        //            {
                        //                worksheet.Cells[fila, columna - 1].Style.Font.SetFromFont(new Font("Arial", 10, FontStyle.Regular));
                        //                worksheet.Cells[fila, columna].Style.Font.SetFromFont(new Font("Arial", 10, FontStyle.Regular));
                        //                worksheet.Cells[fila, columna - 1].Value = dato.FCO_NOMBRE.ToString();
                        //                worksheet.Cells[fila, columna].Value = dato.FVA_VALOR.ToString();
                        //                fila++;
                        //            }
                        //        }

                        //        fila++;
                        //    }
                        //}
                        // end formularios dinamicos


                    }
                    return xlPackage.GetAsByteArray();
                }

            }
            catch (Exception ex)
            {
                throw ex;

            }

            //  return null;
        }


        public static byte[] ObtenerActaDotacion(int CronogramaId, out string nombreArchivo)
        {
            nombreArchivo = string.Empty;
            var listado = new List<DotacionDTO>();
            string NombreDepto = string.Empty;
            int total = 0;
            int totalInstrumento = 0;
            int totalOtros = 0;
            decimal valortotal = 0;

            try
            {
                nombreArchivo = "ActaDotacion.xlsx";

                var rutaPlantilla = HttpContext.Current.Server.MapPath("~/Reportes/plantilladotacioninstrumentos.xlsx");
                var rutaArchivo = HttpContext.Current.Server.MapPath("~/Reportes/DotacionInstrumento.xlsx");

                FileInfo template = new FileInfo(rutaPlantilla);
                FileInfo newFile = new FileInfo(rutaArchivo);

                using (ExcelPackage xlPackage = new ExcelPackage(newFile, template))
                {
                    ExcelWorksheet worksheet = xlPackage.Workbook.Worksheets[1];
                    const int columna = 2;

                    CronogramaDTO datos = CronogramaNeg.ConsultarPorId(CronogramaId);

                    if (datos != null)
                    {
                        if (!String.IsNullOrEmpty(datos.Departamento))
                        {
                            worksheet.Cells[8, 2].Value = string.Format("{0}", datos.Departamento);
                            NombreDepto = datos.Departamento + " - ";
                            worksheet.Cells[8, 8].Value = DateTime.Today.ToShortDateString();
                        }
                        if (!String.IsNullOrEmpty(datos.Municipio))
                        {
                            worksheet.Cells[9, 2].Value = string.Format("{0}", datos.Municipio);
                            NombreDepto = NombreDepto + datos.Municipio;
                        }
                        if (!String.IsNullOrEmpty(datos.Escuela))
                            worksheet.Cells[10, 2].Value = string.Format("{0}", datos.Escuela);
                    }


                    listado = SM.Aplicacion.EntidadesOpeadoras.DotacionConvenioNeg.ConsultarPorCronogramaId(CronogramaId);

                    int i = 15;

                    if (listado != null)
                    {
                        if (listado.Count > 0)
                        {
                            total = listado.Count;
                            worksheet.InsertRow(15, total);
                            foreach (var item in listado)
                            {
                                worksheet.Cells[i, columna - 1].Value = "1";
                                worksheet.Cells[i, columna].Value = item.Tipo;
                                worksheet.Cells[i, columna + 1].Value = item.Elemento;
                                worksheet.Cells[i, columna + 2].Value = item.Formato;
                                worksheet.Cells[i, columna + 3].Value = item.Proveedor;
                                worksheet.Cells[i, columna + 4].Value = item.Marca;
                                worksheet.Cells[i, columna + 5].Value = item.Referencia;
                                worksheet.Cells[i, columna + 6].Value = item.Serial;
                                worksheet.Cells[i, columna + 7].Value = item.Precio;
                                worksheet.Cells[i, columna + 8].Value = item.Precio;
                                worksheet.Cells[i, columna + 9].Value = item.Garantia;
                                valortotal = valortotal + item.Precio;
                                if (item.TipoId == "218")
                                    totalInstrumento++;
                                else
                                    totalOtros++;
                                i++;




                            }
                        }
                    }


                    i = i + 1;
                    worksheet.Cells[i, columna].Value = total.ToString();
                    i++;
                    worksheet.Cells[i, columna].Value = totalInstrumento.ToString();
                    i++;
                    worksheet.Cells[i, columna].Value = string.Format("{0}", totalOtros.ToString());
                    i++;
                    worksheet.Cells[i, columna].Value = string.Format("{0}", valortotal.ToString());
                    i = i + 8;
                    worksheet.Cells[i, columna].Value = string.Format("{0}", NombreDepto);
                    return xlPackage.GetAsByteArray();
                }



            }
            catch (Exception ex)
            {
                throw ex;

            }

            //  return null;
        }

        public static byte[] ObtenerParticipantePorCronograma(int CronogramaId, out string nombreArchivo)
        {
            nombreArchivo = string.Empty;

            var listado = new List<AsistenciaDTO>();
            string NombreDepto = string.Empty;
            // int totalInstrumento = 0; // Removed unused variable
            // int totalOtros = 0; // Removed unused variable
            // decimal valortotal = 0; Removed unused variable 'valortotal'
            try
            {
                nombreArchivo = "ParticipantePorCronograma.xlsx";

                var rutaPlantilla = HttpContext.Current.Server.MapPath("~/Reportes/PlantillaParticipantes.xlsx");
                var rutaArchivo = HttpContext.Current.Server.MapPath("~/Reportes/Participante.xlsx");

                FileInfo template = new FileInfo(rutaPlantilla);
                FileInfo newFile = new FileInfo(rutaArchivo);

                using (ExcelPackage xlPackage = new ExcelPackage(newFile, template))
                {
                    ExcelWorksheet worksheet = xlPackage.Workbook.Worksheets[1];
                    const int columna = 2;

                    CronogramaReporteConvenioDTO datos = CronogramaNeg.ConsultarDatosConvenioPorCronogramaId(CronogramaId);

                    if (datos != null)
                    {
                        if (!String.IsNullOrEmpty(datos.Entidad))
                        {
                            worksheet.Cells[3, 2].Value = string.Format("{0}", datos.Entidad);
                        }
                        if (!String.IsNullOrEmpty(datos.Convenio))
                        {
                            worksheet.Cells[4, 2].Value = string.Format("{0}", datos.Convenio);
                        }
                        if (!String.IsNullOrEmpty(datos.Actividad))
                            worksheet.Cells[5, 2].Value = string.Format("{0}", datos.Actividad);

                        if (!String.IsNullOrEmpty(datos.Cronograma))
                            worksheet.Cells[6, 2].Value = string.Format("{0}", datos.Cronograma);

                        if (!String.IsNullOrEmpty(datos.Departamento))
                            worksheet.Cells[7, 2].Value = string.Format("{0}", datos.Departamento);

                        if (!String.IsNullOrEmpty(datos.Municipio))
                            worksheet.Cells[8, 2].Value = string.Format("{0}", datos.Municipio);

                        if (!String.IsNullOrEmpty(datos.FechaInicio))
                            worksheet.Cells[9, 2].Value = string.Format("{0}", datos.FechaInicio);

                        if (!String.IsNullOrEmpty(datos.FechaFin))
                            worksheet.Cells[10, 2].Value = string.Format("{0}", datos.FechaFin);
                    }

                    listado = AsistenciaNeg.ConsultarPorCronograma(CronogramaId);

                    int i = 13;
                    int l = 12;

                    if (listado != null)
                    {
                        if (listado.Count > 0)
                        {
                            var fechas = listado.FirstOrDefault();

                            if (fechas.Dias != null)
                            {
                                int j = 1;
                                foreach (var x in fechas.Dias)
                                {
                                    worksheet.Cells[l, columna + j].Value = x.FechaAsistenciaNueva.ToString("dd/MM/yyyy");
                                    j++;
                                }
                            }

                            foreach (var item in listado)
                            {
                                worksheet.Cells[i, columna - 1].Value = item.Identificacion;
                                worksheet.Cells[i, columna].Value = item.Nombres + " " + item.Apellidos;

                                if (item.Dias != null)
                                {
                                    int j = 1;
                                    foreach (var x in item.Dias)
                                    {
                                        worksheet.Cells[i, columna + j].Value = x.asistio;
                                        j++;
                                    }
                                }
                                i++;
                            }
                        }
                    }

                    return xlPackage.GetAsByteArray();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
    public class documentoCreacion
    {
        public static int CrearDocumento(int UsuarioId, string NombreUsuario, string strIp, HttpPostedFileBase ArchivoAgenda)
        {
            int DocumentoId = 0;

            byte[] data;
            if (ArchivoAgenda != null && ArchivoAgenda.ContentLength > 0)
            {
                using (Stream inputStream = ArchivoAgenda.InputStream)
                {
                    MemoryStream memoryStream = inputStream as MemoryStream;
                    if (memoryStream == null)
                    {
                        memoryStream = new MemoryStream();
                        inputStream.CopyTo(memoryStream);
                    }

                    data = memoryStream.ToArray();
                }

                // Mapea los datos del documento

                var documento = new DocumentoDTO
                {
                    NombreArchivo = ArchivoAgenda.FileName,
                    ExtensionArchivo = Path.GetExtension(ArchivoAgenda.FileName),
                    BytesArchivo = data,
                    TamanoArchivo = data.Length,
                    TipoContenido = ArchivoAgenda.ContentType,
                    FechaRegistro = DateTime.Now,
                    UsuarioId = UsuarioId,
                };

                DocumentoId = SM.Aplicacion.Documentos.DocumentosNeg.Crear(documento, NombreUsuario, strIp, UsuarioId);

            }
            return DocumentoId;

        }



    }

}