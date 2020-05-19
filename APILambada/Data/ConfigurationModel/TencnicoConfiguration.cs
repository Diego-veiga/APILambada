using APILambada.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APILambada.Data.ConfigurationModel
{
    public class TencnicoConfiguration : IEntityTypeConfiguration<Tecnico>
    {
        public void Configure(EntityTypeBuilder<Tecnico> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.DataNascimento).IsRequired();
            builder.Property(t => t.Nome).IsRequired().HasMaxLength(25);
            builder.HasMany(t => t.Lambadas).WithOne(l => l.Tecnico);
        }
    }
}
