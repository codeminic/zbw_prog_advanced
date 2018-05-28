using System.Drawing;

namespace Copy.GraphicItem
{
    public interface IShape : IGraphicItem
    {
        Color AreaColor { get; set; }
    }
}