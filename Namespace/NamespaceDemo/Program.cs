using System;

namespace NamespaceDemo
{
    class Program
    {
        private static int x = 30;

        static void Main(string[] args)
        {
            int x = 10;
            Console.WriteLine($"The value of A.x is {A.x}");
            Console.WriteLine($"The value of inner x is {x}");
            Console.WriteLine($"The value of Program.x is {Program.x}");
            PrintX();
        }

        static void PrintX(){
            Console.WriteLine($"The value of outer x is {x}");
        }
    }

    class A
    {
        public static int x=20;
    }
}
