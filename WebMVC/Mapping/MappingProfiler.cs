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
        CreateMap<YearPlanModel, YearPlanDTO>().ReverseMap();
        CreateMap<SubjectModel, SubjectDTO>().ReverseMap();

        CreateMap<GroupNameWithId, GroupNameWithIdDTO>().ReverseMap();

        CreateMap<YearPlan, YearPlanNameWithIdDTO>()
            .ForMember(dest => dest.PlanId, opt => opt.MapFrom(x=>x.Id))
            .ReverseMap();
    }
}
