using ElectroformLite.Domain.Models;

namespace ElectroformLite.Application.Interfaces;

public interface IDataGroupRepository
{
    List<DataGroup> GetDataGroups();
}
