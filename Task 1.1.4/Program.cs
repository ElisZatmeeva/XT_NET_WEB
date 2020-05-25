using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1._1._4
{
    class XMasTree
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Введите количество прямоугольников:");
            int n = int.Parse(Console.ReadLine());
            int height = n * 2;

            for (int i = 0; i < height; i++) {
                int l = i + 4;
                             
                if (i == 0) {

                    for (int j = 0; j < 3; j++)
                    {
                        int k = 0;   
                        int q = 0; 
                        if (j == 2)
                        {
                            k = 3;
                            q = -2;
                        }
                        for (; k <= j ; k++)
                        {
                            Console.Write(" ");
                            k++;
                        }
                       
                        for (; q <= j; q++)

                        {
                            Console.Write("*");
                            q++;
                        }

                        Console.WriteLine();
                    }
                }
                else if (i % 2 == 0)
                {

                    for (int y = 0; y < l; y += 2) 
                    {
                        for (int z = l; z > y; z-=2)
                        {
                            Console.Write(" ");

                        }
                        for (int t = 0; t <= y; t++)
                        {
                            Console.Write("*");

                        }
                        Console.WriteLine();
                       
                    }
                    l += 2;
                }
            }
            Console.ReadLine();
        }
    }
}
