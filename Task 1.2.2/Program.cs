using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1._2._2
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "написать программу, которая";
            string str2 = "описание";

            StringBuilder sb = new StringBuilder(str);
            StringBuilder sb2 = new StringBuilder(str2);
            int z = 0;
            int i = 0;
            for (; i < sb.Length; i++)
            {
                for (int j = 0; j < sb2.Length; j++)
                {
                    if(sb[i] == sb2[j])
                    {
                        string s = sb[i].ToString();
                        sb.Insert(i, s, 1);
                        i++;
                        break;                       
                    }                    
                }
            }
            Console.WriteLine(sb);
            Console.ReadKey();
        }       
    }
}
