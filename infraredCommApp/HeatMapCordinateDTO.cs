using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace infraredCommApp
{
    public class HeatMapCordinateDTO
    {
        public string Name { get; set; }
        public int CountOfClients { get; set; }
        public int PointX { get; set; }
        public int PointY { get; set; }
        public bool IsMatched { get; set; }
    }

}
