using ElectroformLite.Application.Interfaces;
using MediatR;

namespace ElectroformLite.Application.Templates.Commands.EditTemplate;

public class EditTemplateCommandHandler : IRequestHandler<EditTemplateCommand>
{
    private readonly ITemplateRepository _repository;

    public EditTemplateCommandHandler(ITemplateRepository repository)
    {
        _repository = repository;
    }

    public Task<Unit> Handle(EditTemplateCommand request, CancellationToken cancellationToken)
    {
        _repository.Update(request.Template);

        return Task.FromResult(Unit.Value);
    }
}