using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1._2._3
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "Aнтон выпил кофе и послушал Cтинга";
            string str2 = "Aнтон хорошо начал утро: послушал Стинга, выпил кофе и посмотрел Звёздные Войны";
            OutStrWith(str);
            OutStrWithout(str2);
            Console.ReadLine();
        }
           static string OutStrWith(string str){
                int sum = 0;
                string[] words = str.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                
                for (int i = 0; i < words.Length; i++)
                {

                    for (int j = 0; j < words[i].Length; j++)
                    {
                        char c = words[i][0];
                        if (Char.IsLower(c))
                        {
                            sum += 1;
                            break;
                        }
                    }
                }

            Console.WriteLine($"Ввод без *: {str} \nВывод: {sum} ");
            return str;
           }
           static string OutStrWithout(string str2){
               int sum2 = 0;

               string[] words2 = str2.Split(new char[] { ' ', ',', ':', ';' }, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < words2.Length; i++)
                {

                    for (int j = 0; j < words2[i].Length; j++)
                    {
                        char c = words2[i][0];
                        if (Char.IsLower(c))
                        {
                            sum2 += 1;
                            break;
                        }
                    }
                }

            Console.WriteLine($"Ввод со *: {str2} \nВывод: {sum2} ");
            return str2;
            }        
           
    }
     
}

