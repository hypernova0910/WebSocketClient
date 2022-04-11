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

namespace WebSocketClient
{
    public partial class Home : Form
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
        private Dictionary<string, CecmProgramControl> program__control;
        
        public Home()
        {
            InitializeComponent();
            connected_status_session_ids = new Dictionary<string, bool>();
            program_id__session_id = new Dictionary<string, string>();
            program_id__ws = new Dictionary<string, WebSocket>();
            program__control = new Dictionary<string, CecmProgramControl>();
        }

        List<CecmProgramDTO> lstCecm;
        List<ConfigProgramDTO> lstConfig;
        WebSocket ws;
        ServiceResult serviceResult;
        HistoryConnectDTO historyConnectDTO;

        private void Home_Load(object sender, EventArgs e)
        {
            
            //Console.WriteLine("length data: " + lst.Count());
            GenControl();
            //for (int i = 0; i < lst.Count; i++)
            //{

            //    //Console.WriteLine("item: " + item.name);
            //    cecmProgramDTOBindingSource.Add(lst[i]);
            //    dataGridViewLstProgram.Rows[i].Cells[0].Value = i + 1;

            //    ////button
            //    //DataGridViewButtonColumn uninstallButtonColumn = new DataGridViewButtonColumn();
            //    //uninstallButtonColumn.Name = "btnConnect"+i;
            //    //uninstallButtonColumn.Text = "Ket noi";


            //    //dataGridViewLstProgram.Columns.Insert(3,uninstallButtonColumn);
            //    //int columnIndex = 2;
            //    //if (dataGridViewLstProgram.Columns["uninstall_column"] == null)
            //    //{
            //    //    dataGridViewSoftware.Columns.Insert(columnIndex, uninstallButtonColumn);
            //    //}

            //}



            //Console.WriteLine("login.donviID: " + Login.donviID);
        }
        private void GenControl()
        {
            
            flowLayoutPanelLstProgram.Controls.Clear();
            lstCecm = getAllCecmProgramByDeptid(Login.donviID);
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
                CecmProgramControl[] lstControl = new CecmProgramControl[countProgram];
                for(int i=0;i< countProgram; i++)
                {
                    lstControl[i] = new CecmProgramControl();
                    // set Label va Butotn
                    Label lbl = new Label();
                    lbl.Text = lstCecm[i].name;
                    //Button btn = new Button();
                    //btn.Name = "btnKetnoi" + i.ToString();
                    //btn.Text = "Ket noi";
                    //btn.BackColor = Color.Green;
                    // set user control
                    //lstControl[i].Title = lstName[i];
                    //lstControl[i].button = btn;
                    lstControl[i].label = lbl;
                    lstControl[i].name = lstCecm[i].name;
                    lstControl[i].cecmId = lstCecm[i].cecmProgramId;
                    lstControl[i].code = lstCecm[i].code;
                    lstControl[i].address = lstCecm[i].address;
                    lstControl[i].timeST = "Từ " + lstCecm[i].startTimeST + " đến " + lstCecm[i].endTimeST;
                    lstControl[i].deptName = lstCecm[i].deptName;
                    lstControl[i].stt = lstCecm[i].stt;
                    // thong tin cau hinh
                    lstControl[i].configName = (lstConfig[i].config_name != null) ? lstConfig[i].config_name : "";
                    
                    lstControl[i].configTime = lstConfig[i].time;
                    lstControl[i].configSpeed = lstConfig[i].speed;
                    lstControl[i].configIP = lstConfig[i].is_checkIPST + " ," + lstConfig[i].ip_address;
                    lstControl[i].configStatus = lstConfig[i].statusST;

                    flowLayoutPanelLstProgram.Controls.Add(lstControl[i]);
                    //lstControl[i].label.Click += new EventHandler(Label_Click);

                    program__control.Add(lstCecm[i].cecmProgramId.ToString(), lstControl[i]);
                    // 

                    lstControl[i].Click += new System.EventHandler(this.UserControl_Click);
                    //lstControl[i].button.Click += new EventHandler(UCButton_Click);
                    Console.WriteLine("222222222222: ");
                }
                // load lan dau tien thi se co san
                lbl_ProgramName.Text = lstControl[0].name;
                label_CecmId_Hide.Text = lstControl[0].cecmId.ToString();
                label_ProgramCode.Text = lstControl[0].code;
                label_DeptName.Text = lstControl[0].deptName;
                label_ProgramTime.Text = lstControl[0].timeST;
                label_ProgramStatus.Text = lstControl[0].stt;
                label_ConfigName.Text = lstControl[0].configName;
                label_ConfigTime.Text = lstControl[0].configTime;
                label_ConfigSpeed.Text = lstControl[0].configSpeed;
                label_ConfigIP.Text = lstControl[0].configIP;
                label_ConfigStatus.Text = lstControl[0].configStatus;

                CecmProgramControl.activeControl = lstControl[0];
                lstControl[0].BackColor = Color.SkyBlue;
            }
        }
        void UCButton_Click(Object sender, EventArgs e) 
        {
            //CecmProgramControl b = (CecmProgramControl)sender;

            MessageBox.Show("aaaaaaaaaaaaaaaaaaaaa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        void UserControl_Click(Object sender, EventArgs e)
        {
            this.OnClick(e);
            CecmProgramControl obj = (CecmProgramControl)sender;
            lbl_ProgramName.Text = obj.name;
            label_CecmId_Hide.Text = obj.cecmId.ToString();
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
            string URL = ConfigURL.ServerServiceUrl + "/cert-service/configProgramRsServiceRest/getOneByCecmId/";
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
			string URL = ConfigURL.ServerServiceUrl + "/vnmac-service/cecmProgramServiceRest/getallCecmProgram2/1/";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL);
            string objectST = "";
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync(deptid.ToString()).Result;
            if (response.IsSuccessStatusCode)
            {
                objectST = response.Content.ReadAsStringAsync().Result.ToString();
                lstCecmProgram = JsonConvert.DeserializeObject<List<CecmProgramDTO>>(objectST);
            }

            return lstCecmProgram;
        }
        

        private void dataGridViewLstProgram_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if(dataGridViewLstProgram.Columns[e.ColumnIndex].Name == "btnConnect")
            //if (dataGridViewLstProgram.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected)
            //{
            //        DataGridViewImageCell cell = (DataGridViewImageCell)
            //dataGridViewLstProgram.Rows[e.RowIndex].Cells[e.ColumnIndex];

            //btnConnect.Text = "Ngắt kết nối";
            //btnConnect.DefaultCellStyle.BackColor = Color.GreenYellow;

            //dataGridViewLstProgram.CurrentCell.Value = "Ngắt kết nối";
            //dataGridViewLstProgram.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "Ngat ket noi";

            if (cecmProgramDTOBindingSource1.Count > 0)
            {
                cecmProgramDTOBindingSource1.RemoveCurrent();
            }
            cecmProgramDTOBindingSource1.Add(lstCecm[e.RowIndex]);
            

            //}
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (label_CecmId_Hide.Text.IsNullOrEmpty())
            {
                MessageBox.Show("Chưa chọn dự án kết nối", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (program_id__session_id.ContainsKey(label_CecmId_Hide.Text))
            {
                MessageBox.Show("Dự án đã kết nối trước đó rồi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (!connected_status_session_ids[program_id__session_id[label_CecmId_Hide.Text]])
                {
                    MessageBox.Show("Server đã chặn gửi dữ liệu DA" + label_CecmId_Hide.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Server đã cho gửi dữ liệu DA" + label_CecmId_Hide.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                //connected_status_session_ids.Add(label_CecmId_Hide.Text, true);
                // cat chuo lay dai IP
                string[] arrIP = label_ConfigIP.Text.Split(',');
                if (arrIP.Length > 1)
                {
                    if (!arrIP[1].IsNullOrEmpty())
                    {
                        string[] lstsubIP = arrIP[1].Split('.');
                        string[] lstmysubIP = Login.myIP.Split('.');
                        //neu ok
                        if(lstsubIP[0]== lstmysubIP[0]&& lstsubIP[1] == lstmysubIP[1] && lstsubIP[2] == lstmysubIP[2])
                        {
                            // them moi historyconnect table
                            //addHistoryConnectDTO(long.Parse(label_CecmId_Hide.Text), lbl_ProgramName.Text, label_DeptName.Text, Login.userName, Login.donviID);


                            // get
                            //Thread thrd2 = new Thread(getOneHistoryConnectByID);
                            //thrd2.IsBackground = true;
                            //thrd2.Start();

                            // create websocket connect server
                            Thread thrd = new Thread(createSocket);
                            thrd.IsBackground = true;
                            thrd.Start();
                            MessageBox.Show("Kết nối thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Địa chỉ IP này không được phép truy cập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        // them moi historyconnect table
                        //addHistoryConnectDTO(long.Parse(label_CecmId_Hide.Text), lbl_ProgramName.Text, label_DeptName.Text, Login.userName, Login.donviID);


                        // get
                        //Thread thrd2 = new Thread(getOneHistoryConnectByID);
                        //thrd2.IsBackground = true;
                        //thrd2.Start();

                        // create websocket connect server
                        Thread thrd = new Thread(createSocket);
                        thrd.IsBackground = true;
                        thrd.Start();
                        MessageBox.Show("Kết nối thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            
        }
        void createSocket()
        {
            PaserPacket pPaserPacket = new PaserPacket();
            ws = new WebSocket("ws://103.101.162.83:8084/cert-web/message");
            {
                //ws.Close();

                // gui data cuoi cung o day
                string program_id = label_CecmId_Hide.Text;
                string session_id = "";
                program_id__ws.Add(program_id, ws);
                program_id__ws[program_id].OnMessage += (sender2, e2) =>
                {
                    Console.WriteLine("Data type: " + sender2.GetType());
                    Console.WriteLine("Data cuoi: " + e2.Data);
                    if (e2.Data.Contains("Deny"))
                    {
                        string[] status = e2.Data.Split(':');
                        if(status[1] == session_id)
                        {
                            program__control[program_id].getLabelProgramName().ForeColor = Color.Red;
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
                            program__control[program_id].getLabelProgramName().ForeColor = Color.Green;
                            connected_status_session_ids[status[1]] = true;
                            MessageBox.Show("Server đã cho gửi dữ liệu SID " + status[1], "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        //program_id = status[1];
                    }
                    else if (e2.Data.Contains("Open"))
                    {
                        program__control[program_id].getLabelProgramName().ForeColor = Color.Green;
                        string[] status = e2.Data.Split(':');
                        session_id = status[1];
                        connected_status_session_ids.Add(session_id, true);
                        program_id__session_id.Add(program_id, session_id);
                        Console.WriteLine("session_id: " + session_id);
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
                Thread.Sleep(100);
                //ws.Send("InfoClinet;" + Login.userName + ";" + historyConnectDTO.deptidST + ";" + historyConnectDTO.cecm_program_idST + ";" + DateTime.Now.ToString("dd'-'MM'-'yyyy'T'HH':'mm':'ss"));
                program_id__ws[program_id].Send("InfoClinet;;;" + Login.userName + ";;;" + label_DeptName.Text + ";;;" + label_CecmId_Hide.Text + ";;;" + lbl_ProgramName.Text + ";;;" + DateTime.Now.ToString("HH:mm:ss dd-MM-yyyy") + ";;;" + session_id + ";;;" + Login.donviID);

                string[] lines = System.IO.File.ReadAllLines(@"..\..\..\cvmine.txt");

                // Display the file contents by using a foreach loop.
                Console.WriteLine("Sendata to server");
                Console.WriteLine("Total: " + lines.Length);

                int i = 1;
                bool isClose = false;
                bool isCloseAuto = false;
                Thread.Sleep(100);
                Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
                DateTime start = DateTime.Now;
                double timeLast;
                if(double.TryParse(label_ConfigTime.Text, out timeLast))
                {
                    timeLast *= 60;
                }
                else
                {
                    timeLast = 120;
                }
                double timeLoopTmp;
                int timeLoop;
                Console.WriteLine("label_ConfigSpeed.Text: " + label_ConfigSpeed.Text);
                if(double.TryParse(label_ConfigSpeed.Text, out timeLoopTmp))
                {
                    timeLoop = (int)(timeLoopTmp * 1000);
                }
                else
                {
                    timeLoop = 5000;
                }
                Console.WriteLine("timeLoop: " + timeLoop);
                Console.WriteLine("timeLast: " + timeLast);
                while (!isClose)
                {
                    //Console.WriteLine("In the loop");
                    foreach (string line in lines)
                    {
                        if((DateTime.Now - start).TotalSeconds > timeLast)
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
                        if (connected_status_session_ids[session_id])
                        {
                            //Console.WriteLine("Success");
                            string strCv = ConvertToGoole(line);

                            if (strCv == string.Empty)
                            {
                                program_id__ws[program_id].Send(line);
                            }
                            else
                            {
                                program_id__ws[program_id].Send(strCv);
                                string[] strTmp = strCv.Split(',');
                                addInfoConnectDTO(Login.userName, Login.myIP, "MD1GPS", strTmp[1], strTmp[9] + "; " + strTmp[11], "00");
                                Console.WriteLine("\tData send " + i + ":" + strCv);
                                i++;
                            }
                        }
                        //ws.Send(userName);
                        //ws.Send(password);
                        // Use a tab to indent each line of the file.
                        // + "," + userName + "," + password
                        else
                        {
                            Console.WriteLine("Server blocked");
                        }


                        Thread.Sleep(timeLoop);
                        //ws.Close();
                    }
                }
                Console.WriteLine("End");
                //Close do tự động hết thời gian truyền
                if (isCloseAuto)
                {
                    program__control[program_id].getLabelProgramName().ForeColor = Color.Black;
                    connected_status_session_ids.Remove(program_id__session_id[program_id]);
                    program_id__session_id.Remove(program_id);
                    //ws.Close();
                    program_id__ws[program_id].Close();
                    program_id__ws.Remove(program_id);
                    MessageBox.Show("Hết thời gian truyền tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                //Console.ReadKey(true);
            }
        }
        void getOneHistoryConnectByID()
        {
            string URL_2 = ConfigURL.ServerServiceUrl + "/cert-service/historyConnectRsServiceRest/getOneById/";
            string gid = serviceResult.id.ToString();
            string historyConnectST = "";
            HttpClient client2 = new HttpClient();
            client2.BaseAddress = new Uri(URL_2);
            client2.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response2 = client2.GetAsync(gid).Result;
            if (response2.IsSuccessStatusCode)
            {
                historyConnectST = response2.Content.ReadAsStringAsync().Result.ToString();
                historyConnectDTO = JsonConvert.DeserializeObject<HistoryConnectDTO>(historyConnectST);
                //Console.WriteLine("historyConnectDTO: " + historyConnectDTO.time_startST);
            }
        }
        void addHistoryConnectDTO(long program_id, string programName, string deptname, string usernameI, long deptID)
        {
            // call api add history table
            DateTime now = DateTime.Now.AddHours(-7);
            string datenow = now.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss");
            Console.WriteLine("DateTime.Now.ToString: " + datenow);

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(ConfigURL.ServerServiceUrl + "/cert-service/historyConnectRsServiceRest/addDTO/");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = new JavaScriptSerializer().Serialize(new
                {
                    cecm_program_id = program_id,
                    cecm_program_name = programName,
                    dept_name = deptname,
                    username = usernameI,
                    deptid = deptID,
                    time_start = datenow,
                    time_end = datenow
                });
                streamWriter.Write(json);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                serviceResult = JsonConvert.DeserializeObject<ServiceResult>(result);  // them list neu nhieu servieresult list<lastKnownPosition>>
            }
        }

        void addInfoConnectDTO(string usernameI, string IP,string COMMAND, string Magnetic, string GPS, string Corner)
        {
            // call api add history table
            string datenow = DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss");
            Console.WriteLine("DateTime.Now.ToString: " + datenow);

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(ConfigURL.ServerMongoUrl + "/addObj");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = new JavaScriptSerializer().Serialize(new
                {
                    cecm_program_name = lbl_ProgramName.Text,
                    username = usernameI,
                    ip = IP,
                    command = COMMAND,
                    magnetic = Magnetic,
                    gps = GPS,
                    corner = Corner,
                    time_start = datenow
                });
                streamWriter.Write(json);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                Console.WriteLine("result add: " + result);
            }
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            //ws.Send("Close:" + program_id__session_id[label_CecmId_Hide.Text]);
            //Thread.Sleep(100);
            program__control[label_CecmId_Hide.Text].getLabelProgramName().ForeColor = Color.Black;
            if (program_id__session_id.ContainsKey(label_CecmId_Hide.Text))
            {
                connected_status_session_ids.Remove(program_id__session_id[label_CecmId_Hide.Text]);
                program_id__session_id.Remove(label_CecmId_Hide.Text);
                //ws.Close();
                program_id__ws[label_CecmId_Hide.Text].Close();
                program_id__ws.Remove(label_CecmId_Hide.Text);
                MessageBox.Show("Ngắt kết nối", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //updateHistoryConnectDTO(DateTime.Now.AddHours(-7));


                Console.WriteLine("Closed websocket!!");
            }
            else
            {
                MessageBox.Show("Dự án chưa kết nối", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //connected_status_session_ids.Remove(label_CecmId_Hide.Text);
            // get one by id
            //getOneHistoryConnectByID();


            // udpate by id

            //this.Close();
        }

        private void Ws_OnClose(object sender, CloseEventArgs e)
        {
            throw new NotImplementedException();
        }

        void updateHistoryConnectDTO(DateTime timeEnd)
        {
            string datetimeClose = timeEnd.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss");
            Console.WriteLine("datetimeClose: " + datetimeClose);
            string time_startSTtmp = historyConnectDTO.time_startST;
            string[] lstTmp = time_startSTtmp.Split(' ');
            time_startSTtmp = lstTmp[0] + "T" + lstTmp[1];
            Console.WriteLine("time_startSTtmp: " + time_startSTtmp);

            var httpWebRequestUpdate = (HttpWebRequest)WebRequest.Create(ConfigURL.ServerServiceUrl + "/cert-service/historyConnectRsServiceRest/updateBO/");
            httpWebRequestUpdate.ContentType = "application/json";
            httpWebRequestUpdate.Method = "POST";
            using (var streamWriter = new StreamWriter(httpWebRequestUpdate.GetRequestStream()))
            {
                string json = new JavaScriptSerializer().Serialize(new
                {
                    gid = historyConnectDTO.gid,
                    cecm_program_id = historyConnectDTO.cecm_program_id,
                    cecm_program_code = historyConnectDTO.cecm_program_code,
                    cecm_program_name = lbl_ProgramName.Text,
                    username = historyConnectDTO.username,
                    deptid = historyConnectDTO.deptid,
                    dept_name = label_DeptName.Text,
                    dept_address = historyConnectDTO.dept_address,
                    dept_email = historyConnectDTO.dept_email,
                    dept_phone = historyConnectDTO.dept_phone,
                    time_start = time_startSTtmp,
                    time_end = datetimeClose  // quan trong la update cai nay nay
                }); ;
                streamWriter.Write(json);
            }

            var httpResponseUpdate = (HttpWebResponse)httpWebRequestUpdate.GetResponse();
            using (var streamReader = new StreamReader(httpResponseUpdate.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                //serviceResult = JsonConvert.DeserializeObject<ServiceResult>(result);  // them list neu nhieu servieresult list<lastKnownPosition>>
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            foreach(KeyValuePair<string, WebSocket> pair in program_id__ws)
            {
                pair.Value.Close();
            }
            program_id__session_id.Clear();
            program_id__ws.Clear();
            connected_status_session_ids.Clear();
            program__control.Clear();
            Login signin = new Login();
            signin.Show();
        }
    }
}
