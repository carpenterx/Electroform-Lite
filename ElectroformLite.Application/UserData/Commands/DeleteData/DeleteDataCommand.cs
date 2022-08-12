using MediatR;

namespace ElectroformLite.Application.UserData.Commands.DeleteData;

public class DeleteDataCommand : IRequest
{
    public int DataId { get; set; }

    public DeleteDataCommand(int dataId)
    {
        DataId = dataId;
    }
}
