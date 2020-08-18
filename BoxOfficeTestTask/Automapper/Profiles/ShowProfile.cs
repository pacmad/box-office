using AutoMapper;
using BoxOfficeTestTask.Models.Shows;
using BoxOfficeTestTask.ViewModels.Shows;

namespace BoxOfficeTestTask.Automapper.Profiles
{
    public class ShowProfile : Profile
    {
        public ShowProfile()
        {
            CreateMap<Show, ShowViewModel>()
                .ForMember(mem => mem.Id, src => src.MapFrom(from => from.Id))
                .ForMember(mem => mem.Name, src => src.MapFrom(from => from.Name))
                .ForMember(mem => mem.Description, src => src.MapFrom(from => from.Description))
                .ForMember(mem => mem.Sessions, src => src.MapFrom(from => from.Sessions))
                .ForMember(mem => mem.MinAge, src => src.MapFrom(from => from.MinAge));
        }
    }
}
