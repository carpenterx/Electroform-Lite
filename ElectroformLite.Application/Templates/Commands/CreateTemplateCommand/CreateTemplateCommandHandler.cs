using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.Templates.Commands.CreateTemplateCommand;

public class CreateTemplateCommandHandler : IRequestHandler<CreateTemplateCommand, int>
{
    private readonly ITemplateRepository _repository;

    public CreateTemplateCommandHandler(ITemplateRepository repository)
    {
        _repository = repository;
    }

    public Task<int> Handle(CreateTemplateCommand request, CancellationToken cancellationToken)
    {
        Template template = new(request.TemplateName, request.TemplateContent);
        _repository.Create(template);

        return Task.FromResult(template.Id);
    }
}