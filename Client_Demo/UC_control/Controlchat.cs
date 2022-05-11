using ClassLibrary;
using Command_Main;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client_Demo.UC_control
{
    public partial class Controlchat : UserControl
    {
        byte[] photo_aray;
        private int idla = 0;
        private int idlal = 0;
        public SocketClient Client { get; set; }
        private ClassLibrary.Class1 Object;
        string myname;
        private string maGroup = "null";
        string hisname= "null";


        public Controlchat()
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
        {
  
        }



        private void Controlchat_Load(object sender, EventArgs e)
        {
            WellKnownClientTypeEntry entry = RemotingConfiguration.IsWellKnownClientType(typeof(ClassLibrary.Class1));
            if (entry == null)
            {
                // register
                RemotingConfiguration.RegisterWellKnownClientType(typeof(ClassLibrary.Class1), "http://127.0.0.1:9000/MyObj");
                Object = new ClassLibrary.Class1();
            }
            // flowLayoutPanel1.HorizontalScroll.Visible = false;
            // flowLayoutPanel2.HorizontalScroll.Visible = false;
            // flowLayoutPanel3.HorizontalScroll.Visible = false;
            //loaduserchat();
        
            addemoji();
            loadgroupschat();
        }
        public void loadchat()
        {
            flowLayoutPanel2.AutoScroll = true;
             flowLayoutPanel2.HorizontalScroll.Visible = false;
            flowLayoutPanel2.Controls.Clear();
            DataTable ds = Object.getchats();
          
            if (ds != null)
            {
                if (ds.Rows.Count > 0)
                {

                 
                    ItemchatLeft[] lisits = new ItemchatLeft[ds.Rows.Count];
                    ItemchatRight[] lisits2 = new ItemchatRight[ds.Rows.Count];
                    itemchat_Img_LEFT[] lisits3 = new itemchat_Img_LEFT[ds.Rows.Count];
                    itemChat_img_RIGHT[] lisits4 = new itemChat_img_RIGHT[ds.Rows.Count];
                    item_IconLeft[] lisits5 = new item_IconLeft[ds.Rows.Count];
                    Item_IconRight[] lisits6 = new Item_IconRight[ds.Rows.Count];
                    for (int i = 0; i < 1; i++)
                    {
                        foreach (DataRow row in ds.Rows)
                        {

                            flowLayoutPanel2.Invoke((MethodInvoker)delegate {
                                lisits[i] = new ItemchatLeft();
                                lisits2[i] = new ItemchatRight();
                                lisits3[i] = new itemchat_Img_LEFT();
                                lisits4[i] = new itemChat_img_RIGHT();
                                lisits5[i] = new item_IconLeft();
                                lisits6[i] = new Item_IconRight();

                                string stype = row["type"].ToString();

                                if (stype.Equals("text") || stype.Equals("File"))
                                {
                                    lisits[i].namemy = row["content"].ToString();
                                    lisits2[i].namemy = row["content"].ToString();
                                    if (row["avatar"] != System.DBNull.Value)
                                    {
                                        MemoryStream ms = new MemoryStream((byte[])row["avatar"]);
                                        lisits[i].Icon = new Bitmap(ms);
                                        lisits2[i].Icon = new Bitmap(ms);
                                    }
                                    string myname = Home.myname;
                                    if (row["myname"].ToString() == myname && row["hisname"].ToString() == hisname)
                                    {
                                        flowLayoutPanel2.Controls.Add(lisits2[i]);
                           
                                    }
                                    else if (row["hisname"].ToString() == myname && row["myname"].ToString() == hisname)
                                    {
                                        flowLayoutPanel2.Controls.Add(lisits[i]);
                             
                                       
                                    }
                                }
                                else if (stype.Equals("Image"))
                                {
                                    if (row["imgSend"] != System.DBNull.Value)
                                    {
                                        MemoryStream ms = new MemoryStream((byte[])row["imgSend"]);
                                        lisits4[i].imgssend = new Bitmap(ms);
                                        lisits3[i].imgssend = new Bitmap(ms);
                                    }

                                    if (row["avatar"] != System.DBNull.Value)
                                    {
                                        MemoryStream ms = new MemoryStream((byte[])row["avatar"]);
                                        lisits4[i].Icon = new Bitmap(ms);
                                        lisits3[i].Icon = new Bitmap(ms);
                                    }
                                    string myname = Home.myname;
                                    if (row["myname"].ToString() == myname && row["hisname"].ToString() == hisname)
                                    {
                                        flowLayoutPanel2.Controls.Add(lisits3[i]);
                          
                                    }
                                    else if (row["hisname"].ToString() == myname && row["myname"].ToString() == hisname)
                                    {
                                        flowLayoutPanel2.Controls.Add(lisits4[i]);
                            
                                    }
                                }
                                else if (stype.Equals("Icon"))
                                {
                                    if (row["imgSend"] != System.DBNull.Value)
                                    {
                                        MemoryStream ms = new MemoryStream((byte[])row["imgSend"]);
                                        lisits5[i].imgssend = new Bitmap(ms);
                                        lisits6[i].imgssend = new Bitmap(ms);
                                    }

                                    if (row["avatar"] != System.DBNull.Value)
                                    {
                                        MemoryStream ms = new MemoryStream((byte[])row["avatar"]);
                                        lisits5[i].Icon = new Bitmap(ms);
                                        lisits6[i].Icon = new Bitmap(ms);
                                    }
                                    string myname = Home.myname;
                                    if (row["myname"].ToString() == myname && row["hisname"].ToString() == hisname)
                                    {
                                        flowLayoutPanel2.Controls.Add(lisits6[i]);

                                    }
                                    else if (row["hisname"].ToString() == myname && row["myname"].ToString() == hisname)
                                    {
                                        flowLayoutPanel2.Controls.Add(lisits5[i]);

                                    }
                                }


                            });

                        }
                    }

                }
            }

             flowLayoutPanel2.AutoScrollPosition = new Point(0, int.MaxValue);
    
        }
        private void usercontrol_click(object sender, EventArgs e)
        {
            panel4.Visible = true;
            panel6.Visible = false;
            Item_userchat obj = (Item_userchat)sender;
            hisname = obj.namemy;
            label2.Text = hisname;
            maGroup = "null";
            DataTable ds = Object.getPro(hisname);
            if (ds != null)
            {
                if (ds.Rows.Count > 0)
                {

                    foreach (DataRow row in ds.Rows)
                    {

                        if (row["img"] != System.DBNull.Value)
                        {
                            photo_aray = (byte[])row["img"];
                            MemoryStream ms = new MemoryStream(photo_aray);
                            guna2CirclePictureBox1.Image = Image.FromStream(ms);
                        }
                    }

                }
            }

            loadchat();

        }
        public void loaduserchat()
        {
            flowLayoutPanel1.Controls.Clear();
            int id = Convert.ToInt32(Home.myid.ToString());
            DataTable ds = Object.GetUserChat(id);

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
                                
                                if (row["Image"] != System.DBNull.Value)
                                {
                                    MemoryStream ms = new MemoryStream((byte[])row["Image"]);
                                    lisits[i].Icon = new Bitmap(ms);
                                }


                                flowLayoutPanel1.Controls.Add(lisits[i]);

                              lisits[i].Click += new System.EventHandler(this.usercontrol_click);
                           
                            });

                        }
                    }

                }
            }
            
 
        }


        public void loadchatgr(string maGroup)
        {
            flowLayoutPanel2.Controls.Clear();
            DataTable ds = Object.getchatGR(maGroup);

            if (ds != null)
            {
                if (ds.Rows.Count > 0)
                {
                    ItemchatLeft[] lisits = new ItemchatLeft[ds.Rows.Count];
                    ItemchatRight[] lisits2 = new ItemchatRight[ds.Rows.Count];
                    itemchat_Img_LEFT[] lisits3 = new itemchat_Img_LEFT[ds.Rows.Count];
                    itemChat_img_RIGHT[] lisits4 = new itemChat_img_RIGHT[ds.Rows.Count];
                    item_IconLeft[] lisits5 = new item_IconLeft[ds.Rows.Count];
                    Item_IconRight[] lisits6 = new Item_IconRight[ds.Rows.Count];
                    for (int i = 0; i < 1; i++)
                    {
                        foreach (DataRow row in ds.Rows)
                        {

                            flowLayoutPanel2.Invoke((MethodInvoker)delegate {
                                lisits[i] = new ItemchatLeft();
                                lisits2[i] = new ItemchatRight();
                                lisits3[i] = new itemchat_Img_LEFT();
                                lisits4[i] = new itemChat_img_RIGHT();
                                lisits5[i] = new item_IconLeft();
                                lisits6[i] = new Item_IconRight();
                                string stype = row["type"].ToString();

                                if (stype.Equals("text") || stype.Equals("File"))
                                {
                                    lisits[i].namemy = row["content"].ToString();
                                    lisits2[i].namemy = row["content"].ToString();
                                    if (row["avatar"] != System.DBNull.Value)
                                    {
                                        MemoryStream ms = new MemoryStream((byte[])row["avatar"]);
                                        lisits[i].Icon = new Bitmap(ms);
                                        lisits2[i].Icon = new Bitmap(ms);
                                    }
                                    string myname = Home.myname;
                                    if (row["myname"].ToString() == myname && row["hisname"].ToString() == hisname)
                                    {
                                        flowLayoutPanel2.Controls.Add(lisits2[i]);
                                    }
                                    else if (row["hisname"].ToString() == hisname)
                                    {
                                        flowLayoutPanel2.Controls.Add(lisits[i]);
                                    }
                                }
                                else if (stype.Equals("Image"))
                                {
                                    if (row["imgSend"] != System.DBNull.Value)
                                    {
                                        MemoryStream ms = new MemoryStream((byte[])row["imgSend"]);
                                        lisits4[i].imgssend = new Bitmap(ms);
                                        lisits3[i].imgssend = new Bitmap(ms);
                                    }

                                    if (row["avatar"] != System.DBNull.Value)
                                    {
                                        MemoryStream ms = new MemoryStream((byte[])row["avatar"]);
                                        lisits4[i].Icon = new Bitmap(ms);
                                        lisits3[i].Icon = new Bitmap(ms);
                                    }
                                    string myname = Home.myname;
                                    if (row["myname"].ToString() == myname && row["hisname"].ToString() == hisname)
                                    {
                                        flowLayoutPanel2.Controls.Add(lisits3[i]);
                                    }
                                    else if (row["hisname"].ToString() == hisname)
                                    {
                                        flowLayoutPanel2.Controls.Add(lisits4[i]);
                                    }
                                }
                                else if (stype.Equals("Icon"))
                                {
                                    if (row["imgSend"] != System.DBNull.Value)
                                    {
                                        MemoryStream ms = new MemoryStream((byte[])row["imgSend"]);
                                        lisits5[i].imgssend = new Bitmap(ms);
                                        lisits6[i].imgssend = new Bitmap(ms);
                                    }

                                    if (row["avatar"] != System.DBNull.Value)
                                    {
                                        MemoryStream ms = new MemoryStream((byte[])row["avatar"]);
                                        lisits5[i].Icon = new Bitmap(ms);
                                        lisits6[i].Icon = new Bitmap(ms);
                                    }
                                    string myname = Home.myname;
                                    if (row["myname"].ToString() == myname && row["hisname"].ToString() == hisname)
                                    {
                                        flowLayoutPanel2.Controls.Add(lisits6[i]);

                                    }
                                    else if (row["hisname"].ToString() == hisname)
                                    {
                                        flowLayoutPanel2.Controls.Add(lisits5[i]);

                                    }
                                }


                            });

                        }
                    }

                }
            }
            // int chane = flowLayoutPanel2.VerticalScroll.Value + flowLayoutPanel2.VerticalScroll.Maximum;

            flowLayoutPanel2.AutoScrollPosition = new Point(0, int.MaxValue);
            // flowLayoutPanel2.Controls.
            // flowLayoutPanel1.FlowDirection = FlowDirection.BottomUp;
        }
        public void loadgroupschat()
        {
            flowLayoutPanel3.Controls.Clear();
    
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

                            flowLayoutPanel3.Invoke((MethodInvoker)delegate {
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
                                if(ka == true)
                                {
                                    flowLayoutPanel3.Controls.Add(lisits[i]);

                                }
                              // lisits[i].Click += new System.EventHandler(this.usercontrol_click2);
                                 lisits[i].MouseUp += Button1_MouseUp;
                            });

                        }
                    }

                }
            }

        }
        private void Button1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

                Class1 dss = new Class1();
                string myname = Home.myname;
                bool kajjj = dss.checkleader(maGroup, myname);
                if (kajjj == true)
                {
                    MessageBox.Show("Bạn không thế rời nhóm vì bạn là Leader");         
                }
                else
                {
                    Item_userchat obj = (Item_userchat)sender;
                    string namemb = Home.myname;
                    string texxt = "Bạn có chắc là muốn";
                    string key = "out";
                    Del_MemberGR kla = new Del_MemberGR(maGroup, namemb, texxt, key);
                    kla.Show();
                }

              
            }
            else if (e.Button == MouseButtons.Left)
            {
                panel4.Visible = true;
                panel6.Visible = false;
                Item_userchat obj = (Item_userchat)sender;
                hisname = obj.namemy;
                maGroup = obj.magr;
                guna2CirclePictureBox1.Image = obj.Icon;
                label2.Text = hisname;

                loadchatgr(maGroup);
            }
        }

        private void usercontrol_clickGROP(object sender, MouseEventArgs e)
        {



        }

        private void usercontrol_click2(object sender, EventArgs e)
        {

        }
        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            string contentss = guna2TextBox1.Text.ToString();
            string myname = Home.myname;
            string type = "text";
            string group = maGroup;

            Image avata = Home.avata;
            Class1 dsa = new Class1();
            ImageConverter _imageConverter = new ImageConverter();
            byte[] xByte = (byte[])_imageConverter.ConvertTo(guna2CirclePictureBox2.Image, typeof(byte[]));
            dsa.InsertChat(myname, hisname, contentss, type, group, avata, xByte);
             /*
               SentChat requestinfuser = new SentChat(myname, hisname, contentss, type, group, avata, avata);
               Command_Main.Message ms = new Command_Main.Message(Command_Main.Command.SendChat, SerializeHelpers.SerializeData(requestinfuser));
               this.Client.Send(ms.ToMessage());
           
              */
            guna2TextBox1.Text = "";
            if (maGroup.Equals("null"))
            {
                loadnewMychat();

            }
            else
            {
                loadnewMychatGroup();
            }
     

        }

        

        private void itemchatRight1_Load(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

       
        }

        private void guna2ImageButton4_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "All files (*.*)|*.*|All files(*.*) | *.* ";
            DialogResult res = openFileDialog1.ShowDialog();
            if (res == DialogResult.OK)
            {

                string fileName;
                fileName = System.IO.Path.GetFileName(openFileDialog1.FileName);
                string contentss = fileName;
                string myname = Home.myname;
                string type = "File";
                string group = maGroup;

                Image avata = Home.avata;
                Class1 dsa = new Class1();
                ImageConverter _imageConverter = new ImageConverter();
                byte[] xByte = (byte[])_imageConverter.ConvertTo(guna2CirclePictureBox2.Image, typeof(byte[]));
                dsa.InsertChat(myname, hisname, contentss, type, group, avata, xByte);

                guna2TextBox1.Text = "";
                if (maGroup.Equals("null"))
                {
                    loadnewMychat();

                }
                else
                {
                    loadnewMychatGroup();
                }

            }
        }

        private void guna2ImageButton3_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Images |*.bmp;*.jpg;*.png;*.gif;*.ico";
            DialogResult res = openFileDialog1.ShowDialog();
            if (res == DialogResult.OK)
            {
             Image Imagesend = Image.FromFile(openFileDialog1.FileName);

                string contentss = "null";
                string myname = Home.myname;
                string type = "Image";
                string group = maGroup;

                ImageConverter _imageConverter = new ImageConverter();
                byte[] xByte = (byte[])_imageConverter.ConvertTo(Imagesend, typeof(byte[]));

                Image avata = Home.avata;
                Class1 dsa = new Class1();
                dsa.InsertChat(myname, hisname, contentss, type, group, avata, xByte);
           
                guna2TextBox1.Text = "";
                if (maGroup.Equals("null"))
                {
                    loadnewMychat();

                }
                else
                {
                    loadnewMychatGroup();
                }


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
    

          
        }

        private void button2_Click(object sender, EventArgs e)
        {
        
         
        }

        private void Search_TextChanged(object sender, EventArgs e)
        {

        }

        private void openFileDialog2_FileOk(object sender, CancelEventArgs e)
        {

        }
        public void loadnewMychat()
        {    
         DataTable ds = Object.getchatNew();
            if (ds != null)
            {
                if (ds.Rows.Count > 0)
                {
                    ItemchatRight[] lisits2 = new ItemchatRight[ds.Rows.Count];
                    itemchat_Img_LEFT[] lisits3 = new itemchat_Img_LEFT[ds.Rows.Count];
                    Item_IconRight[] lisits6 = new Item_IconRight[ds.Rows.Count];
                    for (int i = 0; i < 1; i++)
                    {
                        foreach (DataRow row in ds.Rows)
                        {

                            flowLayoutPanel2.Invoke((MethodInvoker)delegate {
         
                                lisits2[i] = new ItemchatRight();
                                lisits3[i] = new itemchat_Img_LEFT();
                                lisits6[i] = new Item_IconRight();

                                string stype = row["type"].ToString();
                           
                                if (stype.Equals("text") || stype.Equals("File"))
                                {
            
                                    lisits2[i].namemy = row["content"].ToString();
                                    if (row["avatar"] != System.DBNull.Value)
                                    {
                                        MemoryStream ms = new MemoryStream((byte[])row["avatar"]);
                  
                                        lisits2[i].Icon = new Bitmap(ms);
                                    }
                                    string myname = Home.myname;
                                    if (row["myname"].ToString() == myname && row["hisname"].ToString() == hisname)
                                    {
                                        flowLayoutPanel2.Controls.Add(lisits2[i]);

                                    }
                             
                                }
                                else if (stype.Equals("Image"))
                                {
                                    if (row["imgSend"] != System.DBNull.Value)
                                    {
                                        MemoryStream ms = new MemoryStream((byte[])row["imgSend"]);
                          
                                        lisits3[i].imgssend = new Bitmap(ms);
                                    }

                                    if (row["avatar"] != System.DBNull.Value)
                                    {
                                        MemoryStream ms = new MemoryStream((byte[])row["avatar"]);
                             
                                        lisits3[i].Icon = new Bitmap(ms);
                                    }
                                    string myname = Home.myname;
                                    if (row["myname"].ToString() == myname && row["hisname"].ToString() == hisname)
                                    {
                                        flowLayoutPanel2.Controls.Add(lisits3[i]);

                                    }
                                  
                                }
                                else if (stype.Equals("Icon"))
                                {
                                    if (row["imgSend"] != System.DBNull.Value)
                                    {
                                        MemoryStream ms = new MemoryStream((byte[])row["imgSend"]);
                        
                                        lisits6[i].imgssend = new Bitmap(ms);
                                    }

                                    if (row["avatar"] != System.DBNull.Value)
                                    {
                                        MemoryStream ms = new MemoryStream((byte[])row["avatar"]);
                                 
                                        lisits6[i].Icon = new Bitmap(ms);
                                    }
                                    string myname = Home.myname;
                                    if (row["myname"].ToString() == myname && row["hisname"].ToString() == hisname)
                                    {
                                        flowLayoutPanel2.Controls.Add(lisits6[i]);

                                    }
                               
                                }
                           
                            });

                        }
                    }

                }


            }
   
            flowLayoutPanel2.AutoScrollPosition = new Point(0, int.MaxValue);
      
        }




        public void loadnewhischat()
        {
            DataTable ds = Object.getchatNew();

            if (ds != null)
            {
                if (ds.Rows.Count > 0)
                {
                    ItemchatLeft[] lisits = new ItemchatLeft[ds.Rows.Count];
                    itemChat_img_RIGHT[] lisits4 = new itemChat_img_RIGHT[ds.Rows.Count];
                    item_IconLeft[] lisits5 = new item_IconLeft[ds.Rows.Count];
                    for (int i = 0; i < 1; i++)
                    {
                        foreach (DataRow row in ds.Rows)
                        {

                            flowLayoutPanel2.Invoke((MethodInvoker)delegate {
                                lisits[i] = new ItemchatLeft();
                                lisits4[i] = new itemChat_img_RIGHT();
                                lisits5[i] = new item_IconLeft();
        

                                string stype = row["type"].ToString();
                                idla = Convert.ToInt32(row["id"]);
                                if (stype.Equals("text") || stype.Equals("File"))
                                {
                                    lisits[i].namemy = row["content"].ToString();
                                    if (row["avatar"] != System.DBNull.Value)
                                    {
                                        MemoryStream ms = new MemoryStream((byte[])row["avatar"]);
                                        lisits[i].Icon = new Bitmap(ms);
                                    }
                                    string myname = Home.myname;
                                   if (row["hisname"].ToString() == myname && row["myname"].ToString() == hisname)
                                    {
                                        flowLayoutPanel2.Controls.Add(lisits[i]);
                                    }
                                }
                                else if (stype.Equals("Image"))
                                {
                                    if (row["imgSend"] != System.DBNull.Value)
                                    {
                                        MemoryStream ms = new MemoryStream((byte[])row["imgSend"]);
                                        lisits4[i].imgssend = new Bitmap(ms);                  
                                    }

                                    if (row["avatar"] != System.DBNull.Value)
                                    {
                                        MemoryStream ms = new MemoryStream((byte[])row["avatar"]);
                                        lisits4[i].Icon = new Bitmap(ms);
                                    }
                                    string myname = Home.myname;
                                    if (row["hisname"].ToString() == myname && row["myname"].ToString() == hisname)
                                    {
                                        flowLayoutPanel2.Controls.Add(lisits4[i]);

                                    }
                                }
                                else if (stype.Equals("Icon"))
                                {
                                    if (row["imgSend"] != System.DBNull.Value)
                                    {
                                        MemoryStream ms = new MemoryStream((byte[])row["imgSend"]);
                                        lisits5[i].imgssend = new Bitmap(ms);             
                                    }

                                    if (row["avatar"] != System.DBNull.Value)
                                    {
                                        MemoryStream ms = new MemoryStream((byte[])row["avatar"]);
                                        lisits5[i].Icon = new Bitmap(ms);
                                    }
                                    string myname = Home.myname;
                                   if (row["hisname"].ToString() == myname && row["myname"].ToString() == hisname)
                                    {
                                        flowLayoutPanel2.Controls.Add(lisits5[i]);

                                    }
                                }
                             
                            });

                        }
                    }

                }


            }
            // int chane = flowLayoutPanel2.VerticalScroll.Value + flowLayoutPanel2.VerticalScroll.Maximum;
            flowLayoutPanel2.AutoScrollPosition = new Point(0, int.MaxValue);
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            if (maGroup.Equals("null"))
            {
                Class1 lao = new Class1();
                bool kal = lao.checkchatnew();
                if (kal == true)
                {
                   loadnewhischat();
                    Class1 kla = new Class1();
                  kla.updatechatnew(idla);

                }
            }
            else
            {
                Class1 lao = new Class1();
                bool kal2 = lao.checkchatCGroupnew(maGroup);
                if (kal2 == true)
                {
                    loadnewhischatGroup();
                    Class1 kla = new Class1();
                    kla.updatechatGRnew(idlal, maGroup);
                }
            }
      
        
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
          
           
     
        }
        private void guna2ImageButton2_Click(object sender, EventArgs e)
        {
            listView1.Visible = true;
            flowLayoutPanel2.Controls.Add(listView1);       
            flowLayoutPanel2.AutoScrollPosition = new Point(0, int.MaxValue);
         //   listView1.Click += ListView1_DoubleClick;

        }

        private void ListView1_DoubleClick(object sender, EventArgs e)
        {
           
              
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void guna2CirclePictureBox2_Click(object sender, EventArgs e)
        {
            flowLayoutPanel2.Controls.Remove(listView1);
            listView1.Visible = false;

            //senicon();
        }

 

        public void senicon()
        {

            ImageConverter _imageConverter = new ImageConverter();
            byte[] xByte = (byte[])_imageConverter.ConvertTo(guna2CirclePictureBox2.Image, typeof(byte[]));
 
            string contentss = "null";
            string myname = Home.myname;
            string type = "Icon";
            string group = maGroup;

            Image avata = Home.avata;
            Class1 dsa = new Class1();
            dsa.InsertChat(myname, hisname, contentss, type, group, avata, xByte);
        }

        public void addemoji()
        {

            var files = Directory.GetFiles("icons", ".", SearchOption.AllDirectories);
            int id = 0;
            listView1.LargeImageList = imageList1;
            foreach (string filename in files)
            {
                if (Regex.IsMatch(filename, @".jpg|.png|.gif$"))

                    imageList1.Images.Add(Image.FromFile(filename));
                // đưa lên list view
                listView1.Items.Add("", id);
                id++;
            }


        }

        private void listView1_MouseClick_1(object sender, MouseEventArgs e)
        {
            if (listView1.FocusedItem == null) return;

            try
            {
                int index = listView1.SelectedItems[0].Index;
                Image img = imageList1.Images[index];

                guna2CirclePictureBox2.Image = img;

                senicon();
                if (maGroup.Equals("null"))
                {
                    loadnewMychat();

                }
                else
                {
                    loadnewMychatGroup();
                }
                listView1.Visible = false;
            }
            catch
            {

            }

        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
   
        }






        ///////////////////////////////////////////////////////
        ///





        public void loadnewMychatGroup()
        {
            DataTable ds = Object.getnewchatGR(maGroup);
            if (ds != null)
            {
                if (ds.Rows.Count > 0)
                {
                    ItemchatRight[] lisits2 = new ItemchatRight[ds.Rows.Count];
                    itemchat_Img_LEFT[] lisits3 = new itemchat_Img_LEFT[ds.Rows.Count];
                    Item_IconRight[] lisits6 = new Item_IconRight[ds.Rows.Count];
                    for (int i = 0; i < 1; i++)
                    {
                        foreach (DataRow row in ds.Rows)
                        {

                            flowLayoutPanel2.Invoke((MethodInvoker)delegate {

                                lisits2[i] = new ItemchatRight();
                                lisits3[i] = new itemchat_Img_LEFT();
                                lisits6[i] = new Item_IconRight();

                                string stype = row["type"].ToString();
                              
                                if (stype.Equals("text") || stype.Equals("File"))
                                {

                                    lisits2[i].namemy = row["content"].ToString();
                                    if (row["avatar"] != System.DBNull.Value)
                                    {
                                        MemoryStream ms = new MemoryStream((byte[])row["avatar"]);

                                        lisits2[i].Icon = new Bitmap(ms);
                                    }
                                    string myname = Home.myname;
                                    if (row["myname"].ToString() == myname && row["hisname"].ToString() == hisname)
                                    {
                                        flowLayoutPanel2.Controls.Add(lisits2[i]);

                                    }

                                }
                                else if (stype.Equals("Image"))
                                {
                                    if (row["imgSend"] != System.DBNull.Value)
                                    {
                                        MemoryStream ms = new MemoryStream((byte[])row["imgSend"]);

                                        lisits3[i].imgssend = new Bitmap(ms);
                                    }

                                    if (row["avatar"] != System.DBNull.Value)
                                    {
                                        MemoryStream ms = new MemoryStream((byte[])row["avatar"]);

                                        lisits3[i].Icon = new Bitmap(ms);
                                    }
                                    string myname = Home.myname;
                                    if (row["myname"].ToString() == myname && row["hisname"].ToString() == hisname)
                                    {
                                        flowLayoutPanel2.Controls.Add(lisits3[i]);

                                    }

                                }
                                else if (stype.Equals("Icon"))
                                {
                                    if (row["imgSend"] != System.DBNull.Value)
                                    {
                                        MemoryStream ms = new MemoryStream((byte[])row["imgSend"]);

                                        lisits6[i].imgssend = new Bitmap(ms);
                                    }

                                    if (row["avatar"] != System.DBNull.Value)
                                    {
                                        MemoryStream ms = new MemoryStream((byte[])row["avatar"]);

                                        lisits6[i].Icon = new Bitmap(ms);
                                    }
                                    string myname = Home.myname;
                                    if (row["myname"].ToString() == myname && row["hisname"].ToString() == hisname)
                                    {
                                        flowLayoutPanel2.Controls.Add(lisits6[i]);

                                    }

                                }

                            });

                        }
                    }

                }


            }

            flowLayoutPanel2.AutoScrollPosition = new Point(0, int.MaxValue);

        }




        public void loadnewhischatGroup()
        {
            DataTable ds = Object.getnewchatGR(maGroup);

            if (ds != null)
            {
                if (ds.Rows.Count > 0)
                {
                    ItemchatLeft[] lisits = new ItemchatLeft[ds.Rows.Count];
                    itemChat_img_RIGHT[] lisits4 = new itemChat_img_RIGHT[ds.Rows.Count];
                    item_IconLeft[] lisits5 = new item_IconLeft[ds.Rows.Count];
                    for (int i = 0; i < 1; i++)
                    {
                        foreach (DataRow row in ds.Rows)
                        {

                            flowLayoutPanel2.Invoke((MethodInvoker)delegate {
                                lisits[i] = new ItemchatLeft();
                                lisits4[i] = new itemChat_img_RIGHT();
                                lisits5[i] = new item_IconLeft();


                                string stype = row["type"].ToString();
                                idlal = Convert.ToInt32(row["id"]);
                                if (stype.Equals("text") || stype.Equals("File"))
                                {
                                    lisits[i].namemy = row["content"].ToString();
                                    if (row["avatar"] != System.DBNull.Value)
                                    {
                                        MemoryStream ms = new MemoryStream((byte[])row["avatar"]);
                                        lisits[i].Icon = new Bitmap(ms);
                                    }
                                    string myname = Home.myname;
                                    if (row["hisname"].ToString() == hisname && row["myname"].ToString() != myname)
                                    {
                                        flowLayoutPanel2.Controls.Add(lisits[i]);
                                    }
                                }
                                else if (stype.Equals("Image"))
                                {
                                    if (row["imgSend"] != System.DBNull.Value)
                                    {
                                        MemoryStream ms = new MemoryStream((byte[])row["imgSend"]);
                                        lisits4[i].imgssend = new Bitmap(ms);
                                    }

                                    if (row["avatar"] != System.DBNull.Value)
                                    {
                                        MemoryStream ms = new MemoryStream((byte[])row["avatar"]);
                                        lisits4[i].Icon = new Bitmap(ms);
                                    }
                                    string myname = Home.myname;
                                    if (row["hisname"].ToString() == hisname && row["myname"].ToString() != myname)
                                    {
                                        flowLayoutPanel2.Controls.Add(lisits4[i]);

                                    }
                                }
                                else if (stype.Equals("Icon"))
                                {
                                    if (row["imgSend"] != System.DBNull.Value)
                                    {
                                        MemoryStream ms = new MemoryStream((byte[])row["imgSend"]);
                                        lisits5[i].imgssend = new Bitmap(ms);
                                    }

                                    if (row["avatar"] != System.DBNull.Value)
                                    {
                                        MemoryStream ms = new MemoryStream((byte[])row["avatar"]);
                                        lisits5[i].Icon = new Bitmap(ms);
                                    }
                                    string myname = Home.myname;
                                    if (row["hisname"].ToString() == hisname && row["myname"].ToString() != myname)
                                    {
                                        flowLayoutPanel2.Controls.Add(lisits5[i]);

                                    }
                                }

                            });

                        }
                    }

                }


            }
            // int chane = flowLayoutPanel2.VerticalScroll.Value + flowLayoutPanel2.VerticalScroll.Maximum;
            flowLayoutPanel2.AutoScrollPosition = new Point(0, int.MaxValue);

        }

    }
}
