using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Data.SqlClient;
//
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Data.OleDb;
using Command_Main;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting;

namespace ServerMain
{

    //trao doi server - client
    enum Command // dinh nghia cac lenh
    {
        Sendata, // showchat
        ShowUserChat, // showchat
        ShowChat, // showchat
        SendChat, // 
        CreatGroup,   //
                      // Booking,
                      // sendCategory,
                      // sendInfouser,
                      // changeInfoUser,
                      //  bookingt,
                      // Historybooking,
        Login,      //dag nhap
        Logout,     //dang xuat
        Message,    //thong diep
        List,       //lay danh sach client
        recData,    //nhan datatu server
        discon,     // ngat ket noi với 1 clent
        Null,      //No command
    }
    public delegate void DlgInitGrid(object datasource);
    public partial class FmDoashboard : Form
    {
       private string keyserver;
        //struct ClientInfo chua thong tin client dang nhap tren he thong
        struct ClientInfo
        {
            public Socket socket;   //bien Socket
            public string strName;  //ten 
        }

        //mang chua cac client tren server
        ArrayList clientList;

        //khai bao bien socket tren server
        Socket serverSocket;

        byte[] byteData = new byte[2048];



        public static string stree2;
        int IDcus;
        //


        public static int solog;
        SocketServer socketServer;
         DBconnection connect = new DBconnection();
        public FmDoashboard()
        {
            clientList = new ArrayList();
            InitializeComponent();
            //  SetServer(Server);
            socketServer = new SocketServer();
            socketServer.OnDataReceived += socketServer_OnDataReceived;
        }
        void socketServer_OnDataReceived(object sender, ReceivedDataEventArgs e)
        {

            
            // Xuly
            Command_Main.Message message = Command_Main.Message.Parse(e.Data);
            switch (message.Command)
              
            {
               
          
                case Command_Main.Command.Login:
                    LoginRequest request = (LoginRequest)SerializeHelpers.DeserializeData(message.DataByte);
                
                    // Validate
                    int makh = 0;
                    bool success = connect.ValidateLogin(request.ID, request.Password);
                

                    if (success == true)
                    {
                        DataTable db = connect.GetIDNguoidung(request.ID);
                        makh = Convert.ToInt32(db.Rows[0]["id"].ToString());
                    }

                    LoginResponse response = new LoginResponse() { Success = success };

                    Command_Main.Message responseMsg = new Command_Main.Message(Command_Main.Command.Login, SerializeHelpers.SerializeData(response));

                    ((SocketServer)sender).SetClientMaKH(e.SocketKey, makh);
                    ((SocketServer)sender).Send(responseMsg.ToMessage(), e.SocketKey);

                    break;


                case Command_Main.Command.Sendata:

                    var SendInfUserRequest = (SendInfUserRequest)SerializeHelpers.DeserializeData(message.DataByte);
                    SendInfUserResponse sendInfoUserResponse = this.GetInfoUserResponse(SendInfUserRequest.ID, SendInfUserRequest.Password);

                    var sendmesg = new Command_Main.Message(Command_Main.Command.Sendata, SerializeHelpers.SerializeData(sendInfoUserResponse));
                    ((SocketServer)sender).Send(sendmesg.ToMessage(), e.SocketKey);
                    break;




                case Command_Main.Command.ShowUserChat:
                    UserchatRequest res = (UserchatRequest)SerializeHelpers.DeserializeData(message.DataByte);

                    DataTable data = connect.GetUserChat();
                    UserchatResponse UserchatRequest = new UserchatResponse(data);
                    //    UserchatResponse UserchatRequest = this.GetUserChat();
                    var senhisResponseMsg = new Command_Main.Message(Command_Main.Command.ShowUserChat, SerializeHelpers.SerializeData(UserchatRequest));
                        ((SocketServer)sender).Send(senhisResponseMsg.ToMessage(), e.SocketKey);
                    break;

                case Command_Main.Command.SendChat:

                    SentChat sendchat = (SentChat)SerializeHelpers.DeserializeData(message.DataByte);

                    string myname = Convert.ToString(sendchat.Myname.ToString());
                    string hisname = Convert.ToString(sendchat.Hisname.ToString());
                
                    string ndchat = Convert.ToString(sendchat.Ndungchat.ToString());
                    string type = Convert.ToString(sendchat.Type.ToString());
                    string group = Convert.ToString(sendchat.Group.ToString());
                    Image avata = sendchat.avatar;
                    Image imgsends = sendchat.avatar;




                    //DBconnection0 connect0 = new DBconnection0();
                    connect.InsertChat(myname, hisname, ndchat, type, group, avata, imgsends);
          

                    break;

            }
        }


        public SendInfUserResponse GetInfoUserResponse(string id, string pass)
        {
        
            string name;
            string adress;
            string phone;
            string sex;
            int Id;
            string love, email;
            byte[] img;
            DataTable InfoData = connect.SendInfoUser(id, pass);

            Command_Main.SendInfUserResponse response = new Command_Main.SendInfUserResponse()
            {
                Items = new Command_Main.DataObjects.InfoUser[InfoData.Rows.Count]
            };

            for (int i = 0; i < InfoData.Rows.Count; i++)
            {
                name = InfoData.Rows[i]["name"].ToString();
                phone = InfoData.Rows[i]["phone"].ToString();
                adress = InfoData.Rows[i]["adress"].ToString();
                sex = InfoData.Rows[i]["Sex"].ToString();
                email = InfoData.Rows[i]["mail"].ToString();
                love = InfoData.Rows[i]["love"].ToString();
                img = (byte[])InfoData.Rows[i]["img"];
                Id = Convert.ToInt32(InfoData.Rows[i]["Id"].ToString());


                response.Items[i] = new Command_Main.DataObjects.InfoUser(Id, name, pass, phone, adress, email, sex, love, img);
            }
            return response;
        }




        /*
          public UserchatResponse GetUserChat() {

              string name;
              int id;
              byte[] img;
              DataTable InfoData = connect.GetUserChat();

              Command_Main.UserchatResponse response = new Command_Main.UserchatResponse()
              {
                  Items = new Command_Main.DataObjects.InfoItemUserChat[InfoData.Rows.Count]
              };

              for (int i = 0; i < InfoData.Rows.Count; i++)
              {
                  if (InfoData.Rows[i]["img"] != System.DBNull.Value)
                  {
                      img = (byte[])InfoData.Rows[i]["img"];
                      name = InfoData.Rows[i]["name"].ToString();

                     id = Convert.ToInt32(InfoData.Rows[i]["id"].ToString());
                    response.Items[i] = new Command_Main.DataObjects.InfoItemUserChat(id, name, img);
                  }

              }
              return response;
          }

  */




        private void guna2GradientCircleButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
      
        private void FmDoashboard_Load_1(object sender, EventArgs e)
        {
           
            System.Runtime.Remoting.Channels.Http.HttpChannel server = new System.Runtime.Remoting.Channels.Http.HttpChannel(9000);
            ChannelServices.RegisterChannel(server, false);
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(ClassLibrary.Class1), "MyObj", WellKnownObjectMode.SingleCall);
            // MessageBox.Show("Server đã chạy");

       

      
        
        }
        private void DoashBoard(object sender, EventArgs e)
        {

     

       
        }
        private void Button_Add_Items_Click(object sender, EventArgs e)
        {

   
          
        }
        private void Button_UpdateData_Click(object sender, EventArgs e)
        {

        
        }

        private void Button_Statistic_Click(object sender, EventArgs e) { 

  
        }

        private void logout_Click(object sender, EventArgs e)
        {

        }

        private void uC_Doashboard1_Load(object sender, EventArgs e)
        {

        }

        private void uC_Additems1_Load(object sender, EventArgs e)
        {

        }

        private void uC_UpdateData1_Load(object sender, EventArgs e)
        {

        }

        private void uC_ThongKe1_Load(object sender, EventArgs e)
        {

        }
        public byte[] SerializeData(Object o)
        {
            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf1 = new BinaryFormatter();

            bf1.Serialize(ms, o);
            return ms.ToArray();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
 
                 
   
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
    
        }
    }




    //cau truc data nhan va send 
    //each other
    class Data // khi nhan - giu du lieu he thong se chuyen doi du  lieu truoc khi hien thi
    {
        public Data()
        {
            this.cmdCommand = Command.Null;// lenh
            this.strMessage = null;// thong diep
            this.strName = null;// ten user
        }

        //cat chuoi byte sang du lieu 
        public Data(byte[] data)
        {
            //ta quy dinh 4 bit dau tien cho lenh
            this.cmdCommand = (Command)BitConverter.ToInt32(data, 0);

            //4 bit tip theo ten client
            int nameLen = BitConverter.ToInt32(data, 4);

            //4 bit tip theo chieu dai tin nhan
            int msgLen = BitConverter.ToInt32(data, 8);

            //kiem tra doi dai ten client 
            if (nameLen > 0)// neu do dai >0 
                this.strName = Encoding.UTF8.GetString(data, 12, nameLen);
            else
                this.strName = null;

            //kiem tra doi dai tin nhan 
            if (msgLen > 0)
                this.strMessage = Encoding.UTF8.GetString(data, 12 + nameLen, msgLen);
            else
                this.strMessage = null;
        }

        //chuyen doi du lieu vao mang byte
        public byte[] ToByte()
        {
            List<byte> result = new List<byte>();

            //4 bit dau . danh cho lenh
            result.AddRange(BitConverter.GetBytes((int)cmdCommand));

            //thêm chieu dai ten
            if (strName != null)
                result.AddRange(BitConverter.GetBytes(strName.Length));
            else
                result.AddRange(BitConverter.GetBytes(0));

            //doi dai tin nhan
            if (strMessage != null)
                result.AddRange(BitConverter.GetBytes(strMessage.Length));
            else
                result.AddRange(BitConverter.GetBytes(0));

            //them ten
            if (strName != null)
                result.AddRange(Encoding.UTF8.GetBytes(strName));

            //thong diep
            if (strMessage != null)
                result.AddRange(Encoding.UTF8.GetBytes(strMessage));

            return result.ToArray();
        }

        public string strName;      //ten khach hang tren he thong 
        public string strMessage;   //thong diep
        public Command cmdCommand;  //loai lenh : 5 loai (login, logout, send message, etcetera)
    }
}
