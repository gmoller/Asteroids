using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonogameUtilities
{
    public class Label
    {
        private readonly SpriteFont _spriteFont;

        public Label(SpriteFont spriteFont)
        {
            _spriteFont = spriteFont;
        }

        public void Draw(SpriteBatch spriteBatch, string text, Vector2 position)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(_spriteFont, text, position, Color.Blue, 0.0f, Vector2.Zero, 1.0f, SpriteEffects.None, 0.0f);
            spriteBatch.DrawString(_spriteFont, text, position, Color.White, 0.0f, new Vector2(-5, -5), 1.0f, SpriteEffects.None, 0.0f);
            spriteBatch.End();
        }
    }
}