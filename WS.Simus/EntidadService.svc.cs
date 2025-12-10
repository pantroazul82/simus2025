using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WS.Simus.LogicaData;
using WS.Simus.Data;

namespace WS.Simus
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "EntidadService" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione EntidadService.svc o EntidadService.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class EntidadService : IEntidadService
    {
        public List<EntidadData> ConsultarEntidades(string usuario, string contrasena)
        {
            List<EntidadData> listEntidad = new List<EntidadData>();
            try
            {
                listEntidad = EntidadLogica.ConsultarEntidades(usuario, contrasena);

            }
            catch (Exception ex)
            {

                throw new Exception("Error: ", ex);
            }
            return listEntidad;
        }

        public EntidadData ConsultarEntidadesPorId(string usuario, string contrasena, int EntidadId)
        {
            EntidadData entidad = new EntidadData();
            try
            {
                entidad = EntidadLogica.ConsultarEntidadesPorId(usuario, contrasena, EntidadId);

            }
            catch (Exception ex)
            {

                throw new Exception("Error: ", ex);
            }
            return entidad;
        }

        public EntidadData ConsultarEntidadesPorNit(string usuario, string contrasena, int Nit)
        {
            EntidadData entidad = new EntidadData();
            try
            {
                entidad = EntidadLogica.ConsultarEntidadesPorNit(usuario, contrasena, Nit);

            }
            catch (Exception ex)
            {

                throw new Exception("Error: ", ex);
            }
            return entidad;
        }

        public List<EntidadData> ConsultarEntidadesPorRangoFechas(string usuario, string contrasena, DateTime FechaInicio, DateTime FechaFinal)
        {
            List<EntidadData> listEntidad = new List<EntidadData>();
            try
            {
                listEntidad = EntidadLogica.ConsultarEntidadesPorRangoFechas(usuario, contrasena, FechaInicio, FechaFinal);

            }
            catch (Exception ex)
            {

                throw new Exception("Error: ", ex);
            }
            return listEntidad;
        }
    }
}
