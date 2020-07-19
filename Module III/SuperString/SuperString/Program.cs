using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace SuperString
{
    class Program
    {
        static public string MyText(string text)
        {
            bool rus = false, eng = false;

            text = text.ToLower();

            byte[] Ch = Encoding.Default.GetBytes(text);
            foreach (byte ch in Ch)
            {
                if ((ch >= 97) && (ch <= 122)) eng = true;
                if ((ch >= 224) && (ch <= 255)) rus = true;
            }

            if (eng & !rus) return "English";
            if (rus & !eng) return "Russia";
            if (eng & rus) return "Mixed"; //смашанный состав
            return "Number";
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите текст:");
            string text = Console.ReadLine();
            Console.WriteLine(MyText(text));
            Console.ReadLine();
        }       
       
    }
}
