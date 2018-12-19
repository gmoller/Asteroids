using System.Collections;
using System.Collections.Generic;
using AsteroidsGameLibrary.Entities;

namespace AsteroidsGameLibrary
{
    public class Asteroids : IEnumerable<Asteroid>
    {
        private readonly List<Asteroid> _asteroids;

        public int Count => _asteroids.Count;

        public Asteroids()
        {
            _asteroids = new List<Asteroid>();
        }

        public void Add(Asteroid asteroid)
        {
            _asteroids.Add(asteroid);
        }

        public bool CollidesWith(Asteroid asteroid)
        {
            foreach (Asteroid item in _asteroids)
            {
                if (CollisionChecker.IsColliding(asteroid, item)) return true;
            }

            return false;
        }

        public IEnumerator<Asteroid> GetEnumerator()
        {
            return ((IEnumerable<Asteroid>)_asteroids).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<Asteroid>)_asteroids).GetEnumerator();
        }
    }
}