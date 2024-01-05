// See https://aka.ms/new-console-template for more information
using Geometry.Model;

Console.WriteLine("Hello, World!");


// IMesurable1D m = null;
// Form f = null;
IList<Point> points = new List<Point>() {
    new() { Name = "O", X = 0.0, Y = 0.0 },
    new() { Name = "A", X = 3.0, Y = 0.0 },
    new() { Name = "B", X = 0.0, Y = 4.0 },
    new() { Name = "D", X = 5.25, Y = 3.5 },
};

IList<Form> forms = new List<Form>(points);

foreach (Point p in points)
{
    Console.WriteLine(p);
    Console.WriteLine($"{p.Name}, {p.X}, {p.Y}");
    Console.WriteLine();
}

points[^1].Y = 12.75;
Console.WriteLine(points[^1]);

Circle circleC1 = new()
{
    Name = "C1",
    Center = points[0],
    Radius = 10.0,
};
forms.Add(circleC1);

Console.WriteLine();
foreach (var form in forms) 
{
    Console.WriteLine(form);
}
