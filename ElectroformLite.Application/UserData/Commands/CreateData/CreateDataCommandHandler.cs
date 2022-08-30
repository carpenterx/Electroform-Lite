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
        Data data = new(request.Value);
        _unitOfWork.DataRepository.Create(data);
        DataTemplate? dataTemplate = await _unitOfWork.DataTemplateRepository.GetDataTemplate(request.DataTemplateId);

        if (dataTemplate is null)
        {
            return null;
        }

        dataTemplate.UserData.Add(data);
        await _unitOfWork.Save();

        return data;
    }
}