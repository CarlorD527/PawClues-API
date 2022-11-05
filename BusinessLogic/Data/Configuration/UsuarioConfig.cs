using Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Data.Configuration
{
    public class UsuarioConfig
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.Property(u => u.FechaIngreso).IsRequired();
            builder.Property(u => u.NombreCompleto).IsRequired().HasMaxLength(100);
            builder.HasOne(r => r.Distrito).WithMany().HasForeignKey(m => m.DistritoId);
            builder.Property(u => u.NombreCompleto).IsRequired().HasMaxLength(100);
            builder.Property(u => u.NumeroContacto).IsRequired().HasMaxLength(10);
        }
    }
}
