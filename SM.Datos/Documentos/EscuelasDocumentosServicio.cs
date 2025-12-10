using SM.Datos.AuditoriaData;
using SM.Datos.DTO;
using SM.SIPA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SM.Datos.Documentos
{
    /// <summary>
    /// Clase de datos para asociar los documentos a laas escuelas.
    /// </summary>
    public class EscuelasDocumentosServicio
    {
        public static void Crear(ART_MUSICA_DOCUMENTOS documento, decimal EscuelaId, string Categoria, string NombreUsuario, string strIP, int ArtMusicaUsuarioId)
        {
            int documentoId = 0;
            try
            {

                using (var context = new SIPAEntities())
                {
                    using (var dbContextTransaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            context.ART_MUSICA_DOCUMENTOS.Add(documento);
                            context.SaveChanges();
                            documentoId = documento.Id;

                            var entidad = new ART_MUSICA_ESCUELAS_DOCUMENTOS
                            {
                                Categoria = Categoria,
                                EscuelaId = EscuelaId,
                                DocumentoId = documentoId,
                            };
                            context.ART_MUSICA_ESCUELAS_DOCUMENTOS.Add(entidad);
                            context.SaveChanges();
                            dbContextTransaction.Commit();

                            //Auditoria
                            string temp;
                            temp = string.Format("El usuario {0} ({1}) creó el {2} la escuela de música.\nDatos actuales:\n{3} ", NombreUsuario, ArtMusicaUsuarioId, DateTime.Now, "ART_MUSICA_ESCUELAS_DOCUMENTOS");
                            StringBuilder stringBuilder = new StringBuilder();
                            stringBuilder.AppendLine(temp);
                            ART_MUSICA_REGISTRO_OPERACION registroOperacion = new ART_MUSICA_REGISTRO_OPERACION { Categoria = CategoriaRegistroOperacion.EscuelasDocumentos.ToString(), IpUsuario = strIP, RegistroId = Convert.ToInt32(EscuelaId), UsuarioId = ArtMusicaUsuarioId, NombreUsuario = NombreUsuario, Descripcion = stringBuilder.ToString(), FechaRegistro = DateTime.Now, Operacion = "Creación" };

                            RegistroOperacionServicio auditoria = new RegistroOperacionServicio();
                            auditoria.Crear(registroOperacion);
                        }
                        catch(Exception)
                        {
                            dbContextTransaction.Rollback();
                            throw;
                        }
                    }


                }

              
            }
            catch (Exception)
            {
                throw;
            }

        }



        public static void CrearDocumentosDotacion(ART_MUSICA_DOCUMENTOS documento, int DotacionId, string Categoria)
        {
            int documentoId = 0;
            try
            {

                using (var context = new SIPAEntities())
                {
                    using (var dbContextTransaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            context.ART_MUSICA_DOCUMENTOS.Add(documento);
                            context.SaveChanges();
                            documentoId = documento.Id;

                            var entidad = new ART_MUSICA_DOTACION_DOCUMENTOS
                            {
                                DotacionId = DotacionId,
                                CategoriaId = Convert.ToInt32(Categoria),
                                DocumentoId = documentoId,
                            };
                            context.ART_MUSICA_DOTACION_DOCUMENTOS.Add(entidad);
                            context.SaveChanges();
                            dbContextTransaction.Commit();

                           
                        }
                        catch (Exception)
                        {
                            dbContextTransaction.Rollback();
                            throw;
                        }
                    }


                }


            }
            catch (Exception)
            {
                throw;
            }

        }


        public static void CrearDocumentosCronograma(ART_MUSICA_DOCUMENTOS documento, int CronogramaId, string Tipo, int UsuarioId)
        {
            int documentoId = 0;
            try
            {

                using (var context = new SIPAEntities())
                {
                    using (var dbContextTransaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            context.ART_MUSICA_DOCUMENTOS.Add(documento);
                            context.SaveChanges();
                            documentoId = documento.Id;

                            var entidad = new ART_MUSICA_CRONOGRAMA_DOCUMENTO
                            {
                                CronogramaId = CronogramaId,
                                TipoId = Convert.ToInt32(Tipo),
                                UsuarioId = UsuarioId,
                                FechaCreacion = DateTime.Today,
                                DocumentoId = documentoId,
                            };
                            context.ART_MUSICA_CRONOGRAMA_DOCUMENTO.Add(entidad);
                            context.SaveChanges();
                            dbContextTransaction.Commit();


                        }
                        catch (Exception)
                        {
                            dbContextTransaction.Rollback();
                            throw;
                        }
                    }


                }


            }
            catch (Exception)
            {
                throw;
            }

        }

        public static void EliminarDocumento(int EscuelaDocumentoId)
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    using (var dbContextTransaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            var entidad = context.ART_MUSICA_ESCUELAS_DOCUMENTOS.Where(x => x.Id == EscuelaDocumentoId).FirstOrDefault();

                            if (entidad != null)
                            {
                                int documentoId = entidad.DocumentoId;

                                context.ART_MUSICA_ESCUELAS_DOCUMENTOS.Remove(entidad);
                                context.SaveChanges();

                                context.ART_MUSICA_DOCUMENTOS.Remove(context.ART_MUSICA_DOCUMENTOS.Where(x => x.Id == documentoId).FirstOrDefault());
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

        public static void EliminarDocumentoDotacion(int DotacionDocumentoId)
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    using (var dbContextTransaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            var entidad = context.ART_MUSICA_DOTACION_DOCUMENTOS.Where(x => x.Id == DotacionDocumentoId).FirstOrDefault();

                            if (entidad != null)
                            {
                                int documentoId = entidad.DocumentoId;

                                context.ART_MUSICA_DOTACION_DOCUMENTOS.Remove(entidad);
                                context.SaveChanges();

                                context.ART_MUSICA_DOCUMENTOS.Remove(context.ART_MUSICA_DOCUMENTOS.Where(x => x.Id == documentoId).FirstOrDefault());
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

        public static void EliminarDocumentoCronograma(int CronogramaDocumentoId)
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    using (var dbContextTransaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            var entidad = context.ART_MUSICA_CRONOGRAMA_DOCUMENTO.Where(x => x.Id == CronogramaDocumentoId).FirstOrDefault();

                            if (entidad != null)
                            {
                                int documentoId = entidad.DocumentoId;

                                context.ART_MUSICA_CRONOGRAMA_DOCUMENTO.Remove(entidad);
                                context.SaveChanges();

                                context.ART_MUSICA_DOCUMENTOS.Remove(context.ART_MUSICA_DOCUMENTOS.Where(x => x.Id == documentoId).FirstOrDefault());
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

        public static List<DocumentoResultadoDTO> ConsultarDocumentos(decimal EscuelaId)
        {
            var listDocumentos = new List<DocumentoResultadoDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    listDocumentos = (from e in context.ART_MUSICA_ESCUELAS_DOCUMENTOS
                                      join d in context.ART_MUSICA_DOCUMENTOS on e.DocumentoId equals d.Id
                                      where e.EscuelaId == EscuelaId
                                      select new DocumentoResultadoDTO { 
                                          EscuelaDocumentoId = e.Id,
                                          DocumentoId = e.DocumentoId,
                                          EscuelaId = e.EscuelaId,
                                          Categoria = e.Categoria,
                                          TamanoArchivo = d.TamanoArchivo ?? 0,
                                          NombreArchivo = d.NombreArchivo,
                                          FechaRegistro = d.FechaRegistro 
                                      }).ToList();
                }

                return listDocumentos;
            }
            catch (Exception)
            { throw; }
        }

        public static List<DocumentoResultadoDTO> ConsultarDocumentosDotacion(int DotacionId)
        {
            var listDocumentos = new List<DocumentoResultadoDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    listDocumentos = (from e in context.ART_MUSICA_DOTACION_DOCUMENTOS
                                      join d in context.ART_MUSICA_DOCUMENTOS on e.DocumentoId equals d.Id
                                      join p in context.ART_MUSICA_PARAMETROS_SERVICIOS on e.CategoriaId equals p.Id
                                      where e.DotacionId == DotacionId
                                      select new DocumentoResultadoDTO
                                      {
                                          DotacionDocumentoId = e.Id,
                                          DocumentoId = e.DocumentoId,
                                          DotacionId = e.DotacionId,
                                          Categoria = p.Nombre,
                                          TamanoArchivo = d.TamanoArchivo ?? 0,
                                          NombreArchivo = d.NombreArchivo,
                                          FechaRegistro = d.FechaRegistro
                                      }).ToList();
                }

                return listDocumentos;
            }
            catch (Exception)
            { throw; }
        }

        public static List<DocumentoResultadoDTO> ConsultarDocumentosCronograma(int CronogramaId)
        {
            var listDocumentos = new List<DocumentoResultadoDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    listDocumentos = (from e in context.ART_MUSICA_CRONOGRAMA_DOCUMENTO
                                      join d in context.ART_MUSICA_DOCUMENTOS on e.DocumentoId equals d.Id
                                      join p in context.ART_MUSICA_PARAMETROS_SERVICIOS on e.TipoId equals p.Id
                                      where e.CronogramaId == CronogramaId
                                      select new DocumentoResultadoDTO
                                      {
                                          DotacionDocumentoId = e.Id,
                                          DocumentoId = e.DocumentoId,
                                          CronogramaId = e.CronogramaId,
                                          Categoria = p.Nombre,
                                          TamanoArchivo = d.TamanoArchivo ?? 0,
                                          NombreArchivo = d.NombreArchivo,
                                          FechaRegistro = d.FechaRegistro
                                      }).ToList();
                }

                return listDocumentos;
            }
            catch (Exception)
            { throw; }
        }

    }
}
