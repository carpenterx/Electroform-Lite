using ElectroformLite.Domain.Models;

namespace ElectroformLite.Application.Interfaces;

public interface IDataRepository
{
    void Create(Data data);
    void Delete(Guid id);
    void Update(Data data);
    Data GetData(Guid id);
    List<Data> GetAllData();
}
