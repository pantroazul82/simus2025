using SM.LibreriaComun.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebSImus.Models;

namespace WebSImus.Translator
{
    public class TranslatorHomeActores
    {
        public static List<AgrupacionHomeModels> AgrupacionesHome(List<AgrupacionHomeDataDTO> objfrom)
        {
            var objTo = new List<AgrupacionHomeModels>();
            if (objfrom != null)
            {
                foreach (var item in objfrom)
                {
                    var datos = new AgrupacionHomeModels();
                    datos.ID = item.ID;
                    datos.CodigoDepartamento = item.CodigoDepartamento;
                    datos.CodigoMunicipio = item.CodigoMunicipio;
                    datos.CodigoPais = item.CodigoPais;
                    datos.Imagen = item.Imagen;
                    datos.PaginaWeb = item.PaginaWeb;
                    datos.Departamento = item.Departamento;
                    datos.Pais = item.Pais;
                    datos.Municipio = item.Municipio;
                    datos.Nombres = item.Nombres;
                    datos.PerfilFacebook = item.PerfilFacebook;
                    datos.PerfilSoundCloud = item.PerfilSoundCloud;
                    datos.PerfilTwitter = item.PerfilTwitter;
                    datos.CanalYoutube = item.CanalYoutube;
                    datos.Genero = item.Genero;
                    datos.Tipo = item.Tipo;
                    datos.TipoAgrupacionId = item.TipoAgrupacionId;
                    datos.verMas = "/Home/DetalleAgrupacion/" + item.ID.ToString();
                    datos.rutaFoto = "";
                    if (item.Imagen != null)
                        datos.Imagen = item.Imagen;
                    else
                        datos.rutaFoto = "../img/agrupa_generica.jpg";
                    objTo.Add(datos);
                }
            }
            return objTo;
        }

        public static List<ActoresHomeModels> AgentesHome(List<ActorHomeDataDTO> objfrom)
        {
            var objTo = new List<ActoresHomeModels>();
            if (objfrom != null)
            {
                foreach (var item in objfrom)
                {
                    var datos = new ActoresHomeModels();
                    datos.ID = item.ID;
                    datos.CodigoDepartamento = item.CodigoDepartamento;
                    datos.CodigoMunicipio = item.CodigoMunicipio;
                    datos.CodigoPais = item.CodigoPais;
                    datos.Imagen = item.Imagen;
                    datos.PaginaWeb = item.PaginaWeb;
                    datos.Departamento = item.Departamento;
                    datos.Pais = item.Pais;
                    datos.Municipio = item.Municipio;
                    datos.Nombres = item.Nombres;
                    datos.PerfilFacebook = item.PerfilFacebook;
                    datos.PerfilSoundCloud = item.PerfilSoundCloud;
                    datos.PerfilTwitter = item.PerfilTwitter;
                    datos.CanalYoutube = item.CanalYoutube;
                    datos.Dato = item.Dato;
                    datos.Tipo = item.Tipo;
                    datos.TipoId = item.TipoId;
                    datos.verMas = "../Home/DetalleAgente/" + item.ID.ToString();
                    datos.rutaFoto = "";
                    if (item.Imagen != null)
                        datos.Imagen = item.Imagen;
                    else
                        datos.rutaFoto = "../img/agente_generico.png";
                    objTo.Add(datos);
                }
            }
            return objTo;
        }

        public static List<ActoresHomeModels> EscenariosHome(List<ActorHomeDataDTO> objfrom, string ficha)
        {
            var objTo = new List<ActoresHomeModels>();
            if (objfrom != null)
            {
                foreach (var item in objfrom)
                {
                    var datos = new ActoresHomeModels();
                    datos.ID = item.ID;
                    datos.CodigoDepartamento = item.CodigoDepartamento;
                    datos.CodigoMunicipio = item.CodigoMunicipio;
                    datos.CodigoPais = item.CodigoPais;
                    datos.Imagen = item.Imagen;
                    datos.PaginaWeb = item.PaginaWeb;
                    datos.Departamento = item.Departamento;
                    datos.Pais = item.Pais;
                    datos.Municipio = item.Municipio;
                    datos.Nombres = item.Nombres;
                     datos.Dato = item.Dato;
                    datos.Tipo = item.Tipo;
                    datos.TipoId = item.TipoId;
                    datos.verMas = "../Actores/" + ficha + "/" + item.ID.ToString();
                    datos.rutaFoto = "";
                    if (item.Imagen != null)
                        datos.Imagen = item.Imagen;
                    else
                        datos.rutaFoto = "../img/escenario_generico.jpg";
                    objTo.Add(datos);
                }
            }
            return objTo;
        }


        public static List<ActoresHomeModels> EntidadHome(List<ActorHomeDataDTO> objfrom)
        {
            var objTo = new List<ActoresHomeModels>();
            if (objfrom != null)
            {
                foreach (var item in objfrom)
                {
                    var datos = new ActoresHomeModels();
                    datos.ID = item.ID;
                    datos.CodigoDepartamento = item.CodigoDepartamento;
                    datos.CodigoMunicipio = item.CodigoMunicipio;
                    datos.CodigoPais = item.CodigoPais;
                    datos.Imagen = item.Imagen;
                    datos.PaginaWeb = item.PaginaWeb;
                    datos.Departamento = item.Departamento;
                    datos.Pais = item.Pais;
                    datos.Municipio = item.Municipio;
                    datos.Nombres = item.Nombres;
                    datos.PerfilFacebook = item.PerfilFacebook;
                    datos.PerfilSoundCloud = item.PerfilSoundCloud;
                    datos.PerfilTwitter = item.PerfilTwitter;
                    datos.CanalYoutube = item.CanalYoutube;
                    datos.Dato = item.Dato;
                    datos.Tipo = item.Tipo;
                    datos.TipoId = item.TipoId;
                    datos.verMas = "../Home/DetalleEntidad/" + item.ID.ToString();
                    datos.rutaFoto = "";
                    if (item.Imagen != null)
                        datos.Imagen = item.Imagen;
                    else
                        datos.rutaFoto = "../img/entidad_generica.jpg";
                    objTo.Add(datos);
                }
            }
            return objTo;
        }

        public static List<ActoresHomeModels> EscuelasHome(List<ActorHomeDataDTO> objfrom)
        {
            var objTo = new List<ActoresHomeModels>();
            if (objfrom != null)
            {
                foreach (var item in objfrom)
                {
                    var datos = new ActoresHomeModels();
                    datos.ID = item.ID;
                    datos.CodigoDepartamento = item.CodigoDepartamento;
                    datos.CodigoMunicipio = item.CodigoMunicipio;
                    datos.CodigoPais = item.CodigoPais;
                    datos.Imagen = item.Imagen;
                    datos.PaginaWeb = item.PaginaWeb;
                    datos.Departamento = item.Departamento;
                    datos.Pais = item.Pais;
                    datos.Municipio = item.Municipio;
                    datos.Nombres = item.Nombres;
                    datos.PerfilFacebook = item.PerfilFacebook;
                    datos.PerfilSoundCloud = item.PerfilSoundCloud;
                    datos.PerfilTwitter = item.PerfilTwitter;
                    datos.CanalYoutube = item.CanalYoutube;
                    datos.Dato = item.Dato;
                    datos.Tipo = item.Tipo;
                    datos.TipoId = item.TipoId;
                    datos.verMas = "../Home/Ficha/" + item.ID.ToString();
                    datos.rutaFoto = "";
                    if (item.Imagen != null)
                        datos.Imagen = item.Imagen;
                    else
                        datos.rutaFoto = "../img/generica_escuelas.jpg";
                    objTo.Add(datos);
                }
            }
            return objTo;
        }
    }
}