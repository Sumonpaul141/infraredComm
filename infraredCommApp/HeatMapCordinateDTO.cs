using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace infraredCommApp
{
    public class HeatMapCordinateDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int CountOfClients { get; set; }
        public int PointX { get; set; }
        public int PointY { get; set; }
        public DateTime OccuredDate { get; set; }
    }

    public class HeatMapCordinateWithMapDTO
    {
        public Bitmap MapImage { get; set; }
        public int CummCountOfClient { get; set; }
        public HeatMapCordinateDTO HeatMapCordinate { get; set; }

    }
}
