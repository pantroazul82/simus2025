using SM.SIPA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GeoServicioMasivo
{
    public static class AgrupacionNeg
    {
        public static List<GeoServicioMasivo.ServicioMasivoNeg.Encabezado> ConsultarAgrupaciones()
        {
            var listBasica = new List<GeoServicioMasivo.ServicioMasivoNeg.Encabezado>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    listBasica = (from a in context.ART_MUSICA_AGRUPACION
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

        public static void ActualizarAgrupacion(int Id, string Latitud, string Longitud)
        {

            try
            {
                using (var context = new SIPAEntities())
                {

                    var agrupacion = context.ART_MUSICA_AGRUPACION.Where(x => x.Id == Id).FirstOrDefault();

                    if (agrupacion != null)
                    {
                        agrupacion.Latitud = Latitud;
                        agrupacion.Longitud = Longitud;
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
