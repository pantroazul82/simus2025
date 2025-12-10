using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WS.Simus.Data;
using SM.WSDatos;
using SM.WSDatos.WSDTO;
using SM.WSDatos.Agentes;

namespace WS.Simus.LogicaData
{
    public class AgenteLogica
    {
        public static List<AgenteData> ConsultarAgentes(string usuario, string contrasena)
        {
            List<AgenteData> listAgente = new List<AgenteData>();
            List<AgenteDTO> listAgenteDTO = new List<AgenteDTO>();
            try
            {
                string strMensajeError = "";
                listAgenteDTO = AgenteServicio.ConsultarAgentes(usuario, contrasena, out strMensajeError);

                if (String.IsNullOrEmpty(strMensajeError))
                {
                    if (listAgenteDTO != null)
                    {
                        if (listAgenteDTO.Count > 0)
                        {
                            foreach (var item in listAgenteDTO)
                            {
                                AgenteData datos = new AgenteData();
                                datos.AgenteId = item.AgenteId;
                                if (!string.IsNullOrEmpty(item.CodigoMunicipio))
                                    datos.CodigoMunicipio = item.CodigoMunicipio;
                                if (!string.IsNullOrEmpty(item.CorreoElectronico))
                                    datos.CorreoElectronico = item.CorreoElectronico;
                                if (!string.IsNullOrEmpty(item.Direccion))
                                    datos.Direccion = item.Direccion;

                                datos.FechaActualizacion = item.FechaActualizacion;
                                datos.FechaCreacion = item.FechaCreacion;

                                if (item.FechaNacimiento != null)
                                {
                                    if (item.FechaNacimiento.Value.Year != 1)
                                        datos.FechaNacimiento = (DateTime)item.FechaNacimiento;
                                }

                                if (!string.IsNullOrEmpty(item.Genero))
                                    datos.Genero = item.Genero;
                                if (item.Imagen != null)
                                    datos.Imagen = item.Imagen;
                                if (!string.IsNullOrEmpty(item.Latitud))
                                    datos.Latitud = item.Latitud;
                                if (!string.IsNullOrEmpty(item.Longitud))
                                    datos.Longitud = item.Longitud;

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
                                if (!string.IsNullOrEmpty(item.Telefono))
                                    datos.Telefono = item.Telefono;
                                if (!string.IsNullOrEmpty(item.TipoDocumento))
                                    datos.TipoDocumento = item.TipoDocumento;

                                listAgente.Add(datos);
                            } // endforeach
                        } // end If list.count> 0
                        else
                        {
                            AgenteData datos = new AgenteData();
                            datos.Mensaje = "No hay datos";
                            listAgente.Add(datos);

                        }

                    } //if (listAgenteDTO != null) 
                    else
                    {
                        AgenteData datos = new AgenteData();
                        datos.Mensaje = "No hay datos";
                        listAgente.Add(datos);

                    }

                }// end if
                else
                {
                    AgenteData datos = new AgenteData();
                    datos.Mensaje = strMensajeError;
                    listAgente.Add(datos);

                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listAgente;
        }

        public static List<AgenteData> ConsultarAgentesPorRangoFechas(string usuario, string contrasena, DateTime FechaInicio, DateTime FechaFinal)
        {
            List<AgenteData> listAgente = new List<AgenteData>();
            List<AgenteDTO> listAgenteDTO = new List<AgenteDTO>();
            try
            {
                string strMensajeError = "";
                listAgenteDTO = AgenteServicio.ConsultarAgentesPorRangoFechas(usuario, contrasena, FechaInicio, FechaFinal, out strMensajeError);

                if (String.IsNullOrEmpty(strMensajeError))
                {
                    if (listAgenteDTO != null)
                    {
                        if (listAgenteDTO.Count > 0)
                        {
                            foreach (var item in listAgenteDTO)
                            {
                                AgenteData datos = new AgenteData();
                                datos.AgenteId = item.AgenteId;
                                if (!string.IsNullOrEmpty(item.CodigoMunicipio))
                                    datos.CodigoMunicipio = item.CodigoMunicipio;
                                if (!string.IsNullOrEmpty(item.CorreoElectronico))
                                    datos.CorreoElectronico = item.CorreoElectronico;
                                if (!string.IsNullOrEmpty(item.Direccion))
                                    datos.Direccion = item.Direccion;

                                datos.FechaActualizacion = item.FechaActualizacion;
                                datos.FechaCreacion = item.FechaCreacion;

                                if (item.FechaNacimiento != null)
                                {
                                    if (item.FechaNacimiento.Value.Year != 1)
                                        datos.FechaNacimiento = (DateTime)item.FechaNacimiento;
                                }

                                if (!string.IsNullOrEmpty(item.Genero))
                                    datos.Genero = item.Genero;
                                if (item.Imagen != null)
                                    datos.Imagen = item.Imagen;
                                if (!string.IsNullOrEmpty(item.Latitud))
                                    datos.Latitud = item.Latitud;
                                if (!string.IsNullOrEmpty(item.Longitud))
                                    datos.Longitud = item.Longitud;

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
                                if (!string.IsNullOrEmpty(item.Telefono))
                                    datos.Telefono = item.Telefono;
                                if (!string.IsNullOrEmpty(item.TipoDocumento))
                                    datos.TipoDocumento = item.TipoDocumento;

                                listAgente.Add(datos);
                            } // endforeach
                        } // end If list.count> 0
                        else
                        {
                            AgenteData datos = new AgenteData();
                            datos.Mensaje = "No hay datos";
                            listAgente.Add(datos);

                        }

                    } //if (listAgenteDTO != null) 
                    else
                    {
                        AgenteData datos = new AgenteData();
                        datos.Mensaje = "No hay datos";
                        listAgente.Add(datos);

                    }

                }// end if
                else
                {
                    AgenteData datos = new AgenteData();
                    datos.Mensaje = strMensajeError;
                    listAgente.Add(datos);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listAgente;
        }

        public static AgenteData ConsultarAgentePorId(string usuario, string contrasena, int AgenteId)
        {
            AgenteData Agente = new AgenteData();
            AgenteDTO AgenteDTO = new AgenteDTO();
            try
            {
                string strMensajeError = "";
                AgenteDTO = AgenteServicio.ConsultarAgentePorId(usuario, contrasena, AgenteId, out strMensajeError);

                if (String.IsNullOrEmpty(strMensajeError))
                {
                    if (AgenteDTO != null)
                    {
                        Agente.AgenteId = AgenteDTO.AgenteId;
                        if (!string.IsNullOrEmpty(AgenteDTO.CodigoMunicipio))
                            Agente.CodigoMunicipio = AgenteDTO.CodigoMunicipio;
                        if (!string.IsNullOrEmpty(AgenteDTO.CorreoElectronico))
                            Agente.CorreoElectronico = AgenteDTO.CorreoElectronico;
                        if (!string.IsNullOrEmpty(AgenteDTO.Direccion))
                            Agente.Direccion = AgenteDTO.Direccion;

                        Agente.FechaActualizacion = AgenteDTO.FechaActualizacion;
                        Agente.FechaCreacion = AgenteDTO.FechaCreacion;

                        if (AgenteDTO.FechaNacimiento != null)
                        {
                            if (AgenteDTO.FechaNacimiento.Value.Year != 1)
                                Agente.FechaNacimiento = (DateTime)AgenteDTO.FechaNacimiento;
                        }

                        if (!string.IsNullOrEmpty(AgenteDTO.Genero))
                            Agente.Genero = AgenteDTO.Genero;
                        if (AgenteDTO.Imagen != null)
                            Agente.Imagen = AgenteDTO.Imagen;
                        if (!string.IsNullOrEmpty(AgenteDTO.Latitud))
                            Agente.Latitud = AgenteDTO.Latitud;
                        if (!string.IsNullOrEmpty(AgenteDTO.Longitud))
                            Agente.Longitud = AgenteDTO.Longitud;

                        if (!string.IsNullOrEmpty(AgenteDTO.NumeroDocumento))
                            Agente.NumeroDocumento = AgenteDTO.NumeroDocumento;
                        if (!string.IsNullOrEmpty(AgenteDTO.PrimerApellido))
                            Agente.PrimerApellido = AgenteDTO.PrimerApellido;
                        if (!string.IsNullOrEmpty(AgenteDTO.PrimerNombre))
                            Agente.PrimerNombre = AgenteDTO.PrimerNombre;
                        if (!string.IsNullOrEmpty(AgenteDTO.SegundoApellido))
                            Agente.SegundoApellido = AgenteDTO.SegundoApellido;
                        if (!string.IsNullOrEmpty(AgenteDTO.SegundoNombre))
                            Agente.SegundoNombre = AgenteDTO.SegundoNombre;
                        if (!string.IsNullOrEmpty(AgenteDTO.Telefono))
                            Agente.Telefono = AgenteDTO.Telefono;
                        if (!string.IsNullOrEmpty(AgenteDTO.TipoDocumento))
                            Agente.TipoDocumento = AgenteDTO.TipoDocumento;

                    } // end if null
                    else
                    { Agente.Mensaje = "No hay datos"; }
                } // end if
                else
                { Agente.Mensaje = strMensajeError; }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Agente;
        }

        public static AgenteData ConsultarAgentePorIdentificacion(string usuario, string contrasena, string tipoDocumento, string numeroDocumento)
        {
            AgenteData Agente = new AgenteData();
            AgenteDTO AgenteDTO = new AgenteDTO();
            try
            {

                string strMensajeError = "";
                AgenteDTO = AgenteServicio.ConsultarAgentePorIdentificacion(usuario, contrasena, tipoDocumento, numeroDocumento, out strMensajeError);

                if (String.IsNullOrEmpty(strMensajeError))
                {
                    if (AgenteDTO != null)
                    {
                        Agente.AgenteId = AgenteDTO.AgenteId;
                        if (!string.IsNullOrEmpty(AgenteDTO.CodigoMunicipio))
                            Agente.CodigoMunicipio = AgenteDTO.CodigoMunicipio;
                        if (!string.IsNullOrEmpty(AgenteDTO.CorreoElectronico))
                            Agente.CorreoElectronico = AgenteDTO.CorreoElectronico;
                        if (!string.IsNullOrEmpty(AgenteDTO.Direccion))
                            Agente.Direccion = AgenteDTO.Direccion;

                        Agente.FechaActualizacion = AgenteDTO.FechaActualizacion;
                        Agente.FechaCreacion = AgenteDTO.FechaCreacion;

                        if (AgenteDTO.FechaNacimiento != null)
                        {
                            if (AgenteDTO.FechaNacimiento.Value.Year != 1)
                                Agente.FechaNacimiento = (DateTime)AgenteDTO.FechaNacimiento;
                        }

                        if (!string.IsNullOrEmpty(AgenteDTO.Genero))
                            Agente.Genero = AgenteDTO.Genero;
                        if (AgenteDTO.Imagen != null)
                            Agente.Imagen = AgenteDTO.Imagen;
                        if (!string.IsNullOrEmpty(AgenteDTO.Latitud))
                            Agente.Latitud = AgenteDTO.Latitud;
                        if (!string.IsNullOrEmpty(AgenteDTO.Longitud))
                            Agente.Longitud = AgenteDTO.Longitud;

                        if (!string.IsNullOrEmpty(AgenteDTO.NumeroDocumento))
                            Agente.NumeroDocumento = AgenteDTO.NumeroDocumento;
                        if (!string.IsNullOrEmpty(AgenteDTO.PrimerApellido))
                            Agente.PrimerApellido = AgenteDTO.PrimerApellido;
                        if (!string.IsNullOrEmpty(AgenteDTO.PrimerNombre))
                            Agente.PrimerNombre = AgenteDTO.PrimerNombre;
                        if (!string.IsNullOrEmpty(AgenteDTO.SegundoApellido))
                            Agente.SegundoApellido = AgenteDTO.SegundoApellido;
                        if (!string.IsNullOrEmpty(AgenteDTO.SegundoNombre))
                            Agente.SegundoNombre = AgenteDTO.SegundoNombre;
                        if (!string.IsNullOrEmpty(AgenteDTO.Telefono))
                            Agente.Telefono = AgenteDTO.Telefono;
                        if (!string.IsNullOrEmpty(AgenteDTO.TipoDocumento))
                            Agente.TipoDocumento = AgenteDTO.TipoDocumento;

                    } // end if null
                    else
                    { Agente.Mensaje = "No hay datos"; }
                } // end if
                else
                { Agente.Mensaje = strMensajeError; }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Agente;
        }
    }
}