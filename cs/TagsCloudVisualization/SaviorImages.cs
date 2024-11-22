using System.Drawing;

namespace TagsCloudVisualization;

public class SaviorImages
{
    public static void SaveImage(Bitmap bmp, string fileName)
    {
        bmp.Save(fileName);
    }
}