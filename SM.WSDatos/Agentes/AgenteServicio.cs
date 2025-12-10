using SM.SIPA;
using SM.WSDatos.Helper;
using SM.WSDatos.WSDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.WSDatos.Agentes
{
    public class AgenteServicio
    {
        public static List<AgenteDTO> ConsultarAgentes(string usuario, string contrasena, out string mensajeError)
        {
            List<AgenteDTO> ListAgentes = new List<AgenteDTO>();
            string codigoDepartamento = "";
            try
            {
                codigoDepartamento = UsuarioWsService.ValidaUsuario(usuario, contrasena);

                if (string.IsNullOrEmpty(codigoDepartamento))
                {
                    mensajeError = "Usuario y/o contrasena invalido";

                }
                else
                {
                    mensajeError = "";
                    using (var context = new SIPAEntities())
                    {

                        ListAgentes = (from a in context.ART_MUSICA_AGENTE
                                       join z in context.BAS_ZONAS_GEOGRAFICAS on a.CodMunicipio equals z.ZON_ID
                                       join d in context.BAS_ZONAS_GEOGRAFICAS on z.ZON_PADRE_ID equals d.ZON_ID
                                       join t in context.BAS_TIPOS_DOCUMENTOS_IDENTIDAD on a.CodTipoDocumento equals t.DOC_ID
                                       where d.ZON_ID == codigoDepartamento
                                       select new AgenteDTO
                                       {
                                           AgenteId = a.ID,
                                           CodigoDepartamento = d.ZON_ID,
                                           CodigoMunicipio = z.ZON_ID,
                                           CorreoElectronico = a.CorreoElectronico,
                                           Direccion = a.Direccion,
                                           FechaActualizacion = a.FechaActualizacion,
                                           FechaNacimiento = a.FechaNacimiento,
                                           Genero = a.Sexo,
                                           FechaCreacion = a.FechaCreacion,
                                           Imagen = a.Imagen,
                                           Latitud = z.ZON_LATITUD.ToString(),
                                           Longitud = z.ZON_LONGITUD.ToString(),
                                           NumeroDocumento = a.Identificacion,
                                           PrimerApellido = a.PrimerApellido,
                                           PrimerNombre = a.PrimerNombre,
                                           SegundoApellido = a.SedundoApellido,
                                           SegundoNombre = a.SegundoNombre,
                                           Telefono = a.Telefono,
                                           TipoDocumento = t.CODIGO
                                       }).ToList();


                    }
                }
                return ListAgentes;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static AgenteDTO ConsultarAgentePorId(string usuario, string contrasena, int AgenteId, out string mensajeError)
        {
            AgenteDTO Agente = new AgenteDTO();
            string codigoDepartamento = "";
            try
            {
                codigoDepartamento = UsuarioWsService.ValidaUsuario(usuario, contrasena);

                if (string.IsNullOrEmpty(codigoDepartamento))
                {
                    mensajeError = "Usuario y/o contrasena invalido";
                }
                else
                {
                    mensajeError = "";
                    using (var context = new SIPAEntities())
                    {

                        Agente = (from a in context.ART_MUSICA_AGENTE
                                  join z in context.BAS_ZONAS_GEOGRAFICAS on a.CodMunicipio equals z.ZON_ID
                                  join d in context.BAS_ZONAS_GEOGRAFICAS on z.ZON_PADRE_ID equals d.ZON_ID
                                  join t in context.BAS_TIPOS_DOCUMENTOS_IDENTIDAD on a.CodTipoDocumento equals t.DOC_ID
                                  where d.ZON_ID == codigoDepartamento
                                  where a.ID == AgenteId
                                  select new AgenteDTO
                                  {
                                      AgenteId = a.ID,
                                      CodigoDepartamento = d.ZON_ID,
                                      CodigoMunicipio = z.ZON_ID,
                                      CorreoElectronico = a.CorreoElectronico,
                                      Direccion = a.Direccion,
                                      FechaActualizacion = a.FechaActualizacion,
                                      FechaNacimiento = a.FechaNacimiento,
                                      Genero = a.Sexo,
                                      FechaCreacion = a.FechaCreacion,
                                      Imagen = a.Imagen,
                                      Latitud = z.ZON_LATITUD.ToString(),
                                      Longitud = z.ZON_LONGITUD.ToString(),
                                      NumeroDocumento = a.Identificacion,
                                      PrimerApellido = a.PrimerApellido,
                                      PrimerNombre = a.PrimerNombre,
                                      SegundoApellido = a.SedundoApellido,
                                      SegundoNombre = a.SegundoNombre,
                                      Telefono = a.Telefono,
                                      TipoDocumento = t.CODIGO
                                  }).FirstOrDefault();


                    }
                }
                return Agente;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static AgenteDTO ConsultarAgentePorIdentificacion(string usuario, string contrasena, string tipoDocumento, string numeroDocumento, out string strMensajeError)
        {
            AgenteDTO Agente = new AgenteDTO();
            string codigoDepartamento = "";
            try
            {
                codigoDepartamento = UsuarioWsService.ValidaUsuario(usuario, contrasena);

                if (string.IsNullOrEmpty(codigoDepartamento))
                {
                    strMensajeError = "Usuario y/o contrasena invalido";
                }
                else
                {
                    strMensajeError = "";
                    using (var context = new SIPAEntities())
                    {

                        Agente = (from a in context.ART_MUSICA_AGENTE
                                  join z in context.BAS_ZONAS_GEOGRAFICAS on a.CodMunicipio equals z.ZON_ID
                                  join d in context.BAS_ZONAS_GEOGRAFICAS on z.ZON_PADRE_ID equals d.ZON_ID
                                  join t in context.BAS_TIPOS_DOCUMENTOS_IDENTIDAD on a.CodTipoDocumento equals t.DOC_ID
                                  where d.ZON_ID == codigoDepartamento
                                  where t.CODIGO == tipoDocumento
                                  where a.Identificacion == numeroDocumento
                                  select new AgenteDTO
                                  {
                                      AgenteId = a.ID,
                                      CodigoDepartamento = d.ZON_ID,
                                      CodigoMunicipio = z.ZON_ID,
                                      CorreoElectronico = a.CorreoElectronico,
                                      Direccion = a.Direccion,
                                      FechaActualizacion = a.FechaActualizacion,
                                      FechaNacimiento = a.FechaNacimiento,
                                      Genero = a.Sexo,
                                      FechaCreacion = a.FechaCreacion,
                                      Imagen = a.Imagen,
                                      Latitud = z.ZON_LATITUD.ToString(),
                                      Longitud = z.ZON_LONGITUD.ToString(),
                                      NumeroDocumento = a.Identificacion,
                                      PrimerApellido = a.PrimerApellido,
                                      PrimerNombre = a.PrimerNombre,
                                      SegundoApellido = a.SedundoApellido,
                                      SegundoNombre = a.SegundoNombre,
                                      Telefono = a.Telefono,
                                      TipoDocumento = t.CODIGO
                                  }).FirstOrDefault();


                    }
                }
                return Agente;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<AgenteDTO> ConsultarAgentesPorRangoFechas(string usuario, string contrasena, DateTime FechaInicio, DateTime FechaFinal, out string strMensajeError)
        {
            List<AgenteDTO> ListAgentes = new List<AgenteDTO>();
            string codigoDepartamento = "";
            try
            {
                codigoDepartamento = UsuarioWsService.ValidaUsuario(usuario, contrasena);

                if (string.IsNullOrEmpty(codigoDepartamento))
                {
                    strMensajeError = "Usuario y/o contrasena invalido";
                }
                else
                {
                    if (FechaFinal < FechaInicio)
                    {
                        strMensajeError = "La fecha final no puede ser menor a la inicial";
                    }
                    else
                    {
                        strMensajeError = "";
                        using (var context = new SIPAEntities())
                        {

                            ListAgentes = (from a in context.ART_MUSICA_AGENTE
                                           join z in context.BAS_ZONAS_GEOGRAFICAS on a.CodMunicipio equals z.ZON_ID
                                           join d in context.BAS_ZONAS_GEOGRAFICAS on z.ZON_PADRE_ID equals d.ZON_ID
                                           join t in context.BAS_TIPOS_DOCUMENTOS_IDENTIDAD on a.CodTipoDocumento equals t.DOC_ID
                                           where d.ZON_ID == codigoDepartamento
                                           where a.FechaActualizacion >= FechaInicio
                                           where a.FechaActualizacion <= FechaFinal
                                           select new AgenteDTO
                                           {
                                               AgenteId = a.ID,
                                               CodigoDepartamento = d.ZON_ID,
                                               CodigoMunicipio = z.ZON_ID,
                                               CorreoElectronico = a.CorreoElectronico,
                                               Direccion = a.Direccion,
                                               FechaActualizacion = a.FechaActualizacion,
                                               FechaNacimiento = a.FechaNacimiento,
                                               Genero = a.Sexo,
                                               FechaCreacion = a.FechaCreacion,
                                               Imagen = a.Imagen,
                                               Latitud = z.ZON_LATITUD.ToString(),
                                               Longitud = z.ZON_LONGITUD.ToString(),
                                               NumeroDocumento = a.Identificacion,
                                               PrimerApellido = a.PrimerApellido,
                                               PrimerNombre = a.PrimerNombre,
                                               SegundoApellido = a.SedundoApellido,
                                               SegundoNombre = a.SegundoNombre,
                                               Telefono = a.Telefono,
                                               TipoDocumento = t.CODIGO
                                           }).ToList();
                        }

                    }
                }
                return ListAgentes;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       
    }
}
