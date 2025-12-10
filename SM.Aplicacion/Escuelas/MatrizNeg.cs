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
    public class MatrizNeg
    {
        #region Actualizacion
        public static int Crear(MatrizNuevoDTO model, int UsuarioId)
        {
            int registroId = 0;
            try
            {

                var registro = new ART_MUSICA_ESCUELA_MATRIZ
                {
                    EscuelaId = model.EscuelaId,
                    Clasificacion = model.Clasificacion,
                    ClasificacionId = model.ClasificacionId,
                    Dificultades = model.Dificultades,
                    Fortaleza = model.Fortaleza,
                    Tipo = model.TipoM,
                    FechaCreacion = DateTime.Now,
                    FechaActualizacion = DateTime.Now,
                    UsuarioId = UsuarioId

                };



                registroId = MatrizServicio.Agregar(registro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return registroId;
        }

        public static void Actualizar(int Id, MatrizNuevoDTO model, int UsuarioId)
        {
            try
            {

                MatrizServicio.Actualizar(Id, model, UsuarioId);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

        #region Consulta

        public static MatrizNuevoDTO ConsultarPorId(int Id)
        {
            try
            {
                var datos = new MatrizNuevoDTO();
                var model = MatrizServicio.ConsultarPorId(Id);

                if (model != null)
                {
                    datos.ClasificacionId = model.ClasificacionId;
                    datos.Clasificacion = model.Clasificacion;
                    datos.Dificultades = model.Dificultades;
                    datos.Fortaleza = model.Fortaleza;
                    datos.TipoM = model.Tipo;
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
        public static List<MatrizNuevoDTO> ConsultarPorEscuelaId(decimal EscuelaId, string tipo)
        {
            try
            {
                var resultado = new List<MatrizNuevoDTO>();
                var listado = MatrizServicio.ConsultarPorEscuelaId(EscuelaId, tipo);

                if (listado != null)
                {
                    foreach (var model in listado)
                    {
                        var datos = new MatrizNuevoDTO();
                        datos.ClasificacionId = model.ClasificacionId;
                        datos.Clasificacion = model.Clasificacion;
                        datos.Dificultades = model.Dificultades;
                        datos.Fortaleza = model.Fortaleza;
                        datos.TipoM = model.Tipo;
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

        public static List<MatrizNuevoDTO> ValidarExisteEscuela(decimal EscuelaId)
        {
            try
            {
                var resultado = new List<MatrizNuevoDTO>();
                var listado = MatrizServicio.ValidarExisteEscuela(EscuelaId);

                if (listado != null)
                {
                    foreach (var model in listado)
                    {
                        var datos = new MatrizNuevoDTO();
                        datos.ClasificacionId = model.ClasificacionId;
                        datos.Clasificacion = model.Clasificacion;
                        datos.Dificultades = model.Dificultades;
                        datos.Fortaleza = model.Fortaleza;
                        datos.TipoM = model.Tipo;
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
