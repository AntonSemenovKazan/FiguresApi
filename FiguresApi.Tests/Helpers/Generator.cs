using System;
using System.Linq;
using FiguresApi.Contracts;
using FiguresApi.Domain;

namespace FiguresApi.Tests.Helpers
{
    public static class Generator
    {
        private static readonly Random Rnd = new Random();

        public static int GenerateNumber() => Rnd.Next();

        public static Contracts.Coordinates GenerateCoordinate()
        {
            var x = GenerateNumber();
            var y = GenerateNumber();

            return new Contracts.Coordinates(x, y);
        }

        public static Contracts.Coordinates[] GenerateCoordinates(int number)
        {
            if (number == 0)
                return new Contracts.Coordinates[0];

            return Enumerable.Range(1, number).Select(n => GenerateCoordinate()).ToArray();
        }

        public static Figure GenerateFigure(string figureType)
        {
            switch (figureType)
            {
                case FigureType.Circle:
                    return new Figure()
                    {
                        Type = FigureType.Circle,
                        Coordinates = Generator.GenerateCoordinates(2)
                    };
                case FigureType.Triangle:
                    return new Figure()
                    {
                        Type = FigureType.Triangle,
                        Coordinates = Generator.GenerateCoordinates(3)
                    };
                default:
                    throw new ArgumentOutOfRangeException(figureType);
            }
        }

        public static FigureFactory GenerateFigureFactory()
        {
            var mapper = AutoMapperHelper.GetMapper();
            return new FigureFactory(mapper);
        }
    }
}