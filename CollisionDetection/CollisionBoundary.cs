using System;
using ShapesLibrary;

namespace CollisionDetectionLibrary
{
    public class CollisionBoundary
    {
        public Shapes Shapes { get; }

        public CollisionBoundary(Shape shape)
        {
            Shapes = new Shapes();
            Shapes.Add(shape);
        }

        public CollisionBoundary(Shapes shapes)
        {
            Shapes = shapes;
        }

        public bool CollidesWith(CollisionBoundary collisionBoundary)
        {
            bool collides = false;

            // check outer hull
            //Shape hull1 = Shapes.GetHull();
            //Shape hull2 = collisionBoundary.Shapes.GetHull();
            //if (CollidesWith(hull1, hull2))
            {
                // check each shape
                collides = CheckEachShape(Shapes, collisionBoundary.Shapes);
            }

            return collides;
        }

        private bool CheckEachShape(Shapes collisionBoundaryShapes1, Shapes collisionBoundaryShapes2)
        {
            bool collides = false;

            foreach (Shape shape1 in collisionBoundaryShapes1)
            {
                foreach (Shape shape2 in collisionBoundaryShapes2)
                {
                    collides = CollidesWith(shape1, shape2);
                    if (collides)
                    {
                        return true;
                    }
                }
            }

            return collides;
        }

        private bool CollidesWith(Shape shape1, Shape shape2)
        {
            if (shape1 is Circle)
            {
                if (shape2 is Circle)
                {
                    return ShapeCollisionDetection.CollidesWith((Circle)shape1, (Circle)shape2);
                }
            }

            if (shape1 is Rectangle)
            {
                if (shape2 is Circle)
                {
                    return ShapeCollisionDetection.CollidesWith((Rectangle)shape1, (Circle)shape2);
                }
            }

            if (shape1 is OrientedRectangle)
            {
                if (shape2 is Circle)
                {
                    return ShapeCollisionDetection.CollidesWith((OrientedRectangle)shape1, (Circle)shape2);
                }
                else if (shape2 is LineSegment)
                {
                    return ShapeCollisionDetection.CollidesWith((OrientedRectangle)shape1, (LineSegment)shape2);
                }
            }

            if (shape1 is LineSegment)
            {
                if (shape2 is Circle)
                {
                    return ShapeCollisionDetection.CollidesWith((LineSegment)shape1, (Circle)shape2);
                }
                else if (shape2 is LineSegment)
                {
                    return ShapeCollisionDetection.CollidesWith((LineSegment)shape1, (LineSegment)shape2);
                }
            }

            throw new NotImplementedException($"Type1: [{shape1.GetType()}], Type2: [{shape2.GetType()}] not implemented.");
        }
    }
}