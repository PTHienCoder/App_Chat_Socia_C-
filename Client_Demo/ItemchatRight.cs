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
    public partial class ItemchatRight : UserControl
    {
     
        public ItemchatRight()
        {
            InitializeComponent();
        }



        private void ItemchatRight_Load(object sender, EventArgs e)
        {

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
    }
}
