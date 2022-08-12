using ElectroformLite.Application.Interfaces;
using MediatR;

namespace ElectroformLite.Application.DataGroupTypes.Commands.EditDataGroupType;

public class EditDataGroupTypeCommandHandler : IRequestHandler<EditDataGroupTypeCommand>
{
    private readonly IDataGroupTypeRepository _repository;

    public EditDataGroupTypeCommandHandler(IDataGroupTypeRepository repository)
    {
        _repository = repository;
    }

    public Task<Unit> Handle(EditDataGroupTypeCommand request, CancellationToken cancellationToken)
    {
        _repository.Update(request.DataGroupType);

        return Task.FromResult(Unit.Value);
    }
}