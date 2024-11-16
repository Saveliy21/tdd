using System.Drawing;
using FluentAssertions;
using NUnit.Framework;
using static System.IO.File;

namespace TagsCloudVisualization.TagsCloudVisualizationTests;

public class CloudGeneratorTest
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
        CircularCloudLayouter circularCloudLayouter =
            new CircularCloudLayouter(new Point(CloudLayouterConst.CloudCentreX, CloudLayouterConst.CloudCentreY));
        circularCloudLayouter.PutNextRectangle(new Size(2, 2));
        CloudGenerator.DrawRectangles(circularCloudLayouter.GetRectangles(), FileName);
        Exists(FileName).Should().BeTrue();
    }

    [Test]
    public void GenerateRectangles_ShouldReturnList_WithCorrectSize()
    {
        List<Rectangle> list = CloudGenerator.GenerateRectangles(200);
        list.Should().NotBeNullOrEmpty();
        list.Count.Should().Be(200);
    }
}