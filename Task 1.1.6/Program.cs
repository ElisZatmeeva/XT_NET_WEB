using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._1._6_Reight
{
    class Program
    {
        [Flags]
        enum TypeFont
        {
            None = 0,
            bold = 1,
            italic = 2,
            underline = 4

        }
        static void Main(string[] args)
        {
            int j = 0;
            bool res = true;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Параметры надписи:{Enum.Format(typeof(TypeFont), 0, "G")}");

            TypeFont[] typeFonts = (TypeFont[])Enum.GetValues(typeof(TypeFont));
            try
            {
                do
            {
                Console.WriteLine("Введите:");


                foreach (TypeFont item in typeFonts)
                {
                    if (item != TypeFont.None)
                        Console.WriteLine("{0,3:D}:\t{0:G}", item);
                }

                int num = int.Parse(Console.ReadLine());
                TypeFont font1 = TypeFont.bold;
                TypeFont font2 = TypeFont.bold | TypeFont.italic;
                TypeFont font3 = font2 ^ TypeFont.bold;

                if (num <= 0 || num > 4)
                {
                    Console.WriteLine("Значения не в деапозоне от 1 до 4. Выхожу из программы.");
                    res = false;
                }
                switch (num)
                {
                    case 1 when j == 0 | j % 2 != 0 :
                        Console.WriteLine($"Параметры надписи {font1}");
                        j++;
                        break;

                    case 1 when j > 0 & j % 2 == 0:
                        Console.WriteLine($"Параметры надписи {font3}");
                        j++;
                        break;

                    case 2:
                        Console.WriteLine($"Параметры надписи {font2}");
                        j++;
                        break;
                }
            } while (res);
        }
            catch (Exception)
            {

                Console.WriteLine("Выход из программы");
            }

    Console.ReadKey();
        }
    }
}
