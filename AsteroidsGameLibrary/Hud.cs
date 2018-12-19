using AsteroidsGameLibrary.Controls;

namespace AsteroidsGameLibrary
{
    public class Hud
    {
        public Label LivesLabel { get; set; }
        public Label ScoreLabel { get; set; }

        public int SpriteFontId { get; }

        public Hud(int spriteFontId)
        {
            SpriteFontId = spriteFontId;
        }
    }
}