using SM.Datos.Agrupacion;
using SM.Datos.DTO;
using SM.Datos.Entidades;
using SM.Datos.Eventos;
using SM.LibreriaComun.DTO;
using SM.LibreriaComun.DTO.Certificacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Aplicacion.Agrupacion
{
    public class ActoresNeg
    {
        public static List<ActorHomeDataDTO> ConsultarActorHomePorTodos(string tipo = "Agente")
        {
            try
            {
                var model = new List<ActoresHomeDTO>();
                var prueba = new List<ActoresHomeDTO>();
                var listResultado = new List<ActorHomeDataDTO>();

                if (tipo == "Agente")
                    model = ActoresServicio.ConsultarAgentesHome();
                else if (tipo == "Entidad")
                    model = ActoresServicio.ConsultarEntidadesHome();
                else if (tipo == "Escuelas")
                    model = ActoresServicio.ConsultarEscuelasHome();


                if (model != null)
                {
                    foreach (var item in model)
                    {
                        var datos = new ActorHomeDataDTO();
                        if (item.ID == 0)
                            datos.ID = (int)item.ENT_ID;
                        else
                            datos.ID = item.ID;
                        datos.CodigoDepartamento = item.CodigoDepartamento;
                        datos.CodigoMunicipio = item.CodigoMunicipio;
                        datos.CodigoPais = item.CodigoPais;
                        datos.Imagen = item.Imagen;
                        datos.PaginaWeb = item.PaginaWeb;
                        datos.Departamento = item.Departamento;
                        datos.Pais = item.Pais;
                        datos.Municipio = item.Municipio;
                        if (item.Nombres.Length > 78)
                            datos.Nombres = item.Nombres.Substring(0, 79);
                        else
                            datos.Nombres = item.Nombres;
                        datos.PerfilFacebook = item.PerfilFacebook;
                        datos.PerfilSoundCloud = item.PerfilSoundCloud;
                        datos.PerfilTwitter = item.PerfilTwitter;
                        datos.CanalYoutube = item.CanalYoutube;
                        datos.Dato = item.Dato;
                        datos.Tipo = item.Tipo;
                        datos.TipoId = item.TipoId;
                        listResultado.Add(datos);
                    }

                }


                return listResultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<ActorHomeDataDTO> ConsultarActorHomePorDepartamento(string codDepto, string tipo = "Agente")
        {
            try
            {
                var model = new List<ActoresHomeDTO>();
                var prueba = new List<ActoresHomeDTO>();
                var listResultado = new List<ActorHomeDataDTO>();

                if (tipo == "Agente")
                    model = ActoresServicio.ConsultarAgentesHomePorDepartamento(codDepto);
                else if (tipo == "Entidad")
                    model = ActoresServicio.ConsultarEntidadesHomePorDepartamento(codDepto);
                else if (tipo == "Escuelas")
                    model = ActoresServicio.ConsultarEscuelasHomePorDepartamento(codDepto);



                if (model != null)
                {
                    foreach (var item in model)
                    {
                        var datos = new ActorHomeDataDTO();
                        if (item.ID == 0)
                            datos.ID = (int)item.ENT_ID;
                        else
                            datos.ID = item.ID;
                        datos.CodigoDepartamento = item.CodigoDepartamento;
                        datos.CodigoMunicipio = item.CodigoMunicipio;
                        datos.CodigoPais = item.CodigoPais;
                        datos.Imagen = item.Imagen;
                        datos.PaginaWeb = item.PaginaWeb;
                        datos.Departamento = item.Departamento;
                        datos.Pais = item.Pais;
                        datos.Municipio = item.Municipio;
                        if (item.Nombres.Length > 78)
                            datos.Nombres = item.Nombres.Substring(0, 79);
                        else
                            datos.Nombres = item.Nombres;
                        datos.PerfilFacebook = item.PerfilFacebook;
                        datos.PerfilSoundCloud = item.PerfilSoundCloud;
                        datos.PerfilTwitter = item.PerfilTwitter;
                        datos.CanalYoutube = item.CanalYoutube;
                        datos.Dato = item.Dato;
                        datos.Tipo = item.Tipo;
                        datos.TipoId = item.TipoId;
                        listResultado.Add(datos);
                    }

                }


                return listResultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ActorHomeDataDTO> ConsultarActorHomePorMunicipio(string codMunicipio, string tipo = "Agente")
        {
            try
            {
                var model = new List<ActoresHomeDTO>();
                var prueba = new List<ActoresHomeDTO>();
                var listResultado = new List<ActorHomeDataDTO>();

                if (tipo == "Agente")
                    model = ActoresServicio.ConsultarAgentesHomePorMunicipio(codMunicipio);
                else if (tipo == "Entidad")
                    model = ActoresServicio.ConsultarEntidadesHomePorMunicipio(codMunicipio);
                else if (tipo == "Escuelas")
                    model = ActoresServicio.ConsultarEscuelasHomePorMunicipio(codMunicipio);



                if (model != null)
                {
                    foreach (var item in model)
                    {
                        var datos = new ActorHomeDataDTO();
                        if (item.ID == 0)
                            datos.ID = (int)item.ENT_ID;
                        else
                            datos.ID = item.ID;
                        datos.CodigoDepartamento = item.CodigoDepartamento;
                        datos.CodigoMunicipio = item.CodigoMunicipio;
                        datos.CodigoPais = item.CodigoPais;
                        datos.Imagen = item.Imagen;
                        datos.PaginaWeb = item.PaginaWeb;
                        datos.Departamento = item.Departamento;
                        datos.Pais = item.Pais;
                        datos.Municipio = item.Municipio;
                        if (item.Nombres.Length > 78)
                            datos.Nombres = item.Nombres.Substring(0, 79);
                        else
                            datos.Nombres = item.Nombres;
                        datos.PerfilFacebook = item.PerfilFacebook;
                        datos.PerfilSoundCloud = item.PerfilSoundCloud;
                        datos.PerfilTwitter = item.PerfilTwitter;
                        datos.CanalYoutube = item.CanalYoutube;
                        datos.Dato = item.Dato;
                        datos.Tipo = item.Tipo;
                        datos.TipoId = item.TipoId;
                        listResultado.Add(datos);
                    }

                }


                return listResultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ActorHomeDataDTO> ConsultarEscuelasHomePorTipo(int tipoId, string tipo = "Escuelas")
        {
            try
            {
                var model = new List<ActoresHomeDTO>();
                var prueba = new List<ActoresHomeDTO>();
                var listResultado = new List<ActorHomeDataDTO>();

                if (tipo == "Escuelas")
                    model = ActoresServicio.ConsultarEscuelasHomePorTipo(tipoId);



                if (model != null)
                {
                    foreach (var item in model)
                    {
                        var datos = new ActorHomeDataDTO();
                        if (item.ID == 0)
                            datos.ID = (int)item.ENT_ID;
                        else
                            datos.ID = item.ID;
                        datos.CodigoDepartamento = item.CodigoDepartamento;
                        datos.CodigoMunicipio = item.CodigoMunicipio;
                        datos.CodigoPais = item.CodigoPais;
                        datos.Imagen = item.Imagen;
                        datos.PaginaWeb = item.PaginaWeb;
                        datos.Departamento = item.Departamento;
                        datos.Pais = item.Pais;
                        datos.Municipio = item.Municipio;
                        datos.Nombres = item.Nombres;
                        datos.PerfilFacebook = item.PerfilFacebook;
                        datos.PerfilSoundCloud = item.PerfilSoundCloud;
                        datos.PerfilTwitter = item.PerfilTwitter;
                        datos.CanalYoutube = item.CanalYoutube;
                        datos.Dato = item.Dato;
                        datos.Tipo = item.Tipo;
                        datos.TipoId = item.TipoId;
                        listResultado.Add(datos);
                    }

                }


                return listResultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region Escenarios
        public static List<ActorHomeDataDTO> ConsultarEscenarioTodo()
        {
            try
            {
                byte[] imagen;
                var model = new List<HomeEstandarResultado>();
                var listResultado = new List<ActorHomeDataDTO>();
                model = EscenariosServicios.ConsultarEscenariosEscenicosPublicados();

                if (model != null)
                {
                    foreach (var item in model)
                    {
                        var datos = new ActorHomeDataDTO();
                        imagen = null;
                        datos.ID = item.Id;
                        datos.CodigoDepartamento = item.CodDepto;
                        datos.CodigoMunicipio = item.CodMunicipio;
                        imagen = EscenariosServicios.ObtenerImagenPrincipal(item.Id);
                        if (imagen != null)
                            datos.Imagen = imagen;
                        datos.Departamento = item.Departamento;
                        datos.Municipio = item.Municipio;
                        if (item.Nombre.Length > 78)
                            datos.Nombres = item.Nombre.Substring(0, 79);
                        else
                            datos.Nombres = item.Nombre;
                        datos.Tipo = item.Clasificacion;
                        datos.TipoId = item.ClasificacionId;
                        listResultado.Add(datos);
                    }

                }


                return listResultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ActorHomeDataDTO> ConsultarEscenarioPorDepartamento(string codDepto)
        {
            try
            {
                byte[] imagen;
                var model = new List<HomeEstandarResultado>();
                var listResultado = new List<ActorHomeDataDTO>();
                model = EscenariosServicios.ConsultarEscenariosEscenicosPublicadosPorDepartamento(codDepto);

                if (model != null)
                {
                    foreach (var item in model)
                    {
                        var datos = new ActorHomeDataDTO();
                        imagen = null;
                        datos.ID = item.Id;
                        datos.CodigoDepartamento = item.CodDepto;
                        datos.CodigoMunicipio = item.CodMunicipio;
                        imagen = EscenariosServicios.ObtenerImagenPrincipal(item.Id);
                        if (imagen != null)
                            datos.Imagen = imagen;
                        datos.Departamento = item.Departamento;
                        datos.Municipio = item.Municipio;
                        if (item.Nombre.Length > 78)
                            datos.Nombres = item.Nombre.Substring(0, 79);
                        else
                            datos.Nombres = item.Nombre;
                        datos.Tipo = item.Clasificacion;
                        datos.TipoId = item.ClasificacionId;
                        listResultado.Add(datos);
                    }

                }


                return listResultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ActorHomeDataDTO> ConsultarEscenarioPorMunicipio(string codMunicipio)
        {
            try
            {
                byte[] imagen;
                var model = new List<HomeEstandarResultado>();
                var listResultado = new List<ActorHomeDataDTO>();
                model = EscenariosServicios.ConsultarEscenariosEscenicosPublicadosPorMunicipio(codMunicipio);

                if (model != null)
                {
                    foreach (var item in model)
                    {
                        var datos = new ActorHomeDataDTO();
                        imagen = null;
                        datos.ID = item.Id;
                        datos.CodigoDepartamento = item.CodDepto;
                        datos.CodigoMunicipio = item.CodMunicipio;
                        imagen = EscenariosServicios.ObtenerImagenPrincipal(item.Id);
                        if (imagen != null)
                            datos.Imagen = imagen;
                        datos.Departamento = item.Departamento;
                        datos.Municipio = item.Municipio;
                        if (item.Nombre.Length > 78)
                            datos.Nombres = item.Nombre.Substring(0, 79);
                        else
                            datos.Nombres = item.Nombre;
                        datos.Tipo = item.Clasificacion;
                        datos.TipoId = item.ClasificacionId;
                        listResultado.Add(datos);
                    }

                }


                return listResultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ActorHomeDataDTO> ConsultarEscenarioPorClasificacionId(int ClasificacionId)
        {
            try
            {
                byte[] imagen;
                var model = new List<HomeEstandarResultado>();
                var listResultado = new List<ActorHomeDataDTO>();
                model = EscenariosServicios.ConsultarEscenariosEscenicosPublicadosPorClasificacionId(ClasificacionId);

                if (model != null)
                {
                    foreach (var item in model)
                    {
                        var datos = new ActorHomeDataDTO();
                        imagen = null;
                        datos.ID = item.Id;
                        datos.CodigoDepartamento = item.CodDepto;
                        datos.CodigoMunicipio = item.CodMunicipio;
                        imagen = EscenariosServicios.ObtenerImagenPrincipal(item.Id);
                        if (imagen != null)
                            datos.Imagen = imagen;
                        datos.Departamento = item.Departamento;
                        datos.Municipio = item.Municipio;
                        if (item.Nombre.Length > 78)
                            datos.Nombres = item.Nombre.Substring(0, 79);
                        else
                            datos.Nombres = item.Nombre;
                        datos.Tipo = item.Clasificacion;
                        datos.TipoId = item.ClasificacionId;
                        listResultado.Add(datos);
                    }

                }


                return listResultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region EventosPeriodicos
        public static List<ActorHomeDataDTO> ConsultarEventosTodo()
        {
            try
            {
                byte[] imagen;
                var model = new List<HomeEstandarResultado>();
                var listResultado = new List<ActorHomeDataDTO>();
                model = EventosPeriodicosServicio.ConsultarEventosPublicados();

                if (model != null)
                {
                    foreach (var item in model)
                    {
                        var datos = new ActorHomeDataDTO();
                        imagen = null;
                        datos.ID = item.Id;
                        datos.CodigoDepartamento = item.CodDepto;
                        datos.CodigoMunicipio = item.CodMunicipio;
                        imagen = EscenariosServicios.ObtenerImagenPrincipal(item.Id);
                        if (imagen != null)
                            datos.Imagen = imagen;
                        datos.Departamento = item.Departamento;
                        datos.Municipio = item.Municipio;
                        if (item.Nombre.Length > 78)
                            datos.Nombres = item.Nombre.Substring(0, 79);
                        else
                            datos.Nombres = item.Nombre;
                        datos.Tipo = item.Clasificacion;
                        datos.TipoId = item.ClasificacionId;
                        listResultado.Add(datos);
                    }

                }


                return listResultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ActorHomeDataDTO> ConsultarEventosPorDepartamento(string codDepto)
        {
            try
            {
                byte[] imagen;
                var model = new List<HomeEstandarResultado>();
                var listResultado = new List<ActorHomeDataDTO>();
                model = EventosPeriodicosServicio.ConsultarEventosPublicadosPorDepartamento(codDepto);

                if (model != null)
                {
                    foreach (var item in model)
                    {
                        var datos = new ActorHomeDataDTO();
                        imagen = null;
                        datos.ID = item.Id;
                        datos.CodigoDepartamento = item.CodDepto;
                        datos.CodigoMunicipio = item.CodMunicipio;
                        imagen = EscenariosServicios.ObtenerImagenPrincipal(item.Id);
                        if (imagen != null)
                            datos.Imagen = imagen;
                        datos.Departamento = item.Departamento;
                        datos.Municipio = item.Municipio;
                        if (item.Nombre.Length > 78)
                            datos.Nombres = item.Nombre.Substring(0, 79);
                        else
                            datos.Nombres = item.Nombre;
                        datos.Tipo = item.Clasificacion;
                        datos.TipoId = item.ClasificacionId;
                        listResultado.Add(datos);
                    }

                }


                return listResultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ActorHomeDataDTO> ConsultarEventosPorMunicipio(string codMunicipio)
        {
            try
            {
                byte[] imagen;
                var model = new List<HomeEstandarResultado>();
                var listResultado = new List<ActorHomeDataDTO>();
                model = EventosPeriodicosServicio.ConsultarEventosPublicadosPorMunicipio(codMunicipio);

                if (model != null)
                {
                    foreach (var item in model)
                    {
                        var datos = new ActorHomeDataDTO();
                        imagen = null;
                        datos.ID = item.Id;
                        datos.CodigoDepartamento = item.CodDepto;
                        datos.CodigoMunicipio = item.CodMunicipio;
                        imagen = EscenariosServicios.ObtenerImagenPrincipal(item.Id);
                        if (imagen != null)
                            datos.Imagen = imagen;
                        datos.Departamento = item.Departamento;
                        datos.Municipio = item.Municipio;
                        if (item.Nombre.Length > 78)
                            datos.Nombres = item.Nombre.Substring(0, 79);
                        else
                            datos.Nombres = item.Nombre;
                        datos.Tipo = item.Clasificacion;
                        datos.TipoId = item.ClasificacionId;
                        listResultado.Add(datos);
                    }

                }


                return listResultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ActorHomeDataDTO> ConsultarEventosporClasificacionId(int ClasificacionId)
        {
            try
            {
                byte[] imagen;
                var model = new List<HomeEstandarResultado>();
                var listResultado = new List<ActorHomeDataDTO>();
                model = EventosPeriodicosServicio.ConsultarEventosPublicadosPorClasificacionId(ClasificacionId);

                if (model != null)
                {
                    foreach (var item in model)
                    {
                        var datos = new ActorHomeDataDTO();
                        imagen = null;
                        datos.ID = item.Id;
                        datos.CodigoDepartamento = item.CodDepto;
                        datos.CodigoMunicipio = item.CodMunicipio;
                        imagen = EscenariosServicios.ObtenerImagenPrincipal(item.Id);
                        if (imagen != null)
                            datos.Imagen = imagen;
                        datos.Departamento = item.Departamento;
                        datos.Municipio = item.Municipio;
                        if (item.Nombre.Length > 78)
                            datos.Nombres = item.Nombre.Substring(0, 79);
                        else
                            datos.Nombres = item.Nombre;
                        datos.Tipo = item.Clasificacion;
                        datos.TipoId = item.ClasificacionId;
                        listResultado.Add(datos);
                    }

                }


                return listResultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Certificacion

        public static CertificacionDTO ConsultarCertificacionEscuelas(decimal EscuelaId)
        {
            var registro = new CertificacionDTO();
            try
            {
                return registro = ActoresServicio.ConsultarCertificacionEscuelas(EscuelaId);
            }
              
           
            catch (Exception ex)
            {
                throw ex;
            }    

        }

        public static CertificacionDTO ConsultarCertificacionAgentes(int Id)
        {
            var registro = new CertificacionDTO();
            try
            {
                return registro = ActoresServicio.ConsultarCertificacionAgentes(Id);
            }


            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static CertificacionDTO ConsultarCertificacionAgrupacion(int Id)
        {
            var registro = new CertificacionDTO();
            try
            {
                return registro = ActoresServicio.ConsultarCertificacionAgrupacion(Id);
            }


            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static CertificacionDTO ConsultarCertificacionEntidad(int Id)
        {
            var registro = new CertificacionDTO();
            try
            {
                return registro = ActoresServicio.ConsultarCertificacionEntidad(Id);
            }


            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion
    }
}
