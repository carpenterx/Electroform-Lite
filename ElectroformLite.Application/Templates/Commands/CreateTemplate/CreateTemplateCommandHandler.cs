using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.Templates.Commands.CreateTemplate;

public class CreateTemplateCommandHandler : IRequestHandler<CreateTemplateCommand, Template?>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateTemplateCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Template?> Handle(CreateTemplateCommand request, CancellationToken cancellationToken)
    {
        Template template = new(request.Name, request.Content);
        _unitOfWork.TemplateRepository.Create(template);

        foreach (Guid dataGroupTemplateId in request.DataGroupTemplateIds)
        {
            DataGroupTemplate? dataGroupTemplate = await _unitOfWork.DataGroupTemplateRepository.GetDataGroupTemplate(dataGroupTemplateId);

            if (dataGroupTemplate == null)
            {
                return null;
            }

            //template.DataGroupTemplates.Add(dataGroupTemplate);
        }
        await _unitOfWork.Save();

        return template;
    }
}