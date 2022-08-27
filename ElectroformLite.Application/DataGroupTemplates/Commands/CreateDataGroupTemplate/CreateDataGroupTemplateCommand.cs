using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.DataGroupTemplates.Commands.CreateDataGroupTemplate;

public class CreateDataGroupTemplateCommand : IRequest<DataGroupTemplate>
{
    public DataGroupTemplate DataGroupTemplate { get; set; }

    public CreateDataGroupTemplateCommand(DataGroupTemplate dataGroupTemplate)
    {
        DataGroupTemplate = dataGroupTemplate;
    }
}
