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
            var Person = new Person() { FirstName = "Vlad", LastName = "Vladov" };

            WontUpdate(Person);
            Console.WriteLine("WontUpdate");
            Console.WriteLine($"First name: {Person.FirstName}, Last name: {Person.LastName}\n");

            UpdateImplicitly(Person);
            Console.WriteLine("UpdateImplicitly");
            Console.WriteLine($"First name: {Person.FirstName}, Last name: {Person.LastName}\n");

            UpdateExplicitly(ref Person);
            Console.WriteLine("UpdateExplicitly");
            Console.WriteLine($"First name: {Person.FirstName}, Last name: {Person.LastName}\n");

            unsafe
            {
                TypedReference tr = __makeref(Person);
                IntPtr ptr = **(IntPtr**)(&tr);
                Console.WriteLine($"---   Person object before passing to method: {ptr}");
            }

            //!!!most important!!!
            AssignmenedNotUpdated(Person);
            Console.WriteLine("AssignmenedNotUpdated");
            Console.WriteLine($"First name: {Person.FirstName}, Last name: {Person.LastName}\n");

            //or by ref

            //!!!most important!!!
            //AssignmenedUpdated(ref Person);
            //Console.WriteLine("AssignmenedUpdated");
            //Console.WriteLine($"First name: {Person.FirstName}, Last name: {Person.LastName}\n");

            unsafe
            {
                TypedReference tr = __makeref(Person);
                IntPtr ptr = **(IntPtr**)(&tr);
                Console.WriteLine($"---   Person object after method completed: {ptr}");
            }

            Console.ReadLine();
        }

        public static void WontUpdate(Person p)
        {
            //New instance does jack...
            var newP = new Person() { FirstName = p.FirstName, LastName = p.LastName };
            newP.FirstName = "Dasha";
            newP.LastName = "Dasheva";
        }

        public static void UpdateImplicitly(Person p)
        {
            //Passing by reference implicitly
            p.FirstName = "Dasha";
            p.LastName = "Dasheva";
        }

        public static void UpdateExplicitly(ref Person p)
        {
            //Again passing by reference explicitly (reduntant)
            p.FirstName = "Dasha";
            p.LastName = "Dasheva";
        }

        public static void AssignmenedNotUpdated(Person person)
        {
            var newPerson = new Person()
            {
                FirstName = "Ded",
                LastName = "Dedov"
            };

            unsafe
            {
                TypedReference tr = __makeref(person);
                IntPtr ptr = **(IntPtr**)(&tr);
                Console.WriteLine($"---   Person object passed to method, but BEFORE changes/assign: {ptr}");
            }
            person = newPerson;

            unsafe
            {
                TypedReference tr = __makeref(person);
                IntPtr ptr = **(IntPtr**)(&tr);
                Console.WriteLine($"---   Person object passed to method, but AFTER changes/assign: {ptr}");
                Console.WriteLine();
            }
        }

        public static void AssignmenedUpdated(ref Person person)
        {
            var newPerson = new Person()
            {
                FirstName = "Ded",
                LastName = "Dedov"
            };

            unsafe
            {
                TypedReference tr = __makeref(person);
                IntPtr ptr = **(IntPtr**)(&tr);
                Console.WriteLine($"---   Person object passed to method, but BEFORE changes/assign: {ptr}");
            }
            person = newPerson;

            unsafe
            {
                TypedReference tr = __makeref(person);
                IntPtr ptr = **(IntPtr**)(&tr);
                Console.WriteLine($"---   Person object passed to method, but AFTER changes/assign: {ptr}");
                Console.WriteLine();
            }
        }
    }

    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string printName()
        {
            return $"First name: {FirstName} Last name:{LastName}";
        }
    }
}
