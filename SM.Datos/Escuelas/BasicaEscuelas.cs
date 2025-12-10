using SM.Datos.DTO;
using SM.SIPA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Datos.Escuelas
{
   public class BasicaEscuelas
    {
       // Método deshabilitado - Tabla ART_REGIMEN_ENTIDAD no existe en BD
       public static string ConsultarNombreRegimen(decimal Id)
       {
           // Retorna cadena vacía porque la tabla no existe
           return string.Empty;
       }

       public static string ConsultarTipoVinculacion(int Id)
       {
           string Nombre = "";
           try
           {
               using (var context = new SIPAEntities())
               {

                   Nombre = context.ART_MUSICA_TIPO_VINCULACION.Where(x => x.ID_TIPO_VINCULACION == Id).FirstOrDefault().DESCRIPCION_TIPO_VINCULACION;

               }
               return Nombre;

           }
           catch (Exception)
           {
               throw;
           }
       }

       // Método deshabilitado - Tabla ART_NIVEL_ADMINISTRACION no existe en BD
       public static string ConsultarNombreNivelAdministracion(int Id)
       {
           return string.Empty;
       }

       // Método deshabilitado - Tabla ART_ESPACIO_PRINCIPAL no existe en BD
       public static string ConsultarNombreEspacio(int Id)
       {
           return string.Empty;
       }

       public static string ConsultarNombreOrganizacionComunitaria(int Id)
       {
           string Nombre = "";
           try
           {
               using (var context = new SIPAEntities())
               {

                   Nombre = context.ART_MUSICA_ORGANIZACION_COMUNITARIA.Where(x => x.ORGANIZACION_COMUNITARIA_ID == Id).FirstOrDefault().ORGANIZACION_COMUNITARIA_DESCRIPCION;

               }
               return Nombre;

           }
           catch (Exception)
           {
               throw;
           }
       }
       
       // Método deshabilitado - Tabla ART_REGIMEN_ENTIDAD no existe en BD
       public static List<Parametro> ConsultarRegimenPadre()
       {
           return new List<Parametro>();
       }

       // Método deshabilitado - Tabla ART_REGIMEN_ENTIDAD no existe en BD  
       public static List<Parametro> ConsultarRegimenHijos(decimal? PadreId)
       {
           return new List<Parametro>();
       }

       // Método deshabilitado - Tabla ART_NIVEL_ADMINISTRACION no existe en BD
       public static List<Parametro> ConsultarNivelesAdministracion()
       {
           return new List<Parametro>();
       }

       public static List<Parametro> ConsultarTipoVinculacionDirector()
       {
           List<Parametro> listBasica = new List<Parametro>();
           try
           {
               using (var context = new SIPAEntities())
               {
                   var VarParametros = context.ART_ME_ART_MUSICA_TIPO_VINCULACION_ObtenerTodos().ToList();

                   foreach (var item in VarParametros)
                   {
                       Parametro objParametro = new Parametro();
                       objParametro.Id = item.ID_TIPO_VINCULACION;
                       objParametro.Nombre = item.DESCRIPCION_TIPO_VINCULACION;
                       listBasica.Add(objParametro);
                   }

               }
               return listBasica;

           }
           catch (Exception)
           {
               throw;
           }
       }

       // Método deshabilitado - Tabla ART_ESPACIO_PRINCIPAL no existe en BD
       public static List<Parametro> ConsultarEspacios()
       {
           return new List<Parametro>();
       }

       public static List<Parametro> ConsultarOrganizacionComunitaria()
       {
           List<Parametro> listBasica = new List<Parametro>();
           try
           {
               using (var context = new SIPAEntities())
               {
                   var VarParametros = context.ART_ME_ART_MUSICA_ORGANIZACION_COMUNITARIA_ObtenerTodos().ToList();

                   foreach (var item in VarParametros)
                   {
                       Parametro objParametro = new Parametro();
                       objParametro.Id = item.ORGANIZACION_COMUNITARIA_ID;
                       objParametro.Nombre = item.ORGANIZACION_COMUNITARIA_DESCRIPCION;
                       listBasica.Add(objParametro);
                   }

               }
               return listBasica;

           }
           catch (Exception)
           {
               throw;
           }
       }
       public static List<Parametro> ConsultarFuentesDotacion()
       {
           List<Parametro> listBasica = new List<Parametro>();
           try
           {
               using (var context = new SIPAEntities())
               {
                   var VarParametros = context.ART_ME_ART_MUSICA_FUENTES_DOTACION_ObtenerTodos().ToList();

                   foreach (var item in VarParametros)
                   {
                       Parametro objParametro = new Parametro();
                       objParametro.Id = item.ART_MUSICA_FUENTES_DOTACION_ID;
                       objParametro.Nombre = item.ART_MUSICA_FUENTES_DOTACION_DESCRIPCION;
                       listBasica.Add(objParametro);
                   }

               }
               return listBasica;

           }
           catch (Exception)
           {
               throw;
           }
       }

       public static List<Parametro> ConsultarProyectosParticipacion()
       {
           List<Parametro> listBasica = new List<Parametro>();
           try
           {
               using (var context = new SIPAEntities())
               {
                   var VarParametros = context.ART_ME_ART_MUSICA_TIPO_PROY_ORG_COM_ObtenerTodos().ToList();

                   foreach (var item in VarParametros)
                   {
                       Parametro objParametro = new Parametro();
                       objParametro.Id = item.ART_MUS_TIP_PROY_ORG_COM_ID;
                       objParametro.Nombre = item.ART_MUS_TIP_PROY_ORG_COM_DESCRIPCION;
                       listBasica.Add(objParametro);
                   }

               }
               return listBasica;

           }
           catch (Exception)
           {
               throw;
           }
       }
       public static List<Parametro> ConsultarSolucionesAcusticas()
       {
           List<Parametro> listBasica = new List<Parametro>();
           try
           {
               using (var context = new SIPAEntities())
               {
                   var VarParametros = context.ART_ME_ART_ME_SOLUCIONES_ACUSTICAS_ObtenerTodos().ToList();

                   foreach (var item in VarParametros)
                   {
                       Parametro objParametro = new Parametro();
                       objParametro.Id = item.SAC_ID;
                       objParametro.Nombre = item.SAC_DESCRIPCION;
                       listBasica.Add(objParametro);
                   }

               }
               return listBasica;

           }
           catch (Exception)
           {
               throw;
           }
       }

       public static List<Parametro> ConsultarTiposFuentesDotacion()
       {
           List<Parametro> listBasica = new List<Parametro>();
           try
           {
               using (var context = new SIPAEntities())
               {
                   var VarParametros = context.ART_ME_ART_MUSICA_NIVEL_FUENTES_DOTACION_ObtenerTodos().ToList();

                   foreach (var item in VarParametros)
                   {
                       Parametro objParametro = new Parametro();
                       objParametro.Id = item.ART_MUS_NIV_FUEN_DOT_ID;
                       objParametro.Nombre = item.ART_MUS_NIV_FUE_DOT_DESCRIPCION;
                       listBasica.Add(objParametro);
                   }

               }
               return listBasica;

           }
           catch (Exception)
           {
               throw;
           }
       }

       public static List<Parametro> ConsultarMaterialPedagogico()
       {
           List<Parametro> listBasica = new List<Parametro>();
           try
           {
               using (var context = new SIPAEntities())
               {
                   var VarParametros = context.ART_ME_ART_MUSICA_MATERIAL_PEDAGOGICO_ObtenerTodos().ToList();

                   foreach (var item in VarParametros)
                   {
                       Parametro objParametro = new Parametro();
                       objParametro.Id = item.ART_MUS_MAT_PED_ID;
                       objParametro.Nombre = item.ART_MUS_MAT_PED_DESCRIPCION;
                       listBasica.Add(objParametro);
                   }

               }
               return listBasica;

           }
           catch (Exception)
           {
               throw;
           }
       }

       public static List<Parametro> ConsultarTiposInternet()
       {
           List<Parametro> listBasica = new List<Parametro>();
           try
           {
               using (var context = new SIPAEntities())
               {
                   listBasica = (from I in context.ART_MUSICA_TIPOS_INTERNET
                                 select new Parametro
                                       {
                                           Id = I.ID,
                                           Nombre = I.DESCRIPCION
                                       }).ToList();

               }
               return listBasica;

           }
           catch (Exception)
           {
               throw;
           }
       }

       // Método deshabilitado - Tabla ART_TIPOS_ESCUELAS no existe en BD
       public static List<Parametro> ConsultarTipoEscuelasMusica()
       {
           return new List<Parametro>();
       }

       // Método deshabilitado - Tabla ART_TIPOS_ESCUELAS no existe en BD
       public static string ObtenerNombreTipoEscuela(int Id)
       {
           return string.Empty;
       }

       public static List<Parametro> ConsultarEjes()
       {
           List<Parametro> listBasica = new List<Parametro>();
           try
           {
               using (var context = new SIPAEntities())
               {
                   listBasica = (from I in context.ART_MUSICA_EJES 
                                 select new Parametro
                                 {
                                     Id = I.Id,
                                     Nombre = I.Nombre
                                 }).ToList();

               }
               return listBasica;

           }
           catch (Exception)
           {
               throw;
           }
       }

       public static List<Parametro> ConsultarTradicionalGeneros()
       {
           List<Parametro> listBasica = new List<Parametro>();
           try
           {
               using (var context = new SIPAEntities())
               {
                   listBasica = (from I in context.ART_MUSICA_TRADICIONAL_GENEROS 
                                 select new Parametro
                                 {
                                     Id = I.Id,
                                     Nombre = I.Nombre
                                 }).ToList();

               }
               return listBasica;

           }
           catch (Exception)
           {
               throw;
           }
       }

       // Método deshabilitado - Tabla ART_TIPOS_ESCUELAS no existe en BD
       public static List<Parametro> ConsultarTipoEscuelasDanza()
       {
           return new List<Parametro>();
       }

       public static List<ART_ME_ART_MUSICA_PROYECTOSORGANIZACION_ObtenerPorENT_ID_Result> ConsultarProyectosParticipacionSeleccionada(decimal EntId)
       {
           List<ART_ME_ART_MUSICA_PROYECTOSORGANIZACION_ObtenerPorENT_ID_Result> resultado = new List<ART_ME_ART_MUSICA_PROYECTOSORGANIZACION_ObtenerPorENT_ID_Result>();
           try
           {
               using (var context = new SIPAEntities())
               {
                   resultado = context.ART_ME_ART_MUSICA_PROYECTOSORGANIZACION_ObtenerPorENT_ID(EntId).ToList();

               }
               return resultado;

           }
           catch (Exception)
           {
               throw;
           }
       }

       public static List<ART_ME_ART_MUSICA_FUENTES_DOTACION_ObtenerPorENT_ID_Result> ConsultarFuentesDotacionSeleccionada(decimal EntId)
       {
           List<ART_ME_ART_MUSICA_FUENTES_DOTACION_ObtenerPorENT_ID_Result> resultado = new List<ART_ME_ART_MUSICA_FUENTES_DOTACION_ObtenerPorENT_ID_Result>();
           try
           {
               using (var context = new SIPAEntities())
               {
                   resultado = context.ART_ME_ART_MUSICA_FUENTES_DOTACION_ObtenerPorENT_ID(EntId).ToList();

               }
               return resultado;

           }
           catch (Exception)
           {
               throw;
           }
       }

       public static List<ART_ME_ART_MUSICA_FUENTES_DOTACION_ObtenerPorENT_ID_produccion_Result> ConsultarTiposFuentesDotacionSeleccionada(decimal EntId)
       {
           List<ART_ME_ART_MUSICA_FUENTES_DOTACION_ObtenerPorENT_ID_produccion_Result> resultado = new List<ART_ME_ART_MUSICA_FUENTES_DOTACION_ObtenerPorENT_ID_produccion_Result>();
           try
           {
               using (var context = new SIPAEntities())
               {
                   resultado = context.ART_ME_ART_MUSICA_FUENTES_DOTACION_ObtenerPorENT_ID_produccion(EntId).ToList();

               }
               return resultado;

           }
           catch (Exception)
           {
               throw;
           }
       }

       public static List<ART_ME_ART_MUSICA_ENT_INFR_MATERIAL_PEGAOGICO_ObtenerPorENT_ID_Result> ConsultarMaterialPedagogicoSeleccionada(decimal EntId)
       {
           List<ART_ME_ART_MUSICA_ENT_INFR_MATERIAL_PEGAOGICO_ObtenerPorENT_ID_Result> resultado = new List<ART_ME_ART_MUSICA_ENT_INFR_MATERIAL_PEGAOGICO_ObtenerPorENT_ID_Result>();
           try
           {
               using (var context = new SIPAEntities())
               {
                   resultado = context.ART_ME_ART_MUSICA_ENT_INFR_MATERIAL_PEGAOGICO_ObtenerPorENT_ID(EntId).ToList();

               }
               return resultado;

           }
           catch (Exception)
           {
               throw;
           }
       }

       public static List<ART_ME_ART_ME_ESCUELA_SOLUCIONES_ACUSTICAS_ObtenerPorId_Result> ConsultarSolucionesAcusticasSeleccionada(decimal EntId)
       {
           List<ART_ME_ART_ME_ESCUELA_SOLUCIONES_ACUSTICAS_ObtenerPorId_Result> resultado = new List<ART_ME_ART_ME_ESCUELA_SOLUCIONES_ACUSTICAS_ObtenerPorId_Result>();
           try
           {
               using (var context = new SIPAEntities())
               {
                   resultado = context.ART_ME_ART_ME_ESCUELA_SOLUCIONES_ACUSTICAS_ObtenerPorId(EntId).ToList();

               }
               return resultado;

           }
           catch (Exception)
           {
               throw;
           }
       }

       public static List<Parametro> ConsultarTiposInternetSeleccionados(decimal Ent_Id)
       {
           List<Parametro> listBasica = new List<Parametro>();
           try
           {
               using (var context = new SIPAEntities())
               {
                   listBasica = (from I in context.ART_MUSICA_ENTIDAD_TIPOS_INTERNET
                                 where I.ENT_ID == Ent_Id
                                 select new Parametro
                                 {
                                     Id = I.TIPOS_INTERNET_ID,
                                     Nombre = ""
                                 }).ToList();

               }
               return listBasica;

           }
           catch (Exception)
           {
               throw;
           }
       }
    }
}
