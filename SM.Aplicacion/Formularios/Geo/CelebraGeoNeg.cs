using SM.Datos.DTO.Geo;
using SM.Datos.Geo;
using SM.LibreriaComun.DTO.GEO;
using SM.SIPA;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SM.Aplicacion.Geo
{
    public class CelebraGeoNeg
    {
        public static List<CelebraGeoDTO> ConsultarDatosCelebra(string server, int paramAno)
        {
            try
            {
                var model = new List<CelebraGeoResultadoDTO>();
                var result = new List<CelebraGeoDTO>();
                var conciertos = new List<ART_MUSICA_EVENTOS>();
                model = CelebraGeoServicio.ConsultarConciertosCelebra(paramAno);
                //conciertos = CelebraGeoServicio.ConsultarConciertos(paramAno);

                foreach (var item in model)
                {
                    var datos = new CelebraGeoDTO();

                    var geo = new Geometry();
                    geo.Distancia = "";
                    if (item.ZON_LATITUD != null)
                        geo.Latitud = item.ZON_LATITUD.ToString();
                    if (item.ZON_LONGITUD != null)
                        geo.Longitud = item.ZON_LONGITUD.ToString();

                    datos.CantidadConciertos = item.cantidad;
                    datos.Cod_Departamento = item.CodDepartamento;
                    datos.Cod_Municipio = item.CodMunicipio;
                    datos.Departamento = item.NombreDepartamento;
                    datos.Municipio = item.NombreMunicipio;
                    datos.Ver_Mas = server + "Musica/DetalleProgramacion?Ano=" + paramAno + "&codigo=" + item.CodMunicipio;
                    datos.geometry = geo;

                    //var listResultado = conciertos.Where(x => x.CodMunicipio == item.CodMunicipio).ToList();
                    //var listadoConciertos = new List<ConciertosDTO>();
                    //foreach (var x in listResultado)
                    //{
                    //    var datosinfo = new ConciertosDTO();
                    //    datosinfo.ConciertoId = x.Id;
                    //    datosinfo.EntidadOrganizadora = x.EntidadOrganizadora;
                    //    datosinfo.Lugar = x.LugarEvento;
                    //    datosinfo.hora = x.FechaEvento.ToString("dd/MM/yyyy");
                    //    listadoConciertos.Add(datosinfo);
                    //}
                   // datos.Conciertos = listadoConciertos;
                    result.Add(datos);
                }

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ConciertosDTO> ConsultarConciertosPorMunicipio(string server, int intAno, string codMunicipio)
        {
            try
            {
                var conciertosmodel = CelebraGeoServicio.ConsultarConciertosPorMunicipio(intAno, codMunicipio);

                var listadoConciertos = new List<ConciertosDTO>();
                foreach (var x in conciertosmodel)
                {
                    var datosinfo = new ConciertosDTO();
                    datosinfo.CodMunicipio = x.CodMunicipio;
                    datosinfo.Municipio = x.Municipio;
                    datosinfo.Departamento = x.Departamento;
                    datosinfo.EntidadOrganizadora = x.EntidadOrganizadora;
                    datosinfo.Lugar = x.Lugar;
                    datosinfo.hora = x.FechaEvento.ToString("dd/MM/yyy hh:mm tt"); 
                    datosinfo.Ver_Mas = server + "Musica/DetalleProgramacion?Ano=" + intAno + "&codigo=" + x.CodMunicipio;
                    listadoConciertos.Add(datosinfo);
                }

                return listadoConciertos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ConciertosPorMunicipioDTO> ConsultarCantidadConciertosPorMun(string server, string codDepto, int paramAno)
        {
            try
            {
                var conciertosmodel = CelebraGeoServicio.ConsultarCantidadConciertosPorMun(codDepto, paramAno);

                var listadoConciertos = new List<ConciertosPorMunicipioDTO>();
                foreach (var x in conciertosmodel)
                {
                    var datosinfo = new ConciertosPorMunicipioDTO();
                    datosinfo.CodMunicipio = x.CodMunicipio;
                    datosinfo.NombreMunicipio = x.NombreMunicipio;
                    datosinfo.cantidad = x.cantidad;
                    datosinfo.ver_Mas = server + "Musica/DetalleProgramacion?Ano=" + paramAno + "&codigo=" + x.CodMunicipio;
                    listadoConciertos.Add(datosinfo);
                }

                return listadoConciertos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int CantidadMunicipiosPorDepto(string codDepto)
        {
            try
            {
                int  cantidad = CelebraGeoServicio.CantidadMunicipiosPorDepto(codDepto);



                return cantidad;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<CelebraPorcentajeGeoDTO> ConsultarPorcentajeAvanceDepartamento(string server, int paramAno)
        {
            try
            {

                var result = new List<CelebraPorcentajeGeoDTO>();
                var departamentoModel = CelebraGeoServicio.ConsultarCantidadDepartamentos();
                var celebraModel = CelebraGeoServicio.ConsultarCantidadConciertosPorDepto(paramAno);


                result = (from c in departamentoModel
                          join d in celebraModel on c.ZON_ID equals d.CodDepartamento into dm
                          from d in dm.DefaultIfEmpty()
                          select new CelebraPorcentajeGeoDTO
                          {
                              CantidadConciertoRegistrado = d == null ? 0 : d.cantidad,
                              CantidadTotalMunicipios = c.cantidad,
                              PorcentajeAvance = d == null ? 0 : (d.cantidad * 100) / c.cantidad,
                              Cod_Departamento = c.ZON_ID,
                              Departamento = c.ZON_NOMBRE
                          }).ToList();


                //result = (from d in departamentoModel
                //          join c in celebraModel on d.ZON_ID equals c.CodDepartamento
                //          select new CelebraPorcentajeGeoDTO
                //            {
                //                CantidadConciertoRegistrado = c.cantidad,
                //                CantidadTotalMunicipios = d.cantidad,
                //                PorcentajeAvance = (c.cantidad * 100) / d.cantidad,
                //                Cod_Departamento = c.CodDepartamento,
                //                Departamento = c.NombreDepartamento
                //            }).ToList();

               
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
