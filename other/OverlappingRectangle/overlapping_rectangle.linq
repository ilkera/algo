<Query Kind="Program" />

/* Problem: Overlapping Rectangle

Given two axis-aligned rectangles A and B. Write a function to determine if the two rectangles overlap.

*/
void Main()
{
       Rectangle r1 = new Rectangle( 10, 20, 10, 20);
       Rectangle r2 = new Rectangle( 15, 10, 15, 20);
       
       Console.WriteLine( "Overlaps? : {0}", RectangleOverlap.IsOverlapping(r1,r2));
}

public class RectangleOverlap
{
        public static bool IsOverlapping(Rectangle first, Rectangle second)
       {
               bool xOverlap = IsValueInRange(first.X, second.X, second.X + second.Width) ||
                                         IsValueInRange(second.X, first.X, first.X + first.Width);
                                         
               bool yOverlap = IsValueInRange(first.Y, second.Y, second.Y + second.Height) ||
                                         IsValueInRange(second.Y, first.Y, first.Y + first.Height);
                                         
               return xOverlap && yOverlap;
       }
       
        private static bool IsValueInRange( int value, int min, int max)
       {
               return value >= min && value <= max;
       }
}


public class Rectangle
{
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
       
        public Rectangle( int x, int y, int width, int height)
       {
              X = x;
              Y = y;
              Height = height;
              Width = width;
       }
}
