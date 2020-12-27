using AutoMapper;
using FiguresApi.Converters;

namespace FiguresApi.Tests.Helpers
{
    public static class AutoMapperHelper
    {
        public static MapperConfiguration GetConfig() => new MapperConfiguration(cfg => { cfg.AddProfile<FigureProfile>(); });

        public static IMapper GetMapper() => GetConfig().CreateMapper();
    }
}