using System.Numerics;
using ShapesLibrary;

namespace CollisionDetectionLibrary
{
    public static partial class ShapeCollisionDetection
    {
        // circle-circle
        public static bool CollidesWith(Circle a, Circle b)
        {
            return a.Intersects(b);
        }

        // circle-line
        public static bool CollidesWith(Circle a, Line b)
        {
            return a.Intersects(b);
        }

        // circle-linesegment
        public static bool CollidesWith(Circle a, LineSegment b)
        {
            return a.Intersects(b);
        }

        // circle-rectangle
        public static bool CollidesWith(Circle a, Rectangle b)
        {
            return a.Intersects(b);
        }

        // circle-oriented rectangle
        public static bool CollidesWith(Circle a, OrientedRectangle b)
        {
            return a.Intersects(b);
        }

        // circle-point
        public static bool CollidesWith(Circle a, Vector2 b)
        {
            return a.Intersects(b);
        }
    }
}