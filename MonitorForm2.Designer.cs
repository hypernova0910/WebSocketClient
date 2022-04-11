
namespace WebSocketClient
{
    partial class MonitorForm2
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.metroTabControl2 = new MetroFramework.Controls.MetroTabControl();
            this.machineBombTab = new MetroFramework.Controls.MetroTabPage();
            this.chart_bomb = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.machineMineTab = new MetroFramework.Controls.MetroTabPage();
            this.chart_mine = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.cbAreaMap = new MetroFramework.Controls.MetroComboBox();
            this.dgvMessage = new System.Windows.Forms.DataGridView();
            this.count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.command = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.machineId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.magnetic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GPS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.corner = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeGPS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.chartTab = new MetroFramework.Controls.MetroTabPage();
            this.tableTab = new MetroFramework.Controls.MetroTabPage();
            this.mapTab = new MetroFramework.Controls.MetroTabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.areaImg = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.metroTabControl2.SuspendLayout();
            this.machineBombTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart_bomb)).BeginInit();
            this.machineMineTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart_mine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMessage)).BeginInit();
            this.metroTabControl1.SuspendLayout();
            this.chartTab.SuspendLayout();
            this.tableTab.SuspendLayout();
            this.mapTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.areaImg)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.ForestGreen;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1171, 66);
            this.panel1.TabIndex = 0;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(225, 28);
            this.label1.TabIndex = 2;
            this.label1.Text = "Giám sát thống kê";
            // 
            // btnExit
            // 
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(1096, 0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 66);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "X";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // metroTabControl2
            // 
            this.metroTabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroTabControl2.Controls.Add(this.machineBombTab);
            this.metroTabControl2.Controls.Add(this.machineMineTab);
            this.metroTabControl2.Location = new System.Drawing.Point(13, 17);
            this.metroTabControl2.Name = "metroTabControl2";
            this.metroTabControl2.SelectedIndex = 0;
            this.metroTabControl2.Size = new System.Drawing.Size(1124, 633);
            this.metroTabControl2.TabIndex = 2;
            this.metroTabControl2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // machineBombTab
            // 
            this.machineBombTab.Controls.Add(this.chart_bomb);
            this.machineBombTab.HorizontalScrollbarBarColor = true;
            this.machineBombTab.Location = new System.Drawing.Point(4, 39);
            this.machineBombTab.Name = "machineBombTab";
            this.machineBombTab.Size = new System.Drawing.Size(1116, 590);
            this.machineBombTab.TabIndex = 0;
            this.machineBombTab.Text = "Dò bom   ";
            this.machineBombTab.VerticalScrollbarBarColor = true;
            // 
            // chart_bomb
            // 
            chartArea1.AxisX.LineWidth = 3;
            chartArea1.AxisX.Maximum = 60D;
            chartArea1.AxisX.Minimum = 0D;
            chartArea1.AxisX.ScaleBreakStyle.Enabled = true;
            chartArea1.AxisX.ScaleBreakStyle.StartFromZero = System.Windows.Forms.DataVisualization.Charting.StartFromZero.Yes;
            chartArea1.AxisX2.Minimum = 0D;
            chartArea1.AxisY.LineWidth = 3;
            chartArea1.Name = "ChartArea1";
            this.chart_bomb.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart_bomb.Legends.Add(legend1);
            this.chart_bomb.Location = new System.Drawing.Point(8, 8);
            this.chart_bomb.Name = "chart_bomb";
            this.chart_bomb.Size = new System.Drawing.Size(1082, 559);
            this.chart_bomb.TabIndex = 2;
            this.chart_bomb.Text = "Gía trị từ trường máy dò bom";
            // 
            // machineMineTab
            // 
            this.machineMineTab.Controls.Add(this.chart_mine);
            this.machineMineTab.HorizontalScrollbarBarColor = true;
            this.machineMineTab.Location = new System.Drawing.Point(4, 39);
            this.machineMineTab.Name = "machineMineTab";
            this.machineMineTab.Size = new System.Drawing.Size(144, 0);
            this.machineMineTab.TabIndex = 1;
            this.machineMineTab.Text = "Dò mìn   ";
            this.machineMineTab.VerticalScrollbarBarColor = true;
            // 
            // chart_mine
            // 
            chartArea2.AxisX.LineWidth = 3;
            chartArea2.AxisX.Maximum = 60D;
            chartArea2.AxisX.Minimum = 0D;
            chartArea2.AxisX.ScaleBreakStyle.Enabled = true;
            chartArea2.AxisX.ScaleBreakStyle.StartFromZero = System.Windows.Forms.DataVisualization.Charting.StartFromZero.Yes;
            chartArea2.AxisX2.Minimum = 0D;
            chartArea2.AxisY.LineWidth = 3;
            chartArea2.Name = "ChartArea1";
            this.chart_mine.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart_mine.Legends.Add(legend2);
            this.chart_mine.Location = new System.Drawing.Point(8, 8);
            this.chart_mine.Name = "chart_mine";
            this.chart_mine.Size = new System.Drawing.Size(1082, 559);
            this.chart_mine.TabIndex = 2;
            this.chart_mine.Text = "Gía trị từ trường máy dò bom";
            // 
            // cbAreaMap
            // 
            this.cbAreaMap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbAreaMap.FormattingEnabled = true;
            this.cbAreaMap.ItemHeight = 24;
            this.cbAreaMap.Location = new System.Drawing.Point(804, 17);
            this.cbAreaMap.Name = "cbAreaMap";
            this.cbAreaMap.Size = new System.Drawing.Size(337, 30);
            this.cbAreaMap.TabIndex = 3;
            this.cbAreaMap.SelectedValueChanged += new System.EventHandler(this.cbAreaMap_SelectedValueChanged);
            // 
            // dgvMessage
            // 
            this.dgvMessage.AllowUserToDeleteRows = false;
            this.dgvMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMessage.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(139)))), ((int)(((byte)(205)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMessage.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMessage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMessage.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.count,
            this.command,
            this.machineId,
            this.time,
            this.magnetic,
            this.GPS,
            this.corner,
            this.timeGPS,
            this.status});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMessage.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvMessage.EnableHeadersVisualStyles = false;
            this.dgvMessage.Location = new System.Drawing.Point(13, 19);
            this.dgvMessage.Name = "dgvMessage";
            this.dgvMessage.ReadOnly = true;
            this.dgvMessage.RowHeadersVisible = false;
            this.dgvMessage.RowHeadersWidth = 51;
            this.dgvMessage.RowTemplate.Height = 24;
            this.dgvMessage.RowTemplate.ReadOnly = true;
            this.dgvMessage.Size = new System.Drawing.Size(1127, 636);
            this.dgvMessage.TabIndex = 2;
            // 
            // count
            // 
            this.count.FillWeight = 50F;
            this.count.HeaderText = "STT";
            this.count.MinimumWidth = 6;
            this.count.Name = "count";
            this.count.ReadOnly = true;
            // 
            // command
            // 
            this.command.FillWeight = 50F;
            this.command.HeaderText = "Lệnh";
            this.command.MinimumWidth = 6;
            this.command.Name = "command";
            this.command.ReadOnly = true;
            // 
            // machineId
            // 
            this.machineId.HeaderText = "SH máy";
            this.machineId.MinimumWidth = 6;
            this.machineId.Name = "machineId";
            this.machineId.ReadOnly = true;
            // 
            // time
            // 
            this.time.FillWeight = 120F;
            this.time.HeaderText = "Thời gian";
            this.time.MinimumWidth = 6;
            this.time.Name = "time";
            this.time.ReadOnly = true;
            // 
            // magnetic
            // 
            this.magnetic.HeaderText = "Gía trị từ trường";
            this.magnetic.MinimumWidth = 6;
            this.magnetic.Name = "magnetic";
            this.magnetic.ReadOnly = true;
            // 
            // GPS
            // 
            this.GPS.FillWeight = 150F;
            this.GPS.HeaderText = "GPS";
            this.GPS.MinimumWidth = 6;
            this.GPS.Name = "GPS";
            this.GPS.ReadOnly = true;
            // 
            // corner
            // 
            this.corner.FillWeight = 50F;
            this.corner.HeaderText = "Góc";
            this.corner.MinimumWidth = 6;
            this.corner.Name = "corner";
            this.corner.ReadOnly = true;
            // 
            // timeGPS
            // 
            this.timeGPS.FillWeight = 120F;
            this.timeGPS.HeaderText = "Thời gian sửa";
            this.timeGPS.MinimumWidth = 6;
            this.timeGPS.Name = "timeGPS";
            this.timeGPS.ReadOnly = true;
            // 
            // status
            // 
            this.status.HeaderText = "Trạng thái";
            this.status.MinimumWidth = 6;
            this.status.Name = "status";
            this.status.ReadOnly = true;
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Controls.Add(this.chartTab);
            this.metroTabControl1.Controls.Add(this.tableTab);
            this.metroTabControl1.Controls.Add(this.mapTab);
            this.metroTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroTabControl1.Location = new System.Drawing.Point(0, 66);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 0;
            this.metroTabControl1.Size = new System.Drawing.Size(1171, 714);
            this.metroTabControl1.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTabControl1.TabIndex = 1;
            this.metroTabControl1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTabControl1.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // chartTab
            // 
            this.chartTab.Controls.Add(this.metroTabControl2);
            this.chartTab.HorizontalScrollbarBarColor = true;
            this.chartTab.Location = new System.Drawing.Point(4, 39);
            this.chartTab.Name = "chartTab";
            this.chartTab.Size = new System.Drawing.Size(1163, 671);
            this.chartTab.TabIndex = 0;
            this.chartTab.Text = "Biểu đồ   ";
            this.chartTab.VerticalScrollbarBarColor = true;
            // 
            // tableTab
            // 
            this.tableTab.Controls.Add(this.dgvMessage);
            this.tableTab.HorizontalScrollbarBarColor = true;
            this.tableTab.Location = new System.Drawing.Point(4, 39);
            this.tableTab.Name = "tableTab";
            this.tableTab.Size = new System.Drawing.Size(1163, 671);
            this.tableTab.TabIndex = 2;
            this.tableTab.Text = "Bảng   ";
            this.tableTab.VerticalScrollbarBarColor = true;
            // 
            // mapTab
            // 
            this.mapTab.Controls.Add(this.label2);
            this.mapTab.Controls.Add(this.areaImg);
            this.mapTab.Controls.Add(this.cbAreaMap);
            this.mapTab.HorizontalScrollbarBarColor = true;
            this.mapTab.Location = new System.Drawing.Point(4, 39);
            this.mapTab.Name = "mapTab";
            this.mapTab.Size = new System.Drawing.Size(1163, 671);
            this.mapTab.TabIndex = 1;
            this.mapTab.Text = "Bản đồ   ";
            this.mapTab.VerticalScrollbarBarColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(647, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Vùng dự án";
            // 
            // areaImg
            // 
            this.areaImg.ImageLocation = "";
            this.areaImg.Location = new System.Drawing.Point(22, 81);
            this.areaImg.Name = "areaImg";
            this.areaImg.Size = new System.Drawing.Size(1119, 567);
            this.areaImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.areaImg.TabIndex = 2;
            this.areaImg.TabStop = false;
            this.areaImg.Paint += new System.Windows.Forms.PaintEventHandler(this.areaImg_Paint);
            // 
            // MonitorForm2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1171, 780);
            this.Controls.Add(this.metroTabControl1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MonitorForm2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MonitorForm2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MonitorForm2_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.metroTabControl2.ResumeLayout(false);
            this.machineBombTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart_bomb)).EndInit();
            this.machineMineTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart_mine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMessage)).EndInit();
            this.metroTabControl1.ResumeLayout(false);
            this.chartTab.ResumeLayout(false);
            this.tableTab.ResumeLayout(false);
            this.mapTab.ResumeLayout(false);
            this.mapTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.areaImg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnExit;
        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private System.Windows.Forms.Label label1;
        private MetroFramework.Controls.MetroTabPage chartTab;
        private MetroFramework.Controls.MetroTabPage mapTab;
        private MetroFramework.Controls.MetroTabPage tableTab;
        private MetroFramework.Controls.MetroTabControl metroTabControl2;
        private MetroFramework.Controls.MetroTabPage machineBombTab;
        private MetroFramework.Controls.MetroTabPage machineMineTab;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_bomb;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_mine;
        private MetroFramework.Controls.MetroComboBox cbAreaMap;
        private System.Windows.Forms.PictureBox areaImg;
        private System.Windows.Forms.DataGridView dgvMessage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn count;
        private System.Windows.Forms.DataGridViewTextBoxColumn command;
        private System.Windows.Forms.DataGridViewTextBoxColumn machineId;
        private System.Windows.Forms.DataGridViewTextBoxColumn time;
        private System.Windows.Forms.DataGridViewTextBoxColumn magnetic;
        private System.Windows.Forms.DataGridViewTextBoxColumn GPS;
        private System.Windows.Forms.DataGridViewTextBoxColumn corner;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeGPS;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
    }
}