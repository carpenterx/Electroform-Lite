using ElectroformLite.Application.Exceptions;
using ElectroformLite.Application.Interfaces;
using ElectroformLite.Application.Utils;
using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.Templates.Commands.DeleteTemplate;

public class DeleteTemplateCommandHandler : IRequestHandler<DeleteTemplateCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteTemplateCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteTemplateCommand request, CancellationToken cancellationToken)
    {
        Template? template = await _unitOfWork.TemplateRepository.GetTemplate(request.TemplateId);
        if (template == null)
        {
            HttpResponseMessage response = HttpUtilities.HttpResponseMessageBuilder("Template Not Found");
            throw new NotFoundHttpResponseException(response);
        }

        _unitOfWork.TemplateRepository.Delete(template);
        await _unitOfWork.Save();

        return Unit.Value;
    }
}