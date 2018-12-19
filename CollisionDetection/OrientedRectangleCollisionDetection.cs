using System.Numerics;
using ShapesLibrary;

namespace CollisionDetectionLibrary
{
    public static partial class ShapeCollisionDetection
    {
        //oriented rectangle-circle
        public static bool CollidesWith(OrientedRectangle a, Circle b)
        {
            return a.Intersects(b);
        }

        // oriented rectangle-line
        public static bool CollidesWith(OrientedRectangle a, Line b)
        {
            return a.Intersects(b);
        }

        // oriented rectangle-line segment
        public static bool CollidesWith(OrientedRectangle a, LineSegment b)
        {
            return a.Intersects(b);
        }

        // oriented rectangle-rectangle
        public static bool CollidesWith(OrientedRectangle a, Rectangle b)
        {
            return a.Intersects(b);
        }

        // oriented rectangle-oriented rectangle
        public static bool CollidesWith(OrientedRectangle a, OrientedRectangle b)
        {
            return a.Intersects(b);
        }

        // oriented rectangle-point
        public static bool CollidesWith(OrientedRectangle a, Vector2 b)
        {
            return a.Intersects(b);
        }
    }
}