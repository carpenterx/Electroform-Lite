using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.Documents.Commands.CreateDocument;

public class CreateDocumentCommandHandler : IRequestHandler<CreateDocumentCommand, Document?>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateDocumentCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Document?> Handle(CreateDocumentCommand request, CancellationToken cancellationToken)
    {
        Template? template = await _unitOfWork.TemplateRepository.GetTemplate(request.TemplateId);
        if (template == null)
        {
            return null;
        }

        Document document = new(template.Name, template.Content);
        _unitOfWork.DocumentRepository.Create(document);

        foreach (Guid dataGroupId in request.DataGroupIds)
        {
            DataGroup? dataGroup = await _unitOfWork.DataGroupRepository.GetDataGroup(dataGroupId);
            if (dataGroup == null)
            {
                return null;
            }

            document.DataGroups.Add(dataGroup);
        }
        template.Documents.Add(document);
        await _unitOfWork.Save();

        return document;
    }
}