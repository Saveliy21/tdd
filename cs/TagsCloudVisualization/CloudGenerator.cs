using System.Drawing;

namespace TagsCloudVisualization;

public static class CloudGenerator
{
    public static List<Rectangle> GenerateRectangles(int count)
    {
        CircularCloudLayouter circularCloudLayouter =
            new CircularCloudLayouter(new Point(CloudLayouterConst.CloudCentreX, CloudLayouterConst.CloudCentreY));
        Random rnd = new Random();
        for (int i = 0; i < count; i++)
        {
            int width = rnd.Next(10, 25);
            int height = rnd.Next(10, 25);
            circularCloudLayouter.PutNextRectangle(new Size(width, height));
        }

        return circularCloudLayouter.GetRectangles();
    }

    public static void DrawRectangles(List<Rectangle> rectangles, string fileName)
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

        bmp.Save(fileName);
    }
}