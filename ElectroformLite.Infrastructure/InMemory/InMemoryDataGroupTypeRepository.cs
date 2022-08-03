using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;

namespace ElectroformLite.Infrastructure.InMemory;

public class InMemoryDataGroupTypeRepository : IDataGroupTypeRepository
{
    public List<DataGroupType> GetDataGroupTypes()
    {
        List<DataGroupType> dataGroupTypes = new();

        DataGroupType personType = new() { Id = 0, Value = "Person" };
        dataGroupTypes.Add(personType);

        DataGroupType contactType = new() { Id = 1, Value = "Contact" };
        dataGroupTypes.Add(contactType);

        return dataGroupTypes;
    }
}
