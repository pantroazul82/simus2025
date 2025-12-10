using SM.Datos.AuditoriaData;
using SM.Datos.DTO;
using SM.LibreriaComun.DTO;
using SM.SIPA;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Datos.Escuelas
{
    public class ServicioEscuela
    {

        #region Actualización

        public static void AgregarGeneros(ART_MUSICA_PRACTICA_GENERO registro)
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    context.ART_MUSICA_PRACTICA_GENERO.Add(registro);
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void EliminarPracticaGenero(int PracticaGeneroId)
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    context.ART_MUSICA_PRACTICA_GENERO.Remove(context.ART_MUSICA_PRACTICA_GENERO.Where(x => x.Id == PracticaGeneroId).FirstOrDefault());
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<Parametro> ConsultarGenerosPorPracticaID(int FormacionPracticaId)
        {
            var listBasica = new List<Parametro>();
            List<ART_MUSICA_PRACTICA_GENERO> VarParametros = new List<ART_MUSICA_PRACTICA_GENERO>();
            try
            {
                using (var context = new SIPAEntities())
                {
                   VarParametros = context.ART_MUSICA_PRACTICA_GENERO.Where(x => x.FormacionPracticaId == FormacionPracticaId).ToList();

                    foreach (var item in VarParametros)
                    {
                        var objParametro = new Parametro();
                        objParametro.Id = item.Id;
                        objParametro.Nombre = item.atributo; 
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

        public static List<Parametro> ConsultarPracticaPorEscuela(int EscuelaId)
        {
            var listBasica = new List<Parametro>();
          
            try
            {
                using (var context = new SIPAEntities())
                {
                   

                    listBasica = (from a in context.ART_MUSICA_FORMACION_PRACTICA
                                  join e in context.ART_MUSICA_PRACTICA_MUSICAL on a.PracticaMusicalId equals e.ART_MUS_PRAC_MUS_ID
                                  where a.EscuelaId == EscuelaId
                                     orderby e.ART_MUS_PRAC_MUS_DESCRIPCION
                                  select new Parametro { Nombre = e.ART_MUS_PRAC_MUS_DESCRIPCION, Id = a.Id, PadreId = a.EscuelaId }).ToList();

                }
                return listBasica;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void AgregarPractica(ART_MUSICA_FORMACION_PRACTICA registro)
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    context.ART_MUSICA_FORMACION_PRACTICA.Add(registro);
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static bool ExisteEscuelaPractica(decimal Escuelaid, Int16 PracticaId)
        {
            bool validar = false;
            try
            {
                using (var context = new SIPAEntities())
                {
                  var registro =   context.ART_MUSICA_FORMACION_PRACTICA.Where(x => x.EscuelaId == Escuelaid && x.PracticaMusicalId == PracticaId).FirstOrDefault();

                  if (registro != null && registro.Id > 0)
                      validar = true;
                }
            }
                
            catch (Exception)
            {
                throw;
            }

            return validar;
        }
        public static decimal CrearEscuela(string nombre,
                                            string NIT,
                                            int? anoConstitucion,
                                            string nombrecontacto,
                                            string cargoContacto,
                                            string resena,
                                            string telefono,
                                            string correoContacto,
                                            decimal UsuarioId,
                                            string CodigoMunicipio,
                                            int areaId,
                                            string direccion,
                                            string telefonoEscuela,
                                            string faxEscuela,
                                            string CorreoElectronicoEscuela,
                                            string paginaWeb,
                                            string Naturaleza,
                                            string TipoEscuela,
                                            byte[] imagen,
                                            string Latitud,
                                            string Longitud,
                                            int SimusUsuarioId,
                                            string NombreUsuario,
                                            string strIP)
        {

            decimal EscuelaId = 0;
            double dbLatitud = 0;
            double dbLongitud = 0;

            try
            {
                using (var context = new SIPAEntities())
                {
                    using (var dbContextTransaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            var varEscuelaId = context.ART_ME_ART_ENTIDADES_ARTES_Insertar(nombre,
                                                                     String.Empty,
                                                                     String.Empty,
                                                                     NIT,
                                                                     anoConstitucion,
                                                                     nombrecontacto,
                                                                     cargoContacto,
                                                                     resena).FirstOrDefault() ?? 0;

                            EscuelaId = Convert.ToDecimal(varEscuelaId);

                            var entidad = new ART_MUSICA_ENTIDAD_IDENTIFICACION
                            {
                                ENT_ID = EscuelaId,
                                ENT_TELEFONOS = telefono,
                                ENT_CONTACTO_CORREO = correoContacto,
                                USU_ID = UsuarioId,
                                ENT_TIPO_ESCUELA = TipoEscuela,
                                EstadoId = 1,
                                Imagen = imagen
                            };

                            context.ART_MUSICA_ENTIDAD_IDENTIFICACION.Add(entidad);


                            string telefonoSiNo = "S";
                            string faxSiNo = "S";
                            string correoSINO = "S";

                            if (String.IsNullOrEmpty(telefonoEscuela))
                                telefonoSiNo = "N";

                            if (String.IsNullOrEmpty(faxEscuela))
                                faxSiNo = "N";

                            if (String.IsNullOrEmpty(CorreoElectronicoEscuela))
                                correoSINO = "N";

                            if (!String.IsNullOrEmpty(Latitud))
                            {
                                if (Latitud.Contains("."))
                                    Latitud = Latitud.Replace(".", ",");
                                dbLatitud = Convert.ToDouble(Latitud);
                            }

                            if (!String.IsNullOrEmpty(Longitud))
                            {
                                if (Longitud.Contains("."))
                                    Longitud = Longitud.Replace(".", ",");
                                dbLongitud = Convert.ToDouble(Longitud);
                            }
                            var nuevaUbicacion = new ART_ENTIDAD_UBICACION

                            {
                                ENT_ID = EscuelaId,
                                ZON_ID = CodigoMunicipio,
                                ARE_ID = areaId,
                                ENT_DIRECCION = direccion,
                                ENT_DIRECCION_CORRESPONDENCIA = direccion,
                                ENT_PAGINA_WEB = paginaWeb,
                                ENT_TELEFONO = telefonoEscuela,
                                ENT_FAX = faxEscuela,
                                ENT_SINO_TELEFONO = telefonoSiNo,
                                ENT_SINO_FAX = faxSiNo,
                                ENT_SINO_CORREO_ELECTRONICO_ENTIDAD = correoSINO,
                                MUS_LATITUD = dbLatitud,
                                MUS_LONGITUD = dbLongitud,
                            };
                            context.ART_ENTIDAD_UBICACION.Add(nuevaUbicacion);

                            var nuevaNaturaleza = new ART_ENTIDAD_NATURALEZA_JURIDICA

                              {
                                  ENT_ID = EscuelaId,
                                  ENT_PERSONERIA_JURIDICA = "N",
                                  ENT_NATURALEZA = Naturaleza,

                              };
                            context.ART_ENTIDAD_NATURALEZA_JURIDICA.Add(nuevaNaturaleza);

                            context.SaveChanges();
                            dbContextTransaction.Commit();

                            //Auditoria
                            string temp;
                            temp = string.Format("El usuario {0} ({1}) creó el {2} la escuela de música.\nDatos actuales:\n{3} ", NombreUsuario, SimusUsuarioId, DateTime.Now, "ART_ENTIDADES_ARTES");
                            StringBuilder stringBuilder = new StringBuilder();
                            stringBuilder.AppendLine(temp);
                            ART_MUSICA_REGISTRO_OPERACION registroOperacion = new ART_MUSICA_REGISTRO_OPERACION { Categoria = CategoriaRegistroOperacion.Escuelas.ToString(), IpUsuario = strIP, RegistroId = Convert.ToInt32(EscuelaId), UsuarioId = SimusUsuarioId, NombreUsuario = NombreUsuario, Descripcion = stringBuilder.ToString(), FechaRegistro = DateTime.Now, Operacion = "Creación" };

                            RegistroOperacionServicio auditoria = new RegistroOperacionServicio();
                            auditoria.Crear(registroOperacion);
                        }
                        catch
                        { dbContextTransaction.Rollback(); }
                    }

                }


                return EscuelaId;

            }
            catch (Exception)
            { throw; }
        }


        public static void ActualizarImagen(decimal entId,
                                            byte[] image,
                                            int SimusUsuarioId,
                                            string NombreUsuario,
                                            string strIP)
        {
            var model = new ART_MUSICA_ENTIDAD_IDENTIFICACION();
            try
            {
                using (var context = new SIPAEntities())
                {
                    model = context.ART_MUSICA_ENTIDAD_IDENTIFICACION.Where(x => x.ENT_ID == entId).FirstOrDefault();

                    if (model != null)
                    {
                        model.Imagen = image;
                        context.SaveChanges();
                        //Auditoria
                        string temp;
                        temp = string.Format("El usuario {0} ({1}) actualizó el {2} la imagen de la escuela de música.\nDatos actuales:\n{3} ", NombreUsuario, SimusUsuarioId, DateTime.Now, "ART_MUSICA_ENTIDAD_IDENTIFICACION");
                        StringBuilder stringBuilder = new StringBuilder();
                        stringBuilder.AppendLine(temp);
                        ART_MUSICA_REGISTRO_OPERACION registroOperacion = new ART_MUSICA_REGISTRO_OPERACION { Categoria = CategoriaRegistroOperacion.Escuelas.ToString(), IpUsuario = strIP, RegistroId = Convert.ToInt32(entId), UsuarioId = SimusUsuarioId, NombreUsuario = NombreUsuario, Descripcion = stringBuilder.ToString(), FechaRegistro = DateTime.Now, Operacion = "Actualización Imagen" };

                        RegistroOperacionServicio auditoria = new RegistroOperacionServicio();
                        auditoria.Crear(registroOperacion);
                    }

                }

            }
            catch (Exception)
            { throw; }
        }

        public static void ActualizarEscuela(decimal entId,
                                             string entNombre,
                                             string entImagen,
                                             string entPaginaWeb,
                                             string entNit,
                                             int entAnoConstitucion,
                                             string entNombreContacto,
                                             string entCargoContacto,
                                             string entResena,
                                            string telefono,
                                            string correoContacto,
                                            decimal UsuarioId,
                                            string CodigoMunicipio,
                                            int areaId,
                                            string direccion,
                                            string telefonoEscuela,
                                            string faxEscuela,
                                            string CorreoElectronicoEscuela,
                                            byte[] imagen,
                                            string Naturaleza,
                                            string TipoEscuela,
                                            int SimusUsuarioId,
                                            string NombreUsuario,
                                            string strIP)
        {
            try
            {

                using (var context = new SIPAEntities())
                {
                    using (var dbContextTransaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            context.ART_ME_ART_ENTIDADES_ARTES_Actualizar(entId,
                                                                          entNombre,
                                                                          entImagen,
                                                                          entPaginaWeb,
                                                                          entNit,
                                                                          entAnoConstitucion,
                                                                          entNombreContacto,
                                                                          entCargoContacto,
                                                                          entResena);

                            var entidad = context.ART_MUSICA_ENTIDAD_IDENTIFICACION.Where(x => x.ENT_ID == entId).FirstOrDefault();

                            if (entidad != null)
                            {
                                entidad.ENT_TELEFONOS = telefono;
                                entidad.ENT_TIPO_ESCUELA = TipoEscuela;
                                entidad.ENT_CONTACTO_CORREO = correoContacto;
                                if (imagen != null)
                                    entidad.Imagen = imagen;
                            }
                            //context.SaveChanges();

                            var naturaleza = context.ART_ENTIDAD_NATURALEZA_JURIDICA.Where(x => x.ENT_ID == entId).FirstOrDefault();
                            if (naturaleza != null)
                            {
                                naturaleza.ENT_NATURALEZA = Naturaleza;
                            }
                            else
                            {
                                int NivelDepende = 6;

                                context.ART_ME_ART_ENTIDAD_NATURALEZA_JURIDICA_Insertar(entId,
                                                                                         "N",
                                                                                         string.Empty,
                                                                                         Naturaleza,
                                                                                         string.Empty,
                                                                                         string.Empty,
                                                                                         string.Empty,
                                                                                         NivelDepende,
                                                                                         string.Empty,
                                                                                         string.Empty,
                                                                                         string.Empty,
                                                                                         string.Empty,
                                                                                         null,
                                                                                         null,
                                                                                         null);
                            }

                            context.SaveChanges();

                            string telefonoSiNo = "S";
                            string faxSiNo = "S";
                            string correoSINO = "S";

                            if (String.IsNullOrEmpty(telefonoEscuela))
                                telefonoSiNo = "N";

                            if (String.IsNullOrEmpty(faxEscuela))
                                faxSiNo = "N";

                            if (String.IsNullOrEmpty(CorreoElectronicoEscuela))
                                correoSINO = "N";

                            context.ART_ME_ART_ENTIDAD_UBICACION_Actualizar(entId,
                                                                  CodigoMunicipio,
                                                                  areaId,
                                                                  direccion,
                                                                  String.Empty,
                                                                  telefonoSiNo,
                                                                  telefonoEscuela,
                                                                  faxSiNo,
                                                                  faxEscuela,
                                                                  String.Empty,
                                                                  correoSINO,
                                                                  CorreoElectronicoEscuela,
                                                                  entPaginaWeb,
                                                                  String.Empty,
                                                                  String.Empty,
                                                                  String.Empty,
                                                                  String.Empty);

                            dbContextTransaction.Commit();

                            //Auditoria
                            string temp;
                            temp = string.Format("El usuario {0} ({1}) actualizó el {2} la  escuela de música.\nDatos actuales:\n{3} ", NombreUsuario, SimusUsuarioId, DateTime.Now, "ART_ENTIDADES_ARTES");
                            StringBuilder stringBuilder = new StringBuilder();
                            stringBuilder.AppendLine(temp);
                            ART_MUSICA_REGISTRO_OPERACION registroOperacion = new ART_MUSICA_REGISTRO_OPERACION { Categoria = CategoriaRegistroOperacion.Escuelas.ToString(), IpUsuario = strIP, RegistroId = Convert.ToInt32(entId), UsuarioId = SimusUsuarioId, NombreUsuario = NombreUsuario, Descripcion = stringBuilder.ToString(), FechaRegistro = DateTime.Now, Operacion = "Actualización" };

                            RegistroOperacionServicio auditoria = new RegistroOperacionServicio();
                            auditoria.Crear(registroOperacion);
                        }
                        catch
                        { dbContextTransaction.Rollback(); }

                    }

                }
            }
            catch (Exception)
            { throw; }

        }


        public static void ActualizarEscuelaGeo(decimal entId,
                                           string entNombre,
                                           string entImagen,
                                           string entPaginaWeb,
                                           string entNit,
                                           int entAnoConstitucion,
                                           string entNombreContacto,
                                           string entCargoContacto,
                                           string entResena,
                                          string telefono,
                                          string correoContacto,
                                          decimal UsuarioId,
                                          string CodigoMunicipio,
                                          int areaId,
                                          string direccion,
                                          string telefonoEscuela,
                                          string faxEscuela,
                                          string CorreoElectronicoEscuela,
                                          byte[] imagen,
                                          string Naturaleza,
                                          string TipoEscuela,
                                          string Latitud,
                                          string Longitud,
                                           int EstadoId,
                                            string OperatividadId,
                                          int SimusUsuarioId,
                                          string NombreUsuario,
                                          string strIP)
        {
            try
            {

                using (var context = new SIPAEntities())
                {
                    using (var dbContextTransaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            context.ART_ME_ART_ENTIDADES_ARTES_Actualizar(entId,
                                                                          entNombre,
                                                                          entImagen,
                                                                          entPaginaWeb,
                                                                          entNit,
                                                                          entAnoConstitucion,
                                                                          entNombreContacto,
                                                                          entCargoContacto,
                                                                          entResena);

                            var entidad = context.ART_MUSICA_ENTIDAD_IDENTIFICACION.Where(x => x.ENT_ID == entId).FirstOrDefault();

                            if (entidad != null)
                            {
                                entidad.ENT_TELEFONOS = telefono;
                                entidad.ENT_TIPO_ESCUELA = TipoEscuela;
                                entidad.ENT_CONTACTO_CORREO = correoContacto;
                                entidad.EstadoId = EstadoId;
                                if (!String.IsNullOrEmpty(OperatividadId) )
                                    entidad.OperatividadId = Convert.ToInt32(OperatividadId);
                                if (imagen != null)
                                    entidad.Imagen = imagen;
                            }

                            var naturaleza = context.ART_ENTIDAD_NATURALEZA_JURIDICA.Where(x => x.ENT_ID == entId).FirstOrDefault();
                            if (naturaleza != null)
                            {
                                naturaleza.ENT_NATURALEZA = Naturaleza;
                            }
                            else
                            {

                                var nuevaNaturaleza = new ART_ENTIDAD_NATURALEZA_JURIDICA

                                {
                                    ENT_ID = entId,
                                    ENT_PERSONERIA_JURIDICA = "N",
                                    ENT_NATURALEZA = Naturaleza,

                                };
                                context.ART_ENTIDAD_NATURALEZA_JURIDICA.Add(nuevaNaturaleza);
                            }


                            var ubicacion = context.ART_ENTIDAD_UBICACION.Where(x => x.ENT_ID == entId).FirstOrDefault();

                            if (ubicacion != null)
                            {
                                ubicacion.ENT_DIRECCION = direccion;
                                ubicacion.ENT_DIRECCION_CORRESPONDENCIA = direccion;
                                ubicacion.ENT_FAX = faxEscuela;
                                ubicacion.ENT_TELEFONO = telefonoEscuela;
                                ubicacion.ENT_PAGINA_WEB = entPaginaWeb;
                                ubicacion.ENT_CORREO_ELECTRONICO_ENTIDAD = CorreoElectronicoEscuela;
                                ubicacion.ARE_ID = areaId;
                                ubicacion.ZON_ID = CodigoMunicipio;
                                if ((!String.IsNullOrEmpty(Latitud)) && (!String.IsNullOrEmpty(Longitud)))
                                {
                                    double dbLongitud = 0;
                                    double dbLatitud = 0;

                                    if (Latitud.Contains("."))
                                        Latitud = Latitud.Replace(".", ",");
                                    dbLatitud = Convert.ToDouble(Latitud);


                                    if (Longitud.Contains("."))
                                        Longitud = Longitud.Replace(".", ",");
                                    dbLongitud = Convert.ToDouble(Longitud);

                                    ubicacion.MUS_LATITUD = dbLatitud;
                                    ubicacion.MUS_LONGITUD = dbLongitud;
                                }
                            }

                            context.SaveChanges();
                            dbContextTransaction.Commit();

                            //Auditoria
                            string temp;
                            temp = string.Format("El usuario {0} ({1}) actualizó el {2} la  escuela de música.\nDatos actuales:\n{3} ", NombreUsuario, SimusUsuarioId, DateTime.Now, "ART_ENTIDADES_ARTES");
                            StringBuilder stringBuilder = new StringBuilder();
                            stringBuilder.AppendLine(temp);
                            ART_MUSICA_REGISTRO_OPERACION registroOperacion = new ART_MUSICA_REGISTRO_OPERACION { Categoria = CategoriaRegistroOperacion.Escuelas.ToString(), IpUsuario = strIP, RegistroId = Convert.ToInt32(entId), UsuarioId = SimusUsuarioId, NombreUsuario = NombreUsuario, Descripcion = stringBuilder.ToString(), FechaRegistro = DateTime.Now, Operacion = "Actualización" };

                            RegistroOperacionServicio auditoria = new RegistroOperacionServicio();
                            auditoria.Crear(registroOperacion);
                        }
                        catch
                        { dbContextTransaction.Rollback(); }

                    }

                }
            }
            catch (Exception)
            { throw; }

        }

        public static void ActualizarEscuelaEstado(decimal entId,
                                                  string strEstado,
                                                  int SimusUsuarioId,
                                                  string NombreUsuario,
                                                  string strIP)
        {
            try
            {

                using (var context = new SIPAEntities())
                {
                    context.ART_ME_ART_ENTIDADES_ARTES_ActualizarEstado(entId,
                                                                  strEstado);

                    //Auditoria
                    string temp;
                    temp = string.Format("El usuario {0} ({1}) actualizó el {2} el estado de la escuela de música.\nDatos actuales:\n{3} ", NombreUsuario, SimusUsuarioId, DateTime.Now, "ART_ENTIDADES_ARTES");
                    StringBuilder stringBuilder = new StringBuilder();
                    stringBuilder.AppendLine(temp);
                    ART_MUSICA_REGISTRO_OPERACION registroOperacion = new ART_MUSICA_REGISTRO_OPERACION { Categoria = CategoriaRegistroOperacion.Escuelas.ToString(), IpUsuario = strIP, RegistroId = Convert.ToInt32(entId), UsuarioId = SimusUsuarioId, NombreUsuario = NombreUsuario, Descripcion = stringBuilder.ToString(), FechaRegistro = DateTime.Now, Operacion = "Actualización Estado" };

                    RegistroOperacionServicio auditoria = new RegistroOperacionServicio();
                    auditoria.Crear(registroOperacion);

                }

            }
            catch (Exception)
            { throw; }

        }

        public static void Eliminar(decimal entId,
                                    int SimusUsuarioId,
                                    string NombreUsuario,
                                    string strIP)
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    context.ART_MUSICA_ENTIDAD_TIPOS_INTERNET.RemoveRange(context.ART_MUSICA_ENTIDAD_TIPOS_INTERNET.Where(x => x.ENT_ID == entId));
                    context.SaveChanges();
                    context.ART_ME_ELIMINAR_ESCUELA(entId);

                    //Auditoria
                    string temp;
                    temp = string.Format("El usuario {0} ({1}) eliminó el {2} la escuela de música.\nDatos actuales:\n{3} ", NombreUsuario, SimusUsuarioId, DateTime.Now, "ART_ENTIDADES_ARTES");
                    StringBuilder stringBuilder = new StringBuilder();
                    stringBuilder.AppendLine(temp);
                    ART_MUSICA_REGISTRO_OPERACION registroOperacion = new ART_MUSICA_REGISTRO_OPERACION { Categoria = CategoriaRegistroOperacion.Escuelas.ToString(), IpUsuario = strIP, RegistroId = Convert.ToInt32(entId), UsuarioId = SimusUsuarioId, NombreUsuario = NombreUsuario, Descripcion = stringBuilder.ToString(), FechaRegistro = DateTime.Now, Operacion = "Eliminar" };

                    RegistroOperacionServicio auditoria = new RegistroOperacionServicio();
                    auditoria.Crear(registroOperacion);

                }

            }
            catch (Exception)
            { throw; }

        }

        public static void EliminarIdentificacion(decimal entId)
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    context.ART_ME_ART_MUSICA_ENTIDAD_IDENTIFICACION_Eliminar(entId);

                }

            }
            catch (Exception)
            { throw; }

        }

        public static void ActualizarFechaModificacion(decimal entId)
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    var entidad = context.ART_ENTIDADES_ARTES.SingleOrDefault(e => e.ENT_ID == entId);
                    entidad.ENT_FECHA_ACTUALIZACION = DateTime.Today;

                    context.SaveChanges();

                }

            }
            catch (Exception)
            { throw; }

        }
        #endregion


        #region Consultas

        public static string ObtenerNombreEscuela(decimal EntId)
        {

            string nombre = null;
            try
            {
                using (var context = new SIPAEntities())
                {

                    nombre = (from z in context.ART_ENTIDADES_ARTES
                              where z.ENT_ID == EntId
                              select z).FirstOrDefault().ENT_NOMBRE;


                }


            }
            catch (Exception)
            {
                nombre = null;

            }
            return nombre;

        }

        public static List<Basica> ConsultaEscuelaPorMunicipio(string codMunicipio)
        {

            List<Basica> listado;
            try
            {
                using (var context = new SIPAEntities())
                {

                    listado = (from e in context.ART_ENTIDADES_ARTES
                              join u in context.ART_ENTIDAD_UBICACION on e.ENT_ID equals u.ENT_ID
                              join i in context.ART_MUSICA_ENTIDAD_IDENTIFICACION on e.ENT_ID equals i.ENT_ID
                              where u.ZON_ID == codMunicipio
                              where i.ENT_TIPO_ESCUELA == "1"
                              select new Basica
                              {
                                  Value = e.ENT_ID.ToString(),
                                  Nombre = e.ENT_NOMBRE
                              }).ToList();


                }


            }
            catch (Exception)
            {
                throw;

            }
            return listado;

        }
        public static ART_MUSICA_ENTIDAD_IDENTIFICACION ConsultarIdentificacionPorId(decimal EntId)
        {
            var model = new ART_MUSICA_ENTIDAD_IDENTIFICACION();
            try
            {
                using (var context = new SIPAEntities())
                {
                    model = context.ART_MUSICA_ENTIDAD_IDENTIFICACION.Where(x => x.ENT_ID == EntId).FirstOrDefault();

                }
                return model;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static EscuelasDatosBasicosDTO ConsultarEsucuelaPorId(Decimal EntId)
        {
            var model = new EscuelasDatosBasicosDTO();
            try
            {
                using (var context = new SIPAEntities())
                {
                    model = context.Database.SqlQuery<EscuelasDatosBasicosDTO>(@"EXEC ART_ME_ART_ENTIDADES_ARTES_ObtenerPorId_produccion @ENT_ID", new SqlParameter("ENT_ID", EntId)).FirstOrDefault();

                }
                return model;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<EscuelaAuditoriaDTO> ConsultarAuditoriaEscuelas(int EscuelaId)
        {

            List<EscuelaAuditoriaDTO> listResultado = new List<EscuelaAuditoriaDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {


                    listResultado = context.Database.SqlQuery<EscuelaAuditoriaDTO>(@"EXEC ART_MUSICA_AUDITORIA_ESCUELAS @EscuelaId", new SqlParameter("EscuelaId", EscuelaId)).ToList();


                }
                return listResultado;

            }
            catch (Exception)
            {
                throw;
            }


        }

        public static string ObtenerNaturaleza(Decimal EntId)
        {
            string Naturaleza = "";
            try
            {
                using (var context = new SIPAEntities())
                {

                    var model = context.ART_ENTIDAD_NATURALEZA_JURIDICA.Where(x => x.ENT_ID == EntId).FirstOrDefault();
                    if (model != null)
                        Naturaleza = model.ENT_NATURALEZA;

                }
                return Naturaleza;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int ConsultarAreaPorId(Decimal EntId)
        {
            decimal AreaId = 0;
            try
            {
                using (var context = new SIPAEntities())
                {

                    AreaId = context.ART_ENTIDAD_UBICACION.Where(x => x.ENT_ID == EntId).FirstOrDefault().ARE_ID;

                }
                return (int)AreaId;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static bool ExisteEscuela(string municipio)
        {
            bool validate = false;
            try
            {
                using (var context = new SIPAEntities())
                {

                    var entidad = (from E in context.ART_ENTIDADES_ARTES
                                   join U in context.ART_ENTIDAD_UBICACION on E.ENT_ID equals U.ENT_ID
                                   where U.ZON_ID == municipio
                                   select U).FirstOrDefault();

                    if (entidad != null)
                        validate = true;
                }

            }
            catch
            {

            }
            return validate;
        }

        public static List<ART_ME_ART_ENTIDADES_ARTES_ObtenerDatosBasicosPorId_Result> ConsultarEsucuelaDatosBasicosPorId(decimal EntId)
        {
            var model = new List<ART_ME_ART_ENTIDADES_ARTES_ObtenerDatosBasicosPorId_Result>();
            try
            {
                using (var context = new SIPAEntities())
                {
                    model = context.ART_ME_ART_ENTIDADES_ARTES_ObtenerDatosBasicosPorId(EntId).ToList();

                }
                return model;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<ART_ME_ART_ENTIDADES_ARTES_ObtenerParaAdmin_Result> ConsultarEsucuelaParAdminPorId(decimal EntId)
        {
            var model = new List<ART_ME_ART_ENTIDADES_ARTES_ObtenerParaAdmin_Result>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    model = context.ART_ME_ART_ENTIDADES_ARTES_ObtenerParaAdmin(EntId).ToList();

                }
                return model;

            }
            catch (Exception)
            {
                throw;
            }
        }



        public static List<EscuelaResultadoDTO> ConsultarEscuelasTodos(string departamento)
        {

            List<EscuelaResultadoDTO> listResultado = new List<EscuelaResultadoDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {


                    listResultado = context.Database.SqlQuery<EscuelaResultadoDTO>(@"EXEC ART_MUSICA_ESCUELAS_Obtener_Todos_Produccion @DEPARTAMENTO_ID", new SqlParameter("DEPARTAMENTO_ID", departamento)).ToList();


                }
                return listResultado;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<EscuelaNuevoDatosDTO> ConsultarEscuelasTodos()
        {

            List<EscuelaNuevoDatosDTO> listResultado = new List<EscuelaNuevoDatosDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {


                    listResultado = context.Database.SqlQuery<EscuelaNuevoDatosDTO>(@"EXEC ART_MUSICA_OBTENER_ESCUELAS").ToList();


                }
                return listResultado;

            }
            catch (Exception)
            {
                throw;
            }
        }


        public static List<EscuelaNuevoDatosDTO> ConsultarEscuelasPorMunicipio(int UsuarioId)
        {

            List<EscuelaNuevoDatosDTO> listResultado = new List<EscuelaNuevoDatosDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {


                    listResultado = context.Database.SqlQuery<EscuelaNuevoDatosDTO>(@"EXEC ART_MUSICA_ESCUELAS_Por_Municipio_Nuevo @UsuarioId", new SqlParameter("UsuarioId", UsuarioId)).ToList();


                }
                return listResultado;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<EscuelaNuevoDatosDTO> ConsultarEscuelasPorEstado(int EstadoId)
        {

            List<EscuelaNuevoDatosDTO> listResultado = new List<EscuelaNuevoDatosDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {


                    listResultado = context.Database.SqlQuery<EscuelaNuevoDatosDTO>(@"EXEC ART_MUSICA_ESCUELAS_Por_EstadoId_Nuevo @EstadoId", new SqlParameter("EstadoId", EstadoId)).ToList();


                }
                return listResultado;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<EscuelaResultadoPublicoDTO> ConsultaEscuelasDatosPublicos(string EstadoId)
        {

            List<EscuelaResultadoPublicoDTO> listResultado = new List<EscuelaResultadoPublicoDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {


                    listResultado = context.Database.SqlQuery<EscuelaResultadoPublicoDTO>(@"EXEC ART_MUSICA_ESCUELAS_PUBLICO @EstadoId", new SqlParameter("EstadoId", EstadoId)).ToList();


                }
                return listResultado;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<EscuelaNuevoDatosDTO> ConsultarEscuelasPorAdmUsuarios(decimal AdmUsuarioId)
        {

            List<EscuelaNuevoDatosDTO> listResultado = new List<EscuelaNuevoDatosDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {


                    listResultado = context.Database.SqlQuery<EscuelaNuevoDatosDTO>(@"EXEC ART_MUSICA_ESCUELAS_Por_UsuarioID_Nuevo @UsuarioId", new SqlParameter("UsuarioId", AdmUsuarioId)).ToList();


                }
                return listResultado;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<ART_ME_ART_ENTIDADES_ARTES_ObtenerTodosParaAdmin_Result> ConsultarEscuelasTodosParaAdmin(string departamento = "-1")
        {
            var model = new List<ART_ME_ART_ENTIDADES_ARTES_ObtenerTodosParaAdmin_Result>();
            try
            {
                using (var context = new SIPAEntities())
                {
                    model = context.ART_ME_ART_ENTIDADES_ARTES_ObtenerTodosParaAdmin(departamento).ToList();

                }
                return model;

            }
            catch (Exception)
            {
                throw;
            }
        }


        public static List<EscuelaResultadoSolicitudDTO> ConsultarEscuelasPorMunicipio(string codigoMunicipio)
        {
            var listBasica = new List<EscuelaResultadoSolicitudDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    listBasica = (from e in context.ART_ENTIDADES_ARTES
                                  join u in context.ART_ENTIDAD_UBICACION on e.ENT_ID equals u.ENT_ID
                                  join i in context.ART_MUSICA_ENTIDAD_IDENTIFICACION on e.ENT_ID equals i.ENT_ID
                                  join a in context.ADM_USUARIOS on i.USU_ID equals a.USU_ID
                                  where u.ZON_ID == codigoMunicipio
                                  select new EscuelaResultadoSolicitudDTO
                                  {
                                      EsuelaId = e.ENT_ID,
                                      Nombre = e.ENT_NOMBRE,
                                      Direccion = u.ENT_DIRECCION,
                                      Contacto = e.ENT_NOMBRE_CONTACTO,
                                      UsuarioSipaId = i.USU_ID ?? 0,
                                      NombreUsuario = a.USU_NOMBRE,
                                      Correo = a.USU_CORREO_ELECTRONICO
                                  }).ToList();

                }
                return listBasica;

            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion
    }
}
