﻿using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.DataGroupTemplates.Commands.EditDataGroupTemplate;

public class EditDataGroupTemplateCommand : IRequest<DataGroupTemplate?>
{
    public DataGroupTemplate DataGroupTemplate { get; set; }

    public EditDataGroupTemplateCommand(DataGroupTemplate dataGroupTemplate)
    {
        DataGroupTemplate = dataGroupTemplate;
    }
}
