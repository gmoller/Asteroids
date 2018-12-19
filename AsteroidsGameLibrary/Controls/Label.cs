using System.Numerics;

namespace AsteroidsGameLibrary.Controls
{
    public class Label
    {
        public HorizontalAlignment HorizontalAlignment { get; }
        public VerticalAlignment VerticalAlignment { get; }
        public string Text { get; }
        public Vector2 Position { get; }

        public Label(Vector2 position, string text, HorizontalAlignment horizontalAlignment = HorizontalAlignment.Left, VerticalAlignment verticalAlignment = VerticalAlignment.Top)
        {
            Position = position;
            Text = text;
            HorizontalAlignment = horizontalAlignment;
            VerticalAlignment = verticalAlignment;
        }
    }

    public enum HorizontalAlignment
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