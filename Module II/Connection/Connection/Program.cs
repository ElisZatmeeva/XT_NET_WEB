using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Connection
{
    class MyString
    {
        private static string strA;

        private static string strB;


        private char[] _immitationString;
        public string PropertyMyString1 { get; set; } = strA;
        public string PropertyMyString2 { get; set; } = strB;

        public char this[int index]
        {
            get
            {
                return PropertyMyString1[index];
            }
        }

        public MyString()
        {

        }

        public MyString(char[] value)
        {
            _immitationString = new char[value.Length]; // for operatop

            Array.Copy(value, _immitationString, value.Length);
        }

        public MyString(MyString value) // for operator
        {
            PropertyMyString1 = value.ToString();
        }
        public MyString(string strA, string strB)
        {
            PropertyMyString1 = strA;
            PropertyMyString2 = strB;
        }

        public static implicit operator MyString(char[] value) // convertation
        {
            return new MyString { _immitationString = value };
        }

        public static implicit operator char[](MyString value)
        {
            char[] arr = { };
            Array.Copy(value._immitationString, arr, arr.Length);
            return arr;
        }



        static void Main(string[] args)
        {
            SayString();
            MyString myString = new MyString(strA, strB);
            Console.WriteLine(myString[2]); // обращение к indexer

            string str1 = myString.PropertyMyString1;
            char[] firstString = str1.ToCharArray();

            string str2 = myString.PropertyMyString2;
            char[] secondString = str2.ToCharArray();

            MyLibrary.MyString.MyFind(firstString, secondString);
            MyLibrary.MyString.MyConcat(firstString, secondString, out char[] NewString);
            MyLibrary.MyString.MyCompare(firstString, secondString);

            void SayString()
            {

                Console.WriteLine("Введите строку 1");
                strA = Console.ReadLine();

                Console.WriteLine("Введите строку 2");
                strB = Console.ReadLine();

            }

        }
    }
}
