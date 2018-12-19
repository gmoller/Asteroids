using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace MonogameUtilities
{
    public static class SpriteFontManager
    {
        private static Dictionary<int, SpriteFont> _spriteFonts;

        static SpriteFontManager()
        {
            _spriteFonts = new Dictionary<int, SpriteFont>();
        }

        public static int Add(SpriteFont spriteFont)
        {
            int id = _spriteFonts.Count + 1;

            _spriteFonts.Add(id, spriteFont);

            return id;
        }

        public static SpriteFont GetSpriteFont(int id)
        {
            return _spriteFonts[id];
        }
    }
}