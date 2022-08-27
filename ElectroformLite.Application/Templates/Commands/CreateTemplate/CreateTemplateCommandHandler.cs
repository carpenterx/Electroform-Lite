using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.Templates.Commands.CreateTemplate;

public class CreateTemplateCommandHandler : IRequestHandler<CreateTemplateCommand, Template>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateTemplateCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Template> Handle(CreateTemplateCommand request, CancellationToken cancellationToken)
    {
        Template template = request.Template;

        _unitOfWork.TemplateRepository.Create(template);
        await _unitOfWork.Save();

        return template;
    }
}