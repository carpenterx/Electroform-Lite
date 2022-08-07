using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.DataGroupTypes.Commands.CreateDataGroupType;

public class CreateDataGroupTypeCommandHandler : IRequestHandler<CreateDataGroupTypeCommand, int>
{
    private readonly IDataGroupTypeRepository _repository;

    public CreateDataGroupTypeCommandHandler(IDataGroupTypeRepository repository)
    {
        _repository = repository;
    }

    public Task<int> Handle(CreateDataGroupTypeCommand request, CancellationToken cancellationToken)
    {
        DataGroupType dataGroupType = new(request.TypeValue);
        _repository.Create(dataGroupType);

        return Task.FromResult(dataGroupType.Id);
    }
}