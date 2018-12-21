using System;
using System.Numerics;
using System.Text.RegularExpressions;

namespace GeneralUtilities
{
    public static class Vector2Extensions
    {
        public static Vector2 Project(this Vector2 v, Vector2 onto)
        {
            float d = onto.Dot(onto);
            if (d > 0)
            {
                float dp = v.Dot(onto);

                return onto * dp / d;
            }

            return onto;
        }

        public static Vector2 Unit(this Vector2 v)
        {
            float length = v.Length();
            if (length > 0)
            {
                return v / length;
            }

            return v;
        }

        public static Vector2 Rotate(this Vector2 v, float degrees)
        {
            double radians = degrees.ToRadians();
            double sin = Math.Sin(radians);
            double cos = Math.Cos(radians);

            Vector2 r = new Vector2((float)(v.X * cos - v.Y * sin), (float)(v.X * sin + v.Y * cos));

            return r;
        }

        public static Vector2 Rotate90(this Vector2 v)
        {
            Vector2 r = new Vector2(-v.Y, v.X);

            return r;
        }

        public static Vector2 RotateAroundPoint(this Vector2 point, Vector2 center, float angleAsRadians)
        {
            double rotatedX = Math.Cos(angleAsRadians) * (point.X - center.X) - Math.Sin(angleAsRadians) * (point.Y - center.Y) + center.X;
            double rotatedY = Math.Sin(angleAsRadians) * (point.X - center.X) + Math.Cos(angleAsRadians) * (point.Y - center.Y) + center.Y;

            return new Vector2((float)rotatedX, (float)rotatedY);
        }

        public static float Dot(this Vector2 v, Vector2 v2)
        {
            return Vector2.Dot(v, v2);
            //float r = (v.X * v2.X) + (v.Y * v2.Y);
        }

        public static bool Parallel(this Vector2 v, Vector2 v2)
        {
            Vector2 na = v.Rotate90();
            float dotProduct = na.Dot(v2);

            return dotProduct.ApproximatelyEquals(0.0f);
        }

        public static Vector2 Lerp(this Vector2 v, Vector2 v2, float x)
        {
            return Vector2.Lerp(v, v2, x);
        }

        public static float ToAngleAsRadians(this Vector2 v)
        {
            double d = Math.Atan2(v.X, v.Y);

            return (float)d;
        }
    }

    public static class FloatExtensions
    {
        public static bool ApproximatelyEquals(this float a, float b)
        {
            float threshold = 1.0f / 8192.0f;
            float f = Math.Abs(a - b);

            return f < threshold;
        }

        public static float ToRadians(this float degrees)
        {
            double r = degrees * Math.PI / 180.0f;

            return (float)r;
        }

        public static float ToDegrees(this float radians)
        {
            double d = radians * 180.0f / Math.PI;

            return (float)d;
        }

        public static float ClampOnRange(this float f, Range<float> range)
        {
            if (f < range.Minimum) return range.Minimum;
            if (range.Maximum < f) return range.Maximum;

            return f;
        }

        public static Vector2 RadiansToHeadingVector2(this float f)
        {
            return new Vector2((float)Math.Cos(f), (float)Math.Sin(f));
        }
    }

    public static class IntExtensions
    {
        public static float ToRadians(this int degrees)
        {
            double r = degrees * Math.PI / 180.0f;

            return (float)r;
        }
    }
}