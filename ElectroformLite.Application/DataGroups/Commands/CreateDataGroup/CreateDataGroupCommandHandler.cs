using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.DataGroups.Commands.CreateDataGroup;

public class CreateDataGroupCommandHandler : IRequestHandler<CreateDataGroupCommand, DataGroup>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateDataGroupCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<DataGroup> Handle(CreateDataGroupCommand request, CancellationToken cancellationToken)
    {
        DataGroup dataGroup = request.DataGroup;

        _unitOfWork.DataGroupRepository.Create(dataGroup);
        await _unitOfWork.Save();

        return dataGroup;
    }
}