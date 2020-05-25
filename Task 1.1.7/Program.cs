using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1._1._7
{
    class Program
    {
        static void Main(string[] args)
        {
            

            int[] arr = new int[10];

            int max = arr[0];
            int min = arr[9];

            Random random = new Random();

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = random.Next(-500, 500);
            }

            for(int x = 0; x < arr.Length; x++) {  //Sort value
                int temp;
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    for (int j = 0; j < arr.Length - i - 1; j++)
                    {
                        if (arr[j + 1] > arr[j])
                        {
                            temp = arr[j + 1];
                            arr[j + 1] = arr[j];
                            arr[j] = temp;
                        }
                    }
                }
                Console.Write(arr[x] + "\t");
             
            }

            for(int y = 0; y < arr.Length; y++) // Max value
            {
                if(max < arr[y])
                {
                    max = arr[y];
                }
                
            }

            for (int y = 0; y < arr.Length; y++) // Min value
            {
                if (min > arr[y])
                {
                    min = arr[y];
                }

            }

            Console.WriteLine();
            Console.WriteLine("Максимальное значение массива {0}", max);
            Console.WriteLine("Минимальное значение массива {0}", min);
            Console.ReadKey();
        }
    }           
}
