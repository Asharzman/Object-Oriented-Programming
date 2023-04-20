namespace Door_Factory
{
    class Window
    {
        private const double WoodThickness = 0.05; // meters
        private const double GlassThickness = 0.005; // meters

        public double Width { get; }
        public double Height { get; }

        public Window(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public double CalculateArea()
        {
            return Width * Height;
        }

        public double CalculateCircumference()
        {
            return 2 * (Width + Height);
        }

        public double CalculateWoodUsage()
        {
            // The total wood usage is the perimeter of the window frame
            // multiplied by the thickness of the wood
            double perimeter = CalculateCircumference();
            return perimeter * WoodThickness;
        }

        public double CalculateGlassUsage()
        {
            // The total glass usage is the area of the window frame
            // multiplied by the number of glass layers and the thickness of the glass
            double area = CalculateArea();
            return 3 * area * GlassThickness;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Ask the user for the window dimensions
            Console.Write("Enter the width of the window (m): ");
            double width = double.Parse(Console.ReadLine());

            Console.Write("Enter the height of the window (m): ");
            double height = double.Parse(Console.ReadLine());

            // Create a new window object
            Window window = new Window(width, height);

            // Calculate and print the window properties
            Console.WriteLine($"Window area: {window.CalculateArea()} m²");
            Console.WriteLine($"Window circumference: {window.CalculateCircumference()} m");
            Console.WriteLine($"Wood usage: {window.CalculateWoodUsage()} m²");
            Console.WriteLine($"Glass usage: {window.CalculateGlassUsage()} m²");
        }
    }
}