using System.Collections.Generic;
using System.Text;

namespace NNPTPZ1.Mathematics
{
    /// <summary>
    /// Polynomial with complex coefficients. Coefficient at index i belongs to x^i.
    /// </summary>
    public class Polynomial
    {
        public List<ComplexNumber> Coefficients { get; } = new List<ComplexNumber>();

        public void Add(ComplexNumber coefficient) =>
            Coefficients.Add(coefficient);

        /// <summary>
        /// Derives this polynomial and creates new one
        /// </summary>
        /// <returns>Derivated polynomial</returns>
        public Polynomial Derive()
        {
            Polynomial derivative = new Polynomial();
            for (int power = 1; power < Coefficients.Count; power++)
            {
                derivative.Add(Coefficients[power].Multiply(new ComplexNumber() { Real = power }));
            }

            return derivative;
        }

        /// <summary>
        /// Evaluates polynomial at given point
        /// </summary>
        /// <param name="x">point of evaluation</param>
        /// <returns>value of polynomial at x</returns>
        public ComplexNumber Evaluate(double x)
        {
            return Evaluate(new ComplexNumber() { Real = x, Imaginary = 0 });
        }

        /// <summary>
        /// Evaluates polynomial at given point
        /// </summary>
        /// <param name="x">point of evaluation</param>
        /// <returns>value of polynomial at x</returns>
        public ComplexNumber Evaluate(ComplexNumber x)
        {
            ComplexNumber result = ComplexNumber.Zero;
            ComplexNumber xPower = x;

            for (int i = 0; i < Coefficients.Count; i++)
            {
                ComplexNumber term = Coefficients[i];
                if (i > 0)
                {
                    term = term.Multiply(xPower);
                    xPower = xPower.Multiply(x);
                }

                result = result.Add(term);
            }

            return result;
        }

        /// <summary>
        /// Creates string representation, e.g. "(1 + 0i) + (0 + 0i)x + (1 + 0i)xx"
        /// </summary>
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < Coefficients.Count; i++)
            {
                if (i > 0)
                    builder.Append(" + ");

                builder.Append(Coefficients[i]);
                builder.Append('x', i);
            }

            return builder.ToString();
        }
    }
}
