using SM.Datos.AuditoriaData;
using SM.Datos.DTO;
using SM.LibreriaComun.DTO;
using SM.SIPA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Datos.Basicas
{
   public class BusquedaServicio
    {

       public static List<BusquedaResultadoDTO> ConsultarEventos(string parametro)
       {
           var model = new List<BusquedaResultadoDTO>();
           try
           {

               using (var context = new SIPAEntities())
               {

                   model = (from e in context.ART_MUSICA_MODULO_SERVICIOS
                            where e.EstadoId == 2
                            where e.EsActivo == true
                            where e.TipoServicioId == 50
                            where (e.Titulo.Contains(parametro) || (e.Municipio.Contains(parametro)) || (e.Departamento.Contains(parametro)))
                            orderby e.Titulo
                            select new BusquedaResultadoDTO
                            {
                                Id = e.Id,
                                Titulo = e.Titulo,
                                Descripcion = e.Descripcion
                            }).ToList();

                   return model;

               }


           }
           catch (Exception)
           {
               throw;
           }
       }
       public static List<BusquedaResultadoDTO> ConsultarEscuelas(string parametro)
       {
           var model = new List<BusquedaResultadoDTO>();
           try
           {

               using (var context = new SIPAEntities())
               {

                    model = (from e in context.ART_ENTIDADES_ARTES
                                join i in context.ART_MUSICA_ENTIDAD_IDENTIFICACION on e.ENT_ID equals i.ENT_ID
                                join u in context.ART_ENTIDAD_UBICACION on e.ENT_ID equals u.ENT_ID                         
                                join z in context.BAS_ZONAS_GEOGRAFICAS on u.ZON_ID equals z.ZON_ID
                                join d in context.BAS_ZONAS_GEOGRAFICAS on z.ZON_PADRE_ID equals d.ZON_ID
                                where e.ENT_TIPO == "E"
                                where i.EstadoId == 2
                             where (e.ENT_NOMBRE.Contains(parametro) || (z.ZON_NOMBRE.Contains(parametro)) || (d.ZON_NOMBRE.Contains(parametro)))
                                orderby e.ENT_NOMBRE
                                select new BusquedaResultadoDTO
                                {
                                    Id = (int) e.ENT_ID ,
                                    Titulo = e.ENT_NOMBRE,
                                    Descripcion = e.ENT_RESENA
                                }).ToList();

                   return model;

               }


           }
           catch (Exception)
           {
               throw;
           }
       }

       public static List<BusquedaResultadoDTO> ConsultarEntidades(string parametro)
       {
           var model = new List<BusquedaResultadoDTO>();
           try
           {

               using (var context = new SIPAEntities())
               {

                   model = (from e in context.ART_MUSICA_ENTIDADES
                            join z in context.BAS_ZONAS_GEOGRAFICAS on  e.CodigoMunicipio equals z.ZON_ID
                            join d in context.BAS_ZONAS_GEOGRAFICAS on z.ZON_PADRE_ID equals d.ZON_ID
                            where e.EstadoId == 2
                            where (e.Nombre.Contains(parametro) || (z.ZON_NOMBRE.Contains(parametro)) || (d.ZON_NOMBRE.Contains(parametro)))
                            orderby e.Nombre
                            select new BusquedaResultadoDTO
                            {
                                Id = e.Id,
                                Titulo = e.Nombre,
                                Descripcion = e.Descripcion
                            }).ToList();

                   return model;

               }


           }
           catch (Exception)
           {
               throw;
           }
       }

       public static List<BusquedaResultadoDTO> ConsultarAgrupacion(string parametro)
       {
           var model = new List<BusquedaResultadoDTO>();
           try
           {

               using (var context = new SIPAEntities())
               {

                   model = (from e in context.ART_MUSICA_AGRUPACION
                            join z in context.BAS_ZONAS_GEOGRAFICAS on e.CodigoMunicipio equals z.ZON_ID
                            join d in context.BAS_ZONAS_GEOGRAFICAS on z.ZON_PADRE_ID equals d.ZON_ID
                            where e.EstadoId == 2
                            where (e.Nombre.Contains(parametro) || (z.ZON_NOMBRE.Contains(parametro)) || (d.ZON_NOMBRE.Contains(parametro)))
                            orderby e.Nombre
                            select new BusquedaResultadoDTO
                            {
                                Id = e.Id,
                                Titulo = e.Nombre,
                                Descripcion = e.Descripcion
                            }).ToList();

                   return model;

               }


           }
           catch (Exception)
           {
               throw;
           }
       }

       public static List<BusquedaResultadoDTO> ConsultarAgentes(string parametro)
       {
           var model = new List<BusquedaResultadoDTO>();
           try
           {

               using (var context = new SIPAEntities())
               {

                   model = (from e in context.ART_MUSICA_AGENTE
                            join z in context.BAS_ZONAS_GEOGRAFICAS on e.CodMunicipio equals z.ZON_ID
                            join d in context.BAS_ZONAS_GEOGRAFICAS on z.ZON_PADRE_ID equals d.ZON_ID
                            where e.EstadoId == 2
                            where (e.PrimerNombre.Contains(parametro) || e.SegundoNombre.Contains(parametro) || e.PrimerApellido.Contains(parametro) || e.SedundoApellido.Contains(parametro) || (z.ZON_NOMBRE.Contains(parametro)) || (d.ZON_NOMBRE.Contains(parametro)))
                            orderby e.PrimerNombre
                            select new BusquedaResultadoDTO
                            {
                                Id = e.ID,
                                Titulo = e.PrimerNombre + " " + e.SegundoNombre + " " + e.PrimerApellido + " " + e.SedundoApellido,
                                Descripcion = e.Descripcion
                            }).ToList();

                   return model;

               }


           }
           catch (Exception)
           {
               throw;
           }
       }
    }
}
