using Microsoft.EntityFrameworkCore;

namespace AquaBrainAPI;

public class KlantService : IKlantService
{
    private readonly DevelopmentContext _context;
    public KlantService(DevelopmentContext context)
    {
        _context = context;   
    }
        
    public async Task<List<Klant>> GetAllKlanten()
    {
        var klanten = await _context.Klanten.ToListAsync();
        return klanten;
    }
    public async Task<Klant> GetKlantById(int id)
    {
        var klant = await _context.Klanten.FindAsync(id);

        if (klant == null)
        {
            return null;
        }
        return klant;
    }
    public async Task<Klant> GetKlantByUsername(string Gebruikersnaam)
    {
        //Find the klant with the given Gebruikersnaam.

        var klant = await _context.Klanten
            .FirstOrDefaultAsync(k => k.Gebruikersnaam == Gebruikersnaam);

        if (klant == null)
        {
            return null;
        }
        return klant;
    }
    public async Task<Klant> GetKlantByEmail(string Email)
    {
        //Find the klant with the given Email.

        var klant = await _context.Klanten
            .FirstOrDefaultAsync(k => k.Email == Email);

        if (klant == null)
        {
            return null;
        }
        return klant;
    }
    public  async Task<Klant> AddKlant(Klant request)
    {
        _context.Klanten.Add(request);
        await _context.SaveChangesAsync();

        var klant = await _context.Klanten
            .FirstOrDefaultAsync(k => k.Gebruikersnaam == request.Gebruikersnaam);
        
        if (klant == null)
        {
            return null;
        }
        return klant;
    }
    public async Task<List<Klant>> DeleteKlant(int id)
    {
        var klant = await _context.Klanten.FindAsync(id);
        if (klant == null)
        {
            return null;
        }

        _context.Remove(klant);
        await _context.SaveChangesAsync();

        return await _context.Klanten.ToListAsync();
    }
    public async Task<Klant> UpdateKlant(int id, requestKlant request)
    {
        var klant = await _context.Klanten.FindAsync(id);
        if (klant == null)
        {
            return null;
        }

        //Update de klant with the request data.
        klant.Gebruikersnaam = request.Gebruikersnaam;
        klant.Wachtwoord = request.Wachtwoord;
        klant.Voornaam = request.Voornaam;
        klant.Achternaam = request.Achternaam;
        klant.Type = request.Type;
        klant.Email = request.Email;
        klant.Telefoon = request.Telefoon;
        klant.GeboorteDatum = request.GeboorteDatum;

        await _context.SaveChangesAsync();

        return await _context.Klanten.FindAsync(id);
    }
}
