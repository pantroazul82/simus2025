using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebSImus.Models
{
    public class RedesSocialesModel
    {
        [RegularExpression(@"^(https?\:\/\/)?(www\.youtube\.com|youtu\.?be)\/.+$", ErrorMessage = "La URL de YouTube no es válida.")]

        public string UrlYoutube { get; set; }

        public string DescripcionVideo { get; set; }

        [Url(ErrorMessage = "La Url de Flicker es invalida.")]
        public string GaleriaFlicker { get; set; }

        public string DescripcionFlicker { get; set; }

         [Url(ErrorMessage = "La Url de facebook es invalida.")]
        public string Facebook { get; set; }

        [Url(ErrorMessage = "La Url de Canal de Youtube es invalida.")]
        public string CanalYoutube { get; set; }

         [Url(ErrorMessage = "La Url de Twitter es invalida.")]
        public string Twitter { get; set; }

        public decimal EscuelaId { get; set; }

        public decimal VideoId { get; set; }

        public decimal GaleriaId { get; set; }

        public ClasificacionVideoesEnum ClasificacionVideos { get; set; }

        public List<VideoModel> listVideo { get; set; }
        public enum ClasificacionVideoesEnum
        {
            [Display(Name = "Proceso formativo")]
            Procesoformativo = 1,
            [Display(Name = "Encuentros")]

            Encuentros = 2,
            [Display(Name = "Festivales")]

            Festivales = 3,
            [Display(Name = "Presentaciones públicas")]

            Presentacionespublicas = 4,
            [Display(Name = "Ensayos")]
            Ensayos = 5,

            [Display(Name = "Celebra la Música")]
            CelebralaMúsica = 6,
            [Display(Name = "Infraestructura")]
            Infraestructura = 7,
            [Display(Name = "Agrupaciones")]
            Agrupaciones = 8,

            [Display(Name = "Recolección de fondos")]
             Recoleccionfondos = 9,
            [Display(Name = "Intercambios musicales")]
            Intercambiomusicales = 10,
              
            [Display(Name = "Jornadas de esparcimiento")]
            Jornadaesparcimiento = 11,
            [Display(Name = "Vídeo institucional")]
            Videoinstitucional = 12

        }

    
    }



    public class VideoModel
    {

        public int Id { get; set; }
        public decimal EscuelaId { get; set; }
        public WebSImus.Models.RedesSocialesModel.ClasificacionVideoesEnum Clasificacion { get; set; }
        public string NuevaClasificacion { get; set; }
        public string url { get; set; }
        public string Desripcion { get; set; }

        public string FechaPublicacion { get; set; }
    }
}