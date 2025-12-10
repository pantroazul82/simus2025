using SM.LibreriaComun.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SM.Datos.DTO;
using SM.Datos.Escuelas;
using SM.Datos.Basicas;
using SM.SIPA;

namespace SM.Aplicacion.Basicas
{
    public class ParametrosLogica
    {

       

        public static string ConsultarNombreRegimen(decimal Id)
        {
            string Nombre = "";
            try
            {
                Nombre = BasicaEscuelas.ConsultarNombreRegimen(Id);
                return Nombre;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string ConsultarTipoVinculacion(int Id)
        {
            string Nombre = "";
            try
            {
                Nombre = BasicaEscuelas.ConsultarTipoVinculacion(Id);
                return Nombre;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string ConsultarNombreNiveles(int Id)
        {
            string Nombre = "";
            try
            {
                Nombre = BasicaEscuelas.ConsultarNombreNivelAdministracion(Id);
                return Nombre;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string ConsultarNombreEspacio(decimal Id)
        {
            string Nombre = "";
            try
            {
                Nombre = BasicaEscuelas.ConsultarNombreEspacio(Convert.ToInt32(Id));
                return Nombre;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string ConsultarNombreOrganizacionComunitaria(int Id)
        {
            string Nombre = "";
            try
            {
                Nombre = BasicaEscuelas.ConsultarNombreOrganizacionComunitaria(Id);
                return Nombre;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<BasicaDTO> ConsultarRegimenPadre()
        {
            List<BasicaDTO> lisParametro = new List<BasicaDTO>();
            try
            {
                List<Parametro> Parametrodatos = BasicaEscuelas.ConsultarRegimenPadre();

                foreach (var item in Parametrodatos)
                {
                    BasicaDTO objParametro = new BasicaDTO();
                    objParametro.value = item.Id.ToString();
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

        public static List<BasicaDTO> ConsultarRegimenHijos(string PadreId)
        {
            List<BasicaDTO> lisParametro = new List<BasicaDTO>();
            try
            {
                if (!String.IsNullOrEmpty(PadreId))
                {
                    List<Parametro> Parametrodatos = BasicaEscuelas.ConsultarRegimenHijos(Convert.ToDecimal(PadreId));

                    foreach (var item in Parametrodatos)
                    {
                        BasicaDTO objParametro = new BasicaDTO();
                        objParametro.value = item.Id.ToString();
                        objParametro.text = item.Nombre;
                        lisParametro.Add(objParametro);
                    }
                }
                lisParametro = lisParametro.OrderBy(d => d.text).ToList();

                return lisParametro;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<BasicaDTO> ConsultarNivelesAdministracion()
        {
            List<BasicaDTO> lisParametro = new List<BasicaDTO>();
            try
            {
                List<Parametro> Parametrodatos = BasicaEscuelas.ConsultarNivelesAdministracion();

                    foreach (var item in Parametrodatos)
                    {
                        BasicaDTO objParametro = new BasicaDTO();
                        objParametro.value = item.Id.ToString();
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

        public static List<BasicaDTO> ConsultarTipoVinculacionDirector()
        {
            List<BasicaDTO> lisParametro = new List<BasicaDTO>();
            try
            {
                List<Parametro> Parametrodatos = BasicaEscuelas.ConsultarTipoVinculacionDirector();

                foreach (var item in Parametrodatos)
                {
                    BasicaDTO objParametro = new BasicaDTO();
                    objParametro.value = item.Id.ToString();
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

        public static List<BasicaDTO> ConsultarPracticasMusicales()
        {
            List<BasicaDTO> lisParametro = new List<BasicaDTO>();
            try
            {
                List<Parametro> Parametrodatos = ServicioBasicas.ConsultarPracticasMusicales();

                foreach (var item in Parametrodatos)
                {
                    BasicaDTO objParametro = new BasicaDTO();
                    objParametro.value = item.Id.ToString();
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

        public static List<BasicaDTO> ConsultarPracticasFormacionDocentes()
        {
            List<BasicaDTO> lisParametro = new List<BasicaDTO>();
            try
            {
                List<Parametro> Parametrodatos = ServicioBasicas.ConsultarPracticasFormacionDocentes();

                foreach (var item in Parametrodatos)
                {
                    BasicaDTO objParametro = new BasicaDTO();
                    objParametro.value = item.Id.ToString();
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

        public static List<BasicaDTO> ConsultarTipoEscuelasMusica()
        {
            List<BasicaDTO> lisParametro = new List<BasicaDTO>();
            try
            {
                List<Parametro> Parametrodatos = BasicaEscuelas.ConsultarTipoEscuelasMusica();

                foreach (var item in Parametrodatos)
                {
                    BasicaDTO objParametro = new BasicaDTO();
                    objParametro.value = item.Id.ToString();
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

        public static string ObtenerNombreTipoEscuela(int Id)
        {
            string nombre = string.Empty;
            try
            {
                nombre = BasicaEscuelas.ObtenerNombreTipoEscuela(Id);


                return nombre;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string obtenerNombreParametro(int Id)
        {
            string nombre = string.Empty;
            try
            {
                nombre = ServicioBasicas.obtenerNombreParametro(Id);


                return nombre;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<BasicaDTO> ConsultarEjes()
        {
            List<BasicaDTO> lisParametro = new List<BasicaDTO>();
            try
            {
                List<Parametro> Parametrodatos = BasicaEscuelas.ConsultarEjes();

                foreach (var item in Parametrodatos)
                {
                    BasicaDTO objParametro = new BasicaDTO();
                    objParametro.value = item.Id.ToString();
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
        public static List<BasicaDTO> ConsultarTradicionalGeneros()
        {
            List<BasicaDTO> lisParametro = new List<BasicaDTO>();
            try
            {
                List<Parametro> Parametrodatos = BasicaEscuelas.ConsultarTradicionalGeneros();

                foreach (var item in Parametrodatos)
                {
                    BasicaDTO objParametro = new BasicaDTO();
                    objParametro.value = item.Id.ToString();
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

        public static List<BasicaDTO> ConsultarTipoEscuelasDanza()
        {
            List<BasicaDTO> lisParametro = new List<BasicaDTO>();
            try
            {
                List<Parametro> Parametrodatos = BasicaEscuelas.ConsultarTipoEscuelasDanza();

                foreach (var item in Parametrodatos)
                {
                    BasicaDTO objParametro = new BasicaDTO();
                    objParametro.value = item.Id.ToString();
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
        public static List<BasicaDTO> ConsultarPracticaMusicalSeleccionada(decimal EntId)
        {
            List<BasicaDTO> lisParametro = new List<BasicaDTO>();
            List<ART_ME_ART_MUSICA_PRACTICAMUSICAL_ObtenerPorENT_ID_Result> resultado;
            try
            {
                resultado = ServicioBasicas.ConsultarPracticaMusicalSeleccionada(EntId);

                foreach (var item in resultado)
                {
                    BasicaDTO objParametro = new BasicaDTO();
                    objParametro.value = item.ART_MUS_PRAC_MUS_ID.ToString();
                    objParametro.text = item.ART_MUS_PRAC_MUS_DESCRIPCION;
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

        public static List<BasicaDTO> ConsultarPracticasMusicalesPNMC(decimal EntId)
        {
            List<BasicaDTO> lisParametro = new List<BasicaDTO>();
            List<Parametro> resultado;
            try
            {
                resultado = ServicioBasicas.ConsultarPracticasMusicalesPNMC(EntId);

                foreach (var item in resultado)
                {
                    BasicaDTO objParametro = new BasicaDTO();
                    objParametro.value = item.Id.ToString();
                    objParametro.text = "";
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

        //Infraestructura
        public static List<BasicaDTO> ConsultarEspacios()
        {
            List<BasicaDTO> lisParametro = new List<BasicaDTO>();
            try
            {
                List<Parametro> Parametrodatos = BasicaEscuelas.ConsultarEspacios();

                foreach (var item in Parametrodatos)
                {
                    BasicaDTO objParametro = new BasicaDTO();
                    objParametro.value = item.Id.ToString();
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

        public static List<BasicaDTO> ConsultarOrganizacionComunitaria()
        {
            List<BasicaDTO> lisParametro = new List<BasicaDTO>();
            try
            {
                List<Parametro> Parametrodatos = BasicaEscuelas.ConsultarOrganizacionComunitaria();

                foreach (var item in Parametrodatos)
                {
                    BasicaDTO objParametro = new BasicaDTO();
                    objParametro.value = item.Id.ToString();
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

        public static List<EstandarDTO> ConsultarFuentesDotacion()
        {
            List<EstandarDTO> lisParametro = new List<EstandarDTO>();
            try
            {
                List<Parametro> Parametrodatos = BasicaEscuelas.ConsultarFuentesDotacion();

                foreach (var item in Parametrodatos)
                {
                    EstandarDTO objParametro = new EstandarDTO();
                    objParametro.Id = item.Id.ToString();
                    objParametro.Nombre = item.Nombre;
                    lisParametro.Add(objParametro);
                }

                lisParametro = lisParametro.OrderBy(d => d.Nombre).ToList();

                return lisParametro;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<EstandarDTO> ConsultarProyectosParticipacion()
        {
            List<EstandarDTO> lisParametro = new List<EstandarDTO>();
            try
            {
                List<Parametro> Parametrodatos = BasicaEscuelas.ConsultarProyectosParticipacion();

                foreach (var item in Parametrodatos)
                {
                    EstandarDTO objParametro = new EstandarDTO();
                    objParametro.Id = item.Id.ToString();
                    objParametro.Nombre = item.Nombre;
                    lisParametro.Add(objParametro);
                }

                lisParametro = lisParametro.OrderBy(d => d.Nombre).ToList();

                return lisParametro;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<EstandarDTO> ConsultarSolucionesAcusticas()
        {
            List<EstandarDTO> lisParametro = new List<EstandarDTO>();
            try
            {
                List<Parametro> Parametrodatos = BasicaEscuelas.ConsultarSolucionesAcusticas();

                foreach (var item in Parametrodatos)
                {
                    EstandarDTO objParametro = new EstandarDTO();
                    objParametro.Id = item.Id.ToString();
                    objParametro.Nombre = item.Nombre;
                    lisParametro.Add(objParametro);
                }

                lisParametro = lisParametro.OrderBy(d => d.Nombre).ToList();

                return lisParametro;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<EstandarDTO> ConsultarTiposFuentesDotacion()
        {
            List<EstandarDTO> lisParametro = new List<EstandarDTO>();
            try
            {
                List<Parametro> Parametrodatos = BasicaEscuelas.ConsultarTiposFuentesDotacion();

                foreach (var item in Parametrodatos)
                {
                    EstandarDTO objParametro = new EstandarDTO();
                    objParametro.Id = item.Id.ToString();
                    objParametro.Nombre = item.Nombre;
                    lisParametro.Add(objParametro);
                }

                lisParametro = lisParametro.OrderBy(d => d.Nombre).ToList();

                return lisParametro;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<EstandarDTO> ConsultarMaterialPedagogico()
        {
            List<EstandarDTO> lisParametro = new List<EstandarDTO>();
            try
            {
                List<Parametro> Parametrodatos = BasicaEscuelas.ConsultarMaterialPedagogico();

                foreach (var item in Parametrodatos)
                {
                    EstandarDTO objParametro = new EstandarDTO();
                    objParametro.Id = item.Id.ToString();
                    objParametro.Nombre = item.Nombre;
                    lisParametro.Add(objParametro);
                }

                lisParametro = lisParametro.OrderBy(d => d.Nombre).ToList();

                return lisParametro;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<EstandarDTO> ConsultarTiposInternet()
        {
            List<EstandarDTO> lisParametro = new List<EstandarDTO>();
            try
            {
                List<Parametro> Parametrodatos = BasicaEscuelas.ConsultarTiposInternet();

                foreach (var item in Parametrodatos)
                {
                    EstandarDTO objParametro = new EstandarDTO();
                    objParametro.Id = item.Id.ToString();
                    objParametro.Nombre = item.Nombre;
                    lisParametro.Add(objParametro);
                }

                lisParametro = lisParametro.OrderBy(d => d.Nombre).ToList();

                return lisParametro;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<EstandarDTO> ConsultarTiposInternetSeleccionados(decimal EntId)
        {
            List<EstandarDTO> lisParametro = new List<EstandarDTO>();
            try
            {
                List<Parametro> Parametrodatos = BasicaEscuelas.ConsultarTiposInternetSeleccionados(EntId);

                foreach (var item in Parametrodatos)
                {
                    EstandarDTO objParametro = new EstandarDTO();
                    objParametro.Id = item.Id.ToString();
                    objParametro.Nombre = item.Nombre;
                    lisParametro.Add(objParametro);
                }

                lisParametro = lisParametro.OrderBy(d => d.Nombre).ToList();

                return lisParametro;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<EstandarDTO> ConsultarFuentesDotacionSeleccionada(decimal EntId)
        {
            List<EstandarDTO> lisParametro = new List<EstandarDTO>();
            List<ART_ME_ART_MUSICA_FUENTES_DOTACION_ObtenerPorENT_ID_Result> resultado;
            try
            {
                resultado = BasicaEscuelas.ConsultarFuentesDotacionSeleccionada(EntId);

                foreach (var item in resultado)
                {
                    EstandarDTO objParametro = new EstandarDTO();
                    objParametro.Id = item.ART_MUSICA_FUENTES_DOTACION_ID.ToString();
                    objParametro.Nombre = item.ART_MUSICA_FUENTES_DOTACION_DESCRIPCION;
                    lisParametro.Add(objParametro);
                }

                lisParametro = lisParametro.OrderBy(d => d.Nombre).ToList();

                return lisParametro;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<EstandarDTO> ConsultarProyectosParticipacionSeleccionada(decimal EntId)
        {
            List<EstandarDTO> lisParametro = new List<EstandarDTO>();
            List<ART_ME_ART_MUSICA_PROYECTOSORGANIZACION_ObtenerPorENT_ID_Result> resultado;
            try
            {
                resultado = BasicaEscuelas.ConsultarProyectosParticipacionSeleccionada(EntId);

                foreach (var item in resultado)
                {
                    EstandarDTO objParametro = new EstandarDTO();
                    objParametro.Id = item.ART_MUS_TIP_PROY_ORG_COM_ID.ToString();
                    objParametro.Nombre = item.ART_MUS_TIP_PROY_ORG_COM_DESCRIPCION; 
                    lisParametro.Add(objParametro);
                }

                lisParametro = lisParametro.OrderBy(d => d.Nombre).ToList();

                return lisParametro;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<EstandarDTO> ConsultarTiposFuentesDotacionSeleccionada(decimal EntId)
        {
            List<EstandarDTO> lisParametro = new List<EstandarDTO>();
            List<ART_ME_ART_MUSICA_FUENTES_DOTACION_ObtenerPorENT_ID_produccion_Result> resultado;
            try
            {
                resultado = BasicaEscuelas.ConsultarTiposFuentesDotacionSeleccionada(EntId);

                foreach (var item in resultado)
                {
                    EstandarDTO objParametro = new EstandarDTO();
                    objParametro.Id = item.ART_MUSICA_FUENTES_DOTACION_ID.ToString();
                    objParametro.Nombre = item.ART_MUSICA_FUENTES_DOTACION_DESCRIPCION;
                    lisParametro.Add(objParametro);
                }

                lisParametro = lisParametro.OrderBy(d => d.Nombre).ToList();

                return lisParametro;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<EstandarDTO> ConsultarMaterialPedagogicoSeleccionada(decimal EntId)
        {
            List<EstandarDTO> lisParametro = new List<EstandarDTO>();
            List<ART_ME_ART_MUSICA_ENT_INFR_MATERIAL_PEGAOGICO_ObtenerPorENT_ID_Result> resultado;
            try
            {
                resultado = BasicaEscuelas.ConsultarMaterialPedagogicoSeleccionada(EntId);

                foreach (var item in resultado)
                {
                    EstandarDTO objParametro = new EstandarDTO();
                    objParametro.Id = item.ART_MUS_MAT_PED_ID.ToString();
                    objParametro.Nombre = "";
                    lisParametro.Add(objParametro);
                }

                lisParametro = lisParametro.OrderBy(d => d.Nombre).ToList();

                return lisParametro;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<EstandarDTO> ConsultarSolucionesAcusticasSeleccionada(decimal EntId)
        {
            List<EstandarDTO> lisParametro = new List<EstandarDTO>();
            List<ART_ME_ART_ME_ESCUELA_SOLUCIONES_ACUSTICAS_ObtenerPorId_Result> resultado;
            try
            {
                resultado = BasicaEscuelas.ConsultarSolucionesAcusticasSeleccionada(EntId);

                foreach (var item in resultado)
                {
                    EstandarDTO objParametro = new EstandarDTO();
                    objParametro.Id = item.SAC_ID.ToString();
                    objParametro.Nombre = "";
                    lisParametro.Add(objParametro);
                }

                lisParametro = lisParametro.OrderBy(d => d.Nombre).ToList();

                return lisParametro;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
    }
}
