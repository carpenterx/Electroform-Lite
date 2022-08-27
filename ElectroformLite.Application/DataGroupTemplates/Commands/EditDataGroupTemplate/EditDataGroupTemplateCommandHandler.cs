using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.DataGroupTemplates.Commands.EditDataGroupTemplate;

public class EditDataGroupTemplateCommandHandler : IRequestHandler<EditDataGroupTemplateCommand, DataGroupTemplate?>
{
    private readonly IUnitOfWork _unitOfWork;

    public EditDataGroupTemplateCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<DataGroupTemplate?> Handle(EditDataGroupTemplateCommand request, CancellationToken cancellationToken)
    {
        DataGroupTemplate dataGroupTemplateFromRequest = request.DataGroupTemplate;
        DataGroupTemplate? dataGroupTemplateToEdit = await _unitOfWork.DataGroupTemplateRepository.GetDataGroupTemplate(dataGroupTemplateFromRequest.Id);
        if (dataGroupTemplateToEdit == null)
        {
            return null;
        }
        dataGroupTemplateToEdit.Name = dataGroupTemplateFromRequest.Name;
        _unitOfWork.DataGroupTemplateRepository.Update(dataGroupTemplateToEdit);
        await _unitOfWork.Save();

        return dataGroupTemplateToEdit;
    }
}