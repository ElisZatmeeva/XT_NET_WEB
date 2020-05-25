using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1._1._10
{
    class Program
    {
        static void Main(string[] args)
        {

            Random random = new Random();
            int[,] MyArr2 = new int[3,4];
            int Sum = 0;

            for (int i = 0; i < MyArr2.GetLength(0); i++)
            {
                for (int k =0; k < MyArr2.GetLength(1); k++)
                {
                    MyArr2[i, k] = random.Next(-50, 50);
                }
            }

            for (int i = 0; i < MyArr2.GetLength(0); i++)  // Вывод массива
            {
                for (int k = 0; k < MyArr2.GetLength(1); k++)
                {
                    Console.Write(MyArr2[i, k] + "\t");
                }
                Console.WriteLine();
            }


            for (int i = 0; i<MyArr2.GetLength(0); i++)  // Определение суммы элементов, стоящих на чётных позициях
                {
                for (int k = 0; k<MyArr2.GetLength(1); k++)
                {
                    if((i+k) % 2 == 0)
                    {
                        Sum += MyArr2[i, k];
                    }
                }              
            }
            Console.WriteLine("Сумма элементов, стоящих на чётных позициях равна {0}", Sum);
            Console.ReadKey();
        }
    }
}
