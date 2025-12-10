using DevExpress.Xpo;
using SM.Aplicacion.Escuelas;
using SM.LibreriaComun.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using WebSImus.Models;

namespace WebSImus.Translator
{
    public class TranslatorEscuelas
    {
        public static List<EscuelaConsultaModel> ConsultarEscuelasPorEstado(int EstadoId)
        {
            var model = new List<EscuelaConsultaModel>();
            var result = new List<EscuelaNuevoDatosDTO>();
            result = EscuelasLogica.ConsultarEscuelasPorEstado(EstadoId);


            foreach (var item in result)
            {
                var datos = new EscuelaConsultaModel();

                datos.Estado = item.Estado;
                datos.Departamento = item.Departamento;
                datos.EscuelaId = item.ENT_ID;
                datos.FechaActualizacion = item.ENT_FECHA_ACTUALIZACION.ToString("dd/MM/yyyy");
                datos.FechaCreacion = item.ENT_FECHA_DILIGENCIAMIENTO.ToString("dd/MM/yyyy");
                datos.Municipio = item.Municipio;
                datos.NombreEscuela = item.ENT_NOMBRE;
                datos.Naturaleza = item.Naturaleza;
                datos.Tipo = item.Tipo;
                model.Add(datos);
            }

            return model;
        }

        public static List<EscuelaConsultaModel> ConsultarEscuelasPorAdmUsuarios(decimal AdmUsuario)
        {
            var model = new List<EscuelaConsultaModel>();
            var result = new List<EscuelaNuevoDatosDTO>();
            result = EscuelasLogica.ConsultarEscuelasPorAdmUsuarios(AdmUsuario);


            foreach (var item in result)
            {
                var datos = new EscuelaConsultaModel();

                datos.Estado = item.Estado;
                datos.Departamento = item.Departamento;
                datos.EscuelaId = item.ENT_ID;
                datos.FechaActualizacion = item.ENT_FECHA_ACTUALIZACION.ToString("dd/MM/yyyy");
                datos.FechaCreacion = item.ENT_FECHA_DILIGENCIAMIENTO.ToString("dd/MM/yyyy");
                datos.Municipio = item.Municipio;
                datos.NombreEscuela = item.ENT_NOMBRE;
                datos.Naturaleza = item.Naturaleza;
                datos.Tipo = item.Tipo;
                model.Add(datos);
            }




            return model;
        }
        public static Escuelas CargarDatosBasicos(decimal EscuelaId)
        {
            Escuelas model = new Escuelas();
            EscuelaDTO datos = EscuelasLogica.ConsultarDatosBasicosPorId(EscuelaId);

            if (datos != null)
            {
                if ((datos.ENT_ANO_CONSTITUCION != null))
                    model.AnoValue = datos.ENT_ANO_CONSTITUCION.ToString();

                if (!String.IsNullOrEmpty(datos.ENT_CARGO_CONTACTO))
                    model.Cargo = datos.ENT_CARGO_CONTACTO.Trim();

                if (!String.IsNullOrEmpty(datos.ENT_CONTACTO_CORREO))
                    model.CorreoElectronico = datos.ENT_CONTACTO_CORREO.Trim();

                if (!String.IsNullOrEmpty(datos.ENT_CORREO_ELECTRONICO_ENTIDAD))
                    model.CorreoElectronicoEscuela = datos.ENT_CORREO_ELECTRONICO_ENTIDAD.Trim();

                if (!String.IsNullOrEmpty(datos.ZON_PADRE_ID))
                    model.DepartamentoSelector = datos.ZON_PADRE_ID;


                if (!String.IsNullOrEmpty(datos.ENT_DIRECCION))
                    model.Direccion = datos.ENT_DIRECCION;

                if (!String.IsNullOrEmpty(datos.Latitud))
                    model.Latitud = datos.Latitud;

                if (!String.IsNullOrEmpty(datos.Longitud))
                    model.Longitud = datos.Longitud;


                if (!String.IsNullOrEmpty(datos.ENT_ESTADO))
                {
                    if (datos.ENT_ESTADO == "N")
                        model.Estado = 2;
                    else if (datos.ENT_ESTADO == "E")
                        model.Estado = 1;
                    else if (datos.ENT_ESTADO == "P")
                        model.Estado = 1;


                }

                if (datos.ENT_FECHA_ACTUALIZACION != null)
                    model.FechaActualizacion = (DateTime)datos.ENT_FECHA_ACTUALIZACION;

                model.EscuelaId = datos.ENT_ID ?? 0;
                if (!String.IsNullOrEmpty(datos.ENT_FAX))
                    model.Fax = datos.ENT_FAX.Trim();


                if (!String.IsNullOrEmpty(datos.ZON_ID))
                    model.MunicipioSelector = datos.ZON_ID;

                if (!String.IsNullOrEmpty(datos.ENT_NIT))
                    model.Nit = datos.ENT_NIT;

                if (!String.IsNullOrEmpty(datos.ENT_NOMBRE_CONTACTO))
                    model.NombreContacto = datos.ENT_NOMBRE_CONTACTO.Trim();

                if (!String.IsNullOrEmpty(datos.ENT_NOMBRE))
                    model.NombreEscuela = datos.ENT_NOMBRE.Trim();

                if (!String.IsNullOrEmpty(datos.ENT_RESENA))
                    model.Resena = datos.ENT_RESENA.Trim();

                if (!String.IsNullOrEmpty(datos.ENT_PAGINA_WEB))
                    model.SitioWeb = datos.ENT_PAGINA_WEB.Trim();


                if (!String.IsNullOrEmpty(datos.ENT_TELEFONOS))
                    model.Telefono = datos.ENT_TELEFONOS.Trim();


                if (!String.IsNullOrEmpty(datos.ENT_TELEFONO))
                    model.TelefonoEscuela = datos.ENT_TELEFONO.Trim();

                if (!String.IsNullOrEmpty(datos.ZON_NOMBRE))
                {
                    model.Municipio = datos.ZON_NOMBRE.Trim();
                    if (!String.IsNullOrEmpty(datos.ZON_NOMBRE_PADRE))
                        model.Departamento = datos.ZON_NOMBRE_PADRE.Trim();
                    model.ZonaGeografica = model.Municipio + ", " + model.Departamento;
                }

                model.UsuarioId = datos.USU_ID;

                model.imagen = datos.Imagen;


            }
            model.Area = EscuelasLogica.ConsultarAreaPorId(EscuelaId);

            return model;
        }
        public static Institucionalidad CargarInstitucionalidad(decimal EscuelaId)
        {
            Institucionalidad model = new Institucionalidad();
            InstitucionalidadDTO datos = InstitucionalidadLogica.ConsultarInstitucionalidadPorId(EscuelaId);

            model.ActividadMusical = 2;
            model.CreadaLegalmente = 2;
            model.ApoyoAdministrativo = 2;
            model.DependeInstitucion = 2;
            model.FormacionMusical = 2;
            //model.PlanDesarrollo = 2;

            if (datos != null)
            {
                if (datos.ENT_INCLUYE_ACTIVIDAD_MUSICAL)
                    model.ActividadMusical = 1;

                if (!String.IsNullOrEmpty(datos.ENT_NOMBRES_DIRECTOR))
                    model.NombreDirector = datos.ENT_NOMBRES_DIRECTOR.Trim();

                if (!String.IsNullOrEmpty(datos.ENT_CELULAR_DIRECTOR))
                    model.TelefonoCelularDirector = datos.ENT_CELULAR_DIRECTOR.Trim();

                if (!String.IsNullOrEmpty(datos.ENT_CORREO_ELECTRONICO_DIRECTOR))
                    model.CorreoElectronicoDirector = datos.ENT_CORREO_ELECTRONICO_DIRECTOR.Trim();

                if (!String.IsNullOrEmpty(datos.ENT_ENTIDAD_CONTRATANTE))
                    model.EntidadContratanteDirector = datos.ENT_ENTIDAD_CONTRATANTE.Trim();


                if (datos.ENT_CREADA_LEGALMENTE)
                    model.CreadaLegalmente = 1;

                //if (datos.ENT_PLAN_DESARROLLO == true)
                //    model.PlanDesarrollo = 1;

                if (datos.ENT_CUENTA_APOYO_ADMINISTRATIVO)
                    model.ApoyoAdministrativo = 1;

                if (datos.ENT_FECHA_NACIMIENTO_DIRECTOR != null)
                {
                    DateTime datFecha = (DateTime)datos.ENT_FECHA_NACIMIENTO_DIRECTOR;
                    model.FechaNacimiento = datFecha.ToString("yyyy-MM-dd");
                }
                else
                {

                    model.FechaNacimiento = "";
                }

                if (datos.ENT_CANTIDAD_DOCENTES_HONORARIOS == 0)
                    model.ContratoHonorario = "";
                else
                    model.ContratoHonorario = datos.ENT_CANTIDAD_DOCENTES_HONORARIOS.ToString();
                if (datos.ENT_CANTIDAD_DOCENTES_NOMINA == 0)
                    model.ContratoLaboral = "";
                else
                    model.ContratoLaboral = datos.ENT_CANTIDAD_DOCENTES_NOMINA.ToString();
                if (datos.ENT_CANTIDAD_DOCENTES_VOLUNTARIOS == 0)
                    model.Voluntarios = "";
                else
                    model.Voluntarios = datos.ENT_CANTIDAD_DOCENTES_VOLUNTARIOS.ToString();
                if (datos.ENT_CANTIDAD_DOCENTES_PRESTACION_SERVICIOS == 0)
                    model.OrdenPrestacionServicios = "";
                else
                    model.OrdenPrestacionServicios = datos.ENT_CANTIDAD_DOCENTES_PRESTACION_SERVICIOS.ToString();
                if (datos.ENT_CANTIDAD_APOYO_HONORARIOS == 0)
                    model.ContratoHonorariosAdministrativo = "";
                else
                    model.ContratoHonorariosAdministrativo = datos.ENT_CANTIDAD_APOYO_HONORARIOS.ToString();

                if (datos.ENT_CANTIDAD_APOYO_NOMINA == 0)
                    model.ContratoLaboralAdministrativo = "";
                else
                    model.ContratoLaboralAdministrativo = datos.ENT_CANTIDAD_APOYO_NOMINA.ToString();
                if (datos.ENT_CANTIDAD_APOYO_VOLUNTARIO == 0)
                    model.VoluntariosAdministrativo = "";
                else
                    model.VoluntariosAdministrativo = datos.ENT_CANTIDAD_APOYO_VOLUNTARIO.ToString();
                if (datos.ENT_CANTIDAD_APOYO_PRESTACION_SERVICIOS == 0)
                    model.OrdenPrestacionServiciosAdministrativo = "";
                else
                    model.OrdenPrestacionServiciosAdministrativo = datos.ENT_CANTIDAD_APOYO_PRESTACION_SERVICIOS.ToString();
                if (datos.ENT_CANTIDAD_DOCENTES_NIVEL_PRIMARIA == 0)
                    model.Primaria = "";
                else
                    model.Primaria = datos.ENT_CANTIDAD_DOCENTES_NIVEL_PRIMARIA.ToString();
                if (datos.ENT_CANTIDAD_DOCENTES_NIVEL_SECUNDARIA == 0)
                    model.Secundaria = "";
                else
                    model.Secundaria = datos.ENT_CANTIDAD_DOCENTES_NIVEL_SECUNDARIA.ToString();
                if (datos.ENT_CANTIDAD_DOCENTES_NIVEL_TECNICO == 0)
                    model.Tecnico = "";
                else
                    model.Tecnico = datos.ENT_CANTIDAD_DOCENTES_NIVEL_TECNICO.ToString();
                if (datos.ENT_CANTIDAD_DOCENTES_UNIVERSITARIO == 0)
                    model.UniversitariaSinTitulo = "";
                else
                    model.UniversitariaSinTitulo = datos.ENT_CANTIDAD_DOCENTES_UNIVERSITARIO.ToString();
                if (datos.ENT_CANTIDAD_DOCENTES_PREGRADO_MUSICA == 0)
                    model.PregradoMusica = "";
                else
                    model.PregradoMusica = datos.ENT_CANTIDAD_DOCENTES_PREGRADO_MUSICA.ToString();
                if (datos.ENT_CANTIDAD_DOCENTES_PREGRADO_OTRA_AREA == 0)
                    model.PregradoOtrasAreas = "";
                else
                    model.PregradoOtrasAreas = datos.ENT_CANTIDAD_DOCENTES_PREGRADO_OTRA_AREA.ToString();
                if (datos.ENT_CANTIDAD_DOCENTES_POSTGRADO == 0)
                    model.PostGrado = "";
                else
                    model.PostGrado = datos.ENT_CANTIDAD_DOCENTES_POSTGRADO.ToString();


                model.Naturaleza = datos.Naturaleza;
                model.NivelEntidad = datos.NivelEntidad.ToString();
                model.NombreEntidad = datos.EntidadDepende;
                model.Regimen = datos.Regimen;
                model.SubRegimen = datos.SubRegimen;
                model.DependeInstitucion = datos.DependeEntidad;
                model.TipoVinculacionDirector = datos.ENT_TIPO_VINCULACION_DIRECTOR.ToString();
                model.TotalDocentesNivelEducativo = datos.ENT_CANTIDAD_TOTAL_DOCENTES_NIVEL_EDUCATIVO;
                model.TotalDocentesVinculados = datos.ENT_CANTIDAD_TOTAL_DOCENTES_VINCULADOS;
                model.TipoDocumentoCreacion = datos.TipoDocumentoCreacion;
                model.NumeroDocumentoCreacion = datos.NumeroDocumentoCreacion;
                model.FechaDocumentoCreacion = datos.FechaDocumentoCreacion;

                if (datos.DocumentoId > 0)
                {
                    model.DocumentoId = datos.DocumentoId;
                    model.documentoArchivo = TranslatorDocumento.ConsultaDocumento(datos.DocumentoId);
                }
                else
                    model.DocumentoId = 0;

            }

            return model;
        }

        public static Institucionalidad CargarInstitucionalidadFicha(decimal EscuelaId)
        {
            Institucionalidad model = new Institucionalidad();
            InstitucionalidadDTO datos = InstitucionalidadLogica.ConsultarInstitucionalidadPorId(EscuelaId);

            model.ActividadMusical = 2;
            model.CreadaLegalmente = 2;
            model.ApoyoAdministrativo = 2;
            model.DependeInstitucion = 2;
            model.FormacionMusical = 2;

            if (datos != null)
            {
                if (datos.ENT_INCLUYE_ACTIVIDAD_MUSICAL)
                    model.ActividadMusical = 1;

                if (!String.IsNullOrEmpty(datos.ENT_NOMBRES_DIRECTOR))
                    model.NombreDirector = datos.ENT_NOMBRES_DIRECTOR.Trim();

                if (!String.IsNullOrEmpty(datos.ENT_CELULAR_DIRECTOR))
                    model.TelefonoCelularDirector = datos.ENT_CELULAR_DIRECTOR.Trim();

                if (!String.IsNullOrEmpty(datos.ENT_CORREO_ELECTRONICO_DIRECTOR))
                    model.CorreoElectronicoDirector = datos.ENT_CORREO_ELECTRONICO_DIRECTOR.Trim();

                if (!String.IsNullOrEmpty(datos.ENT_ENTIDAD_CONTRATANTE))
                    model.EntidadContratanteDirector = datos.ENT_ENTIDAD_CONTRATANTE.Trim();


                if (datos.ENT_CREADA_LEGALMENTE)
                    model.CreadaLegalmente = 1;


                if (datos.ENT_CUENTA_APOYO_ADMINISTRATIVO)
                    model.ApoyoAdministrativo = 1;

                if (datos.ENT_FECHA_NACIMIENTO_DIRECTOR != null)
                {
                    DateTime datFecha = (DateTime)datos.ENT_FECHA_NACIMIENTO_DIRECTOR;
                    model.FechaNacimiento = datFecha.ToString("yyyy-MM-dd");
                }
                else
                {

                    model.FechaNacimiento = "";
                }

                model.ContratoHonorario = datos.ENT_CANTIDAD_DOCENTES_HONORARIOS.ToString();
                model.Voluntarios = datos.ENT_CANTIDAD_DOCENTES_VOLUNTARIOS.ToString();
                model.ContratoLaboral = datos.ENT_CANTIDAD_DOCENTES_NOMINA.ToString();
                model.OrdenPrestacionServicios = datos.ENT_CANTIDAD_DOCENTES_PRESTACION_SERVICIOS.ToString();
                model.ContratoHonorariosAdministrativo = datos.ENT_CANTIDAD_APOYO_HONORARIOS.ToString();
                model.ContratoLaboralAdministrativo = datos.ENT_CANTIDAD_APOYO_NOMINA.ToString();
                model.VoluntariosAdministrativo = datos.ENT_CANTIDAD_APOYO_VOLUNTARIO.ToString();
                model.OrdenPrestacionServiciosAdministrativo = datos.ENT_CANTIDAD_APOYO_PRESTACION_SERVICIOS.ToString();
                model.Primaria = datos.ENT_CANTIDAD_DOCENTES_NIVEL_PRIMARIA.ToString();
                model.Secundaria = datos.ENT_CANTIDAD_DOCENTES_NIVEL_SECUNDARIA.ToString();
                model.Tecnico = datos.ENT_CANTIDAD_DOCENTES_NIVEL_TECNICO.ToString();
                model.UniversitariaSinTitulo = datos.ENT_CANTIDAD_DOCENTES_UNIVERSITARIO.ToString();
                model.PregradoMusica = datos.ENT_CANTIDAD_DOCENTES_PREGRADO_MUSICA.ToString();
                model.PregradoOtrasAreas = datos.ENT_CANTIDAD_DOCENTES_PREGRADO_OTRA_AREA.ToString();
                model.PostGrado = datos.ENT_CANTIDAD_DOCENTES_POSTGRADO.ToString();



                model.Naturaleza = datos.Naturaleza;
                model.NivelEntidad = datos.NivelEntidad.ToString();
                model.NombreEntidad = datos.EntidadDepende;
                model.Regimen = datos.Regimen;
                model.SubRegimen = datos.SubRegimen;
                model.DependeInstitucion = datos.DependeEntidad;
                model.TipoVinculacionDirector = datos.ENT_TIPO_VINCULACION_DIRECTOR.ToString();
                model.TotalDocentesNivelEducativo = datos.ENT_CANTIDAD_TOTAL_DOCENTES_NIVEL_EDUCATIVO;
                model.TotalDocentesVinculados = datos.ENT_CANTIDAD_TOTAL_DOCENTES_VINCULADOS;


            }

            return model;
        }

        public static InfraestructuraModel CargarInfraestructura(decimal EscuelaId)
        {
            InfraestructuraModel model = new InfraestructuraModel();
            InfraestructuraDTO datos = InfraestructuraLogica.ConsultarInfraestructuraPorId(EscuelaId);

            model.EsSedeAsignada = 2;
            model.EsAdecuadaAcusticamente = 2;
            model.TieneAccesoInternet = 2;
            model.TieneMaterialPedagogico = 2;
            model.TieneInternet = "NO";
            model.AdecuacionAcustica = "NO";


            if (datos != null)
            {
                if (datos.ENT_CANTIDAD_ATRILES == 0)
                    model.CantidadAtriles = "";
                else
                    model.CantidadAtriles = datos.ENT_CANTIDAD_ATRILES.ToString();
                if (datos.ENT_CANTIDAD_INSTR_CUERDAS_PULSADAS == 0)
                    model.CantidadCuerdasPulsadas = "";
                else
                    model.CantidadCuerdasPulsadas = datos.ENT_CANTIDAD_INSTR_CUERDAS_PULSADAS.ToString();
                if (datos.ENT_CANTIDAD_INSTR_CUERDAS_SINFONICAS == 0)
                    model.CantidadCuerdasSinfonicas = "";
                else
                    model.CantidadCuerdasSinfonicas = datos.ENT_CANTIDAD_INSTR_CUERDAS_SINFONICAS.ToString();
                if (datos.ENT_CANTIDAD_ESTANTERIA == 0)
                    model.CantidadEstanterias = "";
                else
                    model.CantidadEstanterias = datos.ENT_CANTIDAD_ESTANTERIA.ToString();
                if (datos.ENT_CANTIDAD_INSTR_OTROS == 0)
                    model.CantidadOtros = "";
                else
                    model.CantidadOtros = datos.ENT_CANTIDAD_INSTR_OTROS.ToString();
                if (datos.ENT_CANTIDAD_INSTR_PERCUSION_MENOR == 0)
                    model.CantidadPercusionMenor = "";
                else
                    model.CantidadPercusionMenor = datos.ENT_CANTIDAD_INSTR_PERCUSION_MENOR.ToString();
                if (datos.ENT_CANTIDAD_INSTR_PERCUSION_SINFONICA == 0)
                    model.CantidadPercusionSinfonica = "";
                else
                    model.CantidadPercusionSinfonica = datos.ENT_CANTIDAD_INSTR_PERCUSION_SINFONICA.ToString();
                if (datos.ENT_CANTIDAD_SILLAS == 0)
                    model.CantidadSillas = "";
                else
                    model.CantidadSillas = datos.ENT_CANTIDAD_SILLAS.ToString();
                if (datos.ENT_CANTIDAD_TABLEROS == 0)
                    model.CantidadTableros = "";
                else
                    model.CantidadTableros = datos.ENT_CANTIDAD_TABLEROS.ToString();
                if (datos.ENT_CANTIDAD_TITULOS_BIBLIOGRAFICOS == 0)
                    model.CantidadTitulosBibliograficos = "";
                else
                    model.CantidadTitulosBibliograficos = datos.ENT_CANTIDAD_TITULOS_BIBLIOGRAFICOS.ToString();
                if (datos.ENT_CANTIDAD_INSTR_VIENTOS_MADERAS == 0)
                    model.CantidadVientosMadera = "";
                else
                    model.CantidadVientosMadera = datos.ENT_CANTIDAD_INSTR_VIENTOS_MADERAS.ToString();
                if (datos.ENT_CANTIDAD_INSTR_VIENTOS_METALES == 0)
                    model.CantidadVientosMetales = "";
                else
                    model.CantidadVientosMetales = datos.ENT_CANTIDAD_INSTR_VIENTOS_METALES.ToString();


                if (datos.ENT_SEDE_PORCENTAJE_ADEC_ACUSTIC == 0)
                    model.PorcentajeAdecuacion = "";
                else
                    model.PorcentajeAdecuacion = datos.ENT_SEDE_PORCENTAJE_ADEC_ACUSTIC.ToString();
                model.Espacio = datos.ENT_ESPACIO.ToString();
                model.TotalInstrumentos = datos.ENT_CANTIDAD_INSTR_TOTAL;

                if (!String.IsNullOrEmpty(datos.ENT_SEDE_LUGAR))
                    model.Sede = datos.ENT_SEDE_LUGAR.Trim();

                if (datos.ENT_SINOACCESO_INTERNET == "S")
                {
                    model.TieneInternet = "SI";
                    model.TieneAccesoInternet = 1;
                }

                if (datos.ENT_SEDE_ADEC_ACUSTIC)
                {
                    model.AdecuacionAcustica = "SI";
                    model.EsAdecuadaAcusticamente = 1;
                }

                if (datos.ENT_MATERIAL_PEDAGOGICO)
                    model.TieneMaterialPedagogico = 1;


                if (datos.ENT_SEDE_ASIGNADA_SOPORTE_ESCRITO)
                    model.EsSedeAsignada = 1;

            }

            return model;
        }

        public static InfraestructuraModel CargarInfraestructuraFicha(decimal EscuelaId)
        {
            InfraestructuraModel model = new InfraestructuraModel();
            InfraestructuraDTO datos = InfraestructuraLogica.ConsultarInfraestructuraPorId(EscuelaId);

            model.EsSedeAsignada = 2;
            model.EsAdecuadaAcusticamente = 2;
            model.TieneAccesoInternet = 2;
            model.TieneMaterialPedagogico = 2;
            model.TieneInternet = "NO";
            model.AdecuacionAcustica = "NO";


            if (datos != null)
            {
                model.CantidadAtriles = datos.ENT_CANTIDAD_ATRILES.ToString();
                model.CantidadCuerdasPulsadas = datos.ENT_CANTIDAD_INSTR_CUERDAS_PULSADAS.ToString();
                model.CantidadCuerdasSinfonicas = datos.ENT_CANTIDAD_INSTR_CUERDAS_SINFONICAS.ToString();
                model.CantidadEstanterias = datos.ENT_CANTIDAD_ESTANTERIA.ToString();
                model.CantidadOtros = datos.ENT_CANTIDAD_INSTR_OTROS.ToString();
                model.CantidadPercusionMenor = datos.ENT_CANTIDAD_INSTR_PERCUSION_MENOR.ToString();
                model.CantidadPercusionSinfonica = datos.ENT_CANTIDAD_INSTR_PERCUSION_SINFONICA.ToString();
                model.CantidadSillas = datos.ENT_CANTIDAD_SILLAS.ToString();
                model.CantidadTableros = datos.ENT_CANTIDAD_TABLEROS.ToString();
                model.CantidadTitulosBibliograficos = datos.ENT_CANTIDAD_TITULOS_BIBLIOGRAFICOS.ToString();
                model.CantidadVientosMadera = datos.ENT_CANTIDAD_INSTR_VIENTOS_MADERAS.ToString();
                model.CantidadVientosMetales = datos.ENT_CANTIDAD_INSTR_VIENTOS_METALES.ToString();
                model.PorcentajeAdecuacion = datos.ENT_SEDE_PORCENTAJE_ADEC_ACUSTIC.ToString();


                model.Espacio = datos.ENT_ESPACIO.ToString();
                model.TotalInstrumentos = datos.ENT_CANTIDAD_INSTR_TOTAL;

                if (!String.IsNullOrEmpty(datos.ENT_SEDE_LUGAR))
                    model.Sede = datos.ENT_SEDE_LUGAR.Trim();

                if (datos.ENT_SINOACCESO_INTERNET == "S")
                {
                    model.TieneInternet = "SI";
                    model.TieneAccesoInternet = 1;
                }

                if (datos.ENT_SEDE_ADEC_ACUSTIC)
                {
                    model.AdecuacionAcustica = "SI";
                    model.EsAdecuadaAcusticamente = 1;
                }

                if (datos.ENT_MATERIAL_PEDAGOGICO)
                    model.TieneMaterialPedagogico = 1;


                if (datos.ENT_SEDE_ASIGNADA_SOPORTE_ESCRITO)
                    model.EsSedeAsignada = 1;

            }

            return model;
        }

        public static ParticipacionModel CargarParticipacion(decimal EscuelaId)
        {
            ParticipacionModel model = new ParticipacionModel();
            ParticipacionDTO datos = ParticipacionLogica.ConsultarParticipacionPorId(EscuelaId);

            model.TieneOrganizacionComunitaria = 2;
            model.TieneProyectosMusica = 2;


            if (datos != null)
            {
                if (datos.ENT_CANTIDAD_ALUMNOS_AFRO == 0)
                    model.CantidadAfrocolombiana = "";
                else
                    model.CantidadAfrocolombiana = datos.ENT_CANTIDAD_ALUMNOS_AFRO.ToString();
                if (datos.ENT_CANTIDAD_ALUMNOS_DESPLAZADOS == 0)
                    model.CantidadDesplazados = "";
                else
                    model.CantidadDesplazados = datos.ENT_CANTIDAD_ALUMNOS_DESPLAZADOS.ToString();
                if (datos.ENT_CANTIDAD_ALUMNOS_DISCAPACITADOS == 0)
                    model.CantidadDicapacitados = "";
                else
                    model.CantidadDicapacitados = datos.ENT_CANTIDAD_ALUMNOS_DISCAPACITADOS.ToString();
                if (datos.ENT_CANTIDAD_ALUMNOS_MASCULINO == 0)
                    model.CantidadHombres = "";
                else
                    model.CantidadHombres = datos.ENT_CANTIDAD_ALUMNOS_MASCULINO.ToString();

                if (datos.ENT_CANTIDAD_ALUMNOS_INDIGENAS == 0)
                    model.CantidadIndigenas = "";
                else
                    model.CantidadIndigenas = datos.ENT_CANTIDAD_ALUMNOS_INDIGENAS.ToString();
                if (datos.ENT_CANTIDAD_ALUMNOS_FEMENINO == 0)
                    model.CantidadMujeres = "";
                else
                    model.CantidadMujeres = datos.ENT_CANTIDAD_ALUMNOS_FEMENINO.ToString();

                //desdes aaqui
                if (datos.ENT_CANTIDAD_ALUMNOS_OTROS == 0)
                    model.CantidadEtniaOtros = "";
                else
                    model.CantidadEtniaOtros = datos.ENT_CANTIDAD_ALUMNOS_OTROS.ToString();
                if (datos.ENT_CANTIDAD_ALUMNOS_MENOR_6 == 0)
                    model.CantidadPrimeraInfancia = "";
                else
                    model.CantidadPrimeraInfancia = datos.ENT_CANTIDAD_ALUMNOS_MENOR_6.ToString();
                if (datos.ENT_CANTIDAD_ALUMNOS_RAIZALES == 0)
                    model.CantidadRaizales = "";
                else
                    model.CantidadRaizales = datos.ENT_CANTIDAD_ALUMNOS_RAIZALES.ToString();
                if (datos.ENT_CANTIDAD_ALUMNOS_REDUNIDOS == 0)
                    model.CantidadRedUnidos = "";
                else
                    model.CantidadRedUnidos = datos.ENT_CANTIDAD_ALUMNOS_REDUNIDOS.ToString();
                if (datos.ENT_CANTIDAD_ALUMNOS_CUPOS == 0)
                    model.CantidadCupos = "";
                else
                    model.CantidadCupos = datos.ENT_CANTIDAD_ALUMNOS_CUPOS.ToString();
                if (datos.ENT_CANTIDAD_ALUMNOS_ROM == 0)
                    model.CantidadRom = "";
                else
                    model.CantidadRom = datos.ENT_CANTIDAD_ALUMNOS_ROM.ToString();
                if (datos.ENT_CANTIDAD_ALUMNOS_RURAL == 0)
                    model.CantidadRural = "";
                else
                    model.CantidadRural = datos.ENT_CANTIDAD_ALUMNOS_RURAL.ToString();
                if (datos.ENT_CANTIDAD_ALUMNOS_URBANA == 0)
                    model.CantidadUrbana = "";
                else
                    model.CantidadUrbana = datos.ENT_CANTIDAD_ALUMNOS_URBANA.ToString();
                if (datos.ENT_CANTIDAD_ALUMNOS_ENTRE_12_18 == 0)
                    model.CantidaEntre12y18 = "";
                else
                    model.CantidaEntre12y18 = datos.ENT_CANTIDAD_ALUMNOS_ENTRE_12_18.ToString();
                if (datos.ENT_CANTIDAD_ALUMNOS_ENTRE_19_25 == 0)
                    model.CantidaEntre19y26 = "";
                else
                    model.CantidaEntre19y26 = datos.ENT_CANTIDAD_ALUMNOS_ENTRE_19_25.ToString();
                if (datos.ENT_CANTIDAD_ALUMNOS_MAYOR_26 == 0)
                    model.CantidaEntre27y60 = "";
                else
                    model.CantidaEntre27y60 = datos.ENT_CANTIDAD_ALUMNOS_MAYOR_26.ToString();
                if (datos.ENT_CANTIDAD_ALUMNOS_ENTRE_7_11 == 0)
                    model.CantidaEntre6y11 = "";
                else
                    model.CantidaEntre6y11 = datos.ENT_CANTIDAD_ALUMNOS_ENTRE_7_11.ToString();
                if (datos.ENT_CANTIDAD_ALUMNOS_MAYOR_60 == 0)
                    model.CantidadMayores60 = "";
                else
                    model.CantidadMayores60 = datos.ENT_CANTIDAD_ALUMNOS_MAYOR_60.ToString();
                if (datos.ENT_INTEGRANTES_ORGANIZACION == 0)
                    model.NumeroIntegrantes = "";
                else
                    model.NumeroIntegrantes = datos.ENT_INTEGRANTES_ORGANIZACION.ToString();


                model.TotalAlumnosArea = datos.ENT_CANTIDAD_TOTAL_ALUMNOS_AREA;
                model.TotalAlumnosEspeciales = datos.ENT_CANTIDAD_TOTAL_ALUMNOS_ESPECIALES;
                model.TotalAlumnosEtnia = datos.ENT_CANTIDAD_TOTAL_ALUMNOS_ETNIA;
                model.TotalAlumnosSexo = datos.ENT_CANTIDAD_TOTAL_ALUMNOS_GENERO;
                model.TotalAlumnosEdad = datos.ENT_CANTITDAD_TOTAL_ALUMNOS_EDAD;


                if (!String.IsNullOrEmpty(datos.ENT_CORREO_ELECTRONICO_PRESIDENTE_ORGANIZACION))
                    model.CorreoElectronicoParticipacion = datos.ENT_CORREO_ELECTRONICO_PRESIDENTE_ORGANIZACION.Trim();

                if (!String.IsNullOrEmpty(datos.ENT_NOMBRE_PRESIDENTE_ORGANIZACION))
                    model.NombrePresidente = datos.ENT_NOMBRE_PRESIDENTE_ORGANIZACION.Trim();

                if (!String.IsNullOrEmpty(datos.ENT_NOMBRE_ORGANIZACION))
                    model.OrganizacionComunitaria = datos.ENT_NOMBRE_ORGANIZACION.Trim();

                if (!String.IsNullOrEmpty(datos.ENT_TELEFONO_CELULAR_PRESIDENTE_ORGANIZACION))
                    model.TelefonoCelular = datos.ENT_TELEFONO_CELULAR_PRESIDENTE_ORGANIZACION.Trim();

                if (!String.IsNullOrEmpty(datos.ENT_TELEFONO_FIJO_PRESIDENTE_ORGANIZACION))
                    model.TelefonoFijo = datos.ENT_TELEFONO_FIJO_PRESIDENTE_ORGANIZACION.Trim();

                if (datos.ENT_ORGANIZACION_COMUNITARIA)
                    model.TieneOrganizacionComunitaria = 1;

                if (datos.ENT_ORGANIZACION_COMUNITARIA_PROYECTO_ENTORNO_ESCUELA)
                    model.TieneProyectosMusica = 1;
                model.TipoOrganizacionComunitaria = datos.ORGANIZACION_COMUNITARIA_ID.ToString();

            }

            return model;
        }

        public static FormacionModel CargarFormacion(decimal EscuelaId)
        {
            FormacionModel model = new FormacionModel();
            FormacionDTO datos = FormacionLogica.ConsultarFormacionPorId(EscuelaId);

            model.TieneProgramasPorEscrito = 2;
            model.TieneTalleresIndependientes = 2;


            if (datos != null)
            {
                if (datos.BASICO_DURACION_PROMEDIO_MESES == 0)
                    model.DuracionBasico = "";
                else
                    model.DuracionBasico = datos.BASICO_DURACION_PROMEDIO_MESES.ToString();
                if (datos.CURSO_DURACION_PROCURSO_SEMANA == 0)
                    model.DuracionCursos = "";
                else
                    model.DuracionCursos = datos.CURSO_DURACION_PROCURSO_SEMANA.ToString();
                if (datos.INICIACION_DURACION_PROMEDIO_MESES == 0)
                    model.DuracionInicio = "";
                else
                    model.DuracionInicio = datos.INICIACION_DURACION_PROMEDIO_MESES.ToString();
                if (datos.MEDIO_DURACION_PROMEDIO_MESES == 0)
                    model.DuracionMedio = "";
                else
                    model.DuracionMedio = datos.MEDIO_DURACION_PROMEDIO_MESES.ToString();
                if (datos.PEDAGOGIAS_DURACION_PROPEDAGOGIAS_SEMANA == 0)
                    model.DuracionPedagogias = "";
                else
                    model.DuracionPedagogias = datos.PEDAGOGIAS_DURACION_PROPEDAGOGIAS_SEMANA.ToString();

                if (datos.BASICO_INTENSIDAD_HORAS_SEMANAL == 0)
                    model.HorasBasico = "";
                else
                    model.HorasBasico = datos.BASICO_INTENSIDAD_HORAS_SEMANAL.ToString();
                if (datos.CURSO_INTENSIDAD_HORAS_SEMANAL == 0)
                    model.HorasCursos = "";
                else
                    model.HorasCursos = datos.CURSO_INTENSIDAD_HORAS_SEMANAL.ToString();
                if (datos.INICIACION_INTENSIDAD_HORAS_SEMANAL == 0)
                    model.HorasInicio = "";
                else
                    model.HorasInicio = datos.INICIACION_INTENSIDAD_HORAS_SEMANAL.ToString();
                if (datos.MEDIO_INTENSIDAD_HORAS_SEMANAL == 0)
                    model.HorasMedio = "";
                else
                    model.HorasMedio = datos.MEDIO_INTENSIDAD_HORAS_SEMANAL.ToString();
                if (datos.PEDAGOGIAS_INTENSIDAD_HORAS_SEMANAL == 0)
                    model.HorasPedagogias = "";
                else
                    model.HorasPedagogias = datos.PEDAGOGIAS_INTENSIDAD_HORAS_SEMANAL.ToString();
                if (!String.IsNullOrEmpty(datos.INICIACION_OBSERVACIONES))
                    model.ObservacionesNiveles = datos.INICIACION_OBSERVACIONES.Trim();
                if (!String.IsNullOrEmpty(datos.CURSO_OBSERVACIONES))
                    model.ObservacionesTalleres = datos.CURSO_OBSERVACIONES.Trim();

                if (datos.TOTALPOBLACIONBASICO == 0)
                    model.PoblacionBasico = "";
                else
                    model.PoblacionBasico = datos.TOTALPOBLACIONBASICO.ToString();

                if (datos.TOTALPOBLACIONCURSO == 0)
                    model.PoblacionCursos = "";
                else
                    model.PoblacionCursos = datos.TOTALPOBLACIONCURSO.ToString();

                if (datos.TOTALPOBLACIONINICACION == 0)
                    model.PoblacionInicio = "";
                else
                    model.PoblacionInicio = datos.TOTALPOBLACIONINICACION.ToString();

                if (datos.TOTALPOBLACIONMEDIO == 0)
                    model.PoblacionMedio = "";
                else
                    model.PoblacionMedio = datos.TOTALPOBLACIONMEDIO.ToString();

                if (datos.TOTALPOBLACIONPEDAGOGIAS == 0)
                    model.PoblacionMedio = "";
                else
                    model.PoblacionPedagogias = datos.TOTALPOBLACIONPEDAGOGIAS.ToString();

                if (!String.IsNullOrEmpty(datos.ENT_PROCESOS_FORMACION))
                    model.ProcesosFormacion = datos.ENT_PROCESOS_FORMACION.Trim();


                if (datos.ENT_PROGRAMAS_FORMULADOS_ESCRITO)
                    model.TieneProgramasPorEscrito = 1;

                if (datos.ENT_TALLERES_INDEPENDIENTES)
                    model.TieneTalleresIndependientes = 1;


            }

            return model;
        }


        public static FormacionModelNuevo TranslatorFormacionDataDTOFormacionModelNuevo(FormacionDatosDTO datos)
        {
            FormacionModelNuevo model = new FormacionModelNuevo();


            model.TieneProgramasPorEscrito = 2;
            model.TieneTalleresIndependientes = 2;


            if (datos != null)
            {

                if (!String.IsNullOrEmpty(datos.ENT_PROCESOS_FORMACION))
                    model.ProcesosFormacion = datos.ENT_PROCESOS_FORMACION.Trim();


                if (datos.ENT_PROGRAMAS_FORMULADOS_ESCRITO)
                    model.TieneProgramasPorEscrito = 1;

                if (datos.ENT_TALLERES_INDEPENDIENTES)
                    model.TieneTalleresIndependientes = 1;


            }

            return model;
        }

        public static FormacionModel CargarFormacionFicha(decimal EscuelaId)
        {
            FormacionModel model = new FormacionModel();
            FormacionDTO datos = FormacionLogica.ConsultarFormacionPorId(EscuelaId);

            model.TieneProgramasPorEscrito = 2;
            model.TieneTalleresIndependientes = 2;


            if (datos != null)
            {
                model.DuracionBasico = datos.BASICO_DURACION_PROMEDIO_MESES.ToString();
                model.DuracionCursos = datos.CURSO_DURACION_PROCURSO_SEMANA.ToString();
                model.DuracionInicio = datos.INICIACION_DURACION_PROMEDIO_MESES.ToString();
                model.DuracionMedio = datos.MEDIO_DURACION_PROMEDIO_MESES.ToString();
                model.DuracionPedagogias = datos.PEDAGOGIAS_DURACION_PROPEDAGOGIAS_SEMANA.ToString();
                model.HorasBasico = datos.BASICO_INTENSIDAD_HORAS_SEMANAL.ToString();
                model.HorasCursos = datos.CURSO_INTENSIDAD_HORAS_SEMANAL.ToString();
                model.HorasInicio = datos.INICIACION_INTENSIDAD_HORAS_SEMANAL.ToString();
                model.HorasMedio = datos.MEDIO_INTENSIDAD_HORAS_SEMANAL.ToString();
                model.HorasPedagogias = datos.PEDAGOGIAS_INTENSIDAD_HORAS_SEMANAL.ToString();
                model.PoblacionBasico = datos.TOTALPOBLACIONBASICO.ToString();
                model.PoblacionCursos = datos.TOTALPOBLACIONCURSO.ToString();
                model.PoblacionInicio = datos.TOTALPOBLACIONINICACION.ToString();
                model.PoblacionMedio = datos.TOTALPOBLACIONMEDIO.ToString();
                model.PoblacionPedagogias = datos.TOTALPOBLACIONPEDAGOGIAS.ToString();

                if (!String.IsNullOrEmpty(datos.INICIACION_OBSERVACIONES))
                    model.ObservacionesNiveles = datos.INICIACION_OBSERVACIONES.Trim();
                if (!String.IsNullOrEmpty(datos.CURSO_OBSERVACIONES))
                    model.ObservacionesTalleres = datos.CURSO_OBSERVACIONES.Trim();



                if (!String.IsNullOrEmpty(datos.ENT_PROCESOS_FORMACION))
                    model.ProcesosFormacion = datos.ENT_PROCESOS_FORMACION.Trim();


                if (datos.ENT_PROGRAMAS_FORMULADOS_ESCRITO)
                    model.TieneProgramasPorEscrito = 1;

                if (datos.ENT_TALLERES_INDEPENDIENTES)
                    model.TieneTalleresIndependientes = 1;


            }

            return model;
        }

        public static ProduccionModel CargarProduccion(decimal EscuelaId)
        {
            ProduccionModel model = new ProduccionModel();
            ProduccionDTO datos = ProduccionLogica.ConsultarProduccionPorId(EscuelaId);


            if (datos != null)
            {

                if (datos.ENT_CANTIDAD_AGRUPACIONES_CONFORMADAS_VIGENTES == 0)
                    model.CantidadAgrupaciones = "";
                else
                    model.CantidadAgrupaciones = datos.ENT_CANTIDAD_AGRUPACIONES_CONFORMADAS_VIGENTES.ToString();
                if (datos.ENT_CANTIDAD_PRESENTACIONES_LOCALIDAD_ULTIMO_ANIO == 0)
                    model.CantidadConciertos = "";
                else
                    model.CantidadConciertos = datos.ENT_CANTIDAD_PRESENTACIONES_LOCALIDAD_ULTIMO_ANIO.ToString();
                if (datos.ENT_CANTIDAD_DISCOS_ULTIMO_ANIO == 0)
                    model.CantidadDiscos = "";
                else
                    model.CantidadDiscos = datos.ENT_CANTIDAD_DISCOS_ULTIMO_ANIO.ToString();
                if (datos.ENT_CANTIDAD_GIRAS_INTER_ULTIMO_ANIO == 0)
                    model.CantidadGirasInternacionales = "";
                else
                    model.CantidadGirasInternacionales = datos.ENT_CANTIDAD_GIRAS_INTER_ULTIMO_ANIO.ToString();
                if (datos.ENT_CANTIDAD_GIRAS_ULTIMO_ANIO == 0)
                    model.CantidadGirasNacionales = "";
                else
                    model.CantidadGirasNacionales = datos.ENT_CANTIDAD_GIRAS_ULTIMO_ANIO.ToString();
                if (datos.ENT_CANTIDAD_MATERIAL_DIVULGATIVO_ULTIMO_ANIO == 0)
                    model.CantidadMaterialDivulgativo = "";
                else
                    model.CantidadMaterialDivulgativo = datos.ENT_CANTIDAD_MATERIAL_DIVULGATIVO_ULTIMO_ANIO.ToString();
                if (datos.ENT_CANTIDAD_MATERIAL_APOYO_ULTIMO_ANIO == 0)
                    model.CantidadMaterialPedagogico = "";
                else
                    model.CantidadMaterialPedagogico = datos.ENT_CANTIDAD_MATERIAL_APOYO_ULTIMO_ANIO.ToString();
                if (datos.ENT_CANTIDAD_REPERTORIOS_ULTIMO_ANIO == 0)
                    model.CantidadRepertorios = "";
                else
                    model.CantidadRepertorios = datos.ENT_CANTIDAD_REPERTORIOS_ULTIMO_ANIO.ToString();

            }

            return model;
        }

        public static ProduccionModel CargarProduccionFicha(decimal EscuelaId)
        {
            ProduccionModel model = new ProduccionModel();
            ProduccionDTO datos = ProduccionLogica.ConsultarProduccionPorId(EscuelaId);


            if (datos != null)
            {
                model.CantidadAgrupaciones = datos.ENT_CANTIDAD_AGRUPACIONES_CONFORMADAS_VIGENTES.ToString();
                model.CantidadConciertos = datos.ENT_CANTIDAD_PRESENTACIONES_LOCALIDAD_ULTIMO_ANIO.ToString();
                model.CantidadDiscos = datos.ENT_CANTIDAD_DISCOS_ULTIMO_ANIO.ToString();
                model.CantidadGirasInternacionales = datos.ENT_CANTIDAD_GIRAS_INTER_ULTIMO_ANIO.ToString();
                model.CantidadGirasNacionales = datos.ENT_CANTIDAD_GIRAS_ULTIMO_ANIO.ToString();
                model.CantidadMaterialDivulgativo = datos.ENT_CANTIDAD_MATERIAL_DIVULGATIVO_ULTIMO_ANIO.ToString();
                model.CantidadMaterialPedagogico = datos.ENT_CANTIDAD_MATERIAL_APOYO_ULTIMO_ANIO.ToString();
                model.CantidadRepertorios = datos.ENT_CANTIDAD_REPERTORIOS_ULTIMO_ANIO.ToString();

            }

            return model;
        }

        public static List<VideoModel> ConsultarVideos(decimal EscuelaId)
        {
            var listVideo = new List<VideoModel>();
            var listadoVIdeos = new List<EscuelaVideoDTO>();
            string strClasificacion = "";
            listadoVIdeos = RedesLogica.ConsultarListadoVideos(EscuelaId);
            foreach (var item in listadoVIdeos)
            {
                var datos = new VideoModel();
                if (!string.IsNullOrEmpty(item.clasificacion))
                {
                    strClasificacion = "";
                    switch (item.clasificacion)
                    {
                        case "1":
                            strClasificacion = "Proceso formativo";
                            break;
                        case "2":
                            strClasificacion = "Encuentros";
                            break;
                        case "3":
                            strClasificacion = "Festivales";
                            break;
                        case "4":
                            strClasificacion = "Presentaciones públicas";
                            break;
                        case "5":
                            strClasificacion = "Ensayos";
                            break;
                        case "6":
                            strClasificacion = "Celebra la música";
                            break;
                        case "7":
                            strClasificacion = "Infraestructura";
                            break;

                        case "8":
                            strClasificacion = "Agrupaciones";
                            break;
                        case "9":
                            strClasificacion = "Recolección de fondos";
                            break;

                        case "10":
                            strClasificacion = "Intercambio musicales";
                            break;
                        case "11":
                            strClasificacion = "Jornada de esparcimiento";
                            break;
                        case "12":
                            strClasificacion = "Vídeo institucional";
                            break;
                        default:
                            strClasificacion = "Sin clasificación";
                            break;
                    }
                    //datos.Clasificacion = (WebSImus.Models.RedesSocialesModel.ClasificacionVideoesEnum)Enum.Parse(typeof(WebSImus.Models.RedesSocialesModel.ClasificacionVideoesEnum), item.clasificacion);
                    datos.NuevaClasificacion = strClasificacion;
                }
                datos.Desripcion = item.Descripcion.Trim();
                datos.EscuelaId = item.EscuelaId;
                datos.Id = item.Id;
                datos.url = item.urlvideoYoutube.Trim();
                datos.FechaPublicacion = item.FechaPublicacion;
                listVideo.Add(datos);
            }

            return listVideo;
        }

        public static List<VideoModel> ConsultarVideosFicha(decimal EscuelaId)
        {
            var listVideo = new List<VideoModel>();
            var listadoVIdeos = new List<EscuelaVideoDTO>();
            string strClasificacion = "";
            listadoVIdeos = RedesLogica.ConsultarListadoVideos(EscuelaId);
            foreach (var item in listadoVIdeos)
            {
                var datos = new VideoModel();
                if (!string.IsNullOrEmpty(item.clasificacion))
                {
                    strClasificacion = "";
                    switch (item.clasificacion)
                    {
                        case "1":
                            strClasificacion = "Proceso formativo";
                            break;
                        case "2":
                            strClasificacion = "Encuentros";
                            break;
                        case "3":
                            strClasificacion = "Festivales";
                            break;
                        case "4":
                            strClasificacion = "Presentaciones públicas";
                            break;
                        case "5":
                            strClasificacion = "Ensayos";
                            break;
                        case "6":
                            strClasificacion = "Celebra la música";
                            break;
                        case "7":
                            strClasificacion = "Infraestructura";
                            break;

                        case "8":
                            strClasificacion = "Agrupaciones";
                            break;
                        case "9":
                            strClasificacion = "Recolección de fondos";
                            break;

                        case "10":
                            strClasificacion = "Intercambio musicales";
                            break;
                        case "11":
                            strClasificacion = "Jornada de esparcimiento";
                            break;
                        case "12":
                            strClasificacion = "Vídeo institucional";
                            break;
                        default:
                            strClasificacion = "Sin clasificación";
                            break;
                    }
                    //datos.Clasificacion = (WebSImus.Models.RedesSocialesModel.ClasificacionVideoesEnum)Enum.Parse(typeof(WebSImus.Models.RedesSocialesModel.ClasificacionVideoesEnum), item.clasificacion);
                    datos.NuevaClasificacion = strClasificacion;
                }
                datos.Desripcion = item.Descripcion.Trim();
                datos.EscuelaId = item.EscuelaId;
                datos.Id = item.Id;
                string codigo = ObtenerCodigoVideoYoutube(item.urlvideoYoutube.Trim());
                datos.url = "https://www.youtube.com/embed/" + codigo;
                datos.FechaPublicacion = item.FechaPublicacion;
                listVideo.Add(datos);
            }

            return listVideo;
        }
        private static string ObtenerCodigoVideoYoutube(string youTubeUrl)
        {
            //Setup the RegEx Match and give it 
            Match regexMatch = Regex.Match(youTubeUrl, "^[^v]+v=(.{11}).*",
                               RegexOptions.IgnoreCase);
            if (regexMatch.Success)
            {
                return regexMatch.Groups[1].Value;
            }
            return youTubeUrl;
        }
        public static RedesSocialesModel CargarDatosRedes(decimal EscuelaId)
        {
            var result = new RedesSocialesModel();
            RedesDTO model = RedesLogica.ConsultarRedesPorId(EscuelaId);

            if (model != null)
            {
                if (!String.IsNullOrEmpty(model.CanalYoutube))
                    result.CanalYoutube = model.CanalYoutube.Trim();
                if (!String.IsNullOrEmpty(model.DescripcionFlicker))
                    result.DescripcionFlicker = model.DescripcionFlicker.Trim();

                if (!String.IsNullOrEmpty(model.Facebook))
                    result.Facebook = model.Facebook.Trim();
                if (!String.IsNullOrEmpty(model.GaleriaFlicker))
                    result.GaleriaFlicker = model.GaleriaFlicker.Trim();
                if (!String.IsNullOrEmpty(model.Twitter))
                    result.Twitter = model.Twitter.Trim();

                result.GaleriaId = model.GaleriaId;
                result.EscuelaId = model.EscuelaId;

                //foreach (var item in model.listVIdeo)
                //{
                //    var datos = new VideoModel();
                //    datos.Clasificacion = (WebSImus.Models.RedesSocialesModel.ClasificacionVideoesEnum)Enum.Parse(typeof(WebSImus.Models.RedesSocialesModel.ClasificacionVideoesEnum), item.clasificacion);
                //    datos.Desripcion = item.Descripcion.Trim();
                //    datos.EscuelaId = item.EscuelaId;
                //    datos.Id = item.Id;
                //    datos.url = item.urlvideoYoutube.Trim();
                //    datos.FechaPublicacion = item.FechaPublicacion;
                //    listVideo.Add(datos);
                //}

                //result.listVideo = listVideo;
            }


            return result;
        }
    }
}