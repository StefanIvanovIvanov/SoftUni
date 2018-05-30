using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using NUnit.Framework;
using _07.Hack;

namespace UnitTests
{
    class HackTests
    {
        [Test]
        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(1)]
        public void AbsTest(decimal number)
        {
            MathMethods mathMethods = new MathMethods();
            decimal result = mathMethods.Abs(number);
            decimal wantedResult = Math.Abs(number);
            Assert.That(result.Equals(wantedResult));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(1)]
        public void FloorTest(decimal number)
        {
            MathMethods mathMethods = new MathMethods();
            decimal result = mathMethods.Floor(number);
            decimal wantedResult = Math.Floor(number);
            Assert.That(result.Equals(wantedResult));
        }
    }
}
