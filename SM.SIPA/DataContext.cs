using System.Data.Entity;


namespace SM.SIPA
{
    public class DataContext : DbContext
    {
        public DataContext()
           // : base(@"Data Source=mctucano\dessql2012; initial catalog=SIMUS; persist security info=True;user id=sinictest;password=123;")
            : base("name=SIPAEntities")
        { }
       public DbSet<ADM_USUARIOS> ADM_USUARIOS { get; set; }
        //public virtual DbSet<ADM_USUARIOS> ADM_USUARIOS { get; set; }
     
    }
}
