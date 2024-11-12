using System.Drawing;

namespace TagsCloudVisualization;

public class Spiral
{
    private readonly Point center;
    private readonly int angleStep;
    private double angle;


    public Spiral(Point center, int angleStep = 1)
    {
        this.center = center;
        this.angleStep = angleStep;
        angle = 0;
    }

    public Point getNextPointOnSpiral()
    {
        angle += angleStep;
        var x = (int) (center.X + angle * Math.Cos(angle));
        var y = (int) (center.Y + angle * Math.Sin(angle));
        return new Point(x, y);
    }
}