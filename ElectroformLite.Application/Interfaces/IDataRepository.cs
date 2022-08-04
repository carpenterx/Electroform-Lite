using ElectroformLite.Domain.Models;

namespace ElectroformLite.Application.Interfaces;

public interface IDataRepository
{
    void Create(Data data);
    void Delete(int id);
    void Update(Data data);
    Data GetData(int id);
    List<Data> GetAllData();
}
