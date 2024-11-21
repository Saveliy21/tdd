using System.Drawing;
using FluentAssertions;
using NUnit.Framework;
using static System.IO.File;

namespace TagsCloudVisualization.TagsCloudVisualizationTests;

public class CloudDrawerTest
{
    private const string FileName = "Picture.png";

    [TearDown]
    public void TearDown()
    {
        if (Exists(FileName))
        {
            Delete(FileName);
        }
    }

    [Test]
    public void DrawRectangles_ShouldDrawImage()
    {
        List<Rectangle> rectangles = new List<Rectangle>();
        rectangles.Add(new Rectangle(500, 500, 100, 100));
        SaveImages.SaveImage(CloudDrawer.DrawRectangles(rectangles), FileName);
        Exists(FileName).Should().BeTrue();
    }
}