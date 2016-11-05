using AutoMapper;
using Futebol.UI.Models;

namespace Futebol.UI.Mappings.Profiles
{
    public class TimeProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Time, TimeVM>();
            CreateMap<TimeVM, Time>();
        }
    }
}