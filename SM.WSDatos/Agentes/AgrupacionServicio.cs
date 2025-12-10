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
    public class AgrupacionServicio
    {

   
        public static List<AgrupacionDTO> ConsultarAgrupaciones(string usuario, string contrasena, out string mensajeError)
        {
            List<AgrupacionDTO> ListEntidades = new List<AgrupacionDTO>();
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

                        ListEntidades = (from a in context.ART_MUSICA_AGRUPACION
                                         join z in context.BAS_ZONAS_GEOGRAFICAS on a.CodigoMunicipio equals z.ZON_ID
                                         join d in context.BAS_ZONAS_GEOGRAFICAS on z.ZON_PADRE_ID equals d.ZON_ID
                                         where d.ZON_ID == codigoDepartamento
                                         select new AgrupacionDTO
                                         {
                                             AgrupacionId = a.Id,
                                             CodigoDepartamento = d.ZON_ID,
                                             CodigoMunicipio = z.ZON_ID,
                                             CorreoElectronico = a.CorreoElectronico,
                                             Direccion = a.Direccion,
                                             FechaActualizacion = a.FechaActualizacion,
                                             FechaCreacion = a.FechaCreacion,
                                             Latitud = z.ZON_LATITUD.ToString(),
                                             Longitud = z.ZON_LONGITUD.ToString(),
                                             Nombre = a.Nombre,
                                             LinkPortafolio = a.LinkPortafolio,
                                             Telefono = a.Telefono,
                                             Descripcion = a.Descripcion,
                                             NumeroDocumento = a.Identificacion,
                                             PrimerApellido = a.PrimerApellido,
                                             PrimerNombre = a.PrimerNombre,
                                             SegundoApellido = a.SedundoApellido,
                                             SegundoNombre = a.SegundoNombre,
                                             TipoDocumento = ""

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

        public static List<AgrupacionDTO> ConsultarAgrupacionesPorRangoFechas(string usuario, string contrasena, DateTime FechaInicio, DateTime FechaFinal, out string mensajeError)
        {
            List<AgrupacionDTO> ListEntidades = new List<AgrupacionDTO>();
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

                            ListEntidades = (from a in context.ART_MUSICA_AGRUPACION
                                             join z in context.BAS_ZONAS_GEOGRAFICAS on a.CodigoMunicipio equals z.ZON_ID
                                             join d in context.BAS_ZONAS_GEOGRAFICAS on z.ZON_PADRE_ID equals d.ZON_ID
                                             where d.ZON_ID == codigoDepartamento
                                             select new AgrupacionDTO
                                             {
                                                 AgrupacionId = a.Id,
                                                 CodigoDepartamento = d.ZON_ID,
                                                 CodigoMunicipio = z.ZON_ID,
                                                 CorreoElectronico = a.CorreoElectronico,
                                                 Direccion = a.Direccion,
                                                 FechaActualizacion = a.FechaActualizacion,
                                                 FechaCreacion = a.FechaCreacion,
                                                 Latitud = z.ZON_LATITUD.ToString(),
                                                 Longitud = z.ZON_LONGITUD.ToString(),
                                                 Nombre = a.Nombre,
                                                 LinkPortafolio = a.LinkPortafolio,
                                                 Telefono = a.Telefono,
                                                 Descripcion = a.Descripcion,
                                                 NumeroDocumento = a.Identificacion,
                                                 PrimerApellido = a.PrimerApellido,
                                                 PrimerNombre = a.PrimerNombre,
                                                 SegundoApellido = a.SedundoApellido,
                                                 SegundoNombre = a.SegundoNombre,
                                                 TipoDocumento = " "

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

        public static AgrupacionDTO ConsultarAgrupacionPorId(string usuario, string contrasena, int AgrupacionId, out string mensajeError)
        {
            AgrupacionDTO entidad = new AgrupacionDTO();
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

                        entidad = (from a in context.ART_MUSICA_AGRUPACION
                                   join z in context.BAS_ZONAS_GEOGRAFICAS on a.CodigoMunicipio equals z.ZON_ID
                                   join d in context.BAS_ZONAS_GEOGRAFICAS on z.ZON_PADRE_ID equals d.ZON_ID
                                   where d.ZON_ID == codigoDepartamento
                                   where a.Id == AgrupacionId
                                   select new AgrupacionDTO
                                   {
                                       AgrupacionId = a.Id,
                                       CodigoDepartamento = d.ZON_ID,
                                       CodigoMunicipio = z.ZON_ID,
                                       CorreoElectronico = a.CorreoElectronico,
                                       Direccion = a.Direccion,
                                       FechaActualizacion = a.FechaActualizacion,
                                       FechaCreacion = a.FechaCreacion,
                                       Latitud = z.ZON_LATITUD.ToString(),
                                       Longitud = z.ZON_LONGITUD.ToString(),
                                       Nombre = a.Nombre,
                                       LinkPortafolio = a.LinkPortafolio,
                                       Telefono = a.Telefono,
                                       Descripcion = a.Descripcion,
                                       NumeroDocumento = a.Identificacion,
                                       PrimerApellido = a.PrimerApellido,
                                       PrimerNombre = a.PrimerNombre,
                                       SegundoApellido = a.SedundoApellido,
                                       SegundoNombre = a.SegundoNombre,
                                       TipoDocumento = " "
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
