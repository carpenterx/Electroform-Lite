using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.DataTemplates.Commands.DeleteDataTemplate;

public class DeleteDataTemplateCommandHandler : IRequestHandler<DeleteDataTemplateCommand, DataTemplate?>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteDataTemplateCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<DataTemplate?> Handle(DeleteDataTemplateCommand request, CancellationToken cancellationToken)
    {
        DataTemplate? dataTemplate = await _unitOfWork.DataTemplateRepository.GetDataTemplate(request.DataTemplateId);
        if (dataTemplate == null)
        {
            return null;
        }

        _unitOfWork.DataTemplateRepository.Delete(dataTemplate);
        await _unitOfWork.Save();

        return dataTemplate;
    }
}