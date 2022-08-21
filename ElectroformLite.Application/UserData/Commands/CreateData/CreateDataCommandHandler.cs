using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.UserData.Commands.CreateData;

public class CreateDataCommandHandler : IRequestHandler<CreateDataCommand, Guid>
{
    private readonly IDataRepository _repository;

    public CreateDataCommandHandler(IDataRepository repository)
    {
        _repository = repository;
    }

    public Task<Guid> Handle(CreateDataCommand request, CancellationToken cancellationToken)
    {
        Data data = request.Data;
        _repository.Create(data);

        return Task.FromResult(data.Id);
    }
}