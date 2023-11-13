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
        private static List<Klant> klant = new List<Klant>
        {
            new Klant { 
                Id = 1, 
                VoorNaam = "Jan", 
                AcherNaam = "Janssen", 
                Email = "Demo@demo.nl", 
                TelefoonNummer = "0612345678" 
            },
            new Klant {
                Id = 2,
                VoorNaam = "Piet",
                AcherNaam = "Pietersen",
                Email = "Demo@demo.nl",
                TelefoonNummer = "0612345678"
            }
        };

        [HttpGet]
        public async Task<ActionResult<List<Klant>>> GetAllKlanten()
        {
            return Ok(klant);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Klant>> GetSingleKlant(int id)
        {
            var singleKlant = klant.Find(x => x.Id == id);

            if (singleKlant == null)
            {
                return NotFound("Klant niet gevonden");
            }

            return Ok(singleKlant);
        }

        [HttpPost]
        public async Task<ActionResult<List<Klant>>> AddKlant([FromBody]Klant request)
        {
            klant.Add(request);
            return Ok(klant);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Klant>>> UpdateKlant(int id, [FromBody]Klant request)
        {
            var selKlant = klant.Find(x => x.Id == id);
            if (selKlant == null)
            {
                return NotFound("Klant niet gevonden");
            }

            selKlant.VoorNaam = request.VoorNaam;
            selKlant.AcherNaam = request.AcherNaam;
            selKlant.Email = request.Email;
            selKlant.TelefoonNummer = request.TelefoonNummer;

            return Ok(klant);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Klant>>> DeleteKlant(int id)
        {
            var selKlant = klant.Find(x => x.Id == id);
            if (selKlant == null)
            {
                return NotFound("Klant niet gevonden");
            }

            klant.Remove(selKlant);

            return Ok(klant);
        }
    }
}