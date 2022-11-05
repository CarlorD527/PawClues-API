using BusinessLogic.Logic;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PawCluesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RazaController : ControllerBase
    {
        private readonly IRazaRepository _razaRepository;
        public RazaController(IRazaRepository razaRepository)
        {
            _razaRepository = razaRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Raza>>> getRazas()
        {

            var razas = await _razaRepository.GetRazasAsync();

            return Ok(razas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Raza>> getRaza(int id)
        {

            return await _razaRepository.getRazaByIdAsync(id);
        }

    }
}
