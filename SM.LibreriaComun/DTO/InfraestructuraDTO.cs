using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.LibreriaComun.DTO
{
    public class InfraestructuraDTO
    {
        public decimal ENT_ID { get; set; }
        public bool ENT_SEDE_ASIGNADA_SOPORTE_ESCRITO { get; set; }
        public bool ENT_SEDE_EQUIP_MOBIL_INSTRUM { get; set; }
        public bool ENT_SEDE_ADEC_ACUSTIC { get; set; }
        public short ENT_CANTIDAD_INSTR_CUERDAS_PULSADAS { get; set; }
        public short ENT_CANTIDAD_INSTR_CUERDAS_SINFONICAS { get; set; }
        public short ENT_CANTIDAD_INSTR_VIENTOS_MADERAS { get; set; }
        public short ENT_CANTIDAD_INSTR_VIENTOS_METALES { get; set; }
        public short ENT_CANTIDAD_INSTR_PERCUSION_MENOR { get; set; }
        public short ENT_CANTIDAD_INSTR_PERCUSION_SINFONICA { get; set; }
        public short ENT_CANTIDAD_INSTR_OTROS { get; set; }
        public short ENT_CANTIDAD_INSTR_TOTAL { get; set; }
        public bool ENT_MATERIAL_PEDAGOGICO { get; set; }
        public short ENT_CANTIDAD_TITULOS_BIBLIOGRAFICOS { get; set; }
        public string ENT_SEDE_LUGAR { get; set; }
        public short ENT_CANTIDAD_SILLAS { get; set; }
        public short ENT_CANTIDAD_ATRILES { get; set; }
        public short ENT_CANTIDAD_TABLEROS { get; set; }
        public short ENT_CANTIDAD_ESTANTERIA { get; set; }
        public short ENT_SEDE_PORCENTAJE_ADEC_ACUSTIC { get; set; }
        public string ENT_SEDE_OTRA_SOLUCION_ADEC_ACUSTIC { get; set; }

        //Otra consulta
        public string ENT_SINOACCESO_INTERNET { get; set; }
        public decimal ENT_ESPACIO { get; set; }
        public string ENT_OTRO_ESPACIO { get; set; }
        public string ENT_SINO_INFRAESTRUCTURA_DISCAPACITADOS { get; set; }
        public string ENT_SINO_BIEN_INTERES_CULTURAL { get; set; }
        public decimal ENT_NIVEL_BIEN_INTERES_CULTURAL { get; set; }
    }
}
