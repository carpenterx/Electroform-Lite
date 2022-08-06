using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;

namespace ElectroformLite.Infrastructure.InMemory;

public class InMemoryDataGroupTypeRepository : IDataGroupTypeRepository
{
    readonly List<DataGroupType> dataGroupTypes = new();

    public void Create(DataGroupType dataGroupType)
    {
        int previousId;
        if (dataGroupTypes.Count > 0)
        {
            previousId = dataGroupTypes[^1].Id;
        }
        else
        {
            previousId = -1;
        }
        dataGroupType.Id = previousId + 1;
        dataGroupTypes.Add(dataGroupType);
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public DataGroupType GetDataGroupType(int id)
    {
        return dataGroupTypes.FirstOrDefault(t => t.Id == id);
    }

    public List<DataGroupType> GetDataGroupTypes()
    {
        /*DataGroupType personType = new() { Id = 0, Value = "Person" };
        dataGroupTypes.Add(personType);

        DataGroupType contactType = new() { Id = 1, Value = "Contact" };
        dataGroupTypes.Add(contactType);*/

        return dataGroupTypes;
    }

    public void Update(DataGroupType dataGroupType)
    {
        throw new NotImplementedException();
    }
}
