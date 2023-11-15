namespace AquaBrainAPI;

public interface IWatertonService
{
    Task<List<Waterton>> GetAllWatertonnen();
    Task<Waterton>? GetWatertonById(int id);
    Task<List<Waterton>>? GetWatertonByWoningId(int id);
    Task<List<Waterton>>? AddWaterton(Waterton request);
    Task<Waterton>? UpdateWaterton(int id, requestWaterton request);
    Task<List<Waterton>>? DeleteWaterton(int id);
}
