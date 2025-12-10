using SM.SIPA;
using SM.WSDatos.WSDTO;
using SM.WSDatos.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.WSDatos.Escuelas
{
    public class EscuelasServicio
    {
        public static List<EscuelaDTO> ConsultarEscuelas(string usuario, string contrasena, out string mensajeError)
        {
            List<EscuelaDTO> listEscuelas = new List<EscuelaDTO>();
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

                        listEscuelas = (from a in context.ART_ENTIDADES_ARTES
                                        join u in context.ART_ENTIDAD_UBICACION on a.ENT_ID equals u.ENT_ID
                                        join i in context.ART_MUSICA_ENTIDAD_IDENTIFICACION on a.ENT_ID equals i.ENT_ID
                                        join z in context.BAS_ZONAS_GEOGRAFICAS on u.ZON_ID equals z.ZON_ID
                                        join d in context.BAS_ZONAS_GEOGRAFICAS on z.ZON_PADRE_ID equals d.ZON_ID
                                        where d.ZON_ID == codigoDepartamento
                                        where a.ENT_TIPO == "E"
                                        where (a.ENT_ESTADO == "E")
                                        select new EscuelaDTO
                                        {
                                            AnoConstitucion = (int)a.ENT_ANO_CONSTITUCION,
                                            Area = (u.ARE_ID == 5 ? "Rural" : "Urbana"),
                                            CargoContacto = a.ENT_CARGO_CONTACTO,
                                            CodigoDepartamento = d.ZON_ID,
                                            CodigoMunicipio = z.ZON_ID,
                                            CorreoElectronicoContacto = i.ENT_CONTACTO_CORREO,
                                            CorreoElectronicoEscuela = u.ENT_CORREO_ELECTRONICO_ENTIDAD,
                                            Direccion = u.ENT_DIRECCION,
                                            EscuelaId = (int)a.ENT_ID,
                                            Nit = a.ENT_NIT,
                                            NombreContacto = a.ENT_NOMBRE_CONTACTO,
                                            NombreEscuela = a.ENT_NOMBRE,
                                            Resena = a.ENT_RESENA,
                                            SitioWeb = u.ENT_PAGINA_WEB,
                                            TelefonoContacto = i.ENT_TELEFONOS,
                                            Telefono = u.ENT_TELEFONO,
                                            FechaActualizacion = (DateTime) a.ENT_FECHA_ACTUALIZACION
                                        }).ToList();


                    }
                }
                return listEscuelas;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<EscuelaDTO> ConsultarEscuelasPorRangoFechas(string usuario, string contrasena,  DateTime FechaInicio, DateTime FechaFinal, out string mensajeError)
        {
            List<EscuelaDTO> listEscuelas = new List<EscuelaDTO>();
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

                            listEscuelas = (from a in context.ART_ENTIDADES_ARTES
                                            join u in context.ART_ENTIDAD_UBICACION on a.ENT_ID equals u.ENT_ID
                                            join i in context.ART_MUSICA_ENTIDAD_IDENTIFICACION on a.ENT_ID equals i.ENT_ID
                                            join z in context.BAS_ZONAS_GEOGRAFICAS on u.ZON_ID equals z.ZON_ID
                                            join d in context.BAS_ZONAS_GEOGRAFICAS on z.ZON_PADRE_ID equals d.ZON_ID
                                            where d.ZON_ID == codigoDepartamento
                                            where a.ENT_TIPO == "E"
                                            where (a.ENT_ESTADO == "E")
                                            where a.ENT_FECHA_ACTUALIZACION >= FechaInicio 
                                            where a.ENT_FECHA_ACTUALIZACION <= FechaFinal
                                            select new EscuelaDTO
                                            {
                                                AnoConstitucion = (int)a.ENT_ANO_CONSTITUCION,
                                                Area = (u.ARE_ID == 5 ? "Rural" : "Urbana"),
                                                CargoContacto = a.ENT_CARGO_CONTACTO,
                                                CodigoDepartamento = d.ZON_ID,
                                                CodigoMunicipio = z.ZON_ID,
                                                CorreoElectronicoContacto = i.ENT_CONTACTO_CORREO,
                                                CorreoElectronicoEscuela = u.ENT_CORREO_ELECTRONICO_ENTIDAD,
                                                Direccion = u.ENT_DIRECCION,
                                                EscuelaId = (int)a.ENT_ID,
                                                Nit = a.ENT_NIT,
                                                NombreContacto = a.ENT_NOMBRE_CONTACTO,
                                                NombreEscuela = a.ENT_NOMBRE,
                                                Resena = a.ENT_RESENA,
                                                SitioWeb = u.ENT_PAGINA_WEB,
                                                TelefonoContacto = i.ENT_TELEFONOS,
                                                Telefono = u.ENT_TELEFONO,
                                                FechaActualizacion = (DateTime)a.ENT_FECHA_ACTUALIZACION
                                            }).ToList();

                        }
                    }
                }
                return listEscuelas;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static EscuelaDTO ConsultarEscuelasPorId(string usuario, string contrasena, int EscuelaId, out string mensajeError)
        {
            EscuelaDTO Escuelas = new EscuelaDTO();
            string codigoDepartamento = "";
            decimal decEscuelaId = EscuelaId;
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

                        Escuelas = (from a in context.ART_ENTIDADES_ARTES
                                    join u in context.ART_ENTIDAD_UBICACION on a.ENT_ID equals u.ENT_ID
                                    join i in context.ART_MUSICA_ENTIDAD_IDENTIFICACION on a.ENT_ID equals i.ENT_ID
                                    join z in context.BAS_ZONAS_GEOGRAFICAS on u.ZON_ID equals z.ZON_ID
                                    join d in context.BAS_ZONAS_GEOGRAFICAS on z.ZON_PADRE_ID equals d.ZON_ID
                                    where d.ZON_ID == codigoDepartamento
                                    where a.ENT_TIPO == "E"
                                    where (a.ENT_ESTADO == "E")
                                    where a.ENT_ID == decEscuelaId
                                    select new EscuelaDTO
                                    {
                                        AnoConstitucion = (int)a.ENT_ANO_CONSTITUCION,
                                        Area = (u.ARE_ID == 5 ? "Rural" : "Urbana"),
                                        CargoContacto = a.ENT_CARGO_CONTACTO,
                                        CodigoDepartamento = d.ZON_ID,
                                        CodigoMunicipio = z.ZON_ID,
                                        CorreoElectronicoContacto = i.ENT_CONTACTO_CORREO,
                                        CorreoElectronicoEscuela = u.ENT_CORREO_ELECTRONICO_ENTIDAD,
                                        Direccion = u.ENT_DIRECCION,
                                        EscuelaId = (int)a.ENT_ID,
                                        Nit = a.ENT_NIT,
                                        NombreContacto = a.ENT_NOMBRE_CONTACTO,
                                        NombreEscuela = a.ENT_NOMBRE,
                                        Resena = a.ENT_RESENA,
                                        SitioWeb = u.ENT_PAGINA_WEB,
                                        TelefonoContacto = i.ENT_TELEFONOS,
                                        Telefono = u.ENT_TELEFONO,
                                        FechaActualizacion = (DateTime)a.ENT_FECHA_ACTUALIZACION
                                    }).FirstOrDefault();


                    }
                }
                return Escuelas;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static EscuelaDTO ConsultarEscuelasPorNit(string usuario, string contrasena, int Nit, out string mensajeError)
        {
            EscuelaDTO Escuelas = new EscuelaDTO();
            string codigoDepartamento = "";
            string strNit = Nit.ToString();
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

                        Escuelas = (from a in context.ART_ENTIDADES_ARTES
                                    join u in context.ART_ENTIDAD_UBICACION on a.ENT_ID equals u.ENT_ID
                                    join i in context.ART_MUSICA_ENTIDAD_IDENTIFICACION on a.ENT_ID equals i.ENT_ID
                                    join z in context.BAS_ZONAS_GEOGRAFICAS on u.ZON_ID equals z.ZON_ID
                                    join d in context.BAS_ZONAS_GEOGRAFICAS on z.ZON_PADRE_ID equals d.ZON_ID
                                    where d.ZON_ID == codigoDepartamento
                                    where a.ENT_TIPO == "E"
                                    where (a.ENT_ESTADO == "E")
                                    where a.ENT_NIT == strNit
                                    select new EscuelaDTO
                                    {
                                        AnoConstitucion = (int)a.ENT_ANO_CONSTITUCION,
                                        Area = (u.ARE_ID == 5 ? "Rural" : "Urbana"),
                                        CargoContacto = a.ENT_CARGO_CONTACTO,
                                        CodigoDepartamento = d.ZON_ID,
                                        CodigoMunicipio = z.ZON_ID,
                                        CorreoElectronicoContacto = i.ENT_CONTACTO_CORREO,
                                        CorreoElectronicoEscuela = u.ENT_CORREO_ELECTRONICO_ENTIDAD,
                                        Direccion = u.ENT_DIRECCION,
                                        EscuelaId = (int)a.ENT_ID,
                                        Nit = a.ENT_NIT,
                                        NombreContacto = a.ENT_NOMBRE_CONTACTO,
                                        NombreEscuela = a.ENT_NOMBRE,
                                        Resena = a.ENT_RESENA,
                                        SitioWeb = u.ENT_PAGINA_WEB,
                                        TelefonoContacto = i.ENT_TELEFONOS,
                                        Telefono = u.ENT_TELEFONO,
                                        FechaActualizacion = (DateTime)a.ENT_FECHA_ACTUALIZACION
                                    }).FirstOrDefault();


                    }
                }
                return Escuelas;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
