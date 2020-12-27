using System.Collections.Generic;

namespace FiguresApi.Db
{
    public class Figure
    {
        public int FigureId { get; set; }

        public string Type { get; set; }

        public List<Coordinates> Coordinates { get; } = new List<Coordinates>();

    }
}