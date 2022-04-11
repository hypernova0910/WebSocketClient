using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSocketClient
{
    class PaserPacket
    {
        const byte FSA_INIT = 0;
        const byte FSA_ADDRESS_SOURCE = 1;
        const byte FSA_ADDRESS_DEST = 2;
        const byte FSA_COMMAND = 3;
        const byte FSA_DATASIZE = 4;
        const byte FSA_DATA = 5;
        const byte FSA_CHKSUM = 6;

        const byte SYNC = 51;
        const byte CS_MAX_DATA = 255;
        // time out next state
        const byte RECV_TIMEOUT = 10;
        // commands
        const byte CMD_LOGIN = 1;
        const byte CMD_LOGOUT = 2;
        // private variables
        private byte com_recv_state, com_recv_timer, com_recv_chksum, com_recv_ctr, com_recv_complete;
        private byte[] com_recv_buff = new byte[CS_MAX_DATA];
        public PaserPacket()
        {
            com_recv_timer = 0;
            com_recv_state = FSA_INIT;
        }
        public void HandleTimeOut_1ms()
        {
            if (com_recv_timer > 0)
            {
                com_recv_timer--;
                if (com_recv_timer==0)
                    com_recv_state = FSA_INIT;
            }
        }
        public virtual void OnLogin(string mUser, string mPass,byte address0, byte address1, byte address2, byte address3)
        {
            string mess = string.Format(">CMD_SELECT_LOGIN: USER({0}) PASS({1}) - ({2}.{3}.{4}.{5})\r\n", mUser, mPass, address0, address1, address2, address3);
            Console.Write(mess);
        }
        public virtual void OnLogOut(byte address0, byte address1, byte address2, byte address3)
        {
            Console.Write(">LOGOUT - ({0}.{1}.{2}.{3})\r\n",address0,address1,address2,address3);
        }
        public void FSAPascer(byte data)
        {
            switch (com_recv_state)
            {
                case FSA_INIT:
                    if (data == SYNC)
                    {
                        com_recv_state = FSA_ADDRESS_SOURCE;
                        com_recv_timer = RECV_TIMEOUT;
                        com_recv_chksum = 0;
                        com_recv_ctr = 0;
                    }
                    break;
                case FSA_ADDRESS_SOURCE:
                    {
                        com_recv_timer = RECV_TIMEOUT;
                        com_recv_chksum ^= data;
                        com_recv_buff[com_recv_ctr] = data; // store source address
                        com_recv_ctr++;
                        if (com_recv_ctr > 3)
                            com_recv_state = FSA_ADDRESS_DEST;
                    }
                    break;
                case FSA_ADDRESS_DEST:
                    {
                        com_recv_timer = RECV_TIMEOUT;
                        com_recv_chksum ^= data;
                        com_recv_buff[com_recv_ctr] = data; // store source address
                        com_recv_ctr++;
                        if (com_recv_ctr > 7)
                            com_recv_state = FSA_COMMAND;
                    }
                    break;
                case FSA_COMMAND:
                    {
                        com_recv_state = FSA_DATASIZE;
                        com_recv_timer = RECV_TIMEOUT;
                        com_recv_chksum ^= data;
                        com_recv_buff[com_recv_ctr] = data; // store ID command
                        com_recv_ctr++;
                    }
                    break;
                case FSA_DATASIZE:
                    {
                        com_recv_chksum ^= data;
                        com_recv_buff[com_recv_ctr] = data; // store data size
                        com_recv_ctr++;
                        if (data > 0 && data <= CS_MAX_DATA)
                            com_recv_state = FSA_DATA;
                        else if (data == 0)
                            com_recv_state = FSA_CHKSUM;
                        else
                        {
                            com_recv_state = FSA_INIT; // off time out
                            com_recv_timer = 0;
                        }
                        com_recv_timer = RECV_TIMEOUT;
                    }
                    break;
                case FSA_DATA:
                    {
                        com_recv_chksum ^= data;
                        com_recv_buff[com_recv_ctr] = data;
                        com_recv_ctr++;
                        if ((com_recv_ctr - 10) == com_recv_buff[9])
                            com_recv_state = FSA_CHKSUM;
                        com_recv_timer = RECV_TIMEOUT;
                    }
                    break;
                case FSA_CHKSUM:
                    {
                        if (com_recv_chksum == data)
                        {
                            com_recv_complete = 1;
                            switch (com_recv_buff[8])
                            {
                                case CMD_LOGOUT:
                                    {
                                        //printf("EXIT_PROGRAM");
                                        OnLogOut(com_recv_buff[0], com_recv_buff[1], com_recv_buff[2], com_recv_buff[3]);                                        
                                        break;
                                    }
                                case CMD_LOGIN:
                                    {
                                        // frame format login
                                        // 0x33 SYNC
                                        // 192.168.0.114 source address
                                        // 192.168.0.215 dest address
                                        // 0x05 CMD_SELECT_LOGIN 
                                        // size array
                                        // size string unicode USER
                                        // data string unicode USER
                                        // size string unicode PASS
                                        // data string unicode PASS
                                        // check sum

                                        //printf("CMD_SELECT_LOGIN");                                        
                                        // user
                                        byte strSize = com_recv_buff[10];
                                        byte[] strUser = new byte[strSize];
                                        Array.Copy(com_recv_buff, 11, strUser, 0, strSize);                                        
                                        string mUser = Encoding.Unicode.GetString(strUser);
                                        // pass
                                        strSize = com_recv_buff[11 + com_recv_buff[10]];
                                        byte[] strPass = new byte[strSize];
                                        Array.Copy(com_recv_buff, 11 + com_recv_buff[10] + 1, strPass, 0, strSize);                                        
                                        string mPass = Encoding.Unicode.GetString(strPass);
                                        OnLogin(mUser, mPass,com_recv_buff[0], com_recv_buff[1], com_recv_buff[2], com_recv_buff[3]);                                      
                                        break;
                                    }
                            }
                        }
                        com_recv_timer = 0;
                        com_recv_state = FSA_INIT;
                    }
                    break;
                default:
                    com_recv_timer = 0;
                    com_recv_state = FSA_INIT;
                    break;
            }

        }
    }
}
    
