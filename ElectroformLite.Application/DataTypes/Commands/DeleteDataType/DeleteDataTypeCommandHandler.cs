using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.DataTypes.Commands.DeleteDataType;

public class DeleteDataTypeCommandHandler : IRequestHandler<DeleteDataTypeCommand, DataType>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteDataTypeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<DataType> Handle(DeleteDataTypeCommand request, CancellationToken cancellationToken)
    {
        DataType? dataType = await _unitOfWork.DataTypeRepository.GetDataType(request.DataTypeId);
        if (dataType == null)
        {
            return null;
        }

        _unitOfWork.DataTypeRepository.Delete(dataType);
        await _unitOfWork.Save();

        return dataType;
    }
}