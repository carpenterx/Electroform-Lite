﻿using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.Documents.Commands.CreateDocument;

public class CreateDocumentCommand : IRequest<Document>
{
    public Document Document { get; set; }

    public CreateDocumentCommand(Document document)
    {
        Document = document;
    }
}
