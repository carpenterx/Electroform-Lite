using ElectroformLite.Application.DataTemplates.Commands.CreateDataTemplate;
using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.DataGroupTemplates.Commands.CreateDataGroupTemplate;

public class CreateDataGroupTemplateCommandHandler : IRequestHandler<CreateDataGroupTemplateCommand, int>
{
    private readonly IDataGroupTemplateRepository _repository;

    public CreateDataGroupTemplateCommandHandler(IDataGroupTemplateRepository repository)
    {
        _repository = repository;
    }

    public Task<int> Handle(CreateDataGroupTemplateCommand request, CancellationToken cancellationToken)
    {
        DataGroupTemplate dataGroupTemplate = new(request.TemplateName, request.TemplateType, request.DataTemplates);
        _repository.Create(dataGroupTemplate);

        return Task.FromResult(dataGroupTemplate.Id);
    }
}