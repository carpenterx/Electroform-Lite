using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.UserData.Commands.CreateData;

public class CreateDataCommand : IRequest<Data>
{
    public Data Data { get; set; }

    public CreateDataCommand(Data data)
    {
        Data = data;
    }
}
