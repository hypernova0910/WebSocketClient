using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebSocketClient
{
    public partial class CecmProgramControl : UserControl
    {
        public CecmProgramControl()
        {
            InitializeComponent();
        }

        //Cái này để lúc click thì nó active sẽ đổi màu, click thằng khác thì đổi màu thằng này về
        //như cũ rồi gán thằng mới click vào đây
        public static CecmProgramControl activeControl;

        private string title;
        private Button _button;
        private Label _label;
        public string name { get; set; }
        public long cecmId { get; set; }
        public string code { get; set; }
        public string address { get; set; }
        public string timeST { get; set; }
        public string deptName { get; set; }
        public string stt { get; set; }
        public string configName { get; set; }
        public string configTime { get; set; }
        public string configSpeed { get; set; }
        public string configIP { get; set; }
        public string configStatus { get; set; }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public Button button
        {
            get { return _button; }
            set { _button = value;  }
        }
        public Label label
        {
            get { return _label; }
            set { _label = value; labelCecmProgName.Text = value.Text; }
        }

        public Label getLabelProgramName()
        {
            return labelCecmProgName;
        }


        private void CecmProgramControl_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(217, 229, 242);
        }

        private void CecmProgramControl_MouseLeave(object sender, EventArgs e)
        {
            if(this == activeControl)
            {
                this.BackColor = Color.SkyBlue;
            }
            else
            {
                this.BackColor = Color.FromArgb(255, 255, 255);
            }
        }

        private void CecmProgramControl_Click(object sender, EventArgs e)
        {
            activeControl.BackColor = Color.FromArgb(255, 255, 255);
            this.BackColor = Color.SkyBlue;
            activeControl = this;
        }
    }
}
