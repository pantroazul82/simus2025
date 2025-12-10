using SM.Datos.DTO;
using SM.SIPA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Datos.RedSocial
{
    public static class RedSocialServicio
    {
        public static List<ART_MUSICA_RED_SOCIAL> ConsultarRedesSociales()
        {
            var listBasica = new List<ART_MUSICA_RED_SOCIAL>();
            try
            {
                using (var context = new SIPAEntities())
                {
                    listBasica = context.ART_MUSICA_RED_SOCIAL.Where(x => x.EsActivo == true).ToList();

                }
                return listBasica;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<RedSocialResultadoDTO> ConsultarRedesSocialesPorAgenteId(int AgenteId)
        {
            var listBasica = new List<RedSocialResultadoDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {
                    listBasica = (from u in context.ART_MUSICA_RED_SOCIAL
                                 select new RedSocialResultadoDTO
                                  {
                                      RedSocialId = u.Id,
                                      Nombre = u.Nombre,
                                      Estilo = u.Estilo,
                                      Etiqueta = u.Etiqueta,
                                      valor = (context.ART_MUSICA_RED_SOCIAL_ACTORES.Where(x => x.AgenteId == AgenteId && x.RedSocialId == u.Id).FirstOrDefault().Valor)
                                  }).ToList();

                }
                return listBasica;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<RedSocialResultadoDTO> ConsultarRedesSocialesPorAgrupacionId(int AgrupacionId)
        {
            var listBasica = new List<RedSocialResultadoDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {
                    listBasica = (from u in context.ART_MUSICA_RED_SOCIAL
                                  select new RedSocialResultadoDTO
                                   {
                                       RedSocialId = u.Id,
                                       Nombre = u.Nombre,
                                       Estilo = u.Estilo,
                                       Etiqueta = u.Etiqueta,
                                       valor = (context.ART_MUSICA_RED_SOCIAL_ACTORES.Where(x => x.AgrupacionId == AgrupacionId && x.RedSocialId == u.Id).FirstOrDefault().Valor)
                                   }).ToList();

                }
                return listBasica;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<RedSocialResultadoDTO> ConsultarRedesSocialesPorEntidadId(int EntidadId)
        {
            var listBasica = new List<RedSocialResultadoDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {
                    listBasica = (from u in context.ART_MUSICA_RED_SOCIAL
                                  select new RedSocialResultadoDTO
                                  {
                                      RedSocialId = u.Id,
                                      Nombre = u.Nombre,
                                      Estilo = u.Estilo,
                                      Etiqueta = u.Etiqueta,
                                      valor = (context.ART_MUSICA_RED_SOCIAL_ACTORES.Where(x => x.EntidadId == EntidadId && x.RedSocialId == u.Id).FirstOrDefault().Valor)
                                  }).ToList();

                }
                return listBasica;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void InsertarRedesSociales(ART_MUSICA_RED_SOCIAL_ACTORES red)
        {

            try
            {
                using (var context = new SIPAEntities())
                {
                    context.ART_MUSICA_RED_SOCIAL_ACTORES.Add(red);
                    context.SaveChanges();

                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void EliminarRedPorAgenteId(int AgenteId)
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    var model = context.ART_MUSICA_RED_SOCIAL_ACTORES.Where(x => x.AgenteId == AgenteId).FirstOrDefault();
                    if (model != null)
                    {
                        context.ART_MUSICA_RED_SOCIAL_ACTORES.RemoveRange(context.ART_MUSICA_RED_SOCIAL_ACTORES.Where(x => x.AgenteId == AgenteId));
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void EliminarRedPorAgrupacionId(int AgrupacionId)
        {
            try
            {

                using (var context = new SIPAEntities())
                {

                    var model = context.ART_MUSICA_RED_SOCIAL_ACTORES.Where(x => x.AgrupacionId == AgrupacionId).FirstOrDefault();
                    if (model != null)
                    {
                        context.ART_MUSICA_RED_SOCIAL_ACTORES.RemoveRange(context.ART_MUSICA_RED_SOCIAL_ACTORES.Where(x => x.AgrupacionId == AgrupacionId));
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void EliminarRedPorEntidadId(int EntidadId)
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    var model = context.ART_MUSICA_RED_SOCIAL_ACTORES.Where(x => x.AgrupacionId == EntidadId).FirstOrDefault();
                    if (model != null)
                    {
                        context.ART_MUSICA_RED_SOCIAL_ACTORES.RemoveRange(context.ART_MUSICA_RED_SOCIAL_ACTORES.Where(x => x.EntidadId == EntidadId));
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
