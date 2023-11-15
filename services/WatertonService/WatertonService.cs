using Microsoft.EntityFrameworkCore;

namespace AquaBrainAPI;

public class WatertonService : IWatertonService
{
    private readonly DevelopmentContext _context;
    public WatertonService(DevelopmentContext context)
    {
        _context = context;   
    }
        
    public async Task<List<Waterton>> GetAllWatertonnen()
    {
        var Watertonnen = await _context.Watertonnen.ToListAsync();
        return Watertonnen;
    }
    public async Task<Waterton> GetWatertonById(int id)
    {
        var waterton = await _context.Watertonnen.FindAsync(id);

        if (waterton == null)
        {
            return null;
        }
        return waterton;
    }
    public async Task<List<Waterton>> GetWatertonByWoningId(int id)
    {
        //Find the klant with the given Gebruikersnaam.

        var watertonnen = await _context.Watertonnen
            .Where(w => w.WoningId == id)
            .ToListAsync();

        if (watertonnen == null || !watertonnen.Any())
        {
            return null;
        }
        return watertonnen;
    }
    public  async Task<List<Waterton>> AddWaterton(Waterton request)
    {
        _context.Watertonnen.Add(request);
        await _context.SaveChangesAsync();

        return await _context.Watertonnen.ToListAsync();
    }
    public async Task<List<Waterton>> DeleteWaterton(int id)
    {
        var waterton = _context.Watertonnen.FindAsync(id);
        if (waterton == null)
        {
            return null;
        }

        _context.Remove(waterton);
        await _context.SaveChangesAsync();

        return await _context.Watertonnen.ToListAsync();
    }
    public async Task<Waterton> UpdateWaterton(int id, requestWaterton request)
    {
        var waterton = await _context.Watertonnen.FindAsync(id);
        if (waterton == null)
        {
            return null;
        }

       waterton.WoningId = request.WoningId;
       waterton.Naam = request.Naam;
       waterton.MaxInhoud = request.MaxInhoud;

        await _context.SaveChangesAsync();

        return await _context.Watertonnen.FindAsync(id);
    }
}
