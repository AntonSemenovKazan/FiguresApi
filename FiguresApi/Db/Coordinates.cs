namespace FiguresApi.Db
{
    public class Coordinates
    {
        public int CoordinatesId { get; set; }

        public double X { get; set; }

        public double Y { get; set; }

        public int FigureId { get; set; }
        public Figure Figure { get; set; }
    }
}