using ElectroformLite.Application.Interfaces;
using MediatR;

namespace ElectroformLite.Application.DataGroupTypes.Commands.EditDataGroupType;

public class EditDataGroupTypeCommandHandler : IRequestHandler<EditDataGroupTypeCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public EditDataGroupTypeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(EditDataGroupTypeCommand request, CancellationToken cancellationToken)
    {
        _unitOfWork.DataGroupTypeRepository.Update(request.DataGroupType);
        await _unitOfWork.Save();

        return Unit.Value;
    }
}