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
    public static class MapaMusicalNeg
    {
        public static List<MunicipiosGeoDTO> ConsultarTradicionalMunicipios(string server)
        {
            try
            {
                var model = new List<TradicionalMunicipioResultadoDTO>();
                var modelGeneros = new List<TradicionalGeneroResultadoDTO>();
                var result = new List<MunicipiosGeoDTO>();
                model = MapaMusicalServicio.ConsultarMunicipiosMusicaTradicional();
       
                foreach (var item in model)
                {
                    var datos = new MunicipiosGeoDTO();
                    var geo = new Geometry();
                    geo.Latitud = item.Latitud.ToString();
                    geo.Longitud = item.Longitud.ToString();
                    datos.Cod_Departamento = item.CodDepartamento;
                    datos.Cod_Municipio = item.CodMunicipio;
                    datos.Departamento = item.Departamento;
                    datos.Municipio = item.Municipio;
                    datos.Ubicacion = item.Municipio + ", " + item.Departamento;
                    datos.EjeId = item.EjeId;
                    datos.Eje = item.Eje;
                    datos.Ver_Mas = server + "ReporteMapas/Eje/" + item.EjeId;
                    datos.Foto = server + item.Foto;
                    datos.Cantidad = item.Cantidad;
                    datos.Estilo = item.Estilo;

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

        public static List<MunicipiosGeoDTO> ConsultarTradicionalMunicipios(string server, string codMunicipio)
        {
            try
            {
                var model = new List<TradicionalMunicipioResultadoDTO>();
                var modelGeneros = new List<TradicionalGeneroResultadoDTO>();
                var result = new List<MunicipiosGeoDTO>();
                model = MapaMusicalServicio.ConsultarMunicipiosMusicaTradicionalPorCodigo(codMunicipio);
                modelGeneros = MapaMusicalServicio.ConsultarGenerosMusicaTradicional();

                foreach (var item in model)
                {
                    var datos = new MunicipiosGeoDTO();
                    var geo = new Geometry();
                    geo.Latitud = item.Latitud.ToString();
                    geo.Longitud = item.Longitud.ToString();
                    datos.Cod_Departamento = item.CodDepartamento;
                    datos.Cod_Municipio = item.CodMunicipio;
                    datos.Departamento = item.Departamento;
                    datos.Municipio = item.Municipio;
                    datos.Ubicacion = item.Municipio + ", " + item.Departamento;
                    datos.EjeId = item.EjeId;
                    datos.Eje = item.Eje;
                    datos.Ver_Mas = server + "ReporteMapas/Eje/" + item.EjeId;
                    datos.Foto = server + item.Foto;
                    datos.Cantidad = item.Cantidad;
                    datos.Estilo = item.Estilo;

                    datos.geometry = geo;

                    var listResultado = modelGeneros.Where(x => x.CodMunicipio == item.CodMunicipio && x.IdEje == item.EjeId).ToList();
                    var listGeneros = new List<GenerosGeoDTO>();

                    foreach (var x in listResultado)
                    {

                        var datosinfo = new GenerosGeoDTO();
                        datosinfo.IdEje = x.IdEje;
                        datosinfo.NombreEje = x.NombreEje;
                        datosinfo.Detalle = x.Detalle;
                        datosinfo.Genero = x.Genero;
                        datosinfo.GeneroId = x.GeneroId;
                        datosinfo.NombreArchivo = x.NombreArchivo;
                        datosinfo.Ruta = server + x.Ruta + x.NombreArchivo;
                        datosinfo.Titulo = x.Titulo;
                        listGeneros.Add(datosinfo);
                    }

                    datos.ListGeneros = listGeneros;
                    result.Add(datos);
                }

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static MunicipiosGeoDTO ConsultarTradicionalMunicipiosModal(string server, string codMunicipio)
        {
            try
            {
                var model = new List<TradicionalMunicipioResultadoDTO>();
                var registro = new TradicionalMunicipioResultadoDTO();
                var listResultado = new List<TradicionalGeneroResultadoDTO>();
                var datos = new MunicipiosGeoDTO();
                model = MapaMusicalServicio.ConsultarMunicipiosMusicaTradicionalPorCodigo(codMunicipio);
                if (model != null && model.Count > 0)
                {
                    registro = model[0];
                    listResultado = MapaMusicalServicio.ConsultarGenerosMusicaTradicionalModal(registro.EjeId, codMunicipio);

                    
                    var geo = new Geometry();

                    datos.Cod_Departamento = registro.CodDepartamento;
                    datos.Cod_Municipio = registro.CodMunicipio;
                    datos.Departamento = registro.Departamento;
                    datos.Municipio = registro.Municipio;
                    datos.Ubicacion = registro.Municipio + ", " + registro.Departamento;
                    datos.EjeId = registro.EjeId;
                    datos.Eje = registro.Eje;
                    datos.Ver_Mas = server + "ReporteMapas/Eje/" + registro.EjeId;
                    datos.Foto = server + registro.Foto;
                    datos.Cantidad = registro.Cantidad;
                    datos.Estilo = registro.Estilo;

                    var listGeneros = new List<GenerosGeoDTO>();
                    foreach (var x in listResultado)
                    {

                        var datosinfo = new GenerosGeoDTO();
                        datosinfo.IdEje = x.IdEje;
                        datosinfo.NombreEje = x.NombreEje;
                        datosinfo.Detalle = x.Detalle;
                        datosinfo.Genero = x.Genero;
                        datosinfo.GeneroId = x.GeneroId;
                        datosinfo.NombreArchivo = x.NombreArchivo;
                        datosinfo.Ruta = server + x.Ruta + x.NombreArchivo;
                        datosinfo.Titulo = x.Titulo;
                        listGeneros.Add(datosinfo);
                    }

                    datos.ListGeneros = listGeneros;

                }


                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static EjeDTO ConsultarEJeResena(int Id, string server)
        {
            try
            {
                var result = new EjeDTO();
                var modelGeneros = new List<TradicionalGeneroResultadoDTO>();
                var model = MapaMusicalServicio.ConsultarEJeResena(Id);
                modelGeneros = MapaMusicalServicio.ConsultarGenerosPorEjeId(Id);

                if (model != null)
                {
                    result.Eje = model.Nombre;
                    result.EjeId = model.Id;
                    result.Resena = model.Resena;
                    result.RutaFoto = model.RutaFoto;
                    //model.Ruta = "img/Tradicionales/Islena/";
                    result.RutaGaleria1 = server + model.Ruta + "1.jpg";
                    result.RutaGaleria2 = server + model.Ruta + "2.jpg";
                    result.RutaGaleria3 = server + model.Ruta + "3.jpg";
                    result.RutaGaleria4 = server + model.Ruta + "4.jpg";

                    //if (model.Id == 1)
                    //    result.RutaMarcador = server + "img/marcadores/andina_centro.png";
                    //else if (model.Id == 2)
                    //    result.RutaMarcador = server + "img/marcadores/andina_centrosu.png";
                    //else if (model.Id == 3)
                    //    result.RutaMarcador = server + "img/marcadores/andina_noocc.png";
                    //else if (model.Id == 4)
                    //    result.RutaMarcador = server + "img/marcadores/andina_suro.png";
                    //else if (model.Id == 5)
                    //    result.RutaMarcador = server + "img/marcadores/caribe.png";
                    //else if (model.Id == 6)
                    //    result.RutaMarcador = server + "img/marcadores/caribe_oriental.png";
                    //else if (model.Id == 7)
                    //    result.RutaMarcador = server + "img/marcadores/frontera.png";
                    //else if (model.Id == 8)
                    //    result.RutaMarcador = server + "img/marcadores/islenas.png";
                    //else if (model.Id == 9)
                    //    result.RutaMarcador = server + "img/marcadores/llanera.png";
                    //else if (model.Id == 10)
                    //    result.RutaMarcador = server + "img/marcadores/pacifico_norte.png";
                    //else if (model.Id == 11)
                    //    result.RutaMarcador = server + "img/marcadores/pacifico_sur.png";
                    //else if (model.Id == 12)
                    //    result.RutaMarcador = server + "img/marcadores/indigenas.png";

                    if (model.Id == 1)
                        result.RutaMarcador = "iconos_usuarios fa-infraestructura fa-2x color-andina-co";
                    else if (model.Id == 2)
                        result.RutaMarcador = "iconos_usuarios fa-andina-cs fa-2x color-andina-cs";
                    else if (model.Id == 3)
                        result.RutaMarcador = "iconos_usuarios fa-andina-suro fa-2x color-andina-norocc";
                    else if (model.Id == 4)
                        result.RutaMarcador = "iconos_usuarios fa-andina-so fa-2x color-andina-surocc";
                    else if (model.Id == 5)
                        result.RutaMarcador = "iconos_usuarios fa-caribe-occ fa-2x color-caribe-occ";
                    else if (model.Id == 6)
                        result.RutaMarcador = "iconos_usuarios fa-caribe-o fa-2x color-caribe-oriental";
                    else if (model.Id == 7)
                        result.RutaMarcador = "iconos_usuarios fa-frontera fa-2x color-frontera";
                    else if (model.Id == 8)
                        result.RutaMarcador = "iconos_usuarios fa-islena fa-2x color-islena";
                    else if (model.Id == 9)
                        result.RutaMarcador = "iconos_usuarios fa-llanera fa-2x color-llanera";
                    else if (model.Id == 10)
                        result.RutaMarcador = "iconos_usuarios fa-pacifico-n fa-2x color-pacifico-n";
                    else if (model.Id == 11)
                        result.RutaMarcador = "iconos_usuarios fa-pacifico-s fa-2x color-pacifico-s";
                    else if (model.Id == 12)
                        result.RutaMarcador = "iconos_usuarios fa-indigenas fa-2x color-indigenas";


                    var listGeneros = new List<GenerosGeoDTO>();

                    foreach (var x in modelGeneros)
                    {

                        var datosinfo = new GenerosGeoDTO();
                        datosinfo.IdEje = x.IdEje;
                        datosinfo.NombreEje = x.NombreEje;
                        datosinfo.Detalle = x.Detalle;
                        datosinfo.Genero = x.Genero;
                        datosinfo.GeneroId = x.GeneroId;
                        datosinfo.NombreArchivo = x.NombreArchivo;
                        datosinfo.Ruta = server + x.Ruta + x.NombreArchivo;
                        datosinfo.Titulo = x.Titulo;
                        listGeneros.Add(datosinfo);
                    }

                    result.listadoGeneros = listGeneros;

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
