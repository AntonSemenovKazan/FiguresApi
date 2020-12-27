using AutoMapper;
using FiguresApi.Db;

namespace FiguresApi.Converters
{
    public class FigureProfile : Profile
    {
        public FigureProfile()
        {
            CreateMap<Coordinates, Contracts.Coordinates>();
            CreateMap<Figure, Contracts.Figure>();

            CreateMap<Coordinates, Domain.Coordinates>();

            CreateMap<Contracts.Coordinates, Coordinates>()
                .ForMember(x => x.FigureId, opt => opt.Ignore())
                .ForMember(x => x.CoordinatesId, opt => opt.Ignore())
                .ForMember(x => x.Figure, opt => opt.Ignore());
            CreateMap<Contracts.Figure, Figure>()
                .ForMember(x => x.FigureId, opt => opt.Ignore());
        }
    }
}
