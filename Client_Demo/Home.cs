using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Command_Main;
using System.Net;
using System.Security.Cryptography;
using System.Runtime.Remoting;
using ClassLibrary;
using Guna.UI2.WinForms;
using System.IO;

namespace Client_Demo
{
    public delegate void DlgInitGrid(object datasource);
    public partial class Home : Form
    {
        ClassLibrary.Class1 Object;
        byte[] photo_aray;
        public DataTable Data_category;
        private string Id;
        private string Pass;
        private int ID;
        public static string myid;
        string Myname;
        private string user, pass;
        DataTable DataUserInfo;
        public static string myname;
        public static Image avata;
        public static string phone, email, adress, sex, love;
        public SocketClient Client { get; set; }
        public Home()
        {

            Login_Client loginForm = new Login_Client(Id, Pass);
            SetInfor_User sn = new SetInfor_User(user, pass);
            if (loginForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.Id = loginForm.ID;
                this.Pass = loginForm.PASSWORD;
                this.SetClient(loginForm.Client);

                this.InitializeComponent();
                /*
                 SendInfUserRequest requestinfuser = new SendInfUserRequest(Id, Pass);
                 Command_Main.Message message_infouser = new Command_Main.Message(Command_Main.Command.Sendata, SerializeHelpers.SerializeData(requestinfuser));
                 this.Client.Send(message_infouser.ToMessage());
              */
                loadttusser();
            }

            else
            {
              Application.Exit();
               // this.Close();
            }

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


        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        void Client_OnDataReceived(object sender, ReceivedDataEventArgs e)
        {
            Command_Main.Message messageResponse = Command_Main.Message.Parse(e.Data);

            switch (messageResponse.Command)
            {   
                case Command_Main.Command.Sendata:

                    SendInfUserResponse sendUserResponse = (SendInfUserResponse)SerializeHelpers.DeserializeData(messageResponse.DataByte);

                    for (int i = 0; i < sendUserResponse.Items.Length; i++)
                    {

                        myid = sendUserResponse.Items[i].Id.ToString();
                        Myname = sendUserResponse.Items[i].Name;
                        label26.Text = sendUserResponse.Items[i].Name;
                        label1.Text = sendUserResponse.Items[i].Love;

                        myname = sendUserResponse.Items[i].Name;
                        email = sendUserResponse.Items[i].Email;
                        phone = sendUserResponse.Items[i].Phone;
                        sex = sendUserResponse.Items[i].Sex;
                        love = sendUserResponse.Items[i].Love;
                        adress = sendUserResponse.Items[i].Adress;
                        //      photo_aray = (byte[])sendUserResponse.Items[i].Img;
                        MemoryStream ms = new MemoryStream((byte[])sendUserResponse.Items[i].Img);
                           guna2CirclePictureBox1.Image = new Bitmap(ms);
                             avata = new Bitmap(ms);
                    }


                    break;



            }


            // Read rows from DataReader and populate the DataTable
        }
        private void iteamVeTau1_Click(object sender, EventArgs e)
        {

        }
        public void loadttusser()
        {

            Class1 dsa = new Class1();
            DataTable ds = dsa.getmyusser(Id, Pass);
            if (ds != null)
            {
                if (ds.Rows.Count > 0)
                {
                    Item_userchat[] lisits = new Item_userchat[ds.Rows.Count];

                    for (int i = 0; i < 1; i++)
                    {
                        foreach (DataRow row in ds.Rows)
                        {

                            label26.Text = row["name"].ToString();
                            label1.Text = row["love"].ToString();
                            myname = row["name"].ToString();
                            phone = row["phone"].ToString();
                            adress = row["adress"].ToString();
                            sex = row["Sex"].ToString();
                            email = row["mail"].ToString();
                            love = row["love"].ToString();
                            if (row["img"] != System.DBNull.Value)
                            {
                                MemoryStream ms = new MemoryStream((byte[])row["img"]);
                                guna2CirclePictureBox1.Image = new Bitmap(ms);
                                avata = new Bitmap(ms);
                            }
                            myid = row["Id"].ToString();

                        }
                    }

                }
            }

        }
        private void usercontrol_click(object sender, EventArgs e)
        {

        }

        private void InitializeGrid(object datasource)
        {


   

        }


        /*
            private void usercontrol_click1(object sender, EventArgs e)
            {
                IteamVeTau obj = (IteamVeTau)sender;
                string tenct = obj.NameCT;
                string ngaydi = obj.Ngay;
                string thoigiankhoihanh = obj.Thoigian;

                int soluongve = obj.Slveconlai;
                string gadi = obj.Gadi;
                string gaden = obj.Gaden;
                string giave = obj.Giave;
                DataTable data = Data_category;
                FmBooking fr = new FmBooking(soluongve, mact, tenct, ngaydi, thoigiankhoihanh, gadi, gaden, ID, giave);

                fr.SetClient(this.Client);
                fr.Show();

            }
            */


        private void Home_Load(object sender, EventArgs e)
        {
            controlHome1.Visible = true;
            controlchat1.Visible = false;
            controlFriends1.Visible = false;
            control_Profile1.Visible = false;

            WellKnownClientTypeEntry entry = RemotingConfiguration.IsWellKnownClientType(typeof(ClassLibrary.Class1));
            if (entry == null)
            {
                // register
                RemotingConfiguration.RegisterWellKnownClientType(typeof(ClassLibrary.Class1), "http://127.0.0.1:9000/MyObj");
                Object = new ClassLibrary.Class1();
            }

        }


        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

     

        } 
       
        public void loaddata()
        {
    
        }
        private void label15_Click(object sender, EventArgs e)
        {

        }
    // button load

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
   
        
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
          
        }

        private void GvListTicketCT_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
    
        }

        private void iteamVeTau1_Load(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {

/*
            UserchatRequest requestinfuser = new UserchatRequest();
            Command_Main.Message ms = new Command_Main.Message(Command_Main.Command.ShowUserChat, SerializeHelpers.SerializeData(requestinfuser));
            this.Client.Send(ms.ToMessage());
*/
            controlchat1.SetClient(this.Client);
            controlHome1.Visible = false;
            controlchat1.Visible = true;
            controlchat1.loaduserchat();
            controlchat1.loadgroupschat();
            controlFriends1.Visible = false;
            control_Profile1.Visible = false;


        }

        private void guna2GradientButton5_Click(object sender, EventArgs e)
        {
            controlHome1.Visible = true;
            controlHome1.loadposst();
            controlchat1.Visible = false;
            controlFriends1.Visible = false;
            control_Profile1.Visible = false;
        }
        private void guna2GradientButton1_Click_1(object sender, EventArgs e)
        {
            //   trang ca nhân
            controlHome1.Visible = false;
            controlchat1.Visible = false;
            controlFriends1.Visible = false;
            control_Profile1.Visible = true;
            control_Profile1.loaduser_Friends();
        }
        private void guna2GradientButton2_Click_1(object sender, EventArgs e)
        {
            //   friends
            controlHome1.Visible = false;
            controlchat1.Visible = false;
            controlFriends1.Visible = true;
            controlFriends1.loaduser_social();
            control_Profile1.Visible = false;
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
           
        }

        private void guna2GradientCircleButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void tbTenchuyentau_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
     
        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {
            ///logout

            this.Hide(); 

        }

        private void guna2GradientCircleButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

     

        private void timer1_Tick(object sender, EventArgs e)
        {


        }


    }
}
