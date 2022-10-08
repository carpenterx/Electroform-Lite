using ElectroformLite.Application.Exceptions;
using ElectroformLite.Application.Interfaces;
using ElectroformLite.Application.Utils;
using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.Templates.Commands.CreateTemplate;

public class CreateTemplateCommandHandler : IRequestHandler<CreateTemplateCommand, Template>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateTemplateCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Template> Handle(CreateTemplateCommand request, CancellationToken cancellationToken)
    {
        Template template = new(request.Name, request.Content);
        _unitOfWork.TemplateRepository.Create(template);

        foreach (KeyValuePair<Guid, string> aliasTemplateDataItem in request.AliasTemplateData)
        {
            DataGroupTemplate? dataGroupTemplate = await _unitOfWork.DataGroupTemplateRepository.GetDataGroupTemplate(aliasTemplateDataItem.Key);

            if (dataGroupTemplate == null)
            {
                HttpResponseMessage response = HttpUtilities.HttpResponseMessageBuilder("Data Group Template Not Found");
                throw new NotFoundHttpResponseException(response);
            }

            AliasTemplate aliasTemplate = new(aliasTemplateDataItem.Value);
            _unitOfWork.AliasTemplateRepository.Create(aliasTemplate);
            dataGroupTemplate.AliasTemplates.Add(aliasTemplate);
            template.AliasTemplates.Add(aliasTemplate);
        }
        await _unitOfWork.Save();

        return template;
    }
}