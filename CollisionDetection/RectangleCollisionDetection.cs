using System.Numerics;
using ShapesLibrary;

namespace CollisionDetectionLibrary
{
    public static partial class ShapeCollisionDetection
    {
        // rectangle-circle
        public static bool CollidesWith(Rectangle a, Circle b)
        {
            return a.Intersects(b);
        }

        // rectangle-line
        public static bool CollidesWith(Rectangle a, Line b)
        {
            return a.Intersects(b);
        }

        // rectangle-line segment
        public static bool CollidesWith(Rectangle a, LineSegment b)
        {
            return a.Intersects(b);
        }

        // rectangle-rectangle
        public static bool CollidesWith(Rectangle a, Rectangle b)
        {
            return a.Intersects(b);
        }

        // rectangle-oriented rectangle
        public static bool CollidesWith(Rectangle a, OrientedRectangle b)
        {
            return a.Intersects(b);
        }

        // rectangle-point
        public static bool CollidesWith(Rectangle a, Vector2 b)
        {
            return a.Intersects(b);
        }
    }
}