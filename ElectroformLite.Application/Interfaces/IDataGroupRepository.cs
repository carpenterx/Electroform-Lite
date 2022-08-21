using ElectroformLite.Domain.Models;

namespace ElectroformLite.Application.Interfaces;

public interface IDataGroupRepository
{
    void Create(DataGroup dataGroup);
    void Delete(Guid id);
    void Update(DataGroup dataGroup);
    DataGroup GetDataGroup(Guid id);
    List<DataGroup> GetDataGroupsByType(Guid id);
    List<DataGroup> GetDataGroups();
}
