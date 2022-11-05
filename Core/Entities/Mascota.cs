using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Mascota
    {
        [Key]
        public int MascotaId { get; set; }
        public string ColorPelo { get; set; }
        public int Años { get; set; }
        public int Meses { get; set; }
        public string Imagen { get; set; }
        public int? RazaId { get; set; }
      
        public int UsuarioId { get; set; }
        public bool Encontrada { get; set; }
        
        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; }

        [ForeignKey("RazaId")]
        public Raza Raza { get; set; }
 
    }
}
