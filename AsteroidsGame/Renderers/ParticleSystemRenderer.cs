using Microsoft.Xna.Framework.Graphics;
using MonogameUtilities;
using ParticleSystemLibrary;

namespace AsteroidsGame.Renderers
{
    public static class ParticleSystemRenderer
    {
        public static void Draw(SpriteBatch spriteBatch, ParticleSystem particleSystem)
        {
            foreach (Particle particle in particleSystem.Particles)
            {
                if (particle.IsAlive)
                {
                    Texture2D texture = TextureManager.GetTexture(particle.TextureId);
                    var origin = new Microsoft.Xna.Framework.Vector2(texture.Bounds.Width / 2.0f, texture.Bounds.Height / 2.0f);
                    var position = new Microsoft.Xna.Framework.Vector2(particle.Position.X, particle.Position.Y);
                    var color = new Microsoft.Xna.Framework.Color(particle.Color.PackedValue);
                    spriteBatch.Draw(texture, position, texture.Bounds, color, 0.0f, origin, particle.Size, SpriteEffects.None, 0.0f);
                }
            }
        }
    }
}