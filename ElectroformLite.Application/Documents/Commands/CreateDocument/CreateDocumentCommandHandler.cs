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
        Template? template = await _unitOfWork.TemplateRepository.GetTemplateWithDocuments(request.TemplateId);
        if (template == null)
        {
            return null;
        }

        /*if (template.DataGroupTemplates.Count != request.DataGroupIds.Count)
        {
            return null;
        }

        List<DataGroup> dataGroups = await _unitOfWork.DataGroupRepository.GetDataGroupsWithIds(request.DataGroupIds);*/

        //Dictionary<string, string> dataDictionary = new();
        /*foreach (DataGroup dataGroup in dataGroups)
        {
            foreach (Data data in dataGroup.UserData)
            {
                dataDictionary.Add($"[{dataGroup.DataGroupPlaceholder}.{data.DataTemplate.Placeholder}]", data.Value);
            }
        }*/

        List<Alias> aliases = new();
        Dictionary<string, string> dataDictionary = new();
        foreach (KeyValuePair<Guid, Guid> aliasDataItem in request.AliasData)
        {
            AliasTemplate? aliasTemplate = await _unitOfWork.AliasTemplateRepository.GetAliasTemplateWithAliases(aliasDataItem.Key);
            if (aliasTemplate == null)
            {
                return null;
            }

            DataGroup? dataGroup = await _unitOfWork.DataGroupRepository.GetDataGroupWithDataAndAliases(aliasDataItem.Value);
            if (dataGroup == null)
            {
                return null;
            }

            foreach (Data data in dataGroup.UserData)
            {
                //dataDictionary.Add($"[{aliasTemplate.Name}.{data.DataTemplate.Placeholder}]", data.Value);
                dataDictionary.Add(TextUtilities.GeneratePlaceholder(aliasTemplate.Name, data.DataTemplate.Placeholder), data.Value);
            }

            Alias alias = new();
            _unitOfWork.AliasRepository.Create(alias);
            aliasTemplate.Aliases.Add(alias);
            dataGroup.Aliases.Add(alias);
            
            aliases.Add(alias);
        }
        string documentName;
        if (string.IsNullOrEmpty(request.DocumentName))
        {
            documentName = template.Name;
        } else
        {
            documentName = request.DocumentName;
        }
        documentName = TextUtilities.ReplacePlaceholders(documentName, dataDictionary);
        string documentContent = TextUtilities.ReplacePlaceholders(template.Content, dataDictionary);
        Document document = new(documentName, documentContent);
        _unitOfWork.DocumentRepository.Create(document);
        document.Aliases = aliases;
        template.Documents.Add(document);
        await _unitOfWork.Save();
        //document.DataGroups.AddRange(dataGroups);
        /*document.DataGroups = dataGroups;
        template.Documents.Add(document);
        await _unitOfWork.Save();*/

        return document;
    }
}