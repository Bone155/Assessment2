using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary
{
    class Exercises
    {
        public string Reverse(string text)
        {
            char[] cArray = text.ToCharArray();
            string reverse = string.Empty;
            for (int i = cArray.Length - 1; i > -1; i--)
            {
                reverse += cArray[i];
            }
            return reverse;
        }

        public void DecToBin(uint n)
        {
            string binary = "";
            while (n >= 1)
            {
                if (n % 2 == 0)
                {
                    binary += "0";
                }
                else if (n % 2 == 1)
                {
                    binary += "1";
                }
                n /= 2;
            }
            Console.WriteLine(Reverse(binary));
        }

        public uint BinToDec(string bin)
        {
            char[] array = bin.ToCharArray();
            Array.Reverse(array);
            uint sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == '1')
                {
                    // Method uses raising 2 to the power of the index. 
                    if (i == 0)
                    {
                        sum += 1;
                    }
                    else
                    {
                        sum += (uint)Math.Pow(2, i);
                    }
                }
            }
            return sum;
        }

        public bool IsLeftMost(string value)
        {
            char[] array = value.ToCharArray();
            bool isLeft = false;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[0] >= '1')
                    isLeft = true;
            }
            return isLeft;
        }

        public bool IsRightMost(string value)
        {
            char[] array = value.ToCharArray();
            Array.Reverse(array);
            bool isRight = false;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[0] == '1')
                    isRight = true;
            }
            return isRight;
        }

        public bool IsBitSet(string value)
        {
            char[] array = value.ToCharArray();
            char[] array2 = value.ToCharArray();
            Array.Reverse(array2);
            bool isSet = false;
            for (int i = 0; i < array.Length && i < array2.Length; i++)
            {
                if (array[0] == '1' && array2[0] == '1')
                    isSet = true;
            }
            return isSet;
        }

        public uint GetRightMost(string A)
        {
            char[] array = A.ToCharArray();
            char[] array2 = A.ToCharArray();
            Array.Reverse(array);
            uint result = 0;
            for (int i = 0; i < array.Length && i < array2.Length; i++)
            {
                if (array[i] == '1' && array2[i] == '0')//A&B == B
                    result = '0';//A & B

                else if (array[i] == '0' && array2[i] == '1')
                    result = '0';

                else if (array[i] == '1' && array2[i] == '1')
                    result = '1';

                else
                    result = '0';
                
            }
            return result;
        }
    }

    class Program
    {
        static void Main()
        {
            Exercises ex = new Exercises();
            //uint.TryParse(Console.ReadLine(), out uint num);
            string bin = "10011100";
            uint number = 49;
            ex.DecToBin(number);
            Console.WriteLine();

            Console.Write(ex.BinToDec(bin));
            Console.WriteLine();
            Console.WriteLine();

            Console.Write(ex.IsLeftMost(bin));
            Console.WriteLine();
            Console.WriteLine();

            Console.Write(ex.IsRightMost(bin));
            Console.WriteLine();
            Console.WriteLine();

            Console.Write(ex.IsBitSet(bin));
            Console.WriteLine();
            Console.WriteLine();

            //Console.Write(ex.GetRightMost(bin));
            Console.WriteLine();
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
