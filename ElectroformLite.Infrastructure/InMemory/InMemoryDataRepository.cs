using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;

namespace ElectroformLite.Infrastructure.InMemory;

public class InMemoryDataRepository : IDataRepository
{
    readonly List<Data> dataList = new();

    public void Create(Data data)
    {
        data.Id = Guid.NewGuid();
        dataList.Add(data);
    }

    public void Delete(Guid id)
    {
        Data? data = dataList.FirstOrDefault(d => d.Id == id);
        if (data is null)
        {
            throw new InvalidOperationException($"Data with id {id} not found");
        }
        dataList.Remove(data);
    }

    public List<Data> GetAllData()
    {
        return dataList;
    }

    public Data GetData(Guid id)
    {
        Data? data = dataList.FirstOrDefault(d => d.Id == id);
        if (data is null)
        {
            throw new InvalidOperationException($"Data with id {id} not found");
        }
        return data;
    }

    public void Update(Data data)
    {
        Data? dataToUpdate = dataList.FirstOrDefault(d => d.Id == data.Id);
        if (dataToUpdate is null)
        {
            throw new InvalidOperationException($"Data with id {data.Id} not found");
        }
        dataToUpdate.Placeholder = data.Placeholder;
        dataToUpdate.Value = data.Value;
    }
}
