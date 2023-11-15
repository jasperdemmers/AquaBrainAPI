namespace AquaBrainAPI;

public interface IWoningService
{
    Task<List<Woning>> GetAllWoningen();
    Task<Woning>? GetWoningById(int id);
    Task<List<Woning>>? GetWoningByKlantId(int id);
    Task<List<Woning>>? AddWoning(Woning request);
    Task<Woning>? UpdateWoning(int id, requestWoning request);
    Task<List<Woning>>? DeleteWoning(int id);
}
