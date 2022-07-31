using ElectroformLite.Domain.Models;

namespace ElectroformLite.Domain.Services;

public class DataGroupTypeService
{
    public static List<DataGroupType> GetDataGroupTypes()
    {
        List<DataGroupType> dataGroupTypes = new();

        DataGroupType personType = new() { Id = 0, Value = "Person" };
        dataGroupTypes.Add(personType);

        DataGroupType contactType = new() { Id = 1, Value = "Contact" };
        dataGroupTypes.Add(contactType);

        return dataGroupTypes;
    }
}
