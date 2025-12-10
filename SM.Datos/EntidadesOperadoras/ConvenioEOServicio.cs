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
    public class ConvenioEOServicio
    {

        #region actualizacion
        public static int Crear(ART_MUSICA_CONVENIOS registro)
        {
            int DotacionId = 0;
            try
            {
                using (var context = new SIPAEntities())
                {
                    context.ART_MUSICA_CONVENIOS.Add(registro);
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

        public static void ActualizarDocumento(int ConvenioId,
                                               int documentoId)
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    var entidad = context.ART_MUSICA_CONVENIOS.Where(x => x.Id == ConvenioId).FirstOrDefault();

                    if (entidad != null)
                    {
                        entidad.DocumentoId = documentoId;
                        entidad.FechaActualizacion = DateTime.Now;
                    }
                    context.SaveChanges();
                }
            }
            catch (Exception)
            { throw; }
        }

        public static void Actualizar(int Id, ConvenioDTO datos, int UsuarioId)
        {
            try
            {

                using (var context = new SIPAEntities())
                {
                    var entidad = context.ART_MUSICA_CONVENIOS.Where(x => x.Id == Id).FirstOrDefault();



                    if (entidad != null)
                    {
                        entidad.Coord_AgenteId = Convert.ToInt32(datos.Coord_AgenteId);
                        entidad.EntidadId = Convert.ToInt32(datos.EntidadId);
                        entidad.EstadoId = Convert.ToInt32(datos.EstadoId);
                        entidad.FechaInicio = Convert.ToDateTime(datos.FechaInicio);
                        entidad.FechaFin = Convert.ToDateTime(datos.FechaFin);
                        entidad.Objeto = datos.Objeto;
                        entidad.Periodo = Convert.ToInt32(datos.Periodo);
                        entidad.Valor = Convert.ToDecimal(datos.Valor);
                        entidad.Descripcion = datos.Descripcion;
                        entidad.FechaActualizacion = DateTime.Now;
                        entidad.FechaCreacion = DateTime.Now;
                        entidad.Nombre = datos.Nombre;
                        entidad.UsuarioCreadorId = UsuarioId;

                    }
                    context.SaveChanges();

                }
            }
            catch (Exception)
            { throw; }
        }

        #endregion

        #region Consulta
        public static ART_MUSICA_CONVENIOS ConsultarPorId(int Id)
        {

            var registro = new ART_MUSICA_CONVENIOS();

            try
            {
                using (var context = new SIPAEntities())
                {

                    registro = context.ART_MUSICA_CONVENIOS.Where(x => x.Id == Id).FirstOrDefault();


                }
                return registro;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<ART_MUSICA_CONVENIOS> ConsultarTodo()
        {

            var listado = new List<ART_MUSICA_CONVENIOS>();

            try
            {
                using (var context = new SIPAEntities())
                {

                    listado = context.ART_MUSICA_CONVENIOS.ToList();


                }
                return listado;

            }
            catch (Exception)
            {
                throw;
            }
        }


        public static List<Basica> ObtenerEntidadesOperadoras()
        {

            List<Basica> listado;
            try
            {
                using (var context = new SIPAEntities())
                {

                    listado = (from E in context.ART_MUSICA_ENTIDADES
                               join T in context.ART_MUSICA_ENTIDAD_TIPOENTIDAD on E.Id equals T.EntidadId
                               where T.TipoEntidadId == 40
                               where E.EstadoId == 2
                               select new Basica
                               {
                                   Value = E.Id.ToString(),
                                   Nombre = E.Nombre
                               }).ToList();



                }
                return listado;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<Basica> ObtenerRepresentanteLegal()
        {
            //244 representante legal

            List<Basica> listado;
            try
            {
                using (var context = new SIPAEntities())
                {

                    listado = (from E in context.ART_MUSICA_AGENTE
                               join T in context.ART_MUSICA_AGENTEXOCUPACION on E.ID equals T.AgenteId
                               where T.OficioId == 244
                               select new Basica
{
    Value = E.ID.ToString(),
    Nombre = E.PrimerNombre + " " + E.SegundoNombre + " " + E.PrimerApellido
}).ToList();



                }
                return listado;

            }
            catch (Exception)
            {
                throw;
            }
        }


        public static List<Basica> ObtenerCoordinador()
        {
            //245 coordinador

            List<Basica> listado;
            try
            {
                using (var context = new SIPAEntities())
                {

                    listado = (from E in context.ART_MUSICA_AGENTE
                               join T in context.ART_MUSICA_AGENTEXOCUPACION on E.ID equals T.AgenteId
                               where T.OficioId == 245
                               select new Basica
                               {
                                   Value = E.ID.ToString(),
                                   Nombre = E.PrimerNombre + " " + E.SegundoNombre + " " + E.PrimerApellido
                               }).ToList();



                }
                return listado;

            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
