using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSImus.Comunes
{
    public static class ConstantesRecursosBD
    {

        public const String SIMUS_RECURSOS_USUARIO = "SIMUS_RECURSOS_USUARIO";
        public const String SIMUS_USUARIO_TIPO_SIMUS = "SIMUS";
        public const String SIMUS_USUARIO_TIPO_CELEBRALAMUSICA = "MUSICA";
        public const String SIMUS_USUARIO_TIPO_CELEBRALADANZA = "DANZA";
        public const String SIMUS_USUARIO_TIPO_MINCULTURA = "MINCULTURA";
        public const String SIMUS_SIPA_CLAVE_DEFAULT = "12345678";
        public const String SIMUS_SIPA_COD_BOGOTA = "11";
        public const String SIMUS_SIPA_COD_AMAZONAS = "91";
        public const String SIMUS_SIPA_COD_ANTIOQUIA = "05";
        public const String SIMUS_SIPA_COD_COLOMBIA = "52";
        public const string RECURSO_PAGINA = "PAG";
        public const string RECURSO_MENU = "MENU";
        public const string CODIGO_ADMIN = "ADMIN";
        public const string CODIGO_COORDINADOR = "COOR";
        public const string CODIGO_ASESOR = "ASE";
        public const string CODIGO_APROBACION_DANZA = "DANZA";
        public const string CODIGO_APROBACION_MUSICA = "APROBADORCELEBRA";
        public const int CODIGO_ESTADO_PUBLICADO = 2;
        public const int CODIGO_ESTADO_PENDIENTE = 1;

        //Estados convocatorias
        public const int CODIGO_ESTADOCONV_PENDIENTE = 1;
        public const int CODIGO_ESTADOCONV_ACTIVA = 2;
        public const int CODIGO_ESTADOCONV_EVALUACION = 3;
        public const int CODIGO_ESTADOCONV_RECHAZADA = 4;
        public const int CODIGO_ESTADOCONV_FINALIZADA = 4;

        // //Propiedades categorias
        public const int CODIGO_CATEGORIA_ESTADOS = 1;
        public const int CODIGO_CATEGORIAS_ACTORES = 2;
        public const int CODIGO_CATEGORIAS_DOCUMENTOS = 3;
        public const int CODIGO_CATEGORIAS_INSTRUMENTOS = 4;
        public const int CODIGO_CATEGORIAS_PRIORIDAD = 5;
        public const int CODIGO_TIPO_UTILIDAD = 7;
        public const int CODIGO_TIPO_EVENTO = 8;
        public const int CODIGO_TIPO_NOTICIAS = 9;
        public const int CODIGO_TIPO_CLASIFICADOS = 10;
        public const int CODIGO_TIPO_DOCUMENTOS = 11;
        public const int CODIGO_TIPO_HERRAMIENTAS = 12;
        public const int CODIGO_TIPO_ESCENARIOS = 14;
        public const int CODIGO_TIPO_EVENTOS_PERIODICOS = 13;
        public const int CODIGO_DIAS_SEMANA = 15;
        public const int CODIGO_TIPO_OPERACION = 16;
        public const int CODIGO_TIPO_ACTIVIDAD = 24;
        public const int CODIGO_OPERA_ENTIDAD = 25;
        public const int CODIGO_TIPO_DOTACION = 26;
        public const int CODIGO_FORMATO = 27;
        public const int CODIGO_ACCESORIO = 28;
        public const int CODIGO_OTROS_ELEMETOS = 29;
        public const int CODIGO_TIPO_CONTENIDO= 30;
        public const int CODIGO_CRONOGRAMA_DOCUMENTO = 31;
        // //Actores Id 
        public const int CODIGO_ACTORES_AGENTES = 6;
        public const int CODIGO_ACTORES_ENTIDADES = 7;
        public const int CODIGO_ACTORES_AGRUPACIONES = 8;
        public const int CODIGO_ACTORES_ESCUELAS = 9;

        // //Actores
        public const string ACTORES_AGENTES = "Agentes";
        public const string ACTORES_ENTIDADES = "Entidades";
        public const string ACTORES_AGRUPACIONES = "Agrupaciones";
        public const string ACTORES_ESCUELAS = "Escuelas";

        //

        // Estado de dotacion
        public const int CODIGO_ESTADO_DOTACION_INSCRITO = 38;

        // Tipo de utilidades
        public const string NOMBRE_UTILIDAD_EVENTO = "Eventos";
        public const string NOMBRE_UTILIDAD_CLASIFICADOS = "Clasificados";
        public const string NOMBRE_UTILIDAD_NOTICIAS = "Noticias";
        public const string NOMBRE_UTILIDAD_DOCUMENTOS = "Documentos";

        //Ficha de asesoria de escuelas Clasificación

        public const string FICHA_CLASIFICACION_TECNICA = "Técnica";
        public const string FICHA_CLASIFICACION_TECNICA_INSTRUMENTAL = "TécnicaInstrumental";
        public const string FICHA_CLASIFICACION_TECNICA_EVALUACION = "EvaluaciónDelRepertorio";
        public const string FICHA_CLASIFICACION_TECNICA_COMUNICACION = "ComunicaciónYLiderazgo";

        //Ficha de asesoria de escuelas Matriz

        public const string FICHA_MATRIZ_OBSERVACION = "ObservaciónDelDesempeñoDelDocente";
        public const string FICHA_MATRIZ_PROCESO = "PercepciónDelProcesoMusical";
        
    }
}