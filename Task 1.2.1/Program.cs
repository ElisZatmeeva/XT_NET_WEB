using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Task_1._2._1
{
    class Program
    {
        

        static void Main(string[] args)
        {
            StrParsing();           
        }

        static string StrParsing() {            
            string str = "Викентий хорошо отметил день рождения: покушал пиццу, посмотрел кино, пообщался со студентами в чате";

            string[] arr = new[] { "!", "?", ".", ",", ":", ";", "-" };

           for (int i = 0; i < arr.Length; i++)
            {
                str = str.Replace(arr[i], "");
            }
            GetSumAvg(str);
            return str;
        }
            static double GetSumAvg(string str) {
                double sum = 0;
                double sumAvg;   // Средние значения округляются до следующего числа от нуля. 
                                 //Например, 3,75 округляется до 3,8, -3,75 округляются до-3,8.

                int j = 0;
                string[] words = str.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string s in words) {
                    string str2 = s;
                    sum += str2.Length;
                   /* System.Console.WriteLine("Длина слова {0} равна {1} ", str2, str2.Length);*/
                    j++;
                }
                sumAvg = Math.Round((sum / j), 1, MidpointRounding.AwayFromZero);
                System.Console.WriteLine("Общая длина слов равна {0}, средняя длина слова составляет {1}", sum, sumAvg);
                Console.Read();
                return sumAvg;
            }                    
        }
    }

