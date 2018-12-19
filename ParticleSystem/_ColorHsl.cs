//using System;

//namespace ParticleSystem
//{
//    public class ColorHsl
//    {
//        private float _hue;
//        private float _saturation;
//        private float _luminosity;

//        private byte _r;
//        private byte _g;
//        private byte _b;

//        public float Hue { get { return _hue; } } // 0 - 360
//        public float Saturation { get { return _saturation; } } // 0 - 1
//        public float Luminosity { get { return _luminosity; } } // 0 - 1

//        public float R { get { return _r; } }
//        public float G { get { return _g; } }
//        public float B { get { return _b; } }

//        public static ColorHsl Black => new ColorHsl(0.0f, 0.0f, 0.0f);
//        public static ColorHsl White => new ColorHsl(0.0f, 0.0f, 1.0f);
//        public static ColorHsl Red => new ColorHsl(0.0f, 1.0f, 0.5f);
//        public static ColorHsl Lime => new ColorHsl(120.0f, 1.0f, 0.5f);
//        public static ColorHsl Blue => new ColorHsl(240.0f, 1.0f, 0.5f);
//        public static ColorHsl Yellow => new ColorHsl(60.0f, 1.0f, 0.5f);
//        public static ColorHsl Cyan => new ColorHsl(180.0f, 1.0f, 0.5f);

//        public ColorHsl(float hue, float saturation, float luminosity)
//        {
//            _hue = CheckRange(hue, 0.0f, 360.0f);
//            _saturation = CheckRange(saturation, 0.0f, 1.0f);
//            _luminosity = CheckRange(luminosity, 0.0f, 1.0f); ;

//            byte[] rgb = CalculateRgb(hue / 360.0f, saturation, luminosity);
//            _r = rgb[0];
//            _g = rgb[1];
//            _b = rgb[2];
//        }

//        private float CheckRange(float value, float min, float max)
//        {
//            if (value < min)
//                value = min;
//            else if (value > max)
//                value = max;

//            return value;
//        }

//        private byte[] CalculateRgb(float hue, float saturation, float luminosity)
//        {
//            const float ONE_THIRD = 1.0f / 3.0f;

//            float r, g, b;
//            if (saturation == 0.0f)
//            {
//                r = g = b = luminosity;
//            }
//            else
//            {
//                float q = luminosity < 0.5f ? luminosity * (1 + saturation) : luminosity + saturation - luminosity * saturation;
//                float p = 2 * luminosity - q;
//                r = HueToRgb(p, q, hue + ONE_THIRD);
//                g = HueToRgb(p, q, hue);
//                b = HueToRgb(p, q, hue - ONE_THIRD);
//            }

//            var result = new byte[3];
//            result[0] = (byte)Math.Round(r * 255);
//            result[1] = (byte)Math.Round(g * 255);
//            result[2] = (byte)Math.Round(b * 255);

//            return result;
//        }

//        private float HueToRgb(float p, float q, float t)
//        {
//            const float ONE_HALF = 1.0f / 2.0f;
//            const float TWO_THIRDS = 2.0f / 3.0f;
//            const float ONE_SIXTH = 1.0f / 6.0f;

//            if (t < 0.0f) t += 1.0f;
//            if (t > 1.0f) t -= 1.0f;
//            if (t < ONE_SIXTH) return p + (q - p) * 6 * t;
//            if (t < ONE_HALF) return q;
//            if (t < TWO_THIRDS) return p + (q - p) * (TWO_THIRDS - t) * 6;

//            return p;
//        }
//    }
//}