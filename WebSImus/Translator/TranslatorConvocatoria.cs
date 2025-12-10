using SM.LibreriaComun.DTO.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebSImus.Models;

namespace WebSImus.Translator
{
    public class TranslatorConvocatoria
    {
        public static EstimuloModel TranslatorConvocatoriaEstimuloModel(ConvocatoriaEstimuloDTO objfrom)
        {
            var objto = new EstimuloModel();
            objto.Id = objfrom.Id;
            objto.EstadoId = objfrom.EstadoId.ToString();
            objto.Titulo = objfrom.Titulo;
            objto.EstadoId = objfrom.EstadoId.ToString();
            objto.FechaApertura = objfrom.FechaApertura.ToString("yyyy-MM-dd");
            objto.FechaCierre = objfrom.FechaCierre.ToString("yyyy-MM-dd");
            objto.FechaPublicacion = objfrom.FechaPublicacion.ToString("yyyy-MM-dd");
            objto.Periodo = objfrom.Periodo.ToString();
            if (objfrom.DocumentoId > 0)
            {
                objto.DocumentoId = objfrom.DocumentoId;
                objto.documentoArchivo = TranslatorDocumento.ConsultaDocumento(objfrom.DocumentoId);
            }
            else
                objto.DocumentoId = 0;
            return objto;
        }
        public static ConvocatoriaModels TranslatorConvocatoriaModel(ConvocatoriaNuevoDTO objfrom)
        {
            var objto = new ConvocatoriaModels();
            objto.ConvocatoriaId = objfrom.Id;
            objto.ArtMusicaUsuarioId = objfrom.UsuarioId;
            objto.Descripcion = objfrom.Descripcion;
            objto.EstadoId = objfrom.EstadoId.ToString();
            objto.FechaFin = objfrom.FechaFin.ToString("yyyy-MM-dd");
            objto.FechaInicio = objfrom.FechaInicio.ToString("yyyy-MM-dd");
            objto.RelacionadoA = objfrom.RelacionadoA;
            objto.Tipo = objfrom.TipoActorId.ToString();
            objto.TipoActor = objfrom.ActorId.ToString();
            objto.Titulo = objfrom.Titulo;
            objto.NombreEstado = objfrom.Estado;
            if (objfrom.DocumentoId > 0)
            {
                objto.DocumentoId = objfrom.DocumentoId;
                objto.documentoArchivo = TranslatorDocumento.ConsultaDocumento(objfrom.DocumentoId);
            }
            else
                objto.DocumentoId = 0;
            return objto;
        }

        public static ConvocatoriaDetalleModels TranslatorConvocatoriaDetalle(ConvocatoriaNuevoDTO objfrom)
        {
            var objto = new ConvocatoriaDetalleModels();
            objto.EsDotacion = false;
            objto.ConvocatoriaId = objfrom.Id;
            objto.Descripcion = objfrom.Descripcion;
            objto.EstadoId = objfrom.EstadoId.ToString();
            objto.FechaFin = objfrom.FechaFin.ToString("yyyy-MM-dd");
            objto.FechaInicio = objfrom.FechaInicio.ToString("yyyy-MM-dd");
            objto.RelacionadoA = objfrom.RelacionadoA;
            objto.Tipo = objfrom.TipoActorId.ToString();
            objto.TipoActor = objfrom.ActorId.ToString();
            objto.Titulo = objfrom.Titulo;
            objto.NombreEstado = objfrom.Estado;
            objto.documentoId = objfrom.DocumentoId;
            objto.NombreTipo = SM.Aplicacion.Servicios.ConvocatoriaNeg.ObtenerNombreParamentro(objfrom.TipoActorId);
            if (objfrom.DocumentoId > 0)
            {
                objto.DocumentoId = objfrom.DocumentoId;
                objto.documentoArchivo = TranslatorDocumento.ConsultaDocumento(objfrom.DocumentoId);
            }
            else
                objto.DocumentoId = 0;
            return objto;
        }

        public static DotacionModel TranslatorDotacion(DotacionDTO objfrom)
        {
            var objto = new DotacionModel();
            objto.Apellido = objfrom.Apellido;
            objto.Cargo = objfrom.Cargo;
            objto.Celular = objfrom.Celular;
            objto.ConvocatoriaId = (int)objfrom.ConvocatoriaId;
            objto.Email = objfrom.Email;
            objto.EntidadId = objfrom.EntidadId;
            objto.EscuelaId = objfrom.EscuelaId.ToString();
            objto.Id = objfrom.Id;
            objto.Identificacion = objfrom.Identificacion;
            objto.Nombre = objfrom.Nombre;
            objto.Telefono = objfrom.Telefono;
            return objto;
        }
    }
}