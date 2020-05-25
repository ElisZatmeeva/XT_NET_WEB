using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Task_1._1._2
{
    class Triangle
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Введите число (количество строк)");
            int  n = int.Parse(Console.ReadLine());

            int i = 0;
            while (i < n)
            {

                int j = 0;
                while (j <= i)
                {
                    Console.Write("*");
                    j++;

                }
                Console.WriteLine();
                i++;

            }
            Console.ReadKey();
        }

    }
}