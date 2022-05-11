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

namespace Client_Demo.UC_control
{
    public partial class Control_Profile : UserControl
    {
        public Control_Profile()
        {
            InitializeComponent();
        }

        private void Control_Profile_Load(object sender, EventArgs e)
        {
            label11.Text = Home.love;
            label10.Text = Home.sex;
            label9.Text = Home.adress;
            label8.Text = Home.email;
            label7.Text = Home.phone;
   
            label12.Text = Home.myname;

            guna2CirclePictureBox1.Image = Home.avata;
            control_CreateGroup1.Visible = false;
            loaduser_Friends();
        }

          private void guna2GradientCircleButton1_Click(object sender, EventArgs e)
        {
     
        }

        public void loaduser_Friends()
        {
            Class1 aka = new Class1();
            int haha = Convert.ToInt32(Home.myid);
            DataTable ds = aka.GetUserChat(haha);
            int count = 0;
            if (ds != null)
            {
                if (ds.Rows.Count > 0)
                {
                    Item_User_social[] lisits = new Item_User_social[ds.Rows.Count];
                    for (int i = 0; i < 1; i++)
                    {
                        foreach (DataRow row in ds.Rows)
                        {
                            count++;
                        }
                    }
                    guna2GradientButton1.Text = count + " Friends";
                }
            }
        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            control_CreateGroup1.Visible = true;
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            Manage_Groups ds = new Manage_Groups();
            ds.Show();
        }
    }
}
