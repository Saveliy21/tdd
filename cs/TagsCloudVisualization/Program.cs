using TagsCloudVisualization;

const string fileName1 = "Rectangles 50.png";
const string fileName2 = "Rectangles 100.png";
const string fileName3 = "Rectangles 400.png";

CloudGenerator.DrawRectangles(CloudGenerator.GenerateRectangles(50), fileName1);
CloudGenerator.DrawRectangles(CloudGenerator.GenerateRectangles(100), fileName2);
CloudGenerator.DrawRectangles(CloudGenerator.GenerateRectangles(400), fileName3);