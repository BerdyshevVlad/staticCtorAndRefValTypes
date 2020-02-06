using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace testParma
{
    class Program
    {
        static void Main(string[] args)
        {
            A b = new B();
            b.Str();

            Console.WriteLine("============================================");

            A b2 = new B();
            b2.Str2();

            Console.WriteLine("============================================");

            A b3 = new B();
            b3.Str3();

            Console.WriteLine("============================================");

            A b4 = new B();
            b4.Str4();

            Console.WriteLine("============================================");

            A a;
            a = new B();
            a = A.StatMethodReturnA();

            Console.ReadLine();
        }
    }

    public class A
    {
        public virtual int PropA { get { return 3; }}

        static A()
        {
            Console.WriteLine("Static ctor A");
        }

        public A()
        {
            Console.WriteLine("Ctor A");
        }

        public A(int x)
        {
            Console.WriteLine($"Ctor A with x: {x}");
        }

        public static void StatMethod()
        {
            Console.WriteLine("StatMethod");
        }

        public static A StatMethodReturnA()
        {
            Console.WriteLine("StatMethodReturnA");
            return new A();
        }

        public virtual void Str()
        {
            Console.WriteLine("A");
        }

        public virtual void Str2()
        {
            Console.WriteLine("A");
        }

        public virtual void Str3()
        {
            Console.WriteLine("A");
        }

        public void Str4()
        {
            Console.WriteLine("A");
        }
    }

    public class B : A
    {
        public override int PropA => 5;

        static B()
        {
            Console.WriteLine("Static ctor B");
        }

        public B()
        {
            Console.WriteLine("Ctor B");
        }

        public B(int x) : base(x)
        {
            Console.WriteLine($"Ctor B with x: {x}");
        }

        public override void Str()
        {
            Console.WriteLine("B");
        }

        public void Str2()
        {
            Console.WriteLine("B");
        }

        public new void Str3()
        {
            Console.WriteLine("B");
        }

        public new void Str4()
        {
            Console.WriteLine("B");
        }

        public void OnlyBMethod()
        {
            Console.WriteLine("OnlyBMethod");
        } 
    }

}
