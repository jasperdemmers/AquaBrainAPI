namespace AquaBrainAPI;

public interface IKlantService
{
    Task<List<Klant>> GetAllKlanten();
    Task<Klant>? GetKlantById(int id);
    Task<Klant>? GetKlantByUsername(string Gebruikersnaam);
    Task<Klant>? GetKlantByEmail(string Email);
    Task<Klant>? AddKlant(Klant request);
    Task<Klant>? UpdateKlant(int id, requestKlant request);
    Task<List<Klant>>? DeleteKlant(int id);
}
