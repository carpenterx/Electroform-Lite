﻿using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.UserData.Commands.EditData;

public class EditDataCommand : IRequest
{
    public Data Data { get; set; }

    public EditDataCommand(Data data)
    {
        Data = data;
    }
}
