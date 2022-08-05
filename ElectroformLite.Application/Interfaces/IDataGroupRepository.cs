using ElectroformLite.Domain.Models;

namespace ElectroformLite.Application.Interfaces;

public interface IDataGroupRepository
{
    void Create(DataGroup dataGroup);
    void Delete(int id);
    void Update(DataGroup dataGroup);
    DataGroup GetDataGroup(int id);
    List<DataGroup> GetDataGroups();
}
