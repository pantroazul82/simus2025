using SM.Datos.Escuelas;
using SM.LibreriaComun.DTO.FichaAsesoria;
using SM.SIPA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Aplicacion.Escuelas
{
    public class ClasificacionNeg
    {
        #region Actualizacion
        public static int Crear(ClasificacionNuevoDTO model, int UsuarioId)
        {
            int registroId = 0;
            try
            {

                var registro = new ART_MUSICA_ESCUELA_CLASIFICACION
                {
                    EscuelaId = model.EscuelaId,
                    Bueno = model.Bueno,
                    Clasificacion = model.Clasificacion,
                    ClasificacionId = model.ClasificacionId,
                    DEFICIENTE = model.DEFICIENTE,
                    NOSEREALIZA = model.NOSEREALIZA,
                    REGULAR = model.REGULAR,
                    Tipo = model.Tipo,
                    FechaCreacion = DateTime.Now,
                    FechaActualizacion = DateTime.Now,
                    UsuarioId = UsuarioId

                };



                registroId = ClasificacionServicio.Agregar(registro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return registroId;
        }

        public static void Actualizar(int Id, ClasificacionNuevoDTO model, int UsuarioId)
        {
            try
            {

                ClasificacionServicio.Actualizar(Id, model, UsuarioId);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

        #region Consulta
        public static ClasificacionNuevoDTO ConsultarPorId(int Id)
        {
            try
            {
                var datos = new ClasificacionNuevoDTO();
                var model = ClasificacionServicio.ConsultarPorId(Id);

                if (model != null)
                {
                    datos.ClasificacionId = model.ClasificacionId;
                    datos.Clasificacion = model.Clasificacion;
                    datos.Bueno = model.Bueno;
                    datos.DEFICIENTE = model.DEFICIENTE;
                    datos.NOSEREALIZA = model.NOSEREALIZA;
                    datos.REGULAR = model.REGULAR;
                    datos.Tipo = model.Tipo;
                    datos.EscuelaId = model.EscuelaId;
                    datos.Id = model.Id;
                }


                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<ClasificacionNuevoDTO> ConsultarPorEscuelaId(decimal EscuelaId, string tipo)
        {
            try
            {
                var resultado = new List<ClasificacionNuevoDTO>();
                var listado = ClasificacionServicio.ConsultarPorEscuelaId(EscuelaId, tipo);

                if (listado != null)
                {
                    foreach (var model in listado)
                    {
                        var datos = new ClasificacionNuevoDTO();
                        datos.ClasificacionId = model.ClasificacionId;
                        datos.Clasificacion = model.Clasificacion;
                        datos.Bueno = model.Bueno;
                        datos.DEFICIENTE = model.DEFICIENTE;
                        datos.NOSEREALIZA = model.NOSEREALIZA;
                        datos.REGULAR = model.REGULAR;
                        datos.Tipo = model.Tipo;
                        datos.EscuelaId = model.EscuelaId;
                        datos.Id = model.Id;
                        resultado.Add(datos);
                    }

                }


                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ClasificacionNuevoDTO> ValidarExisteEscuela(decimal EscuelaId)
        {
            try
            {
                var resultado = new List<ClasificacionNuevoDTO>();
                var listado = ClasificacionServicio.ValidarExisteEscuela(EscuelaId);

                if (listado != null)
                {
                    foreach (var model in listado)
                    {
                        var datos = new ClasificacionNuevoDTO();
                        datos.ClasificacionId = model.ClasificacionId;
                        datos.Clasificacion = model.Clasificacion;
                        datos.Bueno = model.Bueno;
                        datos.DEFICIENTE = model.DEFICIENTE;
                        datos.NOSEREALIZA = model.NOSEREALIZA;
                        datos.REGULAR = model.REGULAR;
                        datos.Tipo = model.Tipo;
                        datos.EscuelaId = model.EscuelaId;
                        datos.Id = model.Id;
                        resultado.Add(datos);
                    }

                }


                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
