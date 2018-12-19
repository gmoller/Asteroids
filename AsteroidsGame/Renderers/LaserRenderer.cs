using Microsoft.Xna.Framework.Graphics;
using AsteroidsGameLibrary.Entities;

namespace AsteroidsGame.Renderers
{
    public static class LaserRenderer
    {
        public static void Draw(SpriteBatch spriteBatch, Laser laser)
        {
            if (laser.IsFiring)
            {
                ParticleSystemRenderer.Draw(spriteBatch, laser.LaserParticleSystem.Particles);
            }
        }
    }
}