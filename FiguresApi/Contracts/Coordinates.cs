namespace FiguresApi.Contracts
{
    public class Coordinates
    {
        public Coordinates(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double X { get; set; }

        public double Y { get; set; }
    }
}