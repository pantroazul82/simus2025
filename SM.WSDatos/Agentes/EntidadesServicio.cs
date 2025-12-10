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
    public class EntidadesServicio
    {
        public static List<EntidadesDTO> ConsultarEntidades(string usuario, string contrasena, out string mensajeError)
        {
            List<EntidadesDTO> ListEntidades = new List<EntidadesDTO>();
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

                        ListEntidades = (from a in context.ART_MUSICA_ENTIDADES
                                         join z in context.BAS_ZONAS_GEOGRAFICAS on a.CodigoMunicipio equals z.ZON_ID
                                         join d in context.BAS_ZONAS_GEOGRAFICAS on z.ZON_PADRE_ID equals d.ZON_ID
                                         where d.ZON_ID == codigoDepartamento
                                         select new EntidadesDTO
                                         {
                                             EntidadId = a.Id,
                                             CodigoDepartamento = d.ZON_ID,
                                             CodigoMunicipio = z.ZON_ID,
                                             CorreoElectronico = a.CorreoElectronico,
                                             Direccion = a.Direccion,
                                             FechaActualizacion = a.FechaActualizacion,
                                             FechaCreacion = a.FechaCreacion,
                                             Latitud = z.ZON_LATITUD.ToString(),
                                             Longitud = z.ZON_LONGITUD.ToString(),
                                             Nombre = a.Nombre,
                                             Nit = a.Nit,
                                             DigitoVerificacion = ((a.DigitoVerificacion == null) ? 0 : (int)a.DigitoVerificacion),
                                             LinkPortafolio = a.LinkPortafolio,
                                             Telefono = a.Telefono,
                                             Descripcion = a.Descripcion,
                                             TipoEntidad =""

                                         }).ToList();


                    }
                }
                return ListEntidades;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<EntidadesDTO> ConsultarEntidadesPorRangoFechas(string usuario, string contrasena, DateTime FechaInicio, DateTime FechaFinal, out string mensajeError)
        {
            List<EntidadesDTO> ListEntidades = new List<EntidadesDTO>();
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
                    if (FechaFinal < FechaInicio)
                    {
                        mensajeError = "La fecha final no puede ser menor a la inicial";
                    }
                    else
                    {
                        mensajeError = "";
                        using (var context = new SIPAEntities())
                        {

                            ListEntidades = (from a in context.ART_MUSICA_ENTIDADES
                                             join z in context.BAS_ZONAS_GEOGRAFICAS on a.CodigoMunicipio equals z.ZON_ID
                                             join d in context.BAS_ZONAS_GEOGRAFICAS on z.ZON_PADRE_ID equals d.ZON_ID
                                             where d.ZON_ID == codigoDepartamento
                                             where a.FechaActualizacion >= FechaInicio
                                             where a.FechaActualizacion <= FechaFinal
                                             select new EntidadesDTO
                                             {
                                                 EntidadId = a.Id,
                                                 CodigoDepartamento = d.ZON_ID,
                                                 CodigoMunicipio = z.ZON_ID,
                                                 CorreoElectronico = a.CorreoElectronico,
                                                 Direccion = a.Direccion,
                                                 FechaActualizacion = a.FechaActualizacion,
                                                 FechaCreacion = a.FechaCreacion,
                                                 Latitud = z.ZON_LATITUD.ToString(),
                                                 Longitud = z.ZON_LONGITUD.ToString(),
                                                 Nombre = a.Nombre,
                                                 Nit = a.Nit,
                                                 DigitoVerificacion = ((a.DigitoVerificacion == null) ? 0 : (int)a.DigitoVerificacion),
                                                 LinkPortafolio = a.LinkPortafolio,
                                                 Telefono = a.Telefono,
                                                 Descripcion = a.Descripcion,
                                                 TipoEntidad = ""

                                             }).ToList();

                        }
                    }
                }
                return ListEntidades;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static EntidadesDTO ConsultarEntidadesPorId(string usuario, string contrasena, int EntidadId, out string mensajeError)
        {
            EntidadesDTO entidad = new EntidadesDTO();
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

                        entidad = (from a in context.ART_MUSICA_ENTIDADES
                                   join z in context.BAS_ZONAS_GEOGRAFICAS on a.CodigoMunicipio equals z.ZON_ID
                                   join d in context.BAS_ZONAS_GEOGRAFICAS on z.ZON_PADRE_ID equals d.ZON_ID
                                    where d.ZON_ID == codigoDepartamento
                                   where a.Id == EntidadId
                                   select new EntidadesDTO
                                   {
                                       EntidadId = a.Id,
                                       CodigoDepartamento = d.ZON_ID,
                                       CodigoMunicipio = z.ZON_ID,
                                       CorreoElectronico = a.CorreoElectronico,
                                       Direccion = a.Direccion,
                                       FechaActualizacion = a.FechaActualizacion,
                                       FechaCreacion = a.FechaCreacion,
                                       Latitud = z.ZON_LATITUD.ToString(),
                                       Longitud = z.ZON_LONGITUD.ToString(),
                                       Nombre = a.Nombre,
                                       Nit = a.Nit,
                                       DigitoVerificacion = ((a.DigitoVerificacion == null) ? 0 : (int)a.DigitoVerificacion),
                                       LinkPortafolio = a.LinkPortafolio,
                                       Telefono = a.Telefono,
                                       Descripcion = a.Descripcion,
                                       TipoEntidad = ""

                                   }).FirstOrDefault();


                    }
                }
                return entidad;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static EntidadesDTO ConsultarEntidadesPorNit(string usuario, string contrasena, int Nit, out string mensajeError)
        {
            EntidadesDTO entidad = new EntidadesDTO();
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

                        entidad = (from a in context.ART_MUSICA_ENTIDADES
                                   join z in context.BAS_ZONAS_GEOGRAFICAS on a.CodigoMunicipio equals z.ZON_ID
                                   join d in context.BAS_ZONAS_GEOGRAFICAS on z.ZON_PADRE_ID equals d.ZON_ID
                                   where d.ZON_ID == codigoDepartamento
                                   where a.Nit == Nit
                                   select new EntidadesDTO
                                   {
                                       EntidadId = a.Id,
                                       CodigoDepartamento = d.ZON_ID,
                                       CodigoMunicipio = z.ZON_ID,
                                       CorreoElectronico = a.CorreoElectronico,
                                       Direccion = a.Direccion,
                                       FechaActualizacion = a.FechaActualizacion,
                                       FechaCreacion = a.FechaCreacion,
                                       Latitud = z.ZON_LATITUD.ToString(),
                                       Longitud = z.ZON_LONGITUD.ToString(),
                                       Nombre = a.Nombre,
                                       Nit = a.Nit,
                                       DigitoVerificacion = ((a.DigitoVerificacion == null) ? 0 : (int)a.DigitoVerificacion),
                                       LinkPortafolio = a.LinkPortafolio,
                                       Telefono = a.Telefono,
                                       Descripcion = a.Descripcion,
                                       TipoEntidad = ""

                                   }).FirstOrDefault();


                    }
                }
                return entidad;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
