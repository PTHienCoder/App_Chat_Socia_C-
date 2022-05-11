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
    public partial class ItemchatLeft : UserControl
    {
        public ItemchatLeft()
        {
            InitializeComponent();
        }
        private string text;
        public string namemy
        {
            get { return text; }
            set { text = value; label3.Text = value; }
        }
        private Image icon;
        public Image Icon
        {
            get { return icon; }
            set { icon = value; guna2CirclePictureBox1.Image = value; }
        }
        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
