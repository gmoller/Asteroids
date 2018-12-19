using System.Numerics;
using ShapesLibrary;

namespace CollisionDetectionLibrary
{
    public static partial class ShapeCollisionDetection
    {
        // point-circle
        public static bool CollidesWith(Vector2 a, Circle b)
        {
            return b.Intersects(a);
        }

        // point-line
        public static bool CollidesWith(Vector2 a, Line b)
        {
            return b.Intersects(a);
        }

        // point-line segment
        public static bool CollidesWith(Vector2 a, LineSegment b)
        {
            return b.Intersects(a);
        }

        // point-rectangle
        public static bool CollidesWith(Vector2 a, Rectangle b)
        {
            return b.Intersects(a);
        }

        // point-oriented rectangle
        public static bool CollidesWith(Vector2 a, OrientedRectangle b)
        {
            return b.Intersects(a);
        }

        // point-point
        public static bool CollidesWith(Vector2 a, Vector2 b)
        {
            return a.Equals(b);
        }
    }
}