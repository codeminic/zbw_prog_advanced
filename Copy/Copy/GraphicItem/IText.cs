using System.Drawing;

namespace Copy.GraphicItem
{
    public interface IText : IGraphicItem
    {
        string Text { get; }

        Color TextColor { get; }
    }
}