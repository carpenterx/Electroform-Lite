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
        DataGroup dataGroup = new(request.Name);
        _unitOfWork.DataGroupRepository.Create(dataGroup);
        DataGroupTemplate? dataGroupTemplate = await _unitOfWork.DataGroupTemplateRepository.GetDataGroupTemplate(request.DataGroupTemplateId);

        if (dataGroupTemplate is null)
        {
            return null;
        }

        dataGroupTemplate.DataGroups.Add(dataGroup);
        await _unitOfWork.Save();

        return dataGroup;
    }
}