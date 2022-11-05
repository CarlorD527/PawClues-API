using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Distrito
    {
        [Key]
        public int DistritoId { get; set; }

        public string NombreDistrito { get; set; }
    }
}
