using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1._2._4
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "я плохо учил русский язык. забываю начинать предложения с заглавной. хорошо, что можно написать программу!";
            StringBuilder sb = new StringBuilder(str);

            string[] arr = new[] { "!", "?", "."};
            

            for (int k = 0; k < sb.Length; k++)
            {
                if(k == 0)
                {
                    char f = Char.ToUpper(sb[k]);
                    sb[k] = f;
                }

                string c = sb[k].ToString();
                for (int i = 0; i < arr.Length; i++)
                {
                    string s = arr[i];
                    if (c == s)
                    {                       
                        try
                        {
                      
                            char f = Char.ToUpper(sb[k + 2]);
                            sb[k + 2] = f;
                      
                        }
                        catch (Exception)
                        {
                            break;
                        }
                       
                    }
                }
            }
            Console.WriteLine(sb);
            Console.ReadLine();
        }
    }
}
