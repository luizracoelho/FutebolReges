using AutoMapper;
using Futebol.UI.Models;

namespace Futebol.UI.Mappings.Profiles
{
    public class JogadorProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Jogador, JogadorVM>();
            CreateMap<JogadorVM, Jogador>();
        }
    }
}