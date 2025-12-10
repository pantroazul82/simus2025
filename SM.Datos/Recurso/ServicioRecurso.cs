using SM.Datos.AuditoriaData;
using SM.SIPA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Datos.Recurso
{
  public   class ServicioRecurso
    {
      public const string RECURSO_MENU = "MENU";
      public const string RECURSO_PAGINA = "PAG";
      /// <summary>
      /// Todos los recursos
      /// </summary>
      /// <returns></returns>
      public static List<ART_MUSICA_RECURSO> ObtenerTodoRecurso()
      {
          List<ART_MUSICA_RECURSO> listMenu = new List<ART_MUSICA_RECURSO>();
          using (SIPAEntities db = new SIPAEntities())
          {

              listMenu = (from r in db.ART_MUSICA_RECURSO
                          orderby r.Nombre ascending
                          select r).ToList();


          }
          return listMenu;
      }

      public static List<ART_MUSICA_RECURSO> ObtenerTodoPagina()
      {
          List<ART_MUSICA_RECURSO> listMenu = new List<ART_MUSICA_RECURSO>();
          using (SIPAEntities db = new SIPAEntities())
          {

              listMenu = (from r in db.ART_MUSICA_RECURSO.Where(x => x.Tipo == RECURSO_PAGINA )
                          orderby r.Nombre ascending
                          select r).ToList();


          }
          return listMenu;
      }

      public static List<ART_MUSICA_RECURSO> ObtenerTodoPaginaporPadre(int idPadre)
      {
          List<ART_MUSICA_RECURSO> listMenu = new List<ART_MUSICA_RECURSO>();
          using (SIPAEntities db = new SIPAEntities())
          {

              listMenu = (from r in db.ART_MUSICA_RECURSO.Where(x => x.Tipo == RECURSO_PAGINA && x.IdPadre == idPadre)
                          orderby r.Nombre ascending
                          select r).ToList();


          }
          return listMenu;
      }


      /// <summary>
      /// Recurso por Id
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      public static ART_MUSICA_RECURSO ObtenerRecurso(int id)
      {
          ART_MUSICA_RECURSO obRecurso = new ART_MUSICA_RECURSO();
          using (SIPAEntities db = new SIPAEntities())
          {

              obRecurso = (from r in db.ART_MUSICA_RECURSO.Where(x => x.Id == id)
                          orderby r.Nombre ascending
                          select r).SingleOrDefault();


          }
          return obRecurso;
      }


      public static bool crearMenu(ART_MUSICA_RECURSO objMenu, int UsuarioId, string NombreUsuario, string strIP)
      {
          bool respuesta = false;

          try
          {
              using (var context = new SIPAEntities())
              {
                  context.ART_MUSICA_RECURSO.Add(objMenu);

                  context.SaveChanges();

                  //Auditoria
                  string temp;
                  temp = string.Format("El usuario {0} ({1}) creación el {2} al menú.\nDatos actuales:\n{3} ", NombreUsuario, UsuarioId, DateTime.Now, objMenu);
                  StringBuilder stringBuilder = new StringBuilder();
                  stringBuilder.AppendLine(temp);
                  ART_MUSICA_REGISTRO_OPERACION registroOperacion = new ART_MUSICA_REGISTRO_OPERACION { Categoria = CategoriaRegistroOperacion.Recursos.ToString(), IpUsuario = strIP, RegistroId = objMenu.Id, UsuarioId = UsuarioId, NombreUsuario = NombreUsuario, Descripcion = stringBuilder.ToString(), FechaRegistro = DateTime.Now, Operacion = "Creación Menú" };

                  RegistroOperacionServicio auditoria = new RegistroOperacionServicio();
                  auditoria.Crear(registroOperacion);
              }
              respuesta = true;

          }
          catch (Exception)
          {
              respuesta = true;
          }
          return respuesta;
      }
      /// <summary>
      /// Existe  codigo de menu
      /// </summary>
      /// <param name="objMenu"></param>
      /// <returns></returns>
      public static bool existecodigoMenu(ART_MUSICA_RECURSO objMenu)
      {
          bool respuesta = false;
          var model = new ART_MUSICA_RECURSO();
          try
          {
              using (var context = new SIPAEntities())
              {
                  context.ART_MUSICA_RECURSO.Add(objMenu);

                  model = context.ART_MUSICA_RECURSO.Where(x => x.Codigo == objMenu.Codigo).FirstOrDefault();

              }
              if (model != null)
              {
                  respuesta = true;
              }

          }
          catch (Exception)
          {
              respuesta = true;
          }
          return respuesta;
      }



      public static bool modificarMenu(ART_MUSICA_RECURSO objMenu, int UsuarioId, string NombreUsuario, string strIP)
      {
          bool respuesta = false;

          try
          {
              using (var context = new SIPAEntities())
              {

                  var usuario = context.ART_MUSICA_RECURSO.Where(b => b.Id == objMenu.Id).FirstOrDefault();
                  context.Entry(usuario).CurrentValues.SetValues(objMenu);
                  context.SaveChanges();

                  //Auditoria
                  string temp;
                  temp = string.Format("El usuario {0} ({1}) actualizó el {2} al página menú.\nDatos actuales:\n{3} ", NombreUsuario, UsuarioId, DateTime.Now, objMenu);
                  StringBuilder stringBuilder = new StringBuilder();
                  stringBuilder.AppendLine(temp);
                  ART_MUSICA_REGISTRO_OPERACION registroOperacion = new ART_MUSICA_REGISTRO_OPERACION { Categoria = CategoriaRegistroOperacion.Recursos.ToString(), IpUsuario = strIP, RegistroId = objMenu.Id, UsuarioId = UsuarioId, NombreUsuario = NombreUsuario, Descripcion = stringBuilder.ToString(), FechaRegistro = DateTime.Now, Operacion = "Actualización Menú" };

                  RegistroOperacionServicio auditoria = new RegistroOperacionServicio();
                  auditoria.Crear(registroOperacion);


              }
              respuesta = true;

          }
          catch (Exception)
          {
              respuesta = true;
          }
          return respuesta;
      }


      public static bool crearPagina(ART_MUSICA_RECURSO objMenu, int UsuarioId, string NombreUsuario, string strIP)
      {
          bool respuesta = false;

          try
          {
              using (var context = new SIPAEntities())
              {
                       
                 
                  context.ART_MUSICA_RECURSO.Add(objMenu);

                  context.SaveChanges();

                  //Auditoria
                  string temp;
                  temp = string.Format("El usuario {0} ({1}) actualizó el {2} al página menú.\nDatos actuales:\n{3} ", NombreUsuario, UsuarioId, DateTime.Now, objMenu);
                  StringBuilder stringBuilder = new StringBuilder();
                  stringBuilder.AppendLine(temp);
                  ART_MUSICA_REGISTRO_OPERACION registroOperacion = new ART_MUSICA_REGISTRO_OPERACION { Categoria = CategoriaRegistroOperacion.Recursos.ToString(), IpUsuario = strIP, RegistroId = objMenu.Id, UsuarioId = UsuarioId, NombreUsuario = NombreUsuario, Descripcion = stringBuilder.ToString(), FechaRegistro = DateTime.Now, Operacion = "Creación Página" };

                  RegistroOperacionServicio auditoria = new RegistroOperacionServicio();
                  auditoria.Crear(registroOperacion);

              }
              respuesta = true;

          }
          catch (Exception)
          {
              respuesta = true;
          }
          return respuesta;
      }

      public static bool ModificarPagina(ART_MUSICA_RECURSO objpagina, int UsuarioId, string NombreUsuario, string strIP)
      {
          bool respuesta = false;

          try
          {
              using (var context = new SIPAEntities())
              {

                  var objMenu = context.ART_MUSICA_RECURSO.Where(b => b.Id == objpagina.Id).FirstOrDefault();
                  context.Entry(objMenu).CurrentValues.SetValues(objpagina);
                  context.SaveChanges();

                  //Auditoria
                  string temp;
                  temp = string.Format("El usuario {0} ({1}) actualizó el {2} al página menú.\nDatos actuales:\n{3} ", NombreUsuario, UsuarioId, DateTime.Now, objMenu);
                  StringBuilder stringBuilder = new StringBuilder();
                  stringBuilder.AppendLine(temp);
                  ART_MUSICA_REGISTRO_OPERACION registroOperacion = new ART_MUSICA_REGISTRO_OPERACION { Categoria = CategoriaRegistroOperacion.Recursos.ToString(), IpUsuario = strIP, RegistroId = objMenu.Id, UsuarioId = UsuarioId, NombreUsuario = NombreUsuario, Descripcion = stringBuilder.ToString(), FechaRegistro = DateTime.Now, Operacion = "Actualización Pagina" };

                  RegistroOperacionServicio auditoria = new RegistroOperacionServicio();
                  auditoria.Crear(registroOperacion);



              }
              respuesta = true;

          }
          catch (Exception)
          {
              respuesta = true;
          }
          return respuesta;
      }
      /// <summary>
      /// Adicionamos o bridamos acceso a ciudades y deptos al rol
      /// </summary>
      /// <param name="objNew"></param>
      /// <returns></returns>
      public static bool adicionardeptoUsuario(ART_MUSICA_USER_CIUDAD objNew)
      {
           bool respuesta = false;
      

          try
          {
              using (var context = new SIPAEntities())
              {

                  // var objRec = (from p in context.ART_MUSICA_RECURSO.Where(x => x.IdPadre == objMenu.IdPadre) select p).SingleOrDefault();
                  context.ART_MUSICA_USER_CIUDAD.Add(objNew);

                  context.SaveChanges();





              }
              respuesta = true;

          }
          catch (Exception)
          {
              respuesta = true;
          }
          return respuesta;
      }

      /// <summary>
      /// eliminamos un usuario ciudad
      /// </summary>
      /// <param name="objNew"></param>
      /// <returns></returns>
      public static bool eliminardeptoUsuario(ART_MUSICA_USER_CIUDAD objNew)
      {
          bool respuesta = false;


          try
          {
              using (var context = new SIPAEntities())
              {

                  var objRec = (from p in context.ART_MUSICA_USER_CIUDAD.Where(x => x.Id == objNew.Id) select p).SingleOrDefault();
                  context.ART_MUSICA_USER_CIUDAD.Remove(objRec);

                  context.SaveChanges();





              }
              respuesta = true;

          }
          catch (Exception)
          {
              respuesta = true;
          }
          return respuesta;
      }



      public static List<ART_MUSICA_USER_CIUDAD> obtenerCiudadUsuarioPorId(int IdUser)
      {
          List<ART_MUSICA_USER_CIUDAD> listciudad = new List<ART_MUSICA_USER_CIUDAD>();
          using (SIPAEntities db = new SIPAEntities())
          {

              listciudad = (from r in db.ART_MUSICA_USER_CIUDAD.Where(x => x.IdUser == IdUser)
                          orderby r.CodDpto ascending
                          select r).ToList();


          }
          return listciudad;
      }

    }
}
