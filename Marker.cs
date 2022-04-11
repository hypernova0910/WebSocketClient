using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebSocketClient
{
    public partial class Marker : PictureBox
    {
        public Marker()
        {
            Image = Properties.Resources.marker;
            Size = new System.Drawing.Size(20, 20);
            SizeMode = PictureBoxSizeMode.StretchImage;
            BackColor = Color.Transparent;
            InitializeComponent();
        }

        public Marker(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }


    }
}
