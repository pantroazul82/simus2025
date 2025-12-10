using SM.WSDatos.Agentes;
using SM.WSDatos.WSDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WS.Simus.Data;

namespace WS.Simus.LogicaData
{
    public class AgrupacionLogica
    {
        public static List<AgrupacionData> ConsultarAgrupaciones(string usuario, string contrasena)
        {
            List<AgrupacionData> listEntidad = new List<AgrupacionData>();
            List<AgrupacionDTO> listEntidadDTO = new List<AgrupacionDTO>();
            try
            {
                string strMensajeError = "";
                listEntidadDTO = AgrupacionServicio.ConsultarAgrupaciones(usuario, contrasena, out strMensajeError);

                if (String.IsNullOrEmpty(strMensajeError))
                {
                    if (listEntidadDTO != null)
                    {
                        if (listEntidadDTO.Count > 0)
                        {
                            foreach (var item in listEntidadDTO)
                            {
                                AgrupacionData datos = new AgrupacionData();
                                datos.AgrupacionId = item.AgrupacionId;
                              
                                if (!string.IsNullOrEmpty(item.CodigoMunicipio))
                                    datos.CodigoMunicipio = item.CodigoMunicipio;
                                if (!string.IsNullOrEmpty(item.CorreoElectronico))
                                    datos.CorreoElectronico = item.CorreoElectronico;
                                if (!string.IsNullOrEmpty(item.Direccion))
                                    datos.Direccion = item.Direccion;

                                datos.FechaActualizacion = item.FechaActualizacion;
                                datos.FechaCreacion = item.FechaCreacion;


                                if (!string.IsNullOrEmpty(item.Nombre))
                                    datos.Nombre = item.Nombre;

                                if (!string.IsNullOrEmpty(item.Latitud))
                                    datos.Latitud = item.Latitud;
                                if (!string.IsNullOrEmpty(item.Longitud))
                                    datos.Longitud = item.Longitud;

                                if (!string.IsNullOrEmpty(item.LinkPortafolio))
                                    datos.LinkPortafolio = item.LinkPortafolio;

                                if (!string.IsNullOrEmpty(item.Telefono))
                                    datos.Telefono = item.Telefono;

                                if (!string.IsNullOrEmpty(item.Descripcion))
                                    datos.Descripcion = item.Descripcion;

                                if (!string.IsNullOrEmpty(item.TipoDocumento))
                                    datos.TipoDocumento = item.TipoDocumento;

                                if (!string.IsNullOrEmpty(item.NumeroDocumento))
                                    datos.NumeroDocumento = item.NumeroDocumento;


                                if (!string.IsNullOrEmpty(item.PrimerApellido))
                                    datos.PrimerApellido = item.PrimerApellido;

                                if (!string.IsNullOrEmpty(item.PrimerNombre))
                                    datos.PrimerNombre = item.PrimerNombre;

                                if (!string.IsNullOrEmpty(item.SegundoApellido))
                                    datos.SegundoApellido = item.SegundoApellido;

                                if (!string.IsNullOrEmpty(item.SegundoNombre))
                                    datos.SegundoNombre = item.SegundoNombre;

                                listEntidad.Add(datos);
                            } // endforeach
                        } // end If list.count> 0
                        else
                        {
                            AgrupacionData datos = new AgrupacionData();
                            datos.Mensaje = "No hay datos";
                            listEntidad.Add(datos);

                        }

                    } //if (listAgenteDTO != null) 
                    else
                    {
                        AgrupacionData datos = new AgrupacionData();
                        datos.Mensaje = "No hay datos";
                        listEntidad.Add(datos);

                    }

                }// end if
                else
                {
                    AgrupacionData datos = new AgrupacionData();
                    datos.Mensaje = strMensajeError;
                    listEntidad.Add(datos);

                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listEntidad;
        }

        public static List<AgrupacionData> ConsultarAgrupacionesPorRangoFechas(string usuario, string contrasena, DateTime FechaInicio, DateTime FechaFinal)
        {
            List<AgrupacionData> listEntidad = new List<AgrupacionData>();
            List<AgrupacionDTO> listEntidadDTO = new List<AgrupacionDTO>();
            try
            {
                string strMensajeError = "";
                listEntidadDTO = AgrupacionServicio.ConsultarAgrupacionesPorRangoFechas(usuario, contrasena, FechaInicio, FechaFinal, out strMensajeError);

                if (String.IsNullOrEmpty(strMensajeError))
                {
                    if (listEntidadDTO != null)
                    {
                        if (listEntidadDTO.Count > 0)
                        {
                            foreach (var item in listEntidadDTO)
                            {
                                AgrupacionData datos = new AgrupacionData();
                                datos.AgrupacionId = item.AgrupacionId;

                                if (!string.IsNullOrEmpty(item.CodigoMunicipio))
                                    datos.CodigoMunicipio = item.CodigoMunicipio;
                                if (!string.IsNullOrEmpty(item.CorreoElectronico))
                                    datos.CorreoElectronico = item.CorreoElectronico;
                                if (!string.IsNullOrEmpty(item.Direccion))
                                    datos.Direccion = item.Direccion;

                                datos.FechaActualizacion = item.FechaActualizacion;
                                datos.FechaCreacion = item.FechaCreacion;


                                if (!string.IsNullOrEmpty(item.Nombre))
                                    datos.Nombre = item.Nombre;

                                if (!string.IsNullOrEmpty(item.Latitud))
                                    datos.Latitud = item.Latitud;
                                if (!string.IsNullOrEmpty(item.Longitud))
                                    datos.Longitud = item.Longitud;

                                if (!string.IsNullOrEmpty(item.LinkPortafolio))
                                    datos.LinkPortafolio = item.LinkPortafolio;

                                if (!string.IsNullOrEmpty(item.Telefono))
                                    datos.Telefono = item.Telefono;

                                if (!string.IsNullOrEmpty(item.Descripcion))
                                    datos.Descripcion = item.Descripcion;

                                if (!string.IsNullOrEmpty(item.TipoDocumento))
                                    datos.TipoDocumento = item.TipoDocumento;

                                if (!string.IsNullOrEmpty(item.NumeroDocumento))
                                    datos.NumeroDocumento = item.NumeroDocumento;


                                if (!string.IsNullOrEmpty(item.PrimerApellido))
                                    datos.PrimerApellido = item.PrimerApellido;

                                if (!string.IsNullOrEmpty(item.PrimerNombre))
                                    datos.PrimerNombre = item.PrimerNombre;

                                if (!string.IsNullOrEmpty(item.SegundoApellido))
                                    datos.SegundoApellido = item.SegundoApellido;

                                if (!string.IsNullOrEmpty(item.SegundoNombre))
                                    datos.SegundoNombre = item.SegundoNombre;

                                listEntidad.Add(datos);
                            } // endforeach
                        } // end If list.count> 0
                        else
                        {
                            AgrupacionData datos = new AgrupacionData();
                            datos.Mensaje = "No hay datos";
                            listEntidad.Add(datos);

                        }

                    } //if (listAgenteDTO != null) 
                    else
                    {
                        AgrupacionData datos = new AgrupacionData();
                        datos.Mensaje = "No hay datos";
                        listEntidad.Add(datos);

                    }

                }// end if
                else
                {
                    AgrupacionData datos = new AgrupacionData();
                    datos.Mensaje = strMensajeError;
                    listEntidad.Add(datos);

                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listEntidad;
        }

        public static AgrupacionData ConsultarAgrupacionPorId(string usuario, string contrasena, int AgrupacionId)
        {
            AgrupacionData entidad = new AgrupacionData();
            AgrupacionDTO entidadDTO = new AgrupacionDTO();
            try
            {
                string strMensajeError = "";
                entidadDTO = AgrupacionServicio.ConsultarAgrupacionPorId(usuario, contrasena, AgrupacionId, out strMensajeError);

                if (String.IsNullOrEmpty(strMensajeError))
                {
                    if (entidadDTO != null)
                    {
                        entidad.AgrupacionId = entidadDTO.AgrupacionId;
    

                        if (!string.IsNullOrEmpty(entidadDTO.CodigoMunicipio))
                            entidad.CodigoMunicipio = entidadDTO.CodigoMunicipio;
                        if (!string.IsNullOrEmpty(entidadDTO.CorreoElectronico))
                            entidad.CorreoElectronico = entidadDTO.CorreoElectronico;
                        if (!string.IsNullOrEmpty(entidadDTO.Direccion))
                            entidad.Direccion = entidadDTO.Direccion;

                        entidad.FechaActualizacion = entidadDTO.FechaActualizacion;
                        entidad.FechaCreacion = entidadDTO.FechaCreacion;


                        if (!string.IsNullOrEmpty(entidadDTO.Nombre))
                            entidad.Nombre = entidadDTO.Nombre;

                        if (!string.IsNullOrEmpty(entidadDTO.Latitud))
                            entidad.Latitud = entidadDTO.Latitud;
                        if (!string.IsNullOrEmpty(entidadDTO.Longitud))
                            entidad.Longitud = entidadDTO.Longitud;

                        if (!string.IsNullOrEmpty(entidadDTO.LinkPortafolio))
                            entidad.LinkPortafolio = entidadDTO.LinkPortafolio;

                        if (!string.IsNullOrEmpty(entidadDTO.Telefono))
                            entidad.Telefono = entidadDTO.Telefono;

                        if (!string.IsNullOrEmpty(entidadDTO.Descripcion))
                            entidad.Descripcion = entidadDTO.Descripcion;

                        if (!string.IsNullOrEmpty(entidadDTO.TipoDocumento))
                            entidad.TipoDocumento = entidadDTO.TipoDocumento;

                        if (!string.IsNullOrEmpty(entidadDTO.NumeroDocumento))
                            entidad.NumeroDocumento = entidadDTO.NumeroDocumento;


                        if (!string.IsNullOrEmpty(entidadDTO.PrimerApellido))
                            entidad.PrimerApellido = entidadDTO.PrimerApellido;

                        if (!string.IsNullOrEmpty(entidadDTO.PrimerNombre))
                            entidad.PrimerNombre = entidadDTO.PrimerNombre;

                        if (!string.IsNullOrEmpty(entidadDTO.SegundoApellido))
                            entidad.SegundoApellido = entidadDTO.SegundoApellido;

                        if (!string.IsNullOrEmpty(entidadDTO.SegundoNombre))
                            entidad.SegundoNombre = entidadDTO.SegundoNombre;

                    } // end if null
                    else
                    { entidad.Mensaje = "No hay datos"; }
                } // end if
                else
                { entidad.Mensaje = strMensajeError; }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return entidad;
        }
    }
}