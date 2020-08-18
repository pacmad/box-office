using AutoMapper;
using BoxOfficeTestTask.Models.Shows;
using BoxOfficeTestTask.ViewModels.Shows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoxOfficeTestTask.Automapper.Profiles
{
    public class SessionProfile : Profile
    {
        public SessionProfile()
        {
            CreateMap<Session, SessionViewModel>()
                .ForMember(mem => mem.Id, src => src.MapFrom(from => from.Id))
                .ForMember(mem => mem.ShowId, src => src.MapFrom(from => from.ShowId))
                .ForMember(mem => mem.MaxTickets, src => src.MapFrom(from => from.MaxTickets))
                .ForMember(mem => mem.StartTime, src => src.MapFrom(from => from.StartTime));
        }
    }
}
