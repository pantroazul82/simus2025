using SM.Datos.Basicas;
using SM.Datos.Servicios;
using SM.LibreriaComun.DTO.Servicios;
using SM.SIPA;
using System;
using System.Collections.Generic;
using System.Linq;
using SM.LibreriaComun.DTO;
using SM.Datos.DTO.Servicios;
using SM.Datos.DTO.Geo;
using SM.LibreriaComun.DTO.GEO;
namespace SM.Aplicacion.Servicios
{
    public class UtilidadNeg
    {
        #region actualizacion
        public static int CrearUtilidad(UtilidadDTO datos, string NombreUsuario, string strIP)
        {
            var entidad = new ART_MUSICA_MODULO_SERVICIOS();
            int UtilidadId = 0;
            string NombreActor = "";
            try
            {


                if (datos.codDepto.Length == 2)
                    datos.Departamento = ServicioBasicas.obtenerNombreDepartamento(datos.codDepto);
                else
                    datos.codDepto = "";


                if (datos.codMunicipio.Length == 5)
                {
                    datos.Municipio = ServicioBasicas.obtenerNombreMunicipio(datos.codMunicipio);
                    datos.OtraCiudad = "";
                }
                else
                    datos.codMunicipio = "";

                if (datos != null)
                {
                    ///Realacionado con un agente
                    if (datos.TipoActorId == 6)
                    {
                        NombreActor = ConvocatoriaServicio.ObtenerNombreAgente(datos.ActorId);
                        entidad = new ART_MUSICA_MODULO_SERVICIOS
                        {
                            Descripcion = datos.Descripcion,
                            EstadoId = 1,
                            FechaInicio = datos.FechaInicio,
                            FechaFin = datos.FechaFin,
                            FechaCreacion = DateTime.Now,
                            Titulo = datos.Titulo,
                            UsuarioCreadorId = datos.UsuarioId,
                            TipoActorId = Convert.ToInt32(datos.TipoActorId),
                            TipoActor = "Agentes",
                            NombreActor = NombreActor,
                            AgenteId = Convert.ToInt32(datos.ActorId),
                            TipoServicioId = datos.TipoUtilidadId,
                            TipoEventoId = datos.TipoEventoId,
                            CodDepto = datos.codDepto,
                            CodMunicipio = datos.codMunicipio,
                            Departamento = datos.Departamento,
                            Municipio = datos.Municipio,
                            Direccion = datos.Direccion,
                            CodPais = datos.CodPais,
                            OtraCiudad = datos.OtraCiudad,
                            Telefono = datos.Telefono,
                            Imagen = datos.imagen,
                            Email = datos.CorreoElectronico,
                            Contacto = "",
                            EsActivo = datos.EsActivo
                        };
                    }
                    else if (datos.TipoActorId == 7)
                    {
                        NombreActor = ConvocatoriaServicio.ObtenerNombreEntidad(datos.ActorId);
                        entidad = new ART_MUSICA_MODULO_SERVICIOS
                        {
                            Descripcion = datos.Descripcion,
                            EstadoId = 1,
                            FechaInicio = datos.FechaInicio,
                            FechaFin = datos.FechaFin,
                            FechaCreacion = DateTime.Now,
                            Titulo = datos.Titulo,
                            UsuarioCreadorId = datos.UsuarioId,
                            TipoActorId = Convert.ToInt32(datos.TipoActorId),
                            NombreActor = NombreActor,
                            TipoActor = "Entidad",
                            EntidadId = Convert.ToInt32(datos.ActorId),
                            TipoServicioId = datos.TipoUtilidadId,
                            TipoEventoId = datos.TipoEventoId,
                            CodDepto = datos.codDepto,
                            CodMunicipio = datos.codMunicipio,
                            Departamento = datos.Departamento,
                            Municipio = datos.Municipio,
                            Direccion = datos.Direccion,
                            CodPais = datos.CodPais,
                            Imagen = datos.imagen,
                            OtraCiudad = datos.OtraCiudad,
                            Telefono = datos.Telefono,
                            Email = datos.CorreoElectronico,
                            Contacto = "",
                            EsActivo = datos.EsActivo
                        };
                    }
                    else if (datos.TipoActorId == 8)
                    {
                        NombreActor = ConvocatoriaServicio.ObtenerNombreAgrupacion(datos.ActorId);
                        entidad = new ART_MUSICA_MODULO_SERVICIOS
                        {
                            Descripcion = datos.Descripcion,
                            EstadoId = 1,
                            FechaInicio = datos.FechaInicio,
                            FechaFin = datos.FechaFin,
                            FechaCreacion = DateTime.Now,
                            Titulo = datos.Titulo,
                            UsuarioCreadorId = datos.UsuarioId,
                            TipoActorId = Convert.ToInt32(datos.TipoActorId),
                            TipoActor = "Agrupación",
                            NombreActor = NombreActor,
                            AgrupacionId = Convert.ToInt32(datos.ActorId),
                            TipoServicioId = datos.TipoUtilidadId,
                            TipoEventoId = datos.TipoEventoId,
                            CodDepto = datos.codDepto,
                            CodMunicipio = datos.codMunicipio,
                            Departamento = datos.Departamento,
                            Municipio = datos.Municipio,
                            Direccion = datos.Direccion,
                            CodPais = datos.CodPais,
                            OtraCiudad = datos.OtraCiudad,
                            Telefono = datos.Telefono,
                            Imagen = datos.imagen,
                            Email = datos.CorreoElectronico,
                            Contacto = "",
                            EsActivo = datos.EsActivo
                        };
                    }
                    else if (datos.TipoActorId == 9)
                    {
                        NombreActor = ConvocatoriaServicio.ObtenerNombreEscuela(datos.ActorId);
                        entidad = new ART_MUSICA_MODULO_SERVICIOS
                        {
                            Descripcion = datos.Descripcion,
                            EstadoId = 1,
                            FechaInicio = datos.FechaInicio,
                            FechaFin = datos.FechaFin,
                            FechaCreacion = DateTime.Now,
                            Titulo = datos.Titulo,
                            UsuarioCreadorId = datos.UsuarioId,
                            TipoActorId = Convert.ToInt32(datos.TipoActorId),
                            TipoActor = "Escuelas",
                            NombreActor = NombreActor,
                            EscuelaId = Convert.ToInt32(datos.ActorId),
                            TipoServicioId = datos.TipoUtilidadId,
                            TipoEventoId = datos.TipoEventoId,
                            CodDepto = datos.codDepto,
                            CodMunicipio = datos.codMunicipio,
                            Departamento = datos.Departamento,
                            Municipio = datos.Municipio,
                            Direccion = datos.Direccion,
                            CodPais = datos.CodPais,
                            OtraCiudad = datos.OtraCiudad,
                            Telefono = datos.Telefono,
                            Imagen = datos.imagen,
                            Email = datos.CorreoElectronico,
                            Contacto = "",
                            EsActivo = datos.EsActivo
                        };
                    }

                    UtilidadId = UtilidadServicio.Agregar(entidad, NombreUsuario, datos.UsuarioId, strIP);
                    //if ((!String.IsNullOrEmpty(datos.Latitud)) && (!String.IsNullOrEmpty(datos.Longitud)))
                    //{
                    //    UtilidadServicio.ActualizarCoordenadas(UtilidadId, datos.Latitud, datos.Longitud);
                    //}
                }
                return UtilidadId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void EliminarGenero(int UtilidadGeneroId)
        {
            try
            { UtilidadServicio.EliminarGenero(UtilidadGeneroId); }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void EliminarServicio(int UtilidadServicioId)
        {
            try
            { UtilidadServicio.EliminarServicio(UtilidadServicioId); }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void AgregarGenero(int UtilidadId,
                                  string strAtributo)
        {
            int GeneroId = 0;
            try
            {
                GeneroId = SM.Datos.Basicas.CaracterizacionMusicalServicio.ObtenerGeneroId(strAtributo);

                var registro = new ART_MUSICA_UTILIDAD_GENEROS();
                registro.UtilidadId = UtilidadId;
                registro.GeneroId = GeneroId;
                registro.Atributo = strAtributo;
                UtilidadServicio.AgregarGeneros(registro);


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void AgregarServicio(int UtilidadId,
                                      string strAtributo)
        {
            int ServicioId = 0;
            try
            {
                ServicioId = SM.Datos.Basicas.CaracterizacionMusicalServicio.ObtenerServicioId(strAtributo);
                var registro = new ART_MUSICA_UTILIDAD_SERVICIO();
                registro.UtilidadId = UtilidadId;
                registro.Atributo = strAtributo;
                registro.ServicioId = ServicioId;
                UtilidadServicio.AgregarServicio(registro);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void ActualizarDOcumento(int utilidadId, int DocumentoId)
        {
            try
            {
                UtilidadServicio.ActualizarDocumentoutilidad(utilidadId, DocumentoId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static void Actualizarutilidad(UtilidadDTO datos, string NombreUsuario, string strIP)
        {
            try
            {
                if (datos != null)
                {
                    UtilidadServicio.Actualizar(datos.UtilidadId,
                                                datos.Titulo,
                                                datos.Descripcion,
                                                datos.FechaInicio,
                                                datos.FechaFin,
                                                datos.EstadoId,
                                                datos.TipoActorId,
                                                datos.ActorId,
                                                datos.TipoUtilidadId,
                                                datos.TipoEventoId,
                                                datos.CodPais,
                                                datos.codDepto,
                                                datos.codMunicipio,
                                                datos.OtraCiudad,
                                                datos.Direccion,
                                                datos.Telefono,
                                                datos.CorreoElectronico,
                                                datos.EsActivo,
                                                datos.imagen,
                                                datos.UsuarioAprobadorId,
                                                NombreUsuario,
                                                strIP);

                    if ((!String.IsNullOrEmpty(datos.Latitud)) && (!String.IsNullOrEmpty(datos.Longitud)))
                    {
                        UtilidadServicio.ActualizarCoordenadas(datos.UtilidadId, datos.Latitud, datos.Longitud);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion


        #region Consultas
        public static List<EstandarDTO> ConsultarGenerosPorUtilidadId(int UtilidadId)
        {
            var lisParametro = new List<EstandarDTO>();
            try
            {
                List<SM.Datos.DTO.Parametro> Parametrodatos = UtilidadServicio.ConsultarGenerosPorUtilidadId(UtilidadId);

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

        public static List<EstandarDTO> ConsultarServicioPorUtilidadId(int UtilidadId)
        {
            var lisParametro = new List<EstandarDTO>();
            try
            {
                List<SM.Datos.DTO.Parametro> Parametrodatos = UtilidadServicio.ConsultarServicioPorUtilidadId(UtilidadId);

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
        public static UtilidadDTO ConsultarUtilidadporId(int Id)
        {
            try
            {
                var datos = new UtilidadDTO();
                var model = UtilidadServicio.ConsultarPorId(Id);
                int EstadoId = 0;
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

                    EstadoId = model.EstadoId;

                    datos.Descripcion = model.Descripcion;
                    datos.Estado = ConvocatoriaServicio.ObtenerNombreEstado(EstadoId);
                    datos.EstadoId = EstadoId;
                    datos.FechaFin = model.FechaFin ?? DateTime.Today;
                    datos.FechaInicio = model.FechaInicio ?? DateTime.Today;
                    datos.UtilidadId = model.Id;
                    datos.RelacionadoA = model.NombreActor;
                    datos.TipoActorId = model.TipoActorId;
                    datos.Titulo = model.Titulo;
                    datos.UsuarioId = model.UsuarioCreadorId;
                    datos.TipoUtilidadId = model.TipoServicioId ?? 0;
                    datos.TipoEventoId = model.TipoEventoId ?? 0;
                    datos.imagen = model.Imagen;
                    datos.CodPais = model.CodPais ?? 0;
                    datos.OtraCiudad = model.OtraCiudad;
                    datos.Departamento = model.Departamento;
                    datos.Municipio = model.Municipio;
                    datos.codDepto = model.CodDepto;
                    datos.codMunicipio = model.CodMunicipio;
                    datos.Direccion = model.Direccion;
                    datos.Telefono = model.Telefono;
                    datos.CorreoElectronico = model.Email;
                    datos.EsActivo = model.EsActivo ?? false;
                    if (model.DocumentoId == null)
                        datos.DocumentoId = 0;
                    else
                        datos.DocumentoId = (int)model.DocumentoId;

                    if (model.Coordenadas != null)
                    {

                        datos.Latitud = model.Coordenadas.Latitude.Value.ToString();
                        datos.Longitud = model.Coordenadas.Longitude.Value.ToString();
                    }
                }


                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region ProcedimientosAlmacenados
        public static List<UtilidadListadoDTO> ConsultarTodos()
        {
            try
            {
                var model = new List<UtilidadResultadoDTO>();
                var listResultado = new List<UtilidadListadoDTO>();
                model = UtilidadServicio.ConsultarTodos();

                if (model != null)
                {
                    foreach (var item in model)
                    {
                        var datos = new UtilidadListadoDTO();
                        datos.Clasificacion = item.Clasificacion;
                        datos.Estado = item.Estado;
                        datos.FechaFin = item.FechaFin ?? DateTime.Today;
                        datos.FechaInicio = item.FechaInicio ?? DateTime.Today;
                        if (item.FechaActualizacion != null)
                        {
                            DateTime datfecha =  Convert.ToDateTime(item.FechaActualizacion);
                            datos.FechaActualizacion = datfecha.ToString("dd/MM/yyy");
                        }
                      
                        datos.FechaCreacion = item.FechaCreacion.ToString("dd/MM/yyy");
                        datos.NombreActor = item.NombreActor;
                        datos.TipoActor = item.TipoActor;
                        datos.TipoUtilidad = item.TipoUtilidad;
                        datos.Titulo = item.Titulo;
                        datos.UtilidadId = item.UtilidadId;
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
        public static List<UtilidadListadoDTO> ConsultarPorMunicipio(int UsuarioID)
        {
            try
            {
                var model = new List<UtilidadResultadoDTO>();
                var listResultado = new List<UtilidadListadoDTO>();
                model = UtilidadServicio.ConsultarPorMunicipio(UsuarioID);

                if (model != null)
                {
                    foreach (var item in model)
                    {
                        var datos = new UtilidadListadoDTO();
                        datos.Clasificacion = item.Clasificacion;
                        datos.Estado = item.Estado;
                        datos.FechaFin = item.FechaFin ?? DateTime.Today;
                        datos.FechaInicio = item.FechaInicio ?? DateTime.Today;
                        datos.NombreActor = item.NombreActor;
                        datos.TipoActor = item.TipoActor;
                        datos.TipoUtilidad = item.TipoUtilidad;
                        datos.Titulo = item.Titulo;
                        datos.UtilidadId = item.UtilidadId;
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
        public static List<UtilidadListadoDTO> ConsultarPorEstadoId(int EstadoId)
        {
            try
            {
                var model = new List<UtilidadResultadoDTO>();
                var listResultado = new List<UtilidadListadoDTO>();
                model = UtilidadServicio.ConsultarPorEstadoId(EstadoId);

                if (model != null)
                {
                    foreach (var item in model)
                    {
                        var datos = new UtilidadListadoDTO();
                        datos.Clasificacion = item.Clasificacion;
                        datos.Estado = item.Estado;
                        datos.FechaFin = item.FechaFin ?? DateTime.Today;
                        datos.FechaInicio = item.FechaInicio ?? DateTime.Today;
                        datos.NombreActor = item.NombreActor;
                        datos.TipoActor = item.TipoActor;
                        datos.TipoUtilidad = item.TipoUtilidad;
                        datos.Titulo = item.Titulo;
                        datos.UtilidadId = item.UtilidadId;
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
        public static List<UtilidadListadoDTO> ConsultarPorUsuarioId(int UsuarioID)
        {
            try
            {
                var model = new List<UtilidadResultadoDTO>();
                var listResultado = new List<UtilidadListadoDTO>();
                model = UtilidadServicio.ConsultarPorUsuarioId(UsuarioID);

                if (model != null)
                {
                    foreach (var item in model)
                    {
                        var datos = new UtilidadListadoDTO();
                        datos.Clasificacion = item.Clasificacion;
                        datos.Estado = item.Estado;
                        datos.FechaFin = item.FechaFin ?? DateTime.Today;
                        datos.FechaInicio = item.FechaInicio ?? DateTime.Today;
                        datos.NombreActor = item.NombreActor;
                        datos.TipoActor = item.TipoActor;
                        datos.TipoUtilidad = item.TipoUtilidad;
                        datos.Titulo = item.Titulo;
                        datos.UtilidadId = item.UtilidadId;
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

        public static List<UtilidadHomeDataDTO> ConsultarDatosPorTipoUtilidad(int utilidadId)
        {
            try
            {
                var model = new List<UtilidadHomeDTO>();
                var listResultado = new List<UtilidadHomeDataDTO>();
                model = UtilidadServicio.ConsultarDatosPorTipoUtilidad(utilidadId);
                DateTime inicio;
                DateTime final;

                if (model != null)
                {
                    foreach (var item in model)
                    {
                        var datos = new UtilidadHomeDataDTO();
                        datos.Clasificacion = item.Clasificacion;
                        datos.Estado = item.Estado;
                        inicio = item.FechaInicio ?? DateTime.Today;
                        final = item.FechaFin ?? DateTime.Today;
                        datos.FechaFin = final.ToString("dd/MM/yyyy");
                        datos.FechaInicio = inicio.ToString("dd/MM/yyyy");
                        datos.NombreActor = item.NombreActor;
                        datos.TipoActor = item.TipoActor;
                        datos.TipoUtilidad = item.TipoUtilidad;
                        datos.Titulo = item.Titulo;
                        datos.UtilidadId = item.UtilidadId;
                        datos.TipoActorId = item.TipoActorId;
                        datos.TipoEventoId = item.TipoEventoId;
                        datos.TipoServicioId = item.TipoServicioId;
                        datos.Email = item.Email;
                        datos.Telefono = item.Telefono;
                        if (item.Descripcion.Length > 189)
                            datos.Descripcion = item.Descripcion.Substring(0, 189) + "...";
                        else
                            datos.Descripcion = item.Descripcion;
                        datos.Direccion = item.Direccion;
                        if (item.CodPais == 52)
                            datos.Ubicacion = item.Pais + " " + item.Departamento + " " + item.Municipio;
                        else
                            datos.Ubicacion = item.Pais + " " + item.OtraCiudad;
                        datos.verMas = "/Home/DetalleAgrupacion/" + item.UtilidadId.ToString();
                        datos.rutaFoto = "";
                        if (item.Imagen != null)
                            datos.Imagen = item.Imagen;
                        else
                            datos.rutaFoto = "../img/agrupa_generica.jpg";
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

        public static List<UtilidadHomeDataDTO> ConsultarDatosDocumentos(int utilidadId)
        {
            try
            {
                var model = new List<UtilidadHomeDTO>();
                var listResultado = new List<UtilidadHomeDataDTO>();
                model = UtilidadServicio.ConsultarDatosDocumentos(utilidadId);

                DateTime inicio;
                DateTime final;

                if (model != null)
                {
                    foreach (var item in model)
                    {
                        var datos = new UtilidadHomeDataDTO();
                        datos.Clasificacion = item.Clasificacion;
                        datos.Estado = item.Estado;
                        inicio = item.FechaInicio ?? DateTime.Today;
                        final = item.FechaFin ?? DateTime.Today;
                        datos.FechaFin = final.ToString("dd/MM/yyyy");
                        datos.FechaInicio = inicio.ToString("dd/MM/yyyy");
                        datos.NombreActor = item.NombreActor;
                        datos.TipoActor = item.TipoActor;
                        datos.TipoUtilidad = item.TipoUtilidad;
                        datos.Titulo = item.Titulo;
                        datos.UtilidadId = item.UtilidadId;
                        datos.TipoActorId = item.TipoActorId;
                        datos.TipoEventoId = item.TipoEventoId;
                        datos.TipoServicioId = item.TipoServicioId;
                        datos.Email = item.Email;
                        datos.Telefono = item.Telefono;
                        datos.DocumentoId = item.DocumentoId;
                        if (item.Descripcion.Length > 189)
                            datos.Descripcion = item.Descripcion.Substring(0, 189) + "...";
                        else
                            datos.Descripcion = item.Descripcion;
                        datos.Direccion = item.Direccion;
                        if (item.CodPais == 52)
                            datos.Ubicacion = item.Pais + " " + item.Departamento + " " + item.Municipio;
                        else
                            datos.Ubicacion = item.Pais + " " + item.OtraCiudad;
                        datos.verMas = "/Home/DetalleAgrupacion/" + item.UtilidadId.ToString();
                        datos.rutaFoto = "";
                        if (item.Imagen != null)
                            datos.Imagen = item.Imagen;
                        else
                            datos.rutaFoto = "../img/agrupa_generica.jpg";
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

        public static UtilidadDataDetalleDTO ConsultarDetallePorId(int Id)
        {
            try
            {
                var model = new UtilidadDetalleDTO();
                var datos = new UtilidadDataDetalleDTO();
                model = UtilidadServicio.ConsultarDetallePorId(Id);

                if (model != null)
                {

                    datos.Clasificacion = model.Clasificacion;
                    datos.Estado = model.Estado;
                    datos.FechaFin = model.FechaFin ?? DateTime.Today;
                    datos.FechaInicio = model.FechaInicio ?? DateTime.Today;
                    datos.NombreActor = model.NombreActor;
                    datos.TipoActor = model.TipoActor;
                    datos.TipoUtilidad = model.TipoUtilidad;
                    datos.Titulo = model.Titulo;
                    datos.UtilidadId = model.UtilidadId;
                    datos.DocumentoId = model.DocumentoId ?? 0;
                    datos.Departamento = model.Departamento;
                    datos.Descripcion = model.Descripcion;
                    datos.Direccion = model.Direccion;
                    datos.Email = model.Email;
                    datos.Imagen = model.Imagen;
                    datos.Municipio = model.Municipio;
                    datos.OtraCiudad = model.OtraCiudad;
                    datos.Pais = model.Pais;
                    datos.Telefono = model.Telefono;

                }

                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<NoticiasDataDTO> ConsultarNoticiasRecientes(int TipoUtilidadId)
        {
            try
            {
                var model = new List<NoticiasDTO>();
                var listResultado = new List<NoticiasDataDTO>();
                model = UtilidadServicio.ConsultarNoticiasRecientes(TipoUtilidadId);


                if (model != null)
                {
                    foreach (var item in model)
                    {
                        var datos = new NoticiasDataDTO();
                        datos.FechaInicio = item.FechaInicio.ToString("dd/MM/yyyy");
                        datos.FechaFinal = item.FechaFinal.ToString("dd/MM/yyyy");
                        datos.Titulo = item.Titulo;
                        datos.UtilidadId = item.UtilidadId;
                        if (item.Descripcion.Length > 189)
                            datos.Descripcion = item.Descripcion.Substring(0, 189) + "...";
                        else
                            datos.Descripcion = item.Descripcion;

                        datos.rutaFoto = "";
                        if (item.Imagen != null)
                            datos.Imagen = item.Imagen;
                        else
                            datos.rutaFoto = "../img/agrupa_generica.jpg";
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

      
        public static DateTime UltimoDIaMes(DateTime date)
        {
            return date.AddMonths(1).AddSeconds(-1);
        }
        public static List<NoticiasDataDTO> ConsultarEventosdelMes(int TipoUtilidadId)
        {
            try
            {
                DateTime datFechaInicio = DateTime.Today;
                DateTime datFechaFinal = DateTime.Today;
                var model = new List<NoticiasDTO>();
                var listResultado = new List<NoticiasDataDTO>();
                int diaInicio = datFechaInicio.Day;

                if (diaInicio >= 1 && diaInicio <= 8)
                {
                    datFechaInicio = DateTime.Today;
                    datFechaFinal = datFechaInicio.AddDays(15);
                }
                else if (diaInicio >= 9 && diaInicio <= 15)
                {
                    datFechaInicio = DateTime.Today.AddDays(-5);
                    datFechaFinal = datFechaInicio.AddDays(10);
                }
                else if (diaInicio >= 16 && diaInicio <= 20)
                {
                    datFechaInicio = DateTime.Today.AddDays(-10);
                   
                    datFechaFinal = datFechaInicio.AddDays(8);
                }
                else if (diaInicio >= 21 && diaInicio <= 31)
                {
                    datFechaInicio = DateTime.Today.AddDays(-10);
                     DateTime FechaPrimerDia = new DateTime(datFechaInicio.Year, datFechaInicio.Month, 1);
                     datFechaFinal = UltimoDIaMes(FechaPrimerDia);
                }
                model = UtilidadServicio.ConsultarEventosdelMes(TipoUtilidadId, datFechaInicio, datFechaFinal);

                if (model.Count <= 3)
                {
                    DateTime FechaPrimerDia = new DateTime(datFechaInicio.Year, datFechaInicio.Month, 1);
                    datFechaFinal = UltimoDIaMes(FechaPrimerDia);
                    model = UtilidadServicio.ConsultarEventosdelMes(TipoUtilidadId, FechaPrimerDia, datFechaFinal);
                      if (model.Count <= 3)
                      {
                          datFechaFinal = datFechaFinal.AddMonths(1);
                          model = UtilidadServicio.ConsultarEventosdelMes(TipoUtilidadId, FechaPrimerDia, datFechaFinal);
                      }
                }

                if (model != null)
                {
                    foreach (var item in model)
                    {
                        var datos = new NoticiasDataDTO();
                        datos.FechaInicio = item.FechaInicio.ToLongDateString();
                        datos.FechaFinal = item.FechaFinal.ToString("dd/MM/yyyy");
                        datos.Titulo = item.Titulo;
                        datos.UtilidadId = item.UtilidadId;
                        if (item.Descripcion.Length > 189)
                            datos.Descripcion = item.Descripcion.Substring(0, 189) + "...";
                        else
                            datos.Descripcion = item.Descripcion;

                        datos.rutaFoto = "";
                        if (item.Imagen != null)
                            datos.Imagen = item.Imagen;
                        else
                            datos.rutaFoto = "../img/agrupa_generica.jpg";
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
        public static List<HerramientaDTO> ConsultarHerramienta()
        {
            try
            {
                var model = new List<HerramientaResultadoDTO>();
                var listResultado = new List<HerramientaDTO>();
                model = UtilidadServicio.ConsultarHerramienta();


                if (model != null)
                {
                    foreach (var item in model)
                    {
                        var datos = new HerramientaDTO();
                        datos.Id = item.Id;
                        datos.Nombre = item.Nombre;
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

        public static List<HerramientaDTO> ConsultarHerramientaPorTipoID(int tipoId)
        {
            try
            {
                var model = new List<HerramientaResultadoDTO>();
                var listResultado = new List<HerramientaDTO>();
                model = UtilidadServicio.ConsultarHerramientaPorTipoID(tipoId);


                if (model != null)
                {
                    foreach (var item in model)
                    {
                        var datos = new HerramientaDTO();
                        datos.Id = item.Id;
                        datos.Nombre = item.Nombre;
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

        public static HerramientaDetalleDTO ConsultarHerramientaDetalleID(int Id)
        {
            try
            {
                var model = new HerramientaResultadoDetalleDTO();
                var datos = new HerramientaDetalleDTO();
                model = UtilidadServicio.ConsultarHerramientaDetalle(Id);


                if (model != null)
                {
                    datos.Id = model.Id;
                    datos.Nombre = model.Nombre;
                    datos.Tipo = model.Tipo;
                    datos.TipoId = model.TipoId;
                    datos.Descripcion = model.Descripcion;
                    datos.DocumentoId = model.DocumentoId ?? 0;
                    if (!String.IsNullOrEmpty(model.UrlVideo))
                        datos.EsVideo = true;
                    else
                        datos.EsVideo = false;
                    datos.FechaRegistro = model.FechaRegistro.ToString("dd/MM/yyyy");
                    datos.Autores = model.autores;
                    datos.UrlArchivo = model.UrlArchivo;
                    datos.UrlVideo = model.UrlVideo;

                }


                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Geo
        public static List<AgendaDTO> ConsultarEventosAgenda()
        {
            try
            {
                var model = new List<EventoGeoResultadoDTO>();
                var listResultado = new List<AgendaDTO>();
                model = UtilidadServicio.ConsultarEventosAgenda();



                if (model != null)
                {
                    foreach (var item in model)
                    {
                        var datos = new AgendaDTO();
                        datos.FechaFin = item.FechaFin ?? DateTime.Now;
                        datos.FechaInicio = item.FechaInicio ?? DateTime.Now;
                        datos.Titulo = item.Titulo;
                        datos.UtilidadId = item.UtilidadId;
                        datos.Email = item.Email;
                        datos.Telefono = item.Telefono;
                        if (item.Descripcion.Length > 189)
                            datos.Descripcion = item.Descripcion.Substring(0, 189) + "...";
                        else
                            datos.Descripcion = item.Descripcion;

                        datos.Departamento = item.Departamento;
                        datos.Municipio = item.Municipio;
                        datos.CodMunicipio = item.CodMunicipio;
                        datos.CodDepto = item.CodDepto;

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
        public static List<EventosGeoDTO> ConsultarEventosGeo(string server, int TipoUtilidadId)
        {
            try
            {
                var model = new List<EventoGeoResultadoDTO>();
                var listResultado = new List<EventosGeoDTO>();
                model = UtilidadServicio.ConsultarEventosGeo(TipoUtilidadId);

                DateTime inicio;
                DateTime final;

                if (model != null)
                {
                    foreach (var item in model)
                    {
                        var datos = new EventosGeoDTO();
                        datos.Clasificacion = item.Clasificacion;
                        inicio = item.FechaInicio ?? DateTime.Today;
                        final = item.FechaFin ?? DateTime.Today;
                        datos.FechaFin = final.ToString("dd/MM/yyyy");
                        datos.FechaInicio = inicio.ToString("dd/MM/yyyy");
                        datos.NombreActor = item.NombreActor;
                        datos.TipoActor = item.TipoActor;
                        datos.Titulo = item.Titulo;
                        datos.UtilidadId = item.UtilidadId;
                        datos.TipoActorId = item.TipoActorId;
                        datos.TipoEventoId = item.TipoEventoId;
                        datos.Email = item.Email;
                        datos.Telefono = item.Telefono;
                        datos.DocumentoId = item.DocumentoId ?? 0;
                        if (item.Descripcion.Length > 189)
                            datos.Descripcion = item.Descripcion.Substring(0, 189) + "...";
                        else
                            datos.Descripcion = item.Descripcion;
                        datos.Direccion = item.Direccion;
                        datos.Ubicacion = item.Departamento + " " + item.Municipio;
                        datos.Departamento = item.Departamento;
                        datos.Municipio = item.Municipio;
                        datos.CodMunicipio = item.CodMunicipio;
                        datos.CodDepto = item.CodDepto;

                        datos.rutaFoto = "";
                        if (item.Imagen != null)
                            datos.Imagen = item.Imagen;
                        else
                            datos.rutaFoto = server + "/img/agrupa_generica.jpg";
                        var geo = new Geometry();
                        if (item.Coordenadas != null)
                        {
                            geo.Latitud = item.Coordenadas.Latitude.Value.ToString();
                            geo.Longitud = item.Coordenadas.Longitude.Value.ToString();
                        }
                        else
                        {
                            geo.Latitud = item.LatitudMunicipio.ToString();
                            geo.Longitud = item.LongitudMunicipio.ToString();
                        }
                        datos.geometry = geo;
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

        public static List<EventosGeoDTO> ConsultarEventosGeoPorMunicipio(string server, int TipoUtilidadId, string CodMunicipio)
        {
            try
            {
                var model = new List<EventoGeoResultadoDTO>();
                var listResultado = new List<EventosGeoDTO>();
                model = UtilidadServicio.ConsultarEventosGeoPorMunicipio(TipoUtilidadId, CodMunicipio);

                DateTime inicio;
                DateTime final;

                if (model != null)
                {
                    foreach (var item in model)
                    {
                        var datos = new EventosGeoDTO();
                        datos.Clasificacion = item.Clasificacion;
                        inicio = item.FechaInicio ?? DateTime.Today;
                        final = item.FechaFin ?? DateTime.Today;
                        datos.FechaFin = final.ToString("dd/MM/yyyy");
                        datos.FechaInicio = inicio.ToString("dd/MM/yyyy");
                        datos.NombreActor = item.NombreActor;
                        datos.TipoActor = item.TipoActor;
                        datos.Titulo = item.Titulo;
                        datos.UtilidadId = item.UtilidadId;
                        datos.TipoActorId = item.TipoActorId;
                        datos.TipoEventoId = item.TipoEventoId;
                        datos.Email = item.Email;
                        datos.Telefono = item.Telefono;
                        datos.DocumentoId = item.DocumentoId ?? 0;
                        if (item.Descripcion.Length > 189)
                            datos.Descripcion = item.Descripcion.Substring(0, 189) + "...";
                        else
                            datos.Descripcion = item.Descripcion;
                        datos.Direccion = item.Direccion;
                        datos.Ubicacion = item.Departamento + " " + item.Municipio;
                        datos.Departamento = item.Departamento;
                        datos.Municipio = item.Municipio;
                        datos.CodMunicipio = item.CodMunicipio;
                        datos.CodDepto = item.CodDepto;

                        datos.rutaFoto = "";
                        if (item.Imagen != null)
                            datos.Imagen = item.Imagen;
                        else
                            datos.rutaFoto = server + "/img/agrupa_generica.jpg";
                        var geo = new Geometry();
                        if (item.Coordenadas != null)
                        {
                            geo.Latitud = item.Coordenadas.Latitude.Value.ToString();
                            geo.Longitud = item.Coordenadas.Longitude.Value.ToString();
                        }
                        else
                        {
                            geo.Latitud = item.LatitudMunicipio.ToString();
                            geo.Longitud = item.LongitudMunicipio.ToString();
                        }
                        datos.geometry = geo;
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
    }
}
