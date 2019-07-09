using System;

namespace ClassMembersDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new A();
            var b = new A.B();
            // var x = A.i;
            var y = A.j;
            var z = A.k;
            // var ww = A.w;
            Console.WriteLine("Hello World!");
        }

    }

    class A{
       public class B{} // 所有成员都可以加访问类型修饰
       public int w = 5;
       public static int k = 4;
    //    public static const int i = 3; //常量不能标记为static
       public const int j = 3;
    }
}
