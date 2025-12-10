using SM.Datos.DTO;
using SM.Datos.DTO.Servicios;
using SM.Datos.Servicios;
using SM.LibreriaComun.DTO;
using SM.LibreriaComun.DTO.Servicios;
using SM.SIPA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Aplicacion.Servicios
{
    public class ConvocatoriaNeg
    {
        public static List<EstandarDTO> ConsultarParametros(int CategoriaId)
        {
            var lisParametro = new List<EstandarDTO>();
            try
            {
                List<Basica> Parametrodatos = ConvocatoriaServicio.ConsultarParametros(CategoriaId);

                foreach (var item in Parametrodatos)
                {
                    EstandarDTO objParametro = new EstandarDTO();
                    objParametro.Id = item.Value;
                    objParametro.Nombre = item.Nombre;
                    lisParametro.Add(objParametro);
                }

                lisParametro = lisParametro.OrderBy(d => d.Nombre).ToList();

                return lisParametro;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static List<EstandarDTO> ConsultarParametrosOrdenarPorId(int CategoriaId)
        {
            var lisParametro = new List<EstandarDTO>();
            try
            {
                List<Basica> Parametrodatos = ConvocatoriaServicio.ConsultarParametros(CategoriaId);

                foreach (var item in Parametrodatos)
                {
                    EstandarDTO objParametro = new EstandarDTO();
                    objParametro.Id = item.Value;
                    objParametro.Nombre = item.Nombre;
                    lisParametro.Add(objParametro);
                }

                lisParametro = lisParametro.OrderBy(d => d.Id).ToList();

                return lisParametro;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<BasicaDTO> ConsultarCategoria(int CategoriaId)
        {
            var lisParametro = new List<BasicaDTO>();
            try
            {
                List<Basica> Parametrodatos = ConvocatoriaServicio.ConsultarParametros(CategoriaId);

                foreach (var item in Parametrodatos)
                {
                    BasicaDTO objParametro = new BasicaDTO();
                    objParametro.value = item.Value;
                    objParametro.text = item.Nombre;
                    lisParametro.Add(objParametro);
                }

                lisParametro = lisParametro.OrderBy(d => d.text).ToList();

                return lisParametro;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<BasicaDTO> ConsultarCategoriaPorConvocatoria(int ConvocatoriaId)
        {
            var lisParametro = new List<BasicaDTO>();
            try
            {
                List<Parametro> Parametrodatos = ConvocatoriaServicio.ConsultarDirigidoA(ConvocatoriaId);

                foreach (var item in Parametrodatos)
                {
                    BasicaDTO objParametro = new BasicaDTO();
                    objParametro.value = item.Id.ToString();
                    objParametro.text = item.Nombre;
                    lisParametro.Add(objParametro);
                }

                lisParametro = lisParametro.OrderBy(d => d.text).ToList();

                return lisParametro;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int ObtenerCategoriaId(int inId)
        {
            int CategoriaId = 0;
            try
            {
                CategoriaId = ConvocatoriaServicio.ObtenerCategoriaId(inId);

                return CategoriaId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int ObtenerId(string nombre)
        {
            int CategoriaId = 0;
            try
            {
                CategoriaId = ConvocatoriaServicio.ObtenerId(nombre);

                return CategoriaId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string ObtenerNombreParametro(int inId)
        {
            string nombre = "";
            try
            {
                nombre = ConvocatoriaServicio.ObtenerNombreParametro(inId);

                return nombre;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string ObtenerNombreConvocatoria(int Id)
        {
            string nombre = "";
            try
            {
                nombre = ConvocatoriaServicio.ObtenerNombreConvocatoria(Id);

                return nombre;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<ConvocatoriaListDTO> ConsultarConvocatoriaPorEstadoId(int estadoId)
        {
            try
            {
                var model = new List<ConvocatoriaResultadoDTO>();
                var listEntidad = new List<ConvocatoriaListDTO>();
                model = ConvocatoriaServicio.ConsultarConvocatoriasPorEstadoId(estadoId);

                if (model != null)
                {
                    foreach (var item in model)
                    {
                        var datos = new ConvocatoriaListDTO();
                        datos.Estado = item.Estado;
                        datos.FechaFin = item.FechaFin.ToString("dd/MM/yyyy");
                        datos.FechaInicio = item.FechaInicio.ToString("dd/MM/yyyy");
                        datos.Id = item.Id;
                        datos.Titulo = item.Titulo;
                        datos.RelacionadoA = item.NombreActor;
                        datos.Tipo = item.TipoActor;

                        listEntidad.Add(datos);
                    }

                }


                return listEntidad;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ConvocatoriaListDTO> ConsultarConvocatoriaHome(int estadoId)
        {
            try
            {
                var model = new List<ConvocatoriaResultadoDTO>();
                var listEntidad = new List<ConvocatoriaListDTO>();
                model = ConvocatoriaServicio.ConsultarConvocatoriasPorEstadoId(estadoId);

                if (model != null)
                {
                    foreach (var item in model)
                    {
                        var datos = new ConvocatoriaListDTO();
                        datos.Estado = item.Estado;
                        datos.FechaFin = item.FechaFin.ToString("dd/MM/yyyy");
                        datos.FechaInicio = item.FechaInicio.ToString("dd/MM/yyyy");
                        datos.Id = item.Id;
                        if (item.Titulo.Length > 60)
                            datos.Titulo = item.Titulo.Substring(0, 60) + "...";
                        else
                            datos.Titulo = item.Titulo;
                        if (item.NombreActor.Length > 60)
                            datos.RelacionadoA = item.NombreActor.Substring(0, 60) + "...";
                        else
                            datos.RelacionadoA = item.NombreActor;
                        datos.Tipo = item.TipoActor;
                        if (item.Descripcion.Length > 150)
                            datos.Descripcion = item.Descripcion.Substring(0, 150) + "...";
                        else
                            datos.Descripcion = item.Descripcion;
                        if (item.DocumentoId != null)
                            datos.DocumentoId = (int)item.DocumentoId;
                        else
                            datos.DocumentoId = 0;

                        listEntidad.Add(datos);
                    }

                }


                return listEntidad;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public static List<ConvocatoriaListDTO> ConsultarConvocatoriaPorUsuarioId(int UsuarioId)
        {
            try
            {
                var model = new List<ConvocatoriaResultadoDTO>();
                var listEntidad = new List<ConvocatoriaListDTO>();
                model = ConvocatoriaServicio.ConsultarConvocatoriasPorUsuarioId(UsuarioId);

                if (model != null)
                {
                    foreach (var item in model)
                    {
                        var datos = new ConvocatoriaListDTO();
                        datos.Estado = item.Estado;
                        datos.FechaFin = item.FechaFin.ToString("dd/MM/yyyy");
                        datos.FechaInicio = item.FechaInicio.ToString("dd/MM/yyyy");
                        datos.Id = item.Id;
                        datos.Titulo = item.Titulo;
                        datos.RelacionadoA = item.NombreActor;
                        datos.Tipo = item.TipoActor;

                        listEntidad.Add(datos);
                    }

                }


                return listEntidad;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static ConvocatoriaNuevoDTO ConsultarConvocatoriaPorId(int Id)
        {
            try
            {
                var datos = new ConvocatoriaNuevoDTO();
                var model = ConvocatoriaServicio.ConsultarConvocatoriaPorId(Id);

                if (model != null)
                {
                    if (model.AgenteId != null)
                        datos.ActorId = (int)model.AgenteId;
                    else if (model.EntidadId != null)
                        datos.ActorId = (int)model.EntidadId;
                    else if (model.AgrupacionId != null)
                        datos.ActorId = (int)model.AgrupacionId;
                    else if (model.EscuelaId != null)
                        datos.ActorId = (int)model.EscuelaId;

                    datos.Descripcion = model.Descripcion;
                    datos.Estado = ConvocatoriaServicio.ObtenerNombreEstado(model.EstadoId);
                    datos.EstadoId = model.EstadoId;
                    datos.FechaFin = model.FechaFin;
                    datos.FechaInicio = model.FechaInicio;
                    datos.Id = model.Id;
                    datos.RelacionadoA = model.NombreActor;
                    datos.TipoActorId = model.TipoActorId;
                    datos.Titulo = model.Titulo;
                    datos.UsuarioId = model.UsuarioId;
                    if (model.DocumentoId == null)
                        datos.DocumentoId = 0;
                    else
                        datos.DocumentoId = (int)model.DocumentoId;
                }


                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string ObtenerNombreParamentro(int Id)
        {
            string Nombre;
            try
            {
                Nombre = ConvocatoriaServicio.ObtenerNombreEstado(Id);

                return Nombre;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string ObtenerIdConvocatoriaDotacion()
        {
            string Nombre;
            try
            {
                Nombre = ConvocatoriaServicio.ObtenerIdConvocatoriaDotacion();

                return Nombre;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<EstandarDTO> ConsultarDirigidoA(int Id)
        {
            List<EstandarDTO> lisParametro = new List<EstandarDTO>();
            try
            {
                List<Parametro> Parametrodatos = ConvocatoriaServicio.ConsultarDirigidoA(Id);

                foreach (var item in Parametrodatos)
                {
                    EstandarDTO objParametro = new EstandarDTO();
                    objParametro.Id = item.Id.ToString();
                    objParametro.Nombre = item.Nombre;
                    lisParametro.Add(objParametro);
                }

                lisParametro = lisParametro.OrderBy(d => d.Nombre).ToList();

                return lisParametro;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<EstandarDTO> ConsultarEntidadesHabilitadasDotacion(bool EsAdmin, int UsuarioId)
        {
            List<EstandarDTO> lisParametro = new List<EstandarDTO>();
            List<Parametro> Parametrodatos;
            try
            {
                if (EsAdmin)
                    Parametrodatos = ConvocatoriaServicio.ConsultarEntidadesHabilitadasDotacion();
                else
                    Parametrodatos = ConvocatoriaServicio.ConsultarEntidadesHabilitadasDotacionPorUsuarioId(UsuarioId);

                foreach (var item in Parametrodatos)
                {
                    EstandarDTO objParametro = new EstandarDTO();
                    objParametro.Id = item.Id.ToString();
                    objParametro.Nombre = item.Nombre;
                    lisParametro.Add(objParametro);
                }

                lisParametro = lisParametro.OrderBy(d => d.Nombre).ToList();

                return lisParametro;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<EstandarDTO> ConsultarEntidadesRegistradas(int ConvocatoriaId, bool EsAdmin, int usuarioId)
        {
            List<EstandarDTO> lisParametro = new List<EstandarDTO>();
            List<Parametro> Parametrodatos;

            try
            {
                if (EsAdmin)
                    Parametrodatos = ConvocatoriaServicio.ConsultarEntidadesRegistradas(ConvocatoriaId);
                else
                    Parametrodatos = ConvocatoriaServicio.ConsultarEntidadesRegistradasPorUsuario(ConvocatoriaId, usuarioId);

                foreach (var item in Parametrodatos)
                {
                    EstandarDTO objParametro = new EstandarDTO();
                    objParametro.Id = item.Id.ToString();
                    objParametro.Nombre = item.Nombre;
                    lisParametro.Add(objParametro);
                }

                lisParametro = lisParametro.OrderBy(d => d.Nombre).ToList();

                return lisParametro;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void ActualizarConvocatoria(ConvocatoriaNuevoDTO datos, string[] dirigidoA)
        {
            try
            {
                if (datos != null)
                {
                    ConvocatoriaServicio.Actualizar(datos.Id,
                                                     datos.Titulo,
                                                     datos.Descripcion,
                                                     datos.FechaInicio,
                                                     datos.FechaFin,
                                                     datos.EstadoId,
                                                     datos.TipoActorId,
                                                     datos.ActorId,
                                                     dirigidoA);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int CrearConvocatoria(ConvocatoriaNuevoDTO datos, string[] dirigidoA)
        {
            var entidad = new ART_MUSICA_CONVOCATORIAS();
            int ConvocatoriaId = 0;
            string NombreActor = "";
            try
            {
                if (datos != null)
                {
                    if (datos.TipoActorId == 6)
                    {
                        NombreActor = ConvocatoriaServicio.ObtenerNombreAgente(datos.ActorId);
                        entidad = new ART_MUSICA_CONVOCATORIAS
                                  {
                                      Descripcion = datos.Descripcion,
                                      EstadoId = 1,
                                      FechaInicio = datos.FechaInicio,
                                      FechaFin = datos.FechaFin,
                                      FechaRegistro = DateTime.Now,
                                      Titulo = datos.Titulo,
                                      UsuarioId = datos.UsuarioId,
                                      TipoActorId = Convert.ToInt32(datos.TipoActorId),
                                      NombreActor = NombreActor,
                                      AgenteId = Convert.ToInt32(datos.ActorId)
                                  };
                    }
                    else if (datos.TipoActorId == 7)
                    {
                        NombreActor = ConvocatoriaServicio.ObtenerNombreEntidad(datos.ActorId);
                        entidad = new ART_MUSICA_CONVOCATORIAS
                                  {
                                      Descripcion = datos.Descripcion,
                                      EstadoId = 1,
                                      FechaInicio = datos.FechaInicio,
                                      FechaFin = datos.FechaFin,
                                      FechaRegistro = DateTime.Now,
                                      Titulo = datos.Titulo,
                                      UsuarioId = datos.UsuarioId,
                                      TipoActorId = Convert.ToInt32(datos.TipoActorId),
                                      NombreActor = NombreActor,
                                      EntidadId = Convert.ToInt32(datos.ActorId)
                                  };
                    }
                    else if (datos.TipoActorId == 8)
                    {
                        NombreActor = ConvocatoriaServicio.ObtenerNombreAgrupacion(datos.ActorId);
                        entidad = new ART_MUSICA_CONVOCATORIAS
                        {
                            Descripcion = datos.Descripcion,
                            EstadoId = 1,
                            FechaInicio = datos.FechaInicio,
                            FechaFin = datos.FechaFin,
                            FechaRegistro = DateTime.Now,
                            Titulo = datos.Titulo,
                            UsuarioId = datos.UsuarioId,
                            TipoActorId = Convert.ToInt32(datos.TipoActorId),
                            NombreActor = NombreActor,
                            AgrupacionId = Convert.ToInt32(datos.ActorId)
                        };
                    }
                    else if (datos.TipoActorId == 9)
                    {
                        NombreActor = ConvocatoriaServicio.ObtenerNombreEscuela(datos.ActorId);
                        entidad = new ART_MUSICA_CONVOCATORIAS
                        {
                            Descripcion = datos.Descripcion,
                            EstadoId = 1,
                            FechaInicio = datos.FechaInicio,
                            FechaFin = datos.FechaFin,
                            FechaRegistro = DateTime.Now,
                            Titulo = datos.Titulo,
                            UsuarioId = datos.UsuarioId,
                            TipoActorId = Convert.ToInt32(datos.TipoActorId),
                            NombreActor = NombreActor,
                            EscuelaId = Convert.ToInt32(datos.ActorId)
                        };
                    }

                    ConvocatoriaId = ConvocatoriaServicio.AgregarConvocatoria(entidad, dirigidoA);
                }
                return ConvocatoriaId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    
        public static void ActualizarDocumento(int ConvocatoriaId, int DocumentoId)
        {
            try
            {
                ConvocatoriaServicio.ActualizarDocumento(ConvocatoriaId, DocumentoId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string ObtenerNombreEntidad(int EntidadId)
        {
            string Nombre = "";
            try
            {
                Nombre = ConvocatoriaServicio.ObtenerNombreEntidad(EntidadId);
                return Nombre;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string ObtenerNombreEscuela(int EscuelaId)
        {
            string Nombre = "";
            try
            {
                Nombre = ConvocatoriaServicio.ObtenerNombreEscuela(EscuelaId);
                return Nombre;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string ObtenerMunicipioPorEntidad(int EntidadId)
        {
            string Nombre = "";
            try
            {
                Nombre = ConvocatoriaServicio.ObtenerMunicipioPorEntidad(EntidadId);
                return Nombre;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static EstandarDTO ObtenerEscuelaPorEntidadId(int EntidadId)
        {
            var parametro = new Parametro();
            var resultado = new EstandarDTO();
            try
            {
                parametro = ConvocatoriaServicio.ObtenerEscuelaPorEntidadId(EntidadId);
                if (parametro != null)
                {
                    resultado.Id = parametro.Id.ToString();
                    resultado.Nombre = parametro.Nombre;
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
