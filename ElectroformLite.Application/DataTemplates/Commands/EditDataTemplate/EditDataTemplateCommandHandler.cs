using ElectroformLite.Application.Interfaces;
using MediatR;

namespace ElectroformLite.Application.DataTemplates.Commands.EditDataTemplate;

public class EditDataTemplateCommandHandler : IRequestHandler<EditDataTemplateCommand>
{
    private readonly IDataTemplateRepository _repository;

    public EditDataTemplateCommandHandler(IDataTemplateRepository repository)
    {
        _repository = repository;
    }

    public Task<Unit> Handle(EditDataTemplateCommand request, CancellationToken cancellationToken)
    {
        _repository.Update(request.DataTemplate);

        return Task.FromResult(Unit.Value);
    }
}