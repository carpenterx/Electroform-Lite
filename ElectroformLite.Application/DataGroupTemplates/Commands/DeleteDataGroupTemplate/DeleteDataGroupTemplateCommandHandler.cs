using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.DataGroupTemplates.Commands.DeleteDataGroupTemplate;

public class DeleteDataGroupTemplateCommandHandler : IRequestHandler<DeleteDataGroupTemplateCommand, DataGroupTemplate?>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteDataGroupTemplateCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<DataGroupTemplate?> Handle(DeleteDataGroupTemplateCommand request, CancellationToken cancellationToken)
    {
        DataGroupTemplate? dataGroupTemplate = await _unitOfWork.DataGroupTemplateRepository.GetDataGroupTemplate(request.DataGroupTemplateId);
        if (dataGroupTemplate == null)
        {
            return null;
        }

        _unitOfWork.DataGroupTemplateRepository.Delete(dataGroupTemplate);
        await _unitOfWork.Save();

        return dataGroupTemplate;
    }
}