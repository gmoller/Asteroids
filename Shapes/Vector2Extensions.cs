using System.Numerics;
using GeneralUtilities;

namespace ShapesLibrary
{
    public static class Vector2Extensions
    {
        public static Vector2 ClampOnRectangle(this Vector2 point, Rectangle r)
        {
            Vector2 clamp = new Vector2(point.X.ClampOnRange(new Range<float>(r.Left, r.Right)), point.Y.ClampOnRange(new Range<float>(r.Top, r.Bottom)));

            return clamp;
        }
    }
}