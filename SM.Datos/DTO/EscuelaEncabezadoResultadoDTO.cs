using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Datos.DTO
{
    /// <summary>
    /// Clase utilizada para la transferencia datos entre los procedimientos almacenados de consulta para Georreferenciar y la capa de datos. trae datos principales de las escuelas
    /// </summary>
    public class EscuelaEncabezadoResultadoDTO
    {
        public decimal EscuelaId { get; set; }
        public string Nombre { get; set; }

        public string Resena { get; set; }
    }
}
