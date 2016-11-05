using AutoMapper;
using Futebol.UI.Mappings.Profiles;

namespace Futebol.UI.Mappings
{
    public class MapConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<TimeProfile>();
                cfg.AddProfile<PosicaoProfile>();
                cfg.AddProfile<JogadorProfile>();
            });
        }
    }
}