﻿using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.DataGroupTemplates.Queries.GetDataGroupTemplate;

public class GetDataGroupTemplateQueryHandler : IRequestHandler<GetDataGroupTemplateQuery, DataGroupTemplate?>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetDataGroupTemplateQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<DataGroupTemplate?> Handle(GetDataGroupTemplateQuery request, CancellationToken cancellationToken)
    {
        DataGroupTemplate? dataGroupTemplate = await _unitOfWork.DataGroupTemplateRepository.GetDataGroupTemplate(request.DataGroupTemplateId);

        return dataGroupTemplate;
    }
}
