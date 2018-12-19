using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using AsteroidsGameLibrary;
using MonogameUtilities;

namespace AsteroidsGame.Renderers
{
    public static class HudRenderer
    {
        public static void Draw(SpriteBatch spriteBatch, Hud _hud)
        {
            SpriteFont spriteFont = SpriteFontManager.GetSpriteFont(_hud.SpriteFontId);

            Label lblScore = new Label(spriteFont);
            Vector2 position = DetermineLabelPosition(_hud.ScoreLabel, spriteFont);
            lblScore.Draw(spriteBatch, _hud.ScoreLabel.Text, position);

            Label lblLives = new Label(spriteFont);
            position = DetermineLabelPosition(_hud.LivesLabel, spriteFont);
            lblLives.Draw(spriteBatch, _hud.LivesLabel.Text, position);
        }

        private static Vector2 DetermineLabelPosition(AsteroidsGameLibrary.Controls.Label label, SpriteFont spriteFont)
        {
            float x;
            float y;

            switch (label.HorizontAlignment)
            {
                case AsteroidsGameLibrary.Controls.HorizontAlignment.Left:
                    x = label.Position.X;
                    break;
                case AsteroidsGameLibrary.Controls.HorizontAlignment.Center:
                    Vector2 size = spriteFont.MeasureString(label.Text);
                    x = label.Position.X - size.X * Constants.ONE_HALF;
                    break;
                case AsteroidsGameLibrary.Controls.HorizontAlignment.Right:
                    size = spriteFont.MeasureString(label.Text);
                    x = label.Position.X - size.X;
                    break;
                default:
                    throw new NotImplementedException($"Label.HorizontAlignment [{label.HorizontAlignment}] not implemented.");
            }

            switch (label.VerticalAlignment)
            {
                case AsteroidsGameLibrary.Controls.VerticalAlignment.Top:
                    y = label.Position.Y;
                    break;
                case AsteroidsGameLibrary.Controls.VerticalAlignment.Center:
                    Vector2 size = spriteFont.MeasureString(label.Text);
                    y = label.Position.Y - size.Y * Constants.ONE_HALF;
                    break;
                case AsteroidsGameLibrary.Controls.VerticalAlignment.Bottom:
                    size = spriteFont.MeasureString(label.Text);
                    y = label.Position.Y - size.Y;
                    break;
                default:
                    throw new NotImplementedException($"Label.VerticalAlignment [{label.VerticalAlignment}] not implemented.");
            }

            var position = new Vector2(x, y);

            return position;
        }
    }
}