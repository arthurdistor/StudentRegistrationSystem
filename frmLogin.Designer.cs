namespace TestStudentRegistration
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblDateTime = new System.Windows.Forms.Label();
            this.Logout = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.Panel = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnLogin = new ePOSOne.btnProduct.Button_WOC();
            this.btnCloseNo = new ePOSOne.btnProduct.Button_WOC();
            this.btnCloseYes = new ePOSOne.btnProduct.Button_WOC();
            this.lblForgotPass = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.txtforgotusername = new System.Windows.Forms.TextBox();
            this.txtforgotpassword = new System.Windows.Forms.TextBox();
            this.btnForgotChangePass = new ePOSOne.btnProduct.Button_WOC();
            this.btnForgotClose = new System.Windows.Forms.PictureBox();
            this.ForgotPass = new System.Windows.Forms.Panel();
            this.txtforgotadminpass = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtforgotadminuser = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            this.Logout.SuspendLayout();
            this.Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnForgotClose)).BeginInit();
            this.ForgotPass.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtUser
            // 
            this.txtUser.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUser.Location = new System.Drawing.Point(50, 302);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(288, 23);
            this.txtUser.TabIndex = 1;
            this.txtUser.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUser_KeyPress);
            // 
            // txtPass
            // 
            this.txtPass.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPass.Location = new System.Drawing.Point(50, 366);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(288, 23);
            this.txtPass.TabIndex = 2;
            this.txtPass.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPass_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(45, 274);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Username:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(45, 338);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(39, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 37);
            this.label3.TabIndex = 4;
            this.label3.Text = "Student";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(113)))), ((int)(((byte)(201)))));
            this.panel1.Controls.Add(this.lblForgotPass);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnLogin);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtUser);
            this.panel1.Controls.Add(this.txtPass);
            this.panel1.Location = new System.Drawing.Point(587, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(399, 750);
            this.panel1.TabIndex = 6;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.move_window);
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(293, 684);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(114, 63);
            this.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnClose.TabIndex = 8;
            this.btnClose.TabStop = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(39, 163);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(175, 37);
            this.label5.TabIndex = 6;
            this.label5.Text = "Registration";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(40, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 37);
            this.label4.TabIndex = 5;
            this.label4.Text = "System";
            // 
            // lblDateTime
            // 
            this.lblDateTime.AutoSize = true;
            this.lblDateTime.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(45)))), ((int)(((byte)(101)))));
            this.lblDateTime.Location = new System.Drawing.Point(22, 28);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(176, 32);
            this.lblDateTime.TabIndex = 7;
            this.lblDateTime.Text = "Date and time";
            // 
            // Logout
            // 
            this.Logout.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Logout.Controls.Add(this.label6);
            this.Logout.Controls.Add(this.btnCloseNo);
            this.Logout.Controls.Add(this.label7);
            this.Logout.Controls.Add(this.btnCloseYes);
            this.Logout.Controls.Add(this.label44);
            this.Logout.Location = new System.Drawing.Point(254, 200);
            this.Logout.Name = "Logout";
            this.Logout.Size = new System.Drawing.Size(373, 170);
            this.Logout.TabIndex = 83;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(45)))), ((int)(((byte)(101)))));
            this.label6.Location = new System.Drawing.Point(103, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(182, 30);
            this.label6.TabIndex = 68;
            this.label6.Text = "close the system?";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Sitka Heading", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(45)))), ((int)(((byte)(101)))));
            this.label7.Location = new System.Drawing.Point(176, 7);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(25, 39);
            this.label7.TabIndex = 66;
            this.label7.Text = "i";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label44.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(45)))), ((int)(((byte)(101)))));
            this.label44.Location = new System.Drawing.Point(77, 36);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(241, 30);
            this.label44.TabIndex = 0;
            this.label44.Text = "Are you sure you want ";
            // 
            // Panel
            // 
            this.Panel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Panel.Controls.Add(this.panel1);
            this.Panel.Controls.Add(this.pictureBox1);
            this.Panel.Controls.Add(this.lblDateTime);
            this.Panel.Location = new System.Drawing.Point(0, 0);
            this.Panel.Name = "Panel";
            this.Panel.Size = new System.Drawing.Size(1019, 750);
            this.Panel.TabIndex = 84;
            this.Panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.move_window);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(61, 137);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(478, 519);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.move_window);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(113)))), ((int)(((byte)(201)))));
            this.btnLogin.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(45)))), ((int)(((byte)(101)))));
            this.btnLogin.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(45)))), ((int)(((byte)(101)))));
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(153)))), ((int)(((byte)(193)))));
            this.btnLogin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(153)))), ((int)(((byte)(193)))));
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnLogin.Location = new System.Drawing.Point(143, 425);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.OnHoverBorderColor = System.Drawing.Color.White;
            this.btnLogin.OnHoverButtonColor = System.Drawing.Color.White;
            this.btnLogin.OnHoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(153)))), ((int)(((byte)(193)))));
            this.btnLogin.Size = new System.Drawing.Size(119, 37);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "Login";
            this.btnLogin.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(153)))), ((int)(((byte)(193)))));
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            this.btnLogin.MouseHover += new System.EventHandler(this.btnLogin_MouseHover);
            // 
            // btnCloseNo
            // 
            this.btnCloseNo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(114)))), ((int)(((byte)(168)))));
            this.btnCloseNo.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(114)))), ((int)(((byte)(168)))));
            this.btnCloseNo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCloseNo.FlatAppearance.BorderSize = 0;
            this.btnCloseNo.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCloseNo.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCloseNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseNo.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloseNo.Location = new System.Drawing.Point(225, 105);
            this.btnCloseNo.Name = "btnCloseNo";
            this.btnCloseNo.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(153)))), ((int)(((byte)(193)))));
            this.btnCloseNo.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(153)))), ((int)(((byte)(193)))));
            this.btnCloseNo.OnHoverTextColor = System.Drawing.Color.White;
            this.btnCloseNo.Size = new System.Drawing.Size(121, 46);
            this.btnCloseNo.TabIndex = 67;
            this.btnCloseNo.Text = "No";
            this.btnCloseNo.TextColor = System.Drawing.Color.White;
            this.btnCloseNo.UseVisualStyleBackColor = true;
            this.btnCloseNo.Click += new System.EventHandler(this.btnCloseNo_Click);
            // 
            // btnCloseYes
            // 
            this.btnCloseYes.BorderColor = System.Drawing.Color.Red;
            this.btnCloseYes.ButtonColor = System.Drawing.Color.Red;
            this.btnCloseYes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCloseYes.FlatAppearance.BorderSize = 0;
            this.btnCloseYes.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCloseYes.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCloseYes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseYes.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloseYes.Location = new System.Drawing.Point(27, 105);
            this.btnCloseYes.Name = "btnCloseYes";
            this.btnCloseYes.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(153)))), ((int)(((byte)(193)))));
            this.btnCloseYes.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(153)))), ((int)(((byte)(193)))));
            this.btnCloseYes.OnHoverTextColor = System.Drawing.Color.White;
            this.btnCloseYes.Size = new System.Drawing.Size(121, 46);
            this.btnCloseYes.TabIndex = 65;
            this.btnCloseYes.Text = "Yes";
            this.btnCloseYes.TextColor = System.Drawing.Color.White;
            this.btnCloseYes.UseVisualStyleBackColor = true;
            this.btnCloseYes.Click += new System.EventHandler(this.btnCloseYes_Click);
            // 
            // lblForgotPass
            // 
            this.lblForgotPass.AutoSize = true;
            this.lblForgotPass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblForgotPass.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblForgotPass.Location = new System.Drawing.Point(246, 397);
            this.lblForgotPass.Name = "lblForgotPass";
            this.lblForgotPass.Size = new System.Drawing.Size(92, 13);
            this.lblForgotPass.TabIndex = 9;
            this.lblForgotPass.Text = "Forgot Password?";
            this.lblForgotPass.Click += new System.EventHandler(this.lblForgotPass_Click);
            this.lblForgotPass.MouseLeave += new System.EventHandler(this.lblForgotPass_MouseLeave);
            this.lblForgotPass.MouseHover += new System.EventHandler(this.lblForgotPass_MouseHover);
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label39.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(114)))), ((int)(((byte)(168)))));
            this.label39.Location = new System.Drawing.Point(66, 50);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(87, 21);
            this.label39.TabIndex = 74;
            this.label39.Text = "Username";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label42.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(114)))), ((int)(((byte)(168)))));
            this.label42.Location = new System.Drawing.Point(65, 118);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(121, 21);
            this.label42.TabIndex = 82;
            this.label42.Text = "New Password";
            // 
            // txtforgotusername
            // 
            this.txtforgotusername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtforgotusername.Location = new System.Drawing.Point(69, 78);
            this.txtforgotusername.Name = "txtforgotusername";
            this.txtforgotusername.Size = new System.Drawing.Size(232, 26);
            this.txtforgotusername.TabIndex = 1;
            // 
            // txtforgotpassword
            // 
            this.txtforgotpassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtforgotpassword.Location = new System.Drawing.Point(70, 142);
            this.txtforgotpassword.Name = "txtforgotpassword";
            this.txtforgotpassword.PasswordChar = '*';
            this.txtforgotpassword.Size = new System.Drawing.Size(231, 26);
            this.txtforgotpassword.TabIndex = 2;
            // 
            // btnForgotChangePass
            // 
            this.btnForgotChangePass.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(45)))), ((int)(((byte)(101)))));
            this.btnForgotChangePass.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(45)))), ((int)(((byte)(101)))));
            this.btnForgotChangePass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnForgotChangePass.FlatAppearance.BorderSize = 0;
            this.btnForgotChangePass.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(229)))), ((int)(((byte)(237)))));
            this.btnForgotChangePass.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(229)))), ((int)(((byte)(237)))));
            this.btnForgotChangePass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnForgotChangePass.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnForgotChangePass.Location = new System.Drawing.Point(122, 310);
            this.btnForgotChangePass.Name = "btnForgotChangePass";
            this.btnForgotChangePass.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(153)))), ((int)(((byte)(193)))));
            this.btnForgotChangePass.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(153)))), ((int)(((byte)(193)))));
            this.btnForgotChangePass.OnHoverTextColor = System.Drawing.Color.White;
            this.btnForgotChangePass.Size = new System.Drawing.Size(169, 50);
            this.btnForgotChangePass.TabIndex = 85;
            this.btnForgotChangePass.Text = "Change Password";
            this.btnForgotChangePass.TextColor = System.Drawing.Color.White;
            this.btnForgotChangePass.UseVisualStyleBackColor = true;
            this.btnForgotChangePass.Click += new System.EventHandler(this.btnForgotChangePass_Click);
            // 
            // btnForgotClose
            // 
            this.btnForgotClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnForgotClose.BackgroundImage")));
            this.btnForgotClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnForgotClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnForgotClose.Location = new System.Drawing.Point(343, 12);
            this.btnForgotClose.Name = "btnForgotClose";
            this.btnForgotClose.Size = new System.Drawing.Size(40, 37);
            this.btnForgotClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnForgotClose.TabIndex = 86;
            this.btnForgotClose.TabStop = false;
            this.btnForgotClose.Click += new System.EventHandler(this.btnForgotClose_Click);
            // 
            // ForgotPass
            // 
            this.ForgotPass.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ForgotPass.Controls.Add(this.label9);
            this.ForgotPass.Controls.Add(this.txtforgotadminuser);
            this.ForgotPass.Controls.Add(this.label8);
            this.ForgotPass.Controls.Add(this.txtforgotadminpass);
            this.ForgotPass.Controls.Add(this.btnForgotClose);
            this.ForgotPass.Controls.Add(this.btnForgotChangePass);
            this.ForgotPass.Controls.Add(this.txtforgotpassword);
            this.ForgotPass.Controls.Add(this.txtforgotusername);
            this.ForgotPass.Controls.Add(this.label42);
            this.ForgotPass.Controls.Add(this.label39);
            this.ForgotPass.Location = new System.Drawing.Point(336, 163);
            this.ForgotPass.Name = "ForgotPass";
            this.ForgotPass.Size = new System.Drawing.Size(387, 412);
            this.ForgotPass.TabIndex = 82;
            // 
            // txtforgotadminpass
            // 
            this.txtforgotadminpass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtforgotadminpass.Location = new System.Drawing.Point(70, 258);
            this.txtforgotadminpass.Name = "txtforgotadminpass";
            this.txtforgotadminpass.PasswordChar = '*';
            this.txtforgotadminpass.Size = new System.Drawing.Size(231, 26);
            this.txtforgotadminpass.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(114)))), ((int)(((byte)(168)))));
            this.label8.Location = new System.Drawing.Point(68, 234);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(169, 21);
            this.label8.TabIndex = 88;
            this.label8.Text = "Full Admin Password";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(114)))), ((int)(((byte)(168)))));
            this.label9.Location = new System.Drawing.Point(68, 175);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(174, 21);
            this.label9.TabIndex = 90;
            this.label9.Text = "Full Admin Username";
            // 
            // txtforgotadminuser
            // 
            this.txtforgotadminuser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtforgotadminuser.Location = new System.Drawing.Point(69, 199);
            this.txtforgotadminuser.Name = "txtforgotadminuser";
            this.txtforgotadminuser.Size = new System.Drawing.Size(232, 26);
            this.txtforgotadminuser.TabIndex = 3;
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(229)))), ((int)(((byte)(237)))));
            this.ClientSize = new System.Drawing.Size(985, 749);
            this.Controls.Add(this.Panel);
            this.Controls.Add(this.Logout);
            this.Controls.Add(this.ForgotPass);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            this.Logout.ResumeLayout(false);
            this.Logout.PerformLayout();
            this.Panel.ResumeLayout(false);
            this.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnForgotClose)).EndInit();
            this.ForgotPass.ResumeLayout(false);
            this.ForgotPass.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private ePOSOne.btnProduct.Button_WOC btnLogin;
        private System.Windows.Forms.Label lblDateTime;
        private System.Windows.Forms.Panel Logout;
        private ePOSOne.btnProduct.Button_WOC btnCloseYes;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Panel Panel;
        private System.Windows.Forms.PictureBox btnClose;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label6;
        private ePOSOne.btnProduct.Button_WOC btnCloseNo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblForgotPass;
        private System.Windows.Forms.Panel ForgotPass;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtforgotadminuser;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtforgotadminpass;
        private System.Windows.Forms.PictureBox btnForgotClose;
        private ePOSOne.btnProduct.Button_WOC btnForgotChangePass;
        private System.Windows.Forms.TextBox txtforgotpassword;
        private System.Windows.Forms.TextBox txtforgotusername;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label label39;
    }
}