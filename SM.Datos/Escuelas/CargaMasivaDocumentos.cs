using SM.Datos.DTO;
using SM.SIPA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Datos.Escuelas
{
    public class CargaMasivaDocumentos
    {
        public static List<ART_MUS_TIP_DOC_CRE_ENT_INSTITUC> ConsultaListadoDocumentosCreacion()
        {
            try
            {
                var model = new List<ART_MUS_TIP_DOC_CRE_ENT_INSTITUC>();
                using (var context = new SIPAEntities())
                {

                    model = context.ART_MUS_TIP_DOC_CRE_ENT_INSTITUC.Where(x => x.DocumentoId == null && x.ART_MUS_TIP_DOC_CRE_DOCUMENTO != "" && x.ART_MUS_TIP_DOC_CRE_DOCUMENTO.Contains(".pdf")).ToList();

                   // model = context.ART_MUS_TIP_DOC_CRE_ENT_INSTITUC.Where(x => x.ART_MUS_TIP_DOC_CRE_DOCUMENTO.Contains(".pdf")).Take(50).ToList();
                }
                return model;

            }
            catch (Exception)
            {
                throw;
            }
        }


        public static List<ART_ENTIDADES_ARTES> ConsultaCargarImagenes()
        {
            try
            {
                var model = new List<ART_ENTIDADES_ARTES>();
                using (var context = new SIPAEntities())
                {

                    model = context.ART_ENTIDADES_ARTES.Where(x =>x.ENT_ESTADO == "E" &&  x.ENT_IMAGEN != null && x.ENT_IMAGEN != "").ToList();

                 
                }
                return model;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<ART_MUSICA_USUARIO> ConsultarUsuarios()
        {
            try
            {
                var model = new List<ART_MUSICA_USUARIO>();
                using (var context = new SIPAEntities())
                {

                    model = context.ART_MUSICA_USUARIO.Where(x => x.Id >= 2402 && x.Id <= 2606).ToList();


                }
                return model;

            }
            catch (Exception)
            {
                throw;
            }
        }


        public static void ActualizarContraseña(int Id, string strContraseña)
        {
            try
            {

                using (var context = new SIPAEntities())
                {

                    var entidad = context.ART_MUSICA_USUARIO.Where(x => x.Id == Id).FirstOrDefault();

                    entidad.TipoRSS = strContraseña;
                    context.SaveChanges();
                }


            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void ActualizarNuevaContraseña(int Id, string strContraseña)
        {
            try
            {

                using (var context = new SIPAEntities())
                {

                    var entidad = context.ART_MUSICA_USUARIO.Where(x => x.Id == Id).FirstOrDefault();

                    entidad.Contraseña  = strContraseña;
                    context.SaveChanges();
                }


            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void ActualizarDocumentoId(decimal EntId, int documentoId)
        {
            try
            {
              
                using (var context = new SIPAEntities())
                {

                    var entidad = context.ART_MUS_TIP_DOC_CRE_ENT_INSTITUC.Where(x => x.ENT_ID == EntId).FirstOrDefault();

                    entidad.DocumentoId = documentoId;
                    context.SaveChanges();
                }
               

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void ActualizarImagen(decimal EntId,   byte[] image)
        {
            try
            {

                using (var context = new SIPAEntities())
                {

                    var model = context.ART_MUSICA_ENTIDAD_IDENTIFICACION.Where(x => x.ENT_ID == EntId).FirstOrDefault();

                    if (model != null)
                    {
                        model.Imagen = image;
                        context.SaveChanges();
                    }
                }


            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
