using ElectroformLite.Application.Exceptions;
using ElectroformLite.Application.Interfaces;
using ElectroformLite.Application.Utils;
using ElectroformLite.Domain.Models;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace ElectroformLite.Application.DataGroups.Commands.DeleteDataGroup;

public class DeleteDataGroupCommandHandler : IRequestHandler<DeleteDataGroupCommand, DataGroup>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteDataGroupCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<DataGroup> Handle(DeleteDataGroupCommand request, CancellationToken cancellationToken)
    {
        DataGroup? dataGroup = await _unitOfWork.DataGroupRepository.GetDataGroup(request.DataGroupId);
        if (dataGroup == null)
        {
            HttpResponseMessage response = HttpUtilities.HttpResponseMessageBuilder("Data Group Not Found");
            throw new NotFoundHttpResponseException(response);
        }

        _unitOfWork.DataGroupRepository.Delete(dataGroup);
        await _unitOfWork.Save();

        return dataGroup;
    }
}