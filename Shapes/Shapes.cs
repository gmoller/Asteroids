using System.Collections;
using System.Collections.Generic;

namespace ShapesLibrary
{
    public class Shapes : IEnumerable<Shape>
    {
        private readonly List<Shape> _shapes;

        public Shapes()
        {
            _shapes = new List<Shape>();
        }

        public void Add(Shape shape)
        {
            _shapes.Add(shape);
        }

        public IEnumerator<Shape> GetEnumerator()
        {
            return ((IEnumerable<Shape>)_shapes).GetEnumerator();
        }

        public Rectangle GetHull()
        {
            Rectangle hull = new Rectangle(0, 0, 0, 0);
            foreach (Rectangle shape in _shapes)
            {
                hull = hull.EnlargeRectangle(shape);
            }

            return hull;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<Shape>)_shapes).GetEnumerator();
        }
    }
}