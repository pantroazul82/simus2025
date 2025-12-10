using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using ExtensionMethods;
using SM.SIPA;
using SM.Datos.Servicios;
using SM.Datos.Basicas;

namespace GeoServicioMasivo
{
    public class EventosSINICNeg
    {
        public string ObtenerEventos( string url)
        {
         
          
            try
            {
                url = "http://www.sinic.gov.co/eventossinic/api/SIMUS/ConsultaEventosMusica?esTotal=false";

                WebRequest req = WebRequest.Create(url);

                req.Method = "GET";

                HttpWebResponse resp = req.GetResponse() as HttpWebResponse;
                if (resp.StatusCode == HttpStatusCode.OK)
                {
                  

                    using (Stream respStream = resp.GetResponseStream())
                    {
                        StreamReader reader = new StreamReader(respStream, Encoding.UTF8);
                        var result = reader.ReadToEnd();
                        dynamic content = JsonConvert.DeserializeObject(result);
                        var array = content.datos;
                        reader.Close();
                        respStream.Close();
                        if (array != null)
                        {
                            foreach (JProperty item in array.Properties())
                            {
                                var prueba = item;

                                string value = "";
                                foreach (JArray arraylista in item)
                                {
                                    foreach (JObject singleProp in arraylista)
                                    {
                                        var datos = new UtilidadDTO();
                                        datos.CodPais = 52;
                                        datos.TipoActorId = 7;
                                        datos.TipoUtilidadId = 50;
                                        datos.TipoEventoId = 135;
                                        datos.ActorId = 1580;
                                        datos.UsuarioId = 103;
                                        datos.UsuarioAprobadorId = 103;
                                        datos.EsActivo = true;
                                        datos.OtraCiudad = "";
                                        foreach (JProperty p in singleProp.Properties())
                                        {
                                            if (p.Name == "Identificador")
                                            {
                                                value = p.Value.ToString();
                                                datos.EventoSinicId = Convert.ToDecimal(value);

                                            }

                                            if (p.Name == "Nombre")
                                            {
                                                value = p.Value.ToString();
                                                datos.Titulo = value;
                                            }
                                            if (p.Name == "Resumen")
                                            {
                                                value = p.Value.ToString();
                                                datos.Descripcion = value;
                                            }
                                            if (p.Name == "IdentificadorZona")
                                            {
                                                value = p.Value.ToString();
                                                datos.codMunicipio = value;
                                                string codepto = value.Substring(0, 2);
                                                datos.codDepto = codepto;
                                            }

                                            if (p.Name == "DireccionContacto")
                                            {
                                                value = p.Value.ToString();
                                                datos.Direccion = value;
                                            }
                                            if (p.Name == "TelefonoContacto")
                                            {
                                                value = p.Value.ToString();
                                                datos.Telefono = value;
                                            }
                                            if (p.Name == "CorreoElectronicoContacto")
                                            {
                                                value = p.Value.ToString();
                                                datos.CorreoElectronico = value;
                                            }
                                            if (p.Name == "FechaInicio")
                                            {
                                                value = p.Value.ToString();
                                                datos.FechaInicio = Convert.ToDateTime(value);
                                            }
                                            if (p.Name == "FechaFin")
                                            {
                                                value = p.Value.ToString();
                                                if ((!String.IsNullOrEmpty(value)) && (value != null))
                                                    datos.FechaFin = Convert.ToDateTime(value);
                                                else
                                                    datos.FechaFin = datos.FechaInicio;
                                            }
                                            if (p.Name == "NombreZona")
                                            {
                                                value = p.Value.ToString();
                                                datos.Municipio = value;
                                            }

                                        }
                                        if (datos.EventoSinicId > 5353)
                                            CrearUtilidad(datos, "Administrador", "");
                                    }
                                }

                            }
                        }
                        string strResultado = Convert.ToString(result);
                        string varresultado = strResultado;
                        return varresultado;
                    }
                }
                else
                {
                    Console.WriteLine(string.Format("Status Code: {0}, Status Description: {1}", resp.StatusCode, resp.StatusDescription));

                    return "Fallo";
                }
         


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


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


                
                if (datos != null)
                {
                    ///Realacionado con un agente
                   if (datos.TipoActorId == 7)
                    {
                        NombreActor = "Ministerio de Cultura";
                        entidad = new ART_MUSICA_MODULO_SERVICIOS
                        {
                            Descripcion = datos.Descripcion,
                            EstadoId = 2,
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
                            EsActivo = datos.EsActivo,
                            EventoSINICId = datos.EventoSinicId
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
                   
                }
                return UtilidadId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

    public class UtilidadDTO
    {
        public int UtilidadId { get; set; }
        public decimal EventoSinicId { get; set; }
        public int DocumentoId { get; set; }
        public int EstadoId { get; set; }
        public byte[] imagen { get; set; }
        public int ActorId { get; set; }
        public int TipoUtilidadId { get; set; }
        public int TipoEventoId { get; set; }
        public string Titulo { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Estado { get; set; }
        public string RelacionadoA { get; set; }
        public int TipoActorId { get; set; }
        public string Descripcion { get; set; }
        public int UsuarioId { get; set; }
        public int UsuarioAprobadorId { get; set; }
        public bool EsActivo { get; set; }
        // datos ubicacion
        public int CodPais { get; set; }
        public string OtraCiudad { get; set; }
        public string Direccion { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public string codDepto { get; set; }
        public string Departamento { get; set; }
        public string codMunicipio { get; set; }
        public string Municipio { get; set; }


        // datos contacto
        public string Telefono { get; set; }
        public string CorreoElectronico { get; set; }
    }
}
