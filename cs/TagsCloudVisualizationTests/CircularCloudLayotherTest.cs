using System.Drawing;
using FluentAssertions;
using NUnit.Framework;

namespace TagsCloudVisualization.TagsCloudVisualizationTests;

public class CircularCloudLayotherTest
{
    private CircularCloudLayouter _circularCloudLayouter;

    [SetUp]
    public void SetUp()
    {
        _circularCloudLayouter = new CircularCloudLayouter(new Point());
    }

    [TestCase(-2, 3, TestName = "Negative width")]
    [TestCase(2, -3, TestName = "Negative height")]
    [TestCase(0, 0, TestName = "zero width and height")]
    [TestCase(-2, -3, TestName = "Negative weight and height")]
    public void PutNextRectangle_ShouldThrowArgumentException_WithNegativeInput(int width, int height)
    {
        Action action = () => new CircularCloudLayouter(new Point()).PutNextRectangle(new Size(width, height));
        action.Should().Throw<ArgumentException>();
    }
    
    [TestCase(2, 3, TestName = "positive width and height")]
    public void PutNextRectangle_ShouldNotThrowArgumentException_WithCorrectInput(int width, int height)
    {
        Action action = () => new CircularCloudLayouter(new Point()).PutNextRectangle(new Size(width, height));
        action.Should().NotThrow<ArgumentException>();
    }

    [Test]
    public void PutNextRectangle_ShouldAddNewRectangle()
    {
        _circularCloudLayouter.PutNextRectangle(new Size(2, 2));
        _circularCloudLayouter.GetRectangles().Should().NotBeEmpty();
        _circularCloudLayouter.GetRectangles().Should().Contain(new Rectangle(-1, -1, 2, 2));
    }
    
    [Test]
    public void CircularCloudLayouter_RectAngelsListShouldHaveCorrectSize()
    {
        _circularCloudLayouter.PutNextRectangle(new Size(2, 2));
        _circularCloudLayouter.PutNextRectangle(new Size(2, 2));
        _circularCloudLayouter.PutNextRectangle(new Size(2, 2));
        _circularCloudLayouter.GetRectangles().Count.Should().Be(3);
    }

    [Test]
    public void CircularCloudLayouter_RectAngelsShouldNoIntersectsWithOthers()
    {
        Random rnd = new Random();
        for (int i = 0; i < 100; i++)
        {
            int width = rnd.Next(1, 10);
            int height = rnd.Next(1, 10);
            _circularCloudLayouter.PutNextRectangle(new Size(width, height));
        }

        List<Rectangle> rectangels = _circularCloudLayouter.GetRectangles();
        foreach (Rectangle rectangle in rectangels)
        {
            rectangels.Where((_, j) => j != rectangels.IndexOf(rectangle))
                .All(r => !r.IntersectsWith(rectangle))
                .Should().BeTrue();
        }
    }

    [Test, MaxTime(5000)]
    public void CircularCloudLayouter_ShouldWorkInTime()
    {
        Random rnd = new Random();
        for (int i = 0; i < 10000; i++)
        {
            int width = rnd.Next(1, 10);
            int height = rnd.Next(1, 10);
            _circularCloudLayouter.PutNextRectangle(new Size(width, height));
        }
    }
}