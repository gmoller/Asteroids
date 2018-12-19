using System;
using Microsoft.Xna.Framework;

namespace MonogameUtilities
{
    public static class Vector2Extensions
    {
        public static float Angle(this Vector2 v)
        {
            return (float)Math.Atan2(v.Y, v.X);
        }

        public static Vector2 RotateAroundPoint(this Vector2 point, Vector2 center, float angleAsRadians)
        {
            double rotatedX = Math.Cos(angleAsRadians) * (point.X - center.X) - Math.Sin(angleAsRadians) * (point.Y - center.Y) + center.X;
            double rotatedY = Math.Sin(angleAsRadians) * (point.X - center.X) + Math.Cos(angleAsRadians) * (point.Y - center.Y) + center.Y;

            return new Vector2((float)rotatedX, (float)rotatedY);
        }
    }
}