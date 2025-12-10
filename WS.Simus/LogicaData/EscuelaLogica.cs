using SM.WSDatos.Escuelas;
using SM.WSDatos.WSDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WS.Simus.Data;

namespace WS.Simus.LogicaData
{
    public class EscuelaLogica
    {
        public static List<EscuelaData> ConsultEscuelas(string usuario, string contrasena)
        {
            List<EscuelaData> listEscuelas = new List<EscuelaData>();
            List<EscuelaDTO> listEscuelasDTO = new List<EscuelaDTO>();
            try
            {
                string strMensajeError = "";
                listEscuelasDTO = EscuelasServicio.ConsultarEscuelas(usuario, contrasena, out strMensajeError);

                if (String.IsNullOrEmpty(strMensajeError))
                {
                    if (listEscuelasDTO != null)
                    {
                        if (listEscuelasDTO.Count > 0)
                        {
                            foreach (var item in listEscuelasDTO)
                            {
                                EscuelaData datos = new EscuelaData();
                                datos.EscuelaId = item.EscuelaId;
                                if (!string.IsNullOrEmpty(item.CodigoMunicipio))
                                    datos.CodigoMunicipio = item.CodigoMunicipio;
                                if (!string.IsNullOrEmpty(item.NombreEscuela))
                                    datos.NombreEscuela = item.NombreEscuela;
                                if (!string.IsNullOrEmpty(item.Direccion))
                                    datos.Direccion = item.Direccion;
                                if (!string.IsNullOrEmpty(item.Telefono))
                                    datos.Telefono = item.Telefono;
                                if (!string.IsNullOrEmpty(item.Resena))
                                    datos.Resena = item.Resena;
                                if (!string.IsNullOrEmpty(item.Area))
                                    datos.Area = item.Area;
                                if (!string.IsNullOrEmpty(item.SitioWeb))
                                    datos.SitioWeb = item.SitioWeb;
                                if (!string.IsNullOrEmpty(item.CorreoElectronicoEscuela))
                                    datos.CorreoElectronicoEscuela = item.CorreoElectronicoEscuela;

                                datos.FechaActualizacion = item.FechaActualizacion;
                                if (item.AnoConstitucion != 0)
                                    datos.AnoConstitucion = item.AnoConstitucion;
                                if (!string.IsNullOrEmpty(item.Nit))
                                    datos.Nit = item.Nit;
                              
                             
                                if (!string.IsNullOrEmpty(item.NombreContacto))
                                    datos.NombreContacto = item.NombreContacto;
                                
                                if (!string.IsNullOrEmpty(item.TelefonoContacto))
                                    datos.TelefonoContacto = item.TelefonoContacto;
                                if (!string.IsNullOrEmpty(item.CargoContacto))
                                    datos.CargoContacto = item.CargoContacto;

                                if (!string.IsNullOrEmpty(item.CorreoElectronicoContacto))
                                    datos.CorreoElectronicoContacto = item.CorreoElectronicoContacto;
                               

                                listEscuelas.Add(datos);
                            } // endforeach
                        } // end If list.count> 0
                        else
                        {
                            EscuelaData datos = new EscuelaData();
                            datos.Mensaje = "No hay datos";
                            listEscuelas.Add(datos);

                        }

                    } //if (listAgenteDTO != null) 
                    else
                    {
                        EscuelaData datos = new EscuelaData();
                        datos.Mensaje = "No hay datos";
                        listEscuelas.Add(datos);

                    }

                }// end if
                else
                {
                    EscuelaData datos = new EscuelaData();
                    datos.Mensaje = strMensajeError;
                    listEscuelas.Add(datos);

                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listEscuelas;
        }

        public static List<EscuelaData>  ConsultarEscuelasPorRangoFechas(string usuario, string contrasena,  DateTime FechaInicio, DateTime FechaFinal)
        {
            List<EscuelaData> listEscuelas = new List<EscuelaData>();
            List<EscuelaDTO> listEscuelasDTO = new List<EscuelaDTO>();
            try
            {
                string strMensajeError = "";
                listEscuelasDTO = EscuelasServicio.ConsultarEscuelasPorRangoFechas(usuario, contrasena, FechaInicio, FechaFinal, out strMensajeError);

                if (String.IsNullOrEmpty(strMensajeError))
                {
                    if (listEscuelasDTO != null)
                    {
                        if (listEscuelasDTO.Count > 0)
                        {
                            foreach (var item in listEscuelasDTO)
                            {
                                EscuelaData datos = new EscuelaData();
                                datos.EscuelaId = item.EscuelaId;
                                if (!string.IsNullOrEmpty(item.CodigoMunicipio))
                                    datos.CodigoMunicipio = item.CodigoMunicipio;
                                if (!string.IsNullOrEmpty(item.NombreEscuela))
                                    datos.NombreEscuela = item.NombreEscuela;
                                if (!string.IsNullOrEmpty(item.Direccion))
                                    datos.Direccion = item.Direccion;
                                if (!string.IsNullOrEmpty(item.Telefono))
                                    datos.Telefono = item.Telefono;
                                if (!string.IsNullOrEmpty(item.Resena))
                                    datos.Resena = item.Resena;
                                if (!string.IsNullOrEmpty(item.Area))
                                    datos.Area = item.Area;
                                if (!string.IsNullOrEmpty(item.SitioWeb))
                                    datos.SitioWeb = item.SitioWeb;
                                if (!string.IsNullOrEmpty(item.CorreoElectronicoEscuela))
                                    datos.CorreoElectronicoEscuela = item.CorreoElectronicoEscuela;

                                datos.FechaActualizacion = item.FechaActualizacion;
                                if (item.AnoConstitucion != 0)
                                    datos.AnoConstitucion = item.AnoConstitucion;
                                if (!string.IsNullOrEmpty(item.Nit))
                                    datos.Nit = item.Nit;


                                if (!string.IsNullOrEmpty(item.NombreContacto))
                                    datos.NombreContacto = item.NombreContacto;

                                if (!string.IsNullOrEmpty(item.TelefonoContacto))
                                    datos.TelefonoContacto = item.TelefonoContacto;
                                if (!string.IsNullOrEmpty(item.CargoContacto))
                                    datos.CargoContacto = item.CargoContacto;

                                if (!string.IsNullOrEmpty(item.CorreoElectronicoContacto))
                                    datos.CorreoElectronicoContacto = item.CorreoElectronicoContacto;


                                listEscuelas.Add(datos);
                            } // endforeach
                        } // end If list.count> 0
                        else
                        {
                            EscuelaData datos = new EscuelaData();
                            datos.Mensaje = "No hay datos";
                            listEscuelas.Add(datos);

                        }

                    } //if (listAgenteDTO != null) 
                    else
                    {
                        EscuelaData datos = new EscuelaData();
                        datos.Mensaje = "No hay datos";
                        listEscuelas.Add(datos);

                    }

                }// end if
                else
                {
                    EscuelaData datos = new EscuelaData();
                    datos.Mensaje = strMensajeError;
                    listEscuelas.Add(datos);

                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listEscuelas;
        }

        public static EscuelaData ConsultarEscuelasPorId(string usuario, string contrasena, int EscuelaId)
        {
            EscuelaData Escuela = new EscuelaData();
            EscuelaDTO escuelaDTO = new EscuelaDTO();
            try
            {
                string strMensajeError = "";
                escuelaDTO = EscuelasServicio.ConsultarEscuelasPorId(usuario, contrasena, EscuelaId, out strMensajeError);

                if (String.IsNullOrEmpty(strMensajeError))
                {
                    if (escuelaDTO != null)
                    {
                        Escuela.EscuelaId = escuelaDTO.EscuelaId;
                        if (!string.IsNullOrEmpty(escuelaDTO.CodigoMunicipio))
                            Escuela.CodigoMunicipio = escuelaDTO.CodigoMunicipio;
                        if (!string.IsNullOrEmpty(escuelaDTO.NombreEscuela))
                            Escuela.NombreEscuela = escuelaDTO.NombreEscuela;
                        if (!string.IsNullOrEmpty(escuelaDTO.Direccion))
                            Escuela.Direccion = escuelaDTO.Direccion;
                        if (!string.IsNullOrEmpty(escuelaDTO.Telefono))
                            Escuela.Telefono = escuelaDTO.Telefono;
                        if (!string.IsNullOrEmpty(escuelaDTO.Resena))
                            Escuela.Resena = escuelaDTO.Resena;
                        if (!string.IsNullOrEmpty(escuelaDTO.Area))
                            Escuela.Area = escuelaDTO.Area;
                        if (!string.IsNullOrEmpty(escuelaDTO.SitioWeb))
                            Escuela.SitioWeb = escuelaDTO.SitioWeb;
                        if (!string.IsNullOrEmpty(escuelaDTO.CorreoElectronicoEscuela))
                            Escuela.CorreoElectronicoEscuela = escuelaDTO.CorreoElectronicoEscuela;

                        Escuela.FechaActualizacion = escuelaDTO.FechaActualizacion;
                        if (escuelaDTO.AnoConstitucion != 0)
                            Escuela.AnoConstitucion = escuelaDTO.AnoConstitucion;
                        if (!string.IsNullOrEmpty(escuelaDTO.Nit))
                            Escuela.Nit = escuelaDTO.Nit;


                        if (!string.IsNullOrEmpty(escuelaDTO.NombreContacto))
                            Escuela.NombreContacto = escuelaDTO.NombreContacto;

                        if (!string.IsNullOrEmpty(escuelaDTO.TelefonoContacto))
                            Escuela.TelefonoContacto = escuelaDTO.TelefonoContacto;
                        if (!string.IsNullOrEmpty(escuelaDTO.CargoContacto))
                            Escuela.CargoContacto = escuelaDTO.CargoContacto;

                        if (!string.IsNullOrEmpty(escuelaDTO.CorreoElectronicoContacto))
                            Escuela.CorreoElectronicoContacto = escuelaDTO.CorreoElectronicoContacto;

                    } // end if null
                    else
                    { Escuela.Mensaje = "No hay datos"; }
                } // end if
                else
                { Escuela.Mensaje = strMensajeError; }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Escuela;
        }

        public static EscuelaData ConsultarEscuelasPorNit(string usuario, string contrasena, int Nit)
        {
            EscuelaData Escuela = new EscuelaData();
            EscuelaDTO escuelaDTO = new EscuelaDTO();
            try
            {
                string strMensajeError = "";
                escuelaDTO = EscuelasServicio.ConsultarEscuelasPorNit(usuario, contrasena, Nit, out strMensajeError);

                if (String.IsNullOrEmpty(strMensajeError))
                {
                    if (escuelaDTO != null)
                    {
                        Escuela.EscuelaId = escuelaDTO.EscuelaId;
                        if (!string.IsNullOrEmpty(escuelaDTO.CodigoMunicipio))
                            Escuela.CodigoMunicipio = escuelaDTO.CodigoMunicipio;
                        if (!string.IsNullOrEmpty(escuelaDTO.NombreEscuela))
                            Escuela.NombreEscuela = escuelaDTO.NombreEscuela;
                        if (!string.IsNullOrEmpty(escuelaDTO.Direccion))
                            Escuela.Direccion = escuelaDTO.Direccion;
                        if (!string.IsNullOrEmpty(escuelaDTO.Telefono))
                            Escuela.Telefono = escuelaDTO.Telefono;
                        if (!string.IsNullOrEmpty(escuelaDTO.Resena))
                            Escuela.Resena = escuelaDTO.Resena;
                        if (!string.IsNullOrEmpty(escuelaDTO.Area))
                            Escuela.Area = escuelaDTO.Area;
                        if (!string.IsNullOrEmpty(escuelaDTO.SitioWeb))
                            Escuela.SitioWeb = escuelaDTO.SitioWeb;
                        if (!string.IsNullOrEmpty(escuelaDTO.CorreoElectronicoEscuela))
                            Escuela.CorreoElectronicoEscuela = escuelaDTO.CorreoElectronicoEscuela;

                        Escuela.FechaActualizacion = escuelaDTO.FechaActualizacion;
                        if (escuelaDTO.AnoConstitucion != 0)
                            Escuela.AnoConstitucion = escuelaDTO.AnoConstitucion;
                        if (!string.IsNullOrEmpty(escuelaDTO.Nit))
                            Escuela.Nit = escuelaDTO.Nit;


                        if (!string.IsNullOrEmpty(escuelaDTO.NombreContacto))
                            Escuela.NombreContacto = escuelaDTO.NombreContacto;

                        if (!string.IsNullOrEmpty(escuelaDTO.TelefonoContacto))
                            Escuela.TelefonoContacto = escuelaDTO.TelefonoContacto;
                        if (!string.IsNullOrEmpty(escuelaDTO.CargoContacto))
                            Escuela.CargoContacto = escuelaDTO.CargoContacto;

                        if (!string.IsNullOrEmpty(escuelaDTO.CorreoElectronicoContacto))
                            Escuela.CorreoElectronicoContacto = escuelaDTO.CorreoElectronicoContacto;

                    } // end if null
                    else
                    { Escuela.Mensaje = "No hay datos"; }
                } // end if
                else
                { Escuela.Mensaje = strMensajeError; }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Escuela;
        }
    }
}