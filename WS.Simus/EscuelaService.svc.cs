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
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "EscuelaService" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione EscuelaService.svc o EscuelaService.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class EscuelaService : IEscuelaService
    {
        public List<EscuelaData> ConsultarEscuelas(string usuario, string contrasena)
        {
            List<EscuelaData> listEntidad = new List<EscuelaData>();
            try
            {
                listEntidad = EscuelaLogica.ConsultEscuelas(usuario, contrasena);

            }
            catch (Exception ex)
            {

                throw new Exception("Error: ", ex);
            }
            return listEntidad;
        }

        public EscuelaData ConsultarEscuelasPorId(string usuario, string contrasena, int EscuelaId)
        {
            EscuelaData escuela = new EscuelaData();
            try
            {
                escuela = EscuelaLogica.ConsultarEscuelasPorId(usuario, contrasena, EscuelaId);

            }
            catch (Exception ex)
            {

                throw new Exception("Error: ", ex);
            }
            return escuela;
        }

        public EscuelaData ConsultarEscuelasPorNit(string usuario, string contrasena, int Nit)
        {
            EscuelaData escuela = new EscuelaData();
            try
            {
                escuela = EscuelaLogica.ConsultarEscuelasPorNit(usuario, contrasena, Nit);

            }
            catch (Exception ex)
            {

                throw new Exception("Error: ", ex);
            }
            return escuela;
        }

        public List<EscuelaData> ConsultarEscuelasPorRangoFechas(string usuario, string contrasena, DateTime FechaInicio, DateTime FechaFinal)
        {
            List<EscuelaData> listEntidad = new List<EscuelaData>();
            try
            {
                listEntidad = EscuelaLogica.ConsultarEscuelasPorRangoFechas(usuario, contrasena, FechaInicio, FechaFinal);

            }
            catch (Exception ex)
            {

                throw new Exception("Error: ", ex);
            }
            return listEntidad;
        }
    }
}
