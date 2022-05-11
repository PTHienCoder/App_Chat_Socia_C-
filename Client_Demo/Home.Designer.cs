
namespace Client_Demo
{
    partial class Home
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.guna2GradientCircleButton2 = new Guna.UI2.WinForms.Guna2GradientCircleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2GradientButton5 = new Guna.UI2.WinForms.Guna2GradientButton();
            this.guna2GradientButton2 = new Guna.UI2.WinForms.Guna2GradientButton();
            this.guna2GradientButton4 = new Guna.UI2.WinForms.Guna2GradientButton();
            this.guna2GradientButton3 = new Guna.UI2.WinForms.Guna2GradientButton();
            this.guna2GradientButton1 = new Guna.UI2.WinForms.Guna2GradientButton();
            this.guna2CirclePictureBox1 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.label26 = new System.Windows.Forms.Label();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2Elipse2 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2Elipse3 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.controlFriends1 = new Client_Demo.UC_control.ControlFriends();
            this.controlHome1 = new Client_Demo.UC_control.ControlHome();
            this.control_Profile1 = new Client_Demo.UC_control.Control_Profile();
            this.controlchat1 = new Client_Demo.UC_control.Controlchat();
            this.guna2Panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.White;
            this.guna2Panel1.Controls.Add(this.controlchat1);
            this.guna2Panel1.Controls.Add(this.control_Profile1);
            this.guna2Panel1.Controls.Add(this.controlHome1);
            this.guna2Panel1.Controls.Add(this.controlFriends1);
            this.guna2Panel1.Controls.Add(this.panel4);
            this.guna2Panel1.Location = new System.Drawing.Point(12, 12);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            this.guna2Panel1.Size = new System.Drawing.Size(956, 440);
            this.guna2Panel1.TabIndex = 1;
            this.guna2Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.guna2Panel1_Paint);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel4.Controls.Add(this.guna2GradientCircleButton2);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.guna2GradientButton5);
            this.panel4.Controls.Add(this.guna2GradientButton2);
            this.panel4.Controls.Add(this.guna2GradientButton4);
            this.panel4.Controls.Add(this.guna2GradientButton3);
            this.panel4.Controls.Add(this.guna2GradientButton1);
            this.panel4.Controls.Add(this.guna2CirclePictureBox1);
            this.panel4.Controls.Add(this.label26);
            this.panel4.Location = new System.Drawing.Point(727, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(230, 440);
            this.panel4.TabIndex = 41;
            this.panel4.Paint += new System.Windows.Forms.PaintEventHandler(this.panel4_Paint);
            // 
            // guna2GradientCircleButton2
            // 
            this.guna2GradientCircleButton2.CheckedState.Parent = this.guna2GradientCircleButton2;
            this.guna2GradientCircleButton2.CustomImages.Parent = this.guna2GradientCircleButton2;
            this.guna2GradientCircleButton2.FillColor = System.Drawing.Color.Gray;
            this.guna2GradientCircleButton2.FillColor2 = System.Drawing.Color.Silver;
            this.guna2GradientCircleButton2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2GradientCircleButton2.ForeColor = System.Drawing.Color.Black;
            this.guna2GradientCircleButton2.HoverState.Parent = this.guna2GradientCircleButton2;
            this.guna2GradientCircleButton2.Location = new System.Drawing.Point(207, 0);
            this.guna2GradientCircleButton2.Name = "guna2GradientCircleButton2";
            this.guna2GradientCircleButton2.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2GradientCircleButton2.ShadowDecoration.Parent = this.guna2GradientCircleButton2;
            this.guna2GradientCircleButton2.Size = new System.Drawing.Size(22, 21);
            this.guna2GradientCircleButton2.TabIndex = 41;
            this.guna2GradientCircleButton2.Text = "X";
            this.guna2GradientCircleButton2.Click += new System.EventHandler(this.guna2GradientCircleButton2_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(3, 170);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(215, 22);
            this.label1.TabIndex = 46;
            this.label1.Text = "Thông tin của bạn";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // guna2GradientButton5
            // 
            this.guna2GradientButton5.BorderRadius = 20;
            this.guna2GradientButton5.CheckedState.Parent = this.guna2GradientButton5;
            this.guna2GradientButton5.CustomImages.Parent = this.guna2GradientButton5;
            this.guna2GradientButton5.FillColor = System.Drawing.Color.Silver;
            this.guna2GradientButton5.FillColor2 = System.Drawing.Color.Goldenrod;
            this.guna2GradientButton5.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2GradientButton5.ForeColor = System.Drawing.Color.White;
            this.guna2GradientButton5.HoverState.Parent = this.guna2GradientButton5;
            this.guna2GradientButton5.Location = new System.Drawing.Point(-43, 212);
            this.guna2GradientButton5.Name = "guna2GradientButton5";
            this.guna2GradientButton5.ShadowDecoration.Parent = this.guna2GradientButton5;
            this.guna2GradientButton5.Size = new System.Drawing.Size(261, 40);
            this.guna2GradientButton5.TabIndex = 45;
            this.guna2GradientButton5.Text = "Trang Chủ";
            this.guna2GradientButton5.TextOffset = new System.Drawing.Point(10, 0);
            this.guna2GradientButton5.Click += new System.EventHandler(this.guna2GradientButton5_Click);
            // 
            // guna2GradientButton2
            // 
            this.guna2GradientButton2.BorderRadius = 20;
            this.guna2GradientButton2.CheckedState.Parent = this.guna2GradientButton2;
            this.guna2GradientButton2.CustomImages.Parent = this.guna2GradientButton2;
            this.guna2GradientButton2.FillColor = System.Drawing.Color.Silver;
            this.guna2GradientButton2.FillColor2 = System.Drawing.Color.MediumTurquoise;
            this.guna2GradientButton2.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2GradientButton2.ForeColor = System.Drawing.Color.White;
            this.guna2GradientButton2.HoverState.Parent = this.guna2GradientButton2;
            this.guna2GradientButton2.Location = new System.Drawing.Point(-81, 350);
            this.guna2GradientButton2.Name = "guna2GradientButton2";
            this.guna2GradientButton2.ShadowDecoration.Parent = this.guna2GradientButton2;
            this.guna2GradientButton2.Size = new System.Drawing.Size(236, 40);
            this.guna2GradientButton2.TabIndex = 42;
            this.guna2GradientButton2.Text = "Friends";
            this.guna2GradientButton2.TextOffset = new System.Drawing.Point(50, 0);
            this.guna2GradientButton2.Click += new System.EventHandler(this.guna2GradientButton2_Click_1);
            // 
            // guna2GradientButton4
            // 
            this.guna2GradientButton4.BorderRadius = 20;
            this.guna2GradientButton4.CheckedState.Parent = this.guna2GradientButton4;
            this.guna2GradientButton4.CustomImages.Parent = this.guna2GradientButton4;
            this.guna2GradientButton4.FillColor = System.Drawing.Color.Silver;
            this.guna2GradientButton4.FillColor2 = System.Drawing.Color.Maroon;
            this.guna2GradientButton4.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2GradientButton4.ForeColor = System.Drawing.Color.White;
            this.guna2GradientButton4.HoverState.Parent = this.guna2GradientButton4;
            this.guna2GradientButton4.Location = new System.Drawing.Point(-68, 394);
            this.guna2GradientButton4.Name = "guna2GradientButton4";
            this.guna2GradientButton4.ShadowDecoration.Parent = this.guna2GradientButton4;
            this.guna2GradientButton4.Size = new System.Drawing.Size(202, 40);
            this.guna2GradientButton4.TabIndex = 44;
            this.guna2GradientButton4.Text = "Logout";
            this.guna2GradientButton4.TextOffset = new System.Drawing.Point(50, 0);
            this.guna2GradientButton4.Click += new System.EventHandler(this.guna2GradientButton4_Click);
            // 
            // guna2GradientButton3
            // 
            this.guna2GradientButton3.BorderRadius = 20;
            this.guna2GradientButton3.CheckedState.Parent = this.guna2GradientButton3;
            this.guna2GradientButton3.CustomImages.Parent = this.guna2GradientButton3;
            this.guna2GradientButton3.FillColor = System.Drawing.Color.Silver;
            this.guna2GradientButton3.FillColor2 = System.Drawing.Color.MediumPurple;
            this.guna2GradientButton3.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2GradientButton3.ForeColor = System.Drawing.Color.White;
            this.guna2GradientButton3.HoverState.Parent = this.guna2GradientButton3;
            this.guna2GradientButton3.Location = new System.Drawing.Point(-43, 304);
            this.guna2GradientButton3.Name = "guna2GradientButton3";
            this.guna2GradientButton3.ShadowDecoration.Parent = this.guna2GradientButton3;
            this.guna2GradientButton3.Size = new System.Drawing.Size(218, 40);
            this.guna2GradientButton3.TabIndex = 43;
            this.guna2GradientButton3.Text = "Message";
            this.guna2GradientButton3.TextOffset = new System.Drawing.Point(20, 0);
            this.guna2GradientButton3.Click += new System.EventHandler(this.guna2GradientButton3_Click);
            // 
            // guna2GradientButton1
            // 
            this.guna2GradientButton1.BorderRadius = 20;
            this.guna2GradientButton1.CheckedState.Parent = this.guna2GradientButton1;
            this.guna2GradientButton1.CustomImages.Parent = this.guna2GradientButton1;
            this.guna2GradientButton1.FillColor = System.Drawing.Color.Silver;
            this.guna2GradientButton1.FillColor2 = System.Drawing.Color.MediumSeaGreen;
            this.guna2GradientButton1.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2GradientButton1.ForeColor = System.Drawing.Color.White;
            this.guna2GradientButton1.HoverState.Parent = this.guna2GradientButton1;
            this.guna2GradientButton1.Location = new System.Drawing.Point(-42, 258);
            this.guna2GradientButton1.Name = "guna2GradientButton1";
            this.guna2GradientButton1.ShadowDecoration.Parent = this.guna2GradientButton1;
            this.guna2GradientButton1.Size = new System.Drawing.Size(237, 40);
            this.guna2GradientButton1.TabIndex = 41;
            this.guna2GradientButton1.Text = "Trang cá nhân";
            this.guna2GradientButton1.TextOffset = new System.Drawing.Point(20, 0);
            this.guna2GradientButton1.Click += new System.EventHandler(this.guna2GradientButton1_Click_1);
            // 
            // guna2CirclePictureBox1
            // 
            this.guna2CirclePictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("guna2CirclePictureBox1.Image")));
            this.guna2CirclePictureBox1.Location = new System.Drawing.Point(53, 14);
            this.guna2CirclePictureBox1.Name = "guna2CirclePictureBox1";
            this.guna2CirclePictureBox1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CirclePictureBox1.ShadowDecoration.Parent = this.guna2CirclePictureBox1;
            this.guna2CirclePictureBox1.Size = new System.Drawing.Size(126, 126);
            this.guna2CirclePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2CirclePictureBox1.TabIndex = 40;
            this.guna2CirclePictureBox1.TabStop = false;
            // 
            // label26
            // 
            this.label26.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label26.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label26.Location = new System.Drawing.Point(27, 143);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(182, 27);
            this.label26.TabIndex = 25;
            this.label26.Text = "name\r\n";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.TargetControl = this.panel4;
            this.guna2DragControl1.UseTransparentDrag = true;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // controlFriends1
            // 
            this.controlFriends1.BackColor = System.Drawing.Color.White;
            this.controlFriends1.Location = new System.Drawing.Point(0, 0);
            this.controlFriends1.Name = "controlFriends1";
            this.controlFriends1.Size = new System.Drawing.Size(724, 434);
            this.controlFriends1.TabIndex = 42;
            // 
            // controlHome1
            // 
            this.controlHome1.BackColor = System.Drawing.Color.White;
            this.controlHome1.Location = new System.Drawing.Point(0, 0);
            this.controlHome1.Name = "controlHome1";
            this.controlHome1.Size = new System.Drawing.Size(724, 434);
            this.controlHome1.TabIndex = 43;
            // 
            // control_Profile1
            // 
            this.control_Profile1.BackColor = System.Drawing.Color.White;
            this.control_Profile1.Location = new System.Drawing.Point(7, 0);
            this.control_Profile1.Name = "control_Profile1";
            this.control_Profile1.Size = new System.Drawing.Size(714, 434);
            this.control_Profile1.TabIndex = 44;
            // 
            // controlchat1
            // 
            this.controlchat1.BackColor = System.Drawing.Color.White;
            this.controlchat1.Client = null;
            this.controlchat1.Location = new System.Drawing.Point(7, 0);
            this.controlchat1.Name = "controlchat1";
            this.controlchat1.Size = new System.Drawing.Size(714, 434);
            this.controlchat1.TabIndex = 45;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Cyan;
            this.ClientSize = new System.Drawing.Size(981, 465);
            this.Controls.Add(this.guna2Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home";
            this.Load += new System.EventHandler(this.Home_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse2;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse3;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label26;
        private Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox1;
        private Guna.UI2.WinForms.Guna2GradientButton guna2GradientButton4;
        private Guna.UI2.WinForms.Guna2GradientButton guna2GradientButton3;
        private Guna.UI2.WinForms.Guna2GradientButton guna2GradientButton2;
        private Guna.UI2.WinForms.Guna2GradientButton guna2GradientButton1;
        private Guna.UI2.WinForms.Guna2GradientButton guna2GradientButton5;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2GradientCircleButton guna2GradientCircleButton2;
        private UC_control.ControlFriends controlFriends1;
        private UC_control.Control_Profile control_Profile1;
        private UC_control.ControlHome controlHome1;
        private UC_control.Controlchat controlchat1;
    }
}