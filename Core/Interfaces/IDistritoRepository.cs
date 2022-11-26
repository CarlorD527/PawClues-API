using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IDistritoRepository
    {

        Task<IReadOnlyList<Distrito>> GetDistritoAsync();
        Task<Distrito> getDistritoByIdAsync(int id);

    }
}
