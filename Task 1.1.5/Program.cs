using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._1._5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            int i = 0;
            int sum = 0;
            for(; i < 1000; i++)
            {
                
                if (i % 3 == 0 & i % 5==0 | i % 3 == 0 | i % 5 == 0)
                {
                    sum += i;
                }
              
            }
            Console.WriteLine($"Сумма всех чисел меньше 1000, кратных 3-ём или 5-ти равна {sum}");
            Console.ReadLine();
        }
    }
}


