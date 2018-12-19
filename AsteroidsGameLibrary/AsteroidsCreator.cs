using AsteroidsGameLibrary.Entities;
using GeneralUtilities;

namespace AsteroidsGameLibrary
{
    public static class AsteroidsCreator
    {
        public static Asteroids CreateAsteroids(int numberToCreate)
        {
            var asteroids = new Asteroids();

            for (int i = 0; i < 1000; ++i)
            {
                Asteroid asteroid = CreateAsteroid(asteroids);

                bool asteroidCollision = asteroids.CollidesWith(asteroid);
                bool middleX = new Range<float>(GameSettings.Resolution.X * Constants.ONE_THIRD, GameSettings.Resolution.X * Constants.TWO_THIRDS).ContainsValue(asteroid.Position.X);
                bool middleY = new Range<float>(GameSettings.Resolution.Y * Constants.ONE_THIRD, GameSettings.Resolution.Y * Constants.TWO_THIRDS).ContainsValue(asteroid.Position.Y);
                if (asteroidCollision || (middleX && middleY))
                {
                }
                else
                {
                    asteroids.Add(asteroid);
                }

                if (asteroids.Count >= numberToCreate) break;
            }

            return asteroids;
        }

        private static Asteroid CreateAsteroid(Asteroids asteroids)
        {
            float x = RandomHelper.RandomNumber(20.0f, GameSettings.Resolution.X - 20.0f);
            float y = RandomHelper.RandomNumber(20.0f, GameSettings.Resolution.Y - 20.0f);
            float r = RandomHelper.RandomNumber(1.0f, 3.0f);

            var asteroid = new Asteroid(new System.Numerics.Vector2(x, y), 20.0f, 6, r);

            return asteroid;
        }
    }
}