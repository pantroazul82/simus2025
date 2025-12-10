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
    public class ObservacionNeg
    {
         #region Actualizacion
        public static int Crear(ObservacionNuevoDTO model, int UsuarioId)
        {
            int registroId = 0;
            try
            {
               ART_MUSICA_ESCUELA_OBSERVACION entidad = ObservacionServicio.ConsultarPorTipo(model.EscuelaId, model.Tipo);

               if (entidad == null)
               {
                   var registro = new ART_MUSICA_ESCUELA_OBSERVACION
                   {
                       EscuelaId = model.EscuelaId,
                       Observaciones = model.Observaciones,
                       Recomendaciones = model.Recomendaciones,
                       Tipo = model.Tipo,
                       FechaCreacion = DateTime.Now,
                       FechaActualizacion = DateTime.Now,
                       UsuarioId = UsuarioId

                   };



                   registroId = ObservacionServicio.Agregar(registro);
               }
               else
               {
                   Actualizar(entidad.Id, model, UsuarioId);
               }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return registroId;
        }

        public static void Actualizar(int Id, ObservacionNuevoDTO model, int UsuarioId)
        {
            try
            {

                ObservacionServicio.Actualizar(Id, model, UsuarioId);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static void Eliminar(int Id)
        {
            try
            {

                ObservacionServicio.Eliminar(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

        #region Consulta


        public static ObservacionNuevoDTO ConsultarPorId(int Id)
        {
            try
            {
                var datos = new ObservacionNuevoDTO();
                var model = ObservacionServicio.ConsultarPorId(Id);

                if (model != null)
                {
                    datos.Observaciones = model.Observaciones;
                    datos.Recomendaciones = model.Recomendaciones;
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

        public static ObservacionNuevoDTO ConsultarPorTipo(decimal Id, string tipo)
        {
            try
            {
                var datos = new ObservacionNuevoDTO();
                var model = ObservacionServicio.ConsultarPorTipo(Id, tipo);

                if (model != null)
                {
                    datos.Observaciones = model.Observaciones;
                    datos.Recomendaciones = model.Recomendaciones;
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

        public static List<ObservacionNuevoDTO> ConsultarPorEscuelaId(decimal EscuelaId)
        {
            try
            {
                var resultado = new List<ObservacionNuevoDTO>();
                var listado = ObservacionServicio.ConsultarPorEscuelaId(EscuelaId);

                if (listado != null)
                {
                    foreach (var model in listado)
                    {
                        var datos = new ObservacionNuevoDTO();
                        datos.Observaciones = model.Observaciones;
                        datos.Recomendaciones = model.Recomendaciones;
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
   
