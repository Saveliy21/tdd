using System.Drawing;

namespace TagsCloudVisualization;

public static class CloudDrawer
{
    public static Bitmap DrawRectangles(List<Rectangle> rectangles, Size size)
    { 
        var bmp = new Bitmap(size.Width, size.Height);
        using var newGraphics = Graphics.FromImage(bmp);
        using var backgroundBrush = new SolidBrush(Color.White);
        using var rectanglePen = new Pen(Color.Black);
        newGraphics.FillRectangle(backgroundBrush, 0, 0, size.Width, size.Height);
        foreach (var rectangle in rectangles)
        {
            newGraphics.DrawRectangle(rectanglePen, rectangle);
        }
        return bmp;
    }
}