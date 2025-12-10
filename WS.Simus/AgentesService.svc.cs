using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WS.Simus.Data;
using System.Diagnostics;
using WS.Simus.LogicaData;

namespace WS.Simus
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "AgentesService" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione AgentesService.svc o AgentesService.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class AgentesService : IAgentesService
    {
        public List<AgenteData> ConsultarAgentes(string usuario, string contrasena)
        {
            List<AgenteData> listAgente = new List<AgenteData>();
            try
            {
                listAgente = AgenteLogica.ConsultarAgentes(usuario, contrasena);

            }
            catch (Exception ex)
            {

                throw new Exception("Error: ", ex);
            }
            return listAgente;
        }

        public AgenteData ConsultarAgentePorId(string usuario, string contrasena, int AgenteId)
        {
           AgenteData Agente = new AgenteData();
            try
            {
                Agente = AgenteLogica.ConsultarAgentePorId(usuario, contrasena, AgenteId);

            }
            catch (Exception ex)
            {

                throw new Exception("Error: ", ex);
            }
            return Agente;
        }

        public AgenteData ConsultarAgentePorIdentificacion(string usuario, string contrasena, string tipoDocumento, string numeroDocumento)
        {
            AgenteData Agente = new AgenteData();
            try
            {
                Agente = AgenteLogica.ConsultarAgentePorIdentificacion(usuario, contrasena, tipoDocumento, numeroDocumento);

            }
            catch (Exception ex)
            {

                throw new Exception("Error: ", ex);
            }
            return Agente;
        }

        public List<AgenteData> ConsultarAgentesPorRangoFechas(string usuario, string contrasena, DateTime FechaInicio, DateTime FechaFinal)
        {
            List<AgenteData> listAgente = new List<AgenteData>();
            try
            {
                listAgente = AgenteLogica.ConsultarAgentesPorRangoFechas(usuario, contrasena, FechaInicio, FechaFinal);

            }
            catch (Exception ex)
            {

                throw new Exception("Error: ", ex);
            }
            return listAgente;
        }
        private void Log(string value, bool showDate)
        {
            if (showDate)
                Trace.WriteLine(string.Format("{0:dd/MM/yyyy HH:mm:ss.fff} - {1}", DateTime.Now, value));
            else
                Trace.WriteLine(value);
        }
    }
}
