
namespace WebSocketClient
{
    partial class MainHome
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnLogIn = new System.Windows.Forms.Button();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.btnDetail = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.pnlPrograms = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlProgramDetail = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label_CecmId_Hide = new System.Windows.Forms.Label();
            this.label_ProgramStatus = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label_ConfigStatus = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label_ConfigIP = new System.Windows.Forms.Label();
            this.label_ConfigTime = new System.Windows.Forms.Label();
            this.label_ConfigName = new System.Windows.Forms.Label();
            this.label_ConfigSpeed = new System.Windows.Forms.Label();
            this.label_DeptName = new System.Windows.Forms.Label();
            this.label_ProgramTime = new System.Windows.Forms.Label();
            this.label_ProgramCode = new System.Windows.Forms.Label();
            this.lbl_ProgramName = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.tbMQTT = new System.Windows.Forms.TextBox();
            this.lblDeptId = new System.Windows.Forms.Label();
            this.flowLayoutPanel1.SuspendLayout();
            this.pnlPrograms.SuspendLayout();
            this.pnlProgramDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnLogIn);
            this.flowLayoutPanel1.Controls.Add(this.btnLogOut);
            this.flowLayoutPanel1.Controls.Add(this.btnConnect);
            this.flowLayoutPanel1.Controls.Add(this.btnDisconnect);
            this.flowLayoutPanel1.Controls.Add(this.btnDetail);
            this.flowLayoutPanel1.Controls.Add(this.btnExit);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1151, 126);
            this.flowLayoutPanel1.TabIndex = 4;
            this.flowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // btnLogIn
            // 
            this.btnLogIn.BackColor = System.Drawing.Color.Transparent;
            this.btnLogIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogIn.Image = global::WebSocketClient.Properties.Resources.login_icon;
            this.btnLogIn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnLogIn.Location = new System.Drawing.Point(3, 3);
            this.btnLogIn.Name = "btnLogIn";
            this.btnLogIn.Size = new System.Drawing.Size(185, 120);
            this.btnLogIn.TabIndex = 2;
            this.btnLogIn.Text = "Đăng nhập";
            this.btnLogIn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLogIn.UseVisualStyleBackColor = false;
            this.btnLogIn.EnabledChanged += new System.EventHandler(this.btnLogIn_EnabledChanged);
            this.btnLogIn.Click += new System.EventHandler(this.btnLogIn_Click);
            // 
            // btnLogOut
            // 
            this.btnLogOut.BackColor = System.Drawing.Color.Transparent;
            this.btnLogOut.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLogOut.Image = global::WebSocketClient.Properties.Resources.log_out_icon;
            this.btnLogOut.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnLogOut.Location = new System.Drawing.Point(194, 3);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(189, 121);
            this.btnLogOut.TabIndex = 3;
            this.btnLogOut.Text = "Đăng xuất";
            this.btnLogOut.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLogOut.UseVisualStyleBackColor = false;
            this.btnLogOut.EnabledChanged += new System.EventHandler(this.btnLogIn_EnabledChanged);
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.BackColor = System.Drawing.Color.Transparent;
            this.btnConnect.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnConnect.Image = global::WebSocketClient.Properties.Resources.connect_margin_icon;
            this.btnConnect.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnConnect.Location = new System.Drawing.Point(389, 3);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(185, 121);
            this.btnConnect.TabIndex = 6;
            this.btnConnect.Text = "Kết nối";
            this.btnConnect.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnConnect.UseVisualStyleBackColor = false;
            this.btnConnect.EnabledChanged += new System.EventHandler(this.btnLogIn_EnabledChanged);
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.BackColor = System.Drawing.Color.Transparent;
            this.btnDisconnect.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDisconnect.Image = global::WebSocketClient.Properties.Resources.disconnect_margin_icon;
            this.btnDisconnect.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDisconnect.Location = new System.Drawing.Point(580, 3);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(185, 121);
            this.btnDisconnect.TabIndex = 5;
            this.btnDisconnect.Text = "Ngắt kết nối";
            this.btnDisconnect.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDisconnect.UseVisualStyleBackColor = false;
            this.btnDisconnect.EnabledChanged += new System.EventHandler(this.btnLogIn_EnabledChanged);
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // btnDetail
            // 
            this.btnDetail.BackColor = System.Drawing.Color.Transparent;
            this.btnDetail.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDetail.Image = global::WebSocketClient.Properties.Resources.icons8_info_80;
            this.btnDetail.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDetail.Location = new System.Drawing.Point(771, 3);
            this.btnDetail.Name = "btnDetail";
            this.btnDetail.Size = new System.Drawing.Size(185, 121);
            this.btnDetail.TabIndex = 5;
            this.btnDetail.Text = "Chi tiết";
            this.btnDetail.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDetail.UseVisualStyleBackColor = false;
            this.btnDetail.EnabledChanged += new System.EventHandler(this.btnLogIn_EnabledChanged);
            this.btnDetail.Click += new System.EventHandler(this.btnDetail_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExit.Image = global::WebSocketClient.Properties.Resources.exit_icon;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnExit.Location = new System.Drawing.Point(962, 3);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(185, 121);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Thoát";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.EnabledChanged += new System.EventHandler(this.btnLogIn_EnabledChanged);
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // pnlPrograms
            // 
            this.pnlPrograms.AutoScroll = true;
            this.pnlPrograms.BackColor = System.Drawing.Color.Transparent;
            this.pnlPrograms.Controls.Add(this.label1);
            this.pnlPrograms.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnlPrograms.Location = new System.Drawing.Point(0, 126);
            this.pnlPrograms.Name = "pnlPrograms";
            this.pnlPrograms.Size = new System.Drawing.Size(352, 603);
            this.pnlPrograms.TabIndex = 5;
            this.pnlPrograms.WrapContents = false;
            this.pnlPrograms.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlPrograms_Paint);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(329, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "Danh sách các dự án đang hoạt động";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlProgramDetail
            // 
            this.pnlProgramDetail.Controls.Add(this.lblDeptId);
            this.pnlProgramDetail.Controls.Add(this.label2);
            this.pnlProgramDetail.Controls.Add(this.label_CecmId_Hide);
            this.pnlProgramDetail.Controls.Add(this.label_ProgramStatus);
            this.pnlProgramDetail.Controls.Add(this.label8);
            this.pnlProgramDetail.Controls.Add(this.label_ConfigStatus);
            this.pnlProgramDetail.Controls.Add(this.label7);
            this.pnlProgramDetail.Controls.Add(this.label_ConfigIP);
            this.pnlProgramDetail.Controls.Add(this.label_ConfigTime);
            this.pnlProgramDetail.Controls.Add(this.label_ConfigName);
            this.pnlProgramDetail.Controls.Add(this.label_ConfigSpeed);
            this.pnlProgramDetail.Controls.Add(this.label_DeptName);
            this.pnlProgramDetail.Controls.Add(this.label_ProgramTime);
            this.pnlProgramDetail.Controls.Add(this.label_ProgramCode);
            this.pnlProgramDetail.Controls.Add(this.lbl_ProgramName);
            this.pnlProgramDetail.Controls.Add(this.label12);
            this.pnlProgramDetail.Controls.Add(this.label11);
            this.pnlProgramDetail.Controls.Add(this.label10);
            this.pnlProgramDetail.Controls.Add(this.label9);
            this.pnlProgramDetail.Controls.Add(this.label6);
            this.pnlProgramDetail.Controls.Add(this.label5);
            this.pnlProgramDetail.Controls.Add(this.label4);
            this.pnlProgramDetail.Controls.Add(this.label3);
            this.pnlProgramDetail.Location = new System.Drawing.Point(352, 126);
            this.pnlProgramDetail.Name = "pnlProgramDetail";
            this.pnlProgramDetail.Size = new System.Drawing.Size(799, 673);
            this.pnlProgramDetail.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(266, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(248, 29);
            this.label2.TabIndex = 23;
            this.label2.Text = "THÔNG TIN DỰ ÁN";
            // 
            // label_CecmId_Hide
            // 
            this.label_CecmId_Hide.AutoSize = true;
            this.label_CecmId_Hide.Location = new System.Drawing.Point(42, 574);
            this.label_CecmId_Hide.Name = "label_CecmId_Hide";
            this.label_CecmId_Hide.Size = new System.Drawing.Size(0, 17);
            this.label_CecmId_Hide.TabIndex = 22;
            this.label_CecmId_Hide.Visible = false;
            // 
            // label_ProgramStatus
            // 
            this.label_ProgramStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ProgramStatus.Location = new System.Drawing.Point(212, 259);
            this.label_ProgramStatus.Name = "label_ProgramStatus";
            this.label_ProgramStatus.Size = new System.Drawing.Size(557, 25);
            this.label_ProgramStatus.TabIndex = 21;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(37, 315);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(138, 25);
            this.label8.TabIndex = 6;
            this.label8.Text = "Tên cấu hình";
            // 
            // label_ConfigStatus
            // 
            this.label_ConfigStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ConfigStatus.Location = new System.Drawing.Point(212, 526);
            this.label_ConfigStatus.Name = "label_ConfigStatus";
            this.label_ConfigStatus.Size = new System.Drawing.Size(557, 25);
            this.label_ConfigStatus.TabIndex = 20;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(37, 370);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(166, 25);
            this.label7.TabIndex = 5;
            this.label7.Text = "Thời gian (phút)";
            // 
            // label_ConfigIP
            // 
            this.label_ConfigIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ConfigIP.Location = new System.Drawing.Point(212, 473);
            this.label_ConfigIP.Name = "label_ConfigIP";
            this.label_ConfigIP.Size = new System.Drawing.Size(557, 25);
            this.label_ConfigIP.TabIndex = 18;
            // 
            // label_ConfigTime
            // 
            this.label_ConfigTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ConfigTime.Location = new System.Drawing.Point(212, 370);
            this.label_ConfigTime.Name = "label_ConfigTime";
            this.label_ConfigTime.Size = new System.Drawing.Size(557, 25);
            this.label_ConfigTime.TabIndex = 17;
            // 
            // label_ConfigName
            // 
            this.label_ConfigName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ConfigName.Location = new System.Drawing.Point(212, 315);
            this.label_ConfigName.Name = "label_ConfigName";
            this.label_ConfigName.Size = new System.Drawing.Size(557, 25);
            this.label_ConfigName.TabIndex = 16;
            // 
            // label_ConfigSpeed
            // 
            this.label_ConfigSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ConfigSpeed.Location = new System.Drawing.Point(212, 424);
            this.label_ConfigSpeed.Name = "label_ConfigSpeed";
            this.label_ConfigSpeed.Size = new System.Drawing.Size(557, 25);
            this.label_ConfigSpeed.TabIndex = 15;
            // 
            // label_DeptName
            // 
            this.label_DeptName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_DeptName.Location = new System.Drawing.Point(212, 151);
            this.label_DeptName.Name = "label_DeptName";
            this.label_DeptName.Size = new System.Drawing.Size(557, 25);
            this.label_DeptName.TabIndex = 14;
            // 
            // label_ProgramTime
            // 
            this.label_ProgramTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ProgramTime.Location = new System.Drawing.Point(212, 206);
            this.label_ProgramTime.Name = "label_ProgramTime";
            this.label_ProgramTime.Size = new System.Drawing.Size(557, 25);
            this.label_ProgramTime.TabIndex = 13;
            // 
            // label_ProgramCode
            // 
            this.label_ProgramCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ProgramCode.Location = new System.Drawing.Point(212, 104);
            this.label_ProgramCode.Name = "label_ProgramCode";
            this.label_ProgramCode.Size = new System.Drawing.Size(557, 25);
            this.label_ProgramCode.TabIndex = 12;
            // 
            // lbl_ProgramName
            // 
            this.lbl_ProgramName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ProgramName.Location = new System.Drawing.Point(212, 56);
            this.lbl_ProgramName.Name = "lbl_ProgramName";
            this.lbl_ProgramName.Size = new System.Drawing.Size(557, 25);
            this.lbl_ProgramName.TabIndex = 11;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(37, 104);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(102, 25);
            this.label12.TabIndex = 10;
            this.label12.Text = "Mã dự án";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(37, 151);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(73, 25);
            this.label11.TabIndex = 9;
            this.label11.Text = "Đơn vị";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(37, 206);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(102, 25);
            this.label10.TabIndex = 8;
            this.label10.Text = "Thời gian";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(37, 259);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(110, 25);
            this.label9.TabIndex = 7;
            this.label9.Text = "Trạng thái";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(37, 424);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 25);
            this.label6.TabIndex = 4;
            this.label6.Text = "Tốc độ (s)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(37, 473);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 25);
            this.label5.TabIndex = 3;
            this.label5.Text = "Kiểm tra IP";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(37, 526);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 25);
            this.label4.TabIndex = 2;
            this.label4.Text = "Trạng thái";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(37, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 25);
            this.label3.TabIndex = 1;
            this.label3.Text = "Tên dự án";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(26, 753);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(64, 17);
            this.label13.TabIndex = 7;
            this.label13.Text = "MQTT IP";
            // 
            // tbMQTT
            // 
            this.tbMQTT.Location = new System.Drawing.Point(115, 750);
            this.tbMQTT.Name = "tbMQTT";
            this.tbMQTT.Size = new System.Drawing.Size(198, 22);
            this.tbMQTT.TabIndex = 8;
            this.tbMQTT.Text = "localhost";
            // 
            // lblDeptId
            // 
            this.lblDeptId.AutoSize = true;
            this.lblDeptId.Location = new System.Drawing.Point(600, 15);
            this.lblDeptId.Name = "lblDeptId";
            this.lblDeptId.Size = new System.Drawing.Size(0, 17);
            this.lblDeptId.TabIndex = 24;
            this.lblDeptId.Visible = false;
            // 
            // MainHome
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1151, 797);
            this.Controls.Add(this.tbMQTT);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.pnlProgramDetail);
            this.Controls.Add(this.pnlPrograms);
            this.Controls.Add(this.flowLayoutPanel1);
            this.MaximizeBox = false;
            this.Name = "MainHome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phần mềm kết nối dự án";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainHome_FormClosing);
            this.Load += new System.EventHandler(this.HieuHome_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.pnlPrograms.ResumeLayout(false);
            this.pnlProgramDetail.ResumeLayout(false);
            this.pnlProgramDetail.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnLogIn;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Button btnDetail;
        private System.Windows.Forms.FlowLayoutPanel pnlPrograms;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlProgramDetail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbl_ProgramName;
        private System.Windows.Forms.Label label_ProgramStatus;
        private System.Windows.Forms.Label label_ConfigStatus;
        private System.Windows.Forms.Label label_ConfigIP;
        private System.Windows.Forms.Label label_ConfigTime;
        private System.Windows.Forms.Label label_ConfigName;
        private System.Windows.Forms.Label label_ConfigSpeed;
        private System.Windows.Forms.Label label_DeptName;
        private System.Windows.Forms.Label label_ProgramTime;
        private System.Windows.Forms.Label label_ProgramCode;
        private System.Windows.Forms.Label label_CecmId_Hide;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tbMQTT;
        private System.Windows.Forms.Label lblDeptId;
    }
}