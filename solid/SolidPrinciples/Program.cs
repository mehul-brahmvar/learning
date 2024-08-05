using SolidPrinciples;

//Single responsiblity principle

// Open closed principle

// Liskov's substitution principle

//Interface segregation principle

// Dependency Inversion principle

I2DShape circle = new Circle(10);
Console.WriteLine(circle.GetArea());

I2DShape rectangle = new Rectangle(10, 20);
Console.WriteLine(rectangle.GetArea());

I3DShape cube = new Cube(10);
Console.WriteLine(cube.GetVolume());

IPrinter printer = new Printer();
printer.Print(circle);
printer.Print(rectangle);
printer.Print(cube);
