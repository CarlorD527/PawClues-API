using BusinessLogic.Data;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using PawCluesAPI.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BusinessLogic.Logic
{
    public class MascotaRepository : IMascotaRepository
    {
        private readonly PawClawsDbContext _context;
        public MascotaRepository(PawClawsDbContext context) {

            _context = context;
        }
       
        public async Task<Mascota> getMascotaByIdAsync(int id)
        {
            
            return await _context.Mascota.Include(m => m.Raza).FirstOrDefaultAsync(m=>m.RazaId== id);
        }

        public async Task<IReadOnlyList<Mascota>> GetMascotasAsync()
        {
           return await _context.Mascota.Include(m =>m.Raza).Include(u=>u.Usuario).ToListAsync();
        }

        public async Task PostMascotaAsync(Mascota mascota)
        {
          
            _context.Add(mascota);
            await _context.SaveChangesAsync();
        }
        Task IMascotaRepository.UpdateMascotaAsync(Mascota mascota)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteMascotaAsync(int id)
        {
            _context.Remove(_context.Mascota.Single(a => a.MascotaId == 1));

            await _context.SaveChangesAsync();
        }
    }
}
