using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1._1._9
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            int[] MyArr = new int[10];
            Random random = new Random();

            for (int i = 0; i < MyArr.Length; i++)
            {
                MyArr[i] = random.Next(-25, 25);
                Console.Write(MyArr[i] + "\t");
            }


            for (int j = 0; j < MyArr.Length; j++)
            {
                if (MyArr[j] >= 0)
                {
                    sum += MyArr[j];
                }
                Console.WriteLine();
            }
            Console.WriteLine("Сумма неотрициательных элементов в массиве равна {0}", sum);
            Console.ReadLine();
        }       
    }
}
