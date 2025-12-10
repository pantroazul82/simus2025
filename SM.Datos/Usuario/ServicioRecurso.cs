using SM.SIPA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Datos.Usuario
{
    public class ServicioRecurso
    {
        public static List<ART_MUSICA_RECURSO> ObtenerMenuPadre(List<int> listRol)
        {
            List<ART_MUSICA_RECURSO> listMenu = new List<ART_MUSICA_RECURSO>();
            using (SIPAEntities db = new SIPAEntities())
            {

                listMenu = (from p in db.ART_MUSICA_ROL_RECURSO
                            join r in db.ART_MUSICA_RECURSO on p.RecId equals r.Id
                            join l in listRol on p.RolId equals l
                            where (r.Tipo == "MENU")
                            orderby p.Orden ascending
                            select r).Distinct().ToList(); 


            }
            return listMenu;
        }

        /// <summary>
        /// Obtiene las opciones de los recursos a los cuales tiene acceso el rol
        /// </summary>
        /// <param name="idRol"></param>
        /// <returns></returns>
        public static List<ART_MUSICA_RECURSO> ObtenerMenu(int idRol)
        {
            List<ART_MUSICA_RECURSO> listMenu = new List<ART_MUSICA_RECURSO>();
            using (SIPAEntities db = new SIPAEntities())
            {


                listMenu = (from p in db.ART_MUSICA_ROL_RECURSO
                            join r in db.ART_MUSICA_RECURSO on p.RecId equals r.Id
                            where (p.RolId == idRol && r.IdPadre != null && r.Tipo == "MENU")
                            orderby r.Id
                            select p.ART_MUSICA_RECURSO).ToList();

            }
            return listMenu;
        }


        public static List<ART_MUSICA_RECURSO> ObtenerMenuOpcionesporIdpadre(int idPadre, List<int> listRol)
        {
            List<ART_MUSICA_RECURSO> listMenu = new List<ART_MUSICA_RECURSO>();
            using (SIPAEntities db = new SIPAEntities())
            {

                listMenu = (from p in db.ART_MUSICA_ROL_RECURSO
                            join r in db.ART_MUSICA_RECURSO on p.RecId equals r.Id
                            join l in listRol on p.RolId equals l
                            where (r.IdPadre == idPadre && r.Tipo == "PAG")
                            orderby r.Id
                            select p.ART_MUSICA_RECURSO).Distinct().ToList();

            }
            return listMenu;
        }


        public static void EliminarOpcionesRol(int idRol)
        {
            ART_MUSICA_ROL rol = new ART_MUSICA_ROL();


            using (SIPAEntities db = new SIPAEntities())
            {
                rol = (from p in db.ART_MUSICA_ROL
                       where p.Id == idRol
                       select p).Single();


                // Query the database for the rows to be deleted.
                var relacionesEliminar =
                    from relaciones in db.ART_MUSICA_ROL_RECURSO
                    where relaciones.RolId == rol.Id
                    select relaciones;


                if (relacionesEliminar.Count() > 0)
                {
                    foreach (var relacion in relacionesEliminar)
                    {
                        db.ART_MUSICA_ROL_RECURSO.Remove(relacion);
                    }

                    db.SaveChanges();
                }

            }
        }




        /// <summary>
        /// 
        /// </summary>
        /// <param name="objRol"></param>
        /// <param name="objRec"></param>
        /// <returns></returns>
        public static bool resgistrarRecuersoRol(ART_MUSICA_ROL objRol, ART_MUSICA_RECURSO objRec)
        {
            bool respuesta = true;


            ART_MUSICA_ROL_RECURSO adnew = new ART_MUSICA_ROL_RECURSO();

           
            try
            {
                using (var context = new SIPAEntities())
                {
                    var ROL = context.ART_MUSICA_ROL.Where(b => b.Id == objRol.Id).FirstOrDefault();
                    var RECURSO = context.ART_MUSICA_RECURSO.Where(b => b.Id == objRec.Id).FirstOrDefault();

                    adnew.ART_MUSICA_ROL = ROL;
                    adnew.ART_MUSICA_RECURSO = RECURSO;
                    adnew.Fecha = DateTime.Now;

                    context.ART_MUSICA_ROL_RECURSO.Add(adnew);

                    context.SaveChanges();

                }
                respuesta = true;

            }
            catch (Exception)
            {
                respuesta = false;
            }


            return respuesta;
        }

        public static ART_MUSICA_RECURSO obtenerRecporId(int idRecuerso)
        {
            ART_MUSICA_RECURSO objRec = null;
            try
            {



                using (SIPAEntities db = new SIPAEntities())
                {

                    objRec = (from p in db.ART_MUSICA_RECURSO.Where(x => x.Id == idRecuerso) select p).SingleOrDefault();



                }
            }
            catch (Exception r)
            {
                objRec = null;
            }



            return objRec;
        }

    }
}
