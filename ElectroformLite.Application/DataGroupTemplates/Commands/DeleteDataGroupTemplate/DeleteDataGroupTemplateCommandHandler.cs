using ElectroformLite.Application.Exceptions;
using ElectroformLite.Application.Interfaces;
using ElectroformLite.Application.Utils;
using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.DataGroupTemplates.Commands.DeleteDataGroupTemplate;

public class DeleteDataGroupTemplateCommandHandler : IRequestHandler<DeleteDataGroupTemplateCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteDataGroupTemplateCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteDataGroupTemplateCommand request, CancellationToken cancellationToken)
    {
        DataGroupTemplate? dataGroupTemplate = await _unitOfWork.DataGroupTemplateRepository.GetDataGroupTemplate(request.DataGroupTemplateId);
        if (dataGroupTemplate == null)
        {
            HttpResponseMessage response = HttpUtilities.HttpResponseMessageBuilder("Data Group Template Not Found");
            throw new NotFoundHttpResponseException(response);
        }

        _unitOfWork.DataGroupTemplateRepository.Delete(dataGroupTemplate);
        await _unitOfWork.Save();

        return Unit.Value;
    }
}