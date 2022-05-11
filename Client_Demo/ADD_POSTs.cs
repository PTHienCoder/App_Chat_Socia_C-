using ClassLibrary;
using Client_Demo.UC_control;
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
    public partial class ADD_POSTs : Form
    {
        public ADD_POSTs()
        {
            InitializeComponent();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            string title = Convert.ToString(Search.Text);
            string desc = Convert.ToString(guna2TextBox1.Text);
   

            // ImageConverter _imageConverter = new ImageConverter();
            Image img = guna2PictureBox1.Image;
            Image avata = Home.avata;
            // byte[] xByte = new ImageConverter().ConvertTo(guna2CirclePictureBox1.Image, typeof(Byte[]));
            //   byteơ imgs = Convert.ToString(guna2CirclePictureBox1.Image);
            string namep = Home.myname;
            Class1 dss = new Class1();
            var a = dss.ADD_Post(title, desc, img, namep, avata);
            if (a == true)
            {

                guna2TextBox1.Text = "";
                Search.Text = "";

                this.Close();
                MessageBox.Show("Đăng bài thành công");
          
            }
            else
            {

                MessageBox.Show("Đăng bài thất bại");
                this.Close();
            }
           
        }

        private void guna2GradientCircleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "jpeg|*.jpg|bmp|*.png|bmp|*.bmp|all files|*.*";
            DialogResult res = openFileDialog1.ShowDialog();
            if (res == DialogResult.OK)
            {
                guna2PictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }
    }
}
