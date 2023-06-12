using ComplexTrr;
using System;

namespace ComplexTrTests
{
    [TestFixture]
    public class ComplexTrTests
    {
        [Test]
        public void ConstructorTest()
        {
            var complextr = new ComplexTr(10, -5);
            Assert.That(complextr.Abs, Is.EqualTo(10));
            Assert.That(complextr.Arg, Is.EqualTo(-5));
        }
        [TestCase(-30)]
        public void Abs_ArgumentException(double val)
        {
            var complextr = new ComplexTr();
            Assert.That(() => complextr.Abs = val, Throws.ArgumentException);
        }
        [TestCase(15, (Math.PI), -15)]
        [TestCase(0, 0, 0)]
        [TestCase(15, (Math.PI/2), 0)]
        public void ReTest(double abs, double arg, double result)
        {
            var complextr = new ComplexTr(abs,arg);
            Assert.That(complextr.Re, Is.EqualTo(result));
        }
        [TestCase(15, (Math.PI), 0)]
        [TestCase(0, 0, 0)]
        [TestCase(15, (Math.PI / 2), 15)]
        public void ImTest(double abs, double arg, double result)
        {
            var complextr = new ComplexTr(abs, arg);
            Assert.That(complextr.Im, Is.EqualTo(result));
        }
        [TestCase(0, 120, "0")]
        [TestCase(1, 3.14, "z = cos (3,14) + i * sin (3,14)")]
        [TestCase(2, 3.14, "z = 2 * (cos (3,14) + i * sin (3,14))")]
        public void ToStringTest(double abs, double arg, string result)
        {
            var complextr = new ComplexTr(abs, arg);
            Assert.That(complextr.ToString(), Is.EqualTo(result));
        }
        [TestCase(30, 30, true)]
        [TestCase(30, 15, false)]
        public void Equals_ComplexTr_ExpectedResult(double abs1, double abs2, bool result)
        {
            var complextr1 = new ComplexTr(abs1, 0);
            var complextr2 = new ComplexTr(abs2, 0);
            Assert.That(complextr1.Equals(complextr2), Is.EqualTo(result));
        }
        [Test]
        public void Equals_WrongArgument_ArgumentException()
        {
            var complextr = new ComplexTr();
            var smth = new object();
            Assert.That(() => complextr.Equals(smth), Throws.ArgumentException);
        }
        [Test]
        public static void GetHashCodeTest()
        {
            var x = new ComplexTr(10, 10);
            var y = new ComplexTr(10,10);
            var z = new ComplexTr(30, 10);
            Assert.That(x.Equals(y), Is.True);
            Assert.That(x.Equals(z), Is.False);
        }
        [Test]
        public static void ComparisonTest()
        {
            var x = new ComplexTr(10, 10);
            var y = new ComplexTr(10, 10);
            var z = new ComplexTr(30, 10);
            Assert.That(x == y, Is.True);
            Assert.That(x != y, Is.False);
            Assert.That(x == z, Is.False);
            Assert.That(x != z, Is.True);
        }
        [TestCase(2, 4,4,4,8,8)]
        [TestCase(3,-4,3,4,9,0)]
        [TestCase(0, 0, 0, 0, 0, 0)]
        public void MultiplicationTest(double abs1, double arg1, double abs2, double arg2, double resultAbs, double resultArg)
        {
            var complextr1 = new ComplexTr(abs1,arg1);
            var complextr2 = new ComplexTr(abs2,arg2);
            var result = new ComplexTr(resultAbs, resultArg);
            Assert.That(complextr1 * complextr2, Is.EqualTo(result));
        }
        public void Division_ArgumentException()
        {
            var complextr1 = new ComplexTr(1, 1);
            var complextr2 = new ComplexTr(0, 1);
            Assert.That(() => complextr1 / complextr2, Throws.ArgumentException);
        }
        [TestCase(4, 4, 2, 4, 2, 0)]
        [TestCase(0, 4, 2, 4, 0, 0)]
        [TestCase(9, -4, 3, 4, 3, -8)]
        public void DivisionTest(double abs1, double arg1, double abs2, double arg2, double resultAbs, double resultArg)
        {
            var complextr1 = new ComplexTr(abs1, arg1);
            var complextr2 = new ComplexTr(abs2, arg2);
            var result = new ComplexTr(resultAbs, resultArg);
            Assert.That(complextr1 / complextr2, Is.EqualTo(result));
        }
    }
}