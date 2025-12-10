using SM.Datos.Escuelas;
using SM.LibreriaComun.DTO;
using SM.SIPA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Aplicacion.Escuelas
{
    public class CategorizacionLogica
    {
        public static List<CategorizacionResumenDTO> ConsultarCategorizacionPorEscuela(decimal EntId, out decimal suma)
        {
            try
            {
                var model = new List<ART_MUSICA_VALORES_CATEGORIZACION_Result>();
                var result = new List<CategorizacionResumenDTO>();
                model = Categorizacion.ConsultarCategorizacionPorEscuela(EntId);
                decimal SumarValor = 0;
                decimal intValor = 0;
                foreach (var item in model)
                {
                    var datos = new CategorizacionResumenDTO();
                     intValor = 0;
                    datos.Descripcion = item.Descripcion;
                    datos.Id = item.Id;
                    datos.PadreId = item.PadreId;
                    datos.Porcentaje = item.Porcentaje;
                   
                    if (item.Valor != null)
                    {
                        if (item.Valor > 0)
                        {
                            intValor = Convert.ToDecimal(item.Valor) * 100;
                            datos.Valor = Convert.ToInt32(intValor);
                            datos.ValorPorcentaje = datos.Valor.ToString() + " %";
                        }
                        else
                        {
                            datos.Valor = 0;
                            datos.ValorPorcentaje = "0 %";
                        }
                    }
                    else
                    {
                        datos.Valor = 0;
                        datos.ValorPorcentaje = "0 %";
                    }
                    if (item.PadreId == 0)
                    {
                        SumarValor = SumarValor + datos.Valor;

                        if (datos.Valor <= 5)
                        {
                            datos.Estilo = "progress-bar-danger";
                            datos.barra = 10;
                        }
                        else if (datos.Valor > 5 && datos.Valor <= 10)
                        {
                            datos.Estilo = "progress-bar-warning";
                            datos.barra = 30;
                        }
                        else if (datos.Valor > 10 && datos.Valor <= 15)
                        {
                            datos.Estilo = "progress-bar-info";
                            datos.barra = 65;
                        }
                        else if (datos.Valor > 15 && datos.Valor <= 20)
                        {
                            datos.Estilo = "progress-bar-success";
                            datos.barra = 90;
                        }
                    }
                    result.Add(datos);
                }
                suma = SumarValor;

                                  

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static CategoriaEncabezadoDTO ConsultarNombreEscuela(decimal EntId)
        {
            try
            {
                var model = new ART_MUSICA_NOMBRE_CATEGORIA_Result();
                var datos = new CategoriaEncabezadoDTO();
                model = Categorizacion.ConsultarNombreEscuela(EntId);

                if (model != null)
                {
                    datos.Categoria = model.Categoria;
                    datos.EscuelaId = model.EscuelaId;
                    datos.Nombre = model.Nombre;
                    datos.Porcentaje = model.Porcentaje;

                }

                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
