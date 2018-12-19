using System.Numerics;

namespace AsteroidsGameLibrary
{
    public static class Helper
    {
        public static Vector2 WrapAround(Vector2 position, Vector2 resolution)
        {
            Vector2 pos = position;

            if (pos.X < 0)
            {
                pos = new Vector2(resolution.X, pos.Y);
            }
            if (pos.X > resolution.X)
            {
                pos = new Vector2(0, pos.Y);
            }

            if (pos.Y < 0)
            {
                pos = new Vector2(pos.X, resolution.Y);
            }
            if (pos.Y > resolution.Y)
            {
                pos = new Vector2(pos.X, 0);
            }

            return pos;
        }
    }
}