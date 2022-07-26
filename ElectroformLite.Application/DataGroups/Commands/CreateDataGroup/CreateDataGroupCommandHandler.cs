﻿using ElectroformLite.Application.Exceptions;
using ElectroformLite.Application.Interfaces;
using ElectroformLite.Application.Utils;
using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.DataGroups.Commands.CreateDataGroup;

public class CreateDataGroupCommandHandler : IRequestHandler<CreateDataGroupCommand, DataGroup>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateDataGroupCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<DataGroup> Handle(CreateDataGroupCommand request, CancellationToken cancellationToken)
    {
        DataGroupTemplate? dataGroupTemplate = await _unitOfWork.DataGroupTemplateRepository.GetDataGroupTemplateWithDataGroups(request.DataGroupTemplateId);

        if (dataGroupTemplate is null)
        {
            HttpResponseMessage response = HttpUtilities.HttpResponseMessageBuilder("Data Group Template Not Found");
            throw new NotFoundHttpResponseException(response);
        }

        DataGroup dataGroup = new(request.Name);
        _unitOfWork.DataGroupRepository.Create(dataGroup);

        foreach (KeyValuePair<Guid, string> dataProperty in request.DataProperties)
        {
            DataTemplate? dataTemplate = await _unitOfWork.DataTemplateRepository.GetDataTemplateWithData(dataProperty.Key);
            if (dataTemplate is null)
            {
                HttpResponseMessage response = HttpUtilities.HttpResponseMessageBuilder("Data Template Not Found");
                throw new NotFoundHttpResponseException(response);
            }

            Data data = new(dataProperty.Value, dataTemplate.Id);
            _unitOfWork.DataRepository.Create(data);
            dataTemplate.UserData.Add(data);
            dataGroup.UserData.Add(data);
        }

        dataGroupTemplate.DataGroups.Add(dataGroup);
        await _unitOfWork.Save();

        return dataGroup;
    }
}