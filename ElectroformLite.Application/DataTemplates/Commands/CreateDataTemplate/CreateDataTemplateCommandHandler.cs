using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.DataTemplates.Commands.CreateDataTemplate;

public class CreateDataTemplateCommandHandler : IRequestHandler<CreateDataTemplateCommand, DataTemplate>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateDataTemplateCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<DataTemplate> Handle(CreateDataTemplateCommand request, CancellationToken cancellationToken)
    {
        DataTemplate dataTemplate = request.DataTemplate;

        _unitOfWork.DataTemplateRepository.Create(dataTemplate);
        await _unitOfWork.Save();

        return dataTemplate;
    }
}