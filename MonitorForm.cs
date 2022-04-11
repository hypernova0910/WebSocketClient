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
    public partial class MonitorForm : Form
    {
        public MonitorForm()
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

        private void MonitorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true; // this cancels the close event.
        }

        private void cbAreaMap_SelectedValueChanged(object sender, EventArgs e)
        {
            if(cbAreaMap.ValueMember == "")
            {
                return;
            }
            foreach (CecmProgramAreaMapDTO dto in MainHome.lstArea)
            {
                if ((long)cbAreaMap.SelectedValue == dto.cecmProgramAreaMapId)
                {
                    areaImg.ImageLocation = ConfigURL.LocalServiceUrl + "/TopicFiles/" + dto.photo_file;
                    areaImg.Controls.Clear();
                }
            }
        }
    }
}
