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
    public class MascotaConfig : IEntityTypeConfiguration<Mascota>
    {
        public void Configure(EntityTypeBuilder<Mascota> builder)
        {
            builder.Property(m => m.ColorPelo).IsRequired().HasMaxLength(100);
            builder.Property(m => m.Años).IsRequired().HasMaxLength(40);
            builder.Property(m => m.Meses).IsRequired().HasMaxLength(40);
            builder.Property(m => m.Imagen).IsRequired().HasMaxLength(200);
            builder.Property(m => m.Encontrada).IsRequired();
            builder.HasOne(r => r.Raza).WithMany().HasForeignKey(m => m.RazaId);
            builder.HasOne(u => u.Usuario).WithMany().HasForeignKey(m => m.UsuarioId);

        }
    }
}
