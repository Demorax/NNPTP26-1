using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NNPTPZ1.Tests
{
    [TestClass()]
    public class FractalSettingsTests
    {
        [TestMethod()]
        public void FromArgumentsTest()
        {
            FractalSettings settings = FractalSettings.FromArguments(
                new[] { "400", "200", "-2", "2", "-1.5", "1.5", "fractal.png" });

            Assert.AreEqual(400, settings.Width);
            Assert.AreEqual(200, settings.Height);
            Assert.AreEqual(-2, settings.XMin);
            Assert.AreEqual(2, settings.XMax);
            Assert.AreEqual(-1.5, settings.YMin);
            Assert.AreEqual(1.5, settings.YMax);
            Assert.AreEqual("fractal.png", settings.OutputPath);
            Assert.AreEqual(0.01, settings.XStep, 1e-12);
            Assert.AreEqual(0.015, settings.YStep, 1e-12);
        }

        [TestMethod()]
        public void FromArgumentsWithoutOutputTest()
        {
            FractalSettings settings = FractalSettings.FromArguments(
                new[] { "400", "200", "-2", "2", "-1.5", "1.5" });

            Assert.AreEqual(FractalSettings.DefaultOutputPath, settings.OutputPath);
        }

        [TestMethod()]
        public void FromArgumentsInvalidTest()
        {
            Assert.ThrowsException<ArgumentException>(() => FractalSettings.FromArguments(new[] { "400", "200" }));
            Assert.ThrowsException<ArgumentException>(() => FractalSettings.FromArguments(new[] { "abc", "200", "-2", "2", "-1", "1" }));
            Assert.ThrowsException<ArgumentException>(() => FractalSettings.FromArguments(new[] { "0", "200", "-2", "2", "-1", "1" }));
        }
    }
}
