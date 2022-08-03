using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;

namespace ElectroformLite.Infrastructure.InMemory;

public class InMemoryDataRepository : IDataRepository
{
    public void Create(Data data)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public List<Data> GetAllData()
    {
        List<Data> data = new();

        Data firstName = new(0, "FirstName", "John");
        Data lastName = new(1, "LastName", "Doh");
        Data email = new(2, "Email", "john.doh@gmail.com");
        Data phone = new(3, "PhoneNumber", "1234567890");

        data.Add(firstName);
        data.Add(lastName);
        data.Add(email);
        data.Add(phone);

        return data;
    }

    public int GetData(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(int id)
    {
        throw new NotImplementedException();
    }
}
