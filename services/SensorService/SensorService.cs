using Microsoft.EntityFrameworkCore;

namespace AquaBrainAPI;

public class SensorService : ISensorService
{
    private readonly DevelopmentContext _context;
    public SensorService(DevelopmentContext context)
    {
        _context = context;   
    }
        
    public async Task<List<Sensor>> GetSensorsByWatertonId(int id)
    {
        //Get all sensors that have the given WatertonID. Each sensor has an SensorID. Only give the latest record of each SensorID.
        var Sensors = await _context.Sensors
            .Where(s => s.WatertonId == id)
            .GroupBy(s => s.SensorId)
            .Select(s => s.OrderByDescending(s => s.CreatedDate).FirstOrDefault())
            .ToListAsync();

        if (Sensors == null || !Sensors.Any())
        {
            return null;
        }

        return Sensors;
    }

    public async Task<List<Sensor>> GetSensorData(int sensorId, int watertonId)
    {
        //Get all sensor data that have the given SensorID and WatertonID. We want to see previous records of the same sensorId aswell. So there will be duplicates. Make sure that the latest entry is first.
        var Sensors = await _context.Sensors
            .Where(s => s.SensorId == sensorId && s.WatertonId == watertonId)
            .OrderByDescending(s => s.CreatedDate)
            .ToListAsync();

        if (Sensors == null || !Sensors.Any())
        {
            return null;
        }

        return Sensors;
    }

    public async Task<List<Sensor>> DeleteSensorData(int sensorId, int watertonId)
    {
        //Delete all sensor data that have the given SensorID and WatertonID.
        var Sensors = await _context.Sensors
            .Where(s => s.SensorId == sensorId && s.WatertonId == watertonId)
            .ToListAsync();

        //Delete all entries in Sensors and update database
        foreach (var sensor in Sensors)
        {
            _context.Remove(sensor);
        }
        await _context.SaveChangesAsync();

        if (Sensors == null || !Sensors.Any())
        {
            return null;
        }

        return Sensors;
    }
    public async Task<Sensor> NewSensorData(newSensor request)
    {
        var data = new Sensor
        {
            WatertonId = request.WatertonId,
            SensorId = request.SensorID,
            Waarde = request.waarde,
            Type = request.Type,
        };

        //Add new sensor data to the database.
        _context.Sensors.Add(data);
        await _context.SaveChangesAsync();

        return data;
    }
}
