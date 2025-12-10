using SM.Datos.DTO;
using SM.LibreriaComun.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Aplicacion.Reporte
{
    public class IndicadoresNeg
    {
        #region ReportesExcel
        public static List<ReporteDescargarDTO> ConsultarDetalleGraficaNaturaleza(int PeriodoAno)
        {
            List<ReporteDescargarDTO> lstRerporte = new List<ReporteDescargarDTO>();
            try
            {
                var reporte = new List<ReporteDescargar>();
                if (PeriodoAno == 1)
                    reporte = SM.Datos.Reportes.IndicadoresServicios.ConsultarDetalleGraficaNaturaleza();
                else
                    reporte = SM.Datos.Reportes.IndicadoresServicios.ConsultarDetalleGraficaNaturalezaHistorico(PeriodoAno);

                ReporteDescargarDTO objreporte = null;
                foreach (var item in reporte)
                {
                    objreporte = new ReporteDescargarDTO();
                    objreporte.Departamento = item.Departamento;
                    objreporte.Municipio = item.Municipio;
                    objreporte.codMunicipio = item.codMunicipio;
                    objreporte.Nombre = item.Nombre;
                    objreporte.Naturaleza = item.Naturaleza;
                    lstRerporte.Add(objreporte);

                }

            }
            catch (Exception ex)
            { throw ex; }
            return lstRerporte;
        }

        public static List<ReporteDescargarDTO> ConsultarDetalleGraficaLegalmenteConstituida(int PeriodoAno)
        {
            List<ReporteDescargarDTO> lstRerporte = new List<ReporteDescargarDTO>();
            try
            {
                var reporte = new List<ReporteDescargar>();
                if (PeriodoAno == 1)
                    reporte = SM.Datos.Reportes.IndicadoresServicios.ConsultarDetalleGraficaLegalmenteConstituida();
                else
                    reporte = SM.Datos.Reportes.IndicadoresServicios.ConsultarDetalleGraficaLegalmenteConstituidaHistorico(PeriodoAno);

                ReporteDescargarDTO objreporte = null;
                foreach (var item in reporte)
                {
                    objreporte = new ReporteDescargarDTO();
                    objreporte.Departamento = item.Departamento;
                    objreporte.Municipio = item.Municipio;
                    objreporte.codMunicipio = item.codMunicipio;
                    objreporte.Nombre = item.Nombre;
                    objreporte.Naturaleza = item.Naturaleza;
                    objreporte.criterio6 = item.criterio6;
                    if (item.criterio6 == "1")
                        objreporte.criterio6 = "SI";
                    else if (item.criterio6 == "0")
                        objreporte.criterio6 = "NO";
                    lstRerporte.Add(objreporte);

                }

            }
            catch (Exception ex)
            { throw ex; }
            return lstRerporte;
        }

        public static List<ReporteDescargarDTO> ConsultarDetalleGraficaTipoEscuela(int PeriodoAno)
        {
            List<ReporteDescargarDTO> lstRerporte = new List<ReporteDescargarDTO>();
            try
            {
                var reporte = new List<ReporteDescargar>();
                if (PeriodoAno == 1)
                    reporte = SM.Datos.Reportes.IndicadoresServicios.ConsultarDetalleGraficaTipoEscuela();
                else
                    reporte = SM.Datos.Reportes.IndicadoresServicios.ConsultarDetalleGraficaTipoEscuelaHistorico(PeriodoAno);
                ReporteDescargarDTO objreporte = null;
                foreach (var item in reporte)
                {
                    objreporte = new ReporteDescargarDTO();
                    objreporte.Departamento = item.Departamento;
                    objreporte.Municipio = item.Municipio;
                    objreporte.codMunicipio = item.codMunicipio;
                    objreporte.Nombre = item.Nombre;
                    objreporte.Naturaleza = item.Naturaleza;
                    objreporte.criterio6 = item.criterio6;
                    lstRerporte.Add(objreporte);

                }

            }
            catch (Exception ex)
            { throw ex; }
            return lstRerporte;
        }



        public static List<ReporteDescargarDTO> ConsultarDetalleGraficaFamiliaInstrumental(int PeriodoAno)
        {
            List<ReporteDescargarDTO> lstRerporte = new List<ReporteDescargarDTO>();
            try
            {
                var reporte = new List<ReporteDescargar>();
                if (PeriodoAno == 1)
                    reporte = SM.Datos.Reportes.IndicadoresServicios.ConsultarDetalleGraficaFamiliaInstrumental();
                else
                    reporte = SM.Datos.Reportes.IndicadoresServicios.ConsultarDetalleGraficaFamiliaInstrumentalHistorico(PeriodoAno);
                ReporteDescargarDTO objreporte = null;
                foreach (var item in reporte)
                {
                    objreporte = new ReporteDescargarDTO();
                    objreporte.Departamento = item.Departamento;
                    objreporte.Municipio = item.Municipio;
                    objreporte.codMunicipio = item.codMunicipio;
                    objreporte.Nombre = item.Nombre;
                    objreporte.Naturaleza = item.Naturaleza;
                    objreporte.criterio6 = item.criterio6;
                    objreporte.criterio7 = item.criterio7;
                    objreporte.criterio12 = item.criterio12;
                    objreporte.criterio19 = item.criterio19;
                    objreporte.criterio26 = item.criterio26;
                    objreporte.criterio27 = item.criterio27;
                    objreporte.criterio28 = item.criterio28;
                    objreporte.criterio29 = item.criterio29;
                    lstRerporte.Add(objreporte);

                }

            }
            catch (Exception ex)
            { throw ex; }
            return lstRerporte;
        }

        public static List<ReporteDescargarDTO> ConsultarDetalleGraficaPracticaMusical(int PeriodoAno)
        {
            List<ReporteDescargarDTO> lstRerporte = new List<ReporteDescargarDTO>();
            try
            {
                var reporte = new List<ReportePractica>();
                if (PeriodoAno == 1)
                    reporte = SM.Datos.Reportes.IndicadoresServicios.ConsultarDetalleGraficaPracticaMusical();
                else
                    reporte = SM.Datos.Reportes.IndicadoresServicios.ConsultarDetalleGraficaPracticaMusicalHistorico(PeriodoAno);

                ReporteDescargarDTO objreporte = null;
                foreach (var item in reporte)
                {
                    objreporte = new ReporteDescargarDTO();
                    objreporte.Departamento = item.Departamento;
                    objreporte.Municipio = item.Municipio;
                    objreporte.codMunicipio = item.codMunicipio;
                    objreporte.Nombre = item.Nombre;
                    objreporte.Naturaleza = item.Naturaleza;
                    if (item.Banda == "0")
                        objreporte.criterio6 = "No";
                    else
                        objreporte.criterio6 = "Si";

                    if (item.MusicaTradicional == "0")
                        objreporte.criterio7 = "No";
                    else
                        objreporte.criterio7 = "Si";

                    if (item.Coros == "0")
                        objreporte.criterio12 = "No";
                    else
                        objreporte.criterio12 = "Si";

                    if (item.Orquesta == "0")
                        objreporte.criterio19 = "No";
                    else
                        objreporte.criterio19 = "Si";

                    if (item.Urbana == "0")
                        objreporte.criterio26 = "No";
                    else
                        objreporte.criterio26 = "Si";

                    if (item.Iniciacion == "0")
                        objreporte.criterio27 = "No";
                    else
                        objreporte.criterio27 = "Si";

                    lstRerporte.Add(objreporte);

                }

            }
            catch (Exception ex)
            { throw ex; }
            return lstRerporte;
        }

        public static List<ReporteDescargarDTO> ConsultarDetalleGraficaRangosEtarios(int PeriodoAno)
        {
            List<ReporteDescargarDTO> lstRerporte = new List<ReporteDescargarDTO>();
            try
            {
                var reporte = new List<ReporteDescargar>();
                if (PeriodoAno == 1)
                    reporte = SM.Datos.Reportes.IndicadoresServicios.ConsultarDetalleGraficaRangosEtarios();
                else
                    reporte = SM.Datos.Reportes.IndicadoresServicios.ConsultarDetalleGraficaRangosEtariosHistorico(PeriodoAno);
                ReporteDescargarDTO objreporte = null;
                foreach (var item in reporte)
                {
                    objreporte = new ReporteDescargarDTO();
                    objreporte.Departamento = item.Departamento;
                    objreporte.Municipio = item.Municipio;
                    objreporte.codMunicipio = item.codMunicipio;
                    objreporte.Nombre = item.Nombre;
                    objreporte.Naturaleza = item.Naturaleza;
                    objreporte.criterio6 = item.criterio6;
                    objreporte.criterio7 = item.criterio7;
                    objreporte.criterio12 = item.criterio12;
                    objreporte.criterio19 = item.criterio19;
                    objreporte.criterio26 = item.criterio26;
                    objreporte.criterio27 = item.criterio27;
                    lstRerporte.Add(objreporte);

                }

            }
            catch (Exception ex)
            { throw ex; }
            return lstRerporte;
        }

        public static List<ReporteDescargarDTO> ConsultarDetalleNivelEducativoDocentes(int PeriodoAno)
        {
            List<ReporteDescargarDTO> lstRerporte = new List<ReporteDescargarDTO>();
            try
            {
                var reporte = new List<ReporteDescargar>();
                if (PeriodoAno == 1)
                    reporte = SM.Datos.Reportes.IndicadoresServicios.ConsultarDetalleNivelEducativoDocentes();
                else
                    reporte = SM.Datos.Reportes.IndicadoresServicios.ConsultarDetalleNivelEducativoDocentesHistorico(PeriodoAno);

                ReporteDescargarDTO objreporte = null;
                foreach (var item in reporte)
                {
                    objreporte = new ReporteDescargarDTO();
                    objreporte.Departamento = item.Departamento;
                    objreporte.Municipio = item.Municipio;
                    objreporte.codMunicipio = item.codMunicipio;
                    objreporte.Nombre = item.Nombre;
                    objreporte.Naturaleza = item.Naturaleza;
                    objreporte.criterio6 = item.criterio6;
                    objreporte.criterio7 = item.criterio7;
                    objreporte.criterio12 = item.criterio12;
                    objreporte.criterio19 = item.criterio19;
                    objreporte.criterio26 = item.criterio26;
                    objreporte.criterio27 = item.criterio27;
                    objreporte.criterio28 = item.criterio28;
                    lstRerporte.Add(objreporte);

                }

            }
            catch (Exception ex)
            { throw ex; }
            return lstRerporte;
        }

        public static List<ReporteDescargarDTO> ConsultarDetalleCirculacion(int PeriodoAno)
        {
            List<ReporteDescargarDTO> lstRerporte = new List<ReporteDescargarDTO>();
            try
            {
                var reporte = new List<ReporteDescargar>();
                if (PeriodoAno == 1)
                    reporte = SM.Datos.Reportes.IndicadoresServicios.ConsultarDetalleCirculacion();
                else
                    reporte = SM.Datos.Reportes.IndicadoresServicios.ConsultarDetalleCirculacionHistorico(PeriodoAno);
                ReporteDescargarDTO objreporte = null;
                foreach (var item in reporte)
                {
                    objreporte = new ReporteDescargarDTO();
                    objreporte.Departamento = item.Departamento;
                    objreporte.Municipio = item.Municipio;
                    objreporte.codMunicipio = item.codMunicipio;
                    objreporte.Nombre = item.Nombre;
                    objreporte.Naturaleza = item.Naturaleza;
                    objreporte.criterio6 = item.criterio6;
                    objreporte.criterio7 = item.criterio7;
                    objreporte.criterio12 = item.criterio12;

                    lstRerporte.Add(objreporte);

                }

            }
            catch (Exception ex)
            { throw ex; }
            return lstRerporte;
        }
        public static List<ReporteDescargarDTO> ConsultarDetalleGraficaUbicacion(int PeriodoAno)
        {
            List<ReporteDescargarDTO> lstRerporte = new List<ReporteDescargarDTO>();
            try
            {
                var reporte = new List<ReporteDescargar>();
                if (PeriodoAno == 1)
                    reporte = SM.Datos.Reportes.IndicadoresServicios.ConsultarDetalleGraficaUbicacion();
                else
                    reporte = SM.Datos.Reportes.IndicadoresServicios.ConsultarDetalleGraficaUbicacionHistorico(PeriodoAno);
                ReporteDescargarDTO objreporte = null;
                foreach (var item in reporte)
                {
                    objreporte = new ReporteDescargarDTO();
                    objreporte.Departamento = item.Departamento;
                    objreporte.Municipio = item.Municipio;
                    objreporte.codMunicipio = item.codMunicipio;
                    objreporte.Nombre = item.Nombre;
                    objreporte.Naturaleza = item.Naturaleza;
                    objreporte.criterio6 = item.criterio6;
                    objreporte.criterio7 = item.criterio7;

                    lstRerporte.Add(objreporte);

                }

            }
            catch (Exception ex)
            { throw ex; }
            return lstRerporte;
        }
        public static List<ReporteDescargarDTO> ConsultarDetalleGraficaGrupoEtnico(int PeriodoAno)
        {
            List<ReporteDescargarDTO> lstRerporte = new List<ReporteDescargarDTO>();
            try
            {
                var reporte = new List<ReporteDescargar>();
                if (PeriodoAno == 1)
                    reporte = SM.Datos.Reportes.IndicadoresServicios.ConsultarDetalleGraficaGrupoEtnico();
                else
                    reporte = SM.Datos.Reportes.IndicadoresServicios.ConsultarDetalleGraficaGrupoEtnicoHistorico(PeriodoAno);

                ReporteDescargarDTO objreporte = null;
                foreach (var item in reporte)
                {
                    objreporte = new ReporteDescargarDTO();
                    objreporte.Departamento = item.Departamento;
                    objreporte.Municipio = item.Municipio;
                    objreporte.codMunicipio = item.codMunicipio;
                    objreporte.Nombre = item.Nombre;
                    objreporte.Naturaleza = item.Naturaleza;
                    objreporte.criterio6 = item.criterio6;
                    objreporte.criterio7 = item.criterio7;
                    objreporte.criterio12 = item.criterio12;
                    objreporte.criterio19 = item.criterio19;
                    lstRerporte.Add(objreporte);

                }

            }
            catch (Exception ex)
            { throw ex; }
            return lstRerporte;
        }
        public static List<ReporteDescargarDTO> ConsultarDetalleGraficaSexo(int PeriodoAno)
        {
            List<ReporteDescargarDTO> lstRerporte = new List<ReporteDescargarDTO>();
            try
            {
                var reporte = new List<ReporteDescargar>();
                if (PeriodoAno == 1)
                    reporte = SM.Datos.Reportes.IndicadoresServicios.ConsultarDetalleGraficaSexo();
                else
                    reporte = SM.Datos.Reportes.IndicadoresServicios.ConsultarDetalleGraficaSexoHistorico(PeriodoAno);

                ReporteDescargarDTO objreporte = null;
                foreach (var item in reporte)
                {
                    objreporte = new ReporteDescargarDTO();
                    objreporte.Departamento = item.Departamento;
                    objreporte.Municipio = item.Municipio;
                    objreporte.codMunicipio = item.codMunicipio;
                    objreporte.Nombre = item.Nombre;
                    objreporte.Naturaleza = item.Naturaleza;
                    objreporte.criterio6 = item.criterio6;
                    objreporte.criterio7 = item.criterio7;

                    lstRerporte.Add(objreporte);

                }

            }
            catch (Exception ex)
            { throw ex; }
            return lstRerporte;
        }
        #endregion

       
        public static List<indicadoresDTO> ObtenerEscuelasPorNaturalezaActual(int PeriodoAno)
        {
            var lstRerporte = new List<indicadoresDTO>();
            var reporte = new List<ReporteDTO>();
            if (PeriodoAno == 1)
                reporte = SM.Datos.Reportes.IndicadoresServicios.ObtenerEscuelasPorNaturalezaActual();
            else
                reporte = SM.Datos.Reportes.IndicadoresServicios.ObtenerEscuelasPorNaturalezaHistorico(PeriodoAno);
            indicadoresDTO objreporte = null;
            foreach (var i in reporte)
            {
                objreporte = new indicadoresDTO();
                objreporte.indexLabel = i.Nombre;
                objreporte.y = i.valor;
                if (i.Nombre == "PUBLICA")
                {
                    objreporte.exploded = true;
                    objreporte.orden = 3;
                }
                else
                    objreporte.exploded = false;

                if (i.Nombre == "PRIVADA")
                    objreporte.orden = 2;

                if (i.Nombre == "MIXTA")
                    objreporte.orden = 1;

                lstRerporte.Add(objreporte);

            }

            lstRerporte = lstRerporte.OrderByDescending(x => x.orden).ToList();

            return lstRerporte;
        }

        public static EscuelasEstadisticasDTO ObtenerDatosFijosEscuelas(int PeriodoAno)
        {
            int cantidadTotalDepende = 0;
            int cantidadTotalOrganizacion = 0;
            var reporte = new List<ReporteDTO>();
            var reporteOrganizacion = new List<ReporteDTO>();

            if (PeriodoAno == 1)
            {
                reporte = SM.Datos.Reportes.IndicadoresServicios.ObtenerEscuelasDependeOtraEntidad();
                reporteOrganizacion = SM.Datos.Reportes.IndicadoresServicios.ObtenerEscuelasConOrganizacionComunitaria();
            }
            else
            {
                reporte = SM.Datos.Reportes.IndicadoresServicios.ObtenerEscuelasDependeOtraEntidadHistorico(PeriodoAno);
                reporteOrganizacion = SM.Datos.Reportes.IndicadoresServicios.ObtenerEscuelasConOrganizacionComunitariaHistorico(PeriodoAno);

            }

            EscuelasEstadisticasDTO objreporte = new EscuelasEstadisticasDTO();
            foreach (var i in reporte)
            {
                if (i.Nombre == "PUBLICA")
                    objreporte.PublicaDepende = i.valor;
                else if (i.Nombre == "PRIVADA")
                    objreporte.PrivadaDepende = i.valor;
                else if (i.Nombre == "MIXTA")
                    objreporte.MixtaDepende = i.valor;

                cantidadTotalDepende = cantidadTotalDepende + i.valor;
            }

            foreach (var x in reporteOrganizacion)
            {
                if (x.Nombre == "PUBLICA")
                    objreporte.PublicaOrganizacion = x.valor;
                else if (x.Nombre == "PRIVADA")
                    objreporte.PrivadaOrganizacion = x.valor;
                else if (x.Nombre == "MIXTA")
                    objreporte.MixtaOrganizacion = x.valor;

                cantidadTotalOrganizacion = cantidadTotalOrganizacion + x.valor;

            }
            objreporte.TotalDepende = cantidadTotalDepende;
            objreporte.TotalOrganizacion = cantidadTotalOrganizacion;
            return objreporte;
        }

        public static DocentesEstadisticasDTO ObtenerDatosFijosDocentes(int periodo)
        {
            int TotalAlumnos = 0;
            int TotalDocentes = 0;
            var reporteEstudiantes = new List<ReporteDTO>();
            var reporteDocentes = new List<ReporteDTO>();
            if (periodo == 1)
            {
                reporteEstudiantes = SM.Datos.Reportes.IndicadoresServicios.ObtenerTotalEstudiantesPorNaturaleza();
                reporteDocentes = SM.Datos.Reportes.IndicadoresServicios.ObtenerTotalDocentesPorNaturaleza();
            }
            else
            {
                reporteEstudiantes = SM.Datos.Reportes.IndicadoresServicios.ObtenerTotalEstudiantesPorNaturalezaHistorico(periodo);
                reporteDocentes = SM.Datos.Reportes.IndicadoresServicios.ObtenerTotalDocentesPorNaturalezaHistorico(periodo);
            }
            DocentesEstadisticasDTO objreporte = new DocentesEstadisticasDTO();
            foreach (var i in reporteEstudiantes)
            {
                if (i.Nombre == "PUBLICA")
                {
                    foreach (var x in reporteDocentes)
                    {
                        if (x.Nombre == "PUBLICA")
                        {
                            objreporte.Publica = i.valor / x.valor;
                            TotalDocentes = TotalDocentes + x.valor;
                        }
                    }
                }
                else if (i.Nombre == "PRIVADA")
                {
                    foreach (var x in reporteDocentes)
                    {
                        if (x.Nombre == "PRIVADA")
                        {
                            objreporte.Privada = i.valor / x.valor;
                            TotalDocentes = TotalDocentes + x.valor;
                        }
                    }
                }
                else if (i.Nombre == "MIXTA")
                {
                    foreach (var x in reporteDocentes)
                    {
                        if (x.Nombre == "MIXTA")
                        {
                            objreporte.Mixta = i.valor / x.valor;
                            TotalDocentes = TotalDocentes + x.valor;
                        }
                    }
                }

                TotalAlumnos = TotalAlumnos + i.valor;
            }

            objreporte.TotalAlumnos = TotalAlumnos;
            objreporte.TotalDocentes = TotalDocentes;
            return objreporte;
        }

        public static DepartamentoEstadisticasDTO ObtenerEscuelasPorDepartamento(string codDepto, int periodo)
        {
            try
            {
                var reporte = new List<ReporteDTO>();
                if (periodo == 1)
                    reporte = SM.Datos.Reportes.IndicadoresServicios.ObtenerEscuelasPorDepartamento(codDepto);
                else
                    reporte = SM.Datos.Reportes.IndicadoresServicios.ObtenerEscuelasPorDepartamentoHistorico(codDepto, periodo);

                DepartamentoEstadisticasDTO objreporte = new DepartamentoEstadisticasDTO();
                objreporte.TotalEscuelas = 0;
                foreach (var i in reporte)
                {
                    if (i.Nombre == "PUBLICA")
                        objreporte.Publica = i.valor;
                    else if (i.Nombre == "PRIVADA")
                        objreporte.Privada = i.valor;
                    else if (i.Nombre == "MIXTA")
                        objreporte.Mixta = i.valor;

                    objreporte.TotalEscuelas += i.valor;
                }

                objreporte.NombreDepto = SM.Datos.Basicas.ServicioBasicas.obtenerNombreDepartamento(codDepto);
                return objreporte;
            }
            catch (Exception ex)
            { throw ex; }


        }

        public static EstudiantesEstadisticasDTO ObtenerDatosFijosEstudiantes(int periodo)
        {
            var reporte = new UbicacionReporte();
            if (periodo == 1)
                reporte = SM.Datos.Reportes.IndicadoresServicios.ObtenerTotalEstudiantesUbicacion();
            else
                reporte = SM.Datos.Reportes.IndicadoresServicios.ObtenerTotalEstudiantesUbicacionHistorico(periodo);

            EstudiantesEstadisticasDTO objreporte = new EstudiantesEstadisticasDTO();
            objreporte.Rural = reporte.Rural;
            objreporte.Urbana = reporte.Urbana;
            objreporte.totalUbicacion = reporte.Rural + reporte.Urbana;
            objreporte.PorcentajeRural = (reporte.Rural * 100);
            objreporte.PorcentajeRural = objreporte.PorcentajeRural / objreporte.totalUbicacion;
            objreporte.PorcentajeUrbana = (reporte.Urbana * 100);
            objreporte.PorcentajeUrbana = objreporte.PorcentajeUrbana / objreporte.totalUbicacion;
            return objreporte;
        }

        public static List<LegalmenteDTO> ObtenerEscuelasLegalmenteConstituidas(int periodo, bool boolSI)
        {
            var lstRerporte = new List<LegalmenteDTO>();
            var reporte = new List<ReporteDTO>();

            if (periodo == 1)
                reporte = SM.Datos.Reportes.IndicadoresServicios.ObtenerEscuelasLegalmenteConstituidas(boolSI);
            else
                reporte = SM.Datos.Reportes.IndicadoresServicios.ObtenerEscuelasLegalmenteConstituidasHistorico(periodo, boolSI);

            LegalmenteDTO objreporte = null;
            foreach (var i in reporte)
            {
                objreporte = new LegalmenteDTO();
                objreporte.label = i.Nombre;
                objreporte.y = i.valor;

                lstRerporte.Add(objreporte);

            }

            lstRerporte = lstRerporte.OrderByDescending(x => x.label).ToList();

            return lstRerporte;
        }

        public static List<LegalmenteDTO> ObtenerEscuelasPorTipo(int periodo)
        {
            var lstRerporte = new List<LegalmenteDTO>();
            var reporte = new List<ReporteDTO>();

            if (periodo == 1)
                reporte = SM.Datos.Reportes.IndicadoresServicios.ObtenerEscuelasPorTipo();
            else
                reporte = SM.Datos.Reportes.IndicadoresServicios.ObtenerEscuelasPorTipoHistorico(periodo);
            LegalmenteDTO objreporte = null;
            foreach (var i in reporte)
            {
                objreporte = new LegalmenteDTO();
                objreporte.label = i.Nombre;
                objreporte.y = i.valor;

                lstRerporte.Add(objreporte);

            }

            lstRerporte = lstRerporte.OrderBy(x => x.y).ToList();

            return lstRerporte;
        }

        public static List<LegalmenteDTO> ObtenerEscuelasPorTipoYNaturaleza(string strNaturaleza, int periodo)
        {
            var lstRerporte = new List<LegalmenteDTO>();
            var lstTipo = new List<LegalmenteDTO>();
            var reporte = new List<ReporteDTO>();

            if (periodo == 1)
                reporte = SM.Datos.Reportes.IndicadoresServicios.ObtenerEscuelasPorTipoYNaturaleza(strNaturaleza);
            else
                reporte = SM.Datos.Reportes.IndicadoresServicios.ObtenerEscuelasPorTipoYNaturalezaHistorico(strNaturaleza, periodo);

            var tipo = SM.Datos.Reportes.IndicadoresServicios.ObtenerTipoEscuelas();

            LegalmenteDTO objreporte = null;
            foreach (var i in tipo)
            {
                objreporte = new LegalmenteDTO();
                objreporte.label = i.Nombre;
                objreporte.y = i.valor;

                foreach (var x in reporte)
                {
                    if (i.Nombre == x.Nombre)
                        objreporte.y = x.valor;
                }
                lstRerporte.Add(objreporte);

            }


            return lstRerporte;
        }

        public static List<LegalmenteDTO> ObtenerEscuelasPorPracticaMusical(int periodo, string strNaturaleza)
        {
            var lstRerporte = new List<LegalmenteDTO>();
            var reporte = new List<ReporteDTO>();

            if (periodo == 1)
                reporte = SM.Datos.Reportes.IndicadoresServicios.ObtenerEscuelasPorPracticaMusical(strNaturaleza);
            else
                reporte = SM.Datos.Reportes.IndicadoresServicios.ObtenerEscuelasPorPracticaMusicalHistorico(periodo, strNaturaleza);

            LegalmenteDTO objreporte = null;
            foreach (var i in reporte)
            {
                objreporte = new LegalmenteDTO();
                objreporte.label = i.Nombre;
                objreporte.y = i.valor;

                lstRerporte.Add(objreporte);

            }

            lstRerporte = lstRerporte.OrderByDescending(x => x.label).ToList();

            return lstRerporte;
        }

        public static List<LegalmenteDTO> ObtenerEscuelasPorFamiliaInstrumental(int periodo, string strNaturaleza)
        {
            var lstRerporte = new List<LegalmenteDTO>();
            var reporte = new List<ReporteDTO>();

            if (periodo == 1)
                reporte = SM.Datos.Reportes.IndicadoresServicios.ObtenerEscuelasPorFamiliaInstrumental(strNaturaleza);
            else
                reporte = SM.Datos.Reportes.IndicadoresServicios.ObtenerEscuelasPorFamiliaInstrumentalHistorico(periodo, strNaturaleza);

            LegalmenteDTO objreporte = null;
            foreach (var i in reporte)
            {
                objreporte = new LegalmenteDTO();
                objreporte.label = i.Nombre;
                objreporte.y = i.valor;

                lstRerporte.Add(objreporte);

            }

            lstRerporte = lstRerporte.OrderByDescending(x => x.label).ToList();

            return lstRerporte;
        }

        public static List<LegalmenteDTO> ObtenerEscuelasPorNivelEducativoDocentes(int periodo, string strNaturaleza)
        {
            var lstRerporte = new List<LegalmenteDTO>();
            var reporte = new List<ReporteDTO>();
            if (periodo == 1)
                reporte = SM.Datos.Reportes.IndicadoresServicios.ObtenerEscuelasPorNivelEducativoDocentes(strNaturaleza);
            else
                reporte = SM.Datos.Reportes.IndicadoresServicios.ObtenerEscuelasPorNivelEducativoDocentesHistorico(periodo, strNaturaleza);

            LegalmenteDTO objreporte = null;
            foreach (var i in reporte)
            {
                objreporte = new LegalmenteDTO();
                objreporte.label = i.Nombre;
                objreporte.y = i.valor;

                lstRerporte.Add(objreporte);

            }


            return lstRerporte;
        }


        public static List<LegalmenteDTO> ObtenerEscuelasPorProduccion(int periodo, string strNaturaleza)
        {
            var lstRerporte = new List<LegalmenteDTO>();
            var reporte = new List<ReporteDTO>();
            if (periodo == 1)
                reporte = SM.Datos.Reportes.IndicadoresServicios.ObtenerEscuelasPorProduccion(strNaturaleza);
            else
                reporte = SM.Datos.Reportes.IndicadoresServicios.ObtenerEscuelasPorProduccionHistorico(periodo, strNaturaleza);

            LegalmenteDTO objreporte = null;
            foreach (var i in reporte)
            {
                objreporte = new LegalmenteDTO();
                objreporte.label = i.Nombre;
                objreporte.y = i.valor;

                lstRerporte.Add(objreporte);

            }


            return lstRerporte;
        }
        public static List<LegalmenteDTO> ObtenerEstudiantesPorRangosEtarios(int periodo, string strNaturaleza)
        {
            var lstRerporte = new List<LegalmenteDTO>();
            var reporte = new List<ReporteDTO>();
            if (periodo == 1)
                reporte = SM.Datos.Reportes.IndicadoresServicios.ObtenerEstudiantesPorRangosEtarios(strNaturaleza);
            else
                reporte = SM.Datos.Reportes.IndicadoresServicios.ObtenerEstudiantesPorRangosEtariosHistorico(periodo, strNaturaleza);
            LegalmenteDTO objreporte = null;
            foreach (var i in reporte)
            {
                objreporte = new LegalmenteDTO();
                objreporte.label = i.Nombre;
                objreporte.y = i.valor;

                lstRerporte.Add(objreporte);

            }


            return lstRerporte;
        }

        public static List<LegalmenteDTO> ObtenerEstudiantesPorUbicacion(string strNaturaleza)
        {
            var lstRerporte = new List<LegalmenteDTO>();

            var reporte = SM.Datos.Reportes.IndicadoresServicios.ObtenerEstudiantesPorUbicacion(strNaturaleza);
            LegalmenteDTO objreporte = null;
            foreach (var i in reporte)
            {
                objreporte = new LegalmenteDTO();
                objreporte.label = i.Nombre;
                objreporte.y = i.valor;

                lstRerporte.Add(objreporte);

            }


            return lstRerporte;
        }

        public static List<LegalmenteDTO> ObtenerEstudiantesPorUbicacionUrbana(int periodo)
        {
            var lstRerporte = new List<LegalmenteDTO>();
            var reporte = new List<ReporteDTO>();

            if (periodo == 1)
                reporte = SM.Datos.Reportes.IndicadoresServicios.ObtenerEstudiantesPorUbicacionUrbana();
            else
                reporte = SM.Datos.Reportes.IndicadoresServicios.ObtenerEstudiantesPorUbicacionUrbanaHistorico(periodo);
            LegalmenteDTO objreporte = null;
            foreach (var i in reporte)
            {
                objreporte = new LegalmenteDTO();
                objreporte.label = i.Nombre;
                objreporte.y = i.valor;

                lstRerporte.Add(objreporte);

            }


            return lstRerporte;
        }

        public static List<LegalmenteDTO> ObtenerEstudiantesPorUbicacionRural(int periodo)
        {
            var lstRerporte = new List<LegalmenteDTO>();
            var reporte = new List<ReporteDTO>();

            if (periodo == 1)
                reporte = SM.Datos.Reportes.IndicadoresServicios.ObtenerEstudiantesPorUbicacionRural();
            else
                reporte = SM.Datos.Reportes.IndicadoresServicios.ObtenerEstudiantesPorUbicacionRuralHistorico(periodo);

            LegalmenteDTO objreporte = null;
            foreach (var i in reporte)
            {
                objreporte = new LegalmenteDTO();
                objreporte.label = i.Nombre;
                objreporte.y = i.valor;

                lstRerporte.Add(objreporte);

            }


            return lstRerporte;
        }

        public static List<LegalmenteDTO> ObtenerEstudiantesPorSexoMasculino(int periodo)
        {
            var lstRerporte = new List<LegalmenteDTO>();
            var reporte = new List<ReporteDTO>();

            if (periodo == 1)
                reporte = SM.Datos.Reportes.IndicadoresServicios.ObtenerEstudiantesPorSexoMasculino();
            else
                reporte = SM.Datos.Reportes.IndicadoresServicios.ObtenerEstudiantesPorSexoMasculinoHistorico(periodo);

            LegalmenteDTO objreporte = null;
            foreach (var i in reporte)
            {
                objreporte = new LegalmenteDTO();
                objreporte.label = i.Nombre;
                objreporte.y = i.valor;

                lstRerporte.Add(objreporte);

            }


            return lstRerporte;
        }
        public static List<LegalmenteDTO> ObtenerEstudiantesPorSexoFemenino(int periodo)
        {
            var lstRerporte = new List<LegalmenteDTO>();
            var reporte = new List<ReporteDTO>();

            if (periodo == 1)
                reporte = SM.Datos.Reportes.IndicadoresServicios.ObtenerEstudiantesPorSexoFemenino();
            else
                reporte = SM.Datos.Reportes.IndicadoresServicios.ObtenerEstudiantesPorSexoFemeninoHistorico(periodo);

            LegalmenteDTO objreporte = null;
            foreach (var i in reporte)
            {
                objreporte = new LegalmenteDTO();
                objreporte.label = i.Nombre;
                objreporte.y = i.valor;

                lstRerporte.Add(objreporte);

            }


            return lstRerporte;
        }
        public static List<LegalmenteDTO> ObtenerEstudiantesPorSexo(string strNaturaleza)
        {
            var lstRerporte = new List<LegalmenteDTO>();

            var reporte = SM.Datos.Reportes.IndicadoresServicios.ObtenerEstudiantesPorSexo(strNaturaleza);
            LegalmenteDTO objreporte = null;
            foreach (var i in reporte)
            {
                objreporte = new LegalmenteDTO();
                objreporte.label = i.Nombre;
                objreporte.y = i.valor;

                lstRerporte.Add(objreporte);

            }


            return lstRerporte;
        }
        public static List<LegalmenteDTO> ObtenerEstudiantesPorGrupoEtnico(int periodo, string strNaturaleza)
        {
            var lstRerporte = new List<LegalmenteDTO>();
            var reporte = new List<ReporteDTO>();
            if (periodo == 1)
                reporte = SM.Datos.Reportes.IndicadoresServicios.ObtenerEstudiantesPorGrupoEtnico(strNaturaleza);
            else
                reporte = SM.Datos.Reportes.IndicadoresServicios.ObtenerEstudiantesPorGrupoEtnicoHistorico(periodo, strNaturaleza);
            LegalmenteDTO objreporte = null;
            foreach (var i in reporte)
            {
                objreporte = new LegalmenteDTO();
                objreporte.label = i.Nombre;
                objreporte.y = i.valor;

                lstRerporte.Add(objreporte);

            }


            return lstRerporte;
        }
    }
}
