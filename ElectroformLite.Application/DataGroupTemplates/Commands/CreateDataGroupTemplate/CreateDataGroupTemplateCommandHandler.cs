using ElectroformLite.Application.Exceptions;
using ElectroformLite.Application.Interfaces;
using ElectroformLite.Application.Utils;
using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.DataGroupTemplates.Commands.CreateDataGroupTemplate;

public class CreateDataGroupTemplateCommandHandler : IRequestHandler<CreateDataGroupTemplateCommand, DataGroupTemplate>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateDataGroupTemplateCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<DataGroupTemplate> Handle(CreateDataGroupTemplateCommand request, CancellationToken cancellationToken)
    {
        DataGroupType? dataGroupType = await _unitOfWork.DataGroupTypeRepository.GetFullDataGroupType(request.DataGroupTypeId);

        if (dataGroupType is null)
        {
            HttpResponseMessage response = HttpUtilities.HttpResponseMessageBuilder("Data Group Type Not Found");
            throw new NotFoundHttpResponseException(response);
        }

        DataGroupTemplate dataGroupTemplate = new();
        _unitOfWork.DataGroupTemplateRepository.Create(dataGroupTemplate);

        foreach (Guid dataId in request.DataTemplateIds)
        {
            DataTemplate? dataTemplate = await _unitOfWork.DataTemplateRepository.GetDataTemplate(dataId);

            if (dataTemplate is null)
            {
                HttpResponseMessage response = HttpUtilities.HttpResponseMessageBuilder("Data Template Not Found");
                throw new NotFoundHttpResponseException(response);
            }

            dataGroupTemplate.DataTemplates.Add(dataTemplate);
        }

        dataGroupType.DataGroupTemplates.Add(dataGroupTemplate);
        await _unitOfWork.Save();

        return dataGroupTemplate;
    }
}