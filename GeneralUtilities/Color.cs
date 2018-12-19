namespace GeneralUtilities
{
    public class Color
    {
        public uint PackedValue { get; }
        public byte A => (byte)(PackedValue >> 24);
        public byte B => (byte)(PackedValue >> 16);
        public byte G => (byte)(PackedValue >> 8);
        public byte R => (byte)(PackedValue);

        public static Color Azure => new Color(240, 255, 255, 255);
        public static Color Black => new Color(0, 0, 0, 255);
        public static Color Blue => new Color(0, 0, 255, 255);
        public static Color DarkKhaki => new Color(189, 183, 107, 255);
        public static Color DeepPink => new Color(255, 20, 147, 255);
        public static Color ForestGreen => new Color(34, 139, 34, 255);
        public static Color GhostWhite => new Color(248, 248, 255, 255);
        public static Color HotPink => new Color(255, 105, 180, 255);
        public static Color Khaki => new Color(240, 230, 140, 255);
        public static Color Lavender => new Color(230, 230, 250, 255);
        public static Color OliveDrab => new Color(107, 142, 35, 255);
        public static Color Red => new Color(255, 0, 0, 255);
        public static Color Snow => new Color(255, 250, 250, 255);
        public static Color White => new Color(255, 255, 255, 255); // 0xFFFFFFFF

        public Color(uint packedValue)
        {
            PackedValue = packedValue;
        }

        public Color(byte r, byte g, byte b, byte a = 255)
        {
            PackedValue = 0;
            PackedValue = (PackedValue & 0x00FFFFFF) | ((uint)(a << 24));
            PackedValue = (PackedValue & 0xFF00FFFF) | ((uint)(b << 16));
            PackedValue = (PackedValue & 0xFFFF00FF) | ((uint)(g << 8));
            PackedValue = (PackedValue & 0xFFFFFF00) | r;
        }
    }
}