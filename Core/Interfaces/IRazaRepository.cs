using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
     public  interface IRazaRepository
    {


        Task<Raza> getRazaByIdAsync(int id);

        Task<IReadOnlyList<Raza>> GetRazasAsync();

        Task PostRazaAsync(Raza raza);

        Task UpdateRazaAsync(Raza raza);

        Task DeleteRazaAsync(int? id);
    }
}
