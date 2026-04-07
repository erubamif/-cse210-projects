class Program
{
    static void Main(string[] args)
    {
        // Test Square
        Square square = new Square("Red", 5);
        Console.WriteLine($"Square Color: {square.GetColor()}, Area: {square.GetArea()}");

        // Test Rectangle
        Rectangle rectangle = new Rectangle("Blue", 4, 6);
        Console.WriteLine($"Rectangle Color: {rectangle.GetColor()}, Area: {rectangle.GetArea()}");

        // Test Circle
        Circle circle = new Circle("Green", 3);
        Console.WriteLine($"Circle Color: {circle.GetColor()}, Area: {circle.GetArea():F2}");

        Console.WriteLine("\n--- Polymorphism in action with List<Shape> ---\n");

        // Create a list of shapes (polymorphism)
        List<Shape> shapes = new List<Shape>();

        shapes.Add(new Square("Yellow", 7));
        shapes.Add(new Rectangle("Purple", 5, 8));
        shapes.Add(new Circle("Orange", 4));

        // Iterate through the list
        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"Shape Color: {shape.GetColor()}, Area: {shape.GetArea():F2}");
        }
    }
}