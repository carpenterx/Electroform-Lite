using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.DataGroups.Commands.DeleteDataFromDataGroup;

public class DeleteDataFromDataGroupCommandHandler : IRequestHandler<DeleteDataFromDataGroupCommand, DataGroup?>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteDataFromDataGroupCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<DataGroup?> Handle(DeleteDataFromDataGroupCommand request, CancellationToken cancellationToken)
    {
        DataGroup? dataGroup = await _unitOfWork.DataGroupRepository.GetDataGroup(request.DataGroupId);
        Data? data = await _unitOfWork.DataRepository.GetData(request.DataId);

        if (dataGroup is null || data is null)
        {
            return null;
        }

        dataGroup.UserData.Remove(data);
        await _unitOfWork.Save();

        return dataGroup;
    }
}
