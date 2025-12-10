using SM.Datos.Basicas;
using SM.Datos.DTO;
using SM.Datos.Reportes;
using SM.LibreriaComun.DTO;
using SM.LibreriaComun.DTO.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Aplicacion.Basicas
{
    public class BasicaLogica
    {

        public static EstadoDTO ObtenerEstadoMensaje(int estadoId)
        {
        
            var registro = new EstadoDTO();
            try
            {
               registro = ServicioBasicas.ObtenerEstadoMensaje(estadoId);
           

                return registro;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<BasicaDTO> ConsultarCategoria(int CategoriaId)
        {
            var lisParametro = new List<BasicaDTO>();
            try
            {
                List<Basica> Parametrodatos = ServicioBasicas.ConsultarParametros(CategoriaId);

                foreach (var item in Parametrodatos)
                {
                    BasicaDTO objParametro = new BasicaDTO();
                    objParametro.value = item.Value;
                    objParametro.text = item.Nombre;
                    lisParametro.Add(objParametro);
                }

                lisParametro = lisParametro.OrderBy(d => d.text).ToList();

                return lisParametro;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<BasicaDTO> ConsultarParametrosPorCategoria(string Categoria)
        {
            var lisParametro = new List<BasicaDTO>();
            try
            {
                List<Basica> Parametrodatos = ServicioBasicas.ConsultarParametrosPorCategoria(Categoria);

                foreach (var item in Parametrodatos)
                {
                    BasicaDTO objParametro = new BasicaDTO();
                    objParametro.value = item.Value;
                    objParametro.text = item.Nombre;
                    lisParametro.Add(objParametro);
                }

                lisParametro = lisParametro.OrderBy(d => d.text).ToList();

                return lisParametro;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<BasicaDTO> ConsultarListadoAnos()
        {
            List<BasicaDTO> listAno = new List<BasicaDTO>();
            try
            {

                for (int i = DateTime.Now.Year; i > DateTime.Now.Year - 100; i--)
                {
                    BasicaDTO item = new BasicaDTO();
                    item.value = i.ToString();
                    item.text = i.ToString();
                    listAno.Add(item);
                }

                listAno = listAno.OrderBy(d => d.text).ToList();

                return listAno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<BasicaDTO> ConsultarSINO()
        {
            List<BasicaDTO> listAno = new List<BasicaDTO>();
            try
            {

                BasicaDTO item = new BasicaDTO();
                item.value = "SI";
                item.text = "SI";
                listAno.Add(item);

                 item = new BasicaDTO();
                item.value = "NO";
                item.text = "NO";
                listAno.Add(item);


                return listAno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<BasicaDTO> ConsultarListadoAnosMusica()
        {
            List<BasicaDTO> listAno = new List<BasicaDTO>();
            try
            {

                for (int i = DateTime.Now.Year; i > DateTime.Now.Year - 3; i--)
                {
                    BasicaDTO item = new BasicaDTO();
                    item.value = i.ToString();
                    item.text = i.ToString();
                    listAno.Add(item);
                }

                listAno = listAno.OrderBy(d => d.text).ToList();

                return listAno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<BasicaDTO> ConsultarListadoAnosMusicaIndicadores()
        {
            List<BasicaDTO> listAno = new List<BasicaDTO>();
            try
            {
                BasicaDTO item;

                List<int> listadoPeriodo = IndicadoresServicios.ObtenerPeriodo();
                foreach (var i in listadoPeriodo)
                {
                    item = new BasicaDTO();
                    item.value = i.ToString();
                    item.text = i.ToString();
                    listAno.Add(item);
                }

                item = new BasicaDTO();
                item.value = "1";
                item.text = "Actual";
                listAno.Add(item);

                //listAno = listAno.OrderBy(d => d.text).ToList();

                return listAno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<BasicaDTO> ConsultarListadoAgenteAnos()
        {
            List<BasicaDTO> listAno = new List<BasicaDTO>();
            try
            {

                for (int i = DateTime.Now.Year; i > DateTime.Now.Year - 100; i--)
                {
                    BasicaDTO item = new BasicaDTO();
                    item.value = i.ToString();
                    item.text = i.ToString();
                    listAno.Add(item);
                }

                listAno = listAno.OrderByDescending(d => d.text).ToList();

                return listAno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<BasicaDTO> ConsultarMeses()
        {
            List<BasicaDTO> lisParametro = new List<BasicaDTO>();
            try
            {
                lisParametro.Add(new BasicaDTO() { text = "Enero", value = "1" });
                lisParametro.Add(new BasicaDTO() { text = "Febrero", value = "2" });
                lisParametro.Add(new BasicaDTO() { text = "Marzo", value = "3" });
                lisParametro.Add(new BasicaDTO() { text = "Abril", value = "4" });
                lisParametro.Add(new BasicaDTO() { text = "Mayo", value = "5" });
                lisParametro.Add(new BasicaDTO() { text = "Junio", value = "6" });
                lisParametro.Add(new BasicaDTO() { text = "Julio", value = "7" });
                lisParametro.Add(new BasicaDTO() { text = "Agosto", value = "8" });
                lisParametro.Add(new BasicaDTO() { text = "Septiembre", value = "9" });
                lisParametro.Add(new BasicaDTO() { text = "Octubre", value = "10" });
                lisParametro.Add(new BasicaDTO() { text = "Noviembre", value = "11" });
                lisParametro.Add(new BasicaDTO() { text = "Diciembre", value = "12" });
                return lisParametro;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<BasicaDTO> ListadoConsultas()
        {
            List<BasicaDTO> lisParametro = new List<BasicaDTO>();
            try
            {
                lisParametro.Add(new BasicaDTO() { text = "Mis Registros", value = "1" });
                lisParametro.Add(new BasicaDTO() { text = "Publicados", value = "2" });

                return lisParametro;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<BasicaDTO> ListadoConsultasAdmin()
        {
            List<BasicaDTO> lisParametro = new List<BasicaDTO>();
            try
            {
                lisParametro.Add(new BasicaDTO() { text = "Mis Registros", value = "1" });
                lisParametro.Add(new BasicaDTO() { text = "Publicados", value = "2" });
                lisParametro.Add(new BasicaDTO() { text = "Todos", value = "3" });

                return lisParametro;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<BasicaDTO> ConsultarNaturaleza()
        {
            try
            {
                List<BasicaDTO> listParametro = new List<BasicaDTO>{
               new BasicaDTO { value = "PUBLICA", text  = "Pública" },
               new BasicaDTO { value = "PRIVADA", text  = "Privada" },
               new BasicaDTO { value = "MIXTA", text  = "Mixta" },
               //new BasicaDTO { value = "INDIGENA", text  = "Indígena" },
               //new BasicaDTO { value = "CONSEJO COMUNITARIO", text  = "Consejo Comunitario" },
        
            };

                listParametro = listParametro.OrderBy(d => d.text).ToList();

                return listParametro;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<BasicaDTO> ConsultarTiposDocumentos()
        {
            List<BasicaDTO> listBasicas = new List<BasicaDTO>();
            try
            {
                List<Basica> datos = ServicioBasicas.ConsultaTipoDocumentos();

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

        public static string ObtenerNombreEstado(int intEstadoId)
        {
            string nombre;
            try
            {

                nombre = ServicioBasicas.ObtenerNombreEstado(intEstadoId);

                return nombre;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
