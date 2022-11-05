using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Data.Configuration
{
    public class RazaConfig : IEntityTypeConfiguration<Raza>
    {
        public void Configure(EntityTypeBuilder<Raza> builder)
        {
            builder.Property(p => p.NombreRaza).IsRequired().HasMaxLength(100);
            builder.Property(p => p.imagen).IsRequired().HasMaxLength(1000);

        }
    }
}
