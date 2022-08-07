using MediatR;
using ElectroformLite.Domain.Models;

namespace ElectroformLite.Application.UserData.Queries.GetDataList;

public class GetDataListQuery : IRequest<List<Data>>
{

}
