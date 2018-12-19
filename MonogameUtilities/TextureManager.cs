using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace MonogameUtilities
{
    public static class TextureManager
    {
        private static Dictionary<int, Texture2D> _textures;

        static TextureManager()
        {
            _textures = new Dictionary<int, Texture2D>();
        }

        public static int Add(Texture2D texture)
        {
            int id = _textures.Count + 1;

            _textures.Add(id, texture);

            return id;
        }

        public static Texture2D GetTexture(int id)
        {
            return _textures[id];
        }
    }
}