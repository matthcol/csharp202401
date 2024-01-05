// See https://aka.ms/new-console-template for more information
using Geometry.Extension;
using Geometry.Model;

Console.WriteLine("Hello, World!");


// IMesurable1D m = null;
// Form f = null;
IList<Point> points = new List<Point>() {
    new() { Name = "O", X = 0.0, Y = 0.0 },
    new() { Name = "A", X = 3.0, Y = 0.0 },
    new() { Name = "B", X = 0.0, Y = 4.0 },
    new() { Name = "D", X = 5.25, Y = 3.5 },
    new() { Name = "E", X = -5.25, Y = 3.5 },
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

Polygon poly1 = new("P1", [points[0], points[1], points[2]]);
Console.WriteLine(poly1);
forms.Add(poly1);


try
{
    Polygon p2 = new("?", [points[3]]);
} 
catch (ArgumentException ex)
{
    Console.WriteLine("Not possible ;)");
}


// surface totale de toutes les formes IMesurable2D
foreach (var form in forms)
{
    if (form is IMesurable2D m)
    {
        double area= m.Area;
        Console.WriteLine($"{form} is IMesurable2D, has area {area}");
    }
}

// Where: Form IMesurable2D
// Select: Form => Area
// Final: Sum
double totalArea = forms.Where(f => f is not null and IMesurable2D)
    .Select(f => f as IMesurable2D)
    .Sum(m => m!.Area);
Console.WriteLine(totalArea);

// Pattern matching (switch or is)
// https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/pattern-matching
foreach (var point in points)
{
    switch (point)
    {
        case { Name: "O"}:
            Console.WriteLine($"Point O: {point}");
            break;
        case
        {
            Name: var name,
            X: < 0.0
        }:
            Console.WriteLine($"Point with negative X: {name}");
            break;
        case { 
            X: var x, 
            Y: >= 1.0 and <= 5.0
        }:
            Console.WriteLine($"Point with Y in [0..5] and X={x}: {point}");
            break;
        case {
            X: var x,
            Y: var y,
        } when x > Math.Pow(y,2):
                Console.WriteLine($"Point with X linked to Y: {point}");
            break;

    }
}

Comparison<Point> cmp = (p1, p2) =>  (int) (p1.X - p2.X);
Func<Point, Point, int> cmp2 = (p1, p2) => (int)(p1.X - p2.X);

var pointSample = poly1.Where(p => p.X > 0.0)
    .ToList();
foreach (var item in pointSample)
{
    Console.WriteLine(item);
}

poly1.Translate(1.0, -1.0);
var names = String.Join('-',
    poly1.Where(p => p.X > 0.0)
    .Select(p => p.Name)
);
Console.WriteLine(names);


//p1.Summits.Where(p => p.X > 0)
//    .ToList();

var pointA = points[1];
pointA += 2;
var pointA2 = pointA + 3;
Console.WriteLine($"{pointA}, {pointA2}");

var summit = poly1[0];
Console.WriteLine(summit);
poly1[1] = points[^1];