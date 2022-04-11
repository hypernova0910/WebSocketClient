
namespace WebSocketClient
{
    partial class MonitorForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.chartTab = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.machineBombTab = new System.Windows.Forms.TabPage();
            this.chart_bomb = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.machineMineTab = new System.Windows.Forms.TabPage();
            this.chart_mine = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.mapTab = new System.Windows.Forms.TabPage();
            this.areaImg = new System.Windows.Forms.PictureBox();
            this.cbAreaMap = new System.Windows.Forms.ComboBox();
            this.tableTab = new System.Windows.Forms.TabPage();
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
            this.tabControl1.SuspendLayout();
            this.chartTab.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.machineBombTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart_bomb)).BeginInit();
            this.machineMineTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart_mine)).BeginInit();
            this.mapTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.areaImg)).BeginInit();
            this.tableTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMessage)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.chartTab);
            this.tabControl1.Controls.Add(this.mapTab);
            this.tabControl1.Controls.Add(this.tableTab);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(15, 3);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1188, 713);
            this.tabControl1.TabIndex = 0;
            // 
            // chartTab
            // 
            this.chartTab.Controls.Add(this.tabControl2);
            this.chartTab.Location = new System.Drawing.Point(4, 34);
            this.chartTab.Name = "chartTab";
            this.chartTab.Padding = new System.Windows.Forms.Padding(3);
            this.chartTab.Size = new System.Drawing.Size(1180, 675);
            this.chartTab.TabIndex = 0;
            this.chartTab.Text = "Biểu đồ";
            this.chartTab.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.machineBombTab);
            this.tabControl2.Controls.Add(this.machineMineTab);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(3, 3);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(1174, 669);
            this.tabControl2.TabIndex = 0;
            // 
            // machineBombTab
            // 
            this.machineBombTab.Controls.Add(this.chart_bomb);
            this.machineBombTab.Location = new System.Drawing.Point(4, 34);
            this.machineBombTab.Name = "machineBombTab";
            this.machineBombTab.Padding = new System.Windows.Forms.Padding(3);
            this.machineBombTab.Size = new System.Drawing.Size(1166, 631);
            this.machineBombTab.TabIndex = 0;
            this.machineBombTab.Text = "Dò bom (0)";
            this.machineBombTab.UseVisualStyleBackColor = true;
            // 
            // chart_bomb
            // 
            chartArea1.AxisX.Minimum = 0D;
            chartArea1.AxisX.ScaleBreakStyle.Enabled = true;
            chartArea1.AxisX.ScaleBreakStyle.StartFromZero = System.Windows.Forms.DataVisualization.Charting.StartFromZero.Yes;
            chartArea1.AxisX2.Minimum = 0D;
            chartArea1.Name = "ChartArea1";
            this.chart_bomb.ChartAreas.Add(chartArea1);
            this.chart_bomb.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chart_bomb.Legends.Add(legend1);
            this.chart_bomb.Location = new System.Drawing.Point(3, 3);
            this.chart_bomb.Name = "chart_bomb";
            this.chart_bomb.Size = new System.Drawing.Size(1160, 625);
            this.chart_bomb.TabIndex = 0;
            this.chart_bomb.Text = "Gía trị từ trường máy dò bom";
            // 
            // machineMineTab
            // 
            this.machineMineTab.Controls.Add(this.chart_mine);
            this.machineMineTab.Location = new System.Drawing.Point(4, 34);
            this.machineMineTab.Name = "machineMineTab";
            this.machineMineTab.Padding = new System.Windows.Forms.Padding(3);
            this.machineMineTab.Size = new System.Drawing.Size(1166, 631);
            this.machineMineTab.TabIndex = 1;
            this.machineMineTab.Text = "Dò mìn (0)";
            this.machineMineTab.UseVisualStyleBackColor = true;
            // 
            // chart_mine
            // 
            chartArea2.AxisX.ScaleBreakStyle.Enabled = true;
            chartArea2.AxisX.ScaleBreakStyle.StartFromZero = System.Windows.Forms.DataVisualization.Charting.StartFromZero.Yes;
            chartArea2.Name = "ChartArea1";
            this.chart_mine.ChartAreas.Add(chartArea2);
            this.chart_mine.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this.chart_mine.Legends.Add(legend2);
            this.chart_mine.Location = new System.Drawing.Point(3, 3);
            this.chart_mine.Name = "chart_mine";
            this.chart_mine.Size = new System.Drawing.Size(1160, 625);
            this.chart_mine.TabIndex = 1;
            this.chart_mine.Text = "Gía trị từ trường máy dò mìn";
            // 
            // mapTab
            // 
            this.mapTab.Controls.Add(this.areaImg);
            this.mapTab.Controls.Add(this.cbAreaMap);
            this.mapTab.Location = new System.Drawing.Point(4, 34);
            this.mapTab.Name = "mapTab";
            this.mapTab.Padding = new System.Windows.Forms.Padding(3);
            this.mapTab.Size = new System.Drawing.Size(1180, 672);
            this.mapTab.TabIndex = 1;
            this.mapTab.Text = "Bản đồ";
            this.mapTab.UseVisualStyleBackColor = true;
            // 
            // areaImg
            // 
            this.areaImg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.areaImg.ImageLocation = "http://103.101.162.83:8084/TopicFiles/HCMC.jpg";
            this.areaImg.Location = new System.Drawing.Point(22, 63);
            this.areaImg.Name = "areaImg";
            this.areaImg.Size = new System.Drawing.Size(1140, 581);
            this.areaImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.areaImg.TabIndex = 1;
            this.areaImg.TabStop = false;
            // 
            // cbAreaMap
            // 
            this.cbAreaMap.FormattingEnabled = true;
            this.cbAreaMap.Location = new System.Drawing.Point(738, 16);
            this.cbAreaMap.Name = "cbAreaMap";
            this.cbAreaMap.Size = new System.Drawing.Size(424, 33);
            this.cbAreaMap.TabIndex = 0;
            this.cbAreaMap.SelectedValueChanged += new System.EventHandler(this.cbAreaMap_SelectedValueChanged);
            // 
            // tableTab
            // 
            this.tableTab.Controls.Add(this.dgvMessage);
            this.tableTab.Location = new System.Drawing.Point(4, 34);
            this.tableTab.Name = "tableTab";
            this.tableTab.Size = new System.Drawing.Size(1180, 672);
            this.tableTab.TabIndex = 2;
            this.tableTab.Text = "Bảng";
            this.tableTab.UseVisualStyleBackColor = true;
            // 
            // dgvMessage
            // 
            this.dgvMessage.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(139)))), ((int)(((byte)(205)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.dgvMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMessage.EnableHeadersVisualStyles = false;
            this.dgvMessage.Location = new System.Drawing.Point(0, 0);
            this.dgvMessage.Name = "dgvMessage";
            this.dgvMessage.RowHeadersVisible = false;
            this.dgvMessage.RowHeadersWidth = 51;
            this.dgvMessage.RowTemplate.Height = 24;
            this.dgvMessage.RowTemplate.ReadOnly = true;
            this.dgvMessage.Size = new System.Drawing.Size(1180, 672);
            this.dgvMessage.TabIndex = 0;
            // 
            // count
            // 
            this.count.FillWeight = 50F;
            this.count.HeaderText = "STT";
            this.count.MinimumWidth = 6;
            this.count.Name = "count";
            // 
            // command
            // 
            this.command.HeaderText = "Lệnh";
            this.command.MinimumWidth = 6;
            this.command.Name = "command";
            // 
            // machineId
            // 
            this.machineId.HeaderText = "SH máy";
            this.machineId.MinimumWidth = 6;
            this.machineId.Name = "machineId";
            // 
            // time
            // 
            this.time.HeaderText = "Thời gian";
            this.time.MinimumWidth = 6;
            this.time.Name = "time";
            // 
            // magnetic
            // 
            this.magnetic.HeaderText = "Gía trị từ trường";
            this.magnetic.MinimumWidth = 6;
            this.magnetic.Name = "magnetic";
            // 
            // GPS
            // 
            this.GPS.FillWeight = 150F;
            this.GPS.HeaderText = "GPS";
            this.GPS.MinimumWidth = 6;
            this.GPS.Name = "GPS";
            // 
            // corner
            // 
            this.corner.HeaderText = "Góc";
            this.corner.MinimumWidth = 6;
            this.corner.Name = "corner";
            // 
            // timeGPS
            // 
            this.timeGPS.HeaderText = "Thời gian sửa";
            this.timeGPS.MinimumWidth = 6;
            this.timeGPS.Name = "timeGPS";
            // 
            // status
            // 
            this.status.HeaderText = "Trạng thái";
            this.status.MinimumWidth = 6;
            this.status.Name = "status";
            // 
            // MonitorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1188, 713);
            this.Controls.Add(this.tabControl1);
            this.Name = "MonitorForm";
            this.Text = "MonitorForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MonitorForm_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.chartTab.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.machineBombTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart_bomb)).EndInit();
            this.machineMineTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart_mine)).EndInit();
            this.mapTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.areaImg)).EndInit();
            this.tableTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMessage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage chartTab;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage machineBombTab;
        private System.Windows.Forms.TabPage machineMineTab;
        private System.Windows.Forms.TabPage mapTab;
        private System.Windows.Forms.TabPage tableTab;
        private System.Windows.Forms.DataGridView dgvMessage;
        private System.Windows.Forms.DataGridViewTextBoxColumn count;
        private System.Windows.Forms.DataGridViewTextBoxColumn command;
        private System.Windows.Forms.DataGridViewTextBoxColumn machineId;
        private System.Windows.Forms.DataGridViewTextBoxColumn time;
        private System.Windows.Forms.DataGridViewTextBoxColumn magnetic;
        private System.Windows.Forms.DataGridViewTextBoxColumn GPS;
        private System.Windows.Forms.DataGridViewTextBoxColumn corner;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeGPS;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_bomb;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_mine;
        private System.Windows.Forms.ComboBox cbAreaMap;
        private System.Windows.Forms.PictureBox areaImg;
    }
}