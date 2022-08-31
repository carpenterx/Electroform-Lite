using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.DataGroupTemplates.Commands.CreateDataGroupTemplate;

public class CreateDataGroupTemplateCommandHandler : IRequestHandler<CreateDataGroupTemplateCommand, DataGroupTemplate?>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateDataGroupTemplateCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<DataGroupTemplate?> Handle(CreateDataGroupTemplateCommand request, CancellationToken cancellationToken)
    {
        DataGroupType? dataGroupType = await _unitOfWork.DataGroupTypeRepository.GetDataGroupType(request.DataGroupTypeId);

        if (dataGroupType is null)
        {
            return null;
        }

        DataGroupTemplate dataGroupTemplate = new(request.Name);
        _unitOfWork.DataGroupTemplateRepository.Create(dataGroupTemplate);

        foreach (Guid dataId in request.DataTemplateIds)
        {
            DataTemplate? dataTemplate = await _unitOfWork.DataTemplateRepository.GetDataTemplate(dataId);

            if (dataTemplate is null)
            {
                return null;
            }

            dataGroupTemplate.DataTemplates.Add(dataTemplate);
        }

        dataGroupType.DataGroupTemplates.Add(dataGroupTemplate);
        await _unitOfWork.Save();

        return dataGroupTemplate;
    }
}