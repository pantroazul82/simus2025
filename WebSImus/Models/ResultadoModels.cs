using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSImus.Models
{
    public class ResultadoModels
    {
        public int Id { get; set; }

        public string Titulo { get; set; }
        public string Descripcion { get; set; }
    }

    public class BusquedaPadreModels
    {
        public IPagedList<WebSImus.Models.ResultadoModels> escuelas { get; set; }
    }
}