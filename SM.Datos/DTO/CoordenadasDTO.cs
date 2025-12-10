using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Datos.DTO
{
    /// <summary>
    /// Clase utilizada para la transferencia datos entre los procedimientos almacenados de consulta para Georreferenciar y la capa de datos. trae datos de las coordenadas
    /// </summary>
   public class CoordenadasDTO
    {
        public string Latitud { get; set; }
        public string Longitud { get; set; }
    }
}
