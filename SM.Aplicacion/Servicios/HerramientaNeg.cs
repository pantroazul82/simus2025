using SM.Datos.Servicios;
using SM.LibreriaComun.DTO.Servicios;
using SM.SIPA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Aplicacion.Servicios
{
    public class HerramientaNeg
    {
        #region actualizar
        public static int Crear(HerramientaDetalleDTO datos, string NombreUsuario, string strIP)
        {
            var entidad = new ART_MUSICA_HERRAMIENTAS();
            int UtilidadId = 0;

            try
            {

                if (datos != null)
                {


                    entidad = new ART_MUSICA_HERRAMIENTAS
                    {
                        Nombre = datos.Nombre,
                        autores = datos.Autores,
                        FechaRegistro = DateTime.Now,
                        FechaActualizacion = DateTime.Now,
                        TipoId = datos.TipoId,
                        UrlArchivo = datos.UrlArchivo,
                        UrlVideo = datos.UrlVideo,
                        UsuarioId = datos.UsuarioId,
                        Descripcion = datos.Descripcion,
                        EstadoId = datos.EstadoId,

                    };
                }


                UtilidadId = HerramientaServicio.Agregar(entidad, NombreUsuario, datos.UsuarioId, strIP);

                return UtilidadId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void ActualizarDOcumento(int herramientaId, int DocumentoId)
        {
            try
            {
                HerramientaServicio.ActualizarDocumento(herramientaId, DocumentoId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void Actualizar(int HerramientaId,
                                string Nombre,
                                string descripcion,
                                string autores,
                                int EstadoId,
                                int TipoId,
                                string link,
                                string urlyoutube,
                                int UsuarioAprobadorId,
                                 string NombreUsuario,
                                string strIP)
        {
            try
            {

                HerramientaServicio.Actualizar(HerramientaId,
                                   Nombre,
                                   descripcion,
                                   autores,
                                   EstadoId,
                                   TipoId,
                                   link,
                                   urlyoutube,
                                   UsuarioAprobadorId,
                                    NombreUsuario,
                                   strIP);

            }
            catch (Exception ex)
            { throw ex; }
        }

        #endregion

        #region consultas
        public static List<HerramientaDataDTO> ConsultarHerramientas()
        {
            var listado = new List<HerramientaDataDTO>();
            try
            {
                var listResultado = HerramientaServicio.ConsultarHerramientas();

                foreach (var item in listResultado)
                {
                    var datos = new HerramientaDataDTO();
                    datos.Estado = item.Estado;
                    datos.Id = item.Id;
                    datos.Nombre = item.Nombre;
                    datos.TipoHerramienta = item.TipoHerramienta;
                    datos.TipoId = item.TipoId;
                    datos.FechaActualizacion = item.FechaActualizacion.ToString("dd/MM/yyyy"); 
                    listado.Add(datos);
                }

                return listado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static HerramientaDataDTO ObtenerHerramienta(int Id)
        {
            var datos = new HerramientaDataDTO();
            try
            {
                var resultado = HerramientaServicio.ObtenerHerramienta(Id);

                datos.EstadoId = resultado.EstadoId;
                datos.Id = resultado.Id;
                datos.Nombre = resultado.Nombre;
                datos.Autores = resultado.autores;
                datos.Descripcion = resultado.Descripcion;
                datos.UrlArchivo = resultado.UrlArchivo;
                datos.UrlYoutube = resultado.UrlVideo; 
                datos.TipoId = resultado.TipoId;
                datos.DocumentoId = resultado.DocumentoId ?? 0;
                    return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
