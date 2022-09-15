using ElectroformLite.Application.Exceptions;
using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;
using MediatR;
using System.Net;

namespace ElectroformLite.Application.DataGroupTypes.Commands.EditDataGroupType;

public class EditDataGroupTypeCommandHandler : IRequestHandler<EditDataGroupTypeCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public EditDataGroupTypeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(EditDataGroupTypeCommand request, CancellationToken cancellationToken)
    {
        DataGroupType? dataGroupTypeToEdit = await _unitOfWork.DataGroupTypeRepository.GetDataGroupType(request.DataGroupTypeId);

        if (dataGroupTypeToEdit == null)
        {
            var response = new HttpResponseMessage(HttpStatusCode.NotFound)
            {
                ReasonPhrase = "Data Group Type Not Found"
            };
            throw new NotFoundHttpResponseException(response);
        }

        dataGroupTypeToEdit.Value = request.DataGroupTypeValue;
        _unitOfWork.DataGroupTypeRepository.Update(dataGroupTypeToEdit);
        await _unitOfWork.Save();

        return Unit.Value;
    }
}