using ElectroformLite.Application.Exceptions;
using ElectroformLite.Application.Interfaces;
using ElectroformLite.Application.Utils;
using ElectroformLite.Domain.Models;
using MediatR;
using System.Net;

namespace ElectroformLite.Application.DataTemplates.Commands.CreateDataTemplate;

public class CreateDataTemplateCommandHandler : IRequestHandler<CreateDataTemplateCommand, DataTemplate>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateDataTemplateCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<DataTemplate> Handle(CreateDataTemplateCommand request, CancellationToken cancellationToken)
    {
        DataType? dataType = await _unitOfWork.DataTypeRepository.GetFullDataType(request.DataTypeId);

        if (dataType is null)
        {
            /*var response = new HttpResponseMessage(HttpStatusCode.NotFound)
            {
                ReasonPhrase = "Data Type Not Found"
            };*/
            HttpResponseMessage response = HttpUtilities.HttpResponseMessageBuilder("Data Type Not Found");
            throw new NotFoundHttpResponseException(response);
        }

        DataTemplate dataTemplate = new(request.Placeholder, request.DataTypeId);
        dataTemplate.DataType = dataType;
        _unitOfWork.DataTemplateRepository.Create(dataTemplate);

        //dataType.DataTemplates.Add(dataTemplate);
        await _unitOfWork.Save();

        return dataTemplate;
    }
}