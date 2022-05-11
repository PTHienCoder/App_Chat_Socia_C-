using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command_Main.DataObjects
{
    [Serializable]
    public class InfoUser
    {
        public string Name { get; set; }
        public string Pass { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public string Sex { get; set; }
        public string Email { get; set; }

        public string Love { get; set; }
        public byte[] Img { get; set; }
        public int Id;
        public InfoUser(int id, string name, string pass, string phone, string adress,string email, string sex, string love, byte[] img)
        {
            this.Name = name;
            this.Pass = pass;
            this.Adress = adress;
            this.Phone = phone;
            this.Sex = sex;
            this.Love = love;
            this.Email = email;
            this.Img = img;
            this.Id = id;
        }
    }
}
