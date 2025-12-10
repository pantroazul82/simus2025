using SM.SIPA;
using SM.LibreriaComun.DTO;
using SM.Datos.Escuelas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Aplicacion.Escuelas
{
    public class ProduccionLogica
    {
        #region Actualizacion

        public static bool ValidarProduccion(decimal entId)
        {
            bool validar = false;
            try
            {
                validar = Produccion.ValidarProduccion(entId);
            }
            catch (Exception ex)
            { throw ex; }
            return validar;
        }
        public static void Grabar(decimal entId,
                                        short entCantidadGirasUltimoAno,
                                        short entCantidadPresentacionesLocalidadUltimoAno,
                                        short entCantidadDiscosUltimoAno,
                                        short entCantidadRepertoriosUltimoAno,
                                        short entCantidadMaterialDivulgativoUltimoAno,
                                        short entCantidadMaterialApoyoUltimoAno,
                                        short entCantidadAgrupacionesConformadasVigentesUltimoAno,
                                        short entCantidadGirasInterUltimoAno,
                                        int SimusUsuarioId,
                                        string NombreUsuario,
                                        string strIP)
        {
            try
            {

               bool validar = Produccion.ValidarProduccion(entId);

               if (!validar)
                {
                    Produccion.Insertar(entId,
                                        entCantidadGirasUltimoAno,
                                        entCantidadPresentacionesLocalidadUltimoAno,
                                        entCantidadDiscosUltimoAno,
                                        entCantidadRepertoriosUltimoAno,
                                        entCantidadMaterialDivulgativoUltimoAno,
                                        entCantidadMaterialApoyoUltimoAno,
                                        entCantidadAgrupacionesConformadasVigentesUltimoAno,
                                        entCantidadGirasInterUltimoAno,
                                        SimusUsuarioId,
                                       NombreUsuario,
                                      strIP);
                }
                else
                {
                    Produccion.Actualizar(entId,
                                          entCantidadGirasUltimoAno,
                                          entCantidadPresentacionesLocalidadUltimoAno,
                                          entCantidadDiscosUltimoAno,
                                          entCantidadRepertoriosUltimoAno,
                                          entCantidadMaterialDivulgativoUltimoAno,
                                          entCantidadMaterialApoyoUltimoAno,
                                          entCantidadAgrupacionesConformadasVigentesUltimoAno,
                                          entCantidadGirasInterUltimoAno,
                                          SimusUsuarioId,
                                       NombreUsuario,
                                      strIP);
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public static void Actualizar(ProduccionDTO datos, int SimusUsuarioId,
                                        string NombreUsuario,
                                        string strIP)
        {
            try
            {
                Produccion.Insertar(datos.ENT_ID,
                                    datos.ENT_CANTIDAD_GIRAS_ULTIMO_ANIO,
                                    datos.ENT_CANTIDAD_PRESENTACIONES_LOCALIDAD_ULTIMO_ANIO,
                                    datos.ENT_CANTIDAD_DISCOS_ULTIMO_ANIO,
                                    datos.ENT_CANTIDAD_REPERTORIOS_ULTIMO_ANIO,
                                    datos.ENT_CANTIDAD_MATERIAL_DIVULGATIVO_ULTIMO_ANIO,
                                    datos.ENT_CANTIDAD_MATERIAL_APOYO_ULTIMO_ANIO,
                                    datos.ENT_CANTIDAD_AGRUPACIONES_CONFORMADAS_VIGENTES,
                                    datos.ENT_CANTIDAD_GIRAS_INTER_ULTIMO_ANIO,
                                     SimusUsuarioId,
                                       NombreUsuario,
                                      strIP);
            }
            catch (Exception ex)
            { throw ex; }
        }
        #endregion
        #region consultas
        public static ProduccionDTO ConsultarProduccionPorId(decimal EscuelaId)
        {
            try
            {
                var model = new List<ART_ME_ART_MUSICA_ENTIDAD_PRODUCCION_ObtenerPorId_Result>();
                var datos = new ProduccionDTO();
                model = Produccion.ConsultarProduccionPorId(EscuelaId);

                if (model.Count > 0)
                {

                    datos.ENT_CANTIDAD_AGRUPACIONES_CONFORMADAS_VIGENTES = model[0].ENT_CANTIDAD_AGRUPACIONES_CONFORMADAS_VIGENTES;
                    datos.ENT_CANTIDAD_DISCOS_ULTIMO_ANIO = model[0].ENT_CANTIDAD_DISCOS_ULTIMO_ANIO;
                    datos.ENT_CANTIDAD_GIRAS_INTER_ULTIMO_ANIO = model[0].ENT_CANTIDAD_GIRAS_INTER_ULTIMO_ANIO ?? 0;
                    datos.ENT_CANTIDAD_GIRAS_ULTIMO_ANIO = model[0].ENT_CANTIDAD_GIRAS_ULTIMO_ANIO;
                    datos.ENT_CANTIDAD_MATERIAL_APOYO_ULTIMO_ANIO = model[0].ENT_CANTIDAD_MATERIAL_APOYO_ULTIMO_ANIO;
                    datos.ENT_CANTIDAD_MATERIAL_DIVULGATIVO_ULTIMO_ANIO = model[0].ENT_CANTIDAD_MATERIAL_DIVULGATIVO_ULTIMO_ANIO;
                    datos.ENT_CANTIDAD_PRESENTACIONES_LOCALIDAD_ULTIMO_ANIO = model[0].ENT_CANTIDAD_PRESENTACIONES_LOCALIDAD_ULTIMO_ANIO;
                    datos.ENT_CANTIDAD_REPERTORIOS_ULTIMO_ANIO = model[0].ENT_CANTIDAD_REPERTORIOS_ULTIMO_ANIO;
                    datos.ENT_ID = model[0].ENT_ID;

                }

                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ProduccionDTO> ConsultarProduccionTodos()
        {
            try
            {
                var model = new List<ART_ME_ART_MUSICA_ENTIDAD_PRODUCCION_ObtenerTodos_Result>();
                var result = new List<ProduccionDTO>();
                model = Produccion.ConsultarProduccionTodos();

                foreach (var item in model)
                {
                    ProduccionDTO datos = new ProduccionDTO();
                    datos.ENT_CANTIDAD_AGRUPACIONES_CONFORMADAS_VIGENTES = item.ENT_CANTIDAD_AGRUPACIONES_CONFORMADAS_VIGENTES;
                    datos.ENT_CANTIDAD_DISCOS_ULTIMO_ANIO = item.ENT_CANTIDAD_DISCOS_ULTIMO_ANIO;
                    datos.ENT_CANTIDAD_GIRAS_INTER_ULTIMO_ANIO = item.ENT_CANTIDAD_GIRAS_INTER_ULTIMO_ANIO ?? 0;
                    datos.ENT_CANTIDAD_GIRAS_ULTIMO_ANIO = item.ENT_CANTIDAD_GIRAS_ULTIMO_ANIO;
                    datos.ENT_CANTIDAD_MATERIAL_APOYO_ULTIMO_ANIO = item.ENT_CANTIDAD_MATERIAL_APOYO_ULTIMO_ANIO;
                    datos.ENT_CANTIDAD_MATERIAL_DIVULGATIVO_ULTIMO_ANIO = item.ENT_CANTIDAD_MATERIAL_DIVULGATIVO_ULTIMO_ANIO;
                    datos.ENT_CANTIDAD_PRESENTACIONES_LOCALIDAD_ULTIMO_ANIO = item.ENT_CANTIDAD_PRESENTACIONES_LOCALIDAD_ULTIMO_ANIO;
                    datos.ENT_CANTIDAD_REPERTORIOS_ULTIMO_ANIO = item.ENT_CANTIDAD_REPERTORIOS_ULTIMO_ANIO;
                    datos.ENT_ID = item.ENT_ID;
                    result.Add(datos);
                }

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
