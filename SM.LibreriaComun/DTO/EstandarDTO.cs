using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.LibreriaComun.DTO
{

    public class EstandarDTO
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string FormacionId { get; set; }
        public string clase { get; set; }
        public string EscuelaId { get; set; }
        public bool EsSeleccionado { get; set; }
    }

    public class PracticaHomeModelDTO
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string FormacionId { get; set; }
        public string clase { get; set; }
        public string EscuelaId { get; set; }
        public bool EsSeleccionado { get; set; }
        public List<EstandarDTO> listadoGeneros { get; set; }
        public List<NivelesFormacionDTO> listadoNiveles { get; set; }
    }

}
