using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System;
using WebSocketSharp;
using System.Threading;
using System.Windows.Forms;
using System.Globalization;

namespace WebSocketClient
{
    class Program
    {
        const byte SYNC = 51;
        const byte CMD_LOGIN = 1;
        const byte CMD_LOGOUT = 2;
        static byte[] GetIPAddressLocalConnected()
        {
            byte[] ipLocal = new byte[4];            
            ipLocal[0] = 192; ipLocal[1] = 168; ipLocal[2] = 0; ipLocal[3] = 112;
            return ipLocal;
        }
        static byte[] GetIPAddressServerConnected()
        {
            byte[] ipServer = new byte[4];
            ipServer[0] = 192; ipServer[1] = 168; ipServer[2] = 0; ipServer[3] = 10;
            return ipServer;
        }
        static void SendCMDLogin(WebSocket ws, PaserPacket pPaserPacket,string strUser,string strPass)
        {
            // frame format open file
            // 0x33 SYNC
            // 192.168.0.114 source address
            // 192.168.0.215 dest address
            // 1 CMD_SELECT_LOGIN 
            // size array
            // size string unicode USER
            // data string unicode USER
            // size string unicode PASS
            // data string unicode PASS
            // check sum
            byte[] arrByteUser = Encoding.Unicode.GetBytes(strUser);
            byte sizeStrUser = (byte)(arrByteUser.Length);

            byte[] arrBytePass = Encoding.Unicode.GetBytes(strPass);
            byte sizeStrPass = (byte)(arrBytePass.Length);
            byte sizeArray = (byte)(1 + sizeStrUser + 1 + sizeStrPass);
            byte sizeMess = (byte)(1 + 4 + 4 + 1 + 1 + sizeArray + 1);

            byte[] strBuff = new byte[sizeMess];
            byte i, checksum = 0;
            byte[] ipLocal = GetIPAddressLocalConnected();
            byte[] ipServer= GetIPAddressServerConnected();
            
            //GetIPAddressConnected(ipLocal, ipServer);
            strBuff[0] = SYNC;
            strBuff[1] = ipLocal[0];
            strBuff[2] = ipLocal[1];
            strBuff[3] = ipLocal[2];
            strBuff[4] = ipLocal[3];
            strBuff[5] = ipServer[0];
            strBuff[6] = ipServer[1];
            strBuff[7] = ipServer[2];
            strBuff[8] = ipServer[3];
            strBuff[9] = CMD_LOGIN;
            strBuff[10] = sizeArray;
            strBuff[11] = sizeStrUser;

            Array.Copy(arrByteUser, 0, strBuff, 12, sizeStrUser);            
            //::memcpy(strBuff + 12, pUser, sizeStrUser);
            i = (byte)(11 + sizeStrUser + 1);
            strBuff[i] = sizeStrPass;
            i++;

            Array.Copy(arrBytePass, 0, strBuff, i, sizeStrPass);
            //::memcpy(strBuff + i, pPass, sizeStrPass);
            i += sizeStrPass;

            for (byte j = 1; j < i; j++)
                checksum ^= strBuff[j];
            strBuff[i] = checksum;
            i++;
            ws.Send(strBuff);
            // test paser
            PaserPacket(pPaserPacket,strBuff);

            Array.Clear(strBuff, 0, i);            
        }
        static void SendCMDLogOut(WebSocket ws, PaserPacket pPaserPacket)
        {
            // frame format close file
            // 0x33 SYNC
            // 192.168.0.114 source address
            // 192.168.0.215 dest address
            // 2 CMD_LOGOUT 
            // 0 size array
            // check sum
            byte sizeArray = 0;
            byte sizeMess = (byte)(1 + 4 + 4 + 1 + sizeArray + 2);
            byte[] strBuff = new byte[sizeMess];
            byte i, checksum = 0;
            byte[] ipLocal = GetIPAddressLocalConnected();
            byte[] ipServer = GetIPAddressServerConnected();
            //GetIPAddressConnected(ipLocal, ipServer);
            strBuff[0] = SYNC;
            strBuff[1] = ipLocal[0];
            strBuff[2] = ipLocal[1];
            strBuff[3] = ipLocal[2];
            strBuff[4] = ipLocal[3];
            strBuff[5] = ipServer[0];
            strBuff[6] = ipServer[1];
            strBuff[7] = ipServer[2];
            strBuff[8] = ipServer[3];
            strBuff[9] = CMD_LOGOUT;
            strBuff[10] = 0;
            i = 10;
            for (byte j = 1; j <= i; j++)
                checksum ^= strBuff[j];
            i++;
            strBuff[i] = checksum;
            i++;
            ws.Send(strBuff);
            // test paser
            PaserPacket(pPaserPacket,strBuff);

            Array.Clear(strBuff, 0, i);
        }
        static void PaserPacket(PaserPacket pPaserPacket, byte[] data)
        {
            
            for (int i = 0; i < data.Length; i++)
                pPaserPacket.FSAPascer(data[i]);
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
       static string ConvertToGoole(string str)
        {
            // !MDGPS,11508,17,0,27,12,3,17,A,2102.417724,N,10547.533203,E,0.275948,0.000000,0.000000,225,*26:
            string strRet=string.Empty;
            if (str.Length < 6)
                return strRet;
            if(str.Substring(0,6)== "!MDGPS")
            {
                int[] vecArr = new int[str.Length];
                int k = 0;
                for(int i=0;i< str.Length;i++)
                {
                    if (str[i] == ',')
                    {
                        vecArr[k] = i;k++;
                    }
                }
                // get string 
                string strLat = str.Substring(vecArr[8]+1, vecArr[9] - vecArr[8]-1);
                float latGPS = 0.0f;
                if (!float.TryParse(strLat, out latGPS))
                    return strRet;
                string strLong = str.Substring(vecArr[10] + 1, vecArr[11] - vecArr[10] - 1);
                float longGPS = 0.0f;
                if (!float.TryParse(strLong, out longGPS))
                    return strRet;
                float latGoogle=0.0f,longGoogle=0.0f;
                ConvertToGoogle(latGPS,'N',longGPS,'E', ref latGoogle, ref longGoogle);
                strRet = str.Substring(0, vecArr[8]+1) + latGoogle.ToString() + ",N," + longGoogle.ToString() + str.Substring(vecArr[11]);

            }
            return strRet;
        }

        [STAThread]
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Home());
            Application.Run(new MainHome());
            //Application.Run(new Form1());

        }
    }
}
