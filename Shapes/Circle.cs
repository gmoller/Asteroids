using System.Numerics;
using GeneralUtilities;

namespace ShapesLibrary
{
    public class Circle : Shape
    {
        public Vector2 Center { get; }
        public float Radius { get; }

        public Circle(Vector2 center, float radius)
        {
            Center = center;
            Radius = radius;
        }

        public Circle(float x, float y, float radius)
            : this(new Vector2(x, y), radius)
        {
        }

        public Circle(int x, int y, int radius)
            : this(new Vector2(x, y), radius)
        {
        }

        #region Intersects

        public bool Intersects(Circle c)
        {
            float radiusSum = Radius + c.Radius;
            Vector2 distance = Center - c.Center;
            bool overlaps = distance.Length() <= radiusSum;

            return overlaps;
        }

        public bool Intersects(Line l)
        {
            Vector2 lc = Center - l.Base;
            Vector2 p = lc.Project(l.Direction);
            Vector2 nearest = l.Base + p;

            bool overlaps = Intersects(nearest);

            return overlaps;
        }

        public bool Intersects(LineSegment ls)
        {
            if (Intersects(ls.Point1))
            {
                return true;
            }
            if (Intersects(ls.Point2))
            {
                return true;
            }

            Vector2 d = ls.Point2 - ls.Point1;
            Vector2 lc = Center - ls.Point1;
            Vector2 p = lc.Project(d);
            Vector2 nearest = ls.Point1 + p;

            bool overlaps = Intersects(nearest) && p.Length() <= d.Length() && p.Dot(d) >= 0;

            return overlaps;
        }

        public bool Intersects(Rectangle r)
        {
            Vector2 clamped = Center.ClampOnRectangle(r);
            bool overlaps = Intersects(clamped);

            return overlaps;
        }

        public bool Intersects(OrientedRectangle or)
        {
            Rectangle lr = or.ToLocalRectangle();

            Vector2 distance = Center - or.Center;
            distance = distance.Rotate(-or.RotationInDegrees);

            Vector2 lcCenter = distance + or.HalfExtend;
            Circle lc = new Circle(lcCenter, Radius);

            bool overlaps = lr.Intersects(lc);

            return overlaps;
        }

        public bool Intersects(Vector2 v)
        {
            Vector2 distance = Center - v;
            bool overlaps = distance.Length() <= Radius;

            return overlaps;
        }

        #endregion

    }
}