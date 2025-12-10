using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SM.LibreriaComun.DTO;
using SM.Datos.Basicas;
using SM.Datos.DTO;

namespace SM.Aplicacion.Basicas
{
    public class ZonaGeograficasLogica
    {
        public static List<BasicaDTO> ConsultarDepartamentos()
        {
            List<BasicaDTO> listdepartamento = new List<BasicaDTO>();
            try
            {
                List<Basica> departamentosdatos = ServicioBasicas.ConsultarDepartamentos();

                foreach (var item in departamentosdatos)
                {
                    BasicaDTO itemdepartamento = new BasicaDTO();
                    itemdepartamento.value = item.Value;
                    if (item.Value == "88")
                        itemdepartamento.text = "ARCHIPIÉLAGO DE SAN ANDRÉS";
                    else
                    {
                        itemdepartamento.text = item.Nombre;
                    }
                    listdepartamento.Add(itemdepartamento);
                }

                listdepartamento = listdepartamento.OrderBy(d => d.text).ToList();

                return listdepartamento;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<BasicaDTO> ConsultarDepartamentosporPais(string cod)
        {
            List<BasicaDTO> listdepartamento = new List<BasicaDTO>();
            try
            {
                List<Basica> departamentosdatos = ServicioBasicas.ConsultarDepartamentosporPais(cod);

                foreach (var item in departamentosdatos)
                {
                    BasicaDTO itemdepartamento = new BasicaDTO();
                    itemdepartamento.value = item.Value;
                    if (item.Value == "88")
                        itemdepartamento.text = "ARCHIPIÉLAGO DE SAN ANDRÉS";
                    else
                    {
                        itemdepartamento.text = item.Nombre;
                    }
                    listdepartamento.Add(itemdepartamento);
                }

                listdepartamento = listdepartamento.OrderBy(d => d.text).ToList();

                return listdepartamento;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<BasicaDTO> ConsultarPaises()
        {
            List<BasicaDTO> listBasicas = new List<BasicaDTO>();
            try
            {
                List<Basica> datos = ServicioBasicas.ConsultarPaises();

                foreach (var item in datos)
                {
                    BasicaDTO itemdatos = new BasicaDTO();
                    itemdatos.value = item.Value;
                    itemdatos.text = item.Nombre;
                    listBasicas.Add(itemdatos);
                }

                listBasicas = listBasicas.OrderBy(d => d.text).ToList();

                return listBasicas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<BasicaDTO> ConsultarAreas()
        {
            List<BasicaDTO> listBasicas = new List<BasicaDTO>();
            try
            {
                List<Basica> datos = ServicioBasicas.ConsultarAreas();

                foreach (var item in datos)
                {
                    BasicaDTO itemdatos = new BasicaDTO();
                    itemdatos.value = item.Value;
                    itemdatos.text = item.Nombre;
                    listBasicas.Add(itemdatos);
                }

                listBasicas = listBasicas.OrderBy(d => d.text).ToList();

                return listBasicas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<BasicaDTO> ConsultarMunicipios(string departamento = null)
        {
            List<BasicaDTO> listMunicipios = new List<BasicaDTO>();
            try
            {
                if (!String.IsNullOrEmpty(departamento))
                {
                    List<Basica> MunicipioDatos = ServicioBasicas.ConsultarMunicipios(departamento);

                    foreach (var item in MunicipioDatos)
                    {
                        BasicaDTO itemdepartamento = new BasicaDTO();
                        itemdepartamento.value = item.Value;
                        itemdepartamento.text = item.Nombre;
                        listMunicipios.Add(itemdepartamento);
                    }

                    listMunicipios = listMunicipios.OrderBy(d => d.text).ToList();
                }
                return listMunicipios;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Obtenmos el departemnteo por codigo
        /// </summary>
        /// <param name="coddepartamento"></param>
        /// <returns></returns>
        public static BasicaDTO obtenerDptoporCod(string coddepartamento)
        {
            BasicaDTO objDepto = null;
            try
            {

                Basica objdptoBiz = ServicioBasicas.obtenerDepartamentoPorcod(coddepartamento);

                if (objdptoBiz != null)
                {
                    objDepto = new BasicaDTO();
                    objDepto.value = objdptoBiz.Value;
                    objDepto.text = objdptoBiz.Nombre;

                }



                return objDepto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Obtiene el nombre del departamento y municipio a partir del código de municipio
        /// </summary>
        /// <param name="CodigoMunicipio"></param>
        /// <returns></returns>
        public static BasicaDTO ObtenerNombres(string CodigoMunicipio)
        {
            BasicaDTO objDepto = null;
            try
            {

                Basica objdptoBiz = ServicioBasicas.ObtenerNombres(CodigoMunicipio);

                if (objdptoBiz != null)
                {
                    objDepto = new BasicaDTO();
                    objDepto.value = objdptoBiz.Value;
                    objDepto.text = objdptoBiz.Nombre;

                }



                return objDepto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string ObtenerNombreDepartamentoyMunicipio(string CodigoMunicipio)
        {
            string strNombre = "";
            try
            {

                Basica objdptoBiz = ServicioBasicas.ObtenerNombres(CodigoMunicipio);

                if (objdptoBiz != null)
                {
                    strNombre = objdptoBiz.Value + " - " + objdptoBiz.Nombre;
                }

                return strNombre;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string ObtenerNombresPorEscuelaId(decimal EscuelaId)
        {
            string strNombre = "";
            try
            {

                Basica objdptoBiz = ServicioBasicas.ObtenerNombresPorEscuelaId(EscuelaId);

                if (objdptoBiz != null)
                {
                    strNombre = objdptoBiz.Value + " - " + objdptoBiz.Nombre;
                }

                return strNombre;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Obtener municipio asociado al dpto
        /// </summary>
        /// <param name="coddepartamento"></param>
        /// <param name="codMunicipio"></param>
        /// <returns></returns>
        public static BasicaDTO obtenerMuniporCod(string coddepartamento, string codMunicipio)
        {
            BasicaDTO objDepto = null;
            try
            {

                Basica objdptoBiz = ServicioBasicas.obtenerMunicipioPorcod(coddepartamento, codMunicipio);

                if (objdptoBiz != null)
                {
                    objDepto = new BasicaDTO();
                    objDepto.value = objdptoBiz.Value;
                    objDepto.text = objdptoBiz.Nombre;

                }



                return objDepto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string obtenerNombreMunicipio(string codMunicipio)
        {
            string nombre;
            try
            {

                nombre = ServicioBasicas.obtenerNombreMunicipio(codMunicipio);

                return nombre;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string obtenerNombreDepartamento(string coddepartamento)
        {
            string nombre;
            try
            {

                nombre = ServicioBasicas.obtenerNombreDepartamento(coddepartamento);

                return nombre;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
