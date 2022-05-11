using ClassLibrary;
using Client_Demo.UC_control;
using Command_Main;
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
    public partial class Detail_User : Form
    {
        public string id, name, status;
        public Image img;
        string myid = Home.myid;
        public SocketClient Client { get; set; }
        public Detail_User(string name, string status, string id, Image img)
        {
            this.name = name;
            this.id = id;
            this.status = status;
            this.img = img;
            InitializeComponent();
        }
        public void SetClient(SocketClient client)
        {
            this.Client = client;
         
         
        }

        private void guna2GradientCircleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Detail_User_Load(object sender, EventArgs e)
        {
            guna2CirclePictureBox1.Image = img;
            label3.Text = name;
            label2.Text = status;
            checkbtn();


        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            Class1 ds = new Class1();
            bool aa = ds.LeaveFlower(name);
            if (aa == true)
            {
                MessageBox.Show("Bỏ fower thành công");
  
                checkbtn();
            }
            else
            {
                MessageBox.Show("Bỏ fower thất bại");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {

        }

        public void checkbtn()
        {
            int id = Convert.ToInt32(Home.myid);
            Class1 ds = new Class1();
            bool aa = ds.CheckBTAddfiend(name, id);
            if (aa == true)
            {
                guna2GradientButton2.Visible = true;
                guna2GradientButton1.Visible = false;
            }
            else
            {
                guna2GradientButton2.Visible = false;
                guna2GradientButton1.Visible = true;
            }
        }


        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {


            Class1 ds = new Class1();
            bool aa = ds.Flower(name, status, myid, img);
            if (aa == true)
            {
                MessageBox.Show("fower thành công");
            //    ControlFriends kaa = new ControlFriends();
             //   kaa.loaduser_social();
                checkbtn();
            }
            else
            {
                MessageBox.Show("fower thất bại");
            }


        }
    }
}
