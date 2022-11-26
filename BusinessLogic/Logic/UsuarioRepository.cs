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
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly PawClawsDbContext _context;

        public UsuarioRepository(PawClawsDbContext context)
        {

            _context = context;
        }

        public async Task<Usuario> getUsuarioaByIdAsync(int id)
        {
            return await _context.Usuario.FirstOrDefaultAsync(u => u.UsuarioId == id);
        }
        public async Task<IReadOnlyList<Usuario>> GetUsuariosAsync()
        {
            return await _context.Usuario.ToListAsync();
        }

        public async Task PostUsuarioAsync(Usuario usuario)
        {
            _context.Add(usuario);
            await _context.SaveChangesAsync();
        }

        Task IUsuarioRepository.DeleteUsuarioAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUsuarioAsync(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> getUsuarioByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
