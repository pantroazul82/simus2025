using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SM.Aplicacion.Agrupacion;
using SM.LibreriaComun.DTO;
using WebSImus.Models;
namespace WebSImus.Translator
{
    public class TranslatorAgrupacion
    {
        public static AgrupacionNuevoModels ConsultarAgrupacionPorId(int Id)
        {
            try
            {
                var model = new AgrupacionDTO();
                var datos = new AgrupacionNuevoModels();
                model = AgrupacionNeg.ConsultarAgrupacionPorId(Id);

                if (model != null)
                {
                    datos.ArtMusicaUsuarioId = model.ArtMusicaUsuarioId;
                    datos.CodigoDepartamento = model.CodigoDepartamento;
                    datos.CodigoMunicipio = model.CodigoMunicipio;
                    datos.CodigoPais = model.CodigoPais;
                    datos.CorreoElectronico = model.CorreoElectronico;
                    datos.Descripcion = model.Descripcion;
                    datos.TipoAgrupacionId = model.TipoAgrupacionId.ToString();
                    datos.Direccion = model.Direccion;
                    datos.EstadoId = model.EstadoId.ToString();
                    datos.EstadoOldId = model.EstadoId.ToString();
                    datos.FechaActualizacion = model.FechaActualizacion;
                    datos.FechaCreacion = model.FechaCreacion;
                    datos.AgrupacionId = model.AgrupacionId;
                    datos.imagen = model.imagen;
                    datos.Latitud = model.Latitud;
                    datos.linkPortafolio = model.linkPortafolio;
                    datos.Longitud = model.Longitud;
                    datos.Nombre = model.Nombre;
                    datos.Telefono = model.Telefono;
                    datos.DocumentoId = model.DocumentoId;
                    datos.NaturalezaId = model.NaturalezaId.ToString();
                    if (model.AreaId == 0)
                        datos.AreaId = "4";
                    else
                        datos.AreaId = model.AreaId.ToString();

                    if (model.DocumentoId > 0)
                    {
                        datos.DocumentoId = model.DocumentoId;
                        datos.documentoArchivo = TranslatorDocumento.ConsultaDocumento(datos.DocumentoId);
                    }
                    else
                        datos.DocumentoId = 0;

                }


                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static AgrupacionDataModels ConsultarDatosAgrupacionPorId(int Id)
        {
            try
            {
                var model = new AgrupacionDataDTO();
                var datos = new AgrupacionDataModels();
                model = AgrupacionNeg.ConsultarDatosAgrupacionPorId(Id);

                if (model != null)
                {
                    datos.AgrupacionId = model.AgrupacionId;
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
                    datos.CODIGO = model.CODIGO;
                    datos.DOC_NOMBRE = model.DOC_NOMBRE;
                    datos.Identificacion = model.Identificacion;
                    datos.Descripcion = model.Descripcion;
                    datos.NombreDirector = model.NombreDirector;
                    datos.ApellidoDirector = model.ApellidoDirector;
                    datos.Nombre = model.Nombre;
                    datos.TipoAgrupacion = model.TipoAgrupacion;
                    datos.Telefono = model.Telefono;
                    datos.Estado = model.Estado;
                    datos.FechaActualizacion = model.FechaActualizacion.ToString("dd/MM/yyyy");
                    datos.FechaCreacion = model.FechaCreacion.ToString("dd/MM/yyyy");
                    datos.documentoId = model.DocumentoId;
                }


                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<AgrupacionDataModels> ConsultarAgrupacionTodos()
        {
            try
            {
                var model = new List<AgrupacionDataDTO>();
                var listResultado = new List<AgrupacionDataModels>();

                model = AgrupacionNeg.ConsultarAgrupacionTodos();

                if (model != null)
                {
                    foreach (var item in model)
                    {
                        var datos = new AgrupacionDataModels();
                        datos.AgrupacionId = item.AgrupacionId;
                        datos.Departamento = item.Departamento;
                        datos.Municipio = item.Municipio;
                        datos.Nombre = item.Nombre;
                        datos.TipoAgrupacion = item.TipoAgrupacion;
                        datos.Estado = item.Estado;
                        datos.FechaActualizacion = item.FechaActualizacion.ToString("dd/MM/yyyy"); ;
                        datos.FechaCreacion = item.FechaCreacion.ToString("dd/MM/yyyy"); ;
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

        public static List<AgrupacionDataModels> ConsultarAgrupacionUsuarioId(int UsuarioId)
        {
            try
            {
                var model = new List<AgrupacionDataDTO>();
                var listResultado = new List<AgrupacionDataModels>();

                model = AgrupacionNeg.ConsultarAgrupacionPorUsuarioId(UsuarioId);

                if (model != null)
                {
                    foreach (var item in model)
                    {
                        var datos = new AgrupacionDataModels();
                        datos.AgrupacionId = item.AgrupacionId;
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
                        datos.CODIGO = item.CODIGO;
                        datos.DOC_NOMBRE = item.DOC_NOMBRE;
                        datos.Identificacion = item.Identificacion;
                        datos.Descripcion = item.Descripcion;
                        datos.NombreDirector = item.NombreDirector;
                        datos.ApellidoDirector = item.ApellidoDirector;
                        datos.Nombre = item.Nombre;
                        datos.TipoAgrupacion = item.TipoAgrupacion;
                        datos.Telefono = item.Telefono;
                        datos.Estado = item.Estado;
                        datos.FechaActualizacion = item.FechaActualizacion.ToString("dd/MM/yyyy");
                        datos.FechaCreacion = item.FechaCreacion.ToString("dd/MM/yyyy"); ;
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

        public static List<AgrupacionDataModels> ConsultarAgrupacionPorMunicipio(int UsuarioId)
        {
            try
            {
                var model = new List<AgrupacionDataDTO>();
                var listResultado = new List<AgrupacionDataModels>();

                model = AgrupacionNeg.ConsultarAgrupacionPorMunicipio(UsuarioId);

                if (model != null)
                {
                    foreach (var item in model)
                    {
                        var datos = new AgrupacionDataModels();
                        datos.AgrupacionId = item.AgrupacionId;
                        datos.Departamento = item.Departamento;
                        datos.Municipio = item.Municipio;
                        datos.Nombre = item.Nombre;
                        datos.TipoAgrupacion = item.TipoAgrupacion;
                        datos.Estado = item.Estado;
                        datos.FechaActualizacion = item.FechaActualizacion.ToString("dd/MM/yyyy"); ;
                        datos.FechaCreacion = item.FechaCreacion.ToString("dd/MM/yyyy"); ;
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

        public static List<AgrupacionDataModels> ConsultarAgrupacionPorEstadoId(int EstadoId)
        {
            try
            {
                var model = new List<AgrupacionDataDTO>();
                var listResultado = new List<AgrupacionDataModels>();

                model = AgrupacionNeg.ConsultarAgrupacionPorEstadoId(EstadoId);

                if (model != null)
                {
                    foreach (var item in model)
                    {
                        var datos = new AgrupacionDataModels();
                        datos.AgrupacionId = item.AgrupacionId;
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
                        datos.CODIGO = item.CODIGO;
                        datos.DOC_NOMBRE = item.DOC_NOMBRE;
                        datos.Identificacion = item.Identificacion;
                        datos.Descripcion = item.Descripcion;
                        datos.NombreDirector = item.NombreDirector;
                        datos.ApellidoDirector = item.ApellidoDirector;
                        datos.Nombre = item.Nombre;
                        datos.TipoAgrupacion = item.TipoAgrupacion;
                        datos.Telefono = item.Telefono;
                        datos.Estado = item.Estado;
                        datos.FechaActualizacion = item.FechaActualizacion.ToString("dd/MM/yyyy"); ;
                        datos.FechaCreacion = item.FechaCreacion.ToString("dd/MM/yyyy"); ;
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
    }
}