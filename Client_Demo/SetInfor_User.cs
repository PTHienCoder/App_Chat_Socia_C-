﻿using Command_Main;
using System;
using System.Drawing;
using System.Runtime.Remoting;
using System.Windows.Forms;

namespace Client_Demo
{
    public partial class SetInfor_User : Form
    {
        private string User;
        private string Pass;
        ClassLibrary.Class1 Object;


        public SetInfor_User(string user, string pass)
        {

            this.User = user;
            this.Pass = pass;
            InitializeComponent();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public SocketClient Client { get; set; }
        public void SetClient(SocketClient client)
        {
            this.Client = client;
            this.Client.OnDataReceived += Client_OnDataReceived;
            this.Client.OnDisconnected += Client_OnDisconnected;
        }
        void Client_OnDisconnected(object sender, EventArgs e)
        {

        }

        void Client_OnDataReceived(object sender, ReceivedDataEventArgs e)
        {

        }
        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {


            string love = Convert.ToString(guna2TextBox1.Text);
            string Adress = Convert.ToString(guna2TextBox2.Text);
            string Phone = Convert.ToString(guna2TextBox3.Text);
            string Email = Convert.ToString(guna2TextBox4.Text);
            string sex = Convert.ToString(guna2ComboBox1.Text);

            // ImageConverter _imageConverter = new ImageConverter();
             Image img = guna2CirclePictureBox1.Image;
            // byte[] xByte = new ImageConverter().ConvertTo(guna2CirclePictureBox1.Image, typeof(Byte[]));
            //   byteơ imgs = Convert.ToString(guna2CirclePictureBox1.Image);
            var abc = Object.checkusser(User);
            if (abc == true)
            {
                this.Close();
                MessageBox.Show("Username đã có người dung, vui lòng đặt lại");
            }
            else
            {
                var a = Object.dangkykhachhang(User, Pass, love, Adress, Phone, Email, sex, img);
                if (a == true)
                {

                    guna2TextBox1.Text = "";
                    guna2TextBox2.Text = "";
                    guna2TextBox3.Text = "";
                    guna2TextBox4.Text = "";

                    this.Close();
                    MessageBox.Show("Đăng ký thành công");

                }
                else

                    MessageBox.Show("Đăng ký thất bại");


                this.Close();
            }

           
        }


        private void SetInfor_User_Load(object sender, EventArgs e)
        {
            WellKnownClientTypeEntry entry = RemotingConfiguration.IsWellKnownClientType(typeof(ClassLibrary.Class1));
            if (entry == null)
            {
                // register
                RemotingConfiguration.RegisterWellKnownClientType(typeof(ClassLibrary.Class1), "http://127.0.0.1:9000/MyObj");
                Object = new ClassLibrary.Class1();
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
