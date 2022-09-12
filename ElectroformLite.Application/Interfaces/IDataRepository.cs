using ElectroformLite.Domain.Models;

namespace ElectroformLite.Application.Interfaces;

public interface IDataRepository
{
    void Create(Data data);
    void Delete(Data data);
    void Update(Data data);
    Task<Data?> GetData(Guid id);
    Task<List<Data>> GetAllData();
}
