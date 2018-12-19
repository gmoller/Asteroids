using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace MonogameUtilities
{
    public static class TextureManager
    {
        private static readonly Dictionary<int, Texture2D> Textures;

        static TextureManager()
        {
            Textures = new Dictionary<int, Texture2D>();
        }

        public static int Add(Texture2D texture)
        {
            int id = Textures.Count + 1;

            Textures.Add(id, texture);

            return id;
        }

        public static Texture2D GetTexture(int id)
        {
            return Textures[id];
        }
    }
}