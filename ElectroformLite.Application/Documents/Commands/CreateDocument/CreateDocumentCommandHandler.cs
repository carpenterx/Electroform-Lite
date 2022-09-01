using ElectroformLite.Application.Interfaces;
using ElectroformLite.Application.Utils;
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

        Dictionary<string, string> dataDictionary = new();
        foreach (DataGroup dataGroup in dataGroups)
        {
            foreach (Data data in dataGroup.UserData)
            {
                dataDictionary.Add($"[{dataGroup.DataGroupPlaceholder}.{data.Placeholder}]", data.Value);
            }
        }
        string documentName = TextUtilities.ReplacePlaceholders(template.Name, dataDictionary);
        string documentContent = TextUtilities.ReplacePlaceholders(template.Content, dataDictionary);
        Document document = new(documentName, documentContent);
        _unitOfWork.DocumentRepository.Create(document);
        document.DataGroups.AddRange(dataGroups);
        template.Documents.Add(document);
        await _unitOfWork.Save();

        return document;
    }
}