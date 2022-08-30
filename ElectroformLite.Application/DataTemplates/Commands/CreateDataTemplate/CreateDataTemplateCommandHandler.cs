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
        DataTemplate dataTemplate = new(request.Placeholder);
        _unitOfWork.DataTemplateRepository.Create(dataTemplate);
        DataType? dataType = await _unitOfWork.DataTypeRepository.GetDataType(request.DataTypeId);

        if (dataType is null)
        {
            return null;
        }

        dataType.DataTemplates.Add(dataTemplate);
        await _unitOfWork.Save();

        return dataTemplate;
    }
}