using System.Drawing;

namespace TagsCloudVisualization;

public class CircularCloudLayouter : ICircularCloudLayouter
{
    private readonly Point center;
    private List<Rectangle> rectangles;
    private Spiral spiral;

    public CircularCloudLayouter(Point center)
    {
        this.center = center;
        rectangles = new List<Rectangle>();
        spiral = new Spiral(center);
    }

    public Rectangle PutNextRectangle(Size rectangleSize)
    {
        Rectangle rectangle;
        if (rectangleSize.Width < 0 || rectangleSize.Height < 0)
        {
            throw new ArgumentException($"Rectangle size ({rectangleSize}) should be positive");
        }

        do
        {
            Point point = spiral.getNextPointOnSpiral();
            point.Offset(-rectangleSize.Width / 2, -rectangleSize.Height / 2);
            rectangle = new Rectangle(point, rectangleSize);
        } while (rectangles.Any(r => r.IntersectsWith(rectangle)));

        rectangles.Add(rectangle);
        return rectangle;
    }

    public List<Rectangle> GetRectangles()
    {
        return rectangles;
    }
}