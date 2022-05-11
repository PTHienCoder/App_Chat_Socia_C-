using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command_Main
{
    [Serializable]
    public class ChangeInfoUserRequest
    {
        public string Tendangnhap { get; set; }
        public string Matkhau { get; set; }
        public string Sodienthoai { get; set; }
        public string Diachi { get; set; }
        public string Tendaydu { get; set; }
        public string Email { get; set; }

        public ChangeInfoUserRequest(string User, string Pass, string Name, string Adress,  string Phone, string Email)
        {
       
            this.Tendangnhap = User;
            this.Matkhau = Pass;
            this.Sodienthoai = Name;
            this.Diachi = Adress;
            this.Tendaydu = Phone;
            this.Email = Email;
        }
    }
}
