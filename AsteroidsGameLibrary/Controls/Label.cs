using System.Numerics;

namespace AsteroidsGameLibrary.Controls
{
    public class Label
    {
        public HorizontAlignment HorizontAlignment { get; }
        public VerticalAlignment VerticalAlignment { get; }
        public string Text { get; }
        public Vector2 Position { get; }

        public Label(Vector2 position, string text, HorizontAlignment horizontAlignment = HorizontAlignment.Left, VerticalAlignment verticalAlignment = VerticalAlignment.Top)
        {
            Position = position;
            Text = text;
            HorizontAlignment = horizontAlignment;
            VerticalAlignment = verticalAlignment;
        }
    }

    public enum HorizontAlignment
    {
        Left,
        Center,
        Right
    }

    public enum VerticalAlignment
    {
        Top,
        Center,
        Bottom
    }
}