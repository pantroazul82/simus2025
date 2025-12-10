using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SM.Datos.Escuelas;
using SM.SIPA;
using SM.LibreriaComun.DTO;
using SM.Datos.DTO;

namespace SM.Aplicacion.Escuelas
{
    public class RedesLogica
    {
        public static List<EscuelaVideoDTO> ConsultarListadoVideos(decimal EscuelaId)
        {
            try
            {
                var listVideo = new List<ART_ME_VIDEOS_ESCUELAS>();
                var listVideoResultado = new List<EscuelaVideoDTO>();
                listVideo = RedesSociales.ConsultarVideosEscuelas(EscuelaId);
                foreach (var item in listVideo)
                {
                    var datos = new EscuelaVideoDTO();
                    datos.Id = (int)item.VID_ID;
                    datos.clasificacion = item.VID_CLASIFICACION;
                    datos.Descripcion = item.VID_DESCRIPCION;
                    datos.EscuelaId = item.ENT_ID;
                    datos.urlvideoYoutube = item.VID_URL;
                    datos.FechaPublicacion = item.VID_FECHA_PUBLICACION.ToString("yyyy-MM-dd");
                    listVideoResultado.Add(datos);
                }

                return listVideoResultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static RedesDTO ConsultarRedesPorId(decimal EscuelaId)
        {
            try
            {
                var result = new RedesDTO();
                var model = new RedesSocialesDTO();
                var listVideo = new List<ART_ME_VIDEOS_ESCUELAS>();
                var listVideoResultado = new List<EscuelaVideoDTO>();
                model = RedesSociales.ConsultarRedesSociales(EscuelaId);
                //listVideo = RedesSociales.ConsultarVideosEscuelas(EscuelaId);
     
           
                //foreach (var item in listVideo)
                //{
                //    var datos = new EscuelaVideoDTO();
                //    datos.Id = (int) item.VID_ID;
                //    datos.clasificacion = item.VID_CLASIFICACION;
                //    datos.Descripcion = item.VID_DESCRIPCION;
                //    datos.EscuelaId = item.ENT_ID;
                //    datos.urlvideoYoutube = item.VID_URL;
                //    datos.FechaPublicacion = item.VID_FECHA_PUBLICACION.ToString("yyyy-MM-dd");
                //    listVideoResultado.Add(datos); 
                //}

                if (model != null)
                {
                    result.CanalYoutube = model.CanalYoutube;
                    result.DescripcionFlicker = model.DescripcionFlicker;
                    result.EscuelaId = model.EscuelaId;
                    result.Facebook = model.Facebook;
                    result.GaleriaFlicker = model.GaleriaFlicker;
                    result.GaleriaId = model.GaleriaId;
                    result.Twitter = model.Twitter;
                    result.listVIdeo = listVideoResultado;

                }


                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void AgregarRedes(decimal EscuelaId,
                                        string urlFacebook,
                                        string urlTwitter,
                                        string canalYoutube,
                                        decimal? VideoId,
                                        decimal? GaleriaId, 
                                        string Galeria,
                                        string descripcionGaleria)
        {
            try
            {
                RedesSociales.AgregarRedesSociales(EscuelaId, urlFacebook, urlTwitter, canalYoutube);

               
                if (VideoId > 0)
                   RedesSociales.EliminarVideoYoutube(EscuelaId, (decimal)VideoId);
               

                if (!String.IsNullOrEmpty(Galeria))
                {
                    RedesSociales.AgregarGaleria(EscuelaId, Galeria, descripcionGaleria);
                }
                if (GaleriaId > 0)
                    RedesSociales.EliminarGaleria(EscuelaId, (decimal)GaleriaId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void AgregarVídeo(EscuelaVideoDTO datos)
        {
            try
            {
                var redes = new ART_ME_VIDEOS_ESCUELAS
                {
                    ENT_ID = datos.EscuelaId,
                    VID_CLASIFICACION = datos.clasificacion,
                    VID_DESCRIPCION = datos.Descripcion,
                    VID_URL = datos.urlvideoYoutube,
                    VID_FECHA_PUBLICACION = DateTime.Now,
                };

                RedesSociales.AgregarVideoYoutube(redes);
              
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void EliminarVideo(int VideoId)
        {
            try
            { RedesSociales.EliminarVideo(VideoId); }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
