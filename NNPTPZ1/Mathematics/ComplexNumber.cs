using System;

namespace NNPTPZ1.Mathematics
{
    public class ComplexNumber
    {
        /// <summary>
        /// Returns new instance, so that the shared value cannot be modified through its setters.
        /// </summary>
        public static ComplexNumber Zero => new ComplexNumber();

        public double Real { get; set; }
        public double Imaginary { get; set; }

        public ComplexNumber Add(ComplexNumber other)
        {
            return new ComplexNumber()
            {
                Real = Real + other.Real,
                Imaginary = Imaginary + other.Imaginary
            };
        }

        public ComplexNumber Subtract(ComplexNumber other)
        {
            return new ComplexNumber()
            {
                Real = Real - other.Real,
                Imaginary = Imaginary - other.Imaginary
            };
        }

        public ComplexNumber Multiply(ComplexNumber other)
        {
            // (a + bi)(c + di) = (ac - bd) + (ad + bc)i
            return new ComplexNumber()
            {
                Real = Real * other.Real - Imaginary * other.Imaginary,
                Imaginary = Real * other.Imaginary + Imaginary * other.Real
            };
        }

        public ComplexNumber Divide(ComplexNumber other)
        {
            // multiply numerator and denominator by conjugate of denominator:
            // (a + bi) / (c + di) = (a + bi)(c - di) / (c^2 + d^2)
            ComplexNumber numerator = Multiply(new ComplexNumber() { Real = other.Real, Imaginary = -other.Imaginary });
            double denominator = other.Real * other.Real + other.Imaginary * other.Imaginary;

            return new ComplexNumber()
            {
                Real = numerator.Real / denominator,
                Imaginary = numerator.Imaginary / denominator
            };
        }

        public double GetAbsoluteValue()
        {
            return Math.Sqrt(Real * Real + Imaginary * Imaginary);
        }

        public double GetAngleInRadians()
        {
            return Math.Atan2(Imaginary, Real);
        }

        public override bool Equals(object obj)
        {
            return obj is ComplexNumber other
                && other.Real == Real
                && other.Imaginary == Imaginary;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Real.GetHashCode() * 397) ^ Imaginary.GetHashCode();
            }
        }

        public override string ToString()
        {
            return $"({Real} + {Imaginary}i)";
        }
    }
}
