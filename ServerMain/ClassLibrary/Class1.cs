using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Command_Main;
using System.Drawing;
using System.IO;

namespace ClassLibrary
{
    public class Class1
    {
        public SqlConnection connection;
        private SqlCommand command;
        private SqlDataAdapter adater;
        private DataTable table;
        private string key = SerializeHelpers.GetKey();


        // public string ConnectionString = "Data Source=(local)\\SQLEXPRESS;Initial Catalog=AnNinhMang;User ID=sa; Password=123456";
        // private string connectstring = "server=.; database=AnNinhMang; integrated security = true;";

        static string strConnectionString = "Data Source=ADMIN;Initial Catalog=Chat;User ID=sa;Password=123456";
        public void OpenConnection()
        {
            connection = new SqlConnection(strConnectionString);

            connection.Open();

        }
        public void CloseConnection()
        {

            connection.Close();
        }


        public DataTable ExecuteCommandText(string cmdText)
        {
            DataTable data = null;

            OpenConnection();
            command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = cmdText;
            command.Connection = connection;

            adater = new SqlDataAdapter(command);

            data = new DataTable();
            adater.Fill(data);
            CloseConnection();
            return data;
        }
        public DataTable getmyusser(string tendangnhap, string matkhau)
        {
            OpenConnection();

            string sql = "SELECT  *  from NguoiDung where name ='" + tendangnhap + "' and pass ='" + matkhau + "' ";
            SqlCommand command = new SqlCommand(sql, connection);
            try
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(command))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    return dt;
                }
            }
            catch
            {
                throw;
            }
        }
        public DataSet GetData(string cmdText)
        {

            OpenConnection();
            command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = cmdText;
            command.Connection = connection;

            adater = new SqlDataAdapter(command);

            DataSet data1 = new DataSet();
            adater.Fill(data1);
            CloseConnection();
            return data1;
        }

        // đăng nhập admindbo.Tau

        public bool dangkykhachhang(string name, string pass, string love, string diachi, string phone, string email, string sex, Image img)
        {
         //   var img = new ImageConverter().ConvertTo(imgs, typeof(Byte[]));


            string sql = " Insert Into NguoiDung (name,pass,phone,mail,love,adress,Sex,img) values(@username,@pass,@phone,@mail,@love,@adress,@sex,@img)";

        //    string strConnectionString = "Data Source=ADMIN;Initial Catalog=chat;User ID=sa;Password=123456";
            SqlConnection con = new SqlConnection(strConnectionString);
            con.Open();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = sql;
            command.Connection = con;
            command.Parameters.AddWithValue("@username", name);
            command.Parameters.AddWithValue("@pass", pass);
            command.Parameters.AddWithValue("@phone", phone);
            command.Parameters.AddWithValue("@mail", email);
            command.Parameters.AddWithValue("@love", love);
            command.Parameters.AddWithValue("@adress", diachi);
            command.Parameters.AddWithValue("@sex", sex);

            MemoryStream ms = new MemoryStream();
            img.Save(ms, img.RawFormat);


            command.Parameters.AddWithValue("@img", ms.ToArray());

            int rows = command.ExecuteNonQuery();

            if (rows > 0)
                return true;
            else
                return false;

        }
        public bool ADD_Post(string title, string desc, Image img, string namp, Image avata)
        {
            //   var img = new ImageConverter().ConvertTo(imgs, typeof(Byte[]));

            string sts = "new";
            string sql = " Insert Into Post_App (title,descc,img,name_p,avata,status) values(@username,@pass,@phone,@mail,@love,@status)";

            //    string strConnectionString = "Data Source=ADMIN;Initial Catalog=chat;User ID=sa;Password=123456";
            SqlConnection con = new SqlConnection(strConnectionString);
            con.Open();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = sql;
            command.Connection = con;


            command.Parameters.AddWithValue("@username", title);
            command.Parameters.AddWithValue("@pass", desc);
            MemoryStream ms = new MemoryStream();
            img.Save(ms, img.RawFormat);
            command.Parameters.AddWithValue("@phone", ms.ToArray());
            command.Parameters.AddWithValue("@mail", namp);
            command.Parameters.AddWithValue("@status", sts);

            MemoryStream mss = new MemoryStream();
            avata.Save(mss, avata.RawFormat);
            command.Parameters.AddWithValue("@love", mss.ToArray());

            int rows = command.ExecuteNonQuery();

            if (rows > 0)
                return true;
            else
                return false;

        }
        public void updatepostnew(int id)
        {

            //  string Sovcl = Convert.ToString(sovecapnhat);
            string sqlq = "UPDATE Post_App SET status=@status WHERE [id]='" + id + "'";
            //update
            SqlConnection con = new SqlConnection(strConnectionString);
            con.Open();
            SqlCommand command1 = new SqlCommand();
            command1.CommandType = CommandType.Text;
            command1.CommandText = sqlq;
            command1.Connection = con;
            command1.Parameters.AddWithValue("@status", "old");
            command1.ExecuteNonQuery();

        }
        public DataTable getpostNew()
        {
            OpenConnection();
            string kkkk = "new";
            string query = "SELECT * FROM Post_App WHERE status='" + kkkk + "' ";
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(command))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    return dt;
                }
            }
            catch
            {
                throw;
            }

        }
        public bool checkpostnew()
        {
            string magr = "new";
            try
            {

                string query = "SELECT Count(*) as DEM FROM Post_App WHERE status='" + magr + "'";

                DataTable data = ExecuteCommandText(query);
                if (Convert.ToInt32(data.Rows[0]["DEM"].ToString()) > 0)

                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }

        }




        public bool Flower(string name, string love, string id, Image img)
        {
            //   var img = new ImageConverter().ConvertTo(imgs, typeof(Byte[]));


            string sql = " Insert Into Friends (idFR,name,Image,status) values(@id,@name,@img,@status)";

            //    string strConnectionString = "Data Source=ADMIN;Initial Catalog=chat;User ID=sa;Password=123456";
            SqlConnection con = new SqlConnection(strConnectionString);
            con.Open();
            int dd = Convert.ToInt32(id);


            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = sql;
            command.Connection = con;
            command.Parameters.AddWithValue("@id", dd);
            command.Parameters.AddWithValue("@name", name);

            command.Parameters.AddWithValue("@status", love);
       

            MemoryStream ms = new MemoryStream();
            img.Save(ms, img.RawFormat);


            command.Parameters.AddWithValue("@img", ms.ToArray());

            int rows = command.ExecuteNonQuery();

            if (rows > 0)
                return true;
            else
                return false;

        }


        public bool CeateGroup(string magr, string name, Image img, string leader)
        {
            //   var img = new ImageConverter().ConvertTo(imgs, typeof(Byte[]));


            string sql = " Insert Into Groups (maGR,name,imga,leader) values(@id,@name,@img,@ld)";

            //    string strConnectionString = "Data Source=ADMIN;Initial Catalog=chat;User ID=sa;Password=123456";
            SqlConnection con = new SqlConnection(strConnectionString);
            con.Open();



            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = sql;
            command.Connection = con;
            command.Parameters.AddWithValue("@id", magr);
            command.Parameters.AddWithValue("@name", name);

            command.Parameters.AddWithValue("@ld", leader);

            MemoryStream ms = new MemoryStream();
            img.Save(ms, img.RawFormat);


            command.Parameters.AddWithValue("@img", ms.ToArray());

            int rows = command.ExecuteNonQuery();

            if (rows > 0)
                return true;
            else
                return false;

        }
        public bool Addmember(string magr, string name, string hisname)
        {
            //   var img = new ImageConverter().ConvertTo(imgs, typeof(Byte[]));


            string sql = " Insert Into Groups_List (maGR,leader,member) values(@id,@name,@img)";

            //    string strConnectionString = "Data Source=ADMIN;Initial Catalog=chat;User ID=sa;Password=123456";
            SqlConnection con = new SqlConnection(strConnectionString);
            con.Open();



            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = sql;
            command.Connection = con;
            command.Parameters.AddWithValue("@id", magr);
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@img", hisname);

            int rows = command.ExecuteNonQuery();

            if (rows > 0)
                return true;
            else
                return false;

        }
        public bool LeaveFlower(string name)
        {
            //   var img = new ImageConverter().ConvertTo(imgs, typeof(Byte[]));


            string sql = "DELETE FROM Friends WHERE name='" + name + "'";
            SqlConnection con = new SqlConnection(strConnectionString);
            con.Open();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = sql;
            command.Connection = con;


            int rows = command.ExecuteNonQuery();
            if (rows > 0)
                return true;
            else
                return false;

        }
        public bool DelMemberGR(string magr, string nammb)
        {

            string sql = "DELETE FROM Groups_List WHERE maGR='" + magr + "' AND member='" + nammb + "'";
            SqlConnection con = new SqlConnection(strConnectionString);
            con.Open();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = sql;
            command.Connection = con;


            int rows = command.ExecuteNonQuery();
            if (rows > 0)
                return true;
            else
                return false;

        }
        public bool checkleader(string magr, string nammb)
        {
            try
            {

                string query = "SELECT Count(*) as DEM FROM Groups WHERE maGR='" + magr + "'AND leader='" + nammb + "'";

                DataTable data = ExecuteCommandText(query);
                if (Convert.ToInt32(data.Rows[0]["DEM"].ToString()) > 0)

                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }

        }
        public DataTable GetUserChat(int id)
        {
            OpenConnection();
            string sql = "SELECT * from Friends WHERE idFR='" + id + "'  ORDER BY id DESC";
            //    string sql = "select Soluongve,LoaiGhe,NgayDat,ThoigianChay,MaHD,total,Gaden,Gadi,TenDayDu,TenDangNhap,SoDienThoai,Email,DiaChi from HoaDon dv, nguoidung nd where nd.ID=dv.MaKH";

            SqlCommand command = new SqlCommand(sql, connection);
            try
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(command))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    return dt;
                }
            }
            catch
            {
                throw;
            }
            // return data;

        }
        public DataTable getGRchat()
        {
            OpenConnection();
            string sql = "SELECT * from Groups ORDER BY id DESC ";
            
            SqlCommand command = new SqlCommand(sql, connection);
            try
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(command))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    return dt;
                }
            }
            catch
            {
                throw;
            }
            // return data;

        }
        public DataTable getMYGRchat(string mynae)
        {
            OpenConnection();
            string sql = "SELECT * from Groups WHERE leader='" + mynae + "' ORDER BY id DESC ";

            SqlCommand command = new SqlCommand(sql, connection);
            try
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(command))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    return dt;
                }
            }
            catch
            {
                throw;
            }
            // return data;

        }
        public DataTable GetPosst()
        {
            OpenConnection();
            string sql = "SELECT * from Post_App ORDER BY id DESC";

            SqlCommand command = new SqlCommand(sql, connection);
            try
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(command))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    return dt;
                }
            }
            catch
            {
                throw;
            }
            // return data;

        }
        public DataTable GetUserSC()
        {
            OpenConnection();
            string sql = "SELECT * from NguoiDung ";
            //    string sql = "select Soluongve,LoaiGhe,NgayDat,ThoigianChay,MaHD,total,Gaden,Gadi,TenDayDu,TenDangNhap,SoDienThoai,Email,DiaChi from HoaDon dv, nguoidung nd where nd.ID=dv.MaKH";

            SqlCommand command = new SqlCommand(sql, connection);
            try
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(command))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    return dt;
                }
            }
            catch
            {
                throw;
            }
            // return data;

        }
        public DataTable getPro(string user)
        {
            OpenConnection();

            string query = "SELECT * FROM NguoiDung WHERE name='" + user + "'";
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(command))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    return dt;
                }
            }
            catch
            {
                throw;
            }
            
        }
        public DataTable getGR(string user)
        {
            OpenConnection();

            string query = "SELECT * FROM Groups WHERE name='" + user + "'";
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(command))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    return dt;
                }
            }
            catch
            {
                throw;
            }

        }
        public bool CheckBTAddfiend(string st, int id)
        {
            try
            {

                string query = "SELECT Count(*) as DEM FROM Friends WHERE name='" + st + "' AND idFR='" + id + "'";

                DataTable data = ExecuteCommandText(query);
                if (Convert.ToInt32(data.Rows[0]["DEM"].ToString()) > 0)

                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }

        }
        public bool checkposstFriends( int id)
        {
            try
            {

                string query = "SELECT Count(*) as DEM FROM Friends WHERE idFR='" + id + "'";

                DataTable data = ExecuteCommandText(query);
                if (Convert.ToInt32(data.Rows[0]["DEM"].ToString()) > 0)

                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }

        }
        public bool checkusser(string st)
        {
            try
            {

                string query = "SELECT Count(*) as DEM FROM NguoiDung WHERE name='" + st + "'";

                DataTable data = ExecuteCommandText(query);
                if (Convert.ToInt32(data.Rows[0]["DEM"].ToString()) > 0)

                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }

        }


        public bool CheckmemberGR(string magr, string myname)
        {
            try
            {

                string query = "SELECT Count(*) as DEM FROM Groups_List WHERE maGR='" + magr + "' AND ( leader='" + myname + "' OR member='" + myname + "')";

                DataTable data = ExecuteCommandText(query);
                if (Convert.ToInt32(data.Rows[0]["DEM"].ToString()) > 0)

                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }

        }


/*
        public bool CheckMYGR(string magr, string myname)
        {
            try
            {

                string query = "SELECT Count(*) as DEM FROM Groups_List WHERE maGR='" + magr + "' AND  leader='" + myname +  "'";

                DataTable data = ExecuteCommandText(query);
                if (Convert.ToInt32(data.Rows[0]["DEM"].ToString()) > 0)

                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }

        }*/

        public bool CheckMemberGR(string magr, string namemb)
        {
            try
            {

                string query = "SELECT Count(*) as DEM FROM Groups_List WHERE maGR='" + magr + "' AND  member='" + namemb + "'";

                DataTable data = ExecuteCommandText(query);
                if (Convert.ToInt32(data.Rows[0]["DEM"].ToString()) > 0)

                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }

        }


        public bool checkchatnew()
        {
            string magr = "new";
            try
            {

                string query = "SELECT Count(*) as DEM FROM chats WHERE status='" + magr + "'";

                DataTable data = ExecuteCommandText(query);
                if (Convert.ToInt32(data.Rows[0]["DEM"].ToString()) > 0)

                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }

        }
        public bool checkchatCGroupnew(string magr)
        {
            string stt = "new";
            try
            {

                string query = "SELECT Count(*) as DEM FROM chats WHERE status='" + stt + "'AND groupp='" + magr + "'";

                DataTable data = ExecuteCommandText(query);
                if (Convert.ToInt32(data.Rows[0]["DEM"].ToString()) > 0)

                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }

        }
        public DataTable getchats()
        {
            OpenConnection();

            string query = "SELECT * FROM chats ";
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(command))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    return dt;
                }
            }
            catch
            {
                throw;
            }

        }
        public DataTable getchatGR(string magr)
        {
            OpenConnection();

            string query = "SELECT * FROM chats WHERE groupp='" + magr + "' ";
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(command))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    return dt;
                }
            }
            catch
            {
                throw;
            }

        }



        public DataTable getnewchatGR(string magr)
        {
            OpenConnection();
            string kala = "new";
            string query = "SELECT * FROM chats WHERE groupp='" + magr + "' AND status='" + kala + "'";
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(command))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    return dt;
                }
            }
            catch
            {
                throw;
            }

        }
        public DataTable getchatNew()
        {
            OpenConnection();
            string kkkk = "new";
            string query = "SELECT * FROM chats WHERE status='" + kkkk + "' ";
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(command))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    return dt;
                }
            }
            catch
            {
                throw;
            }

        }
        public void updatechatnew(int id)
        {
            
          //  string Sovcl = Convert.ToString(sovecapnhat);
            string sqlq = "UPDATE chats SET status=@status WHERE [id]='" + id + "'";
            //update
            SqlConnection con = new SqlConnection(strConnectionString);
            con.Open();
            SqlCommand command1 = new SqlCommand();
            command1.CommandType = CommandType.Text;
            command1.CommandText = sqlq;
            command1.Connection = con;
            command1.Parameters.AddWithValue("@status", "old");
            command1.ExecuteNonQuery();
            
        }
        public void updatechatGRnew(int id, string grop)
        {

            //  string Sovcl = Convert.ToString(sovecapnhat);
            string sqlq = "UPDATE chats SET status=@status WHERE [id]='" + id + "' AND [groupp]='" + grop + "'";
            //update
            SqlConnection con = new SqlConnection(strConnectionString);
            con.Open();
            SqlCommand command1 = new SqlCommand();
            command1.CommandType = CommandType.Text;
            command1.CommandText = sqlq;
            command1.Connection = con;
            command1.Parameters.AddWithValue("@status", "old");
            command1.ExecuteNonQuery();

        }
        public bool InsertChat(string myname, string hisname, string ndchat, string type, string group, Image avata, byte[] imgsnd)
        {

            string sql = " Insert Into chats (myname, hisname,content,type,groupp,avatar,imgSend,status) values(@myname,@hisname,@content,@type,@group,@vata,@send,@status)";


            SqlConnection con = new SqlConnection(strConnectionString);
            con.Open();

            //them
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = sql;
            command.Connection = con;
            string kkkk = "new";
            command.Parameters.AddWithValue("@myname", myname);
            command.Parameters.AddWithValue("@hisname", hisname);
            command.Parameters.AddWithValue("@content", ndchat);
            command.Parameters.AddWithValue("@type", type);
            command.Parameters.AddWithValue("@group", group);
            command.Parameters.AddWithValue("@status", kkkk);
            MemoryStream ms = new MemoryStream();
            avata.Save(ms, avata.RawFormat);
            command.Parameters.AddWithValue("@vata", ms.ToArray());

            MemoryStream msss = new MemoryStream();
           // imgsnd.Save(msss, imgsnd.RawFormat);
            command.Parameters.AddWithValue("@send", imgsnd);

            int rows = command.ExecuteNonQuery();


            if (rows > 0)
                return true;
            else
                return false;

        }

    }
}
