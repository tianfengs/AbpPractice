using ArchitectureConstraints.Multicasting;
using static System.Console;
namespace ArchitectureConstraints
{
    class Program
    {
        static void Main(string[] args)
        {
            var m = new MyClass();
            m.Method1();
            m.Method2();

            var n = new MyClass(1);
            Read();
        }
    }

    //测试引用约束时取消下面注释
    //[Unsealable]
    //public class MyUnsealableClass
    //{}

    //public sealed class TryingToSeal:MyUnsealableClass
    //{}
}
