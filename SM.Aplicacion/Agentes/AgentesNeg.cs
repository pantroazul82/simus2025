using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SM.Datos.Agentes;
using SM.Datos.DTO;
using SM.SIPA;
using SM.LibreriaComun.DTO;
using System.Net.Http;
using System.Net.Http.Headers;
using ExtensionMethods;
using Newtonsoft.Json;
using System.Runtime.Serialization;


namespace SM.Aplicacion.Agentes
{
   
    public class AgentesNeg
    {
        #region Consultas
        public static List<EstandarDTO> ConsultarServicioPorInteresId(int AgenteId)
        {
            var lisParametro = new List<EstandarDTO>();
            try
            {
                List<Parametro> Parametrodatos = AgenteServicio.ConsultarServicioPorInteresId(AgenteId);

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

        public static List<EstandarDTO> ConsultarAgentesAsociadosPorAgrupacionId(int AgrupacionId)
        {
            var lisParametro = new List<EstandarDTO>();
            try
            {
                List<Parametro> Parametrodatos = AgenteServicio.ConsultarAgentesAsociadosPorAgrupacionId(AgrupacionId);

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
        public static List<EstandarDTO> ConsultarServicioPorAgenteId(int AgenteId)
        {
            var lisParametro = new List<EstandarDTO>();
            try
            {
                List<Parametro> Parametrodatos = AgenteServicio.ConsultarServicioPorAgenteId(AgenteId);

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
        public static List<OcupacionDTO> ConsultarOcupacionPorAgenteId(int AgenteId)
        {
            var lisParametro = new List<OcupacionDTO>();
            try
            {
                List<OcupacionResultadoDTO> Parametrodatos = AgenteServicio.ConsultarOcupacionPorAgenteId(AgenteId);

                foreach (var item in Parametrodatos)
                {
                    OcupacionDTO objParametro = new OcupacionDTO();
                    objParametro.Id = item.Id;
                    objParametro.AgenteId = item.AgenteId;
                    objParametro.Atributo = item.Atributo;
                    objParametro.EsGeneroMusical = item.EsGenero;
                    objParametro.EsInstrumento = item.EsInstrumento;
                    objParametro.OficioId = item.OficioId;
                   lisParametro.Add(objParametro);
                }

                lisParametro = lisParametro.OrderBy(d => d.Atributo).ToList();

                return lisParametro;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static AgenteDTO ConsultarUsuarioPorId(int UsuarioId)
        {
            try
            {
                var model = new ART_MUSICA_USUARIO();
                var datos = new AgenteDTO();
                model = AgenteServicio.ConsultarUsuarioPorId(UsuarioId);

                if (model != null)
                {
                    datos.ArtMusicaUsuarioId = model.Id;
                    datos.CodigoDepartamento = model.CodDpto;
                    datos.CodigoMunicipio = model.CodMunicipio;
                    datos.CodigoPais = model.CodPais;
                    datos.CorreoElectronico = model.Email;
                    datos.Direccion = "";
                    datos.FechaNacimiento = model.FechaNacimiento ?? Convert.ToDateTime("1900-01-01");
                    datos.imagen = model.ImagenUsuario;
                    datos.linkPortafolio = "";
                    datos.NumeroDocumento = model.Identificacion;
                    datos.PrimerApellido = model.PrimerApellido;
                    datos.PrimerNombre = model.PrimerNombre;
                    datos.SegundoApellido = model.SegundoApellido;
                    datos.SegundoNombre = model.SegundoNombre;
                    if (model.Sexo.Trim() == "Femenino")
                        datos.Sexo = "F";
                    else if (model.Sexo.Trim() == "Masculino")
                        datos.Sexo = "M";
                    datos.Telefono = "";
                    datos.TipoDocumento = model.CodTipoDocumento;

                }

               
                return datos;
            }
            catch (Exception ex)
            { 
                throw ex;
            }
        }

       

        public static int ObtenerAgenteId(int UsuarioId)
        {

            int AgenteId = 0;
            try
            {

                AgenteId = AgenteServicio.ObtenerAgenteId(UsuarioId);



            }
            catch (Exception ex)
            {
                throw ex;
            }
            return AgenteId;
        }

        public static int ObtenerAgenteId(string tipodocumentoId, string Numerodocumento)
        {

            int AgenteId = 0;
            try
            {

                AgenteId = AgenteServicio.ObtenerAgenteId(tipodocumentoId, Numerodocumento);



            }
            catch (Exception ex)
            {
                throw ex;
            }
            return AgenteId;
        }
        public static AgenteDTO ConsultarAgenteporId(int AgenteId)
        {
            try
            {
                var model = new ART_MUSICA_AGENTE();
                var datos = new AgenteDTO();
                model = AgenteServicio.ConsultarAgenteporId(AgenteId);

                if (model != null)
                {
                    datos.AgenteId = model.ID;
                    datos.ArtMusicaUsuarioId = model.IdADM_ART_USUARIO;
                    datos.CodigoDepartamento = model.CodigoDepartamento;
                    datos.CodigoMunicipio = model.CodMunicipio;
                    datos.CodigoPais = model.CodPais;
                    datos.CorreoElectronico = model.CorreoElectronico;
                    datos.Direccion = model.Direccion;
                    datos.FechaNacimiento = model.FechaNacimiento ?? Convert.ToDateTime("1900-01-01");
                    datos.imagen = model.Imagen;
                    datos.linkPortafolio = model.LinkPortafolio;
                    datos.NumeroDocumento = model.Identificacion;
                    datos.PrimerApellido = model.PrimerApellido;
                    datos.PrimerNombre = model.PrimerNombre;
                    datos.SegundoApellido = model.SedundoApellido;
                    datos.SegundoNombre = model.SegundoNombre;
                    datos.Sexo = model.Sexo;
                    datos.Telefono = model.Telefono;
                    datos.TipoDocumento = model.CodTipoDocumento.ToString();
                    datos.EstadoId = model.EstadoId;
                    datos.Descripcion = model.Descripcion;
                    datos.NombreArtistico = model.NombreArtistico;
                    datos.CodigoArea = model.ARE_ID.ToString()  ??  "";
                }


                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static AgenteDatosDTO ConsultarDatosAgentePorId(int AgenteId)
        {
            try
            {
                var model = new ART_MUSICA_AGENTE_datos_Id_Result();
                var datos = new AgenteDatosDTO();
                model = AgenteServicio.ConsultarDatosAgentePorId(AgenteId);

                if (model != null)
                {
                    datos.AgenteId = model.AgenteId;
                    datos.CodigoDepartamento = model.CodigoDepartamento;
                    datos.CodigoMunicipio = model.CodMunicipio;
                    datos.CodigoPais = model.CodPais;
                    datos.CorreoElectronico = model.CorreoElectronico;
                    datos.Direccion = model.Direccion;
                    datos.imagen = model.Imagen;
                    datos.linkPortafolio = model.LinkPortafolio;
                    datos.NumeroDocumento = model.Identificacion;
                    datos.NombreCompletos = model.NombreCompleto;
                    datos.Nombres = model.Nombres;
                    datos.Apellidos = model.Apellidos;
                    datos.Sexo = model.Sexo;
                    datos.Departamento = model.Departamento;
                    datos.Pais = model.Pais;
                    datos.Municipio = model.Municipio;
                    datos.TipoDocumentoDescripcion = model.TipoDocumentoDescripcion;
                    datos.Telefono = model.Telefono;
                    datos.Estado = model.Estado;
                    datos.TipoDocumento = model.CodTipoDocumento.ToString();
                    datos.Descripcion = model.Descripcion;
                }


                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<AgenteListadoDTO> ConsultarAgentesTodos()
        {
            try
            {
                var model =new List<AgenteListadoDTO>();
             return  model = AgenteServicio.ConsultarAgentesNuevo();


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<AgenteListadoDTO> ConsultarAgentesPermisosTodos(int UsuarioId)
        {
            try
            {
                var model = new List<AgenteListadoDTO>();
               return model = AgenteServicio.ConsultarAgentesNuevoPorUsuarioId(UsuarioId);

               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<AgenteDatosDTO> ConsultarAgenteUsuarioId(int UserId)
        {
            try
            {
                var model = new List<ART_MUSICA_AGENTE_datos_UsuarioId_Result>();
                var listAgentes = new List<AgenteDatosDTO>();
                model = AgenteServicio.ConsultarAgenteUsuarioId(UserId);

                if (model != null)
                {
                    foreach (var item in model)
                    {
                        var datos = new AgenteDatosDTO();
                        datos.AgenteId = item.AgenteId;
                        datos.CodigoDepartamento = item.CodigoDepartamento;
                        datos.CodigoMunicipio = item.CodMunicipio;
                        datos.CodigoPais = item.CodPais;
                        datos.CorreoElectronico = item.CorreoElectronico;
                        datos.Direccion = item.Direccion;
                        datos.imagen = item.Imagen;
                        datos.linkPortafolio = item.LinkPortafolio;
                        datos.NumeroDocumento = item.Identificacion;
                        datos.NombreCompletos = item.NombreCompleto;
                        datos.Nombres = item.Nombres;
                        datos.Apellidos = item.Apellidos;
                        datos.Departamento = item.Departamento;
                        datos.Pais = item.Pais;
                        datos.Municipio = item.Municipio;
                        datos.Estado = item.Estado;
                        datos.TipoDocumento = item.CodTipoDocumento.ToString();
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


        public static List<AgenteDatosDTO> ConsultarAgentePorAgrupacionId(int AgrupacionId)
        {
            try
            {
                var model = new List<AgenteResultadoDTO>();
                var listAgentes = new List<AgenteDatosDTO>();
                model = AgenteServicio.ConsultarAgentesPorAgrupacionId(AgrupacionId);

                if (model != null)
                {
                    foreach (var item in model)
                    {
                        var datos = new AgenteDatosDTO();
                        datos.AgenteId = item.AgenteId;
                        datos.CodigoDepartamento = item.CodigoDepartamento;
                        datos.CodigoMunicipio = item.CodMunicipio;
                        datos.CodigoPais = item.CodPais;
                        datos.CorreoElectronico = item.CorreoElectronico;
                        datos.Direccion = item.Direccion;
                        datos.imagen = item.Imagen;
                        datos.linkPortafolio = item.LinkPortafolio;
                        datos.NumeroDocumento = item.Identificacion;
                        datos.NombreCompletos = item.NombreCompleto;
                        datos.TipoDocumentoDescripcion = item.TipoDocumentoDescripcion;
                        datos.Nombres = item.Nombres;
                        datos.Apellidos = item.Apellidos;
                        datos.Departamento = item.Departamento;
                        datos.Pais = item.Pais;
                        datos.Municipio = item.Municipio;
                        datos.Estado = item.Estado;
                        datos.TipoDocumento = item.CodTipoDocumento.ToString();
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

        public static List<AgenteDatosDTO> ConsultarAgentesRecientes()
        {
            try
            {
                var model = new List<AgenteResultadoDTO>();
                var listAgentes = new List<AgenteDatosDTO>();
                model = AgenteServicio.ConsultarAgentesRecientes();

                if (model != null)
                {
                    foreach (var item in model)
                    {
                        var datos = new AgenteDatosDTO();
                        datos.AgenteId = item.AgenteId;
                        datos.CodigoDepartamento = item.CodigoDepartamento;
                        datos.CodigoMunicipio = item.CodMunicipio;
                        datos.CodigoPais = item.CodPais;
                        datos.CorreoElectronico = item.CorreoElectronico;
                        datos.Direccion = item.Direccion;
                        datos.imagen = item.Imagen;
                        datos.linkPortafolio = item.LinkPortafolio;
                        datos.NumeroDocumento = item.Identificacion;
                        datos.NombreCompletos = item.NombreCompleto;
                        datos.Nombres = item.Nombres;
                        datos.Apellidos = item.Apellidos;
                        datos.Departamento = item.Departamento;
                        datos.Pais = item.Pais;
                        datos.Municipio = item.Municipio;
                        datos.Estado = item.Estado;
                        datos.TipoDocumento = item.CodTipoDocumento.ToString();
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

        public static List<AgenteDatosDTO> ConsultarAgentesRecientePorBusqueda(string Busqueda)
        {
            try
            {
                var model = new List<AgenteResultadoDTO>();
                var listAgentes = new List<AgenteDatosDTO>();
                model = AgenteServicio.ConsultarAgentesRecientePorBusqueda(Busqueda);

                if (model != null)
                {
                    foreach (var item in model)
                    {
                        var datos = new AgenteDatosDTO();
                        datos.AgenteId = item.AgenteId;
                        datos.CodigoDepartamento = item.CodigoDepartamento;
                        datos.CodigoMunicipio = item.CodMunicipio;
                        datos.CodigoPais = item.CodPais;
                        datos.CorreoElectronico = item.CorreoElectronico;
                        datos.Direccion = item.Direccion;
                        datos.imagen = item.Imagen;
                        datos.linkPortafolio = item.LinkPortafolio;
                        datos.NumeroDocumento = item.Identificacion;
                        datos.NombreCompletos = item.NombreCompleto;
                        datos.Nombres = item.Nombres;
                        datos.Apellidos = item.Apellidos;
                        datos.Departamento = item.Departamento;
                        datos.Pais = item.Pais;
                        datos.Municipio = item.Municipio;
                        datos.Estado = item.Estado;
                        datos.TipoDocumento = item.CodTipoDocumento.ToString();
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
        public static List<AgenteDatosDTO> ConsultarAgenteEstadoId(int EstadoId)
        {
            try
            {
                var model = new List<ART_MUSICA_AGENTE_datos_EstadoId_Result>();
                var listAgentes = new List<AgenteDatosDTO>();
                model = AgenteServicio.ConsultarAgenteEstadoId(EstadoId);

                if (model != null)
                {
                    foreach (var item in model)
                    {
                        var datos = new AgenteDatosDTO();
                        datos.AgenteId = item.AgenteId;
                        datos.CodigoDepartamento = item.CodigoDepartamento;
                        datos.CodigoMunicipio = item.CodMunicipio;
                        datos.CodigoPais = item.CodPais;
                        datos.CorreoElectronico = item.CorreoElectronico;
                        datos.Direccion = item.Direccion;
                        datos.imagen = item.Imagen;
                        datos.linkPortafolio = item.LinkPortafolio;
                        datos.NumeroDocumento = item.Identificacion;
                        datos.NombreCompletos = item.NombreCompleto;
                        datos.Nombres = item.Nombres;
                        datos.Apellidos = item.Apellidos;
                        datos.Departamento = item.Departamento;
                        datos.Pais = item.Pais;
                        datos.Municipio = item.Municipio;
                        datos.Estado = item.Estado;
                        datos.TipoDocumento = item.CodTipoDocumento.ToString();
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
        #endregion

        #region Actualizacion

        public static int Crear(AgenteDTO agente,  string strIP, string NombreUsuario)
        {
            int AgenteId = 0;
            try
            {


                AgenteId = AgenteServicio.Crear(agente.ArtMusicaUsuarioId,
                                                        agente.TipoDocumento,
                                                        agente.NumeroDocumento,
                                                        agente.PrimerNombre,
                                                        agente.SegundoNombre,
                                                        agente.PrimerApellido,
                                                        agente.SegundoApellido,
                                                        agente.FechaNacimiento,
                                                        agente.Direccion,
                                                        agente.CorreoElectronico,
                                                        agente.Sexo,
                                                        agente.CodigoPais,
                                                        agente.CodigoDepartamento,
                                                        agente.CodigoMunicipio,
                                                        agente.Telefono,
                                                        agente.linkPortafolio,
                                                        agente.Descripcion,
                                                        agente.NombreArtistico,
                                                        agente.CodigoArea,
                                                        agente.imagen,
                                                        strIP,
                                                        NombreUsuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return AgenteId;
        }

        public static bool existenumeroTipoDocumento(string identificacion, int codTipo)
        {
            bool respuesta = false;


            respuesta = respuesta = AgenteServicio.existenumeroTipoDocumento(identificacion, codTipo);
            return respuesta;
        }

        public static  int CrearAgente(AgenteDTO agente,  string strIP, string NombreUsuario)
        {
            int AgenteId = 0;
            try
            {


                AgenteId = AgenteServicio.CrearAgente(agente.ArtMusicaUsuarioId,
                                                        agente.TipoDocumento,
                                                        agente.NumeroDocumento,
                                                        agente.PrimerNombre,
                                                        agente.SegundoNombre,
                                                        agente.PrimerApellido,
                                                        agente.SegundoApellido,
                                                        agente.FechaNacimiento,
                                                        agente.Direccion,
                                                        agente.CorreoElectronico,
                                                        agente.Sexo,
                                                        agente.CodigoPais,
                                                        agente.CodigoDepartamento,
                                                        agente.CodigoMunicipio,
                                                        agente.Telefono,
                                                        agente.linkPortafolio,
                                                        agente.imagen,
                                                        agente.NombreArtistico,
                                                        Convert.ToInt32(agente.CodigoArea),
                                                        agente.Descripcion,
                                                        strIP,
                                                        NombreUsuario);


               
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return AgenteId;
        }



        public static async Task<int> CrearAgenteSinic(string path, AgenteDTO agente, decimal UsuarioSipaId)
        {
     
           string url = path + "Api/Agentes";
            Uri theUri = new Uri(url);
            int bandera = 0;
            try
            {

                using (var Client = new HttpClient())
                {
                    Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    Client.DefaultRequestHeaders.Host = theUri.Host;

                    AgenteModels resultado = new AgenteModels
                    {
                        AgenteId = 0,
                        AnoTarjetaProfesional = "",
                        CodigoEstado = "P",
                        CiudadNacimiento = "",
                        CodigoMinoriaEtnica = null,
                        CodigoMunicipio = agente.CodigoMunicipio,
                        CodigoPais = 52,
                        CodigoTipoAgente = String.Empty,
                        CodigoTipoDocumento = Convert.ToInt32(agente.TipoDocumento),
                        DescripcionDiscapacidad = String.Empty,
                        NumeroDocumento = agente.NumeroDocumento,
                        FechaDiligenciamiento = DateTime.Today,
                        FechaExpedicionPasaporte = null,
                        FechaNacimiento = agente.FechaNacimiento,
                        FechaVencimientoPasaporte = null,
                        FechaVigenciaFinal = null,
                        FechaVigenciaInicial = null,
                        Genero = agente.Sexo,
                        LugarExpDocumento = String.Empty,
                        LugarNacimiento = String.Empty,
                        NombresApellidos = agente.PrimerNombre + " " + agente.SegundoNombre + " " + agente.PrimerApellido + " " + agente.SegundoApellido,
                        NumeroPasaporte = string.Empty,
                        PerteneceMinoriaEtnica = false,
                        NumeroTP = String.Empty,
                        Seudononimo = agente.NombreArtistico,
                        TieneDiscapacidad = false,
                        TienePasaporte = false,
                        TieneTarjetaProfesional = false,
                        UsuarioSIpaId = UsuarioSipaId

                    };

                    string jsonString = resultado.ToJSON();
                    StringContent theContent = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/json");
                    HttpResponseMessage aResponse = await Client.PostAsync(theUri, theContent);
                    if (aResponse.IsSuccessStatusCode)
                    {
                        dynamic content = JsonConvert.DeserializeObject(aResponse.Content.ReadAsStringAsync().Result);
                        var array = content.data;
                        bandera = 1;
                    }
                    else
                    {
                        // show the response status code 
                        String failureMsg = "HTTP Status: " + aResponse.StatusCode.ToString() + " – Reason: " + aResponse.ReasonPhrase;
                        bandera = 2;

                    }

                    aResponse.Dispose();
                    aResponse = null;
                    Client.Dispose();
                }

                return bandera;
            }
            catch(Exception ex)
            {
                string Mensajte = ex.Message;
                 throw ex;
            }

        }

        public static void ActualizarAgente(AgenteDTO agente, bool cambiar, string strIP, string NombreUsuario)
        {
           
            try
            {
                if (cambiar)
                {
                    AgenteServicio.ActualizarAgenteEstado(agente.AgenteId,
                                              agente.EstadoId,
                                              agente.TipoDocumento,
                                              agente.NumeroDocumento,
                                              agente.PrimerNombre,
                                              agente.SegundoNombre,
                                              agente.PrimerApellido,
                                              agente.SegundoApellido,
                                              agente.FechaNacimiento,
                                              agente.Direccion,
                                              agente.CorreoElectronico,
                                              agente.Sexo,
                                              agente.CodigoPais,
                                              agente.CodigoDepartamento,
                                              agente.CodigoMunicipio,
                                              agente.Telefono,
                                              agente.linkPortafolio,
                                              agente.Descripcion,
                                              agente.CodigoArea,
                                              agente.NombreArtistico,
                                              agente.imagen,
                                              strIP,
                                              NombreUsuario,
                                              agente.ArtMusicaUsuarioId);
                }
                else
                {

                    AgenteServicio.ActualizarAgente(agente.AgenteId,
                                                    agente.ArtMusicaUsuarioId,
                                                    agente.TipoDocumento,
                                                    agente.NumeroDocumento,
                                                    agente.PrimerNombre,
                                                    agente.SegundoNombre,
                                                    agente.PrimerApellido,
                                                    agente.SegundoApellido,
                                                    agente.FechaNacimiento,
                                                    agente.Direccion,
                                                    agente.CorreoElectronico,
                                                    agente.Sexo,
                                                    agente.CodigoPais,
                                                    agente.CodigoDepartamento,
                                                    agente.CodigoMunicipio,
                                                    agente.Telefono,
                                                    agente.linkPortafolio,
                                                    agente.Descripcion,
                                                    agente.CodigoArea,
                                                    agente.NombreArtistico,
                                                    agente.imagen,
                                                    strIP,
                                                    NombreUsuario);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

           
        }

        public static void EliminarAgenteOcupacion(int AgenteOcupacionId)
        {
            try
            { AgenteServicio.EliminarAgenteOcupacion(AgenteOcupacionId); }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void EliminarAgenteServicio(int AgenteServicioId)
        {
            try
            { AgenteServicio.EliminarAgenteServicio(AgenteServicioId); }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void EliminarAgenteAgrupacion(int AgenteServicioId)
        {
            try
            { AgenteServicio.EliminarAgenteAgrupacion(AgenteServicioId); }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void EliminarAgenteInteres(int AgenteInteresId)
        {
            try
            { AgenteServicio.EliminarAgenteInteres(AgenteInteresId); }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void EliminarAgente(int AgenteId)
        {
            try
            {
                AgenteServicio.EliminarAgente(AgenteId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void AgregarOcupacion(int AgenteId,
                                            string strAtributo)
                                            
        {
            int OficioId = 0;
            try
            {
               OficioId = SM.Datos.Basicas.CaracterizacionMusicalServicio.ObtenerOficioId(strAtributo);
               bool validate =  AgenteServicio.ValidarOcupacion(AgenteId, strAtributo);
               if (!validate)
               {
                   var registro = new ART_MUSICA_AGENTEXOCUPACION();
                   registro.AgenteId = AgenteId;
                   registro.Atributo = strAtributo;
                   registro.OficioId = OficioId;
                   registro.Estado = true;
                   AgenteServicio.AgregarOcupacion(registro);
               }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void AgregarInstrumentos(int AgenteId,
                                               int OficioId,
                                              string strAtributo)
        {
            int InstrumentoId = 0;
            try
            {
                InstrumentoId = SM.Datos.Basicas.CaracterizacionMusicalServicio.ObtenerInstrumentoId(strAtributo);
                bool validate = AgenteServicio.ValidarInstrumentos(AgenteId, OficioId, strAtributo);
                if (!validate)
                {
                    var registro = new ART_MUSICA_AGENTES_INSTRUMENTOS();
                    registro.AgenteId = AgenteId;
                    registro.Instrumento = strAtributo;
                    registro.OficioId = OficioId;
                    registro.InstrumentoId = InstrumentoId;
                    registro.Estado = true;
                    AgenteServicio.AgregarInstrumento(registro);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void AgregarServicio(int AgenteId,
                                         string strAtributo)
        {
            int ServicioId = 0;
            try
            {
                ServicioId = SM.Datos.Basicas.CaracterizacionMusicalServicio.ObtenerServicioId(strAtributo);
                var registro = new ART_MUSICA_AGENTE_SERVICIO();
                registro.AgenteId = AgenteId;
                registro.Atributo = strAtributo;
                registro.ServicioId = ServicioId;
                registro.Estado = true;
                AgenteServicio.AgregarServicio(registro);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void AgregarAgente(int AgrupacionId,
                                      string strAtributo)
        {
            int AgenteId = 0;
            try
            {
                AgenteId = SM.Datos.Basicas.CaracterizacionMusicalServicio.ObtenerAgenteId(strAtributo);
                if (AgenteId != 0)
                {
                    var registro = new ART_MUSICA_AGENTE_AGRUPACION();
                    registro.AgenteId = AgenteId;
                    registro.AgrupacionId = AgrupacionId;
                    AgenteServicio.AgregarAgrupacionAgente(registro);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void AgregarInteres(int AgenteId,
                                        string strAtributo)
        {
            int InteresId = 0;
            try
            {
                InteresId = SM.Datos.Basicas.CaracterizacionMusicalServicio.ObtenerInteresId(strAtributo);
                var registro = new ART_MUSICA_AGENTE_INTERESES();
                registro.AgenteId = AgenteId;
                registro.Atributo = strAtributo;
                registro.InteresesId = InteresId;
                registro.Estado = "1";
                AgenteServicio.AgregarInteres(registro);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
