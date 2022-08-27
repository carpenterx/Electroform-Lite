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
		CreateMap<Data, DataGetPutDto>().ReverseMap();
		CreateMap<DataPostDto, Data>();
        CreateMap<DataGroup, DataGroupGetPutDto>().ReverseMap();
        CreateMap<DataGroupPostDto, DataGroup>();
        CreateMap<DataTemplate, DataTemplateGetPutDto>().ReverseMap();
        CreateMap<DataTemplatePostDto, DataTemplate>();
        CreateMap<DataGroupTemplate, DataGroupTemplateGetPutDto>().ReverseMap();
        CreateMap<DataGroupTemplatePostDto, DataGroupTemplate>();
    }
}
