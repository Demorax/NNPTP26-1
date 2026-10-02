using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NNPTPZ1.Mathematics.Tests
{
    [TestClass()]
    public class PolynomialTests
    {
        [TestMethod()]
        public void EvaluateTest()
        {
            Polynomial poly = new Polynomial();
            poly.Add(new ComplexNumber() { Real = 1, Imaginary = 0 });
            poly.Add(new ComplexNumber() { Real = 0, Imaginary = 0 });
            poly.Add(new ComplexNumber() { Real = 1, Imaginary = 0 });
            ComplexNumber result = poly.Evaluate(new ComplexNumber() { Real = 0, Imaginary = 0 });
            var expected = new ComplexNumber() { Real = 1, Imaginary = 0 };
            Assert.AreEqual(expected, result);
            result = poly.Evaluate(new ComplexNumber() { Real = 1, Imaginary = 0 });
            expected = new ComplexNumber() { Real = 2, Imaginary = 0 };
            Assert.AreEqual(expected, result);
            result = poly.Evaluate(new ComplexNumber() { Real = 2, Imaginary = 0 });
            expected = new ComplexNumber() { Real = 5.0000000000, Imaginary = 0 };
            Assert.AreEqual(expected, result);

            // i^2 + 1 = 0
            result = poly.Evaluate(new ComplexNumber() { Real = 0, Imaginary = 1 });
            Assert.AreEqual(ComplexNumber.Zero, result);
        }

        [TestMethod()]
        public void DeriveTest()
        {
            // (x^3 + 1)' = 3x^2
            Polynomial poly = new Polynomial();
            poly.Add(new ComplexNumber() { Real = 1 });
            poly.Add(ComplexNumber.Zero);
            poly.Add(ComplexNumber.Zero);
            poly.Add(new ComplexNumber() { Real = 1 });

            Polynomial derivative = poly.Derive();

            CollectionAssert.AreEqual(
                new[] { ComplexNumber.Zero, ComplexNumber.Zero, new ComplexNumber() { Real = 3 } },
                derivative.Coefficients);
        }

        [TestMethod()]
        public void ToStringTest()
        {
            Polynomial poly = new Polynomial();
            poly.Add(new ComplexNumber() { Real = 1, Imaginary = 0 });
            poly.Add(new ComplexNumber() { Real = 0, Imaginary = 0 });
            poly.Add(new ComplexNumber() { Real = 1, Imaginary = 0 });

            Assert.AreEqual("(1 + 0i) + (0 + 0i)x + (1 + 0i)xx", poly.ToString());
        }
    }
}
