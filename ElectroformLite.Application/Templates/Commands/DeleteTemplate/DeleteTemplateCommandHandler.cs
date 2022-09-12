﻿using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.Templates.Commands.DeleteTemplate;

public class DeleteTemplateCommandHandler : IRequestHandler<DeleteTemplateCommand, Template?>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteTemplateCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Template?> Handle(DeleteTemplateCommand request, CancellationToken cancellationToken)
    {
        Template? template = await _unitOfWork.TemplateRepository.GetTemplate(request.TemplateId);
        if (template == null)
        {
            return null;
        }

        _unitOfWork.TemplateRepository.Delete(template);
        await _unitOfWork.Save();

        return template;
    }
}