using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client_Demo
{
    public partial class itemchat_Img_LEFT : UserControl
    {
        public itemchat_Img_LEFT()
        {
            InitializeComponent();
        }
        private Image icon;
        public Image Icon
        {
            get { return icon; }
            set { icon = value; guna2CirclePictureBox1.Image = value; }
        }
        private Image imgssen;
        public Image imgssend
        {
            get { return imgssen; }
            set { imgssen = value; guna2PictureBox1.Image = value; }
        }
    }
}
