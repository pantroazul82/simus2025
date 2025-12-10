using SM.Datos.DTO.Servicios;
using SM.SIPA;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Datos.Servicios
{
    public class ParticipacionServicio
    {

        public static void AgregarParticipacion(ART_MUSICA_PARTICIPACION registro)
        {
            try
            {
                using (var context = new SIPAEntities())
                {
                    context.ART_MUSICA_PARTICIPACION.Add(registro);
                    context.SaveChanges();


                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<ParticipacionResultadoDTO> ConsultarParticipacionPorConvocatoriaId(int ConvocatoriaId)
        {

            var listResultado = new List<ParticipacionResultadoDTO>();

            try
            {
                using (var context = new SIPAEntities())
                {


                    listResultado = context.Database.SqlQuery<ParticipacionResultadoDTO>(@"EXEC ART_MUSICA_LISTADO_PARTICIPCION @ConvocatoriaId", new SqlParameter("ConvocatoriaId", ConvocatoriaId)).ToList();

                }
                return listResultado;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<ParticipacionResultadoDTO> ConsultarConvocatoriasPorUsuarioId(int UsuarioId)
        {

            var listResultado = new List<ParticipacionResultadoDTO>();

            try
            {
                using (var context = new SIPAEntities())
                {


                    listResultado = context.Database.SqlQuery<ParticipacionResultadoDTO>(@"EXEC ART_MUSICA_LISTADO_MIS_PARTICIPCION @UsuarioId", new SqlParameter("UsuarioId", UsuarioId)).ToList();

                }
                return listResultado;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<ParticipacionResultadoDTO> ConsultarMisParticipaciones(int usuarioId)
        {

            var listResultado = new List<ParticipacionResultadoDTO>();

            try
            {
                using (var context = new SIPAEntities())
                {


                    listResultado = context.Database.SqlQuery<ParticipacionResultadoDTO>(@"EXEC ART_MUSICA_MIS_PARTICIPACIONES @UsuarioId", new SqlParameter("UsuarioId", usuarioId)).ToList();

                }
                return listResultado;

            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
