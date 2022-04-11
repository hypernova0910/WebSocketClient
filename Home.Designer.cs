namespace WebSocketClient
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.labelLstProgram = new System.Windows.Forms.Label();
            this.labelInfoProgram = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.flowLayoutPanelLstProgram = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label_ProgramStatus = new System.Windows.Forms.Label();
            this.label_ProgramTime = new System.Windows.Forms.Label();
            this.label_DeptName = new System.Windows.Forms.Label();
            this.label_ProgramCode = new System.Windows.Forms.Label();
            this.lbl_ProgramName = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label_ConfigStatus = new System.Windows.Forms.Label();
            this.label_ConfigIP = new System.Windows.Forms.Label();
            this.label_ConfigSpeed = new System.Windows.Forms.Label();
            this.label_ConfigTime = new System.Windows.Forms.Label();
            this.label_ConfigName = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label_CecmId_Hide = new System.Windows.Forms.Label();
            this.cecmProgramDTOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cecmProgramDTOBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cecmProgramDTOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cecmProgramDTOBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.SkyBlue;
            this.label1.Font = new System.Drawing.Font("Cambria", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1033, 52);
            this.label1.TabIndex = 0;
            this.label1.Text = "PHẦN MỀM KẾT NỐI DỮ LIỆU CÔNG TRƯỜNG";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.Image = ((System.Drawing.Image)(resources.GetObject("btnLogout.Image")));
            this.btnLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.Location = new System.Drawing.Point(1027, 0);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(4);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(172, 52);
            this.btnLogout.TabIndex = 1;
            this.btnLogout.Text = "Đăng xuất";
            this.btnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // labelLstProgram
            // 
            this.labelLstProgram.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelLstProgram.BackColor = System.Drawing.Color.White;
            this.labelLstProgram.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelLstProgram.Font = new System.Drawing.Font("Century", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLstProgram.ForeColor = System.Drawing.Color.DodgerBlue;
            this.labelLstProgram.Location = new System.Drawing.Point(-1, 53);
            this.labelLstProgram.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelLstProgram.Name = "labelLstProgram";
            this.labelLstProgram.Size = new System.Drawing.Size(387, 51);
            this.labelLstProgram.TabIndex = 2;
            this.labelLstProgram.Text = "Danh sách dự án";
            this.labelLstProgram.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelInfoProgram
            // 
            this.labelInfoProgram.BackColor = System.Drawing.Color.White;
            this.labelInfoProgram.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelInfoProgram.Font = new System.Drawing.Font("Century", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInfoProgram.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.labelInfoProgram.Location = new System.Drawing.Point(385, 53);
            this.labelInfoProgram.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelInfoProgram.Name = "labelInfoProgram";
            this.labelInfoProgram.Size = new System.Drawing.Size(813, 51);
            this.labelInfoProgram.TabIndex = 3;
            this.labelInfoProgram.Text = "Thông tin dự án ";
            this.labelInfoProgram.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnConnect
            // 
            this.btnConnect.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnect.ForeColor = System.Drawing.Color.White;
            this.btnConnect.Location = new System.Drawing.Point(661, 571);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(4);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(113, 43);
            this.btnConnect.TabIndex = 6;
            this.btnConnect.Text = "Kết nối";
            this.btnConnect.UseVisualStyleBackColor = false;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Red;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(807, 571);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(113, 43);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Hủy";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // flowLayoutPanelLstProgram
            // 
            this.flowLayoutPanelLstProgram.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanelLstProgram.Location = new System.Drawing.Point(-1, 105);
            this.flowLayoutPanelLstProgram.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanelLstProgram.Name = "flowLayoutPanelLstProgram";
            this.flowLayoutPanelLstProgram.Size = new System.Drawing.Size(387, 514);
            this.flowLayoutPanelLstProgram.TabIndex = 9;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label_ProgramStatus);
            this.groupBox1.Controls.Add(this.label_ProgramTime);
            this.groupBox1.Controls.Add(this.label_DeptName);
            this.groupBox1.Controls.Add(this.label_ProgramCode);
            this.groupBox1.Controls.Add(this.lbl_ProgramName);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.groupBox1.Location = new System.Drawing.Point(395, 112);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(789, 226);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin chung";
            // 
            // label_ProgramStatus
            // 
            this.label_ProgramStatus.Font = new System.Drawing.Font("Microsoft New Tai Lue", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ProgramStatus.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label_ProgramStatus.Location = new System.Drawing.Point(135, 177);
            this.label_ProgramStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_ProgramStatus.Name = "label_ProgramStatus";
            this.label_ProgramStatus.Size = new System.Drawing.Size(647, 37);
            this.label_ProgramStatus.TabIndex = 9;
            // 
            // label_ProgramTime
            // 
            this.label_ProgramTime.Font = new System.Drawing.Font("Microsoft New Tai Lue", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ProgramTime.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label_ProgramTime.Location = new System.Drawing.Point(127, 140);
            this.label_ProgramTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_ProgramTime.Name = "label_ProgramTime";
            this.label_ProgramTime.Size = new System.Drawing.Size(655, 37);
            this.label_ProgramTime.TabIndex = 8;
            // 
            // label_DeptName
            // 
            this.label_DeptName.Font = new System.Drawing.Font("Microsoft New Tai Lue", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_DeptName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label_DeptName.Location = new System.Drawing.Point(127, 103);
            this.label_DeptName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_DeptName.Name = "label_DeptName";
            this.label_DeptName.Size = new System.Drawing.Size(655, 32);
            this.label_DeptName.TabIndex = 7;
            // 
            // label_ProgramCode
            // 
            this.label_ProgramCode.Font = new System.Drawing.Font("Microsoft New Tai Lue", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ProgramCode.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label_ProgramCode.Location = new System.Drawing.Point(127, 66);
            this.label_ProgramCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_ProgramCode.Name = "label_ProgramCode";
            this.label_ProgramCode.Size = new System.Drawing.Size(655, 37);
            this.label_ProgramCode.TabIndex = 6;
            // 
            // lbl_ProgramName
            // 
            this.lbl_ProgramName.Font = new System.Drawing.Font("Microsoft New Tai Lue", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ProgramName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl_ProgramName.Location = new System.Drawing.Point(127, 26);
            this.lbl_ProgramName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_ProgramName.Name = "lbl_ProgramName";
            this.lbl_ProgramName.Size = new System.Drawing.Size(655, 41);
            this.lbl_ProgramName.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(32, 181);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 20);
            this.label6.TabIndex = 4;
            this.label6.Text = "Trạng thái: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(32, 145);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 20);
            this.label5.TabIndex = 3;
            this.label5.Text = "Thời gian: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(35, 108);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Đơn vị: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(35, 73);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Mã dự án: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(32, 34);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tên dự án: ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label_ConfigStatus);
            this.groupBox2.Controls.Add(this.label_ConfigIP);
            this.groupBox2.Controls.Add(this.label_ConfigSpeed);
            this.groupBox2.Controls.Add(this.label_ConfigTime);
            this.groupBox2.Controls.Add(this.label_ConfigName);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.groupBox2.Location = new System.Drawing.Point(395, 346);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(789, 222);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin cấu hình";
            // 
            // label_ConfigStatus
            // 
            this.label_ConfigStatus.Font = new System.Drawing.Font("Microsoft New Tai Lue", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ConfigStatus.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label_ConfigStatus.Location = new System.Drawing.Point(127, 175);
            this.label_ConfigStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_ConfigStatus.Name = "label_ConfigStatus";
            this.label_ConfigStatus.Size = new System.Drawing.Size(627, 34);
            this.label_ConfigStatus.TabIndex = 14;
            // 
            // label_ConfigIP
            // 
            this.label_ConfigIP.Font = new System.Drawing.Font("Microsoft New Tai Lue", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ConfigIP.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label_ConfigIP.Location = new System.Drawing.Point(135, 143);
            this.label_ConfigIP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_ConfigIP.Name = "label_ConfigIP";
            this.label_ConfigIP.Size = new System.Drawing.Size(627, 34);
            this.label_ConfigIP.TabIndex = 13;
            // 
            // label_ConfigSpeed
            // 
            this.label_ConfigSpeed.Font = new System.Drawing.Font("Microsoft New Tai Lue", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ConfigSpeed.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label_ConfigSpeed.Location = new System.Drawing.Point(127, 106);
            this.label_ConfigSpeed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_ConfigSpeed.Name = "label_ConfigSpeed";
            this.label_ConfigSpeed.Size = new System.Drawing.Size(655, 34);
            this.label_ConfigSpeed.TabIndex = 12;
            // 
            // label_ConfigTime
            // 
            this.label_ConfigTime.Font = new System.Drawing.Font("Microsoft New Tai Lue", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ConfigTime.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label_ConfigTime.Location = new System.Drawing.Point(167, 71);
            this.label_ConfigTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_ConfigTime.Name = "label_ConfigTime";
            this.label_ConfigTime.Size = new System.Drawing.Size(621, 34);
            this.label_ConfigTime.TabIndex = 11;
            // 
            // label_ConfigName
            // 
            this.label_ConfigName.Font = new System.Drawing.Font("Microsoft New Tai Lue", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ConfigName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label_ConfigName.Location = new System.Drawing.Point(161, 31);
            this.label_ConfigName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_ConfigName.Name = "label_ConfigName";
            this.label_ConfigName.Size = new System.Drawing.Size(627, 34);
            this.label_ConfigName.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(33, 181);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 20);
            this.label7.TabIndex = 9;
            this.label7.Text = "Trạng thái: ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(35, 146);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(102, 20);
            this.label8.TabIndex = 8;
            this.label8.Text = "Kiểm tra IP: ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(33, 110);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(96, 20);
            this.label9.TabIndex = 7;
            this.label9.Text = "Tốc độ (s): ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label10.Location = new System.Drawing.Point(32, 73);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(136, 20);
            this.label10.TabIndex = 6;
            this.label10.Text = "Thời gian (phút): ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label11.Location = new System.Drawing.Point(33, 36);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(115, 20);
            this.label11.TabIndex = 5;
            this.label11.Text = "Tên cấu hình: ";
            // 
            // label_CecmId_Hide
            // 
            this.label_CecmId_Hide.Font = new System.Drawing.Font("Microsoft New Tai Lue", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_CecmId_Hide.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label_CecmId_Hide.Location = new System.Drawing.Point(1007, 64);
            this.label_CecmId_Hide.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_CecmId_Hide.Name = "label_CecmId_Hide";
            this.label_CecmId_Hide.Size = new System.Drawing.Size(101, 25);
            this.label_CecmId_Hide.TabIndex = 10;
            this.label_CecmId_Hide.Visible = false;
            // 
            // cecmProgramDTOBindingSource
            // 
            this.cecmProgramDTOBindingSource.DataSource = typeof(WebSocketClient.CecmProgramDTO);
            // 
            // cecmProgramDTOBindingSource1
            // 
            this.cecmProgramDTOBindingSource1.DataSource = typeof(WebSocketClient.CecmProgramDTO);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1200, 618);
            this.Controls.Add(this.label_CecmId_Hide);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.flowLayoutPanelLstProgram);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.labelInfoProgram);
            this.Controls.Add(this.labelLstProgram);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home";
            this.Load += new System.EventHandler(this.Home_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cecmProgramDTOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cecmProgramDTOBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label labelLstProgram;
        private System.Windows.Forms.Label labelInfoProgram;
        private System.Windows.Forms.BindingSource cecmProgramDTOBindingSource1;
        private System.Windows.Forms.BindingSource cecmProgramDTOBindingSource;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelLstProgram;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label_ProgramStatus;
        private System.Windows.Forms.Label label_ProgramTime;
        private System.Windows.Forms.Label label_DeptName;
        private System.Windows.Forms.Label label_ProgramCode;
        private System.Windows.Forms.Label lbl_ProgramName;
        private System.Windows.Forms.Label label_ConfigStatus;
        private System.Windows.Forms.Label label_ConfigIP;
        private System.Windows.Forms.Label label_ConfigSpeed;
        private System.Windows.Forms.Label label_ConfigTime;
        private System.Windows.Forms.Label label_ConfigName;
        private System.Windows.Forms.Label label_CecmId_Hide;
    }
}