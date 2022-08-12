using ElectroformLite.Application.Interfaces;
using MediatR;

namespace ElectroformLite.Application.UserData.Commands.DeleteData;

public class DeleteDataCommandHandler : IRequestHandler<DeleteDataCommand>
{
    private readonly IDataRepository _repository;

    public DeleteDataCommandHandler(IDataRepository repository)
    {
        _repository = repository;
    }

    public Task<Unit> Handle(DeleteDataCommand request, CancellationToken cancellationToken)
    {
        _repository.Delete(request.DataId);

        return Task.FromResult(Unit.Value);
    }
}