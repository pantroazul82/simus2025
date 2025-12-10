using SM.Aplicacion.Documentos;
using SM.Datos.DTO;
using SM.Datos.EntidadesOperadoras;
using SM.Datos.Servicios;
using SM.LibreriaComun.DTO;
using SM.LibreriaComun.DTO.EntidadesOperadoras;
using SM.SIPA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Aplicacion.EntidadesOpeadoras
{
    public class ConvenioNeg
    {
        #region actualizar

        public static int Crear(ConvenioDTO datos, int UsuarioId)
        {
            int registroId = 0;
        
            try
            {


                var registro = new ART_MUSICA_CONVENIOS
                {
                    Coord_AgenteId = Convert.ToInt32(datos.Coord_AgenteId),
                        EntidadId = Convert.ToInt32(datos.EntidadId),
                        EstadoId = Convert.ToInt32(datos.EstadoId),
                        FechaInicio = Convert.ToDateTime(datos.FechaInicio),
                        FechaFin = Convert.ToDateTime(datos.FechaFin),
                        Objeto = datos.Objeto,                       
                        Periodo = Convert.ToInt32(datos.Periodo),
                        Valor = Convert.ToDecimal(datos.Valor),
                        Descripcion = datos.Descripcion,
                        Nombre = datos.Nombre,
                    FechaCreacion = DateTime.Today,
                    FechaActualizacion = DateTime.Today,
                    UsuarioCreadorId = UsuarioId

                };



                registroId = ConvenioEOServicio.Crear(registro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return registroId;
        }

        public static void ActualizarDocumento(int Id, int DocumentoId)
        {
            try
            {
                ConvenioEOServicio.ActualizarDocumento(Id, DocumentoId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void Actualizar(int Id, ConvenioDTO model, int UsuarioId)
        {
            try
            {

                ConvenioEOServicio.Actualizar(Id, model, UsuarioId);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

        #region Consulta

        public static List<BasicaDTO> ObtenerEntidadesOperadoras()
        {
            var lisParametro = new List<BasicaDTO>();
            try
            {
                List<Basica> Parametrodatos = ConvenioEOServicio.ObtenerEntidadesOperadoras();

                foreach (var item in Parametrodatos)
                {
                    var objParametro = new BasicaDTO();
                    objParametro.value = item.Value;
                    objParametro.text = item.Nombre;
                    lisParametro.Add(objParametro);
                }

                lisParametro = lisParametro.OrderBy(d => d.text).ToList();

                return lisParametro;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<BasicaDTO> ObtenerRepresentanteLegal()
        {
            var lisParametro = new List<BasicaDTO>();
            try
            {
                List<Basica> Parametrodatos = ConvenioEOServicio.ObtenerRepresentanteLegal();

                foreach (var item in Parametrodatos)
                {
                    var objParametro = new BasicaDTO();
                    objParametro.value = item.Value;
                    objParametro.text = item.Nombre;
                    lisParametro.Add(objParametro);
                }

                lisParametro = lisParametro.OrderBy(d => d.text).ToList();

                return lisParametro;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<BasicaDTO> ObtenerCoordinador()
        {
            var lisParametro = new List<BasicaDTO>();
            try
            {
                List<Basica> Parametrodatos = ConvenioEOServicio.ObtenerCoordinador();

                foreach (var item in Parametrodatos)
                {
                    var objParametro = new BasicaDTO();
                    objParametro.value = item.Value;
                    objParametro.text = item.Nombre;
                    lisParametro.Add(objParametro);
                }

                lisParametro = lisParametro.OrderBy(d => d.text).ToList();

                return lisParametro;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static ConvenioDTO ConsultarPorId(int Id)
        {
            try
            {
                var entidad = new ConvenioDTO();
                var datos = ConvenioEOServicio.ConsultarPorId(Id);

                if (datos != null)
                {
                    entidad.Id = datos.Id;
                    entidad.Coord_AgenteId = datos.Coord_AgenteId.ToString();
                    entidad.EntidadId = datos.EntidadId.ToString();
                    entidad.EstadoId = datos.EstadoId.ToString();
                    entidad.FechaInicio = datos.FechaInicio.ToString("yyyy-MM-dd");
                    entidad.FechaFin = datos.FechaFin.ToString("yyyy-MM-dd");
                    entidad.Objeto = datos.Objeto;
                    entidad.Periodo = datos.Periodo.ToString();
                    entidad.Valor = Convert.ToInt64(datos.Valor).ToString();
                    entidad.Descripcion = datos.Descripcion;
                    entidad.FechaActualizacion = DateTime.Now;
                    entidad.FechaCreacion = DateTime.Now;
                    entidad.Nombre = datos.Nombre;
                    entidad.UsuarioCreadorId = datos.UsuarioCreadorId;
                    entidad.NombreEntidad = ConvocatoriaServicio.ObtenerNombreentidad(datos.EntidadId);
                
                    if (datos.DocumentoId > 0)
                    {
                        entidad.DocumentoId = datos.DocumentoId ?? 0;
                        entidad.documentoArchivo = DocumentosNeg.ConsultarDocumento(entidad.DocumentoId); 
                    }
                    else
                        entidad.DocumentoId = 0;
                  
                }


                return entidad;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ConvenioConsultaDTO> ConsultarTodos()
        {
            try
            {
                var listdoentidad = new List<ConvenioConsultaDTO>();
                var listado = ConvenioEOServicio.ConsultarTodo();

                if (listado != null)
                {
                    foreach (var datos in listado)
                    {
                        var entidad = new ConvenioConsultaDTO();
                        entidad.Id = datos.Id;
                        entidad.Coord_AgenteId = datos.Coord_AgenteId.ToString();
                        entidad.EntidadId = datos.EntidadId.ToString();
                        entidad.EstadoId = datos.EstadoId.ToString();
                        entidad.FechaInicio = datos.FechaInicio.ToString("yyyy-MM-dd");
                        entidad.FechaFin = datos.FechaFin.ToString("yyyy-MM-dd");
                        entidad.Objeto = datos.Objeto;
                        entidad.Periodo = datos.Periodo.ToString();
                        entidad.Valor = Convert.ToInt64(datos.Valor).ToString();
                        entidad.Descripcion = datos.Descripcion;
                        entidad.FechaActualizacion = datos.FechaActualizacion;
                        entidad.FechaCreacion = datos.FechaCreacion;
                        entidad.Nombre = datos.Nombre;
                        entidad.UsuarioCreadorId = datos.UsuarioCreadorId;
                        entidad.Nombreestado = ConvocatoriaServicio.ObtenerNombreEstadoSIMUS(datos.EstadoId);
                        entidad.Nombreentidad = ConvocatoriaServicio.ObtenerNombreentidad(datos.EntidadId);
                        listdoentidad.Add(entidad);
                    }
                }


                return listdoentidad;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
