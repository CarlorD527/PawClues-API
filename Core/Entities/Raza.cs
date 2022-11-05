using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Raza 
    {
        [Key]
        public int RazaId { get; set; }
        public string NombreRaza { get; set; }
        public string imagen { get; set;}

    }
}
