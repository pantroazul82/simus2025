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
    public class RepositorioNeg
    {
        #region Actualizacion
        public static int Crear( RepertorioNuevoDTO model, int UsuarioId)
        {
            int registroId = 0;
            try
            {

                var registro = new ART_MUSICA_ESCUELA_REPERTORIOS
                {
                    Arreglista = model.Arreglista,
                    Compositor = model.Compositor,
                    Dificultad = model.Dificultad,
                    EscuelaId = model.EscuelaId,
                    Nombre = model.Nombre,
                    FechaCreacion = DateTime.Now,
                    FechaActualizacion = DateTime.Now,
                    UsuarioId = UsuarioId

                };



                registroId = RepertorioServicio.Agregar(registro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return registroId;
        }

        public static void Actualizar(int Id, RepertorioNuevoDTO model, int UsuarioId)
        {
            try
            {

                RepertorioServicio.Actualizar(Id, model, UsuarioId);
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

               RepertorioServicio.Eliminar(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion

        #region Consultas
        public static RepertorioNuevoDTO ConsultarPorId(int Id)
        {
            try
            {
                var datos = new RepertorioNuevoDTO();
                var model = RepertorioServicio.ConsultarPorId(Id);

                if (model != null)
                {

                    datos.Compositor = model.Compositor;
                    datos.Arreglista = model.Arreglista;
                    datos.Dificultad = model.Dificultad;
                    datos.EscuelaId = model.EscuelaId;
                    datos.Id = model.Id;
                    datos.Nombre = model.Nombre;
                   
                }


                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<RepertorioNuevoDTO> ConsultarPorEscuelaId(decimal EscuelaId)
        {
            try
            {
                var resultado = new List<RepertorioNuevoDTO>();
                var listado = RepertorioServicio.ConsultarPorEscuelaId(EscuelaId);

                if (listado != null)
                {
                    foreach (var model in listado)
                    {
                        var datos = new RepertorioNuevoDTO();
                        datos.Compositor = model.Compositor;
                        datos.Arreglista = model.Arreglista;
                        datos.Dificultad = model.Dificultad;
                        datos.EscuelaId = model.EscuelaId;
                        datos.Id = model.Id;
                        datos.Nombre = model.Nombre;
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
