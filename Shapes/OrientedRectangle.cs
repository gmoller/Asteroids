using System;
using System.Numerics;
using GeneralUtilities;

namespace ShapesLibrary
{
    public class OrientedRectangle : Shape
    {
        private LineSegment _edge0;
        private LineSegment _edge1;
        private LineSegment _edge2;
        private LineSegment _edge3;
        private Vector2? _vertex0;
        private Vector2? _vertex1;
        private Vector2? _vertex2;
        private Vector2? _vertex3;

        public Vector2 Center { get; }
        public Vector2 Size { get; }
        public Vector2 HalfExtend { get; }
        public float RotationInDegrees { get; }

        public LineSegment Edge0 => _edge0 ?? (_edge0 = GetEdge(0));
        public LineSegment Edge1 => _edge1 ?? (_edge1 = GetEdge(1));
        public LineSegment Edge2 => _edge2 ?? (_edge2 = GetEdge(2));
        public LineSegment Edge3 => _edge3 ?? (_edge3 = GetEdge(3));

        public Vector2 Corner0 { get { if (_vertex0 == null) { _vertex0 = GetVertex(new Vector2(Center.X - HalfExtend.X, Center.Y + HalfExtend.Y)); } return _vertex0.Value; } }
        public Vector2 Corner1 { get { if (_vertex1 == null) { _vertex1 = GetVertex(new Vector2(Center.X + HalfExtend.X, Center.Y + HalfExtend.Y)); } return _vertex1.Value; } }
        public Vector2 Corner2 { get { if (_vertex2 == null) { _vertex2 = GetVertex(new Vector2(Center.X + HalfExtend.X, Center.Y - HalfExtend.Y)); } return _vertex2.Value; } }
        public Vector2 Corner3 { get { if (_vertex3 == null) { _vertex3 = GetVertex(new Vector2(Center.X - HalfExtend.X, Center.Y - HalfExtend.Y)); } return _vertex3.Value; } }

        public OrientedRectangle(Vector2 center, Vector2 size, float rotationInDegrees)
        {
            Center = center;
            Size = size;
            HalfExtend = size / 2;
            RotationInDegrees = rotationInDegrees;
        }

        public OrientedRectangle(float centerX, float centerY, float width, float height, float rotationInDegrees)
            : this(new Vector2(centerX, centerY), new Vector2(width, height), rotationInDegrees)
        {
        }

        public OrientedRectangle(int centerX, int centerY, int width, int height, float rotationInDegrees)
            : this(new Vector2(centerX, centerY), new Vector2(width, height), rotationInDegrees)
        {
        }

        #region Intersects

        public bool Intersects(Circle c)
        {
            return c.Intersects(this);
        }

        public bool Intersects(Line l)
        {
            return l.Intersects(this);
        }

        public bool Intersects(LineSegment ls)
        {
            return ls.Intersects(this);
        }

        public bool Intersects(Rectangle r)
        {
            return r.Intersects(this);
        }

        public bool Intersects(OrientedRectangle or)
        {
            if (or.HasSeparatingAxis(Edge0))
            {
                return false;
            }
            if (or.HasSeparatingAxis(Edge1))
            {
                return false;
            }
            if (HasSeparatingAxis(or.Edge0))
            {
                return false;
            }
            if (HasSeparatingAxis(or.Edge1))
            {
                return false;
            }

            return true;
        }

        public bool Intersects(Vector2 v)
        {
            Rectangle lr = ToLocalRectangle();

            Vector2 lp = v - Center;
            lp = lp.Rotate(-RotationInDegrees);
            lp = lp + HalfExtend;

            bool overlaps = lr.Intersects(lp);

            return overlaps;
        }

        #endregion

        private bool HasSeparatingAxis(LineSegment axis)
        {
            Vector2 n = axis.Point1 - axis.Point2;

            Range<float> axisRange = axis.Project(n);
            Range<float> r0Range = Edge0.Project(n);
            Range<float> r2Range = Edge2.Project(n);
            Range<float> rProjection = r0Range.Hull(r2Range);

            return !axisRange.IntersectsRange(rProjection);
        }

        private Vector2 GetVertex(Vector2 v)
        {
            return v.RotateAroundPoint(Center, RotationInDegrees.ToRadians());
        }

        private LineSegment GetEdge(int edgeNumber)
        {
            Vector2 a = HalfExtend;
            Vector2 b = HalfExtend;

            switch (edgeNumber)
            {
                case 0:
                    a.X = -a.X;
                    break;
                case 1:
                    b.Y = -b.Y;
                    break;
                case 2:
                    a.Y = -a.Y;
                    b = -b;
                    break;
                case 3:
                    a = -a;
                    b.X = -b.X;
                    break;
                default:
                    throw new NotImplementedException();

            }

            a = a.Rotate(RotationInDegrees);
            a += Center;

            b = b.Rotate(RotationInDegrees);
            b += Center;

            LineSegment edge = new LineSegment(a, b);

            return edge;
        }

        public Rectangle ToLocalRectangle()
        {
            return new Rectangle(new Vector2(0.0f, 0.0f), Size);
        }

        public Circle GetCircleHull()
        {
            Circle hull = new Circle(Center, HalfExtend.Length());

            return hull;
        }

        public Rectangle GetRectangleHull()
        {
            Rectangle hull = new Rectangle(Center, Vector2.Zero);

            hull = hull.EnlargePoint(Corner0);
            hull = hull.EnlargePoint(Corner1);
            hull = hull.EnlargePoint(Corner2);
            hull = hull.EnlargePoint(Corner3);

            return hull;
        }
    }
}