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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void GenControl()
        {

            flowLayoutPanel1.Controls.Clear();
            CecmProgramControl[] lstControl = new CecmProgramControl[3];
            string[] lstName = new string[] { "Dự án 1Dự án 1Dự án 1Dự án 1Dự án 1Dự án 1", "Dự án 2", "Dự án 3", };
            Button btn1 = new Button();
            btn1.Name = "btn1";
            Button[] lstBtn = new Button[3] { btn1 , btn1 , btn1 };
            for(int i = 0; i < lstControl.Length; i++)
            {
                Label lbl1 = new Label();
                lbl1.Text = "abcd";
                lstControl[i] = new CecmProgramControl();
                lstControl[i].Title = lstName[i];
                lstControl[i].button = lstBtn[i];
                lstControl[i].label = lbl1;
                
                flowLayoutPanel1.Controls.Add(lstControl[i]);
                //lstControl[i].label.Click += new EventHandler(Label_Click);
                Console.WriteLine("222222222222: ");
                lstControl[i].Click += new System.EventHandler(this.UserControl_Click);

            }
        }
        void UserControl_Click(Object sender, EventArgs e)
        {
            CecmProgramControl obj = (CecmProgramControl)sender;
            lbel_name.Text = obj.Title;
            obj.BackColor = Color.Green;
            showPanel();
        }
        void Label_Click(Object sender, EventArgs e)
        {
            this.OnClick(EventArgs.Empty);
            Console.WriteLine("sender: " + sender);
            string lbl = (string)sender;
            Console.WriteLine("lbl.Text: " + lbl);
            lbel_name.Text = lbl;
            showPanel();
        }
        void showPanel()
        {
            panelParent.Visible = true;
        }
        void hidePanel()
        {
            panelParent.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GenControl();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            hidePanel();
        }
    }
}
