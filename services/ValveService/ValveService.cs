using Microsoft.EntityFrameworkCore;

namespace AquaBrainAPI;

public class ValveService : IValveService
{
    private readonly DevelopmentContext _context;
    public ValveService(DevelopmentContext context)
    {
        _context = context;   
    }
        
    public async Task<List<Valve>> GetValvesByWatertonId(int watertonId)
    {
        var Valves = await _context.Valves
            .Where(s => s.WatertonId == watertonId)
            .GroupBy(s => s.Id)
            .Select(s => s.OrderByDescending(s => s.CreatedDate).FirstOrDefault())
            .ToListAsync();

        if (Valves == null || !Valves.Any())
        {
            return null;
        }

        return Valves;
    }

    public async Task<Valve> GetValveData(int valveId, int watertonId)
    {
        //Get the valve with the given ValveID and WatertonID.
        var valve = await _context.Valves
            .Where(s => s.Id == valveId && s.WatertonId == watertonId)
            .FirstOrDefaultAsync();

        if (valve == null) {
            return null;
        }

        return valve;
    }

    public async Task<Valve> UpdateValve(requestValve request, int valveId, int watertonId)
    {
        //Update the valve with the given ValveID and WatertonID with the given request.
        var valve = await _context.Valves
            .Where(s => s.Id == valveId && s.WatertonId == watertonId)
            .FirstOrDefaultAsync();

        if (valve == null) {
            return null;
        }

        valve.Open = request.Open;

        await _context.SaveChangesAsync();

        var changedValve = await _context.Valves
            .Where(s => s.Id == valveId && s.WatertonId == watertonId)
            .FirstOrDefaultAsync();

        return changedValve;
    }
}
