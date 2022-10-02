using ElectroformLite.Application.Exceptions;
using ElectroformLite.Application.Interfaces;
using ElectroformLite.Application.Utils;
using ElectroformLite.Domain.Models;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace ElectroformLite.Application.DataGroups.Commands.EditDataGroup;

public class EditDataGroupCommandHandler : IRequestHandler<EditDataGroupCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public EditDataGroupCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(EditDataGroupCommand request, CancellationToken cancellationToken)
    {
        DataGroup? dataGroupToEdit = await _unitOfWork.DataGroupRepository.GetDataGroupWithData(request.DataGroupPutDto.Id);

        if (dataGroupToEdit == null)
        {
            HttpResponseMessage response = HttpUtilities.HttpResponseMessageBuilder("Data Group Not Found");
            throw new NotFoundHttpResponseException(response);
        }

        dataGroupToEdit.Name = request.DataGroupPutDto.Name;
        /*foreach (KeyValuePair<Guid, string> dataProperty in request.DataGroupPutDto.UserData)
        {
            dataGroupToEdit.UserData.First(d => d.Id == dataProperty.Key).Value = dataProperty.Value;
        }*/
        Dictionary<Guid, string> dataDictionary = request.DataGroupPutDto.UserData;
        foreach (var data in dataGroupToEdit.UserData)
        {
            if (dataDictionary.ContainsKey(data.Id))
            {
                data.Value = request.DataGroupPutDto.UserData[data.Id];
            }
            /*else
            {
                data.Value = "";
            }*/
        }
        _unitOfWork.DataGroupRepository.Update(dataGroupToEdit);
        await _unitOfWork.Save();

        return Unit.Value;
    }
}