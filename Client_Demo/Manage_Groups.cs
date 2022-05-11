using ClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client_Demo
{
    public partial class Manage_Groups : Form
    {
        string maGroup;
        public Manage_Groups()
        {
            InitializeComponent();
        }
        private void Manage_Groups_Load(object sender, EventArgs e)
        {
            loadGRlisst();
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2GradientCircleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void loadmygr()
        {
            flowLayoutPanel1.Controls.Clear();

            Class1 dsa = new Class1();
            DataTable ds = dsa.getGRchat();

            if (ds != null)
            {
                if (ds.Rows.Count > 0)
                {
                    Item_userchat[] lisits = new Item_userchat[ds.Rows.Count];

                    for (int i = 0; i < 1; i++)
                    {
                        foreach (DataRow row in ds.Rows)
                        {

                            flowLayoutPanel1.Invoke((MethodInvoker)delegate {
                                lisits[i] = new Item_userchat();

                                lisits[i].namemy = row["name"].ToString();
                                lisits[i].magr = row["maGR"].ToString();

                                if (row["imga"] != System.DBNull.Value)
                                {
                                    MemoryStream ms = new MemoryStream((byte[])row["imga"]);
                                    lisits[i].Icon = new Bitmap(ms);
                                }
                                string mgr = row["maGR"].ToString();                              
                                string myanem = Home.myname;
                                Class1 dss = new Class1();
                                bool ka = dss.checkleader(mgr, myanem);
                                if (ka == true)
                                {
                                    flowLayoutPanel1.Controls.Add(lisits[i]);

                                }
                               // flowLayoutPanel1.Controls.Add(lisits[i]);

                                lisits[i].Click += new System.EventHandler(this.usercontrol_click2);
                            });

                        }
                    }

                }
            }

        }
        public void loadGRlisst()
        {
            flowLayoutPanel1.Controls.Clear();
            Class1 dsa = new Class1();
            DataTable ds = dsa.getGRchat();

            if (ds != null)
            {
                if (ds.Rows.Count > 0)
                {
                    Item_userchat[] lisits = new Item_userchat[ds.Rows.Count];

                    for (int i = 0; i < 1; i++)
                    {
                        foreach (DataRow row in ds.Rows)
                        {

                            flowLayoutPanel1.Invoke((MethodInvoker)delegate {
                                lisits[i] = new Item_userchat();

                                lisits[i].namemy = row["name"].ToString();
                                lisits[i].magr = row["maGR"].ToString();

                                if (row["imga"] != System.DBNull.Value)
                                {
                                    MemoryStream ms = new MemoryStream((byte[])row["imga"]);
                                    lisits[i].Icon = new Bitmap(ms);
                                }
                                string mgr = row["maGR"].ToString();
                                string myanem = Home.myname;
                                Class1 dss = new Class1();
                                bool ka = dss.CheckmemberGR(mgr, myanem);
                                if (ka == true)
                                {
                                    flowLayoutPanel1.Controls.Add(lisits[i]);

                                }

                                lisits[i].Click += new System.EventHandler(this.usercontrol_click2);
                            });

                        }
                    }

                }
            }

        }
        private void usercontrol_click2(object sender, EventArgs e)
        {
            guna2GradientButton1.Visible = true;

            Item_userchat obj = (Item_userchat)sender;
            maGroup = obj.magr;
            guna2CirclePictureBox1.Image = obj.Icon;
            label3.Text = obj.namemy;

            loadmember(maGroup);
        }
        public void loadmember(string maGroup)
        {
            flowLayoutPanel2.Controls.Clear();
            int id = Convert.ToInt32(Home.myid.ToString());
            Class1 aa = new Class1();
            DataTable ds = aa.GetUserChat(id);

            if (ds != null)
            {
                if (ds.Rows.Count > 0)
                {
                    Item_User_social[] lisits = new Item_User_social[ds.Rows.Count];
                    for (int i = 0; i < 1; i++)
                    {
                        foreach (DataRow row in ds.Rows)
                        {

                            flowLayoutPanel2.Invoke((MethodInvoker)delegate {
                                lisits[i] = new Item_User_social();

                                lisits[i].namemy = row["name"].ToString();
                               string namemb = row["name"].ToString();

                                if (row["Image"] != System.DBNull.Value)
                                {
                                    MemoryStream ms = new MemoryStream((byte[])row["Image"]);
                                    lisits[i].Icon = new Bitmap(ms);
                                }

                                Class1 dss = new Class1();
                                bool ka = dss.CheckMemberGR(maGroup, namemb);
                                if (ka == true)
                                {
                                    flowLayoutPanel2.Controls.Add(lisits[i]);

                                }
                         
                                lisits[i].DoubleClick += new System.EventHandler(this.usercontrol_click);
                            });

                        }
                    }

                }
            }
        }

        private void usercontrol_click(object sender, EventArgs e)
        {
            Item_User_social obj = (Item_User_social)sender;
            string namemb = Home.myname;
            string nmbb = obj.namemy;
            Class1 dss = new Class1();
            bool kajjj = dss.checkleader(maGroup, namemb);
            if (kajjj == true)
            {
                string texxt = "Bạn có chắc muốn xoá thành viên này ";
                string key = "del";
                Del_MemberGR kla = new Del_MemberGR(maGroup, nmbb, texxt, key);
                kla.Show();
               
            }
            else {
                MessageBox.Show("Bạn không có quyền xoá thành viên nhóm này");
            }
           
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
         
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            loadmember(maGroup);
        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            loadmygr();
         }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            loadGRlisst();
        }

        private void guna2GradientCircleButton2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2GradientButton1_Click_1(object sender, EventArgs e)
        {
            Intavition_member_groups dsd = new Intavition_member_groups(maGroup);
            dsd.Show();
        }
    }
}
