using APILambada.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APILambada.Data.ConfigurationModel
{
    public class LambadaConfiguration : IEntityTypeConfiguration<Lambada>
    {
        public void Configure(EntityTypeBuilder<Lambada> builder)
        {
            builder.HasKey(l => l.Id);
            builder.Property(l => l.Titulo).IsRequired().HasMaxLength(50);
            builder.Property(l => l.Descricao).IsRequired();
            builder.Property(l => l.DataLambada).IsRequired();
            builder.HasOne(l => l.Tecnico).WithMany(t => t.Lambadas);
        }
    }
}
