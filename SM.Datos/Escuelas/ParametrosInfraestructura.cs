using SM.SIPA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Datos.Escuelas
{
    public class ParametrosInfraestructura
    {
        #region FuentesDotación
        #region Actualización
        public static void InsertarFuentesDotacion(decimal entId, short artMusicaFuentesDotacionId)
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    context.ART_ME_ART_MUSICA_ENT_INFR_FUENTES_DOTACION_Insertar(entId,
                                                                             artMusicaFuentesDotacionId);
                                                                         
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
                    context.SaveChanges();
                }

            }
            catch (Exception)
            { throw; }

        }
        #endregion

        #region Consultas
        public static List<ART_ME_ART_MUSICA_ENT_INFR_FUENTES_DOTACION_ObtenerPorENT_ID_Result> ConsultarFuentesDotacionPorId(decimal EntId)
        {
            try
            {
                var model = new List<ART_ME_ART_MUSICA_ENT_INFR_FUENTES_DOTACION_ObtenerPorENT_ID_Result>();
                using (var context = new SIPAEntities())
                {

                    model = context.ART_ME_ART_MUSICA_ENT_INFR_FUENTES_DOTACION_ObtenerPorENT_ID(EntId).ToList();

                }
                return model;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<ART_ME_ART_MUSICA_FUENTES_DOTACION_ObtenerTodos_Result> ConsultarFuentesDotacionTodos()
        {
            try
            {
                var model = new List<ART_ME_ART_MUSICA_FUENTES_DOTACION_ObtenerTodos_Result>();
                using (var context = new SIPAEntities())
                {

                    model = context.ART_ME_ART_MUSICA_FUENTES_DOTACION_ObtenerTodos().ToList();

                }
                return model;

            }
            catch (Exception)
            {
                throw;
            }
        }
       
        #endregion
        #endregion

        #region MaterialPedagogico
        #region Actualización
        public static void InsertarMaterialPedagogico(decimal entId, short entMusMatPedId)
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    context.ART_ME_ART_MUSICA_ENT_INFR_MATERIAL_PEGAOGICO_Insertar(entId,
                                                                                    entMusMatPedId);

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
                    context.SaveChanges();
                }

            }
            catch (Exception)
            { throw; }

        }
        #endregion

        #region Consultas
        public static List<ART_ME_ART_MUSICA_ENT_INFR_MATERIAL_PEGAOGICO_ObtenerPorENT_ID_Result> ConsultarMaterialPedagogicoPorId(decimal EntId)
        {
            try
            {
                var model = new List<ART_ME_ART_MUSICA_ENT_INFR_MATERIAL_PEGAOGICO_ObtenerPorENT_ID_Result>();
                using (var context = new SIPAEntities())
                {

                    model = context.ART_ME_ART_MUSICA_ENT_INFR_MATERIAL_PEGAOGICO_ObtenerPorENT_ID(EntId).ToList();

                }
                return model;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<ART_ME_ART_MUSICA_MATERIAL_PEDAGOGICO_ObtenerTodos_Result> ConsultarMaterialPedagogicoTodos()
        {
            try
            {
                var model = new List<ART_ME_ART_MUSICA_MATERIAL_PEDAGOGICO_ObtenerTodos_Result>();
                using (var context = new SIPAEntities())
                {

                    model = context.ART_ME_ART_MUSICA_MATERIAL_PEDAGOGICO_ObtenerTodos().ToList();

                }
                return model;

            }
            catch (Exception)
            {
                throw;
            }
        }


        #endregion
        #endregion

        #region NivelFuentesDotación
        #region Actualización
        public static void InsertarNivelFuentesDotacion(decimal entId, short artMusNivFuenDotId)
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    context.ART_ME_ART_MUSICA_ENT_INFR_NIVEL_FUENTES_DOTACION_Insertar(entId,
                                                                                    artMusNivFuenDotId);

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
                    context.SaveChanges();
                }

            }
            catch (Exception)
            { throw; }

        }
        #endregion

        #region Consultas
        public static List<ART_ME_ART_MUSICA_ENT_INFR_NIVEL_FUENTES_DOTACION_ObtenerPorENT_ID_Result> ConsultarNivelFuentesDotacionPorId(decimal EntId)
        {
            try
            {
                var model = new List<ART_ME_ART_MUSICA_ENT_INFR_NIVEL_FUENTES_DOTACION_ObtenerPorENT_ID_Result>();
                using (var context = new SIPAEntities())
                {

                    model = context.ART_ME_ART_MUSICA_ENT_INFR_NIVEL_FUENTES_DOTACION_ObtenerPorENT_ID(EntId).ToList();

                }
                return model;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<ART_ME_ART_MUSICA_NIVEL_FUENTES_DOTACION_ObtenerTodos_Result> ConsultarNivelFuentesDotacionTodos()
        {
            try
            {
                var model = new List<ART_ME_ART_MUSICA_NIVEL_FUENTES_DOTACION_ObtenerTodos_Result>();
                using (var context = new SIPAEntities())
                {

                    model = context.ART_ME_ART_MUSICA_NIVEL_FUENTES_DOTACION_ObtenerTodos().ToList();

                }
                return model;

            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion
        #endregion
    }
}
