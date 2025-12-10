using OfficeOpenXml;
using System;
using System.Data;
using System.IO;
using System.Web;

namespace WebSImus.Comunes
{
    public class Excel
    {
        // La licencia y compatibilidad de EPPlus se configuran en Web.config (appSettings)
        public static MemoryStream CrearReporteGeneral(string nombreReporte, string parametros, DataTable dataTable, out string nombreArchivo)
        {
            // Sanitizar nombreReporte para evitar caracteres inválidos en nombre de archivo
            string nombreSeguro = nombreReporte.Replace(":", "").Replace("/", "").Replace("\\", "").Replace("?", "").Replace("*", "").Replace("\"", "").Replace("<", "").Replace(">", "").Replace("|", "");
            nombreArchivo = string.Format("{0}-{1}.xlsx", nombreSeguro, DateTime.Now.ToString("yyyyMMddHHmmss"));
            FileInfo directorioPlantillas = new FileInfo(string.Format("{0}\\PlantillaGeneralReportes.xlsx", HttpContext.Current.Server.MapPath("~/plantilla/")));
            FileInfo directorioTemporal = new FileInfo(string.Format("{0}\\{1}", HttpContext.Current.Server.MapPath("~/Temp/"), nombreArchivo));

            using (ExcelPackage excelPackage = new ExcelPackage(directorioTemporal, directorioPlantillas))
            {
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[1];

                worksheet.Cells[4, 2].Value = string.Format("{0} - Fecha de generación: {1}", nombreReporte, DateTime.Now);
                worksheet.Name = nombreReporte;
                 worksheet.Cells[6, 2].Value = string.Format("Número de registros: {0}", dataTable.Rows.Count);

                int fila = 8;
                int columna = 1;


                foreach (DataColumn dataColumn in dataTable.Columns)
                {
                    
                    worksheet.Cells[fila, columna].Value = dataColumn.ColumnName;
                    worksheet.Cells[fila, columna].AutoFitColumns(50, 250);

                    columna++;
                }

                fila = 9;

                foreach (DataRow dataRow in dataTable.Rows)
                {
                    columna = 1;
                    for (int i = 0; i < dataTable.Columns.Count; i++)
                    {
                        worksheet.Cells[fila, columna].Value = dataRow[i];
                        worksheet.Cells[fila, columna].AutoFitColumns(50, 250);

                        if (dataRow[i] is decimal)
                            worksheet.Cells[fila, columna].Style.Numberformat.Format = @"#,##0.00";

                        DateTime temp;
                        if (dataRow.Table.Columns[i].ColumnName.Contains("Fecha") && DateTime.TryParse(dataRow[i].ToString(), out temp))
                        {
                            worksheet.Cells[fila, columna].Style.Numberformat.Format = @"dd/MM/yyy hh:mm:ss";
                            worksheet.Cells[fila, columna].Value = temp;
                        }

                        columna++;
                    }

                    fila++;
                }

                var stream = new MemoryStream();
                excelPackage.SaveAs(stream);

                return stream;
            }
        }

        /// <summary>
        /// Reporte detallado de Festivales: Hoja 1 (general versiones) usando estructura similar a CrearReporteGeneral,
        /// Hoja 2 (Entidades Aliadas) si existe DataTable de entidades.
        /// Reutiliza la plantilla general.
        /// </summary>
        public static MemoryStream CrearReporteFestivalesDetallado(string nombreReporte, DataTable dataTableGeneral, DataTable dataTableEntidades, out string nombreArchivo)
        {
            // Sanitizar nombreReporte para evitar caracteres inválidos en nombre de archivo
            string nombreSeguro = nombreReporte.Replace(":", "").Replace("/", "").Replace("\\", "").Replace("?", "").Replace("*", "").Replace("\"", "").Replace("<", "").Replace(">", "").Replace("|", "");
            nombreArchivo = string.Format("{0}-{1}.xlsx", nombreSeguro, DateTime.Now.ToString("yyyyMMddHHmmss"));
            FileInfo directorioPlantillas = new FileInfo(string.Format("{0}\\PlantillaGeneralReportes.xlsx", HttpContext.Current.Server.MapPath("~/plantilla/")));
            FileInfo directorioTemporal = new FileInfo(string.Format("{0}\\{1}", HttpContext.Current.Server.MapPath("~/Temp/"), nombreArchivo));

            using (ExcelPackage excelPackage = new ExcelPackage(directorioTemporal, directorioPlantillas))
            {
                // Hoja 1: General
                ExcelWorksheet wsGeneral = excelPackage.Workbook.Worksheets[1];
                wsGeneral.Cells[4, 2].Value = string.Format("{0} - Fecha de generación: {1}", nombreReporte, DateTime.Now);
                wsGeneral.Name = nombreReporte;
                wsGeneral.Cells[6, 2].Value = string.Format("Número de registros: {0}", dataTableGeneral.Rows.Count);

                int fila = 8; int columna = 1;
                foreach (DataColumn col in dataTableGeneral.Columns)
                {
                    wsGeneral.Cells[fila, columna].Value = col.ColumnName;
                    wsGeneral.Cells[fila, columna].AutoFitColumns(50, 250);
                    columna++;
                }
                fila = 9;
                foreach (DataRow dr in dataTableGeneral.Rows)
                {
                    columna = 1;
                    for (int i = 0; i < dataTableGeneral.Columns.Count; i++)
                    {
                        wsGeneral.Cells[fila, columna].Value = dr[i];
                        wsGeneral.Cells[fila, columna].AutoFitColumns(50, 250);
                        DateTime temp;
                        if (dataTableGeneral.Columns[i].ColumnName.Contains("Fecha") && DateTime.TryParse(dr[i].ToString(), out temp))
                        {
                            wsGeneral.Cells[fila, columna].Style.Numberformat.Format = @"dd/MM/yyy hh:mm:ss";
                            wsGeneral.Cells[fila, columna].Value = temp;
                        }
                        columna++;
                    }
                    fila++;
                }

                // Hoja 2: Entidades Aliadas (solo si hay datos)
                if (dataTableEntidades != null && dataTableEntidades.Rows.Count > 0)
                {
                    var wsEntidades = excelPackage.Workbook.Worksheets.Add("EntidadesAliadas");
                    wsEntidades.Cells[1, 1].Value = "Entidades Aliadas";
                    wsEntidades.Cells[2, 1].Value = string.Format("Fecha de generación: {0}", DateTime.Now);
                    int f2 = 4; int c2 = 1;
                    foreach (DataColumn col in dataTableEntidades.Columns)
                    {
                        wsEntidades.Cells[f2, c2].Value = col.ColumnName;
                        wsEntidades.Cells[f2, c2].AutoFitColumns(50, 250);
                        c2++;
                    }
                    f2 = 5;
                    foreach (DataRow dr in dataTableEntidades.Rows)
                    {
                        c2 = 1;
                        for (int i = 0; i < dataTableEntidades.Columns.Count; i++)
                        {
                            wsEntidades.Cells[f2, c2].Value = dr[i];
                            wsEntidades.Cells[f2, c2].AutoFitColumns(50, 250);
                            c2++;
                        }
                        f2++;
                    }
                }

                var stream = new MemoryStream();
                excelPackage.SaveAs(stream);
                return stream;
            }
        }

        public static MemoryStream CrearReportePorcentajeDepartamentos(string nombreReporte, string parametros, DataTable dataTable, out string nombreArchivo)
        {
            nombreArchivo = string.Format("{0}-{1}.xlsx", nombreReporte, DateTime.Now.ToString("yyyyMMddHHmmss"));
            FileInfo directorioPlantillas = new FileInfo(string.Format("{0}\\PlantillaEventosDepartamento.xlsx", HttpContext.Current.Server.MapPath("~/plantilla/")));
            FileInfo directorioTemporal = new FileInfo(string.Format("{0}\\{1}", HttpContext.Current.Server.MapPath("~/Temp/"), nombreArchivo));

            using (ExcelPackage excelPackage = new ExcelPackage(directorioTemporal, directorioPlantillas))
            {
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[1];

                worksheet.Cells[4, 2].Value = string.Format("{0} - Fecha de generación: {1}", nombreReporte, DateTime.Now);
                worksheet.Name = nombreReporte;
     

                int fila = 7;
                int columna = 1;


                foreach (DataColumn dataColumn in dataTable.Columns)
                {

                    worksheet.Cells[fila, columna].Value = dataColumn.ColumnName;
                    worksheet.Cells[fila, columna].AutoFitColumns(50, 250);

                    columna++;
                }

                fila = 8;

                foreach (DataRow dataRow in dataTable.Rows)
                {
                    columna = 1;
                    for (int i = 0; i < dataTable.Columns.Count; i++)
                    {
                        worksheet.Cells[fila, columna].Value = dataRow[i];
                        worksheet.Cells[fila, columna].AutoFitColumns(50, 250);

                        if (dataRow[i] is decimal)
                            worksheet.Cells[fila, columna].Style.Numberformat.Format = @"#,##0.00";

                        DateTime temp;
                        if (dataRow.Table.Columns[i].ColumnName.Contains("Fecha") && DateTime.TryParse(dataRow[i].ToString(), out temp))
                        {
                            worksheet.Cells[fila, columna].Style.Numberformat.Format = @"dd/MM/yyy hh:mm:ss";
                            worksheet.Cells[fila, columna].Value = temp;
                        }

                        columna++;
                    }

                    fila++;
                }

                var stream = new MemoryStream();
                excelPackage.SaveAs(stream);

                return stream;
            }
        }

        public static MemoryStream CrearEstadisticasEscuelas(string nombreReporte, DataTable dataTable, out string nombreArchivo, 
                                                            string NombreDepto, int porcentaje, int totalMun, int totalMunEscuelas,
                                                            int totalEscuelas, int totalPublica, int TotalPrivadas, int totalMixtas)
        {
            nombreArchivo = string.Format("{0}-{1}.xlsx", nombreReporte, DateTime.Now.ToString("yyyyMMddHHmmss"));
            FileInfo directorioPlantillas = new FileInfo(string.Format("{0}\\PlantillaEscuelasMapas.xlsx", HttpContext.Current.Server.MapPath("~/plantilla/")));
            FileInfo directorioTemporal = new FileInfo(string.Format("{0}\\{1}", HttpContext.Current.Server.MapPath("~/Temp/"), nombreArchivo));

            using (ExcelPackage excelPackage = new ExcelPackage(directorioTemporal, directorioPlantillas))
            {
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[1];

                worksheet.Cells[4, 2].Value = string.Format("{0} - Fecha de generación: {1}", nombreReporte, DateTime.Now);
                worksheet.Name = nombreReporte;
                worksheet.Cells[8, 2].Value = porcentaje.ToString();
                worksheet.Cells[8, 3].Value = totalMun.ToString();
                worksheet.Cells[8, 4].Value = totalMunEscuelas.ToString();
                worksheet.Cells[8, 5].Value = totalEscuelas.ToString();
                worksheet.Cells[8, 6].Value = totalPublica.ToString();
                worksheet.Cells[8, 7].Value = TotalPrivadas.ToString();
                worksheet.Cells[8, 8].Value = totalMixtas.ToString();

                int fila = 10;
                int columna = 1;


                foreach (DataColumn dataColumn in dataTable.Columns)
                {

                    worksheet.Cells[fila, columna].Value = dataColumn.ColumnName;
                    worksheet.Cells[fila, columna].AutoFitColumns(50, 250);

                    columna++;
                }

                fila = 11;

                foreach (DataRow dataRow in dataTable.Rows)
                {
                    columna = 1;
                    for (int i = 0; i < dataTable.Columns.Count; i++)
                    {
                        worksheet.Cells[fila, columna].Value = dataRow[i];
                        worksheet.Cells[fila, columna].AutoFitColumns(50, 250);

                        if (dataRow[i] is decimal)
                            worksheet.Cells[fila, columna].Style.Numberformat.Format = @"#,##0.00";

                        DateTime temp;
                        if (dataRow.Table.Columns[i].ColumnName.Contains("Fecha") && DateTime.TryParse(dataRow[i].ToString(), out temp))
                        {
                            worksheet.Cells[fila, columna].Style.Numberformat.Format = @"dd/MM/yyy hh:mm:ss";
                            worksheet.Cells[fila, columna].Value = temp;
                        }

                        columna++;
                    }

                    fila++;
                }

                var stream = new MemoryStream();
                excelPackage.SaveAs(stream);

                return stream;
            }
        }
        public static MemoryStream CrearFichaProyecto(string nombreReporte, DataTable dataTableProyecto, DataTable dataTableFuentes, DataTable dataTableRegistroOperaciones, out string nombreArchivo)
        {
            nombreArchivo = string.Format("{0}-{1}.xlsx", DateTime.Now.ToString("yyyyMMddHHmmss"), nombreReporte);
            FileInfo directorioPlantillas = new FileInfo(string.Format("{0}\\PlantillaFichaProyecto.xlsx", HttpContext.Current.Server.MapPath("~/Content/Plantillas/")));
            FileInfo directorioTemporal = new FileInfo(string.Format("{0}\\{1}", HttpContext.Current.Server.MapPath("~/Temp/"), nombreArchivo));

            using (ExcelPackage excelPackage = new ExcelPackage(directorioTemporal, directorioPlantillas))
            {
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[1];

                worksheet.Name = nombreReporte;

                //Codigo Proyecto
                worksheet.Cells[3, 12].Value = dataTableProyecto.Rows[0]["ProyectoId"];

                //Codigo Escenario ??
                //worksheet.Cells[4, 12].Value = dataTableProyecto.Rows[0]["ProyectoId"];

                //Municipio
                worksheet.Cells[5, 3].Value = dataTableProyecto.Rows[0]["Municipio"] + "-" + dataTableProyecto.Rows[0]["Departamento"];
                //Beneficiario
                worksheet.Cells[6, 3].Value = dataTableProyecto.Rows[0]["NombreBeneficiario"];
                //Dirección
                worksheet.Cells[7, 3].Value = dataTableProyecto.Rows[0]["Direccion"];
                //Telefono
                worksheet.Cells[8, 3].Value = dataTableProyecto.Rows[0]["Telefono"] + "-" + dataTableProyecto.Rows[0]["Celular"];
                //Correo Electronico
                worksheet.Cells[9, 3].Value = dataTableProyecto.Rows[0]["CorreoElectronico"];
                //Representante Legal
                worksheet.Cells[10, 3].Value = dataTableProyecto.Rows[0]["RepresentanteLegal"];

                //Nombre del escenario
                worksheet.Cells[5, 8].Value = dataTableProyecto.Rows[0]["Escenario"];
                //Direccion
                worksheet.Cells[7, 8].Value = dataTableProyecto.Rows[0]["EscenarioDireccion"];
                //Telefono
                worksheet.Cells[8, 8].Value = dataTableProyecto.Rows[0]["EscenarioTelefono"];
                //Naturaleza
                worksheet.Cells[9, 8].Value = dataTableProyecto.Rows[0]["EscenarioTipo"];
                //Titularidad
                worksheet.Cells[9, 10].Value = dataTableProyecto.Rows[0]["EscenarioPropiedadTipo"];
                //Aforo
                worksheet.Cells[9, 12].Value = dataTableProyecto.Rows[0]["EscenarioAforo"];
                //¿Está declarado como Bien de Interés Cultural BIC?  
                worksheet.Cells[10, 10].Value = dataTableProyecto.Rows[0]["EscenarioInmuebleCultural"].ToString() == "False" ? "NO" : "SÍ";
                //Area 
                worksheet.Cells[10, 12].Value = dataTableProyecto.Rows[0]["EscenarioArea"];

                //Nombre proyecto
                worksheet.Cells[14, 3].Value = dataTableProyecto.Rows[0]["ProyectoNombre"];
                //Tipo de proyecto
                worksheet.Cells[15, 3].Value = dataTableProyecto.Rows[0]["ProyectoTipo"];
                //otro mobiliario
                worksheet.Cells[16, 3].Value = dataTableProyecto.Rows[0]["ProyectoTipoDotacionOtro1"];
                //Elemento artisticos
                worksheet.Cells[16, 3].Value = dataTableProyecto.Rows[0]["ProyectoTipoDotacionOtro2"];
                //Tecnologias TIC
                worksheet.Cells[16, 9].Value = dataTableProyecto.Rows[0]["ProyectoTipoDotacionOtro3"];
                //Otros
                worksheet.Cells[17, 9].Value = dataTableProyecto.Rows[0]["ProyectoOtroTipoOtro"];

                //Descripcion
                worksheet.Cells[21, 3].Value = dataTableProyecto.Rows[0]["ProyectoDescripcion"];
                //Relacion del proyecto con el plan de desarrollo
                worksheet.Cells[22, 3].Value = dataTableProyecto.Rows[0]["ProyectoPlanDeDesarrollo"];
                //Antecedentes
                worksheet.Cells[23, 3].Value = dataTableProyecto.Rows[0]["ProyectoJustificacion"];
                //Objetivo general
                worksheet.Cells[24, 3].Value = dataTableProyecto.Rows[0]["ProyectoObjetivoGeneral"];
                //Objetivo especificos
                worksheet.Cells[25, 3].Value = dataTableProyecto.Rows[0]["ProyectoObjetivosEspecificos"];

                //fecha estimada inicio
                worksheet.Cells[29, 4].Value = dataTableProyecto.Rows[0]["ProyectoCronogramaFechaInicio"];
                //fecha estimada final
                worksheet.Cells[30, 4].Value = dataTableProyecto.Rows[0]["ProyectoCronogramaFechaFinal"];

                int fila = 33;
                decimal totalValor = 0;
                decimal totalRendimientos = 0;
                decimal totalOtros = 0;

                foreach (DataRow fuente in dataTableFuentes.Rows)
                {
                    worksheet.Cells[fila, 2].Value = fuente["Fuente"];
                    worksheet.Cells[fila, 3].Value = fuente["Valor"];
                    worksheet.Cells[fila, 4].Value = fuente["Vigencia"];
                    if (fuente["Valor"] != null)
                    {
                        decimal valor;
                        decimal.TryParse(fuente["Valor"].ToString(), out valor);
                        totalValor += valor;

                        if (fuente["Fuente"].ToString().Equals("Otros recursos"))
                        {
                            totalOtros += valor;
                        }

                        if (fuente["Fuente"].ToString().Equals("Rendimientos recursos de la contribución parafiscal cultural"))
                        {
                            totalRendimientos += valor;
                        }
                    }

                    fila++;
                }

                ////Total recursos LEP
                //worksheet.Cells[46, 3].Value = totalValor;
                ////Total Rendimientos LEP
                //worksheet.Cells[47, 3].Value = totalRendimientos;
                ////Total Rendimientos LEP
                //worksheet.Cells[48, 3].Value = totalValor + totalRendimientos;
                ////Total Otros
                //worksheet.Cells[49, 3].Value = totalOtros;
                //Total Valor Proyecto
                if (!string.IsNullOrWhiteSpace(dataTableProyecto.Rows[0]["ProyectoValorTotal"].ToString()))
                {
                    var temp = dataTableProyecto.Rows[0]["ProyectoValorTotal"].ToString();
                    worksheet.Cells[42, 3].Value = Convert.ToDecimal(temp);
                }

                //Numero de artistas
                worksheet.Cells[29, 8].Value = dataTableProyecto.Rows[0]["IndicadoresArtistas"];
                //Numero de asistentes por año
                worksheet.Cells[29, 10].Value = dataTableProyecto.Rows[0]["IndicadoresAsistentesAno"];
                //Numero de espectaculos por año
                worksheet.Cells[29, 12].Value = dataTableProyecto.Rows[0]["IndicadoresEventosPorAno"];
                //Adecuaciones personas con discapacidad
                worksheet.Cells[31, 7].Value = dataTableProyecto.Rows[0]["AdecuacionesPersonasConDiscapacidad"];
                //Adecuaciones Primera infancia
                worksheet.Cells[33, 7].Value = dataTableProyecto.Rows[0]["AdecuacionesPersonasPrimeraInfancia"];
                //Otras adecuaciones
                worksheet.Cells[35, 7].Value = dataTableProyecto.Rows[0]["AdecuacionesOtras"];

                //Acto administrativo seleccion beneficiario
                worksheet.Cells[38, 9].Value = dataTableProyecto.Rows[0]["ViabilidadActoAdministrativoApertura"];
                //Acto administrativo seleccion beneficiario
                worksheet.Cells[39, 9].Value = dataTableProyecto.Rows[0]["ViabilidadActoAdministrativoSeleccion"];
                //Se realizó la verificación
                worksheet.Cells[40, 12].Value = "NO";

                if (dataTableProyecto.Rows[0]["ViabilidadNormativaUrbanistica"] != null)
                {
                    worksheet.Cells[40, 12].Value = dataTableProyecto.Rows[0]["ViabilidadNormativaUrbanistica"].ToString() == "True" ? "SÍ" : "NO";
                }

                //Licencia de construcción
                worksheet.Cells[41, 11].Value = dataTableProyecto.Rows[0]["ViabilidadLicenciaConstruccion"];
                //Fecha de construcción
                worksheet.Cells[41, 12].Value = dataTableProyecto.Rows[0]["ViabilidadFechaExpedicion"];


                //if (dataTableProyecto.Rows[0]["EscenarioTipo"].Equals("Privado"))
                //{
                //    //Acto administrativo de apertura de la convocatoria
                //    worksheet.Cells[42, 7].Value = "Acto administrativo de apertura de la convocatoria";                    
                //    worksheet.Cells[43, 7].Value = dataTableProyecto.Rows[0]["ViabilidadActoAdministrativoApertura"];
                //}
                //else
                //{
                //    // Programa y proyecto de inversión en el plan de desarrollo
                //    //worksheet.Cells[42, 7].Value = " Programa y proyecto de inversión en el plan de desarrollo";
                //    //worksheet.Cells[43, 7].Value = dataTableProyecto.Rows[0]["ViabilidadPlanDeInversion"];
                //}


                //Acto administrativo de apertura de la convocatoria
                worksheet.Cells[42, 7].Value = dataTableProyecto.Rows[0]["NombreUsuario"];
                //Fecha registro
                worksheet.Cells[42, 10].Value = dataTableProyecto.Rows[0]["FechaRegistro"];
                //Estado
                worksheet.Cells[42, 12].Value = dataTableProyecto.Rows[0]["Estado"];

                //Observaciones
                worksheet.Cells[44, 2].Value = dataTableProyecto.Rows[0]["Observaciones"];
                //worksheet.Cells[57, 3].Value = dataTableProyecto.Rows[0]["CambioEstadoComentario"];

                //Fecha actual
                worksheet.Cells[48, 12].Value = DateTime.Now.ToString("yyyy-MM-dd");


                fila = 50;
                foreach (DataRow operacion in dataTableRegistroOperaciones.Rows)
                {
                    worksheet.Cells[fila, 2].Value = operacion["FechaRegistro"].ToString();
                    worksheet.Cells[fila, 3].Value = operacion["NombreUsuario"].ToString();
                    worksheet.Cells[fila, 4].Value = operacion["Contenido"].ToString();
                    fila++;
                }

                var stream = new MemoryStream();
                excelPackage.SaveAs(stream);

                return stream;
            }
        }

        public static MemoryStream CrearReporteCruce(string nombreReporte, string parametros, DataTable dataTable, out string nombreArchivo)
        {
            nombreArchivo = string.Format("{0}-{1}.xlsx", DateTime.Now.ToString("yyyyMMddHHmmss"), nombreReporte);
            FileInfo directorioPlantillas = new FileInfo(string.Format("{0}\\PlantillaMatrizCruce.xlsx", HttpContext.Current.Server.MapPath("~/Content/Plantillas/")));
            FileInfo directorioTemporal = new FileInfo(string.Format("{0}\\{1}", HttpContext.Current.Server.MapPath("~/Temp/"), nombreArchivo));

            using (ExcelPackage excelPackage = new ExcelPackage(directorioTemporal, directorioPlantillas))
            {
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[1];

                worksheet.Cells[4, 2].Value = string.Format("{0} - Fecha de generación: {1}", nombreReporte, DateTime.Now);
                worksheet.Name = nombreReporte;
                worksheet.Cells[6, 2].Value = string.Format("Parámetros: {0}", parametros);
                worksheet.Cells[7, 2].Value = string.Format("Número de registros: {0}", dataTable.Rows.Count);

                int fila = 11;

                foreach (DataRow dataRow in dataTable.Rows)
                {
                    // Datos del evento
                    worksheet.Cells[fila, 2].Value = dataRow["Código del evento"].ToString();
                    worksheet.Cells[fila, 3].Value = dataRow["Nombre del evento"].ToString();
                    worksheet.Cells[fila, 4].Value = dataRow["Fecha inicial del evento"].ToString();
                    worksheet.Cells[fila, 5].Value = dataRow["Fecha final del evento"].ToString();
                    worksheet.Cells[fila, 6].Value = dataRow["Departamento del evento"].ToString();
                    worksheet.Cells[fila, 7].Value = dataRow["Municipio del evento"].ToString();
                    worksheet.Cells[fila, 8].Value = dataRow["Nombre del productor"].ToString();
                    worksheet.Cells[fila, 9].Value = dataRow["Código del productor"].ToString();
                    worksheet.Cells[fila, 10].Value = dataRow["Nombre del operador"].ToString();

                    // Datos de la declaración
                    worksheet.Cells[fila, 11].Value = dataRow["Declaraciones"].ToString();
                    worksheet.Cells[fila, 12].Value = dataRow["Declaración 2184 - Valor boletería igual o mayor 3 UVT"].ToString();
                    worksheet.Cells[fila, 13].Value = dataRow["Declaración 2184 - Contribución parafiscal"].ToString();
                    worksheet.Cells[fila, 14].Value = dataRow["Declaración 2185 - Valor boletería igual o mayor 3 UVT"].ToString();
                    worksheet.Cells[fila, 15].Value = dataRow["Declaración 2185 - Contribución parafiscal"].ToString();
                    worksheet.Cells[fila, 16].Value = dataRow["Declaración - Contribución parafiscal"].ToString();

                    // Datos reporte Sayco Acinpro
                    worksheet.Cells[fila, 17].Value = dataRow["Sayco - Número asistentes boleta igual o mayor 3 UVT"].ToString();
                    worksheet.Cells[fila, 18].Value = dataRow["Sayco - Número cortesías igual o mayor 3 UVT"].ToString();
                    worksheet.Cells[fila, 19].Value = dataRow["Sayco - Valor boletería igual o mayor 3 UVT"].ToString();
                    worksheet.Cells[fila, 20].Value = dataRow["Sayco - Valor cortesías igual o mayor 3 UVT"].ToString();
                    worksheet.Cells[fila, 21].Value = dataRow["Sayco - Base gravable"].ToString();
                    worksheet.Cells[fila, 22].Value = dataRow["Sayco - Contribución parafiscal"].ToString();

                    // Datos reporte in situ
                    worksheet.Cells[fila, 23].Value = dataRow["In situ - Número asistentes boleta igual o mayor 3 UVT"].ToString();
                    worksheet.Cells[fila, 24].Value = dataRow["In situ - Número cortesías igual o mayor 3 UVT"].ToString();
                    worksheet.Cells[fila, 25].Value = dataRow["In situ - Valor boletería igual o mayor 3 UVT"].ToString();
                    worksheet.Cells[fila, 26].Value = dataRow["In situ - Valor cortesías igual o mayor 3 UVT"].ToString();
                    worksheet.Cells[fila, 27].Value = dataRow["In situ - Base gravable"].ToString();
                    worksheet.Cells[fila, 28].Value = dataRow["In situ - Contribución parafiscal"].ToString();

                    // Datos reporte comercial
                    worksheet.Cells[fila, 29].Value = dataRow["Comercial - Valor boletería igual o mayor 3 UVT"].ToString();
                    worksheet.Cells[fila, 30].Value = dataRow["Comercial - Valor cortesías igual o mayor 3 UVT"].ToString();
                    worksheet.Cells[fila, 31].Value = dataRow["Comercial - Base gravable"].ToString();
                    worksheet.Cells[fila, 32].Value = dataRow["Comercial - Contribución parafiscal"].ToString();

                    // Datos reporte territorial
                    worksheet.Cells[fila, 33].Value = dataRow["Territorial - Valor boletería igual o mayor 3 UVT"].ToString();
                    worksheet.Cells[fila, 34].Value = dataRow["Territorial - Valor cortesías igual o mayor 3 UVT"].ToString();
                    worksheet.Cells[fila, 35].Value = dataRow["Territorial - Base gravable"].ToString();
                    worksheet.Cells[fila, 36].Value = dataRow["Territorial - Contribución parafiscal"].ToString();

                    // Datos resultados
                    worksheet.Cells[fila, 37].Value = dataRow["Diferencia - SAYCO - Declaración"].ToString();
                    worksheet.Cells[fila, 38].Value = dataRow["Diferencia - SAYCO - Declaración - Reporte"].ToString();
                    worksheet.Cells[fila, 39].Value = dataRow["Diferencia - CONTROL IN SITU - Declaración"].ToString();
                    worksheet.Cells[fila, 40].Value = dataRow["Diferencia - CONTROL IN SITU - Declaración - Reporte"].ToString();
                    worksheet.Cells[fila, 41].Value = dataRow["Diferencia - REPORTE COMERCIAL - Declaración"].ToString();
                    worksheet.Cells[fila, 42].Value = dataRow["Diferencia - REPORTE COMERCIAL - Declaración - Reporte"].ToString();
                    worksheet.Cells[fila, 43].Value = dataRow["Diferencia - REPORTE TERRITORIAL - Declaración"].ToString();
                    worksheet.Cells[fila, 44].Value = dataRow["Diferencia - REPORTE TERRITORIAL - Declaración - Reporte"].ToString();

                    fila++;
                }

                var stream = new MemoryStream();
                excelPackage.SaveAs(stream);

                return stream;
            }
        }
    }

}