using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.UserData.Commands.DeleteData;

public class DeleteDataCommandHandler : IRequestHandler<DeleteDataCommand, Data?>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteDataCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Data?> Handle(DeleteDataCommand request, CancellationToken cancellationToken)
    {
        Data? data = await _unitOfWork.DataRepository.GetData(request.DataId);
        if (data == null)
        {
            return null;
        }

        _unitOfWork.DataRepository.Delete(data);
        await _unitOfWork.Save();

        return data;
    }
}