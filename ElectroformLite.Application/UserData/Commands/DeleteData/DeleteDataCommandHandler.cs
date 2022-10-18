using ElectroformLite.Application.Exceptions;
using ElectroformLite.Application.Interfaces;
using ElectroformLite.Application.Utils;
using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.UserData.Commands.DeleteData;

public class DeleteDataCommandHandler : IRequestHandler<DeleteDataCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteDataCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteDataCommand request, CancellationToken cancellationToken)
    {
        Data? data = await _unitOfWork.DataRepository.GetData(request.DataId);
        if (data == null)
        {
            HttpResponseMessage response = HttpUtilities.HttpResponseMessageBuilder("Data Not Found");
            throw new NotFoundHttpResponseException(response);
        }

        _unitOfWork.DataRepository.Delete(data);
        await _unitOfWork.Save();

        return Unit.Value;
    }
}