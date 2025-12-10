using System.Collections.Generic;
using System.Linq;
using SM.Datos.DTO;
using SM.SIPA;
using System.Data.SqlClient;
using System;
using System.ComponentModel.DataAnnotations;


namespace SM.Datos.AuditoriaData
{
    /// <summary>
    /// Interface para crear la auditoria del SIMUS
    /// </summary>
    public interface IRegistroOperacionServicio
    {
        ART_MUSICA_REGISTRO_OPERACION Obtener(int RegistroId);

        void Crear(ART_MUSICA_REGISTRO_OPERACION registro);
    }

    /// <summary>
    /// Clase de datos para crear y consultar registro de la auditoria
    /// </summary>
    public class RegistroOperacionServicio : IRegistroOperacionServicio
    {
        #region Constructor

        //public RegistroOperacionServicio(IRepositoryAsync<RegistroOperacion> repository, IUnitOfWorkAsync unitOfWork)
        //    : base(repository, unitOfWork)
        //{
        //}

        #endregion

        #region Metodos

        public ART_MUSICA_REGISTRO_OPERACION Obtener(int RegistroId)
        {
            var registro = new ART_MUSICA_REGISTRO_OPERACION();
            try
            {
                using (var context = new SIPAEntities())
                {

                    registro = context.ART_MUSICA_REGISTRO_OPERACION.Where(x => x.Id == RegistroId).FirstOrDefault();

                }
                return registro;

            }
            catch (Exception)
            {
                throw;
            }
        }




        public void Crear(ART_MUSICA_REGISTRO_OPERACION registro)
        {
            try
            {

                using (var context = new SIPAEntities())
                {
                    context.ART_MUSICA_REGISTRO_OPERACION.Add(registro);
                    context.SaveChanges();
                }



            }
            catch (Exception)
            {
                throw;
            }

        }

        #endregion
    }

    public enum CategoriaRegistroOperacion
    {
        [Display(Name = "Agentes")]
        Agente = 1,
        [Display(Name = "Roles")]
        Roles = 2,
        [Display(Name = "Usuario")]
        Usuario = 12,
        [Display(Name = "Recursos")]
        Recursos = 3,
        [Display(Name = "Escuelas")]
        Escuelas = 4,
        [Display(Name = "Escuelas Música - Institucionalidad")]
        EscuelasInstitucionalidad = 5,
        [Display(Name = "Escuelas Música - Infraestructura")]
        EscuelasInfraestructura = 6,
        [Display(Name = "Escuelas Música - Formación")]
        EscuelasFormación = 7,
        [Display(Name = "Escuelas Música - Participación")]
        EscuelasParticipación = 8,
        [Display(Name = "Escuelas Música - Producción")]
        EscuelasProducción = 9,
        [Display(Name = "Entidades")]
        Entidades = 10,
        [Display(Name = "Agrupación")]
        Agrupación = 11,
        [Display(Name = "Escuelas Música - Documentos")]
        EscuelasDocumentos = 12,
        [Display(Name = "Documentos")]
        Documentos = 13,
        [Display(Name = "Servicios")]
        Servicios = 14,
        [Display(Name = "Herramientas")]
        Herramientas = 15,
        [Display(Name = "Eventos")]
        Eventos = 16,
        [Display(Name = "ConvocatoriaEstimulos")]
        ConvocatoriaEstimulos = 17,
        [Display(Name = "EventosCelebraMusica")]
        EventosCelebraMusica = 18,
        [Display(Name = "Notificacion")]
        Notificacion = 19

    }
}
