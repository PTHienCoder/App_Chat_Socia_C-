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
    public partial class Item_POST : UserControl
    {
        public Item_POST()
        {
            InitializeComponent();
        }
        private string namp;
        public string Namep
        {
            get { return namp; }
            set { namp = value; label12.Text = value; }
        }
        private string tite;
        public string title
        {
            get { return tite; }
            set { tite = value; label2.Text = value; }
        }
        private string desc;
        public string Desc
        {
            get { return desc; }
            set { desc = value; label1.Text = value; }
        }

    
        private Image icon;
        public Image Icon
        {
            get { return icon; }
            set { icon = value; guna2CirclePictureBox1.Image = value; }
        }
        private Image image;
        public Image Imgagee
        {
            get { return image; }
            set { image = value; guna2PictureBox1.Image = value; }
        }

    }


}
