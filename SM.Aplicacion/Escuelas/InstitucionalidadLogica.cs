using SM.SIPA;
using SM.LibreriaComun.DTO;
using SM.Datos.Escuelas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SM.Datos.DTO;


namespace SM.Aplicacion.Escuelas
{
    public class InstitucionalidadLogica
    {
        #region Actualizar

        public static bool ValidarInstitucionalidad(decimal entId)
        {
            bool validar = false;
            try
            {
                validar = Institucionalidad.ValidarInstitucionalidad(entId);
            }
            catch (Exception ex)
            { throw ex; }
            return validar;
        }
        public static void Grabar(decimal entId,
                                    bool? entCreadaLegalmente,
                                    string entNombreDirector,
                                    DateTime? entFechaNacimientoDirector,
                                    string entCelularDirector,
                                    string entCorreoElectronicoDirector,
                                    short? entTipoVinculacionDirector,
                                    string entEntidadContratanteDirector,
                                    short entCantidadDocentesVoluntarios,
                                    short entCantidadDocentesPrestacionServicios,
                                    short entCantidadDocentesHonorarios,
                                    short entCantidadDocentesNomina,
                                    short entCantidadDocentesVinculados,
                                    short entCantidadDocentesNivelPrimaria,
                                    short entCantidadDocentesNivelSecundaria,
                                    short entCantidadDocentesNivelTecnico,
                                    short entCantidadDocentesNivelUniversitario,
                                    short entCantidadDocentesNivelPregadoMusica,
                                    short entCantidadDocentesNivelPregadoOtraArea,
                                    short entCantidadDocentesNivelPostgrado,
                                    short entCantidadDocentesNivelEducativo,
                                    bool entCuentaApoyoAdministrativo,
                                    short entCantidadApoyoVoluntario,
                                    short entCantidadApoyoPrestacionServicios,
                                    short entCantidadApoyoHonorarios,
                                    short entCantidadApoyoNomina,
                                    bool entIncluyeActividadMusical,
                                    string Naturaleza,
                                    int dependeEntidad,
                                    string entEntidadDepende,
                                    int NivelDepende,
                                    string strRegimen,
                                    string strSubregimen,
                                    int SimusUsuarioId,
                                    string NombreUsuario,
                                    string strIP,
                                    string Operaentidad,
                                     List<string> practicamusicalPNMCselecionadas)
        {
            try
            {

                bool validar = Institucionalidad.ValidarInstitucionalidad(entId);
                string strDependeEntidad = "N";
                if (dependeEntidad == 1)
                    strDependeEntidad = "S";
                if (!validar)
                {
                    Institucionalidad.Insertar(entId,
                                               entCreadaLegalmente,
                                                true,
                                                entNombreDirector,
                                                entFechaNacimientoDirector,
                                                entCelularDirector,
                                                entCorreoElectronicoDirector,
                                                entTipoVinculacionDirector,
                                                entEntidadContratanteDirector,
                                                entCantidadDocentesVoluntarios,
                                                entCantidadDocentesPrestacionServicios,
                                                entCantidadDocentesHonorarios,
                                                entCantidadDocentesNomina,
                                                entCantidadDocentesVinculados,
                                                entCantidadDocentesNivelPrimaria,
                                                entCantidadDocentesNivelSecundaria,
                                                entCantidadDocentesNivelTecnico,
                                                entCantidadDocentesNivelUniversitario,
                                                entCantidadDocentesNivelPregadoMusica,
                                                entCantidadDocentesNivelPregadoOtraArea,
                                                entCantidadDocentesNivelPostgrado,
                                                entCantidadDocentesNivelEducativo,
                                                entCuentaApoyoAdministrativo,
                                                entCantidadApoyoVoluntario,
                                                entCantidadApoyoPrestacionServicios,
                                                entCantidadApoyoHonorarios,
                                                entCantidadApoyoNomina,
                                                entIncluyeActividadMusical,
                                                Naturaleza,
                                                strDependeEntidad,
                                                entEntidadDepende,
                                                NivelDepende,
                                                strRegimen,
                                                strSubregimen,
                                                SimusUsuarioId,
                                                NombreUsuario,
                                                strIP);

                }
                else
                {
                    Institucionalidad.Actualizar(entId,
                                               entCreadaLegalmente,
                                                true,
                                                entNombreDirector,
                                                entFechaNacimientoDirector,
                                                entCelularDirector,
                                                entCorreoElectronicoDirector,
                                                entTipoVinculacionDirector,
                                                entEntidadContratanteDirector,
                                                entCantidadDocentesVoluntarios,
                                                entCantidadDocentesPrestacionServicios,
                                                entCantidadDocentesHonorarios,
                                                entCantidadDocentesNomina,
                                                entCantidadDocentesVinculados,
                                                entCantidadDocentesNivelPrimaria,
                                                entCantidadDocentesNivelSecundaria,
                                                entCantidadDocentesNivelTecnico,
                                                entCantidadDocentesNivelUniversitario,
                                                entCantidadDocentesNivelPregadoMusica,
                                                entCantidadDocentesNivelPregadoOtraArea,
                                                entCantidadDocentesNivelPostgrado,
                                                entCantidadDocentesNivelEducativo,
                                                entCuentaApoyoAdministrativo,
                                                entCantidadApoyoVoluntario,
                                                entCantidadApoyoPrestacionServicios,
                                                entCantidadApoyoHonorarios,
                                                entCantidadApoyoNomina,
                                                entIncluyeActividadMusical,
                                                Naturaleza,
                                                strDependeEntidad,
                                                entEntidadDepende,
                                                NivelDepende,
                                                strRegimen,
                                                strSubregimen,
                                                SimusUsuarioId,
                                                NombreUsuario,
                                                strIP);


                }

                if (practicamusicalPNMCselecionadas != null && practicamusicalPNMCselecionadas.Count > 0)
                {
                    Institucionalidad.EliminarPracticaMusicalPNMC(entId);
                    Institucionalidad.ActualizarPracticasMusicalesPNMC(entId, practicamusicalPNMCselecionadas);
                }

                if (!String.IsNullOrEmpty(Operaentidad))
                {
                    Institucionalidad.ActaulizarOperaEntidad(entId, Operaentidad);
                }
              
            }
            catch (Exception ex)
            { throw ex; }
        }

        public static void CrearDocumentoEscuelas(decimal escuelaId, int DocumentoId, string nombredocumento, string fechadocumento, string tipodocumentoId, string numeroDocumento)
        {
            try
            {

                DateTime datFecha = DateTime.Today;
                if (!string.IsNullOrEmpty(fechadocumento))
                    datFecha = Convert.ToDateTime(fechadocumento);

                short shortTipo = Convert.ToInt16(tipodocumentoId);

                Institucionalidad.creardocumentoEscuelas(escuelaId, DocumentoId, nombredocumento, datFecha, shortTipo, numeroDocumento);
            }
            catch (Exception ex)
            { throw ex; }

        }


        #endregion

        # region Consultar
        public static InstitucionalidadDTO ConsultarInstitucionalidadPorId(decimal EscuelaId)
        {
            try
            {
                var result = new List<InstitucionalidadDTO>();
                var model = new ART_MUSICA_ENTIDAD_INSTITUCIONALIDAD();
                var modelNaturaleza = new List<ART_ME_ART_ENTIDAD_NATURALEZA_JURIDICA_ObtenerPorId_Result>();
                var modelDocumento = new ART_MUS_TIP_DOC_CRE_ENT_INSTITUC();
                model = Institucionalidad.ObtenerInstitucionalidad(EscuelaId);
                modelNaturaleza = Institucionalidad.ConsultarNaturalezaJuridicaPorId(EscuelaId);
                modelDocumento = Institucionalidad.ObtenerDocumentoEscuelas(EscuelaId);
                InstitucionalidadDTO datos = new InstitucionalidadDTO();
                datos.DependeEntidad = 2;
                if (model != null)
                {
                    datos.ENT_CANTIDAD_APOYO_HONORARIOS = model.ENT_CANTIDAD_APOYO_HONORARIOS ?? 0;
                    datos.ENT_CANTIDAD_APOYO_NOMINA = model.ENT_CANTIDAD_APOYO_NOMINA ?? 0;
                    datos.ENT_CANTIDAD_APOYO_PRESTACION_SERVICIOS = model.ENT_CANTIDAD_APOYO_PRESTACION_SERVICIOS ?? 0;
                    datos.ENT_CANTIDAD_APOYO_VOLUNTARIO = model.ENT_CANTIDAD_APOYO_VOLUNTARIO ?? 0;
                    datos.ENT_CANTIDAD_DOCENTES_HONORARIOS = model.ENT_CANTIDAD_DOCENTES_HONORARIOS ?? 0;
                    datos.ENT_CANTIDAD_DOCENTES_NIVEL_PRIMARIA = model.ENT_CANTIDAD_DOCENTES_NIVEL_PRIMARIA ?? 0;
                    datos.ENT_CANTIDAD_DOCENTES_NIVEL_SECUNDARIA = model.ENT_CANTIDAD_DOCENTES_NIVEL_SECUNDARIA ?? 0;
                    datos.ENT_CANTIDAD_DOCENTES_NIVEL_TECNICO = model.ENT_CANTIDAD_DOCENTES_NIVEL_TECNICO ?? 0;
                    datos.ENT_CANTIDAD_DOCENTES_NOMINA = model.ENT_CANTIDAD_DOCENTES_NOMINA ?? 0;
                    datos.ENT_CANTIDAD_DOCENTES_POSTGRADO = model.ENT_CANTIDAD_DOCENTES_POSTGRADO ?? 0;
                    datos.ENT_CANTIDAD_DOCENTES_PREGRADO_MUSICA = model.ENT_CANTIDAD_DOCENTES_PREGRADO_MUSICA ?? 0;
                    datos.ENT_CANTIDAD_DOCENTES_PREGRADO_OTRA_AREA = model.ENT_CANTIDAD_DOCENTES_PREGRADO_OTRA_AREA ?? 0;
                    datos.ENT_CANTIDAD_DOCENTES_PRESTACION_SERVICIOS = model.ENT_CANTIDAD_DOCENTES_PRESTACION_SERVICIOS ?? 0;
                    datos.ENT_CANTIDAD_DOCENTES_UNIVERSITARIO = model.ENT_CANTIDAD_DOCENTES_UNIVERSITARIO ?? 0;
                    datos.ENT_CANTIDAD_DOCENTES_VOLUNTARIOS = model.ENT_CANTIDAD_DOCENTES_VOLUNTARIOS ?? 0;
                    datos.ENT_CANTIDAD_TOTAL_DOCENTES_NIVEL_EDUCATIVO = model.ENT_CANTIDAD_TOTAL_DOCENTES_NIVEL_EDUCATIVO ?? 0;
                    datos.ENT_CANTIDAD_TOTAL_DOCENTES_VINCULADOS = model.ENT_CANTIDAD_TOTAL_DOCENTES_VINCULADOS ?? 0;
                    datos.ENT_CELULAR_DIRECTOR = model.ENT_CELULAR_DIRECTOR;
                    datos.ENT_CORREO_ELECTRONICO_DIRECTOR = model.ENT_CELULAR_DIRECTOR;
                    datos.ENT_CORREO_ELECTRONICO_DIRECTOR = model.ENT_CORREO_ELECTRONICO_DIRECTOR;
                    datos.ENT_CREADA_LEGALMENTE = model.ENT_CREADA_LEGALMENTE;
                    datos.ENT_CUENTA_APOYO_ADMINISTRATIVO = model.ENT_CUENTA_APOYO_ADMINISTRATIVO;
                    datos.ENT_ENTIDAD_CONTRATANTE = model.ENT_ENTIDAD_CONTRATANTE;
                    datos.ENT_FECHA_NACIMIENTO_DIRECTOR = model.ENT_FECHA_NACIMIENTO_DIRECTOR;
                    datos.ENT_ID = model.ENT_ID;
                    datos.ENT_INCLUYE_ACTIVIDAD_MUSICAL = model.ENT_INCLUYE_ACTIVIDAD_MUSICAL;
                    datos.ENT_NOMBRES_DIRECTOR = model.ENT_NOMBRES_DIRECTOR;
                    datos.ENT_TIENE_DIRECTOR = model.ENT_TIENE_DIRECTOR;
                    datos.ENT_TIPO_VINCULACION_DIRECTOR = model.ENT_TIPO_VINCULACION_DIRECTOR ?? 0;
                    datos.ENT_PLAN_DESARROLLO = model.ENT_PLAN_DESARROLLO;
                    if (model.ENT_OPERA != null)
                        datos.OperaEntidad = Convert.ToString(model.ENT_OPERA);
                    else
                        datos.OperaEntidad = "";

                }


                if (modelNaturaleza.Count > 0)
                {
                    datos.Naturaleza = modelNaturaleza[0].ENT_NATURALEZA;
                    datos.Regimen = modelNaturaleza[0].ENT_OTRO_REGIMEN;
                    datos.SubRegimen = modelNaturaleza[0].ENT_OTRO_SUBREGIMEN;
                    datos.EntidadDepende = modelNaturaleza[0].ENT_DEPENDE;
                    if (modelNaturaleza[0].ENT_SINO_ENTIDAD == "S")
                        datos.DependeEntidad = 1;
                    else
                        datos.DependeEntidad = 2;
                    datos.NivelEntidad = modelNaturaleza[0].ENT_NIVEL_ENTIDAD_DEPENDE ?? 0;
                }

                if (modelDocumento != null)
                {
                    datos.DocumentoId = modelDocumento.DocumentoId ?? 0;
                    datos.FechaDocumentoCreacion = modelDocumento.ART_MUS_TIP_DOC_CRE_FECHA_DOC.ToString("yyyy-MM-dd");
                    datos.NumeroDocumentoCreacion = modelDocumento.ART_MUS_TIP_DOC_CRE_NUMERO_DOC;
                    datos.TipoDocumentoCreacion = modelDocumento.ART_MUS_TIP_DOC_CRE_ID.ToString();
                }

                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<InstitucionalidadDTO> ConsultarInstitucionalidadTodos()
        {
            try
            {
                var model = new List<ART_ME_ART_MUSICA_ENTIDAD_INSTITUCIONALIDAD_ObtenerTodos_Result>();
                var result = new List<InstitucionalidadDTO>();
                model = Institucionalidad.ConsultarInstitucionalidadTodos();

                foreach (var item in model)
                {
                    InstitucionalidadDTO datos = new InstitucionalidadDTO();
                    datos.ENT_CANTIDAD_APOYO_HONORARIOS = item.ENT_CANTIDAD_APOYO_HONORARIOS ?? 0;
                    datos.ENT_CANTIDAD_APOYO_NOMINA = item.ENT_CANTIDAD_APOYO_HONORARIOS ?? 0;
                    datos.ENT_CANTIDAD_APOYO_PRESTACION_SERVICIOS = item.ENT_CANTIDAD_APOYO_HONORARIOS ?? 0;
                    datos.ENT_CANTIDAD_APOYO_VOLUNTARIO = item.ENT_CANTIDAD_APOYO_HONORARIOS ?? 0;
                    datos.ENT_CANTIDAD_DOCENTES_HONORARIOS = item.ENT_CANTIDAD_APOYO_HONORARIOS ?? 0;
                    datos.ENT_CANTIDAD_DOCENTES_NIVEL_PRIMARIA = item.ENT_CANTIDAD_DOCENTES_NIVEL_PRIMARIA ?? 0;
                    datos.ENT_CANTIDAD_DOCENTES_NIVEL_SECUNDARIA = item.ENT_CANTIDAD_DOCENTES_NIVEL_SECUNDARIA ?? 0;
                    datos.ENT_CANTIDAD_DOCENTES_NIVEL_TECNICO = item.ENT_CANTIDAD_DOCENTES_NIVEL_TECNICO ?? 0;
                    datos.ENT_CANTIDAD_DOCENTES_NOMINA = item.ENT_CANTIDAD_DOCENTES_NOMINA ?? 0;
                    datos.ENT_CANTIDAD_DOCENTES_POSTGRADO = item.ENT_CANTIDAD_DOCENTES_POSTGRADO ?? 0;
                    datos.ENT_CANTIDAD_DOCENTES_PREGRADO_MUSICA = item.ENT_CANTIDAD_DOCENTES_PREGRADO_MUSICA ?? 0;
                    datos.ENT_CANTIDAD_DOCENTES_PREGRADO_OTRA_AREA = item.ENT_CANTIDAD_DOCENTES_PREGRADO_OTRA_AREA ?? 0;
                    datos.ENT_CANTIDAD_DOCENTES_PRESTACION_SERVICIOS = item.ENT_CANTIDAD_DOCENTES_PRESTACION_SERVICIOS ?? 0;
                    datos.ENT_CANTIDAD_DOCENTES_UNIVERSITARIO = item.ENT_CANTIDAD_DOCENTES_UNIVERSITARIO ?? 0;
                    datos.ENT_CANTIDAD_DOCENTES_VOLUNTARIOS = item.ENT_CANTIDAD_DOCENTES_VOLUNTARIOS ?? 0;
                    datos.ENT_CANTIDAD_TOTAL_DOCENTES_NIVEL_EDUCATIVO = item.ENT_CANTIDAD_TOTAL_DOCENTES_NIVEL_EDUCATIVO ?? 0;
                    datos.ENT_CANTIDAD_TOTAL_DOCENTES_VINCULADOS = item.ENT_CANTIDAD_TOTAL_DOCENTES_VINCULADOS ?? 0;
                    datos.ENT_CELULAR_DIRECTOR = item.ENT_CELULAR_DIRECTOR;
                    datos.ENT_CORREO_ELECTRONICO_DIRECTOR = item.ENT_CELULAR_DIRECTOR;
                    datos.ENT_CORREO_ELECTRONICO_DIRECTOR = item.ENT_CORREO_ELECTRONICO_DIRECTOR;
                    datos.ENT_CREADA_LEGALMENTE = item.ENT_CREADA_LEGALMENTE;
                    datos.ENT_CUENTA_APOYO_ADMINISTRATIVO = item.ENT_CUENTA_APOYO_ADMINISTRATIVO;
                    datos.ENT_ENTIDAD_CONTRATANTE = item.ENT_ENTIDAD_CONTRATANTE;
                    datos.ENT_FECHA_NACIMIENTO_DIRECTOR = item.ENT_FECHA_NACIMIENTO_DIRECTOR;
                    datos.ENT_ID = item.ENT_ID;
                    datos.ENT_INCLUYE_ACTIVIDAD_MUSICAL = item.ENT_INCLUYE_ACTIVIDAD_MUSICAL;
                    datos.ENT_NOMBRES_DIRECTOR = item.ENT_NOMBRES_DIRECTOR;
                    datos.ENT_TIENE_DIRECTOR = item.ENT_TIENE_DIRECTOR;
                    datos.ENT_TIPO_VINCULACION_DIRECTOR = item.ENT_TIPO_VINCULACION_DIRECTOR ?? 0;
                    result.Add(datos);

                }

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<BasicaDTO> ObtenerTipoDocumentoCreacion()
        {
            try
            {
                var model = new List<TipoDocumentoDTO>();
                var result = new List<BasicaDTO>();
                model = Institucionalidad.ObtenerTipoDocumentoCreacion();

                foreach (var item in model)
                {
                    BasicaDTO datos = new BasicaDTO();
                    datos.text = item.ART_MUS_TIP_DOC_CRE_DESCRPICION;
                    datos.value = item.ART_MUS_TIP_DOC_CRE_ID.ToString();
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
