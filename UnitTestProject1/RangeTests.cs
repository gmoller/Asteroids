using System.Numerics;
using GeneralUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class RangeTests
    {
        [TestMethod]
        public void ContainsValue()
        {
            Range<float> a = new Range<float>(5.0f, 10.0f);

            Assert.IsTrue(a.ContainsValue(8.0f));
            Assert.IsTrue(a.ContainsValue(5.0f));
            Assert.IsTrue(a.ContainsValue(10.0f));
            Assert.IsFalse(a.ContainsValue(4.99f));
            Assert.IsFalse(a.ContainsValue(10.01f));
        }

        [TestMethod]
        public void ContainsRange()
        {
            Range<float> a = new Range<float>(5.0f, 10.0f);
            Range<float> b = new Range<float>(7.0f, 9.0f);
            Range<float> c = new Range<float>(4.0f, 6.0f);

            Assert.IsTrue(a.ContainsRange(b));
            Assert.IsFalse(b.ContainsRange(a));
            Assert.IsFalse(a.ContainsRange(c));
        }

        [TestMethod]
        public void IsInsideRange()
        {
            Range<float> a = new Range<float>(5.0f, 10.0f);
            Range<float> b = new Range<float>(7.0f, 9.0f);
            Range<float> c = new Range<float>(4.0f, 6.0f);

            Assert.IsTrue(b.IsInsideRange(a));
            Assert.IsFalse(c.IsInsideRange(a));
        }

        [TestMethod]
        public void IntersectsRange()
        {
            Range<float> a = new Range<float>(5.0f, 10.0f);
            Range<float> b = new Range<float>(12.0f, 15.0f);
            Range<float> c = new Range<float>(3.0f, 7.0f);
            Range<float> d = new Range<float>(3.0f, 5.0f);
            Range<float> e = new Range<float>(3.0f, 4.99999f);

            Assert.IsFalse(a.IntersectsRange(b));
            Assert.IsTrue(a.IntersectsRange(c));
            Assert.IsTrue(a.IntersectsRange(d));
            Assert.IsFalse(e.IntersectsRange(a));
        }

        [TestMethod]
        public void Hull()
        {
            Range<float> a = new Range<float>(5.0f, 10.0f);
            Range<float> b = new Range<float>(8.0f, 12.0f);
            Range<float> c = new Range<float>(8.0f, 9.0f);

            Range<float> hull1 = a.Hull(b);
            Range<float> hull2 = a.Hull(c);

            Assert.IsTrue(hull1 == new Range<float>(5.0f, 12.0f));
            Assert.IsTrue(hull2 == new Range<float>(5.0f, 10.0f));

            Assert.AreEqual(new Range<float>(5.0f, 12.0f), hull1);
            Assert.AreEqual(new Range<float>(5.0f, 10.0f), hull2);
        }

        [TestMethod]
        public void SortAscending()
        {
            Range<float> a = new Range<float>(10.0f, 5.0f);
            Range<float> b = new Range<float>(5.0f, 10.0f);

            Range<float> ascendingA = a.SortAscending();
            Range<float> ascendingB = b.SortAscending();

            Assert.IsTrue(ascendingA == new Range<float>(5.0f, 10.0f));
            Assert.IsTrue(ascendingB == new Range<float>(5.0f, 10.0f));

            Assert.AreEqual(new Range<float>(5.0f, 10.0f), ascendingA);
            Assert.AreEqual(new Range<float>(5.0f, 10.0f), ascendingB);
        }

        [TestMethod]
        public void SortDescending()
        {
            Range<float> a = new Range<float>(10.0f, 5.0f);
            Range<float> b = new Range<float>(5.0f, 10.0f);

            Range<float> descendingA = a.SortDescending();
            Range<float> descendingB = b.SortDescending();

            Assert.IsTrue(descendingA == new Range<float>(10.0f, 5.0f));
            Assert.IsTrue(descendingB == new Range<float>(10.0f, 5.0f));

            Assert.AreEqual(new Range<float>(10.0f, 5.0f), descendingA);
            Assert.AreEqual(new Range<float>(10.0f, 5.0f), descendingB);
        }
    }
}