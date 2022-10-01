using ElectroformLite.Application.Exceptions;
using ElectroformLite.Application.Interfaces;
using ElectroformLite.Application.Utils;
using ElectroformLite.Domain.Models;
using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace ElectroformLite.Application.DataTemplates.Commands.DeleteDataTemplate;

public class DeleteDataTemplateCommandHandler : IRequestHandler<DeleteDataTemplateCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteDataTemplateCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteDataTemplateCommand request, CancellationToken cancellationToken)
    {
        DataTemplate? dataTemplate = await _unitOfWork.DataTemplateRepository.GetDataTemplateWithDataAndDataGroupTemplates(request.DataTemplateId);

        if (dataTemplate == null)
        {
            /*var response = new HttpResponseMessage(HttpStatusCode.NotFound)
            {
                ReasonPhrase = "Data Template Not Found"
            };*/
            HttpResponseMessage response = HttpUtilities.HttpResponseMessageBuilder("Data Template Not Found");
            throw new NotFoundHttpResponseException(response);
        }

        if (dataTemplate.UserData.Count > 0 || dataTemplate.DataGroupTemplates.Count > 0)
        {
            /*var response = new HttpResponseMessage(HttpStatusCode.Forbidden)
            {
                ReasonPhrase = "Data Template Cannot Be Deleted"
            };*/
            HttpResponseMessage response = HttpUtilities.HttpResponseMessageBuilder("Data Template Cannot Be Deleted");
            throw new CantDeleteHttpResponseException(response);
        }

        _unitOfWork.DataTemplateRepository.Delete(dataTemplate);
        await _unitOfWork.Save();

        return Unit.Value;
    }
}