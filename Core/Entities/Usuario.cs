using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }

        public DateTime FechaIngreso { get; set; }

        public int DistritoId { get; set; }

        [ForeignKey("DistritoId")]
        public Distrito Distrito { get; set; }

        public string NombreCompleto { get; set; }
        public string NumeroContacto { get; set; }

    }
}
