using ElectroformLite.Application.Interfaces;
using MediatR;

namespace ElectroformLite.Application.UserData.Commands.EditData;

public class EditDataCommandHandler : IRequestHandler<EditDataCommand>
{
    private readonly IDataRepository _repository;

    public EditDataCommandHandler(IDataRepository repository)
    {
        _repository = repository;
    }

    public Task<Unit> Handle(EditDataCommand request, CancellationToken cancellationToken)
    {
        _repository.Update(request.Data);

        return Task.FromResult(Unit.Value);
    }
}