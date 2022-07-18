using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace WebSocketClient.EncodeModule
{
    public class TestEnc
    {
        public static string convertToFullstring16(string input)
        {
            if (input != null)
            {
                if (input.Length < 13)
                {
                    for (int i = input.Length; i < 13; i++)
                    {
                        input = input + ' ';
                    }
                }
            }
            return input;
        }
        public static int[] convertstringToArrInt(string input)
        {
            char[] arr = input.ToCharArray();
            int[] arrint = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                arrint[i] = (int)arr[i];
            }
            return arrint;
        }
        public static string convetIntegerToBinary8(int input)
        {
            var temp = Convert.ToString(input, 2);
            //while (temp.Length != 8)
            while (temp.Length < 8)
            {
                temp = "0" + temp;
            }
            return temp;
        }
        public static string[] convetArrayIntegerToBinary8(int[] arr)
        {
            string[] starr = new string[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                starr[i] = TestEnc.convetIntegerToBinary8(arr[i]);
            }
            return starr;
        }
        public static string[] convertArrstringToBlock(string[] binary, int size)
        {
            var st = "";
            for (int i = 0; i < binary.Length; i++)
            {
                st += binary[i];
            }
            var lengthArr = (int)(binary.Length * 8 / size);
            string[] rs = new string[lengthArr];
            for (int i = 0; i < lengthArr; i++)
            {
                rs[i] = st.Substring(i * 4, i * 4 + 4 - i * 4);
            }
            return rs;
        }
        public static string[,] convertArrstringToMatrix(string[] binary2, int colums, int rows)
        {
            string[,] matrix = new string[rows, colums];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < colums; j++)
                {
                    matrix[i, j] = binary2[(i * colums) + j];
                }
            }
            return matrix;
        }
        public static string[,] matrixColumsChange(string[,] matrix, int col1, int col2)
        {
            //        string[][] matrixRS = new string[matrix.length][matrix[0].length];
            string[] columns1 = new string[matrix.Length];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                columns1[i] = matrix[i, col1 - 1];
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                matrix[i, col1 - 1] = matrix[i, col2 - 1];
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                matrix[i, col2 - 1] = columns1[i];
            }
            return matrix;
        }

        //Có thể lỗi
        public static void printMatrix(string[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    //console.write(matrix[i, j] + ' ');
                }
                //console.writeLine();
            }
        }
        public static string[,] transformationMatrix(string[,] matrix)
        {
            string[,] matrixTrans = new string[matrix.GetLength(1), matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrixTrans[j, i] = matrix[i, j];
                }
            }
            return matrixTrans;
        }
        public static string[] convertstringParent(string[,] matrixTrans)
        {
            string[] st = new string[2];
            st[0] = "";
            st[1] = "";
            var rowPol = (int)(matrixTrans.GetLength(0) / 2);
            for (int i = 0; i < matrixTrans.GetLength(0); i++)
            {
                for (int j = 0; j < matrixTrans.GetLength(1); j++)
                {
                    if (i < rowPol)
                    {
                        st[0] += matrixTrans[i, j];
                    }
                    else
                    {
                        st[1] += matrixTrans[i, j];
                    }
                }
            }
            return st;
        }
        public static int getRandomNumberInRange(int min, int max)
        {
            if (min >= max)
            {
                throw new ArgumentException("max must be greater than min");
            }
            var r = new Random();
            return r.Next((max - min) + 1) + min;
        }
        public static string[] convertParentToChild(string[] parent, int crossover1, int crossover2)
        {
            string[] stChild = new string[2];
            var st0part1 = parent[0].Substring(0, crossover1 - 0);
            var st0part2 = parent[0].Substring(crossover1, crossover2 - crossover1);
            var st0part3 = parent[0].Substring(crossover2, parent[0].Length - crossover2);
            var st1part1 = parent[1].Substring(0, crossover1 - 0);
            var st1part2 = parent[1].Substring(crossover1, crossover2 - crossover1);
            var st1part3 = parent[1].Substring(crossover2, parent[1].Length - crossover2);
            stChild[0] = st0part1 + st1part2 + st0part3;
            stChild[1] = st1part1 + st0part2 + st1part3;
            return stChild;
        }
        public static void printArr(string[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                //console.write(arr[i] + ' ');
            }
            //console.writeLine();
        }
        public static void printArrInt(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                //console.write(arr[i] + " ");
            }
            //console.writeLine();
        }
        public static string[] convertMutation(string[] child, int[] point1)
        {
            string[] childConvert = new string[2];
            for (int n = 0; n < 2; n++)
            {
                childConvert[n] = "";
                for (int i = 0; i < child[n].Length; i++)
                {
                    var check = false;
                    for (int j = 0; j < point1.Length; j++)
                    {
                        if (i == point1[j])
                        {
                            check = true;
                        }
                    }
                    if (check)
                    {
                        childConvert[n] += TestEnc.convertMutation(child[n][i]);
                    }
                    else
                    {
                        childConvert[n] += child[n][i];
                    }
                }
            }
            return childConvert;
        }
        //
        public static char convertMutation(char ch)
        {
            if (ch == '0')
            {
                return '1';
            }
            else
            {
                return '0';
            }
        }
        public static string[] convertItem8(string[] child)
        {
            var st = child[0] + child[1];
            string[] converted = new string[(int)(st.Length / 8)];
            for (int i = 0; i < converted.Length; i++)
            {
                converted[i] = st.Substring(i * 8, i * 8 + 8 - i * 8);
            }
            return converted;
        }

        //Có thể lỗi
        public static string convertIntArray(string[] item8, int crossPoint)
        {
            var st = "";
            for (int i = 0; i < item8.Length; i++)
            {
                var part1 = item8[i].Substring(0, 2 - 0);
                var part2 = item8[i].Substring(2, item8[i].Length - 2);
                st += (Convert.ToInt32(part1, 2).ToString("x") + ' ' + Convert.ToInt32(part2, 2).ToString("x") + ' ');
            }
            return st;
        }
        public static string hexToBin(string s)
        {
            return Convert.ToString(Convert.ToInt32(s, 16), 2);
        }
        public static string hexToBinNumberPlace(string s, int num)
        {
            var binary = TestEnc.hexToBin(s);
            while (binary.Length < num)
            {
                binary = "0" + binary;
            }
            return binary;
        }
        public static string arrToString(string[] st)
        {
            var rs = "";
            for (int i = 0; i < st.Length; i++)
            {
                rs += st[i];
            }
            return rs;
        }
        public static string[] convertArrToMutate(string[] rs)
        {
            string[] mutate = new string[2];
            mutate[0] = "";
            mutate[1] = "";
            var rowPol = (int)(rs.Length / 2);
            for (int i = 0; i < rowPol; i++)
            {
                mutate[0] += rs[i];
            }
            for (int i = rowPol; i < rs.Length; i++)
            {
                mutate[1] += rs[i];
            }
            return mutate;
        }
        public static string[,] decConvertParentToMatrix(string[] parent, int rows, int colums)
        {
            var st = parent[0] + parent[1];
            string[,] matrix = new string[rows, colums];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < colums; j++)
                {
                    matrix[i, j] = st.Substring(i * 32 + j * 4, i * 32 + j * 4 + 4 - i * 32 + j * 4);
                }
            }
            return matrix;
        }
        public static string[] convertMatrixToString(string[,] matrix)
        {
            string[] st = new string[matrix.Length * matrix.GetLength(1)];
            var n = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    st[n] = matrix[i, j];
                    n++;
                }
            }
            return st;
        }
        public static string[] convertArrToShortArr(string[] st)
        {
            string[] rs = new string[(int)(st.Length / 2)];
            for (int i = 0; i < rs.Length; i++)
            {
                rs[i] = st[i * 2] + st[i * 2 + 1];
            }
            return rs;
        }
        public static int[] convertBinaryToInt(string[] binary)
        {
            int[] rs = new int[binary.Length];
            for (int i = 0; i < rs.Length; i++)
            {
                rs[i] = Convert.ToInt32(binary[i], 2);
            }
            return rs;
        }
        public static string convertAscciToString(int[] ascci)
        {
            var st = "";
            for (int i = 0; i < ascci.Length; i++)
            {
                st += (char)ascci[i];
            }
            return st;
        }
        public static string enc(string input, int N, int crossover1, int crossover2, int[] mutation, int crossPoint, int n1, int n2)
        {
            input = TestEnc.convertToFullstring16(input);
            //console.writeLine(input);
            int[] arrintTmp = TestEnc.convertstringToArrInt(input);
            //console.writeLine("Step 1: ");
            TestEnc.printArrInt(arrintTmp);
            int[] arrint = new int[arrintTmp.Length + 3];
            for (int i = 0; i < arrintTmp.Length; i++)
            {
                arrint[i] = arrintTmp[i];
            }
            arrint[13] = 1;
            arrint[14] = 1;
            arrint[15] = 1;
            //console.writeLine("Step 2: ");
            TestEnc.printArrInt(arrint);
            string[] binary = TestEnc.convetArrayIntegerToBinary8(arrint);
            //console.writeLine("Step 3: ");
            TestEnc.printArr(binary);
            //console.writeLine("Step 4: ");
            string[] binary2 = TestEnc.convertArrstringToBlock(binary, N);
            TestEnc.printArr(binary2);
            var colums = N;
            var rows = (int)(binary2.Length / N);
            string[,] matrix = TestEnc.convertArrstringToMatrix(binary2, colums, rows);
            //console.writeLine("Step 5: Matrix");
            TestEnc.printMatrix(matrix);
            //console.writeLine("Step 6:");
            //console.writeLine("n1=" + n1 + ", n2=" + n2);
            matrix = TestEnc.matrixColumsChange(matrix, n1, n2);
            TestEnc.printMatrix(matrix);
            //console.writeLine("Step 7:");
            TestEnc.printMatrix(matrix);
            string[,] matrixTrans = TestEnc.transformationMatrix(matrix);
            //console.writeLine("Step 8:");
            TestEnc.printMatrix(matrixTrans);
            //console.writeLine("Step 9:");
            string[] parent = TestEnc.convertstringParent(matrixTrans);
            //console.writeLine("parent 1 " + parent[0]);
            //console.writeLine("parent 2 " + parent[1]);
            //console.writeLine("Step 10:");
            //console.writeLine("crossover1 " + crossover1.ToString() + " crossover2 " + crossover2.ToString());
            //console.writeLine("Step 10:");
            string[] child = TestEnc.convertParentToChild(parent, crossover1, crossover2);
            //console.writeLine("child1 " + child[0]);
            //console.writeLine("child2 " + child[1]);
            //console.writeLine("Step 11:");
            TestEnc.printArrInt(mutation);
            //console.writeLine("Step 12:");
            string[] childMutation = TestEnc.convertMutation(child, mutation);
            //console.writeLine("childMutation1 " + childMutation[0]);
            //console.writeLine("childMutation2 " + childMutation[1]);
            //console.writeLine("Step 13:");
            childMutation[0] = TestEnc.leftLogicalShift(childMutation[0]);
            childMutation[1] = TestEnc.leftLogicalShift(childMutation[1]);
            //console.writeLine("childMutation1 left logical shift" + childMutation[0]);
            //console.writeLine("childMutation2 left logical shift" + childMutation[1]);
            string[] item8 = TestEnc.convertItem8(childMutation);
            //console.writeLine("Step 14:");
            TestEnc.printArr(item8);
            //console.writeLine("Step 15:");
            //console.writeLine(crossPoint);
            //console.writeLine("Step 16:");
            var enc = TestEnc.convertIntArray(item8, crossPoint);
            //console.writeLine(enc);
            return enc;
        }
        public static string dec(string input, int N, int crossover1, int crossover2, int[] mutation, int crossPoint, int n1, int n2)
        {
            string[] st = input.Split(' ');
            string[] rs = new string[(int)(st.Length / 2)];
            for (int i = 0; i < rs.Length; i++)
            {
                rs[i] = TestEnc.hexToBinNumberPlace(st[i * 2], crossPoint) + TestEnc.hexToBinNumberPlace(st[i * 2 + 1], 8 - crossPoint);
            }
            string[] decMutate = TestEnc.convertArrToMutate(rs);
            //console.writeLine("Mutate ");
            TestEnc.printArr(decMutate);
            decMutate[0] = TestEnc.de_leftLogicalShift(decMutate[0]);
            decMutate[1] = TestEnc.de_leftLogicalShift(decMutate[1]);
            //console.writeLine("childMutation1 de left logical shift" + decMutate[0]);
            //console.writeLine("childMutation2 de left logical shift" + decMutate[1]);
            string[] decChild = TestEnc.convertMutation(decMutate, mutation);
            //console.writeLine("Child ");
            TestEnc.printArr(decChild);
            string[] parent = TestEnc.convertParentToChild(decChild, crossover1, crossover2);
            //console.writeLine("parent ");
            TestEnc.printArr(parent);
            var rows = N;
            var colums = (int)(parent[0].Length / (N * 2));
            string[,] matrix = TestEnc.decConvertParentToMatrix(parent, rows, colums);
            //console.writeLine("matrix ");
            TestEnc.printMatrix(matrix);
            string[,] matrixTrans = TestEnc.transformationMatrix(matrix);
            matrixTrans = TestEnc.matrixColumsChange(matrixTrans, n1, n2);
            //console.writeLine("matrix trans");
            TestEnc.printMatrix(matrixTrans);
            string[] arrBlock = TestEnc.convertMatrixToString(matrixTrans);
            TestEnc.printArr(arrBlock);
            string[] arrAscci = TestEnc.convertArrToShortArr(arrBlock);
            TestEnc.printArr(arrAscci);
            int[] ascciCode = TestEnc.convertBinaryToInt(arrAscci);
            TestEnc.printArrInt(ascciCode);
            var result = TestEnc.convertAscciToString(ascciCode);
            result = result.Trim();
            return result;
        }
        public static string rs_xor(string st1, string st2)
        {
            var rs = "";
            string[] arr1 = st1.Split(' ');
            string[] arr2 = st2.Split(' ');
            for (int i = 0; i < arr1.Length; i++)
            {
                rs += TestEnc.xor(arr1[i], arr2[i]);
                if (i != arr1.Length - 1)
                {
                    rs += ' ';
                }
            }
            return rs;
        }
        public static string rs_de_xor(string st1, string st2)
        {
            var rs = "";
            string[] arr1 = st1.Split(' ');
            string[] arr2 = st2.Split(' ');
            for (int i = 0; i < arr1.Length; i++)
            {
                rs += TestEnc.de_xor(arr1[i], arr2[i]);
                if (i != arr1.Length - 1)
                {
                    rs += ' ';
                }
            }
            return rs;
        }
        public static string xor(string st1, string st2)
        {
            if (st1.Equals(st2))
            {
                return "0";
            }
            else
            {
                return "1";
            }
        }
        public static string de_xor(string kq, string st2)
        {
            var st = "";
            if (kq.Equals("0") && st2.Equals("0"))
            {
                st = "0";
            }
            if (kq.Equals("0") && st2.Equals("1"))
            {
                st = "1";
            }
            if (kq.Equals("1") && st2.Equals("1"))
            {
                st = "0";
            }
            if (kq.Equals("1") && st2.Equals("0"))
            {
                st = "1";
            }
            return st;
        }
        public static string leftLogicalShift(string arr)
        {
            var st1 = arr.Substring(1, arr.Length - 1);
            var rs = st1 + arr[0].ToString();
            return rs;
        }
        public static string de_leftLogicalShift(string arr)
        {
            var st1 = arr.Substring(0, arr.Length - 1 - 0);
            var rs = arr[arr.Length - 1].ToString() + st1;
            return rs;
        }
        public static string createS(int RF, int C, int M)
        {
            var S = "";
            for (int i = 0; i < (C + M + 6); i++)
            {
                S += RF.ToString() + ' ';
            }
            return S;
        }
        public static string createPrivateKey(int N, int crossover1, int crossover2, int[] mutation, int crossPoint, int n1, int n2, int C, int M)
        {
            var S = "";
            S += (N).ToString("X") + ' ';
            S += (crossover1).ToString("X") + ' ' + (crossover2).ToString("X") + ' ';
            for (int i = 0; i < mutation.Length; i++)
            {
                S += (mutation[i]).ToString("X") + ' ';
            }
            S += (crossPoint).ToString("X") + ' ' + (n1).ToString("X") + ' ' + (n2).ToString("X") + ' ' + (C).ToString("X") + ' ' + (M).ToString("X");
            return S;
        }
        public static string hoanviRFlan(string day, int PF, int RF)
        {
            string[] arr = day.Split(' ');
            string[] arr1 = new string[arr.Length];
            for (int n = 0; n < RF; n++)
            {
                for (int i = 0; i < arr.Length - PF; i++)
                {
                    arr1[i] = arr[i + PF];
                }
                for (int i = (arr.Length - PF); i < arr.Length; i++)
                {
                    arr1[i] = arr[i - arr.Length + PF];
                }
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = arr1[i];
                }
            }
            var st1 = "";
            for (int i = 0; i < arr1.Length; i++)
            {
                //console.write(arr1[i] + ' ');
                st1 += arr1[i];
                if (i != arr1.Length - 1)
                {
                    st1 += ' ';
                }
            }
            return st1;
        }
        public static string convert2To16(string binary)
        {
            binary = binary.Replace(" ", "");
            var decimal2 = Convert.ToInt32(binary, 2);
            return (decimal2).ToString("X");
        }
        public static string createKFPublic(string KRPrivate)
        {
            string[] arr = KRPrivate.Split(' ');
            for (int i = 0; i < arr.Length; i++)
            {
                var decimal_ = Convert.ToInt32(arr[i], 16);
                var st = Convert.ToString(decimal_, 2);
                if (st.Length < 8)
                {
                    var a = "";
                    for (int r = 0; r < 8 - st.Length; r++)
                    {
                        a += "0";
                    }
                    arr[i] = a + st;
                }
            }
            for (int i = 0; i < arr.Length; i++)
            {
                var abc = arr[i];
                arr[i] = "";
                for (int j = 0; j < abc.Length; j++)
                {
                    arr[i] += abc[j];
                    if (j != abc.Length - 1)
                    {
                        arr[i] += ' ';
                    }
                }
            }
            var KFPublic = "";
            string[] rs_xor = new string[arr.Length];
            for (int i = 0; i < rs_xor.Length; i++)
            {
                rs_xor[i] = TestEnc.convert2To16(TestEnc.rs_xor(arr[i], "0 0 0 0 1 0 0 1"));
                //            System.out.print(rs_xor[i]+"   ");
                KFPublic += rs_xor[i] + "   ";
            }
            return KFPublic;
        }
    }
}
