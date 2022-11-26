using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos
{
    public class UsuarioDto
    {   
        public int DistritoId { get; set; }
        public string NombreCompleto { get; set; }
        public string NumeroContacto { get; set; }
    }

}
