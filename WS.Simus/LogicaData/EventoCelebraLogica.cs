using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SM.Aplicacion.Eventos;

namespace WS.Simus.LogicaData
{
    public class EventoCelebraLogica
    {

        public static int ConsultarMunicipiosParticipantesDanza()
        {
            int intResultado = 0;
            try
            {
                intResultado = EventosNeg.CantidadMunicipioParticipantesDanza();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return intResultado;
        }

        public static int ConsultarDepartamentosParticipantesDanza()
        {
            int intResultado = 0;
            try
            {
                intResultado = EventosNeg.CantidadDepartamentoParticipantesDanza();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return intResultado;
        }

        public static int ConsultarEventosDanza()
        {
            int intResultado = 0;
            try
            {
                intResultado = EventosNeg.ConsultarCantidadEventosDanza();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return intResultado;
        }

        public static int ConsultarMunicipiosParticipantes()
        {
            int intResultado = 0;
            try
            {
                intResultado = ArtistasNeg.CantidadMunicipioParticipantes();
       
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return intResultado;
        }

        public static int ConsultarCantidadArtistas()
        {
            int intResultado = 0;
            try
            {
                intResultado = ArtistasNeg.ConsultarCantidadArtistas();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return intResultado;
        }

        public static int ConsultarCantidadConciertos()
        {
            int intResultado = 0;
            try
            {
                intResultado = ArtistasNeg.ConsultarCantidadConciertos();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return intResultado;
        }

        public static int ConsultarCantidadGrupos()
        {
            int intResultado = 0;
            try
            {
                intResultado = ArtistasNeg.ConsultarCantidadGrupos();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return intResultado;
        }
    }
}