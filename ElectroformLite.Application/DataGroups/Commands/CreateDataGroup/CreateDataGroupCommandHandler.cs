using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.DataGroups.Commands.CreateDataGroup;

public class CreateDataGroupCommandHandler : IRequestHandler<CreateDataGroupCommand, int>
{
    private readonly IDataGroupRepository _repository;

    public CreateDataGroupCommandHandler(IDataGroupRepository repository)
    {
        _repository = repository;
    }

    public Task<int> Handle(CreateDataGroupCommand request, CancellationToken cancellationToken)
    {
        DataGroup dataGroup = request.DataGroup;
        _repository.Create(dataGroup);

        return Task.FromResult(dataGroup.Id);
    }
}