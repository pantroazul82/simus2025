using SM.SIPA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SM.Datos.DTO;


namespace SM.Datos.Escuelas
{
    public class RedesSociales
    {

        #region VideosYoutube
        public static void EliminarVideo(int VideoId)
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    context.ART_ME_VIDEOS_ESCUELAS.Remove(context.ART_ME_VIDEOS_ESCUELAS.Where(x => x.VID_ID == VideoId).FirstOrDefault());
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void AgregarRedesSociales(decimal entId,
                                               string urlFacebook,
                                               string urlTwitter,
                                               string canalYoutube)
        {
            try
            {
                using (var context = new SIPAEntities())
                {

                    var query = (from entidad in context.ART_ENTIDAD_UBICACION
                                 where entidad.ENT_ID == entId
                                 select entidad).First();

                    if (query != null)
                    {
                        if (!String.IsNullOrEmpty(urlFacebook))
                            query.PERFIL_FACEBOOK = urlFacebook;
                        if (!String.IsNullOrEmpty(urlTwitter))
                            query.PERFIL_TWITTER = urlTwitter;
                        if (!String.IsNullOrEmpty(canalYoutube))
                            query.CANAL_YOUTUBE = canalYoutube;
                        context.SaveChanges();
                    }


                }
            }
            catch (Exception)
            { throw; }
        }

        public static List<ART_ME_VIDEOS_ESCUELAS> ConsultarVideosEscuelas(decimal EscuelaId)
        {
            var listVideo = new List<ART_ME_VIDEOS_ESCUELAS>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    listVideo = context.ART_ME_VIDEOS_ESCUELAS.Where(x => x.ENT_ID == EscuelaId).ToList();
                }

                return listVideo;
            }
            catch (Exception)
            { throw; }
        }

        public static RedesSocialesDTO ConsultarRedesSociales(decimal entId)
        {
            var redes = new RedesSocialesDTO();
            try
            {
                using (var context = new SIPAEntities())
                {

                    redes = (from entidad in context.ART_ENTIDAD_UBICACION
                             where entidad.ENT_ID == entId
                             select new RedesSocialesDTO
                             {
                                 CanalYoutube = entidad.CANAL_YOUTUBE,
                                 Facebook = entidad.PERFIL_FACEBOOK,
                                 Twitter = entidad.PERFIL_TWITTER,
                                 EscuelaId = entidad.ENT_ID
                             }
                                 ).FirstOrDefault();



                    var galeria = (from i in context.ART_ME_IMAGENES_ESCUELAS
                                   where i.ENT_ID == entId
                                   orderby i.IMG_FECHA_PUBLICACION descending
                                   select new
                                   {
                                       i.IMG_ID,
                                       i.IMG_FECHA_PUBLICACION,
                                       i.IMG_DESCRIPCION,
                                       i.IMG_URL
                                   }
                            ).FirstOrDefault();



                    if (galeria != null)
                    {
                        redes.GaleriaId = galeria.IMG_ID;
                        redes.GaleriaFlicker = galeria.IMG_URL;
                        redes.DescripcionFlicker = galeria.IMG_DESCRIPCION;
                    }
                    return redes;

                }
            }
            catch (Exception)
            { throw; }
        }
        public static void AgregarVideoYoutube(ART_ME_VIDEOS_ESCUELAS video)
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    context.ART_ME_VIDEOS_ESCUELAS.Add(video);
                    context.SaveChanges();

                }
            }
            catch (Exception)
            { throw; }
        }

        public static void EliminarVideoYoutube(decimal entId,
                                              decimal videoId)
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    context.ART_ME_ART_ME_VIDEOS_ESCUELAS_Eliminar(entId, videoId);

                }
            }
            catch (Exception)
            { throw; }
        }

        public static void EliminarVideoYoutubePorEscuelaId(decimal entId)
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    context.ART_ME_ART_ME_VIDEOS_ESCUELAS_EliminarPorENT_ID(entId);

                }
            }
            catch (Exception)
            { throw; }
        }

        public static List<ART_ME_ART_ME_VIDEOS_ESCUELAS_ObtenerPorENT_ID_Result> ConsultarVideoYoutube(decimal entId)
        {
            try
            {
                var resultado = new List<ART_ME_ART_ME_VIDEOS_ESCUELAS_ObtenerPorENT_ID_Result>();

                using (var context = new SIPAEntities())
                {
                    resultado = context.ART_ME_ART_ME_VIDEOS_ESCUELAS_ObtenerPorENT_ID(entId).ToList();

                }
                return resultado;
            }
            catch (Exception)
            { throw; }
        }
        #endregion

        #region Galeria
        public static void AgregarGaleria(decimal entId,
                                                string UrlGaleria,
                                                string descripcion)
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    context.ART_ME_ART_ME_IMAGENES_ESCUELAS_Insertar(entId, UrlGaleria, descripcion);

                }
            }
            catch (Exception)
            { throw; }
        }

        public static void EliminarGaleria(decimal entId,
                                              decimal GaleriaId)
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    context.ART_ME_ART_ME_IMAGENES_ESCUELAS_Eliminar(entId, GaleriaId);

                }
            }
            catch (Exception)
            { throw; }
        }

        public static void EliminarGaleria(decimal entId)
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    context.ART_ME_ART_ME_IMAGENES_ESCUELAS_EliminarPorENT_ID(entId);

                }
            }
            catch (Exception)
            { throw; }
        }

        public static List<ART_ME_ART_ME_IMAGENES_ESCUELAS_ObtenerPorENT_ID_Result> ConsultarGaleria(decimal entId)
        {
            try
            {
                var resultado = new List<ART_ME_ART_ME_IMAGENES_ESCUELAS_ObtenerPorENT_ID_Result>();

                using (var context = new SIPAEntities())
                {
                    resultado = context.ART_ME_ART_ME_IMAGENES_ESCUELAS_ObtenerPorENT_ID(entId).ToList();

                }
                return resultado;
            }
            catch (Exception)
            { throw; }
        }
        #endregion
    }
}
