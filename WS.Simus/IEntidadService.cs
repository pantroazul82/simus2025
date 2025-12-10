using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WS.Simus.Data;

namespace WS.Simus
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IEntidadService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IEntidadService
    {
        [OperationContract]
        List<EntidadData> ConsultarEntidades(string usuario, string contrasena);

        [OperationContract]
        EntidadData ConsultarEntidadesPorId(string usuario, string contrasena, int EntidadId);
        [OperationContract]
        EntidadData ConsultarEntidadesPorNit(string usuario, string contrasena, int Nit);

        [OperationContract]
        List<EntidadData> ConsultarEntidadesPorRangoFechas(string usuario, string contrasena, DateTime FechaInicio, DateTime FechaFinal);
    }
}
