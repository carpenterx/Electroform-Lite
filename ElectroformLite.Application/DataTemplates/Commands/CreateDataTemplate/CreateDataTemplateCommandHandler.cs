using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.DataTemplates.Commands.CreateDataTemplate;

public class CreateDataTemplateCommandHandler : IRequestHandler<CreateDataTemplateCommand, int>
{
    private readonly IDataTemplateRepository _repository;

    public CreateDataTemplateCommandHandler(IDataTemplateRepository repository)
    {
        _repository = repository;
    }

    public Task<int> Handle(CreateDataTemplateCommand request, CancellationToken cancellationToken)
    {
        DataTemplate dataTemplate = new(request.TemplatePlaceholder, request.TemplateType);
        _repository.Create(dataTemplate);

        return Task.FromResult(dataTemplate.Id);
    }
}