using System;

namespace GeneralUtilities
{
    public static class RandomHelper
    {
        private static Random Rand = new Random(); // For generating pseudo-random numbers

        public static float RandomNumber(float min, float max)
        {
            if (min > max) throw new Exception("Min must be less than or equal to max.");

            return min + ((max - min) * (float)(Rand.NextDouble()));
        }

        public static byte RandomNumber(byte min, byte max)
        {
            if (min > max) throw new Exception("Min must be less than or equal to max.");

            byte o1 = (byte)(max - min + 1);
            byte o2 = (byte)Rand.Next(0, o1);
            byte o3 = (byte)(o2 + min);

            return o3;
        }

        public static int RandomNumber(int min, int max)
        {
            if (min > max) throw new Exception("Min must be less than or equal to max.");

            int o1 = max - min + 1;
            int o2 = Rand.Next(0, o1);
            int o3 = o2 + min;

            return o3;
        }

        public static byte[] NextBytes(int numberOfBytes)
        {
            var b = new byte[numberOfBytes];
            Rand.NextBytes(b);

            return b;
        }
    }
}