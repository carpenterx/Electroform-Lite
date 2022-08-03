using ElectroformLite.Domain.Models;

namespace ElectroformLite.Application.Interfaces;

public interface IDataRepository
{
    void Create(Data data);
    void Delete(int id);
    void Update(int id);
    int GetData(int id);
    List<Data> GetAllData();
}
