using SM.Datos.AuditoriaData;
using SM.Datos.DTO;
using SM.SIPA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Datos.Escuelas
{
    public class Institucionalidad
    {
        #region Actualización
        public static void Insertar(decimal? entId,
                                    bool? entCreadaLegalmente,
                                    bool? entTieneDirector,
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
                                    string entSiNoEntidad,
                                    string entEntidadDepende,
                                    int NivelDepende,
                                    string strRegimen,
                                    string strSubregimen,
                                    int SimusUsuarioId,
                                    string NombreUsuario,
                                    string strIP)
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    string entPersoneriaJuridica = "N";
                    if (entCreadaLegalmente == true)
                        entPersoneriaJuridica = "S";

                    if (entTipoVinculacionDirector == 0)
                        entTipoVinculacionDirector = null;


                    if (strRegimen == "0")
                        strRegimen = String.Empty;

                    if (strSubregimen == "0")
                        strSubregimen = String.Empty;

                    if (Naturaleza == "0")
                        Naturaleza = String.Empty;

                    using (var dbContextTransaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            if (entFechaNacimientoDirector != null)
                            {
                                if ((entFechaNacimientoDirector.Value.Year == 1) || (entFechaNacimientoDirector.Value.Year == 1900))
                                {
                                    entFechaNacimientoDirector = null;
                                }
                            }
                            context.ART_ME_ART_MUSICA_ENTIDAD_INSTITUCIONALIDAD_Insertar(entId,
                                                                                           entCreadaLegalmente,
                                                                                           entTieneDirector,
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
                                                                                           entIncluyeActividadMusical);

                            if (NivelDepende == 0)
                                NivelDepende = 6;

                            var naturaleza = context.ART_ENTIDAD_NATURALEZA_JURIDICA.Where(x => x.ENT_ID == entId).FirstOrDefault();
                            if (naturaleza != null)
                            {
                                context.ART_ME_ART_ENTIDAD_NATURALEZA_JURIDICA_Actualizar(entId,
                                                                                    entPersoneriaJuridica,
                                                                                    string.Empty,
                                                                                    Naturaleza,
                                                                                    string.Empty,
                                                                                    entSiNoEntidad,
                                                                                    entEntidadDepende,
                                                                                    NivelDepende,
                                                                                    strRegimen,
                                                                                    strSubregimen,
                                                                                    string.Empty,
                                                                                    string.Empty,
                                                                                    null,
                                                                                    null,
                                                                                    null);
                            }
                            else
                            {
                                context.ART_ME_ART_ENTIDAD_NATURALEZA_JURIDICA_Insertar(entId,
                                                                                        "N",
                                                                                        string.Empty,
                                                                                        Naturaleza,
                                                                                        string.Empty,
                                                                                        string.Empty,
                                                                                        string.Empty,
                                                                                        NivelDepende,
                                                                                        string.Empty,
                                                                                        string.Empty,
                                                                                        string.Empty,
                                                                                        string.Empty,
                                                                                        null,
                                                                                        null,
                                                                                        null);
                            }


                            dbContextTransaction.Commit();

                            //Auditoria
                            string temp;
                            temp = string.Format("El usuario {0} ({1}) insertó el {2} la  escuela de música - institucionalidad.\nDatos actuales:\n{3} ", NombreUsuario, SimusUsuarioId, DateTime.Now, "ART_MUSICA_ENTIDAD_INSTITUCIONALIDAD");
                            StringBuilder stringBuilder = new StringBuilder();
                            stringBuilder.AppendLine(temp);
                            ART_MUSICA_REGISTRO_OPERACION registroOperacion = new ART_MUSICA_REGISTRO_OPERACION { Categoria = CategoriaRegistroOperacion.EscuelasInstitucionalidad.ToString(), IpUsuario = strIP, RegistroId = Convert.ToInt32(entId), UsuarioId = SimusUsuarioId, NombreUsuario = NombreUsuario, Descripcion = stringBuilder.ToString(), FechaRegistro = DateTime.Now, Operacion = "Actualización" };

                            RegistroOperacionServicio auditoria = new RegistroOperacionServicio();
                            auditoria.Crear(registroOperacion);

                        }
                        catch
                        {
                            dbContextTransaction.Rollback();
                            throw;
                        }
                    }


                }
            }
            catch (Exception)
            { throw; }
        }

        public static void EliminarPracticaMusicalPNMC(decimal EscuelaId)
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    //Ojo preguntar sobre la eliminación
                    context.ART_MUSICA_PRACTICAS_PNMC.RemoveRange(context.ART_MUSICA_PRACTICAS_PNMC.Where(x => x.EscuelaId == EscuelaId));
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        public static void ActualizarPracticasMusicalesPNMC(decimal entId, List<string> practicamusicalselecionadas)
        {
            try
            {
                using (var context = new SIPAEntities())
                {

                    foreach (string item in practicamusicalselecionadas)
                    {
                        ART_MUSICA_PRACTICAS_PNMC entidad = new ART_MUSICA_PRACTICAS_PNMC
                        {
                            PracticaMusicalId = Convert.ToInt16(item),
                            EscuelaId = entId

                        };

                        context.ART_MUSICA_PRACTICAS_PNMC.Add(entidad);

                    }

                    context.SaveChanges();
                }

            }
            catch (Exception)
            { throw; }
        }

        public static void creardocumentoEscuelas(decimal escuelaId, int DocumentoId, string nombredocumento, DateTime fechadocumento, short tipodocumentoId, string numeroDocumento)
        {
            try
            {
               
                using (var context = new SIPAEntities())
                {
                    using (var dbContextTransaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            var documento = context.ART_MUS_TIP_DOC_CRE_ENT_INSTITUC.Where(x => x.ENT_ID == escuelaId).FirstOrDefault();
                            if (documento != null)
                            {
                                documento.ART_MUS_TIP_DOC_CRE_DOCUMENTO = nombredocumento;
                                documento.ART_MUS_TIP_DOC_CRE_FECHA_DOC = fechadocumento;
                                documento.ART_MUS_TIP_DOC_CRE_ID = tipodocumentoId;
                                documento.ART_MUS_TIP_DOC_CRE_NUMERO_DOC = numeroDocumento;
                                if (DocumentoId > 0)
                                    documento.DocumentoId = DocumentoId;

                            }
                            else
                            {
                                if (DocumentoId > 0)
                                {
                                    var entidad = new ART_MUS_TIP_DOC_CRE_ENT_INSTITUC
                                    {
                                        ENT_ID = escuelaId,
                                        DocumentoId = DocumentoId,
                                        ART_MUS_TIP_DOC_CRE_DOCUMENTO = nombredocumento,
                                        ART_MUS_TIP_DOC_CRE_FECHA_DOC = fechadocumento,
                                        ART_MUS_TIP_DOC_CRE_ID = tipodocumentoId,
                                        ART_MUS_TIP_DOC_CRE_NUMERO_DOC = numeroDocumento

                                    };
                                    context.ART_MUS_TIP_DOC_CRE_ENT_INSTITUC.Add(entidad);
                                }
                            }

                            context.SaveChanges();
                            dbContextTransaction.Commit();
                        }
                        catch
                        {
                            dbContextTransaction.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception)
            { throw; }
        }

        public static bool ValidarInstitucionalidad(decimal EntId)
        {
            try
            {
                bool validar = false;
                using (var context = new SIPAEntities())
                {
                    // Ojo esto se valida al crear formación
                    var datos = context.ART_MUSICA_ENTIDAD_INSTITUCIONALIDAD.Where(x => x.ENT_ID == EntId).SingleOrDefault();
                    if (datos != null)
                        validar = true;

                    return validar;
                }
            }
            catch (Exception)
            { throw; }
        }

        public static void ActaulizarOperaEntidad(decimal EntId, string OperaEntidad)
        {
            try
            {

                using (var context = new SIPAEntities())
                {

                    var entidad = context.ART_MUSICA_ENTIDAD_INSTITUCIONALIDAD.Where(x => x.ENT_ID == EntId).SingleOrDefault();
                    if (entidad != null)
                    {
                        entidad.ENT_OPERA = Convert.ToInt32(OperaEntidad);
                    }

                    context.SaveChanges();

                }
            }
            catch (Exception)
            { throw; }
        }

        public static void ActualizarPlanDesarrollo(decimal EntId, bool EsDesarrollo)
        {
            try
            {

                using (var context = new SIPAEntities())
                {

                    var entidad = context.ART_MUSICA_ENTIDAD_INSTITUCIONALIDAD.Where(x => x.ENT_ID == EntId).SingleOrDefault();
                    if (entidad != null)
                    {
                        entidad.ENT_PLAN_DESARROLLO = EsDesarrollo;
                    }

                    context.SaveChanges();
        
                }
            }
            catch (Exception)
            { throw; }
        }
        public static void ValidarFormacion(decimal EntId)
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    // Ojo esto se valida al crear formación
                    var escuela = context.ART_MUSICA_ENTIDAD_FORMACION.Where(x => x.ENT_ID == EntId).SingleOrDefault();

                    if (escuela == null)
                    {
                        ART_MUSICA_ENTIDAD_FORMACION formacion = new ART_MUSICA_ENTIDAD_FORMACION
                        {
                            ENT_ID = EntId,
                            ENT_PRACTICAS_MUSICALES_ORIENTADAS_MUSICO = false,
                            ENT_TALLERES_INDEPENDIENTES = false,
                            ENT_PROGRAMAS_FORMULADOS_ESCRITO = false,
                            ENT_FOMRACION_MUSICAL_PLAN_NAL_MUSICA_CONVIVENCIA = false
                        };

                        context.ART_MUSICA_ENTIDAD_FORMACION.Add(formacion);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception)
            { throw; }
        }


        public static void Actualizar(decimal? entId,
                                        bool? entCreadaLegalmente,
                                        bool entTieneDirector,
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
                                        string entSiNoEntidad,
                                        string entEntidadDepende,
                                        int? NivelDepende,
                                        string strRegimen,
                                        string strSubregimen,
                                        int SimusUsuarioId,
                                        string NombreUsuario,
                                        string strIP)
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    string entPersoneriaJuridica = "N";
                    if (entCreadaLegalmente == true)
                        entPersoneriaJuridica = "S";

                    if (entTipoVinculacionDirector == 0)
                        entTipoVinculacionDirector = null;

                    if (NivelDepende == 0)
                        NivelDepende = null;

                    if (strRegimen == "0")
                        strRegimen = String.Empty;

                    if (strSubregimen == "0")
                        strSubregimen = String.Empty;

                    if (Naturaleza == "0")
                        Naturaleza = String.Empty;

                    if (entFechaNacimientoDirector != null)
                    {
                        if ((entFechaNacimientoDirector.Value.Year == 1) || (entFechaNacimientoDirector.Value.Year == 1900))
                        {
                            entFechaNacimientoDirector = null;
                        }
                    }

                    using (var dbContextTransaction = context.Database.BeginTransaction())
                    {
                        try
                        {

                            context.ART_ME_ART_MUSICA_ENTIDAD_INSTITUCIONALIDAD_Actualizar(entId,
                                                                                             entCreadaLegalmente,
                                                                                             entTieneDirector,
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
                                                                                             entIncluyeActividadMusical);

                            context.ART_ME_ART_ENTIDAD_NATURALEZA_JURIDICA_Actualizar(entId,
                                                                                   entPersoneriaJuridica,
                                                                                   string.Empty,
                                                                                   Naturaleza,
                                                                                   string.Empty,
                                                                                   entSiNoEntidad,
                                                                                   entEntidadDepende,
                                                                                   NivelDepende,
                                                                                   strRegimen,
                                                                                   strSubregimen,
                                                                                   string.Empty,
                                                                                   string.Empty,
                                                                                   null,
                                                                                   null,
                                                                                   null);
                            dbContextTransaction.Commit();

                            //Auditoria
                            string temp;
                            temp = string.Format("El usuario {0} ({1}) actualizó el {2} la  escuela de música - institucionalidad.\nDatos actuales:\n{3} ", NombreUsuario, SimusUsuarioId, DateTime.Now, "ART_MUSICA_ENTIDAD_INSTITUCIONALIDAD");
                            StringBuilder stringBuilder = new StringBuilder();
                            stringBuilder.AppendLine(temp);
                            ART_MUSICA_REGISTRO_OPERACION registroOperacion = new ART_MUSICA_REGISTRO_OPERACION { Categoria = CategoriaRegistroOperacion.EscuelasInstitucionalidad.ToString(), IpUsuario = strIP, RegistroId = Convert.ToInt32(entId), UsuarioId = SimusUsuarioId, NombreUsuario = NombreUsuario, Descripcion = stringBuilder.ToString(), FechaRegistro = DateTime.Now, Operacion = "Actualización" };

                            RegistroOperacionServicio auditoria = new RegistroOperacionServicio();
                            auditoria.Crear(registroOperacion);

                        }
                        catch
                        {
                            dbContextTransaction.Rollback();
                            throw;
                        }
                    }

                }
            }
            catch (Exception)
            { throw; }
        }

        public static void Eliminar(decimal entId)
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    context.ART_ME_ART_MUSICA_ENTIDAD_INSTITUCIONALIDAD_Eliminar(entId);
                    context.SaveChanges();
                }

            }
            catch (Exception)
            { throw; }

        }

        public static void EliminarNaturaleza(decimal entId)
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    context.ART_ME_ART_ENTIDAD_NATURALEZA_JURIDICA_Eliminar(entId);
                    context.SaveChanges();
                }

            }
            catch (Exception)
            { throw; }

        }
        #endregion

        #region Consultas

        public static List<TipoDocumentoDTO> ObtenerTipoDocumentoCreacion()
        {

            List<TipoDocumentoDTO> listEntidad = new List<TipoDocumentoDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {


                    listEntidad = context.Database.SqlQuery<TipoDocumentoDTO>(@"EXEC ART_ME_ART_MUSICA_TIPO_DOCUMENTO_CREACION_ObtenerTodos").ToList();




                }
                return listEntidad;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<ART_ME_ART_MUSICA_ENTIDAD_INSTITUCIONALIDAD_ObtenerPorId_Result> ConsultarInstitucionalidadPorId(decimal EntId)
        {
            try
            {
                var model = new List<ART_ME_ART_MUSICA_ENTIDAD_INSTITUCIONALIDAD_ObtenerPorId_Result>();
                using (var context = new SIPAEntities())
                {

                    model = context.ART_ME_ART_MUSICA_ENTIDAD_INSTITUCIONALIDAD_ObtenerPorId(EntId).ToList();

                }
                return model;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static ART_MUSICA_ENTIDAD_INSTITUCIONALIDAD ObtenerInstitucionalidad(decimal EntId)
        {
            try
            {
                var model = new ART_MUSICA_ENTIDAD_INSTITUCIONALIDAD();
                using (var context = new SIPAEntities())
                {

                    model = context.ART_MUSICA_ENTIDAD_INSTITUCIONALIDAD.Where(X => X.ENT_ID == EntId).FirstOrDefault();

                }
                return model;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<ART_ME_ART_ENTIDAD_NATURALEZA_JURIDICA_ObtenerPorId_Result> ConsultarNaturalezaJuridicaPorId(decimal EntId)
        {
            try
            {
                var model = new List<ART_ME_ART_ENTIDAD_NATURALEZA_JURIDICA_ObtenerPorId_Result>();
                using (var context = new SIPAEntities())
                {

                    model = context.ART_ME_ART_ENTIDAD_NATURALEZA_JURIDICA_ObtenerPorId(EntId).ToList();

                }
                return model;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static ART_MUS_TIP_DOC_CRE_ENT_INSTITUC ObtenerDocumentoEscuelas(decimal EntId)
        {
            try
            {
                var model = new ART_MUS_TIP_DOC_CRE_ENT_INSTITUC();
                using (var context = new SIPAEntities())
                {

                    model = context.ART_MUS_TIP_DOC_CRE_ENT_INSTITUC.Where(x => x.ENT_ID == EntId).FirstOrDefault(); 

                }
                return model;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<ART_ME_ART_MUSICA_ENTIDAD_INSTITUCIONALIDAD_ObtenerTodos_Result> ConsultarInstitucionalidadTodos()
        {
            try
            {
                var model = new List<ART_ME_ART_MUSICA_ENTIDAD_INSTITUCIONALIDAD_ObtenerTodos_Result>();
                using (var context = new SIPAEntities())
                {

                    model = context.ART_ME_ART_MUSICA_ENTIDAD_INSTITUCIONALIDAD_ObtenerTodos().ToList();

                }
                return model;

            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

    }
}
