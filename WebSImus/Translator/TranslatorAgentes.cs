using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SM.Aplicacion.Agentes;
using SM.LibreriaComun.DTO;
using WebSImus.Models;

namespace WebSImus.Translator
{
    public class TranslatorAgentes
    {
        public enum Meses
        {
            Enero = 1,
            Febrero = 2,
            Marzo = 3,
            Abril = 4,
            Mayo = 5,
            Junio = 6,
            Julio = 7,
            Agosto = 8,
            Septiembre = 9,
            Octubre = 10,
            Noviembre = 11,
            Diciembre = 12
        }

        public const int Experiencia = 1;
        public const int Formacion = 2;
        public static AgenteModel ConsultarUsuarioPorId(int UsuarioId)
        {
            try
            {
                var model = new AgenteDTO();
                var datos = new AgenteModel();
                model = AgentesNeg.ConsultarUsuarioPorId(UsuarioId);

                if (model != null)
                {
                    datos.ArtMusicaUsuarioId = model.ArtMusicaUsuarioId;
                    datos.CodigoDepartamento = model.CodigoDepartamento;
                    datos.CodigoMunicipio = model.CodigoMunicipio;
                    datos.CodigoPais = model.CodigoPais;
                    datos.CorreoElectronico = model.CorreoElectronico;
                    datos.Direccion = model.Direccion;
                    datos.FechaNacimiento = model.FechaNacimiento;
                    datos.imagen = model.imagen;
                    datos.linkPortafolio = model.linkPortafolio;
                    datos.NumeroDocumento = model.NumeroDocumento;
                    datos.PrimerApellido = model.PrimerApellido;
                    datos.PrimerNombre = model.PrimerNombre;
                    datos.SegundoApellido = model.SegundoApellido;
                    datos.SegundoNombre = model.SegundoNombre;
                    datos.Sexo = model.Sexo;
                    datos.Telefono = model.Telefono;
                    datos.TipoDocumento = model.TipoDocumento;

                }


                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static AgenteModel ConsultarAgenteporId(int Id)
        {
            try
            {
                var model = new AgenteDTO();
                var datos = new AgenteModel();
                model = AgentesNeg.ConsultarAgenteporId(Id);

                if (model != null)
                {
                    datos.AgenteId = Id;
                    datos.ArtMusicaUsuarioId = model.ArtMusicaUsuarioId;
                    datos.CodigoDepartamento = model.CodigoDepartamento;
                    datos.CodigoMunicipio = model.CodigoMunicipio;
                    datos.CodigoPais = model.CodigoPais;
                    datos.CorreoElectronico = model.CorreoElectronico;
                    datos.Direccion = model.Direccion;
                    datos.FechaNacimiento = model.FechaNacimiento;
                    datos.imagen = model.imagen;
                    datos.linkPortafolio = model.linkPortafolio;
                    datos.NumeroDocumento = model.NumeroDocumento;
                    datos.PrimerApellido = model.PrimerApellido;
                    datos.PrimerNombre = model.PrimerNombre;
                    datos.SegundoApellido = model.SegundoApellido;
                    datos.SegundoNombre = model.SegundoNombre;
                    datos.Sexo = model.Sexo.Trim();
                    datos.Telefono = model.Telefono;
                    datos.TipoDocumento = model.TipoDocumento;
                    datos.EstadoId = model.EstadoId.ToString();
                    datos.EstadoOldId = model.EstadoId.ToString();
                    datos.Descripcion = model.Descripcion;
                    datos.NombreArtistico = model.NombreArtistico;
                    datos.Area = model.CodigoArea;
                }


                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static AgentePublicoModels ConsultarDatosAgentePorId(int Id)
        {
            try
            {
                var model = new AgenteDatosDTO();
                var datos = new AgentePublicoModels();
                model = AgentesNeg.ConsultarDatosAgentePorId(Id);

                if (model != null)
                {
                    datos.AgenteId = Id;
                    datos.ArtMusicaUsuarioId = model.ArtMusicaUsuarioId;
                    datos.CodigoDepartamento = model.CodigoDepartamento;
                    datos.CodigoMunicipio = model.CodigoMunicipio;
                    datos.CodigoPais = model.CodigoPais;
                    datos.CorreoElectronico = model.CorreoElectronico;
                    datos.Direccion = model.Direccion;
                    datos.FechaNacimiento = model.FechaNacimiento;
                    datos.imagen = model.imagen;
                    datos.linkPortafolio = model.linkPortafolio;
                    datos.NumeroDocumento = model.NumeroDocumento;
                    datos.PrimerApellido = model.PrimerApellido;
                    datos.PrimerNombre = model.PrimerNombre;
                    datos.SegundoApellido = model.SegundoApellido;
                    datos.SegundoNombre = model.SegundoNombre;
                    datos.Sexo = model.Sexo;
                    datos.Telefono = model.Telefono;
                    datos.TipoDocumento = model.TipoDocumento;
                    datos.TipoDocumentoDescripcion = model.TipoDocumentoDescripcion;
                    datos.Departamento = model.Departamento;
                    datos.Municipio = model.Municipio;
                    datos.Pais = model.Pais;
                    datos.Nombres = model.Nombres;
                    datos.Apellidos = model.Apellidos;
                    datos.NombreCompleto = model.NombreCompletos;
                    datos.Estado = model.Estado;
                    datos.descripcion = model.Descripcion;
                }


                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<AgentePublicoModels> ConsultarAgentePorAgrupacionId(int AgrupacionId)
        {
            try
            {
                var model = new List<AgenteDatosDTO>();
                var listAgentes = new List<AgentePublicoModels>();

                model = AgentesNeg.ConsultarAgentePorAgrupacionId(AgrupacionId);

                if (model != null)
                {
                    foreach (var item in model)
                    {
                        var datos = new AgentePublicoModels();
                        datos.AgenteId = item.AgenteId;
                        datos.ArtMusicaUsuarioId = item.ArtMusicaUsuarioId;
                        datos.CodigoDepartamento = item.CodigoDepartamento;
                        datos.CodigoMunicipio = item.CodigoMunicipio;
                        datos.CodigoPais = item.CodigoPais;
                        datos.CorreoElectronico = item.CorreoElectronico;
                        datos.Direccion = item.Direccion;
                        datos.FechaNacimiento = item.FechaNacimiento;
                        datos.imagen = item.imagen;
                        datos.linkPortafolio = item.linkPortafolio;
                        datos.NumeroDocumento = item.NumeroDocumento;
                        datos.Sexo = item.Sexo;
                        datos.Telefono = item.Telefono;
                        datos.TipoDocumento = item.TipoDocumento;
                        datos.TipoDocumentoDescripcion = item.TipoDocumentoDescripcion;
                        datos.Departamento = item.Departamento;
                        datos.Municipio = item.Municipio;
                        datos.Pais = item.Pais;
                        datos.Nombres = item.Nombres;
                        datos.Apellidos = item.Apellidos;
                        datos.NombreCompleto = item.NombreCompletos;
                        datos.Estado = item.Estado;
                        listAgentes.Add(datos);
                    }
                }


                return listAgentes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<AgentePublicoModels> ConsultarAgentesRecientePorBusqueda(string Busqueda)
        {
            try
            {
                var model = new List<AgenteDatosDTO>();
                var listAgentes = new List<AgentePublicoModels>();

                model = AgentesNeg.ConsultarAgentesRecientePorBusqueda(Busqueda);

                if (model != null)
                {
                    foreach (var item in model)
                    {
                        var datos = new AgentePublicoModels();
                        datos.AgenteId = item.AgenteId;
                        datos.ArtMusicaUsuarioId = item.ArtMusicaUsuarioId;
                        datos.CodigoDepartamento = item.CodigoDepartamento;
                        datos.CodigoMunicipio = item.CodigoMunicipio;
                        datos.CodigoPais = item.CodigoPais;
                        datos.CorreoElectronico = item.CorreoElectronico;
                        datos.Direccion = item.Direccion;
                        datos.FechaNacimiento = item.FechaNacimiento;
                        datos.imagen = item.imagen;
                        datos.linkPortafolio = item.linkPortafolio;
                        datos.NumeroDocumento = item.NumeroDocumento;
                        datos.Sexo = item.Sexo;
                        datos.Telefono = item.Telefono;
                        datos.TipoDocumento = item.TipoDocumento;
                        datos.TipoDocumentoDescripcion = item.TipoDocumentoDescripcion;
                        datos.Departamento = item.Departamento;
                        datos.Municipio = item.Municipio;
                        datos.Pais = item.Pais;
                        datos.Nombres = item.Nombres;
                        datos.Apellidos = item.Apellidos;
                        datos.NombreCompleto = item.NombreCompletos;
                        datos.Estado = item.Estado;
                        listAgentes.Add(datos);
                    }
                }


                return listAgentes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<AgentePublicoModels> ConsultarAgentesRecientes()
        {
            try
            {
                var model = new List<AgenteDatosDTO>();
                var listAgentes = new List<AgentePublicoModels>();

                model = AgentesNeg.ConsultarAgentesRecientes();

                if (model != null)
                {
                    foreach (var item in model)
                    {
                        var datos = new AgentePublicoModels();
                        datos.AgenteId = item.AgenteId;
                        datos.ArtMusicaUsuarioId = item.ArtMusicaUsuarioId;
                        datos.CodigoDepartamento = item.CodigoDepartamento;
                        datos.CodigoMunicipio = item.CodigoMunicipio;
                        datos.CodigoPais = item.CodigoPais;
                        datos.CorreoElectronico = item.CorreoElectronico;
                        datos.Direccion = item.Direccion;
                        datos.FechaNacimiento = item.FechaNacimiento;
                        datos.imagen = item.imagen;
                        datos.linkPortafolio = item.linkPortafolio;
                        datos.NumeroDocumento = item.NumeroDocumento;
                        datos.Sexo = item.Sexo;
                        datos.Telefono = item.Telefono;
                        datos.TipoDocumento = item.TipoDocumento;
                        datos.TipoDocumentoDescripcion = item.TipoDocumentoDescripcion;
                        datos.Departamento = item.Departamento;
                        datos.Municipio = item.Municipio;
                        datos.Pais = item.Pais;
                        datos.Nombres = item.Nombres;
                        datos.Apellidos = item.Apellidos;
                        datos.NombreCompleto = item.NombreCompletos;
                        datos.Estado = item.Estado;
                        listAgentes.Add(datos);
                    }
                }


                return listAgentes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
      

        public static List<AgentePublicoModels> ConsultarAgentesPorUsuarioId(int UsuarioId)
        {
            try
            {
                var model = new List<AgenteDatosDTO>();
                var listAgentes = new List<AgentePublicoModels>();

                model = AgentesNeg.ConsultarAgenteUsuarioId(UsuarioId);

                if (model != null)
                {
                    foreach (var item in model)
                    {
                        var datos = new AgentePublicoModels();
                        datos.AgenteId = item.AgenteId;
                        datos.ArtMusicaUsuarioId = item.ArtMusicaUsuarioId;
                        datos.CodigoDepartamento = item.CodigoDepartamento;
                        datos.CodigoMunicipio = item.CodigoMunicipio;
                        datos.CodigoPais = item.CodigoPais;
                        datos.CorreoElectronico = item.CorreoElectronico;
                        datos.Direccion = item.Direccion;
                        datos.FechaNacimiento = item.FechaNacimiento;
                        datos.imagen = item.imagen;
                        datos.linkPortafolio = item.linkPortafolio;
                        datos.NumeroDocumento = item.NumeroDocumento;
                        datos.Sexo = item.Sexo;
                        datos.Telefono = item.Telefono;
                        datos.TipoDocumento = item.TipoDocumento;
                        datos.TipoDocumentoDescripcion = item.TipoDocumentoDescripcion;
                        datos.Departamento = item.Departamento;
                        datos.Municipio = item.Municipio;
                        datos.Pais = item.Pais;
                        datos.Nombres = item.Nombres;
                        datos.Apellidos = item.Apellidos;
                        datos.NombreCompleto = item.NombreCompletos;
                        datos.Estado = item.Estado;
                        listAgentes.Add(datos);
                    }
                }


                return listAgentes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<AgentePublicoModels> ConsultarAgentesPorEstadoId(int EstadoId)
        {
            try
            {
                var model = new List<AgenteDatosDTO>();
                var listAgentes = new List<AgentePublicoModels>();

                model = AgentesNeg.ConsultarAgenteEstadoId(EstadoId);

                if (model != null)
                {
                    foreach (var item in model)
                    {
                        var datos = new AgentePublicoModels();
                        datos.AgenteId = item.AgenteId;
                        datos.ArtMusicaUsuarioId = item.ArtMusicaUsuarioId;
                        datos.CodigoDepartamento = item.CodigoDepartamento;
                        datos.CodigoMunicipio = item.CodigoMunicipio;
                        datos.CodigoPais = item.CodigoPais;
                        datos.CorreoElectronico = item.CorreoElectronico;
                        datos.Direccion = item.Direccion;
                        datos.FechaNacimiento = item.FechaNacimiento;
                        datos.imagen = item.imagen;
                        datos.linkPortafolio = item.linkPortafolio;
                        datos.NumeroDocumento = item.NumeroDocumento;
                        datos.Sexo = item.Sexo;
                        datos.Telefono = item.Telefono;
                        datos.TipoDocumento = item.TipoDocumento;
                        datos.TipoDocumentoDescripcion = item.TipoDocumentoDescripcion;
                        datos.Departamento = item.Departamento;
                        datos.Municipio = item.Municipio;
                        datos.Pais = item.Pais;
                        datos.Nombres = item.Nombres;
                        datos.Apellidos = item.Apellidos;
                        datos.NombreCompleto = item.NombreCompletos;
                        datos.Estado = item.Estado;
                        listAgentes.Add(datos);
                    }
                }


                return listAgentes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<AgenteExperienciaModels> ConsultarExperiencia(int AgenteId, int Tipo)
        {
            try
            {
                var model = new List<ExperienciaDTO>();
                var listExperiencia = new List<AgenteExperienciaModels>();
                model = ExperienciaNeg.ConsultarExperienciaPorAgente(AgenteId, Tipo);

                if (model != null)
                {
                    foreach (var item in model)
                    {
                        var datos = new AgenteExperienciaModels();
                        datos.AgenteId = item.AgenteId;
                        datos.AnoFin = item.AnoFin;
                        datos.AnoInicio = item.AnoInicio;
                        datos.Descripcion = item.Descripcion;
                        datos.Empresa = item.Empresa;
                        datos.ExperienciaId = item.Id;
                        datos.MesFin = item.MesFin;
                        datos.MesInicio = item.MesInicio;
                        datos.Tipo = item.Tipo;
                        datos.Titulo = item.Titulo;
                        datos.TrabajoActual = item.TrabajoActual;

                        if (datos.MesInicio == 1)
                            datos.FechaInicio = "Enero " + datos.AnoInicio.ToString();
                        else if (datos.MesInicio == 2)
                            datos.FechaInicio = "Febrero " + datos.AnoInicio.ToString();
                        else if (datos.MesInicio == 3)
                            datos.FechaInicio = "Marzo " + datos.AnoInicio.ToString();
                        else if (datos.MesInicio == 4)
                            datos.FechaInicio = "Abril " + datos.AnoInicio.ToString();
                        else if (datos.MesInicio == 5)
                            datos.FechaInicio = "Mayo " + datos.AnoInicio.ToString();
                        else if (datos.MesInicio == 6)
                            datos.FechaInicio = "Junio " + datos.AnoInicio.ToString();
                        else if (datos.MesInicio == 7)
                            datos.FechaInicio = "Julio " + datos.AnoInicio.ToString();
                        else if (datos.MesInicio == 8)
                            datos.FechaInicio = "Agosto " + datos.AnoInicio.ToString();
                        else if (datos.MesInicio ==9)
                            datos.FechaInicio = "Septiembre " + datos.AnoInicio.ToString();
                        else if (datos.MesInicio == 10)
                            datos.FechaInicio = "Octubre " + datos.AnoInicio.ToString();
                        else if (datos.MesInicio == 11)
                            datos.FechaInicio = "Noviembre " + datos.AnoInicio.ToString();
                        else if (datos.MesInicio == 12)
                            datos.FechaInicio = "Diciembre " + datos.AnoInicio.ToString();

                        if (datos.MesFin == 1)
                            datos.FechaFinal = "Enero " + datos.AnoFin.ToString();
                        else if (datos.MesFin == 2)
                            datos.FechaFinal = "Febrero " + datos.AnoFin.ToString();
                        else if (datos.MesFin == 3)
                            datos.FechaFinal = "Marzo " + datos.AnoFin.ToString();
                        else if (datos.MesFin == 4)
                            datos.FechaFinal = "Abril " + datos.AnoFin.ToString();
                        else if (datos.MesFin == 5)
                            datos.FechaFinal = "Mayo " + datos.AnoFin.ToString();
                        else if (datos.MesFin == 6)
                            datos.FechaFinal = "Junio " + datos.AnoFin.ToString();
                        else if (datos.MesFin == 7)
                            datos.FechaFinal = "Julio " + datos.AnoFin.ToString();
                        else if (datos.MesFin == 8)
                            datos.FechaFinal = "Agosto " + datos.AnoFin.ToString();
                        else if (datos.MesFin == 9)
                            datos.FechaFinal = "Septiembre " + datos.AnoFin.ToString();
                        else if (datos.MesFin == 10)
                            datos.FechaFinal = "Octubre " + datos.AnoFin.ToString();
                        else if (datos.MesFin == 11)
                            datos.FechaFinal = "Noviembre " + datos.AnoFin.ToString();
                        else if (datos.MesFin == 12)
                            datos.FechaFinal = "Diciembre " + datos.AnoFin.ToString();
                        listExperiencia.Add(datos);
                    }

                }


                return listExperiencia;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}