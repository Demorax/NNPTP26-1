using System;
using System.Collections.Generic;
using System.Drawing;
using NNPTPZ1.Mathematics;

namespace NNPTPZ1
{
    /// <summary>
    /// Renders Newton fractal of given polynomial. Every pixel is colored by the root
    /// to which Newton's iteration converges and darkened by the number of iterations.
    /// </summary>
    public class NewtonFractalRenderer
    {
        private const int ConvergedIterations = 30;
        private const double ConvergenceThreshold = 0.5;
        private const double RootTolerance = 0.01;
        private const double ZeroReplacement = 0.0001;
        private const int DarkeningPerIteration = 2;

        private static readonly Color[] RootColors =
        {
            Color.Red, Color.Blue, Color.Green, Color.Yellow, Color.Orange, Color.Fuchsia, Color.Gold, Color.Cyan, Color.Magenta
        };

        private readonly Polynomial polynomial;
        private readonly Polynomial derivative;
        private readonly List<ComplexNumber> roots = new List<ComplexNumber>();

        public NewtonFractalRenderer(Polynomial polynomial)
        {
            this.polynomial = polynomial;
            derivative = polynomial.Derive();
        }

        public Bitmap Render(FractalSettings settings)
        {
            Bitmap bitmap = new Bitmap(settings.Width, settings.Height);

            for (int y = 0; y < settings.Height; y++)
            {
                for (int x = 0; x < settings.Width; x++)
                {
                    ComplexNumber point = ToComplexPlane(settings, x, y);
                    int iterations = SolveByNewtonMethod(ref point);
                    int rootIndex = GetRootIndex(point);

                    bitmap.SetPixel(x, y, GetColor(rootIndex, iterations));
                }
            }

            return bitmap;
        }

        private static ComplexNumber ToComplexPlane(FractalSettings settings, int x, int y)
        {
            ComplexNumber point = new ComplexNumber()
            {
                Real = settings.XMin + x * settings.XStep,
                Imaginary = (float)(settings.YMin + y * settings.YStep)
            };

            // Newton's iteration cannot start exactly at zero
            if (point.Real == 0)
                point.Real = ZeroReplacement;
            if (point.Imaginary == 0)
                point.Imaginary = (float)ZeroReplacement;

            return point;
        }

        /// <summary>
        /// Moves the point towards a root of the polynomial.
        /// </summary>
        /// <returns>number of iterations made</returns>
        private int SolveByNewtonMethod(ref ComplexNumber point)
        {
            int iterations = 0;
            for (int i = 0; i < ConvergedIterations; i++)
            {
                ComplexNumber step = polynomial.Evaluate(point).Divide(derivative.Evaluate(point));
                point = point.Subtract(step);

                // big steps do not count, the iteration has not converged yet
                if (Math.Pow(step.Real, 2) + Math.Pow(step.Imaginary, 2) >= ConvergenceThreshold)
                {
                    i--;
                }
                iterations++;
            }

            return iterations;
        }

        private int GetRootIndex(ComplexNumber point)
        {
            int rootIndex = roots.FindLastIndex(root => IsSameRoot(root, point));
            if (rootIndex < 0)
            {
                roots.Add(point);
                rootIndex = roots.Count - 1;
            }

            return rootIndex;
        }

        private static bool IsSameRoot(ComplexNumber root, ComplexNumber point)
        {
            return Math.Pow(point.Real - root.Real, 2) + Math.Pow(point.Imaginary - root.Imaginary, 2) <= RootTolerance;
        }

        private static Color GetColor(int rootIndex, int iterations)
        {
            Color rootColor = RootColors[rootIndex % RootColors.Length];
            int darkening = iterations * DarkeningPerIteration;

            return Color.FromArgb(
                Math.Max(0, rootColor.R - darkening),
                Math.Max(0, rootColor.G - darkening),
                Math.Max(0, rootColor.B - darkening));
        }
    }
}
