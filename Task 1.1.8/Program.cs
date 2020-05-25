using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1._1._8
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,,] myArr = new int[3, 6, 4]; //Инициализация трёхмерного массива
            Random random = new Random();


            for (int i = 0; i < myArr.GetLength(0); i++)

            {
                for (int j = 0; j < myArr.GetLength(1); j++)
                {
                    for (int k = 0; k < myArr.GetLength(2); k++)
                    {
                        myArr[i, j, k] = random.Next(-50, 50);
                    }
                }
            }

            Console.WriteLine("Вид массива до замены положительных чисел на нули");
            for (int i = 0; i < myArr.GetLength(0); i++)
            {
                Console.WriteLine("Размерность {0}", i + 1);
                for (int j = 0; j < myArr.GetLength(1); j++)
                {
                    for (int k = 0; k < myArr.GetLength(2); k++)
                    {
                        Console.Write(myArr[i, j, k] + " ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }

            Console.WriteLine("Вид массива после замены положительных чисел на нули");

            for (int i = 0; i < myArr.GetLength(0); i++)
            {
                Console.WriteLine("Размерность {0}", i + 1);
                for (int j = 0; j < myArr.GetLength(1); j++)
                {
                    for (int k = 0; k < myArr.GetLength(2); k++)
                    {

                        if (myArr[i, j, k] > 0)
                        {
                            myArr[i, j, k] = 0;
                        }
                        Console.Write(myArr[i, j, k] + " ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();       
            }
            Console.ReadKey();
        }
    }
}



