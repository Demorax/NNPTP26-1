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
        static int Main(string[] args)
        {
            FractalSettings settings;
            try
            {
                settings = FractalSettings.FromArguments(args);
            }
            catch (ArgumentException e)
            {
                Console.Error.WriteLine(e.Message);
                Console.Error.WriteLine(FractalSettings.Usage);
                return 1;
            }

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
                bitmap.Save(settings.OutputPath);
            }

            return 0;
        }
    }
}
