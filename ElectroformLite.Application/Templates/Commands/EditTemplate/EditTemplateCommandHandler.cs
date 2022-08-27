using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.Templates.Commands.EditTemplate;

public class EditTemplateCommandHandler : IRequestHandler<EditTemplateCommand, Template?>
{
    private readonly IUnitOfWork _unitOfWork;

    public EditTemplateCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Template?> Handle(EditTemplateCommand request, CancellationToken cancellationToken)
    {
        Template templateFromRequest = request.Template;
        Template? templateToEdit = await _unitOfWork.TemplateRepository.GetTemplate(templateFromRequest.Id);
        if (templateToEdit == null)
        {
            return null;
        }
        templateToEdit.Name = templateFromRequest.Name;
        templateToEdit.Content = templateFromRequest.Content;
        _unitOfWork.TemplateRepository.Update(templateToEdit);
        await _unitOfWork.Save();

        return templateToEdit;
    }
}