using System;

namespace FiguresApi.Domain
{
    public static class FigureHelper
    {
        public static double GetDistance(Coordinates a, Coordinates b)
        {
            return Math.Sqrt(Math.Pow(b.X - a.X, 2) + Math.Pow(b.Y - a.Y, 2));
        }

    }
}