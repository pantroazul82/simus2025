using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WS.Simus.Data;
using WS.Simus.LogicaData;

namespace WS.Simus
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "AgrupacionService" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione AgrupacionService.svc o AgrupacionService.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class AgrupacionService : IAgrupacionService
    {
        public List<AgrupacionData> ConsultarAgrupaciones(string usuario, string contrasena)
        {
            List<AgrupacionData> listEntidad = new List<AgrupacionData>();
            try
            {
                listEntidad = AgrupacionLogica.ConsultarAgrupaciones(usuario, contrasena);

            }
            catch (Exception ex)
            {

                throw new Exception("Error: ", ex);
            }
            return listEntidad;
        }

        public AgrupacionData ConsultarAgrupacionPorId(string usuario, string contrasena, int AgrupacionId)
        {
            AgrupacionData entidad = new AgrupacionData();
            try
            {
                entidad = AgrupacionLogica.ConsultarAgrupacionPorId(usuario, contrasena, AgrupacionId);

            }
            catch (Exception ex)
            {

                throw new Exception("Error: ", ex);
            }
            return entidad;
        }


        public List<AgrupacionData> ConsultarAgrupacionesPorRangoFechas(string usuario, string contrasena, DateTime FechaInicio, DateTime FechaFinal)
        {
            List<AgrupacionData> listEntidad = new List<AgrupacionData>();
            try
            {
                listEntidad = AgrupacionLogica.ConsultarAgrupacionesPorRangoFechas(usuario, contrasena, FechaInicio, FechaFinal);

            }
            catch (Exception ex)
            {

                throw new Exception("Error: ", ex);
            }
            return listEntidad;
        }
    }
}
