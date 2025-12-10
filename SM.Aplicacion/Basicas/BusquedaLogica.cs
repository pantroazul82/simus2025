using SM.Datos.Basicas;
using SM.LibreriaComun.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Aplicacion.Basicas
{
    public class BusquedaLogica
    {
        public static List<BusquedaResultadoDTO> ConsultarEventos(string parametro)
        {
            try
            {

                var listResultado = new List<BusquedaResultadoDTO>();
                listResultado = BusquedaServicio.ConsultarEventos(parametro);
                return listResultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<BusquedaResultadoDTO> ConsultarEscuelas(string parametro)
        {
            try
            {

                var listResultado = new List<BusquedaResultadoDTO>();
                listResultado = BusquedaServicio.ConsultarEscuelas(parametro);
                return listResultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<BusquedaResultadoDTO> ConsultarEntidades(string parametro)
        {
            try
            {

                var listResultado = new List<BusquedaResultadoDTO>();
                listResultado = BusquedaServicio.ConsultarEntidades(parametro);
                return listResultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<BusquedaResultadoDTO> ConsultarAgrupacion(string parametro)
        {
            try
            {

                var listResultado = new List<BusquedaResultadoDTO>();
                listResultado = BusquedaServicio.ConsultarAgrupacion(parametro);
                return listResultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<BusquedaResultadoDTO> ConsultarAgentes(string parametro)
        {
            try
            {

                var listResultado = new List<BusquedaResultadoDTO>();
                listResultado = BusquedaServicio.ConsultarAgentes(parametro);
                return listResultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
