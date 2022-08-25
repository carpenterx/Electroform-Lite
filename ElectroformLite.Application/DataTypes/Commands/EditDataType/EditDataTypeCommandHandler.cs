using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.DataTypes.Commands.EditDataType;

public class EditDataTypeCommandHandler : IRequestHandler<EditDataTypeCommand, DataType?>
{
    private readonly IUnitOfWork _unitOfWork;

    public EditDataTypeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<DataType?> Handle(EditDataTypeCommand request, CancellationToken cancellationToken)
    {
        DataType dataTypeFromRequest = request.DataType;
        DataType? dataTypeToEdit = await _unitOfWork.DataTypeRepository.GetDataType(dataTypeFromRequest.Id);
        if (dataTypeToEdit == null)
        {
            return null;
        }
        dataTypeToEdit.Value = dataTypeFromRequest.Value;
        _unitOfWork.DataTypeRepository.Update(dataTypeToEdit);
        await _unitOfWork.Save();

        return dataTypeToEdit;
    }
}