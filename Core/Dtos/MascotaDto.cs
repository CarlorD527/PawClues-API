using Core.Entities;
using Microsoft.AspNetCore.Http;

namespace PawCluesAPI.Dtos
{
    public class MascotaDto
    {
        public string ColorPelo { get; set; }
        public int Años { get; set; }
        public int Meses { get; set; }
        public int RazaId { get; set; }
        public Boolean Encontrada { get; set; }
        public int UsuarioId { get; set; }

    }
}
