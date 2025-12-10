using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SM.Datos.Escuelas;
using SM.SIPA;
using SM.LibreriaComun.DTO;
using SM.Datos.DTO;
using SM.Datos.Basicas;

namespace SM.Aplicacion.Escuelas
{
    public class EscuelasLogica
    {

        #region Actualizacion


        public static void AgregarPracticaMusical(decimal EscuelaId,
                                                Int16 PracticaId)
        {

            try
            {
                if (!ServicioEscuela.ExisteEscuelaPractica(EscuelaId, PracticaId))
                {
                    var registro = new ART_MUSICA_FORMACION_PRACTICA
                    {
                        EscuelaId = EscuelaId,
                        PracticaMusicalId = PracticaId
                    };


                    ServicioEscuela.AgregarPractica(registro);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void EliminarPracticaGenero(int PracticaGeneroId)
        {
            try
            { ServicioEscuela.EliminarPracticaGenero(PracticaGeneroId); }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static List<EstandarDTO> ConsultarGenerosPorPracticaID(int FormacionPracticaId)
        {
            var lisParametro = new List<EstandarDTO>();
            try
            {
                List<Parametro> Parametrodatos = ServicioEscuela.ConsultarGenerosPorPracticaID(FormacionPracticaId);

                foreach (var item in Parametrodatos)
                {
                    EstandarDTO objParametro = new EstandarDTO();
                    objParametro.Id = item.Id.ToString();
                    objParametro.Nombre = item.Nombre;
                    objParametro.FormacionId = FormacionPracticaId.ToString();
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

        public static List<EstandarDTO> ConsultarPracticaPorEscuela(int EscuelaId)
        {
            var lisParametro = new List<EstandarDTO>();
            try
            {
                List<Parametro> Parametrodatos = ServicioEscuela.ConsultarPracticaPorEscuela(EscuelaId);

                foreach (var item in Parametrodatos)
                {
                    EstandarDTO objParametro = new EstandarDTO();
                    objParametro.Id = item.Id.ToString();
                    objParametro.Nombre = item.Nombre;
                    objParametro.EscuelaId = item.PadreId.ToString();
                    objParametro.clase = "Nivel" + item.Id.ToString();
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

        public static List<PracticaHomeModelDTO> ConsultarPracticaPorEscuelaHome(int EscuelaId)
        {
            var lisParametro = new List<PracticaHomeModelDTO>();
            try
            {
                List<Parametro> Parametrodatos = ServicioEscuela.ConsultarPracticaPorEscuela(EscuelaId);

                foreach (var item in Parametrodatos)
                {
                    PracticaHomeModelDTO objParametro = new PracticaHomeModelDTO();
                    objParametro.Id = item.Id.ToString();
                    objParametro.Nombre = item.Nombre;
                    objParametro.EscuelaId = item.PadreId.ToString();
                    objParametro.clase = "Nivel" + item.Id.ToString();
                    var listado = new List<EstandarDTO>();

                    listado = EscuelasLogica.ConsultarGenerosPorPracticaID(Convert.ToInt32(item.Id));
                    objParametro.listadoGeneros = listado;

                    //Educación por niveles

                    var listadoNiveles = new List<NivelesFormacionDTO>();
                    listadoNiveles = FormacionLogica.ConsultarNiveles(Convert.ToInt32(item.Id));
                    objParametro.listadoNiveles = listadoNiveles;

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
        public static void AgregarGenero(int formacionPracticaId,
                                 string strAtributo)
        {
            int GeneroId = 0;
            try
            {
                GeneroId = SM.Datos.Basicas.CaracterizacionMusicalServicio.ObtenerGeneroId(strAtributo);

                var registro = new ART_MUSICA_PRACTICA_GENERO
                {
                    FormacionPracticaId = formacionPracticaId,
                    GeneroId = GeneroId,
                    atributo = strAtributo 
                };


                ServicioEscuela.AgregarGeneros(registro);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static decimal CrearEscuela(string nombre,
                                            string NIT,
                                            int anoConstitucion,
                                            string nombrecontacto,
                                            string cargoContacto,
                                            string resena,
                                            string telefono,
                                            string correoContacto,
                                            decimal UsuarioId,
                                            string CodigoMunicipio,
                                            int areaId,
                                            string direccion,
                                            string telefonoEscuela,
                                            string faxEscuela,
                                            string CorreoElectronicoEscuela,
                                            string paginaWeb,
                                            string Naturaleza,
                                            string TipoEscuela,
                                            byte[] imagen,
                                            string Latitud,
                                            string Longitud,
                                             int SimusUsuarioId,
                                            string NombreUsuario,
                                            string strIP)
        {

            decimal EscuelaId = 0;
            try
            {
                EscuelaId = ServicioEscuela.CrearEscuela(nombre,
                                                         NIT,
                                                         anoConstitucion,
                                                         nombrecontacto,
                                                         cargoContacto,
                                                         resena,
                                                         telefono,
                                                         correoContacto,
                                                         UsuarioId,
                                                         CodigoMunicipio,
                                                         areaId,
                                                         direccion,
                                                         telefonoEscuela,
                                                         faxEscuela,
                                                         CorreoElectronicoEscuela,
                                                         paginaWeb,
                                                         Naturaleza,
                                                         TipoEscuela,
                                                         imagen,
                                                         Latitud,
                                                         Longitud,
                                                         SimusUsuarioId,
                                                         NombreUsuario,
                                                         strIP);



                return EscuelaId;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public static void ActualizarEScuela(decimal entId,
                                             string entNombre,
                                             string strImagen,
                                             string entPaginaWeb,
                                             string entNit,
                                             int entAnoConstitucion,
                                             string entNombreContacto,
                                             string entCargoContacto,
                                             string entResena,
                                             string entTelefonos,
                                             string entContactoCorreo,
                                             decimal UsuarioId,
                                             string CodigoMunicipio,
                                             int areaId,
                                             string direccion,
                                             string telefonoEscuela,
                                             string faxEscuela,
                                             string CorreoElectronicoEscuela,
                                             byte[] imagen,
                                             string Naturaleza,
                                            string TipoEscuela,
                                            int SimusUsuarioId,
                                            string NombreUsuario,
                                            string strIP)
        {

            try
            {
                ServicioEscuela.ActualizarEscuela(entId,
                                             entNombre,
                                             strImagen,
                                             entPaginaWeb,
                                             entNit,
                                             entAnoConstitucion,
                                             entNombreContacto,
                                             entCargoContacto,
                                             entResena,
                                             entTelefonos,
                                             entContactoCorreo,
                                             UsuarioId,
                                             CodigoMunicipio,
                                             areaId,
                                             direccion,
                                             telefonoEscuela,
                                             faxEscuela,
                                             CorreoElectronicoEscuela,
                                             imagen,
                                             Naturaleza,
                                             TipoEscuela,
                                             SimusUsuarioId,
                                             NombreUsuario,
                                             strIP);



            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public static void ActualizarEScuelaGeo(decimal entId,
                                          string entNombre,
                                          string strImagen,
                                          string entPaginaWeb,
                                          string entNit,
                                          int entAnoConstitucion,
                                          string entNombreContacto,
                                          string entCargoContacto,
                                          string entResena,
                                          string entTelefonos,
                                          string entContactoCorreo,
                                          decimal UsuarioId,
                                          string CodigoMunicipio,
                                          int areaId,
                                          string direccion,
                                          string telefonoEscuela,
                                          string faxEscuela,
                                          string CorreoElectronicoEscuela,
                                          byte[] imagen,
                                          string Naturaleza,
                                         string TipoEscuela,
                                         string Latitud,
                                         string Longitud,
                                         int EstadoId,
                                         string OperatividadId,
                                         int SimusUsuarioId,
                                         string NombreUsuario,
                                         string strIP)
        {

            try
            {


                ServicioEscuela.ActualizarEscuelaGeo(entId,
                                             entNombre,
                                             strImagen,
                                             entPaginaWeb,
                                             entNit,
                                             entAnoConstitucion,
                                             entNombreContacto,
                                             entCargoContacto,
                                             entResena,
                                             entTelefonos,
                                             entContactoCorreo,
                                             UsuarioId,
                                             CodigoMunicipio,
                                             areaId,
                                             direccion,
                                             telefonoEscuela,
                                             faxEscuela,
                                             CorreoElectronicoEscuela,
                                             imagen,
                                             Naturaleza,
                                             TipoEscuela,
                                             Latitud,
                                             Longitud,
                                             EstadoId,
                                             OperatividadId,
                                             SimusUsuarioId,
                                             NombreUsuario,
                                             strIP);



            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public static void ActualizarEscuelaEstado(decimal entId,
                                                  string strEstado,
                                                 int SimusUsuarioId,
                                                string NombreUsuario,
                                                string strIP)
        {

            try
            {
                ServicioEscuela.ActualizarEscuelaEstado(entId, strEstado, SimusUsuarioId, NombreUsuario, strIP);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static void ActualizarImagen(decimal entId,
                                            byte[] imagen,
                                            int SimusUsuarioId,
                                            string NombreUsuario,
                                            string strIP)
        {

            try
            {
                ServicioEscuela.ActualizarImagen(entId, imagen, SimusUsuarioId, NombreUsuario, strIP);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static void ActualizarFechaModificacion(decimal entId)
        {

            try
            {
                ServicioEscuela.ActualizarFechaModificacion(entId);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static void Eliminar(decimal entId,
                                    int SimusUsuarioId,
                                    string NombreUsuario,
                                    string strIP)
        {

            try
            {
                ServicioEscuela.EliminarIdentificacion(entId);
                Formacion.Eliminar(entId);
                Infraestructura.Eliminar(entId);
                Institucionalidad.Eliminar(entId);
                Institucionalidad.EliminarNaturaleza(entId);
                Participacion.Eliminar(entId);
                Produccion.Eliminar(entId);
                ServicioEscuela.Eliminar(entId, SimusUsuarioId, NombreUsuario, strIP);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static void EliminarEscuelas(decimal entId,
                                        int SimusUsuarioId,
                                    string NombreUsuario,
                                    string strIP)
        {

            try
            {

                ServicioEscuela.Eliminar(entId, SimusUsuarioId, NombreUsuario, strIP);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        #endregion

        #region Consultas

        public static List<BasicaDTO> ConsultarEscuelaMunicipios(string codigoMunicipio = null)
        {
            List<BasicaDTO> listado = new List<BasicaDTO>();
            try
            {
                if (!String.IsNullOrEmpty(codigoMunicipio))
                {
                    List<Basica> MunicipioDatos = ServicioEscuela.ConsultaEscuelaPorMunicipio(codigoMunicipio);

                    foreach (var item in MunicipioDatos)
                    {
                        BasicaDTO itemdepartamento = new BasicaDTO();
                        itemdepartamento.value = item.Value;
                        itemdepartamento.text = item.Nombre;
                        listado.Add(itemdepartamento);
                    }

                    listado = listado.OrderBy(d => d.text).ToList();
                }
                return listado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static string ObtenerNombreEscuela(decimal EntId)
        {
            string nombre;
            try
            {

                nombre = ServicioEscuela.ObtenerNombreEscuela(EntId);

                return nombre;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static EscuelaDTO ConsultarDatosBasicosPorId(decimal EscuelaId)
        {
            try
            {
                var model = new ART_MUSICA_ENTIDAD_IDENTIFICACION();
                var modelBasica = new EscuelasDatosBasicosDTO();
                EscuelaDTO datos = new EscuelaDTO();
                model = ServicioEscuela.ConsultarIdentificacionPorId(EscuelaId);
                modelBasica = ServicioEscuela.ConsultarEsucuelaPorId(EscuelaId);
                string Naturaleza = ServicioEscuela.ObtenerNaturaleza(EscuelaId);

                if (modelBasica != null)
                {
                    datos.Naturaleza = Naturaleza;
                    datos.CANAL_YOUTUBE = modelBasica.CANAL_YOUTUBE;
                    datos.ENT_ACTIVIDAD_PRINCIPAL = modelBasica.ENT_ACTIVIDAD_PRINCIPAL;
                    datos.ENT_ANO_CONSTITUCION = modelBasica.ENT_ANO_CONSTITUCION;
                    datos.ENT_ANO_VINCUALCION_CONTACTO = modelBasica.ENT_ANO_VINCUALCION_CONTACTO;
                    datos.ENT_AREA_ARTISTICA = modelBasica.ENT_AREA_ARTISTICA;
                    datos.ENT_CARGO_CONTACTO = modelBasica.ENT_CARGO_CONTACTO;
                    datos.ENT_CONCERTACION = modelBasica.ENT_CONCERTACION;
                    datos.ENT_CONTACTO_CORREO = modelBasica.ENT_CONTACTO_CORREO;
                    datos.ENT_CORREO_ELECTRONICO_ENTIDAD = modelBasica.ENT_CORREO_ELECTRONICO_ENTIDAD;
                    datos.ENT_DIRECCION = modelBasica.ENT_DIRECCION;
                    datos.ENT_DIRECCION_CORRESPONDENCIA = modelBasica.ENT_DIRECCION_CORRESPONDENCIA;
                    datos.ENT_ESTADO = modelBasica.ENT_ESTADO;
                    datos.ENT_FAX = modelBasica.ENT_FAX;
                    datos.ENT_FECHA_ACTUALIZACION = modelBasica.ENT_FECHA_ACTUALIZACION;
                    datos.ENT_FECHA_CAMBIO_ESTADO = modelBasica.ENT_FECHA_CAMBIO_ESTADO;
                    datos.ENT_FECHA_DILIGENCIAMIENTO = modelBasica.ENT_FECHA_DILIGENCIAMIENTO;
                    datos.ENT_FECHA_VIGENCIA_FINAL = modelBasica.ENT_FECHA_VIGENCIA_FINAL;
                    datos.ENT_FECHA_VIGENCIA_INICIAL = modelBasica.ENT_FECHA_VIGENCIA_INICIAL;
                    datos.ENT_FORMACION_PUBLICO = modelBasica.ENT_FORMACION_PUBLICO;
                    datos.ENT_ID = modelBasica.ENT_ID;
                    datos.ENT_IMAGEN = modelBasica.ENT_IMAGEN;
                    datos.ENT_NIT = modelBasica.ENT_NIT;
                    datos.ENT_NIVEL_ENTIDAD_DEPENDE_RED = modelBasica.ENT_NIVEL_ENTIDAD_DEPENDE_RED;
                    datos.ENT_NOMBRE = modelBasica.ENT_NOMBRE;
                    datos.ENT_NOMBRE_CONTACTO = modelBasica.ENT_NOMBRE_CONTACTO;
                    datos.ENT_NOMBRE_ENTIDAD_DEPENDE_RED = modelBasica.ENT_NOMBRE_ENTIDAD_DEPENDE_RED;
                    datos.ENT_NOMBRES_DIRECTOR = modelBasica.ENT_NOMBRES_DIRECTOR;
                    datos.ENT_OBSERVACION_VALIDACION = modelBasica.ENT_OBSERVACION_VALIDACION;
                    datos.ENT_PAGINA_WEB = modelBasica.ENT_PAGINA_WEB;
                    datos.ENT_RECURSO_MIXTAS = modelBasica.ENT_RECURSO_MIXTAS;
                    datos.ENT_RECURSO_PRIVADO = modelBasica.ENT_RECURSO_PRIVADO;
                    datos.ENT_RECURSO_PUBLICO = modelBasica.ENT_RECURSO_PUBLICO;
                    datos.ENT_RESENA = modelBasica.ENT_RESENA;
                    datos.ENT_TELEFONO = modelBasica.ENT_TELEFONO;
                    datos.ENT_TELEFONOS = modelBasica.ENT_TELEFONOS;
                    datos.PERFIL_FACEBOOK = modelBasica.PERFIL_FACEBOOK;
                    datos.PERFIL_TWITTER = modelBasica.PERFIL_TWITTER;
                    datos.REG_ID = modelBasica.REG_ID;
                    datos.ZON_ID = modelBasica.ZON_ID;
                    datos.ZON_NOMBRE = modelBasica.ZON_NOMBRE;
                    datos.ZON_NOMBRE_PADRE = modelBasica.ZON_NOMBRE_PADRE;
                    datos.ZON_PADRE_ID = modelBasica.ZON_PADRE_ID;
                    datos.ZOP_NOMBRE = modelBasica.ZOP_NOMBRE;
                    datos.ZON_NOMBRE = modelBasica.ZON_NOMBRE;
                    datos.ZON_NOMBRE_PADRE = modelBasica.ZON_NOMBRE_PADRE;
                    datos.Latitud = "";
                    datos.Longitud = "";
                    if (modelBasica.ENT_LATITUD != null)
                    {
                        if (modelBasica.ENT_LATITUD != 0)
                            datos.Latitud = modelBasica.ENT_LATITUD.ToString();


                    }
                    if (modelBasica.ENT_LONGITUD != null)
                    {
                        if (modelBasica.ENT_LONGITUD != 0)
                            datos.Longitud = modelBasica.ENT_LONGITUD.ToString();

                    }

                    if (datos.Latitud == "")
                    {
                        var varCoordenadas = ServicioBasicas.ObtenerCoordenadasMunicipio(modelBasica.ZON_ID);
                        if (varCoordenadas != null)
                        {
                            if (varCoordenadas.Latitud != "0")
                            {
                                datos.Latitud = varCoordenadas.Latitud;
                                datos.Longitud = varCoordenadas.Longitud;
                            }
                        }
                    }
                }

                if (model != null)
                {
                    if (model.Imagen != null)
                        datos.Imagen = model.Imagen;

                    datos.TipoEscuela = model.ENT_TIPO_ESCUELA;
                    datos.EstadoId = model.EstadoId.ToString();
                    datos.USU_ID = model.USU_ID ?? 0;
                    datos.OperatividadEscuela = model.OperatividadId.ToString();
                }
                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool ExisteEscuela(string municipio)
        {
            bool validate = false;
            try
            {
                validate = ServicioEscuela.ExisteEscuela(municipio);
                return validate;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int ConsultarAreaPorId(Decimal EntId)
        {
            int AreaId = 0;
            try
            {
                AreaId = ServicioEscuela.ConsultarAreaPorId(EntId);
                return AreaId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<EscuelaDTO> ConsultarEsucuelaParAdminPorId(decimal EscuelaId)
        {
            try
            {
                var model = new List<ART_ME_ART_ENTIDADES_ARTES_ObtenerParaAdmin_Result>();
                var result = new List<EscuelaDTO>();
                model = ServicioEscuela.ConsultarEsucuelaParAdminPorId(EscuelaId);

                foreach (var item in model)
                {
                    EscuelaDTO datos = new EscuelaDTO();
                    datos.ENT_CARGO_CONTACTO = item.ENT_CARGO_CONTACTO;
                    datos.ENT_CONTACTO_CORREO = item.ENT_CONTACTO_CORREO;
                    datos.ENT_CORREO_ELECTRONICO_ENTIDAD = item.ENT_CORREO_ELECTRONICO_ENTIDAD;
                    datos.ENT_DIRECCION = item.ENT_DIRECCION;
                    datos.ENT_DIRECCION_CORRESPONDENCIA = item.ENT_DIRECCION_CORRESPONDENCIA;
                    datos.ENT_ESTADO = item.ENT_ESTADO;
                    datos.ENT_FAX = item.ENT_FAX;
                    datos.ENT_ID = item.ENT_ID;
                    datos.ENT_IMAGEN = item.ENT_IMAGEN;
                    datos.ENT_NIT = item.ENT_NIT;
                    datos.ENT_NOMBRE = item.ENT_NOMBRE;
                    datos.ENT_NOMBRE_CONTACTO = item.ENT_NOMBRE_CONTACTO;
                    datos.ENT_PAGINA_WEB = item.ENT_PAGINA_WEB;
                    datos.ENT_RESENA = item.ENT_RESENA;
                    datos.ENT_TELEFONO = item.ENT_TELEFONO;
                    datos.ENT_TELEFONOS = item.ENT_TELEFONO;
                    datos.ZON_ID = item.ZON_ID;
                    datos.ZON_NOMBRE = item.ZON_NOMBRE;
                    datos.ZON_NOMBRE_PADRE = item.ZON_NOMBRE_PADRE;
                    datos.ZON_PADRE_ID = item.ZON_PADRE_ID;
                    result.Add(datos);
                }

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<EscuelaNuevoDatosDTO> ConsultarEscuelasTodos()
        {
            try
            {
                var model = new List<EscuelaNuevoDatosDTO>();
                return model = ServicioEscuela.ConsultarEscuelasTodos();


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<EscuelaNuevoDatosDTO> ConsultarEscuelasPorAdmUsuarios(decimal AdmUsuarioId)
        {
            try
            {
                var model = new List<EscuelaNuevoDatosDTO>();

                return model = ServicioEscuela.ConsultarEscuelasPorAdmUsuarios(AdmUsuarioId);


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<EscuelaNuevoDatosDTO> ConsultarEscuelasPorEstado(int EstadoId)
        {
            try
            {
              

                var model = new List<EscuelaNuevoDatosDTO>();

                return model = ServicioEscuela.ConsultarEscuelasPorEstado(EstadoId);

               
                   

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<EscuelaSolicitudDTO> ConsultarEscuelasPorMunicipio(string CodMunicipio, decimal UsuadioSIpaId)
        {
            try
            {
                var model = new List<EscuelaResultadoSolicitudDTO>();
                var result = new List<EscuelaSolicitudDTO>();
                model = ServicioEscuela.ConsultarEscuelasPorMunicipio(CodMunicipio);

                foreach (var item in model)
                {
                    var datos = new EscuelaSolicitudDTO();
                    datos.EscuelaId = item.EsuelaId;
                    datos.NombreEscuela = item.Nombre;
                    datos.Direccion = item.Direccion;
                    datos.Contacto = item.Contacto;
                    datos.UsuarioActualId = UsuadioSIpaId;
                    datos.UsuarioEscuelaId = item.UsuarioSipaId;
                    datos.NombreUsuario = item.NombreUsuario;
                    datos.Correo = item.Correo;
                    result.Add(datos);
                }

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<EscuelaPublicoDTO> ConsultaEscuelasDatosPublicos(string EstadoId)
        {
            try
            {
                var model = new List<EscuelaResultadoPublicoDTO>();
                var result = new List<EscuelaPublicoDTO>();
                model = ServicioEscuela.ConsultaEscuelasDatosPublicos(EstadoId);

                foreach (var item in model)
                {
                    EscuelaPublicoDTO datos = new EscuelaPublicoDTO();
                    datos.EscuelaId = item.ENT_ID;
                    datos.NombreEscuela = item.ENT_NOMBRE;
                    datos.CodigoDepartamento = item.CodigoDepartamento;
                    datos.CodigoMunicipio = item.CodigoMunicipio;
                    datos.Departamento = item.Departamento;
                    datos.Municipio = item.Municipio;
                    datos.Naturaleza = item.Naturaleza;
                    datos.Tipo = item.Tipo;
                    result.Add(datos);
                }

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<EscuelaNuevoDatosDTO> ConsultarEscuelasPorMunicipio(int UsuarioId)
        {
            try
            {
                var model = new List<EscuelaNuevoDatosDTO>();
                return model = ServicioEscuela.ConsultarEscuelasPorMunicipio(UsuarioId);


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<EscuelaDatosDTO> ConsultarEscuelasTodosParaAdmin(string departamento)
        {
            try
            {
                var model = new List<ART_ME_ART_ENTIDADES_ARTES_ObtenerTodosParaAdmin_Result>();
                var result = new List<EscuelaDatosDTO>();
                model = ServicioEscuela.ConsultarEscuelasTodosParaAdmin(departamento);

                foreach (var item in model)
                {
                    EscuelaDatosDTO datos = new EscuelaDatosDTO();
                    datos.DESCRIPCION_CATEGORIA = item.DESCRIPCION_CATEGORIA;
                    datos.ENT_CARGO_CONTACTO = item.ENT_CARGO_CONTACTO;
                    datos.ENT_CONTACTO_CORREO = item.ENT_CONTACTO_CORREO;
                    datos.ENT_CORREO_ELECTRONICO_ENTIDAD = item.ENT_CORREO_ELECTRONICO_ENTIDAD;
                    datos.ENT_DIRECCION = item.ENT_DIRECCION;
                    datos.ENT_DIRECCION_CORRESPONDENCIA = item.ENT_DIRECCION_CORRESPONDENCIA;
                    datos.ENT_ESTADO = item.ENT_ESTADO;
                    datos.ENT_FAX = item.ENT_FAX;
                    datos.ENT_ID = item.ENT_ID;
                    datos.ENT_IMAGEN = item.ENT_IMAGEN;
                    datos.ENT_NIT = item.ENT_NIT;
                    datos.ENT_NOMBRE = item.ENT_NOMBRE;
                    datos.ENT_NOMBRE_CONTACTO = item.ENT_NOMBRE_CONTACTO;
                    datos.ENT_PAGINA_WEB = item.ENT_PAGINA_WEB;
                    datos.ENT_RESENA = item.ENT_RESENA;
                    datos.ENT_TELEFONO = item.ENT_TELEFONO;
                    datos.ENT_TELEFONOS = item.ENT_TELEFONO;
                    datos.ZON_ID = item.ZON_ID;
                    datos.ZON_NOMBRE = item.ZON_NOMBRE;
                    datos.ZON_NOMBRE_PADRE = item.ZON_NOMBRE_PADRE;
                    datos.ZON_PADRE_ID = item.ZON_PADRE_ID;
                    result.Add(datos);
                }

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static List<EscuelaAuditoriaModelDTO> ConsultarAuditoriaEscuelas(int EscuelaId)
        {
            try
            {
                var model = new List<EscuelaAuditoriaDTO>();
                var result = new List<EscuelaAuditoriaModelDTO>();
                model = ServicioEscuela.ConsultarAuditoriaEscuelas(EscuelaId);

                foreach (var item in model)
                {
                    EscuelaAuditoriaModelDTO datos = new EscuelaAuditoriaModelDTO();
                    datos.Id = item.Id;
                    datos.Descripcion = item.Descripcion;
                    datos.Categoria = item.Categoria;
                    datos.Escuelas = item.Escuelas;
                    datos.FechaRegistro = item.FechaRegistro.ToLongDateString();
                    datos.NombreUsuario = item.NombreUsuario;
                    datos.Operacion = item.Operacion;
                    result.Add(datos);
                }

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion


    }
}
