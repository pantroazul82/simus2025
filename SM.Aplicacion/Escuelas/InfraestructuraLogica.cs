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

    public class InfraestructuraLogica
    {
        #region Actualizacion

        public static bool ValidarInfraestructura(decimal entId)
        {
            bool validar = false;
            try
            {
                validar = Infraestructura.ValidarInfraestructura(entId);
            }
            catch (Exception ex)
            { throw ex; }
            return validar;
        }
        public static void Grabar(decimal entId,
                             bool entSedeAsignadaSoporteEscrito,
                             bool entSedeEquipMobilInstrum,
                             bool entSedeAdecAcustic,
                             short entCantidadInstrCuerdasPulsadas,
                             short entCantidadInstrCuerdasSinfonicas,
                             short entCantidadInstrVientosMaderas,
                             short entCantidadInstrVientosMetales,
                             short entCantidadInstrPercusionMenor,
                             short entCantidadInstrPercusionSinfonica,
                             short entCantidadInstrOtros,
                             short entCantidadInstrTotal,
                             bool entMaterialPedagogico,
                             short entCantidadTitulosBibliograficos,
                             string entSedeLugar,
                             short entCantidadSillas,
                             short entCantidadAtriles,
                             short entCantidadTableros,
                             short entCantidadEstanteria,
                             short entSedePorcentajeAdecAcustic,
                             string entSedeOtraSolucionAdecAcustic,
                             bool tieneAccesoInternet,
                             string[] TiposInternet,
                             string[] FuentesDotacion,
                             string[] NivelesFuentesDotacion,
                             string[] MaterialPedagogico,
                             string[] soluciones,
                             string EspacioId,
                             int SimusUsuarioId,
                             string NombreUsuario,
                             string strIP)
        {
            try
            {
                bool validar= Infraestructura.ValidarInfraestructura(entId);

                if (!validar)
                {
                    Infraestructura.Insertar(entId,
                                          entSedeAsignadaSoporteEscrito,
                                          entSedeEquipMobilInstrum,
                                          entSedeAdecAcustic,
                                          entCantidadInstrCuerdasPulsadas,
                                          entCantidadInstrCuerdasSinfonicas,
                                          entCantidadInstrVientosMaderas,
                                          entCantidadInstrVientosMetales,
                                          entCantidadInstrPercusionMenor,
                                          entCantidadInstrPercusionSinfonica,
                                          entCantidadInstrOtros,
                                          entCantidadInstrTotal,
                                          entMaterialPedagogico,
                                          entCantidadTitulosBibliograficos,
                                          entSedeLugar,
                                          entCantidadSillas,
                                          entCantidadAtriles,
                                          entCantidadTableros,
                                          entCantidadEstanteria,
                                          entSedePorcentajeAdecAcustic,
                                          entSedeOtraSolucionAdecAcustic,
                                          tieneAccesoInternet,
                                          TiposInternet,
                                          FuentesDotacion,
                                          NivelesFuentesDotacion,
                                          MaterialPedagogico,
                                          soluciones,
                                          EspacioId,
                                          SimusUsuarioId,
                                          NombreUsuario,
                                          strIP); 
                }
                else 
                {
                    Infraestructura.Actualizar(entId,
                                          entSedeAsignadaSoporteEscrito,
                                          entSedeEquipMobilInstrum,
                                          entSedeAdecAcustic,
                                          entCantidadInstrCuerdasPulsadas,
                                          entCantidadInstrCuerdasSinfonicas,
                                          entCantidadInstrVientosMaderas,
                                          entCantidadInstrVientosMetales,
                                          entCantidadInstrPercusionMenor,
                                          entCantidadInstrPercusionSinfonica,
                                          entCantidadInstrOtros,
                                          entCantidadInstrTotal,
                                          entMaterialPedagogico,
                                          entCantidadTitulosBibliograficos,
                                          entSedeLugar,
                                          entCantidadSillas,
                                          entCantidadAtriles,
                                          entCantidadTableros,
                                          entCantidadEstanteria,
                                          entSedePorcentajeAdecAcustic,
                                          entSedeOtraSolucionAdecAcustic,
                                          tieneAccesoInternet,
                                          TiposInternet,
                                          FuentesDotacion,
                                          NivelesFuentesDotacion,
                                          MaterialPedagogico,
                                          soluciones,
                                          EspacioId,
                                          SimusUsuarioId,
                                          NombreUsuario,
                                          strIP); 
                }

            }
            catch (Exception ex)
            { throw ex; }
        }
      
       
        #endregion

        #region Consultas
        public static InfraestructuraDTO ConsultarInfraestructuraPorId(decimal EscuelaId)
        {
            try
            {
                var model = new List<ART_ME_ART_MUSICA_ENTIDAD_INFRAESTRUCTURA_ObtenerPorId_Result>();
                var modelEntidad = new List<ART_ME_ART_ENTIDAD_INFRAESTRUCTURA_ObtenerPorId_Result>();
                InfraestructuraDTO datos = new InfraestructuraDTO();
                model = Infraestructura.ConsultarInfraestructuraPorId(EscuelaId);
                modelEntidad = Infraestructura.ConsultarInfraestructuraEntidadPorId(EscuelaId);

                if (model.Count > 0)
                {
                    datos.ENT_CANTIDAD_ATRILES = model[0].ENT_CANTIDAD_ATRILES ?? 0;
                    datos.ENT_CANTIDAD_ESTANTERIA = model[0].ENT_CANTIDAD_ESTANTERIA ?? 0;
                    datos.ENT_CANTIDAD_INSTR_CUERDAS_PULSADAS = model[0].ENT_CANTIDAD_INSTR_CUERDAS_PULSADAS;
                    datos.ENT_CANTIDAD_INSTR_CUERDAS_SINFONICAS = model[0].ENT_CANTIDAD_INSTR_CUERDAS_SINFONICAS;
                    datos.ENT_CANTIDAD_INSTR_OTROS = model[0].ENT_CANTIDAD_INSTR_OTROS;
                    datos.ENT_CANTIDAD_INSTR_PERCUSION_MENOR = model[0].ENT_CANTIDAD_INSTR_PERCUSION_MENOR;
                    datos.ENT_CANTIDAD_INSTR_PERCUSION_SINFONICA = model[0].ENT_CANTIDAD_INSTR_PERCUSION_SINFONICA;
                    datos.ENT_CANTIDAD_INSTR_TOTAL = model[0].ENT_CANTIDAD_INSTR_TOTAL;
                    datos.ENT_CANTIDAD_INSTR_VIENTOS_MADERAS = model[0].ENT_CANTIDAD_INSTR_VIENTOS_MADERAS;
                    datos.ENT_CANTIDAD_INSTR_VIENTOS_METALES = model[0].ENT_CANTIDAD_INSTR_VIENTOS_METALES;
                    datos.ENT_CANTIDAD_SILLAS = model[0].ENT_CANTIDAD_SILLAS ?? 0;
                    datos.ENT_CANTIDAD_TABLEROS = model[0].ENT_CANTIDAD_TABLEROS ?? 0;
                    datos.ENT_CANTIDAD_TITULOS_BIBLIOGRAFICOS = model[0].ENT_CANTIDAD_TITULOS_BIBLIOGRAFICOS;
                    datos.ENT_ID = model[0].ENT_ID;
                    datos.ENT_MATERIAL_PEDAGOGICO = model[0].ENT_MATERIAL_PEDAGOGICO;
                    datos.ENT_SEDE_ADEC_ACUSTIC = model[0].ENT_SEDE_ADEC_ACUSTIC;
                    datos.ENT_SEDE_ASIGNADA_SOPORTE_ESCRITO = model[0].ENT_SEDE_ASIGNADA_SOPORTE_ESCRITO;
                    datos.ENT_SEDE_EQUIP_MOBIL_INSTRUM = model[0].ENT_SEDE_EQUIP_MOBIL_INSTRUM;
                    datos.ENT_SEDE_LUGAR = model[0].ENT_SEDE_LUGAR;
                    datos.ENT_SEDE_OTRA_SOLUCION_ADEC_ACUSTIC = model[0].ENT_SEDE_OTRA_SOLUCION_ADEC_ACUSTIC;
                    datos.ENT_SEDE_PORCENTAJE_ADEC_ACUSTIC = model[0].ENT_SEDE_PORCENTAJE_ADEC_ACUSTIC ?? 0;

                }

                if (modelEntidad.Count > 0)
                {
                    datos.ENT_SINOACCESO_INTERNET = modelEntidad[0].ENT_SINOACCESO_INTERNET;
                    if (modelEntidad[0].ENT_ESPACIO != null)
                        datos.ENT_ESPACIO = (decimal)modelEntidad[0].ENT_ESPACIO;
                    else
                        datos.ENT_ESPACIO = 0;
                    //datos.ENT_OTRO_ESPACIO = modelEntidad[0].ENT_OTRO_ESPACIO;
                    //datos.ENT_SINO_INFRAESTRUCTURA_DISCAPACITADOS = modelEntidad[0].ENT_SINO_INFRAESTRUCTURA_DISCAPACITADOS;
                    //datos.ENT_SINO_BIEN_INTERES_CULTURAL = modelEntidad[0].ENT_SINO_BIEN_INTERES_CULTURAL;
                    //datos.ENT_NIVEL_BIEN_INTERES_CULTURAL = (decimal)modelEntidad[0].ENT_NIVEL_BIEN_INTERES_CULTURAL;
                }

                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<InfraestructuraDTO> ConsultarInfraestructuraTodos()
        {
            try
            {
                var model = new List<ART_ME_ART_MUSICA_ENTIDAD_INFRAESTRUCTURA_ObtenerTodos_Result>();
                var result = new List<InfraestructuraDTO>();
                model = Infraestructura.ConsultarInfraestructuraTodos();

                foreach (var item in model)
                {
                    InfraestructuraDTO datos = new InfraestructuraDTO();
                    datos.ENT_CANTIDAD_ATRILES = item.ENT_CANTIDAD_ATRILES ?? 0;
                    datos.ENT_CANTIDAD_ESTANTERIA = item.ENT_CANTIDAD_ESTANTERIA ?? 0;
                    datos.ENT_CANTIDAD_INSTR_CUERDAS_PULSADAS = item.ENT_CANTIDAD_INSTR_CUERDAS_PULSADAS;
                    datos.ENT_CANTIDAD_INSTR_CUERDAS_SINFONICAS = item.ENT_CANTIDAD_INSTR_CUERDAS_SINFONICAS;
                    datos.ENT_CANTIDAD_INSTR_OTROS = item.ENT_CANTIDAD_INSTR_OTROS;
                    datos.ENT_CANTIDAD_INSTR_PERCUSION_MENOR = item.ENT_CANTIDAD_INSTR_PERCUSION_MENOR;
                    datos.ENT_CANTIDAD_INSTR_PERCUSION_SINFONICA = item.ENT_CANTIDAD_INSTR_PERCUSION_SINFONICA;
                    datos.ENT_CANTIDAD_INSTR_TOTAL = item.ENT_CANTIDAD_INSTR_TOTAL;
                    datos.ENT_CANTIDAD_INSTR_VIENTOS_MADERAS = item.ENT_CANTIDAD_INSTR_VIENTOS_MADERAS;
                    datos.ENT_CANTIDAD_INSTR_VIENTOS_METALES = item.ENT_CANTIDAD_INSTR_VIENTOS_METALES;
                    datos.ENT_CANTIDAD_SILLAS = item.ENT_CANTIDAD_SILLAS ?? 0;
                    datos.ENT_CANTIDAD_TABLEROS = item.ENT_CANTIDAD_TABLEROS ?? 0;
                    datos.ENT_CANTIDAD_TITULOS_BIBLIOGRAFICOS = item.ENT_CANTIDAD_TITULOS_BIBLIOGRAFICOS;
                    datos.ENT_ID = item.ENT_ID;
                    datos.ENT_MATERIAL_PEDAGOGICO = item.ENT_MATERIAL_PEDAGOGICO;
                    datos.ENT_SEDE_ADEC_ACUSTIC = item.ENT_SEDE_ADEC_ACUSTIC;
                    datos.ENT_SEDE_ASIGNADA_SOPORTE_ESCRITO = item.ENT_SEDE_ASIGNADA_SOPORTE_ESCRITO;
                    datos.ENT_SEDE_EQUIP_MOBIL_INSTRUM = item.ENT_SEDE_EQUIP_MOBIL_INSTRUM;
                    datos.ENT_SEDE_LUGAR = item.ENT_SEDE_LUGAR;
                    datos.ENT_SEDE_OTRA_SOLUCION_ADEC_ACUSTIC = item.ENT_SEDE_OTRA_SOLUCION_ADEC_ACUSTIC;
                    datos.ENT_SEDE_PORCENTAJE_ADEC_ACUSTIC = item.ENT_SEDE_PORCENTAJE_ADEC_ACUSTIC ?? 0;
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
