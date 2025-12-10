using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using SM.LibreriaComun.DTO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace WebSImus.Models
{
    public class Usuarios
    {
        [Display(Name = "* Correo electrónico")]
        //[DataType(DataType.EmailAddress, ErrorMessage = "Correo electrónico  no es valido")]
        [StringLength(100, ErrorMessage = "Máximo número de caracteres sobrepasado")]
        [Required(ErrorMessage = "El usuario es obligatorio")]
        //[EmailAddress(ErrorMessage = "El Correo electrónico  no es valido")]
        public string usuario { get; set; }
        [Required(ErrorMessage = "La contraseña es obligatoria")]
        [StringLength(20, ErrorMessage = "La longitud de la contraseña debe tener al menos ocho caracteres, al menos una mayúscula, una minúscula, un número y un carácter especial.", MinimumLength = 4)]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*_\-\.]).{8,}$", ErrorMessage = "La contraseña debe tener al menos una mayúscula, una minúscula, un número y un carácter especial.")]
        public string contrasena { get; set; }

      
        public string fechaNacimiento { get; set; }

       

        public string tipoRedSocial { get; set; }
        public string idRedSocial { get; set; }
        [Required(ErrorMessage = "El primer nombre es obligatorio")]
        public string primerNombre { get; set; }
        public string segundoApellido { get; set; }
        public string sexo { get; set; }
        public bool esnuevoenSimus { get; set; }
        [Required(ErrorMessage = "El tipo documento es obligatorio")]
        public string tipoDocumento { get; set; }
        [Required(ErrorMessage = "El número documento es obligatorio")]
        public string numeroDocumento { get; set; }

        [Required(ErrorMessage = "El país es obligatorio")]
        public string pais { get; set; }
        public string departamento { get; set; }
        public string municipio { get; set; }

        [Required(ErrorMessage = "El primer apellido es obligatorio")]
        public string primerApellido { get; set; }
        /// <summary>
        /// Usuario de mincultura       
        /// </summary>
        public bool esUsuarioInterno { get; set; }
        public bool esActivo { get; set; }
        public string rutafoto { get; set; }
        public string segundoNombre { get; set; }
        public decimal idUserSipa { get; set; }

        public bool esAgente { get; set; }

        public bool esUsuarioSiMUS { get; set; }
        public bool esUsuariodeRSS { get; set; }


        public bool aceptaCondiciones { get; set; }
        [Required(ErrorMessage = "El campo confirmar contraseña es obligatorio")]
        [StringLength(20, ErrorMessage = "La longitud de la contraseña debe tener al menos ocho caracteres, al menos uno en mayúscula, uno en minúscula y por lo menos un número", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Compare("contrasena", ErrorMessage = "El campo contraseña y confirmar contraseña no son iguales")]
        public string confcontrasena { get; set; }

        public string msg { get; set; }

        public int Id { get; set; }
        public byte[] imagen { get; set; }
        public List<int> IdRol { get; set; }

        public List<UserDptoMunDTO> lstAuxDpto { get; set; }

        public int IdAgente { get; set; }
        public static string ImageSource(byte[] imagen)
        {
            if (imagen == null) return "";
            string mimeType = "image/png";/* Get mime type somehow (e.g. "image/png") */;
            string base64 = Convert.ToBase64String(imagen);
            return string.Format("data:{0};base64,{1}", mimeType, base64);

        }

        public static string CreateImageThumbnail(byte[] image, int width = 748, int height = 440)
        {
            if (image == null) return "";

            string mimeType = "";
            string base64 = "";
            using (var stream = new System.IO.MemoryStream(image))
            {
              
                var img = Image.FromStream(stream);
                var thumbnail = img.GetThumbnailImage(width, height, () => false, IntPtr.Zero);

                using (var thumbStream = new System.IO.MemoryStream())
                {
                    thumbnail.Save(thumbStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    byte[] nuevaImagen = thumbStream.GetBuffer();

                    mimeType = "image/png";/* Get mime type somehow (e.g. "image/png") */;
                    base64 = Convert.ToBase64String(nuevaImagen);
                    
                  
                }
            }

            return string.Format("data:{0};base64,{1}", mimeType, base64);
        }

        public static string CreateImage(byte[] image, int width = 440, int height = 300)
        {
            if (image == null) return "";

            string mimeType = "";
            string base64 = "";

           var img2 =  byteArrayToImage(image);
           Bitmap bm = ResizeImage(img2, width, height);


           using (MemoryStream ms = new MemoryStream())
           {
               bm.Save(ms, ImageFormat.Jpeg);
               mimeType = "image/png";/* Get mime type somehow (e.g. "image/png") */;
               base64 = Convert.ToBase64String(ms.ToArray());
           }
            return string.Format("data:{0};base64,{1}", mimeType, base64);
        }

        public static Image byteArrayToImage(byte[] bytesArr)
        {
            MemoryStream memstr = new MemoryStream(bytesArr);
            Image img = Image.FromStream(memstr);
            return img;
        }
        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }


        public static Image Resize(Image image, int newWidth, int maxHeight, bool onlyResizeIfWider)
        {
            if (onlyResizeIfWider && image.Width <= newWidth) newWidth = image.Width;

            var newHeight = image.Height * newWidth / image.Width;
            if (newHeight > maxHeight)
            {
                // Resize with height instead  
                newWidth = image.Width * maxHeight / image.Height;
                newHeight = maxHeight;
            }

            var res = new Bitmap(newWidth, newHeight);

            using (var graphic = Graphics.FromImage(res))
            {
                graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphic.SmoothingMode = SmoothingMode.HighQuality;
                graphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
                graphic.CompositingQuality = CompositingQuality.HighQuality;
                graphic.DrawImage(image, 0, 0, newWidth, newHeight);
            }

            return res;
        }  
  
        public IList<RolDTO> AvailableRols { get; set; }
        public PostedRoles PostedRoles { get; set; }



    }
    public class PostedRoles
    {
        public string[] RolIDs { get; set; }

        public PostedRoles()
        {

        }
    }

    public class AutenticacionViewModel
    {
        [Required]
        [StringLength(512)]
        //[EmailAddress(ErrorMessage = "Por favor ingrese un correo valido.")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "{0} Tiene formato incorrecto.")]
        [Display(Name = "Correo electrónico:")]
        public string NombreUsuario { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña:")]
        public string Contrasena { get; set; }

        [Display(Name = "Recordarme")]
        public bool Recordarme { get; set; }
        public string msg { get; set; }

        [Required]
        [Display(Name = "Aceptar terminos y condiciones")]
        public bool AceptarTerminos { get; set; }

        public string redirecciona { get; set; }
      
    }

    public class UsuarioViewModel
    {
        public int UsuarioId { get; set; }
        public int AgenteId { get; set; }
        public bool EsAgente { get; set; }
        public byte[] imagen { get; set; }
        public bool esUsuarioInterno { get; set; }
        public bool esActivo { get; set; }
        public bool esUsuarioSiMUS { get; set; }
        public bool esUsuariodeRSS { get; set; }
        public string rutafoto { get; set; }
        public static string ImageSource(byte[] imagen)
        {
            if (imagen == null) return "";
            string mimeType = "image/png";/* Get mime type somehow (e.g. "image/png") */;
            string base64 = Convert.ToBase64String(imagen);
            return string.Format("data:{0};base64,{1}", mimeType, base64);

        }

    }

}