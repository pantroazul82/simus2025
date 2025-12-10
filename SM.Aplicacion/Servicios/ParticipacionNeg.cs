using SM.Datos.DTO.Servicios;
using SM.Datos.Servicios;
using SM.LibreriaComun.DTO;
using SM.LibreriaComun.DTO.Servicios;
using SM.SIPA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Aplicacion.Servicios
{
    public class ParticipacionNeg
    {
        public static List<ParticipacionListDTO> ConsultarInstrumentoDotacion(int DotacionId)
        {
            try
            {
                var listDatos = new List<ParticipacionResultadoDTO>();
                var listResultado = new List<ParticipacionListDTO>();
                listDatos = ParticipacionServicio.ConsultarMisParticipaciones(DotacionId);
                foreach (var item in listDatos)
                {
                    var datos = new ParticipacionListDTO();
                    datos.AgenteId = item.AgenteId;
                    datos.AgrupacionId = item.AgrupacionId;
                    datos.Convocatoria = item.Convocatoria;
                    datos.ConvocatoriaId = item.ConvocatoriaId;
                    datos.EntidadId = item.EntidadId;
                    datos.EscuelaId = item.EscuelaId;
                    datos.Estado = item.Estado;
                    datos.Id = item.Id;
                    datos.RelacionadoA = item.RelacionadoA;
                    listResultado.Add(datos);
                }

                return listResultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ParticipacionListadoDTO> ConsultarParticipacionPorConvocatoriaId(int convocatoriaId)
        {
            try
            {
                var model = new List<ParticipacionResultadoDTO>();
                var listEntidad = new List<ParticipacionListadoDTO>();
                model = ParticipacionServicio.ConsultarParticipacionPorConvocatoriaId(convocatoriaId);

                if (model != null)
                {
                    foreach (var item in model)
                    {
                        var datos = new ParticipacionListadoDTO();
                        datos.ConvocatoriaId = item.ConvocatoriaId;
                        if (item.AgenteId > 0)
                            datos.ActorId = (int)item.AgenteId;
                        else if (item.AgrupacionId > 0)
                            datos.ActorId = (int)item.AgrupacionId;
                        else if (item.EntidadId > 0)
                            datos.ActorId = (int)item.EntidadId;
                        else if (item.EscuelaId > 0)
                            datos.ActorId = (int)item.EscuelaId;
                        datos.Descripcion = item.Descripcion;
                        datos.FechaRegistro = item.FechaRegistro.ToString("dd/MM/yyyy");
                        datos.Id = item.Id;
                        datos.Nombre = item.Nombre;
                        datos.RelacionadoA = item.RelacionadoA;
                        datos.Usuario = item.Usuario;
                        listEntidad.Add(datos);
                    }

                }


                return listEntidad;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ParticipacionListadoDTO> ConsultarConvocatoriasPorUsuarioId(int UsuarioId)
        {
            try
            {
                var model = new List<ParticipacionResultadoDTO>();
                var listEntidad = new List<ParticipacionListadoDTO>();
                model = ParticipacionServicio.ConsultarConvocatoriasPorUsuarioId(UsuarioId);

                if (model != null)
                {
                    foreach (var item in model)
                    {
                        var datos = new ParticipacionListadoDTO();
                        datos.ConvocatoriaId = item.ConvocatoriaId;
                        if (item.AgenteId > 0)
                            datos.ActorId = (int)item.AgenteId;
                        else if (item.AgrupacionId > 0)
                            datos.ActorId = (int)item.AgrupacionId;
                        else if (item.EntidadId > 0)
                            datos.ActorId = (int)item.EntidadId;
                        else if (item.EscuelaId > 0)
                            datos.ActorId = (int)item.EscuelaId;
                        datos.Descripcion = item.Descripcion;
                        datos.FechaRegistro = item.FechaRegistro.ToString("dd/MM/yyyy");
                        datos.Id = item.Id;
                        datos.Nombre = item.Nombre;
                        datos.RelacionadoA = item.RelacionadoA;
                        datos.Usuario = item.Usuario;
                        listEntidad.Add(datos);
                    }

                }


                return listEntidad;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void AgregarParticipacion(ParticipacionDetalleDTO datos)
        {
            var entidad = new ART_MUSICA_PARTICIPACION();
            string NombreActor = "";
            try
            {
                if (datos.TipoActorId == 6)
                {
                    NombreActor = ConvocatoriaServicio.ObtenerNombreAgente(datos.ActorId);
                    ConvocatoriaServicio.EliminatParticipacionAgente(datos.ConvocatoriaId, datos.ActorId);
                    entidad = new ART_MUSICA_PARTICIPACION
                    {
                        ConvocatoriaId = datos.ConvocatoriaId,
                        FechaRegistro = DateTime.Now,
                        Descripcion = datos.Descipcion,
                        UsuarioId = datos.UsuarioId,
                        EstadoId = datos.EstadoId,
                        AgenteId = datos.ActorId,
                        Nombre = NombreActor,
                        RelacionadoA = "Agentes"
                    };
                }
                else if (datos.TipoActorId == 7)
                {
                    NombreActor = ConvocatoriaServicio.ObtenerNombreEntidad(datos.ActorId);
                    ConvocatoriaServicio.EliminatParticipacionEntidad(datos.ConvocatoriaId, datos.ActorId);
                    entidad = new ART_MUSICA_PARTICIPACION
                    {
                        ConvocatoriaId = datos.ConvocatoriaId,
                        FechaRegistro = DateTime.Now,
                        Descripcion = datos.Descipcion,
                        UsuarioId = datos.UsuarioId,
                        EstadoId = datos.EstadoId,
                        EntidadId = datos.ActorId,
                        Nombre = NombreActor,
                        RelacionadoA = "Entidad"
                    };
                }
                else if (datos.TipoActorId == 8)
                {
                    NombreActor = ConvocatoriaServicio.ObtenerNombreAgrupacion(datos.ActorId);
                    ConvocatoriaServicio.EliminatParticipacionAgrupacion(datos.ConvocatoriaId, datos.ActorId);
                    entidad = new ART_MUSICA_PARTICIPACION
                    {
                        ConvocatoriaId = datos.ConvocatoriaId,
                        FechaRegistro = DateTime.Now,
                        Descripcion = datos.Descipcion,
                        UsuarioId = datos.UsuarioId,
                        EstadoId = datos.EstadoId,
                        AgrupacionId = datos.ActorId,
                        Nombre = NombreActor,
                        RelacionadoA = "Agrupación"
                    };
                }
                else if (datos.TipoActorId == 9)
                {
                    NombreActor = ConvocatoriaServicio.ObtenerNombreEscuela(datos.ActorId);
                    ConvocatoriaServicio.EliminatParticipacionEscuelas(datos.ConvocatoriaId, datos.ActorId);
                    entidad = new ART_MUSICA_PARTICIPACION
                    {
                        ConvocatoriaId = datos.ConvocatoriaId,
                        FechaRegistro = DateTime.Now,
                        Descripcion = datos.Descipcion,
                        UsuarioId = datos.UsuarioId,
                        EstadoId = datos.EstadoId,
                        EscuelaId = datos.ActorId,
                        Nombre = NombreActor,
                        RelacionadoA = "Escuelas"
                    };

                }
                ParticipacionServicio.AgregarParticipacion(entidad);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
