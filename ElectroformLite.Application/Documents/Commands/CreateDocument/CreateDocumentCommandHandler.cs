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

        if (template.DataGroupTemplates.Count != request.DataGroupIds.Count)
        {
            return null;
        }

        List<DataGroup> dataGroups = await _unitOfWork.DataGroupRepository.GetDataGroupsWithIds(request.DataGroupIds);
        string documentName = template.Name;
        string documentContent = template.Content;
        foreach (DataGroup dataGroup in dataGroups)
        {
            foreach (Data data in dataGroup.UserData)
            {
                documentName = documentName.Replace($"[{dataGroup.DataGroupPlaceholder}.{data.Placeholder}]", data.Value);
                documentContent = documentContent.Replace($"[{dataGroup.DataGroupPlaceholder}.{data.Placeholder}]", data.Value);
            }
        }

        Document document = new(documentName, documentContent);
        _unitOfWork.DocumentRepository.Create(document);
        document.DataGroups.AddRange(dataGroups);
        template.Documents.Add(document);
        await _unitOfWork.Save();

        return document;
    }
}