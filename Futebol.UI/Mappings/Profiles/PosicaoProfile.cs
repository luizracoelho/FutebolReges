using AutoMapper;
using Futebol.UI.Models;

namespace Futebol.UI.Mappings.Profiles
{
    public class PosicaoProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Posicao, PosicaoVM>();
            CreateMap<PosicaoVM, Posicao>();
        }
    }
}