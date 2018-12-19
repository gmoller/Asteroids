using System;
using System.Numerics;
using GeneralUtilities;

namespace ShapesLibrary
{
    public class Rectangle : Shape
    {
        public Vector2 Origin { get; }
        public Vector2 Size { get; }
        public Vector2 Center => new Vector2(Origin.X + Size.X / 2, Origin.Y + Size.Y / 2);

        public Vector2 Corner0 => new Vector2(Origin.X + Size.X, Origin.Y);
        public Vector2 Corner1 => Origin + Size;
        public Vector2 Corner2 => new Vector2(Origin.X, Origin.Y + Size.Y);
        public Vector2 Corner3 => Origin;

        public float Left => Origin.X;
        public float Right => Origin.X + Size.X;
        public float Top => Origin.Y;
        public float Bottom => Origin.Y + Size.Y;

        public Rectangle(Vector2 origin, Vector2 size)
        {
            Origin = origin;
            Size = size;
        }

        public Rectangle(float x, float y, float width, float height)
            : this(new Vector2(x, y), new Vector2(width, height))
        {
        }

        public Rectangle(int x, int y, int width, int height)
            : this(new Vector2(x, y), new Vector2(width, height))
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
            Range<float> a = new Range<float>(Left, Right);
            Range<float> b = new Range<float>(r.Left, r.Right);

            Range<float> c = new Range<float>(Top, Bottom).SortAscending();
            Range<float> d = new Range<float>(r.Top, r.Bottom).SortAscending();

            bool overlaps = a.IntersectsRange(b) && c.IntersectsRange(d);

            return overlaps;
        }

        public bool Intersects(OrientedRectangle or)
        {
            //TODO: implemented faster algorithm

            OrientedRectangle or2 = new OrientedRectangle(Center, Size, 0.0f);

            bool overlaps = or.Intersects(or2);

            //Rectangle orHull = or.GetRectangleHull();

            //if (orHull.Intersects(this) == false) return false;

            //LineSegment edge = or.Edge0;
            ////if (edge.SeparatingAxisForRectangle(this)) return false;

            //edge = or.Edge1;
            ////bool overlaps = edge.SeparatingAxisForRectangle(this) == false;
            //bool overlaps = false;

            return overlaps;
        }

        public bool Intersects(Vector2 v)
        {
            bool overlaps = Left <= v.X && Bottom >= v.Y && v.X <= Right && v.Y >= Top;

            return overlaps;
        }

        #endregion

        public Rectangle EnlargePoint(Vector2 p)
        {
            Vector2 origin = new Vector2(Math.Min(Left, p.X), Math.Min(Top, p.Y));
            Vector2 size = new Vector2(Math.Max(Right, p.X), Math.Max(Bottom, p.Y));
            size = size - origin;

            return new Rectangle(origin, size);
        }

        public Rectangle EnlargeRectangle(Rectangle r)
        {
            Vector2 maxCorner = r.Origin + r.Size;
            Rectangle enlarged = EnlargePoint(maxCorner);

            return enlarged.EnlargePoint(r.Origin);
        }
    }
}