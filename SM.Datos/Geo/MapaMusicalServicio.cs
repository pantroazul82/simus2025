using SM.Datos.DTO.Geo;
using SM.SIPA;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Datos.Geo
{
    public static class MapaMusicalServicio
    {
        public static List<TradicionalMunicipioResultadoDTO> ConsultarMunicipiosMusicaTradicional()
        {
            var listResultado = new List<TradicionalMunicipioResultadoDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    listResultado = context.Database.SqlQuery<TradicionalMunicipioResultadoDTO>(@"EXEC ART_MUSICA_TRADICIONAL_OBTENER_MUNICIPIOS").ToList();

                }
                return listResultado;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<TradicionalMunicipioResultadoDTO> ConsultarMunicipiosMusicaTradicionalPorCodigo(string codMunicipio)
        {
            var listResultado = new List<TradicionalMunicipioResultadoDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    listResultado = context.Database.SqlQuery<TradicionalMunicipioResultadoDTO>(@"EXEC ART_MUSICA_TRADICIONAL_OBTENER_MUNICIPIOS_POR_CODIGO @CODMUNICIPIO", new SqlParameter("CODMUNICIPIO", codMunicipio)).ToList();

                }
                return listResultado;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<TradicionalGeneroResultadoDTO> ConsultarGenerosMusicaTradicional()
        {
            var listResultado = new List<TradicionalGeneroResultadoDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    listResultado = context.Database.SqlQuery<TradicionalGeneroResultadoDTO>(@"EXEC ART_MUSICA_TRADICIONAL_OBTENER_GENEROS").ToList();

                }
                return listResultado;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public static List<TradicionalGeneroResultadoDTO> ConsultarGenerosMusicaTradicionalModal(int EjeID, string Codigo)
        {
            var listResultado = new List<TradicionalGeneroResultadoDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    listResultado = context.Database.SqlQuery<TradicionalGeneroResultadoDTO>(@"EXEC ART_MUSICA_TRADICIONAL_OBTENER_GENEROS_MODAL @EJEID, @codigo", new SqlParameter("EJEID", EjeID), new SqlParameter("codigo", Codigo)).ToList();

                }
                return listResultado;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static ART_MUSICA_EJES ConsultarEJeResena(int Id)
        {
            var registro = new ART_MUSICA_EJES();
            try
            {
                using (var context = new SIPAEntities())
                {

                    registro = context.ART_MUSICA_EJES.Where(x => x.Id == Id).FirstOrDefault();

                }
                return registro;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<TradicionalGeneroResultadoDTO> ConsultarGenerosPorEjeId(int Id)
        {

            var listResultado = new List<TradicionalGeneroResultadoDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    listResultado = (from g in context.ART_MUSICA_TRADICIONAL_GENEROS
                                     join a in context.ART_MUSICA_TRADICIONAL_AUDIOS on g.Id equals a.GeneroId
                                     where g.EjeId == Id
                                     where a.EstadoId == true
                                     select new TradicionalGeneroResultadoDTO
                               {
                                  Detalle = a.Detalle,
                                  Genero = g.Nombre,
                                  IdEje = g.EjeId ?? 0,
                                  GeneroId = g.Id,
                                  NombreArchivo = a.NombreArchivo,
                                  Ruta = a.Ruta,
                                  Titulo = a.Titulo

                               }).ToList();


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
