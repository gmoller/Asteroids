using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using AsteroidsGameLibrary.Entities;
using MonogameUtilities;

namespace AsteroidsGame.Renderers
{
    public static class AsteroidRenderer
    {
        public static void Draw(SpriteBatch spriteBatch, Asteroid asteroid)
        {
            for (int i = 0; i < asteroid.Vertices.Count; ++i)
            {
                int v2 = i == asteroid.Vertices.Count - 1 ? 0 : i + 1;

                var position = new Vector2(asteroid.Position.X, asteroid.Position.Y);
                var offset1 = new Vector2(asteroid.Vertices[i].X, asteroid.Vertices[i].Y);
                var offset2 = new Vector2(asteroid.Vertices[v2].X, asteroid.Vertices[v2].Y);
                var color = new Color(asteroid.Color.PackedValue);
                spriteBatch.DrawLine(position + offset1 * asteroid.Size, position + offset2 * asteroid.Size, color);
            }
        }
    }
}