using SM.Datos.AuditoriaData;
using SM.Datos.Basicas;
using SM.Datos.DTO.Festivales;
using SM.Datos.DTO.Servicios;
using SM.SIPA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace SM.Datos.Servicios
{
    public class FestivalServicio
    {
        #region Consulta
        
        /// <summary>
        /// Obtiene todos los festivales registrados por un usuario específico
        /// </summary>
        public static List<FestivalListadoDTO> ObtenerPorUsuarioId(int usuarioId)
        {
            try
            {
                // Log para depuración
                EscribirLog($"ObtenerPorUsuarioId - Consultando festivales para usuarioId: {usuarioId}");
                
                using (var context = new SIPAEntities())
                {
                    // Usar SQL directo para evitar problemas con el esquema
                    var sql = @"
                        SELECT 
                            id,
                            NOMBRE_FESTIVAL,
                            FECHA_ENVIO,
                            ID_ESTADO
                        FROM ART_MUS_FESTIVALES
                        WHERE creado_por = @p0
                        ORDER BY FECHA_ENVIO DESC";
                    
                    EscribirLog($"ObtenerPorUsuarioId - Ejecutando consulta SQL directa...");
                    
                    var datos = context.Database.SqlQuery<FestivalRawDTO>(sql, usuarioId).ToList();

                    EscribirLog($"ObtenerPorUsuarioId - Registros encontrados: {datos.Count}");

                    var resultado = new List<FestivalListadoDTO>();

                    foreach (var f in datos)
                    {
                        resultado.Add(new FestivalListadoDTO
                        {
                            Id = f.id,
                            Nombre = f.NOMBRE_FESTIVAL ?? "",
                            FechaCreacion = f.FECHA_ENVIO ?? DateTime.MinValue,
                            FechaSolicitud = f.FECHA_ENVIO ?? DateTime.MinValue,
                            FechaSolicitudAclaraciones = f.FECHA_ENVIO,
                            FechaReciboAclaraciones = null,
                            Estado = f.ID_ESTADO.HasValue ? ObtenerNombreEstadoFestival(f.ID_ESTADO.Value) : "Sin estado"
                        });
                    }

                    EscribirLog($"ObtenerPorUsuarioId - DTOs generados: {resultado.Count}");
                    return resultado;
                }
            }
            catch (Exception ex)
            {
                EscribirLog($"ObtenerPorUsuarioId - ERROR: {ex.Message}\n{ex.StackTrace}");
                
                // Capturar inner exception
                var innerEx = ex.InnerException;
                while (innerEx != null)
                {
                    EscribirLog($"INNER EXCEPTION: {innerEx.Message}\n{innerEx.StackTrace}");
                    innerEx = innerEx.InnerException;
                }
                
                throw;
            }
        }
        
        // Clase auxiliar para mapear resultado SQL
        private class FestivalRawDTO
        {
            public int id { get; set; }
            public string NOMBRE_FESTIVAL { get; set; }
            public DateTime? FECHA_ENVIO { get; set; }
            public int? ID_ESTADO { get; set; }
        }

        private static void EscribirLog(string mensaje)
        {
            try
            {
                string rutaLog = @"C:\Users\Admin\Documents\Proyecto Carlos\Simus_Web\FestivalServicio.log";
                string lineaLog = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {mensaje}\n";
                File.AppendAllText(rutaLog, lineaLog);
            }
            catch { /* Ignorar errores de log */ }
        }

        /// <summary>
        /// Obtiene todos los festivales (para administradores)
        /// </summary>
        public static List<FestivalListadoDTO> ObtenerTodos()
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    var festivales = context.ART_MUS_FESTIVALES
                        .OrderByDescending(f => f.FECHA_ENVIO)
                        .ToList();

                    var resultado = new List<FestivalListadoDTO>();

                    foreach (var f in festivales)
                    {
                        resultado.Add(new FestivalListadoDTO
                        {
                            Id = f.id,
                            Nombre = f.NOMBRE_FESTIVAL ?? "",
                            FechaCreacion = f.FECHA_ENVIO ?? DateTime.MinValue,
                            FechaSolicitud = f.FECHA_ENVIO ?? DateTime.MinValue,
                            FechaSolicitudAclaraciones = f.FECHA_ENVIO,
                            FechaReciboAclaraciones = null,
                            Estado = f.ID_ESTADO.HasValue ? ObtenerNombreEstadoFestival(f.ID_ESTADO.Value) : "Sin estado"
                        });
                    }

                    return resultado;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Obtiene un festival por ID con todos sus detalles
        /// </summary>
        public static FestivalDetalleDTO ObtenerPorId(int festivalId)
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    var sql = @"
                        SELECT 
                            id,
                            creado_por,
                            NOMBRE_FESTIVAL,
                            VERSIONES_REALIZADAS,
                            FECHA_ULTIMA_VERSION,
                            DESCRIPCION_FESTIVAL,
                            CORREO_CONTACTO,
                            INSTAGRAM,
                            FACEBOOK,
                            PAGINA_WEB,
                            OTRO_ENLACE,
                            CELULAR,
                            OBSERVACIONES_CONTACTO,
                            FECHA_ENVIO,
                            ID_ESTADO
                        FROM ART_MUS_FESTIVALES
                        WHERE id = @p0";
                    
                    var datos = context.Database.SqlQuery<FestivalCompletoDT>(sql, festivalId).FirstOrDefault();
                    
                    if (datos == null)
                        return null;
                    
                    return new FestivalDetalleDTO
                    {
                        Id = datos.id,
                        Nombre = datos.NOMBRE_FESTIVAL ?? "",
                        VersionesRealizadas = datos.VERSIONES_REALIZADAS,
                        FechaUltimaVersion = datos.FECHA_ULTIMA_VERSION,
                        Descripcion = datos.DESCRIPCION_FESTIVAL ?? "",
                        CorreoContacto = datos.CORREO_CONTACTO ?? "",
                        Instagram = datos.INSTAGRAM ?? "",
                        Facebook = datos.FACEBOOK ?? "",
                        PaginaWeb = datos.PAGINA_WEB ?? "",
                        OtroEnlace = datos.OTRO_ENLACE ?? "",
                        Celular = datos.CELULAR ?? "",
                        ObservacionesContacto = datos.OBSERVACIONES_CONTACTO ?? "",
                        FechaEnvio = datos.FECHA_ENVIO,
                        Estado = datos.ID_ESTADO.HasValue ? ObtenerNombreEstadoFestival(datos.ID_ESTADO.Value) : "Sin estado"
                    };
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        // Clase auxiliar para mapear datos completos
        private class FestivalCompletoDT
        {
            public int id { get; set; }
            public int? creado_por { get; set; }
            public string NOMBRE_FESTIVAL { get; set; }
            public int? VERSIONES_REALIZADAS { get; set; }
            public DateTime? FECHA_ULTIMA_VERSION { get; set; }
            public string DESCRIPCION_FESTIVAL { get; set; }
            public string CORREO_CONTACTO { get; set; }
            public string INSTAGRAM { get; set; }
            public string FACEBOOK { get; set; }
            public string PAGINA_WEB { get; set; }
            public string OTRO_ENLACE { get; set; }
            public string CELULAR { get; set; }
            public string OBSERVACIONES_CONTACTO { get; set; }
            public DateTime? FECHA_ENVIO { get; set; }
            public int? ID_ESTADO { get; set; }
        }

        /// <summary>
        /// Obtiene festivales filtrados por texto (nombre)
        /// </summary>
        public static List<FestivalListadoDTO> ObtenerPorFiltro(int usuarioId, string filtroTexto)
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    // Usar SQL directo
                    string sql;
                    List<FestivalRawDTO> datos;
                    
                    if (!string.IsNullOrWhiteSpace(filtroTexto))
                    {
                        sql = @"
                            SELECT 
                                id,
                                NOMBRE_FESTIVAL,
                                FECHA_ENVIO,
                                ID_ESTADO
                            FROM ART_MUS_FESTIVALES
                            WHERE creado_por = @p0 AND NOMBRE_FESTIVAL LIKE @p1
                            ORDER BY FECHA_ENVIO DESC";
                        datos = context.Database.SqlQuery<FestivalRawDTO>(sql, usuarioId, "%" + filtroTexto + "%").ToList();
                    }
                    else
                    {
                        sql = @"
                            SELECT 
                                id,
                                NOMBRE_FESTIVAL,
                                FECHA_ENVIO,
                                ID_ESTADO
                            FROM ART_MUS_FESTIVALES
                            WHERE creado_por = @p0
                            ORDER BY FECHA_ENVIO DESC";
                        datos = context.Database.SqlQuery<FestivalRawDTO>(sql, usuarioId).ToList();
                    }

                    var resultado = new List<FestivalListadoDTO>();

                    foreach (var f in datos)
                    {
                        resultado.Add(new FestivalListadoDTO
                        {
                            Id = f.id,
                            Nombre = f.NOMBRE_FESTIVAL ?? "",
                            FechaCreacion = f.FECHA_ENVIO ?? DateTime.MinValue,
                            FechaSolicitud = f.FECHA_ENVIO ?? DateTime.MinValue,
                            FechaSolicitudAclaraciones = f.FECHA_ENVIO,
                            FechaReciboAclaraciones = null,
                            Estado = f.ID_ESTADO.HasValue ? ObtenerNombreEstadoFestival(f.ID_ESTADO.Value) : "Sin estado"
                        });
                    }

                    return resultado;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Obtiene todas las fuentes de financiación disponibles
        /// </summary>
        public static List<FuenteFinanciacionDTO> ObtenerFuentesFinanciacion()
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    string sql = @"
                        SELECT 
                            ID AS Id,
                            FUENTE_FINANCIACION AS Nombre
                        FROM ART_MUS_FESTIVALES_FUENTE_FINANCIACION
                        WHERE ACTIVO = 1 OR ACTIVO IS NULL
                        ORDER BY FUENTE_FINANCIACION";

                    var datos = context.Database.SqlQuery<FuenteFinanciacionDTO>(sql).ToList();
                    return datos;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Actualización

        /// <summary>
        /// Crea un nuevo festival usando DTO
        /// </summary>
        public static int Agregar(FestivalCrearDTO datos, string nombreUsuario, int usuarioId, string strIP)
        {
            try
            {
                EscribirLog($"Agregar - Iniciando creación de festival. Usuario: {nombreUsuario}, UsuarioId: {usuarioId}");
                EscribirLog($"Agregar - Datos: Nombre={datos.Nombre}, NumeroVersiones={datos.NumeroVersiones}, FechaUltimaVersion={datos.FechaUltimaVersion}");
                
                var registro = new ART_MUS_FESTIVALES
                {
                    NOMBRE_FESTIVAL = datos.Nombre?.Trim(),
                    VERSIONES_REALIZADAS = datos.NumeroVersiones,
                    FECHA_ULTIMA_VERSION = datos.FechaUltimaVersion,
                    DESCRIPCION_FESTIVAL = datos.Descripcion?.Trim(),
                    CORREO_CONTACTO = datos.CorreoContacto?.Trim(),
                    INSTAGRAM = datos.Instagram?.Trim(),
                    FACEBOOK = datos.Facebook?.Trim(),
                    PAGINA_WEB = datos.PaginaWeb?.Trim(),
                    OTRO_ENLACE = datos.OtroEnlace?.Trim(),
                    CELULAR = datos.TelefonoCelular?.Trim(),
                    OBSERVACIONES_CONTACTO = datos.Observaciones?.Trim(),
                    ID_ESTADO = datos.IdEstado
                };

                EscribirLog($"Agregar - Entidad creada, llamando a AgregarInterno...");
                int resultado = AgregarInterno(registro, nombreUsuario, usuarioId, strIP);
                EscribirLog($"Agregar - Festival creado con ID: {resultado}");
                return resultado;
            }
            catch (Exception ex)
            {
                EscribirLog($"Agregar - ERROR: {ex.Message}\n{ex.StackTrace}");
                var innerEx = ex.InnerException;
                while (innerEx != null)
                {
                    EscribirLog($"INNER EXCEPTION: {innerEx.Message}\n{innerEx.StackTrace}");
                    innerEx = innerEx.InnerException;
                }
                throw;
            }
        }

        /// <summary>
        /// Crea un nuevo festival (uso interno - usa DTO en su lugar)
        /// </summary>
        private static int AgregarInterno(ART_MUS_FESTIVALES registro, string nombreUsuario, int usuarioId, string strIP)
        {
            try
            {
                EscribirLog($"AgregarInterno - Iniciando. Nombre: {registro.NOMBRE_FESTIVAL}, UsuarioId: {usuarioId}");
                
                using (var context = new SIPAEntities())
                {
                    registro.creado_por = usuarioId;
                    registro.FECHA_ENVIO = DateTime.Now;

                    EscribirLog($"AgregarInterno - Agregando entidad al contexto...");
                    context.ART_MUS_FESTIVALES.Add(registro);
                    
                    EscribirLog($"AgregarInterno - Llamando a SaveChanges()...");
                    int cambios = context.SaveChanges();
                    EscribirLog($"AgregarInterno - SaveChanges completado. Cambios guardados: {cambios}");
                    EscribirLog($"AgregarInterno - ID generado: {registro.id}");

                    // Auditoría
                    try
                    {
                        EscribirLog($"AgregarInterno - Creando auditoría...");
                        var descripcion = $"El usuario {nombreUsuario} ({usuarioId}) creó el festival '{registro.NOMBRE_FESTIVAL}' el {DateTime.Now}";
                        var registroOperacion = new ART_MUSICA_REGISTRO_OPERACION
                        {
                            Categoria = "Festivales",
                            IpUsuario = strIP,
                            RegistroId = registro.id,
                            UsuarioId = usuarioId,
                            NombreUsuario = nombreUsuario,
                            Descripcion = descripcion,
                            FechaRegistro = DateTime.Now,
                            Operacion = "Creación"
                        };

                        var auditoria = new RegistroOperacionServicio();
                        auditoria.Crear(registroOperacion);
                        EscribirLog($"AgregarInterno - Auditoría creada exitosamente");
                    }
                    catch (Exception exAudit)
                    {
                        EscribirLog($"AgregarInterno - Error en auditoría (no crítico): {exAudit.Message}");
                        // No lanzar excepción, ya que el registro principal se guardó
                    }

                    EscribirLog($"AgregarInterno - Retornando ID: {registro.id}");
                    return registro.id;
                }
            }
            catch (Exception ex)
            {
                EscribirLog($"AgregarInterno - ERROR CRÍTICO: {ex.Message}\n{ex.StackTrace}");
                var innerEx = ex.InnerException;
                while (innerEx != null)
                {
                    EscribirLog($"INNER EXCEPTION: {innerEx.Message}\n{innerEx.StackTrace}");
                    innerEx = innerEx.InnerException;
                }
                throw;
            }
        }

        /// <summary>
        /// Actualiza un festival existente usando DTO
        /// </summary>
        public static void Actualizar(FestivalActualizarDTO datos, string nombreUsuario, int usuarioId, string strIP)
        {
            try
            {
                EscribirLog($"Actualizar - Iniciando actualización de festival ID: {datos.Id}. Usuario: {nombreUsuario}");
                
                using (var context = new SIPAEntities())
                {
                    var entidad = context.ART_MUS_FESTIVALES.FirstOrDefault(f => f.id == datos.Id);
                    if (entidad != null)
                    {
                        EscribirLog($"Actualizar - Festival encontrado: {entidad.NOMBRE_FESTIVAL}");
                        
                        entidad.NOMBRE_FESTIVAL = datos.Nombre?.Trim();
                        entidad.VERSIONES_REALIZADAS = datos.NumeroVersiones;
                        entidad.FECHA_ULTIMA_VERSION = datos.FechaUltimaVersion;
                        entidad.DESCRIPCION_FESTIVAL = datos.Descripcion?.Trim();
                        entidad.CORREO_CONTACTO = datos.CorreoContacto?.Trim();
                        entidad.INSTAGRAM = datos.Instagram?.Trim();
                        entidad.FACEBOOK = datos.Facebook?.Trim();
                        entidad.PAGINA_WEB = datos.PaginaWeb?.Trim();
                        entidad.OTRO_ENLACE = datos.OtroEnlace?.Trim();
                        entidad.CELULAR = datos.TelefonoCelular?.Trim();
                        entidad.OBSERVACIONES_CONTACTO = datos.Observaciones?.Trim();
                        entidad.ID_ESTADO = datos.IdEstado;

                        EscribirLog($"Actualizar - Llamando a SaveChanges()...");
                        int cambios = context.SaveChanges();
                        EscribirLog($"Actualizar - SaveChanges completado. Cambios guardados: {cambios}");

                        // Auditoría
                        try
                        {
                            EscribirLog($"Actualizar - Creando auditoría...");
                            var descripcion = $"El usuario {nombreUsuario} ({usuarioId}) actualizó el festival '{entidad.NOMBRE_FESTIVAL}' el {DateTime.Now}";
                            var registroOperacion = new ART_MUSICA_REGISTRO_OPERACION
                            {
                                Categoria = "Festivales",
                                IpUsuario = strIP,
                                RegistroId = datos.Id,
                                UsuarioId = usuarioId,
                                NombreUsuario = nombreUsuario,
                                Descripcion = descripcion,
                                FechaRegistro = DateTime.Now,
                                Operacion = "Actualización"
                            };

                            var auditoria = new RegistroOperacionServicio();
                            auditoria.Crear(registroOperacion);
                            EscribirLog($"Actualizar - Auditoría creada exitosamente");
                        }
                        catch (Exception exAudit)
                        {
                            EscribirLog($"Actualizar - Error en auditoría (no crítico): {exAudit.Message}");
                        }
                    }
                    else
                    {
                        EscribirLog($"Actualizar - ADVERTENCIA: No se encontró el festival con ID: {datos.Id}");
                    }
                }
            }
            catch (Exception ex)
            {
                EscribirLog($"Actualizar - ERROR: {ex.Message}\n{ex.StackTrace}");
                var innerEx = ex.InnerException;
                while (innerEx != null)
                {
                    EscribirLog($"INNER EXCEPTION: {innerEx.Message}\n{innerEx.StackTrace}");
                    innerEx = innerEx.InnerException;
                }
                throw;
            }
        }

        /// <summary>
        /// Actualiza un festival existente
        /// </summary>
        public static void Actualizar(int festivalId, ART_MUS_FESTIVALES datosActualizados, string nombreUsuario, int usuarioId, string strIP)
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    var entidad = context.ART_MUS_FESTIVALES.FirstOrDefault(f => f.id == festivalId);
                    if (entidad != null)
                    {
                        entidad.NOMBRE_FESTIVAL = datosActualizados.NOMBRE_FESTIVAL;
                        entidad.VERSIONES_REALIZADAS = datosActualizados.VERSIONES_REALIZADAS;
                        entidad.FECHA_ULTIMA_VERSION = datosActualizados.FECHA_ULTIMA_VERSION;
                        entidad.DESCRIPCION_FESTIVAL = datosActualizados.DESCRIPCION_FESTIVAL;
                        entidad.CORREO_CONTACTO = datosActualizados.CORREO_CONTACTO;
                        entidad.INSTAGRAM = datosActualizados.INSTAGRAM;
                        entidad.FACEBOOK = datosActualizados.FACEBOOK;
                        entidad.PAGINA_WEB = datosActualizados.PAGINA_WEB;
                        entidad.OTRO_ENLACE = datosActualizados.OTRO_ENLACE;
                        entidad.CELULAR = datosActualizados.CELULAR;
                        entidad.OBSERVACIONES_CONTACTO = datosActualizados.OBSERVACIONES_CONTACTO;

                        context.SaveChanges();

                        // Auditoría
                        var descripcion = $"El usuario {nombreUsuario} ({usuarioId}) actualizó el festival '{entidad.NOMBRE_FESTIVAL}' el {DateTime.Now}";
                        var registroOperacion = new ART_MUSICA_REGISTRO_OPERACION
                        {
                            Categoria = "Festivales",
                            IpUsuario = strIP,
                            RegistroId = festivalId,
                            UsuarioId = usuarioId,
                            NombreUsuario = nombreUsuario,
                            Descripcion = descripcion,
                            FechaRegistro = DateTime.Now,
                            Operacion = "Actualización"
                        };

                        var auditoria = new RegistroOperacionServicio();
                        auditoria.Crear(registroOperacion);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Cambia el estado de un festival
        /// </summary>
        public static void CambiarEstado(int festivalId, int nuevoEstadoId, string nombreUsuario, int usuarioId, string strIP)
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    var entidad = context.ART_MUS_FESTIVALES.FirstOrDefault(f => f.id == festivalId);
                    if (entidad != null)
                    {
                        var estadoAnterior = entidad.ID_ESTADO;
                        entidad.ID_ESTADO = nuevoEstadoId;
                        context.SaveChanges();

                        // Auditor&iacute;a
                        var estadoAnteriorNombre = estadoAnterior.HasValue ? ObtenerNombreEstadoFestival(estadoAnterior.Value) : "Sin estado";
                        var estadoNuevoNombre = ObtenerNombreEstadoFestival(nuevoEstadoId);
                        var descripcion = $"El usuario {nombreUsuario} ({usuarioId}) cambió el estado del festival '{entidad.NOMBRE_FESTIVAL}' de {estadoAnteriorNombre} a {estadoNuevoNombre} el {DateTime.Now}";
                        var registroOperacion = new ART_MUSICA_REGISTRO_OPERACION
                        {
                            Categoria = "Festivales",
                            IpUsuario = strIP,
                            RegistroId = festivalId,
                            UsuarioId = usuarioId,
                            NombreUsuario = nombreUsuario,
                            Descripcion = descripcion,
                            FechaRegistro = DateTime.Now,
                            Operacion = "Cambio de Estado"
                        };

                        var auditoria = new RegistroOperacionServicio();
                        auditoria.Crear(registroOperacion);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Consulta Pública

        /// <summary>
        /// Obtiene el catálogo de territorios sonoros para filtros públicos
        /// </summary>
        public static List<CatalogoItemDTO> ObtenerTerritoriosSonoros()
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    return context.ART_MUS_TERRITORIOS_SONOROS
                        .OrderBy(t => t.TERRITORIOS_SONOROS)
                        .Select(t => new CatalogoItemDTO
                        {
                            Id = t.ID,
                            Nombre = t.TERRITORIOS_SONOROS ?? ""
                        })
                        .ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Obtiene el catálogo de tipologías para filtros públicos
        /// </summary>
        public static List<CatalogoItemDTO> ObtenerTipologias()
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    return context.ART_MUS_FESTIVALES_TIPOLOGIA
                        .Where(t => t.ACTIVO == 1)
                        .OrderBy(t => t.TIPOLOGIA)
                        .Select(t => new CatalogoItemDTO
                        {
                            Id = t.ID,
                            Nombre = t.TIPOLOGIA ?? ""
                        })
                        .ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Obtiene el catálogo de expresiones artísticas para filtros públicos
        /// </summary>
        public static List<CatalogoItemDTO> ObtenerExpresionesArtisticas()
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    return context.ART_MUS_FESTIVALES_EXPRESIONES_ARTISTICAS
                        .Where(e => e.ACTIVO == true)
                        .OrderBy(e => e.EXPRESION_ARTISTICA)
                        .Select(e => new CatalogoItemDTO
                        {
                            Id = e.ID,
                            Nombre = e.EXPRESION_ARTISTICA ?? ""
                        })
                        .ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Obtiene el catálogo de tipos de ingreso para filtros públicos
        /// </summary>
        public static List<CatalogoItemDTO> ObtenerTiposIngreso()
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    return context.ART_MUS_TIPOINGRESO
                        .OrderBy(t => t.TIPO_INGRESO)
                        .Select(t => new CatalogoItemDTO
                        {
                            Id = t.ID,
                            Nombre = t.TIPO_INGRESO ?? ""
                        })
                        .ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Obtiene el catálogo de departamentos (zonas con ZON_PADRE_ID null)
        /// </summary>
        public static List<CatalogoItemDTO> ObtenerDepartamentos()
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    return context.BAS_ZONAS_GEOGRAFICAS
                        .Where(z => z.ZON_PADRE_ID == null)
                        .OrderBy(z => z.ZON_NOMBRE)
                        .Select(z => new CatalogoItemDTO
                        {
                            Id = 0, // No se usa el ID numérico
                            Codigo = z.ZON_ID,
                            Nombre = z.ZON_NOMBRE ?? ""
                        })
                        .ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Obtiene los municipios de un departamento específico
        /// </summary>
        /// <param name="codigoDepartamento">Código del departamento (ZON_ID)</param>
        public static List<CatalogoItemDTO> ObtenerMunicipiosPorDepartamento(string codigoDepartamento)
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    return context.BAS_ZONAS_GEOGRAFICAS
                        .Where(z => z.ZON_PADRE_ID == codigoDepartamento)
                        .OrderBy(z => z.ZON_NOMBRE)
                        .Select(z => new CatalogoItemDTO
                        {
                            Id = 0, // No se usa el ID numérico
                            Codigo = z.ZON_ID,
                            Nombre = z.ZON_NOMBRE ?? ""
                        })
                        .ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Busca festivales según criterios para consulta pública
        /// </summary>
        public static List<FestivalPublicoDTO> BuscarPublico(ConsultaPublicaFiltrosDTO filtros)
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    // Obtener versiones de festivales publicadas con todas las relaciones necesarias
                    var query = context.ART_MUS_FESTIVALES_VERSION
                        .Include("ART_MUS_FESTIVALES")
                        .Include("ART_MUS_FESTIVALES_TIPOLOGIA")
                        .Include("ART_MUS_LOCALIZACIONXVERSION")
                        .Include("ART_MUS_LOCALIZACIONXVERSION.BAS_ZONAS_GEOGRAFICAS")
                        .Include("ART_MUS_TERRITORIOS_SONOROSXVERSION")
                        .Include("ART_MUS_FESTIVALES_EXPRESIONXVERSION")
                        .Include("ART_MUS_TIPOINGRESOXVERSION")
                        .Include("ART_MUS_MATERIALMULTIMEDIA")
                        .Where(v => v.ART_MUS_FESTIVALES.ID_ESTADO == 4); // Estado "Publicado"

                    // Filtrar por mes (solo si está seleccionado el checkbox)
                    if (!string.IsNullOrEmpty(filtros.MesInicio))
                    {
                        // Formato: yyyy-MM
                        if (DateTime.TryParse(filtros.MesInicio + "-01", out DateTime mes))
                        {
                            int anio = mes.Year;
                            int mesNum = mes.Month;
                            string anioBuscar = anio.ToString();
                            string mesBuscar = mesNum.ToString("00");
                            
                            query = query.Where(v => v.FECHA_INICIO != null && 
                                v.FECHA_INICIO.StartsWith(anioBuscar) &&
                                v.FECHA_INICIO.Substring(5, 2) == mesBuscar);
                        }
                    }

                    // Filtrar por rango de fechas (solo si está seleccionado el checkbox)
                    if (filtros.FechaInicio.HasValue && filtros.FechaFin.HasValue)
                    {
                        string fechaInicioStr = filtros.FechaInicio.Value.ToString("yyyy-MM-dd");
                        string fechaFinStr = filtros.FechaFin.Value.ToString("yyyy-MM-dd");
                        
                        query = query.Where(v => v.FECHA_INICIO != null && 
                            string.Compare(v.FECHA_INICIO, fechaInicioStr) >= 0 &&
                            v.FECHA_INICIO != null &&
                            string.Compare(v.FECHA_INICIO, fechaFinStr) <= 0);
                    }
                    else if (filtros.FechaInicio.HasValue)
                    {
                        // Solo filtrar por fecha inicio si no hay fecha fin
                        string fechaStr = filtros.FechaInicio.Value.ToString("yyyy-MM-dd");
                        query = query.Where(v => v.FECHA_INICIO != null && 
                            string.Compare(v.FECHA_INICIO, fechaStr) >= 0);
                    }
                    else if (filtros.FechaFin.HasValue)
                    {
                        // Solo filtrar por fecha fin si no hay fecha inicio
                        string fechaStr = filtros.FechaFin.Value.ToString("yyyy-MM-dd");
                        query = query.Where(v => v.FECHA_INICIO != null && 
                            string.Compare(v.FECHA_INICIO, fechaStr) <= 0);
                    }

                    // Filtrar por texto de búsqueda
                    if (!string.IsNullOrWhiteSpace(filtros.TextoBusqueda))
                    {
                        string buscar = filtros.TextoBusqueda.ToLower();
                        query = query.Where(v => 
                            v.ART_MUS_FESTIVALES.NOMBRE_FESTIVAL.ToLower().Contains(buscar) ||
                            v.NOMBRE_VERSION.ToLower().Contains(buscar) ||
                            v.DESCRIPCION_VERSION.ToLower().Contains(buscar));
                    }

                    // Filtrar por territorios sonoros
                    if (filtros.TerritoriosSeleccionados != null && filtros.TerritoriosSeleccionados.Any())
                    {
                        query = query.Where(v => v.ART_MUS_TERRITORIOS_SONOROSXVERSION
                            .Any(t => filtros.TerritoriosSeleccionados.Contains(t.ID_TERRITORIOS_SONOROS.Value)));
                    }

                    // Filtrar por tipologías
                    if (filtros.TipologiasSeleccionadas != null && filtros.TipologiasSeleccionadas.Any())
                    {
                        query = query.Where(v => filtros.TipologiasSeleccionadas.Contains(v.ID_TIPOLOGIA.Value));
                    }

                    // Filtrar por expresiones artísticas
                    if (filtros.ExpresionesSeleccionadas != null && filtros.ExpresionesSeleccionadas.Any())
                    {
                        query = query.Where(v => v.ART_MUS_FESTIVALES_EXPRESIONXVERSION
                            .Any(e => filtros.ExpresionesSeleccionadas.Contains(e.ID_EXPRESION_ARTISTICA)));
                    }

                    // Filtrar por departamento (usando la relación ZON_PADRE_ID)
                    if (!string.IsNullOrWhiteSpace(filtros.Departamento))
                    {
                        query = query.Where(v => v.ART_MUS_LOCALIZACIONXVERSION
                            .Any(l => l.BAS_ZONAS_GEOGRAFICAS != null && 
                                      (l.BAS_ZONAS_GEOGRAFICAS.ZON_PADRE_ID == filtros.Departamento || 
                                       l.ZON_ID == filtros.Departamento)));
                    }

                    // Filtrar por municipio
                    if (!string.IsNullOrWhiteSpace(filtros.Municipio))
                    {
                        query = query.Where(v => v.ART_MUS_LOCALIZACIONXVERSION
                            .Any(l => l.ZON_ID == filtros.Municipio));
                    }

                    // Filtrar por tipo de ingreso
                    if (!string.IsNullOrWhiteSpace(filtros.TipoIngreso))
                    {
                        if (int.TryParse(filtros.TipoIngreso, out int tipoIngresoId))
                        {
                            query = query.Where(v => v.ART_MUS_TIPOINGRESOXVERSION
                                .Any(t => t.ID_TIPOINGRESO == tipoIngresoId));
                        }
                    }

                    // Filtrar por tipo (tipología del filtro superior)
                    if (!string.IsNullOrWhiteSpace(filtros.Tipo))
                    {
                        if (int.TryParse(filtros.Tipo, out int tipologiaId))
                        {
                            query = query.Where(v => v.ID_TIPOLOGIA == tipologiaId);
                        }
                    }

                    // Obtener resultados agrupados por festival (solo la versión más reciente de cada uno)
                    var versiones = query
                        .ToList() // Traer a memoria primero
                        .GroupBy(v => v.ID_FESTIVAL)
                        .Select(g => g.OrderByDescending(v => v.ID).First()) // La versión más reciente ingresada
                        .OrderByDescending(v => v.FECHA_INICIO)
                        .ToList();

                    var resultados = new List<FestivalPublicoDTO>();

                    foreach (var version in versiones)
                    {
                        // Obtener primera localización (principal)
                        var localizacion = version.ART_MUS_LOCALIZACIONXVERSION.FirstOrDefault();
                        
                        string departamento = "";
                        string municipio = "";
                        
                        if (localizacion != null && localizacion.BAS_ZONAS_GEOGRAFICAS != null)
                        {
                            // ZON_ID tiene formato: CODDEP o CODDEPCODMUN
                            var zonId = localizacion.ZON_ID;
                            municipio = localizacion.BAS_ZONAS_GEOGRAFICAS.ZON_NOMBRE ?? "";
                            
                            // Buscar el departamento (código de 2 dígitos)
                            if (!string.IsNullOrEmpty(zonId) && zonId.Length >= 2)
                            {
                                string codDep = zonId.Substring(0, 2);
                                var dept = context.BAS_ZONAS_GEOGRAFICAS
                                    .FirstOrDefault(z => z.ZON_ID == codDep);
                                if (dept != null)
                                {
                                    departamento = dept.ZON_NOMBRE ?? "";
                                }
                            }
                        }
                        
                        // Obtener URL de imagen del afiche (buscar por descripción)
                        var multimedia = version.ART_MUS_MATERIALMULTIMEDIA.ToList();
                        var afiche = multimedia.FirstOrDefault(m => m.DESCRIPCION_ARCHIVO != null && m.DESCRIPCION_ARCHIVO.ToLower().Contains("afiche"));
                        
                        // Si no hay afiche, buscar logo
                        if (afiche == null)
                        {
                             afiche = multimedia.FirstOrDefault(m => m.DESCRIPCION_ARCHIVO != null && m.DESCRIPCION_ARCHIVO.ToLower().Contains("logo"));
                        }
                        
                        // Si no hay logo, buscar cualquier imagen
                        if (afiche == null)
                        {
                             afiche = multimedia.FirstOrDefault(m => m.URL_ARCHIVO != null && (m.URL_ARCHIVO.ToLower().EndsWith(".jpg") || m.URL_ARCHIVO.ToLower().EndsWith(".png") || m.URL_ARCHIVO.ToLower().EndsWith(".jpeg")));
                        }

                        DateTime? fechaInicio = null;
                        if (!string.IsNullOrEmpty(version.FECHA_INICIO))
                        {
                            DateTime.TryParse(version.FECHA_INICIO, out DateTime fi);
                            fechaInicio = fi;
                        }

                        DateTime? fechaFin = null;
                        if (!string.IsNullOrEmpty(version.FECHA_FIN))
                        {
                            DateTime.TryParse(version.FECHA_FIN, out DateTime ff);
                            fechaFin = ff;
                        }

                        resultados.Add(new FestivalPublicoDTO
                        {
                            Id = version.ART_MUS_FESTIVALES.id,
                            VersionId = version.ID,
                            Nombre = version.ART_MUS_FESTIVALES.NOMBRE_FESTIVAL,
                            NombreVersion = version.NOMBRE_VERSION,
                            FechaInicio = fechaInicio,
                            FechaFin = fechaFin,
                            Departamento = departamento,
                            Municipio = municipio,
                            Ubicacion = !string.IsNullOrEmpty(municipio) ? $"{municipio}, {departamento}" : departamento,
                            ImagenUrl = afiche?.URL_ARCHIVO,
                            Descripcion = version.DESCRIPCION_VERSION,
                            SinPublicoPresencial = false, // No existe el campo en la BD
                            VersionNumero = version.VERSION_FESTIVAL
                        });
                    }

                    return resultados;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Obtiene el detalle completo de un festival por su ID para consulta pública (obtiene la versión más reciente)
        /// </summary>
        public static dynamic ObtenerDetalleFestivalPublico(int festivalId)
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    // Buscar el festival
                    var festival = context.ART_MUS_FESTIVALES.FirstOrDefault(f => f.id == festivalId);
                    if (festival == null)
                        return null;

                    // Obtener la versión más reciente del festival
                    var version = context.ART_MUS_FESTIVALES_VERSION
                        .Where(v => v.ID_FESTIVAL == festivalId)
                        .OrderByDescending(v => v.ID)
                        .FirstOrDefault();

                    if (version == null)
                        return null;
                    
                    int versionId = version.ID;

                    // Obtener localización manualmente
                    var localizacion = context.ART_MUS_LOCALIZACIONXVERSION
                        .FirstOrDefault(l => l.ID_VERSION == versionId);
                    
                    string departamento = "";
                    string municipio = "";
                    
                    if (localizacion != null)
                    {
                        var zona = context.BAS_ZONAS_GEOGRAFICAS
                            .FirstOrDefault(z => z.ZON_ID == localizacion.ZON_ID);
                        
                        if (zona != null)
                        {
                            municipio = zona.ZON_NOMBRE ?? "";
                            
                            // Buscar el departamento (código de 2 dígitos)
                            if (!string.IsNullOrEmpty(localizacion.ZON_ID) && localizacion.ZON_ID.Length >= 2)
                            {
                                string codDep = localizacion.ZON_ID.Substring(0, 2);
                                var dept = context.BAS_ZONAS_GEOGRAFICAS
                                    .FirstOrDefault(z => z.ZON_ID == codDep);
                                if (dept != null)
                                {
                                    departamento = dept.ZON_NOMBRE ?? "";
                                }
                            }
                        }
                    }

                    // Obtener todas las imágenes válidas
                    var multimedia = context.ART_MUS_MATERIALMULTIMEDIA
                        .Where(m => m.ID_VERSION == versionId && m.URL_ARCHIVO != null)
                        .ToList();
                        
                    var imagenes = multimedia
                        .Where(m => m.URL_ARCHIVO.ToLower().EndsWith(".jpg") || 
                                   m.URL_ARCHIVO.ToLower().EndsWith(".png") || 
                                   m.URL_ARCHIVO.ToLower().EndsWith(".jpeg"))
                        .Select(m => m.URL_ARCHIVO)
                        .ToList();

                    // Si no hay imágenes, intentar buscar afiche o logo específicamente si no se encontraron por extensión
                    if (!imagenes.Any())
                    {
                        var afiche = multimedia.FirstOrDefault(m => m.DESCRIPCION_ARCHIVO != null && m.DESCRIPCION_ARCHIVO.ToLower().Contains("afiche"));
                        if (afiche != null) imagenes.Add(afiche.URL_ARCHIVO);
                        
                        if (!imagenes.Any())
                        {
                            var logo = multimedia.FirstOrDefault(m => m.DESCRIPCION_ARCHIVO != null && m.DESCRIPCION_ARCHIVO.ToLower().Contains("logo"));
                            if (logo != null) imagenes.Add(logo.URL_ARCHIVO);
                        }
                    }

                    // Obtener tipología
                    string tipologia = "";
                    if (version.ID_TIPOLOGIA.HasValue)
                    {
                        var tip = context.ART_MUS_FESTIVALES_TIPOLOGIA
                            .FirstOrDefault(t => t.ID == version.ID_TIPOLOGIA.Value);
                        tipologia = tip?.TIPOLOGIA ?? "";
                    }

                    // Obtener expresiones artísticas
                    var expresiones = context.ART_MUS_FESTIVALES_EXPRESIONXVERSION
                        .Where(e => e.ID_VERSION == versionId)
                        .Join(context.ART_MUS_FESTIVALES_EXPRESIONES_ARTISTICAS,
                            ex => ex.ID_EXPRESION_ARTISTICA,
                            ea => ea.ID,
                            (ex, ea) => ea.EXPRESION_ARTISTICA)
                        .ToList();

                    string expresionesArtisticas = expresiones.Any() ? string.Join(", ", expresiones) : "";

                    return new
                    {
                        nombre = festival.NOMBRE_FESTIVAL,
                        fechaInicio = version.FECHA_INICIO,
                        fechaFin = version.FECHA_FIN,
                        departamento = departamento,
                        municipio = municipio,
                        ubicacion = !string.IsNullOrEmpty(municipio) ? $"{municipio}, {departamento}" : departamento,
                        descripcion = version.DESCRIPCION_VERSION ?? "",
                        imagenes = imagenes,
                        tipologia = tipologia,
                        expresionesArtisticas = expresionesArtisticas,
                        correo = version.CORREO_CONTACTO ?? "",
                        instagram = version.INSTAGRAM ?? "",
                        facebook = version.FACEBOOK ?? "",
                        paginaWeb = version.PAGINA_WEB ?? "",
                        otroEnlace = version.OTRO_ENLACE ?? "",
                        telefono = version.TELEFONO_CELULAR ?? ""
                    };
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Estados de Festivales

        /// <summary>
        /// Obtiene el nombre del estado de un festival desde la tabla ART_MUS_FESTIVALES_ESTADO
        /// </summary>
        /// <param name="estadoId">ID del estado</param>
        /// <returns>Nombre del estado o "Sin estado" si no se encuentra</returns>
        public static string ObtenerNombreEstadoFestival(int estadoId)
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    var estado = context.ART_MUS_FESTIVALES_ESTADO
                        .FirstOrDefault(e => e.ID == estadoId);
                    
                    return estado?.FESTIVALES_ESTADO ?? "Sin estado";
                }
            }
            catch (Exception)
            {
                return "Sin estado";
            }
        }

        #endregion
    }
}
