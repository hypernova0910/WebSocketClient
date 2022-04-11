using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WebSocketClient
{
    public partial class MonitorForm2 : Form
    {
        private bool mouseDown;
        private Point lastLocation;
        //private const int CS_DROPSHADOW = 0x20000;
        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        CreateParams cp = base.CreateParams;
        //        cp.ClassStyle |= CS_DROPSHADOW;
        //        return cp;
        //    }
        //}

        public MonitorForm2()
        {
            InitializeComponent();
        }

        public DataGridView getDataGridView()
        {
            return dgvMessage;
        }

        public Chart getChartBomb()
        {
            return chart_bomb;
        }

        public Chart getChartMine()
        {
            return chart_mine;
        }

        public ComboBox getCbAreaMap()
        {
            return cbAreaMap;
        }

        public PictureBox getAreaImg()
        {
            return areaImg;
        }

        private void cbAreaMap_SelectedValueChanged(object sender, EventArgs e)
        {
            areaImg.ImageLocation = "";
            areaImg.Controls.Clear();
            if (cbAreaMap.ValueMember == "")
            {
                return;
            }
            MainHome.currMapId = (long)cbAreaMap.SelectedValue;
            //Chọn tất cả dự án. Đây sẽ là số âm của mã dự án
            //Ví dụ dự án 32 thì cbAreaMap.SelectedValue = -32
            //Việc này giúp lưu lại lịch sử dễ dàng hơn
            //Do không phải quan tâm đây là tất cả các vùng dự án của dự án nào
            if ((long)cbAreaMap.SelectedValue < 0)
            {
                CecmProgramAreaMapDTO dtoBig = (CecmProgramAreaMapDTO)cbAreaMap.SelectedItem;
                if(dtoBig.right_long - dtoBig.left_long <= 0 || dtoBig.top_lat - dtoBig.bottom_lat <= 0)
                {
                    return;
                }
                foreach (CecmProgramAreaMapDTO dto in MainHome.lstArea)
                {
                    if(dto.right_long == null || dto.left_long == null
                    || dto.top_lat == null || dto.bottom_lat == null
                    || dtoBig.right_long - dtoBig.left_long <= 0
                    || dtoBig.top_lat - dtoBig.bottom_lat <= 0)
                    {
                        continue;
                    }
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.ImageLocation = ConfigURL.ServerServiceUrl + "/TopicFiles/" + dto.photo_file;
                    pictureBox.Width = (int)(areaImg.Width * (dto.right_long - dto.left_long) / (dtoBig.right_long - dtoBig.left_long));
                    pictureBox.Height = (int)(areaImg.Height * (dto.top_lat - dto.bottom_lat) / (dtoBig.top_lat - dtoBig.bottom_lat));
                    int x = (int)(areaImg.Width * (dto.left_long - dtoBig.left_long) / (dtoBig.right_long - dtoBig.left_long));
                    int y = (int)(areaImg.Height * (1 - ((dto.top_lat - dtoBig.bottom_lat) / (dtoBig.top_lat - dtoBig.bottom_lat))));
                    pictureBox.Location = new Point(x, y);
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    areaImg.Controls.Add(pictureBox);
                    pictureBox.Paint += new PaintEventHandler(delegate(object sender2, PaintEventArgs e2)
                    {
                        Graphics g = e2.Graphics;
                        //g.SmoothingMode = SmoothingMode.AntiAlias;
                        using (Pen pen = new Pen(Color.Red, 1))
                        {
                            //CecmProgramAreaMapDTO dto2 = (CecmProgramAreaMapDTO)cbAreaMap.SelectedItem;
                            //string polygon = dto.polygonGeom;
                            //MessageBox.Show(polygon);
                            List<PointF[]> lst = CommonFunctions.convertMultiPolygon(dto, pictureBox.Size);
                            foreach (PointF[] points in lst)
                            {
                                g.DrawPolygon(pen, points);
                                g.FillPolygon(new SolidBrush(Color.FromArgb(85, 168, 50, 147)), points);
                            }
                        }
                    });
                    pictureBox.BorderStyle = BorderStyle.FixedSingle;
                    //areaImg.Controls.SetChildIndex(pictureBox, 10);
                }
                //return;
            }
            else
            {
                foreach (CecmProgramAreaMapDTO dto in MainHome.lstArea)
                {
                    if ((long)cbAreaMap.SelectedValue == dto.cecmProgramAreaMapId)
                    {
                        areaImg.ImageLocation = ConfigURL.ServerServiceUrl + "/TopicFiles/" + dto.photo_file;
                        break;
                    }
                }
            }
            if (MainHome.map_id__point.ContainsKey((long)cbAreaMap.SelectedValue))
            {
                foreach(Control control in MainHome.map_id__point[(long)cbAreaMap.SelectedValue])
                {
                    areaImg.Controls.Add(control);
                    if (control.Visible)
                    {
                        control.BringToFront();
                    }
                }
            }
            //draw polygon
            //MULTIPOLYGON(((106.6655 17.09,106.65231 17.15595,106.69188 17.1609,106.7298 17.12628,106.74299 17.07681,106.73969 17.04054,106.6655 17.09,106.6655 17.09,106.6655 17.09)))
            //MULTIPOLYGON(((106.75288 17.14606,106.7199 17.22355,106.81718 17.20871,106.84356 17.20377,106.8617 17.1543,106.84356 17.09165,106.77102 17.07681,106.73309 17.10649,106.75288 17.14606,106.75288 17.14606,106.75288 17.14606,106.75288 17.14606,106.75288 17.14606,106.75288 17.14606,106.75288 17.14606)))
            //MULTIPOLYGON(((106.90945 21.24169,107.2214 21.11845,107.2214 20.87967,106.68994 20.79495,106.65913 21.28405,106.88635 21.38033,106.90945 21.24169)))
            //Graphics g = areaImg.CreateGraphics();
            ////g.SmoothingMode = SmoothingMode.AntiAlias;
            //using (Pen pen = new Pen(Color.Red, 3))
            //{
            //    CecmProgramAreaMapDTO dto = (CecmProgramAreaMapDTO)cbAreaMap.SelectedItem;
            //    //string polygon = dto.polygonGeom;
            //    //MessageBox.Show(polygon);
            //    List<PointF[]> lst = CommonFunctions.convertMultiPolygon(dto, areaImg.Size);
            //    foreach (PointF[] points in lst)
            //    {
            //        g.DrawPolygon(pen, points);
            //        g.FillPolygon(Brushes.Yellow, points);
            //    }
            //}
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void areaImg_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            //g.SmoothingMode = SmoothingMode.AntiAlias;
            using (Pen pen = new Pen(Color.Red, 1))
            {
                CecmProgramAreaMapDTO dto = (CecmProgramAreaMapDTO)cbAreaMap.SelectedItem;
                //string polygon = dto.polygonGeom;
                //MessageBox.Show(polygon);
                List<PointF[]> lst = CommonFunctions.convertMultiPolygon(dto, areaImg.Size);
                foreach (PointF[] points in lst)
                {
                    g.DrawPolygon(pen, points);
                    g.FillPolygon(new SolidBrush(Color.FromArgb(85, 168, 50, 147)), points);
                }
            }
        }

        private void MonitorForm2_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }
    }
}
