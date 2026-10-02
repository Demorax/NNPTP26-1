using System;
using System.Drawing;
using NNPTPZ1.Mathematics;

namespace NNPTPZ1
{
    /// <summary>
    /// This program should produce Newton fractals.
    /// See more at: https://en.wikipedia.org/wiki/Newton_fractal
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            FractalSettings settings = FractalSettings.FromArguments(args);

            // x^3 + 1
            Polynomial polynomial = new Polynomial();
            polynomial.Add(new ComplexNumber() { Real = 1 });
            polynomial.Add(ComplexNumber.Zero);
            polynomial.Add(ComplexNumber.Zero);
            polynomial.Add(new ComplexNumber() { Real = 1 });

            Console.WriteLine(polynomial);
            Console.WriteLine(polynomial.Derive());

            NewtonFractalRenderer renderer = new NewtonFractalRenderer(polynomial);
            using (Bitmap bitmap = renderer.Render(settings))
            {
                bitmap.Save(settings.OutputPath ?? "../../../out.png");
            }
        }
    }
}
