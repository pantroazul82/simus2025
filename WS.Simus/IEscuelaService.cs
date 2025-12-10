using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WS.Simus.Data;

namespace WS.Simus
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IEscuelaService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IEscuelaService
    {
        [OperationContract]
        List<EscuelaData> ConsultarEscuelas(string usuario, string contrasena);

        [OperationContract]
        EscuelaData ConsultarEscuelasPorId(string usuario, string contrasena, int EscuelaId);
        [OperationContract]
        EscuelaData ConsultarEscuelasPorNit(string usuario, string contrasena, int Nit);

        [OperationContract]
        List<EscuelaData> ConsultarEscuelasPorRangoFechas(string usuario, string contrasena, DateTime FechaInicio, DateTime FechaFinal);
    }
}
