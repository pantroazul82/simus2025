using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.LibreriaComun.DTO
{
    public class ProduccionDTO
    {
        public decimal ENT_ID { get; set; }
        public short ENT_CANTIDAD_GIRAS_ULTIMO_ANIO { get; set; }
        public short ENT_CANTIDAD_PRESENTACIONES_LOCALIDAD_ULTIMO_ANIO { get; set; }
        public short ENT_CANTIDAD_DISCOS_ULTIMO_ANIO { get; set; }
        public short ENT_CANTIDAD_REPERTORIOS_ULTIMO_ANIO { get; set; }
        public short ENT_CANTIDAD_MATERIAL_DIVULGATIVO_ULTIMO_ANIO { get; set; }
        public short ENT_CANTIDAD_MATERIAL_APOYO_ULTIMO_ANIO { get; set; }
        public short ENT_CANTIDAD_AGRUPACIONES_CONFORMADAS_VIGENTES { get; set; }
        public short ENT_CANTIDAD_GIRAS_INTER_ULTIMO_ANIO { get; set; }
    }
}
