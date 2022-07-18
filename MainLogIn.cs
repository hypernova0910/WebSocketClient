using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebSocketClient
{
    public partial class MainLogIn : Form
    {
        public static string userName, password, myIP;
        // info message send to server
        public static long donviID, duanID = 1;
        public static bool isLogin;
        ServiceResult serviceResult;
        HistoryConnectDTO historyConnectDTO;

        public MainLogIn()
        {
            InitializeComponent();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            tryLogIn();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
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

        private void HieuLogIn_Load(object sender, EventArgs e)
        {
            isLogin = false;
        }

        private static string hashPassword(string password, string salt)
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

        private void tryLogIn()
        {
            userName = txtUsername.Text;
            password = txtPassword.Text;
            bool valid = true;
            if (userName.Trim() == "")
            {
                lblUsernameValidate.Visible = true;
                valid = false;
            }
            else
            {
                lblUsernameValidate.Visible = false;
            }
            if (password.Trim() == "")
            {
                lblPasswordValidator.Visible = true;
                valid = false;
            }
            else
            {
                lblPasswordValidator.Visible = false;
            }
            if (!valid)
            {
                return;
            }

            // get password de checklogin
            string info = getUserByUsername(userName);
            if (info == "No internet")
            {
                return;
            }
            string[] lstInfo = info.Split(',');
            if (lstInfo.Length < 3)
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                donviID = 0;
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
                //Home home = new Home();
                //home.Show();
                

                string hostName = Dns.GetHostName(); // Retrive the Name of HOST  
                // Get the IP  
                myIP = Dns.GetHostByName(hostName).AddressList[0].ToString();
                isLogin = true;
                Close();

            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                donviID = 0;
            }
        }

        string getUserByUsername(string userNameI)
        {
            // get list use rs using API
            string URL = "http://" + ConfigURL.WebIP + "/vnmac-service/usersServiceRest/getbyusername2/";
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
            catch (Exception e)
            {
                MessageBox.Show("Bạn đang không có kết nối internet", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dataObjects = "No internet";
            }
            return dataObjects;
        }
    }
}
