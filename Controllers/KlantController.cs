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
    public class KlantController : ControllerBase
    {
        private readonly IKlantService _klantService;
        public KlantController(IKlantService klantService)
        {
            _klantService = klantService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Klant>>> GetAllKlanten()
        {
            var result = await _klantService.GetAllKlanten();
            if (result is null) {
                return NotFound("Klanten niet gevonden");
            }
            return Ok(result);
        }

        [HttpGet("gebruikersnaam/{gebruikersnaam}")]
        public async Task<ActionResult<Klant>> GetKlantByUsername(string gebruikersnaam)
        {
            var result = await _klantService.GetKlantByUsername(gebruikersnaam);
            if (result is null) {
                return NotFound("Klant niet gevonden");
            }
            return Ok(result);
        }
        [HttpGet("id/{id}")]
        public async Task<ActionResult<Klant>> GetKlantById(int id)
        {
            var result = await _klantService.GetKlantById(id);
            if (result is null) {
                return NotFound("Klant niet gevonden");
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<Klant>>> AddKlant([FromBody]Klant request)
        {
            var result = await _klantService.AddKlant(request);
            if (result is null) {
                return BadRequest("Klant niet toegevoegd");
            }
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Klant>> UpdateKlant(int id, [FromBody]requestKlant request)
        {
            var result = await _klantService.UpdateKlant(id, request);
            if (result is null) {
                return NotFound("Klant niet gevonden");
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Klant>>> DeleteKlant(int id)
        {
            var result = await _klantService.DeleteKlant(id);
            if (result is null) {
                return NotFound("Klant niet gevonden");
            }
            return Ok(result);
        }
    }
}