using ElectroformLite.Application.Exceptions;
using ElectroformLite.Application.Interfaces;
using ElectroformLite.Application.Utils;
using ElectroformLite.Domain.Models;
using MediatR;
using System.Net;

namespace ElectroformLite.Application.DataTypes.Commands.DeleteDataType;

public class DeleteDataTypeCommandHandler : IRequestHandler<DeleteDataTypeCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteDataTypeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteDataTypeCommand request, CancellationToken cancellationToken)
    {
        DataType? dataType = await _unitOfWork.DataTypeRepository.GetFullDataType(request.DataTypeId);
        if (dataType == null)
        {
            /*var response = new HttpResponseMessage(HttpStatusCode.NotFound)
            {
                ReasonPhrase = "Data Type Not Found"
            };*/
            HttpResponseMessage response = HttpUtilities.HttpResponseMessageBuilder("Data Type Not Found");
            throw new NotFoundHttpResponseException(response);
        }

        if (dataType.DataTemplates.Count > 0)
        {
            /*var response = new HttpResponseMessage(HttpStatusCode.Forbidden)
            {
                ReasonPhrase = "Data Type Cannot Be Deleted"
            };*/
            HttpResponseMessage response = HttpUtilities.HttpResponseMessageBuilder("Data Type Cannot Be Deleted", HttpStatusCode.Forbidden);
            throw new CantDeleteHttpResponseException(response);
        }

        _unitOfWork.DataTypeRepository.Delete(dataType);
        await _unitOfWork.Save();

        return Unit.Value;
    }
}