using System.Drawing;
using FluentAssertions;
using NUnit.Framework;

namespace TagsCloudVisualization.TagsCloudVisualizationTests;

public class SpiralTest
{
    private Spiral _spiral;

    [SetUp]
    public void Setup()
    {
        _spiral = new Spiral(new Point(0, 0));
    }

    [Test]
    public void getNextPointOnSpiral_ShouldReturnNextPointOnSpiral()
    {
        Point point = new Point();
        for (int i = 0; i < 2; i++)
        {
            point = _spiral.GetNextPointOnSpiral();
        }

        point.Should().Be(new Point(0, 1));
    }

    [Test]
    public void GetNextPointOnSpiral_ShouldReturnPointsOnSpiral()
    {
        List<Point> expected = new List<Point>
        {
            new Point(0, 0), new Point(0, 1), new Point(-2, 0), new Point(-2, -3), new Point(1, -4),
            new Point(5, -1), new Point(5, 4), new Point(-1, 7)
        };
        List<Point> points = new List<Point>();
        for (int i = 0; i < 8; i++)
        {
            points.Add(_spiral.GetNextPointOnSpiral());
        }

        points.Should().BeEquivalentTo(expected);
    }
}