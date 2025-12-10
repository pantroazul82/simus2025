using SM.LibreriaComun.DTO.GEO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SM.Datos.Geo;
using SM.Datos.DTO.Geo;
using SM.SIPA;

namespace SM.Aplicacion.Geo
{
    public class GeoNeg
    {
        public static List<EscuelaGeoDTO> ConsultarEscuelas(string server)
        {
            try
            {
                var model = new List<EscuelasGeoResultadoDto>();
                var result = new List<EscuelaGeoDTO>();
                model = GeoServicio.ConsultarEscuelas();


                foreach (var item in model)
                {
                    var datos = new EscuelaGeoDTO();
                    var geo = new Geometry();
                    geo.Distancia = "";


                    if (item.Latitud == 0)
                    {
                        geo.Latitud = item.LatitudMunicipio.ToString();
                        geo.Longitud = item.LongitudMunicipio.ToString();
                    }
                    else
                    {
                        geo.Latitud = item.Latitud.ToString();
                        geo.Longitud = item.Longitud.ToString();
                    }

                    datos.Cod_Departamento = item.CodigoDepartamento;
                    datos.Cod_Municipio = item.CodigoMunicipio;
                    datos.CorreoElectronico = item.CorreoElectronico;
                    datos.Departamento = item.Departamento;
                    datos.Direccion = item.Direccion;
                    datos.Id = Convert.ToInt32(item.ENT_ID);
                    datos.Municipio = item.Municipio;
                    datos.Naturaleza = item.Naturaleza;
                    datos.Nombre = item.Nombre;
                    datos.PaginaWeb = item.PaginaWeb;
                    datos.Telefono = item.Telefono;
                    datos.TipoEscuela = item.TipoEscuela;
                    datos.TipoEscuelaId = item.TipoEscuelaId; 
                    datos.UrlFacebook = item.UrlFacebook;
                    datos.UrlTwitter = item.UrlTwitter;
                    datos.UrlYoutube = item.UrlYoutube;
                    datos.Ver_Mas = server + "Home/Ficha/" + item.ENT_ID.ToString();
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

        public static List<EscuelaGeoDTO> ConsultarEscuelasPorCodigoMunicipio(string server, string codMunicipio)
        {
            try
            {
                var model = new List<EscuelasGeoResultadoDto>();
                var result = new List<EscuelaGeoDTO>();
                model = GeoServicio.ConsultarEscuelasPorCodigoMunicipio(codMunicipio);


                foreach (var item in model)
                {
                    var datos = new EscuelaGeoDTO();
                    var geo = new Geometry();
                    geo.Distancia = "";


                    if (item.Latitud == 0)
                    {
                        geo.Latitud = item.LatitudMunicipio.ToString();
                        geo.Longitud = item.LongitudMunicipio.ToString();
                    }
                    else
                    {
                        geo.Latitud = item.Latitud.ToString();
                        geo.Longitud = item.Longitud.ToString();
                    }

                    datos.Cod_Departamento = item.CodigoDepartamento;
                    datos.Cod_Municipio = item.CodigoMunicipio;
                    datos.CorreoElectronico = item.CorreoElectronico;
                    datos.Departamento = item.Departamento;
                    datos.Direccion = item.Direccion;
                    datos.Id = Convert.ToInt32(item.ENT_ID);
                    datos.Municipio = item.Municipio;
                    datos.Naturaleza = item.Naturaleza;
                    datos.Nombre = item.Nombre;
                    datos.PaginaWeb = item.PaginaWeb;
                    datos.Telefono = item.Telefono;
                    datos.TipoEscuela = item.TipoEscuela;
                    datos.TipoEscuelaId = item.TipoEscuelaId;
                    datos.UrlFacebook = item.UrlFacebook;
                    datos.UrlTwitter = item.UrlTwitter;
                    datos.UrlYoutube = item.UrlYoutube;
                    datos.Ver_Mas = server + "Home/Ficha/" + item.ENT_ID.ToString();
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

        public static List<AgentesDptoDTO> ConsultarAgentesPorDepartamento()
        {
            try
            {
                var model = new List<CelebraResultadoDptoDTO>();
                var result = new List<AgentesDptoDTO>();
                model = GeoServicio.ConsultarAgentesPorDepartamento();


                foreach (var item in model)
                {
                    var datos = new AgentesDptoDTO();
                    
                    datos.Cod_Departamento = item.CodDepartamento;
                    datos.Departamento = item.NombreDepartamento;
                    datos.Cantidad = item.cantidad;
                    datos.PorcentajeAvance = item.cantidad;
                    
                    result.Add(datos);
                }

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<AgenteMunicipioDTO> ConsultarAgentesPorMunicipio(string CodDepto)
        {
            try
            {
                var model = new List<AgenteMunicipioResultadoDTO>();
                var result = new List<AgenteMunicipioDTO>();
                model = GeoServicio.ConsultarAgentesPoMunicipio(CodDepto);


                foreach (var item in model)
                {
                    var datos = new AgenteMunicipioDTO();

                    datos.CodDepartamento = item.CodDepartamento;
                    datos.CodMunicipio = item.CodMunicipio;
                    datos.cantidad = item.cantidad;
                    datos.Municipio = item.Municipio;

                    result.Add(datos);
                }

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<AgentesGeoDTO> ConsultarAgentes(string server)
        {
            try
            {
                var model = new List<AgentesGeoResultadoDTO>();
                var result = new List<AgentesGeoDTO>();
                model = GeoServicio.ConsultarAgentes();


                foreach (var item in model)
                {
                    var datos = new AgentesGeoDTO();
                    var geo = new Geometry();
                    geo.Distancia = "";
                    geo.Latitud = item.LatitudMunicipio.ToString();
                    geo.Longitud = item.LongitudMunicipio.ToString();
                    datos.Cod_Departamento = item.CodigoDepartamento;
                    datos.Cod_Municipio = item.CodigoMunicipio;
                    datos.Cod_Pais = item.CodPais;
                    datos.Pais = item.Pais;
                    datos.Departamento = item.Departamento;
                    datos.Id = item.Id;
                    datos.Municipio = item.Municipio;
                    datos.Nombre = item.Nombres;
                    datos.PaginaWeb = item.PaginaWeb;
                    datos.UrlFacebook = item.PerfilFacebook;
                    datos.UrlTwitter = item.PerfilTwitter;
                    datos.UrlYoutube = item.CanalYoutube;
                    datos.UrlSoundCloud = item.PerfilSoundCloud;
                    datos.UrlFlickr = item.PerfilFlickr;
                    datos.Ver_Mas = server + "Home/DetalleAgente/" + item.Id.ToString();
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

        public static List<EntidadesGeoDTO> ConsultarEntidades(string server)
        {
            try
            {
                var model = new List<EntidadesGeoResultadoDTO>();
                var result = new List<EntidadesGeoDTO>();
                model = GeoServicio.ConsultarEntidades();


                foreach (var item in model)
                {
                    var datos = new EntidadesGeoDTO();
                    var geo = new Geometry();
                    geo.Distancia = "";
                    if (String.IsNullOrEmpty(item.Latitud))
                    {
                        geo.Latitud = item.LatitudMunicipio.ToString();
                        geo.Longitud = item.LongitudMunicipio.ToString();
                    }
                    else
                    {
                        geo.Latitud = item.Latitud.ToString();
                        geo.Longitud = item.Longitud.ToString();
                    }
                    datos.Nit = item.Nit.ToString();
                    datos.Naturaleza = item.Naturaleza;
                    datos.Direccion = item.Direccion;
                    datos.Telefono = item.Telefono;
                    datos.CorreoElectronico = item.CorreoElectronico;
                    datos.Cod_Departamento = item.CodigoDepartamento;
                    datos.Cod_Municipio = item.CodigoMunicipio;
                    datos.Cod_Pais = item.CodPais.ToString();
                    datos.Pais = item.Pais;
                    datos.Departamento = item.Departamento;
                    datos.Id = item.Id;
                    datos.Municipio = item.Municipio;
                    datos.Nombre = item.Nombres;
                    datos.PaginaWeb = item.PaginaWeb;
                    datos.UrlFacebook = item.PerfilFacebook;
                    datos.UrlTwitter = item.PerfilTwitter;
                    datos.UrlYoutube = item.CanalYoutube;
                    datos.UrlSoundCloud = item.PerfilSoundCloud;
                    datos.UrlFlickr = item.PerfilFlickr;
                    datos.Ver_Mas = server + "Home/DetalleEntidad/" + item.Id.ToString();
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

        public static List<EntidadesGeoDTO> ConsultarEntidades(string server, string codMunicipio)
        {
            try
            {
                var model = new List<EntidadesGeoResultadoDTO>();
                var result = new List<EntidadesGeoDTO>();
                model = GeoServicio.ConsultarEntidadesPorCodigoMunicipio(codMunicipio);


                foreach (var item in model)
                {
                    var datos = new EntidadesGeoDTO();
                    var geo = new Geometry();
                    geo.Distancia = "";
                    if (String.IsNullOrEmpty(item.Latitud))
                    {
                        geo.Latitud = item.LatitudMunicipio.ToString();
                        geo.Longitud = item.LongitudMunicipio.ToString();
                    }
                    else
                    {
                        geo.Latitud = item.Latitud.ToString();
                        geo.Longitud = item.Longitud.ToString();
                    }
                    datos.Nit = item.Nit.ToString();
                    datos.Naturaleza = item.Naturaleza;
                    datos.Direccion = item.Direccion;
                    datos.Telefono = item.Telefono;
                    datos.CorreoElectronico = item.CorreoElectronico;
                    datos.Cod_Departamento = item.CodigoDepartamento;
                    datos.Cod_Municipio = item.CodigoMunicipio;
                    datos.Cod_Pais = item.CodPais.ToString();
                    datos.Pais = item.Pais;
                    datos.Departamento = item.Departamento;
                    datos.Id = item.Id;
                    datos.Municipio = item.Municipio;
                    datos.Nombre = item.Nombres;
                    datos.PaginaWeb = item.PaginaWeb;
                    datos.UrlFacebook = item.PerfilFacebook;
                    datos.UrlTwitter = item.PerfilTwitter;
                    datos.UrlYoutube = item.CanalYoutube;
                    datos.UrlSoundCloud = item.PerfilSoundCloud;
                    datos.UrlFlickr = item.PerfilFlickr;
                    datos.Ver_Mas = server + "Home/DetalleEntidad/" + item.Id.ToString();
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

        public static List<EntidadesGeoDTO> ConsultarAgrupaciones(string server)
        {
            try
            {
                var model = new List<AgrupacionGeoResultadoDTO>();
                var result = new List<EntidadesGeoDTO>();
                model = GeoServicio.ConsultarAgrupaciones();


                foreach (var item in model)
                {
                    var datos = new EntidadesGeoDTO();
                    var geo = new Geometry();
                    geo.Distancia = "";
                    if (String.IsNullOrEmpty(item.Latitud))
                    {
                        geo.Latitud = item.LatitudMunicipio.ToString();
                        geo.Longitud = item.LongitudMunicipio.ToString();
                    }
                    else
                    {
                        geo.Latitud = item.Latitud.ToString();
                        geo.Longitud = item.Longitud.ToString();
                    }

                    datos.Direccion = item.Direccion;
                    datos.Telefono = item.Telefono;
                    datos.CorreoElectronico = item.CorreoElectronico;
                    datos.Cod_Departamento = item.CodigoDepartamento;
                    datos.Cod_Municipio = item.CodigoMunicipio;
                    datos.Cod_Pais = item.CodPais.ToString();
                    datos.Pais = item.Pais;
                    datos.Departamento = item.Departamento;
                    datos.Id = item.Id;
                    datos.Municipio = item.Municipio;
                    datos.Nombre = item.Nombres;
                    datos.PaginaWeb = item.PaginaWeb;
                    datos.UrlFacebook = item.PerfilFacebook;
                    datos.UrlTwitter = item.PerfilTwitter;
                    datos.UrlYoutube = item.CanalYoutube;
                    datos.UrlSoundCloud = item.PerfilSoundCloud;
                    datos.UrlFlickr = item.PerfilFlickr;
                    datos.Ver_Mas = server + "Home/DetalleAgrupacion/" + item.Id.ToString();
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

        public static List<EntidadesGeoDTO> ConsultarAgrupaciones(string server, string codMunicipio)
        {
            try
            {
                var model = new List<AgrupacionGeoResultadoDTO>();
                var result = new List<EntidadesGeoDTO>();
                model = GeoServicio.ConsultarAgrupacionesPorCodigoMunicipio(codMunicipio);


                foreach (var item in model)
                {
                    var datos = new EntidadesGeoDTO();
                    var geo = new Geometry();
                    geo.Distancia = "";
                    if (String.IsNullOrEmpty(item.Latitud))
                    {
                        geo.Latitud = item.LatitudMunicipio.ToString();
                        geo.Longitud = item.LongitudMunicipio.ToString();
                    }
                    else
                    {
                        geo.Latitud = item.Latitud.ToString();
                        geo.Longitud = item.Longitud.ToString();
                    }

                    datos.Direccion = item.Direccion;
                    datos.Telefono = item.Telefono;
                    datos.CorreoElectronico = item.CorreoElectronico;
                    datos.Cod_Departamento = item.CodigoDepartamento;
                    datos.Cod_Municipio = item.CodigoMunicipio;
                    datos.Cod_Pais = item.CodPais.ToString();
                    datos.Pais = item.Pais;
                    datos.Departamento = item.Departamento;
                    datos.Id = item.Id;
                    datos.Municipio = item.Municipio;
                    datos.Nombre = item.Nombres;
                    datos.PaginaWeb = item.PaginaWeb;
                    datos.UrlFacebook = item.PerfilFacebook;
                    datos.UrlTwitter = item.PerfilTwitter;
                    datos.UrlYoutube = item.CanalYoutube;
                    datos.UrlSoundCloud = item.PerfilSoundCloud;
                    datos.UrlFlickr = item.PerfilFlickr;
                    datos.Ver_Mas = server + "Home/DetalleAgrupacion/" + item.Id.ToString();
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


        public static List<EscuelaDepartamentoDTO> ConsultarEscuelasPorDepartamento(string server)
        {
            try
            {

                var result = new List<EscuelaDepartamentoDTO>();
                var escuelasmodel = GeoServicio.ConsultarEscuelasPorDepartamento();
                var departamentoModel = CelebraGeoServicio.ConsultarCantidadDepartamentos();
                //var municipiomodel = GeoServicio.ConsultarEscuelasPorMunicipio();

                result = (from d in departamentoModel
                          join c in escuelasmodel on d.ZON_ID equals c.CodDepartamento
                          select new EscuelaDepartamentoDTO
                         {
                             CantidadMunicipiosEscuelas = c.cantidad,
                             CantidadTotalMunicipios = d.cantidad,
                             porcentajeAvance = (c.cantidad * 100) / d.cantidad,
                             Cod_Departamento = c.CodDepartamento,
                             Departamento = c.NombreDepartamento
                         }).ToList();

               
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<EscuelaDepartamentoDTO> ConsultarEscuelasPorDepartamentoIndicadores(int periodo)
        {
            try
            {
                var escuelasmodel = new List<CelebraResultadoDptoDTO>();
                var result = new List<EscuelaDepartamentoDTO>();
                if (periodo == 1)
                 escuelasmodel = GeoServicio.ConsultarEscuelasPorDepartamento();
                else
                    escuelasmodel = GeoServicio.ConsultarEscuelasPorDepartamentoHistorico(periodo);

                var departamentoModel = CelebraGeoServicio.ConsultarCantidadDepartamentos();
              

                result = (from d in departamentoModel
                          join c in escuelasmodel on d.ZON_ID equals c.CodDepartamento
                          select new EscuelaDepartamentoDTO
                          {
                              CantidadMunicipiosEscuelas = c.cantidad,
                              CantidadTotalMunicipios = d.cantidad,
                              porcentajeAvance = (c.cantidad * 100) / d.cantidad,
                              Cod_Departamento = c.CodDepartamento,
                              Departamento = c.NombreDepartamento
                          }).ToList();


                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<EscuelaMunicipioDTO> ConsultarEscuelasPorMunicipio(string CodDeparamento)
        {
            try
            {

                var municipiomodel = GeoServicio.ConsultarDatosEscuelasPoMunicipio(CodDeparamento);
                var listadoMunicipio = new List<EscuelaMunicipioDTO>();
                foreach (var x in municipiomodel)
                    {
                        var datosMun = new EscuelaMunicipioDTO();
                        datosMun.Cantidad = x.Cantidad;
                        datosMun.Cantidad_Mixta = x.Cantidad_Mixta;
                        datosMun.Cantidad_Privada = x.Cantidad_Privada;
                        datosMun.Cantidad_Publica = x.Cantidad_Publica;
                        datosMun.Cod_Departamento = x.CodDepartamento;
                        datosMun.Cod_Municipio = x.CodMunicipio;
                        datosMun.Municipio = x.Municipio;
                        listadoMunicipio.Add(datosMun);
                    }


                return listadoMunicipio;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
