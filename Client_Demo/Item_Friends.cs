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
    public partial class Item_Friends : UserControl
    {

        public Item_Friends()
        {
            InitializeComponent();
        }
        private string text;
        public string namemy
        {
            get { return text; }
            set { text = value; label3.Text = value; }
        }
        private string text1;
        public string statuss
        {
            get { return text1; }
            set { text1 = value; label2.Text = value; }
        }
        private Image icon;
        public Image Icon
        {
            get { return icon; }
            set { icon = value; guna2CirclePictureBox1.Image = value; }
        }

        private void Item_Friends_MouseHover(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(217, 229, 242);
        }

        private void Item_Friends_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(255, 255, 255);
        }
    }
}
