using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infraredCommApp
{
    
    public class HeatMap
    {
        public string tagId;
        public string tagname;
        public int pointx;
        public int pointy;
        public int tagtype;
        public DateTime tagDate;


        public HeatMap()
        {
            tagId = "";
            tagname = "";
            pointx = 0;
            pointy = 0;
            tagtype = 0;
            tagDate =DateTime.Now;
        }
    }
   
    //コンテンツタグの時0、赤外線タグの時1
    // public UserControl2 UC2 = new UserControl2();

   
}
