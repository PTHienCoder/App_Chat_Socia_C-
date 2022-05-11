using ClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client_Demo
{
    public partial class Del_MemberGR : Form
    {
        string namemb, maGr, txxx, key;
        public Del_MemberGR(string maGR, string namMB, string text, string keys)
        {
            this.maGr = maGR;
            this.namemb = namMB;
            this.txxx = text;
            this.key = keys;
            InitializeComponent();
        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            Class1 dss = new Class1();
            bool ka = dss.DelMemberGR(maGr, namemb);
            this.Close();
        }

        private void Del_MemberGR_Load(object sender, EventArgs e)
        {
            label3.Text = txxx;

            if (key.Equals("out"))
            {
                guna2GradientButton2.Visible = true;
                guna2GradientButton3.Visible = false;
            }
            else if (key.Equals("del"))
            {
                guna2GradientButton2.Visible = false;
                guna2GradientButton3.Visible = true;
            }
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
               Class1 dss = new Class1(); 
                bool ka = dss.DelMemberGR(maGr, namemb);
                this.Close();
 
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
