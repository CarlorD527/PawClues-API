using AutoMapper;
using BusinessLogic.Logic;
using Core.Dtos;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using PawCluesAPI.Dtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PawCluesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;
        public UsuariosController(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> getUsuarios()
        {

            var usuarios = await _usuarioRepository.GetUsuariosAsync();

            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> getUsuario(int id)
        {

            return await _usuarioRepository.getUsuarioByIdAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult> postUsuario(UsuarioDto obj)
        {

               

                var usuario = _mapper.Map<Usuario>(obj);

            usuario.FechaIngreso = DateTime.Now;

                await _usuarioRepository.PostUsuarioAsync(usuario);


            return Ok(obj);
        }
    }
}
