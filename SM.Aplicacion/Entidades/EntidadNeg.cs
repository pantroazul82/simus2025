using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SM.Datos.Entidades;
using SM.SIPA;
using SM.LibreriaComun.DTO;
using SM.Datos.DTO;

namespace SM.Aplicacion.Entidades
{
    public class EntidadNeg
    {
        #region Actualizacion
        public static void CrearEntidad(EntidadDTO entidad, string[] TipoEntidad, string NombreUsuario, string strIP)
        {
            try
            {

                EntidadServicio.CrearEntidad(entidad.ArtMusicaUsuarioId,
                                              entidad.Nombre,
                                              entidad.Nit,
                                              entidad.DigitoVerificacion,
                                              entidad.CodigoPais,
                                              entidad.CodigoMunicipio,
                                              entidad.CodigoDepartamento,
                                              entidad.Direccion,
                                              entidad.CorreoElectronico,
                                              entidad.Telefono,
                                              entidad.LinkPortafolio,
                                              entidad.Imagen,
                                              entidad.Descripcion,
                                              entidad.Naturaleza,
                                              TipoEntidad,
                                              NombreUsuario,
                                              strIP);

            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public static bool ExisteNit(string numero)
        {
            bool respuesta = false;


            respuesta = respuesta = EntidadServicio.ExisteNit(Convert.ToInt32(numero));
            return respuesta;
        }
        public static void ActualizarEntidad(EntidadDTO entidad, bool Escambiar, string[] TipoEntidad, string NombreUsuario, string strIP)
        {

            try
            {
                if (Escambiar)
                {
                    EntidadServicio.ActualizarEntidadEstado(entidad.Id,
                                                     entidad.ArtMusicaUsuarioId,
                                                     entidad.Nombre,
                                                     entidad.Nit,
                                                     entidad.DigitoVerificacion,
                                                     entidad.CodigoPais,
                                                     entidad.CodigoMunicipio,
                                                     entidad.CodigoDepartamento,
                                                     entidad.Direccion,
                                                     entidad.CorreoElectronico,
                                                     entidad.Telefono,
                                                     entidad.LinkPortafolio,
                                                     entidad.Imagen,
                                                     entidad.Descripcion,
                                                     entidad.Naturaleza,
                                                     entidad.EstadoId,
                                                     TipoEntidad,
                                                     NombreUsuario,
                                                     strIP);
                }
                else
                {
                    EntidadServicio.ActualizarEntidad(entidad.Id,
                                                      entidad.ArtMusicaUsuarioId,
                                                      entidad.Nombre,
                                                      entidad.Nit,
                                                      entidad.DigitoVerificacion,
                                                      entidad.CodigoPais,
                                                      entidad.CodigoMunicipio,
                                                      entidad.CodigoDepartamento,
                                                      entidad.Direccion,
                                                      entidad.CorreoElectronico,
                                                      entidad.Telefono,
                                                      entidad.LinkPortafolio,
                                                      entidad.Imagen,
                                                      entidad.Descripcion,
                                                      entidad.Naturaleza,
                                                      TipoEntidad,
                                                      NombreUsuario,
                                                      strIP);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public static void EliminarEntidad(int entidadId)
        {
            try
            {
                EntidadServicio.EliminarEntidad(entidadId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Consultas

        public static EntidadDTO ConsultarEntidadporId(int entidadId)
        {
            try
            {
                var model = new ART_MUSICA_ENTIDADES();
                var datos = new EntidadDTO();
                model = EntidadServicio.ConsultarEntidadPorId(entidadId);

                if (model != null)
                {
                    datos.ArtMusicaUsuarioId = model.ArtMusicaUsuarioId;
                    datos.CodigoDepartamento = model.CodigoDepartamento;
                    datos.CodigoMunicipio = model.CodigoMunicipio;
                    datos.CodigoPais = model.CodigoPais;
                    datos.CorreoElectronico = model.CorreoElectronico;
                    datos.Descripcion = model.Descripcion;
                    datos.DigitoVerificacion = model.DigitoVerificacion ?? 0;
                    datos.Direccion = model.Direccion;
                    datos.EstadoId = model.EstadoId;
                    datos.FechaActualizacion = model.FechaActualizacion;
                    datos.FechaCreacion = model.FechaCreacion;
                    datos.Id = model.Id;
                    datos.Imagen = model.Imagen;
                    datos.Latitud = model.Latitud;
                    datos.LinkPortafolio = model.LinkPortafolio;
                    datos.Longitud = model.Longitud;
                    datos.Nit = model.Nit;
                    datos.Nombre = model.Nombre;
                    datos.Telefono = model.Telefono;
                    datos.Naturaleza = model.Naturaleza;

                }


                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static EntidadDatosDTO ConsultarDatosEntidadPorId(int entidadId)
        {
            try
            {
                var model = new EntidadResultadoDTO();
                var datos = new EntidadDatosDTO();
                model = EntidadServicio.ConsultarDatosEntidadPorId(entidadId);

                if (model != null)
                {
                    datos.Id = model.EntidadId;
                    datos.CodigoDepartamento = model.CodigoDepartamento;
                    datos.CodigoMunicipio = model.CodigoMunicipio;
                    datos.CodigoPais = model.CodigoPais;
                    datos.CorreoElectronico = model.CorreoElectronico;
                    datos.Direccion = model.Direccion;
                    datos.Imagen = model.Imagen;
                    datos.LinkPortafolio = model.LinkPortafolio;
                    datos.Departamento = model.Departamento;
                    datos.Pais = model.Pais;
                    datos.Municipio = model.Municipio;
                    datos.DigitoVerificacion = model.DigitoVerificacion ?? 0;
                    datos.Nit = model.Nit;
                    datos.Nombre = model.Nombre;
                    datos.Naturaleza = model.Naturaleza;
                    datos.Telefono = model.Telefono;
                    datos.Estado = model.Estado;
                    datos.FechaActualizacion = model.FechaActualizacion;
                    datos.FechaCreacion = model.FechaCreacion;
                    datos.Descripcion = model.Descripcion; 

                }


                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<EntidadDatosNuevoDTO> ConsultarEntidadTodos()
        {
            try
            {
                var model = new List<EntidadDatosNuevoDTO>();
               return  model = EntidadServicio.ConsultarEntidadTodos();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<EntidadDatosDTO> ConsultarEntidadPorUsuarioId(int UsuarioID)
        {
            try
            {
                var model = new List<EntidadResultadoDTO>();
                var listEntidad = new List<EntidadDatosDTO>();
                model = EntidadServicio.ConsultarEntidadPorUsuarioId(UsuarioID);

                if (model != null)
                {
                    foreach (var item in model)
                    {
                        var datos = new EntidadDatosDTO();
                        datos.Id = item.EntidadId;
                        datos.CodigoDepartamento = item.CodigoDepartamento;
                        datos.CodigoMunicipio = item.CodigoMunicipio;
                        datos.CodigoPais = item.CodigoPais;
                        datos.CorreoElectronico = item.CorreoElectronico;
                        datos.Direccion = item.Direccion;
                        datos.Imagen = item.Imagen;
                        datos.LinkPortafolio = item.LinkPortafolio;
                        datos.Departamento = item.Departamento;
                        datos.Pais = item.Pais;
                        datos.Municipio = item.Municipio;
                        datos.DigitoVerificacion = item.DigitoVerificacion ?? 0;
                        datos.Nit = item.Nit;
                        datos.Nombre = item.Nombre;
                        datos.Naturaleza = item.Naturaleza;
                        datos.Telefono = item.Telefono;
                        datos.Estado = item.Estado;
                        datos.FechaActualizacion = item.FechaActualizacion;
                        datos.FechaCreacion = item.FechaCreacion;
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

        public static List<EntidadDatosNuevoDTO> ConsultarEntidadPorMunicipio(int UsuarioID)
        {
            try
            {
                var model = new List<EntidadDatosNuevoDTO>();
               return model = EntidadServicio.ConsultarEntidadPorMunicipio(UsuarioID);

               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<EntidadDatosDTO> ConsultarEntidadPorEstado(int EstadoId)
        {
            try
            {
                var model = new List<EntidadResultadoDTO>();
                var listEntidad = new List<EntidadDatosDTO>();
                model = EntidadServicio.ConsultarEntidadPorEstado(EstadoId);

                if (model != null)
                {
                    foreach (var item in model)
                    {
                        var datos = new EntidadDatosDTO();
                        datos.Id = item.EntidadId;
                        datos.CodigoDepartamento = item.CodigoDepartamento;
                        datos.CodigoMunicipio = item.CodigoMunicipio;
                        datos.CodigoPais = item.CodigoPais;
                        datos.CorreoElectronico = item.CorreoElectronico;
                        datos.Direccion = item.Direccion;
                        datos.Imagen = item.Imagen;
                        datos.LinkPortafolio = item.LinkPortafolio;
                        datos.Departamento = item.Departamento;
                        datos.Pais = item.Pais;
                        datos.Municipio = item.Municipio;
                        datos.DigitoVerificacion = item.DigitoVerificacion ?? 0;
                        datos.Nit = item.Nit;
                        datos.Nombre = item.Nombre;
                        datos.Naturaleza = item.Naturaleza;
                        datos.Telefono = item.Telefono;
                        datos.Estado = item.Estado;
                        datos.FechaActualizacion = item.FechaActualizacion;
                        datos.FechaCreacion = item.FechaCreacion;
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
        #endregion
    }
}
