using static System.Console;
namespace AopValidate
{
    class Program
    {
        [MyLocationAspect]
        public static string Farb { get; set; }
        static void Main(string[] args)
        {
            Farb = "farb";
            Read();
        }
    }
}
