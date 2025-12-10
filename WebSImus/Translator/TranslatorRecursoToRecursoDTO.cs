using SM.LibreriaComun.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebSImus.Models;

namespace WebSImus.Translator
{
    public class TranslatorRecursoToRecursoDTO
    {

        public static List<RecursoModel> TranslatorRecursoDTOToRecurso( List<RecursoDTO> lstRec)
        {
            List<RecursoModel> lstMenu = new List<RecursoModel>();





            if (lstRec != null)
            {
                foreach (RecursoDTO recurso in lstRec)
                {
                    RecursoModel recursomodel = new RecursoModel();
                    recursomodel.id = recurso.id;
                    recursomodel.codigo = recurso.codigo;
                    recursomodel.nombre = recurso.rec_nombre;
                    recursomodel.activo = recurso.estado;
                    recursomodel.titulo = recurso.rec_titulo;
                    recursomodel.tipo = recurso.rec_tipo_nombre;
                    recursomodel.nombrepadre = recurso.nombrepadre;
                    recursomodel.fechacreacion = recurso.fechacreacion;


                    lstMenu.Add(recursomodel);
                }

            }



            return lstMenu;
        }


        public static RecursoDTO TranslatorRecursoModelToRecursoDTO(RecursoModel objFrom)
        {
            RecursoDTO objTo = new RecursoDTO();

            objTo.id = objFrom.id;
            objTo.codigo = objFrom.codigo;
            objTo.rec_nombre = objFrom.nombre;
            objTo.estado = objFrom.activo;
            objTo.rec_titulo = objFrom.titulo;
            objTo.rec_estilo = objFrom.estilo;
            objTo.rec_tipo = objFrom.tipo;
            objTo.rec_id_padre = objFrom.idPadre;
            objTo.fechacreacion = objFrom.fechacreacion;
            objTo.rec_ruta = objFrom.url;


            return objTo;
        }

        public static RecursoModel TranslatorRecursoDTOToRecurso(RecursoDTO objfrom)
        {
            RecursoModel objTo = new RecursoModel();





            if (objfrom != null)
            {


                objTo.id = objfrom.id;
                objTo.idPadre = objfrom.rec_id_padre;
                objTo.codigo = objfrom.codigo;
                objTo.nombre = objfrom.rec_nombre;
                objTo.activo = objfrom.estado;
                objTo.titulo = objfrom.rec_titulo;
                objTo.estilo = objfrom.rec_estilo;
                objTo.url = objfrom.rec_ruta;
                objTo.tipo = objfrom.rec_tipo_nombre;
                objTo.nombrepadre = objfrom.nombrepadre;
                objTo.fechacreacion = objfrom.fechacreacion;


                  
             

            }



            return objTo;
        }


    }
}