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
    public class DistritoRepository : IDistritoRepository
    {
        private readonly PawClawsDbContext _context;
        public DistritoRepository(PawClawsDbContext context)
        {

            _context = context;
        }
        public async Task<IReadOnlyList<Distrito>> GetDistritoAsync()
        {
            return await _context.Distrito.ToListAsync();
        } 

        public async Task<Distrito> getDistritoByIdAsync(int id)
        {
            return await _context.Distrito.Include(m => m.DistritoId).FirstOrDefaultAsync(m => m.DistritoId == id);
         
        }
    }
}
