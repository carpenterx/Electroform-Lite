﻿using ElectroformLite.Application.Exceptions;
using ElectroformLite.Application.Interfaces;
using ElectroformLite.Application.Utils;
using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.Documents.Queries.GetDocument;

public class GetDocumentQueryHandler : IRequestHandler<GetDocumentQuery, Document>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetDocumentQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Document> Handle(GetDocumentQuery request, CancellationToken cancellationToken)
    {
        Document? document = await _unitOfWork.DocumentRepository.GetDocument(request.DocumentId);

        if (document == null)
        {
            HttpResponseMessage response = HttpUtilities.HttpResponseMessageBuilder("Document Not Found");
            throw new NotFoundHttpResponseException(response);
        }

        return document;
    }
}