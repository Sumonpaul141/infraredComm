using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infraredCommApp
{
    public class ContentPlayResultModel
    {
        public int UserSN { get; set; }
        public int ContentID { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public int PlayTime { get; set; }
        public int EndMode { get; set; }
        public bool IsQuiz { get; set; }
        public bool IsCorrectAns { get; set; }
        public int InputedAns { get; set; }
    }
}
