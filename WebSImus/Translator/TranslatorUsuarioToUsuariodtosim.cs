using SM.LibreriaComun.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebSImus.Comunes;
using WebSImus.Models;

namespace WebSImus.Translator
{
    public class TranslatorUsuarioToUsuariodtosim
    {

        public static Usuarios UsuarioDTOSIMtoUsuario(UsuarioDTOSIM objfrom)
        {
            Usuarios objTo = null;
            if (objfrom != null)
            {
                objTo = new Usuarios();
                objTo.departamento = objfrom.CodDpto;
                objTo.pais = objfrom.CodPais;
                objTo.municipio = objfrom.CodMunicipio;

                objTo.numeroDocumento = objfrom.Identificacion;
                objTo.tipoDocumento = objfrom.CodTipoDocumento;
                objTo.idRedSocial = objfrom.IdUserRSS;
                objTo.primerApellido = objfrom.PrimerApellido;
                objTo.segundoApellido = objfrom.segundoApellido;
                objTo.primerNombre = objfrom.PrimerNombre;
                objTo.segundoNombre = objfrom.SegundoNombre;
                objTo.sexo = objfrom.Sexo;
                objTo.usuario = objfrom.Email;
                objTo.idRedSocial = objfrom.IdUserRSS;
                objTo.esnuevoenSimus = objfrom.esnuevoenSimus;
                objTo.esUsuariodeRSS = false;
                objTo.IdRol = objfrom.IdRol;
                objTo.contrasena = objfrom.contrasena;
                objTo.confcontrasena = objfrom.contrasena;
                //usuario de redesde sociales
                if (objTo.idRedSocial != null)
                {
                    objTo.esUsuariodeRSS = true;
                    objTo.contrasena = Comunes.ConstantesRecursosBD.SIMUS_SIPA_CLAVE_DEFAULT;
                    objTo.confcontrasena = Comunes.ConstantesRecursosBD.SIMUS_SIPA_CLAVE_DEFAULT;
                }

                objTo.tipoRedSocial = objfrom.TipoRSS;
                objTo.esUsuarioSiMUS = false;
                //usuario de simus
                if (objTo.tipoRedSocial != null && objTo.tipoRedSocial.Trim() == ConstantesRecursosBD.SIMUS_USUARIO_TIPO_SIMUS) objTo.esUsuarioSiMUS = true;
                //usuario de mincultura
                objTo.esUsuarioInterno = Convert.ToBoolean(objfrom.esUsuarioInterno);
                objTo.esActivo = objfrom.esActivo;
                objTo.rutafoto = objfrom.rutaFoto;
             
                objTo.fechaNacimiento = objfrom.Fechanacimiento != null ? objfrom.Fechanacimiento.Value.ToString("yyyy-MM-dd") : String.Empty;

                //usuario resgitrado por simus
                objTo.Id = objfrom.Id;
                objTo.imagen = objfrom.imagen;

                //Manejo del agente
                objTo.esAgente = false;
                if (objfrom.IdAgente > 0)
                {
                    objTo.esAgente = true;
                    objTo.IdAgente = objfrom.IdAgente;
                }

            }




            return objTo;
        }



        public static UsuarioDTOSIM UsuariotoUsuarioDTOSIM(Usuarios objfrom)
        {
            UsuarioDTOSIM objTo = new UsuarioDTOSIM();
            objTo.Id = objfrom.Id;
            objTo.CodDpto = objfrom.departamento;
            objTo.CodPais = objfrom.pais;
            objTo.CodMunicipio = objfrom.municipio;

            objTo.Identificacion = objfrom.numeroDocumento;
            objTo.PrimerNombre = objfrom.primerNombre;
            objTo.PrimerApellido = objfrom.primerApellido;
            objTo.SegundoNombre = objfrom.segundoNombre;
            objTo.segundoApellido = objfrom.segundoApellido;
            objTo.Sexo = objfrom.sexo;
            objTo.TipoRSS = objfrom.tipoRedSocial;
            objTo.CodTipoDocumento = objfrom.tipoDocumento;
            objTo.Email = objfrom.usuario;
            objTo.IdUserRSS = objfrom.idRedSocial;
            objTo.TipoRSS = objfrom.tipoRedSocial;
            objTo.esUsuarioInterno = objfrom.esUsuarioInterno;
            objTo.esActivo = objfrom.esActivo;
            objTo.imagen = objfrom.imagen;
            objTo.rutaFoto = objfrom.rutafoto;
            objTo.contrasena = objfrom.confcontrasena;
            objTo.IdSipa = objfrom.idUserSipa;
            if (!string.IsNullOrEmpty(objfrom.fechaNacimiento))
                objTo.Fechanacimiento = DateTime.Parse(objfrom.fechaNacimiento);
          
            return objTo;
        }



        public static UsuarioViewModel ObtenerUsuarioBasico(string UsuarioId)
        {
            UsuarioViewModel objTo = new UsuarioViewModel();

            UsuarioBasicoDTO datos = SM.Aplicacion.Modulo_Usuarios.UsuarioLogica.ObtenerUsuarioBasicoLayout(Convert.ToInt32(UsuarioId));

            if (datos != null)
            {
                objTo.AgenteId = datos.AgenteId;
                objTo.esActivo = datos.esActivo;
                objTo.EsAgente = datos.EsAgente;
                objTo.esUsuariodeRSS = datos.esUsuariodeRSS;
                objTo.esUsuarioInterno = datos.esUsuarioInterno;
                objTo.esUsuarioSiMUS = datos.esUsuarioSiMUS;
                objTo.imagen = datos.imagen;
                objTo.rutafoto = datos.rutafoto;
                objTo.UsuarioId = datos.UsuarioId;
            }
            return objTo;
        }

    }
}