using System;

namespace FiguresApi.Services
{
    public class Circle : IFigure
    {
        private readonly Coordinates center;
        private readonly double radius;

        public Circle(Coordinates center, double radius)
        {
            this.center = center;
            this.radius = radius;
        }

        public double GetSquare()
        {
            return Math.PI * Math.Pow(radius, 2) / 2;
        }
    }
}
