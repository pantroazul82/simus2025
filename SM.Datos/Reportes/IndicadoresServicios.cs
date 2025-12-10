using SM.Datos.DTO;
using SM.SIPA;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Datos.Reportes
{
    public class IndicadoresServicios
    {

        #region reportesDetalleExcel

        public static List<int> ObtenerPeriodo()
        {
            List<int> listReporte = new List<int>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    listReporte = context.Database.SqlQuery<int>(@"EXEC ART_MUSICA_OBTENER_PERIODO").ToList();



                }
                return listReporte;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<ReporteDescargar> ConsultarDetalleGraficaNaturaleza()
        {
            List<ReporteDescargar> listReporte = new List<ReporteDescargar>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    listReporte = context.Database.SqlQuery<ReporteDescargar>(@"EXEC ART_MUSICA_REPORTE_NATURALEZA_DETALLE").ToList();



                }
                return listReporte;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<ReporteDescargar> ConsultarDetalleGraficaNaturalezaHistorico(int periodo)
        {
            List<ReporteDescargar> listReporte = new List<ReporteDescargar>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    listReporte = context.Database.SqlQuery<ReporteDescargar>(@"EXEC ART_MUSICA_HISTORICO_NATURALEZA_DETALLE @Periodo", new SqlParameter("Periodo", periodo)).ToList();



                }
                return listReporte;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<ReporteDescargar> ConsultarDetalleGraficaLegalmenteConstituida()
        {
            List<ReporteDescargar> listReporte = new List<ReporteDescargar>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    listReporte = context.Database.SqlQuery<ReporteDescargar>(@"EXEC ART_MUSICA_REPORTE_LEGALMENTE_CONSTITUIDA").ToList();



                }
                return listReporte;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<ReporteDescargar> ConsultarDetalleGraficaLegalmenteConstituidaHistorico(int periodo)
        {
            List<ReporteDescargar> listReporte = new List<ReporteDescargar>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    listReporte = context.Database.SqlQuery<ReporteDescargar>(@"EXEC ART_MUSICA_REPORTE_LEGALMENTE_CONSTITUIDA_HISTORICO @Periodo", new SqlParameter("Periodo", periodo)).ToList();



                }
                return listReporte;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<ReporteDescargar> ConsultarDetalleGraficaTipoEscuela()
        {
            List<ReporteDescargar> listReporte = new List<ReporteDescargar>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    listReporte = context.Database.SqlQuery<ReporteDescargar>(@"EXEC ART_MUSICA_REPORTE_TIPO_ESCUELA").ToList();

                }
                return listReporte;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<ReporteDescargar> ConsultarDetalleGraficaTipoEscuelaHistorico(int periodo)
        {
            List<ReporteDescargar> listReporte = new List<ReporteDescargar>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    listReporte = context.Database.SqlQuery<ReporteDescargar>(@"EXEC ART_MUSICA_REPORTE_TIPO_ESCUELA_HISTORICO @periodo", new SqlParameter("periodo", periodo)).ToList();

                }
                return listReporte;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<ReporteDescargar> ConsultarDetalleGraficaFamiliaInstrumentalHistorico(int periodo)
        {
            List<ReporteDescargar> listReporte = new List<ReporteDescargar>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    listReporte = context.Database.SqlQuery<ReporteDescargar>(@"EXEC ART_MUSICA_REPORTE_FAMILIA_INSTRUMENTAL_DETALLE_HISTORICO @Periodo", new SqlParameter("Periodo", periodo)).ToList();

                }
                return listReporte;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<ReporteDescargar> ConsultarDetalleGraficaFamiliaInstrumental()
        {
            List<ReporteDescargar> listReporte = new List<ReporteDescargar>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    listReporte = context.Database.SqlQuery<ReporteDescargar>(@"EXEC ART_MUSICA_REPORTE_FAMILIA_INSTRUMENTAL_DETALLE").ToList();

                }
                return listReporte;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<ReporteDescargar> ConsultarDetalleGraficaRangosEtarios()
        {
            List<ReporteDescargar> listReporte = new List<ReporteDescargar>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    listReporte = context.Database.SqlQuery<ReporteDescargar>(@"EXEC ART_MUSICA_REPORTE_DETALLE_EDADES").ToList();

                }
                return listReporte;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<ReporteDescargar> ConsultarDetalleGraficaRangosEtariosHistorico(int periodo)
        {
            List<ReporteDescargar> listReporte = new List<ReporteDescargar>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    listReporte = context.Database.SqlQuery<ReporteDescargar>(@"EXEC ART_MUSICA_REPORTE_DETALLE_EDADES_HISTORICO @Periodo", new SqlParameter("Periodo", periodo)).ToList();

                }
                return listReporte;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<ReporteDescargar> ConsultarDetalleGraficaUbicacion()
        {
            List<ReporteDescargar> listReporte = new List<ReporteDescargar>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    listReporte = context.Database.SqlQuery<ReporteDescargar>(@"EXEC ART_MUSICA_REPORTE_DETALLE_UBICACION").ToList();

                }
                return listReporte;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<ReporteDescargar> ConsultarDetalleGraficaUbicacionHistorico(int periodo)
        {
            List<ReporteDescargar> listReporte = new List<ReporteDescargar>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    listReporte = context.Database.SqlQuery<ReporteDescargar>(@"EXEC ART_MUSICA_REPORTE_DETALLE_UBICACION_HISTORICO @Periodo", new SqlParameter("Periodo", periodo)).ToList();

                }
                return listReporte;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<ReporteDescargar> ConsultarDetalleGraficaGrupoEtnico()
        {
            List<ReporteDescargar> listReporte = new List<ReporteDescargar>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    listReporte = context.Database.SqlQuery<ReporteDescargar>(@"EXEC ART_MUSICA_REPORTE_DETALLE_GRUPO_ETNICO").ToList();

                }
                return listReporte;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<ReporteDescargar> ConsultarDetalleGraficaGrupoEtnicoHistorico(int periodo)
        {
            List<ReporteDescargar> listReporte = new List<ReporteDescargar>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    listReporte = context.Database.SqlQuery<ReporteDescargar>(@"EXEC ART_MUSICA_REPORTE_DETALLE_GRUPO_ETNICO_HISTORICO @Periodo", new SqlParameter("Periodo", periodo)).ToList();

                }
                return listReporte;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<ReporteDescargar> ConsultarDetalleGraficaSexo()
        {
            List<ReporteDescargar> listReporte = new List<ReporteDescargar>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    listReporte = context.Database.SqlQuery<ReporteDescargar>(@"EXEC ART_MUSICA_REPORTE_DETALLE_SEXO").ToList();

                }
                return listReporte;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<ReporteDescargar> ConsultarDetalleGraficaSexoHistorico(int periodo)
        {
            List<ReporteDescargar> listReporte = new List<ReporteDescargar>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    listReporte = context.Database.SqlQuery<ReporteDescargar>(@"EXEC ART_MUSICA_REPORTE_DETALLE_SEXO_HISTORICO @Periodo", new SqlParameter("Periodo", periodo)).ToList();

                }
                return listReporte;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<ReporteDescargar> ConsultarDetalleNivelEducativoDocentes()
        {
            List<ReporteDescargar> listReporte = new List<ReporteDescargar>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    listReporte = context.Database.SqlQuery<ReporteDescargar>(@"EXEC ART_MUSICA_REPORTE_DETALLE_DOCENTES").ToList();

                }
                return listReporte;

            }
            catch (Exception)
            {
                throw;
            }
        }


        public static List<ReporteDescargar> ConsultarDetalleNivelEducativoDocentesHistorico(int periodo)
        {
            List<ReporteDescargar> listReporte = new List<ReporteDescargar>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    listReporte = context.Database.SqlQuery<ReporteDescargar>(@"EXEC ART_MUSICA_REPORTE_DETALLE_DOCENTES_HISTORICO @Periodo", new SqlParameter("Periodo", periodo)).ToList();

                }
                return listReporte;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<ReporteDescargar> ConsultarDetalleCirculacion()
        {
            List<ReporteDescargar> listReporte = new List<ReporteDescargar>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    listReporte = context.Database.SqlQuery<ReporteDescargar>(@"EXEC ART_MUSICA_REPORTE_DETALLE_CIRCULACION").ToList();

                }
                return listReporte;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<ReporteDescargar> ConsultarDetalleCirculacionHistorico(int periodo)
        {
            List<ReporteDescargar> listReporte = new List<ReporteDescargar>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    listReporte = context.Database.SqlQuery<ReporteDescargar>(@"EXEC ART_MUSICA_REPORTE_DETALLE_CIRCULACION_HISTORICO @Periodo", new SqlParameter("Periodo", periodo)).ToList();

                }
                return listReporte;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<ReportePractica> ConsultarDetalleGraficaPracticaMusical()
        {
            List<ReportePractica> listReporte = new List<ReportePractica>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    listReporte = context.Database.SqlQuery<ReportePractica>(@"EXEC ART_MUSICA_REPORTE_PRACTICA_MUSICAL_DETALLE").ToList();

                }
                return listReporte;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<ReportePractica> ConsultarDetalleGraficaPracticaMusicalHistorico(int periodo)
        {
            List<ReportePractica> listReporte = new List<ReportePractica>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    listReporte = context.Database.SqlQuery<ReportePractica>(@"EXEC ART_MUSICA_REPORTE_PRACTICA_MUSICAL_DETALLE_HISTORICO @Periodo", new SqlParameter("Periodo", periodo)).ToList();

                }
                return listReporte;

            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
        
        // Métodos deshabilitados - Tabla ART_TIPOS_ESCUELAS no existe en BD
        public static List<ReporteDTO> ObtenerTipoEscuelas()
        {
            return new List<ReporteDTO>();
        }

        public static List<ReporteDTO> ObtenerEscuelasPorTipo()
        {
            return new List<ReporteDTO>();
        }

        public static List<ReporteDTO> ObtenerEscuelasPorTipoHistorico(int periodo)
        {
            return new List<ReporteDTO>();
        }

        public static List<ReporteDTO> ObtenerEscuelasDependeOtraEntidadHistorico(int PeriodoAno)
        {
            var listReporte = new List<ReporteDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    listReporte = (from e in context.ART_MUSICA_HISTORICO_ESCUELAS
                                   where e.Periodo == PeriodoAno
                                   where e.DependeOtraEntidad == true
                                   group e by new { e.Naturaleza } into g
                                   select new ReporteDTO
                                   {
                                       Nombre = g.Key.Naturaleza,
                                       valor = g.Count()

                                   }).ToList();


                }
                return listReporte;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<ReporteDTO> ObtenerEscuelasDependeOtraEntidad()
        {
            var listReporte = new List<ReporteDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    listReporte = (from e in context.ART_ENTIDADES_ARTES
                                   join n in context.ART_ENTIDAD_NATURALEZA_JURIDICA on e.ENT_ID equals n.ENT_ID
                                   where e.ENT_TIPO == "E"
                                   where n.ENT_SINO_ENTIDAD == "S"
                                   group n by new { n.ENT_NATURALEZA } into g
                                   select new ReporteDTO
                                   {
                                       Nombre = g.Key.ENT_NATURALEZA,
                                       valor = g.Count()

                                   }).ToList();


                }
                return listReporte;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<ReporteDTO> ObtenerEscuelasConOrganizacionComunitaria()
        {
            var listReporte = new List<ReporteDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    listReporte = (from e in context.ART_ENTIDADES_ARTES
                                   join n in context.ART_ENTIDAD_NATURALEZA_JURIDICA on e.ENT_ID equals n.ENT_ID
                                   join p in context.ART_MUSICA_ENTIDAD_PARTICIPACION on e.ENT_ID equals p.ENT_ID
                                   where e.ENT_TIPO == "E"
                                   where p.ENT_ORGANIZACION_COMUNITARIA == true
                                   group n by new { n.ENT_NATURALEZA } into g
                                   select new ReporteDTO
                                   {
                                       Nombre = g.Key.ENT_NATURALEZA,
                                       valor = g.Count()

                                   }).ToList();


                }
                return listReporte;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<ReporteDTO> ObtenerEscuelasConOrganizacionComunitariaHistorico(int periodoAno)
        {
            var listReporte = new List<ReporteDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    listReporte = (from e in context.ART_MUSICA_HISTORICO_ESCUELAS
                                   where e.Periodo == periodoAno
                                   where e.OrganizacionComunitaria == true
                                   group e by new { e.Naturaleza } into g
                                   select new ReporteDTO
                                   {
                                       Nombre = g.Key.Naturaleza,
                                       valor = g.Count()

                                   }).ToList();


                }
                return listReporte;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static UbicacionReporte ObtenerTotalEstudiantesUbicacion()
        {
            var listReporte = new UbicacionReporte();
            try
            {
                using (var context = new SIPAEntities())
                {

                    listReporte = context.Database.SqlQuery<UbicacionReporte>(@"EXEC ART_MUSICA_REPORTE_UBICACION_ESTUDIANTES").SingleOrDefault(); ;

                }
                return listReporte;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static UbicacionReporte ObtenerTotalEstudiantesUbicacionHistorico(int periodo)
        {
            var listReporte = new UbicacionReporte();
            try
            {
                using (var context = new SIPAEntities())
                {

                    listReporte = context.Database.SqlQuery<UbicacionReporte>(@"EXEC ART_MUSICA_REPORTE_UBICACION_ESTUDIANTES_HISTORICO @Periodo", new SqlParameter("Periodo", periodo)).SingleOrDefault(); ;

                }
                return listReporte;

            }
            catch (Exception)
            {
                throw;
            }
        }
        
        // Métodos deshabilitados - Tabla ART_TIPOS_ESCUELAS no existe en BD
        public static List<ReporteDTO> ObtenerEscuelasPorTipoYNaturaleza(string strNaturaleza)
        {
            return new List<ReporteDTO>();
        }

        public static List<ReporteDTO> ObtenerEscuelasPorTipoYNaturalezaHistorico(string strNaturaleza, int periodo)
        {
            return new List<ReporteDTO>();
        }

        public static List<ReporteDTO> ObtenerEscuelasPorDepartamento(string codDepto)
        {
            var listReporte = new List<ReporteDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    listReporte = (from e in context.ART_ENTIDADES_ARTES
                                   join n in context.ART_ENTIDAD_NATURALEZA_JURIDICA on e.ENT_ID equals n.ENT_ID
                                   join u in context.ART_ENTIDAD_UBICACION on e.ENT_ID equals u.ENT_ID
                                   join m in context.BAS_ZONAS_GEOGRAFICAS on u.ZON_ID equals m.ZON_ID
                                   where e.ENT_TIPO == "E"
                                   where m.ZON_PADRE_ID == codDepto
                                   group n by new { n.ENT_NATURALEZA } into g
                                   select new ReporteDTO
                                   {
                                       Nombre = g.Key.ENT_NATURALEZA,
                                       valor = g.Count()

                                   }).ToList();


                }
                return listReporte;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<ReporteDTO> ObtenerEscuelasPorDepartamentoHistorico(string codDepto, int periodo)
        {
            var listReporte = new List<ReporteDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    listReporte = (from e in context.ART_MUSICA_HISTORICO_ESCUELAS
                                   where e.Periodo == periodo
                                   where e.CodDepto == codDepto
                                   group e by new { e.Naturaleza } into g
                                   select new ReporteDTO
                                   {
                                       Nombre = g.Key.Naturaleza,
                                       valor = g.Count()

                                   }).ToList();


                }
                return listReporte;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<ReporteDTO> ObtenerEscuelasPorNaturalezaActual()
        {
            var listReporte = new List<ReporteDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    listReporte = (from e in context.ART_ENTIDADES_ARTES
                                   join n in context.ART_ENTIDAD_NATURALEZA_JURIDICA on e.ENT_ID equals n.ENT_ID
                                   where e.ENT_TIPO == "E"
                                   group n by new { n.ENT_NATURALEZA } into g
                                   select new ReporteDTO
                                     {
                                         Nombre = g.Key.ENT_NATURALEZA,
                                         valor = g.Count()

                                     }).ToList();


                }
                return listReporte;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<ReporteDTO> ObtenerEscuelasPorNaturalezaHistorico(int PeriodoAno)
        {
            var listReporte = new List<ReporteDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    listReporte = (from e in context.ART_MUSICA_HISTORICO_ESCUELAS
                                   where e.Periodo == PeriodoAno
                                   group e by new { e.Naturaleza } into g
                                   select new ReporteDTO
                                   {
                                       Nombre = g.Key.Naturaleza,
                                       valor = g.Count()

                                   }).ToList();


                }
                return listReporte;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<ReporteDTO> ObtenerEscuelasLegalmenteConstituidas(bool boolSI)
        {
            var listReporte = new List<ReporteDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    listReporte = (from e in context.ART_ENTIDADES_ARTES
                                   join n in context.ART_ENTIDAD_NATURALEZA_JURIDICA on e.ENT_ID equals n.ENT_ID
                                   join i in context.ART_MUSICA_ENTIDAD_INSTITUCIONALIDAD on e.ENT_ID equals i.ENT_ID
                                   where e.ENT_TIPO == "E"
                                   where i.ENT_CREADA_LEGALMENTE == boolSI
                                   group n by new { n.ENT_NATURALEZA } into g
                                   select new ReporteDTO
                                   {
                                       Nombre = g.Key.ENT_NATURALEZA,
                                       valor = g.Count()

                                   }).ToList();


                }
                return listReporte;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<ReporteDTO> ObtenerEscuelasLegalmenteConstituidasHistorico(int periodo, bool boolSI)
        {
            var listReporte = new List<ReporteDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    listReporte = (from e in context.ART_MUSICA_HISTORICO_ESCUELAS
                                   where e.Periodo == periodo
                                   where e.Legalmente == boolSI
                                   where ((e.Naturaleza == "PUBLICA") || (e.Naturaleza == "PRIVADA") || (e.Naturaleza == "MIXTA"))
                                   group e by new { e.Naturaleza } into g
                                   select new ReporteDTO
                                   {
                                       Nombre = g.Key.Naturaleza,
                                       valor = g.Count()

                                   }).ToList();


                }
                return listReporte;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<ReporteDTO> ObtenerEscuelasPorPracticaMusical(string strNaturaleza)
        {
            var listReporte = new List<ReporteDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    var reporte = context.Database.SqlQuery<BasicoReporte>(@"EXEC ART_MUSICA_ESCUELAS_PRACTICA_MUSICAL @Naturaleza", new SqlParameter("Naturaleza", strNaturaleza));



                    ReporteDTO objbasico = null;
                    foreach (var item in reporte)
                    {
                        objbasico = new ReporteDTO();
                        objbasico.Nombre = item.Nombre;
                        objbasico.valor = item.Value;
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

        public static List<ReporteDTO> ObtenerEscuelasPorPracticaMusicalHistorico(int Periodo, string strNaturaleza)
        {
            var listReporte = new List<ReporteDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    var reporte = context.Database.SqlQuery<PracticaHistoricoDTO>(@"EXEC ART_MUSICA_ESCUELAS_PRACTICA_MUSICAL_HISTORICO @Naturaleza, @Periodo", new SqlParameter("Naturaleza", strNaturaleza), new SqlParameter("Periodo", Periodo)).ToList();



                    ReporteDTO objbasico = null;
                    foreach (var item in reporte)
                    {
                        objbasico = new ReporteDTO();
                        objbasico.Nombre = "Bandas";
                        objbasico.valor = item.Bandas;
                        listReporte.Add(objbasico);

                        objbasico = new ReporteDTO();
                        objbasico.Nombre = "Coros";
                        objbasico.valor = item.Coros;
                        listReporte.Add(objbasico);

                        objbasico = new ReporteDTO();
                        objbasico.Nombre = "Orquesta Sinfónica";
                        objbasico.valor = item.Orquesta;
                        listReporte.Add(objbasico);

                        objbasico = new ReporteDTO();
                        objbasico.Nombre = "Música Tradicionales";
                        objbasico.valor = item.MusicaTradicional;
                        listReporte.Add(objbasico);

                        objbasico = new ReporteDTO();
                        objbasico.Nombre = "Urbana";
                        objbasico.valor = item.Urbana;
                        listReporte.Add(objbasico);

                        objbasico = new ReporteDTO();
                        objbasico.Nombre = "Iniciación";
                        objbasico.valor = item.Iniciacion;
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
        public static List<ReporteDTO> ObtenerEscuelasPorFamiliaInstrumental(string strNaturaleza)
        {
            var listReporte = new List<ReporteDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    var reporte = context.Database.SqlQuery<FamiliaInstrumentalReporte>(@"EXEC ART_MUSICA_REPORTE_FAMILIA_INSTRUMENTAL @Naturaleza", new SqlParameter("Naturaleza", strNaturaleza));



                    ReporteDTO objbasico = null;
                    foreach (var item in reporte)
                    {
                        objbasico = new ReporteDTO();
                        objbasico.Nombre = "Cuerdas Pulsadas";
                        objbasico.valor = item.cuerdapulsada;
                        listReporte.Add(objbasico);

                        objbasico = new ReporteDTO();
                        objbasico.Nombre = "Cuerdas Sinfónicas";
                        objbasico.valor = item.cuerdassinf;
                        listReporte.Add(objbasico);

                        objbasico = new ReporteDTO();
                        objbasico.Nombre = "Vientos Maderas";
                        objbasico.valor = item.vientomadera;
                        listReporte.Add(objbasico);

                        objbasico = new ReporteDTO();
                        objbasico.Nombre = "Vientos Metales";
                        objbasico.valor = item.vientometales;
                        listReporte.Add(objbasico);

                        objbasico = new ReporteDTO();
                        objbasico.Nombre = "Percusión Menor";
                        objbasico.valor = item.pmenor;
                        listReporte.Add(objbasico);


                        objbasico = new ReporteDTO();
                        objbasico.Nombre = "Percusión Sinfónica";
                        objbasico.valor = item.psinfonica;
                        listReporte.Add(objbasico);

                        objbasico = new ReporteDTO();
                        objbasico.Nombre = "Otros Instrumentos";
                        objbasico.valor = item.instrumentootra;
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

        public static List<ReporteDTO> ObtenerEscuelasPorFamiliaInstrumentalHistorico(int periodo, string strNaturaleza)
        {
            var listReporte = new List<ReporteDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    var reporte = context.Database.SqlQuery<FamiliaInstrumentalReporte>(@"EXEC ART_MUSICA_REPORTE_FAMILIA_INSTRUMENTAL_HISTORICO @Naturaleza, @Periodo", new SqlParameter("Naturaleza", strNaturaleza), new SqlParameter("Periodo", periodo));



                    ReporteDTO objbasico = null;
                    foreach (var item in reporte)
                    {
                        objbasico = new ReporteDTO();
                        objbasico.Nombre = "Cuerdas Pulsadas";
                        objbasico.valor = item.cuerdapulsada;
                        listReporte.Add(objbasico);

                        objbasico = new ReporteDTO();
                        objbasico.Nombre = "Cuerdas Sinfónicas";
                        objbasico.valor = item.cuerdassinf;
                        listReporte.Add(objbasico);

                        objbasico = new ReporteDTO();
                        objbasico.Nombre = "Vientos Maderas";
                        objbasico.valor = item.vientomadera;
                        listReporte.Add(objbasico);

                        objbasico = new ReporteDTO();
                        objbasico.Nombre = "Vientos Metales";
                        objbasico.valor = item.vientometales;
                        listReporte.Add(objbasico);

                        objbasico = new ReporteDTO();
                        objbasico.Nombre = "Percusión Menor";
                        objbasico.valor = item.pmenor;
                        listReporte.Add(objbasico);


                        objbasico = new ReporteDTO();
                        objbasico.Nombre = "Percusión Sinfónica";
                        objbasico.valor = item.psinfonica;
                        listReporte.Add(objbasico);

                        objbasico = new ReporteDTO();
                        objbasico.Nombre = "Otros Instrumentos";
                        objbasico.valor = item.instrumentootra;
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

        public static List<ReporteDTO> ObtenerEstudiantesPorRangosEtarios(string strNaturaleza)
        {
            var listReporte = new List<ReporteDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    var reporte = context.Database.SqlQuery<BasicoReporte>(@"EXEC ART_MUSICA_REPORTE_RANGOETARIOS @Naturaleza", new SqlParameter("Naturaleza", strNaturaleza));



                    ReporteDTO objbasico = null;
                    foreach (var item in reporte)
                    {
                        objbasico = new ReporteDTO();
                        objbasico.Nombre = item.Nombre;
                        objbasico.valor = item.Value;
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

        public static List<ReporteDTO> ObtenerEstudiantesPorRangosEtariosHistorico(int periodo, string strNaturaleza)
        {
            var listReporte = new List<ReporteDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    var reporte = context.Database.SqlQuery<RangoETarioReporte>(@"EXEC ART_MUSICA_REPORTE_RANGOETARIOS_HISTORICO @Naturaleza, @Periodo", new SqlParameter("Naturaleza", strNaturaleza), new SqlParameter("Periodo", periodo));



                    ReporteDTO objbasico = null;
                    foreach (var item in reporte)
                    {
                        objbasico = new ReporteDTO();
                        objbasico.Nombre = "Menor de 6 años";
                        objbasico.valor = item.Menor6;
                        listReporte.Add(objbasico);

                        objbasico = new ReporteDTO();
                        objbasico.Nombre = "Entre 7 y 11 años";
                        objbasico.valor = item.Entre7y11;
                        listReporte.Add(objbasico);

                        objbasico = new ReporteDTO();
                        objbasico.Nombre = "Entre 12 y 18 años";
                        objbasico.valor = item.Entre12y18;
                        listReporte.Add(objbasico);

                        objbasico = new ReporteDTO();
                        objbasico.Nombre = "Entre 19 y 25 años";
                        objbasico.valor = item.Entre19y25;
                        listReporte.Add(objbasico);

                        objbasico = new ReporteDTO();
                        objbasico.Nombre = "Entre 26 y 60 años";
                        objbasico.valor = item.Entre26y60;
                        listReporte.Add(objbasico);

                        objbasico = new ReporteDTO();
                        objbasico.Nombre = "Mayor de 60 años";
                        objbasico.valor = item.Mayor60;
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
        public static List<ReporteDTO> ObtenerEstudiantesPorUbicacion(string strNaturaleza)
        {
            var listReporte = new List<ReporteDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    var reporte = context.Database.SqlQuery<BasicoReporte>(@"EXEC ART_MUSICA_REPORTE_UBICACION @Naturaleza", new SqlParameter("Naturaleza", strNaturaleza));



                    ReporteDTO objbasico = null;
                    foreach (var item in reporte)
                    {
                        objbasico = new ReporteDTO();
                        objbasico.Nombre = item.Nombre;
                        objbasico.valor = item.Value;
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

        public static List<ReporteDTO> ObtenerEstudiantesPorUbicacionUrbana()
        {
            var listReporte = new List<ReporteDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    var reporte = context.Database.SqlQuery<BasicoReporte>(@"EXEC ART_MUSICA_REPORTE_URBANA");



                    ReporteDTO objbasico = null;
                    foreach (var item in reporte)
                    {
                        objbasico = new ReporteDTO();
                        objbasico.Nombre = item.Nombre;
                        objbasico.valor = item.Value;
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

        public static List<ReporteDTO> ObtenerEstudiantesPorUbicacionUrbanaHistorico(int periodo)
        {
            var listReporte = new List<ReporteDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    var reporte = context.Database.SqlQuery<BasicoReporte>(@"EXEC ART_MUSICA_REPORTE_URBANA_HISTORICO @Periodo", new SqlParameter("Periodo", periodo));

                    ReporteDTO objbasico = null;
                    foreach (var item in reporte)
                    {
                        objbasico = new ReporteDTO();
                        objbasico.Nombre = item.Nombre;
                        objbasico.valor = item.Value;
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

        public static List<ReporteDTO> ObtenerEstudiantesPorUbicacionRuralHistorico(int periodo)
        {
            var listReporte = new List<ReporteDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    var reporte = context.Database.SqlQuery<BasicoReporte>(@"EXEC ART_MUSICA_REPORTE_RURAL_HISTORICO @Periodo", new SqlParameter("Periodo", periodo));

                    ReporteDTO objbasico = null;
                    foreach (var item in reporte)
                    {
                        objbasico = new ReporteDTO();
                        objbasico.Nombre = item.Nombre;
                        objbasico.valor = item.Value;
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

        public static List<ReporteDTO> ObtenerEstudiantesPorSexoMasculinoHistorico(int periodo)
        {
            var listReporte = new List<ReporteDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    var reporte = context.Database.SqlQuery<BasicoReporte>(@"EXEC ART_MUSICA_REPORTE_MASCULINO_HISTORICO @Periodo", new SqlParameter("Periodo", periodo));

                    ReporteDTO objbasico = null;
                    foreach (var item in reporte)
                    {
                        objbasico = new ReporteDTO();
                        objbasico.Nombre = item.Nombre;
                        objbasico.valor = item.Value;
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

        public static List<ReporteDTO> ObtenerEstudiantesPorSexoFemeninoHistorico(int periodo)
        {
            var listReporte = new List<ReporteDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    var reporte = context.Database.SqlQuery<BasicoReporte>(@"EXEC ART_MUSICA_REPORTE_FEMENINO_HISTORICO @Periodo", new SqlParameter("Periodo", periodo));

                    ReporteDTO objbasico = null;
                    foreach (var item in reporte)
                    {
                        objbasico = new ReporteDTO();
                        objbasico.Nombre = item.Nombre;
                        objbasico.valor = item.Value;
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
        public static List<ReporteDTO> ObtenerEstudiantesPorUbicacionRural()
        {
            var listReporte = new List<ReporteDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    var reporte = context.Database.SqlQuery<BasicoReporte>(@"EXEC ART_MUSICA_REPORTE_RURAL");



                    ReporteDTO objbasico = null;
                    foreach (var item in reporte)
                    {
                        objbasico = new ReporteDTO();
                        objbasico.Nombre = item.Nombre;
                        objbasico.valor = item.Value;
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

        public static List<ReporteDTO> ObtenerEstudiantesPorSexoMasculino()
        {
            var listReporte = new List<ReporteDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    var reporte = context.Database.SqlQuery<BasicoReporte>(@"EXEC ART_MUSICA_REPORTE_MASCULINO");



                    ReporteDTO objbasico = null;
                    foreach (var item in reporte)
                    {
                        objbasico = new ReporteDTO();
                        objbasico.Nombre = item.Nombre;
                        objbasico.valor = item.Value;
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
        public static List<ReporteDTO> ObtenerEstudiantesPorSexoFemenino()
        {
            var listReporte = new List<ReporteDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    var reporte = context.Database.SqlQuery<BasicoReporte>(@"EXEC ART_MUSICA_REPORTE_FEMENINO");



                    ReporteDTO objbasico = null;
                    foreach (var item in reporte)
                    {
                        objbasico = new ReporteDTO();
                        objbasico.Nombre = item.Nombre;
                        objbasico.valor = item.Value;
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

        public static List<ReporteDTO> ObtenerEstudiantesPorSexo(string strNaturaleza)
        {
            var listReporte = new List<ReporteDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    var reporte = context.Database.SqlQuery<BasicoReporte>(@"EXEC ART_MUSICA_REPORTE_SEXO @Naturaleza", new SqlParameter("Naturaleza", strNaturaleza));



                    ReporteDTO objbasico = null;
                    foreach (var item in reporte)
                    {
                        objbasico = new ReporteDTO();
                        objbasico.Nombre = item.Nombre;
                        objbasico.valor = item.Value;
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

        public static List<ReporteDTO> ObtenerEstudiantesPorGrupoEtnico(string strNaturaleza)
        {
            var listReporte = new List<ReporteDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    var reporte = context.Database.SqlQuery<BasicoReporte>(@"EXEC ART_MUSICA_REPORTE_GRUPO_ETNICO @Naturaleza", new SqlParameter("Naturaleza", strNaturaleza));



                    ReporteDTO objbasico = null;
                    foreach (var item in reporte)
                    {
                        objbasico = new ReporteDTO();
                        objbasico.Nombre = item.Nombre;
                        objbasico.valor = item.Value;
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

        public static List<ReporteDTO> ObtenerEstudiantesPorGrupoEtnicoHistorico(int periodo, string strNaturaleza)
        {
            var listReporte = new List<ReporteDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    var reporte = context.Database.SqlQuery<GrupoEtnicoReporte>(@"EXEC ART_MUSICA_REPORTE_GRUPO_ETNICO_HISTORICO @Naturaleza, @Periodo", new SqlParameter("Naturaleza", strNaturaleza), new SqlParameter("Periodo", periodo));



                    ReporteDTO objbasico = null;
                    foreach (var item in reporte)
                    {
                        objbasico = new ReporteDTO();
                        objbasico.Nombre = "Afrocolombiana";
                        objbasico.valor = item.PoblacionAfro;
                        listReporte.Add(objbasico);

                        objbasico = new ReporteDTO();
                        objbasico.Nombre = "Indígenas";
                        objbasico.valor = item.PoblacionIndigena;
                        listReporte.Add(objbasico);

                        objbasico = new ReporteDTO();
                        objbasico.Nombre = "Raizales";
                        objbasico.valor = item.PoblacionRaizales;
                        listReporte.Add(objbasico);

                        objbasico = new ReporteDTO();
                        objbasico.Nombre = "ROM";
                        objbasico.valor = item.PoblacionRom;
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
        public static List<ReporteDTO> ObtenerEscuelasPorNivelEducativoDocentes(string strNaturaleza)
        {
            var listReporte = new List<ReporteDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    var reporte = context.Database.SqlQuery<NivelEducativoReporte>(@"EXEC ART_MUSICA_REPORTE_DOCENTE_EDUCACION @Naturaleza", new SqlParameter("Naturaleza", strNaturaleza));



                    ReporteDTO objbasico = null;
                    foreach (var item in reporte)
                    {
                        objbasico = new ReporteDTO();
                        objbasico.Nombre = "Primaria";
                        objbasico.valor = item.primaria;
                        listReporte.Add(objbasico);

                        objbasico = new ReporteDTO();
                        objbasico.Nombre = "Secundaria";
                        objbasico.valor = item.secundaria;
                        listReporte.Add(objbasico);

                        objbasico = new ReporteDTO();
                        objbasico.Nombre = "Técnico";
                        objbasico.valor = item.tecnico;
                        listReporte.Add(objbasico);

                        objbasico = new ReporteDTO();
                        objbasico.Nombre = "Pregrado Incompleto";
                        objbasico.valor = item.universiatrio;
                        listReporte.Add(objbasico);

                        objbasico = new ReporteDTO();
                        objbasico.Nombre = "Pregrado de Música";
                        objbasico.valor = item.pregradomusica;
                        listReporte.Add(objbasico);


                        objbasico = new ReporteDTO();
                        objbasico.Nombre = "Pregrado Otra Área";
                        objbasico.valor = item.pregradootra;
                        listReporte.Add(objbasico);

                        objbasico = new ReporteDTO();
                        objbasico.Nombre = "Posgrado";
                        objbasico.valor = item.postgrado;
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

        public static List<ReporteDTO> ObtenerEscuelasPorNivelEducativoDocentesHistorico(int periodo, string strNaturaleza)
        {
            var listReporte = new List<ReporteDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    var reporte = context.Database.SqlQuery<NivelEducativoReporte>(@"EXEC ART_MUSICA_REPORTE_DOCENTE_EDUCACION_HISTORICO @Naturaleza, @Periodo ", new SqlParameter("Naturaleza", strNaturaleza), new SqlParameter("Periodo", periodo));



                    ReporteDTO objbasico = null;
                    foreach (var item in reporte)
                    {
                        objbasico = new ReporteDTO();
                        objbasico.Nombre = "Primaria";
                        objbasico.valor = item.primaria;
                        listReporte.Add(objbasico);

                        objbasico = new ReporteDTO();
                        objbasico.Nombre = "Secundaria";
                        objbasico.valor = item.secundaria;
                        listReporte.Add(objbasico);

                        objbasico = new ReporteDTO();
                        objbasico.Nombre = "Técnico";
                        objbasico.valor = item.tecnico;
                        listReporte.Add(objbasico);

                        objbasico = new ReporteDTO();
                        objbasico.Nombre = "Pregrado Incompleto";
                        objbasico.valor = item.universiatrio;
                        listReporte.Add(objbasico);

                        objbasico = new ReporteDTO();
                        objbasico.Nombre = "Pregrado de Música";
                        objbasico.valor = item.pregradomusica;
                        listReporte.Add(objbasico);


                        objbasico = new ReporteDTO();
                        objbasico.Nombre = "Pregrado Otra Área";
                        objbasico.valor = item.pregradootra;
                        listReporte.Add(objbasico);

                        objbasico = new ReporteDTO();
                        objbasico.Nombre = "Posgrado";
                        objbasico.valor = item.postgrado;
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

        public static List<ReporteDTO> ObtenerEscuelasPorProduccion(string strNaturaleza)
        {
            var listReporte = new List<ReporteDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    var reporte = context.Database.SqlQuery<ProduccionReporte>(@"EXEC ART_MUSICA_REPORTE_PRODUCCION @Naturaleza", new SqlParameter("Naturaleza", strNaturaleza));

                    ReporteDTO objbasico = null;
                    foreach (var item in reporte)
                    {
                        objbasico = new ReporteDTO();
                        objbasico.Nombre = "Locales";
                        objbasico.valor = item.giraLocales;
                        listReporte.Add(objbasico);

                        objbasico = new ReporteDTO();
                        objbasico.Nombre = "Nacionales";
                        objbasico.valor = item.nacional;
                        listReporte.Add(objbasico);

                        objbasico = new ReporteDTO();
                        objbasico.Nombre = "Internacionales";
                        objbasico.valor = item.internacional;
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

        public static List<ReporteDTO> ObtenerEscuelasPorProduccionHistorico(int periodo, string strNaturaleza)
        {
            var listReporte = new List<ReporteDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    var reporte = context.Database.SqlQuery<ProduccionReporte>(@"EXEC ART_MUSICA_REPORTE_PRODUCCION_HISTORICO @Naturaleza, @Periodo", new SqlParameter("Naturaleza", strNaturaleza), new SqlParameter("Periodo", periodo));

                    ReporteDTO objbasico = null;
                    foreach (var item in reporte)
                    {
                        objbasico = new ReporteDTO();
                        objbasico.Nombre = "Locales";
                        objbasico.valor = item.giraLocales;
                        listReporte.Add(objbasico);

                        objbasico = new ReporteDTO();
                        objbasico.Nombre = "Nacionales";
                        objbasico.valor = item.nacional;
                        listReporte.Add(objbasico);

                        objbasico = new ReporteDTO();
                        objbasico.Nombre = "Internacionales";
                        objbasico.valor = item.internacional;
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

        public static List<ReporteDTO> ObtenerTotalEstudiantesPorNaturaleza()
        {
            var listReporte = new List<ReporteDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    var reporte = context.Database.SqlQuery<BasicoReporte>(@"EXEC ART_MUSICA_REPORTE_TOTAL_ALUMNOS");



                    ReporteDTO objbasico = null;
                    foreach (var item in reporte)
                    {
                        objbasico = new ReporteDTO();
                        objbasico.Nombre = item.Nombre;
                        objbasico.valor = item.Value;
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

        public static List<ReporteDTO> ObtenerTotalEstudiantesPorNaturalezaHistorico(int periodo)
        {
            var listReporte = new List<ReporteDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    var reporte = context.Database.SqlQuery<BasicoReporte>(@"EXEC ART_MUSICA_REPORTE_TOTAL_ALUMNOS_HISTORICO @Periodo", new SqlParameter("Periodo", periodo));



                    ReporteDTO objbasico = null;
                    foreach (var item in reporte)
                    {
                        objbasico = new ReporteDTO();
                        objbasico.Nombre = item.Nombre;
                        objbasico.valor = item.Value;
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

        public static List<ReporteDTO> ObtenerTotalDocentesPorNaturaleza()
        {
            var listReporte = new List<ReporteDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    var reporte = context.Database.SqlQuery<BasicoReporte>(@"EXEC ART_MUSICA_REPORTE_TOTAL_DOCENTES");



                    ReporteDTO objbasico = null;
                    foreach (var item in reporte)
                    {
                        objbasico = new ReporteDTO();
                        objbasico.Nombre = item.Nombre;
                        objbasico.valor = item.Value;
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

        public static List<ReporteDTO> ObtenerTotalDocentesPorNaturalezaHistorico(int periodo)
        {
            var listReporte = new List<ReporteDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    var reporte = context.Database.SqlQuery<BasicoReporte>(@"EXEC ART_MUSICA_REPORTE_TOTAL_DOCENTES_HISTORICO @Periodo", new SqlParameter("Periodo", periodo));



                    ReporteDTO objbasico = null;
                    foreach (var item in reporte)
                    {
                        objbasico = new ReporteDTO();
                        objbasico.Nombre = item.Nombre;
                        objbasico.valor = item.Value;
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
    }
}
