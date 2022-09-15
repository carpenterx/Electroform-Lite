using ElectroformLite.Application.Exceptions;
using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;
using MediatR;
using System.Net;

namespace ElectroformLite.Application.DataTypes.Commands.EditDataType;

public class EditDataTypeCommandHandler : IRequestHandler<EditDataTypeCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public EditDataTypeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(EditDataTypeCommand request, CancellationToken cancellationToken)
    {
        DataType? dataTypeToEdit = await _unitOfWork.DataTypeRepository.GetDataType(request.DataTypeId);
        if (dataTypeToEdit == null)
        {
            var response = new HttpResponseMessage(HttpStatusCode.NotFound)
            {
                ReasonPhrase = "Data Type Not Found"
            };
            throw new NotFoundHttpResponseException(response);
        }
        dataTypeToEdit.Value = request.NewDataTypeValue;
        _unitOfWork.DataTypeRepository.Update(dataTypeToEdit);
        await _unitOfWork.Save();

        return Unit.Value;
    }
}