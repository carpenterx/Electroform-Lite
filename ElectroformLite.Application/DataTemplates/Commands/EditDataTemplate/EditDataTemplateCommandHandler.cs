using ElectroformLite.Application.Exceptions;
using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;
using MediatR;
using System.Net;

namespace ElectroformLite.Application.DataTemplates.Commands.EditDataTemplate;

public class EditDataTemplateCommandHandler : IRequestHandler<EditDataTemplateCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public EditDataTemplateCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(EditDataTemplateCommand request, CancellationToken cancellationToken)
    {
        DataTemplate? dataTemplateToEdit = await _unitOfWork.DataTemplateRepository.GetDataTemplate(request.DataTemplateId);

        if (dataTemplateToEdit == null)
        {
            var response = new HttpResponseMessage(HttpStatusCode.NotFound)
            {
                ReasonPhrase = "Data Template Not Found"
            };
            throw new NotFoundHttpResponseException(response);
        }

        dataTemplateToEdit.Placeholder = request.DataTemplatePlaceholder;
        _unitOfWork.DataTemplateRepository.Update(dataTemplateToEdit);
        await _unitOfWork.Save();

        return Unit.Value;
    }
}