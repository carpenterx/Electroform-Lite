using ElectroformLite.Domain.Models;

namespace ElectroformLite.Application.Interfaces;

public interface IDataGroupTypeRepository
{
    List<DataGroupType> GetDataGroupTypes();
}
