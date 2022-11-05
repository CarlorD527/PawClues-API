using BusinessLogic.Data;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Logic
{
    public class RazaRepository : IRazaRepository
    {
        private readonly PawClawsDbContext _context;

        public RazaRepository(PawClawsDbContext context)
        {

            _context = context;
        }
        public async Task<IReadOnlyList<Raza>> GetRazasAsync()
        {
            return await _context.Raza.ToListAsync();
        }

        public Task DeleteRazaAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public async Task<Raza> getRazaByIdAsync(int id)
        {
            return await _context.Raza.FirstOrDefaultAsync(m => m.RazaId == id);
        }

        public Task PostRazaAsync(Raza raza)
        {
            throw new NotImplementedException();
        }

        public Task UpdateRazaAsync(Raza raza)
        {
            throw new NotImplementedException();
        }
    }
}
