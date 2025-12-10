using SM.SIPA;
using System;
using System.Collections.Generic;
using System.Linq;
using SM.Datos.DTO.Geo;
using System.Data.SqlClient;

namespace SM.Datos.Geo
{
    public static class CelebraGeoServicio
    {
        public static List<CelebraGeoResultadoDTO> ConsultarConciertosCelebra(int intAno)
        {
            var listResultado = new List<CelebraGeoResultadoDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    listResultado = context.Database.SqlQuery<CelebraGeoResultadoDTO>(@"EXEC ART_MUSICA_CELEBRA_MAPAS @paramAno", new SqlParameter("paramAno", intAno)).ToList();

                }
                return listResultado;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public static List<CantidadMunicipiosPorDeptoDTO> ConsultarCantidadDepartamentos()
        {
            var listResultado = new List<CantidadMunicipiosPorDeptoDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    listResultado = context.Database.SqlQuery<CantidadMunicipiosPorDeptoDTO>(@"EXEC ART_MUSICA_CANTIDAD_DEPARTAMENTO").ToList();

                }
                return listResultado;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<CelebraResultadoDptoDTO> ConsultarCantidadConciertosPorDepto(int intAno)
        {
            var listResultado = new List<CelebraResultadoDptoDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    listResultado = context.Database.SqlQuery<CelebraResultadoDptoDTO>(@"EXEC ART_MUSICA_CELEBRA_POR_DEPARTAMENTO @paramAno", new SqlParameter("paramAno", intAno)).ToList();

                }
                return listResultado;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public static List<CelebraResultadoMunDTO> ConsultarCantidadConciertosPorMun(string codDepto, int filtroAno)
        {
            var listResultado = new List<CelebraResultadoMunDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    listResultado = context.Database.SqlQuery<CelebraResultadoMunDTO>(@"EXEC ART_MUSICA_CELEBRA_POR_MUNICIPIO_FILTRO_POR_ANO @CodDepto, @filtroAno", new SqlParameter("CodDepto", codDepto), new SqlParameter("filtroAno", filtroAno)).ToList();

                }
                return listResultado;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int CantidadMunicipiosPorDepto(string codDepto)
        {
            int Cantidad = 0;
            try
            {
                using (var context = new SIPAEntities())
                {

                    Cantidad = context.BAS_ZONAS_GEOGRAFICAS.Where(x => x.ZON_PADRE_ID == codDepto && x.EsCorrimiento == false).Count();

                }
                return Cantidad;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<ART_MUSICA_EVENTOS> ConsultarConciertos(int intAno)
        {

            try
            {
                using (var context = new SIPAEntities())
                {

                    var listResultado = context.ART_MUSICA_EVENTOS.Where(x => x.AnoEvento == intAno && x.AreaArtisticaId == 15).ToList();

                    return listResultado;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<ConciertoResultadoDetalleDTO> ConsultarConciertosPorMunicipio(int intAno, string codMunicipio)
        {

            try
            {
                using (var context = new SIPAEntities())
                {

                    var listResultado = context.ART_MUSICA_EVENTOS.Where(x => x.AreaArtisticaId == 15 && x.EstadoId == 2 && x.AnoEvento == intAno && x.CodMunicipio == codMunicipio).Select(x => new ConciertoResultadoDetalleDTO
                 {
                     CodMunicipio = x.CodMunicipio,
                     ConciertoId = x.Id,
                     Departamento = x.NombreDepartamento,
                     Municipio = x.NombreMunicipio,
                     EntidadOrganizadora = x.EntidadOrganizadora,
                     Lugar = x.LugarEvento,
                     FechaEvento = x.FechaEvento
                 }).ToList();

                    return listResultado;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
