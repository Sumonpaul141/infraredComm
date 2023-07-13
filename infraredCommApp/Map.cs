using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infraredCommApp
{
    [Serializable]
    public class Map
    {
        public  List<tagu> taglist = new List<tagu>();       

        private string _MapFileName;
        private string _MapName;

        public string MapFileName
        {
            get { return _MapFileName; }
            set { _MapFileName = value; }
        }
        public string MapName
        {
            get { return _MapName; }
            set { _MapName = value; }
        }

        public Map(string str, string num)
        {
            _MapFileName = str;
            _MapName = num;
        }
    }
}
