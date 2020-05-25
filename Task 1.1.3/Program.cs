using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1._1._3
{
    class AnotherTringle
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Введите число");
            int  n = int.Parse(Console.ReadLine());
            int  height = n * 2;

            for (int i = 0; i < height; i += 2)
            {
                for (int j = height; j > i; j-=2)
                {
                    Console.Write(" ");
                   
                }
                for (int k = 0; k <= i; k++)
                {
                    Console.Write("*");

                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }   
}
