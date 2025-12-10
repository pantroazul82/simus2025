using SM.SIPA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoServicioMasivo
{
    public static class EscuelasNeg
    {
        public static List<GeoServicioMasivo.ServicioMasivoNeg.Encabezado> ConsultarEscuelas()
        {
            var listBasica = new List<GeoServicioMasivo.ServicioMasivoNeg.Encabezado>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    listBasica = (from e in context.ART_ENTIDADES_ARTES 
                                  join u in context.ART_ENTIDAD_UBICACION on e.ENT_ID  equals u.ENT_ID
                                  where e.ENT_TIPO == "E"
                                  where e.ENT_ID >= 132496
                                  where e.ENT_ID <= 142581
                                  select new GeoServicioMasivo.ServicioMasivoNeg.Encabezado
                                  {
                                      identificador = e.ENT_ID.ToString(),
                                      ciudad = u.ZON_ID ,
                                      direccion = u.ENT_DIRECCION,
                                  }).ToList();

                }
                return listBasica;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void ActualizarEscuelas(int Id, string Latitud, string Longitud)
        {

            try
            {
                using (var context = new SIPAEntities())
                {

                    var registro = context.ART_ENTIDAD_UBICACION.Where(x => x.ENT_ID  == Id).FirstOrDefault();
                    Latitud = Latitud.Replace(".", ",");
                    Longitud = Longitud.Replace(".", ",");
                    double dlatidud = Convert.ToDouble(Latitud);
                    double dlongitud = Convert.ToDouble(Longitud);

                    if (registro != null)
                    {
                        registro.ENT_LATITUD = dlatidud;
                        registro.ENT_LONGITUD = dlongitud;
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
