using System;

namespace FiguresApi.Services
{
    public class Triangle : IFigure
    {
        private readonly Coordinates[] coordinates;

        public Triangle(Coordinates[] coordinates)
        {
            this.coordinates = coordinates;
        }

        public double GetSquare()
        {
            var a = FigureHelper.GetDistance(coordinates[0], coordinates[1]);
            var b = FigureHelper.GetDistance(coordinates[1], coordinates[2]);
            var c = FigureHelper.GetDistance(coordinates[0], coordinates[1]);
            var p = (a + b + c) / 2;

            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }
    }
}