using AsteroidsGameLibrary.Entities;

namespace AsteroidsGameLibrary
{
    public class CollisionChecker
    {
        public static bool IsColliding(SpaceShip spaceShip, Asteroid asteroid)
        {
            return spaceShip.CollisionBoundary.CollidesWith(asteroid.CollisionBoundary);
        }

        public static bool IsColliding(Laser laser, Asteroid asteroid)
        {
            return laser.CollisionBoundary.CollidesWith(asteroid.CollisionBoundary);
        }

        public static bool IsColliding(Asteroid asteroid1, Asteroid asteroid2)
        {
            return asteroid1.CollisionBoundary.CollidesWith(asteroid2.CollisionBoundary);
        }
    }
}