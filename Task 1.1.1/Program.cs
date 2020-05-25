using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Task_1._1._1
{
    class Rectangle
    {
        public string a;
        
        static void Main()
        {
            int a;
            int b;
            int res;
            bool repeat = true;
            Console.ForegroundColor = ConsoleColor.Green;
            while (repeat)
            {              
                try {
                    
                   do
                    {
                        Console.Write("Введите высоту прямоугольника = ");
                   
                    }
                    while (!int.TryParse(Console.ReadLine(), out a));
                    do
                    {
                        Console.Write("Bведите длину прямоугольника = ");
                    }
                    while (!int.TryParse(Console.ReadLine(), out b));

                        if (a <= 0 || b <= 0)
                        {

                            throw new Exception("Введите значение больше нуля");
                        }
                        else
                        {
                            res = a * b;
                            Console.WriteLine($"Площадь прямоугольника высотой {a}, шириной {b} равна {res} квадратных метра");

                        }
                }
                catch (Exception e)
                {
                   throw; 
                    Console.WriteLine($"Ошибка: {e.Message}");
                }
                
                
                repeat = false;
                Console.ReadKey();
                
            }
        }
    }
}