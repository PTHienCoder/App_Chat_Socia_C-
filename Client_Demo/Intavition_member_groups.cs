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
    public partial class Intavition_member_groups : Form
    {
        string Magr;
        public Intavition_member_groups(string magr)
        {
            this.Magr = magr;
            InitializeComponent();
        }

        private void guna2GradientCircleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
       
        }

        private void Intavition_member_groups_Load(object sender, EventArgs e)
        {
            loadfriends();
        }
        public void loadfriends()
        {

            flowLayoutPanel1.Controls.Clear();
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

                            flowLayoutPanel1.Invoke((MethodInvoker)delegate {
                                lisits[i] = new Item_User_social();

                                lisits[i].namemy = row["name"].ToString();

                                if (row["Image"] != System.DBNull.Value)
                                {
                                    MemoryStream ms = new MemoryStream((byte[])row["Image"]);
                                    lisits[i].Icon = new Bitmap(ms);
                                }                       
                                string namemb = row["name"].ToString();
                                Class1 dss = new Class1();
                                bool ka = dss.CheckMemberGR(Magr, namemb);
                                if (ka == true)
                                {
                                    lisits[i].statuss = "Thành viên";

                                }


                                flowLayoutPanel1.Controls.Add(lisits[i]);

                                lisits[i].Click += new System.EventHandler(this.usercontrol_click);
                            });

                        }
                    }

                }
            }
        }

        private void usercontrol_click(object sender, EventArgs e)
        {
            Item_User_social obj = (Item_User_social)sender;
            string hisname = obj.namemy;
            obj.statuss = "Đã mời";
            string myname = Home.myname;
            Class1 aab = new Class1();
            bool aa = aab.Addmember(Magr, myname, hisname);
            if (aa == true)
            {
                MessageBox.Show("mời thành công");
            

            }
            else
            {
                MessageBox.Show("mời thất bại");
            }

        }
    }
}
