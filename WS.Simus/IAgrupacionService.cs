using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WS.Simus.Data;

namespace WS.Simus
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IAgrupacionService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IAgrupacionService
    {
        [OperationContract]
        List<AgrupacionData> ConsultarAgrupaciones(string usuario, string contrasena);

        [OperationContract]
        AgrupacionData ConsultarAgrupacionPorId(string usuario, string contrasena, int AgrupacionId);
     
        [OperationContract]
        List<AgrupacionData> ConsultarAgrupacionesPorRangoFechas(string usuario, string contrasena, DateTime FechaInicio, DateTime FechaFinal);
    }
}
