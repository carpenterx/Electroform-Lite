using AutoMapper;
using ElectroformLite.Application.Dto;
using ElectroformLite.Domain.Models;

namespace ElectroformLite.Application.Profiles;

public class ElectroformProfiles : Profile
{
    public ElectroformProfiles()
    {
        CreateMap<DataGroupTypeDto, DataGroupType>().ReverseMap();
        CreateMap<DataTypeDto, DataType>().ReverseMap();
        CreateMap<Data, DataGetPutDto>().ReverseMap();
        CreateMap<Data, DataGetDto>().ReverseMap();
        //CreateMap<DataPostDto, Data>();
        CreateMap<DataGroup, DataGroupGetPutDto>().ReverseMap();
        CreateMap<DataGroup, DataGroupGetDto>().ReverseMap();
        //CreateMap<DataGroupPostDto, DataGroup>();
        CreateMap<DataTemplate, DataTemplateGetPutDto>().ReverseMap();
        //CreateMap<DataTemplatePostDto, DataTemplate>();
        CreateMap<DataGroupTemplate, DataGroupTemplateGetDto>().ReverseMap();
        CreateMap<DataGroupTemplate, DataGroupTemplateDto>().ReverseMap();
        //CreateMap<DataGroupTemplatePostDto, DataGroupTemplate>();
        CreateMap<Template, TemplateGetPutDto>().ReverseMap();
        CreateMap<Template, TemplateGetDto>().ReverseMap();
        CreateMap<AliasTemplate, AliasTemplateDto>().ReverseMap();
        CreateMap<AliasTemplate, AliasTemplateGetDto>().ReverseMap();
        //CreateMap<TemplatePostDto, Template>();
        CreateMap<Document, DocumentGetDto>().ReverseMap();
        //CreateMap<DocumentPostDto, Document>();
    }
}
