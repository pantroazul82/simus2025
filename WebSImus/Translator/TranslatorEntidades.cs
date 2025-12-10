using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SM.Aplicacion.Entidades;
using SM.LibreriaComun.DTO;
using WebSImus.Models;

namespace WebSImus.Translator
{
    public class TranslatorEntidades
    {
        public static EntidadModels ConsultaEntidadPorId(int Id)
        {
            try
            {
                var model = new EntidadDTO();
                var datos = new EntidadModels();
                model = EntidadNeg.ConsultarEntidadporId(Id);

                if (model != null)
                {
                    datos.ArtMusicaUsuarioId = model.ArtMusicaUsuarioId;
                    datos.CodigoDepartamento = model.CodigoDepartamento;
                    datos.CodigoMunicipio = model.CodigoMunicipio;
                  
                    datos.CorreoElectronico = model.CorreoElectronico.Trim();
                    datos.Descripcion = model.Descripcion;
                    if (model.DigitoVerificacion == 0)
                        datos.DigitoVerificacion ="";
                    else
                        datos.DigitoVerificacion = model.DigitoVerificacion.ToString();
                    datos.Direccion = model.Direccion;
                    datos.EstadoId = model.EstadoId.ToString();
                    datos.EstadoOldId = model.EstadoId.ToString();
                    datos.FechaActualizacion = model.FechaActualizacion;
                    datos.FechaCreacion = model.FechaCreacion;
                    datos.Id = model.Id;
                    datos.Imagen = model.Imagen;
                    datos.Latitud = model.Latitud;
                    datos.LinkPortafolio = model.LinkPortafolio;
                    datos.Longitud = model.Longitud;
                    datos.Nit = model.Nit.ToString();
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

        public static EntidadDatosModels ConsultarDatosEntidadPorId(int Id)
        {
            try
            {
                var model = new EntidadDatosDTO();
                var datos = new EntidadDatosModels();
                model = EntidadNeg.ConsultarDatosEntidadPorId(Id);

                if (model != null)
                {
                    datos.Id = model.Id;
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
                    datos.DigitoVerificacion = model.DigitoVerificacion;
                    datos.Nit = model.Nit;
                    datos.Nombre = model.Nombre;
                    datos.Naturaleza = model.Naturaleza;
                    datos.Telefono = model.Telefono;
                    datos.Estado = model.Estado;
                    datos.FechaActualizacion = model.FechaActualizacion ;
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

        public static List<EntidadDatosModels> ConsultarEntidadTodos()
        {
            try
            {
                var model = new List<EntidadDatosNuevoDTO>();
                var listEntidad = new List<EntidadDatosModels>();

                model = EntidadNeg.ConsultarEntidadTodos();

                if (model != null)
                {
                    foreach (var item in model)
                    {
                        var datos = new EntidadDatosModels();
                        datos.Id = item.Id;
                        datos.Departamento = item.Departamento;
                        datos.Municipio = item.Municipio;
                        datos.Nit = item.Nit;
                        datos.Nombre = item.Nombre;
                        datos.Naturaleza = item.Naturaleza;
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

        public static List<EntidadDatosModels> ConsultarEntidadPorUsuarioId(int UsuarioId)
        {
            try
            {
                var model = new List<EntidadDatosDTO>();
                var listEntidad = new List<EntidadDatosModels>();

                model = EntidadNeg.ConsultarEntidadPorUsuarioId(UsuarioId);

                if (model != null)
                {
                    foreach (var item in model)
                    {
                        var datos = new EntidadDatosModels();
                        datos.Id = item.Id;
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
                        datos.DigitoVerificacion = item.DigitoVerificacion;
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

   
        public static List<EntidadDatosModels> ConsultarEntidadPorEstado(int EstadoId)
        {
            try
            {
                var model = new List<EntidadDatosDTO>();
                var listEntidad = new List<EntidadDatosModels>();

                model = EntidadNeg.ConsultarEntidadPorEstado(EstadoId);

                if (model != null)
                {
                    foreach (var item in model)
                    {
                        var datos = new EntidadDatosModels();
                        datos.Id = item.Id;
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
                        datos.DigitoVerificacion = item.DigitoVerificacion;
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
    }
}