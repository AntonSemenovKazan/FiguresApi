using FiguresApi.Contracts;
using FiguresApi.Domain;

namespace FiguresApi.Validators
{
    public static class FigureValidator
    {
        public static bool IsValid(Figure figure)
        {
            switch (figure.Type)
            {
                case FigureType.Circle:
                    return IsValidCircle(figure);
                case FigureType.Triangle:
                    return IsValidTriangle(figure);
                default:
                    return false;
            }
        }

        private static bool IsValidCircle(Figure figure)
        {
            return figure.Coordinates.Length == 2;
        }
        private static bool IsValidTriangle(Figure figure)
        {
            return figure.Coordinates.Length == 3;
        }
    }
}
