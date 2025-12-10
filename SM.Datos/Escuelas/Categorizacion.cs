using SM.SIPA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Datos.Escuelas
{
    public class Categorizacion
    {
        public static List<ART_MUSICA_VALORES_CATEGORIZACION_Result> ConsultarCategorizacionPorEscuela(decimal EntId)
        {
            var resultado = new List<ART_MUSICA_VALORES_CATEGORIZACION_Result>();
            try
            {
                using (var context = new SIPAEntities())
                {
                    resultado = context.ART_MUSICA_VALORES_CATEGORIZACION(EntId).ToList();

                }
                return resultado;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static ART_MUSICA_NOMBRE_CATEGORIA_Result ConsultarNombreEscuela(decimal EntId)
        {
            var resultado = new ART_MUSICA_NOMBRE_CATEGORIA_Result();
            try
            {
                using (var context = new SIPAEntities())
                {
                    resultado = context.ART_MUSICA_NOMBRE_CATEGORIA(EntId).FirstOrDefault();

                }
                return resultado;

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
