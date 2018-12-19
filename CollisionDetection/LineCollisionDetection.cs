using System.Numerics;
using ShapesLibrary;

namespace CollisionDetectionLibrary
{
    public static partial class ShapeCollisionDetection
    {
        // line-circle
        public static bool CollidesWith(Line a, Circle b)
        {
            return a.Intersects(b);
        }

        // line-line
        public static bool CollidesWith(Line a, Line b)
        {
            return a.Intersects(b);
        }

        // line-line segment
        public static bool CollidesWith(Line a, LineSegment b)
        {
            return a.Intersects(b);
        }

        // line-rectangle
        public static bool CollidesWith(Line a, Rectangle b)
        {
            return a.Intersects(b);
        }

        // line-oriented rectangle
        public static bool CollidesWith(Line a, OrientedRectangle b)
        {
            return a.Intersects(b);
        }

        // line-point
        public static bool CollidesWith(Line a, Vector2 b)
        {
            return a.Intersects(b);
        }
    }
}