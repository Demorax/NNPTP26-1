using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NNPTPZ1.Mathematics.Tests
{
    [TestClass()]
    public class ComplexNumberTests
    {
        [TestMethod()]
        public void AddTest()
        {
            ComplexNumber a = new ComplexNumber() { Real = 10, Imaginary = 20 };
            ComplexNumber b = new ComplexNumber() { Real = 1, Imaginary = 2 };

            Assert.AreEqual(new ComplexNumber() { Real = 11, Imaginary = 22 }, a.Add(b));

            a = new ComplexNumber() { Real = 1, Imaginary = -1 };
            b = new ComplexNumber() { Real = 0, Imaginary = 0 };

            Assert.AreEqual(new ComplexNumber() { Real = 1, Imaginary = -1 }, a.Add(b));
        }

        [TestMethod()]
        public void ToStringTest()
        {
            Assert.AreEqual("(10 + 20i)", new ComplexNumber() { Real = 10, Imaginary = 20 }.ToString());
            Assert.AreEqual("(1 + -1i)", new ComplexNumber() { Real = 1, Imaginary = -1 }.ToString());
            Assert.AreEqual("(0 + 0i)", ComplexNumber.Zero.ToString());
        }

        [TestMethod()]
        public void SubtractTest()
        {
            ComplexNumber a = new ComplexNumber() { Real = 10, Imaginary = 20 };
            ComplexNumber b = new ComplexNumber() { Real = 1, Imaginary = 2 };

            Assert.AreEqual(new ComplexNumber() { Real = 9, Imaginary = 18 }, a.Subtract(b));
        }

        [TestMethod()]
        public void MultiplyTest()
        {
            // (1 + 2i)(3 + 4i) = 3 + 4i + 6i + 8i^2 = -5 + 10i
            ComplexNumber a = new ComplexNumber() { Real = 1, Imaginary = 2 };
            ComplexNumber b = new ComplexNumber() { Real = 3, Imaginary = 4 };

            Assert.AreEqual(new ComplexNumber() { Real = -5, Imaginary = 10 }, a.Multiply(b));
        }

        [TestMethod()]
        public void DivideTest()
        {
            ComplexNumber a = new ComplexNumber() { Real = -5, Imaginary = 10 };
            ComplexNumber b = new ComplexNumber() { Real = 3, Imaginary = 4 };

            Assert.AreEqual(new ComplexNumber() { Real = 1, Imaginary = 2 }, a.Divide(b));
        }

        [TestMethod()]
        public void GetAbsoluteValueTest()
        {
            ComplexNumber a = new ComplexNumber() { Real = 3, Imaginary = -4 };

            Assert.AreEqual(5, a.GetAbsoluteValue(), 1e-12);
        }

        [TestMethod()]
        public void GetAngleInRadiansTest()
        {
            Assert.AreEqual(Math.PI / 4, new ComplexNumber() { Real = 1, Imaginary = 1 }.GetAngleInRadians(), 1e-12);
            Assert.AreEqual(-3 * Math.PI / 4, new ComplexNumber() { Real = -1, Imaginary = -1 }.GetAngleInRadians(), 1e-12);
            Assert.AreEqual(Math.PI / 2, new ComplexNumber() { Real = 0, Imaginary = 1 }.GetAngleInRadians(), 1e-12);
        }

        [TestMethod()]
        public void EqualsAndGetHashCodeTest()
        {
            ComplexNumber a = new ComplexNumber() { Real = 1.5, Imaginary = -2 };
            ComplexNumber b = new ComplexNumber() { Real = 1.5, Imaginary = -2 };

            Assert.IsTrue(a.Equals(b));
            Assert.AreEqual(a.GetHashCode(), b.GetHashCode());
            Assert.IsFalse(a.Equals(new ComplexNumber() { Real = 1.5, Imaginary = 2 }));
            Assert.IsFalse(a.Equals(null));
        }
    }
}
