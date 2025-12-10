using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Datos.DTO
{
    public class ParticipacionAlumnosDTO
    {
        public string Menor6Anos { get; set; }
        public string Entre6y11Anos { get; set; }
        public string Entre12y18Anos { get; set; }
        public string Entre19y26Anos { get; set; }
        public string Entre27y60Anos { get; set; }
        public string Mayores60Anos { get; set; }
    }

    public class ParticipacionEtniaDTO
    {
        public string Indigenas { get; set; }
        public string Afro { get; set; }
        public string Rom { get; set; }
        public string Raizales { get; set; }
        public string Otros { get; set; }
       
    }

    public class ParticipacionSexoDTO
    {
        public string Femenino { get; set; }
        public string Masculino { get; set; }
      

    }

    public class ParticipacionUbicacionDTO
    {
        public string Urbana { get; set; }
        public string Rural { get; set; }


    }

    public class ParticipacioCondicionesDTO
    {
        public string Discapacitados { get; set; }
        public string Deplazados { get; set; }
        public string RedUnidos { get; set; }


    }
}
