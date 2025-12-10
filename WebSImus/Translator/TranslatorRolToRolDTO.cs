using SM.LibreriaComun.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebSImus.Models;

namespace WebSImus.Translator
{
    public class TranslatorRolToRolDTO
    {
        public static RolDTO translatorRolToRolDTO(RolModel objfrom)
         {
             RolDTO objto = new RolDTO();
             objto.id = objfrom.id;
             objto.codigo = objfrom.codigo;
             objto.nombre = objfrom.nombre;
             return objto;
         }


        public static RolModel translatorRolDTOToRol(RolDTO objfrom)
        {
            RolModel objto = new RolModel();
            objto.id = objfrom.id;
            objto.codigo = objfrom.codigo;
            objto.nombre = objfrom.nombre;
            return objto;
        }
        
    }
}