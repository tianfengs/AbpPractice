using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using static System.Console;
namespace SimdVector
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (Vector.IsHardwareAccelerated)
            {
                WriteLine("Vetor operation is hardware acceleration!");
                WriteLine();
            }
            var vectorf = new Vector<float>(11f);
            WriteLine(vectorf);
            WriteLine(Vector.SquareRoot(vectorf));

            var vectord = new Vector<double>(11f);
            WriteLine(vectord);
            WriteLine(Vector.SquareRoot(vectord));
            WriteLine();

            var vector3d = new Vector3(0f, 1f, 2f);
            WriteLine(vector3d);
            WriteLine(Vector3.SquareRoot(vector3d));
            WriteLine();

            // N.B. Not all operations are equivalent between complex and vector maths
            var complex = new Complex(1d, 2d);
            WriteLine(complex);
            WriteLine(Complex.Add(complex, complex));

            var vectorComplexSingle = new Vector2(1f, 2f);
            WriteLine(vectorComplexSingle);
            WriteLine(Vector2.Add(vectorComplexSingle, vectorComplexSingle));

            var vectorComplexDouble = new Vector<double>(new[] { 1d, 2d });
            WriteLine(vectorComplexDouble);
            WriteLine(Vector.Add(vectorComplexDouble, vectorComplexDouble));

            ResetColor();
            WriteLine();
            WriteLine("Press any key...");
            ReadKey(true);
        }
    }
}
