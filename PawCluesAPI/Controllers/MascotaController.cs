using AutoMapper;
using BusinessLogic.Logic;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PawCluesAPI.Dtos;

namespace PawCluesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MascotaController : ControllerBase
    {
        private readonly IMascotaRepository _mascotaRepository;

        private readonly IMapper _mapper;
        public MascotaController(IMascotaRepository mascotaRepository, IMapper mapper)
        {
            _mascotaRepository = mascotaRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Mascota>>> getMascotas() {

            var mascotas = await _mascotaRepository.GetMascotasAsync();

            return Ok(mascotas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Mascota>> getMascota(int id) { 
        
               return await _mascotaRepository.getMascotaByIdAsync(id);
        }
        [HttpPost]
        public async Task<ActionResult> postMascota(MascotaDto obj) {

            var mascota = _mapper.Map<Mascota>(obj);

            await _mascotaRepository.PostMascotaAsync(mascota);

            return Ok(obj);
        }
        [HttpDelete]
        public async Task<ActionResult> deleteMascota(int id) {

             await _mascotaRepository.DeleteMascotaAsync(id);
            return Ok();
                }
    }
}
