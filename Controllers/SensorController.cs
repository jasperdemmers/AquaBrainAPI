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
    public class SensorController : ControllerBase
    {
        private readonly ISensorService _sensorService;
        public SensorController(ISensorService sensorService)
        {
            _sensorService = sensorService;
        }

        [HttpGet("watertonid/{id}")]
        public async Task<ActionResult<List<Sensor>>> GetSensorsByWatertonId(int id)
        {
            var result = await _sensorService.GetSensorsByWatertonId(id);
            if (result is null) {
                return NotFound("Sensor(s) niet gevonden");
            }
            return Ok(result);
        }
        [HttpGet("data/{watertonid}/{sensorid}")]
        public async Task<ActionResult<List<Sensor>>> GetSensorData(int sensorid, int watertonid)
        {
            var result = await _sensorService.GetSensorData(sensorid, watertonid);
            if (result is null) {
                return NotFound("Sensor data niet gevonden");
            }
            return Ok(result);
        }

        [HttpDelete("data/{watertonid}/{sensorid}")]
        public async Task<ActionResult<List<Sensor>>> DeleteSensorData(int sensorid, int watertonid)
        {
            var result = await _sensorService.DeleteSensorData(sensorid, watertonid);
            if (result is null) {
                return NotFound("Sensor data niet gevonden");
            }
            return Ok(result);
        }

        [HttpPost("data")]
        public async Task<ActionResult<Sensor>> NewSensorData([FromBody]newSensor request)
        {
            var result = await _sensorService.NewSensorData(request);
            if (result is null) {
                return BadRequest("Sensor data niet toegevoegd");
            }
            return Ok(result);
        }
    }
}