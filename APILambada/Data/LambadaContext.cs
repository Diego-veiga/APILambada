using APILambada.Data.ConfigurationModel;
using APILambada.Model;
using Microsoft.EntityFrameworkCore;

namespace APILambada.Data
{
    public class LambadaContext :DbContext 
    {
        public DbSet<Tecnico> Tecnico { get; set; }
        public DbSet<Lambada> Lambada { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public LambadaContext(DbContextOptions<LambadaContext> options):base(options)
        {
           

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TencnicoConfiguration());
            modelBuilder.ApplyConfiguration(new LambadaConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
