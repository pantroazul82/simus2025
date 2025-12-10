using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SM.Datos.Entidades;
using SM.SIPA;
using SM.LibreriaComun.DTO;
using SM.Datos.DTO;
using SM.Datos.RedSocial;

namespace SM.Aplicacion.RedSocial
{
    public class RedSocialNeg
    {
        public static List<RedSocialDTO> ObtenerRedSocial()
        {
            try
            {
                var model = new List<ART_MUSICA_RED_SOCIAL>();
                var listado = new List<RedSocialDTO>();
                model = RedSocialServicio.ConsultarRedesSociales();

                if (model != null)
                {
                    foreach (var item in model)
                    {
                        var datos = new RedSocialDTO();
                        datos.Estilo = item.Estilo;
                        datos.Nombre = item.Nombre;
                        datos.RedSocialId = item.Id;
                        datos.Etiqueta = item.Etiqueta; 
                        datos.valor = " ";
                        listado.Add(datos);
                    }

                }


                return listado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<RedSocialDTO> ObtenerRedSocialporActor(int RegistroId, string Tipo)
        {
            try
            {
                var model = new List<RedSocialResultadoDTO>();
                var listado = new List<RedSocialDTO>();
                if (Tipo == "Agente")
                model = RedSocialServicio.ConsultarRedesSocialesPorAgenteId(RegistroId);
                else if (Tipo == "Agrupacion")
                    model = RedSocialServicio.ConsultarRedesSocialesPorAgrupacionId(RegistroId);
                else if (Tipo == "Entidad")
                    model = RedSocialServicio.ConsultarRedesSocialesPorEntidadId(RegistroId);

                if (model != null)
                {
                    foreach (var item in model)
                    {
                        var datos = new RedSocialDTO();
                        datos.Estilo = item.Estilo;
                        datos.Nombre = item.Nombre;
                        datos.RedSocialId = item.RedSocialId;
                        datos.Etiqueta = item.Etiqueta;
                        datos.valor = item.valor;
                        listado.Add(datos);
                    }

                }

              

                return listado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public static void InsertarRedesSocialAgente(List<RedSocialDTO> redsocial, int AgenteId)
        {
            try {

                RedSocialServicio.EliminarRedPorAgenteId(AgenteId);
                foreach(var item in redsocial )
                {
                    if (!String.IsNullOrEmpty(item.valor.Trim()))
                    {
                        var registro = new ART_MUSICA_RED_SOCIAL_ACTORES();
                        registro.AgenteId = AgenteId;
                        registro.RedSocialId = item.RedSocialId;
                        registro.Valor = item.valor;
                        RedSocialServicio.InsertarRedesSociales(registro);
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public static void InsertarRedesSocialAgrupacion(List<RedSocialDTO> redsocial, int AgrupacionId)
        {
            try
            {

                RedSocialServicio.EliminarRedPorAgrupacionId(AgrupacionId);
                foreach (var item in redsocial)
                {
                    var registro = new ART_MUSICA_RED_SOCIAL_ACTORES();
                    registro.AgrupacionId = AgrupacionId;
                    registro.RedSocialId = item.RedSocialId;
                    registro.Valor = item.valor;
                    RedSocialServicio.InsertarRedesSociales(registro);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void InsertarRedesSocialEntidad(List<RedSocialDTO> redsocial, int EntidadId)
        {
            try
            {

                RedSocialServicio.EliminarRedPorEntidadId(EntidadId);
                foreach (var item in redsocial)
                {
                    var registro = new ART_MUSICA_RED_SOCIAL_ACTORES();
                    registro.EntidadId = EntidadId;
                    registro.RedSocialId = item.RedSocialId;
                    registro.Valor = item.valor;
                    RedSocialServicio.InsertarRedesSociales(registro);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
