using APILambada.Model;
using Microsoft.EntityFrameworkCore;

namespace APILambada.Data
{
    public class LambadaContext :DbContext 
    {
        public DbSet<Tecnico> Tecnico { get; set; }
        public DbSet<Lambada> Lambada { get; set; }
        public LambadaContext(DbContextOptions<LambadaContext> options):base(options)
        {
           

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
