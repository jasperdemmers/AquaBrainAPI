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
    public class ValveController : ControllerBase
    {
        private readonly IValveService _valveService;
        public ValveController(IValveService valveService)
        {
            _valveService = valveService;
        }

        [HttpGet("{watertonid}")]
        public async Task<ActionResult<List<Sensor>>> GetValvesByWatertonId(int watertonid)
        {
            var result = await _valveService.GetValvesByWatertonId(watertonid);
            if (result is null) {
                return NotFound("Valves niet gevonden");
            }
            return Ok(result);
        }

        [HttpGet("{watertonid}/{valveid}")]
        public async Task<ActionResult<Sensor>> GetValveData(int watertonid, int valveid)
        {
            var result = await _valveService.GetValveData(valveid, watertonid);
            if (result is null) {
                return NotFound("Valve data niet gevonden");
            }
            return Ok(result);
        }

        [HttpPut("{watertonid}/{valveid}")]
        public async Task<ActionResult<Sensor>> UpdateValve([FromBody]requestValve request, int watertonid, int valveid)
        {
            var result = await _valveService.UpdateValve(request, valveid, watertonid);
            if (result is null) {
                return BadRequest("Valve data niet toegevoegd");
            }
            return Ok(result);
        }
    }
}