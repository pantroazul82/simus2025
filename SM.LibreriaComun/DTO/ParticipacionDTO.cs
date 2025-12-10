using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.LibreriaComun.DTO
{
    public class ParticipacionDTO
    {
        public decimal ENT_ID { get; set; }
        public int ENT_CANTIDAD_ALUMNOS_MENOR_6 { get; set; }
        public int ENT_CANTIDAD_ALUMNOS_ENTRE_7_11 { get; set; }
        public int ENT_CANTIDAD_ALUMNOS_ENTRE_12_18 { get; set; }
        public int ENT_CANTIDAD_ALUMNOS_ENTRE_19_25 { get; set; }
        public int ENT_CANTIDAD_ALUMNOS_MAYOR_26 { get; set; }
        public int ENT_CANTITDAD_TOTAL_ALUMNOS_EDAD { get; set; }
        public int ENT_CANTIDAD_ALUMNOS_MASCULINO { get; set; }
        public int ENT_CANTIDAD_ALUMNOS_FEMENINO { get; set; }
        public int ENT_CANTIDAD_TOTAL_ALUMNOS_GENERO { get; set; }
        public int ENT_CANTIDAD_ALUMNOS_RURAL { get; set; }
        public int ENT_CANTIDAD_ALUMNOS_URBANA { get; set; }
        public int ENT_CANTIDAD_TOTAL_ALUMNOS_AREA { get; set; }
        public int ENT_CANTIDAD_ALUMNOS_INDIGENAS { get; set; }
        public int ENT_CANTIDAD_ALUMNOS_AFRO { get; set; }
        public int ENT_CANTIDAD_ALUMNOS_ROM { get; set; }
        public int ENT_CANTIDAD_ALUMNOS_RAIZALES { get; set; }
        public int ENT_CANTIDAD_ALUMNOS_OTROS { get; set; }
        public int ENT_CANTIDAD_TOTAL_ALUMNOS_ETNIA { get; set; }
        public int ENT_CANTIDAD_ALUMNOS_DISCAPACITADOS { get; set; }
        public int ENT_CANTIDAD_ALUMNOS_DESPLAZADOS { get; set; }
        public int ENT_CANTIDAD_TOTAL_ALUMNOS_ESPECIALES { get; set; }
        public bool ENT_ORGANIZACION_COMUNITARIA { get; set; }
        public short ORGANIZACION_COMUNITARIA_ID { get; set; }
        public string OTRA_ORGANIZACION_COMUNITARIA { get; set; }
        public bool ENT_ORGANIZACION_COMUNITARIA_PROYECTO_ENTORNO_ESCUELA { get; set; }
        public string OTRO_PROYECTO_ENTORNO_ESCUELA { get; set; }
        public string ENT_NOMBRE_ORGANIZACION { get; set; }
        public int ENT_INTEGRANTES_ORGANIZACION { get; set; }
        public string ENT_NOMBRE_PRESIDENTE_ORGANIZACION { get; set; }
        public string ENT_TELEFONO_CELULAR_PRESIDENTE_ORGANIZACION { get; set; }
        public string ENT_TELEFONO_FIJO_PRESIDENTE_ORGANIZACION { get; set; }
        public string ENT_CORREO_ELECTRONICO_PRESIDENTE_ORGANIZACION { get; set; }
        public int ENT_CANTIDAD_ALUMNOS_MAYOR_60 { get; set; }
        public int ENT_CANTIDAD_ALUMNOS_REDUNIDOS { get; set; }
        public int ENT_CANTIDAD_ALUMNOS_CUPOS { get; set; }
    }
}
