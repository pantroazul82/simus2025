using SM.Datos.DTO.Geo;
using SM.SIPA;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace SM.Datos.Geo
{
    public static class PatGeoServicio
    {

        public static List<PatGeoResultDTO> ConsultarInmuebles()
        {
            var listResultado = new List<PatGeoResultDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    listResultado = context.Database.SqlQuery<PatGeoResultDTO>(@"EXEC PAT_GEO_INMUEBLES").ToList();

                }
                return listResultado;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<PatGeoResultDTO> ConsultarInmueblesPorCodigoDepartamento(string codDepto)
        {
            var listResultado = new List<PatGeoResultDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    listResultado = context.Database.SqlQuery<PatGeoResultDTO>(@"EXEC PAT_GEO_INMUEBLES @CODDEPTO", new SqlParameter("CODDEPTO", codDepto)).ToList();

                  
                }
                return listResultado;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<PatGeoResultDTO> ConsultarInmueblesPorCodigoMunicipio(string codMunicipio)
        {
            var listResultado = new List<PatGeoResultDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    listResultado = context.Database.SqlQuery<PatGeoResultDTO>(@"EXEC PAT_GEO_INMUEBLES_COD_MUNICIPIO @CODMUNICIPIO", new SqlParameter("CODMUNICIPIO", codMunicipio)).ToList();


                }
                return listResultado;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
