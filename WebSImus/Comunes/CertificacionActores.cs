using SM.Aplicacion.Basicas;
using SM.LibreriaComun.DTO.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSImus.Comunes
{
    public class CertificacionActores
    {
        public static void DatosCertificacion(string modulo, int Id)
        {
            var registro = new CertificacionDTO();
           
            try
            {
                if (modulo == Comunes.ConstantesRecursosBD.ACTORES_AGENTES) {
                    registro = CaracterizacionMusicalNeg.ObtenerdatosAgentes(Id);
                }
                else if (modulo == Comunes.ConstantesRecursosBD.ACTORES_ENTIDADES) {
                    registro = CaracterizacionMusicalNeg.ObtenerdatosEntidades(Id);
                }
                else if (modulo == Comunes.ConstantesRecursosBD.ACTORES_AGRUPACIONES) {
                    registro = CaracterizacionMusicalNeg.ObtenerdatosAgrupacion(Id);
                }
                else if (modulo == Comunes.ConstantesRecursosBD.ACTORES_ESCUELAS) {
                    registro = CaracterizacionMusicalNeg.ObtenerdatosEscuelas(Convert.ToDecimal(Id)); 
                }
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}