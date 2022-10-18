using ElectroformLite.Application.Exceptions;
using ElectroformLite.Application.Interfaces;
using ElectroformLite.Application.Utils;
using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.DataGroupTemplates.Commands.EditDataGroupTemplate;

public class EditDataGroupTemplateCommandHandler : IRequestHandler<EditDataGroupTemplateCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public EditDataGroupTemplateCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(EditDataGroupTemplateCommand request, CancellationToken cancellationToken)
    {
        DataGroupTemplate? dataGroupTemplateToEdit = await _unitOfWork.DataGroupTemplateRepository.GetDataGroupTemplateWithDataTemplates(request.DataGroupTemplateId);
        if (dataGroupTemplateToEdit == null)
        {
            HttpResponseMessage response = HttpUtilities.HttpResponseMessageBuilder("Data Group Template Not Found");
            throw new NotFoundHttpResponseException(response);
        }
        dataGroupTemplateToEdit.DataTemplates.Clear();
        foreach (Guid dataTemplateId in request.DataTemplateIds)
        {
            DataTemplate? dataTemplate = await _unitOfWork.DataTemplateRepository.GetDataTemplate(dataTemplateId);

            if (dataTemplate == null)
            {
                HttpResponseMessage response = HttpUtilities.HttpResponseMessageBuilder("Data Template Not Found");
                throw new NotFoundHttpResponseException(response);
            }

            dataGroupTemplateToEdit.DataTemplates.Add(dataTemplate);
        }
        _unitOfWork.DataGroupTemplateRepository.Update(dataGroupTemplateToEdit);
        await _unitOfWork.Save();

        return Unit.Value;
    }
}