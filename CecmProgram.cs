using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebSocketClient
{
    public partial class CecmProgram : Button
    {
        public CecmProgram()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            //Rectangle Rect = new Rectangle(0, 0, this.Width, this.Height);
            //GraphicsPath GraphPath = new GraphicsPath();
            //GraphPath.AddArc(Rect.X, Rect.Y, 50, 50, 180, 90);
            //GraphPath.AddArc(Rect.X + Rect.Width - 50, Rect.Y, 50, 50, 270, 90);
            //GraphPath.AddArc(Rect.X + Rect.Width - 50, Rect.Y + Rect.Height - 50, 50, 50, 0, 90);
            //GraphPath.AddArc(Rect.X, Rect.Y + Rect.Height - 50, 50, 50, 90, 90);
            ////GraphPath.GetBounds().BackColor = Color.FromArgb(4, 139, 205);
            //this.Region = new Region(GraphPath);
            RectangleF Rect = new RectangleF(0, 0, this.Width, this.Height);
            using (GraphicsPath GraphPath = GetRoundPath(Rect, 20))
            {
                this.Region = new Region(GraphPath);
                using (Pen pen = new Pen(Color.Transparent, 1.75f))
                {
                    pen.Alignment = PenAlignment.Inset;
                    pe.Graphics.DrawPath(pen, GraphPath);
                }
            }
        }

        GraphicsPath GetRoundPath(RectangleF Rect, int radius)
        {
            float r2 = radius / 2f;
            GraphicsPath GraphPath = new GraphicsPath();
            GraphPath.AddArc(Rect.X, Rect.Y, radius, radius, 180, 90);
            GraphPath.AddLine(Rect.X + r2, Rect.Y, Rect.Width - r2, Rect.Y);
            GraphPath.AddArc(Rect.X + Rect.Width - radius, Rect.Y, radius, radius, 270, 90);
            GraphPath.AddLine(Rect.Width, Rect.Y + r2, Rect.Width, Rect.Height - r2);
            GraphPath.AddArc(Rect.X + Rect.Width - radius,
                             Rect.Y + Rect.Height - radius, radius, radius, 0, 90);
            GraphPath.AddLine(Rect.Width - r2, Rect.Height, Rect.X + r2, Rect.Height);
            GraphPath.AddArc(Rect.X, Rect.Y + Rect.Height - radius, radius, radius, 90, 90);
            GraphPath.AddLine(Rect.X, Rect.Height - r2, Rect.X, Rect.Y + r2);
            GraphPath.CloseFigure();
            return GraphPath;
        }

        //Cái này để lúc click thì nó active sẽ đổi màu, click thằng khác thì đổi màu thằng này về
        //như cũ rồi gán thằng mới click vào đây
        public static CecmProgram activeControl;
        public string name { get; set; }
        public long cecmId { get; set; }
        public string code { get; set; }
        public string address { get; set; }
        public string timeST { get; set; }

        public string deptId { get; set; }
        public string deptName { get; set; }
        public string stt { get; set; }
        public string configName { get; set; }
        public string configTime { get; set; }
        public string configSpeed { get; set; }
        public string configIP { get; set; }
        public string configStatus { get; set; }

        //public Label getLabelProgramName()
        //{
        //    return lblProgramName;
        //}

        //public Label label
        //{
        //    get { return lblProgramName; }
        //    set { lblProgramName = value; lblProgramName.Text = value.Text; }
        //}

        private void CecmProgram_Click(object sender, EventArgs e)
        {
            activeControl.BackColor = Color.Transparent;
            this.BackColor = Color.FromArgb(232, 229, 49);
            activeControl = this;
        }

        private void CecmProgram_MouseHover(object sender, EventArgs e)
        {
            //BackColor = Color.FromArgb(217, 229, 242);
        }

        private void CecmProgram_MouseLeave(object sender, EventArgs e)
        {
            //if (this == activeControl)
            //{
            //    this.BackColor = Color.SkyBlue;
            //}
            //else
            //{
            //    this.BackColor = Color.FromArgb(255, 255, 255);
            //}
        }
    }
}
