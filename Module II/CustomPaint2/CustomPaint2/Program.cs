using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CustomPaint2
{
    class Program
    {
        protected static string name;
        protected enum TypeMove
        {
            None = 0,
            AddFigure,
            DisplayFigure,
            Clear,
            Exit,
            ChangeUser
        }

        protected enum TypeFigures
        {
            None = 0,
            Line,
            Circle,
            CircleOut,
            Ring,
            Square,
            Rhombus,
            Triangle,
            Rectangle
        }

        static void Main(string[] args)
        {
            bool res = true;

            TypeMove[] typeMove = (TypeMove[])Enum.GetValues(typeof(TypeMove)); // create array
            TypeFigures[] typeFigures = (TypeFigures[])Enum.GetValues(typeof(TypeFigures));

            void SayName() //узнаёт имя
            {
                Console.WriteLine("Введите имя");
                name = Console.ReadLine();
            }

            void GetFigure()
            {
                string str;
                foreach (TypeFigures item in typeFigures)
                {
                    if (item != TypeFigures.None)
                        Console.WriteLine("{0,7:D}:\t{0:G}", item);
                }
                Console.WriteLine($"{name}, Выберите фигуру");
                str = Console.ReadLine();

                var type = (TypeFigures)Enum.Parse(typeof(TypeFigures), str);
                Figure fig = GetFig(type);
                Console.WriteLine($"Площадь {fig.Area}, Длина {fig.Length}");
                fig.Draw();

                Console.ReadKey();
            }


            void GetList()
            {

                foreach (TypeFigures item in typeFigures)
                {
                    if (item != TypeFigures.None)
                    {
                        var f2 = "TypeFigures." + item;
                        var f = item;
                        Console.WriteLine(item);

                        Figure fig = GetFig(f);
                        if (f2 == "TypeFigures.Ring" | f2 == "TypeFigures.Circle" | f2 == "TypeFigures.CircleOut")
                        {
                            Console.WriteLine($"Координаты точки Х1 = {fig.PointX1}, Координаты точки Y1 =  {fig.PointY1}, " +
                            $"Координаты точки Х2 = {fig.PointX2}, Координаты точки Y2 = {fig.PointY2}," +
                            $" Радиус = {fig.Length}, Площадь = {fig.Area}");
                        }
                        else if (f2 == "TypeFigures.Line")
                        {
                            Console.WriteLine($"Координаты точки Х1 = {fig.PointX1}, Координаты точки Y1 =  {fig.PointY1}, " +
                            $"Координаты точки Х2 = {fig.PointX2}, Координаты точки Y2 = {fig.PointY2}, Длина = {fig.Length} ");

                        }
                        else
                        {
                            Console.WriteLine($"Координаты точки Х1 = {fig.PointX1}, Координаты точки Y1 =  {fig.PointY1}, " +
                            $"Координаты точки Х2 = {fig.PointX2}, Координаты точки Y2 = {fig.PointY2}, Сторона = {fig.Length}," +
                            $" Площадь = {fig.Area}");
                        }
                    }
                }

            }

            SayName();
            do
            {
                Console.WriteLine($"{name}, выберите действие, нажав соответствующую цифру");
                foreach (TypeMove item in typeMove)
                {
                    if (item != TypeMove.None)
                        Console.WriteLine("{0,4:D}:\t{0:G}", item);
                }

                int num = int.Parse(Console.ReadLine());

                switch (num)
                {
                    case 1:
                        Console.WriteLine($"{name}, выберите тип фигуры, указав её имя");
                        GetFigure();
                        break;

                    case 2:
                        GetList();
                        Console.ReadLine();
                        break;

                    case 3:
                        Console.Clear();//очистить холст
                        break;

                    case 4:
                        Environment.Exit(0);//выход из консоли
                        break;

                    case 5:
                        SayName();
                        break;

                    default:
                        res = false;
                        Console.WriteLine("Значение не в диапозоне значений");
                        Console.ReadLine();
                        break;
                }
            } while (res);
        }
        static Figure GetFig(TypeFigures type)
        {

            Console.WriteLine("Введите координату точки х1:");
            double X1 = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите координату точки y1:");
            double Y1 = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите координату точки х2:");
            double X2 = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите координату точки y2:");
            double Y2 = double.Parse(Console.ReadLine());
            double rInner = 5;


            if (type == TypeFigures.Ring)
            {
                Console.WriteLine("Введите внутренний радиус:");
                rInner = double.Parse(Console.ReadLine());
            }

            switch (type)
            {

                case TypeFigures.Circle:
                    return new Circle(X1, Y1, X2, Y2);
                case TypeFigures.CircleOut:
                    return new CircleOut(X1, Y1, X2, Y2);
                case TypeFigures.Line:
                    return new Line(X1, Y1, X2, Y2);
                case TypeFigures.Rectangle:
                    return new Rectangle(X1, Y1, X2, Y2);
                case TypeFigures.Rhombus:
                    return new Rhombus(X1, Y1, X2, Y2);
                case TypeFigures.Ring:
                    return new Ring(X1, Y1, X2, Y2, rInner);
                case TypeFigures.Square:
                    return new Square(X1, Y1, X2, Y2);
                case TypeFigures.Triangle:
                    return new Triangle(X1, Y1, X2, Y2);
                case TypeFigures.None:
                default:
                    return null;
            }

        }
        public abstract class Figure
        {

            public double PointX1 { get; set; }
            public double PointY1 { get; set; }
            public double PointX2 { get; set; }
            public double PointY2 { get; set; }

            abstract public double Area { get; }
            abstract public double Length { get; }

            public abstract void Draw();
            protected Figure(double X1, double Y1, double X2, double Y2)
            {
                PointX1 = X1;
                PointY1 = Y1;
                PointX2 = X2;
                PointY2 = Y2;
            }

        }

        class Line : Figure
        {
            protected double _r;
            public double Segment // радиус / линия / ))
            {
                get
                {
                    return _r = Math.Round(Math.Sqrt(Math.Pow((PointX2 - PointX1), 2) + Math.Pow((PointY2 - PointY1), 2)), 2);
                }

            }
            public override double Area { get; }
            public override double Length
            {
                get
                {
                    return Segment;
                }
            }
            public Line(double X1, double Y1, double X2, double Y2) : base(X1, Y1, X2, Y2)
            {
            }
            public override void Draw()
            {
                Console.WriteLine("Линия создана!");
            }
        }

        class CircleOut : Line//Figure //окружность
        {
            public override double Length  //длина окружности
            {
                get
                {
                    return Math.Round((2 * Math.PI * Segment), 2);
                }
            }

            public CircleOut(double X1, double Y1, double X2, double Y2) : base(X1, Y1, X2, Y2)
            {

            }
            public override void Draw()
            {
                Console.WriteLine("Окружность создана!");
            }
        }

        class Circle : Line // круг
        {
            public override double Length
            {
                get
                {
                    return Segment;
                }
            }
            public override double Area
            {
                get
                {
                    return Math.Round(Math.PI * Math.Pow(Segment, 2), 2);
                }
            }
            public Circle(double X1, double Y1, double X2, double Y2) : base(X1, Y1, X2, Y2)
            {

            }
            public override void Draw()
            {
                Console.WriteLine("Окружность создана!");
            }
        }
        class Ring : Line // кольцо
        {
            private double _rInner;

            public Ring(double X1, double Y1, double X2, double Y2, double rInner) : base(X1, Y1, X2, Y2)
            {
                _rInner = rInner;
            }

            public double RadiusInner
            {
                get
                {
                    return _rInner;
                }
                set
                {
                    _rInner = value < 0 ? -value : value;
                }
            }
            public override double Area //площадь кольца
            {
                get
                {
                    return Math.Round(Math.PI * (Math.Pow(Segment, 2) - Math.Pow(RadiusInner, 2)), 2); // площадь кольца
                }
            }
            public override double Length // длина окружностей 
            {
                get
                {
                    return Segment - RadiusInner;
                }
            }
            public override void Draw()
            {
                Console.WriteLine("Фигура кольцо создана!");
            }
        }

        class Square : Line // радиус окружности равен половине диагонали квадрата, поэтому _а вычисляется в GetA()
        {
            public virtual double GetA // получить сторону А
            {
                get
                {
                    return Math.Round(Segment / Math.Sqrt(2), 2);
                    // Console.WriteLine($"Сторона а равна {A}");
                }
            }
            public override double Area //площадь квадрата
            {
                get
                {
                    return Math.Round(GetA * GetA, 2);
                }
            }
            public override double Length // длина 
            {
                get
                {
                    return Segment;
                }
            } 

            public Square(double X1, double Y1, double X2, double Y2) : base(X1, Y1, X2, Y2)
            {
            }
            public override void Draw()
            {
                Console.WriteLine("Фигура квадрат создана!");
            }
        }

        class Rhombus : Square
        {
            public Rhombus(double X1, double Y1, double X2, double Y2) : base(X1, Y1, X2, Y2)
            {
            }
            public override void Draw()
            {
                Console.WriteLine("Фигура ромб создана!");
            }

        }

        // У прямоугольного треугольника центр описанной окружности лежит на середине гипотенузы. 
        // Катет прямоугольного треугольника, лежащий против угла в 30 градусов, равен половине гипотенузы(т.е. равен радиусу).          
        // Окружность описана вокруг прямоугольного треугольника. 
        // Сумма всех углов треугольника равна 180 => Два остальных угла по 45. Острый Угол 90 градусов.

        class Triangle : Line
        {
            public override double Length // гипотенуза
            {
                get
                {
                    return Segment * 2;
                }
            }
            public virtual double GetB // вычисляемый катет
            {
                get
                {
                    return Math.Round(Math.Sqrt(Math.Pow(Length, 2) - (Math.Pow(Segment, 2))), 2);
                }
            }
            public override double Area //площадь треугольника
            {
                get
                {
                    return Math.Round(((Segment * GetB) / 2), 2);
                }
            }


            public Triangle(double X1, double Y1, double X2, double Y2) : base(X1, Y1, X2, Y2)
            {
            }
            public override void Draw()
            {
                Console.WriteLine("Фигура треугольник создана!");
            }
        }

        class Rectangle : Triangle
        {
            public override double Area //площадь прямоугольника
            {
                get
                {
                    return Math.Round(((Segment * GetB)), 2);
                }
            }

            public Rectangle(double X1, double Y1, double X2, double Y2) : base(X1, Y1, X2, Y2)
            {
            }
            public override void Draw()
            {
                Console.WriteLine("Фигура прямоугольник создана!");
            }
        }
    }
}
