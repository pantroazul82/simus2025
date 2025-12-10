using SM.SIPA;
using System;
using System.Collections.Generic;
using System.Linq;
using SM.Datos.DTO.Geo;
using System.Data.SqlClient;

namespace SM.Datos.Geo
{
   public static  class GeoServicio
    {
    

       public static List<AgentesGeoResultadoDTO> ConsultarAgentes()
       {
           var listResultado = new List<AgentesGeoResultadoDTO>();
           try
           {
               using (var context = new SIPAEntities())
               {

                   listResultado = context.Database.SqlQuery<AgentesGeoResultadoDTO>(@"EXEC ART_MUSICA_AGENTES_MAPAS").ToList();

               }
               return listResultado;
           }
           catch (Exception)
           {
               throw;
           }
       }

       public static List<CelebraResultadoDptoDTO> ConsultarAgentesPorDepartamento()
       {
           var listResultado = new List<CelebraResultadoDptoDTO>();
           try
           {
               using (var context = new SIPAEntities())
               {

                   listResultado = context.Database.SqlQuery<CelebraResultadoDptoDTO>(@"EXEC ART_MUSICA_AGENTES_MAPAS_POR_DEPARTAMENTO").ToList();

               }
               return listResultado;

           }
           catch (Exception)
           {
               throw;
           }
       }

       public static List<AgenteMunicipioResultadoDTO> ConsultarAgentesPoMunicipio(string CodDeparamento)
       {
           var listResultado = new List<AgenteMunicipioResultadoDTO>();
           try
           {
               using (var context = new SIPAEntities())
               {

                   listResultado = context.Database.SqlQuery<AgenteMunicipioResultadoDTO>(@"EXEC ART_MUSICA_AGENTES_POR_MUNICIPIO @CodDepto", new SqlParameter("CodDepto", CodDeparamento)).ToList();


               }
               return listResultado;

           }
           catch (Exception)
           {
               throw;
           }
       }
       public static List<EntidadesGeoResultadoDTO> ConsultarEntidades()
       {
           var listResultado = new List<EntidadesGeoResultadoDTO>();
           try
           {
               using (var context = new SIPAEntities())
               {

                   listResultado = context.Database.SqlQuery<EntidadesGeoResultadoDTO>(@"EXEC ART_MUSICA_ENTIDADES_MAPAS").ToList();

               }
               return listResultado;
           }
           catch (Exception)
           {
               throw;
           }
       }

       public static List<EntidadesGeoResultadoDTO> ConsultarEntidadesPorCodigoMunicipio(string codMunicipio)
       {
           var listResultado = new List<EntidadesGeoResultadoDTO>();
           try
           {
               using (var context = new SIPAEntities())
               {

                   listResultado = context.Database.SqlQuery<EntidadesGeoResultadoDTO>(@"EXEC ART_MUSICA_ENTIDADES_MAPAS_CODIGO_MUNICIPIO @CODMUNICIPIO",new SqlParameter("CODMUNICIPIO", codMunicipio)).ToList();

               }
               return listResultado;
           }
           catch (Exception)
           {
               throw;
           }
       }
       public static List<AgrupacionGeoResultadoDTO> ConsultarAgrupaciones()
       {
           var listResultado = new List<AgrupacionGeoResultadoDTO>();
           try
           {
               using (var context = new SIPAEntities())
               {

                   listResultado = context.Database.SqlQuery<AgrupacionGeoResultadoDTO>(@"EXEC ART_MUSICA_AGRUPACIONES_MAPAS").ToList();

               }
               return listResultado;
           }
           catch (Exception)
           {
               throw;
           }
       }

       public static List<AgrupacionGeoResultadoDTO> ConsultarAgrupacionesPorCodigoMunicipio(string codMunicipio)
       {
           var listResultado = new List<AgrupacionGeoResultadoDTO>();
           try
           {
               using (var context = new SIPAEntities())
               {

                   listResultado = context.Database.SqlQuery<AgrupacionGeoResultadoDTO>(@"EXEC ART_MUSICA_AGRUPACIONES_MAPAS_CODIGO_MUNICIPIO @CODMUNICIPIO", new SqlParameter("CODMUNICIPIO", codMunicipio)).ToList();

               }
               return listResultado;
           }
           catch (Exception)
           {
               throw;
           }
       }

        #region EscuelasMusica
       public static List<EscuelasGeoResultadoDto> ConsultarEscuelas()
       {

           var listResultado = new List<EscuelasGeoResultadoDto>();
           try
           {
               using (var context = new SIPAEntities())
               {


                   listResultado = context.Database.SqlQuery<EscuelasGeoResultadoDto>(@"EXEC ART_MUSICA_GEO_ESCUELAS").ToList();


               }
               return listResultado;

           }
           catch (Exception)
           {
               throw;
           }
       }

       public static List<EscuelasGeoResultadoDto> ConsultarEscuelasPorCodigoMunicipio(string codMunicipio)
       {

           var listResultado = new List<EscuelasGeoResultadoDto>();
           try
           {
               using (var context = new SIPAEntities())
               {


                   listResultado = context.Database.SqlQuery<EscuelasGeoResultadoDto>(@"EXEC ART_MUSICA_GEO_ESCUELAS_CODMUNICIPIO @CODMUNICIPIO", new SqlParameter("CODMUNICIPIO", codMunicipio)).ToList();


               }
               return listResultado;

           }
           catch (Exception)
           {
               throw;
           }
       }
       public static List<CelebraResultadoDptoDTO> ConsultarEscuelasPorDepartamento()
       {

           var listResultado = new List<CelebraResultadoDptoDTO>();
           try
           {
               using (var context = new SIPAEntities())
               {


                   listResultado = context.Database.SqlQuery<CelebraResultadoDptoDTO>(@"EXEC ART_MUSICA_CANTIDAD_ESCUELAS_POR_DEPARTAMENTO").ToList();


               }
               return listResultado;

           }
           catch (Exception)
           {
               throw;
           }
       }

       public static List<CelebraResultadoDptoDTO> ConsultarEscuelasPorDepartamentoHistorico(int periodo)
       {

           var listResultado = new List<CelebraResultadoDptoDTO>();
           try
           {
               using (var context = new SIPAEntities())
               {


                   listResultado = context.Database.SqlQuery<CelebraResultadoDptoDTO>(@"EXEC ART_MUSICA_CANTIDAD_ESCUELAS_DEPARTAMENTO_HISTORICO @Periodo", new SqlParameter("Periodo", periodo)).ToList();


               }
               return listResultado;

           }
           catch (Exception)
           {
               throw;
           }
       }
       public static List<MunicipioEscuelaResultadoDTO> ConsultarEscuelasPorMunicipio()
       {

           var listResultado = new List<MunicipioEscuelaResultadoDTO>();
           try
           {
               using (var context = new SIPAEntities())
               {


                   listResultado = context.Database.SqlQuery<MunicipioEscuelaResultadoDTO>(@"EXEC ART_MUSICA_CANTIDAD_ESCUELAS_POR_MUNICIPIO").ToList();


               }
               return listResultado;

           }
           catch (Exception)
           {
               throw;
           }
       }

       public static List<MunicipioEscuelaResultadoDTO> ConsultarDatosEscuelasPoMunicipio(string CodDeparamento)
       {
           var listResultado = new List<MunicipioEscuelaResultadoDTO>();
           try
           {
               using (var context = new SIPAEntities())
               {

                   listResultado = context.Database.SqlQuery<MunicipioEscuelaResultadoDTO>(@"EXEC ART_MUSICA_ESCUELAS_COD_MUNICIPIO @CodDepto", new SqlParameter("CodDepto", CodDeparamento)).ToList();


               }
               return listResultado;

           }
           catch (Exception)
           {
               throw;
           }
       }
        #endregion


    }
}
