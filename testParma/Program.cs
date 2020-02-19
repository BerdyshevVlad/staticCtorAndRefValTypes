using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace testParma
{
    public interface IInterface
    {
        void Show();
    }

    public class A : IInterface
    {
        public void Show()
        {
            Console.WriteLine(this.GetType());
        }
    }


    public class B : IInterface
    {
        public void Show()
        {
            Console.WriteLine(this.GetType());
        }
    }

    public class C : B
    {

    }

    public class D
    {

    }

    class Program
    {
        static void Main(string[] args)
        {
            A a = new A();
            B b = new B();
            C c = new C();
            D d = new D();

            Method(a);
            Method(b);
            Method(c);
            Method(d);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            Method(a, true);
            Method(b, true);
            Method(c, true);
            Method(d, true);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("==========================");

            dynamic value;
            for (Int32 demo = 0; demo < 2; demo++)
            {
                value = (demo == 0) ? (dynamic)5 : (dynamic)"A";
                value = value + value;
                M(value);
            }

            Object o1 = 123; // OK: Неявное приведение Int32 к Object (упаковка)
            //Int32 n1 = o1; // Ошибка: Нет неявного приведения Object к Int32
            Int32 n2 = (Int32)o1; // OK: Явное приведение Object к Int32 (распаковка)
            dynamic d1 = 123; // OK: Неявное приведение Int32 к dynamic (упаковка)
            Int32 n3 = d1; // OK: Неявное приведение dynamic к Int32 (распаковка)



            // Здесь компилятор позволяет коду компилироваться, потому что на этапе компиляции он не знает, какой из методов M будет вызван.Следовательно, он также не знает, какой тип будет возвращен методом M.Компилятор предполагает, что переменная result имеет динамический тип.Вы можете убедиться в этом, когда наведете указатель мыши на переменную var в редакторе Visual Studio — во всплывающем IntelliSense - окне вы увидите следующее:

            // dynamic: Represents an object whose operations will be resolved at runtime.

            // Если метод M, вызванный на этапе выполнения, возвращает void, выдается исключение Microsoft.CSharp.RuntimeBinder.RuntimeBinderException.
            dynamic dynamicVariable = 123;
            var result = M2(dynamicVariable); // 'var result' - то же, что 'dynamic result'
            Console.WriteLine(result);


            Console.ReadLine();
        }

        private static void M(Int32 n) { Console.WriteLine("M(Int32): " + n); }
        private static void M(String s) { Console.WriteLine("M(String): " + s); }

        private static Type M2(Int32 n){ return n.GetType(); }
        private static Type M2(String s) { return s.GetType(); }

        // see difference:
        // В общем случае компилятор не позволит вам написать код с неявным приведением выражения от типа
        // Object к другому типу, вы должны использовать явное приведение типов.Однако
        // компилятор разрешит выполнить приведение типа dynamic к другому типу с использованием синтаксиса неявного приведения.

        //private static void Method(object value, bool trigger = false)
        private static void Method(dynamic value, bool trigger = false)
        {
            if (trigger)
            {
                value = value as IInterface;
            }

            if (value is A)
            {
                Console.WriteLine("I enter to A");
                value.Show();
                Console.WriteLine("=============");
            }

            if (value is B)
            {
                Console.WriteLine("I enter to B");
                value.Show();
                Console.WriteLine("=============");
            }
            if (value is C)
            {
                Console.WriteLine("I enter to C");
                value.Show();
                Console.WriteLine("=============");
            }
            if (value is D)
            {
                Console.WriteLine("I enter to D");
                Console.WriteLine(value.GetType());
            }
        }
    }
}
