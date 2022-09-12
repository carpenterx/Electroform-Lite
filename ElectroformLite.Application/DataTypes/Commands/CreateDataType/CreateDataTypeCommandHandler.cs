using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.DataTypes.Commands.CreateDataType;

public class CreateDataTypeCommandHandler : IRequestHandler<CreateDataTypeCommand, DataType>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateDataTypeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<DataType> Handle(CreateDataTypeCommand request, CancellationToken cancellationToken)
    {
        DataType dataType = new(request.TypeValue);

        _unitOfWork.DataTypeRepository.Create(dataType);
        await _unitOfWork.Save();

        return dataType;
    }
}