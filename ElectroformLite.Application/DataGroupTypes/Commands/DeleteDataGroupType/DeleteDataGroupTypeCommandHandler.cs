using ElectroformLite.Application.Exceptions;
using ElectroformLite.Application.Interfaces;
using ElectroformLite.Application.Utils;
using ElectroformLite.Domain.Models;
using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace ElectroformLite.Application.DataGroupTypes.Commands.DeleteDataGroupType;

public class DeleteDataGroupTypeCommandHandler : IRequestHandler<DeleteDataGroupTypeCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteDataGroupTypeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteDataGroupTypeCommand request, CancellationToken cancellationToken)
    {
        DataGroupType? dataGroupType = await _unitOfWork.DataGroupTypeRepository.GetFullDataGroupType(request.DataGroupTypeId);

        if (dataGroupType == null)
        {
            /*var response = new HttpResponseMessage(HttpStatusCode.NotFound)
            {
                ReasonPhrase = "Data Group Type Not Found"
            };*/
            HttpResponseMessage response = HttpUtilities.HttpResponseMessageBuilder("Data Group Type Not Found");
            throw new NotFoundHttpResponseException(response);
        }

        if (dataGroupType.DataGroupTemplates.Count > 0)
        {
            /*var response = new HttpResponseMessage(HttpStatusCode.Forbidden)
            {
                ReasonPhrase = "Data Group Type Cannot Be Deleted"
            };*/
            HttpResponseMessage response = HttpUtilities.HttpResponseMessageBuilder("Data Group Type Cannot Be Deleted", HttpStatusCode.Forbidden);
            throw new CantDeleteHttpResponseException(response);
        }

        _unitOfWork.DataGroupTypeRepository.Delete(dataGroupType);
        await _unitOfWork.Save();

        return Unit.Value;
    }
}