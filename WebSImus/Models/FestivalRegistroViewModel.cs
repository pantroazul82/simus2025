using System;

namespace WebSImus.Models
{
    // ViewModel para el formulario de Registro de Festival (pestañas Festival/Versiones)
    public class FestivalRegistroViewModel
    {
        // ID del festival (para edición)
        public int Id { get; set; }

        // Sección: Datos Básicos
        public string Nombre { get; set; }
        public int? NumeroVersiones { get; set; }
        public DateTime? FechaUltimaVersion { get; set; }
        public string Descripcion { get; set; }

        // Sección: Datos de Contacto y Observaciones
        public string CorreoContacto { get; set; }
        public string Instagram { get; set; }
        public string Facebook { get; set; }
        public string PaginaWeb { get; set; }
        public string OtroEnlace { get; set; }
        public string TelefonoCelular { get; set; }
        public string Observaciones { get; set; }

        // Pestaña activa ("festival" | "versiones") para controlar navegación en el mismo View
        public string ActiveTab { get; set; } = "festival";

        // Indica si es edición o creación
        public bool EsEdicion { get; set; } = false;
    }
}
