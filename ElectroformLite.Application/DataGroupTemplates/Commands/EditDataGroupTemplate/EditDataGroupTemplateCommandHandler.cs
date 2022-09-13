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
        DataGroupTemplate? dataGroupTemplateToEdit = await _unitOfWork.DataGroupTemplateRepository.GetDataGroupTemplate(request.DataGroupTemplateId);
        if (dataGroupTemplateToEdit == null)
        {
            return null;
        }
        dataGroupTemplateToEdit.DataTemplates.Clear();
        foreach (Guid dataTemplateId in request.DataTemplateIds)
        {
            DataTemplate? dataTemplate = await _unitOfWork.DataTemplateRepository.GetDataTemplate(dataTemplateId);

            if (dataTemplate == null)
            {
                return null;
            }

            dataGroupTemplateToEdit.DataTemplates.Add(dataTemplate);
        }
        _unitOfWork.DataGroupTemplateRepository.Update(dataGroupTemplateToEdit);
        await _unitOfWork.Save();

        return dataGroupTemplateToEdit;
    }
}