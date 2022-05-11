using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary;
using Command_Main;

namespace Client_Demo.UC_control
{

    public partial class ControlFriends : UserControl
    {
        public static string id, name, status;
        public static Image img;
       private  ClassLibrary.Class1 Object1;
        public SocketClient Client { get; set; }
        public ControlFriends()
        {
            InitializeComponent();
        }
        public void SetClient(SocketClient client)
        {
            this.Client = client;
            this.Client.OnDataReceived += Client_OnDataReceived;
            this.Client.OnDisconnected += Client_OnDisconnected;
        }
        void Client_OnDisconnected(object sender, EventArgs e)
        {
            MessageBox.Show("disconnected");
        }
        void Client_OnDataReceived(object sender, ReceivedDataEventArgs e)
        { }
        private void label1_Click(object sender, EventArgs e)
        {

        }



        private void usercontrol_click(object sender, EventArgs e)
        {
            Item_User_social obj = (Item_User_social)sender;
             name = obj.namemy;
             status = obj.statuss;
             id = obj.id;
             img = obj.Icon;

                Detail_User ds = new Detail_User(name, status, id, img);
                ds.Show();
                ds.SetClient(this.Client);

              



        }

        private void ControlFriends_Load(object sender, EventArgs e)
        {
            WellKnownClientTypeEntry entry = RemotingConfiguration.IsWellKnownClientType(typeof(ClassLibrary.Class1));
            if (entry == null)
            {
                // register
                RemotingConfiguration.RegisterWellKnownClientType(typeof(ClassLibrary.Class1), "http://127.0.0.1:9000/MyObj");
                Object1 = new ClassLibrary.Class1();
         
            }
            loaduser_social();

        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            loaduser_social();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            loaduser_Friends();
        }

        public void loaduser_social()
        {
            flowLayoutPanel1.Controls.Clear();
            Class1 aka = new Class1();
            DataTable ds = aka.GetUserSC();

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
                                lisits[i].statuss = row["love"].ToString();
                                lisits[i].id = row["id"].ToString();
                                if (row["img"] != System.DBNull.Value)
                                {
                                    MemoryStream ms = new MemoryStream((byte[])row["img"]);
                                    lisits[i].Icon = new Bitmap(ms);
                                }
                                int id = Convert.ToInt32(Home.myid);
                                string namela = row["name"].ToString();
                                Class1 dsaa = new Class1();
                                bool kaa = dsaa.CheckBTAddfiend(namela, id);
                                if (kaa == true)
                                {
                                    lisits[i].chek = "*";
                                }
                                string aa = Home.myname;
                                if (row["name"].ToString() != aa.ToString())
                                {
                                    flowLayoutPanel1.Controls.Add(lisits[i]);
                                }
                         
                              

                                lisits[i].Click += new System.EventHandler(this.usercontrol_click);
                            });

                        }
                    }

                }
            }
        }

        public void loaduser_Friends()
        {
            flowLayoutPanel1.Controls.Clear();
            Class1 aka = new Class1();
            int haha = Convert.ToInt32(Home.myid);
            DataTable ds = aka.GetUserChat(haha);

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


                                flowLayoutPanel1.Controls.Add(lisits[i]);

                               
                            });

                        }
                    }

                }
            }
        }

    }
}
