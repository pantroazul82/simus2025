using SM.Aplicacion.Documentos;
using SM.Datos.Basicas;
using SM.Datos.DTO;
using SM.Datos.Entidades;
using SM.Datos.Servicios;
using SM.LibreriaComun.DTO;
using SM.LibreriaComun.DTO.Circulacion;
using SM.SIPA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Aplicacion.Entidades
{
    public class EsnecariosNeg
    {
        #region actualizacion

        public static int Crear(EscenarioDTO model, int UsuarioId)
        {
            int registroId = 0;
            try
            {

                string[] hora = model.HoraApertura.Split(' ');
                string dateString = "01/01/2018" + " " + hora[0] + ":01 " + hora[1];
                DateTime dt = Convert.ToDateTime(dateString);

                string[] horacierre = model.HoraCierre.Split(' ');
                string dateStringCierre = "01/01/2018" + " " + horacierre[0] + ":01 " + horacierre[1];
                DateTime dtCierre = Convert.ToDateTime(dateStringCierre);

                TimeSpan timeInicio = dt.TimeOfDay;
                TimeSpan timeCierre = dtCierre.TimeOfDay;


                var registro = new ART_MUSICA_ESCENARIOS
                {
                    Aforo = Convert.ToInt32(model.aforo),
                    ClasificacionId = Convert.ToInt32(model.ClasificacionId),
                    CodDepto = model.CodDepartamento,
                    CodMunicipio = model.codMunicipio,
                    Contacto = model.Contacto,
                    CorreoElectronico = model.CorreoElectronico,
                    Descripcion = model.Descripcion,
                    Direccion = model.direccion,
                    EsActivo = model.EsActivo,
                    EstadoId = 1,
                    Nombre = model.Nombre,
                    Telefono = model.Telefono,
                    PaginaWeb = model.PaginaWeb,
                    FechaCreacion = DateTime.Now,
                    FechaActualizacion = DateTime.Now,
                    TipoActor = Convert.ToInt32(model.Tipo),
                    UsuarioId = UsuarioId,
                    HoraInicio = timeInicio,
                    HoraFinal = timeCierre
                };

                if (Convert.ToInt32(model.Tipo) == 6)
                {
                    registro.AgenteId = Convert.ToInt32(model.ActorId);
                    registro.RelacionadoA = "Agentes";
                    registro.NombreActor = ConvocatoriaServicio.ObtenerNombreAgente(Convert.ToInt32(model.ActorId));
                }
                else if (Convert.ToInt32(model.Tipo) == 7)
                {
                    registro.EntidadId = Convert.ToInt32(model.ActorId);
                    registro.RelacionadoA = "Entidades";
                    registro.NombreActor = ConvocatoriaServicio.ObtenerNombreEntidad(Convert.ToInt32(model.ActorId));
                }
                else if (Convert.ToInt32(model.Tipo) == 8)
                {
                    registro.AgrupacionId = Convert.ToInt32(model.ActorId);
                    registro.RelacionadoA = "Agrupaciones";
                    registro.NombreActor = ConvocatoriaServicio.ObtenerNombreAgrupacion(Convert.ToInt32(model.ActorId));
                }
                else if (Convert.ToInt32(model.Tipo) == 9)
                {
                    registro.EscuelaId = Convert.ToInt32(model.ActorId);
                    registro.RelacionadoA = "Escuelas";
                    registro.NombreActor = ConvocatoriaServicio.ObtenerNombreEscuela(Convert.ToInt32(model.ActorId));
                }
                registro.Departamento = ServicioBasicas.obtenerNombreDepartamento(model.CodDepartamento);
                registro.Municipio = ServicioBasicas.obtenerNombreMunicipio(model.codMunicipio);

                registroId = EscenariosServicios.Agregar(registro, model.DirigidoAPublicado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return registroId;
        }

        public static void CrearImagen(int registroId, byte[] imagen, bool Esprincipal)
        {

            try
            {

                var registro = new ART_MUSICA_IMAGENES
                {
                    EscenarioId = registroId,
                    Imagen = imagen,
                    Principal = Esprincipal
                };


                registroId = EscenariosServicios.AgregarImagenes(registro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
          
        }

        public static void CrearImagenEventos(int registroId, byte[] imagen, bool Esprincipal)
        {

            try
            {

                var registro = new ART_MUSICA_IMAGENES
                {
                    EventoPeriodicoId = registroId,
                    Imagen = imagen,
                    Principal = Esprincipal
                };


                registroId = EscenariosServicios.AgregarImagenes(registro);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static void ActualizarDocumento(int EscenarioId, int DocumentoId)
        {
            try
            {
                EscenariosServicios.ActualizarDocumento(EscenarioId, DocumentoId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void Actualizar(int Id, EscenarioDTO model, int UsuarioId)
        {
            try
            {

                EscenariosServicios.Actualizar(Id, model, UsuarioId, model.DirigidoAPublicado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
          
        }

        public static void EliminarImagen(int ImagenId)
        {
            try
            {

                EscenariosServicios.EliminarImagen(ImagenId);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

        #region Consulta

        public static List<ImagenDataDTO> ConsultarImagenes(int EscenarioId)
        {
            try
            {

                var listResultado = new List<ImagenDataDTO>();
                listResultado = EscenariosServicios.ConsultarImagenes(EscenarioId);
                return listResultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ImagenDataDTO> ConsultarImagenesEventosperiodicos(int EventoId)
        {
            try
            {

                var listResultado = new List<ImagenDataDTO>();
                listResultado = EscenariosServicios.ConsultarImagenesEventosperiodicos(EventoId);
                return listResultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static EscenarioDTO ConsultarPorId(int Id)
        {
            try
            {
                var datos = new EscenarioDTO();
                var model = EscenariosServicios.ConsultarPorId(Id);

                if (model != null)
                {
                    if (model.AgenteId != null)
                        datos.ActorId = model.AgenteId.ToString();
                    else if (model.EntidadId != null)
                        datos.ActorId = model.EntidadId.ToString();
                    else if (model.AgrupacionId != null)
                        datos.ActorId = model.AgrupacionId.ToString();
                    else if (model.EscuelaId != null)
                        datos.ActorId = model.EscuelaId.ToString();

                    datos.Descripcion = model.Descripcion;
                    datos.NombreEstado = ConvocatoriaServicio.ObtenerNombreEstadoSIMUS(model.EstadoId);
                    datos.EstadoId = model.EstadoId.ToString();
                    datos.Id = model.Id;
                    datos.Nombre = model.Nombre;
                    datos.Tipo = model.TipoActor.ToString();
                    datos.aforo = model.Aforo.ToString();
                    datos.ClasificacionId = model.ClasificacionId.ToString();
                    datos.CodDepartamento = model.CodDepto;
                    datos.codMunicipio = model.CodMunicipio;
                    datos.Contacto = model.Contacto;
                    datos.CorreoElectronico = model.CorreoElectronico;
                    datos.direccion = model.Direccion;
                    datos.EsActivo = (bool) model.EsActivo;
                    datos.HoraApertura = model.HoraInicio.ToString();
                    datos.HoraCierre = model.HoraFinal.ToString();
                    datos.Telefono = model.Telefono;
                    datos.PaginaWeb = model.PaginaWeb;
                    datos.UsuarioId = model.UsuarioId;

                    if (model.DocumentoId == null)
                    {
                        datos.DocumentoId = 0;
                    }
                    else
                    {
                        datos.DocumentoId = (int)model.DocumentoId;
                        datos.documentoArchivo = ConsultaDocumento(datos.DocumentoId);
                    }

                 
                }


                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static List<DocumentoModels> ConsultaDocumento(int Id)
        {
            try
            {
                var model = new DocumentoDTO();
                var datos = new DocumentoModels();
                var listDocumentos = new List<DocumentoModels>();
                model = DocumentosNeg.ConsultaDocumentoPorId(Id);

                if (model != null)
                {
                    datos.BytesArchivo = model.BytesArchivo;
                    datos.DocumentoId = model.DocumentoId;
                    datos.ExtensionArchivo = model.ExtensionArchivo;
                    datos.FechaRegistro = model.FechaRegistro;
                    datos.NombreArchivo = model.NombreArchivo;
                    datos.NombreUsuario = model.NombreUsuario;
                    datos.TamanoArchivo = model.TamanoArchivo;
                    datos.TipoContenido = model.TipoContenido;
                    datos.Token = model.Token;
                    datos.UsuarioId = model.UsuarioId;
                    listDocumentos.Add(datos);
                }


                return listDocumentos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<EstandarDTO> ConsultarDiasSemana(int Id)
        {
            List<EstandarDTO> lisParametro = new List<EstandarDTO>();
            try
            {
                List<Parametro> Parametrodatos = EscenariosServicios.ConsultarDiasSemana(Id);

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
        public static EscenariohomeDTO ConsultarEscenarioFichaId(int Id)
        {
            try
            {
                var model = new ART_MUSICA_ESCENARIOS();
                var datos = new EscenariohomeDTO();
                model = EscenariosServicios.ConsultarEscenariosPorId(Id);
                List<ImagenesBanner> listado = new List<ImagenesBanner>();
                List<ART_MUSICA_IMAGENES> listadoimagenes = new List<ART_MUSICA_IMAGENES>();

                if (model != null)
                {
                    datos.Aforo = model.Aforo;
                    datos.AgenteId = model.AgenteId;
                    datos.AgrupacionId = model.AgrupacionId;
                    datos.Clasificacion = EscenariosServicios.ConsultarClasificacionNombre(model.ClasificacionId);
                    datos.CodDepto = model.CodDepto;
                    datos.Departamento = model.Departamento;
                    datos.Direccion = model.Direccion;
                    datos.Municipio = model.Municipio;
                    datos.Nombre = model.Nombre;
                    datos.NombreActor = model.NombreActor;
                    datos.PaginaWeb = model.PaginaWeb;
                    datos.Telefono = model.Telefono;
                    datos.Contacto = model.Contacto;
                    datos.CorreoElectronico = model.CorreoElectronico;
                    datos.HoraApertura = model.HoraInicio.ToString();
                    datos.HoraCierre = model.HoraFinal.ToString();
                    datos.documentoId = model.DocumentoId ?? 0;
                    datos.DirigidoASeleccionada = EsnecariosNeg.ConsultarDiasSemana(Id);
                    listadoimagenes = EscenariosServicios.ConsultarImagenesEscenarios(Id);

                    if (listadoimagenes != null)
                    {
                        foreach (var x in listadoimagenes)
                        {
                            ImagenesBanner item = new ImagenesBanner();
                            item.imagen = x.Imagen;
                            listado.Add(item);
                        }

                        datos.banner = listado;
                    }
                }


                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<EspacioDataDTO> ConsultarEspaciosPorUsuarioId(int UsuarioID)
        {
            try
            {

                var listResultado = new List<EspacioDataDTO>();
                listResultado = EscenariosServicios.ConsultarEspaciosPorUsuarioId(UsuarioID);
                return listResultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<EspacioDataDTO> ConsultarEspaciosPorEstadoId(int EstadoId)
        {
            try
            {

                var listResultado = new List<EspacioDataDTO>();
                listResultado = EscenariosServicios.ConsultarEspaciosPorEstadoId(EstadoId);
                return listResultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<EspacioDataDTO> ConsultarEspaciosPorMunicipio(int UsuarioID)
        {
            try
            {

                var listResultado = new List<EspacioDataDTO>();
                listResultado = EscenariosServicios.ConsultarEspaciosPorMunicipio(UsuarioID);
                return listResultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<EspacioDataDTO> ConsultarEspaciosTodos()
        {
            try
            {

                var listResultado = new List<EspacioDataDTO>();
                listResultado = EscenariosServicios.ConsultarEspaciosTodos();
                return listResultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
