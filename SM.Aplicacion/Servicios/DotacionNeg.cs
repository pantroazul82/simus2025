using SM.Datos.DTO;
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
    public class DotacionNeg
    {
        public static int CrearDotacion(DotacionDTO datos)
        {
            var entidad = new ART_MUSICA_DOTACION();
            int DotacionId = 0;

            try
            {
                if (datos != null)
                {

                    entidad = new ART_MUSICA_DOTACION
                    {
                        Apellido = datos.Apellido,
                        Cargo = datos.Cargo,
                        Celular = datos.Celular,
                        Email = datos.Email,
                        EntidadId = datos.EntidadId,
                        EscuelaId = datos.EscuelaId,
                        Identificacion = datos.Identificacion,
                        Nombre = datos.Nombre,
                        Telefono = datos.Telefono,
                        ConvocatoriaId = datos.ConvocatoriaId,
                        UsuarioId = datos.UsuarioId
                    };



                    DotacionId = DotacionServicio.Crear(entidad);
                }
                return DotacionId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int CrearDotacionInstrumento(int DotacionId, int InstrumentoId, int prioridadId, int cantidad)
        {
            var entidad = new ART_MUSICA_DOTACION_INSTRUMENTOS();
            int Id = 0;

            try
            {

                entidad = new ART_MUSICA_DOTACION_INSTRUMENTOS
                {
                    DotacionId = DotacionId,
                    InstrumentoId = InstrumentoId,
                    PrioridadId = prioridadId,
                    Cantidad = cantidad
                };



                Id = DotacionServicio.CrearInstrumento(entidad);

                return Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void Actualizar(DotacionDTO datos)
        {
            try
            {
                if (datos != null)
                {
                    DotacionServicio.Actualizar(datos.Id, datos.Nombre, datos.Apellido, datos.Identificacion, datos.Cargo, datos.Telefono, datos.Celular, datos.Email);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DotacionDTO ConsultarDotacionId(int Id)
        {
            try
            {
                var datos = new DotacionDTO();
                var model = DotacionServicio.ConsultarDotacionId(Id);

                if (model != null)
                {
                    datos.Apellido = model.Apellido;
                    datos.Cargo = model.Cargo;
                    datos.Celular = model.Celular;
                    datos.ConvocatoriaId = (int)model.ConvocatoriaId;
                    datos.Email = model.Email;
                    datos.EntidadId = model.EntidadId;
                    datos.EscuelaId = (int)model.EscuelaId;
                    datos.Id = model.Id;
                    datos.Identificacion = model.Identificacion;
                    datos.Nombre = model.Nombre;
                    datos.Telefono = model.Telefono;

                }


                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<DotacionListDTO> ConsultarListadoDotacion()
        {
            try
            {
                var model = new List<DotacionResultadoDTO>();
                var listEntidad = new List<DotacionListDTO>();
                model = DotacionServicio.ConsultarListadoDotacion();

                if (model != null)
                {
                    foreach (var item in model)
                    {
                        var datos = new DotacionListDTO();
                        datos.Cargo = item.Cargo;
                        datos.Departamento = item.Departamento;
                        datos.EntidadId = item.EntidadId;
                        datos.EscuelaId = item.EscuelaId;
                        datos.Id = item.Id;
                        datos.Municipio = item.Municipio;
                        datos.Nombre = item.Nombre;
                        datos.NombreEntidad = item.NombreEntidad;
                        datos.NombreEscuela = item.NombreEscuela;

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

        public static List<DotacionInstrumentoDTO> ConsultarInstrumentoDotacion(int DotacionId)
        {
            try
            {
                var listInstrumento = new List<InstrumentoResultadoDTO>();
                var listResultado = new List<DotacionInstrumentoDTO>();
                listInstrumento = DotacionServicio.ConsultarInstrumentoDotacion(DotacionId);
                foreach (var item in listInstrumento)
                {
                    var datos = new DotacionInstrumentoDTO();
                    datos.Cantidad = item.Cantidad;
                    datos.DotacionId = item.DotacionId;
                    datos.DotacionInstrumentoId = item.DotacionInstrumentoId;
                    datos.Instrumento = item.Instrumento;
                    datos.Prioridad = item.Prioridad;
                    listResultado.Add(datos);
                }

                return listResultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void EliminarDotacionInstrumento(int DotacionInstrumentoId)
        {
            try
            { DotacionServicio.EliminarDotacionInstrumento(DotacionInstrumentoId); }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
