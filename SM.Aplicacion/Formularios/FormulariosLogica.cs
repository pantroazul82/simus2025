using SM.Datos.DTO;
using SM.Datos.Escuelas;
using SM.LibreriaComun.DTO;
using SM.SIPA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Aplicacion.Formularios
{
    public class FormulariosLogica
    {
        public static void GuardarFormulario(List<FormularioResultadoCampoDTO> listFormularioResultado, decimal EscuelaId)
        {
            try
            {
                List<FormularioCampoValoresDTO> listResultado = new List<FormularioCampoValoresDTO>();


                foreach (var item in listFormularioResultado)
                {
                    FormularioCampoValoresDTO datos = new FormularioCampoValoresDTO();
                    datos.FCO_DESCRIPCION = item.FCO_DESCRIPCION;
                    datos.FCO_ID = item.FCO_ID;
                    datos.FCO_NOMBRE = item.FCO_NOMBRE;
                    datos.FOR_ID = item.FOR_ID;
                    datos.FCO_TIPO_DATO = item.FCO_TIPO_DATO;
                    datos.archivo = item.archivo;
                    datos.NombreArchivo = item.NombreArchivo;
                    datos.TipoArchivo = item.TipoArchivo; 
                    listResultado.Add(datos);
                }

                FormulariosDinamicos.GuardarFormulario(listResultado, EscuelaId);
           
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static EscuelaEncabezadoDTO ConsultarEncabezadoEscuela(decimal EscuelaId)
        {
            var resultado = new EscuelaEncabezadoResultadoDTO();
            var datos = new EscuelaEncabezadoDTO();
            try
            {
                resultado = FormulariosDinamicos.ConsultarEncabezadoEscuela(EscuelaId);

                if (resultado != null)
                {
                    datos.EscuelaId = resultado.EscuelaId;
                    datos.Nombre = resultado.Nombre;
                    datos.Resena = resultado.Resena;
                }
                return datos;
            }
             
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<FormularioDTO> ConsultarFormulariosActivos()
        {
            try
            {
            
                var model = FormulariosDinamicos.ConsultarFormulariosActivos();
                List<FormularioDTO> listFormulario = new List<FormularioDTO>();
            
              foreach (var item in model)
                {
                    FormularioDTO datos = new FormularioDTO();
                    datos.Descripcion = item.Descripcion;
                    datos.EsActiva = item.EsActiva;
                    datos.EsEditable = item.EsEditable;
                    datos.EsVisible = item.EsVisible;
                    datos.FechaRegistro = item.FechaRegistro;
                    datos.ForID = item.ForID;
                    datos.Nombre = item.Nombre;
                    datos.Perfiles = item.Perfiles;
                    listFormulario.Add(datos);
                }


              return listFormulario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<FormularioValoresDTO> ConsultarValores(decimal EscuelaId, decimal FormularioId)
        {
            try
            {
                var model = new List<ValoresResultadoDTO>();

                model = FormulariosDinamicos.ConsultarValores(EscuelaId, FormularioId);
                List<FormularioValoresDTO> listFormulario = new List<FormularioValoresDTO>();

                foreach (var item in model)
                {
                    FormularioValoresDTO datos = new FormularioValoresDTO();
                    datos.FCO_ID = item.FCO_ID;
                    datos.FCO_NOMBRE = item.FCO_NOMBRE;
                    datos.FOR_ID = item.FOR_ID;
                    datos.FRE_ID = item.FRE_ID;
                    datos.FVA_DUPLICACION = item.FVA_DUPLICACION;
                    datos.FVA_ID = item.FVA_ID;
                    datos.FVA_VALOR = item.FVA_VALOR;
                   listFormulario.Add(datos);
                }


                return listFormulario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<FormularioCamposDTO> ConsultarCampos(decimal FormularioId)
        {
            try
            {
                var model = new List<FormularioValoresResultadoDTO>();

                model = FormulariosDinamicos.ConsultarCamposFormulariodinamico(FormularioId);
                List<FormularioCamposDTO> listFormulario = new List<FormularioCamposDTO>();

                foreach (var item in model)
                {
                    FormularioCamposDTO datos = new FormularioCamposDTO();
                    datos.FCO_DESCRIPCION = item.FCO_DESCRIPCION;
                    datos.FCO_ESOBLIGATORIA = item.FCO_ESOBLIGATORIA;
                    datos.FCO_ID = item.FCO_ID;
                    datos.FCO_NOMBRE = item.FCO_NOMBRE;
                    datos.FCO_ORDEN = item.FCO_ORDEN;
                    datos.FCO_TIPODATO = item.FCO_TIPODATO;
                    datos.FLI_ID = item.FLI_ID;
                    datos.FOR_ID = item.FOR_ID;
                    datos.FSC_DUPLICACIONES = item.FSC_DUPLICACIONES;
                    datos.FSC_ID = item.FSC_ID;
                    datos.FSC_NOMBRE = item.FSC_NOMBRE;
                    listFormulario.Add(datos);
                }


                return listFormulario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<FormularioCamposDTO> ConsultarCamposFormulariodinamicoTodos()
        {
            try
            {
                var model = new List<FormularioValoresResultadoDTO>();

                model = FormulariosDinamicos.ConsultarCamposFormulariodinamicoTodos();
                List<FormularioCamposDTO> listFormulario = new List<FormularioCamposDTO>();
                var listElementos = new List<ART_ME_FORMULARIOS_LISTAS_ELEMENTOS>();

                listElementos = FormulariosDinamicos.ConsultarElementosLista();

                foreach (var item in model)
                {
                    FormularioCamposDTO datos = new FormularioCamposDTO();
                    datos.FCO_DESCRIPCION = item.FCO_DESCRIPCION;
                    datos.FCO_ESOBLIGATORIA = item.FCO_ESOBLIGATORIA;
                    datos.FCO_ID = item.FCO_ID;
                    datos.FCO_NOMBRE = item.FCO_NOMBRE;
                    datos.FCO_ORDEN = item.FCO_ORDEN;
                    datos.FCO_TIPODATO = item.FCO_TIPODATO;
                    datos.FLI_ID = item.FLI_ID;
                    datos.FOR_ID = item.FOR_ID;
                    datos.FSC_DUPLICACIONES = item.FSC_DUPLICACIONES;
                    datos.FSC_ID = item.FSC_ID;
                    datos.FSC_NOMBRE = item.FSC_NOMBRE;
                    if (item.FLI_ID != null)
                    {
                        datos.listadoBasico = ConsularListadoElementos((decimal)item.FLI_ID, listElementos);
                    }
                    listFormulario.Add(datos);
                }


                return listFormulario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<BasicaDTO> ConsularListadoElementos(decimal ListadoId, List<ART_ME_FORMULARIOS_LISTAS_ELEMENTOS> listElementos)
        {
            try
            {
                
                List<BasicaDTO> listBasicas = new List<BasicaDTO>();
                if (listElementos != null)
                {
                    var resultado = listElementos.Where(x => x.FLI_ID == ListadoId).ToList();

                    foreach (var item in resultado)
                    {
                        BasicaDTO datos = new BasicaDTO();
                        datos.text = item.FLE_ETIQUETA;
                        datos.value = item.FLE_VALOR;
                  
                        listBasicas.Add(datos);
                    }

                }
                return listBasicas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<BasicaDTO> ConsularListadoElementosPorId(decimal ListadoId)
        {
            try
            {
                List<ART_ME_FORMULARIOS_LISTAS_ELEMENTOS> listElementos = FormulariosDinamicos.ConsultarElementosListaPorId(ListadoId); 

                List<BasicaDTO> listBasicas = new List<BasicaDTO>();
                if (listElementos != null)
                {
                    var resultado = listElementos.Where(x => x.FLI_ID == ListadoId).ToList();

                    foreach (var item in resultado)
                    {
                        BasicaDTO datos = new BasicaDTO();
                        datos.text = item.FLE_ETIQUETA;
                        datos.value = item.FLE_VALOR;
                        listBasicas.Add(datos);
                    }

                }
                return listBasicas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<FormularioSeccionesDTO> ConsultarSeccionesTodas()
        {
            try
            {
                var model = new List<ART_ME_FORMULARIOS_SECCIONES>();

                model = FormulariosDinamicos.ConsultarSeccionesTodas();
                List<FormularioSeccionesDTO> listFormulario = new List<FormularioSeccionesDTO>();

                foreach (var item in model)
                {
                    FormularioSeccionesDTO datos = new FormularioSeccionesDTO();
                    datos.FOR_ID = item.FOR_ID;
                    datos.FSC_DUPLICACIONES = item.FSC_DUPLICACIONES;
                    datos.FSC_ID = item.FSC_ID;
                    datos.FSC_NOMBRE = item.FSC_NOMBRE;
                    listFormulario.Add(datos);
                }


                return listFormulario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
