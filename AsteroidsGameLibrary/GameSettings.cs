using GeneralUtilities;
using System.Numerics;

namespace AsteroidsGameLibrary
{
    public static class GameSettings
    {
        public static Vector2 Resolution { get; set; }
        public static Color BackgroundColor { get; set;}

        public static int Lives { get; set; }
        public static int Score { get; set; }
        public static bool ShowCollisionBoundaries { get; set; }
    }
}