using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using WebSocketSharp;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using System.Globalization;
using System.Drawing.Drawing2D;
using System.Net.Sockets;
using CoordinateSharp;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using System.Windows.Forms.DataVisualization.Charting;
using WebSocketClient.EncodeModule;

namespace WebSocketClient
{
    public partial class MainHome : Form
    {
        //private List<String> connected_program_ids;
        //Ứng với mỗi session_id sẽ ứng với một program_id
        private Dictionary<string, string> program_id__session_id;

        private Dictionary<string, WebSocket> program_id__ws;
        //Ứng với mỗi session_id sẽ có một trạng thái
        // true nếu được gửi dữ liệu
        // false nếu không được
        private Dictionary<string, bool> connected_status_session_ids;
        //Cái này để tiện đổi màu chữ
        private Dictionary<string, CecmProgram> program__control;

        //Do bây giờ chạy chương trình chỉ chạy 1 ws tại 1 thời điểm
        //nên biến này để lưi ws đang chạy
        private WebSocket currWs;
        private int timeLoopGlobal;

        //private const string IotEndpoint = "103.159.51.23";
        private const string IotEndpoint = "127.0.0.1";
        //private const string IotEndpoint = "192.168.1.18";
        private const int BrokerPort = 1883; // no SSL 1883 or SSL 8883;
        private string currSessionId;

        //private UdpClient udpServer;

        private List<CecmProgramDTO> lstCecm;
        private List<ConfigProgramDTO> lstConfig;
        private CecmProgram[] lstControl;

        //Dialog mới để theo dõi như trên web
        private MonitorForm2 monitorForm;
        private Dictionary<string, Series> machine_series_bomb;
        private Dictionary<string, Series> machine_series_mine;

        public static List<CecmProgramAreaMapDTO> lstArea;

        //Lưu các máy dò của dự án
        private Dictionary<long, List<string>> program__machines;
        int rowCount = 0;
        private string prevProgramId = "";

        public static Dictionary<long, List<Control>> map_id__point = new Dictionary<long, List<Control>>();
        public static long currMapId;

        public MainHome()
        {
            InitializeComponent();
            program_id__session_id = new Dictionary<string, string>();
            program_id__ws = new Dictionary<string, WebSocket>();
            program__control = new Dictionary<string, CecmProgram>();
            connected_status_session_ids = new Dictionary<string, bool>();
            program__machines = new Dictionary<long, List<string>>();
            btnConnect.Enabled = false;
            btnDisconnect.Enabled = false;
            btnLogOut.Enabled = false;
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            label1.BackColor = Color.Transparent;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            monitorForm = new MonitorForm2();
            machine_series_bomb = new Dictionary<string, Series>();
            machine_series_mine = new Dictionary<string, Series>();
            rowCount = 0;
            //int port = 59567;
            //udpServer = new UdpClient(port);
        }

        private void HieuHome_Load(object sender, EventArgs e)
        {
            ScrollBar vScrollBar1 = new VScrollBar();
            vScrollBar1.Dock = DockStyle.Right;
            vScrollBar1.Scroll += (sender2, e2) => { pnlPrograms.VerticalScroll.Value = vScrollBar1.Value; };
            pnlPrograms.Controls.Add(vScrollBar1);
            Show();
            (new MainLogIn()).ShowDialog();
            if (GenControl())
            {
                btnConnect.Enabled = true;
                btnLogOut.Enabled = true;
                btnLogIn.Enabled = false;
            }
            else
            {
                btnConnect.Enabled = false;
            }
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            (new MainLogIn()).ShowDialog();
            if (GenControl())
            {
                btnConnect.Enabled = true;
                btnDisconnect.Enabled = false;
                btnLogOut.Enabled = true;
                btnLogIn.Enabled = false;
            }
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            //Close();
            foreach (KeyValuePair<string, WebSocket> pair in program_id__ws)
            {
                pair.Value.Close();
            }
            program_id__session_id.Clear();
            program_id__ws.Clear();
            connected_status_session_ids.Clear();
            program__control.Clear();
            pnlPrograms.Controls.Clear();
            pnlPrograms.Controls.Add(label1);
            lbl_ProgramName.Text = "";
            label_CecmId_Hide.Text = "";
            label_ProgramCode.Text = "";
            label_DeptName.Text = "";
            label_ProgramTime.Text = "";
            label_ProgramStatus.Text = "";
            label_ConfigName.Text = "";
            label_ConfigTime.Text = "";
            label_ConfigSpeed.Text = "";
            label_ConfigIP.Text = "";
            label_ConfigStatus.Text = "";
            MainLogIn signin = new MainLogIn();
            btnConnect.Enabled = false;
            btnDisconnect.Enabled = false;
            btnLogIn.Enabled = true;
            btnLogOut.Enabled = false;

            //reset
            monitorForm.getChartBomb().Series.Clear();
            monitorForm.getChartMine().Series.Clear();
            monitorForm.getDataGridView().Rows.Clear();
            monitorForm.getCbAreaMap().ValueMember = "";
            monitorForm.getCbAreaMap().DisplayMember = "";
            monitorForm.getCbAreaMap().DataSource = null;
            //monitorForm.getCbAreaMap().Items.Clear();
            //monitorForm.Refresh();
            machine_series_bomb.Clear();
            machine_series_mine.Clear();

            signin.ShowDialog();
            if (GenControl())
            {
                btnConnect.Enabled = true;
                btnLogOut.Enabled = true;
                btnLogIn.Enabled = false;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (connected_status_session_ids.Count > 0)
            {
                //connected_status_session_ids.Remove(program_id__session_id[label_CecmId_Hide.Text]);
                //program_id__session_id.Remove(label_CecmId_Hide.Text);
                connected_status_session_ids.Clear();
                program_id__session_id.Clear();
                //program_id__ws[label_CecmId_Hide.Text].Close();
                //program_id__ws.Remove(label_CecmId_Hide.Text);
                program_id__ws.Clear();
            }
            Dispose();
        }

        private void pnlPrograms_Paint(object sender, PaintEventArgs e)
        {
            //ControlPaint.DrawBorder(e.Graphics, pnlPrograms.ClientRectangle,
            //Color.White, 1, ButtonBorderStyle.Solid, // left
            //Color.White, 1, ButtonBorderStyle.Solid, // top
            //Color.DimGray, 1, ButtonBorderStyle.Solid, // right
            //Color.DimGray, 1, ButtonBorderStyle.Solid);// bottom
            using (LinearGradientBrush brush = new LinearGradientBrush(pnlPrograms.ClientRectangle,
                Color.FromArgb(127, 183, 235),
                Color.FromArgb(193, 208, 222),
                90F))
            {
                e.Graphics.FillRectangle(brush, pnlPrograms.ClientRectangle);
            }
        }

        private bool GenControl()
        {
            pnlPrograms.Controls.Clear();
            pnlPrograms.Controls.Add(label1);
            if (!MainLogIn.isLogin)
            {
                return false;
            }
            lstCecm = getAllCecmProgramByDeptid(MainLogIn.donviID);
            if(lstCecm.Count == 0)
            {
                return false;
            }
            List<ConfigProgramDTO> lstCTmp = new List<ConfigProgramDTO>();
            foreach (var item in lstCecm)
            {
                ConfigProgramDTO configTmp = getOneConfigByCecmId(item.cecmProgramId);
                lstCTmp.Add(configTmp);
            }
            lstConfig = lstCTmp;
            //lstConfig = 
            int countProgram = lstCecm.Count();
            if (countProgram > 0)
            {
                lstControl = new CecmProgram[countProgram];
                for (int i = 0; i < countProgram; i++)
                {
                    lstControl[i] = new CecmProgram();
                    if(countProgram <= 5)
                    {
                        lstControl[i].Width = 342;
                    }
                    //lstControl[i].Width = pnlPrograms.Width;
                    // set Label va Butotn
                    //Label lbl = new Label();
                    //lbl.Text = lstCecm[i].name;
                    //Button btn = new Button();
                    //btn.Name = "btnKetnoi" + i.ToString();
                    //btn.Text = "Ket noi";
                    //btn.BackColor = Color.Green;
                    // set user control
                    //lstControl[i].Title = lstName[i];
                    //lstControl[i].button = btn;
                    //if(lstCecm[i].name.Length > 45)
                    //{
                    //    lstControl[i].Text = lstCecm[i].name.Substring(0, 45) + "...";
                    //}
                    //else
                    //{
                    //    lstControl[i].Text = lstCecm[i].name;
                    //}
                    lstControl[i].Text = lstCecm[i].name;
                    lstControl[i].name = lstCecm[i].name;
                    lstControl[i].cecmId = lstCecm[i].cecmProgramId;
                    lstControl[i].deptId = lstCecm[i].deptId;
                    lstControl[i].code = lstCecm[i].code;
                    lstControl[i].address = lstCecm[i].address;
                    lstControl[i].timeST = "Từ " + lstCecm[i].startTimeST + " đến " + lstCecm[i].endTimeST;
                    lstControl[i].deptName = lstCecm[i].deptName;
                    lstControl[i].stt = lstCecm[i].stt;
                    // thong tin cau hinh
                    if(lstConfig[i] != null)
                    {
                        lstControl[i].configName = (lstConfig[i].config_name != null) ? lstConfig[i].config_name : "";

                        lstControl[i].configTime = lstConfig[i].time;
                        lstControl[i].configSpeed = lstConfig[i].speed;
                        lstControl[i].configIP = lstConfig[i].is_checkIPST + " ," + lstConfig[i].ip_address;
                        lstControl[i].configStatus = lstConfig[i].statusST;
                    }
                    else
                    {
                        lstControl[i].configIP = "Không ,";
                    }
                    

                    pnlPrograms.Controls.Add(lstControl[i]);
                    //lstControl[i].label.Click += new EventHandler(Label_Click);

                    program__control.Add(lstCecm[i].cecmProgramId.ToString(), lstControl[i]);
                    // 

                    lstControl[i].Click += new EventHandler(UserControl_Click);
                    //lstControl[i].button.Click += new EventHandler(UCButton_Click);
                    //Console.WriteLine("222222222222: ");
                }
                // load lan dau tien thi se co san
                lbl_ProgramName.Text = lstControl[0].name;
                label_CecmId_Hide.Text = lstControl[0].cecmId.ToString();
                lblDeptId.Text = lstControl[0].deptId;
                label_ProgramCode.Text = lstControl[0].code;
                label_DeptName.Text = lstControl[0].deptName;
                label_ProgramTime.Text = lstControl[0].timeST;
                label_ProgramStatus.Text = lstControl[0].stt;
                label_ConfigName.Text = lstControl[0].configName;
                label_ConfigTime.Text = lstControl[0].configTime;
                label_ConfigSpeed.Text = lstControl[0].configSpeed;
                label_ConfigIP.Text = lstControl[0].configIP;
                label_ConfigStatus.Text = lstControl[0].configStatus;

                CecmProgram.activeControl = lstControl[0];
                lstControl[0].BackColor = Color.FromArgb(232, 229, 49);
            }
            return true;
        }

        void UserControl_Click(object sender, EventArgs e)
        {
            //OnClick(e);
            CecmProgram obj = (CecmProgram)sender;
            lbl_ProgramName.Text = obj.name;
            label_CecmId_Hide.Text = obj.cecmId.ToString();
            lblDeptId.Text = obj.deptId;
            lblDeptId.Text = obj.deptId;
            label_ProgramCode.Text = obj.code;
            label_DeptName.Text = obj.deptName;
            label_ProgramTime.Text = obj.timeST;
            label_ProgramStatus.Text = obj.stt;
            label_ConfigName.Text = obj.configName;
            label_ConfigTime.Text = obj.configTime;
            label_ConfigSpeed.Text = obj.configSpeed;
            label_ConfigIP.Text = obj.configIP;
            label_ConfigStatus.Text = obj.configStatus;

            //flowLayoutPanelLstProgram.Visible = 
        }

        private ConfigProgramDTO getOneConfigByCecmId(long cecmId)
        {
            ConfigProgramDTO configProgram = new ConfigProgramDTO();
            //string URL = ConfigURL.ServerServiceUrl + "/vnmac-service/configProgramRsServiceRest/getOneByCecmId/";
            string URL = "http://" + ConfigURL.WebIP + "/vnmac-service/configProgramRsServiceRest/getOneByCecmId/";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL);
            string objectST = "";
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync(cecmId.ToString()).Result;
            if (response.IsSuccessStatusCode)
            {
                //Console.WriteLine("IsSuccessStatusCodeTTTTTTTtttt");
                objectST = response.Content.ReadAsStringAsync().Result.ToString();
                configProgram = JsonConvert.DeserializeObject<ConfigProgramDTO>(objectST);
            }
            return configProgram;
        }

        public List<CecmProgramDTO> getAllCecmProgramByDeptid(long deptid)
        {
            List<CecmProgramDTO> lstCecmProgram = new List<CecmProgramDTO>();
            //string URL = "http://localhost:8084/vnmac-service/cecmProgramServiceRest/getallCecmProgram2/1/";
            string URL = "http://" + ConfigURL.WebIP + "/vnmac-service/cecmProgramServiceRest/getallCecmProgram2/1/" + deptid;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL);
            string objectST = "";
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            try
            {
                HttpResponseMessage response = client.GetAsync(deptid.ToString()).Result;
                if (response.IsSuccessStatusCode)
                {
                    objectST = response.Content.ReadAsStringAsync().Result.ToString();
                    lstCecmProgram = JsonConvert.DeserializeObject<List<CecmProgramDTO>>(objectST);
                }
            }catch(Exception e)
            {

            }
            return lstCecmProgram;
        }

        public async void getAllCecmMachineBomb(long cecmProgramId)
        {
            //List<CecmProgramDTO> lstCecmProgram = new List<CecmProgramDTO>();
            string URL = "http://" + ConfigURL.WebIP + "/vnmac-service/cecmProgramMachineBombRsServiceRest/getAll/0/0";
            HttpClient client = new HttpClient();
            //Uri uri = new Uri(URL);
            //client.BaseAddress = new Uri();
            List<long> ids = new List<long>();
            ids.Add(cecmProgramId);
            //JavaScriptSerializer json_serializer = new JavaScriptSerializer();
            string json = JsonConvert.SerializeObject(new
            {
                listLong1 = ids
            });
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            try
            {
                HttpResponseMessage response = await client.PostAsync(URL, content);
                if (response.IsSuccessStatusCode)
                {
                    string resultContent = await response.Content.ReadAsStringAsync();
                    List<CecmProgramMachineBombDTO> data = JsonConvert.DeserializeObject<List<CecmProgramMachineBombDTO>>(resultContent);
                    List<string> mac_ids = new List<string>();
                    foreach(CecmProgramMachineBombDTO datum in data)
                    {
                        mac_ids.Add(datum.mac_id);
                    }
                    program__machines.Add(cecmProgramId, mac_ids);
                }
                    

                //if (response.IsSuccessStatusCode)
                //{
                //    objectST = response.Content.ReadAsStringAsync().Result.ToString();
                //    lstCecmProgram = JsonConvert.DeserializeObject<List<CecmProgramDTO>>(objectST);
                //}
            }
            catch (Exception e)
            {

            }
        }

        public List<CecmProgramAreaMapDTO> getAllCecmProgramAreaMapByProgramId(long program_id)
        {
            List<CecmProgramAreaMapDTO> lst = new List<CecmProgramAreaMapDTO>();
            string URL = "http://" + ConfigURL.WebIP + "/vnmac-service/cecmProgramAreaMapServiceRest/getallCecmProgramAreaMap/" + program_id + "/0/0";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL);
            string objectST = "";
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            try
            {
                HttpResponseMessage response = client.GetAsync(program_id.ToString()).Result;
                if (response.IsSuccessStatusCode)
                {
                    objectST = response.Content.ReadAsStringAsync().Result.ToString();
                    lst = JsonConvert.DeserializeObject<List<CecmProgramAreaMapDTO>>(objectST);
                }
            }
            catch (Exception e)
            {

            }
            return lst;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (label_CecmId_Hide.Text.IsNullOrEmpty())
                {
                    MessageBox.Show("Chưa chọn dự án kết nối", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (program_id__session_id.ContainsKey(label_CecmId_Hide.Text))
                {
                    MessageBox.Show("Dự án đã kết nối trước đó rồi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (!program__machines.ContainsKey(long.Parse(label_CecmId_Hide.Text)))
                    {
                        getAllCecmMachineBomb(long.Parse(label_CecmId_Hide.Text));
                        Thread.Sleep(200);
                    }
                    //connected_status_session_ids.Add(label_CecmId_Hide.Text, true);

                    // cat chuo lay dai IP
                    string[] arrIP = label_ConfigIP.Text.Split(',');
                    if (arrIP.Length > 1)
                    {
                        if (!arrIP[1].IsNullOrEmpty())
                        {
                            string[] lstsubIP = arrIP[1].Split('.');
                            string[] lstmysubIP = MainLogIn.myIP.Split('.');
                            //neu ok
                            if (lstsubIP[0] == lstmysubIP[0] && lstsubIP[1] == lstmysubIP[1] && lstsubIP[2] == lstmysubIP[2])
                            {
                                // create websocket connect server
                                Thread thrd = new Thread(createSocket);
                                thrd.IsBackground = true;
                                thrd.Start();
                                btnConnect.Enabled = false;
                                btnDisconnect.Enabled = true;
                                foreach (CecmProgram control in lstControl)
                                {
                                    control.Enabled = false;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Địa chỉ IP này không được phép truy cập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            // create websocket connect server
                            Thread thrd = new Thread(createSocket);
                            thrd.IsBackground = true;
                            thrd.Start();
                            btnConnect.Enabled = false;
                            btnDisconnect.Enabled = true;
                            foreach (CecmProgram control in lstControl)
                            {
                                control.Enabled = false;
                            }
                        }
                    }
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Kết nối thất bại");
            }
        }

        void createSocket()
        {
            PaserPacket pPaserPacket = new PaserPacket();
            WebSocket ws = new WebSocket("ws://" + ConfigURL.WebIP + "/vnmac-web/message1");
            //WebSocket ws = new WebSocket("ws://103.101.162.83:8084/vnmac-web/message1");
            {
                currWs = ws;
                //ws.Close();
                var client = new MqttClient(tbMQTT.Text, BrokerPort, false, null, null, MqttSslProtocols.None);
                //client id here is totally arbitary, but I'm pretty sure you can't have more than one client named the same.
                //client.Connect("listener", user, pw);
                // gui data cuoi cung o day
                string program_id = label_CecmId_Hide.Text;
                string session_id = "";
                bool isConnected = false;
                program_id__ws.Add(program_id, ws);
                program_id__ws[program_id].OnMessage += (sender2, e2) =>
                {
                    Console.WriteLine("Data type: " + sender2.GetType());
                    Console.WriteLine("Data cuoi: " + e2.Data);
                    if (e2.Data.Contains("Deny"))
                    {
                        string[] status = e2.Data.Split(':');
                        if (status[1] == session_id)
                        {
                            program__control[program_id].ForeColor = Color.Red;
                            connected_status_session_ids[status[1]] = false;
                            MessageBox.Show("Server đã chặn gửi dữ liệu SID " + status[1], "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        //program_id = status[1];
                    }
                    else if (e2.Data.Contains("Accept"))
                    {
                        string[] status = e2.Data.Split(':');
                        if (status[1] == session_id)
                        {
                            program__control[program_id].ForeColor = Color.Green;
                            connected_status_session_ids[status[1]] = true;
                            MessageBox.Show("Server đã cho gửi dữ liệu SID " + status[1], "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        //program_id = status[1];
                    }
                    else if (e2.Data.Contains("Open"))
                    {
                        program__control[program_id].ForeColor = Color.Green;
                        string[] status = e2.Data.Split(':');
                        session_id = status[1];
                        currSessionId = session_id;
                        connected_status_session_ids.Add(session_id, true);
                        program_id__session_id.Add(program_id, session_id);
                        //program_id__ws[program_id].Send("InfoClinet;;;" + MainLogIn.userName + ";;;" + label_DeptName.Text + ";;;" + label_CecmId_Hide.Text + ";;;" + lbl_ProgramName.Text + ";;;" + DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy") + ";;;" + session_id + ";;;" + lblDeptId.Text);
                        program_id__ws[program_id].Send("InfoClinet;;;" + MainLogIn.userName + ";;;" + label_DeptName.Text + ";;;" + label_CecmId_Hide.Text + ";;;" + lbl_ProgramName.Text + ";;;" + DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy") + ";;;" + session_id + ";;;" + MainLogIn.donviID);
                        Console.WriteLine("session_id: " + session_id);
                        isConnected = true;

                        //event handler for inbound messages
                        //client.MqttMsgPublishReceived -= ClientMqttMsgPublishReceived;
                        client.MqttMsgPublishReceived += ClientMqttMsgPublishReceived;
                        string id = Guid.NewGuid().ToString();
                        try
                        {
                            client.Connect(id);
                        }
                        catch (Exception e)
                        {
                            if (program_id__ws.ContainsKey(program_id))
                            {
                                program_id__ws[program_id].Close();
                                program_id__ws.Remove(program_id);
                            }
                            
                            if (btnConnect.InvokeRequired)
                            {
                                btnConnect.Invoke(new MethodInvoker(delegate
                                {
                                    btnConnect.Enabled = true;
                                    btnDisconnect.Enabled = false;
                                    foreach (CecmProgram control in lstControl)
                                    {
                                        control.Enabled = true;
                                    }
                                }));
                            }
                            program__control[program_id].ForeColor = Color.Black;
                            program_id__session_id.Remove(program_id);
                            MessageBox.Show("Kết nối MQTT bị gián đoạn. Vui lòng thử lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        client.Subscribe(new[] { "bridge/message" }, new[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });

                        //build combobox vùng dự án
                        //List<CecmProgramAreaMapDTO> lst = getAllCecmProgramAreaMapByProgramId(long.Parse(program_id));
                        //monitorForm.getCbAreaMap().DataSource = lst;
                        //monitorForm.getCbAreaMap().ValueMember = "cecmProgramAreaMapId";
                        //monitorForm.getCbAreaMap().DisplayMember = "comboboxName";
                        if (program_id != prevProgramId)
                        {
                            lstArea = getAllCecmProgramAreaMapByProgramId(long.Parse(program_id));
                            if (monitorForm.getCbAreaMap().InvokeRequired)
                            {
                                monitorForm.getCbAreaMap().Invoke(new MethodInvoker(delegate
                                {
                                    CecmProgramAreaMapDTO init = new CecmProgramAreaMapDTO();
                                    init.cecmProgramAreaMapId = -long.Parse(program_id);
                                    init.comboboxName = "Tất cả";
                                    init.left_long = lstArea.Count > 0 ? lstArea[0].left_long : 0;
                                    init.right_long = 0;
                                    init.top_lat = 0;
                                    init.bottom_lat = lstArea.Count > 0 ? lstArea[0].bottom_lat : 0;
                                    init.polygonGeom = "";
                                    //Tìm các giá trị góc lớn nhất trong tất cả các vùng dự án
                                    foreach (CecmProgramAreaMapDTO dto in lstArea)
                                    {
                                        init.polygonGeom += dto.polygonGeom != null ? dto.polygonGeom : "";
                                        if (dto.left_long != null)
                                        {
                                            if (dto.left_long < init.left_long)
                                            {
                                                init.left_long = dto.left_long;
                                            }
                                        }
                                        if (dto.right_long != null)
                                        {
                                            if (dto.right_long > init.right_long)
                                            {
                                                init.right_long = dto.right_long;
                                            }
                                        }
                                        if (dto.top_lat != null)
                                        {
                                            if (dto.top_lat > init.top_lat)
                                            {
                                                init.top_lat = dto.top_lat;
                                            }
                                        }
                                        if (dto.bottom_lat != null)
                                        {
                                            if (dto.bottom_lat < init.bottom_lat)
                                            {
                                                init.bottom_lat = dto.bottom_lat;
                                            }
                                        }
                                    }
                                    List<CecmProgramAreaMapDTO> lst = new List<CecmProgramAreaMapDTO>(lstArea);
                                    lst.Insert(0, init);
                                    monitorForm.getCbAreaMap().DataSource = lst;
                                    monitorForm.getCbAreaMap().DisplayMember = "comboboxName";
                                    monitorForm.getCbAreaMap().ValueMember = "cecmProgramAreaMapId";
                                }));
                            }
                            else
                            {
                                CecmProgramAreaMapDTO init = new CecmProgramAreaMapDTO();
                                init.cecmProgramAreaMapId = -long.Parse(program_id);
                                init.comboboxName = "Tất cả";
                                init.left_long = lstArea.Count > 0 ? lstArea[0].left_long : 0;
                                init.right_long = 0;
                                init.top_lat = 0;
                                init.bottom_lat = lstArea.Count > 0 ? lstArea[0].bottom_lat : 0;
                                init.polygonGeom = "";
                                //Tìm các giá trị góc lớn nhất trong tất cả các vùng dự án
                                foreach (CecmProgramAreaMapDTO dto in lstArea)
                                {
                                    init.polygonGeom += dto.polygonGeom != null ? dto.polygonGeom : "";
                                    if (dto.left_long != null)
                                    {
                                        if (dto.left_long < init.left_long)
                                        {
                                            init.left_long = dto.left_long;
                                        }
                                    }
                                    if (dto.right_long != null)
                                    {
                                        if (dto.right_long > init.right_long)
                                        {
                                            init.right_long = dto.right_long;
                                        }
                                    }
                                    if (dto.top_lat != null)
                                    {
                                        if (dto.top_lat > init.top_lat)
                                        {
                                            init.top_lat = dto.top_lat;
                                        }
                                    }
                                    if (dto.bottom_lat != null)
                                    {
                                        if (dto.bottom_lat < init.bottom_lat)
                                        {
                                            init.bottom_lat = dto.bottom_lat;
                                        }
                                    }
                                }
                                List<CecmProgramAreaMapDTO> lst = new List<CecmProgramAreaMapDTO>(lstArea);
                                lst.Insert(0, init);
                                monitorForm.getCbAreaMap().DataSource = lst;
                                monitorForm.getCbAreaMap().DisplayMember = "comboboxName";
                                monitorForm.getCbAreaMap().ValueMember = "cecmProgramAreaMapId";
                            }
                            prevProgramId = program_id;
                        }

                        MessageBox.Show("Kết nối thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //program_id = status[1];
                    }
                    //else if (e2.Data.Contains("Close"))
                    //{
                    //    string[] status = e2.Data.Split(':');
                    //    connected_status_session_ids.Remove(session_id);
                    //    program_id__session_id.Remove(program_id);
                    //    //program_id = status[1];
                    //}
                };
                program_id__ws[program_id].Connect();
                program_id__ws[program_id].Send("Connected");
                Thread.Sleep(1000);
                if (!isConnected)
                {
                    program_id__ws[program_id].Close();
                    program_id__ws.Remove(program_id);
                    if (btnConnect.InvokeRequired)
                    {
                        btnConnect.Invoke(new MethodInvoker(delegate
                        {
                            btnConnect.Enabled = true;
                            btnDisconnect.Enabled = false;
                            foreach (CecmProgram control in lstControl)
                            {
                                control.Enabled = true;
                            }
                        }));
                    }
                    MessageBox.Show("Bạn đang không có kết nối internet", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //ws.Send("InfoClinet;" + Login.userName + ";" + historyConnectDTO.deptidST + ";" + historyConnectDTO.cecm_program_idST + ";" + DateTime.Now.ToString("dd'-'MM'-'yyyy'T'HH':'mm':'ss"));

                //string[] lines = System.IO.File.ReadAllLines(@"..\..\..\cvmine.txt");

                // Display the file contents by using a foreach loop.
                Console.WriteLine("Sendata to server");
                //Console.WriteLine("Total: " + lines.Length);

                int i = 1;
                bool isClose = false;
                bool isCloseAuto = false;
                bool isCloseByInternet = false;
                Thread.Sleep(100);
                Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
                DateTime start = DateTime.Now;
                double timeLast;
                if (double.TryParse(label_ConfigTime.Text, out timeLast))
                {
                    timeLast *= 60;
                }
                else
                {
                    timeLast = 12000000000000000000;
                }
                double timeLoopTmp;
                int timeLoop;
                Console.WriteLine("label_ConfigSpeed.Text: " + label_ConfigSpeed.Text);
                if (double.TryParse(label_ConfigSpeed.Text, out timeLoopTmp))
                {
                    timeLoop = (int)(timeLoopTmp * 1000);
                }
                else
                {
                    timeLoop = 0;
                }
                Console.WriteLine("timeLoop: " + timeLoop);
                Console.WriteLine("timeLast: " + timeLast);
                timeLoopGlobal = timeLoop;
                while (!isClose)
                {
                    //Console.WriteLine("In the loop");
                    //while(true)
                    //foreach (string line in lines)
                    //{
                    if ((DateTime.Now - start).TotalSeconds > timeLast)
                    {
                        isClose = true;
                        isCloseAuto = true;
                        break;
                    }
                    //Console.WriteLine(line);
                    if (!connected_status_session_ids.ContainsKey(session_id))
                    {
                        //Console.WriteLine("Fail");
                        isClose = true;
                        break;
                    }
                        
                    //remoteEP = null;
                    //buffer = udpServer.Receive(ref remoteEP);
                    //if (buffer != null && buffer.Length > 0)
                    //{
                        //string line = Encoding.ASCII.GetString(buffer);
                    //if (connected_status_session_ids[session_id])
                    //{
                        //Console.WriteLine("Success");
                        //if (!client.IsConnected)
                        //{
                        //    client.Connect(id);
                        //}
                                //string strCv = ConvertToGoole(line);

                                //if (strCv == string.Empty)
                                //{
                                //    program_id__ws[program_id].Send(line);
                                //}
                                //else
                                //{
                                //    program_id__ws[program_id].Send(strCv);
                                //    string[] strTmp = strCv.Split(',');
                                //    if (!addInfoConnectDTO(MainLogIn.userName, MainLogIn.myIP, "MD1GPS", strTmp[1], strTmp[9] + "; " + strTmp[11], "00"))
                                //    {
                                //        isClose = true;
                                //        isCloseByInternet = true;
                                //        break;
                                //    }
                                //    Console.WriteLine("\tData send " + i + ":" + strCv);
                                //    i++;
                                //}
                    //}
                            //ws.Send(userName);
                            //ws.Send(password);
                            // Use a tab to indent each line of the file.
                            // + "," + userName + "," + password
                    //else
                    //{
                    //    Console.WriteLine("Server blocked");
                        //client.Disconnect();
                    //}
                        //}


                    //Thread.Sleep(timeLoop);
                        //ws.Close();
                    //}
                }
                Console.WriteLine("End");
                //Close do tự động hết thời gian truyền
                if (isCloseAuto || isCloseByInternet)
                {
                    program__control[program_id].ForeColor = Color.Black;
                    if (program_id__session_id.ContainsKey(program_id))
                    {
                        connected_status_session_ids.Remove(program_id__session_id[program_id]);
                        program_id__session_id.Remove(program_id);
                    }

                    //ws.Close();
                    if (program_id__ws.ContainsKey(program_id))
                    {
                        program_id__ws[program_id].Close();
                        program_id__ws.Remove(program_id);
                    }
                    
                    if (isCloseAuto)
                    {
                        MessageBox.Show("Hết thời gian truyền tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    if (btnConnect.InvokeRequired)
                    {
                        btnConnect.Invoke(new MethodInvoker(delegate
                        {
                            btnConnect.Enabled = true;
                            btnDisconnect.Enabled = false;
                            foreach(CecmProgram control in lstControl)
                            {
                                control.Enabled = true;
                            }
                        }));
                    }
                    
                }
                //Console.ReadKey(true);
                if (client.IsConnected)
                {
                    client.Disconnect();
                }
            }
        }

        bool addInfoConnectDTO(string usernameI, string IP, string COMMAND, string Magnetic, string GPS, string Corner)
        {
            // call api add history table
            DateTime now = DateTime.Now;
            string datenow = now.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss");
            Console.WriteLine("DateTime.Now.ToString: " + datenow);

            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://" + ConfigURL.WebIP + "/vnmac-mongo-service/addObj");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string[] latLong = GPS.Split(';');
                    double.TryParse(latLong[0].Trim(), out double longt);
                    double.TryParse(latLong[1].Trim(), out double latt);
                    string json = new JavaScriptSerializer().Serialize(new
                    {
                        cecmProgramId = long.Parse(label_CecmId_Hide.Text),
                        deptId = long.Parse(lblDeptId.Text),
                        latitude = latt,
                        longtitude = longt,
                        //deptId = MainLogIn.donviID,
                        cecmProgramName = lbl_ProgramName.Text,
                        username = usernameI,
                        //point = new GeoJsonPoint<GeoJson2DCoordinates>(GeoJson.Position(latt, longt)),
                        ip = IP,
                        command = COMMAND,
                        magnetic = Magnetic,
                        gps = GPS,
                        corner = Corner,
                        timeStart = datenow,
                        timeStartST = now.ToString("HH':'mm':'ss' 'dd'/'MM'/'yyyy")
                    });;;
                    streamWriter.Write(json);
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    Console.WriteLine("result add: " + result);
                }
            }
            catch(Exception e)
            {
                MessageBox.Show("Không thể gửi dữ liệu lên MongoDB", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        static string ConvertToGoole(string str)
        {
            // !MDGPS,11508,17,0,27,12,3,17,A,2102.417724,N,10547.533203,E,0.275948,0.000000,0.000000,225,*26:
            string strRet = string.Empty;
            if (str.Length < 6)
                return strRet;
            if (str.Substring(0, 6) == "!MDGPS")
            {
                int[] vecArr = new int[str.Length];
                int k = 0;
                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i] == ',')
                    {
                        vecArr[k] = i; k++;
                    }
                }
                // get string 
                string strLat = str.Substring(vecArr[8] + 1, vecArr[9] - vecArr[8] - 1);
                float latGPS = 0.0f;
                if (!float.TryParse(strLat, out latGPS))
                    return strRet;
                string strLong = str.Substring(vecArr[10] + 1, vecArr[11] - vecArr[10] - 1);
                float longGPS = 0.0f;
                if (!float.TryParse(strLong, out longGPS))
                    return strRet;
                float latGoogle = 0.0f, longGoogle = 0.0f;
                ConvertToGoogle(latGPS, 'N', longGPS, 'E', ref latGoogle, ref longGoogle);
                strRet = str.Substring(0, vecArr[8] + 1) + latGoogle.ToString() + ",N," + longGoogle.ToString() + str.Substring(vecArr[11]);

                //tinh tesst
                Console.WriteLine("str.Substring(0, vecArr[8] + 1): " + str.Substring(0, vecArr[8] + 1));
                Console.WriteLine("latGoogle.ToString(): " + latGoogle.ToString());
                Console.WriteLine("longGoogle.ToString(): " + longGoogle.ToString());
                Console.WriteLine("str.Substring(vecArr[11]): " + str.Substring(vecArr[11]));
            }
            return strRet;
        }
        static void ConvertToGoogle(float latGPS, char c_lat, float longGPS, char c_long, ref float latGoogle, ref float longGoogle)
        {
            float pp, dd;
            if (latGPS < 100)
            {
                latGoogle = latGPS / 60;
                if (c_lat == 'S')
                    latGoogle = -latGoogle;
            }
            else
            {
                dd = (int)((int)(latGPS) / 100.0f);
                pp = latGPS - (dd * 100.0f);
                latGoogle = (pp / 60.0f) + dd;
                if (c_lat == 'S')
                    latGoogle = -latGoogle;
            }
            if (longGPS < 100)
            {
                longGoogle = longGPS / 60;
                if (c_long == 'S')
                    longGoogle = -longGoogle;
            }
            else
            {
                dd = (int)((int)(longGPS) / 100.0f);
                pp = longGPS - (dd * 100.0f);
                longGoogle = (pp / 60.0f) + dd;
                if (c_long == 'W')
                    longGoogle = -longGoogle;
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            program__control[label_CecmId_Hide.Text].ForeColor = Color.Black;
            if (program_id__session_id.ContainsKey(label_CecmId_Hide.Text))
            {
                connected_status_session_ids.Remove(program_id__session_id[label_CecmId_Hide.Text]);
                program_id__session_id.Remove(label_CecmId_Hide.Text);
                //ws.Close();
                program_id__ws[label_CecmId_Hide.Text].Close();
                program_id__ws.Remove(label_CecmId_Hide.Text);
                btnConnect.Enabled = true;
                btnDisconnect.Enabled = false;
                foreach (CecmProgram control in lstControl)
                {
                    control.Enabled = true;
                }
                MessageBox.Show("Ngắt kết nối", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //updateHistoryConnectDTO(DateTime.Now.AddHours(-7));


                Console.WriteLine("Closed websocket!!");
            }
            else
            {
                MessageBox.Show("Dự án chưa kết nối", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ClientMqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            try
            {
                string fileSPath = "message.txt";
                Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
                Console.WriteLine("We received a message...");
                Console.WriteLine(Encoding.UTF8.GetChars(e.Message));
                string strMess = Encoding.ASCII.GetString(e.Message);
                if (strMess.StartsWith("$MDN"))
                {
                    string[] elements = strMess.Split(',');
                    if (elements.Length <= 10)
                    {
                        return;
                    }
                    List<string> lstJson = new List<string>();
                    string machineId = elements[1];
                    string time = elements[2] + ":" + elements[3] + ":" + elements[4] + " " + elements[5] + "/" + elements[6] + "/" + elements[7];
                    short numValue = short.Parse(elements[8]);
                    short numGPS = short.Parse(elements[9]);
                    string status = elements[10];
                    int.TryParse(elements[10], out int bitSent);
                    bool isFlag = ((bitSent & 8) > 0);
                    bool isDeep = ((bitSent & 2) > 0);

                    double magnetic = 0.0;
                    if (numGPS <= 0 && numValue <= 0)
                    {
                        return;
                    }
                    for (short i = 0; i < numValue; i++)
                    {
                        magnetic += double.Parse(elements[11 + i]);
                    }
                    if (numValue != 0)
                    {
                        magnetic /= numValue;
                    }
                    short offset = numValue;
                    offset += 11;
                    double dLat = 0;
                    double dLon = 0;
                    string timeGPS = "";
                    for (short k = 0; k < numGPS; k++)
                    {
                        timeGPS = elements[offset++] + ":" + elements[offset++] + ":" + elements[offset++] + " " + elements[offset++] + "/" + elements[offset++] + "/" + elements[offset++];
                        //Console.WriteLine("TimeGPS= " + elements[offset++] + ":" + elements[offset++] + ":" + elements[offset++] + " " + elements[offset++] + "/" + elements[offset++] + "/" + elements[offset++]);
                        try
                        {
                            dLat += double.Parse(elements[offset++]);
                            dLon += double.Parse(elements[offset++]);
                            //Console.WriteLine("Lat,Lon= " + dLat + " " + dLon);
                            //Coordinate cWGS84 = new Coordinate(dLat, dLon);
                            //Console.WriteLine("UTM N,E= " + cWGS84.UTM.Northing + " " + cWGS84.UTM.Easting);
                            // write ObjectID,button,TimeGPS,cWGS84.UTM.Northing,cWGS84.UTM.Easting,dTotal to database for CAD app
                            // create packet send ObjectID,button,TimeGPS,dLon,dLat,dTotal to server
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        //lstJson.Add(json);
                    }
                    if (numGPS != 0)
                    {
                        dLon = dLon / numGPS;
                        dLat = dLat / numGPS;
                    }
                    string json = new JavaScriptSerializer().Serialize(new
                    {
                        command = "MDN",
                        machineId = machineId,
                        time = time,
                        status = status,
                        magnetic = magnetic,
                        corner = "00",
                        timeGPS = timeGPS,
                        dLon = dLon,
                        dLat = dLat,
                        isFlag = isFlag,
                        isDeep = isDeep
                        //northing = cWGS84.UTM.Northing,
                        //easting = cWGS84.UTM.Easting,
                        //longZone = cWGS84.UTM.LongZone,
                        //latZone = cWGS84.UTM.LatZone
                    });
                    if (!connected_status_session_ids.ContainsKey(currSessionId))
                    {
                        connected_status_session_ids.Remove(currSessionId);
                        return;
                    }
                    if (!program__machines.ContainsKey(long.Parse(label_CecmId_Hide.Text)))
                    {
                        return;
                    }
                    //Lọc máy dò
                    if (!program__machines[long.Parse(label_CecmId_Hide.Text)].Contains(machineId))
                    {
                        return;
                    }
                    if (!addInfoConnectDTO(MainLogIn.userName, MainLogIn.myIP, "MDN", magnetic.ToString(), dLon + "; " + dLat, "00"))
                    {
                        connected_status_session_ids.Remove(currSessionId);
                        return;
                    }
                    if (connected_status_session_ids[currSessionId])
                    {
                        List<string> encoded = MyEncoder.encrypt(json);
                        string jsonEncoded = new JavaScriptSerializer().Serialize(encoded);
                        Console.WriteLine("Send ws: " + jsonEncoded);
                        currWs.Send(jsonEncoded);
                        System.IO.File.AppendAllText(fileSPath, json + "\n");
                        if (monitorForm.InvokeRequired)
                        {
                            monitorForm.Invoke(new MethodInvoker(delegate
                            {
                            //add data to table
                            DataGridViewRow row = (DataGridViewRow)monitorForm.getDataGridView().Rows[0].Clone();
                            //row.Cells[0].Value = monitorForm.getDataGridView().Rows.Count;
                            row.Cells[0].Value = ++rowCount;
                                row.Cells[1].Value = "MDN";
                                row.Cells[2].Value = machineId;
                                row.Cells[3].Value = time;
                                row.Cells[4].Value = magnetic;
                                row.Cells[5].Value = Math.Round(dLon, 5) + " - " + Math.Round(dLat, 5);
                                row.Cells[6].Value = "00";
                                row.Cells[7].Value = timeGPS;
                                row.Cells[8].Value = status;
                                monitorForm.getDataGridView().Rows.Insert(0, row);
                                if (monitorForm.getDataGridView().Rows.Count > 100)
                                {
                                //monitorForm.getDataGridView().Rows[100].Visible = false;
                                monitorForm.getDataGridView().Rows.RemoveAt(99);
                                }

                            //mark on map
                            if ((long)monitorForm.getCbAreaMap().SelectedValue == currMapId)
                                {
                                    Marker marker = new Marker();
                                    Size mapSize = monitorForm.getAreaImg().Size;
                                    CecmProgramAreaMapDTO dto = (CecmProgramAreaMapDTO)monitorForm.getCbAreaMap().SelectedItem;
                                    if (dto.left_long != null && dto.right_long != null
                                        && dto.top_lat != null && dto.bottom_lat != null
                                        && dto.left_long < dto.right_long && dto.bottom_lat < dto.top_lat)
                                    {
                                        double left_long = (double)dto.left_long;
                                        double right_long = (double)dto.right_long;
                                        double x_percent = (dLon - left_long) / (right_long - left_long);
                                        double x = mapSize.Width * x_percent;
                                        double bottom_lat = (double)dto.bottom_lat;
                                        double top_lat = (double)dto.top_lat;
                                        double y_percent = (dLat - bottom_lat) / (top_lat - bottom_lat);
                                        double y = mapSize.Height * (1 - y_percent);
                                        InfoDialog infoDialog = new InfoDialog(lbl_ProgramName.Text, dLat, dLon, magnetic);
                                        int x_dialog, y_dialog;
                                        if (x_percent > 0.5)
                                        {
                                            x_dialog = (int)x - 10 - infoDialog.Width;
                                        }
                                        else
                                        {
                                            x_dialog = (int)x + 10;
                                        }
                                        if (y_percent < 0.5)
                                        {
                                            y_dialog = (int)y - 10 - infoDialog.Height;

                                        }
                                        else
                                        {
                                            y_dialog = (int)y + 10;
                                        }
                                        infoDialog.Location = new Point(x_dialog, y_dialog);
                                        Control exist_dialog = monitorForm.getAreaImg().GetChildAtPoint(infoDialog.Location);
                                        if (exist_dialog != null && exist_dialog is InfoDialog)
                                        {
                                            if (exist_dialog.Visible == false)
                                            {
                                                monitorForm.getAreaImg().Controls.Remove(exist_dialog);
                                            }

                                        }
                                        monitorForm.getAreaImg().Controls.Add(infoDialog);
                                    //infoDialog.Hide();
                                    marker.Click += new EventHandler(delegate (object sender2, EventArgs e2)
                                        {
                                            infoDialog.Show();
                                            infoDialog.BringToFront();
                                        });
                                        marker.Location = new Point((int)x - marker.Width / 2, (int)y - marker.Height / 2);
                                    //marker.Anchor = AnchorStyles.Top | AnchorStyles.Bottom
                                    //| AnchorStyles.Left
                                    //| AnchorStyles.Right;
                                    //Add infoDialog to history
                                    if (monitorForm.getCbAreaMap().ValueMember != "")
                                        {
                                            if (!map_id__point.ContainsKey((long)monitorForm.getCbAreaMap().SelectedValue))
                                            {
                                                map_id__point.Add((long)monitorForm.getCbAreaMap().SelectedValue, new List<Control>());
                                            }
                                            map_id__point[(long)monitorForm.getCbAreaMap().SelectedValue].Add(infoDialog);
                                        }
                                        Control exist_marker = monitorForm.getAreaImg().GetChildAtPoint(marker.Location);
                                        if (exist_marker != null && exist_marker is Marker)
                                        {
                                            monitorForm.getAreaImg().Controls.Remove(exist_marker);
                                            map_id__point[(long)monitorForm.getCbAreaMap().SelectedValue].Remove(marker);
                                        }
                                        monitorForm.getAreaImg().Controls.Add(marker);
                                        marker.BringToFront();
                                    //Add marker to history
                                    if (monitorForm.getCbAreaMap().ValueMember != "")
                                        {
                                            if (!map_id__point.ContainsKey((long)monitorForm.getCbAreaMap().SelectedValue))
                                            {
                                                map_id__point.Add((long)monitorForm.getCbAreaMap().SelectedValue, new List<Control>());
                                            }
                                            map_id__point[(long)monitorForm.getCbAreaMap().SelectedValue].Add(marker);
                                        }
                                    //monitorForm.getAreaImg().Controls.SetChildIndex(marker, 10);
                                }
                                }



                            //draw chart
                            //DateTime now = DateTime.Now;
                            DateTime now = new DateTime(int.Parse(elements[7]), int.Parse(elements[6]), int.Parse(elements[5]), int.Parse(elements[2]), int.Parse(elements[3]), int.Parse(elements[4]));
                                if (monitorForm.getChartBomb().ChartAreas[0].AxisX.Title != "Thời gian (" + now.Hour + "h" + now.Minute + "p...s)")
                                {
                                    monitorForm.getChartBomb().ChartAreas[0].AxisX.Title = "Thời gian (" + now.Hour + "h" + now.Minute + "p...s)";
                                    monitorForm.getChartBomb().Series.Clear();
                                    machine_series_bomb.Clear();
                                }
                                if (!machine_series_bomb.ContainsKey(machineId))
                                {
                                    Series series = new Series(machineId);
                                    machine_series_bomb.Add(machineId, series);
                                    monitorForm.getChartBomb().Series.Add(series);
                                    monitorForm.getChartBomb().Series[machineId].ChartType = SeriesChartType.Line;
                                    monitorForm.getChartBomb().Series[machineId].MarkerStyle = MarkerStyle.Circle;
                                //monitorForm.getChartBomb().Series[machineId].Points.AddXY(0, 0);
                            }
                                monitorForm.getChartBomb().Series[machineId].Points.AddXY(now.Second, magnetic);
                            }));
                        }
                    }
                    else
                    {
                        Console.WriteLine("Server blocked");
                    }
                    Thread.Sleep(timeLoopGlobal);
                }
                // $MDN,fe807857c8c8be98,7,53,14,15,5,2021,4,1,1,1.1234568357,-1.1234568357,2.1234567165,-2.1234567165,7,53,15,15,5,2021,105.7946321670,21.0636426670
                else if (strMess.StartsWith("$MDM"))
                {
                    string[] elements = strMess.Split(',');
                    if (elements.Length <= 10)
                    {
                        return;
                    }
                    short numValue = short.Parse(elements[8]);
                    short numGPS = short.Parse(elements[9]);
                    double dLat = 0;
                    double dLon = 0;
                    string timeGPS = "";
                    /////////////////////////// first version not process numGPS==0
                    if (numGPS > 0 || numValue > 0)
                    {
                        Console.WriteLine("ObjectID= " + elements[1]);
                        Console.WriteLine("Time= " + elements[2] + ":" + elements[3] + ":" + elements[4] + " " + elements[5] + "/" + elements[6] + "/" + elements[7]);
                        Console.WriteLine("Number value= " + elements[8]);
                        Console.WriteLine("Number GPS= " + elements[9]);
                        Console.WriteLine("Byte status button= " + elements[10]);
                        string machineId = elements[1];
                        string time = elements[2] + ":" + elements[3] + ":" + elements[4] + " " + elements[5] + "/" + elements[6] + "/" + elements[7];
                        string status = elements[10];
                        int.TryParse(elements[10], out int bitSent);
                        bool isFlag = ((bitSent & 8) > 0);
                        bool isDeep = ((bitSent & 2) > 0);
                        byte value;
                        uint led14 = 0, mask = 80;
                        double magnetic = 0;
                        for (short i = 0; i < numValue; i++)
                        {
                            value = byte.Parse(elements[11 + i]);
                            /*
                            if(i== numValue-1)
                                Console.WriteLine(value);
                            else
                                Console.Write(value+",");
                            */
                            led14 = value;
                            led14 &= mask;
                            if (led14 > 0)
                                led14 = 1;
                            mask = value;
                            mask &= 127;
                            if (led14 == 1 && mask > magnetic)
                            {
                                magnetic = mask;
                            }
                            if (i == numValue - 1)
                                Console.WriteLine(mask + "-" + led14); // gia tri thang do - trang thai led 14
                            else
                                Console.Write(mask + "-" + led14 + ","); // gia tri thang do - trang thai led 14
                        }
                        short offset = numValue;
                        offset += 11;
                        for (short k = 0; k < numGPS; k++)
                        {
                            timeGPS = elements[offset++] + ":" + elements[offset++] + ":" + elements[offset++] + " " + elements[offset++] + "/" + elements[offset++] + "/" + elements[offset++];
                            //Console.WriteLine("TimeGPS= " + elements[offset++] + ":" + elements[offset++] + ":" + elements[offset++] + " " + elements[offset++] + "/" + elements[offset++] + "/" + elements[offset++]);
                            try
                            {
                                dLat += double.Parse(elements[offset++]);
                                dLon += double.Parse(elements[offset++]);
                                //Console.WriteLine("Lat,Lon= " + dLat + " " + dLon);
                                //Coordinate cWGS84 = new Coordinate(dLat, dLon);
                                //Console.WriteLine("UTM N,E= " + cWGS84.UTM.Northing + " " + cWGS84.UTM.Easting);
                                // write ObjectID,button,TimeGPS,cWGS84.UTM.Northing,cWGS84.UTM.Easting,dTotal to database for CAD app
                                // create packet send ObjectID,button,TimeGPS,dLon,dLat,dTotal to server
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            //lstJson.Add(json);
                        }
                        if (numGPS != 0)
                        {
                            dLon = dLon / numGPS;
                            dLat = dLat / numGPS;
                        }
                        string json = new JavaScriptSerializer().Serialize(new
                        {
                            command = "MDM",
                            machineId = machineId,
                            time = time,
                            status = status,
                            magnetic = magnetic,
                            corner = "00",
                            timeGPS = timeGPS,
                            dLon = dLon,
                            dLat = dLat,
                            isFlag = isFlag,
                            isDeep = isDeep
                            //northing = cWGS84.UTM.Northing,
                            //easting = cWGS84.UTM.Easting,
                            //longZone = cWGS84.UTM.LongZone,
                            //latZone = cWGS84.UTM.LatZone
                        });
                        if (!connected_status_session_ids.ContainsKey(currSessionId))
                        {
                            connected_status_session_ids.Remove(currSessionId);
                            return;
                        }
                        if (!program__machines[long.Parse(label_CecmId_Hide.Text)].Contains(machineId))
                        {
                            return;
                        }
                        if (!addInfoConnectDTO(MainLogIn.userName, MainLogIn.myIP, "MDM", magnetic.ToString(), dLon + "; " + dLat, "00"))
                        {
                            connected_status_session_ids.Remove(currSessionId);
                            return;
                        }
                        if (connected_status_session_ids[currSessionId])
                        {
                            List<string> encoded = MyEncoder.encrypt(json);
                            string jsonEncoded = new JavaScriptSerializer().Serialize(encoded);
                            Console.WriteLine("Send ws: " + jsonEncoded);
                            currWs.Send(jsonEncoded);
                            System.IO.File.AppendAllText(fileSPath, json + "\n");
                            if (monitorForm.InvokeRequired)
                            {
                                monitorForm.Invoke(new MethodInvoker(delegate
                                {
                                //add data to table
                                DataGridViewRow row = (DataGridViewRow)monitorForm.getDataGridView().Rows[0].Clone();
                                //row.Cells[0].Value = monitorForm.getDataGridView().Rows.Count;
                                row.Cells[0].Value = ++rowCount;
                                    row.Cells[1].Value = "MDM";
                                    row.Cells[2].Value = machineId;
                                    row.Cells[3].Value = time;
                                    row.Cells[4].Value = magnetic;
                                    row.Cells[5].Value = Math.Round(dLon, 5) + " - " + Math.Round(dLat, 5);
                                    row.Cells[6].Value = "00";
                                    row.Cells[7].Value = timeGPS;
                                    row.Cells[8].Value = status;
                                    monitorForm.getDataGridView().Rows.Insert(0, row);
                                    if (monitorForm.getDataGridView().Rows.Count > 100)
                                    {
                                    //monitorForm.getDataGridView().Rows[100].Visible = false;
                                    monitorForm.getDataGridView().Rows.RemoveAt(99);
                                    }

                                //mark on map
                                if ((long)monitorForm.getCbAreaMap().SelectedValue == currMapId)
                                    {
                                        Marker marker = new Marker();
                                        Size mapSize = monitorForm.getAreaImg().Size;
                                        CecmProgramAreaMapDTO dto = (CecmProgramAreaMapDTO)monitorForm.getCbAreaMap().SelectedItem;
                                        if (dto.left_long != null && dto.right_long != null
                                            && dto.top_lat != null && dto.bottom_lat != null
                                            && dto.left_long < dto.right_long && dto.bottom_lat < dto.top_lat)
                                        {
                                            double left_long = (double)dto.left_long;
                                            double right_long = (double)dto.right_long;
                                            double x_percent = (dLon - left_long) / (right_long - left_long);
                                            double x = mapSize.Width * x_percent;
                                            double bottom_lat = (double)dto.bottom_lat;
                                            double top_lat = (double)dto.top_lat;
                                            double y_percent = (dLat - bottom_lat) / (top_lat - bottom_lat);
                                            double y = mapSize.Height * (1 - y_percent);
                                            InfoDialog infoDialog = new InfoDialog(lbl_ProgramName.Text, dLat, dLon, magnetic);
                                            int x_dialog, y_dialog;
                                            if (x_percent > 0.5)
                                            {
                                                x_dialog = (int)x - 10 - infoDialog.Width;
                                            }
                                            else
                                            {
                                                x_dialog = (int)x + 10;
                                            }
                                            if (y_percent < 0.5)
                                            {
                                                y_dialog = (int)y - 10 - infoDialog.Height;

                                            }
                                            else
                                            {
                                                y_dialog = (int)y + 10;
                                            }
                                            infoDialog.Location = new Point(x_dialog, y_dialog);
                                            Control exist_dialog = monitorForm.getAreaImg().GetChildAtPoint(infoDialog.Location);
                                            if (exist_dialog != null && exist_dialog is InfoDialog)
                                            {
                                                if (exist_dialog.Visible == false)
                                                {
                                                    monitorForm.getAreaImg().Controls.Remove(exist_dialog);
                                                }

                                            }
                                            monitorForm.getAreaImg().Controls.Add(infoDialog);
                                        //infoDialog.Hide();
                                        marker.Click += new EventHandler(delegate (object sender2, EventArgs e2)
                                            {
                                                infoDialog.Show();
                                                infoDialog.BringToFront();
                                            });
                                            marker.Location = new Point((int)x - marker.Width / 2, (int)y - marker.Height / 2);
                                        //marker.Anchor = AnchorStyles.Top | AnchorStyles.Bottom
                                        //| AnchorStyles.Left
                                        //| AnchorStyles.Right;
                                        //Add infoDialog to history
                                        if (monitorForm.getCbAreaMap().ValueMember != "")
                                            {
                                                if (!map_id__point.ContainsKey((long)monitorForm.getCbAreaMap().SelectedValue))
                                                {
                                                    map_id__point.Add((long)monitorForm.getCbAreaMap().SelectedValue, new List<Control>());
                                                }
                                                map_id__point[(long)monitorForm.getCbAreaMap().SelectedValue].Add(infoDialog);
                                            }
                                            Control exist_marker = monitorForm.getAreaImg().GetChildAtPoint(marker.Location);
                                            if (exist_marker != null && exist_marker is Marker)
                                            {
                                                monitorForm.getAreaImg().Controls.Remove(exist_marker);
                                                map_id__point[(long)monitorForm.getCbAreaMap().SelectedValue].Remove(marker);
                                            }
                                            monitorForm.getAreaImg().Controls.Add(marker);
                                            marker.BringToFront();
                                        //Add marker to history
                                        if (monitorForm.getCbAreaMap().ValueMember != "")
                                            {
                                                if (!map_id__point.ContainsKey((long)monitorForm.getCbAreaMap().SelectedValue))
                                                {
                                                    map_id__point.Add((long)monitorForm.getCbAreaMap().SelectedValue, new List<Control>());
                                                }
                                                map_id__point[(long)monitorForm.getCbAreaMap().SelectedValue].Add(marker);
                                            }
                                        //monitorForm.getAreaImg().Controls.SetChildIndex(marker, 10);
                                    }
                                    }

                                //draw chart
                                //DateTime now = DateTime.Now;
                                DateTime now = new DateTime(int.Parse(elements[7]), int.Parse(elements[6]), int.Parse(elements[5]), int.Parse(elements[2]), int.Parse(elements[3]), int.Parse(elements[4]));
                                    if (monitorForm.getChartMine().ChartAreas[0].AxisX.Title != "Thời gian (" + now.Hour + "h" + now.Minute + "p...s)")
                                    {
                                        monitorForm.getChartMine().ChartAreas[0].AxisX.Title = "Thời gian (" + now.Hour + "h" + now.Minute + "p...s)";
                                        monitorForm.getChartMine().Series.Clear();
                                        machine_series_mine.Clear();
                                    }
                                    if (!machine_series_mine.ContainsKey(machineId))
                                    {
                                        Series series = new Series(machineId);
                                        machine_series_mine.Add(machineId, series);
                                        monitorForm.getChartMine().Series.Add(series);
                                        monitorForm.getChartMine().Series[machineId].ChartType = SeriesChartType.Line;
                                        monitorForm.getChartMine().Series[machineId].MarkerStyle = MarkerStyle.Circle;
                                    //monitorForm.getChartMine().Series[machineId].Points.AddXY(0, 0);
                                }
                                    monitorForm.getChartMine().Series[machineId].Points.AddXY(now.Second, magnetic);
                                }));
                            }
                        }
                        else
                        {
                            Console.WriteLine("Server blocked");
                        }
                        if(timeLoopGlobal > 0)
                        {
                            Thread.Sleep(timeLoopGlobal);
                        }
                        
                    }
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(flowLayoutPanel1.ClientRectangle,
                Color.FromArgb(193, 208, 222),
                Color.FromArgb(127, 183, 235),                                                
                90F))
            {
                e.Graphics.FillRectangle(brush, flowLayoutPanel1.ClientRectangle);
            }
        }

        private void btnLogIn_EnabledChanged(object sender, EventArgs e)
        {
            if (((Button)sender).Enabled == true)
            {
                ((Button)sender).BackColor = Color.Transparent;
            }
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            monitorForm.Show();
        }

        private void MainHome_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (connected_status_session_ids.Count > 0)
            {
                //connected_status_session_ids.Remove(program_id__session_id[label_CecmId_Hide.Text]);
                //program_id__session_id.Remove(label_CecmId_Hide.Text);
                connected_status_session_ids.Clear();
                program_id__session_id.Clear();
                //program_id__ws[label_CecmId_Hide.Text].Close();
                //program_id__ws.Remove(label_CecmId_Hide.Text);
                program_id__ws.Clear();
            }
        }

        private bool CheckCamCo(int aValue, out bool isButton1Press)
        {
            // Button 1 la diem cam co, button 2 la dung de do do sau
            isButton1Press = false;
            bool isButton1 = ((aValue & 8) > 0);   // khong thay doi
            bool isButton2 = ((aValue & 2) > 0);  // sua lai
            bool isButton3 = ((aValue & 4) > 0); // sua lai
            bool isButton4 = ((aValue & 1) > 0); // khong sua

            if (isButton1)
                isButton1Press = true;

            if (isButton1 || isButton2)
                return true;
            else
                return false;
        }
    }
}
