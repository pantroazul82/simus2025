using SM.Datos.DTO;
using SM.Datos.DTO.Servicios;
using SM.SIPA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Datos.Servicios
{
    public class DotacionServicio
    {
        public static int Crear(ART_MUSICA_DOTACION registro)
        {
            int DotacionId = 0;
            try
            {
                using (var context = new SIPAEntities())
                {
                    context.ART_MUSICA_DOTACION.Add(registro);
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

        public static int CrearInstrumento(ART_MUSICA_DOTACION_INSTRUMENTOS registro)
        {
            int DotacionId = 0;
            try
            {
                using (var context = new SIPAEntities())
                {
                    context.ART_MUSICA_DOTACION_INSTRUMENTOS.Add(registro);
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

        public static void Actualizar(int DotacionId,
                                     string nombre,
                                     string apellido,
                                     string Identificacion,
                                    string cargo,
                                     string Telefono,
                                     string celular,
                                     string email)
        {
            try
            {

                using (var context = new SIPAEntities())
                {
                    var entidad = context.ART_MUSICA_DOTACION.Where(x => x.Id == DotacionId).FirstOrDefault();

                    if (entidad != null)
                    {
                        entidad.Nombre = nombre;
                        entidad.Apellido = apellido;
                        entidad.Identificacion = Identificacion;
                        entidad.Cargo = cargo;
                        entidad.Telefono = Telefono;
                        entidad.Celular = celular;
                        entidad.Email = email;
                    }
                    context.SaveChanges();

                }
            }
            catch (Exception)
            { throw; }
        }

        public static ART_MUSICA_DOTACION ConsultarDotacionId(int Id)
        {

            var registro = new ART_MUSICA_DOTACION();

            try
            {
                using (var context = new SIPAEntities())
                {

                    registro = context.ART_MUSICA_DOTACION.Where(x => x.Id == Id).FirstOrDefault();


                }
                return registro;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<InstrumentoResultadoDTO> ConsultarInstrumentoDotacion(int DotacionId)
        {
            var listDocumentos = new List<InstrumentoResultadoDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    listDocumentos = (from e in context.ART_MUSICA_DOTACION_INSTRUMENTOS
                                      join i in context.ART_MUSICA_PARAMETROS_SERVICIOS on e.InstrumentoId equals i.Id
                                      join p in context.ART_MUSICA_PARAMETROS_SERVICIOS on e.PrioridadId equals p.Id
                                      where e.DotacionId == DotacionId
                                      select new InstrumentoResultadoDTO
                                      {
                                          DotacionInstrumentoId = e.Id,
                                          Instrumento = i.Nombre,
                                          Prioridad = p.Nombre,
                                          Cantidad = e.Cantidad
                                      }).ToList();
                }

                return listDocumentos;
            }
            catch (Exception)
            { throw; }
        }
        public static List<DotacionResultadoDTO> ConsultarListadoDotacion()
        {

            var listResultado = new List<DotacionResultadoDTO>();

            try
            {
                using (var context = new SIPAEntities())
                {


                    listResultado = context.Database.SqlQuery<DotacionResultadoDTO>(@"EXEC ART_MUSICA_LISTADO_DOTACION").ToList();

                }
                return listResultado;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void EliminarDotacionInstrumento(int DotacionInstrumentoId)
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    using (var dbContextTransaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            var entidad = context.ART_MUSICA_DOTACION_INSTRUMENTOS.Where(x => x.Id == DotacionInstrumentoId).FirstOrDefault();

                            if (entidad != null)
                            {
            
                                context.ART_MUSICA_DOTACION_INSTRUMENTOS.Remove(entidad);
                                context.SaveChanges();

                               
                                dbContextTransaction.Commit();
                            }

                        }

                        catch
                        { dbContextTransaction.Rollback(); }
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
