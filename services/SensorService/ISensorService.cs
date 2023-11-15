namespace AquaBrainAPI;

public interface ISensorService
{
    Task<List<Sensor>>? GetSensorsByWatertonId(int id);
    Task<List<Sensor>>? GetSensorData(int sensorId, int watertonId);
    Task<List<Sensor>>? DeleteSensorData(int sensorId, int watertonId);
    Task<Sensor>? NewSensorData(newSensor request);
}
