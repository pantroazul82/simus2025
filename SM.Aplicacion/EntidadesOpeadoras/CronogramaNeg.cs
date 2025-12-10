using SM.Datos.Basicas;
using SM.Datos.DTO;
using SM.Datos.EntidadesOperadoras;
using SM.LibreriaComun.DTO;
using SM.LibreriaComun.DTO.EntidadesOperadoras;
using SM.SIPA;
using System;
using System.Collections.Generic;
using System.Linq;


namespace SM.Aplicacion.EntidadesOpeadoras
{
    public class CronogramaNeg
    {
        #region actualizar

        public static int Crear(CronogramaDTO datos, int UsuarioId)
        {
            int registroId = 0;

            try
            {
                var registro = new ART_MUSICA_CRONOGRAMA
                {
                    ActividadId = Convert.ToInt32(datos.ActividadId),
                    Cod_departamento = datos.Cod_departamento,
                    Cod_municipio = datos.Cod_municipio,
                    Cupo = Convert.ToInt32(datos.Cupo),
                    FechaCreacion = DateTime.Now,
                    FechaActualizacion = DateTime.Now,
                    FechaInicio = Convert.ToDateTime(datos.FechaInicio),
                    FechaFin = Convert.ToDateTime(datos.FechaFin),
                    Nombre = datos.Nombre,
                    UsuarioCreadorId = UsuarioId,
                    EscuelaId = Convert.ToDecimal(datos.Escuela)
                };

                registroId = CronogramaServicio.Crear(registro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return registroId;
        }
        public static void Actualizar(int Id, CronogramaDTO model, int UsuarioId)
        {
            try
            {

                CronogramaServicio.Actualizar(Id, model, UsuarioId);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

        #region Consulta
        public static string ObtenerNombreActividad(int Id)
        {
            string Nombre = "";

            try
            {
               return Nombre = CronogramaServicio.ObtenerNombreActividad(Id);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static ActividadDTO ObtenerActividadPorCronogramaid(int Id)
        {
            var registro = new ART_MUSICA_ACTIVIDADES();
            var datos = new ActividadDTO();

            try
            {
                registro = CronogramaServicio.ObtenerActividadPorCronogramaid(Id);

                if (registro != null)
                {

                    datos.Nombre = registro.Nombre;
                    datos.ConvenioId = registro.ConvenioId;
                    datos.NumeroConvenio = datos.NumeroConvenio;
                    datos.TipoActividadId = datos.TipoActividadId;
                   
                }

                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool ValidaCronogramaXEscuelaId(int Id)
        {
            bool boolBloquear = false;

            try
            {
                return boolBloquear = CronogramaServicio.ValidaCronogramaXEscuelaId(Id);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static CronogramaDTO ConsultarPorId(int Id)
        {
            try
            {
                var entidad = new CronogramaDTO();
                var datos = CronogramaServicio.ConsultarPorId(Id);
                if (datos != null)
                {
                    entidad.Id = datos.Id;
                    entidad.ActividadId = datos.ActividadId;
                    entidad.Cod_departamento = datos.Cod_departamento;
                    entidad.Cod_municipio = datos.Cod_municipio;
                    entidad.Cupo = datos.Cupo.ToString();
                    entidad.FechaCreacion = datos.FechaCreacion;
                    entidad.FechaActualizacion = datos.FechaActualizacion;
                    entidad.FechaInicio = datos.FechaInicio.ToString("yyyy-MM-dd");
                    entidad.FechaFin = datos.FechaFin.ToString("yyyy-MM-dd");
                    entidad.Nombre = datos.Nombre;
                    entidad.Escuela = datos.EscuelaId.ToString();
                    entidad.UsuarioCreadorId = datos.UsuarioCreadorId;
                    entidad.Departamento = ServicioBasicas.obtenerNombreDepartamento(datos.Cod_departamento);
                    entidad.Municipio = ServicioBasicas.obtenerNombreMunicipio(datos.Cod_municipio);
                    entidad.NombreEscuela = ServicioBasicas.ObtenerNombreEscuela(datos.EscuelaId);
                }

                return entidad;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static CronogramaReporteConvenioDTO ConsultarDatosConvenioPorCronogramaId(int Id)
        {
            try
            {
                var entidad = new CronogramaReporteConvenioDTO();
                var datos = CronogramaServicio.ConsultarDatosConvenioPorCronogramaId(Id);
                if (datos != null)
                {

                    entidad.ActividadId = datos.ActividadId;
                    entidad.FechaInicio = datos.FechaInicio.ToString("yyyy-MM-dd");
                    entidad.FechaFin = datos.FechaFin.ToString("yyyy-MM-dd");
                    entidad.Actividad = datos.Actividad;
                    entidad.Convenio = datos.Convenio;
                    entidad.Cronograma = datos.Cronograma;
                    entidad.CronogramaId = datos.CronogramaId;
                    entidad.Departamento = datos.Departamento;
                    entidad.Entidad = datos.Entidad;
                    entidad.EntidadId = datos.EntidadId;
                    entidad.Municipio = datos.Municipio;
                    
                }

                return entidad;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<CronogramaDTO> ConsultarPorActividadId(int Id)
        {
            try
            {
                var listdoentidad = new List<CronogramaDTO>();
                var listado = CronogramaServicio.ConsultarPorActividadId(Id);

                if (listado != null)
                {
                    foreach (var datos in listado)
                    {
                        var entidad = new CronogramaDTO();
                        entidad.Id = datos.Id;
                        entidad.ActividadId = datos.ActividadId;
                        entidad.Cod_departamento = datos.Cod_departamento;
                        entidad.Cod_municipio = datos.Cod_municipio;
                        entidad.Cupo = datos.Cupo.ToString();
                        entidad.FechaCreacion = datos.FechaCreacion;
                        entidad.FechaActualizacion = datos.FechaActualizacion;
                        entidad.FechaInicio = datos.FechaInicio.ToString("yyyy-MM-dd");
                        entidad.FechaFin = datos.FechaFin.ToString("yyyy-MM-dd");
                        entidad.Nombre = datos.Nombre;
                        entidad.UsuarioCreadorId = datos.UsuarioCreadorId;
                        entidad.Departamento = ServicioBasicas.obtenerNombreDepartamento(datos.Cod_departamento);
                        entidad.Municipio = ServicioBasicas.obtenerNombreMunicipio(datos.Cod_municipio);
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

        public static CronogramaEntidadEscuelaDTO ConsultarResponsableCronogramas(decimal EscuelaId)
        {
            try
            {
                var entidad = new CronogramaEntidadEscuelaDTO();
                var datos = CronogramaServicio.ConsultarNombreEntidad(EscuelaId);

                if (datos != null)
                {

                    entidad.EntidadId = datos.EntidadId;
                    entidad.Entidad = datos.Entidad;
                    entidad.FechaInicio = datos.FechaInicio.ToString("yyyy-MM-dd");
                    entidad.FechaFin = datos.FechaFin.ToString("yyyy-MM-dd");
                    entidad.Actividad = datos.Actividad;
                    entidad.Agente = datos.Agente;
                    entidad.Convenio = datos.Convenio;
                    entidad.Cronograma = datos.Cronograma;
                    entidad.Escuela = datos.Escuela;
                    entidad.EscuelaId = datos.EscuelaId;


                }


                return entidad;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<CronogramaListadoDTO> ConsultarResponsableCronogramas(int UsuarioId)
        {
            try
            {
                var listdoentidad = new List<CronogramaListadoDTO>();
                var listado = CronogramaServicio.ConsultarResponsableCronogramas(UsuarioId);

                if (listado != null)
                {
                    foreach (var datos in listado)
                    {
                        var entidad = new CronogramaListadoDTO();
                        entidad.ID = datos.ID;
                        entidad.ActividadId = datos.ActividadId;
                        entidad.ConvenioId = datos.ConvenioId;
                        entidad.FechaInicio = datos.FechaInicio.ToString("yyyy-MM-dd");
                        entidad.FechaFin = datos.FechaFin.ToString("yyyy-MM-dd");
                        entidad.Actividad = datos.Actividad;
                        entidad.Agente = datos.Agente;
                        entidad.Convenio = datos.Convenio;
                        entidad.Cronograma = datos.Cronograma;
                        entidad.Departamento = datos.Departamento;
                        entidad.Escuela = datos.Escuela;
                        entidad.EscuelaId = datos.EscuelaId;
                        entidad.Municipio = datos.Municipio;
                        entidad.CronogramaAgenteId = datos.CronogramaAgenteId;
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

        public static List<CronogramaListadoDTO> ConsultaCoordinadorCronograma()
        {
            try
            {
                var listdoentidad = new List<CronogramaListadoDTO>();
                var listado = CronogramaServicio.ConsultaCoordinadorCronograma();

                if (listado != null)
                {
                    foreach (var datos in listado)
                    {
                        var entidad = new CronogramaListadoDTO();
                        entidad.ID = datos.ID;
                        entidad.ActividadId = datos.ActividadId;
                        entidad.ConvenioId = datos.ConvenioId;
                        entidad.FechaInicio = datos.FechaInicio.ToString("yyyy-MM-dd");
                        entidad.FechaFin = datos.FechaFin.ToString("yyyy-MM-dd");
                        entidad.Actividad = datos.Actividad;
                        entidad.Agente = datos.Agente;
                        entidad.Convenio = datos.Convenio;
                        entidad.Cronograma = datos.Cronograma;
                        entidad.Departamento = datos.Departamento;
                        entidad.Escuela = datos.Escuela;
                        entidad.EscuelaId = datos.EscuelaId;
                        entidad.Municipio = datos.Municipio;
                        entidad.CronogramaAgenteId = datos.CronogramaAgenteId;
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

        #region agentes
        public static List<EstandarDTO> ConsultarAgentesCronograma(int cronogramaId, int TipoId)
        {
            var lisParametro = new List<EstandarDTO>();
            try
            {
                List<Parametro> Parametrodatos = CronogramaServicio.ConsultarAgentesCronograma(cronogramaId, TipoId);

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
        public static void EliminarAgente(int Id)
        {
            try
            { CronogramaServicio.EliminarAgente(Id); }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void AgregarAgente(int cronogramaId,
                                      string strAtributo,
                                        int tipoId,
                                        int UsuarioId)
        {
            int AgenteId = 0;
            try
            {
                AgenteId = SM.Datos.Basicas.CaracterizacionMusicalServicio.ObtenerAgenteId(strAtributo);
                if (AgenteId != 0)
                {
                    var registro = new ART_MUSICA_CRONOGRAMAXAGENTE();
                    registro.AgenteId = AgenteId;
                    registro.CronogramaId = cronogramaId;
                    registro.TipoId = tipoId;
                    registro.UsuarioCreadorid = UsuarioId;
                    registro.FechaCreacion = DateTime.Now;
                    registro.fechaActualizacion = DateTime.Now;
                    if (tipoId == 1)
                        registro.Tipo = "Responsable";
                    else
                        registro.Tipo = "Participante";
                    CronogramaServicio.AgregarAgente(registro);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
