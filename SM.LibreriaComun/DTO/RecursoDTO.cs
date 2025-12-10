using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.LibreriaComun.DTO
{
    public class RecursoDTO
    {


        public int id { get; set; }


        public String codigo { get; set; }


        public int rec_id_padre { get; set; }


        public bool? rec_estado { get; set; }


        public String rec_descripcion { get; set; }


        public String rec_ruta { get; set; }


        public String rec_tipo { get; set; }
        public String rec_tipo_nombre { get; set; }


        public String rec_nombre { get; set; }
        public String nombrepadre { get; set; }
        

        public String rec_titulo { get; set; }
        public String rec_estilo { get; set; }
        public bool aplica { get; set; }
        public bool estado { get; set; }
        public DateTime fechacreacion { get; set; }

        public List<RecursoDTO> opciones { get; set; }
    }
}
