using App;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class LongComplexTests
    {
        [TestCase("0", 0, 0)]
        [TestCase("1", 1, 0)]
        [TestCase("4", 4, 0)]
        [TestCase("1i", 0, 1)]
        [TestCase("i", 0, 1)]
        [TestCase("3i", 0, 3)]
        [TestCase("0+i", 0, 1)]
        [TestCase("1+i", 1, 1)]
        [TestCase("4+3i", 4, 3)]
        [TestCase("-1", -1, 0)]
        [TestCase("-4", -4, 0)]
        [TestCase("-i", 0, -1)]
        [TestCase("-1i", 0, -1)]
        [TestCase("-3i", 0, -3)]
        [TestCase("0-i", 0, -1)]
        [TestCase("-1-i", -1, -1)]
        [TestCase("4-3i", 4, -3)]
        [TestCase("-4-3i", -4, -3)]
        public void Parse_Succeeds(string input, int real, int imaginary)
        {
            var number = LongComplex.Parse(input);
            Assert.AreEqual(real, (int)number.Real);
            Assert.AreEqual(imaginary, (int)number.Imaginary);
        }


        [TestCase(0, 0, ExpectedResult = "0")]
        [TestCase(1, 0, ExpectedResult = "1")]
        [TestCase(4, 0, ExpectedResult = "4")]
        [TestCase(0, 1, ExpectedResult = "i")]
        [TestCase(0, 3, ExpectedResult = "3i")]
        [TestCase(1, 1, ExpectedResult = "1+i")]
        [TestCase(4, 3, ExpectedResult = "4+3i")]
        [TestCase(-1, 0, ExpectedResult = "-1")]
        [TestCase(-4, 0, ExpectedResult = "-4")]
        [TestCase(0, -1, ExpectedResult = "-i")]
        [TestCase(0, -3, ExpectedResult = "-3i")]
        [TestCase(-1, -1, ExpectedResult = "-1-i")]
        [TestCase(4, -3, ExpectedResult = "4-3i")]
        [TestCase(-4, -3, ExpectedResult = "-4-3i")]
        public string ToString_Succeeds(int real, int imaginary)
        {
            return new LongComplex(real, imaginary).ToString();
        }


        [Test]
        public void Multiply_Succeeds()
        {
            var left = new LongComplex(3, 5);
            var right = new LongComplex(7, 11);
            var result = LongComplex.Multiply(left, right);
            Assert.AreEqual(21 - 55, result.Real);
            Assert.AreEqual(33 + 35, result.Imaginary);
        }


        [Test]
        public void Add_Succeeds()
        {
            var left = new LongComplex(3, 5);
            var right = new LongComplex(7, 11);
            var result = LongComplex.Add(left, right);
            Assert.AreEqual(10, result.Real);
            Assert.AreEqual(16, result.Imaginary);
        }


        [Test]
        public void Subtract_Succeeds()
        {
            var left = new LongComplex(3, 5);
            var right = new LongComplex(7, 11);
            var result = LongComplex.Subtract(left, right);
            Assert.AreEqual(-4, result.Real);
            Assert.AreEqual(-6, result.Imaginary);
        }
    }
}
