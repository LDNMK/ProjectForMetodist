using AutoMapper;
using Fait.DAL.NotMapped;
using Fait.LogicObjects.DTO;
using WebAPI.Models;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Add as many of these lines as you need to map your objects
        CreateMap<StudentCardModel, StudentCardDTO>().ReverseMap();
        CreateMap<StudentNameWithIdDTO, StudentNameWithId>().ReverseMap();
        
    }
}
