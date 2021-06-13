using AutoMapper;
using Fait.DAL;
using Fait.DAL.NotMapped;
using FaitLogic.DTO;
using WebAPI.Models;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Student mapping
        CreateMap<StudentCardModel, StudentCardDTO>().ReverseMap();
        CreateMap<StudentCardDTO, StudentsInfo>().ReverseMap();
        CreateMap<StudentCardDTO, Student>().ReverseMap();
        CreateMap<StudentNameWithIdDTO, StudentNameWithId>().ReverseMap();

        // Year plan mapping
        CreateMap<YearPlanModel, YearPlanDTO>().ReverseMap();

        // Subject mapping
        CreateMap<SubjectModel, SubjectDTO>().ReverseMap();
        CreateMap<YearPlan, YearPlanNameWithIdDTO>()
            .ForMember(dest => dest.PlanId, opt => opt.MapFrom(x => x.Id))
            .ReverseMap();

        // Group mapping
        CreateMap<GroupNameWithId, GroupNameWithIdDTO>().ReverseMap();

    }
}
