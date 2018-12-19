using System.Numerics;
using ShapesLibrary;

namespace CollisionDetectionLibrary
{
    public static partial class ShapeCollisionDetection
    {
        // line segment-circle
        public static bool CollidesWith(LineSegment a, Circle b)
        {
            return a.Intersects(b);
        }

        // line segment-line
        public static bool CollidesWith(LineSegment a, Line b)
        {
            return a.Intersects(b);
        }

        // line segment-line segment
        public static bool CollidesWith(LineSegment a, LineSegment b)
        {
            return a.Intersects(b);
        }

        // line segment-rectangle
        public static bool CollidesWith(LineSegment a, Rectangle b)
        {
            return a.Intersects(b);
        }

        // line segment-oriented rectangle
        public static bool CollidesWith(LineSegment a, OrientedRectangle b)
        {
            return a.Intersects(b);
        }

        // line segment-point
        public static bool CollidesWith(LineSegment a, Vector2 b)
        {
            return a.Intersects(b);
        }
    }
}