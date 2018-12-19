using System.Collections.Generic;
using System.Numerics;
using CollisionDetectionLibrary;
using GeneralUtilities;
using ShapesLibrary;

namespace AsteroidsGameLibrary.Entities
{
    public class Asteroid
    {
        private float _asteroidSpeedPerSecond;
        private Vector2 _direction;
        private readonly float _rotationRateInRadians;

        public List<Vector2> Vertices { get; private set; } // center of asteroid
        public Vector2 Position { get; private set; }
        public float Size { get; }
        public Color Color { get; }

        public CollisionBoundary CollisionBoundary
        {
            get
            {
                var shapes = new Shapes();

                for (int i = 0; i < Vertices.Count; ++i)
                {
                    int v2 = i == Vertices.Count - 1 ? 0 : i + 1;
                    shapes.Add(new LineSegment(Position.X + Vertices[i].X * Size, Position.Y + Vertices[i].Y * Size,
                                               Position.X + Vertices[v2].X * Size, Position.Y + Vertices[v2].Y * Size));
                }

                var cb = new CollisionBoundary(shapes);

                return cb;
            }
        }

        public Asteroid(Vector2 position, float size, int numberOfVertices, float rotationRateInRadians)
        {
            Position = position;
            Size = size;
            _rotationRateInRadians = rotationRateInRadians;
            _direction = new Vector2(RandomHelper.RandomNumber(-1.0f, 1.0f), RandomHelper.RandomNumber(-1.0f, 1.0f)); // TODO: use radians and convert to vector
            _asteroidSpeedPerSecond = 100.0f;

            Vertices = new List<Vector2>(numberOfVertices);
            Vertices.Add(new Vector2(RandomHelper.RandomNumber(-0.9f, -0.1f), RandomHelper.RandomNumber(-1.4f, -0.6f)));
            Vertices.Add(new Vector2(RandomHelper.RandomNumber(0.1f, 0.9f), RandomHelper.RandomNumber(-1.4f, -0.6f)));
            Vertices.Add(new Vector2(RandomHelper.RandomNumber(0.6f, 1.4f), RandomHelper.RandomNumber(-0.4f, 0.4f)));
            Vertices.Add(new Vector2(RandomHelper.RandomNumber(0.1f, 0.9f), RandomHelper.RandomNumber(0.6f, 1.4f)));
            Vertices.Add(new Vector2(RandomHelper.RandomNumber(-0.9f, -0.1f), RandomHelper.RandomNumber(0.6f, 1.4f)));
            Vertices.Add(new Vector2(RandomHelper.RandomNumber(-1.4f, -0.6f), RandomHelper.RandomNumber(-0.4f, 0.4f)));

            Color = Color.HotPink;
        }

        public void Update(float deltaTime)
        {
            Position = Position + _direction * _asteroidSpeedPerSecond * deltaTime;

            Position = Helper.WrapAround(Position, GameSettings.Resolution);

            var newVertices = new List<Vector2>(Vertices.Count);
            foreach (Vector2 vertex in Vertices)
            {
                float rotationRateInRadians = _rotationRateInRadians * deltaTime;
                newVertices.Add(vertex.RotateAroundPoint(Vector2.Zero, rotationRateInRadians));
            }

            Vertices = newVertices;
        }

        public bool AsteroidHit()
        {
            int indexOfVertexToRemove = RandomHelper.RandomNumber(0, Vertices.Count - 1);
            Vertices.RemoveAt(indexOfVertexToRemove);

            if (Vertices.Count <= 2)
            {
                return true;
            }

            return false;
        }
    }
}