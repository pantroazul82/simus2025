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
    public class InstrumentoNeg
    {
        #region Actualizacion
        public static int Crear(InstrumentoNuevoDTO model, int UsuarioId)
        {
            int registroId = 0;
            try
            {

                var registro = new ART_MUSICA_ESCUELA_INSTRUMENTOS
                {
                    CantidadBuenos = model.CantidadBuenos,
                    CantidadMalos = model.CantidadMalos,
                    CantidadMincultura = model.CantidadMincultura,
                    CantidadRegular = model.CantidadRegular,
                    CantidadPerdidos = model.CantidadPerdidos,
                    Descripcion = model.Descripcion,
                    EscuelaId = model.EscuelaId,
                    InstrumentoId = model.InstrumentoId,
                    Total = model.Total,
                    FechaCreacion = DateTime.Now,
                    FechaActualizacion = DateTime.Now,
                    UsuarioId = UsuarioId

                };



                registroId = InstrumentoServicio.Agregar(registro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return registroId;
        }

        public static void Actualizar(int Id, InstrumentoNuevoDTO model, int UsuarioId)
        {
            try
            {

                InstrumentoServicio.Actualizar(Id, model, UsuarioId);
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

                InstrumentoServicio.Eliminar(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

        #region Consulta

        public static InstrumentoNuevoDTO ConsultarPorId(int Id)
        {
            try
            {
                var datos = new InstrumentoNuevoDTO();
                var model = InstrumentoServicio.ConsultarPorId(Id);

                if (model != null)
                {
                    datos.CantidadBuenos = model.CantidadBuenos;
                    datos.CantidadMalos = model.CantidadMalos;
                    datos.CantidadMincultura = model.CantidadMincultura;
                    datos.CantidadRegular = model.CantidadRegular;
                    datos.Descripcion = model.Descripcion;
                    datos.InstrumentoId = model.InstrumentoId;
                    datos.CantidadPerdidos = (int)model.CantidadPerdidos;
                    datos.Total = model.Total;
                    datos.EscuelaId = model.EscuelaId ?? 0;
                    datos.Id = model.Id;
                }


                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<InstrumentoNuevoDTO> ConsultarPorEscuelaId(decimal EscuelaId)
        {
            try
            {
                var resultado = new List<InstrumentoNuevoDTO>();
                var listado = InstrumentoServicio.ConsultarPorEscuelaId(EscuelaId);

                if (listado != null)
                {
                    foreach (var model in listado)
                    {
                        var datos = new InstrumentoNuevoDTO();
                        datos.CantidadBuenos = model.CantidadBuenos;
                        datos.CantidadMalos = model.CantidadMalos;
                        datos.CantidadMincultura = model.CantidadMincultura;
                        datos.CantidadRegular = model.CantidadRegular;
                        datos.CantidadPerdidos = model.CantidadPerdidos ?? 0;
                        datos.Descripcion = model.Descripcion;
                        datos.InstrumentoId = model.InstrumentoId;
                        datos.Instrumento = SM.Aplicacion.Basicas.CaracterizacionMusicalNeg.ObenerNombreInstrumento(model.InstrumentoId);
                        datos.Total = model.Total;
                        datos.EscuelaId = model.EscuelaId ?? 0;
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
