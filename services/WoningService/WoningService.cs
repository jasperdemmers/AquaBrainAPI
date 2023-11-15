using Microsoft.EntityFrameworkCore;

namespace AquaBrainAPI;

public class WoningService : IWoningService
{
    private readonly DevelopmentContext _context;
    public WoningService(DevelopmentContext context)
    {
        _context = context;   
    }
        
    public async Task<List<Woning>> GetAllWoningen()
    {
        var Woning = await _context.Woningen.ToListAsync();
        return Woning;
    }
    public async Task<Woning> GetWoningById(int id)
    {
        var woning = await _context.Woningen.FindAsync(id);

        if (woning == null)
        {
            return null;
        }
        return woning;
    }
    public async Task<List<Woning>> GetWoningByKlantId(int id)
    {
        var woningen = await _context.Woningen
            .Where(k => k.KlantId == id)
            .ToListAsync();

        if (woningen == null || !woningen.Any())
        {
            return null;
        }
        return woningen;
    }
    public  async Task<List<Woning>> AddWoning(Woning request)
    {
        _context.Woningen.Add(request);
        await _context.SaveChangesAsync();

        return await _context.Woningen.ToListAsync();
    }
    public async Task<List<Woning>> DeleteWoning(int id)
    {
        var woning = _context.Woningen.FindAsync(id);
        if (woning == null)
        {
            return null;
        }

        _context.Remove(woning);
        await _context.SaveChangesAsync();

        return await _context.Woningen.ToListAsync();
    }
    public async Task<Woning> UpdateWoning(int id, requestWoning request)
    {
        var woning = await _context.Woningen.FindAsync(id);
        if (woning == null)
        {
            return null;
        }

        //Update de klant with the request data.
        woning.KlantId = request.KlantId;
        woning.Naam = request.Naam;

        await _context.SaveChangesAsync();

        return await _context.Woningen.FindAsync(id);
    }
}
