using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.DataGroupTypes.Commands.EditDataGroupType;

public class EditDataGroupTypeCommandHandler : IRequestHandler<EditDataGroupTypeCommand, DataGroupType?>
{
    private readonly IUnitOfWork _unitOfWork;

    public EditDataGroupTypeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<DataGroupType?> Handle(EditDataGroupTypeCommand request, CancellationToken cancellationToken)
    {
        DataGroupType dataGroupTypeFromRequest = request.DataGroupType;
        DataGroupType? dataGroupTypeToEdit = await _unitOfWork.DataGroupTypeRepository.GetDataGroupType(dataGroupTypeFromRequest.Id);
        if (dataGroupTypeToEdit == null)
        {
            return null;
        }
        dataGroupTypeToEdit.Value = dataGroupTypeFromRequest.Value;
        _unitOfWork.DataGroupTypeRepository.Update(dataGroupTypeToEdit);
        await _unitOfWork.Save();

        return dataGroupTypeToEdit;
    }
}