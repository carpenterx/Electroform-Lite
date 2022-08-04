using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.UserData.Commands.CreateData;

public class CreateDataCommandHandler : IRequestHandler<CreateDataCommand, int>
{
    private readonly IDataRepository _repository;

    public CreateDataCommandHandler(IDataRepository repository)
    {
        _repository = repository;
    }

    public Task<int> Handle(CreateDataCommand request, CancellationToken cancellationToken)
    {
        Data data = new(request.DataTemplate, request.DataValue);
        _repository.Create(data);

        return Task.FromResult(data.Id);
    }
}