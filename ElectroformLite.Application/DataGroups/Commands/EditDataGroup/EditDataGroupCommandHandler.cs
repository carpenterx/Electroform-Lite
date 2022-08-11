using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.DataGroups.Commands.EditDataGroup;

public class EditDataGroupCommandHandler : IRequestHandler<EditDataGroupCommand>
{
    private readonly IDataGroupRepository _repository;

    public EditDataGroupCommandHandler(IDataGroupRepository repository)
    {
        _repository = repository;
    }

    public Task<Unit> Handle(EditDataGroupCommand request, CancellationToken cancellationToken)
    {
        DataGroup dataGroup = request.DataGroup;
        _repository.Update(dataGroup);

        return Task.FromResult(Unit.Value;
    }
}