using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WS.Simus.LogicaData;

namespace WS.Simus
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "EventoCelebraService" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione EventoCelebraService.svc o EventoCelebraService.svc.cs en el Explorador de soluciones e inicie la depuración.

    [ServiceBehavior(Namespace = Constantes.constantes.Namespace)]
    public class EventoCelebraService : IEventoCelebraService
    {
        public string CantidadMunicipiosParticipantes()
        {
            int intResultado = 0;
            string Mensaje = "";
            try
            {
                intResultado = EventoCelebraLogica.ConsultarMunicipiosParticipantes();

                Mensaje = intResultado.ToString();
            }
            catch (Exception ex)
            {

                throw new Exception("Error cantidad municipios participantes: ", ex);
            }
            return Mensaje;
        }

        public string CantidadConciertos()
        {
            int intResultado = 0;
            string Mensaje = "";
            try
            {
                intResultado = EventoCelebraLogica.ConsultarCantidadConciertos();
                Mensaje = intResultado.ToString() ;

            }
            catch (Exception ex)
            {

                throw new Exception("Error cantidad conciertos: ", ex);
            }
            return Mensaje;
        }

        public string CantidadArtistas()
        {
            int intResultado = 0;
            string Mensaje = "";
            try
            {
                
                intResultado = EventoCelebraLogica.ConsultarCantidadArtistas();
                Mensaje = intResultado.ToString();
            }
            catch (Exception ex)
            {

                throw new Exception("Error cantidad artistas: ", ex);
            }
            return Mensaje;
        }

        public string CantidadAgrupaciones()
        {
            int intResultado = 0;
            string Mensaje = "";
            try
            {
                intResultado = EventoCelebraLogica.ConsultarCantidadGrupos();
                Mensaje = intResultado.ToString();

            }
            catch (Exception ex)
            {

                throw new Exception("Error cantidad agrupaciones: ", ex);
            }
            return Mensaje;
        }

        public string CantidadMunicipioDanza()
        {
            int intResultado = 0;
            string Mensaje = "";
            try
            {
                intResultado = EventoCelebraLogica.ConsultarMunicipiosParticipantesDanza();
                Mensaje = intResultado.ToString();

            }
            catch (Exception ex)
            {

                throw new Exception("Error cantidad agrupaciones: ", ex);
            }
            return Mensaje;
        }

        public string CantidadDepartamentoDanza()
        {
            int intResultado = 0;
            string Mensaje = "";
            try
            {
                intResultado = EventoCelebraLogica.ConsultarDepartamentosParticipantesDanza();
                Mensaje = intResultado.ToString();
            }
            catch (Exception ex)
            {

                throw new Exception("Error cantidad agrupaciones: ", ex);
            }
            return Mensaje;
        }

        public string CantidadEventosDanza()
        {
            int intResultado = 0;
            string Mensaje = "";
            try
            {
                intResultado = EventoCelebraLogica.ConsultarEventosDanza();
                Mensaje = intResultado.ToString();

            }
            catch (Exception ex)
            {

                throw new Exception("Error cantidad agrupaciones: ", ex);
            }
            return Mensaje;
        }
    }
}
