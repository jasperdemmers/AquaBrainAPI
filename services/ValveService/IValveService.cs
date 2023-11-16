namespace AquaBrainAPI;

public interface IValveService
{
    Task<List<Valve>>? GetValvesByWatertonId(int watertonId);
    Task<Valve>? GetValveData(int valveId, int watertonId);
    Task<Valve>? UpdateValve(requestValve request, int watertonId, int valveId);
}
