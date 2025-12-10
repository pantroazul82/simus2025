using SM.LibreriaComun.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SM.Datos.DTO;
using SM.Datos.Basicas;
using SM.Aplicacion.Modulo_Usuarios;
using SM.LibreriaComun.DTO.General;

namespace SM.Aplicacion.Basicas
{
    public class CaracterizacionMusicalNeg
    {
        public static List<EstandarDTO> ConsultarOficios()
        {
            var lisParametro = new List<EstandarDTO>();
            try
            {
                List<Parametro> Parametrodatos = CaracterizacionMusicalServicio.ConsultarOficiosMusical();
       
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

        public static List<BasicaDTO> ConsultarAgentes(int UsuarioId)
        {
            var lisParametro = new List<BasicaDTO>();
            try
            {
                List<Parametro> Parametrodatos = CaracterizacionMusicalServicio.ConsultarAgentePorUsuarioId(UsuarioId);

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

        public static List<BasicaDTO> ConsultarAgentesAdmin()
        {
            var lisParametro = new List<BasicaDTO>();
            try
            {
                List<Parametro> Parametrodatos = CaracterizacionMusicalServicio.ConsultarAgenteAdmin();

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

        public static List<BasicaDTO> ConsultarEntidadPorUsuarioId(int UsuarioId)
        {
            var lisParametro = new List<BasicaDTO>();
            try
            {
                List<Parametro> Parametrodatos = CaracterizacionMusicalServicio.ConsultarEntidadPorUsuarioId(UsuarioId);

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

        public static List<BasicaDTO> ConsultarEntidadAdmin()
        {
            var lisParametro = new List<BasicaDTO>();
            try
            {
                List<Parametro> Parametrodatos = CaracterizacionMusicalServicio.ConsultarEntidadAdmin();

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

        public static List<BasicaDTO> ConsultarAgrupacionPorUsuarioId(int UsuarioId)
        {
            var lisParametro = new List<BasicaDTO>();
            try
            {
                List<Parametro> Parametrodatos = CaracterizacionMusicalServicio.ConsultarAgrupacionPorUsuarioId(UsuarioId);

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

        public static List<BasicaDTO> ConsultarAgrupacionAdmin()
        {
            var lisParametro = new List<BasicaDTO>();
            try
            {
                List<Parametro> Parametrodatos = CaracterizacionMusicalServicio.ConsultarAgrupacionAdmin();

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

        public static List<BasicaDTO> ConsultarEscuelasPorUsuarioId(decimal UsuarioSipaId)
        {
            var lisParametro = new List<BasicaDTO>();
           
            try
            {
                List<Parametro> Parametrodatos = CaracterizacionMusicalServicio.ConsultarEscuelasPorUsuarioId(UsuarioSipaId);

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

        public static List<BasicaDTO> ConsultarEscuelasAdmin()
        {
            var lisParametro = new List<BasicaDTO>();

            try
            {
                List<Parametro> Parametrodatos = CaracterizacionMusicalServicio.ConsultarEscuelasAdmin();

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

        public static List<EstandarDTO> ConsultarInstrumentos()
        {
            var lisParametro = new List<EstandarDTO>();
            try
            {
               List<Parametro> listInstrumentos = CaracterizacionMusicalServicio.ConsultarInstrumentos();

               foreach (var item in listInstrumentos)
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

        public static string ObenerNombreInstrumento(int Id)
        {
            string Nombre = "";
            try
            {
                return Nombre= CaracterizacionMusicalServicio.ObenerNombreInstrumento(Id);

              
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<BasicaDTO> ConsultarListadoInstrumentos()
        {
            var lisParametro = new List<BasicaDTO>();
            try
            {
                List<Parametro> listInstrumentos = CaracterizacionMusicalServicio.ConsultarListadoInstrumentos();

                foreach (var item in listInstrumentos)
                {
                    BasicaDTO objParametro = new BasicaDTO();

                    objParametro.value = item.Id.ToString();
                    objParametro.text = item.Nombre;
                    lisParametro.Add(objParametro);

                }

       

                return lisParametro;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<EstandarDTO> ConsultarServicios()
        {
            var lisParametro = new List<EstandarDTO>();
            try
            {
                List<Parametro> Parametrodatos = CaracterizacionMusicalServicio.ConsultarServicios();

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

        public static List<EstandarDTO> ConsultarAgentes()
        {
            var lisParametro = new List<EstandarDTO>();
            try
            {
                List<Parametro> Parametrodatos = CaracterizacionMusicalServicio.ConsultarAgentes();

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

        public static List<EstandarDTO> ConsultarGenerosMusicalesNuevo()
        {
            var lisParametro = new List<EstandarDTO>();
            try
            {
                List<Parametro> Parametrodatos = CaracterizacionMusicalServicio.ConsultarGenerosMusicalesNuevo();

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

        public static List<EstandarDTO> ConsultarIntereses()
        {
            var lisParametro = new List<EstandarDTO>();
            try
            {
                List<Parametro> Parametrodatos = CaracterizacionMusicalServicio.ConsultarIntereses();

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

        public static List<EstandarDTO> ConsultarTipoEntidad()
        {
            var lisParametro = new List<EstandarDTO>();
            try
            {
                List<Parametro> Parametrodatos = CaracterizacionMusicalServicio.ConsultarTipoEntidad();

                foreach (var item in Parametrodatos)
                {
                    var objParametro = new EstandarDTO();
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

        public static List<BasicaDTO> ConsultarEstados()
        {
            var lisParametro = new List<BasicaDTO>();
            try
            {
                List<Parametro> Parametrodatos = CaracterizacionMusicalServicio.ConsultarEstados();

                foreach (var item in Parametrodatos)
                {
                    var objParametro = new BasicaDTO();
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

        public static List<BasicaDTO> ConsultarTipoAgrupacion()
        {
            var lisParametro = new List<BasicaDTO>();
            try
            {
                List<Parametro> Parametrodatos = CaracterizacionMusicalServicio.ConsultarTipoAgrupacion();

                foreach (var item in Parametrodatos)
                {
                    var objParametro = new BasicaDTO();
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

        public static List<BasicaDTO> ConsultarNaturaleza()
        {
            var lisParametro = new List<BasicaDTO>();
            try
            {
                List<Parametro> Parametrodatos = CaracterizacionMusicalServicio.ConsultarNaturaleza();

                foreach (var item in Parametrodatos)
                {
                    var objParametro = new BasicaDTO();
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

        public static List<EstandarDTO> ConsultarGenerosMusicales()
        {
            var lisParametro = new List<EstandarDTO>();
            try
            {
                List<GenerosMusicalesResultadoDTO> Parametrodatos = CaracterizacionMusicalServicio.ConsultarGenerosMusicales();

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


        public static List<EstandarDTO> ConsultarGenerosMusicalesPorAgenteId(int AgenteId)
        {
            var lisParametro = new List<EstandarDTO>();
            try
            {
                List<Parametro> Parametrodatos = CaracterizacionMusicalServicio.ConsultarGenerosMusicalesPorAgenteId(AgenteId);

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
        public static List<EstandarDTO> ConsultarAgenteGenerosSeleccionados(int AgenteId)
        {
            var lisParametro = new List<EstandarDTO>();
            try
            {
                List<Parametro> Parametrodatos = CaracterizacionMusicalServicio.ConsultarAgenteGenerosSeleccionados(AgenteId);

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

        public static List<EstandarDTO> ConsultarAgrupacionGenerosSeleccionados(int AgrupacionId)
        {
            var lisParametro = new List<EstandarDTO>();
            try
            {
                List<Parametro> Parametrodatos = CaracterizacionMusicalServicio.ConsultarAgrupacionGenerosSeleccionados(AgrupacionId);

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

        public static List<EstandarDTO> ConsultarAgenteOficiosSeleccionada(int AgenteId)
        {
            var lisParametro = new List<EstandarDTO>();
            try
            {
                List<Parametro> Parametrodatos = CaracterizacionMusicalServicio.ConsultarAgenteOficiosSeleccionada(AgenteId);

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

        public static List<EstandarDTO> ConsultarTipoEntidadSeleccionada(int EntidadId)
        {
            var lisParametro = new List<EstandarDTO>();
            try
            {
                List<Parametro> Parametrodatos = CaracterizacionMusicalServicio.ConsultarTipoEntidadSeleccionada(EntidadId);

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

        public static List<BasicaDTO> ConsultarCategoriaCelebra()
        {
            var lisParametro = new List<BasicaDTO>();
            try
            {
                List<Parametro> Parametrodatos = CaracterizacionMusicalServicio.ConsultarCategoriaCelebra();

                foreach (var item in Parametrodatos)
                {
                    var objParametro = new BasicaDTO();
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

        public static List<BasicaDTO> ConsultarProcesoFormacionCelebra()
        {
            var lisParametro = new List<BasicaDTO>();
            try
            {
                List<Parametro> Parametrodatos = CaracterizacionMusicalServicio.ConsultarProcesoFormacionCelebra();

                foreach (var item in Parametrodatos)
                {
                    var objParametro = new BasicaDTO();
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

        #region CertificacionSIMUS

        public static CertificacionDTO ObtenerdatosEscuelas(decimal EscuelaId)
        {
            var registro = new CertificacionDTO();
            try
            {
                registro = CaracterizacionMusicalServicio.ObtenerdatosEscuelas(EscuelaId);

                return registro;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static CertificacionDTO ObtenerdatosAgentes(Int32 AgenteId)
        {
            var registro = new CertificacionDTO();
            try
            {
                registro = CaracterizacionMusicalServicio.ObtenerdatosAgentes(AgenteId);

                return registro;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static CertificacionDTO ObtenerdatosEntidades(Int32 entidadid)
        {
            var registro = new CertificacionDTO();
            try
            {
                registro = CaracterizacionMusicalServicio.ObtenerdatosEntidades(entidadid);

                return registro;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static CertificacionDTO ObtenerdatosAgrupacion(Int32 agrupacionID)
        {
            var registro = new CertificacionDTO();
            try
            {
                registro = CaracterizacionMusicalServicio.ObtenerdatosAgrupacion(agrupacionID);

                return registro;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
