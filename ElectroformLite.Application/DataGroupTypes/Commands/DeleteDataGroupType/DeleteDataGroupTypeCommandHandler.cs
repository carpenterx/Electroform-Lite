using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.DataGroupTypes.Commands.DeleteDataGroupType;

public class DeleteDataGroupTypeCommandHandler : IRequestHandler<DeleteDataGroupTypeCommand, DataGroupType?>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteDataGroupTypeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<DataGroupType?> Handle(DeleteDataGroupTypeCommand request, CancellationToken cancellationToken)
    {
        DataGroupType? dataGroupType = await _unitOfWork.DataGroupTypeRepository.GetDataGroupType(request.DataGroupTypeId);
        if (dataGroupType == null)
        {
            return null;
        }

        _unitOfWork.DataGroupTypeRepository.Delete(dataGroupType);
        await _unitOfWork.Save();

        return dataGroupType;
    }
}