using AutoMapper;
using BusinessLogic.Logic;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PawCluesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistritoController : ControllerBase
    {
        private readonly IDistritoRepository _distritoRepository;

        private readonly IMapper _mapper;
        public DistritoController(IDistritoRepository distritoRepository, IMapper mapper)
        {
            _distritoRepository = distritoRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<List<Distrito>>> getDistritos()
        {

            var mascotas = await _distritoRepository.GetDistritoAsync();

            return Ok(mascotas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Distrito>> getDistrito(int id)
        {

            return await _distritoRepository.getDistritoByIdAsync(id);
        }
    }
}
