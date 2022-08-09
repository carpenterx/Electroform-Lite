using MediatR;
using ElectroformLite.Domain.Models;

namespace ElectroformLite.Application.DataGroupTemplates.Queries.GetDataGroupTemplates;

public class GetDataGroupTemplatesQuery : IRequest<List<DataGroupTemplate>>
{

}
