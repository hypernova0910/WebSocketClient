using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebSocketSharp;
using System.Windows.Forms;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace WebSocketClient
{
    public partial class Login : Form
    {

        public Login()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }
        //public Login(long donvi)
        //{
        //    donviID = donvi;
        //}

        public static string userName, password, myIP;
        // info message send to server
        public static long donviID, duanID = 1;
        WebSocket ws;
        ServiceResult serviceResult;
        HistoryConnectDTO historyConnectDTO;
        


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


        public static string hashPassword(string password, string salt)
        {
            if (salt == null)
            {
                salt = "";
            }
            string str = password + salt;
            try
            {
                HashAlgorithm sha256 = SHA256.Create();

                byte[] passBytes = Encoding.Default.GetBytes(str);
                byte[] passHash = sha256.ComputeHash(passBytes);
                //char[] charHash = Hex.encodeHex(passHash);
                str = BitConverter.ToString(passHash).Replace("-", "");
                //str = new String(charHash);
            }
            catch (Exception e)
            {
                return null;
            }
            return str;
        }
        private void btnConnect_Click(object sender, EventArgs e)
        {

            tryLogIn();
        }

        private void tryLogIn()
        {
            userName = txtUsername.Text;
            password = txtPassword.Text;
            bool valid = true;
            if (userName.Trim() == "")
            {
                nameValidator.Visible = true;
                valid = false;
            }
            else
            {
                nameValidator.Visible = false;
            }
            if (password.Trim() == "")
            {
                passwordValidator.Visible = true;
                valid = false;
            }
            else
            {
                passwordValidator.Visible = false;
            }
            if (!valid)
            {
                return;
            }

            // get password de checklogin
            string[] lstInfo = getUserByUsername(userName).Split(',');
            if(lstInfo.Length < 3)
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string userpassword = lstInfo[0];
            string usersalt = lstInfo[1];
            long dept_id = long.Parse(lstInfo[2]);
            donviID = dept_id;
            Console.WriteLine("password truoc: " + password);
            password = hashPassword(password, usersalt);
            password = password.ToLower();

            if (password.Equals(userpassword))
            {
                Home home = new Home();
                home.Show();
                this.Hide();

                //// them moi historyconnect table
                //addHistoryConnectDTO(1, userName, dept_id);

                ////view list cecmprogram for Home form


                //// get
                //Thread thrd2 = new Thread(getOneHistoryConnectByID);
                //thrd2.IsBackground = true;
                //thrd2.Start();

                //// create websocket connect server
                //Thread thrd = new Thread(createSocket);
                //thrd.IsBackground = true;
                //thrd.Start();

                string hostName = Dns.GetHostName(); // Retrive the Name of HOST  
                // Get the IP  
                myIP = Dns.GetHostByName(hostName).AddressList[0].ToString();


            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        void addHistoryConnectDTO(long program_id, string usernameI,long deptID)
        {
            // call api add history table
            string datenow = DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss");
            Console.WriteLine("DateTime.Now.ToString: " + datenow);

            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:8084/cert-service/historyConnectRsServiceRest/addDTO/");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = new JavaScriptSerializer().Serialize(new
                {
                    cecm_program_id = program_id,
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

        string getUserByUsername(string userNameI)
        {
            // get list use rs using API
            string URL = ConfigURL.ServerServiceUrl + "/cert-service/usersServiceRest/getbyusername2/";
            string urlParameters = userNameI;
            string dataObjects = "";

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL);

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));

            // List data response.
            try
            {
                HttpResponseMessage response = client.GetAsync(urlParameters).Result;
                if (response.IsSuccessStatusCode)
                {
                    dataObjects = response.Content.ReadAsStringAsync().Result;
                    Console.WriteLine("Tinhhh: " + dataObjects.ToString());
                }
                else
                {
                    Console.WriteLine("TT{0} (II{1})", (int)response.StatusCode, response.ReasonPhrase);
                }
                client.Dispose();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return dataObjects;
        }

        private void btnCloseLogin_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                tryLogIn();
                //e.SuppressKeyPress = true;
                //e.Handled = true;
                txtUsername.Text = "";
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tryLogIn();
                //e.SuppressKeyPress = true;
                //e.Handled = true;
                txtPassword.Text = "";
            }
        }

        //void createSocket()
        //{
        //    PaserPacket pPaserPacket = new PaserPacket();
        //    //ws = new WebSocket("ws://103.101.161.76:8084/prc-web/message");
        //    //ws = new WebSocket("ws://10.10.10.4:3000/cert-web/message");
        //    ws = new WebSocket("ws://127.0.0.1:8084/cert-web/message");
        //    {
        //        //ws.Close();

        //        // gui data cuoi cung o day
        //        ws.OnMessage += (sender2, e2) =>
        //        {
        //            Console.WriteLine("Data type: " + sender2.GetType());
        //            Console.WriteLine("Data cuoi: " + e2.Data);
        //        };
        //        ws.Connect();
        //        ws.Send("Connected");
        //        ws.Send("InfoClinet;" + userName + ";" + historyConnectDTO.deptidST + ";" + historyConnectDTO.cecm_program_idST + ";" + DateTime.Now.ToString("dd'-'MM'-'yyyy'T'HH':'mm':'ss"));
        //        //while(true){
        //        //    string st = Console.ReadLine();
        //        //    ws.Send(st);
        //        //}
        //        //for (int i = 0; i < 100; i++)
        //        //{
        //        //    Console.WriteLine("Sleep for 2 seconds. "+i);
        //        //    ws.Send("xin chao "+i);
        //        //    Thread.Sleep(2000);
        //        //}
        //        //byte[] strBuff = new byte[20];
        //        //strBuff[0] = 1;
        //        //ws.Send(strBuff);
        //        // SendCMDLogin(ws, pPaserPacket, "Adim", "12345abc");
        //        // SendCMDLogin(ws, pPaserPacket,"Adim","12345abc");

        //        //string[] lines = System.IO.File.ReadAllLines(@"C:\Users\cvhuy\AppData\Roaming\Semtech\PicoGW_UI\LOG\PicoGw_Stats_16-11-2018_17_56.csv");
        //        //"E:\Detai2019\DataLog\emap_log.txt"
        //        //string[] lines = System.IO.File.ReadAllLines(@"E:\Detai2019\DataLog\emap_log.txt");
        //        string[] lines = System.IO.File.ReadAllLines(@"..\..\..\cvmine.txt");

        //        // Display the file contents by using a foreach loop.
        //        Console.WriteLine("Sendata to server");
        //        Console.WriteLine("Total: " + lines.Length);
        //        int i = 1;
        //        while (true)
        //        {
        //            foreach (string line in lines)
        //            {
        //                //ws.Send(userName);
        //                //ws.Send(password);
        //                // Use a tab to indent each line of the file.
        //                // + "," + userName + "," + password
        //                string strCv = ConvertToGoole(line);

        //                if (strCv == string.Empty)
        //                {
        //                    ws.Send(line);
        //                }
        //                else
        //                {
        //                    ws.Send(strCv);
        //                    Console.WriteLine("\tData send " + i + ":" + strCv);
        //                    i++;
        //                }


        //                Thread.Sleep(5000);
        //                //ws.Close();
        //            }
        //        }
        //        Console.ReadKey(true);
        //    }
        //}

        //class ServiceResult
        //{
        //    public long id { get; set; }
        //    public string error { get; set; }
        //    public string errorType { get; set; }
        //    public string constraintName { get; set; }
        //    public bool hasError { get; set; }
        //}
        //class HistoryConnectDTO
        //{
        //    public string defaultSortField { get; set; }
        //    public long gid { get; set; }
        //    public long cecm_program_id { get; set; }
        //    public string cecm_program_idST { get; set; }
        //    public string cecm_program_code { get; set; }
        //    public string username { get; set; }
        //    public string deptid { get; set; }
        //    public string deptidST { get; set; }
        //    public string dept_address { get; set; }
        //    public string dept_email { get; set; }
        //    public string dept_phone { get; set; }
        //    public string dept_manager { get; set; }
        //    public string dept_managerST { get; set; }
        //    public string status { get; set; }
        //    public string statusST { get; set; }
        //    public string time_start { get; set; }
        //    public string time_startST { get; set; }
        //    public string time_end { get; set; }
        //    public string time_endST { get; set; }
        //    public long fwmodelId { get; set; }
        //}

        private void btnClose_Click(object sender, EventArgs e)
        {
            ws.Close();
            // get one by id
            //getOneHistoryConnectByID();


            // udpate by id
            updateHistoryConnectDTO();


            Console.WriteLine("Closed websocket!!");
            this.Close();
        }

        void getOneHistoryConnectByID()
        {
            string URL_2 = "http://localhost:8084/cert-service/historyConnectRsServiceRest/getOneById/";
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

        void updateHistoryConnectDTO()
        {
            string datetimeClose = DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss");
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
                    username = historyConnectDTO.username,
                    deptid = historyConnectDTO.deptid,
                    dept_address = historyConnectDTO.dept_address,
                    dept_email = historyConnectDTO.dept_email,
                    dept_phone = historyConnectDTO.dept_phone,
                    time_start = time_startSTtmp,
                    time_end = datetimeClose  // quan trong la update cai nay nay
                });
                streamWriter.Write(json);
            }

            var httpResponseUpdate = (HttpWebResponse)httpWebRequestUpdate.GetResponse();
            using (var streamReader = new StreamReader(httpResponseUpdate.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                //serviceResult = JsonConvert.DeserializeObject<ServiceResult>(result);  // them list neu nhieu servieresult list<lastKnownPosition>>
            }
        }

    }
}
