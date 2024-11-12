using System.Drawing;
using FluentAssertions;
using NUnit.Framework;

namespace TagsCloudVisualization.TagsCloudVisualizationTests;

public class SpiralTest
{
    [Test]
    public void getNextPointOnSpiral_ShouldReturnNextPointOnSpiral()
    {
        Spiral spiral = new Spiral(new Point(0, 0));
        Point point = new Point();
        for (int i = 0; i < 2; i++)
        {
            point = spiral.getNextPointOnSpiral();
        }

        point.Should().Be(new Point(0, 1));
    }
}