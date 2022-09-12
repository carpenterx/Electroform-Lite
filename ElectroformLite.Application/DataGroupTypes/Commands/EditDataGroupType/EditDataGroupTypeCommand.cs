using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.DataGroupTypes.Commands.EditDataGroupType;

public class EditDataGroupTypeCommand : IRequest<DataGroupType?>
{
    public DataGroupType DataGroupType { get; set; }

    public EditDataGroupTypeCommand(DataGroupType dataGroupType)
    {
        DataGroupType = dataGroupType;
    }
}
