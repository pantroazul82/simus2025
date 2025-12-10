using System;
using System.Collections.Generic;
using System.Linq;
using SM.SIPA;
using SM.Datos.DTO.Festivales;
using System.Data.Entity;
using System.Globalization;

namespace SM.Datos.Festivales
{
    /// <summary>
    /// Servicio de acceso a datos para versiones de festivales
    /// </summary>
    public class FestivalVersionServicio
    {
        /// <summary>
        /// Obtiene una versión de festival por su ID
        /// </summary>
        public static FestivalVersionDTO ObtenerPorId(int id)
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    var version = context.ART_MUS_FESTIVALES_VERSION
                        .Include(v => v.ART_MUS_FESTIVALES)
                        .Include(v => v.ART_MUS_TIPOINGRESOXVERSION.Select(t => t.ART_MUS_TIPOINGRESO))
                        .Include(v => v.ART_MUS_MATERIALMULTIMEDIA)
                        .Include(v => v.ART_MUS_FESTIVALES_MODALIDADES_PARTICIPACIONXVERSION.Select(m => m.ART_MUS_FESTIVALES_MODALIDADES_PARTICIPACION))
                        .Include(v => v.ART_MUS_FESTIVALES_EXPRESIONXVERSION.Select(e => e.ART_MUS_FESTIVALES_EXPRESIONES_ARTISTICAS))
                        .FirstOrDefault(v => v.ID == id);

                    if (version == null)
                        return null;

                    return MapearVersionADTO(version);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Obtiene todas las versiones de un festival específico
        /// </summary>
        public static List<FestivalVersionDTO> ObtenerPorFestivalId(int festivalId)
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    var versiones = context.ART_MUS_FESTIVALES_VERSION
                        .Include(v => v.ART_MUS_FESTIVALES)
                        .Include(v => v.ART_MUS_TIPOINGRESOXVERSION.Select(t => t.ART_MUS_TIPOINGRESO))
                        .Include(v => v.ART_MUS_MATERIALMULTIMEDIA)
                        .Include(v => v.ART_MUS_FESTIVALES_MODALIDADES_PARTICIPACIONXVERSION.Select(m => m.ART_MUS_FESTIVALES_MODALIDADES_PARTICIPACION))
                        .Include(v => v.ART_MUS_FESTIVALES_EXPRESIONXVERSION.Select(e => e.ART_MUS_FESTIVALES_EXPRESIONES_ARTISTICAS))
                        .Where(v => v.ID_FESTIVAL == festivalId)
                        .OrderByDescending(v => v.VERSION_FESTIVAL)
                        .ToList();

                    return versiones.Select(v => MapearVersionADTO(v)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Crea una nueva versión de festival
        /// </summary>
        public static int Crear(FestivalVersionCrearDTO dto, string nombreUsuario, int usuarioId, string ip)
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    // Crear entidad de versión
                    var version = new ART_MUS_FESTIVALES_VERSION
                    {
                        ID_FESTIVAL = dto.IdFestival,
                        VERSION_FESTIVAL = dto.NumeroVersion,
                        NOMBRE_VERSION = dto.NombreVersion,
                        DESCRIPCION_VERSION = dto.Descripcion,
                        FECHA_INICIO = dto.FechaInicio.HasValue ? dto.FechaInicio.Value.ToString("yyyy-MM-dd") : null,
                        FECHA_FIN = dto.FechaFin.HasValue ? dto.FechaFin.Value.ToString("yyyy-MM-dd") : null,
                        ID_TIPOLOGIA = dto.IdTipologia,
                        OTRA_TIPOLOGIA = string.IsNullOrWhiteSpace(dto.OtraTipologia) ? null : dto.OtraTipologia.Trim(),
                        OTRA_MODALIDAD_PARTICIPACION = string.IsNullOrWhiteSpace(dto.OtraModalidadParticipacion) ? null : dto.OtraModalidadParticipacion.Trim(),
                        OTRA_EXPRESION_ARTISTICA = string.IsNullOrWhiteSpace(dto.OtraExpresionArtistica) ? null : dto.OtraExpresionArtistica.Trim(),
                        ID_FUENTE_FINANCIACION = dto.IdFuenteFinanciacion,
                        ID_FUENTE_FINANCIACION_SECUNDARIA = dto.IdFuenteFinanciacionSecundaria,
                        OTRA_FUENTE_FINANCIACION_PRIMARIA = string.IsNullOrWhiteSpace(dto.OtraFuenteFinanciacionPrimaria) ? null : dto.OtraFuenteFinanciacionPrimaria.Trim(),
                        OTRA_FUENTE_FINANCIACION_SECUNDARIA = string.IsNullOrWhiteSpace(dto.OtraFuenteFinanciacionSecundaria) ? null : dto.OtraFuenteFinanciacionSecundaria.Trim(),
                        USO_ESTAMPILLA_PROCULTURA = dto.UsoEstampillaProcultura,
                        
                        // Contacto
                        DIRECTOR = string.IsNullOrWhiteSpace(dto.Director) ? null : dto.Director.Trim(),
                        PERTENECE_ORG_COLETIVA = dto.PerteneceOrgColectiva,
                        NOMBRE_ORGANIZACION = string.IsNullOrWhiteSpace(dto.NombreOrganizacion) ? null : dto.NombreOrganizacion.Trim(),
                        ID_TIPO_ORGANIZADOR = dto.IdTipoOrganizador,
                        OTRO_TIPO_ORGANIZADOR = string.IsNullOrWhiteSpace(dto.OtroTipoOrganizador) ? null : dto.OtroTipoOrganizador.Trim(),
                        CORREO_CONTACTO = string.IsNullOrWhiteSpace(dto.CorreoContacto) ? null : dto.CorreoContacto.Trim(),
                        INSTAGRAM = string.IsNullOrWhiteSpace(dto.Instagram) ? null : dto.Instagram.Trim(),
                        FACEBOOK = string.IsNullOrWhiteSpace(dto.Facebook) ? null : dto.Facebook.Trim(),
                        PAGINA_WEB = string.IsNullOrWhiteSpace(dto.PaginaWeb) ? null : dto.PaginaWeb.Trim(),
                        OTRO_ENLACE = string.IsNullOrWhiteSpace(dto.OtroEnlace) ? null : dto.OtroEnlace.Trim(),
                        TELEFONO_CELULAR = string.IsNullOrWhiteSpace(dto.TelefonoCelular) ? null : dto.TelefonoCelular.Trim(),
                        OBSERVACIONES_CONTACTO = string.IsNullOrWhiteSpace(dto.ObservacionesContacto) ? null : dto.ObservacionesContacto.Trim(),
                        
                        // Estado de la versión
                        ID_ESTADO = dto.IdEstado
                    };

                    context.ART_MUS_FESTIVALES_VERSION.Add(version);
                    context.SaveChanges();

                    // Guardar tipos de ingreso
                    if (dto.TiposIngreso != null && dto.TiposIngreso.Any())
                    {
                        foreach (var tipoIngresoId in dto.TiposIngreso)
                        {
                            var tipoIngresoVersion = new ART_MUS_TIPOINGRESOXVERSION
                            {
                                ID_TIPOINGRESO = tipoIngresoId,
                                IDVERSION = version.ID
                            };
                            context.ART_MUS_TIPOINGRESOXVERSION.Add(tipoIngresoVersion);
                        }
                        context.SaveChanges();
                    }

                    // Guardar material multimedia
                    if (dto.MaterialMultimedia != null && dto.MaterialMultimedia.Any())
                    {
                        System.Diagnostics.Debug.WriteLine($"[FestivalVersionServicio.Crear] MaterialMultimedia count: {dto.MaterialMultimedia.Count}");
                        
                        foreach (var material in dto.MaterialMultimedia)
                        {
                            System.Diagnostics.Debug.WriteLine($"[FestivalVersionServicio.Crear] Agregando material: {material.Descripcion} - {material.UrlArchivo}");
                            
                            var multimedia = new ART_MUS_MATERIALMULTIMEDIA
                            {
                                ID_VERSION = version.ID,
                                URL_ARCHIVO = material.UrlArchivo,
                                DESCRIPCION_ARCHIVO = material.Descripcion
                            };
                            context.ART_MUS_MATERIALMULTIMEDIA.Add(multimedia);
                        }
                        context.SaveChanges();
                        System.Diagnostics.Debug.WriteLine($"[FestivalVersionServicio.Crear] Material multimedia guardado correctamente");
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine($"[FestivalVersionServicio.Crear] dto.MaterialMultimedia es NULL o vacío");
                    }

                    // Guardar modalidades de participación
                    if (dto.ModalidadesParticipacion != null && dto.ModalidadesParticipacion.Any())
                    {
                        foreach (var modalidadId in dto.ModalidadesParticipacion.Distinct())
                        {
                            context.ART_MUS_FESTIVALES_MODALIDADES_PARTICIPACIONXVERSION.Add(
                                new ART_MUS_FESTIVALES_MODALIDADES_PARTICIPACIONXVERSION
                                {
                                    ID_VERSION = version.ID,
                                    ID_MODALIDAD = modalidadId
                                });
                        }
                        context.SaveChanges();
                    }

                    // Guardar expresiones artísticas
                    if (dto.ExpresionesArtisticas != null && dto.ExpresionesArtisticas.Any())
                    {
                        foreach (var expresionId in dto.ExpresionesArtisticas.Distinct())
                        {
                            context.ART_MUS_FESTIVALES_EXPRESIONXVERSION.Add(
                                new ART_MUS_FESTIVALES_EXPRESIONXVERSION
                                {
                                    ID_VERSION = version.ID,
                                    ID_EXPRESION_ARTISTICA = expresionId
                                });
                        }
                        context.SaveChanges();
                    }

                    return version.ID;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Actualiza una versión de festival existente
        /// </summary>
        public static void Actualizar(FestivalVersionActualizarDTO dto, string nombreUsuario, int usuarioId, string ip)
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    var version = context.ART_MUS_FESTIVALES_VERSION
                        .Include(v => v.ART_MUS_TIPOINGRESOXVERSION)
                        .Include(v => v.ART_MUS_MATERIALMULTIMEDIA)
                        .Include(v => v.ART_MUS_FESTIVALES_MODALIDADES_PARTICIPACIONXVERSION)
                        .Include(v => v.ART_MUS_FESTIVALES_EXPRESIONXVERSION)
                        .FirstOrDefault(v => v.ID == dto.Id);

                    if (version == null)
                        throw new Exception($"No se encontró la versión con ID {dto.Id}");

                    // Actualizar campos básicos
                    version.VERSION_FESTIVAL = dto.NumeroVersion;
                    version.NOMBRE_VERSION = dto.NombreVersion;
                    version.DESCRIPCION_VERSION = dto.Descripcion;
                    version.FECHA_INICIO = dto.FechaInicio.HasValue ? dto.FechaInicio.Value.ToString("yyyy-MM-dd") : null;
                    version.FECHA_FIN = dto.FechaFin.HasValue ? dto.FechaFin.Value.ToString("yyyy-MM-dd") : null;
                    
                    // Actualizar caracterización
                    version.ID_TIPOLOGIA = dto.IdTipologia;
                    version.OTRA_TIPOLOGIA = string.IsNullOrWhiteSpace(dto.OtraTipologia) ? null : dto.OtraTipologia.Trim();
                    version.OTRA_MODALIDAD_PARTICIPACION = string.IsNullOrWhiteSpace(dto.OtraModalidadParticipacion) ? null : dto.OtraModalidadParticipacion.Trim();
                    version.OTRA_EXPRESION_ARTISTICA = string.IsNullOrWhiteSpace(dto.OtraExpresionArtistica) ? null : dto.OtraExpresionArtistica.Trim();

                    // Actualizar financiación
                    version.ID_FUENTE_FINANCIACION = dto.IdFuenteFinanciacion;
                    version.ID_FUENTE_FINANCIACION_SECUNDARIA = dto.IdFuenteFinanciacionSecundaria;
                    version.OTRA_FUENTE_FINANCIACION_PRIMARIA = string.IsNullOrWhiteSpace(dto.OtraFuenteFinanciacionPrimaria) ? null : dto.OtraFuenteFinanciacionPrimaria.Trim();
                    version.OTRA_FUENTE_FINANCIACION_SECUNDARIA = string.IsNullOrWhiteSpace(dto.OtraFuenteFinanciacionSecundaria) ? null : dto.OtraFuenteFinanciacionSecundaria.Trim();
                    version.USO_ESTAMPILLA_PROCULTURA = dto.UsoEstampillaProcultura;

                    // Actualizar contacto
                    version.DIRECTOR = string.IsNullOrWhiteSpace(dto.Director) ? null : dto.Director.Trim();
                    version.PERTENECE_ORG_COLETIVA = dto.PerteneceOrgColectiva;
                    version.NOMBRE_ORGANIZACION = string.IsNullOrWhiteSpace(dto.NombreOrganizacion) ? null : dto.NombreOrganizacion.Trim();
                    version.ID_TIPO_ORGANIZADOR = dto.IdTipoOrganizador;
                    version.OTRO_TIPO_ORGANIZADOR = string.IsNullOrWhiteSpace(dto.OtroTipoOrganizador) ? null : dto.OtroTipoOrganizador.Trim();
                    version.CORREO_CONTACTO = string.IsNullOrWhiteSpace(dto.CorreoContacto) ? null : dto.CorreoContacto.Trim();
                    version.INSTAGRAM = string.IsNullOrWhiteSpace(dto.Instagram) ? null : dto.Instagram.Trim();
                    version.FACEBOOK = string.IsNullOrWhiteSpace(dto.Facebook) ? null : dto.Facebook.Trim();
                    version.PAGINA_WEB = string.IsNullOrWhiteSpace(dto.PaginaWeb) ? null : dto.PaginaWeb.Trim();
                    version.OTRO_ENLACE = string.IsNullOrWhiteSpace(dto.OtroEnlace) ? null : dto.OtroEnlace.Trim();
                    version.TELEFONO_CELULAR = string.IsNullOrWhiteSpace(dto.TelefonoCelular) ? null : dto.TelefonoCelular.Trim();
                    version.OBSERVACIONES_CONTACTO = string.IsNullOrWhiteSpace(dto.ObservacionesContacto) ? null : dto.ObservacionesContacto.Trim();

                    // Actualizar estado de la versión (solo si se proporciona un valor)
                    if (dto.IdEstado.HasValue)
                    {
                        version.ID_ESTADO = dto.IdEstado;
                    }

                    // Actualizar tipos de ingreso - eliminar existentes y agregar nuevos
                    if (dto.TiposIngreso != null)
                    {
                        // Eliminar tipos de ingreso existentes
                        var tiposExistentes = version.ART_MUS_TIPOINGRESOXVERSION.ToList();
                        foreach (var tipo in tiposExistentes)
                        {
                            context.ART_MUS_TIPOINGRESOXVERSION.Remove(tipo);
                        }

                        // Agregar nuevos tipos de ingreso
                        foreach (var tipoIngresoId in dto.TiposIngreso)
                        {
                            var tipoIngresoVersion = new ART_MUS_TIPOINGRESOXVERSION
                            {
                                ID_TIPOINGRESO = tipoIngresoId,
                                IDVERSION = version.ID
                            };
                            context.ART_MUS_TIPOINGRESOXVERSION.Add(tipoIngresoVersion);
                        }
                    }

                    // Actualizar material multimedia - eliminar existentes y agregar nuevos
                    if (dto.MaterialMultimedia != null)
                    {
                        System.Diagnostics.Debug.WriteLine($"[FestivalVersionServicio.Actualizar] MaterialMultimedia count: {dto.MaterialMultimedia.Count}");
                        
                        // Eliminar material existente
                        var materialExistente = version.ART_MUS_MATERIALMULTIMEDIA.ToList();
                        System.Diagnostics.Debug.WriteLine($"[FestivalVersionServicio.Actualizar] Eliminando {materialExistente.Count} materiales existentes");
                        
                        foreach (var material in materialExistente)
                        {
                            context.ART_MUS_MATERIALMULTIMEDIA.Remove(material);
                        }

                        // Agregar nuevo material
                        foreach (var material in dto.MaterialMultimedia)
                        {
                            System.Diagnostics.Debug.WriteLine($"[FestivalVersionServicio.Actualizar] Agregando material: {material.Descripcion} - {material.UrlArchivo}");
                            
                            var multimedia = new ART_MUS_MATERIALMULTIMEDIA
                            {
                                ID_VERSION = version.ID,
                                URL_ARCHIVO = material.UrlArchivo,
                                DESCRIPCION_ARCHIVO = material.Descripcion
                            };
                            context.ART_MUS_MATERIALMULTIMEDIA.Add(multimedia);
                        }
                        
                        System.Diagnostics.Debug.WriteLine($"[FestivalVersionServicio.Actualizar] Material multimedia agregado, guardando cambios...");
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine($"[FestivalVersionServicio.Actualizar] dto.MaterialMultimedia es NULL");
                    }

                    // Actualizar modalidades de participación
                    if (dto.ModalidadesParticipacion != null)
                    {
                        // Eliminar modalidades existentes
                        var modalidadesExistentes = version.ART_MUS_FESTIVALES_MODALIDADES_PARTICIPACIONXVERSION.ToList();
                        foreach (var modalidad in modalidadesExistentes)
                        {
                            context.ART_MUS_FESTIVALES_MODALIDADES_PARTICIPACIONXVERSION.Remove(modalidad);
                        }

                        // Agregar nuevas modalidades
                        foreach (var modalidadId in dto.ModalidadesParticipacion.Distinct())
                        {
                            context.ART_MUS_FESTIVALES_MODALIDADES_PARTICIPACIONXVERSION.Add(
                                new ART_MUS_FESTIVALES_MODALIDADES_PARTICIPACIONXVERSION
                                {
                                    ID_VERSION = version.ID,
                                    ID_MODALIDAD = modalidadId
                                });
                        }
                    }

                    // Actualizar expresiones artísticas
                    if (dto.ExpresionesArtisticas != null)
                    {
                        // Eliminar expresiones existentes
                        var expresionesExistentes = version.ART_MUS_FESTIVALES_EXPRESIONXVERSION.ToList();
                        foreach (var expresion in expresionesExistentes)
                        {
                            context.ART_MUS_FESTIVALES_EXPRESIONXVERSION.Remove(expresion);
                        }

                        // Agregar nuevas expresiones
                        foreach (var expresionId in dto.ExpresionesArtisticas.Distinct())
                        {
                            context.ART_MUS_FESTIVALES_EXPRESIONXVERSION.Add(
                                new ART_MUS_FESTIVALES_EXPRESIONXVERSION
                                {
                                    ID_VERSION = version.ID,
                                    ID_EXPRESION_ARTISTICA = expresionId
                                });
                        }
                    }

                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Elimina una versión de festival
        /// </summary>
        public static void Eliminar(int id, string nombreUsuario, int usuarioId, string ip)
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    var version = context.ART_MUS_FESTIVALES_VERSION
                        .Include(v => v.ART_MUS_TIPOINGRESOXVERSION)
                        .Include(v => v.ART_MUS_MATERIALMULTIMEDIA)
                        .FirstOrDefault(v => v.ID == id);

                    if (version == null)
                        throw new Exception($"No se encontró la versión con ID {id}");

                    // Eliminar relaciones
                    context.ART_MUS_TIPOINGRESOXVERSION.RemoveRange(version.ART_MUS_TIPOINGRESOXVERSION);
                    context.ART_MUS_MATERIALMULTIMEDIA.RemoveRange(version.ART_MUS_MATERIALMULTIMEDIA);

                    // Eliminar versión
                    context.ART_MUS_FESTIVALES_VERSION.Remove(version);
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Obtiene todos los tipos de ingreso disponibles
        /// </summary>
        public static List<TipoIngresoDTO> ObtenerTiposIngreso()
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    return context.ART_MUS_TIPOINGRESO
                        .Select(t => new TipoIngresoDTO
                        {
                            Id = t.ID,
                            Nombre = t.TIPO_INGRESO
                        })
                        .OrderBy(t => t.Nombre)
                        .ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Obtiene todos los territorios sonoros disponibles
        /// </summary>
        public static List<TerritorioSonoroDTO> ObtenerTerritoriosSonoros()
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    return context.ART_MUS_TERRITORIOS_SONOROS
                        .AsNoTracking()
                        .Select(t => new TerritorioSonoroDTO
                        {
                            Id = t.ID,
                            Nombre = t.TERRITORIOS_SONOROS
                        })
                        .OrderBy(t => t.Nombre)
                        .ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Obtiene todas las tipologías de festivales disponibles
        /// </summary>
        public static List<TipologiaDTO> ObtenerTipologias()
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    return context.ART_MUS_FESTIVALES_TIPOLOGIA
                        .Where(t => t.ACTIVO == 1)
                        .AsNoTracking()
                        .Select(t => new TipologiaDTO
                        {
                            Id = t.ID,
                            Nombre = t.TIPOLOGIA
                        })
                        .OrderBy(t => t.Nombre)
                        .ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Obtiene todas las modalidades de participación disponibles
        /// </summary>
        public static List<ModalidadParticipacionDTO> ObtenerModalidadesParticipacion()
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    return context.ART_MUS_FESTIVALES_MODALIDADES_PARTICIPACION
                        .Where(m => m.ACTIVO == 1)
                        .AsNoTracking()
                        .Select(m => new ModalidadParticipacionDTO
                        {
                            Id = m.ID,
                            Nombre = m.MODALIDAD_PARTICIPACION
                        })
                        .OrderBy(m => m.Nombre)
                        .ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Obtiene todas las expresiones artísticas disponibles
        /// </summary>
        public static List<ExpresionArtisticaDTO> ObtenerExpresionesArtisticas()
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    return context.ART_MUS_FESTIVALES_EXPRESIONES_ARTISTICAS
                        .Where(e => e.ACTIVO == true)
                        .AsNoTracking()
                        .Select(e => new ExpresionArtisticaDTO
                        {
                            Id = e.ID,
                            Nombre = e.EXPRESION_ARTISTICA
                        })
                        .OrderBy(e => e.Nombre)
                        .ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Obtiene las modalidades de participación asociadas a una versión específica
        /// </summary>
        public static List<int> ObtenerModalidadesParticipacionPorVersion(int versionId)
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    return context.ART_MUS_FESTIVALES_MODALIDADES_PARTICIPACIONXVERSION
                        .AsNoTracking()
                        .Where(x => x.ID_VERSION == versionId)
                        .Select(x => x.ID_MODALIDAD)
                        .ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Obtiene las expresiones artísticas asociadas a una versión específica
        /// </summary>
        public static List<int> ObtenerExpresionesArtisticasPorVersion(int versionId)
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    return context.ART_MUS_FESTIVALES_EXPRESIONXVERSION
                        .AsNoTracking()
                        .Where(x => x.ID_VERSION == versionId)
                        .Select(x => x.ID_EXPRESION_ARTISTICA)
                        .ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Guarda las modalidades de participación asociadas a una versión
        /// </summary>
        public static void GuardarModalidadesParticipacion(int versionId, List<int> modalidadesIds, string otraModalidad = null)
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    // Actualizar campo OTRA_MODALIDAD_PARTICIPACION si corresponde
                    var version = context.ART_MUS_FESTIVALES_VERSION.FirstOrDefault(v => v.ID == versionId);
                    if (version != null)
                    {
                        version.OTRA_MODALIDAD_PARTICIPACION = string.IsNullOrWhiteSpace(otraModalidad) ? null : otraModalidad.Trim();
                    }

                    // Eliminar modalidades existentes de esta versión
                    var existentes = context.ART_MUS_FESTIVALES_MODALIDADES_PARTICIPACIONXVERSION
                        .Where(x => x.ID_VERSION == versionId)
                        .ToList();
                    
                    context.ART_MUS_FESTIVALES_MODALIDADES_PARTICIPACIONXVERSION.RemoveRange(existentes);

                    // Insertar nuevas modalidades
                    if (modalidadesIds != null && modalidadesIds.Any())
                    {
                        foreach (var modalidadId in modalidadesIds.Distinct())
                        {
                            context.ART_MUS_FESTIVALES_MODALIDADES_PARTICIPACIONXVERSION.Add(
                                new ART_MUS_FESTIVALES_MODALIDADES_PARTICIPACIONXVERSION
                                {
                                    ID_VERSION = versionId,
                                    ID_MODALIDAD = modalidadId
                                });
                        }
                    }

                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Guarda las expresiones artísticas asociadas a una versión
        /// </summary>
        public static void GuardarExpresionesArtisticas(int versionId, List<int> expresionesIds, string otraExpresion = null)
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    // Actualizar campo OTRA_EXPRESION_ARTISTICA si corresponde
                    var version = context.ART_MUS_FESTIVALES_VERSION.FirstOrDefault(v => v.ID == versionId);
                    if (version != null)
                    {
                        version.OTRA_EXPRESION_ARTISTICA = string.IsNullOrWhiteSpace(otraExpresion) ? null : otraExpresion.Trim();
                    }

                    // Eliminar expresiones existentes de esta versión
                    var existentes = context.ART_MUS_FESTIVALES_EXPRESIONXVERSION
                        .Where(x => x.ID_VERSION == versionId)
                        .ToList();
                    
                    context.ART_MUS_FESTIVALES_EXPRESIONXVERSION.RemoveRange(existentes);

                    // Insertar nuevas expresiones
                    if (expresionesIds != null && expresionesIds.Any())
                    {
                        foreach (var expresionId in expresionesIds.Distinct())
                        {
                            context.ART_MUS_FESTIVALES_EXPRESIONXVERSION.Add(
                                new ART_MUS_FESTIVALES_EXPRESIONXVERSION
                                {
                                    ID_VERSION = versionId,
                                    ID_EXPRESION_ARTISTICA = expresionId
                                });
                        }
                    }

                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Obtiene los territorios sonoros asociados a una versión específica
        /// </summary>
        public static List<int> ObtenerTerritoriosSonorosPorVersion(int versionId)
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    return context.ART_MUS_TERRITORIOS_SONOROSXVERSION
                        .AsNoTracking()
                        .Where(x => x.ID_VERSION == versionId && x.ID_TERRITORIOS_SONOROS.HasValue)
                        .Select(x => x.ID_TERRITORIOS_SONOROS.Value)
                        .ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Guarda los territorios sonoros asociados a una versión
        /// </summary>
        public static void GuardarTerritoriosSonoros(int versionId, List<int> territoriosIds, string practicasMusicales = null)
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    // Obtener la versión para actualizar el campo de prácticas musicales
                    var version = context.ART_MUS_FESTIVALES_VERSION.FirstOrDefault(v => v.ID == versionId);
                    if (version != null && practicasMusicales != null)
                    {
                        version.PRACTICAS_MUSICALES_CONGREGA = practicasMusicales;
                    }

                    // Eliminar territorios sonoros existentes de esta versión
                    var existentes = context.ART_MUS_TERRITORIOS_SONOROSXVERSION
                        .Where(x => x.ID_VERSION == versionId)
                        .ToList();
                    
                    context.ART_MUS_TERRITORIOS_SONOROSXVERSION.RemoveRange(existentes);

                    // Insertar nuevos territorios sonoros
                    if (territoriosIds != null && territoriosIds.Any())
                    {
                        foreach (var territorioId in territoriosIds.Distinct())
                        {
                            context.ART_MUS_TERRITORIOS_SONOROSXVERSION.Add(new ART_MUS_TERRITORIOS_SONOROSXVERSION
                            {
                                ID_VERSION = versionId,
                                ID_TERRITORIOS_SONOROS = territorioId
                            });
                        }
                    }

                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Mapea una entidad ART_MUS_FESTIVALES_VERSION a FestivalVersionDTO
        /// </summary>
        private static FestivalVersionDTO MapearVersionADTO(ART_MUS_FESTIVALES_VERSION version)
        {
            if (version == null)
                return null;

            return new FestivalVersionDTO
            {
                Id = version.ID,
                IdFestival = version.ID_FESTIVAL ?? 0,
                NombreFestival = version.ART_MUS_FESTIVALES?.NOMBRE_FESTIVAL,
                NumeroVersion = version.VERSION_FESTIVAL,
                NombreVersion = version.NOMBRE_VERSION,
                Descripcion = version.DESCRIPCION_VERSION,
                PracticasMusicales = version.PRACTICAS_MUSICALES_CONGREGA,
                FechaInicio = ParsearFecha(version.FECHA_INICIO),
                FechaFin = ParsearFecha(version.FECHA_FIN),
                TiposIngreso = version.ART_MUS_TIPOINGRESOXVERSION?
                    .Select(t => new TipoIngresoDTO
                    {
                        Id = t.ART_MUS_TIPOINGRESO?.ID ?? 0,
                        Nombre = t.ART_MUS_TIPOINGRESO?.TIPO_INGRESO
                    })
                    .ToList() ?? new List<TipoIngresoDTO>(),
                MaterialMultimedia = version.ART_MUS_MATERIALMULTIMEDIA?
                    .Select(m => new MaterialMultimediaDTO
                    {
                        Id = m.ID,
                        UrlArchivo = m.URL_ARCHIVO,
                        Descripcion = m.DESCRIPCION_ARCHIVO
                    })
                    .ToList() ?? new List<MaterialMultimediaDTO>(),
                
                // Caracterización
                IdTipologia = version.ID_TIPOLOGIA,
                OtraTipologia = version.OTRA_TIPOLOGIA,
                ModalidadesParticipacion = version.ART_MUS_FESTIVALES_MODALIDADES_PARTICIPACIONXVERSION?
                    .Select(m => new ModalidadParticipacionDTO
                    {
                        Id = m.ART_MUS_FESTIVALES_MODALIDADES_PARTICIPACION?.ID ?? 0,
                        Nombre = m.ART_MUS_FESTIVALES_MODALIDADES_PARTICIPACION?.MODALIDAD_PARTICIPACION
                    })
                    .ToList() ?? new List<ModalidadParticipacionDTO>(),
                OtraModalidadParticipacion = version.OTRA_MODALIDAD_PARTICIPACION,
                ExpresionesArtisticas = version.ART_MUS_FESTIVALES_EXPRESIONXVERSION?
                    .Select(e => new ExpresionArtisticaDTO
                    {
                        Id = e.ART_MUS_FESTIVALES_EXPRESIONES_ARTISTICAS?.ID ?? 0,
                        Nombre = e.ART_MUS_FESTIVALES_EXPRESIONES_ARTISTICAS?.EXPRESION_ARTISTICA
                    })
                    .ToList() ?? new List<ExpresionArtisticaDTO>(),
                OtraExpresionArtistica = version.OTRA_EXPRESION_ARTISTICA,

                // Financiación
                IdFuenteFinanciacion = version.ID_FUENTE_FINANCIACION,
                IdFuenteFinanciacionSecundaria = version.ID_FUENTE_FINANCIACION_SECUNDARIA,
                OtraFuenteFinanciacionPrimaria = version.OTRA_FUENTE_FINANCIACION_PRIMARIA,
                OtraFuenteFinanciacionSecundaria = version.OTRA_FUENTE_FINANCIACION_SECUNDARIA,
                UsoEstampillaProcultura = version.USO_ESTAMPILLA_PROCULTURA,

                // Contacto
                Director = version.DIRECTOR,
                PerteneceOrgColectiva = version.PERTENECE_ORG_COLETIVA,
                NombreOrganizacion = version.NOMBRE_ORGANIZACION,
                IdTipoOrganizador = version.ID_TIPO_ORGANIZADOR,
                OtroTipoOrganizador = version.OTRO_TIPO_ORGANIZADOR,
                CorreoContacto = version.CORREO_CONTACTO,
                Instagram = version.INSTAGRAM,
                Facebook = version.FACEBOOK,
                PaginaWeb = version.PAGINA_WEB,
                OtroEnlace = version.OTRO_ENLACE,
                TelefonoCelular = version.TELEFONO_CELULAR,
                ObservacionesContacto = version.OBSERVACIONES_CONTACTO
            };
        }

        /// <summary>
        /// Parsea una fecha en formato string a DateTime nullable
        /// </summary>
        private static DateTime? ParsearFecha(string fecha)
        {
            if (string.IsNullOrWhiteSpace(fecha))
                return null;

            DateTime resultado;
            // Intentar parsear en formato yyyy-MM-dd
            if (DateTime.TryParseExact(fecha, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out resultado))
                return resultado;

            // Intentar parsear en otros formatos comunes
            if (DateTime.TryParse(fecha, out resultado))
                return resultado;

            return null;
        }
    }
}
