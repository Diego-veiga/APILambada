using APILambada.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APILambada.Data.ConfigurationModel
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuarios>
    {
        public void Configure(EntityTypeBuilder<Usuarios> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Senha).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Role).IsRequired().HasMaxLength(15);
        }
    }
}
