using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IUsuarioRepository
    {

        Task<Usuario> getUsuarioByIdAsync(int id);

        Task<IReadOnlyList<Usuario>> GetUsuariosAsync();

        Task PostUsuarioAsync(Usuario usuario);

        Task UpdateUsuarioAsync(Usuario usuario);

        Task DeleteUsuarioAsync(int? id);
    }
}
