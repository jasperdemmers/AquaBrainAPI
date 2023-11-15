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
    public class WoningController : ControllerBase
    {
        private readonly IWoningService _woningService;
        public WoningController(IWoningService woningService)
        {
            _woningService = woningService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Woning>>> GetAllWoningen()
        {
            var result = await _woningService.GetAllWoningen();
            if (result is null) {
                return NotFound("Woningen niet gevonden");
            }
            return Ok(result);
        }

        [HttpGet("klantid/{id}")]
        public async Task<ActionResult<Woning>> GetWoningByKlandId(int id)
        {
            var result = await _woningService.GetWoningByKlantId(id);
            if (result is null) {
                return NotFound("Woning niet gevonden");
            }
            return Ok(result);
        }
        [HttpGet("id/{id}")]
        public async Task<ActionResult<Woning>> GetWoningById(int id)
        {
            var result = await _woningService.GetWoningById(id);
            if (result is null) {
                return NotFound("Woning niet gevonden");
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<Woning>>> AddKlant([FromBody]Woning request)
        {
            var result = await _woningService.AddWoning(request);
            if (result is null) {
                return BadRequest("Woning niet toegevoegd");
            }
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Woning>> UpdateWoning(int id, [FromBody]requestWoning request)
        {
            var result = await _woningService.UpdateWoning(id, request);
            if (result is null) {
                return NotFound("Woning niet gevonden");
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Woning>>> DeleteWoning(int id)
        {
            var result = await _woningService.DeleteWoning(id);
            if (result is null) {
                return NotFound("Woning niet gevonden");
            }
            return Ok(result);
        }
    }
}