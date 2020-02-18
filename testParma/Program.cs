using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace testParma
{
    // Интерфейс, определяющий метод Change
    internal interface IChangeBoxedPoint
    {
        void Change(Int32 x, Int32 y);
    }

    // Point - значимый тип.
    internal struct Point : IChangeBoxedPoint
    {
        private Int32 X, Y;
        public Point(Int32 x, Int32 y)
        {
            X = x;
            Y = y;
        }
        public void Change(Int32 x, Int32 y)
        {
            X = x; Y = y;
        }
        public override String ToString()
        {
            return String.Format("({0}, {1})", X.ToString(), Y.ToString());
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Point p = new Point(1, 1);
            Console.WriteLine(p);

            p.Change(2, 2);
            Console.WriteLine(p);

            Object o = p;
            Console.WriteLine(o);

            ((Point)o).Change(3, 3);
            Console.WriteLine(o);

            // p упаковывается, упакованный объект изменяется и освобождается
            Console.WriteLine("p упаковывается, упакованный объект изменяется и освобождается");
            ((IChangeBoxedPoint)p).Change(4, 4);
            Console.WriteLine(p);

            // Упакованный объект изменяется и выводится
            Console.WriteLine("Упакованный объект изменяется и выводится");
            ((IChangeBoxedPoint)o).Change(5, 5);
            Console.WriteLine(o);

            //------------------------------------------------------
            Int32 first = 5;
            Object obj = first; // Упаковка first; obj указывает на упакованный объект
            try
            {
                Int16 second = (Int16)obj; // Генерируется InvalidCastException
            }
            catch (Exception)
            {
                Int16 second = (Int16)(Int32)obj; // Генерируется InvalidCastException
                Console.WriteLine($"(Int16)(Int32)obj works good! Variable second is: {second}");
            }
            

            Console.ReadLine();
        }
    }   
}
