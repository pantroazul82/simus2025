using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.LibreriaComun.DTO
{
   public  class ReporteGeneralDTO
    {
       public string CODIGODEPARTAMENTO { get; set; }
       public string CODIGOMUNICIPIO { get; set; }
        public string DEPARTAMENTO { get; set; }
        public string MUNICIPIO { get; set; }
        public string ESTADO { get; set; }
        public string ENT_ID { get; set; }
        public string NOMBRE_ESCUELA { get; set; }
        public string DIRECCION_ESCUELA { get; set; }
        public string TELEFONO_ESCUELA { get; set; }
        public string FAX_ESCUELA { get; set; }
        public string CORREO_ELECTRONICO_ESCUELA { get; set; }
        public string NOMBRE_CONTACTO { get; set; }
        public string TELEFONO_CONTACTO { get; set; }
        public string CORREO_ELECTRONICO_CONTACTO { get; set; }

        public string TELEFONO_DIRECTOR { get; set; }
        public string CATEGORIA { get; set; }
        public string PORCENTAJE { get; set; }

        public DateTime FECHA_CREACION { get; set; }
        public DateTime FECHA_CATEGORIZACION { get; set; }
        public DateTime FECHA_ACTUALIZACION { get; set; }
        public string NOMBRE_CREADOR { get; set; }
        public string NOMBRE_USUARIO_CREADOR { get; set; }
        public string CORREO_ELECTRONICO_CREADOR { get; set; }
        public string ESCUELA_CREADA_LEGALMENTE { get; set; }
        public string TIENE_PERSONERIA_JURIDICA { get; set; }
        public string NATURALEZA { get; set; }
        public string DEPENDE_DE_OTRA_ENTIDAD { get; set; }
        public string ENTIDAD_DE_LA_QUE_DEPENDE { get; set; }
        public string TIENE_DIRECTOR { get; set; }
        public string NOMBRE_DIRECTOR { get; set; }
        public DateTime FECHA_NACIMIENTO_DIRECTOR { get; set; }
        public string CELULAR_DIRECTOR { get; set; }
        public string TIPO_VINCULACION_DIRECTOR { get; set; }
        public string ENTIDAD_CONTRATANTE_DIRECTOR { get; set; }
        public string CANTIDAD_DOCENTES_VOLUNTARIOS { get; set; }
        public string CANTIDAD_DOCENTES_PRESTACION_SERVICIOS { get; set; }
        public string CANTIDAD_DOCENTES_HONORARIOS { get; set; }
        public string CANTIDAD_DOCENTES_NOMINA { get; set; }

        public string CANTIDAD_TOTAL_DOCENTES_VINCULADOS { get; set; }
        public string CANTIDAD_DOCENTES_NIVEL_PRIMARIA { get; set; }
        public string CANTIDAD_DOCENTES_NIVEL_SECUNDARIA { get; set; }
        public string CANTIDAD_DOCENTES_NIVEL_TECNICO { get; set; }

        public string CANTIDAD_DOCENTES_UNIVERSITARIO { get; set; }

        public string CANTIDAD_DOCENTES_PREGRADO_MUSICA { get; set; }

        public string CANTIDAD_DOCENTES_PREGRADO_OTRA_AREA { get; set; }
        public string CANTIDAD_DOCENTES_POSTGRADO { get; set; }

        public string CANTIDAD_TOTAL_DOCENTES_NIVEL_EDUCATIVO { get; set; }
        public string CUENTA_APOYO_ADMINISTRATIVO { get; set; }

        public string CANTIDAD_APOYO_VOLUNTARIO { get; set; }

        public string CANTIDAD_APOYO_PRESTACION_SERVICIOS { get; set; }


        public string CANTIDAD_APOYO_HONORARIOS { get; set; }
        public string CANTIDAD_APOYO_NOMINA { get; set; }
        public string INCLUYE_ACTIVIDAD_MUSICAL { get; set; }
        public string SEDE_DE_TRABAJO { get; set; }
        public string ESPACIO { get; set; }

        public string SEDE_ASIGNADA_SOPORTE_ESCRITO { get; set; }
        public string CANTIDAD_SILLAS { get; set; }
        public string CANTIDAD_ATRILES { get; set; }
        public string CANTIDAD_TABLEROS { get; set; }
        public string CANTIDAD_ESTANTERIA { get; set; }
        public string SEDE_ADECUADA_ACUSTICAMENTE { get; set; }
        public string PORCENTAJE_ADECUACION_ACUSTICA { get; set; }

        public string CANTIDAD_INSTRUMENTOS_CUERDAS_PULSADAS { get; set; }
        public string CANTIDAD_INSTRUMENTOS_CUERDAS_SINFONICAS { get; set; }
        public string CANTIDAD_INSTRUMENTOS_VIENTOS_MADERAS { get; set; }
        public string CANTIDAD_INSTRUMENTOS_VIENTOS_METALES { get; set; }
        public string CANTIDAD_INSTRUMENTOS_PERCUSION_MENOR { get; set; }

        public string CANTIDAD_INSTRUMENTOS_PERCUSION_SINFONICA { get; set; }
        public string CANTIDAD_INSTRUMENTOS_OTROS { get; set; }
        public string CANTIDAD_INSTRUMENTOS_TOTAL { get; set; }

        public string CUENTA_MATERIAL_PEDAGOGICO { get; set; }
        public string CANTIDAD_TITULOS_BIBLIOGRAFICOS { get; set; }
        public string TIENE_ACCESO_INTERNET { get; set; }
        public string CANTIDAD_ALUMNOS_MENOR_6 { get; set; }
        public string CANTIDAD_ALUMNOS_ENTRE_7_11 { get; set; }
        public string CANTIDAD_ALUMNOS_ENTRE_12_18 { get; set; }
        public string CANTIDAD_ALUMNOS_ENTRE_19_25 { get; set; }
        public string CANTIDAD_ALUMNOS_ENTRE_26_60 { get; set; }
        public string CANTIDAD_ALUMNOS_MAYOR_60 { get; set; }

        public string CANTIDAD_TOTAL_ALUMNOS_EDAD { get; set; }

        public string CANTIDAD_ALUMNOS_MASCULINO { get; set; }

        public string CANTIDAD_ALUMNOS_FEMENINO { get; set; }
        public string CANTIDAD_TOTAL_ALUMNOS_GENERO { get; set; }
        public string CANTIDAD_ALUMNOS_RURAL { get; set; }

        public string CANTIDAD_ALUMNOS_URBANA { get; set; }
        public string CANTIDAD_TOTAL_ALUMNOS_AREA { get; set; }
        public string CANTIDAD_ALUMNOS_INDIGENAS { get; set; }



        public string CANTIDAD_ALUMNOS_AFRO { get; set; }
        public string CANTIDAD_ALUMNOS_ROM { get; set; }
        public string CANTIDAD_ALUMNOS_RAIZALES { get; set; }
        public string CANTIDAD_ALUMNOS_OTROS { get; set; }
        public string CANTIDAD_TOTAL_ALUMNOS_ETNIA { get; set; }

        public string CANTIDAD_ALUMNOS_DISCAPACITADOS { get; set; }

        public string CANTIDAD_ALUMNOS_DESPLAZADOS { get; set; }
        public string CANTIDAD_ALUMNOS_DESVINCULADOS { get; set; }

        public string CANTIDAD_ALUMNOS_VULNERABLES { get; set; }
        public string CANTIDAD_TOTAL_ALUMNOS_ESPECIALES { get; set; }

        public string CUENTA_ORGANIZACION_COMUNITARIA { get; set; }

        public string ORGANIZACION_COMUNITARIA { get; set; }
        public string OTRA_ORGANIZACION_COMUNITARIA { get; set; }
        public string NOMBRE_ORGANIZACION { get; set; }
        public string INTEGRANTES_ORGANIZACION { get; set; }
        public string NOMBRE_PRESIDENTE_ORGANIZACION { get; set; }

        public string TELEFONO_CELULAR_PRESIDENTE_ORGANIZACION { get; set; }
        public string TELEFONO_FIJO_PRESIDENTE_ORGANIZACION { get; set; }
        public string CORREO_ELECTRONICO_PRESIDENTE_ORGANIZACION { get; set; }
        public string PROCESOS_FORMACION { get; set; }
        public string PRACTICAS_MUSICALES { get; set; }
        public string PRACTICAS_MUSICALES_ORIENTADAS_MUSICO { get; set; }

        public string TALLERES_INDEPENDIENTES { get; set; }
        public string PROGRAMAS_FORMULADOS_ESCRITO { get; set; }
        public string INICIACION_DURACION_PROMEDIO_MESES { get; set; }
        
        public string INICIACION_POBLACION { get; set; }
        public string INICIACION_INTENSIDAD_HORAS_SEMANAL { get; set; }
        public string INICIACION_OBSERVACIONES { get; set; }
        public string BASICO_DURACION_PROMEDIO_MESES { get; set; }
       
        public string BASICO_POBLACION { get; set; }
        public string BASICO_INTENSIDAD_HORAS_SEMANAL { get; set; }

        public string BASICO_OBSERVACIONES { get; set; }
        public string MEDIO_DURACION_PROMEDIO_MESES { get; set; }
        public string MEDIO_POBLACION { get; set; }
        public string MEDIO_INTENSIDAD_HORAS_SEMANAL { get; set; }
        public string MEDIO_OBSERVACIONES { get; set; }
        public string CURSO_DURACION_PROCURSO_SEMANA { get; set; }
     
        public string CURSO_POBLACION { get; set; }
        public string CURSO_INTENSIDAD_HORAS_SEMANAL { get; set; }
        public string CURSO_OBSERVACIONES { get; set; }
        public string PEDAGOGIAS_DURACION_PROPEDAGOGIAS_SEMANA { get; set; }
        
        public string PEDAGOGIAS_POBLACION { get; set; }

        public string PEDAGOGIAS_INTENSIDAD_HORAS_SEMANAL { get; set; }
        public string PEDAGOGIAS_OBSERVACIONES { get; set; }

        public string CANTIDAD_GIRAS_NACIONALES_ULTIMO_AÑO { get; set; }

        public string CANTIDAD_GIRAS_INTERNACIONALES_ULTIMO_AÑO { get; set; }
        public string ENT_CANTIDAD_PRESENTACIONES_LOCALIDAD_ULTIMO_ANIO { get; set; }
        public string CANTIDAD_DISCOS_ULTIMO_AÑO { get; set; }
        public string CANTIDAD_REPERTORIOS_ULTIMO_AÑO { get; set; }
        public string CANTIDAD_MATERIAL_DIVULGATIVO_ULTIMO_AÑO { get; set; }
        public string CANTIDAD_MATERIAL_APOYO_ULTIMO_AÑO { get; set; }
        public string CANTIDAD_AGRUPACIONES_CONFORMADAS_VIGENTES { get; set; }
        public string TIPO_ESCUELA { get; set; }
        public string CANTIDAD_PRACTICA { get; set; }
        public string PRACTICA_MUSICALES { get; set; }
    }
}
