using SM.Datos.AuditoriaData;
using SM.SIPA;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace SM.Datos.Notificaciones
{
    public class NotificacionServicio
    {
        #region Actualizar
        public static int Agregar(ART_MUSICA_MOTIVO_HISTORICO registro)
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    context.ART_MUSICA_MOTIVO_HISTORICO.Add(registro);
                    context.SaveChanges();
                  
                    return registro.Id;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

       
        #endregion

        #region Consultas
        public static ART_MUSICA_MOTIVO_HISTORICO ConsultarPorId(int Id)
        {

            var registro = new ART_MUSICA_MOTIVO_HISTORICO();

            try
            {
                using (var context = new SIPAEntities())
                {

                    return registro = context.ART_MUSICA_MOTIVO_HISTORICO.Where(x => x.Id == Id).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<ART_MUSICA_MOTIVO_HISTORICO> ConsultarPorAgrupacionId(int Id)
        {

            var registro = new List<ART_MUSICA_MOTIVO_HISTORICO>();

            try
            {
                using (var context = new SIPAEntities())
                {

                    return registro = context.ART_MUSICA_MOTIVO_HISTORICO.Where(x => x.AgrupacionId == Id).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<ART_MUSICA_MOTIVO_HISTORICO> ConsultarPorAgenteId(int Id)
        {

            var registro = new List<ART_MUSICA_MOTIVO_HISTORICO>();

            try
            {
                using (var context = new SIPAEntities())
                {

                    return registro = context.ART_MUSICA_MOTIVO_HISTORICO.Where(x => x.AgenteId == Id).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<ART_MUSICA_MOTIVO_HISTORICO> ConsultarPorEntidadId(int Id)
        {

            var registro = new List<ART_MUSICA_MOTIVO_HISTORICO>();

            try
            {
                using (var context = new SIPAEntities())
                {

                    return registro = context.ART_MUSICA_MOTIVO_HISTORICO.Where(x => x.EntidadId == Id).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<ART_MUSICA_MOTIVO_HISTORICO> ConsultarPorEscuelaId(decimal Id)
        {

            var registro = new List<ART_MUSICA_MOTIVO_HISTORICO>();

            try
            {
                using (var context = new SIPAEntities())
                {

                    return registro = context.ART_MUSICA_MOTIVO_HISTORICO.Where(x => x.EscuelaId == Id).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
