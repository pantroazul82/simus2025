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
    public class AsesoriaNeg
    {
        #region Actualizacion
        public static int Crear(AsesoriaNuevoDTO model, int UsuarioId)
        {
            int registroId = 0;
            int AnoConformacion = 0;
            int promedioAnual = 0;
            int promedioMensual = 0;
            try
            {

                if (!String.IsNullOrEmpty(model.AnoValue))
                    AnoConformacion = Convert.ToInt32(model.AnoValue);

                if (!String.IsNullOrEmpty(model.PromedioAnualPresentaciones))
                    promedioAnual = Convert.ToInt32(model.PromedioAnualPresentaciones);

                if (!String.IsNullOrEmpty(model.PromedioMesesPresentaciones))
                    promedioMensual = Convert.ToInt32(model.PromedioMesesPresentaciones);

                var registro = new ART_MUSICA_ESCUELA_ASESORIA
                {
                    EscuelaId = model.EscuelaId,
                    Basico = model.Basico,
                    Medio = model.Medio,
                    NombreDirector = model.NombreDirector,
                    Avanzado = model.Avanzado,
                    Conformacion = AnoConformacion,
                    NombreAgrupacion = model.NombreAgrupacion,
                    PracticaColectiva = model.PracticaColectiva,
                    PromedioAnualPresentaciones = promedioAnual,
                    PromedioMesesPresentaciones = promedioMensual,
                    FechaCreacion = DateTime.Now,
                    FechaActualizacion = DateTime.Now,
                    UsuarioId = UsuarioId

                };



                registroId = AsesoriaServicio.Agregar(registro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return registroId;
        }

        public static void Actualizar(int EscuelaId, AsesoriaNuevoDTO model, int UsuarioId)
        {
            try
            {

                AsesoriaServicio.Actualizar(EscuelaId, model, UsuarioId);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static void ActualizarConcepto(int Id, AsesoriaConceptoDTO model, int UsuarioId)
        {
            try
            {

                AsesoriaServicio.ActualizarConcepto(Id, model, UsuarioId);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion

        #region Consulta
        public static AsesoriaNuevoDTO ConsultarPorEscuelaId(decimal EscuelaId)
        {
            try
            {
                var datos = new AsesoriaNuevoDTO();
                var model = AsesoriaServicio.ConsultarPorEscuelaId(EscuelaId);

                if (model != null)
                {
                    datos.NombreDirector = model.NombreDirector;
                    datos.Avanzado = model.Avanzado;
                    datos.Basico = model.Basico;
                    datos.Medio = model.Medio;
                    if ( model.Conformacion != 0)
                        datos.AnoValue = model.Conformacion.ToString();
                    datos.NombreAgrupacion = model.NombreAgrupacion;
                    datos.PracticaColectiva = model.PracticaColectiva;
                    if (model.PromedioAnualPresentaciones != 0)
                        datos.PromedioAnualPresentaciones = model.PromedioAnualPresentaciones.ToString();
                    if ( model.PromedioMesesPresentaciones != 0)
                        datos.PromedioMesesPresentaciones = model.PromedioMesesPresentaciones.ToString();

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

        public static AsesoriaConceptoDTO ConsultarConceptoPorEscuelaId(decimal EscuelaId)
        {
            try
            {
                var datos = new AsesoriaConceptoDTO();
                var model = AsesoriaServicio.ConsultarPorEscuelaId(EscuelaId);

                if (model != null)
                {
                    datos.AspectoAsesorado = model.AspectoAsesorado;
                    datos.Concepto = model.Concepto;
                    datos.Mecanismo = model.Mecanismo;
                    datos.Recomendacion = model.Recomendacion;
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
        #endregion
    }
}
