using SM.LibreriaComun.DTO.GEO;
using System.Collections.Generic;

namespace WebSImus.Areas.Mapas.Models
{
    public class EscuelaTematicoModel
    {

        public EscuelaDataModels responseData { get; set; }
        public string responseDetails { get; set; }
        public int responseStatus { get; set; }
    }

    public class EscuelaDataModels
    {
        public IEnumerable<EscuelaDepartamentoDTO> Escuelas { get; set; }

    }

}