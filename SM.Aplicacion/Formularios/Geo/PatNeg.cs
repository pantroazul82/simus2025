using SM.Datos.DTO.Geo;
using SM.Datos.Geo;
using SM.LibreriaComun.DTO.GEO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Aplicacion.Geo
{
     public static class PatNeg
    {
         public static List<PatGeoDTO> ConsultarInmuebles()
         {
             try
             {
                 var model = new List<PatGeoResultDTO>();
                 var result = new List<PatGeoDTO>();
                 model = PatGeoServicio.ConsultarInmuebles();
                 
                 foreach (var item in model)
                 {
                     var datos = new PatGeoDTO();
                     var geo = new Geometry();
                     geo.Latitud = item.INB_LATITUD.ToString();
                     geo.Longitud = item.INB_LONGITUD.ToString();
                     datos.AMD_ID = item.AMD_ID ??0;
                     datos.AMD_NOMBRE = item.AMD_NOMBRE;
                     datos.CLT_ID = item.CLT_ID;
                     datos.CLT_NOMBRE = item.CLT_NOMBRE;
                     datos.CODIGO_BIEN = item.INB_CODIGO_BIEN;
                     datos.CodigoDepartamento = item.CodigoDepartamento;
                     datos.Dane = item.CodMunicipio;
                     datos.DDI_ID = item.DDI_ID ??0;
                     datos.Departamento = item.Departamento;
                     datos.Direccion = item.INB_DIRECCION_DELIMITACION;
                     datos.INB_ID = item.INB_ID;
                     datos.INR_ID = item.INR_ID ??0;
                     datos.Modelo = item.Modelo;
                     datos.Municipio = item.Municipio;
                     datos.NIVELID = item.CLT_NIVEL ??0;
                     datos.Nombre_Bien = item.INB_NOMBRE_BIEN;
                     datos.NOMBRE_NIVEL = item.CLT_NOMBRE_NIVEL;
                     datos.Otros_Nombres = item.INB_OTROS_NOMBRES;
                     datos.TIS_ID = item.TIS_ID ?? 0;
                     datos.URL_FOTOGRAFIA_BIEN = item.INB_URL_FOTOGRAFIA_BIEN;
                     datos.URL_IMAGEN_DECLARATORIA = item.DDI_URL_IMAGEN_DECLARATORIA;
                     datos.USO_ID = item.USO_ID ?? 0;
                     datos.USO_NOMBRE = item.USO_NOMBRE;
                     datos.Ver_Mas = item.Ver_Mas;
                     datos.Resolucion = item.Resolucion;
                     datos.VCM_ID = item.VCM_ID ?? 0;
                     datos.geometry = geo;
                                     
                     result.Add(datos);
                 }

                 return result;
             }
             catch (Exception ex)
             {
                 throw ex;
             }
         }

         public static List<PatGeoDTO> ConsultarInmueblesPorCodigoMunicipio(string codMunicipio)
         {
             try
             {
                 var model = new List<PatGeoResultDTO>();
                 var result = new List<PatGeoDTO>();
                 model = PatGeoServicio.ConsultarInmueblesPorCodigoMunicipio(codMunicipio);

                 foreach (var item in model)
                 {
                     var datos = new PatGeoDTO();
                     var geo = new Geometry();
                     geo.Latitud = item.INB_LATITUD.ToString();
                     geo.Longitud = item.INB_LONGITUD.ToString();
                     datos.AMD_ID = item.AMD_ID ?? 0;
                     datos.AMD_NOMBRE = item.AMD_NOMBRE;
                     datos.CLT_ID = item.CLT_ID;
                     datos.CLT_NOMBRE = item.CLT_NOMBRE;
                     datos.CODIGO_BIEN = item.INB_CODIGO_BIEN;
                     datos.CodigoDepartamento = item.CodigoDepartamento;
                     datos.Dane = item.CodMunicipio;
                     datos.DDI_ID = item.DDI_ID ?? 0;
                     datos.Departamento = item.Departamento;
                     datos.Direccion = item.INB_DIRECCION_DELIMITACION;
                     datos.INB_ID = item.INB_ID;
                     datos.INR_ID = item.INR_ID ?? 0;
                     datos.Modelo = item.Modelo;
                     datos.Municipio = item.Municipio;
                     datos.NIVELID = item.CLT_NIVEL ?? 0;
                     datos.Nombre_Bien = item.INB_NOMBRE_BIEN;
                     datos.NOMBRE_NIVEL = item.CLT_NOMBRE_NIVEL;
                     datos.Otros_Nombres = item.INB_OTROS_NOMBRES;
                     datos.TIS_ID = item.TIS_ID ?? 0;
                     datos.URL_FOTOGRAFIA_BIEN = item.INB_URL_FOTOGRAFIA_BIEN;
                     datos.URL_IMAGEN_DECLARATORIA = item.DDI_URL_IMAGEN_DECLARATORIA;
                     datos.USO_ID = item.USO_ID ?? 0;
                     datos.USO_NOMBRE = item.USO_NOMBRE;
                     datos.VCM_ID = item.VCM_ID ?? 0;
                     datos.geometry = geo;

                     result.Add(datos);
                 }

                 return result;
             }
             catch (Exception ex)
             {
                 throw ex;
             }
         }

         public static List<PatGeoDTO> ConsultarInmueblesPorCodigoDepartamento(string codDepto)
         {
             try
             {
                 var model = new List<PatGeoResultDTO>();
                 var result = new List<PatGeoDTO>();
                 model = PatGeoServicio.ConsultarInmueblesPorCodigoDepartamento(codDepto);

                 foreach (var item in model)
                 {
                     var datos = new PatGeoDTO();
                     var geo = new Geometry();
                     geo.Latitud = item.INB_LATITUD.ToString();
                     geo.Longitud = item.INB_LONGITUD.ToString();
                     datos.AMD_ID = item.AMD_ID ?? 0;
                     datos.AMD_NOMBRE = item.AMD_NOMBRE;
                     datos.CLT_ID = item.CLT_ID;
                     datos.CLT_NOMBRE = item.CLT_NOMBRE;
                     datos.CODIGO_BIEN = item.INB_CODIGO_BIEN;
                     datos.CodigoDepartamento = item.CodigoDepartamento;
                     datos.Dane = item.CodMunicipio;
                     datos.DDI_ID = item.DDI_ID ?? 0;
                     datos.Departamento = item.Departamento;
                     datos.Direccion = item.INB_DIRECCION_DELIMITACION;
                     datos.INB_ID = item.INB_ID;
                     datos.INR_ID = item.INR_ID ?? 0;
                     datos.Modelo = item.Modelo;
                     datos.Municipio = item.Municipio;
                     datos.NIVELID = item.CLT_NIVEL ?? 0;
                     datos.Nombre_Bien = item.INB_NOMBRE_BIEN;
                     datos.NOMBRE_NIVEL = item.CLT_NOMBRE_NIVEL;
                     datos.Otros_Nombres = item.INB_OTROS_NOMBRES;
                     datos.TIS_ID = item.TIS_ID ?? 0;
                     datos.URL_FOTOGRAFIA_BIEN = item.INB_URL_FOTOGRAFIA_BIEN;
                     datos.URL_IMAGEN_DECLARATORIA = item.DDI_URL_IMAGEN_DECLARATORIA;
                     datos.USO_ID = item.USO_ID ?? 0;
                     datos.USO_NOMBRE = item.USO_NOMBRE;
                     datos.VCM_ID = item.VCM_ID ?? 0;
                     datos.geometry = geo;

                     result.Add(datos);
                 }

                 return result;
             }
             catch (Exception ex)
             {
                 throw ex;
             }
         }
    }
}
