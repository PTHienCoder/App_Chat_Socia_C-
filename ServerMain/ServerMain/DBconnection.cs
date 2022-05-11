using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using Command_Main;
using System.Drawing;
using System.IO;

namespace ServerMain
{
    //        static string strConnectionString = "Data Source=ADMIN\\MSSQLSERVER01;Initial Catalog=Datvetauhoa;User ID=sa;Password=123456";
    class DBconnection
    {
        string keya;
        public SqlConnection connection;
        private SqlCommand command;
        private SqlDataAdapter adater;
        private DataTable table;
        private string key = SerializeHelpers.GetKey();


        // public string ConnectionString = "Data Source=(local)\\SQLEXPRESS;Initial Catalog=AnNinhMang;User ID=sa; Password=123456";
        // private string connectstring = "server=.; database=AnNinhMang; integrated security = true;";
        static string strConnectionString = "Data Source=ADMIN;Initial Catalog=chat;User ID=sa;Password=123456";
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



        public bool ValidateLogin(string user, string pass)
        {
            try
            {
                string s = user.Trim();
                while (s.IndexOf("  ") >= 0)    //tim trong chuoi vi tri co 2 khoang trong tro len      
                    s = s.Replace("  ", " ");   //sau do thay the bang 1 khoang trong            





                string query = "SELECT Count(*) as DEM FROM NguoiDung WHERE name='" + user + "' AND pass='" + pass + "'";

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


        public DataTable SendInfoUser(string tendangnhap, string matkhau)
        {
            string s = tendangnhap.Trim();
            while (s.IndexOf("  ") >= 0)    //tim trong chuoi vi tri co 2 khoang trong tro len      
                s = s.Replace("  ", " ");
          

            string sql = "SELECT  *  from NguoiDung where name ='" + tendangnhap + "' and pass ='" + matkhau + "' ";
            DataTable data = ExecuteCommandText(sql);

            DataTable DataTable_Decrypt = new DataTable();
            DataTable_Decrypt.Columns.Add(new DataColumn("id", typeof(int)));
            DataTable_Decrypt.Columns.Add(new DataColumn("name", typeof(string)));
            DataTable_Decrypt.Columns.Add(new DataColumn("pass", typeof(string)));
            DataTable_Decrypt.Columns.Add(new DataColumn("phone", typeof(string)));
            DataTable_Decrypt.Columns.Add(new DataColumn("mail", typeof(string)));
            DataTable_Decrypt.Columns.Add(new DataColumn("love", typeof(string)));
            DataTable_Decrypt.Columns.Add(new DataColumn("adress", typeof(string)));
            DataTable_Decrypt.Columns.Add(new DataColumn("Sex", typeof(string)));
             DataTable_Decrypt.Columns.Add(new DataColumn("img", typeof(byte[])));

            for (int i = 0; i < data.Rows.Count; i++)
            {
                DataRow NewRow = DataTable_Decrypt.NewRow();
                NewRow["id"] = data.Rows[i]["id"];
                NewRow["name"] = data.Rows[i]["name"].ToString();
                NewRow["pass"] = data.Rows[i]["pass"].ToString();
                NewRow["phone"] = data.Rows[i]["phone"].ToString();
                NewRow["mail"] = data.Rows[i]["mail"].ToString();
                NewRow["love"] = data.Rows[i]["love"].ToString();
                NewRow["adress"] = data.Rows[i]["adress"].ToString();
                NewRow["Sex"] = data.Rows[i]["Sex"].ToString();
                NewRow["img"] = data.Rows[i]["img"];
                DataTable_Decrypt.Rows.Add(NewRow);
            }

            return DataTable_Decrypt;
        }


        public DataTable GetIDNguoidung(string nguoidung)
        {
            
   
            string sql = "select id from Nguoidung where name ='" + nguoidung + "'";
            DataTable data = ExecuteCommandText(sql);

            DataTable DataTable_Decrypt = new DataTable();
            DataTable_Decrypt.Columns.Add(new DataColumn("id", typeof(int)));


            for (int i = 0; i < data.Rows.Count; i++)
            {
                DataRow NewRow = DataTable_Decrypt.NewRow();


                NewRow["id"] = Convert.ToInt32(data.Rows[i]["id"].ToString());


                DataTable_Decrypt.Rows.Add(NewRow);
            }

            return DataTable_Decrypt;
            // return data;

        }






        public bool InsertChat( string myname, string hisname, string ndchat, string type, string group, Image avata, Image imgsnd)
        {


        


            string sql = " Insert Into chats (myname, hisname,content,type,groupp,avatar,imgSend) values(@myname,@hisname,@content,@type,@group,@vata,@send)";


            SqlConnection con = new SqlConnection(strConnectionString);
            con.Open();

            //them
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = sql;
            command.Connection = con;

            command.Parameters.AddWithValue("@myname", myname);
            command.Parameters.AddWithValue("@hisname", hisname);
            command.Parameters.AddWithValue("@content", ndchat);
            command.Parameters.AddWithValue("@type", type);
            command.Parameters.AddWithValue("@group", group);

            MemoryStream ms = new MemoryStream();
            avata.Save(ms, avata.RawFormat);
            command.Parameters.AddWithValue("@vata", ms.ToArray());

            MemoryStream msss = new MemoryStream();
            imgsnd.Save(msss, imgsnd.RawFormat);
            command.Parameters.AddWithValue("@send", msss.ToArray());

            int rows = command.ExecuteNonQuery();
  

            if (rows > 0)
                return true;
            else
                return false;

        }
        public void updatesoluongvetau(string tenct, int sovecapnhat)
        {
            string Sovcl = Convert.ToString(sovecapnhat);
            string Tenchuyentau = tenct;
            string sqlq = "UPDATE Chuyentau SET SoVeToiDa=@soveconlai WHERE [TenChuyenTau]='" + Tenchuyentau + "'";
            //update
            SqlConnection con = new SqlConnection(strConnectionString);
            con.Open();
            SqlCommand command1 = new SqlCommand();
            command1.CommandType = CommandType.Text;
            command1.CommandText = sqlq;
            command1.Connection = con;
            command1.Parameters.AddWithValue("@soveconlai", Sovcl);
            command1.ExecuteNonQuery();

        }

       


        public DataTable GetUserChat()
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

    }
}
