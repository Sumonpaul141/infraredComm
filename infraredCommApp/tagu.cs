using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace infraredCommApp
{
    [Serializable]
    public class tagu
    {
        public string tagId;
        public string tagname;
        public int pointx;
        public int pointy;
        public int tagtype;
        //コンテンツタグの時0、赤外線タグの時1
       // public UserControl2 UC2 = new UserControl2();

        public tagu()
        {
            tagId = "";
            tagname = "";
            pointx = 0;
            pointy = 0;
            tagtype = 0;
        }
    }
}
