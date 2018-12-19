using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeneralUtilities;

namespace UnitTestProject1
{
    [TestClass]
    public class Vector2Tests
    {
        [TestMethod]
        public void AddVectors()
        {
            Vector2 a = new Vector2(3.0f, 5.0f);
            Vector2 b = new Vector2(8.0f, 2.0f);

            Assert.AreEqual(new Vector2(11.0f, 7.0f), a + b);
        }

        [TestMethod]
        public void SubtractVectors()
        {
            Vector2 a = new Vector2(7.0f, 4.0f);
            Vector2 b = new Vector2(3.0f, -3.0f);

            Assert.AreEqual(new Vector2(4.0f, 7.0f), a - b);
        }

        [TestMethod]
        public void NegateVector()
        {
            Vector2 a = new Vector2(7.0f, 4.0f);

            Assert.AreEqual(new Vector2(-7.0f, -4.0f), -a);
        }

        [TestMethod]
        public void MultiplyVector()
        {
            Vector2 a = new Vector2(6.0f, 3.0f);

            Assert.AreEqual(new Vector2(12.0f, 6.0f), a * 2);
        }

        [TestMethod]
        public void DivideVector()
        {
            Vector2 a = new Vector2(8.0f, 4.0f);

            Assert.AreEqual(new Vector2(4.0f, 2.0f), a / 2);
        }

        [TestMethod]
        public void VectorLength()
        {
            Vector2 a = new Vector2(3.0f, 0.0f);

            Assert.AreEqual(3.0f, a.Length());
        }

        [TestMethod]
        public void VectorUnit()
        {
            Vector2 a = new Vector2(3.0f, 0.0f);

            Assert.AreEqual(new Vector2(1.0f, 0.0f), a.Unit());
        }

        [TestMethod]
        public void RotateVector()
        {
            Vector2 a = new Vector2(0.0f, 1.0f);
            Vector2 b = a.Rotate(180.0f);

            Assert.IsTrue(b.X.ApproximatelyEquals(0.0f));
            Assert.AreEqual(0.0f, b.X, 0.00001);
            Assert.AreEqual(-1.0f, b.Y);
        }

        [TestMethod]
        public void VectorDotProduct()
        {
            Vector2 a = new Vector2(8.0f, 2.0f);
            Vector2 b = new Vector2(-2.0f, 8.0f);
            Vector2 c = new Vector2(-5.0f, 5.0f);

            Assert.AreEqual(0.0f, a.Dot(b));
            Assert.AreEqual(-30.0f, a.Dot(c));
            Assert.AreEqual(50.0f, b.Dot(c));
        }
    }
}