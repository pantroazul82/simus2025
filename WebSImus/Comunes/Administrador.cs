using SM.Aplicacion.Basicas;
using SM.LibreriaComun.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSImus.Comunes
{
    public class Administrador
    {
        public static List<BasicaDTO> ObtenerActorAdministrador(string tipo)
        {

            var listActor = new List<BasicaDTO>();

            if (!String.IsNullOrEmpty(tipo))
            {
                if (Convert.ToInt32(tipo) == Comunes.ConstantesRecursosBD.CODIGO_ACTORES_AGENTES)
                    listActor = CaracterizacionMusicalNeg.ConsultarAgentesAdmin();
                else if (Convert.ToInt32(tipo) == Comunes.ConstantesRecursosBD.CODIGO_ACTORES_ENTIDADES)
                    listActor = CaracterizacionMusicalNeg.ConsultarEntidadAdmin();
                else if (Convert.ToInt32(tipo) == Comunes.ConstantesRecursosBD.CODIGO_ACTORES_AGRUPACIONES)
                    listActor = CaracterizacionMusicalNeg.ConsultarAgrupacionAdmin();
                else if (Convert.ToInt32(tipo) == Comunes.ConstantesRecursosBD.CODIGO_ACTORES_ESCUELAS)
                {

                    listActor = CaracterizacionMusicalNeg.ConsultarEscuelasAdmin();
                }

            }

            return listActor;
        }

        public static List<BasicaDTO> ObtenerActor(string tipo, string UsuaroId, string Usuario)
        {

            var listActor = new List<BasicaDTO>();

            if (!String.IsNullOrEmpty(tipo))
            {
                if (Convert.ToInt32(tipo) == Comunes.ConstantesRecursosBD.CODIGO_ACTORES_AGENTES)
                    listActor = CaracterizacionMusicalNeg.ConsultarAgentes(Convert.ToInt32(UsuaroId));
                else if (Convert.ToInt32(tipo) == Comunes.ConstantesRecursosBD.CODIGO_ACTORES_ENTIDADES)
                    listActor = CaracterizacionMusicalNeg.ConsultarEntidadPorUsuarioId(Convert.ToInt32(UsuaroId));
                else if (Convert.ToInt32(tipo) == Comunes.ConstantesRecursosBD.CODIGO_ACTORES_AGRUPACIONES)
                    listActor = CaracterizacionMusicalNeg.ConsultarAgrupacionPorUsuarioId(Convert.ToInt32(UsuaroId));
                else if (Convert.ToInt32(tipo) == Comunes.ConstantesRecursosBD.CODIGO_ACTORES_ESCUELAS)
                {
                    decimal UsuarioSipaId = SM.Aplicacion.Modulo_Usuarios.UsuarioLogica.ObtenerUsuarioSipaId(Usuario);
                    listActor = CaracterizacionMusicalNeg.ConsultarEscuelasPorUsuarioId(UsuarioSipaId);
                }

            }

            return listActor;
        }
    }
}