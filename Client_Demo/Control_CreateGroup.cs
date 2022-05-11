using ClassLibrary;
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
    public partial class Control_CreateGroup : UserControl
    {
        public Control_CreateGroup()
        {
            InitializeComponent();
        }

        private void guna2GradientCircleButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            string name = Search.Text;
            Image img = guna2CirclePictureBox1.Image;
            Random random = new Random();
            int maDatCho = random.Next(1000, 2000);
            string magr = maDatCho.ToString();
            string myname = Home.myname;
            Class1 ds = new Class1();
            bool aa = ds.CeateGroup(magr, name, img, myname);
            if (aa == true)
            {
                MessageBox.Show("Tạo thành công");
                Intavition_member_groups sd = new Intavition_member_groups(magr);
                Search.Text = "";
                sd.Show();
                this.Hide();
        
            }
            else
            {
                MessageBox.Show("Tạo thất bại");
            }
        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "jpeg|*.jpg|bmp|*.png|bmp|*.bmp|all files|*.*";
            DialogResult res = openFileDialog1.ShowDialog();
            if (res == DialogResult.OK)
            {
                guna2CirclePictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }
    }
}
