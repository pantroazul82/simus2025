using Microsoft.AspNet.Identity.EntityFramework;

namespace WebSImus.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public System.Data.Entity.DbSet<SM.LibreriaComun.DTO.EntidadDTO> EntidadDTOes { get; set; }

        public System.Data.Entity.DbSet<SM.LibreriaComun.DTO.EntidadesOperadoras.ConvenioDTO> ConvenioDTOes { get; set; }

        public System.Data.Entity.DbSet<SM.LibreriaComun.DTO.EntidadesOperadoras.ContenidoDTO> ContenidoDTOes { get; set; }

        public System.Data.Entity.DbSet<SM.LibreriaComun.DTO.EntidadesOperadoras.ActividadDTO> ActividadDTOes { get; set; }

        public System.Data.Entity.DbSet<SM.LibreriaComun.DTO.EntidadesOperadoras.CronogramaDTO> CronogramaDTOes { get; set; }
    }
}