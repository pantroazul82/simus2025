using SM.Datos.AuditoriaData;
using SM.SIPA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Datos.Escuelas
{
    public class Infraestructura
    {

        #region Actualización

        public static void Insertar(decimal entId,
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
                using (var context = new SIPAEntities())
                {

                    using (var dbContextTransaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            context.ART_ME_ART_MUSICA_ENTIDAD_INFRAESTRUCTURA_Insertar(entId,
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
                                                                                         entSedeOtraSolucionAdecAcustic);

                            string strSINOAccesoInternet = "N";
                            decimal? decEspacioId = null;
                            if (tieneAccesoInternet)
                                strSINOAccesoInternet = "S";
                            if (!String.IsNullOrEmpty(EspacioId))
                                if (EspacioId != "0")
                                    decEspacioId = Convert.ToDecimal(EspacioId);

                            context.ART_ME_ART_ENTIDAD_INFRAESTRUCTURA_Insertar(entId,
                                                                                strSINOAccesoInternet,
                                                                                decEspacioId,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                null);
                            dbContextTransaction.Commit();

                            //Auditoria
                            string temp;
                            temp = string.Format("El usuario {0} ({1}) insertó el {2} la  escuela de música - infraestructura.\nDatos actuales:\n{3} ", NombreUsuario, SimusUsuarioId, DateTime.Now, "ART_MUSICA_ENTIDAD_INFRAESTRUCTURA");
                            StringBuilder stringBuilder = new StringBuilder();
                            stringBuilder.AppendLine(temp);
                            ART_MUSICA_REGISTRO_OPERACION registroOperacion = new ART_MUSICA_REGISTRO_OPERACION { Categoria = CategoriaRegistroOperacion.EscuelasInfraestructura.ToString(), IpUsuario = strIP, RegistroId = Convert.ToInt32(entId), UsuarioId = SimusUsuarioId, NombreUsuario = NombreUsuario, Descripcion = stringBuilder.ToString(), FechaRegistro = DateTime.Now, Operacion = "Actualización" };

                            RegistroOperacionServicio auditoria = new RegistroOperacionServicio();
                            auditoria.Crear(registroOperacion);

                        }
                        catch
                        { dbContextTransaction.Rollback(); }
                    }
                    if (tieneAccesoInternet)
                    {
                        if (TiposInternet != null)
                            ActutalizarTiposInternet(entId,  TiposInternet);
                    }

                    if (FuentesDotacion != null)
                        ActutalizarFuentesDotacion(entId, FuentesDotacion);
                    if (NivelesFuentesDotacion != null)
                        ActutalizarNivelFuentesDotacion(entId, NivelesFuentesDotacion);
                    if (MaterialPedagogico != null)
                        ActualizarMaterialPedagogico(entId, MaterialPedagogico);
                    if (soluciones != null)
                        ActualizarSolucionesAcusticas(entId, soluciones);


                }
            }
            catch (Exception)
            { throw; }
        }



        public static bool ValidarInfraestructura(decimal EntId)
        {
            try
            {
                bool Validar = false;
                using (var context = new SIPAEntities())
                {
                    // Ojo esto se valida al crear formación
                    var datos = context.ART_MUSICA_ENTIDAD_INFRAESTRUCTURA.Where(x => x.ENT_ID == EntId).SingleOrDefault();
                    if (datos != null)
                        Validar = true;

                    return Validar;
                }
            }
            catch (Exception)
            { throw; }
        }
        public static void Actualizar(decimal entId,
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
                using (var context = new SIPAEntities())
                {
                    using (var dbContextTransaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            context.ART_ME_ART_MUSICA_ENTIDAD_INFRAESTRUCTURA_Actualizar(entId,
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
                                                                                         entSedeOtraSolucionAdecAcustic);

                            string strSINOAccesoInternet = "N";
                            decimal? decEspacioId = null;
                            if (tieneAccesoInternet)
                                strSINOAccesoInternet = "S";
                            if (!String.IsNullOrEmpty(EspacioId))
                                if (EspacioId != "0")
                                    decEspacioId = Convert.ToDecimal(EspacioId);

                            context.ART_ME_ART_ENTIDAD_INFRAESTRUCTURA_Actualizar(entId,
                                                                                strSINOAccesoInternet,
                                                                                decEspacioId);
                                                                              

                            dbContextTransaction.Commit();

                            //Auditoria
                            string temp;
                            temp = string.Format("El usuario {0} ({1}) actualizó el {2} la  escuela de música - infraestructura.\nDatos actuales:\n{3} ", NombreUsuario, SimusUsuarioId, DateTime.Now, "ART_MUSICA_ENTIDAD_INFRAESTRUCTURA");
                            StringBuilder stringBuilder = new StringBuilder();
                            stringBuilder.AppendLine(temp);
                            ART_MUSICA_REGISTRO_OPERACION registroOperacion = new ART_MUSICA_REGISTRO_OPERACION { Categoria = CategoriaRegistroOperacion.EscuelasInfraestructura.ToString(), IpUsuario = strIP, RegistroId = Convert.ToInt32(entId), UsuarioId = SimusUsuarioId, NombreUsuario = NombreUsuario, Descripcion = stringBuilder.ToString(), FechaRegistro = DateTime.Now, Operacion = "Actualización" };

                            RegistroOperacionServicio auditoria = new RegistroOperacionServicio();
                            auditoria.Crear(registroOperacion);

                        }
                        catch
                        { dbContextTransaction.Rollback(); }
                    }

                    if (TiposInternet != null)
                    {
                        EliminarTiposInternet(entId);
                        ActutalizarTiposInternet(entId, TiposInternet);
                    }
                    if (FuentesDotacion != null)
                    {
                        EliminarFuentesDotacion(entId);
                        ActutalizarFuentesDotacion(entId, FuentesDotacion);
                    }
                    if (NivelesFuentesDotacion != null)
                    {
                        EliminarNivelFuentesDotacion(entId);
                        ActutalizarNivelFuentesDotacion(entId, NivelesFuentesDotacion);
                    }
                    if (MaterialPedagogico != null)
                    {
                        EliminarMaterialPedagogico(entId);
                        ActualizarMaterialPedagogico(entId, MaterialPedagogico);
                    }
                    if (soluciones != null)
                    {
                        EliminarSolucionesAcusticas(entId);
                        ActualizarSolucionesAcusticas(entId, soluciones);
                    }
                }
            }
            catch (Exception)
            { throw; }
        }

        public static void ActutalizarTiposInternet(decimal entId, string[] TiposInternet)
        {
            try
            {
                using (var context = new SIPAEntities())
                {

                    foreach (string item in TiposInternet)
                    {
                        ART_MUSICA_ENTIDAD_TIPOS_INTERNET internet = new ART_MUSICA_ENTIDAD_TIPOS_INTERNET() { ENT_ID = entId, TIPOS_INTERNET_ID = Convert.ToInt32(item) };
                        context.ART_MUSICA_ENTIDAD_TIPOS_INTERNET.Add(internet);
                    }
                    context.SaveChanges();
                }

            }
            catch (Exception)
            { throw; }
        }

        public static void EliminarTiposInternet(decimal entId)
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    var internet = context.ART_MUSICA_ENTIDAD_TIPOS_INTERNET.Where(x => x.ENT_ID == entId).FirstOrDefault();
                    if (internet != null)
                    {
                        context.ART_MUSICA_ENTIDAD_TIPOS_INTERNET.Remove(internet);
                        context.SaveChanges();
                    }

                }

            }
            catch (Exception)
            { throw; }
        }

        public static void ActualizarSolucionesAcusticas(decimal entId, string[] solucionesAcusticas)
        {
            try
            {
                using (var context = new SIPAEntities())
                {

                    foreach (string item in solucionesAcusticas)
                    {
                        context.ART_ME_ART_ME_ESCUELA_SOLUCIONES_ACUSTICAS_Insertar(entId, Convert.ToDecimal(item));
                    }

                }

            }
            catch (Exception)
            { throw; }
        }

        public static void EliminarSolucionesAcusticas(decimal entId)
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    context.ART_ME_ART_ME_ESCUELA_SOLUCIONES_ACUSTICAS_Eliminar(entId);

                }

            }
            catch (Exception)
            { throw; }
        }
        public static void ActutalizarFuentesDotacion(decimal entId, string[] Fuentesdotacion)
        {
            try
            {
                using (var context = new SIPAEntities())
                {

                    foreach (string item in Fuentesdotacion)
                    {
                        context.ART_ME_ART_MUSICA_ENT_INFR_FUENTES_DOTACION_Insertar(entId, Convert.ToInt16(item));
                    }

                }

            }
            catch (Exception)
            { throw; }
        }

        public static void EliminarFuentesDotacion(decimal entId)
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    context.ART_ME_ART_MUSICA_ENT_INFR_FUENTES_DOTACION_EliminarPorENT_ID(entId);

                }

            }
            catch (Exception)
            { throw; }
        }

        public static void ActutalizarNivelFuentesDotacion(decimal entId, string[] NivelFuentesDotacion)
        {
            try
            {
                using (var context = new SIPAEntities())
                {

                    foreach (string item in NivelFuentesDotacion)
                    {
                        context.ART_ME_ART_MUSICA_ENT_INFR_NIVEL_FUENTES_DOTACION_Insertar(entId, Convert.ToInt16(item));
                    }

                }

            }
            catch (Exception)
            { throw; }
        }
        public static void EliminarNivelFuentesDotacion(decimal entId)
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    context.ART_ME_ART_MUSICA_ENT_INFR_NIVEL_FUENTES_DOTACION_EliminarPorENT_ID(entId);

                }

            }
            catch (Exception)
            { throw; }
        }

        public static void ActualizarMaterialPedagogico(decimal entId, string[] MaterialPedagogico)
        {
            try
            {
                using (var context = new SIPAEntities())
                {

                    foreach (string item in MaterialPedagogico)
                    {
                        context.ART_ME_ART_MUSICA_ENT_INFR_MATERIAL_PEGAOGICO_Insertar(entId, Convert.ToInt16(item));
                    }

                }

            }
            catch (Exception)
            { throw; }
        }
        public static void EliminarMaterialPedagogico(decimal entId)
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    context.ART_ME_ART_MUSICA_ENT_INFR_MATERIAL_PEGAOGICO_EliminarPorENT_ID(entId);

                }

            }
            catch (Exception)
            { throw; }
        }
        public static void Eliminar(decimal entId)
        {
            try
            {
                EliminarFuentesDotacion(entId);
                EliminarMaterialPedagogico(entId);
                EliminarNivelFuentesDotacion(entId);
                EliminarSolucionesAcusticas(entId);
                EliminarTiposInternet(entId);
                using (var context = new SIPAEntities())
                {
                    context.ART_ME_ART_MUSICA_ENTIDAD_INFRAESTRUCTURA_Eliminar(entId);
                    context.ART_ME_ART_ENTIDAD_INFRAESTRUCTURA_Eliminar(entId);
                  
                }

            }
            catch (Exception)
            { throw; }

        }

       
        #endregion

        #region Consultas
        public static List<ART_ME_ART_MUSICA_ENTIDAD_INFRAESTRUCTURA_ObtenerPorId_Result> ConsultarInfraestructuraPorId(decimal EntId)
        {
            try
            {
                var model = new List<ART_ME_ART_MUSICA_ENTIDAD_INFRAESTRUCTURA_ObtenerPorId_Result>();
                using (var context = new SIPAEntities())
                {

                    model = context.ART_ME_ART_MUSICA_ENTIDAD_INFRAESTRUCTURA_ObtenerPorId(EntId).ToList();

                }
                return model;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<ART_ME_ART_ENTIDAD_INFRAESTRUCTURA_ObtenerPorId_Result> ConsultarInfraestructuraEntidadPorId(decimal EntId)
        {
            try
            {
                var model = new List<ART_ME_ART_ENTIDAD_INFRAESTRUCTURA_ObtenerPorId_Result>();
                using (var context = new SIPAEntities())
                {

                    model = context.ART_ME_ART_ENTIDAD_INFRAESTRUCTURA_ObtenerPorId(EntId).ToList();

                }
                return model;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<ART_ME_ART_MUSICA_ENTIDAD_INFRAESTRUCTURA_ObtenerTodos_Result> ConsultarInfraestructuraTodos()
        {
            try
            {
                var model = new List<ART_ME_ART_MUSICA_ENTIDAD_INFRAESTRUCTURA_ObtenerTodos_Result>();
                using (var context = new SIPAEntities())
                {

                    model = context.ART_ME_ART_MUSICA_ENTIDAD_INFRAESTRUCTURA_ObtenerTodos().ToList();

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
