using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.DataGroupTypes.Commands.CreateDataGroupType;

public class CreateDataGroupTypeCommandHandler : IRequestHandler<CreateDataGroupTypeCommand, DataGroupType>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateDataGroupTypeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<DataGroupType> Handle(CreateDataGroupTypeCommand request, CancellationToken cancellationToken)
    {
        DataGroupType dataGroupType = new(request.TypeValue);

        await _unitOfWork.DataGroupTypeRepository.Create(dataGroupType);
        await _unitOfWork.Save();

        return dataGroupType;
    }
}