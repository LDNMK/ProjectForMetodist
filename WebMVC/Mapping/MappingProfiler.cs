using AutoMapper;
using Fait.DAL;
using Fait.DAL.NotMapped;
using FaitLogic.DTO;
using WebAPI.Models;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Add as many of these lines as you need to map your objects
        CreateMap<StudentCardModel, StudentCardDTO>().ReverseMap();
        CreateMap<StudentCardDTO, StudentsInfo>().ReverseMap();
        CreateMap<StudentCardDTO, Student>().ReverseMap();

        CreateMap<StudentNameWithIdDTO, StudentNameWithId>().ReverseMap();
        CreateMap<CurriculumModel, CurriculumDTO>().ReverseMap();
    }
}
