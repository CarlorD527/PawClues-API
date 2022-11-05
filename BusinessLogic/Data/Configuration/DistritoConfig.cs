using Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Data.Configuration
{
    public class DistritoConfig
    {
        public void Configure(EntityTypeBuilder<Distrito> builder)
        {
            builder.Property(d => d.NombreDistrito).IsRequired().HasMaxLength(40);


        }
    }
}
