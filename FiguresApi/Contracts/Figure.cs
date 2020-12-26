namespace FiguresApi.Contracts
{
    public class Figure
    {
        public string Type { get; set; }

        public Coordinates[] Coordinates { get; set; }
    }
}