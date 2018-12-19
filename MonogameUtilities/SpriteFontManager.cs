using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace MonogameUtilities
{
    public static class SpriteFontManager
    {
        private static readonly Dictionary<int, SpriteFont> SpriteFonts;

        static SpriteFontManager()
        {
            SpriteFonts = new Dictionary<int, SpriteFont>();
        }

        public static int Add(SpriteFont spriteFont)
        {
            int id = SpriteFonts.Count + 1;

            SpriteFonts.Add(id, spriteFont);

            return id;
        }

        public static SpriteFont GetSpriteFont(int id)
        {
            return SpriteFonts[id];
        }
    }
}