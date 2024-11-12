using System.Drawing;
using FluentAssertions;
using NUnit.Framework;

namespace TagsCloudVisualization.TagsCloudVisualizationTests;

public class CircularCloudLayotherTest
{
    [TestCase(-2, 3, TestName = "Negative width")]
    [TestCase(-2, 3, TestName = "Negative height")]
    [TestCase(-2, -3, TestName = "Negative weight and height")]
    public void PutNextRectangle_ShouldThrowArgumentException_WithNegativeInput(int width, int height)
    {
        Action action = () => new CircularCloudLayouter(new Point()).PutNextRectangle(new Size(width, height));
        action.Should().Throw<ArgumentException>();
    }

    [TestCase(0, 0, TestName = "zero width and height")]
    [TestCase(2, 3, TestName = "positive width and height")]
    public void PutNextRectangle_ShouldNotThrowArgumentException_WithCorrectInput(int width, int height)
    {
        Action action = () => new CircularCloudLayouter(new Point()).PutNextRectangle(new Size(width, height));
        action.Should().NotThrow<ArgumentException>();
    }

    [Test]
    public void PutNextRectangle_ShouldAddNewRectangle()
    {
        CircularCloudLayouter circularCloudLayouter = new CircularCloudLayouter(new Point());
        circularCloudLayouter.PutNextRectangle(new Size(2, 2));
        circularCloudLayouter.GetRectangles().Should().NotBeEmpty();
    }

    [Test]
    public void PutNextRectangle_ShouldContainsNewRectangle()
    {
        CircularCloudLayouter circularCloudLayouter = new CircularCloudLayouter(new Point());
        circularCloudLayouter.PutNextRectangle(new Size(2, 2));
        circularCloudLayouter.GetRectangles().Should().Contain(new Rectangle(-1, -1, 2, 2));
    }

    [Test]
    public void PutNextRectangle_ShouldHaveCorrectSize()
    {
        CircularCloudLayouter circularCloudLayouter = new CircularCloudLayouter(new Point());
        circularCloudLayouter.PutNextRectangle(new Size(2, 2));
        circularCloudLayouter.PutNextRectangle(new Size(2, 2));
        circularCloudLayouter.PutNextRectangle(new Size(2, 2));
        circularCloudLayouter.GetRectangles().Count.Should().Be(3);
    }

    [Test]
    public void CircularCloudLayouter_RectAngelsShouldNoIntersectsWithOthers()
    {
        CircularCloudLayouter circularCloudLayouter = new CircularCloudLayouter(new Point());
        circularCloudLayouter.PutNextRectangle(new Size(1, 3));
        circularCloudLayouter.PutNextRectangle(new Size(3, 4));
        circularCloudLayouter.PutNextRectangle(new Size(4, 2));
        List<Rectangle> rectangels = circularCloudLayouter.GetRectangles();
        foreach (Rectangle rectangle in rectangels)
        {
            rectangels.Where((_, j) => j != rectangels.IndexOf(rectangle)).All(r => !r.IntersectsWith(rectangle))
                .Should().BeTrue();
        }
    }
}