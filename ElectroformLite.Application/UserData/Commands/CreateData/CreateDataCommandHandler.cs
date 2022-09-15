using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.UserData.Commands.CreateData;

public class CreateDataCommandHandler : IRequestHandler<CreateDataCommand, Data?>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateDataCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Data?> Handle(CreateDataCommand request, CancellationToken cancellationToken)
    {
        DataTemplate? dataTemplate = await _unitOfWork.DataTemplateRepository.GetDataTemplateAndData(request.DataTemplateId);
        if (dataTemplate is null)
        {
            return null;
        }

        //Data data = new(dataTemplate.Placeholder, request.Value, dataTemplate.DataTypeValue);
        Data data = new(request.Value, dataTemplate.Id);
        _unitOfWork.DataRepository.Create(data);
        dataTemplate.UserData.Add(data);
        await _unitOfWork.Save();

        return data;
    }
}