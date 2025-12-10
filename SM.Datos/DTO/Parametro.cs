using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Datos.DTO
{
   public class Parametro
    {
        public decimal Id { get; set; }
        public string Nombre { get; set; }

        public decimal? PadreId { get; set; }
    }

   public class DatosAsesoria
   {
       public decimal Id { get; set; }
       public DateTime FechaInicioCronograma { get; set; }

       public DateTime FechaFinConvenio { get; set; }
   }
}
