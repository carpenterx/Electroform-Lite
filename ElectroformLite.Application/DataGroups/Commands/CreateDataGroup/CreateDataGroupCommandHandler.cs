using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.DataGroups.Commands.CreateDataGroup;

public class CreateDataGroupCommandHandler : IRequestHandler<CreateDataGroupCommand, DataGroup?>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateDataGroupCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<DataGroup?> Handle(CreateDataGroupCommand request, CancellationToken cancellationToken)
    {
        DataGroupTemplate? dataGroupTemplate = await _unitOfWork.DataGroupTemplateRepository.GetDataGroupTemplate(request.DataGroupTemplateId);

        if (dataGroupTemplate is null)
        {
            return null;
        }

        //DataGroup dataGroup = new(request.Name,dataGroupTemplate.Name);
        DataGroup dataGroup = new(request.Name);
        _unitOfWork.DataGroupRepository.Create(dataGroup);

        foreach (KeyValuePair<Guid, string> dataProperty in request.DataProperties)
        {
            DataTemplate? dataTemplate = await _unitOfWork.DataTemplateRepository.GetDataTemplate(dataProperty.Key);
            if (dataTemplate is null)
            {
                return null;
            }

            //Data data = new(dataTemplate.Placeholder, dataProperty.Value, dataTemplate.DataTypeValue);
            Data data = new(dataProperty.Value, dataTemplate.Id);
            _unitOfWork.DataRepository.Create(data);
            dataTemplate.UserData.Add(data);
            dataGroup.UserData.Add(data);
        }

        dataGroupTemplate.DataGroups.Add(dataGroup);
        await _unitOfWork.Save();

        return dataGroup;
    }
}