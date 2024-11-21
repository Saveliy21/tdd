using System.Drawing;

namespace TagsCloudVisualization;

public static class CloudDrawer
{
    public static Bitmap DrawRectangles(List<Rectangle> rectangles)
    {
        Bitmap bmp = new Bitmap(1000, 1000);
        Graphics newGraphics = Graphics.FromImage(bmp);
        var backgroundBrush = new SolidBrush(Color.White);
        var rectanglePen = new Pen(Color.Black);
        newGraphics.FillRectangle(backgroundBrush, 0, 0, 1000, 1000);
        foreach (var rectangle in rectangles)
        {
            newGraphics.DrawRectangle(rectanglePen, rectangle);
        }

        newGraphics.Dispose();
        return bmp;
    }
}