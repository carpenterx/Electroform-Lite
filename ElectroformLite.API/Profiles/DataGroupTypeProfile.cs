using AutoMapper;
using ElectroformLite.API.Dto;
using ElectroformLite.Domain.Models;

namespace ElectroformLite.API.Profiles;

public class DataGroupTypeProfile : Profile
{
	public DataGroupTypeProfile()
	{
		CreateMap<DataGroupTypeDto, DataGroupType>().ReverseMap();
		CreateMap<DataTypeDto, DataType>().ReverseMap();
	}
}
