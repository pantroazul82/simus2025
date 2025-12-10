using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using SM.LibreriaComun.DTO;

namespace WebSImus.Models
{
    public class EscuelasPadre
    {
        public Escuelas Escuelas { get; set; }

        public Institucionalidad Institucionalidad { get; set; }

        public InfraestructuraModel Infraestructura { get; set; }

        public ParticipacionModel Participacion { get; set; }

        public FormacionModel  Formacion { get; set; }

        public ProduccionModel Produccion { get; set; }

        public RedesSocialesModel RedesSociales { get; set; }
        public IEnumerable<WebSImus.Models.VideoModel> listadoVideo { get; set; }

        public EscuelaDocumentoModels Documentos { get; set; }

        public List<PracticaHomeModelDTO> Practicas { get; set; }
    }

    public class EscuelasNuevo
    {
        public decimal EscuelaId { get; set; }
        public Escuelas Escuelas { get; set; }
      

        public RedesSocialesModel RedesSociales { get; set; }
        public IEnumerable<WebSImus.Models.VideoModel> listadoVideo { get; set; }

        public EscuelaDocumentoModels Documentos { get; set; }
    }
}