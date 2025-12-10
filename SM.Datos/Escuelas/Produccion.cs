using SM.Datos.AuditoriaData;
using SM.SIPA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Datos.Escuelas
{
    public class Produccion
    {
        #region Actualización
        public static void Insertar(decimal entId, 
                                    short entCantidadGirasUltimoAno, 
                                    short entCantidadPresentacionesLocalidadUltimoAno, 
                                    short entCantidadDiscosUltimoAno, 
                                    short entCantidadRepertoriosUltimoAno, 
                                    short entCantidadMaterialDivulgativoUltimoAno, 
                                    short entCantidadMaterialApoyoUltimoAno, 
                                    short entCantidadAgrupacionesConformadasVigentesUltimoAno, 
                                    short entCantidadGirasInterUltimoAno,
                                    int SimusUsuarioId,
                                    string NombreUsuario,
                                     string strIP)
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    context.ART_ME_ART_MUSICA_ENTIDAD_PRODUCCION_Insertar(entId,
                                                                         entCantidadGirasUltimoAno,
                                                                         entCantidadPresentacionesLocalidadUltimoAno,
                                                                         entCantidadDiscosUltimoAno,
                                                                         entCantidadRepertoriosUltimoAno,
                                                                         entCantidadMaterialDivulgativoUltimoAno,
                                                                         entCantidadMaterialApoyoUltimoAno,
                                                                         entCantidadAgrupacionesConformadasVigentesUltimoAno,
                                                                         entCantidadGirasInterUltimoAno);

                    //Auditoria
                    string temp;
                    temp = string.Format("El usuario {0} ({1}) insertó el {2} la  escuela de música - participación.\nDatos actuales:\n{3} ", NombreUsuario, SimusUsuarioId, DateTime.Now, "ART_MUSICA_ENTIDAD_PRODUCCION");
                    StringBuilder stringBuilder = new StringBuilder();
                    stringBuilder.AppendLine(temp);
                    ART_MUSICA_REGISTRO_OPERACION registroOperacion = new ART_MUSICA_REGISTRO_OPERACION { Categoria = CategoriaRegistroOperacion.EscuelasProducción.ToString(), IpUsuario = strIP, RegistroId = Convert.ToInt32(entId), UsuarioId = SimusUsuarioId, NombreUsuario = NombreUsuario, Descripcion = stringBuilder.ToString(), FechaRegistro = DateTime.Now, Operacion = "Actualización" };

                    RegistroOperacionServicio auditoria = new RegistroOperacionServicio();
                    auditoria.Crear(registroOperacion);
                }
            }
            catch (Exception)
            { throw; }
        }

        public static bool ValidarProduccion(decimal EntId)
        {
            try
            {
                bool validar = false;
                using (var context = new SIPAEntities())
                {
                    // Ojo esto se valida al crear formación
                    var datos = context.ART_MUSICA_ENTIDAD_PRODUCCION.Where(x => x.ENT_ID == EntId).SingleOrDefault();
                    if (datos != null)
                        validar = true;

                    return validar;
                }
            }
            catch (Exception)
            { throw; }
        }
        public static void Actualizar(decimal entId, 
                                        short entCantidadGirasUltimoAno, 
                                        short entCantidadPresentacionesLocalidadUltimoAno, 
                                        short entCantidadDiscosUltimoAno, 
                                        short entCantidadRepertoriosUltimoAno, 
                                        short entCantidadMaterialDivulgativoUltimoAno, 
                                        short entCantidadMaterialApoyoUltimoAno, 
                                        short entCantidadAgrupacionesConformadasVigentesUltimoAno, 
                                        short entCantidadGirasInterUltimoAno,
                                        int SimusUsuarioId,
                                       string NombreUsuario,
                                       string strIP)
        {
            try
            {

                using (var context = new SIPAEntities())
                {
                    context.ART_ME_ART_MUSICA_ENTIDAD_PRODUCCION_Actualizar(entId,
                                                                             entCantidadGirasUltimoAno,
                                                                             entCantidadPresentacionesLocalidadUltimoAno,
                                                                             entCantidadDiscosUltimoAno,
                                                                             entCantidadRepertoriosUltimoAno,
                                                                             entCantidadMaterialDivulgativoUltimoAno,
                                                                             entCantidadMaterialApoyoUltimoAno,
                                                                             entCantidadAgrupacionesConformadasVigentesUltimoAno,
                                                                             entCantidadGirasInterUltimoAno);

                    //Auditoria
                    string temp;
                    temp = string.Format("El usuario {0} ({1}) actualizó el {2} la  escuela de música - participación.\nDatos actuales:\n{3} ", NombreUsuario, SimusUsuarioId, DateTime.Now, "ART_MUSICA_ENTIDAD_PRODUCCION");
                    StringBuilder stringBuilder = new StringBuilder();
                    stringBuilder.AppendLine(temp);
                    ART_MUSICA_REGISTRO_OPERACION registroOperacion = new ART_MUSICA_REGISTRO_OPERACION { Categoria = CategoriaRegistroOperacion.EscuelasProducción.ToString(), IpUsuario = strIP, RegistroId = Convert.ToInt32(entId), UsuarioId = SimusUsuarioId, NombreUsuario = NombreUsuario, Descripcion = stringBuilder.ToString(), FechaRegistro = DateTime.Now, Operacion = "Actualización" };

                    RegistroOperacionServicio auditoria = new RegistroOperacionServicio();
                    auditoria.Crear(registroOperacion);
                }
            }
            catch (Exception)
            { throw; }
        }

        public static void Eliminar(decimal entId)
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    context.ART_ME_ART_MUSICA_ENTIDAD_PRODUCCION_Eliminar(entId);
                    context.SaveChanges();
                }

            }
            catch (Exception)
            { throw; }

        }
        #endregion

        #region Consultas
        public static List<ART_ME_ART_MUSICA_ENTIDAD_PRODUCCION_ObtenerPorId_Result> ConsultarProduccionPorId(decimal EntId)
        {
            try
            {
                var model = new List<ART_ME_ART_MUSICA_ENTIDAD_PRODUCCION_ObtenerPorId_Result>();
                using (var context = new SIPAEntities())
                {

                    model = context.ART_ME_ART_MUSICA_ENTIDAD_PRODUCCION_ObtenerPorId(EntId).ToList();

                }
                return model;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<ART_ME_ART_MUSICA_ENTIDAD_PRODUCCION_ObtenerTodos_Result> ConsultarProduccionTodos()
        {
            try
            {
                var model = new List<ART_ME_ART_MUSICA_ENTIDAD_PRODUCCION_ObtenerTodos_Result>();
                using (var context = new SIPAEntities())
                {

                    model = context.ART_ME_ART_MUSICA_ENTIDAD_PRODUCCION_ObtenerTodos().ToList();

                }
                return model;

            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
