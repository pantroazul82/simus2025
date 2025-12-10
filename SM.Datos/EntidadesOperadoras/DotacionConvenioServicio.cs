using SM.Datos.DTO;
using SM.Datos.DTO.Servicios;
using SM.LibreriaComun.DTO.EntidadesOperadoras;
using SM.SIPA;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;


namespace SM.Datos.EntidadesOperadoras
{
    public class DotacionConvenioServicio
    {
        public static int Crear(ART_MUSICA_CONVENIO_DOTACION registro)
        {
            int DotacionId = 0;
            try
            {
                using (var context = new SIPAEntities())
                {
                    context.ART_MUSICA_CONVENIO_DOTACION.Add(registro);
                    context.SaveChanges();
                    DotacionId = registro.Id;

                }

                return DotacionId;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void Actualizar(int Id, DotacionDTO datos, int UsuarioId)
        {
            try
            {

                using (var context = new SIPAEntities())
                {
                    var entidad = context.ART_MUSICA_CONVENIO_DOTACION.Where(x => x.Id == Id).FirstOrDefault();



                    if (entidad != null)
                    {
                        entidad.CronogramaId = Convert.ToInt32(datos.CronogramaId);
                        entidad.FechaActualizacion = DateTime.Now;
                        entidad.Serial = datos.Serial;
                        entidad.Diagnostico = datos.Diagnostico;
                        entidad.Aprobado = datos.Aprobado;
                        entidad.Marca = datos.Marca;
                        entidad.Garantia = datos.Garantia;
                        entidad.Referencia = datos.Referencia;
                        entidad.TipoId = Convert.ToInt32(datos.TipoId);
                        entidad.ElementoId = Convert.ToInt32(datos.ElementoId);
                        entidad.FormatoId = Convert.ToInt32(datos.FormatoId);
                        entidad.Precio = datos.Precio;
                        entidad.UsuarioCreadorId = UsuarioId;
                        entidad.Descripcion = datos.Descripcion;
                        entidad.Prooveedor = datos.Proveedor;

                    }
                    context.SaveChanges();

                }
            }
            catch (Exception)
            { throw; }
        }
        #region Consulta

        public static List<ART_MUSICA_CONVENIO_DOTACION> ConsultarPorCronogramaId(int Id)
        {
            var listado = new List<ART_MUSICA_CONVENIO_DOTACION>();

            try
            {
                using (var context = new SIPAEntities())
                {
                    listado = context.ART_MUSICA_CONVENIO_DOTACION.Where(x => x.CronogramaId == Id).ToList();
                }
                return listado;
            }
            catch (Exception)
            { throw; }
        }
        public static ART_MUSICA_CONVENIO_DOTACION ConsultarPorId(int Id)
        {

            var registro = new ART_MUSICA_CONVENIO_DOTACION();

            try
            {
                using (var context = new SIPAEntities())
                {

                    registro = context.ART_MUSICA_CONVENIO_DOTACION.Where(x => x.Id == Id).FirstOrDefault();


                }
                return registro;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void Eliminar(int Id)
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    context.ART_MUSICA_CONVENIO_DOTACION.Remove(context.ART_MUSICA_CONVENIO_DOTACION.Where(x => x.Id == Id).FirstOrDefault());
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion
    }
}
