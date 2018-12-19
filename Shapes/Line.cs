using System.Numerics;
using GeneralUtilities;

namespace ShapesLibrary
{
    public class Line : Shape
    {
        public Vector2 Base { get; }
        public Vector2 Direction { get; }

        public Line(Vector2 lineBase, Vector2 direction)
        {
            Base = lineBase;
            Direction = direction;
        }

        public Line(float baseX, float baseY, float directionX, float directionY)
            : this(new Vector2(baseX, baseY), new Vector2(directionX, directionY))
        {
        }

        public Line(int baseX, int baseY, int directionX, int directionY)
            : this(new Vector2(baseX, baseY), new Vector2(directionX, directionY))
        {
        }

        public bool Equivalent(Line line)
        {
            bool equivalent;
            if (!Direction.Parallel(line.Direction))
            {
                equivalent = false;
            }
            else
            {
                Vector2 d = Base - line.Base;
                equivalent = d.Parallel(Direction);
            }

            return equivalent;
        }

        public bool OnOneSide(LineSegment ls)
        {
            Vector2 d1 = ls.Point1 - Base;
            Vector2 d2 = ls.Point2 - Base;
            Vector2 n = Direction.Rotate90();

            float f = n.Dot(d1) * n.Dot(d2);

            return f > 0;
        }

        #region Intersects

        public bool Intersects(Circle c)
        {
            return c.Intersects(this);
        }

        public bool Intersects(Line l)
        {
            if (Direction.Parallel(l.Direction))
            {
                bool overlaps = Equivalent(l);

                return overlaps;
            }

            return true;
        }

        public bool Intersects(LineSegment ls)
        {
            bool overlaps = OnOneSide(ls) == false;

            return overlaps;
        }

        public bool Intersects(Rectangle r)
        {
            Vector2 n = Direction.Rotate90();

            Vector2 c1 = r.Origin;
            Vector2 c2 = c1 + r.Size;
            Vector2 c3 = new Vector2(c2.X, c1.Y);
            Vector2 c4 = new Vector2(c1.X, c2.Y);

            c1 = c1 - Base;
            c2 = c2 - Base;
            c3 = c3 - Base;
            c4 = c4 - Base;

            float dp1 = n.Dot(c1);
            float dp2 = n.Dot(c2);
            float dp3 = n.Dot(c3);
            float dp4 = n.Dot(c4);

            bool overlaps = (dp1 * dp2 <= 0) ||
                            (dp2 * dp3 <= 0) ||
                            (dp3 * dp4 <= 0);

            return overlaps;
        }

        public bool Intersects(OrientedRectangle or)
        {
            Rectangle lr = or.ToLocalRectangle();

            Vector2 lineBase = Base - or.Center;
            lineBase = lineBase.Rotate(-or.RotationInDegrees);
            lineBase = lineBase + or.HalfExtend;

            Line ll = new Line(lineBase, Direction.Rotate(-or.RotationInDegrees));

            bool overlaps = ll.Intersects(lr);

            return overlaps;
        }

        public bool Intersects(Vector2 v)
        {
            if (Base.Equals(v)) return true;

            Vector2 lp = v - Base;

            bool overlaps = lp.Parallel(Direction);

            return overlaps;
        }

        #endregion

    }
}