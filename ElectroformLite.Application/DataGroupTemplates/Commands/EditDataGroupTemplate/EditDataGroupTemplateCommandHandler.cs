using ElectroformLite.Application.Interfaces;
using MediatR;

namespace ElectroformLite.Application.DataGroupTemplates.Commands.EditDataGroupTemplate;

public class EditDataGroupTemplateCommandHandler : IRequestHandler<EditDataGroupTemplateCommand>
{
    private readonly IDataGroupTemplateRepository _repository;

    public EditDataGroupTemplateCommandHandler(IDataGroupTemplateRepository repository)
    {
        _repository = repository;
    }

    public Task<Unit> Handle(EditDataGroupTemplateCommand request, CancellationToken cancellationToken)
    {
        _repository.Update(request.DataGroupTemplate);

        return Task.FromResult(Unit.Value);
    }
}