using System;

namespace FiguresApi.Services
{
    public static class FigureType
    {
        public const string Circle = "circle";

        public const string Triangle = "triangle";
    }

    public static class FigureHelper
    {
        public static double GetDistance(Coordinates a, Coordinates b)
        {
            return Math.Sqrt(Math.Pow(b.X - a.X, 2) + Math.Pow(b.Y - a.Y, 2));
        }

    }
}