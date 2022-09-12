using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.UserData.Commands.EditData;

public class EditDataCommandHandler : IRequestHandler<EditDataCommand, Data?>
{
    private readonly IUnitOfWork _unitOfWork;

    public EditDataCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Data?> Handle(EditDataCommand request, CancellationToken cancellationToken)
    {
        Data dataFromRequest = request.Data;
        Data? dataToEdit = await _unitOfWork.DataRepository.GetData(dataFromRequest.Id);
        if (dataToEdit == null)
        {
            return null;
        }
        dataToEdit.Value = dataFromRequest.Value;
        _unitOfWork.DataRepository.Update(dataToEdit);
        await _unitOfWork.Save();

        return dataToEdit;
    }
}