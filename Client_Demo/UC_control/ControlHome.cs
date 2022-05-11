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

namespace Client_Demo.UC_control
{
    public partial class ControlHome : UserControl
    {
        int idla;
        public ControlHome()
        {
            InitializeComponent();
        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            ADD_POSTs ds = new ADD_POSTs();

          
            ds.Show();
        }
        public void loadposst()
        {
            flowLayoutPanel1.Controls.Clear();
            Class1 aka = new Class1();
            DataTable ds = aka.GetPosst();

            if (ds != null)
            {
                if (ds.Rows.Count > 0)
                {
                    Item_POST[] lisits = new Item_POST[ds.Rows.Count];
                    for (int i = 0; i < 1; i++)
                    {
                        foreach (DataRow row in ds.Rows)
                        {

                            flowLayoutPanel1.Invoke((MethodInvoker)delegate {
                                lisits[i] = new Item_POST();

                                lisits[i].Namep = row["name_p"].ToString();
                                lisits[i].title = row["title"].ToString();
                                lisits[i].Desc = row["descc"].ToString();
                                if (row["img"] != System.DBNull.Value && row["avata"] != System.DBNull.Value)
                                {
                                    MemoryStream ms = new MemoryStream((byte[])row["avata"]);
                                    lisits[i].Icon = new Bitmap(ms);

                                    MemoryStream mss = new MemoryStream((byte[])row["img"]);
                                    lisits[i].Imgagee = new Bitmap(mss);
                                }
                                int id = Convert.ToInt32(Home.myid);
                                Class1 dsaa = new Class1();
                                bool kaa = dsaa.checkposstFriends(id);
                                if (kaa == true)
                                {
                                    
                                }
                                flowLayoutPanel1.Controls.Add(lisits[i]);


                            });

                        }
                    }

                }
            }
        }

        private void ControlHome_Load(object sender, EventArgs e)
        {
            loadposst();
            guna2CirclePictureBox2.Image = Home.avata;
            label2.Text = Home.myname;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            loadposst();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Class1 lao = new Class1();
            bool kal = lao.checkpostnew();
            if (kal == true)
            {
                loadnewPosst();
                Class1 kla = new Class1();
                kla.updatepostnew(idla);

            }
        }
        public void loadnewPosst()
        {
        
            Class1 aka = new Class1();
            DataTable ds = aka.getpostNew();

            if (ds != null)
            {
                if (ds.Rows.Count > 0)
                {
                    Item_POST[] lisits = new Item_POST[ds.Rows.Count];
                    for (int i = 0; i < 1; i++)
                    {
                        foreach (DataRow row in ds.Rows)
                        {

                            flowLayoutPanel1.Invoke((MethodInvoker)delegate {
                                lisits[i] = new Item_POST();

                                lisits[i].Namep = row["name_p"].ToString();
                                lisits[i].title = row["title"].ToString();
                                lisits[i].Desc = row["descc"].ToString();

                                idla = Convert.ToInt32(row["id"]);
                                if (row["img"] != System.DBNull.Value && row["avata"] != System.DBNull.Value)
                                {
                                    MemoryStream ms = new MemoryStream((byte[])row["avata"]);
                                    lisits[i].Icon = new Bitmap(ms);

                                    MemoryStream mss = new MemoryStream((byte[])row["img"]);
                                    lisits[i].Imgagee = new Bitmap(mss);
                                }
                                int id = Convert.ToInt32(Home.myid);
                                Class1 dsaa = new Class1();
                                bool kaa = dsaa.checkposstFriends(id);
                                if (kaa == true)
                                {

                                }
                                flowLayoutPanel1.Controls.Add(lisits[i]);


                            });

                        }
                    }

                }
            }
        }
    }
}
