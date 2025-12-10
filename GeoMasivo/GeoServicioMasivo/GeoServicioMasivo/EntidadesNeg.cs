using SM.SIPA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoServicioMasivo
{
    public static class EntidadesNeg
    {
        public static List<GeoServicioMasivo.ServicioMasivoNeg.Encabezado> ConsultarEntidades()
        {
            var listBasica = new List<GeoServicioMasivo.ServicioMasivoNeg.Encabezado>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    listBasica = (from a in context.ART_MUSICA_ENTIDADES 
                                  where a.Id >= 1400
                                  where a.Id <= 1600
                                  select new GeoServicioMasivo.ServicioMasivoNeg.Encabezado
                                  {
                                      identificador = a.Id.ToString(),
                                      ciudad = a.CodigoMunicipio,
                                      direccion = a.Direccion
                                  }).ToList();

                }
                return listBasica;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void ActualizarEntidad(int Id, string Latitud, string Longitud)
        {

            try
            {
                using (var context = new SIPAEntities())
                {

                    var registro = context.ART_MUSICA_ENTIDADES.Where(x => x.Id == Id).FirstOrDefault();

                    if (registro != null)
                    {
                        registro.Latitud = Latitud;
                        registro.Longitud = Longitud;
                    }
                    context.SaveChanges();
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
