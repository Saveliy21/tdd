using System.Drawing;

namespace TagsCloudVisualization;

public class SaveImages
{
    public static void SaveImage(Bitmap bmp, string fileName)
    {
        bmp.Save(fileName);
    }
}