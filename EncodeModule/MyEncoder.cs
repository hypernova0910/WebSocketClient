using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSocketClient.EncodeModule
{
    class MyEncoder
    {
        public static List<string> encrypt(string original)
        {
            //Layer 1
            AESEncoder aesEncoder = new AESEncoder();
            string encodeAES = aesEncoder.EncryptStringToBytes_Aes(original);
            Console.WriteLine("Ma hoa tang 1");
            Console.WriteLine(encodeAES);

            //Layer 2
            ThayAnEncoder thayAnEncoder = new ThayAnEncoder();
            List<string> encodeThayAn = thayAnEncoder.encrypt(encodeAES);
            Console.WriteLine("Ma hoa tang 2");
            Console.WriteLine(encodeThayAn);

            return encodeThayAn;
        }
    }
}
