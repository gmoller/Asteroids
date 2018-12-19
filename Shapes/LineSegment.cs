using System.Numerics;
using GeneralUtilities;

namespace ShapesLibrary
{
    public class LineSegment : Shape
    {
        public Vector2 Point1 { get; }
        public Vector2 Point2 { get; }

        public LineSegment(Vector2 point1, Vector2 point2)
        {
            Point1 = point1;
            Point2 = point2;
        }

        public LineSegment(float point1X, float point1Y, float point2X, float point2Y)
            : this(new Vector2(point1X, point1Y), new Vector2(point2X, point2Y))
        {
        }

        public LineSegment(int point1X, int point1Y, int point2X, int point2Y)
            : this(new Vector2(point1X, point1Y), new Vector2(point2X, point2Y))
        {
        }

        public Range<float> Project(Vector2 onto)
        {
            Vector2 ontoUnit = onto.Unit();

            float min = ontoUnit.Dot(Point1);
            float max = ontoUnit.Dot(Point2);
            Range<float> r = new Range<float>(min, max);
            r = r.SortAscending();

            return r;
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
            var axisA = new Line(Point1, Point2 - Point1);

            if (axisA.OnOneSide(ls))
            {
                return false;
            }

            var axisB = new Line(ls.Point1, ls.Point2 - ls.Point1);

            if (axisB.OnOneSide(this))
            {
                return false;
            }

            if (axisA.Direction.Parallel(axisB.Direction))
            {
                Range<float> rangeA = Project(axisA.Direction);
                Range<float> rangeB = ls.Project(axisA.Direction);

                bool overlaps = rangeA.IntersectsRange(rangeB);

                return overlaps;
            }

            return true;
        }

        public bool Intersects(Rectangle r)
        {
            Line line = new Line(Point1, Point2 - Point1);

            if (line.Intersects(r) == false) return false;

            Range<float> rRange = new Range<float>(r.Left, r.Right);
            Range<float> sRange = new Range<float>(Point1.X, Point2.X);
            sRange = sRange.SortAscending();

            if (rRange.IntersectsRange(sRange) == false) return false;

            rRange = new Range<float>(r.Top, r.Bottom);
            sRange = new Range<float>(Point1.Y, Point2.Y);
            sRange = sRange.SortAscending();

            bool overlaps = rRange.IntersectsRange(sRange);

            return overlaps;
        }

        public bool Intersects(OrientedRectangle or)
        {
            Rectangle lr = or.ToLocalRectangle();

            Vector2 point1 = Point1 - or.Center;
            point1 = point1.Rotate(-or.RotationInDegrees);
            point1 = point1 + or.HalfExtend;

            Vector2 point2 = Point2 - or.Center;
            point2 = point2.Rotate(-or.RotationInDegrees);
            point2 = point2 + or.HalfExtend;

            LineSegment ls = new LineSegment(point1, point2);

            bool overlaps = lr.Intersects(ls);

            return overlaps;
        }

        public bool Intersects(Vector2 v)
        {
            Vector2 d = Point2 - Point1;
            Vector2 lp = v - Point1;
            Vector2 pr = lp.Project(d);

            bool overlaps = lp == pr &&
                            pr.Length() <= d.Length() &&
                            pr.Dot(d) >= 0;

            return overlaps;
        }

        #endregion

    }
}