using SM.Datos.Departamentos;
using SM.LibreriaComun.DTO.WSDepartamento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Aplicacion.Departamento
{
    public class WSDepartamentoNeg
    {
        public static List<AgenteWSDTO> ConsultarWebApiAgentes(string usuario, string contrasena, out string Mensaje)
        {
            var lisParametro = new List<AgenteWSDTO>();
            try
            {
                string strMensajeError = "";
                lisParametro = WSDepartamentoServicio.ConsultarWebApiAgentes(usuario, contrasena, out strMensajeError);
                lisParametro = lisParametro.OrderBy(d => d.PrimerNombre).ToList();
                Mensaje = strMensajeError;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lisParametro;
        }

        public static List<WSEntidadDTO> ConsultarWebApiEntidades(string usuario, string contrasena, out string Mensaje)
        {
            var lisParametro = new List<WSEntidadDTO>();
            try
            {
                string strMensajeError = "";
                lisParametro = WSDepartamentoServicio.ConsultarWebApiEntidades(usuario, contrasena, out strMensajeError);
                lisParametro = lisParametro.OrderBy(d => d.Nombre).ToList();
                Mensaje = strMensajeError;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lisParametro;
        }

        public static List<WSEscuelaDTO> ConsultarWebApiEscuelas(string usuario, string contrasena, out string Mensaje)
        {
            var lisParametro = new List<WSEscuelaDTO>();
            try
            {
                string strMensajeError = "";
                lisParametro = WSDepartamentoServicio.ConsultarWebApiEscuelas(usuario, contrasena, out strMensajeError);
                lisParametro = lisParametro.OrderBy(d => d.NombreEscuela).ToList();
                Mensaje = strMensajeError;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lisParametro;
        }

        public static List<WSEventoDTO> ConsultarWebApiEventos(string usuario, string contrasena, out string Mensaje)
        {
            var lisParametro = new List<WSEventoDTO>();
            try
            {
                string strMensajeError = "";
                lisParametro = WSDepartamentoServicio.ConsultarWebApiEventos(usuario, contrasena, out strMensajeError);
                lisParametro = lisParametro.OrderBy(d => d.Titulo).ToList();
                Mensaje = strMensajeError;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lisParametro;
        }
    }
}
