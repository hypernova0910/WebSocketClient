using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebSocketClient
{
    public partial class InfoDialog : UserControl
    {
        //private const int CS_DROPSHADOW = 0x20000;

        public InfoDialog()
        {
            InitializeComponent();
        }

        public InfoDialog(string program, double dLat, double dLon, double magnetic)
        {
            InitializeComponent();
            lblCecmProgram.Text = program;
            lblCoordinate.Text = dLat + ", " + dLon;
            lblMagnetic.Text = magnetic.ToString();
            Hide();
        }

        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        CreateParams cp = base.CreateParams;
        //        cp.ClassStyle |= CS_DROPSHADOW;
        //        return cp;
        //    }
        //}

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
