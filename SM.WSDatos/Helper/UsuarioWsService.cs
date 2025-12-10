using SM.SIPA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.WSDatos.Helper
{
    public class UsuarioWsService
    {
        public static string ValidaUsuario(string usuario, string contrasena)
        {
            string codigodepartamento = "";
            try
            {
                using (var context = new SIPAEntities())
                {
                    var model = context.ART_MUSICA_WS_USUARIO.Where(x => x.Nombre.Equals(usuario) & x.Contrasena.Equals(contrasena)).FirstOrDefault();

                    if (model != null)
                    {
                        codigodepartamento = model.CodigoDepartamento;
                    }
                }

                return codigodepartamento;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
