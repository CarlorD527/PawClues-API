using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Data
{
    public class PawClawsDbContext : DbContext
    {
        public PawClawsDbContext(DbContextOptions<PawClawsDbContext> options) : base(options) { }


        public DbSet<Mascota> Mascota { get; set; }

        public DbSet<Raza> Raza { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        public DbSet<Distrito> Distrito { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
