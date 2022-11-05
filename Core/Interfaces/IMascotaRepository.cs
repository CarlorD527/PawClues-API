using Core.Entities;
using PawCluesAPI.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IMascotaRepository
    {

        Task<Mascota> getMascotaByIdAsync(int id);

        Task<IReadOnlyList<Mascota>> GetMascotasAsync();

        Task PostMascotaAsync(Mascota mascota);

        Task UpdateMascotaAsync(Mascota mascota);

        Task DeleteMascotaAsync(int id);
    }
}
