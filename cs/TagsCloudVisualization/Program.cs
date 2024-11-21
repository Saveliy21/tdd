using System.Drawing;
using TagsCloudVisualization;

const string fileName1 = "Rectangles 50.png";
const string fileName2 = "Rectangles 100.png";
const string fileName3 = "Rectangles 400.png";


SaveImages.SaveImage(CloudDrawer.DrawRectangles(GenerateRectangles(50)), fileName1);
SaveImages.SaveImage(CloudDrawer.DrawRectangles(GenerateRectangles(100)), fileName2);
SaveImages.SaveImage(CloudDrawer.DrawRectangles(GenerateRectangles(400)), fileName3);


static List<Rectangle> GenerateRectangles(int count)
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