using ElectroformLite.Application.Exceptions;
using ElectroformLite.Application.Interfaces;
using ElectroformLite.Application.Utils;
using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.UserData.Commands.EditData;

public class EditDataCommandHandler : IRequestHandler<EditDataCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public EditDataCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(EditDataCommand request, CancellationToken cancellationToken)
    {
        Data dataFromRequest = request.Data;
        Data? dataToEdit = await _unitOfWork.DataRepository.GetData(dataFromRequest.Id);
        if (dataToEdit == null)
        {
            HttpResponseMessage response = HttpUtilities.HttpResponseMessageBuilder("Data Not Found");
            throw new NotFoundHttpResponseException(response);
        }
        dataToEdit.Value = dataFromRequest.Value;
        _unitOfWork.DataRepository.Update(dataToEdit);
        await _unitOfWork.Save();

        return Unit.Value;
    }
}