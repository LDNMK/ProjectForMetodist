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
        CreateMap<YearPlanModel, YearPlanDTO>()
            .ForMember(dest => dest.GroupIds, opt => opt.MapFrom(x => x.GroupIds))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(x => x.Name))
            .ForMember(dest => dest.SubjectInfo, opt => opt.MapFrom(x => x.SubjectInfo))
            .ForMember(dest => dest.Year, opt => opt.MapFrom(x => x.Year))
            .ReverseMap();

        CreateMap<YearPlan, YearPlanNameWithIdDTO>()
            .ForMember(dest => dest.PlanId, opt => opt.MapFrom(x => x.Id))
            .ForMember(dest => dest.PlanName, opt => opt.MapFrom(x => x.Name))
            .ReverseMap();

        // Subject mapping
        CreateMap<SubjectModel, SubjectDTO>()
            .ForMember(dest => dest.Hours, opt => opt.MapFrom(x => x.Hours))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(x => x.Name))
            .ForMember(dest => dest.IsIndividualTaskExistFall, opt => opt.MapFrom(x => x.IsIndividualTaskExistFall))
            .ForMember(dest => dest.IsIndividualTaskExistSpring, opt => opt.MapFrom(x => x.IsIndividualTaskExistSpring))
            .ForMember(dest => dest.Ects, opt => opt.MapFrom(x => x.Ects))
            .ForMember(dest => dest.Department, opt => opt.MapFrom(x => x.Department))
            .ForMember(dest => dest.ControlTypeSpring, opt => opt.MapFrom(x => x.ControlTypeSpring))
            .ForMember(dest => dest.ControlTypeFall, opt => opt.MapFrom(x => x.ControlTypeFall))
            .ReverseMap();

        CreateMap<SubjectDTO, Subject>()
            .ForMember(dest => dest.Hours, opt => opt.MapFrom(x => x.Hours))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(x => x.Name))
            .ForMember(dest => dest.Ects, opt => opt.MapFrom(x => x.Ects))
            .ForMember(dest => dest.Department, opt => opt.MapFrom(x => x.Department))
            .ReverseMap();

        // Group mapping
        CreateMap<GroupNameWithId, GroupNameWithIdDTO>().ReverseMap();

    }
}
