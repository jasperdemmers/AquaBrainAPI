using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AquaBrainAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WatertonController : ControllerBase
    {
        private readonly IWatertonService _watertonService;
        public WatertonController(IWatertonService watertonService)
        {
            _watertonService = watertonService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Waterton>>> GetAllWatertonnen()
        {
            var result = await _watertonService.GetAllWatertonnen();
            if (result is null) {
                return NotFound("Watertonnen niet gevonden");
            }
            return Ok(result);
        }

        [HttpGet("woningid/{id}")]
        public async Task<ActionResult<List<Waterton>>> GetWatertonByWoningId(int id)
        {
            var result = await _watertonService.GetWatertonByWoningId(id);
            if (result is null) {
                return NotFound("Waterton niet gevonden");
            }
            return Ok(result);
        }
        [HttpGet("id/{id}")]
        public async Task<ActionResult<Waterton>> GetWatertonById(int id)
        {
            var result = await _watertonService.GetWatertonById(id);
            if (result is null) {
                return NotFound("Waterton niet gevonden");
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<Waterton>>> AddKlant([FromBody]Waterton request)
        {
            var result = await _watertonService.AddWaterton(request);
            if (result is null) {
                return BadRequest("Waterton niet toegevoegd");
            }
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Waterton>> UpdateWaterton(int id, [FromBody]requestWaterton request)
        {
            var result = await _watertonService.UpdateWaterton(id, request);
            if (result is null) {
                return NotFound("Waterton niet gevonden");
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Waterton>>> DeleteWaterton(int id)
        {
            var result = await _watertonService.DeleteWaterton(id);
            if (result is null) {
                return NotFound("Waterton niet gevonden");
            }
            return Ok(result);
        }
    }
}