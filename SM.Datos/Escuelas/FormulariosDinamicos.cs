using SM.Datos.DTO;
using SM.SIPA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SM.Datos.Escuelas
{
    public class FormulariosDinamicos
    {

        public static List<ART_ME_FORMULARIOS_LISTAS_ELEMENTOS> ConsultarElementosLista()
        {
            List<ART_ME_FORMULARIOS_LISTAS_ELEMENTOS> listFormularios = new List<ART_ME_FORMULARIOS_LISTAS_ELEMENTOS>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    listFormularios = (from f in context.ART_ME_FORMULARIOS_LISTAS_ELEMENTOS
                                      select f).ToList();


                }
                return listFormularios;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<ART_ME_FORMULARIOS_LISTAS_ELEMENTOS> ConsultarElementosListaPorId(decimal litadoId)
        {
            List<ART_ME_FORMULARIOS_LISTAS_ELEMENTOS> listFormularios = new List<ART_ME_FORMULARIOS_LISTAS_ELEMENTOS>();
            try
            {
                using (var context = new SIPAEntities())
                {

                    listFormularios = (from f in context.ART_ME_FORMULARIOS_LISTAS_ELEMENTOS
                                       where f.FLI_ID == litadoId
                                       select f).ToList();


                }
                return listFormularios;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<FormulariosDTO> ConsultarFormulariosActivos()
        {
            List<FormulariosDTO> listFormularios;
            try
            {
                using (var context = new SIPAEntities())
                {

                    listFormularios = (from f in context.ART_ME_FORMULARIOS
                                       where f.FOR_ESACTIVA == "S"
                                       orderby f.FOR_NOMBRE
                                       select new FormulariosDTO
                                         {
                                          ForID = f.FOR_ID,
                                          Nombre = f.FOR_NOMBRE,
                                          Descripcion = f.FOR_DESCRIPCION,
                                          Perfiles = f.FOR_PERFILES,
                                          EsActiva = f.FOR_ESACTIVA,
                                          EsEditable = f.FOR_ESEDITABLE,
                                          EsVisible = f.FOR_ESVISIBLE,
                                          FechaRegistro = f.FOR_FECHA_REGISTRO
                                         }).ToList();


                }
                return listFormularios;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<FormulariosDTO> ConsultarFormulariosActivosPorId(int Id)
        {
            List<FormulariosDTO> listFormularios;
            try
            {
                using (var context = new SIPAEntities())
                {

                    listFormularios = (from f in context.ART_ME_FORMULARIOS
                                       where f.FOR_ID == Id
                                       orderby f.FOR_NOMBRE
                                       select new FormulariosDTO
                                       {
                                           ForID = f.FOR_ID,
                                           Nombre = f.FOR_NOMBRE,
                                           Descripcion = f.FOR_DESCRIPCION,
                                           Perfiles = f.FOR_PERFILES,
                                           EsActiva = f.FOR_ESACTIVA,
                                           EsEditable = f.FOR_ESEDITABLE,
                                           EsVisible = f.FOR_ESVISIBLE,
                                           FechaRegistro = f.FOR_FECHA_REGISTRO
                                       }).ToList();


                }
                return listFormularios;

            }
            catch (Exception)
            {
                throw;
            }
        }

       

        public static List<ValoresResultadoDTO> ConsultarValores(decimal EntId, decimal FormularioId)
        {

            List<ValoresResultadoDTO> listResultado = new List<ValoresResultadoDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {


                    listResultado = context.Database.SqlQuery<ValoresResultadoDTO>(@"EXEC ART_ME_ART_MUSICA_FORMULARIOS_VALORES @ENT_ID, @FormularioId", new SqlParameter("ENT_ID", EntId), new SqlParameter("FormularioId", FormularioId)).ToList();

                }
                return listResultado;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<FormularioValoresResultadoDTO> ConsultarCamposFormulariodinamico(decimal FormularioId)
        {

            List<FormularioValoresResultadoDTO> listResultado = new List<FormularioValoresResultadoDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {


                    listResultado = context.Database.SqlQuery<FormularioValoresResultadoDTO>(@"EXEC ART_MUSICA_OBTENER_VALORES_FORMULARIOS @FormularioId", new SqlParameter("FormularioId", FormularioId)).ToList();

                }
                return listResultado;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<FormularioValoresResultadoDTO> ConsultarCamposFormulariodinamicoTodos()
        {

            List<FormularioValoresResultadoDTO> listResultado = new List<FormularioValoresResultadoDTO>();
            try
            {
                using (var context = new SIPAEntities())
                {


                    listResultado = context.Database.SqlQuery<FormularioValoresResultadoDTO>(@"EXEC ART_MUSICA_OBTENER_VALORES_FORMULARIOS_TODOS").ToList();

                }
                return listResultado;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<ART_ME_FORMULARIOS_SECCIONES> ConsultarSeccionesTodas()
        {

            List<ART_ME_FORMULARIOS_SECCIONES> listResultado = new List<ART_ME_FORMULARIOS_SECCIONES>();
            try
            {
                using (var context = new SIPAEntities())
                {


                    listResultado = context.Database.SqlQuery<ART_ME_FORMULARIOS_SECCIONES>(@"EXEC ART_MUSICA_OBTENER_SECCIONES").ToList();

                }
                return listResultado;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static EscuelaEncabezadoResultadoDTO  ConsultarEncabezadoEscuela(decimal EscuelaId)
        {

            EscuelaEncabezadoResultadoDTO resultado = new EscuelaEncabezadoResultadoDTO();
            try
            {
                using (var context = new SIPAEntities())
                {


                    resultado = (from a in context.ART_ENTIDADES_ARTES
                                 where a.ENT_ID == EscuelaId
                                 select new EscuelaEncabezadoResultadoDTO
                                       {
                                           EscuelaId = a.ENT_ID,
                                           Nombre = a.ENT_NOMBRE,
                                           Resena = a.ENT_RESENA
                                       }).FirstOrDefault();

                }
                return resultado;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void GuardarFormulario(List<FormularioCampoValoresDTO> listResultado, decimal EscuelaId)
        {
            decimal RegistroId = 0;
       
            try
            {
                using (var context = new SIPAEntities())
                {

                    using (var dbContextTransaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            var formulario = new ART_ME_FORMULARIOS_REGISTRO
                              {
                                  ENT_ID = EscuelaId,
                                  FRE_FECHA_REGISTRO = DateTime.Now,
                              };

                            context.ART_ME_FORMULARIOS_REGISTRO.Add(formulario);
                            context.SaveChanges();
                            RegistroId = formulario.FRE_ID;


                            if (listResultado != null)
                            {
                                foreach (var item in listResultado)
                                {
                                  
                                        var campos = new ART_ME_FORMULARIOS_VALORES
                                        {
                                            FCO_ID = item.FCO_ID,
                                            FRE_ID = RegistroId,
                                            FOR_ID = item.FOR_ID,
                                            FVA_DUPLICACION = -1,
                                            FVA_VALOR = item.FCO_DESCRIPCION,

                                        };

                                        context.ART_ME_FORMULARIOS_VALORES.Add(campos);
                                    
                                    if (item.FCO_TIPO_DATO == "A")
                                    {
                                        if (item.archivo != null)
                                        {
                                            var archivos = new ART_MUSICA_FORMULARIO_ARCHIVOS
                                            {
                                                FCO_ID = item.FCO_ID,
                                                FRE_ID = RegistroId,
                                                FOR_ID = item.FOR_ID,
                                                NombreArchivo = item.NombreArchivo, 
                                                Tipo = item.TipoArchivo,
                                                Archivo = item.archivo,
                                            };
                                            context.ART_MUSICA_FORMULARIO_ARCHIVOS.Add(archivos);
                                        }
                                    }
                                }
                            }


                            context.SaveChanges();
                            dbContextTransaction.Commit();
                        }
                        catch
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
    }
}
