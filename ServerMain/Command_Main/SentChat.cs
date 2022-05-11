using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command_Main
{
    [Serializable]
   public class SentChat
    {
        public string Myname { get; set; }
        public string Hisname { get; set; }
        public string Ndungchat { get; set; }
        public string Type { get; set; }
        public string Group { get; set; }
        public Image avatar { get; set; }
        public Image imgsend { get; set; }
        public SentChat(string myname, string hisname, string ndchat, string type, string group, Image avata, Image imgsend)
        {
            this.Myname = myname;
            this.Hisname = hisname;
            this.Ndungchat = ndchat;
            this.Type = type;
            this.Group = group;
            this.avatar = avata;
            this.imgsend = imgsend;
        }
    }
}
