using SM.WSDatos.Agentes;
using SM.WSDatos.WSDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WS.Simus.Data;

namespace WS.Simus.LogicaData
{
    public class EntidadLogica
    {
        public static List<EntidadData> ConsultarEntidades(string usuario, string contrasena)
        {
            List<EntidadData> listEntidad = new List<EntidadData>();
            List<EntidadesDTO> listEntidadDTO = new List<EntidadesDTO>();
            try
            {
                string strMensajeError = "";
                listEntidadDTO = EntidadesServicio.ConsultarEntidades(usuario, contrasena, out strMensajeError);

                if (String.IsNullOrEmpty(strMensajeError))
                {
                    if (listEntidadDTO != null)
                    {
                        if (listEntidadDTO.Count > 0)
                        {
                            foreach (var item in listEntidadDTO)
                            {
                                EntidadData datos = new EntidadData();
                                datos.EntidadId = item.EntidadId;
                                datos.Nit = item.Nit;
                                datos.DigitoVerificacion = item.DigitoVerificacion;

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

                                if (!string.IsNullOrEmpty(item.TipoEntidad))
                                    datos.TipoEntidad = item.TipoEntidad;
                                
                                listEntidad.Add(datos);
                            } // endforeach
                        } // end If list.count> 0
                        else
                        {
                            EntidadData datos = new EntidadData();
                            datos.Mensaje = "No hay datos";
                            listEntidad.Add(datos);

                        }

                    } //if (listAgenteDTO != null) 
                    else
                    {
                        EntidadData datos = new EntidadData();
                        datos.Mensaje = "No hay datos";
                        listEntidad.Add(datos);

                    }

                }// end if
                else
                {
                    EntidadData datos = new EntidadData();
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

        public static List<EntidadData> ConsultarEntidadesPorRangoFechas(string usuario, string contrasena, DateTime FechaInicio, DateTime FechaFinal)
        {
            List<EntidadData> listEntidad = new List<EntidadData>();
            List<EntidadesDTO> listEntidadDTO = new List<EntidadesDTO>();
            try
            {
                string strMensajeError = "";
                listEntidadDTO = EntidadesServicio.ConsultarEntidadesPorRangoFechas(usuario, contrasena, FechaInicio,  FechaFinal, out strMensajeError);

                if (String.IsNullOrEmpty(strMensajeError))
                {
                    if (listEntidadDTO != null)
                    {
                        if (listEntidadDTO.Count > 0)
                        {
                            foreach (var item in listEntidadDTO)
                            {
                                EntidadData datos = new EntidadData();
                                datos.EntidadId = item.EntidadId;
                                datos.Nit = item.Nit;
                                datos.DigitoVerificacion = item.DigitoVerificacion;

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

                                if (!string.IsNullOrEmpty(item.TipoEntidad))
                                    datos.TipoEntidad = item.TipoEntidad;

                                listEntidad.Add(datos);
                            } // endforeach
                        } // end If list.count> 0
                        else
                        {
                            EntidadData datos = new EntidadData();
                            datos.Mensaje = "No hay datos";
                            listEntidad.Add(datos);

                        }

                    } //if (listAgenteDTO != null) 
                    else
                    {
                        EntidadData datos = new EntidadData();
                        datos.Mensaje = "No hay datos";
                        listEntidad.Add(datos);

                    }

                }// end if
                else
                {
                    EntidadData datos = new EntidadData();
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

        public static EntidadData ConsultarEntidadesPorId(string usuario, string contrasena, int EntidadId)
        {
            EntidadData entidad = new EntidadData();
            EntidadesDTO entidadDTO = new EntidadesDTO();
            try
            {
                string strMensajeError = "";
                entidadDTO = EntidadesServicio.ConsultarEntidadesPorId(usuario, contrasena, EntidadId, out strMensajeError);

                if (String.IsNullOrEmpty(strMensajeError))
                {
                    if (entidadDTO != null)
                    {
                        entidad.EntidadId = entidadDTO.EntidadId;
                        entidad.Nit = entidadDTO.Nit;
                        entidad.DigitoVerificacion = entidadDTO.DigitoVerificacion;

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

                        if (!string.IsNullOrEmpty(entidadDTO.TipoEntidad))
                            entidad.TipoEntidad = entidadDTO.TipoEntidad;

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

        public static EntidadData ConsultarEntidadesPorNit(string usuario, string contrasena, int Nit)
        {
            EntidadData entidad = new EntidadData();
            EntidadesDTO entidadDTO = new EntidadesDTO();
            try
            {
                string strMensajeError = "";
                entidadDTO = EntidadesServicio.ConsultarEntidadesPorNit(usuario, contrasena, Nit, out strMensajeError);

                if (String.IsNullOrEmpty(strMensajeError))
                {
                    if (entidadDTO != null)
                    {
                        entidad.EntidadId = entidadDTO.EntidadId;
                        entidad.Nit = entidadDTO.Nit;
                        entidad.DigitoVerificacion = entidadDTO.DigitoVerificacion;

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

                        if (!string.IsNullOrEmpty(entidadDTO.TipoEntidad))
                            entidad.TipoEntidad = entidadDTO.TipoEntidad;

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