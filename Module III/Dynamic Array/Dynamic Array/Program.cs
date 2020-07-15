using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Messaging;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Linq.Expressions;
using System.Threading;

namespace Dynamic_Array
{
    class Program
    {
        public static int[] myArray1;
        static void Main(string[] args)
        {

            List<int> list = new List<int>();
            list.Add(8);
            list.Add(15);
            int size = list.Count();
          
            MyDynamicArray<int> a = new MyDynamicArray<int>(list);

            myArray1 = new int[5] { 4, 3, 5, 8, 7 };
            MyDynamicArray<int> b = new MyDynamicArray<int>(myArray1);
            b.MyAdd(ref myArray1, 5);


            b.MyAddRange(ref myArray1, list);
            Console.WriteLine("После метода MyAddRange.");
            foreach (var i in myArray1)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine(b.MyRemove(ref myArray1, -8));
            Console.WriteLine(b.MyRemove(ref myArray1, 4));
            Console.WriteLine(b.MyInsert(ref myArray1, 19, 10));
            Console.WriteLine(b.MyInsert(ref myArray1, 19, 45)); 

            MyDynamicArray<int> d = new MyDynamicArray<int>(100);
            foreach (var i in d)
            {
                Console.WriteLine(i);
            }
            Console.ReadLine();
        }
    }

    public class MyDynamicArray<T>: IEnumerable, IEnumerable<T> 
    {
        protected int _size;
        protected int _newSize;
        protected int _n;
        protected T[] _newArr;
        protected bool _res;

        protected int lowerBound; // наименьший индекс
        protected int upperBound; // наибольший индекс

        private readonly int _itemCount; // for IEnumerable
        private int _position;
        private T _current;
       
        public MyDynamicArray(int itemCount)
        {
            if (itemCount < 0)
                throw new ArgumentException();
            else
                _newArr = new T[itemCount];

            _itemCount = itemCount;
            _position = 0;
            _current = _newArr[_position];

        }

        public int MyLength{ get; private set; } // Автоматически реализуемое и доступное только для чтения свойство Length.
        public int MyCapacity 
        {
            get
            {
                return _newArr.Length;
            }
            set
            {
                if (value < _size)
                {
                    T[] temp = new T[value];
                    Array.Copy(_newArr, 0, temp, 0, value);
                    _newArr = temp;
                    _size = value;
                }
                if (value == _newArr.Length)
                {
                    return;
                }

                if (value > 0)
                {
                    T[] temp = new T[value];
                    if (_size > 0)
                        Array.Copy(_newArr, 0, temp, 0, _size);

                    _newArr = temp;
                }

            }
        }
        public MyDynamicArray()
        {
            string[] arrStr = new string[8];
            int[] arrInt = new int[8];
            double[] arrdDouble = new double[8];
            object[] arrObj = new object[8];

        }
        public MyDynamicArray(int[] arrInt)
        {
            int[] arrayInt = new int[_n];

        }
        public MyDynamicArray(IEnumerable<T> collection) 
        {
            _newArr = new T[collection.Count()];
            _newArr = collection.ToArray(); 
        }
        public MyDynamicArray(int low, int high)///Конструктор ДЛЯ свойства Length
        {
            high++;
            if (high <= low)
            {
                throw new IndexOutOfRangeException("Нижний индекс не меньше верхнего.");

            }
            _newArr = new T[high - low];
            MyLength = high - low;
            lowerBound = low;
            upperBound = --high;
        }
        
        
        public T this[int index] // индексатор для класса.
        {
            get
            {
                if (ok(index))
                {
                    return _newArr[index - lowerBound];
                }
                else
                {
                    throw new IndexOutOfRangeException("Ошибка нарушения границ.");
                }
            }
            set
            {
                if (ok(index))
                {
                    _newArr[index - lowerBound] = value;
                }
                else throw new IndexOutOfRangeException("Ошибка нарушения границ.");
            }
        }
        private bool ok(int index) // Возвратить логическое значение true, если индекс находится в установленных границах.
        {
            if (index >= lowerBound & index <= upperBound) return true;
            return false;
        }
        public void MyAdd(ref T[] array, T value)
        {
            if (array == null)
            {
                throw new ArgumentNullException("Аргумент не может быть равен null");
            }
            else if (array.Length == 0)
            {
                throw new ArgumentException("Введите значения в массив");
            }

            int _newSize = array.Length * 2;
            _newArr = new T[_newSize];
            

            for (int i = 0; i < array.Length; i++)
            {
                _newArr[i] = array[i];
            }
             

            _newArr[array.Length] = value;
            array = _newArr;
        }
        public void MyAddRange(ref T[] array, List<T> list)
        {
            if (array == null)
            {
                throw new ArgumentNullException("Аргумент не может быть равен null");
            }
            else if (array.Length == 0)
            {
                throw new ArgumentException("Введите значения в массив");
            }

            int newSize1 = array.Length + list.Count;
            T[] newArr2 = new T[newSize1];
            list.CopyTo(0, newArr2, array.Length, list.Count);

            for (int i = 0; i < array.Length; i++)
            {
                newArr2[i] = array[i];
            }
            array = newArr2;
        }
        public bool MyRemove(ref T[] array, int index)
        {
            if (array == null)
            {
                throw new ArgumentNullException("Аргумент не может быть равен null");
            }
            else if (array.Length == 0)
            {
                throw new ArgumentException("Введите значения в массив");
            }

            bool res = false;
            T[] newArray = new T[array.Length];

            try { 
                for (int i = 0; i < index; i++)
                {
                    newArray[i] = array[i];
                }
                for (int j = index + 1; j < array.Length; j++)
                {
                    newArray[j] = array[j];
                }
                array = newArray;
                res = true;
                return res;
            }
            catch
            {
                return res;
            }
        }
        public bool MyInsert(ref T[] array, T value, int index2)
        {
            if (array == null)
            {
                throw new ArgumentNullException("Аргумент не может быть равен null");
            }
            else if (array.Length == 0)
            {
                throw new ArgumentException("Введите значения в массив");
            }
            _newSize = array.Length;
            if (index2 > array.Length)
                _newSize = index2 + 1;

            try
            {
                var newArr = new T[_newSize];
                newArr[index2] = value;
                if(index2 > array.Length-1)
                {
                    for (int i = 0; i < array.Length & i >= 0; i++) 
                        newArr[i] = array[i];

                }
                else
                {
                    for (int i = index2 - 1; i < array.Length & i >= 0; i--)
                        newArr[i] = array[i];
                    for (int i = index2 + 1; i < newArr.Length; i++)
                        newArr[i] = array[i];
                }
               
                array = newArr;
               
                _res = true;
                return _res;
            }
            catch (ArgumentOutOfRangeException exc)
            {
                Console.WriteLine(exc);
                throw new ArgumentOutOfRangeException($"{_res}. Вы вышли за границу массива");
            }
        }
        public IEnumerator<T> GetEnumerator()//Enumerator
        {

            T current = _newArr[_position];
            for (int i = 0; i < _itemCount - 1; i++)
            {
                if (i == 0) yield return current;

                current = _newArr[_position + 1];
                yield return current;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public void Reset()
        {
            _position = 0;
            _current = _newArr[_position];
        }
    }   
}


