using ElectroformLite.Application.Interfaces;
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
        DataGroupTemplate dataGroupTemplate = request.DataGroupTemplate;

        _unitOfWork.DataGroupTemplateRepository.Create(dataGroupTemplate);
        await _unitOfWork.Save();

        return dataGroupTemplate;
    }
}