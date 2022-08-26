using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.DataGroups.Commands.AddDataToDataGroup;

public class AddDataToDataGroupCommandHandler : IRequestHandler<AddDataToDataGroupCommand, DataGroup?>
{
    private readonly IUnitOfWork _unitOfWork;

    public AddDataToDataGroupCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<DataGroup?> Handle(AddDataToDataGroupCommand request, CancellationToken cancellationToken)
    {
        DataGroup? dataGroup = await _unitOfWork.DataGroupRepository.GetDataGroup(request.DataGroupId);
        Data? data = await _unitOfWork.DataRepository.GetData(request.DataId);

        if (dataGroup is null || data is null)
        {
            return null;
        }

        dataGroup.UserData.Add(data);
        await _unitOfWork.Save();

        return dataGroup;
    }
}
