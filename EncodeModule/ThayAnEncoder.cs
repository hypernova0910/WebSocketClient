using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSocketClient.EncodeModule
{
    class ThayAnEncoder
    {
        int N;
        int n1;
        int n2;
        int crossover1;
        int crossover2;
        int[] mutation;
        int crossPoint;

        private int splitCount = 8;

        public ThayAnEncoder()
        {
            N = 4;
            n1 = 1;
            n2 = 2;
            crossover1 = 15;
            crossover2 = 23;
            mutation = new int[] { 12, 10, 2, 17 };
            crossPoint = 2;
        }

        public List<string> encrypt(string encrypted)
        {
            IEnumerable<string> lst = Split(encrypted, splitCount);
            List<string> encryptThayAn = new List<string>();
            N = 4;
            n1 = 1;
            n2 = 2;
            crossover1 = 15;
            crossover2 = 23;
            mutation = new int[]{ 12, 10, 2, 17 };
            crossPoint = 2;
            foreach (string s in lst)
            {
                //Console.WriteLine(s);
                encryptThayAn.Add(TestEnc.enc(s, N, crossover1, crossover2, mutation, crossPoint, n1, n2));
            }
            return encryptThayAn;
        }

        private IEnumerable<string> Split(string str, int chunkSize)
        {
            return Enumerable.Range(0, str.Length / chunkSize)
            .Select(i => str.Substring(i * chunkSize, chunkSize));
        }
    }
}
