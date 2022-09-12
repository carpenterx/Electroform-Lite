using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.DataGroups.Commands.EditDataGroup;

public class EditDataGroupCommandHandler : IRequestHandler<EditDataGroupCommand, DataGroup?>
{
    private readonly IUnitOfWork _unitOfWork;

    public EditDataGroupCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<DataGroup?> Handle(EditDataGroupCommand request, CancellationToken cancellationToken)
    {
        DataGroup dataGroupFromRequest = request.DataGroup;
        DataGroup? dataGroupToEdit = await _unitOfWork.DataGroupRepository.GetDataGroup(dataGroupFromRequest.Id);
        if (dataGroupToEdit == null)
        {
            return null;
        }
        dataGroupToEdit.Name = dataGroupFromRequest.Name;
        _unitOfWork.DataGroupRepository.Update(dataGroupToEdit);
        await _unitOfWork.Save();

        return dataGroupToEdit;
    }
}