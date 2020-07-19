using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SuperArray
{
    class SupperArray
    {
        static void Main(string[] args)
        {

            int[] arrayInt = new int[] { 800, 35, 48, 75, 1 };
            double[] arrayDouble = new double[] { 15.35, 18.46, 19.5, 15.35, 19.5, 19.5, 18.45, 19.0, 19.5 };

            arrayInt.ApplayToArray((int num) => num + num);
            foreach (var item in arrayInt)
                Console.WriteLine(item);

            arrayInt.ApplayToArray((int num) => num * num);
            foreach (var item in arrayInt)
                Console.WriteLine(item);

            arrayInt.ApplayToArray((int num) => num * 2);
            foreach (var item in arrayInt)
                Console.WriteLine(item);

            Console.Write("Наиболее часто встречающееся значение: "); 
            Console.WriteLine(arrayDouble.MostCommon((double num) => num));

            arrayDouble.ApplayToArray((double num1) => (double)Math.Round(Math.Sqrt(num1), 2, MidpointRounding.AwayFromZero));
            foreach (var item in arrayDouble)
                Console.WriteLine(item);

            var resultSum = arrayDouble.Sum();
            Console.WriteLine($"Сумма всех элементов: {resultSum}");

            var resultSumInt = arrayInt.Sum();
            Console.WriteLine($"Сумма всех значений: {resultSumInt}");

            var resultAvg = (double)Math.Round(arrayDouble.Average(), 2, MidpointRounding.AwayFromZero);
            Console.WriteLine($"Среднее всех значений: {resultAvg}");
            
            Console.ReadLine();

        }
    }
    public static class Int32ArrayExtensions
    {
        public static double SumElem(this int[] array)
        {
            if (array == null)
                throw new ArgumentNullException("Аргумент не может быть ранвым null");
            if (array.Length == 0)
                throw new ArgumentException("Введите значения");
            int sum = array.Sum();
            return sum;
        }
        public static double Average(this int[] array)
        {
            if (array == null)
                throw new ArgumentNullException("Аргумент не может быть ранвым null");
            if (array.Length == 0)
                throw new ArgumentException("Введите значения");
            int count = array.Count();
            int sum = array.Sum();
            var avg = (double)(sum / count);
            return avg;
        }

        public static void ApplayToArray<T>(this T[] array, Func<T, T> modifArray)
        {
            if (modifArray == null)
                return;

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = modifArray(array[i]);
            }
        }

        public static Tres MostCommon<Tsrc, Tres>(this IEnumerable<Tsrc> source, Func<Tsrc, Tres> transform)
        {
            return source.GroupBy(s => transform(s)).OrderByDescending(g => g.Count()).First().Key;
        }

    }
}
 