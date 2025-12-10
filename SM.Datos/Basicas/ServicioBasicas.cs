using SM.SIPA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SM.Datos.DTO;
using SM.LibreriaComun.DTO.General;

namespace SM.Datos.Basicas
{
    /// <summary>
    /// Clase de datos para consultar tablas maestras como son departamento, municipio, estado y tipo de documentos.
    /// </summary>
    public class ServicioBasicas
    {

        public static string obtenerNombreParametro(int Id)
        {
            string Nombre = String.Empty;
            try
            {
                using (var context = new SIPAEntities())
                {

                    Nombre = context.ART_MUSICA_PARAMETROS_SERVICIOS.Where(x => x.Id == Id).FirstOrDefault().Nombre;


                }
                return Nombre;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<Basica> ConsultarParametros(int CategoriaId)
        {
            List<Basica> listPaises;
            try
            {
                using (var context = new SIPAEntities())
                {

                    listPaises = (from P in context.ART_MUSICA_PARAMETROS_SERVICIOS
                                  where P.CategoriaId == CategoriaId
                                  select new Basica
                                  {
                                      Value = P.Id.ToString(),
                                      Nombre = P.Nombre
                                  }).ToList();


                }
                return listPaises;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<Basica> ConsultarParametrosPorCategoria(string Categoria)
        {
            List<Basica> listPaises;
            try
            {
                using (var context = new SIPAEntities())
                {

                    listPaises = (from P in context.ART_MUSICA_PARAMETROS_SERVICIOS
                                  where P.Categoria == Categoria
                                  select new Basica
                                  {
                                      Value = P.Id.ToString(),
                                      Nombre = P.Nombre
                                  }).ToList();


                }
                return listPaises;

            }
            catch (Exception)
            {
                throw;
            }
        }

        #region ZonasGeograficas
        public static List<Basica> ConsultarPaises()
        {
            List<Basica> listPaises;
            try
            {
                using (var context = new SIPAEntities())
                {

                    listPaises = (from z in context.BAS_ZONAS_PAISES
                                  select new Basica
                                  {
                                      Value = z.ZOP_ID.ToString(),
                                      Nombre = z.ZOP_NOMBRE
                                  }).ToList();


                }
                return listPaises;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<Basica> ConsultarDepartamentos()
        {
            List<Basica> listdepartamento;
            try
            {
                using (var context = new SIPAEntities())
                {

                    listdepartamento = (from z in context.BAS_ZONAS_GEOGRAFICAS
                                        where z.ZON_PADRE_ID == null
                                        where z.ZON_ID != "01"
                                        select new Basica
                                         {
                                             Value = z.ZON_ID,
                                             Nombre = z.ZON_NOMBRE
                                         }).ToList();


                }
                return listdepartamento;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<Basica> ConsultarDepartamentosporPais(string codPais)
        {
            List<Basica> listdepartamento;
            try
            {
                using (var context = new SIPAEntities())
                {

                    listdepartamento = (from z in context.BAS_ZONAS_GEOGRAFICAS
                                        where z.ZON_PADRE_ID == codPais
                                        select new Basica
                                        {
                                            Value = z.ZON_ID,
                                            Nombre = z.ZON_NOMBRE
                                        }).ToList();


                }
                return listdepartamento;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<Basica> ConsultarMunicipios(string codigoDane)
        {
            List<Basica> listMunicipio;
            try
            {
                using (var context = new SIPAEntities())
                {

                    listMunicipio = (from z in context.BAS_ZONAS_GEOGRAFICAS
                                     where z.ZON_PADRE_ID == codigoDane
                                     select new Basica
                                     {
                                         Value = z.ZON_ID,
                                         Nombre = z.ZON_NOMBRE
                                     }).ToList();


                }
                return listMunicipio;

            }
            catch (Exception)
            {
                throw;
            }
        }

        // Método deshabilitado - Tabla ART_TIPO_AREA no existe en BD
        public static List<Basica> ConsultarAreas()
        {
            return new List<Basica>();
        }


        public static Basica obtenerMunicipioPorcod(string codDpto, string codMun)
        {

            Basica objMunicipio = null;
            try
            {
                using (var context = new SIPAEntities())
                {

                    objMunicipio = (from z in context.BAS_ZONAS_GEOGRAFICAS
                                    where z.ZON_PADRE_ID == codDpto && z.ZON_ID == codMun
                                    select new Basica
                                    {
                                        Value = z.ZON_ID,
                                        Nombre = z.ZON_NOMBRE
                                    }).SingleOrDefault();


                }


            }
            catch (Exception)
            {
                objMunicipio = null;

            }
            return objMunicipio;

        }




        public static Basica obtenerDepartamentoPorcod(string codDpto)
        {

            Basica objdpto;
            try
            {
                using (var context = new SIPAEntities())
                {

                    objdpto = (from z in context.BAS_ZONAS_GEOGRAFICAS
                               where z.ZON_PADRE_ID == null
                               where z.ZON_ID != "01" && z.ZON_ID == codDpto
                               select new Basica
                               {
                                   Value = z.ZON_ID,
                                   Nombre = z.ZON_NOMBRE
                               }).SingleOrDefault();


                }
                return objdpto;

            }
            catch (Exception)
            {
                throw;
            }

        }

        public static Basica ObtenerNombres(string codigoMunicipio)
        {

            Basica objdpto;
            try
            {
                using (var context = new SIPAEntities())
                {

                    objdpto = (from m in context.BAS_ZONAS_GEOGRAFICAS
                               join d in context.BAS_ZONAS_GEOGRAFICAS on m.ZON_PADRE_ID equals d.ZON_ID
                               where m.ZON_ID == codigoMunicipio
                               select new Basica
                               {
                                   Value = d.ZON_NOMBRE,
                                   Nombre = m.ZON_NOMBRE
                               }).SingleOrDefault();


                }
                return objdpto;

            }
            catch (Exception)
            {
                throw;
            }

        }

        public static Basica ObtenerNombresPorEscuelaId(decimal EscuelaId)
        {

            Basica objdpto;
            try
            {
                using (var context = new SIPAEntities())
                {

                    objdpto = (from m in context.BAS_ZONAS_GEOGRAFICAS
                               join d in context.BAS_ZONAS_GEOGRAFICAS on m.ZON_PADRE_ID equals d.ZON_ID
                               join u in context.ART_ENTIDAD_UBICACION on m.ZON_ID equals u.ZON_ID
                               where u.ENT_ID == EscuelaId
                               select new Basica
                               {
                                   Value = d.ZON_NOMBRE,
                                   Nombre = m.ZON_NOMBRE
                               }).SingleOrDefault();


                }
                return objdpto;

            }
            catch (Exception)
            {
                throw;
            }

        }

        public static CoordenadasDTO ObtenerCoordenadasMunicipio(string codigoMunicipio)
        {

            CoordenadasDTO objdpto;
            try
            {
                using (var context = new SIPAEntities())
                {

                    objdpto = (from m in context.BAS_ZONAS_GEOGRAFICAS
                               where m.ZON_ID == codigoMunicipio
                               select new CoordenadasDTO
                               {
                                   Latitud = m.ZON_LATITUD.ToString() ?? "0", 
                                   Longitud = m.ZON_LONGITUD.ToString() ?? "0"
                               }).SingleOrDefault();


                }
                return objdpto;

            }
            catch (Exception)
            {
                throw;
            }

        }

        public static string obtenerNombreDepartamento(string codDpto)
        {

            string nombre;
            try
            {
                using (var context = new SIPAEntities())
                {

                    nombre = (from z in context.BAS_ZONAS_GEOGRAFICAS
                              where z.ZON_PADRE_ID == null
                              where  z.ZON_ID == codDpto
                              select z).FirstOrDefault().ZON_NOMBRE;

                               
                }
                return nombre;

            }
            catch (Exception)
            {
                throw;
            }

        }

        public static string obtenerNombreMunicipio(string codMun)
        {

            string nombre = null;
            try
            {
                using (var context = new SIPAEntities())
                {

                    nombre = (from z in context.BAS_ZONAS_GEOGRAFICAS
                                    where  z.ZON_ID == codMun
                                    select z).FirstOrDefault().ZON_NOMBRE;


                }


            }
            catch (Exception)
            {
                nombre = null;

            }
            return nombre;

        }

        public static string ObtenerNombreEscuela(decimal? EscuelaId)
        {

            string nombre = null;
            try
            {
                using (var context = new SIPAEntities())
                {

                    nombre = (from z in context.ART_ENTIDADES_ARTES
                              where z.ENT_ID == EscuelaId
                              select z).FirstOrDefault().ENT_NOMBRE;


                }


            }
            catch (Exception)
            {
                nombre = null;

            }
            return nombre;

        }

        public static string ObtenerNombreEstado(int intEstadoId)
        {

            string nombre = null;
            try
            {
                using (var context = new SIPAEntities())
                {

                    nombre = (from z in context.ART_MUSICA_ESTADOS
                              where z.Id == intEstadoId
                              select z).FirstOrDefault().Nombre;


                }


            }
            catch (Exception)
            {
                nombre = null;

            }
            return nombre;

        }

        #endregion

        #region Personas
        public static List<Basica> ConsultaTipoDocumentos()
        {
            List<Basica> listTipoDocumento;
            List<int> listadopermitidos = new List<int>();

            try
            {
                listadopermitidos.Add(2);
                listadopermitidos.Add(5);
                listadopermitidos.Add(6);
                //listadopermitidos.Add(11);
                //listadopermitidos.Add(12);
                //listadopermitidos.Add(13);

                using (var context = new SIPAEntities())
                {

                    listTipoDocumento = (from z in context.BAS_TIPOS_DOCUMENTOS_IDENTIDAD
                                         join l in listadopermitidos on z.DOC_ID equals l
                                         select new Basica
                                         {
                                             Value = z.DOC_ID.ToString(),
                                             Nombre = z.DOC_NOMBRE
                                         }).ToList();


                }
                return listTipoDocumento;

            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Musica
        public static List<Parametro> ConsultarPracticasMusicales()
        {
            List<Parametro> listBasica = new List<Parametro>();
            try
            {
                using (var context = new SIPAEntities())
                {
                    var VarParametros = context.ART_ME_ART_MUSICA_PRACTICA_MUSICAL_ObtenerTodos().ToList();

                    foreach (var item in VarParametros)
                    {
                        Parametro objParametro = new Parametro();
                        objParametro.Id = item.ART_MUS_PRAC_MUS_ID;
                        objParametro.Nombre = item.ART_MUS_PRAC_MUS_DESCRIPCION;
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

        public static List<Parametro> ConsultarPracticasFormacionDocentes()
        {
            List<Parametro> listBasica = new List<Parametro>();
            try
            {
                using (var context = new SIPAEntities())
                {
                    var VarParametros = context.ART_MUSICA_FORMACION_DOCENTES.ToList();

                    foreach (var item in VarParametros)
                    {
                        Parametro objParametro = new Parametro();
                        objParametro.Id = item.Id;
                        objParametro.Nombre = item.Nombre;
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

        public static List<Parametro> ConsultarPracticasMusicalesPNMC(decimal EscuelaID)
        {
            List<Parametro> listBasica = new List<Parametro>();
            try
            {
                using (var context = new SIPAEntities())
                {
                    var VarParametros = context.ART_MUSICA_PRACTICAS_PNMC.Where(x => x.EscuelaId == EscuelaID).ToList();

                    foreach (var item in VarParametros)
                    {
                        Parametro objParametro = new Parametro();
                        objParametro.Id = item.PracticaMusicalId;
                        objParametro.Nombre = "";
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

        public static List<ART_ME_ART_MUSICA_PRACTICAMUSICAL_ObtenerPorENT_ID_Result> ConsultarPracticaMusicalSeleccionada(decimal EntId)
        {
            List<ART_ME_ART_MUSICA_PRACTICAMUSICAL_ObtenerPorENT_ID_Result> resultado = new List<ART_ME_ART_MUSICA_PRACTICAMUSICAL_ObtenerPorENT_ID_Result>();
            try
            {
                using (var context = new SIPAEntities())
                {
                    resultado = context.ART_ME_ART_MUSICA_PRACTICAMUSICAL_ObtenerPorENT_ID(EntId).ToList();

                }
                return resultado;

            }
            catch (Exception)
            {
                throw;
            }
        }



        public static List<Parametro> ConsultarDocumentos()
        {
            List<Parametro> listBasica = new List<Parametro>();
            try
            {
                using (var context = new SIPAEntities())
                {
                    var VarParametros = context.ART_ME_ART_MUSICA_TIPO_DOCUMENTO_CREACION_ObtenerTodos().ToList();

                    foreach (var item in VarParametros)
                    {
                        Parametro objParametro = new Parametro();
                        objParametro.Id = Convert.ToDecimal(item.ART_MUS_TIP_DOC_CRE_ID);
                        objParametro.Nombre = item.ART_MUS_TIP_DOC_CRE_DESCRPICION;
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
        #endregion

        #region Estados

        public static EstadoDTO ObtenerEstadoMensaje(int estadoId)
        {
            var registro = new EstadoDTO();
            try
            {
                using (var context = new SIPAEntities())
                {
                    var parametro = context.ART_MUSICA_ESTADOS.Where(x => x.Id == estadoId).FirstOrDefault();

                    if (parametro != null)
                    {
                        registro.EstadoId = parametro.Id;
                        registro.Nombre = parametro.Nombre;
                        registro.Mensaje = parametro.Mensaje;
                    }

                }
                return registro;

            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

    }
}
