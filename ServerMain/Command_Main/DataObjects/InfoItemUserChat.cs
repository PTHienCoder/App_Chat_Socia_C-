using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command_Main.DataObjects
{
    [Serializable]
    public class InfoItemUserChat
    {
        public string Name { get; set; }
        public byte[] Img { get; set; }
        public int Id;


        public InfoItemUserChat(int id, string name, byte[] img)
        {
            this.Name = name;
            this.Img = img;
            this.Id = id;
        }
    }
}
