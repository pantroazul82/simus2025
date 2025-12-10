using SM.Aplicacion.Agrupacion;
using SM.Aplicacion.Notificacion;
using SM.LibreriaComun.DTO.Certificacion;
using SM.LibreriaComun.DTO.Notificacion;
using System;

namespace WebSImus.Translator
{
    public class TranslatorCertificacion
    {
        public static CertificacionDTO ObtenerModeloactor(int Id, string modulo)
        {
            var model = new CertificacionDTO();
            try
            {

                if (modulo == Comunes.ConstantesRecursosBD.ACTORES_AGENTES)
                    model = ActoresNeg.ConsultarCertificacionAgentes(Id);
                else if (modulo == Comunes.ConstantesRecursosBD.ACTORES_AGRUPACIONES)
                    model = ActoresNeg.ConsultarCertificacionAgrupacion(Id);
                else if (modulo == Comunes.ConstantesRecursosBD.ACTORES_ENTIDADES)
                    model = ActoresNeg.ConsultarCertificacionEntidad(Id);
                else if (modulo == Comunes.ConstantesRecursosBD.ACTORES_ESCUELAS)
                    model = ActoresNeg.ConsultarCertificacionEscuelas(Id);

                if (model != null)
                {
                    model.Dia = DateTime.Today.Day.ToString();
                    model.Mes = DateTime.Today.ToString("MMMM");
                    model.Year = DateTime.Today.Year.ToString();
                    model.FechaActualizacion = model.datFechaActualizacion.ToString("dd/MM/yyyy");
                    model.FechaRegistro = model.datFechaRegistro.ToString("dd/MM/yyyy");
                    model.Modulo = modulo;
                }
                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void AgregarHistoricoCertificacion(int actorId, string modulo, int estadoId, string estado, string nombreUsuario, int UsuarioId)
        {
            var registro = new NotificacionDTO
                {
                    EstadoId = estadoId,
                    Modulo = modulo,
                    RegistroId = actorId,
                    NombreEstado = estado,
                    NombreUsuario = nombreUsuario,
                    UsuarioId = UsuarioId,
                    Tipo = "Certificación",
                    Motivo = ""
                };

           
            NotificacionNeg.Crear(registro);

        }

    }
}