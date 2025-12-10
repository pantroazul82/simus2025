using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WS.Simus.Data;

namespace WS.Simus
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IAgentesService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IAgentesService
    {
        [OperationContract]
        List<AgenteData> ConsultarAgentes(string usuario, string contrasena);

        [OperationContract]
        AgenteData ConsultarAgentePorId(string usuario, string contrasena, int AgenteId);
        [OperationContract]
        AgenteData ConsultarAgentePorIdentificacion(string usuario, string contrasena, string tipoDocumento, string numeroDocumento);

        [OperationContract]
        List<AgenteData> ConsultarAgentesPorRangoFechas(string usuario, string contrasena, DateTime FechaInicio, DateTime FechaFinal);

       
    }
}
