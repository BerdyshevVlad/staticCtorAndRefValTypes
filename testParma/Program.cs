using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace testParma
{
    public class Object
    {
        public virtual Boolean Equals(Object obj)
        {
            // Поскольку тип может переопределять метод (при наследовании)
            // Equals типа Object, этот метод больше не может использоваться для проверки на
            // тождественность.

            // Если обе ссылки указывают на один и тот же объект,
            // значит, эти объекты равны
            if (this == obj) return true;
            // Предполагаем, что объекты не равны
            return false;
        }

        // Для проверки на тождественность нужно всегда вызывать ReferenceEquals (то
        // есть проверять на предмет того, относятся ли две ссылки к одному объекту). 
        public static Boolean ReferenceEquals(Object objA, Object objB)
        {
            return (objA == objB);
        }
    }

    public class ImaginaryNumber :IEquatable<ImaginaryNumber>
    {
        public int RealNumber { get; set; }
        public int ImaginaryUnit { get; set; }

        public ImaginaryNumber(int realNumber,int imaginaryUnit)
        {
            RealNumber = realNumber;
            ImaginaryUnit = imaginaryUnit;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as ImaginaryNumber);
        }

        public bool Equals(ImaginaryNumber other)
        {
            return other != null && ImaginaryUnit == other.ImaginaryUnit;
        }

        public override int GetHashCode()
        {
            var hashCode = 352033288;
            hashCode = hashCode * -1521134295 + RealNumber.GetHashCode();
            return hashCode;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ImaginaryNumber first = new ImaginaryNumber(1,1);
            ImaginaryNumber second = new ImaginaryNumber(2,1);

            bool result = first == second;
            bool resultEquals = first.Equals(second);
            bool resultReference = ReferenceEquals(first,second);

            Console.WriteLine($"First == second: {result}");
            Console.WriteLine($"First equals second: {resultEquals}");
            Console.WriteLine($"First referenceEquals second: {resultReference}");


            Console.ReadLine();
        }
    }
}
