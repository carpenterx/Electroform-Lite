using ElectroformLite.Application.Dto;
using ElectroformLite.Application.Exceptions;
using ElectroformLite.Application.Interfaces;
using ElectroformLite.Application.Utils;
using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.Templates.Commands.EditTemplate;

public class EditTemplateCommandHandler : IRequestHandler<EditTemplateCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public EditTemplateCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(EditTemplateCommand request, CancellationToken cancellationToken)
    {
        Template? templateToEdit = await _unitOfWork.TemplateRepository.GetTemplateWithAliasTemplates(request.Id);
        if (templateToEdit == null)
        {
            HttpResponseMessage response = HttpUtilities.HttpResponseMessageBuilder("Template Not Found");
            throw new NotFoundHttpResponseException(response);
        }

        List<AliasTemplate> aliasTemplates = new();
        foreach (AliasTemplateData aliasTemplateData in request.AliasTemplatesData)
        {
            if (aliasTemplateData.Id == Guid.Empty)
            {
                AliasTemplate aliasTemplate = new(aliasTemplateData.Name)
                {
                    DataGroupTemplateId = aliasTemplateData.DataGroupTemplateId
                };
                _unitOfWork.AliasTemplateRepository.Create(aliasTemplate);
                aliasTemplates.Add(aliasTemplate);
            } else {
                AliasTemplate? aliasTemplate = await _unitOfWork.AliasTemplateRepository.GetAliasTemplate(aliasTemplateData.Id);
                if (aliasTemplate == null)
                {
                    HttpResponseMessage response = HttpUtilities.HttpResponseMessageBuilder("Alias Template Not Found");
                    throw new NotFoundHttpResponseException(response);
                }
                aliasTemplate.Name = aliasTemplateData.Name;
                aliasTemplates.Add(aliasTemplate);
            }
        }

        templateToEdit.Name = request.Name;
        templateToEdit.Content = request.Content;
        templateToEdit.AliasTemplates = aliasTemplates;
        _unitOfWork.TemplateRepository.Update(templateToEdit);
        await _unitOfWork.Save();

        return Unit.Value;
    }
}