using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SM.LibreriaComun.DTO;
using System.Web.Mvc;

namespace WebSImus.Models
{
    public class FormularioModels
    {
        public decimal ForID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string EsActiva { get; set; }
        public string EsVisible { get; set; }
        public string Perfiles { get; set; }
        public string EsEditable { get; set; }
        public DateTime FechaRegistro { get; set; }
        public List<FormularioCamposModels> listCampos { get; set; }
        public List<FormularioSeccionesDTO> listSecciones { get; set; }

      
      
    }
} 