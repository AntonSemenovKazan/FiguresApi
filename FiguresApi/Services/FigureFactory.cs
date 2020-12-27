using System;
using System.Linq;
using AutoMapper;
using FiguresApi.Db;

namespace FiguresApi.Services
{
    public class FigureFactory
    {
        private readonly IMapper mapper;

        public FigureFactory(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public IFigure CreateFrom(Figure figure)
        {
            switch (figure.Type)
            {
                case FigureType.Circle:
                    var coordinates = GetCoordinates(figure);
                    return new Circle(coordinates[0], coordinates[1].X);
                case FigureType.Triangle:
                    return new Triangle(GetCoordinates(figure));
                default:
                    throw new ArgumentOutOfRangeException($"Unknown figure type = {figure.Type}");
            }
        }

        private Coordinates[] GetCoordinates(Figure figure)
        {
            return figure.Coordinates.Select(c => mapper.Map<Coordinates>(c)).ToArray();
        }
    }
}