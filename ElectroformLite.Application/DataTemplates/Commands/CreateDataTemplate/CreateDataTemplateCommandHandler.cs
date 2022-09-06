using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.DataTemplates.Commands.CreateDataTemplate;

public class CreateDataTemplateCommandHandler : IRequestHandler<CreateDataTemplateCommand, DataTemplate?>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateDataTemplateCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<DataTemplate?> Handle(CreateDataTemplateCommand request, CancellationToken cancellationToken)
    {
        DataType? dataType = await _unitOfWork.DataTypeRepository.GetDataType(request.DataTypeId);

        if (dataType is null)
        {
            return null;
        }

        DataTemplate dataTemplate = new(request.Placeholder, request.DataTypeId);
        _unitOfWork.DataTemplateRepository.Create(dataTemplate);

        dataType.DataTemplates.Add(dataTemplate);
        await _unitOfWork.Save();

        return dataTemplate;
    }
}