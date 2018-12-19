using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CollisionDetectionLibrary;
using ShapesLibrary;

namespace UnitTestProject1
{
    [TestClass]
    public class CollisionDetectionTests
    {
        #region Circle

        [TestMethod]
        public void Circle_Circle()
        {
            Circle a = new Circle(new Vector2(4.0f, 4.0f), 2.0f);
            Circle b = new Circle(new Vector2(8.0f, 4.0f), 2.0f);
            Circle c = new Circle(new Vector2(10.0f, 4.0f), 2.0f);

            Assert.IsTrue(ShapeCollisionDetection.CollidesWith(a, b));
            Assert.IsTrue(ShapeCollisionDetection.CollidesWith(b, c));
            Assert.IsFalse(ShapeCollisionDetection.CollidesWith(a, c));
        }

        [TestMethod]
        public void Circle_Line()
        {
            Circle a = new Circle(new Vector2(6.0f, 3.0f), 2.0f);
            Line b = new Line(new Vector2(4.0f, 7.0f), new Vector2(5.0f, -1.0f));
            Line c = new Line(new Vector2(0.0f, 3.0f), new Vector2(10.0f, 3.0f));

            // circle-line
            Assert.IsFalse(ShapeCollisionDetection.CollidesWith(a, b));
            Assert.IsTrue(ShapeCollisionDetection.CollidesWith(a, c));

            // line-circle
            Assert.IsFalse(ShapeCollisionDetection.CollidesWith(b, a));
            Assert.IsTrue(ShapeCollisionDetection.CollidesWith(c, a));
        }

        [TestMethod]
        public void Circe_LineSegment()
        {
            Circle a = new Circle(new Vector2(4.0f, 4.0f), 3.0f);
            LineSegment b = new LineSegment(new Vector2(8.0f, 6.0f), new Vector2(13.0f, 6.0f));
            LineSegment c = new LineSegment(new Vector2(4.0f, 4.0f), new Vector2(13.0f, 6.0f));

            // circle-line segment
            Assert.IsFalse(ShapeCollisionDetection.CollidesWith(a, b));
            Assert.IsTrue(ShapeCollisionDetection.CollidesWith(a, c));

            // line segment-circle
            Assert.IsFalse(ShapeCollisionDetection.CollidesWith(b, a));
            Assert.IsTrue(ShapeCollisionDetection.CollidesWith(c, a));
        }

        [TestMethod]
        public void Circle_Rectangle()
        {
            Rectangle a = new Rectangle(3, 2, 6, 4);
            Circle b = new Circle(new Vector2(5.0f, 4.0f), 1.0f);
            Circle c = new Circle(new Vector2(7.0f, 8.0f), 1.0f);

            // circle-rectangle
            Assert.IsTrue(ShapeCollisionDetection.CollidesWith(b, a));
            Assert.IsFalse(ShapeCollisionDetection.CollidesWith(c, a));

            // rectangle-circle
            Assert.IsTrue(ShapeCollisionDetection.CollidesWith(a, b));
            Assert.IsFalse(ShapeCollisionDetection.CollidesWith(a, c));
        }

        [TestMethod]
        public void Circle_OrientedRectangle()
        {
            OrientedRectangle a = new OrientedRectangle(5, 4, 6, 4, 30.0f);
            Circle b = new Circle(5, 7, 2);
            Circle c = new Circle(15, 17, 2);

            // orient rectangle-circle
            Assert.IsTrue(ShapeCollisionDetection.CollidesWith(a, b));
            Assert.IsFalse(ShapeCollisionDetection.CollidesWith(a, c));

            // circle-oriented rectangle
            Assert.IsTrue(ShapeCollisionDetection.CollidesWith(b, a));
            Assert.IsFalse(ShapeCollisionDetection.CollidesWith(c, a));
        }

        [TestMethod]
        public void Circle_Point()
        {
            Circle a = new Circle(new Vector2(6.0f, 4.0f), 3.0f);
            Vector2 b = new Vector2(8.0f, 3.0f);
            Vector2 c = new Vector2(11.0f, 7.0f);

            // circle-point
            Assert.IsTrue(ShapeCollisionDetection.CollidesWith(a, b));
            Assert.IsFalse(ShapeCollisionDetection.CollidesWith(a, c));

            // point-circle
            Assert.IsTrue(ShapeCollisionDetection.CollidesWith(b, a));
            Assert.IsFalse(ShapeCollisionDetection.CollidesWith(c, a));
        }

        #endregion

        #region Line

        [TestMethod]
        public void Line_Line()
        {
            Vector2 a = new Vector2(3.0f, 5.0f);
            Vector2 b = new Vector2(3.0f, 2.0f);
            Vector2 c = new Vector2(8.0f, 4.0f);

            Vector2 down = new Vector2(5.0f, -1.0f);
            Vector2 up = new Vector2(5.0f, 2.0f);

            Line l1 = new Line(a, down);
            Line l2 = new Line(a, up);
            Line l3 = new Line(b, up);
            Line l4 = new Line(c, down);

            Assert.IsTrue(ShapeCollisionDetection.CollidesWith(l1, l2));
            Assert.IsTrue(ShapeCollisionDetection.CollidesWith(l1, l3));
            Assert.IsFalse(ShapeCollisionDetection.CollidesWith(l2, l3));
            Assert.IsTrue(ShapeCollisionDetection.CollidesWith(l1, l4));
        }

        [TestMethod]
        public void Line_LineSegment()
        {
            Vector2 lineBase = new Vector2(3.0f, 4.0f);
            Vector2 direction = new Vector2(4.0f, -2.0f);
            Vector2 point1 = new Vector2(8.0f, 4.0f);
            Vector2 point2 = new Vector2(11.0f, 7.0f);

            Line a = new Line(lineBase, direction);
            LineSegment b = new LineSegment(point1, point2);
            LineSegment c = new LineSegment(Vector2.Zero, point2);

            // line-line segment
            Assert.IsFalse(ShapeCollisionDetection.CollidesWith(a, b));
            Assert.IsTrue(ShapeCollisionDetection.CollidesWith(a, c));

            // line segment-line
            Assert.IsFalse(ShapeCollisionDetection.CollidesWith(b, a));
            Assert.IsTrue(ShapeCollisionDetection.CollidesWith(c, a));
        }

        [TestMethod]
        public void Line_Rectangle()
        {
            Line a = new Line(6, 8, 2, -3);
            Rectangle b = new Rectangle(3, 2, 6, 4);
            Rectangle c = new Rectangle(1, 1, 1, 1);

            // line-rectangle
            Assert.IsTrue(ShapeCollisionDetection.CollidesWith(a, b));
            Assert.IsFalse(ShapeCollisionDetection.CollidesWith(a, c));

            // rectangle-line
            Assert.IsTrue(ShapeCollisionDetection.CollidesWith(b, a));
            Assert.IsFalse(ShapeCollisionDetection.CollidesWith(c, a));
        }

        [TestMethod]
        public void Line_OrientedRectangle()
        {
            Line a = new Line(7, 3, 2, -1);
            OrientedRectangle b = new OrientedRectangle(5, 4, 6, 4, 30.0f);
            OrientedRectangle c = new OrientedRectangle(1.5f, 1.5f, 1.0f, 1.0f, 0.0f);

            // line-oriented rectangle
            Assert.IsTrue(ShapeCollisionDetection.CollidesWith(a, b));
            Assert.IsFalse(ShapeCollisionDetection.CollidesWith(a, c));

            // oriented rectangle-line
            Assert.IsTrue(ShapeCollisionDetection.CollidesWith(b, a));
            Assert.IsFalse(ShapeCollisionDetection.CollidesWith(c, a));
        }

        [TestMethod]
        public void Line_Point()
        {
            Line a = new Line(3, 7, 7, -2);
            Vector2 b = new Vector2(3.0f, 7.0f);
            Vector2 c = new Vector2(10.0f, 5.0f);
            Vector2 d = new Vector2(5.0f, 3.0f);

            // line-point
            Assert.IsTrue(ShapeCollisionDetection.CollidesWith(a, b));
            Assert.IsTrue(ShapeCollisionDetection.CollidesWith(a, c));
            Assert.IsFalse(ShapeCollisionDetection.CollidesWith(a, d));

            // point-line
            Assert.IsTrue(ShapeCollisionDetection.CollidesWith(b, a));
            Assert.IsTrue(ShapeCollisionDetection.CollidesWith(c, a));
            Assert.IsFalse(ShapeCollisionDetection.CollidesWith(d, a));
        }

        #endregion

        #region LineSegment

        [TestMethod]
        public void LineSegment_LineSegment()
        {
            Vector2 a = new Vector2(3.0f, 4.0f);
            Vector2 b = new Vector2(11.0f, 1.0f);
            Vector2 c = new Vector2(8.0f, 4.0f);
            Vector2 d = new Vector2(11.0f, 7.0f);
            Vector2 e = new Vector2(0.0f, 0.0f);

            LineSegment ls1 = new LineSegment(a, b);
            LineSegment ls2 = new LineSegment(c, d);
            LineSegment ls3 = new LineSegment(e, c);

            Assert.IsFalse(ShapeCollisionDetection.CollidesWith(ls1, ls2));
            Assert.IsTrue(ShapeCollisionDetection.CollidesWith(ls1, ls3));
        }

        [TestMethod]
        public void LineSegment_Rectangle()
        {
            LineSegment a = new LineSegment(6, 8, 10, 2);
            Rectangle b = new Rectangle(3, 2, 6, 4);
            Rectangle c = new Rectangle(1, 1, 1, 1);

            // line segment-rectangle
            Assert.IsTrue(ShapeCollisionDetection.CollidesWith(a, b));
            Assert.IsFalse(ShapeCollisionDetection.CollidesWith(a, c));

            // rectangle-line segment
            Assert.IsTrue(ShapeCollisionDetection.CollidesWith(b, a));
            Assert.IsFalse(ShapeCollisionDetection.CollidesWith(c, a));
        }

        [TestMethod]
        public void LineSegment_OrientedRectangle()
        {
            LineSegment a = new LineSegment(1, 8, 7, 5);
            OrientedRectangle b = new OrientedRectangle(5, 4, 6, 4, 30.0f);
            OrientedRectangle c = new OrientedRectangle(1.5f, 1.5f, 1.0f, 1.0f, 0.0f);

            // line segment-oriented rectangle
            Assert.IsTrue(ShapeCollisionDetection.CollidesWith(a, b));
            Assert.IsFalse(ShapeCollisionDetection.CollidesWith(a, c));

            // oriented rectangle-line segment
            Assert.IsTrue(ShapeCollisionDetection.CollidesWith(b, a));
            Assert.IsFalse(ShapeCollisionDetection.CollidesWith(c, a));
        }

        [TestMethod]
        public void LineSegment_Point()
        {
            LineSegment a = new LineSegment(6, 6, 13, 4);
            Vector2 b = new Vector2(6.0f, 6.0f);
            Vector2 c = new Vector2(13.0f, 4.0f);
            Vector2 d = new Vector2(1.0f, 4.0f);

            // line segment-point
            Assert.IsTrue(ShapeCollisionDetection.CollidesWith(a, b));
            Assert.IsTrue(ShapeCollisionDetection.CollidesWith(a, c));
            Assert.IsFalse(ShapeCollisionDetection.CollidesWith(a, d));

            // point-line segment
            Assert.IsTrue(ShapeCollisionDetection.CollidesWith(b, a));
            Assert.IsTrue(ShapeCollisionDetection.CollidesWith(c, a));
            Assert.IsFalse(ShapeCollisionDetection.CollidesWith(d, a));
        }

        #endregion

        #region Rectangle

        [TestMethod]
        public void Rectangle_Rectangle()
        {
            Rectangle a = new Rectangle(1, 1, 4, 4);
            Rectangle b = new Rectangle(2, 2, 5, 5);
            Rectangle c = new Rectangle(6, 4, 4, 2);

            Assert.IsTrue(ShapeCollisionDetection.CollidesWith(a, b));
            Assert.IsTrue(ShapeCollisionDetection.CollidesWith(b, c));
            Assert.IsFalse(ShapeCollisionDetection.CollidesWith(a, c));
        }

        [TestMethod]
        public void Rectangle_OrientedRectangle()
        {
            Rectangle a = new Rectangle(1, 5, 3, 3);
            Rectangle b = new Rectangle(1, 1, 15, 15);
            OrientedRectangle c = new OrientedRectangle(10, 4, 8, 4, 25.0f);

            // rectangle-oriented rectangle
            Assert.IsFalse(ShapeCollisionDetection.CollidesWith(a, c));
            Assert.IsTrue(ShapeCollisionDetection.CollidesWith(b, c));

            // oriented rectangle-rectangle
            Assert.IsFalse(ShapeCollisionDetection.CollidesWith(c, a));
            Assert.IsTrue(ShapeCollisionDetection.CollidesWith(c, b));
        }

        [TestMethod]
        public void Rectangle_Point()
        {
            Rectangle a = new Rectangle(3, 2, 6, 4);
            Vector2 b = new Vector2(4.0f, 5.0f);
            Vector2 c = new Vector2(11.0f, 4.0f);

            // rectangle-point
            Assert.IsTrue(ShapeCollisionDetection.CollidesWith(a, b));
            Assert.IsFalse(ShapeCollisionDetection.CollidesWith(a, c));

            // point-rectangle
            Assert.IsTrue(ShapeCollisionDetection.CollidesWith(b, a));
            Assert.IsFalse(ShapeCollisionDetection.CollidesWith(c, a));
        }

        #endregion

        #region OrientedRectangle

        [TestMethod]
        public void OrientedRectangle_OrientedRectangle()
        {
            OrientedRectangle a = new OrientedRectangle(3, 5, 2, 6, 15.0f);
            OrientedRectangle b = new OrientedRectangle(10, 5, 4, 4, -15.0f);

            Assert.IsTrue(ShapeCollisionDetection.CollidesWith(a, a));
            Assert.IsFalse(ShapeCollisionDetection.CollidesWith(a, b));
        }

        [TestMethod]
        public void OrientedRectangle_Point()
        {
            OrientedRectangle a = new OrientedRectangle(5, 4, 6, 4, 30.0f);
            OrientedRectangle b = new OrientedRectangle(1.5f, 1.5f, 1.0f, 1.0f, 0.0f);
            Vector2 c = new Vector2(6.0f, 5.0f);
            Vector2 d = new Vector2(10.0f, 6.0f);
            Vector2 e = new Vector2(1.0f, 1.0f);
            Vector2 f = new Vector2(2.0f, 1.0f);
            Vector2 g = new Vector2(2.0f, 2.0f);
            Vector2 h = new Vector2(1.0f, 2.0f);
            Vector2 i = new Vector2(1.5f, 1.5f);

            // orient rectangle-point
            Assert.IsTrue(ShapeCollisionDetection.CollidesWith(a, c));
            Assert.IsFalse(ShapeCollisionDetection.CollidesWith(a, d));
            Assert.IsFalse(ShapeCollisionDetection.CollidesWith(b, c));
            Assert.IsTrue(ShapeCollisionDetection.CollidesWith(b, e));
            Assert.IsTrue(ShapeCollisionDetection.CollidesWith(b, f));
            Assert.IsTrue(ShapeCollisionDetection.CollidesWith(b, g));
            Assert.IsTrue(ShapeCollisionDetection.CollidesWith(b, h));
            Assert.IsTrue(ShapeCollisionDetection.CollidesWith(b, i));

            // point-oriented rectangle
            Assert.IsTrue(ShapeCollisionDetection.CollidesWith(c, a));
            Assert.IsFalse(ShapeCollisionDetection.CollidesWith(d, a));
            Assert.IsFalse(ShapeCollisionDetection.CollidesWith(c, b));
            Assert.IsTrue(ShapeCollisionDetection.CollidesWith(e, b));
            Assert.IsTrue(ShapeCollisionDetection.CollidesWith(f, b));
            Assert.IsTrue(ShapeCollisionDetection.CollidesWith(g, b));
            Assert.IsTrue(ShapeCollisionDetection.CollidesWith(h, b));
            Assert.IsTrue(ShapeCollisionDetection.CollidesWith(i, b));
        }

        #endregion

        #region Point

        [TestMethod]
        public void Point_Point()
        {
            Vector2 a = new Vector2(2.0f, 3.0f);
            Vector2 b = new Vector2(2.0f, 3.0f);
            Vector2 c = new Vector2(3.0f, 4.0f);

            Assert.IsTrue(ShapeCollisionDetection.CollidesWith(a, b));
            Assert.IsFalse(ShapeCollisionDetection.CollidesWith(a, c));
            Assert.IsFalse(ShapeCollisionDetection.CollidesWith(b, c));
        }

        #endregion
    }
}