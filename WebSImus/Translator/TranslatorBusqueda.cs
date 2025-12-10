using SM.LibreriaComun.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebSImus.Models;

namespace WebSImus.Translator
{
    public class TranslatorBusqueda
    {

        public static List<ResultadoModels> TranslatorBusquedaDTOTOResuladoModels(List<BusquedaResultadoDTO> listado)
        {
            List<ResultadoModels> resultado = new List<ResultadoModels>();

            if (listado != null)
            {
                foreach (BusquedaResultadoDTO item in listado)
                {
                    ResultadoModels model = new ResultadoModels();
                    model.Id = item.Id;
                    model.Titulo = item.Titulo.Trim();
                    model.Descripcion = "";
                    if (!String.IsNullOrEmpty(item.Descripcion))
                    {
                        if (item.Descripcion.Length > 149)
                            model.Descripcion = item.Descripcion.Substring(0, 150);
                        else
                            model.Descripcion = item.Descripcion;
                    }
                   
                    resultado.Add(model);
                }

            }

            return resultado;
        }
    }
}