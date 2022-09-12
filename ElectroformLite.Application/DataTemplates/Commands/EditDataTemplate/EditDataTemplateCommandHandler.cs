using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.DataTemplates.Commands.EditDataTemplate;

public class EditDataTemplateCommandHandler : IRequestHandler<EditDataTemplateCommand, DataTemplate?>
{
    private readonly IUnitOfWork _unitOfWork;

    public EditDataTemplateCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<DataTemplate?> Handle(EditDataTemplateCommand request, CancellationToken cancellationToken)
    {
        DataTemplate dataTemplateFromRequest = request.DataTemplate;
        DataTemplate? dataTemplateToEdit = await _unitOfWork.DataTemplateRepository.GetDataTemplate(dataTemplateFromRequest.Id);
        if (dataTemplateToEdit == null)
        {
            return null;
        }
        dataTemplateToEdit.Placeholder = dataTemplateFromRequest.Placeholder;
        _unitOfWork.DataTemplateRepository.Update(dataTemplateToEdit);
        await _unitOfWork.Save();

        return dataTemplateToEdit;
    }
}